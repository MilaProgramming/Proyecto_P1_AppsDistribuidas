// Prestamos.js
import React, { useState, useEffect, useContext } from 'react';
import Card from '../components/card';
import './Prestamos.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { UserContext } from '../components/userContext';

const Prestamos = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const [borrowedBooks, setBorrowedBooks] = useState([]);
  const [autores, setAutores] = useState([]);
  const [categorias, setCategorias] = useState([]);
  const [editoriales, setEditoriales] = useState([]);
  const { user } = useContext(UserContext);

  useEffect(() => {
    const fetchData = async () => {
      try {
        // Fetch all prestamos
        const response = await fetch(`https://localhost:44316/api/Prestamo/VerPrestamos`);
        if (response.ok) {
          const data = await response.json();
          
          // Filter borrowed books (prestamos) for the current user
          const userBorrowedBooks = data.filter(prestamo => prestamo.usu_cedula === user.usu_cedula);
          const bookIds = userBorrowedBooks.map(prestamo => prestamo.lib_id);

          // Fetch all books
          const allBooksResponse = await fetch(`https://localhost:44316/api/Libro/VerLibros`);
          if (allBooksResponse.ok) {
            const allBooksData = await allBooksResponse.json();
            
            // Filter borrowed books from allBooksData based on bookIds
            const borrowedBooksData = allBooksData.filter(book => bookIds.includes(book.lib_id));
            setBorrowedBooks(borrowedBooksData);

            // Fetch autores, categorias, and editoriales
            const autoresResponse = await fetch(`https://localhost:44316/api/Autor/VerAutor`);
            if (autoresResponse.ok) {
              const autoresData = await autoresResponse.json();
              setAutores(autoresData);
            } else {
              console.error('Failed to fetch autores');
            }

            const categoriasResponse = await fetch(`https://localhost:44316/api/Categoria/VerCategorias`);
            if (categoriasResponse.ok) {
              const categoriasData = await categoriasResponse.json();
              setCategorias(categoriasData);
            } else {
              console.error('Failed to fetch categorias');
            }

            const editorialesResponse = await fetch(`https://localhost:44316/api/Editorial/VerEditorial`);
            if (editorialesResponse.ok) {
              const editorialesData = await editorialesResponse.json();
              setEditoriales(editorialesData);
            } else {
              console.error('Failed to fetch editoriales');
            }
          } else {
            console.error('Failed to fetch all books');
          }
        } else {
          console.error('Failed to fetch prestamos');
        }
      } catch (error) {
        console.error('Error:', error);
      }
    };

    if (user) {
      fetchData();
    }
  }, [user]);

  const handleSearchChange = (e) => {
    setSearchTerm(e.target.value);
  };

  const filteredBooks = borrowedBooks.filter((book) =>
    book.lib_nombre.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="user-borrowed-books-container">

      { user ? (
        <>
        <h1 className="libros-prestados">Libros Prestados</h1>
        <div className="search-bar-p">
          <FontAwesomeIcon icon={faSearch} className="search-icon-p" />
          <input
            type="text"
            placeholder="Busca un libro..."
            value={searchTerm}
            onChange={handleSearchChange}
          />
        </div>
        <div className="cards-container">
          {filteredBooks.length === 0 ? (
            <p className="no-books-message">No hay libros prestados para mostrar</p>
          ) : (
            filteredBooks.map((book) => {
              // Find autor, categoria, and editorial from their respective arrays
              const autor = autores.find(a => a.aut_id === book.aut_id);
              const categoria = categorias.find(c => c.cat_id === book.cat_id);
              const editorial = editoriales.find(e => e.edi_id === book.edi_id);

              return (
                <Card
                  key={book.lib_id}
                  book={book}
                  autor={autor}
                  categoria={categoria}
                  editorial={editorial}
                  isForUser={true}
                />
              );
            })
          )}
        </div>
       </>
      ) : (
        <p className="login-message">Inicia sesión para ver tus libros prestados</p>
      )}
    </div>
  );
};

export default Prestamos;
