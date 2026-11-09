// src/pages/HomePage.tsx
import React from 'react';
import { Hero } from '../components/home/Hero';
import { ServicesSection } from '../components/home/ServicesSection';
import { ProjectsSection } from '../components/home/ProjectsSection';
import { ReviewsSection } from '../components/home/ReviewsSection';
import { AreasAndFaqSection } from '../components/home/AreasAndFaqSection';
import { ContactSection } from '../components/home/ContactSection';

export const HomePage: React.FC = () => {
  return (
    <div id="home" className="space-y-0">
      <Hero />
      <ServicesSection />
      <ProjectsSection />
      <ReviewsSection />
      <AreasAndFaqSection />
      <ContactSection />
    </div>
  );
};
