// 資料來源：行政院人事行政總處「政府行政機關辦公日曆表」民國 109 年版（data.gov.tw dataset 14718）
// Source: DGPA official calendar for 2020 (data.gov.tw dataset 14718), generated 2026-07-04
namespace Ozakboy.TaiwanKit.TaiwanHolidays.Core.Data
{
    /// <summary>
    /// 2020 年例外日資料（假日/補假/彈性放假/補班；一般工作日與週末由規則推導）
    /// Exceptional days of 2020 (holidays / make-up holidays / adjusted holidays / make-up workdays)
    /// </summary>
    internal static class Y2020
    {
        /// <summary>
        /// 2020 年例外日清單 / Exceptional-day list of 2020
        /// </summary>
        internal static readonly DayRecord[] Days =
        {
            new DayRecord( 101, DayKind.Holiday, "開國紀念日"),
            new DayRecord( 123, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord( 124, DayKind.Holiday, "農曆除夕"),
            new DayRecord( 125, DayKind.Holiday, "春節"),
            new DayRecord( 126, DayKind.Holiday, "春節"),
            new DayRecord( 127, DayKind.Holiday, "春節"),
            new DayRecord( 128, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 129, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 215, DayKind.MakeupWorkday, "調整上班"),
            new DayRecord( 228, DayKind.Holiday, "和平紀念日"),
            new DayRecord( 402, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 403, DayKind.Holiday, "放假"),
            new DayRecord( 404, DayKind.Holiday, "兒童節及民族掃墓節"),
            new DayRecord( 620, DayKind.MakeupWorkday, "調整上班"),
            new DayRecord( 625, DayKind.Holiday, "端午節"),
            new DayRecord( 626, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord( 926, DayKind.MakeupWorkday, "調整上班"),
            new DayRecord(1001, DayKind.Holiday, "中秋節"),
            new DayRecord(1002, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord(1009, DayKind.MakeupHoliday, "補假"),
            new DayRecord(1010, DayKind.Holiday, "國慶日"),
        };
    }
}
