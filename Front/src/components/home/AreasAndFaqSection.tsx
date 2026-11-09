import React, { useEffect, useState } from 'react';
import { api } from '../../api/client';
import type { AreaDto, FAQDto } from '../../types';

import { MapPin, ChevronDown } from 'lucide-react';

export const AreasAndFaqSection: React.FC = () => {
  const [areas, setAreas] = useState<AreaDto[]>([]);
  const [faqs, setFaqs] = useState<FAQDto[]>([]);
  const [openFaq, setOpenFaq] = useState<string | null>(null);

  useEffect(() => {
    Promise.all([api.getAreas(), api.getFaqs()])
      .then(([areasData, faqsData]) => {
        setAreas(areasData.sort((a, b) => a.displayOrder - b.displayOrder));
        setFaqs(faqsData.sort((a, b) => a.displayOrder - b.displayOrder));
      })
      .catch(console.error);
  }, []);

  return (
    <section className="py-20 bg-slate-50" id="areas">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 space-y-16">
        
        {/* مناطق تحت پوشش */}
        <div>
          <div className="text-center max-w-2xl mx-auto mb-8">
            <span className="text-blue-600 font-bold text-xs uppercase tracking-wider">Local Presence</span>
            <h2 className="text-3xl font-black text-slate-900 mt-1">Areas We Cover Across Manchester</h2>
          </div>
          <div className="grid grid-cols-2 sm:grid-cols-3 lg:grid-cols-4 gap-4">
            {areas.map((area) => (
              <div key={area.id} className="bg-white p-4 rounded-xl border border-slate-200 shadow-sm flex items-start gap-3">
                <MapPin className="w-5 h-5 text-blue-600 shrink-0 mt-0.5" />
                <div>
                  <h4 className="font-bold text-slate-900 text-sm">{area.name}</h4>
                  <p className="text-slate-500 text-xs mt-1 line-clamp-2">{area.shortDescription}</p>
                </div>
              </div>
            ))}
          </div>
        </div>

        {/* سوالات متداول FAQ */}
        <div id="faq" className="max-w-3xl mx-auto">
          <div className="text-center mb-8">
            <span className="text-blue-600 font-bold text-xs uppercase tracking-wider">Common Inquiries</span>
            <h2 className="text-3xl font-black text-slate-900 mt-1">Frequently Asked Questions</h2>
          </div>
          <div className="space-y-3">
            {faqs.map((faq) => {
              const isOpen = openFaq === faq.id;
              return (
                <div key={faq.id} className="bg-white rounded-xl border border-slate-200 overflow-hidden">
                  <button
                    onClick={() => setOpenFaq(isOpen ? null : faq.id)}
                    className="w-full text-left p-4 sm:p-5 flex justify-between items-center font-bold text-slate-900 hover:text-blue-600 transition"
                  >
                    <span>{faq.question}</span>
                    <ChevronDown className={`w-5 h-5 shrink-0 transition-transform ${isOpen ? 'rotate-180 text-blue-600' : 'text-slate-400'}`} />
                  </button>
                  {isOpen && (
                    <div className="px-4 sm:px-5 pb-5 text-slate-600 text-sm leading-relaxed border-t border-slate-100 pt-3">
                      {faq.answer}
                    </div>
                  )}
                </div>
              );
            })}
          </div>
        </div>

      </div>
    </section>
  );
};
