import React, { useState, useContext } from 'react';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars, faUser } from '@fortawesome/free-solid-svg-icons';
import { faQuestionCircle } from '@fortawesome/free-regular-svg-icons';
import Logo from '../assets/logo.png';
import './navBar.css';
import { UserContext } from './userContext';

const Navbar = () => {
  const [isOpen, setIsOpen] = useState(false);
  const { user } = useContext(UserContext);

  const toggleMenu = () => {
    setIsOpen(!isOpen);
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
        <Link className="nav-link" to="/">
          <FontAwesomeIcon icon={faQuestionCircle} />
          <span>Pedir libro</span>
        </Link>
        <div className="nav-user">
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
