import React, { Component } from 'react'
import './Searchbar.css';

const Searchbar = () => {
    return (
    <div className="columns">
        <div className="column is-full">
            
      <div className="field has-addons">
        <p className="control">
            <span className="select">
                <select>
                    <option>Nombre</option>
                    <option>Ciudad</option>
                    <option>Tipo de Mascota</option>
                    <option>Precio por noche</option>
                </select>
            </span>
        </p>
        <p className="control is-expanded">
          <input className="input" type="text" placeholder="Ciudad, Tipo de Mascota, Costo..." />
        </p>
        <p className="control">
          <button className="button is-link">
            Búsqueda
          </button>
        </p>
      </div>
      </div>
    </div>
     );
}
 
export default Searchbar;