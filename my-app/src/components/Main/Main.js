import React, {Fragment, useState} from 'react';
import  Card  from 'components/Card/Card';
import  Searchbar from 'components/Searchbar';
import './Main.css';


const Main = () => {

    //useState
  const [ productos, guardarProductos ] = useState([
    {id: 1, nombre: 'Camisa', precio:50 },
    {id: 2, nombre: 'Camisa2', precio:50 },
  ]);

  const[hogares, guardarHogar] = useState([
    { id: 1, 
      nombre: 'Ave. 2 John K.', 
      cliente:'Alma Patricia', 
      descripcion:'Esta es un hogar para mascotas',
      mascotas:'3',
      precio:'129.99'
    },
    { id: 2, 
      nombre: 'Ave. 2 John K.', 
      cliente:'Alma Patricia', 
      descripcion:'Esta es un hogar para mascotas',
      mascotas:'2',
      precio:'129.99'
    },
    { id: 3, 
      nombre: 'Ave. 2 John K.', 
      cliente:'Alma Patricia', 
      descripcion:'Esta es otro hogar para mascotas',
      mascotas:'1',
      precio:'129.99'
    },
    { id: 4, 
      nombre: 'Ave. 2 John K.', 
      cliente:'Alma Patricia', 
      descripcion:'Esta es otro hogar para mascotas',
      mascotas:'1',
      precio:'129.99'
    },
  ]);

    return (
        <div className="container">
        
        <div className="titulo">
          <h1><b>PetHouse</b></h1>
          <div className="subtitulo"><h2>Cuidamos de tu mejor amigo</h2></div>
          <div className="subtitulo"><h2>Como si fuera el nuestro</h2></div>
        </div>
        <h3>Busca el hogar de tu preferencia</h3>
        <Searchbar />

        <h3>Nuevos Hogares para tu mascota</h3>
        <div className="columns">
          {hogares.map(hogar =>(
            <Card
            key={hogar.id}
            hogar={hogar}/>
            ))}
        </div>
        <h3>Hogares Destacados</h3>
        <div className="columns">
          {hogares.map(hogar =>(
            <Card
            key={hogar.id}
            hogar={hogar}/>
            ))}
        </div>
        </div>
      );
}
 
export default Main;