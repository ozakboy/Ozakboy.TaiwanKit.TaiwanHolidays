# Changelog

All notable changes to **Ozakboy.TaiwanKit.TaiwanHolidays** are documented here.

## [1.0.0] - 2026-07-04

### Added

- Holiday / workday queries backed by the official DGPA government office calendar, with **2017–2027 data embedded** (works offline, zero dependencies)
- Six-way day classification: workday, weekend, holiday, make-up holiday, adjusted day off, make-up workday — make-up Saturdays correctly count as workdays
- `GetDayInfo` / `TryGetDayInfo` with official holiday names (Traditional Chinese + English mapping)
- Yearly lists: `GetHolidays(year)` and `GetMakeupWorkdays(year)`
- Scheduling helpers: `GetNextWorkday`, `GetPreviousWorkday`, `CountWorkdays(from, to)` (inclusive)
- `GetHolidayPeriods(year)`: consecutive 3+ day breaks with representative names; cross-year periods reported untruncated in both years
- Explicit range semantics: out-of-range queries throw `ArgumentOutOfRangeException`; `MinDate` / `MaxDate` / `SupportedYears` exposed
- `DateOnly` overloads on .NET 8+
- Data reflects the 2025 statutory holiday reform (Teachers' Day, Retrocession Day, Constitution Day, Labor Day for all, Lunar New Year's Eve Eve)

### Technical

- Target frameworks: `netstandard2.0` / `netstandard2.1` / `net8.0` / `net9.0` / `net10.0`
- Data source: data.gov.tw dataset 14718 (DGPA official calendars, incl. the 2025-10-20 revision for 2025 and the June 2026 release for 2027); per-year sources annotated in code
- Exception-day storage with rule-derived regular days; lazy immutable lookup table, thread-safe
- Deterministic build, SourceLink, symbol package (`snupkg`), bilingual XML docs
