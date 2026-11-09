import React, { useEffect, useState } from 'react';
import { api } from '../../api/client';
import type { ServiceDto } from '../../types';

import { Zap, AlertTriangle, CheckCircle2, ArrowRight } from 'lucide-react';

export const ServicesSection: React.FC = () => {
  const [services, setServices] = useState<ServiceDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    api.getServices()
      .then((data: ServiceDto[]) =>
        setServices([...data].sort((a: ServiceDto, b: ServiceDto) => (a.displayOrder ?? 0) - (b.displayOrder ?? 0)))
      )
      .catch((err: unknown) => {
        if (err instanceof Error) {
          setError(err.message);
        } else {
          setError('An unexpected error occurred');
        }
      })
      .finally(() => setLoading(false));
  }, []);


  return (
    <section id="services" className="py-20 bg-slate-50">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="text-center max-w-3xl mx-auto mb-14">
          <span className="text-blue-600 font-bold text-xs uppercase tracking-wider">Expertise & Solutions</span>
          <h2 className="text-3xl sm:text-4xl font-black text-slate-900 mt-2">
            Comprehensive Electrical Services
          </h2>
          <p className="text-slate-600 mt-3 text-base">
            Professional solutions for residential, commercial, and emergency electrical requirements across Manchester.
          </p>
        </div>

        {loading ? (
          <div className="grid sm:grid-cols-2 lg:grid-cols-3 gap-6">
            {[...Array(6)].map((_, i) => (
              <div key={i} className="h-56 bg-slate-200 rounded-2xl animate-pulse"></div>
            ))}
          </div>
        ) : error ? (
          <div className="p-4 bg-red-50 text-red-700 rounded-xl text-center">
            Failed to load services from backend. ({error})
          </div>
        ) : (
          <div className="grid sm:grid-cols-2 lg:grid-cols-3 gap-6">
            {services.map((service) => (
              <div
                key={service.id}
                className="group relative bg-white border border-slate-200 rounded-2xl p-6 shadow-sm hover:shadow-xl transition-all duration-300 flex flex-col justify-between"
              >
                <div>
                  <div className="flex items-center justify-between mb-4">
                    <div className="w-12 h-12 rounded-xl bg-blue-50 text-blue-600 flex items-center justify-center group-hover:bg-blue-600 group-hover:text-white transition-colors">
                      <Zap className="w-6 h-6" />
                    </div>
                    {service.isEmergency && (
                      <span className="inline-flex items-center gap-1 bg-amber-100 text-amber-800 text-xs font-bold px-2.5 py-1 rounded-full">
                        <AlertTriangle className="w-3.5 h-3.5" /> Emergency
                      </span>
                    )}
                  </div>
                  <h3 className="text-xl font-bold text-slate-900 group-hover:text-blue-600 transition-colors">
                    {service.title}
                  </h3>
                  <p className="text-slate-600 text-sm mt-2.5 line-clamp-3 leading-relaxed">
                    {service.shortDescription}
                  </p>
                </div>

                <div className="mt-6 pt-4 border-t border-slate-100 flex items-center justify-between">
                  <span className="inline-flex items-center gap-1 text-xs font-medium text-emerald-600">
                    <CheckCircle2 className="w-3.5 h-3.5" /> Guaranteed Work
                  </span>
                  <a
                    href="#contact"
                    className="inline-flex items-center gap-1 text-sm font-semibold text-blue-600 hover:text-blue-700"
                  >
                    Enquire <ArrowRight className="w-4 h-4" />
                  </a>
                </div>
              </div>
            ))}
          </div>
        )}
      </div>
    </section>
  );
};
