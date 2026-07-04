// 資料來源：行政院人事行政總處「政府行政機關辦公日曆表」民國 106 年版（data.gov.tw dataset 14718）
// Source: DGPA official calendar for 2017 (data.gov.tw dataset 14718), generated 2026-07-04
namespace Ozakboy.TaiwanKit.TaiwanHolidays.Core.Data
{
    /// <summary>
    /// 2017 年例外日資料（假日/補假/彈性放假/補班；一般工作日與週末由規則推導）
    /// Exceptional days of 2017 (holidays / make-up holidays / adjusted holidays / make-up workdays)
    /// </summary>
    internal static class Y2017
    {
        /// <summary>
        /// 2017 年例外日清單 / Exceptional-day list of 2017
        /// </summary>
        internal static readonly DayRecord[] Days =
        {
            new DayRecord( 101, DayKind.Holiday, "開國紀念日"),
            new DayRecord( 102, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 127, DayKind.Holiday, "農曆除夕"),
            new DayRecord( 128, DayKind.Holiday, "春節"),
            new DayRecord( 129, DayKind.Holiday, "春節"),
            new DayRecord( 130, DayKind.Holiday, "春節"),
            new DayRecord( 131, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 201, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 218, DayKind.MakeupWorkday, "調整上班"),
            new DayRecord( 227, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord( 228, DayKind.Holiday, "和平紀念日"),
            new DayRecord( 403, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 404, DayKind.Holiday, "兒童節及民族掃墓節"),
            new DayRecord( 529, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord( 530, DayKind.Holiday, "端午節"),
            new DayRecord( 603, DayKind.MakeupWorkday, "調整上班"),
            new DayRecord( 930, DayKind.MakeupWorkday, "調整上班"),
            new DayRecord(1004, DayKind.Holiday, "中秋節"),
            new DayRecord(1009, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord(1010, DayKind.Holiday, "國慶日"),
        };
    }
}
