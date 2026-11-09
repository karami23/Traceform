// src/App.tsx
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Navbar } from './components/Layout/Navbar';
import { Footer } from './components/Layout/Footer';
import { HomePage } from './pages/HomePage';

export default function App() {
  return (
    <Router>
      <div className="min-h-screen flex flex-col bg-white font-sans text-slate-900 selection:bg-blue-600 selection:text-white">
        <Navbar />
        
        <main className="flex-grow">
          <Routes>
            {/* صفحه اصلی (Home) */}
            <Route path="/" element={<HomePage />} />
          </Routes>
        </main>

        <Footer />
      </div>
    </Router>
  );
}
