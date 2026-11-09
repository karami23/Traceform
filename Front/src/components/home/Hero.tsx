import React from 'react';
import { ShieldCheck, Clock, Award, Star, ArrowRight, PhoneCall } from 'lucide-react';

export const Hero: React.FC = () => {
  return (
    <section className="relative bg-gradient-to-br from-slate-950 via-slate-900 to-blue-950 text-white py-16 sm:py-24 overflow-hidden">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 relative z-10">
        <div className="grid lg:grid-cols-12 gap-12 items-center">
          
          {/* متن و اکشن‌ها */}
          <div className="lg:col-span-7 space-y-6">
            <div className="inline-flex items-center gap-2 bg-blue-900/60 border border-blue-700/50 px-3.5 py-1.5 rounded-full text-blue-300 text-xs sm:text-sm font-medium">
              <span className="w-2 h-2 rounded-full bg-emerald-400 animate-pulse"></span>
              Manchester & Greater Manchester Electricians
            </div>

            <h1 className="text-4xl sm:text-5xl lg:text-6xl font-black tracking-tight text-white leading-tight">
              Reliable, Certified <span className="text-transparent bg-clip-text bg-gradient-to-r from-blue-400 to-amber-300">Electrical Services</span>
            </h1>

            <p className="text-slate-300 text-base sm:text-lg max-w-2xl leading-relaxed">
              From emergency callouts to complete commercial rewiring and EV charger installations. NICEIC approved, fully insured, and highly reviewed by Manchester locals.
            </p>

            <div className="flex flex-wrap items-center gap-4 pt-2">
              <a
                href="#contact"
                className="bg-blue-600 hover:bg-blue-500 text-white font-bold px-6 py-3.5 rounded-xl shadow-lg shadow-blue-600/30 flex items-center gap-2 transition"
              >
                Request an Electrician <ArrowRight className="w-4 h-4" />
              </a>
              <a
                href="tel:01618204932"
                className="bg-slate-800/80 hover:bg-slate-700 border border-slate-700 text-slate-200 font-semibold px-6 py-3.5 rounded-xl flex items-center gap-2 transition"
              >
                <PhoneCall className="w-4 h-4 text-amber-400" /> 0161 820 4932
              </a>
            </div>

            {/* نشان‌های اعتماد */}
            <div className="grid grid-cols-3 gap-4 pt-6 border-t border-slate-800">
              <div className="flex items-center gap-2.5">
                <ShieldCheck className="w-5 h-5 text-emerald-400 shrink-0" />
                <span className="text-xs sm:text-sm font-medium text-slate-300">NICEIC Certified</span>
              </div>
              <div className="flex items-center gap-2.5">
                <Clock className="w-5 h-5 text-blue-400 shrink-0" />
                <span className="text-xs sm:text-sm font-medium text-slate-300">24/7 Rapid Response</span>
              </div>
              <div className="flex items-center gap-2.5">
                <Award className="w-5 h-5 text-amber-400 shrink-0" />
                <span className="text-xs sm:text-sm font-medium text-slate-300">Work Guaranteed</span>
              </div>
            </div>
          </div>

          {/* کارت آمار و امتیاز کنار تصویر */}
          <div className="lg:col-span-5 flex justify-center">
            <div className="w-full max-w-md bg-slate-900/90 border border-slate-800 p-6 rounded-2xl shadow-2xl backdrop-blur">
              <div className="flex items-center justify-between pb-4 border-b border-slate-800">
                <div>
                  <p className="text-sm text-slate-400">Google & Trustpilot Rating</p>
                  <p className="text-3xl font-black text-white">4.9 <span className="text-sm text-slate-400 font-normal">/ 5.0</span></p>
                </div>
                <div className="flex gap-1 text-amber-400">
                  {[...Array(5)].map((_, i) => (
                    <Star key={i} className="w-5 h-5 fill-current" />
                  ))}
                </div>
              </div>
              <div className="py-4 space-y-3">
                <div className="flex justify-between text-sm">
                  <span className="text-slate-400">Covering:</span>
                  <span className="text-slate-200 font-semibold">Manchester & Cheshire</span>
                </div>
                <div className="flex justify-between text-sm">
                  <span className="text-slate-400">Typical Response Time:</span>
                  <span className="text-emerald-400 font-semibold">Under 45 Minutes</span>
                </div>
                <div className="flex justify-between text-sm">
                  <span className="text-slate-400">Quotes:</span>
                  <span className="text-slate-200 font-semibold">Free & No-Obligation</span>
                </div>
              </div>
              <a
                href="#contact"
                className="block text-center w-full bg-amber-400 hover:bg-amber-300 text-slate-950 font-bold py-3 rounded-xl transition"
              >
                Book An Emergency Visit
              </a>
            </div>
          </div>

        </div>
      </div>
    </section>
  );
};
