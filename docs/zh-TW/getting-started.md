# 快速開始

## 安裝

```bash
dotnet add package Ozakboy.TaiwanKit.TaiwanHolidays
```

支援框架：`netstandard2.0` / `netstandard2.1` / `net8.0` / `net9.0` / `net10.0`（net8+ 提供 `DateOnly` 多載），零執行期依賴、離線可用。

## 基本查詢

```csharp
using Ozakboy.TaiwanKit.TaiwanHolidays;

HolidayCalendar.IsHoliday(new DateTime(2026, 10, 10));   // true（國慶日）
HolidayCalendar.IsWorkday(new DateTime(2023, 1, 7));     // true（補班的週六！）

TaiwanDayInfo info = HolidayCalendar.GetDayInfo(new DateTime(2026, 2, 17));
// info.Kind        → DayKind.Holiday
// info.Name        → "春節"
// info.EnglishName → "Lunar New Year"
```

六種日型分類：`Workday`（工作日）、`Weekend`（例假日）、`Holiday`（國定假日）、`MakeupHoliday`（補假）、`AdjustedHoliday`（彈性放假）、`MakeupWorkday`（補行上班）。**`IsWorkday` = Workday 或 MakeupWorkday**——補班的週六是工作日。

## 排程輔助

```csharp
// 跨過春節連假找下一個工作日
HolidayCalendar.GetNextWorkday(new DateTime(2026, 2, 13));       // 2026-02-23

// 區間工作日數（含頭尾）
HolidayCalendar.CountWorkdays(new DateTime(2026, 2, 1), new DateTime(2026, 2, 28));

// 連假清單（3 天以上）
foreach (HolidayPeriod p in HolidayCalendar.GetHolidayPeriods(2026))
{
    Console.WriteLine($"{p.Start:MM/dd}~{p.End:MM/dd} 共 {p.TotalDays} 天 {p.Name}");
}
// 例如 02/14~02/22 共 9 天 春節
```

## 年度清單

```csharp
HolidayCalendar.GetHolidays(2026);         // 該年假日清單（國定假日/補假/彈休）
HolidayCalendar.GetMakeupWorkdays(2023);   // 該年補班日清單
```

## 超出範圍的行為

資料涵蓋 **2017-01-01 ～ 2027-12-31**。超出範圍的查詢**一律拋 `ArgumentOutOfRangeException`**——本套件絕不用「只看週末」猜測。需要優雅處理時：

```csharp
if (HolidayCalendar.TryGetDayInfo(date, out TaiwanDayInfo? info))
{
    // 在範圍內
}

// 或事先檢查
var min = HolidayCalendar.MinDate;   // 2017-01-01
var max = HolidayCalendar.MaxDate;   // 2027-12-31
```

## 資料政策

- 唯一來源：行政院人事行政總處「政府行政機關辦公日曆表」（data.gov.tw 開放資料）
- 已含 2025《紀念日及節日實施條例》新制假日（教師節、光復節、行憲紀念日、全民勞動節、小年夜）
- 每年約 5~6 月官方公告次年行事曆後，以 Minor 版釋出新年度資料
- 不含颱風停班（非全國統一）與只紀念不放假的節日
