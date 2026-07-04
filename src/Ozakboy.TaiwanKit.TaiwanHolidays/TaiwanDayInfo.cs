using System;

namespace Ozakboy.TaiwanKit.TaiwanHolidays
{
    /// <summary>
    /// 單日完整資訊（不可變）
    /// Complete information of a single day (immutable)
    /// </summary>
    public sealed class TaiwanDayInfo
    {
        /// <summary>
        /// 建立單日資訊
        /// Creates a day info
        /// </summary>
        internal TaiwanDayInfo(DateTime date, DayKind kind, string? name, string? englishName)
        {
            Date = date;
            Kind = kind;
            Name = name;
            EnglishName = englishName;
        }

        /// <summary>
        /// 日期（時間部分為 00:00:00）
        /// The date (time component is 00:00:00)
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// 日型分類
        /// Kind of the day
        /// </summary>
        public DayKind Kind { get; }

        /// <summary>
        /// 假日/補班名稱（依官方日曆表備註，如「春節」「補假」「補行上班」）；一般工作日與例假日為 null
        /// Holiday/make-up name per the official calendar note (e.g. "春節"); null for regular workdays and weekends
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// 假日英文名稱（由內建對照表轉換）；無對應時為 null
        /// English holiday name (from the built-in mapping); null when unmapped
        /// </summary>
        public string? EnglishName { get; }

        /// <summary>
        /// 是否為工作日（一般工作日或補行上班日）
        /// Whether the day is a workday (regular workday or make-up workday)
        /// </summary>
        public bool IsWorkday
        {
            get { return Kind == DayKind.Workday || Kind == DayKind.MakeupWorkday; }
        }

        /// <summary>
        /// 是否為放假日（例假日、國定假日、補假或調整放假）
        /// Whether the day is a day off (weekend, holiday, make-up holiday or adjusted day off)
        /// </summary>
        public bool IsHoliday
        {
            get { return !IsWorkday; }
        }
    }
}
