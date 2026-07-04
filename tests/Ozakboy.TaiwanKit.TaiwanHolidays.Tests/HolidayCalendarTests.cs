using System;
using System.Linq;
using Xunit;

namespace Ozakboy.TaiwanKit.TaiwanHolidays.Tests
{
    public class HolidayCalendarTests
    {
        // ---- 範圍與邊界 / Range and boundaries ----

        [Fact]
        public void MinDateMaxDate_MatchCoverage()
        {
            Assert.Equal(new DateTime(2017, 1, 1), HolidayCalendar.MinDate);
            Assert.Equal(new DateTime(2027, 12, 31), HolidayCalendar.MaxDate);
            Assert.Equal(11, HolidayCalendar.SupportedYears.Count);
            Assert.Equal(2017, HolidayCalendar.SupportedYears[0]);
            Assert.Equal(2027, HolidayCalendar.SupportedYears[10]);
        }

        [Fact]
        public void GetDayInfo_BoundaryDays_Work()
        {
            Assert.NotNull(HolidayCalendar.GetDayInfo(HolidayCalendar.MinDate));
            Assert.NotNull(HolidayCalendar.GetDayInfo(HolidayCalendar.MaxDate));
        }

        [Theory]
        [InlineData(2016, 12, 31)]
        [InlineData(2028, 1, 1)]
        public void GetDayInfo_OutOfRange_Throws(int year, int month, int day)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => HolidayCalendar.GetDayInfo(new DateTime(year, month, day)));
            Assert.Throws<ArgumentOutOfRangeException>(() => HolidayCalendar.IsHoliday(new DateTime(year, month, day)));
        }

        [Fact]
        public void TryGetDayInfo_OutOfRange_ReturnsFalse()
        {
            bool ok = HolidayCalendar.TryGetDayInfo(new DateTime(2030, 1, 1), out TaiwanDayInfo? info);

            Assert.False(ok);
            Assert.Null(info);
        }

        [Fact]
        public void TryGetDayInfo_InRange_ReturnsTrue()
        {
            bool ok = HolidayCalendar.TryGetDayInfo(new DateTime(2026, 10, 10), out TaiwanDayInfo? info);

            Assert.True(ok);
            Assert.NotNull(info);
            Assert.Equal("國慶日", info!.Name);
        }

        [Theory]
        [InlineData(2016)]
        [InlineData(2028)]
        public void GetHolidays_OutOfRangeYear_Throws(int year)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => HolidayCalendar.GetHolidays(year));
        }

        // ---- 時間部分忽略 / Time component ignored ----

        [Fact]
        public void GetDayInfo_TimeComponent_Ignored()
        {
            Assert.True(HolidayCalendar.IsHoliday(new DateTime(2026, 10, 10, 23, 59, 59)));
        }

        // ---- 下一個/上一個工作日 / Next and previous workday ----

        [Fact]
        public void GetNextWorkday_AcrossLunarNewYear2026()
        {
            // 2026 春節連假：2/14(六)～2/22(日)，2/13(五) 之後的下一個工作日是 2/23(一)
            Assert.Equal(new DateTime(2026, 2, 23), HolidayCalendar.GetNextWorkday(new DateTime(2026, 2, 13)));
        }

        [Fact]
        public void GetPreviousWorkday_AcrossLunarNewYear2026()
        {
            Assert.Equal(new DateTime(2026, 2, 13), HolidayCalendar.GetPreviousWorkday(new DateTime(2026, 2, 23)));
        }

        [Fact]
        public void GetNextWorkday_PlainWeek_ReturnsTomorrow()
        {
            // 2026-03-03（二）→ 3/4（三）
            Assert.Equal(new DateTime(2026, 3, 4), HolidayCalendar.GetNextWorkday(new DateTime(2026, 3, 3)));
        }

        // ---- 區間工作日 / Workday counting ----

        [Fact]
        public void CountWorkdays_AcrossLunarNewYear2026()
        {
            // 2/13(五) 與 2/23(一) 為工作日，中間 2/14～2/22 全放假
            Assert.Equal(2, HolidayCalendar.CountWorkdays(new DateTime(2026, 2, 13), new DateTime(2026, 2, 23)));
        }

        [Fact]
        public void CountWorkdays_SingleWorkday_ReturnsOne()
        {
            Assert.Equal(1, HolidayCalendar.CountWorkdays(new DateTime(2026, 3, 3), new DateTime(2026, 3, 3)));
        }

        [Fact]
        public void CountWorkdays_FromLaterThanTo_Throws()
        {
            Assert.Throws<ArgumentException>(() => HolidayCalendar.CountWorkdays(new DateTime(2026, 3, 4), new DateTime(2026, 3, 3)));
        }

        [Fact]
        public void CountWorkdays_MakeupWorkdaySaturday_Counted()
        {
            // 2023-01-07（六）補行上班，區間 1/7～1/8 應有 1 個工作日
            Assert.Equal(1, HolidayCalendar.CountWorkdays(new DateTime(2023, 1, 7), new DateTime(2023, 1, 8)));
        }

        // ---- 連假查詢 / Holiday periods ----

        [Fact]
        public void GetHolidayPeriods_2026_LunarNewYear9Days()
        {
            var periods = HolidayCalendar.GetHolidayPeriods(2026);
            HolidayPeriod cny = periods.Single(p => p.Start == new DateTime(2026, 2, 14));

            Assert.Equal(new DateTime(2026, 2, 22), cny.End);
            Assert.Equal(9, cny.TotalDays);
            Assert.Equal("春節", cny.Name);
            Assert.Equal("Lunar New Year", cny.EnglishName);
        }

        [Fact]
        public void GetHolidayPeriods_CrossYearPeriod_AppearsInBothYears()
        {
            // 2022-12-31(六)～2023-01-02(一)：元旦跨年連假 3 天
            var in2022 = HolidayCalendar.GetHolidayPeriods(2022);
            var in2023 = HolidayCalendar.GetHolidayPeriods(2023);

            Assert.Contains(in2022, p => p.Start == new DateTime(2022, 12, 31) && p.End == new DateTime(2023, 1, 2) && p.TotalDays == 3);
            Assert.Contains(in2023, p => p.Start == new DateTime(2022, 12, 31) && p.End == new DateTime(2023, 1, 2) && p.TotalDays == 3);
        }

        [Fact]
        public void GetHolidayPeriods_AllPeriods_AtLeast3Days()
        {
            for (int year = 2017; year <= 2027; year++)
            {
                foreach (HolidayPeriod period in HolidayCalendar.GetHolidayPeriods(year))
                {
                    Assert.True(period.TotalDays >= 3);
                    Assert.Equal(period.TotalDays, (int)(period.End - period.Start).TotalDays + 1);
                }
            }
        }

        // ---- DateOnly 多載（net8+） / DateOnly overloads ----

        [Fact]
        public void DateOnlyOverloads_Work()
        {
            Assert.True(HolidayCalendar.IsHoliday(new DateOnly(2026, 10, 10)));
            Assert.False(HolidayCalendar.IsWorkday(new DateOnly(2026, 10, 10)));
            Assert.Equal("國慶日", HolidayCalendar.GetDayInfo(new DateOnly(2026, 10, 10)).Name);
        }

        // ---- 一般日推導 / Regular day derivation ----

        [Fact]
        public void GetDayInfo_RegularWeekendAndWorkday()
        {
            // 2026-03-07（六）一般週末
            TaiwanDayInfo weekend = HolidayCalendar.GetDayInfo(new DateTime(2026, 3, 7));
            Assert.Equal(DayKind.Weekend, weekend.Kind);
            Assert.True(weekend.IsHoliday);
            Assert.Null(weekend.Name);

            // 2026-03-04（三）一般工作日
            TaiwanDayInfo workday = HolidayCalendar.GetDayInfo(new DateTime(2026, 3, 4));
            Assert.Equal(DayKind.Workday, workday.Kind);
            Assert.True(workday.IsWorkday);
        }
    }
}
