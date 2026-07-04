# Ozakboy.TaiwanKit.TaiwanHolidays

[繁體中文](https://github.com/ozakboy/Ozakboy.TaiwanKit.TaiwanHolidays/blob/main/README_zh-TW.md)

Taiwan national holidays and make-up workday queries for .NET. Official government office calendar data (**2017–2027**) embedded — works fully offline, **zero runtime dependencies**.

Part of the **Ozakboy.TaiwanKit** series.

## Features

- **Holiday / workday checks** — `IsHoliday` / `IsWorkday`, correctly treating make-up Saturdays as workdays
- **Day details** — six-way day classification (workday / weekend / holiday / make-up holiday / adjusted day off / make-up workday) with official holiday names (zh-TW + English)
- **Scheduling helpers** — next/previous workday, workday counting between dates, consecutive holiday periods (e.g. the 9-day Lunar New Year break)
- **Official data embedded** — sourced from Taiwan's DGPA "government office calendar" open data (data.gov.tw dataset 14718), including the post-2025 new statutory holidays; new years ship as minor package updates
- **Explicit range semantics** — queries outside 2017–2027 throw (never guess); `TryGetDayInfo` and `MinDate`/`MaxDate` for graceful handling

## Install

```
dotnet add package Ozakboy.TaiwanKit.TaiwanHolidays
```

Supported frameworks: `netstandard2.0` / `netstandard2.1` / `net8.0` / `net9.0` / `net10.0` (with `DateOnly` overloads on net8+)

## Quick start

```csharp
using Ozakboy.TaiwanKit.TaiwanHolidays;

HolidayCalendar.IsHoliday(new DateTime(2026, 10, 10));   // true  (National Day)
HolidayCalendar.IsWorkday(new DateTime(2023, 1, 7));     // true  (make-up Saturday!)

TaiwanDayInfo info = HolidayCalendar.GetDayInfo(new DateTime(2026, 2, 17));
// info.Kind        → DayKind.Holiday
// info.Name        → "春節"
// info.EnglishName → "Lunar New Year"

// Scheduling helpers
HolidayCalendar.GetNextWorkday(new DateTime(2026, 2, 13));                       // 2026-02-23 (after the CNY break)
HolidayCalendar.CountWorkdays(new DateTime(2026, 2, 1), new DateTime(2026, 2, 28)); // workdays in Feb 2026

// Consecutive holiday periods
foreach (HolidayPeriod p in HolidayCalendar.GetHolidayPeriods(2026))
{
    Console.WriteLine($"{p.Start:MM/dd}~{p.End:MM/dd} {p.TotalDays} days {p.Name}");
}
// e.g. 02/14~02/22 9 days 春節

// Out-of-range handling
HolidayCalendar.TryGetDayInfo(new DateTime(2030, 1, 1), out _);  // false — data not covered, no guessing
```

## API overview

| Member | Description |
|--------|-------------|
| `IsHoliday(date)` / `IsWorkday(date)` | Day-off / workday check (throws outside covered range) |
| `GetDayInfo(date)` → `TaiwanDayInfo` | Kind, holiday name (zh-TW + en) |
| `TryGetDayInfo(date, out info)` | Non-throwing variant, `false` when out of range |
| `GetHolidays(year)` | Holidays, make-up holidays and adjusted days off of a year (weekends excluded) |
| `GetMakeupWorkdays(year)` | Make-up Saturdays of a year |
| `GetNextWorkday(date)` / `GetPreviousWorkday(date)` | Next / previous workday (exclusive) |
| `CountWorkdays(from, to)` | Workday count, both ends inclusive |
| `GetHolidayPeriods(year)` | Consecutive 3+ day breaks overlapping the year (cross-year periods untruncated) |
| `MinDate` / `MaxDate` / `SupportedYears` | Data coverage |

## Data policy

- **Source**: DGPA (行政院人事行政總處) official "government office calendar" — the calendar for government agencies, which is also the de-facto business calendar in Taiwan.
- **Coverage**: 2017-01-01 to 2027-12-31. Each year's data is annotated with its source in the repository.
- **Yearly updates**: DGPA announces next year's calendar around May–June; a new minor version ships after each announcement.
- **Not included**: typhoon days / ad-hoc suspensions (not nationwide-uniform), observances that are not days off, and pre-2025 Labor Day (which applied to workers but not government offices — this package models the government calendar).

## Links

- Changelog: [docs/en/changelog.md](https://github.com/ozakboy/Ozakboy.TaiwanKit.TaiwanHolidays/blob/main/docs/en/changelog.md)
- License: MIT

## Ozakboy.TaiwanKit series

| Package | Description |
|---------|-------------|
| `Ozakboy.TaiwanKit.TwIdValidator` | Taiwan ID / BAN / mobile number validation |
| `Ozakboy.TaiwanKit.TaiwanHolidays` | Taiwan national holidays / make-up workday queries (this package) |
| `Ozakboy.TaiwanKit.Ganzhi.NET` | Lunar calendar / solar terms / Ganzhi conversion |
