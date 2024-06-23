// Card.js
import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBook } from '@fortawesome/free-solid-svg-icons';
import './card.css';

const Card = ({ book, author, category, editorial, isForUser}) => {
  return (
    <div className="card">
      <FontAwesomeIcon icon={faBook} className="card-icon" />
      <p className='titulo'>{book.lib_nombre}</p>
      <p><strong>Autor:</strong> {author.aut_nombre}</p>
      <p><strong>Categoría:</strong> {category.cat_nombre}</p>
      <p><strong>Editorial:</strong> {editorial.edi_nombre}</p>
      <button className="pedir-button">{isForUser ? 'Devolver' : 'Pedir'}</button>
    </div>
  );
};

export default Card;
