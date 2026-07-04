namespace Ozakboy.TaiwanKit.TaiwanHolidays.Core
{
    /// <summary>
    /// 資料層的例外日紀錄（僅存非一般日：假日/補假/彈休/補班）
    /// Data-layer record of an exceptional day (only non-regular days are stored)
    /// </summary>
    internal readonly struct DayRecord
    {
        /// <summary>
        /// 建立例外日紀錄
        /// Creates an exceptional-day record
        /// </summary>
        /// <param name="monthDay">月日（MMdd 整數，如 101 = 1/1、1225 = 12/25） / Month-day as MMdd integer</param>
        /// <param name="kind">日型分類 / Kind of the day</param>
        /// <param name="name">官方日曆表備註名稱 / Note from the official calendar</param>
        internal DayRecord(int monthDay, DayKind kind, string name)
        {
            MonthDay = monthDay;
            Kind = kind;
            Name = name;
        }

        /// <summary>
        /// 月日（MMdd 整數）
        /// Month-day as MMdd integer
        /// </summary>
        internal int MonthDay { get; }

        /// <summary>
        /// 日型分類
        /// Kind of the day
        /// </summary>
        internal DayKind Kind { get; }

        /// <summary>
        /// 官方日曆表備註名稱
        /// Note from the official calendar
        /// </summary>
        internal string Name { get; }
    }
}
