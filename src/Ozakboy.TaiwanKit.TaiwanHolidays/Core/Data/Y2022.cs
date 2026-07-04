// 資料來源：行政院人事行政總處「政府行政機關辦公日曆表」民國 111 年版（data.gov.tw dataset 14718）
// Source: DGPA official calendar for 2022 (data.gov.tw dataset 14718), generated 2026-07-04
namespace Ozakboy.TaiwanKit.TaiwanHolidays.Core.Data
{
    /// <summary>
    /// 2022 年例外日資料（假日/補假/彈性放假/補班；一般工作日與週末由規則推導）
    /// Exceptional days of 2022 (holidays / make-up holidays / adjusted holidays / make-up workdays)
    /// </summary>
    internal static class Y2022
    {
        /// <summary>
        /// 2022 年例外日清單 / Exceptional-day list of 2022
        /// </summary>
        internal static readonly DayRecord[] Days =
        {
            new DayRecord( 101, DayKind.Holiday, "開國紀念日"),
            new DayRecord( 122, DayKind.MakeupWorkday, "補行上班"),
            new DayRecord( 131, DayKind.Holiday, "農曆除夕"),
            new DayRecord( 201, DayKind.Holiday, "春節"),
            new DayRecord( 202, DayKind.Holiday, "春節"),
            new DayRecord( 203, DayKind.Holiday, "春節"),
            new DayRecord( 204, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord( 228, DayKind.Holiday, "和平紀念日"),
            new DayRecord( 404, DayKind.Holiday, "兒童節"),
            new DayRecord( 405, DayKind.Holiday, "民族掃墓節"),
            new DayRecord( 603, DayKind.Holiday, "端午節"),
            new DayRecord( 909, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 910, DayKind.Holiday, "中秋節"),
            new DayRecord(1010, DayKind.Holiday, "國慶日"),
        };
    }
}
