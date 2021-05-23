import React, { Component, useEffect } from 'react';
import { Link } from 'react-router-dom';
import './Card.css';


const Card = ({hogar}) => {
    return (
        // <div className="columns">
            <div className="card">
                <div className="col">
                <div className="card-image p-3">
                    <figure className="image is-4by3">
                    <img src="https://bulma.io/images/placeholders/1280x960.png" alt="Placeholder image" />
                    </figure>
                </div>
                <div className="card-content">
                    <div className="media">
                    <div className="media-left">
                        <figure className="image is-48x48">
                        <img src="https://bulma.io/images/placeholders/96x96.png" alt="Placeholder image" />
                        </figure>
                    </div>
                    <div className="media-content">
                        <p className="subtitle is-6">@{hogar.nombreDueno}</p>
                    </div>
                    </div>
                    <div className="content">
                    {hogar.descripcion}
                        <div className="footer-card mb-3">
                            <small>no. de mascotas: {hogar.capacidad}</small> |
                            <small> $ {hogar.costoPorNoche} MXN x noche </small>
                        </div>
                        <Link to="/details" params={{id: hogar.id}} style={{textDecoration:'none', position:'relative', bottom:'-5px', alignSelf:'center'}}><button className="button is-link cardBtn"><i className="fas fa-ellipsis-h"></i></button></Link>
                    </div>
                </div>
            </div>
        </div>
    // </div>
     );
}
export default Card;