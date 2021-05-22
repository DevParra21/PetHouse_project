import React, { Component } from 'react';
import './Card.css';

const Card = ({hogar}) => {
    return (
        // <div className="columns">
        <div className="card">
            <div className="card-image">
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
                    <p className="title is-4">{hogar.nombre}</p>
                    <p className="subtitle is-6">@{hogar.cliente}</p>
                </div>
                </div>
                <div className="content">
                {hogar.descripcion}
                    <div className="footer-card">
                        <small>no. de mascotas: {hogar.mascotas}</small> |
                        <small> $ {hogar.precio} MXN </small>
                    </div>
                        <button className="button is-link"><i className="fas fa-ellipsis-h"></i></button>
                </div>
            </div>
        </div>
    // </div>
     );
}
export default Card;