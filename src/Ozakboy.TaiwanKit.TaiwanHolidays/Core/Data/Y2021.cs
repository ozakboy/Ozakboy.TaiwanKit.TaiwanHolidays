// 資料來源：行政院人事行政總處「政府行政機關辦公日曆表」民國 110 年版（data.gov.tw dataset 14718）
// Source: DGPA official calendar for 2021 (data.gov.tw dataset 14718), generated 2026-07-04
namespace Ozakboy.TaiwanKit.TaiwanHolidays.Core.Data
{
    /// <summary>
    /// 2021 年例外日資料（假日/補假/彈性放假/補班；一般工作日與週末由規則推導）
    /// Exceptional days of 2021 (holidays / make-up holidays / adjusted holidays / make-up workdays)
    /// </summary>
    internal static class Y2021
    {
        /// <summary>
        /// 2021 年例外日清單 / Exceptional-day list of 2021
        /// </summary>
        internal static readonly DayRecord[] Days =
        {
            new DayRecord( 101, DayKind.Holiday, "開國紀念日"),
            new DayRecord( 210, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord( 211, DayKind.Holiday, "農曆除夕"),
            new DayRecord( 212, DayKind.Holiday, "春節"),
            new DayRecord( 213, DayKind.Holiday, "春節"),
            new DayRecord( 214, DayKind.Holiday, "春節"),
            new DayRecord( 215, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 216, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 220, DayKind.MakeupWorkday, "補行上班"),
            new DayRecord( 228, DayKind.Holiday, "和平紀念日"),
            new DayRecord( 301, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 402, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 404, DayKind.Holiday, "兒童節及民族掃墓節"),
            new DayRecord( 405, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 614, DayKind.Holiday, "端午節"),
            new DayRecord( 911, DayKind.MakeupWorkday, "補行上班"),
            new DayRecord( 920, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord( 921, DayKind.Holiday, "中秋節"),
            new DayRecord(1010, DayKind.Holiday, "國慶日"),
            new DayRecord(1011, DayKind.MakeupHoliday, "補假"),
            new DayRecord(1231, DayKind.MakeupHoliday, "補假"),
        };
    }
}
