const data = {
    "Autor": [
      { "aut_id": 1, "aut_nombre": "Gabriel Garcia Marquez" },
      { "aut_id": 2, "aut_nombre": "J.K. Rowling" },
      { "aut_id": 3, "aut_nombre": "Stephen King" }
    ],
    "Editorial": [
      { "edi_id": 1, "edi_nombre": "Penguin Books" },
      { "edi_id": 2, "edi_nombre": "HarperCollins" },
      { "edi_id": 3, "edi_nombre": "Simon & Schuster" }
    ],
    "Categoria": [
      { "cat_id": 1, "cat_nombre": "Fiction" },
      { "cat_id": 2, "cat_nombre": "Fantasy" },
      { "cat_id": 3, "cat_nombre": "Horror" }
    ],
    "Libro": [
      { "lib_id": 1, "lib_nombre": "One Hundred Years of Solitude", "lib_disponible": true, "cat_id": 1, "edi_id": 1, "aut_id": 1 },
      { "lib_id": 2, "lib_nombre": "Harry Potter and the Philosopher's Stone", "lib_disponible": true, "cat_id": 2, "edi_id": 2, "aut_id": 2 },
      { "lib_id": 3, "lib_nombre": "The Shining", "lib_disponible": false, "cat_id": 3, "edi_id": 3, "aut_id": 3 },
      { "lib_id": 4, "lib_nombre": "Love in the Time of Cholera", "lib_disponible": true, "cat_id": 1, "edi_id": 1, "aut_id": 1 },
      { "lib_id": 5, "lib_nombre": "Harry Potter and the Chamber of Secrets", "lib_disponible": true, "cat_id": 2, "edi_id": 2, "aut_id": 2 },
      { "lib_id": 6, "lib_nombre": "It", "lib_disponible": false, "cat_id": 3, "edi_id": 3, "aut_id": 3 }
    ],
    "Usuario": [
      { "usu_cedula": 101, "usu_nombre": "John", "usu_apellido": "Doe", "usu_usuario": "johndoe", "usu_contrasenia": "password123" },
      { "usu_cedula": 102, "usu_nombre": "Jane", "usu_apellido": "Smith", "usu_usuario": "janesmith", "usu_contrasenia": "mypassword" },
      { "usu_cedula": 103, "usu_nombre": "Alice", "usu_apellido": "Johnson", "usu_usuario": "alicej", "usu_contrasenia": "alicepass" }
    ],
    "Prestamo_Libro": [
      { "pre_id": 1, "pre_fecha_inicio": "2024-01-01", "pre_fecha_final": "2024-01-15", "lib_id": 3, "usu_cedula": 101 },
      { "pre_id": 2, "pre_fecha_inicio": "2024-02-01", "pre_fecha_final": "2024-02-15", "lib_id": 2, "usu_cedula": 102 },
      { "pre_id": 3, "pre_fecha_inicio": "2024-03-01", "pre_fecha_final": "2024-03-15", "lib_id": 1, "usu_cedula": 103 }
    ]
  }
  
    export default data;