import React, { useState } from 'react';
import './Login.css';

const Login = () => {
  const [isLogin, setIsLogin] = useState(true);
  const [usu_cedula, setUsuCedula] = useState('');
  const [usu_usuario, setUsuUsuario] = useState('');
  const [usu_contrasenia, setUsuContrasenia] = useState('');
  const [usu_nombre, setUsuNombre] = useState(''); // For registration only
  const [usu_apellido, setUsuApellido] = useState(''); // For registration only

  const handleToggleForm = () => {
    setIsLogin(!isLogin);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Prepare data based on login or register form
    const formData = isLogin
      ? { usu_usuario, usu_contrasenia }
      : { usu_cedula, usu_nombre, usu_apellido, usu_usuario, usu_contrasenia };

    try {
      const url = isLogin ? '/login' : '/register';
      const response = await fetch(url, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData),
      });

      if (response.ok) {
        // Handle successful login or registration
        const data = await response.json();
        console.log(data); // Assuming backend sends back user data or token
      } else {
        // Handle error
        console.error('Login or registration failed');
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
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

          <p className="toggle-form" onClick={handleToggleForm}>
            {isLogin
              ? "¿No tienes cuenta? Registrate."
              : '¿Ya tienes una cuenta? Ve al Login.'}
          </p>
        </div>
      </div>
    </div>
  );
};

export default Login;
