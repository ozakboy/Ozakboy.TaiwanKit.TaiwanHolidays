using System;
using System.Collections.Generic;
using Ozakboy.TaiwanKit.TaiwanHolidays.Core;

namespace Ozakboy.TaiwanKit.TaiwanHolidays
{
    /// <summary>
    /// 台灣國定假日/補班日查詢（資料來源：行政院人事行政總處「政府行政機關辦公日曆表」，內嵌 2017～2027）
    /// Taiwan holiday / make-up workday queries (source: DGPA official government office calendar, 2017-2027 embedded)
    /// </summary>
    public static class HolidayCalendar
    {
        /// <summary>
        /// 資料涵蓋的第一天（2017-01-01）
        /// First covered date (2017-01-01)
        /// </summary>
        public static DateTime MinDate
        {
            get { return new DateTime(HolidayData.MinYear, 1, 1); }
        }

        /// <summary>
        /// 資料涵蓋的最後一天（2027-12-31）
        /// Last covered date (2027-12-31)
        /// </summary>
        public static DateTime MaxDate
        {
            get { return new DateTime(HolidayData.MaxYear, 12, 31); }
        }

        /// <summary>
        /// 資料涵蓋的年份清單
        /// List of covered years
        /// </summary>
        public static IReadOnlyList<int> SupportedYears
        {
            get
            {
                var years = new int[HolidayData.MaxYear - HolidayData.MinYear + 1];
                for (int i = 0; i < years.Length; i++)
                {
                    years[i] = HolidayData.MinYear + i;
                }

                return years;
            }
        }

        /// <summary>
        /// 判斷指定日期是否為放假日（例假日、國定假日、補假或調整放假）。補行上班的週六視為工作日。
        /// Determines whether the date is a day off (weekend, holiday, make-up holiday or adjusted day off). Make-up workdays count as workdays.
        /// </summary>
        /// <param name="date">要查詢的日期（僅取日期部分） / The date to query (date part only)</param>
        /// <returns>是否放假 / Whether the date is a day off</returns>
        /// <exception cref="ArgumentOutOfRangeException">日期超出資料涵蓋範圍（MinDate～MaxDate） / Date outside the covered range</exception>
        public static bool IsHoliday(DateTime date)
        {
            return GetDayInfo(date).IsHoliday;
        }

        /// <summary>
        /// 判斷指定日期是否為工作日（一般工作日或補行上班日）
        /// Determines whether the date is a workday (regular or make-up workday)
        /// </summary>
        /// <param name="date">要查詢的日期（僅取日期部分） / The date to query (date part only)</param>
        /// <returns>是否為工作日 / Whether the date is a workday</returns>
        /// <exception cref="ArgumentOutOfRangeException">日期超出資料涵蓋範圍（MinDate～MaxDate） / Date outside the covered range</exception>
        public static bool IsWorkday(DateTime date)
        {
            return GetDayInfo(date).IsWorkday;
        }

        /// <summary>
        /// 取得指定日期的完整資訊（日型分類、假日名稱）
        /// Gets the complete information of a date (kind, holiday name)
        /// </summary>
        /// <param name="date">要查詢的日期（僅取日期部分） / The date to query (date part only)</param>
        /// <returns>單日資訊 / The day info</returns>
        /// <exception cref="ArgumentOutOfRangeException">日期超出資料涵蓋範圍（MinDate～MaxDate） / Date outside the covered range</exception>
        public static TaiwanDayInfo GetDayInfo(DateTime date)
        {
            DateTime day = date.Date;
            EnsureInRange(day, nameof(date));
            return HolidayData.CreateDayInfo(day);
        }

        /// <summary>
        /// 嘗試取得指定日期的完整資訊；日期超出涵蓋範圍時回傳 false 而不拋例外
        /// Tries to get the day info; returns false (instead of throwing) when the date is outside the covered range
        /// </summary>
        /// <param name="date">要查詢的日期（僅取日期部分） / The date to query (date part only)</param>
        /// <param name="info">單日資訊；超出範圍時為 null / The day info; null when out of range</param>
        /// <returns>是否在涵蓋範圍內 / Whether the date is covered</returns>
        public static bool TryGetDayInfo(DateTime date, out TaiwanDayInfo? info)
        {
            DateTime day = date.Date;
            if (day < MinDate || day > MaxDate)
            {
                info = null;
                return false;
            }

            info = HolidayData.CreateDayInfo(day);
            return true;
        }

        /// <summary>
        /// 取得指定年份的假日清單（國定假日、補假、調整放假；不含一般例假日）
        /// Gets the holiday list of a year (holidays, make-up holidays, adjusted days off; regular weekends excluded)
        /// </summary>
        /// <param name="year">年份 / The year</param>
        /// <returns>依日期排序的假日清單 / Holiday list ordered by date</returns>
        /// <exception cref="ArgumentOutOfRangeException">年份超出資料涵蓋範圍 / Year outside the covered range</exception>
        public static IReadOnlyList<TaiwanDayInfo> GetHolidays(int year)
        {
            EnsureYearInRange(year);
            var list = new List<TaiwanDayInfo>();
            for (DateTime day = new DateTime(year, 1, 1); day.Year == year; day = day.AddDays(1))
            {
                TaiwanDayInfo info = HolidayData.CreateDayInfo(day);
                if (info.Kind == DayKind.Holiday || info.Kind == DayKind.MakeupHoliday || info.Kind == DayKind.AdjustedHoliday)
                {
                    list.Add(info);
                }
            }

            return list;
        }

        /// <summary>
        /// 取得指定年份的補行上班日清單
        /// Gets the make-up workday list of a year
        /// </summary>
        /// <param name="year">年份 / The year</param>
        /// <returns>依日期排序的補班日清單 / Make-up workday list ordered by date</returns>
        /// <exception cref="ArgumentOutOfRangeException">年份超出資料涵蓋範圍 / Year outside the covered range</exception>
        public static IReadOnlyList<TaiwanDayInfo> GetMakeupWorkdays(int year)
        {
            EnsureYearInRange(year);
            var list = new List<TaiwanDayInfo>();
            for (DateTime day = new DateTime(year, 1, 1); day.Year == year; day = day.AddDays(1))
            {
                TaiwanDayInfo info = HolidayData.CreateDayInfo(day);
                if (info.Kind == DayKind.MakeupWorkday)
                {
                    list.Add(info);
                }
            }

            return list;
        }

        /// <summary>
        /// 取得指定日期之後的下一個工作日（不含指定日期本身）
        /// Gets the next workday after the given date (exclusive)
        /// </summary>
        /// <param name="date">起算日期（僅取日期部分） / The starting date (date part only)</param>
        /// <returns>下一個工作日 / The next workday</returns>
        /// <exception cref="ArgumentOutOfRangeException">日期超出資料涵蓋範圍，或往後尋找時超出 MaxDate / Date outside range, or the search walks past MaxDate</exception>
        public static DateTime GetNextWorkday(DateTime date)
        {
            DateTime day = date.Date;
            EnsureInRange(day, nameof(date));

            for (DateTime cursor = day.AddDays(1); cursor <= MaxDate; cursor = cursor.AddDays(1))
            {
                if (HolidayData.CreateDayInfo(cursor).IsWorkday)
                {
                    return cursor;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(date), "下一個工作日超出資料涵蓋範圍 / The next workday is beyond the covered range.");
        }

        /// <summary>
        /// 取得指定日期之前的上一個工作日（不含指定日期本身）
        /// Gets the previous workday before the given date (exclusive)
        /// </summary>
        /// <param name="date">起算日期（僅取日期部分） / The starting date (date part only)</param>
        /// <returns>上一個工作日 / The previous workday</returns>
        /// <exception cref="ArgumentOutOfRangeException">日期超出資料涵蓋範圍，或往前尋找時超出 MinDate / Date outside range, or the search walks past MinDate</exception>
        public static DateTime GetPreviousWorkday(DateTime date)
        {
            DateTime day = date.Date;
            EnsureInRange(day, nameof(date));

            for (DateTime cursor = day.AddDays(-1); cursor >= MinDate; cursor = cursor.AddDays(-1))
            {
                if (HolidayData.CreateDayInfo(cursor).IsWorkday)
                {
                    return cursor;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(date), "上一個工作日超出資料涵蓋範圍 / The previous workday is beyond the covered range.");
        }

        /// <summary>
        /// 計算兩日期（含頭尾）之間的工作日數
        /// Counts workdays between two dates (both ends inclusive)
        /// </summary>
        /// <param name="from">起始日期（含） / Start date (inclusive)</param>
        /// <param name="to">結束日期（含） / End date (inclusive)</param>
        /// <returns>工作日數 / Number of workdays</returns>
        /// <exception cref="ArgumentException">from 晚於 to / from is later than to</exception>
        /// <exception cref="ArgumentOutOfRangeException">日期超出資料涵蓋範圍 / Dates outside the covered range</exception>
        public static int CountWorkdays(DateTime from, DateTime to)
        {
            DateTime start = from.Date;
            DateTime end = to.Date;

            if (start > end)
            {
                throw new ArgumentException("from 不可晚於 to / 'from' must not be later than 'to'.", nameof(from));
            }

            EnsureInRange(start, nameof(from));
            EnsureInRange(end, nameof(to));

            int count = 0;
            for (DateTime cursor = start; cursor <= end; cursor = cursor.AddDays(1))
            {
                if (HolidayData.CreateDayInfo(cursor).IsWorkday)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// 取得與指定年份重疊的連續假期區段（連續 3 天含以上的非工作日）。跨年度的連假會同時出現在兩個年份的結果中，且不截斷。
        /// Gets consecutive holiday periods (3+ non-workdays) overlapping the year. A cross-year period appears in both years' results, untruncated.
        /// </summary>
        /// <param name="year">年份 / The year</param>
        /// <returns>依開始日期排序的連假清單 / Periods ordered by start date</returns>
        /// <exception cref="ArgumentOutOfRangeException">年份超出資料涵蓋範圍 / Year outside the covered range</exception>
        public static IReadOnlyList<HolidayPeriod> GetHolidayPeriods(int year)
        {
            EnsureYearInRange(year);

            var periods = new List<HolidayPeriod>();
            DateTime yearStart = new DateTime(year, 1, 1);
            DateTime yearEnd = new DateTime(year, 12, 31);

            // 從年初往前延伸掃描，讓跨年連假完整呈現（資料邊界處自然截止）
            // Scan from a few days before the year start so cross-year periods are complete
            DateTime scanStart = yearStart.AddDays(-14) < MinDate ? MinDate : yearStart.AddDays(-14);
            DateTime scanEnd = yearEnd.AddDays(14) > MaxDate ? MaxDate : yearEnd.AddDays(14);

            DateTime? runStart = null;
            var runNames = new List<string>();

            for (DateTime cursor = scanStart; cursor <= scanEnd.AddDays(1); cursor = cursor.AddDays(1))
            {
                bool isOff = cursor <= scanEnd && !HolidayData.CreateDayInfo(cursor).IsWorkday;

                if (isOff)
                {
                    if (runStart == null)
                    {
                        runStart = cursor;
                        runNames.Clear();
                    }

                    TaiwanDayInfo info = HolidayData.CreateDayInfo(cursor);
                    if (info.Kind == DayKind.Holiday && info.Name != null)
                    {
                        runNames.Add(info.Name);
                    }
                }
                else if (runStart != null)
                {
                    DateTime runEnd = cursor.AddDays(-1);
                    int totalDays = (int)(runEnd - runStart.Value).TotalDays + 1;
                    if (totalDays >= 3 && runStart.Value <= yearEnd && runEnd >= yearStart)
                    {
                        string? name = PickRepresentativeName(runNames);
                        periods.Add(new HolidayPeriod(runStart.Value, runEnd, totalDays, name, HolidayNames.GetEnglishName(name)));
                    }

                    runStart = null;
                }
            }

            return periods;
        }

#if NET8_0_OR_GREATER
        /// <summary>
        /// 判斷指定日期是否為放假日（DateOnly 多載）
        /// Determines whether the date is a day off (DateOnly overload)
        /// </summary>
        /// <param name="date">要查詢的日期 / The date to query</param>
        /// <returns>是否放假 / Whether the date is a day off</returns>
        /// <exception cref="ArgumentOutOfRangeException">日期超出資料涵蓋範圍 / Date outside the covered range</exception>
        public static bool IsHoliday(DateOnly date)
        {
            return IsHoliday(date.ToDateTime(TimeOnly.MinValue));
        }

        /// <summary>
        /// 判斷指定日期是否為工作日（DateOnly 多載）
        /// Determines whether the date is a workday (DateOnly overload)
        /// </summary>
        /// <param name="date">要查詢的日期 / The date to query</param>
        /// <returns>是否為工作日 / Whether the date is a workday</returns>
        /// <exception cref="ArgumentOutOfRangeException">日期超出資料涵蓋範圍 / Date outside the covered range</exception>
        public static bool IsWorkday(DateOnly date)
        {
            return IsWorkday(date.ToDateTime(TimeOnly.MinValue));
        }

        /// <summary>
        /// 取得指定日期的完整資訊（DateOnly 多載）
        /// Gets the day info (DateOnly overload)
        /// </summary>
        /// <param name="date">要查詢的日期 / The date to query</param>
        /// <returns>單日資訊 / The day info</returns>
        /// <exception cref="ArgumentOutOfRangeException">日期超出資料涵蓋範圍 / Date outside the covered range</exception>
        public static TaiwanDayInfo GetDayInfo(DateOnly date)
        {
            return GetDayInfo(date.ToDateTime(TimeOnly.MinValue));
        }
#endif

        /// <summary>
        /// 從連假內的具名假日中挑出代表名稱（出現最多次者；同次數取先出現者）
        /// Picks the representative name (most frequent; ties resolved by first occurrence)
        /// </summary>
        private static string? PickRepresentativeName(List<string> names)
        {
            if (names.Count == 0)
            {
                return null;
            }

            string best = names[0];
            int bestCount = 0;
            foreach (string candidate in names)
            {
                int count = 0;
                foreach (string other in names)
                {
                    if (other == candidate)
                    {
                        count++;
                    }
                }

                if (count > bestCount)
                {
                    best = candidate;
                    bestCount = count;
                }
            }

            return best;
        }

        /// <summary>
        /// 檢查日期在涵蓋範圍內，否則拋出例外
        /// Ensures the date is within the covered range
        /// </summary>
        private static void EnsureInRange(DateTime day, string paramName)
        {
            if (day < MinDate || day > MaxDate)
            {
                throw new ArgumentOutOfRangeException(
                    paramName,
                    day,
                    $"日期超出資料涵蓋範圍 {MinDate:yyyy-MM-dd}～{MaxDate:yyyy-MM-dd}；可先用 TryGetDayInfo 或 MinDate/MaxDate 檢查 / Date outside the covered range.");
            }
        }

        /// <summary>
        /// 檢查年份在涵蓋範圍內，否則拋出例外
        /// Ensures the year is within the covered range
        /// </summary>
        private static void EnsureYearInRange(int year)
        {
            if (year < HolidayData.MinYear || year > HolidayData.MaxYear)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(year),
                    year,
                    $"年份超出資料涵蓋範圍 {HolidayData.MinYear}～{HolidayData.MaxYear} / Year outside the covered range.");
            }
        }
    }
}
