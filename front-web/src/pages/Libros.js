import React, { useState, useEffect, useContext } from 'react';
import Card from '../components/card'; // Assuming Card component is correctly imported and named
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import './Libros.css';
import { UserContext } from '../components/userContext';

const Libros = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const [books, setBooks] = useState([]);
  const [categorias, setCategorias] = useState([]);
  const [editoriales, setEditoriales] = useState([]);
  const [autores, setAutores] = useState([]);
  const { user } = useContext(UserContext);

  useEffect(() => {
    const fetchData = async () => {
      try {
        // Fetch libros
        const librosResponse = await fetch('https://localhost:44316/api/Libro/VerLibros');
        if (librosResponse.ok) {
          const librosData = await librosResponse.json();
          // Filter librosData to only include books with lib_disponible === true
          const availableBooks = librosData.filter(book => book.lib_disponible);
          setBooks(availableBooks); // Set libros data to state
        } else {
          console.error('Failed to fetch libros data');
        }

        // Fetch categorias
        const categoriasResponse = await fetch('https://localhost:44316/api/Categoria/VerCategorias');
        if (categoriasResponse.ok) {
          const categoriasData = await categoriasResponse.json();
          setCategorias(categoriasData); // Set categorias data to state
        } else {
          console.error('Failed to fetch categorias data');
        }

        // Fetch editoriales
        const editorialesResponse = await fetch('https://localhost:44316/api/Editorial/VerEditorial');
        if (editorialesResponse.ok) {
          const editorialesData = await editorialesResponse.json();
          setEditoriales(editorialesData); // Set editoriales data to state
        } else {
          console.error('Failed to fetch editoriales data');
        }

        // Fetch autores
        const autoresResponse = await fetch('https://localhost:44316/api/Autor/VerAutor');
        if (autoresResponse.ok) {
          const autoresData = await autoresResponse.json();
          setAutores(autoresData); // Set autores data to state
        } else {
          console.error('Failed to fetch autores data');
        }

      } catch (error) {
        console.error('Error:', error);
      }
    };

    fetchData();
  }, []);

  const handleSearchChange = (e) => {
    setSearchTerm(e.target.value);
  };

  const filteredBooks = books.filter((book) =>
    book.lib_nombre.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="libros-container">
      { user ? (
        <>
                <div className="search-bar">
          <FontAwesomeIcon icon={faSearch} className="search-icon" />
          <input
            type="text"
            placeholder="Busca un libro..."
            value={searchTerm}
            onChange={handleSearchChange}
          />
        </div>
        <h1 className="libros-title">Libros Disponibles</h1>
        <div className="cards-container">
          {filteredBooks.length === 0 ? (
            <p className="no-books-message">No hay nada aquí</p>
          ) : (
            filteredBooks.map((book) => {
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
                  isForUser={false}
                />
              );
            })
          )}
        </div>
        </>
      ) : (
        <p className="login-message"> Por favor inicia sesión para ver los libros disponibles</p>
      )};
    </div>
  );
};

export default Libros;
