# Ozakboy.TaiwanKit.TaiwanHolidays

[English](https://github.com/ozakboy/Ozakboy.TaiwanKit.TaiwanHolidays/blob/main/README.md)

.NET 台灣國定假日/補班日查詢套件。內嵌官方行事曆資料（**2017～2027**），完全離線可用、**零執行期依賴**。

**Ozakboy.TaiwanKit** 系列套件之一。

## 功能特色

- **放假/上班判斷** — `IsHoliday` / `IsWorkday`，**補班的週六正確判為工作日**（這是與「只看週末」的關鍵差異）
- **單日詳細資訊** — 六種日型分類（工作日/例假日/國定假日/補假/彈性放假/補行上班）＋官方假日名稱（中文＋英文）
- **排程輔助** — 下一個/上一個工作日、區間工作日計算、連假查詢（例如 2026 春節 9 天連假）
- **官方資料內嵌** — 資料來自人事行政總處「政府行政機關辦公日曆表」開放資料（data.gov.tw dataset 14718），已含 2025 新制假日；每年新公告以 Minor 版更新
- **明確的範圍語意** — 查詢超出 2017～2027 一律拋例外（絕不用猜的）；可用 `TryGetDayInfo` 與 `MinDate`/`MaxDate` 優雅處理

## 安裝

```
dotnet add package Ozakboy.TaiwanKit.TaiwanHolidays
```

支援框架：`netstandard2.0` / `netstandard2.1` / `net8.0` / `net9.0` / `net10.0`（net8+ 提供 `DateOnly` 多載）

## 快速開始

```csharp
using Ozakboy.TaiwanKit.TaiwanHolidays;

HolidayCalendar.IsHoliday(new DateTime(2026, 10, 10));   // true （國慶日）
HolidayCalendar.IsWorkday(new DateTime(2023, 1, 7));     // true （補班的週六！）

TaiwanDayInfo info = HolidayCalendar.GetDayInfo(new DateTime(2026, 2, 17));
// info.Kind        → DayKind.Holiday
// info.Name        → "春節"
// info.EnglishName → "Lunar New Year"

// 排程輔助
HolidayCalendar.GetNextWorkday(new DateTime(2026, 2, 13));                       // 2026-02-23（跨過春節連假）
HolidayCalendar.CountWorkdays(new DateTime(2026, 2, 1), new DateTime(2026, 2, 28)); // 2026 年 2 月工作日數

// 連假查詢
foreach (HolidayPeriod p in HolidayCalendar.GetHolidayPeriods(2026))
{
    Console.WriteLine($"{p.Start:MM/dd}~{p.End:MM/dd} 共 {p.TotalDays} 天 {p.Name}");
}
// 例如 02/14~02/22 共 9 天 春節

// 超出範圍的處理
HolidayCalendar.TryGetDayInfo(new DateTime(2030, 1, 1), out _);  // false — 資料未涵蓋，不猜測
```

## API 總覽

| 成員 | 說明 |
|------|------|
| `IsHoliday(date)` / `IsWorkday(date)` | 放假/上班判斷（超出涵蓋範圍拋例外） |
| `GetDayInfo(date)` → `TaiwanDayInfo` | 日型分類、假日名稱（中＋英） |
| `TryGetDayInfo(date, out info)` | 不拋例外版本，超出範圍回 `false` |
| `GetHolidays(year)` | 某年假日清單（國定假日/補假/彈休；不含一般週末） |
| `GetMakeupWorkdays(year)` | 某年補班日清單 |
| `GetNextWorkday(date)` / `GetPreviousWorkday(date)` | 下一個/上一個工作日（不含當日） |
| `CountWorkdays(from, to)` | 區間工作日數（含頭尾） |
| `GetHolidayPeriods(year)` | 與該年重疊的連假（≥3 天；跨年連假不截斷） |
| `MinDate` / `MaxDate` / `SupportedYears` | 資料涵蓋範圍 |

## 資料政策

- **來源**：行政院人事行政總處「政府行政機關辦公日曆表」——政府機關行事曆，也是台灣一般公司行號的實際依循基準。
- **涵蓋**：2017-01-01 ～ 2027-12-31。每個年度資料在原始碼中標注來源。
- **每年更新**：人事行政總處約每年 5～6 月公告次年行事曆，公告後以 Minor 版釋出。
- **不包含**：颱風停班停課（非全國統一）、只紀念不放假的節日、2025 年以前的勞動節（勞工放假但政府機關上班——本套件以政府行事曆為準）。

## 連結

- 更新紀錄：[docs/zh-TW/changelog.md](https://github.com/ozakboy/Ozakboy.TaiwanKit.TaiwanHolidays/blob/main/docs/zh-TW/changelog.md)
- 授權：MIT

## Ozakboy.TaiwanKit 系列

| 套件 | 說明 |
|------|------|
| `Ozakboy.TaiwanKit.TwIdValidator` | 台灣身分證/統編/手機驗證 |
| `Ozakboy.TaiwanKit.TaiwanHolidays` | 台灣國定假日/補班日查詢（本套件） |
| `Ozakboy.TaiwanKit.Ganzhi.NET` | 農曆/節氣/干支轉換 |
