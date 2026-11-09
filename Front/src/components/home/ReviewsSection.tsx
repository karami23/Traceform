// src/components/home/ReviewsSection.tsx
import React, { useEffect, useState } from 'react';
import { api } from '../../api/client';
import { ReviewStatus } from '../../types';
import type { ReviewDto } from '../../types';


import { Star, Quote } from 'lucide-react';

export const ReviewsSection: React.FC = () => {
  const [reviews, setReviews] = useState<ReviewDto[]>([]);

  useEffect(() => {
    api.getReviews()
      .then((data) => {
        // فقط نظرات تایید شده (Published = 2) را نمایش بده
        setReviews(data.filter((r) => r.status === ReviewStatus.Published));
      })
      .catch(console.error);
  }, []);

  return (
    <section id="reviews" className="py-20 bg-slate-900 text-white">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="text-center max-w-2xl mx-auto mb-14">
          <span className="text-amber-400 font-bold text-xs uppercase tracking-wider">Testimonials</span>
          <h2 className="text-3xl sm:text-4xl font-black text-white mt-2">What Our Clients Say</h2>
          <p className="text-slate-400 mt-2 text-sm">
            Trusted by homeowners and facility managers across Greater Manchester.
          </p>
        </div>

        <div className="grid sm:grid-cols-2 lg:grid-cols-3 gap-6">
          {reviews.map((rev) => (
            <div key={rev.id} className="bg-slate-800/80 border border-slate-700/60 p-6 rounded-2xl relative flex flex-col justify-between">
              <Quote className="absolute top-4 right-4 w-8 h-8 text-slate-700" />
              <div>
                <div className="flex gap-1 text-amber-400 mb-4">
                  {[...Array(rev.rating)].map((_, i) => (
                    <Star key={i} className="w-4 h-4 fill-current" />
                  ))}
                </div>
                <p className="text-slate-300 text-sm leading-relaxed italic">"{rev.content}"</p>
              </div>
              <div className="mt-6 pt-4 border-t border-slate-700/50 flex items-center justify-between">
                <span className="font-bold text-white text-sm">{rev.customerName}</span>
                <span className="text-emerald-400 text-xs font-semibold">Verified Customer</span>
              </div>
            </div>
          ))}
        </div>
      </div>
    </section>
  );
};
