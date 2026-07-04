namespace Ozakboy.TaiwanKit.TaiwanHolidays.Core
{
    /// <summary>
    /// 假日中文名稱 → 英文名稱對照
    /// Chinese-to-English holiday name mapping
    /// </summary>
    internal static class HolidayNames
    {
        /// <summary>
        /// 取得假日名稱的英文對照；無對應時回傳 null
        /// Gets the English name for a holiday note; null when unmapped
        /// </summary>
        /// <param name="name">官方日曆表備註名稱 / Note from the official calendar</param>
        /// <returns>英文名稱或 null / English name or null</returns>
        internal static string? GetEnglishName(string? name)
        {
            switch (name)
            {
                case "開國紀念日": return "New Year's Day";
                case "小年夜": return "Day before Lunar New Year's Eve";
                case "農曆除夕": return "Lunar New Year's Eve";
                case "春節": return "Lunar New Year";
                case "和平紀念日": return "Peace Memorial Day";
                case "兒童節": return "Children's Day";
                case "民族掃墓節": return "Tomb Sweeping Day";
                case "兒童節及民族掃墓節": return "Children's Day and Tomb Sweeping Day";
                case "清明節": return "Tomb Sweeping Day";
                case "勞動節": return "Labor Day";
                case "端午節": return "Dragon Boat Festival";
                case "中秋節": return "Mid-Autumn Festival";
                case "國慶日": return "National Day";
                case "孔子誕辰紀念日": return "Confucius' Birthday (Teachers' Day)";
                case "孔子誕辰紀念日/教師節": return "Confucius' Birthday / Teachers' Day";
                case "臺灣光復暨金門古寧頭大捷紀念日": return "Taiwan Retrocession Day";
                case "行憲紀念日": return "Constitution Day";
                case "補假": return "Make-up holiday";
                case "調整放假": return "Adjusted day off";
                case "放假": return "Day off";
                case "補行上班": return "Make-up workday";
                case "調整上班": return "Make-up workday";
                default: return null;
            }
        }
    }
}
