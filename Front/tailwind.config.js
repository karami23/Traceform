/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        brand: {
          navy: '#0B1B3D',    // سرمه‌ای تیره هدر و بک‌گراندها
          blue: '#1E40AF',    // آبی تخصصی برق
          accent: '#10B981',  // سبز تماس اضطراری و اکشن‌ها
          slate: '#F8FAFC'    // پس‌زمینه روشن سکشن‌ها
        }
      }
    },
  },
  plugins: [],
}
