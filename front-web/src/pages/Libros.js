// Libros.js
import React, { useState } from 'react';
import data from '../assets/data'; // Import your data
import Card from '../components/card';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSearch } from '@fortawesome/free-solid-svg-icons';
import './Libros.css';

const Libros = () => {
  const [searchTerm, setSearchTerm] = useState('');

  const handleSearchChange = (e) => {
    setSearchTerm(e.target.value);
  };

  const filteredBooks = data.Libro.filter((book) =>
    book.lib_nombre.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="libros-container">
 
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
              isForUser={false}
            />
          );
        })}
      </div>

    </div>
  );
};

export default Libros;
