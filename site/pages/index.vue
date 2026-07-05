<script setup>
useHead({ title: 'TaiwanHolidays — 台灣國定假日/補班日查詢 .NET 套件' })
const localePath = useLocalePath()

const features = [
  { key: 'official', icon: '📅' },
  { key: 'makeup', icon: '🗓️' },
  { key: 'scheduling', icon: '⏭️' },
  { key: 'periods', icon: '🏖️' },
]
</script>

<template>
  <div>
    <!-- Hero -->
    <section class="bg-gradient-to-br from-brand-900 via-brand-700 to-brand-500 text-white">
      <div class="max-w-6xl mx-auto px-4 py-20 sm:py-28 text-center">
        <h1 class="text-4xl sm:text-6xl font-extrabold tracking-tight">
          {{ $t('home.hero.title') }}
        </h1>
        <p class="mt-6 text-lg sm:text-xl text-brand-50 max-w-3xl mx-auto leading-relaxed">
          {{ $t('home.hero.subtitle') }}
        </p>
        <div class="mt-10 flex justify-center gap-3 flex-wrap">
          <NuxtLink
            :to="localePath('/docs/getting-started')"
            class="bg-white text-brand-900 px-6 py-3 rounded font-semibold hover:bg-brand-50 transition"
          >
            {{ $t('home.hero.install') }}
          </NuxtLink>
          <a
            href="https://github.com/ozakboy/Ozakboy.TaiwanKit.TaiwanHolidays"
            target="_blank"
            rel="noopener"
            class="bg-brand-900/40 text-white px-6 py-3 rounded font-semibold hover:bg-brand-900/60 border border-white/30 transition"
          >
            {{ $t('home.hero.github') }}
          </a>
        </div>
      </div>
    </section>

    <!-- Features -->
    <section class="max-w-6xl mx-auto px-4 py-16 sm:py-20">
      <h2 class="text-3xl sm:text-4xl font-bold text-center mb-12">
        {{ $t('home.features.title') }}
      </h2>
      <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6">
        <div
          v-for="f in features"
          :key="f.key"
          class="bg-white border border-slate-200 rounded-lg p-6 hover:shadow-lg hover:border-brand-500 transition"
        >
          <div class="text-3xl mb-3">{{ f.icon }}</div>
          <h3 class="font-bold text-lg mb-2">
            {{ $t(`home.features.items.${f.key}.title`) }}
          </h3>
          <p class="text-slate-600 text-sm leading-relaxed">
            {{ $t(`home.features.items.${f.key}.desc`) }}
          </p>
        </div>
      </div>
    </section>

    <!-- Quick Start -->
    <section class="bg-white py-16 sm:py-20 border-t border-slate-200">
      <div class="max-w-4xl mx-auto px-4">
        <h2 class="text-3xl sm:text-4xl font-bold text-center mb-12">
          {{ $t('home.quickstart.title') }}
        </h2>
        <div class="space-y-8">
          <div>
            <h3 class="font-semibold text-lg mb-3">{{ $t('home.quickstart.step1') }}</h3>
            <pre class="bg-slate-900 text-slate-100 rounded p-4 text-sm overflow-x-auto"><code>dotnet add package Ozakboy.TaiwanKit.TaiwanHolidays</code></pre>
          </div>
          <div>
            <h3 class="font-semibold text-lg mb-3">{{ $t('home.quickstart.step2') }}</h3>
            <pre class="bg-slate-900 text-slate-100 rounded p-4 text-sm overflow-x-auto"><code>using Ozakboy.TaiwanKit.TaiwanHolidays;

HolidayCalendar.IsHoliday(new DateTime(2026, 10, 10));   // true（國慶日）
HolidayCalendar.IsWorkday(new DateTime(2023, 1, 7));     // true（補班的週六！）

TaiwanDayInfo info = HolidayCalendar.GetDayInfo(new DateTime(2026, 2, 17));
// info.Kind → Holiday, info.Name → "春節"</code></pre>
          </div>
          <div>
            <h3 class="font-semibold text-lg mb-3">{{ $t('home.quickstart.step3') }}</h3>
            <pre class="bg-slate-900 text-slate-100 rounded p-4 text-sm overflow-x-auto"><code>// 跨過春節連假找下一個工作日
HolidayCalendar.GetNextWorkday(new DateTime(2026, 2, 13));   // 2026-02-23

// 區間工作日數（含頭尾）
HolidayCalendar.CountWorkdays(new DateTime(2026, 2, 1), new DateTime(2026, 2, 28));

// 連假清單（≥3 天）
HolidayCalendar.GetHolidayPeriods(2026);   // 例如 02/14~02/22 春節 9 天</code></pre>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>
