using System;
using System.Linq;
using Xunit;

namespace Ozakboy.TaiwanKit.TaiwanHolidays.Tests
{
    /// <summary>
    /// 逐年資料驗證：分類數量以官方 CSV（data.gov.tw dataset 14718）統計為準；
    /// 春節初一等錨點日期為獨立已知事實，非源自同一份 CSV，可抓出轉換層系統性錯誤。
    /// </summary>
    public class YearlyDataTests
    {
        // year, holidays, makeupHoliday, adjusted, makeupWorkday（來源：官方 CSV 統計）
        [Theory]
        [InlineData(2017, 10, 4, 3, 3)]
        [InlineData(2018, 11, 2, 2, 2)]
        [InlineData(2019, 11, 0, 3, 3)]
        [InlineData(2020, 11, 4, 3, 3)]
        [InlineData(2021, 10, 7, 2, 2)]
        [InlineData(2022, 11, 1, 1, 1)]
        [InlineData(2023, 12, 3, 5, 6)]
        [InlineData(2024, 11, 3, 0, 1)]
        [InlineData(2025, 14, 4, 0, 1)]
        [InlineData(2026, 16, 6, 0, 0)]
        [InlineData(2027, 16, 8, 0, 0)]
        public void GetHolidays_YearlyCounts_MatchOfficialCsv(int year, int holidays, int makeupHoliday, int adjusted, int makeupWorkday)
        {
            var list = HolidayCalendar.GetHolidays(year);

            Assert.Equal(holidays, list.Count(d => d.Kind == DayKind.Holiday));
            Assert.Equal(makeupHoliday, list.Count(d => d.Kind == DayKind.MakeupHoliday));
            Assert.Equal(adjusted, list.Count(d => d.Kind == DayKind.AdjustedHoliday));
            Assert.Equal(makeupWorkday, HolidayCalendar.GetMakeupWorkdays(year).Count);
        }

        // 獨立錨點：春節初一（農曆已知事實，非源自 CSV）
        [Theory]
        [InlineData(2017, 1, 28)]
        [InlineData(2018, 2, 16)]
        [InlineData(2019, 2, 5)]
        [InlineData(2020, 1, 25)]
        [InlineData(2021, 2, 12)]
        [InlineData(2022, 2, 1)]
        [InlineData(2023, 1, 22)]
        [InlineData(2024, 2, 10)]
        [InlineData(2025, 1, 29)]
        [InlineData(2026, 2, 17)]
        [InlineData(2027, 2, 6)]
        public void GetDayInfo_LunarNewYearDay1_IsSpringFestival(int year, int month, int day)
        {
            TaiwanDayInfo info = HolidayCalendar.GetDayInfo(new DateTime(year, month, day));

            Assert.True(info.IsHoliday);
            Assert.Equal(DayKind.Holiday, info.Kind);
            Assert.Equal("春節", info.Name);
        }

        // 獨立錨點：固定日期的國定假日
        [Theory]
        [InlineData(1, 1)]    // 開國紀念日
        [InlineData(2, 28)]   // 和平紀念日
        [InlineData(10, 10)]  // 國慶日
        public void GetDayInfo_FixedHolidays_AllYears(int month, int day)
        {
            for (int year = 2017; year <= 2027; year++)
            {
                TaiwanDayInfo info = HolidayCalendar.GetDayInfo(new DateTime(year, month, day));

                Assert.True(info.IsHoliday, $"{year}-{month}-{day} should be a holiday.");
            }
        }

        // 2025 新制假日（紀念日及節日實施條例）：教師節、光復節、行憲紀念日
        [Fact]
        public void GetDayInfo_NewHolidaysFrom2025_PresentOnlyFrom2025()
        {
            // 行憲紀念日 12/25：2024 上班、2025 起放假
            Assert.True(HolidayCalendar.IsWorkday(new DateTime(2024, 12, 25)));
            Assert.True(HolidayCalendar.IsHoliday(new DateTime(2025, 12, 25)));
            Assert.True(HolidayCalendar.IsHoliday(new DateTime(2026, 12, 25)));

            // 教師節 9/28：2024 上班日曆無假、2026 放假
            Assert.True(HolidayCalendar.IsHoliday(new DateTime(2026, 9, 28)));

            // 光復節 10/25：2026 放假（2026-10-25 為週日，隔日補假）
            Assert.True(HolidayCalendar.IsHoliday(new DateTime(2026, 10, 25)));
            Assert.Equal(DayKind.MakeupHoliday, HolidayCalendar.GetDayInfo(new DateTime(2026, 10, 26)).Kind);

            // 勞動節 5/1：2026 起全民放假（政府行事曆列入）
            Assert.True(HolidayCalendar.IsHoliday(new DateTime(2026, 5, 1)));
        }

        // 補班日：週六上班
        [Fact]
        public void GetDayInfo_MakeupWorkday_SaturdayIsWorkday()
        {
            // 2023-01-07（六）為春節彈性放假的補行上班日
            TaiwanDayInfo info = HolidayCalendar.GetDayInfo(new DateTime(2023, 1, 7));

            Assert.Equal(DayOfWeek.Saturday, info.Date.DayOfWeek);
            Assert.Equal(DayKind.MakeupWorkday, info.Kind);
            Assert.True(info.IsWorkday);
            Assert.False(info.IsHoliday);
        }

        // 2026 起不再彈性放假/補班
        [Fact]
        public void GetMakeupWorkdays_2026And2027_Empty()
        {
            Assert.Empty(HolidayCalendar.GetMakeupWorkdays(2026));
            Assert.Empty(HolidayCalendar.GetMakeupWorkdays(2027));
        }

        // 英文名稱對照
        [Fact]
        public void GetDayInfo_EnglishNames_Mapped()
        {
            Assert.Equal("New Year's Day", HolidayCalendar.GetDayInfo(new DateTime(2026, 1, 1)).EnglishName);
            Assert.Equal("Lunar New Year", HolidayCalendar.GetDayInfo(new DateTime(2026, 2, 17)).EnglishName);
            Assert.Equal("National Day", HolidayCalendar.GetDayInfo(new DateTime(2026, 10, 10)).EnglishName);
        }
    }
}
