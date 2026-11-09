import React from 'react';
import { Zap, ShieldCheck } from 'lucide-react';

export const Footer: React.FC = () => {
  return (
    <footer className="bg-slate-950 text-slate-400 py-12 border-t border-slate-800">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="grid md:grid-cols-4 gap-8 mb-8">
          
          <div className="md:col-span-2 space-y-4">
            <div className="flex items-center gap-2">
              <div className="w-8 h-8 rounded-md bg-blue-600 flex items-center justify-center text-white">
                <Zap className="w-5 h-5 fill-current" />
              </div>
              <span className="text-xl font-black text-white">TRACEFORM</span>
            </div>
            <p className="text-xs sm:text-sm text-slate-400 max-w-sm leading-relaxed">
              Manchester's trusted certified electrical contractors. Providing 24/7 emergency response, domestic rewires, and commercial testing.
            </p>
            <div className="inline-flex items-center gap-2 text-xs text-slate-300 bg-slate-900 border border-slate-800 px-3 py-1.5 rounded-lg">
              <ShieldCheck className="w-4 h-4 text-emerald-400" /> NICEIC Approved Contractor
            </div>
          </div>

          <div>
            <h4 className="text-white font-bold text-sm mb-3">Quick Navigation</h4>
            <ul className="space-y-2 text-xs">
              <li><a href="#services" className="hover:text-white transition">Services</a></li>
              <li><a href="#projects" className="hover:text-white transition">Projects</a></li>
              <li><a href="#areas" className="hover:text-white transition">Areas Covered</a></li>
              <li><a href="#reviews" className="hover:text-white transition">Reviews</a></li>
              <li><a href="#contact" className="hover:text-white transition">Contact Us</a></li>
            </ul>
          </div>

          <div>
            <h4 className="text-white font-bold text-sm mb-3">Contact Details</h4>
            <ul className="space-y-2 text-xs">
              <li>Manchester, United Kingdom</li>
              <li>Phone: 0161 820 4932</li>
              <li>Email: info@traceform.co.uk</li>
              <li>Available 24 Hours / 7 Days</li>
            </ul>
          </div>

        </div>

        <div className="pt-8 border-t border-slate-900 flex flex-col sm:flex-row justify-between items-center gap-4 text-xs text-slate-500">
          <p>© {new Date().getFullYear()} Traceform Electrical Services. All rights reserved.</p>
          <p>Built for Manchester Locals.</p>
        </div>
      </div>
    </footer>
  );
};
