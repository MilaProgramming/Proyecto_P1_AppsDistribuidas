import React, { useState } from 'react';
import data from '../assets/data'; // Import your data
import Card from '../components/card';
import './Prestamos.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSearch } from '@fortawesome/free-solid-svg-icons';

const Prestamo = ({ userId }) => {
  const [searchTerm, setSearchTerm] = useState('');

  // Filter the borrowed books based on the user ID
  const borrowedBooks = data.Prestamo_Libro.filter(
    (borrow) => borrow.usu_cedula === userId
  ).map((borrow) => {
    return data.Libro.find((book) => book.lib_id === borrow.lib_id);
  });

  // Filter the borrowed books based on the search term
  const filteredBooks = borrowedBooks.filter((book) =>
    book.lib_nombre.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const handleSearchChange = (e) => {
    setSearchTerm(e.target.value);
  };

  return (
    <div className="user-borrowed-books-container">
      <h1 className="libros-prestados">Libros Prestados</h1>
      <div className="search-bar">
        <FontAwesomeIcon icon={faSearch} className="search-icon" />
        <input
          type="text"
          placeholder="Busca un libro..."
          value={searchTerm}
          onChange={handleSearchChange}
        />
      </div>
      <div className="cards-container">
        {filteredBooks.map((book) => {
          const author = data.Autor.find((a) => a.aut_id === book.aut_id);
          const category = data.Categoria.find((c) => c.cat_id === book.cat_id);
          const editorial = data.Editorial.find((e) => e.edi_id === book.edi_id);

          return (
            <Card
              key={book.lib_id}
              book={book}
              author={author}
              category={category}
              editorial={editorial}
              isForUser={true}
            />
          );
        })}
      </div>
    </div>
  );
};

export default Prestamo;
