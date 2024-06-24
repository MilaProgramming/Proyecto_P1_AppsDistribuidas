import React, { createContext, useState } from 'react';

export const UserContext = createContext();

export const UserProvider = ({ children }) => {
  const [user, setUser] = useState(null);

  const logout = () => {
    setUser(null);
    // Additional logout logic can be added here, like clearing tokens or cookies
  };

  return (
    <UserContext.Provider value={{ user, setUser, logout }}> {/* Include logout in the context value */}
      {children}
    </UserContext.Provider>
  );
};
