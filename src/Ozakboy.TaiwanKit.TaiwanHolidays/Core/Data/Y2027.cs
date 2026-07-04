// 資料來源：行政院人事行政總處「政府行政機關辦公日曆表」民國 116 年版（data.gov.tw dataset 14718）
// Source: DGPA official calendar for 2027 (data.gov.tw dataset 14718), generated 2026-07-04
namespace Ozakboy.TaiwanKit.TaiwanHolidays.Core.Data
{
    /// <summary>
    /// 2027 年例外日資料（假日/補假/彈性放假/補班；一般工作日與週末由規則推導）
    /// Exceptional days of 2027 (holidays / make-up holidays / adjusted holidays / make-up workdays)
    /// </summary>
    internal static class Y2027
    {
        /// <summary>
        /// 2027 年例外日清單 / Exceptional-day list of 2027
        /// </summary>
        internal static readonly DayRecord[] Days =
        {
            new DayRecord( 101, DayKind.Holiday, "開國紀念日"),
            new DayRecord( 204, DayKind.Holiday, "小年夜"),
            new DayRecord( 205, DayKind.Holiday, "農曆除夕"),
            new DayRecord( 206, DayKind.Holiday, "春節"),
            new DayRecord( 207, DayKind.Holiday, "春節"),
            new DayRecord( 208, DayKind.Holiday, "春節"),
            new DayRecord( 209, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 210, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 228, DayKind.Holiday, "和平紀念日"),
            new DayRecord( 301, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 404, DayKind.Holiday, "兒童節"),
            new DayRecord( 405, DayKind.Holiday, "清明節"),
            new DayRecord( 406, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 430, DayKind.MakeupHoliday, "補假"),
            new DayRecord( 501, DayKind.Holiday, "勞動節"),
            new DayRecord( 609, DayKind.Holiday, "端午節"),
            new DayRecord( 915, DayKind.Holiday, "中秋節"),
            new DayRecord( 928, DayKind.Holiday, "孔子誕辰紀念日/教師節"),
            new DayRecord(1010, DayKind.Holiday, "國慶日"),
            new DayRecord(1011, DayKind.MakeupHoliday, "補假"),
            new DayRecord(1025, DayKind.Holiday, "臺灣光復暨金門古寧頭大捷紀念日"),
            new DayRecord(1224, DayKind.MakeupHoliday, "補假"),
            new DayRecord(1225, DayKind.Holiday, "行憲紀念日"),
            new DayRecord(1231, DayKind.MakeupHoliday, "補假"),
        };
    }
}
