// 資料來源：行政院人事行政總處「政府行政機關辦公日曆表」民國 108 年版（data.gov.tw dataset 14718）
// Source: DGPA official calendar for 2019 (data.gov.tw dataset 14718), generated 2026-07-04
namespace Ozakboy.TaiwanKit.TaiwanHolidays.Core.Data
{
    /// <summary>
    /// 2019 年例外日資料（假日/補假/彈性放假/補班；一般工作日與週末由規則推導）
    /// Exceptional days of 2019 (holidays / make-up holidays / adjusted holidays / make-up workdays)
    /// </summary>
    internal static class Y2019
    {
        /// <summary>
        /// 2019 年例外日清單 / Exceptional-day list of 2019
        /// </summary>
        internal static readonly DayRecord[] Days =
        {
            new DayRecord( 101, DayKind.Holiday, "開國紀念日"),
            new DayRecord( 119, DayKind.MakeupWorkday, "調整上班"),
            new DayRecord( 204, DayKind.Holiday, "農曆除夕"),
            new DayRecord( 205, DayKind.Holiday, "春節"),
            new DayRecord( 206, DayKind.Holiday, "春節"),
            new DayRecord( 207, DayKind.Holiday, "春節"),
            new DayRecord( 208, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord( 223, DayKind.MakeupWorkday, "調整上班"),
            new DayRecord( 228, DayKind.Holiday, "和平紀念日"),
            new DayRecord( 301, DayKind.AdjustedHoliday, "調整放假"),
            new DayRecord( 404, DayKind.Holiday, "兒童節"),
            new DayRecord( 405, DayKind.Holiday, "民族掃墓節"),
            new DayRecord( 607, DayKind.Holiday, "端午節"),
            new DayRecord( 913, DayKind.Holiday, "中秋節"),
            new DayRecord(1005, DayKind.MakeupWorkday, "調整上班"),
            new DayRecord(1010, DayKind.Holiday, "國慶日"),
            new DayRecord(1011, DayKind.AdjustedHoliday, "調整放假"),
        };
    }
}
