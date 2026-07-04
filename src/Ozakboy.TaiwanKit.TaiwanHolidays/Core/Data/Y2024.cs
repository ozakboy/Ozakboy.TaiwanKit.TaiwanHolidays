// 資料來源：行政院人事行政總處「政府行政機關辦公日曆表」民國 113 年版（data.gov.tw dataset 14718）
// Source: DGPA official calendar for 2024 (data.gov.tw dataset 14718), generated 2026-07-04
namespace Ozakboy.TaiwanKit.TaiwanHolidays.Core.Data
{
    /// <summary>
    /// 2024 年例外日資料（假日/補假/彈性放假/補班；一般工作日與週末由規則推導）
    /// Exceptional days of 2024 (holidays / make-up holidays / adjusted holidays / make-up workdays)
    /// </summary>
    internal static class Y2024
    {
        /// <summary>
        /// 2024 年例外日清單 / Exceptional-day list of 2024
        /// </summary>
        internal static readonly DayRecord[] Days =
        {
            new DayRecord( 101, DayKind.Holiday, "開國紀念日"),
            new DayRecord( 208, DayKind.Holiday, "小年夜"),
            new DayRecord( 209, DayKind.Holiday, "農曆除夕"),
            new DayRecord( 210, DayKind.Holiday, "春節"),
            new DayRecord( 211, DayKind.Holiday, "春節"),
            new DayRecord( 212, DayKind.Holiday, "春節"),
            new DayRecord( 213, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 214, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 217, DayKind.MakeupWorkday, "補行上班"),
            new DayRecord( 228, DayKind.Holiday, "和平紀念日"),
            new DayRecord( 404, DayKind.Holiday, "兒童節及民族掃墓節"),
            new DayRecord( 405, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 610, DayKind.Holiday, "端午節"),
            new DayRecord( 917, DayKind.Holiday, "中秋節"),
            new DayRecord(1010, DayKind.Holiday, "國慶日"),
        };
    }
}
