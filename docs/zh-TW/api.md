# API 參考

## HolidayCalendar（靜態入口）

### 基本查詢

| 成員 | 回傳 | 說明 |
|------|------|------|
| `IsHoliday(DateTime)` | `bool` | 是否放假（例假日/國定假日/補假/彈休）；超出範圍拋例外 |
| `IsWorkday(DateTime)` | `bool` | 是否工作日（一般工作日或**補行上班日**） |
| `GetDayInfo(DateTime)` | `TaiwanDayInfo` | 完整單日資訊 |
| `TryGetDayInfo(DateTime, out TaiwanDayInfo?)` | `bool` | 超出範圍回 false 不拋例外 |

net8+ 另提供 `DateOnly` 多載（`IsHoliday` / `IsWorkday` / `GetDayInfo`）。

### 年度清單

| 成員 | 回傳 | 說明 |
|------|------|------|
| `GetHolidays(int year)` | `IReadOnlyList<TaiwanDayInfo>` | 國定假日/補假/彈休（不含一般週末） |
| `GetMakeupWorkdays(int year)` | `IReadOnlyList<TaiwanDayInfo>` | 補班日清單 |

### 排程輔助

| 成員 | 回傳 | 說明 |
|------|------|------|
| `GetNextWorkday(DateTime)` | `DateTime` | 下一個工作日（不含當日） |
| `GetPreviousWorkday(DateTime)` | `DateTime` | 上一個工作日（不含當日） |
| `CountWorkdays(from, to)` | `int` | 區間工作日數（含頭尾）；from > to 拋 `ArgumentException` |
| `GetHolidayPeriods(int year)` | `IReadOnlyList<HolidayPeriod>` | ≥3 天連假；跨年連假在兩年結果中都完整出現 |

### 涵蓋範圍

| 成員 | 值 |
|------|-----|
| `MinDate` | 2017-01-01 |
| `MaxDate` | 2027-12-31 |
| `SupportedYears` | 2017～2027 |

## TaiwanDayInfo

| 屬性 | 型別 | 說明 |
|------|------|------|
| `Date` | `DateTime` | 日期 |
| `Kind` | `DayKind` | 日型分類 |
| `Name` | `string?` | 官方假日/補班名稱（如「春節」）；一般日為 null |
| `EnglishName` | `string?` | 英文名稱對照 |
| `IsWorkday` / `IsHoliday` | `bool` | 便利屬性 |

## DayKind

| 值 | 說明 | IsWorkday |
|-----|------|-----------|
| `Workday` | 一般工作日 | ✅ |
| `Weekend` | 例假日（一般週六日） | ❌ |
| `Holiday` | 國定假日 | ❌ |
| `MakeupHoliday` | 補假 | ❌ |
| `AdjustedHoliday` | 調整放假（彈性放假） | ❌ |
| `MakeupWorkday` | 補行上班（週六補班） | ✅ |

## HolidayPeriod

| 屬性 | 型別 | 說明 |
|------|------|------|
| `Start` / `End` | `DateTime` | 連假頭尾 |
| `TotalDays` | `int` | 總天數 |
| `Name` / `EnglishName` | `string?` | 代表名稱（區段內最多次的假日名，如「春節」） |

## 例外行為

- 日期/年份超出 2017～2027 → `ArgumentOutOfRangeException`（絕不猜測）
- `GetNextWorkday` / `GetPreviousWorkday` 走出資料範圍 → 同上
- `CountWorkdays` 的 from 晚於 to → `ArgumentException`
- 輸入的 `DateTime` 只取日期部分，時間與 Kind 忽略
