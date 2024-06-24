import React from "react";
import NavBar from "../components/navBar.js";
import "./Home.css";
import Icon1 from "../assets/1.png";
import Icon2 from "../assets/2.png";
import Footer from "../components/footer.js";
import Login from "./Login.js";
import Libros from "./Libros.js";
import Prestamo from "./Prestamos.js";

const Home = () => {
    return (
        <div>
            <div className="contenido">
                <div className="icon-transition">
                    <img src={Icon1} alt="Icon 1" className="icon icon1" />
                    <img src={Icon2} alt="Icon 2" className="icon icon2" />
                </div>
                <div>
                    <h1 className="title">¡Bienvenido a Biblio</h1>
                    <p className="text">
                        Biblio te permitirá pedir libros de nuestro catálogo, ¡no te olvides de devolverlos!
                    </p>
                </div>
            </div>
            {/* <Login /> */}
            
            {/* <Libros /> */}

            {/* <Prestamo userId={101} /> */}
        </div>
    );
};

export default Home;