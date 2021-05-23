import React, { Component } from 'react'
import './Reservation.css';


const Reservation = () => {
    
    
    var aPagar='0';
    var fechaInicial=null;
    var fechaFinal=null;
    const monto=199.99;


    const onChangeHandler = e =>{
        if(e.target.name === 'fechaInicial')
            fechaInicial = new Date(e.target.value);
        else
            fechaFinal = new Date(e.target.value);
        
        if(fechaInicial!=null && fechaFinal!=null)
        {
            let diff = Math.abs(fechaFinal - fechaInicial);
            
            this.setState((diff/(1000*60*60*24)) *monto)
        }
    }
        

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
                                    <input className="input" type="date" name="fechaInicial" onChange={onChangeHandler} />
                                    <small className="help is-danger">La fecha no puede ser  menor que la fecha actual</small>
                                </div>
                            </div>
                            <div className="column">
                                <div className="field">
                                    <label className="label">Fecha de salida</label>
                                    <input className="input" type="date" name="fechaFinal" onChange={onChangeHandler} />
                                    <small className="help is-danger">La fecha no puede ser  menor que la fecha de entrada</small>
                                </div>
                            </div>
                        </div>
                        <div className="columns">
                            <div className="column">
                                <div className="field">
                                    <label className="label">Costo por noche</label>
                                    <p className="control">
                                        <span> $ {monto}</span>
                                    </p>
                                </div>
                            </div>
                            <div className="column">
                                <div className="field">
                                    <label className="label">Cantidad a pagar</label>
                                    <p className="control">
                                        <span>$ {aPagar}</span>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div className="field">
                          <label className="label">Comentarios</label>
                          <p className="control">
                            <textarea className="textarea" placeholder="Agrega comentarios sobre tu mascota (Si dejarás comida, si necesita cuidados especiales, etcétera)."></textarea>
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