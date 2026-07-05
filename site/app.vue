<script setup lang="ts">
// JSON-LD 結構化資料 — 讓 Google 認得這是 SoftwareApplication
const jsonLd = {
  '@context': 'https://schema.org',
  '@type': 'SoftwareApplication',
  name: 'Ozakboy.TaiwanKit.TaiwanHolidays',
  alternateName: ['TaiwanHolidays', 'Taiwan Holidays for .NET'],
  applicationCategory: 'DeveloperApplication',
  applicationSubCategory: 'Calendar Library',
  operatingSystem: 'Cross-platform (.NET Standard 2.0+, .NET 8/9/10)',
  description:
    'Taiwan national holidays and make-up workday queries for .NET. Official DGPA government office calendar data (2017-2027) embedded — works fully offline with zero runtime dependencies. Six-way day classification, next/previous workday, workday counting and consecutive holiday periods.',
  url: 'https://holidays.ozakboy.life/',
  downloadUrl: 'https://www.nuget.org/packages/Ozakboy.TaiwanKit.TaiwanHolidays/',
  image: 'https://holidays.ozakboy.life/logo.png',
  author: {
    '@type': 'Person',
    name: 'ozakboy',
    url: 'https://github.com/ozakboy',
  },
  license: 'https://opensource.org/licenses/MIT',
  programmingLanguage: 'C#',
  offers: {
    '@type': 'Offer',
    price: '0',
    priceCurrency: 'USD',
  },
  softwareVersion: '1.0.1',
}

useHead({
  script: [
    {
      type: 'application/ld+json',
      innerHTML: JSON.stringify(jsonLd),
    },
  ],
})
</script>

<template>
  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>
</template>
