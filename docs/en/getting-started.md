# Getting Started

## Install

```bash
dotnet add package Ozakboy.TaiwanKit.TaiwanHolidays
```

Supported frameworks: `netstandard2.0` / `netstandard2.1` / `net8.0` / `net9.0` / `net10.0` (with `DateOnly` overloads on net8+). Zero runtime dependencies, works fully offline.

## Basic queries

```csharp
using Ozakboy.TaiwanKit.TaiwanHolidays;

HolidayCalendar.IsHoliday(new DateTime(2026, 10, 10));   // true  (National Day)
HolidayCalendar.IsWorkday(new DateTime(2023, 1, 7));     // true  (a make-up Saturday!)

TaiwanDayInfo info = HolidayCalendar.GetDayInfo(new DateTime(2026, 2, 17));
// info.Kind        → DayKind.Holiday
// info.Name        → "春節"
// info.EnglishName → "Lunar New Year"
```

Six-way day classification: `Workday`, `Weekend`, `Holiday`, `MakeupHoliday`, `AdjustedHoliday`, `MakeupWorkday`. **`IsWorkday` = Workday or MakeupWorkday** — make-up Saturdays are workdays.

## Scheduling helpers

```csharp
// Next workday across the Lunar New Year break
HolidayCalendar.GetNextWorkday(new DateTime(2026, 2, 13));       // 2026-02-23

// Inclusive workday count
HolidayCalendar.CountWorkdays(new DateTime(2026, 2, 1), new DateTime(2026, 2, 28));

// Consecutive holiday periods (3+ days)
foreach (HolidayPeriod p in HolidayCalendar.GetHolidayPeriods(2026))
{
    Console.WriteLine($"{p.Start:MM/dd}~{p.End:MM/dd} {p.TotalDays} days {p.Name}");
}
// e.g. 02/14~02/22 9 days 春節
```

## Yearly lists

```csharp
HolidayCalendar.GetHolidays(2026);         // holidays / make-up holidays / adjusted days off
HolidayCalendar.GetMakeupWorkdays(2023);   // make-up Saturdays of the year
```

## Out-of-range behavior

Data covers **2017-01-01 to 2027-12-31**. Out-of-range queries **always throw `ArgumentOutOfRangeException`** — this library never guesses from weekends alone. For graceful handling:

```csharp
if (HolidayCalendar.TryGetDayInfo(date, out TaiwanDayInfo? info))
{
    // within range
}

// or check beforehand
var min = HolidayCalendar.MinDate;   // 2017-01-01
var max = HolidayCalendar.MaxDate;   // 2027-12-31
```

## Data policy

- Single source: the official DGPA "government office calendar" (data.gov.tw open data)
- Includes the 2025 statutory holiday reform (Teachers' Day, Retrocession Day, Constitution Day, Labor Day for all, Lunar New Year's Eve Eve)
- A new minor version ships after each yearly announcement (around May-June)
- Not included: typhoon suspensions (not nationwide-uniform) and observances that are not days off
