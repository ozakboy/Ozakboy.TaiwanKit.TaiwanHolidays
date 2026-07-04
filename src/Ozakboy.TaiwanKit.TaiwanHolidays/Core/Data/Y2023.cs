// 資料來源：行政院人事行政總處「政府行政機關辦公日曆表」民國 112 年版（data.gov.tw dataset 14718）
// Source: DGPA official calendar for 2023 (data.gov.tw dataset 14718), generated 2026-07-04
namespace Ozakboy.TaiwanKit.TaiwanHolidays.Core.Data
{
    /// <summary>
    /// 2023 年例外日資料（假日/補假/彈性放假/補班；一般工作日與週末由規則推導）
    /// Exceptional days of 2023 (holidays / make-up holidays / adjusted holidays / make-up workdays)
    /// </summary>
    internal static class Y2023
    {
        /// <summary>
        /// 2023 年例外日清單 / Exceptional-day list of 2023
        /// </summary>
        internal static readonly DayRecord[] Days =
        {
            new DayRecord( 101, DayKind.Holiday, "開國紀念日"),
            new DayRecord( 102, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 107, DayKind.MakeupWorkday, "補行上班"),
            new DayRecord( 120, DayKind.Holiday, "小年夜"),
            new DayRecord( 121, DayKind.Holiday, "農曆除夕"),
            new DayRecord( 122, DayKind.Holiday, "春節"),
            new DayRecord( 123, DayKind.Holiday, "春節"),
            new DayRecord( 124, DayKind.Holiday, "春節"),
            new DayRecord( 125, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 126, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 127, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord( 204, DayKind.MakeupWorkday, "補行上班"),
            new DayRecord( 218, DayKind.MakeupWorkday, "補行上班"),
            new DayRecord( 227, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord( 228, DayKind.Holiday, "和平紀念日"),
            new DayRecord( 325, DayKind.MakeupWorkday, "補行上班"),
            new DayRecord( 403, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord( 404, DayKind.Holiday, "兒童節"),
            new DayRecord( 405, DayKind.Holiday, "民族掃墓節"),
            new DayRecord( 617, DayKind.MakeupWorkday, "補行上班"),
            new DayRecord( 622, DayKind.Holiday, "端午節"),
            new DayRecord( 623, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord( 923, DayKind.MakeupWorkday, "補行上班"),
            new DayRecord( 929, DayKind.Holiday, "中秋節"),
            new DayRecord(1009, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord(1010, DayKind.Holiday, "國慶日"),
        };
    }
}
