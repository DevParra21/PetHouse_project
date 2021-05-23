import React, { Component } from 'react'
import './Reservation.css';


const Reservation = () => {
    return (  
        <div className="container">
            <section className="hero is-medium is-bold">
            <div className="hero-body">
                <div className="columns">
                    <div className="column">
                        <figure className="image is-512x512">
                        <img src="https://bulma.io/images/placeholders/1280x960.png" alt="Placeholder image"/>
                        </figure>
                    </div>
                    <div className="column">
                        <div className="field">
                            <label className="label">Selecciona tu mascota</label>
                            <div>
                                <p class="control">
                                    <span class="select">
                                    <select>
                                        <option>mascota 1</option>
                                        <option>mascota 2</option>
                                        <option>mascota 3</option>
                                    </select>
                                    </span>
                                </p>
                            </div>
                        </div>
                        <div className="columns">
                            <div className="column">
                                <div className="field">
                                    <label className="label">Fecha de entrada</label>
                                    <input className="input" type="date" />
                                    <small className="help is-danger">La fecha no puede ser  menor que la fecha actual</small>
                                </div>
                            </div>
                            <div className="column">
                                <div className="field">
                                    <label className="label">Fecha de salida</label>
                                    <input className="input" type="date" />
                                    <small className="help is-danger">La fecha no puede ser  menor que la fecha de entrada</small>
                                </div>
                            </div>
                        </div>
                        <div className="field">
                          <label className="label">Cantidad a pagar</label>
                          <p className="control">
                            <input className="input is-warning" type="number" placeholder="$" disabled/>
                          </p>
                        </div>
                        
                        
                        <div className="field">
                          <label className="label">Comentarios</label>
                          <p className="control">
                            <textarea className="textarea" placeholder="Textarea"></textarea>
                          </p>
                        </div>
                        
                        
                        <div className="field">
                          <p className="control">
                            <button className="button is-link is-fullwidth">Reservar</button>
                          </p>
                          <p className="control">
                            <button className="button is-danger">Seguir buscando</button>
                          </p>
                        </div>
                    </div>
                </div>
            </div>
            </section>

        </div>
    );
}
 
export default Reservation;