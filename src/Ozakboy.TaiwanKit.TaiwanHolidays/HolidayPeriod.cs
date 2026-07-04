using System;

namespace Ozakboy.TaiwanKit.TaiwanHolidays
{
    /// <summary>
    /// 連續假期區段（不可變）；連續 3 天（含）以上的非工作日視為連假
    /// A consecutive holiday period (immutable); 3+ consecutive non-workdays count as one period
    /// </summary>
    public sealed class HolidayPeriod
    {
        /// <summary>
        /// 建立連假區段
        /// Creates a holiday period
        /// </summary>
        internal HolidayPeriod(DateTime start, DateTime end, int totalDays, string? name, string? englishName)
        {
            Start = start;
            End = end;
            TotalDays = totalDays;
            Name = name;
            EnglishName = englishName;
        }

        /// <summary>
        /// 連假第一天
        /// First day of the period
        /// </summary>
        public DateTime Start { get; }

        /// <summary>
        /// 連假最後一天
        /// Last day of the period
        /// </summary>
        public DateTime End { get; }

        /// <summary>
        /// 連假總天數
        /// Total number of days
        /// </summary>
        public int TotalDays { get; }

        /// <summary>
        /// 連假代表名稱（取區段內出現最多次的假日名稱，如「春節」）；區段內無具名假日時為 null
        /// Representative name (the most frequent holiday name in the period, e.g. "春節"); null when the period has no named holiday
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// 連假代表英文名稱；無對應時為 null
        /// Representative English name; null when unmapped
        /// </summary>
        public string? EnglishName { get; }
    }
}
