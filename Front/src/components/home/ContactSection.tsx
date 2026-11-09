// src/components/home/ContactSection.tsx
import React, { useState } from 'react';
import { api } from '../../api/client';
import type { CreateContactRequestCommand } from '../../types';
import { Phone, Mail, Clock, Send, CheckCircle2, AlertCircle } from 'lucide-react';

export const ContactSection: React.FC = () => {
  const [formData, setFormData] = useState<CreateContactRequestCommand>({
    name: '',
    email: '',
    phone: '',
    message: '',
  });

  const [status, setStatus] = useState<'idle' | 'submitting' | 'success' | 'error'>('idle');
  const [errorMessage, setErrorMessage] = useState('');

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setStatus('submitting');
    setErrorMessage('');

    try {
      await api.createContactRequest(formData);
      setStatus('success');
      setFormData({ name: '', email: '', phone: '', message: '' });
    } catch (err: any) {
      setStatus('error');
      setErrorMessage(err.message || 'Something went wrong while submitting.');
    }
  };

  return (
    <section id="contact" className="py-20 bg-white">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="grid lg:grid-cols-12 gap-12">
          
          {/* اطلاعات ارتباطی */}
          <div className="lg:col-span-5 space-y-6">
            <span className="text-blue-600 font-bold text-xs uppercase tracking-wider">Get In Touch</span>
            <h2 className="text-3xl sm:text-4xl font-black text-slate-900">
              Request a Free Quote or Emergency Callout
            </h2>
            <p className="text-slate-600 text-base leading-relaxed">
              Fill out the form and our Manchester team will respond within 30 minutes. For immediate emergencies, please call us directly.
            </p>

            <div className="space-y-4 pt-4">
              <a href="tel:01618204932" className="flex items-center gap-4 p-4 rounded-xl bg-slate-50 border border-slate-200 hover:border-blue-300 transition">
                <div className="w-10 h-10 rounded-lg bg-amber-400/20 text-amber-700 flex items-center justify-center font-bold">
                  <Phone className="w-5 h-5" />
                </div>
                <div>
                  <p className="text-xs text-slate-500 font-medium">Call Us Directly</p>
                  <p className="text-slate-900 font-bold">0161 820 4932</p>
                </div>
              </a>

              <a href="mailto:info@traceform.co.uk" className="flex items-center gap-4 p-4 rounded-xl bg-slate-50 border border-slate-200 hover:border-blue-300 transition">
                <div className="w-10 h-10 rounded-lg bg-blue-50 text-blue-600 flex items-center justify-center font-bold">
                  <Mail className="w-5 h-5" />
                </div>
                <div>
                  <p className="text-xs text-slate-500 font-medium">Email Inquiries</p>
                  <p className="text-slate-900 font-bold">info@traceform.co.uk</p>
                </div>
              </a>

              <div className="flex items-center gap-4 p-4 rounded-xl bg-slate-50 border border-slate-200">
                <div className="w-10 h-10 rounded-lg bg-emerald-50 text-emerald-600 flex items-center justify-center font-bold">
                  <Clock className="w-5 h-5" />
                </div>
                <div>
                  <p className="text-xs text-slate-500 font-medium">Working Hours</p>
                  <p className="text-slate-900 font-bold">24 Hours / 7 Days a Week</p>
                </div>
              </div>
            </div>
          </div>

          {/* فرم ارسال درخواست */}
          <div className="lg:col-span-7">
            <div className="bg-slate-50 border border-slate-200 p-8 rounded-2xl shadow-sm">
              <h3 className="text-xl font-bold text-slate-900 mb-6">Send Us a Message</h3>

              {status === 'success' ? (
                <div className="p-6 bg-emerald-50 border border-emerald-200 rounded-xl text-center space-y-3">
                  <CheckCircle2 className="w-12 h-12 text-emerald-600 mx-auto" />
                  <h4 className="text-lg font-bold text-emerald-900">Thank You!</h4>
                  <p className="text-sm text-emerald-700">
                    Your request has been submitted successfully. An engineer will contact you shortly.
                  </p>
                  <button
                    onClick={() => setStatus('idle')}
                    className="mt-4 px-4 py-2 bg-emerald-600 text-white rounded-lg text-xs font-semibold hover:bg-emerald-700"
                  >
                    Submit Another Request
                  </button>
                </div>
              ) : (
                <form onSubmit={handleSubmit} className="space-y-4">
                  {status === 'error' && (
                    <div className="p-4 bg-red-50 border border-red-200 text-red-700 rounded-xl text-sm flex items-center gap-2">
                      <AlertCircle className="w-4 h-4 shrink-0" />
                      {errorMessage}
                    </div>
                  )}

                  <div className="grid sm:grid-cols-2 gap-4">
                    <div>
                      <label className="block text-xs font-semibold text-slate-700 mb-1">Your Name *</label>
                      <input
                        required
                        type="text"
                        placeholder="John Doe"
                        value={formData.name}
                        onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                        className="w-full px-4 py-2.5 rounded-lg border border-slate-300 focus:outline-none focus:ring-2 focus:ring-blue-500 text-sm bg-white"
                      />
                    </div>
                    <div>
                      <label className="block text-xs font-semibold text-slate-700 mb-1">Phone Number *</label>
                      <input
                        required
                        type="tel"
                        placeholder="07123 456789"
                        value={formData.phone}
                        onChange={(e) => setFormData({ ...formData, phone: e.target.value })}
                        className="w-full px-4 py-2.5 rounded-lg border border-slate-300 focus:outline-none focus:ring-2 focus:ring-blue-500 text-sm bg-white"
                      />
                    </div>
                  </div>

                  <div>
                    <label className="block text-xs font-semibold text-slate-700 mb-1">Email Address *</label>
                    <input
                      required
                      type="email"
                      placeholder="john@example.com"
                      value={formData.email}
                      onChange={(e) => setFormData({ ...formData, email: e.target.value })}
                      className="w-full px-4 py-2.5 rounded-lg border border-slate-300 focus:outline-none focus:ring-2 focus:ring-blue-500 text-sm bg-white"
                    />
                  </div>

                  <div>
                    <label className="block text-xs font-semibold text-slate-700 mb-1">Message / Job Details</label>
                    <textarea
                      rows={4}
                      placeholder="Please describe the issue or service needed (e.g. fuse box replacement, inspection, emergency fault)..."
                      value={formData.message || ''}
                      onChange={(e) => setFormData({ ...formData, message: e.target.value })}
                      className="w-full px-4 py-2.5 rounded-lg border border-slate-300 focus:outline-none focus:ring-2 focus:ring-blue-500 text-sm bg-white"
                    />
                  </div>

                  <button
                    type="submit"
                    disabled={status === 'submitting'}
                    className="w-full bg-blue-600 hover:bg-blue-700 disabled:bg-blue-400 text-white font-bold py-3.5 rounded-xl shadow-md transition flex items-center justify-center gap-2"
                  >
                    {status === 'submitting' ? (
                      'Sending Request...'
                    ) : (
                      <>
                        <Send className="w-4 h-4" /> Submit Request
                      </>
                    )}
                  </button>
                </form>
              )}
            </div>
          </div>

        </div>
      </div>
    </section>
  );
};
