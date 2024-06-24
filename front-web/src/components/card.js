// Card.js
import React, { useContext, useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBook } from '@fortawesome/free-solid-svg-icons';
import { UserContext } from '../components/userContext';
import { Link } from 'react-router-dom'; 
import './card.css';

const Card = ({ book, autor, categoria, editorial, isForUser }) => {
  const { user } = useContext(UserContext);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [actionType, setActionType] = useState('');

  const handleReturnBook = async () => {
    try {
      // Fetch all prestamos to find the matching prestamo_id
      const prestamosResponse = await fetch(`https://localhost:44316/api/Prestamo/VerPrestamos`);

      if (!prestamosResponse.ok) {
        console.error('Failed to fetch prestamos');
        return;
      }
      const prestamosData = await prestamosResponse.json();
  
      // Find the prestamo_id associated with the current book.lib_id
      const prestamo = prestamosData.find(prestamo => prestamo.lib_id === book.lib_id);
      if (!prestamo) {
        console.error('Prestamo not found for the book');
        return;
      }
  
      // Delete prestamo using its prestamo_id
      const deleteResponse = await fetch(`https://localhost:44316/api/Prestamo/BorrarPrestamo/${prestamo.pre_id}`, {
        method: 'DELETE'
      });
      if (!deleteResponse.ok) {
        console.error('Failed to delete prestamo');
        return;
      }
  
      // Update book availability and other details
      const updateResponse = await fetch(`https://localhost:44316/api/Libro/EditarLibro`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          lib_id: book.lib_id,
          lib_nombre: book.lib_nombre,
          lib_disponible: true, // Update lib_disponible to true
          cat_id: book.cat_id,
          edi_id: book.edi_id,
          aut_id: book.aut_id
        })
      });
      if (!updateResponse.ok) {
        console.error('Failed to update book details');
        return;
      }
      
      setIsModalOpen(true);
      setActionType('Devolver');
      // Handle success: Refresh UI or update state after successful return and delete
      // You may want to reload data or update state in the parent component
    } catch (error) {
      console.error('Error returning book:', error);
    }
  };  

  const createPrestamo = async () => {
    const today = new Date().toISOString().slice(0, 10);
    const oneWeekLater = new Date(Date.now() + 7 * 24 * 60 * 60 * 1000).toISOString().slice(0, 10);
  
    const prestamoData = {
      pre_fecha_inicio: today,
      pre_fecha_final: oneWeekLater,
      lib_id: book.lib_id,
      usu_cedula: user.usu_cedula
    };
  
    console.log('Creating prestamo with data:', prestamoData);
  
    const response = await fetch('https://localhost:44316/api/Prestamo/CrearPrestamo', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        pre_fecha_inicio: today,
        pre_fecha_final: oneWeekLater,
        lib_id: book.lib_id,
        usu_cedula: user.usu_cedula
      })
    });
  
    if (!response.ok) {
      console.error('Failed to create prestamo:', response.status, response.statusText);
      throw new Error('Failed to create prestamo');
    }
  
    return response.json();
  };
  
  const updateBookAvailability = async (book) => {
    const bookData = {
      lib_id: book.lib_id,
      lib_nombre: book.lib_nombre,
      lib_disponible: false,
      cat_id: book.cat_id,
      edi_id: book.edi_id,
      aut_id: book.aut_id
    };
  
    console.log('Updating book availability with data:', bookData);
  
    const response = await fetch(`https://localhost:44316/api/Libro/EditarLibro`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(bookData)
    });
  
    if (!response.ok) {
      console.error('Failed to update book availability:', response.status, response.statusText);
      throw new Error('Failed to update book availability');
    }
  
    return response.json();
  };
  
  const handleRequestBook = async () => {
    try {
      await createPrestamo();
    } catch (error) {
      console.error('Error requesting book:', error);
    }

    try {
      await updateBookAvailability(book);
    } catch (error) {
      console.error('Error updating book availability:', error);
    }

    setIsModalOpen(true);
    setActionType('Pedir');
  };
  
  const closeModal = () => {
    setIsModalOpen(false);
  };
  

  return (
    <div className="card">
      <FontAwesomeIcon icon={faBook} className="card-icon" />
      <p className="titulo">{book.lib_nombre}</p>
      <p><strong>Autor:</strong> {autor ? autor.aut_nombre : 'N/A'}</p>
      <p><strong>Categoría:</strong> {categoria ? categoria.cat_nombre : 'N/A'}</p>
      <p><strong>Editorial:</strong> {editorial ? editorial.edi_nombre : 'N/A'}</p>
      {isForUser ? (
        <button className="pedir-button" onClick={handleReturnBook}>Devolver</button>
      ) : (
        <button className="pedir-button" onClick={handleRequestBook}>Pedir</button>
      )}

      {isModalOpen && (
        <div className="modal">
          <div className="modal-content">
            <span className="close" onClick={closeModal}>&times;</span>
            <h2>{`¿Estás seguro que deseas ${actionType}?`}</h2>
            <div className="modal-buttons">
            {isForUser ? (
              <Link to="/libros">
                <button>Confirmar</button>
              </Link>
            ) : (
              <Link to="/pedidos">
                <button>Confirmar</button>
              </Link>
            )}
            <button onClick={closeModal}>Cancelar</button>
            </div>
          </div>
        </div>
      )}


    </div>
  );
};

export default Card;
