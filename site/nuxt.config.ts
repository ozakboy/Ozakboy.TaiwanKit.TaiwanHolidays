// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2025-01-01',
  devtools: { enabled: true },

  // Nuxt site config (used by sitemap module to prepend absolute URL)
  site: {
    url: 'https://holidays.ozakboy.life',
    name: 'Ozakboy.TaiwanKit.TaiwanHolidays',
    description:
      'Taiwan national holidays and make-up workday queries for .NET. Official DGPA calendar data (2017-2027) embedded, works offline, zero dependencies.',
  },

  app: {
    baseURL: '/',
    head: {
      title: 'TaiwanHolidays — 台灣國定假日/補班日查詢 .NET 套件',
      htmlAttrs: { lang: 'zh-TW' },
      meta: [
        { charset: 'utf-8' },
        { name: 'viewport', content: 'width=device-width, initial-scale=1' },
        {
          name: 'description',
          content:
            'Ozakboy.TaiwanKit.TaiwanHolidays — Taiwan holiday / workday queries for .NET. Official government calendar 2017-2027 embedded, make-up Saturdays handled correctly, next-workday and holiday-period helpers. Zero dependencies.',
        },
        {
          name: 'keywords',
          content:
            'Taiwan holidays, 台灣國定假日, 補班日, 行事曆, TaiwanHolidays, TaiwanKit, .NET, csharp, NuGet, dotnet, workday, calendar',
        },
        { name: 'author', content: 'ozakboy' },

        // Search engine verification
        {
          name: 'google-site-verification',
          content: '7B6Z2O-JFfFD6I0jeayWg1SFeDWKZmf4RwSVGbQHmVk',
        },
        { name: 'msvalidate.01', content: '4928B4223346F74DB53D9754C37164AB' },

        // Open Graph
        { property: 'og:type', content: 'website' },
        { property: 'og:site_name', content: 'Ozakboy.TaiwanKit.TaiwanHolidays' },
        { property: 'og:title', content: 'TaiwanHolidays — Taiwan Holiday / Workday Queries for .NET' },
        {
          property: 'og:description',
          content:
            'Official Taiwan government calendar (2017-2027) embedded. Make-up Saturdays handled correctly. Next-workday, workday counting and holiday-period helpers.',
        },
        { property: 'og:url', content: 'https://holidays.ozakboy.life/' },
        { property: 'og:image', content: 'https://holidays.ozakboy.life/logo.png' },
        { property: 'og:image:alt', content: 'Ozakboy.TaiwanKit logo' },
        { property: 'og:locale', content: 'zh_TW' },
        { property: 'og:locale:alternate', content: 'en_US' },

        // Twitter Card
        { name: 'twitter:card', content: 'summary' },
        { name: 'twitter:title', content: 'TaiwanHolidays — Taiwan Holiday / Workday Queries for .NET' },
        {
          name: 'twitter:description',
          content:
            'Official Taiwan calendar 2017-2027 embedded, offline, zero dependencies. Make-up workdays handled correctly.',
        },
        { name: 'twitter:image', content: 'https://holidays.ozakboy.life/logo.png' },
      ],
      link: [
        { rel: 'icon', type: 'image/png', href: '/logo.png' },
        { rel: 'apple-touch-icon', href: '/logo.png' },
        { rel: 'canonical', href: 'https://holidays.ozakboy.life/' },
      ],
    },
  },

  modules: [
    '@nuxtjs/i18n',
    '@nuxtjs/tailwindcss',
    '@nuxt/content',
    '@nuxtjs/sitemap',
  ],

  // @nuxt/content 讀 site/content/,由 scripts/sync-docs.mjs 自 ../docs/ 同步
  content: {
    build: {
      markdown: {
        toc: { depth: 3 },
        highlight: {
          theme: 'github-light',
        },
      },
    },
  },

  i18n: {
    baseUrl: 'https://holidays.ozakboy.life',
    locales: [
      { code: 'zh-TW', name: '繁體中文', file: 'zh-TW.json' },
      { code: 'en', name: 'English', file: 'en.json' },
    ],
    defaultLocale: 'zh-TW',
    strategy: 'prefix_except_default',
    langDir: 'locales/',
    detectBrowserLanguage: {
      useCookie: true,
      cookieKey: 'i18n_redirected',
      redirectOn: 'root',
    },
  },

  sitemap: {
    autoLastmod: true,
  },

  nitro: {
    preset: 'github_pages',
  },

  ssr: true,
})
