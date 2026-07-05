# 更新紀錄

**Ozakboy.TaiwanKit.TaiwanHolidays** 的所有重要變更記錄於此。

## [1.0.1] - 2026-07-05

### 功能優化

- 加入 Ozakboy.TaiwanKit 系列 logo 作為 NuGet 套件圖示與 README 標頭

## [1.0.0] - 2026-07-04

### 新增功能

- 以人事行政總處官方辦公日曆表為基礎的假日/工作日查詢，**內嵌 2017～2027 資料**（離線可用、零依賴）
- 六種日型分類：工作日、例假日、國定假日、補假、調整放假、補行上班——補班週六正確判為工作日
- `GetDayInfo` / `TryGetDayInfo` 附官方假日名稱（繁中＋英文對照）
- 年度清單：`GetHolidays(year)` 與 `GetMakeupWorkdays(year)`
- 排程輔助：`GetNextWorkday`、`GetPreviousWorkday`、`CountWorkdays(from, to)`（含頭尾）
- `GetHolidayPeriods(year)`：連續 3 天以上連假（附代表名稱）；跨年連假在兩個年份都完整呈現、不截斷
- 明確範圍語意：超出範圍拋 `ArgumentOutOfRangeException`；提供 `MinDate` / `MaxDate` / `SupportedYears`
- .NET 8+ 提供 `DateOnly` 多載
- 資料已反映 2025《紀念日及節日實施條例》新制（教師節、光復節、行憲紀念日、全民勞動節、小年夜）

### 技術改進

- 目標框架：`netstandard2.0` / `netstandard2.1` / `net8.0` / `net9.0` / `net10.0`
- 資料來源：data.gov.tw dataset 14718（人事行政總處官方日曆表，含 114 年 10/20 修正版與 2026 年 6 月發布的 116 年版）；各年度來源標注於原始碼
- 例外日儲存＋規則推導一般日；Lazy 不可變查詢表、線程安全
- 可重現建置、SourceLink、符號套件（`snupkg`）、中英雙語 XML 文件
