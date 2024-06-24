// Login.js
import React, { useState, useEffect, useContext } from 'react';
import './Login.css';
import { UserContext } from '../components/userContext';
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const [isLogin, setIsLogin] = useState(true);
  const [usu_cedula, setUsuCedula] = useState('');
  const [usu_usuario, setUsuUsuario] = useState('');
  const [usu_contrasenia, setUsuContrasenia] = useState('');
  const [usu_nombre, setUsuNombre] = useState('');
  const [usu_apellido, setUsuApellido] = useState('');
  const [error, setError] = useState('');
  const [users, setUsers] = useState([]);
  const { setUsuario } = useContext(UserContext);
  const navigate = useNavigate(); 

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const response = await fetch('https://localhost:44316/api/Usuario/VerUsuarios');
        if (response.ok) {
          const data = await response.json();
          setUsers(data);
        } else {
          console.error('Failed to fetch user data');
        }
      } catch (error) {
        console.error('Error:', error);
      }
    };

    fetchUserData();
  }, []);

  const handleToggleForm = () => {
    setIsLogin(!isLogin);
    setError('');
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');

    if (isLogin) {
      const user = users.find(user => user.usu_usuario === usu_usuario && user.usu_contrasenia === usu_contrasenia);
      if (user) {
        setUsuario(user); // Store user details in context
        navigate('/libros'); // Redirect to /libros on successful login
        console.log('Login successful', user);
      } else {
        setError('Username or password is incorrect');
      }
    } else {
      const usernameExists = users.some(user => user.usu_usuario === usu_usuario);
      if (usernameExists) {
        setError('El nombre de usuario ya está en uso');
      } else {
        const formData = { usu_cedula, usu_nombre, usu_apellido, usu_usuario, usu_contrasenia };
        try {
          const response = await fetch('https://localhost:44316/api/Usuario/CrearUsuario', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify(formData),
          });

          if (response.ok) {
            const data = await response.json();
            setUsuario(data); // Store newly registered user details in context
            navigate('/libros'); // Redirect to /libros on successful registration
            console.log('Registration successful', data);
          } else {
            console.error('Registration failed');
          }
        } catch (error) {
          console.error('Error:', error);
        }
      }
    }
  };

  return (
    <div>
      <div className="login-container">
        <div className="login-content">
          <div className="auth-form-container">
            <h2>{isLogin ? 'Login' : 'Registro'}</h2>
            <form className="auth-form" onSubmit={handleSubmit}>
              {!isLogin && (
                <>
                  <label htmlFor="usu_cedula">Cédula</label>
                  <input
                    type="number"
                    id="usu_cedula"
                    name="usu_cedula"
                    value={usu_cedula}
                    onChange={(e) => setUsuCedula(e.target.value)}
                    required
                  />
                  <label htmlFor="usu_nombre">Nombre</label>
                  <input
                    type="text"
                    id="usu_nombre"
                    name="usu_nombre"
                    value={usu_nombre}
                    onChange={(e) => setUsuNombre(e.target.value)}
                    required
                  />
                  <label htmlFor="usu_apellido">Apellido</label>
                  <input
                    type="text"
                    id="usu_apellido"
                    name="usu_apellido"
                    value={usu_apellido}
                    onChange={(e) => setUsuApellido(e.target.value)}
                    required
                  />
                </>
              )}
              <label htmlFor="usu_usuario">Username</label>
              <input
                type="text"
                id="usu_usuario"
                name="usu_usuario"
                value={usu_usuario}
                onChange={(e) => setUsuUsuario(e.target.value)}
                required
              />
              <label htmlFor="usu_contrasenia">Contraseña</label>
              <input
                type="password"
                id="usu_contrasenia"
                name="usu_contrasenia"
                value={usu_contrasenia}
                onChange={(e) => setUsuContrasenia(e.target.value)}
                required
              />
              <button type="submit" className="auth-button">
                {isLogin ? 'Login' : 'Registro'}
              </button>
            </form>
            {error && <p className="error-message">{error}</p>}
            <p className="toggle-form" onClick={handleToggleForm}>
              {isLogin ? "¿No tienes cuenta? Regístrate." : '¿Ya tienes una cuenta? Ve al Login.'}
            </p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;
