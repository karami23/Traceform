import React, { useState } from 'react';
import { Phone, Mail, Clock, ShieldCheck, Menu, X, Zap } from 'lucide-react';

export const Navbar: React.FC = () => {
  const [mobileMenuOpen, setMobileMenuOpen] = useState(false);

  return (
    <header className="w-full bg-white shadow-sm sticky top-0 z-50">
      {/* نوار اطلاعات تماس بالا */}
      <div className="bg-slate-900 text-slate-300 text-xs sm:text-sm py-2 px-4">
        <div className="max-w-7xl mx-auto flex flex-wrap justify-between items-center gap-2">
          <div className="flex items-center gap-6">
            <span className="flex items-center gap-1.5 text-emerald-400 font-medium">
              <Clock className="w-4 h-4" /> 24/7 Emergency Service
            </span>
            <span className="hidden md:flex items-center gap-1.5">
              <ShieldCheck className="w-4 h-4 text-blue-400" /> NICEIC Approved Contractor
            </span>
          </div>
          <div className="flex items-center gap-6">
            <a href="mailto:info@traceform.co.uk" className="hidden sm:flex items-center gap-1.5 hover:text-white transition">
              <Mail className="w-4 h-4 text-slate-400" /> info@traceform.co.uk
            </a>
            <a href="tel:01618204932" className="flex items-center gap-1.5 text-white font-bold hover:text-amber-400 transition">
              <Phone className="w-4 h-4 text-amber-400" /> 0161 820 4932
            </a>
          </div>
        </div>
      </div>

      {/* منوی اصلی */}
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between items-center h-20">
          {/* لوگو برند - متصل به خانه */}
          <a href="#home" className="flex items-center gap-2">
            <div className="w-10 h-10 rounded-lg bg-blue-600 flex items-center justify-center text-white shadow-md">
              <Zap className="w-6 h-6 fill-current" />
            </div>
            <div>
              <span className="text-2xl font-black tracking-tight text-slate-900">TRACEFORM</span>
              <span className="block text-[10px] tracking-widest text-slate-500 uppercase font-semibold">Electrical Services</span>
            </div>
          </a>

          {/* لینک‌های دسکتاپ - شامل دکمه Home */}
          <nav className="hidden md:flex items-center gap-8 text-sm font-medium text-slate-700">
            <a href="#home" className="hover:text-blue-600 transition">Home</a>
            <a href="#services" className="hover:text-blue-600 transition">Services</a>
            <a href="#projects" className="hover:text-blue-600 transition">Projects</a>
            <a href="#areas" className="hover:text-blue-600 transition">Areas Covered</a>
            <a href="#reviews" className="hover:text-blue-600 transition">Reviews</a>
            <a href="#faq" className="hover:text-blue-600 transition">FAQ</a>
          </nav>

          {/* دکمه اکشن دسکتاپ */}
          <div className="hidden md:flex items-center gap-4">
            <a
              href="#contact"
              className="bg-blue-600 hover:bg-blue-700 text-white font-semibold px-5 py-2.5 rounded-lg shadow-sm hover:shadow transition text-sm"
            >
              Get Free Quote
            </a>
          </div>

          {/* دکمه منوی موبایل */}
          <div className="flex md:hidden">
            <button
              onClick={() => setMobileMenuOpen(!mobileMenuOpen)}
              className="text-slate-600 hover:text-slate-900 p-2"
              aria-label="Toggle menu"
            >
              {mobileMenuOpen ? <X className="w-6 h-6" /> : <Menu className="w-6 h-6" />}
            </button>
          </div>
        </div>
      </div>

      {/* منوی موبایل - شامل دکمه Home */}
      {mobileMenuOpen && (
        <div className="md:hidden border-t border-slate-100 bg-white px-4 pt-3 pb-6 space-y-3">
          <a
            href="#home"
            onClick={() => setMobileMenuOpen(false)}
            className="block py-2 text-slate-700 font-medium hover:text-blue-600"
          >
            Home
          </a>
          <a
            href="#services"
            onClick={() => setMobileMenuOpen(false)}
            className="block py-2 text-slate-700 font-medium hover:text-blue-600"
          >
            Services
          </a>
          <a
            href="#projects"
            onClick={() => setMobileMenuOpen(false)}
            className="block py-2 text-slate-700 font-medium hover:text-blue-600"
          >
            Projects
          </a>
          <a
            href="#areas"
            onClick={() => setMobileMenuOpen(false)}
            className="block py-2 text-slate-700 font-medium hover:text-blue-600"
          >
            Areas Covered
          </a>
          <a
            href="#reviews"
            onClick={() => setMobileMenuOpen(false)}
            className="block py-2 text-slate-700 font-medium hover:text-blue-600"
          >
            Reviews
          </a>
          <a
            href="#faq"
            onClick={() => setMobileMenuOpen(false)}
            className="block py-2 text-slate-700 font-medium hover:text-blue-600"
          >
            FAQ
          </a>
          <a
            href="#contact"
            onClick={() => setMobileMenuOpen(false)}
            className="block w-full text-center bg-blue-600 text-white font-semibold py-2.5 rounded-lg"
          >
            Get Free Quote
          </a>
        </div>
      )}
    </header>
  );
};
