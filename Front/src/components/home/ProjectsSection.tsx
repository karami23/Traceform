// src/components/home/ProjectsSection.tsx
import React, { useEffect, useState } from 'react';
import { api } from '../../api/client';
import type { ProjectDto } from '../../types';

import { MapPin } from 'lucide-react';

export const ProjectsSection: React.FC = () => {
  const [projects, setProjects] = useState<ProjectDto[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    api.getProjects()
      .then(setProjects)
      .catch(console.error)
      .finally(() => setLoading(false));
  }, []);

  return (
    <section id="projects" className="py-20 bg-white">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex flex-col md:flex-row md:items-end justify-between mb-12">
          <div>
            <span className="text-blue-600 font-bold text-xs uppercase tracking-wider">Our Track Record</span>
            <h2 className="text-3xl sm:text-4xl font-black text-slate-900 mt-2">Recent Completed Projects</h2>
          </div>
          <p className="text-slate-500 text-sm max-w-md mt-2 md:mt-0">
            A glimpse into residential rewiring, smart installations, and industrial fit-outs recently completed in Manchester.
          </p>
        </div>

        {loading ? (
          <div className="grid sm:grid-cols-2 lg:grid-cols-3 gap-6">
            {[...Array(3)].map((_, i) => (
              <div key={i} className="h-72 bg-slate-100 rounded-2xl animate-pulse"></div>
            ))}
          </div>
        ) : (
          <div className="grid sm:grid-cols-2 lg:grid-cols-3 gap-6">
            {projects.map((project) => (
              <div key={project.id} className="overflow-hidden rounded-2xl border border-slate-200 bg-slate-50 group hover:shadow-lg transition">
                <div className="h-48 bg-slate-800 relative overflow-hidden flex items-center justify-center">
                  {project.imageUrl ? (
                    <img
                      src={project.imageUrl}
                      alt={project.title}
                      className="w-full h-full object-cover group-hover:scale-105 transition duration-500"
                    />
                  ) : (
                    <div className="text-slate-500 font-mono text-xs">Traceform Electrical Project</div>
                  )}
                  <span className="absolute bottom-3 left-3 bg-slate-950/80 text-white text-xs px-2.5 py-1 rounded-md flex items-center gap-1 backdrop-blur">
                    <MapPin className="w-3.5 h-3.5 text-amber-400" /> {project.location}
                  </span>
                </div>
                <div className="p-5">
                  <h3 className="font-bold text-slate-900 text-lg">{project.title}</h3>
                  <p className="text-slate-600 text-sm mt-2 line-clamp-2 leading-relaxed">{project.description}</p>
                </div>
              </div>
            ))}
          </div>
        )}
      </div>
    </section>
  );
};
