import './App.css';
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import Home from './pages/Home';
import Login from './pages/Login';
import Libros from './pages/Libros';
import Prestamos from './pages/Prestamos';
import Navbar from './components/navBar';
import Footer from './components/footer';
import { UserProvider } from './components/userContext';

function App() {
  return (
    <UserProvider>
      <Router>
        <div className="App">
          <Navbar />
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/login" element={<Login />} />
            <Route path="/libros" element={<Libros />} />
            <Route path="/pedidos" element={<Prestamos />} />
          </Routes>
          <Footer />
        </div>
      </Router>
    </UserProvider>
  );
}

export default App;
