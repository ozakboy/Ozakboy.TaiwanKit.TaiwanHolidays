// 資料來源：行政院人事行政總處「政府行政機關辦公日曆表」民國 115 年版（data.gov.tw dataset 14718）
// Source: DGPA official calendar for 2026 (data.gov.tw dataset 14718), generated 2026-07-04
namespace Ozakboy.TaiwanKit.TaiwanHolidays.Core.Data
{
    /// <summary>
    /// 2026 年例外日資料（假日/補假/彈性放假/補班；一般工作日與週末由規則推導）
    /// Exceptional days of 2026 (holidays / make-up holidays / adjusted holidays / make-up workdays)
    /// </summary>
    internal static class Y2026
    {
        /// <summary>
        /// 2026 年例外日清單 / Exceptional-day list of 2026
        /// </summary>
        internal static readonly DayRecord[] Days =
        {
            new DayRecord( 101, DayKind.Holiday, "開國紀念日"),
            new DayRecord( 215, DayKind.Holiday, "小年夜"),
            new DayRecord( 216, DayKind.Holiday, "農曆除夕"),
            new DayRecord( 217, DayKind.Holiday, "春節"),
            new DayRecord( 218, DayKind.Holiday, "春節"),
            new DayRecord( 219, DayKind.Holiday, "春節"),
            new DayRecord( 220, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 227, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 228, DayKind.Holiday, "和平紀念日"),
            new DayRecord( 403, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 404, DayKind.Holiday, "兒童節"),
            new DayRecord( 405, DayKind.Holiday, "清明節"),
            new DayRecord( 406, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 501, DayKind.Holiday, "勞動節"),
            new DayRecord( 619, DayKind.Holiday, "端午節"),
            new DayRecord( 925, DayKind.Holiday, "中秋節"),
            new DayRecord( 928, DayKind.Holiday, "孔子誕辰紀念日/教師節"),
            new DayRecord(1009, DayKind.MakeupHoliday, "補假"),
            new DayRecord(1010, DayKind.Holiday, "國慶日"),
            new DayRecord(1025, DayKind.Holiday, "臺灣光復暨金門古寧頭大捷紀念日"),
            new DayRecord(1026, DayKind.MakeupHoliday, "補假"),
            new DayRecord(1225, DayKind.Holiday, "行憲紀念日"),
        };
    }
}
