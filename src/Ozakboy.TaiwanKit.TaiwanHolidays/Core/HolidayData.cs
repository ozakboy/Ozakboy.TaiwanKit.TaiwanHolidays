using System;
using System.Collections.Generic;
using Ozakboy.TaiwanKit.TaiwanHolidays.Core.Data;

namespace Ozakboy.TaiwanKit.TaiwanHolidays.Core
{
    /// <summary>
    /// 假日資料彙總層：將各年度例外日資料建成查詢表（Lazy 延遲載入、不可變、線程安全）
    /// Aggregated holiday data: builds the lookup table from per-year records (lazy, immutable, thread-safe)
    /// </summary>
    internal static class HolidayData
    {
        /// <summary>
        /// 資料涵蓋起始年
        /// First covered year
        /// </summary>
        internal const int MinYear = 2017;

        /// <summary>
        /// 資料涵蓋結束年
        /// Last covered year
        /// </summary>
        internal const int MaxYear = 2027;

        /// <summary>
        /// 例外日查詢表（key = yyyyMMdd 整數）
        /// Exceptional-day lookup table (key = yyyyMMdd integer)
        /// </summary>
        private static readonly Lazy<Dictionary<int, DayRecord>> Table = new Lazy<Dictionary<int, DayRecord>>(BuildTable);

        /// <summary>
        /// 建立查詢表
        /// Builds the lookup table
        /// </summary>
        private static Dictionary<int, DayRecord> BuildTable()
        {
            var table = new Dictionary<int, DayRecord>();
            AddYear(table, 2017, Y2017.Days);
            AddYear(table, 2018, Y2018.Days);
            AddYear(table, 2019, Y2019.Days);
            AddYear(table, 2020, Y2020.Days);
            AddYear(table, 2021, Y2021.Days);
            AddYear(table, 2022, Y2022.Days);
            AddYear(table, 2023, Y2023.Days);
            AddYear(table, 2024, Y2024.Days);
            AddYear(table, 2025, Y2025.Days);
            AddYear(table, 2026, Y2026.Days);
            AddYear(table, 2027, Y2027.Days);
            return table;
        }

        /// <summary>
        /// 將單一年度資料加入查詢表
        /// Adds one year of records into the table
        /// </summary>
        private static void AddYear(Dictionary<int, DayRecord> table, int year, DayRecord[] days)
        {
            foreach (DayRecord record in days)
            {
                table.Add(year * 10000 + record.MonthDay, record);
            }
        }

        /// <summary>
        /// 查詢指定日期是否為例外日
        /// Tries to get the exceptional-day record of a date
        /// </summary>
        /// <param name="date">日期（僅取日期部分） / The date (date part only)</param>
        /// <param name="record">例外日紀錄 / The record</param>
        /// <returns>是否為例外日 / Whether the date is exceptional</returns>
        internal static bool TryGetRecord(DateTime date, out DayRecord record)
        {
            int key = (date.Year * 100 + date.Month) * 100 + date.Day;
            return Table.Value.TryGetValue(key, out record);
        }

        /// <summary>
        /// 建立指定日期的完整單日資訊（呼叫端須先確認日期在涵蓋範圍內）
        /// Creates the day info of a date (caller must ensure the date is within range)
        /// </summary>
        /// <param name="date">日期（僅取日期部分） / The date (date part only)</param>
        /// <returns>單日資訊 / The day info</returns>
        internal static TaiwanDayInfo CreateDayInfo(DateTime date)
        {
            DateTime day = date.Date;

            if (TryGetRecord(day, out DayRecord record))
            {
                string? name = record.Name.Length == 0 ? null : record.Name;
                return new TaiwanDayInfo(day, record.Kind, name, HolidayNames.GetEnglishName(name));
            }

            bool weekend = day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday;
            return new TaiwanDayInfo(day, weekend ? DayKind.Weekend : DayKind.Workday, null, null);
        }
    }
}
