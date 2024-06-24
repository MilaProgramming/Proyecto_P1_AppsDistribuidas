// components/UserContext.js

import React, { createContext, useState } from 'react';

const UserContext = createContext();

const UserProvider = ({ children }) => {
  const [user, setUser] = useState(null); // Assuming user object or null
  const [isLoggedIn, setIsLoggedIn] = useState(false); // Track authentication state

  // Check if user is logged in (you can adjust this logic based on your actual authentication mechanism)
  const checkAuth = () => {
    // Example: Check if user object exists
    if (user) {
      setIsLoggedIn(true);
    } else {
      setIsLoggedIn(false);
    }
  };

  const login = (userData) => {
    // Example: Simulate login with user data
    setUser(userData);
    setIsLoggedIn(true);
  };

  const logout = () => {
    // Example: Simulate logout
    setUser(null);
    setIsLoggedIn(false);
  };

  return (
    <UserContext.Provider value={{ user, isLoggedIn, login, logout, checkAuth }}>
      {children}
    </UserContext.Provider>
  );
};

export { UserContext, UserProvider };
