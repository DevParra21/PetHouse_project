import React, { Component } from 'react';

const Producto = ({producto}) => {
    return ( 
        <h1>{producto.id} - {producto.nombre}</h1>
     );
}
 
export default Producto;