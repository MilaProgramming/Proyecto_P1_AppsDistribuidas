import React, { useState, useContext } from 'react';
import { Link, useNavigate } from 'react-router-dom'; // Import useNavigate instead of useHistory
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars, faUser } from '@fortawesome/free-solid-svg-icons';
import { faQuestionCircle } from '@fortawesome/free-regular-svg-icons';
import Logo from '../assets/logo.png';
import './navBar.css';
import { UserContext } from './userContext';

const Navbar = () => {
  const [isOpen, setIsOpen] = useState(false);
  const { user, logout } = useContext(UserContext); // Destructure logout from UserContext

  const navigate = useNavigate(); // Use useNavigate instead of useHistory

  const toggleMenu = () => {
    setIsOpen(!isOpen);
  };

  const handleUserClick = () => {
    if (user) {
      logout(); // Call logout function provided by UserContext
      navigate('/'); // Redirect to home after logout using navigate
    }
  };

  return (
    <nav className="nav">
      <div className="nav-logo">
        <img src={Logo} alt="Logo" />
        <p className='name-logo'>Biblio</p>
      </div>
      <div className={`nav-menu ${isOpen ? 'open' : ''}`}>
        <Link className="nav-link" to="/">
          <FontAwesomeIcon icon="fas fa-home" />
          <span>Inicio</span>
        </Link>
        <Link className="nav-link" to="/libros">
          <FontAwesomeIcon icon={faQuestionCircle} />
          <span>Pedir libro</span>
        </Link>
        <Link className="nav-link" to="/pedidos">
          <FontAwesomeIcon icon={faQuestionCircle} />
          <span>Mis libros</span>
        </Link>
        <div className="nav-user" onClick={handleUserClick}>
          {user ? (
            <>
              <FontAwesomeIcon icon={faUser} />
              <span>{user.usu_usuario}</span>
            </>
          ) : (
            <Link className="nav-link" to="/login">
              <span>Iniciar Sesión</span>
            </Link>
          )}
        </div>
      </div>
      <div className="hamburger" onClick={toggleMenu}>
        <FontAwesomeIcon icon={faBars} />
      </div>
    </nav>
  );
};

export default Navbar;
