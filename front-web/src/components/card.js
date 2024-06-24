import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBook } from '@fortawesome/free-solid-svg-icons';
import './card.css';

const Card = ({ book, autor, categoria, editorial, isForUser }) => {
  return (
    <div className="card">
      <FontAwesomeIcon icon={faBook} className="card-icon" />
      <p className="titulo">{book.lib_nombre}</p>
      <p><strong>Autor:</strong> {autor ? autor.aut_nombre : 'N/A'}</p>
      <p><strong>Categoría:</strong> {categoria ? categoria.cat_nombre : 'N/A'}</p>
      <p><strong>Editorial:</strong> {editorial ? editorial.edi_nombre : 'N/A'}</p>
      <button className="pedir-button">{isForUser ? 'Devolver' : 'Pedir'}</button>
    </div>
  );
};

export default Card;
