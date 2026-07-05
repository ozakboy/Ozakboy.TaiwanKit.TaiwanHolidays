# API Reference

## HolidayCalendar (static entry point)

### Basic queries

| Member | Returns | Description |
|--------|---------|-------------|
| `IsHoliday(DateTime)` | `bool` | Whether the day is off (weekend/holiday/make-up holiday/adjusted); throws when out of range |
| `IsWorkday(DateTime)` | `bool` | Whether the day is a workday (regular or **make-up workday**) |
| `GetDayInfo(DateTime)` | `TaiwanDayInfo` | Complete day info |
| `TryGetDayInfo(DateTime, out TaiwanDayInfo?)` | `bool` | Returns false (no throw) when out of range |

`DateOnly` overloads are available on net8+ (`IsHoliday` / `IsWorkday` / `GetDayInfo`).

### Yearly lists

| Member | Returns | Description |
|--------|---------|-------------|
| `GetHolidays(int year)` | `IReadOnlyList<TaiwanDayInfo>` | Holidays / make-up holidays / adjusted days off (regular weekends excluded) |
| `GetMakeupWorkdays(int year)` | `IReadOnlyList<TaiwanDayInfo>` | Make-up workdays |

### Scheduling helpers

| Member | Returns | Description |
|--------|---------|-------------|
| `GetNextWorkday(DateTime)` | `DateTime` | Next workday (exclusive) |
| `GetPreviousWorkday(DateTime)` | `DateTime` | Previous workday (exclusive) |
| `CountWorkdays(from, to)` | `int` | Inclusive workday count; throws `ArgumentException` when from > to |
| `GetHolidayPeriods(int year)` | `IReadOnlyList<HolidayPeriod>` | 3+ day breaks; cross-year periods appear untruncated in both years |

### Coverage

| Member | Value |
|--------|-------|
| `MinDate` | 2017-01-01 |
| `MaxDate` | 2027-12-31 |
| `SupportedYears` | 2017-2027 |

## TaiwanDayInfo

| Property | Type | Description |
|----------|------|-------------|
| `Date` | `DateTime` | The date |
| `Kind` | `DayKind` | Day classification |
| `Name` | `string?` | Official holiday/make-up name (e.g. "春節"); null for regular days |
| `EnglishName` | `string?` | English name mapping |
| `IsWorkday` / `IsHoliday` | `bool` | Convenience properties |

## DayKind

| Value | Description | IsWorkday |
|-------|-------------|-----------|
| `Workday` | Regular workday | ✅ |
| `Weekend` | Regular weekend | ❌ |
| `Holiday` | National holiday | ❌ |
| `MakeupHoliday` | Make-up holiday | ❌ |
| `AdjustedHoliday` | Adjusted day off | ❌ |
| `MakeupWorkday` | Make-up workday (Saturday) | ✅ |

## HolidayPeriod

| Property | Type | Description |
|----------|------|-------------|
| `Start` / `End` | `DateTime` | Period boundaries |
| `TotalDays` | `int` | Total days |
| `Name` / `EnglishName` | `string?` | Representative name (most frequent holiday name, e.g. "春節") |

## Exception behavior

- Date/year outside 2017-2027 → `ArgumentOutOfRangeException` (never guesses)
- `GetNextWorkday` / `GetPreviousWorkday` walking past the data range → same
- `CountWorkdays` with from later than to → `ArgumentException`
- Only the date part of the input `DateTime` is used; time and Kind are ignored
