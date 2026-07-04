namespace Ozakboy.TaiwanKit.TaiwanHolidays
{
    /// <summary>
    /// 日型分類（依政府行政機關辦公日曆表）
    /// Kind of a day (per the government office calendar)
    /// </summary>
    public enum DayKind
    {
        /// <summary>
        /// 一般工作日
        /// Regular workday
        /// </summary>
        Workday = 0,

        /// <summary>
        /// 例假日（非國定假日的週六、週日）
        /// Regular weekend (Saturday/Sunday that is not a national holiday)
        /// </summary>
        Weekend = 1,

        /// <summary>
        /// 國定假日/放假之紀念日與節日
        /// National holiday
        /// </summary>
        Holiday = 2,

        /// <summary>
        /// 補假（假日逢例假日的補假日）
        /// Make-up holiday (compensation day when a holiday falls on a weekend)
        /// </summary>
        MakeupHoliday = 3,

        /// <summary>
        /// 調整放假（彈性放假日）
        /// Adjusted day off (flexible holiday, usually bridging a long weekend)
        /// </summary>
        AdjustedHoliday = 4,

        /// <summary>
        /// 補行上班日（因彈性放假而須上班的週六）
        /// Make-up workday (a Saturday that becomes a workday to compensate an adjusted day off)
        /// </summary>
        MakeupWorkday = 5,
    }
}
