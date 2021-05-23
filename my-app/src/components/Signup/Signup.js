import React, { Component, Fragment } from 'react';
import './Signup.css';

import {Input} from 'components/Input';
import {ButtonForm} from 'components/ButtonForm';

const Signup = () => {

    // const soloNumeros = (e) =>{
    //     return e.target.value === 
    // }

    return (  
        <Fragment>
            <div className="container">
                <form action="POST">
                    <div className="row mt-3">
                        <div className="col ">
                         <h1 style={{display:'inline-block'}}><i className='fas fa-user-plus'></i> Registro de usuario nuevo.</h1>
                        </div>
                    </div>
                    <hr/>
                    <div className="row">
                        <legend>Datos Personales</legend>
                    </div>
                    <div className="row m-2">
                        <div className="col">
                            <div className="form-group">
                              <label for="nombre">Nombre(s) *</label>
                              <input type="text" className="form-control input" name="nombre" />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col">
                            <div className="form-group">
                              <label for="apellidoPaterno">Apellido Paterno *</label>
                              <input type="text" className="form-control input" name="apellidoPaterno" />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col">
                            <div className="form-group">
                              <label for="apellidoMaterno">Apellido Materno *</label>
                              <input type="text" className="form-control input" name="apellidoMaterno" />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                    </div>
                    <div className="row m-2">
                        <div className="col-4">
                            <div className="form-group">
                              <label for="nombre">Número Telefónico *</label>
                              <input type="number" className="form-control input" name="nombre" maxLength='10' />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col-4">
                            <div className="form-group">
                              <label for="apellidoPaterno">Fecha de Nacimiento</label>
                              <input type="date" className='input'/>
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                    </div>
                    <hr/>
                    <div className="row">
                        <legend>Dirección</legend>
                    </div>
                    <div className="row m-2">
                        <div className="col">
                            <div className="form-group">
                              <label for="calle">Calle *</label>
                              <input type="text" className="form-control input" name="calle" />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col-2">
                            <div className="form-group">
                              <label for="noExterior">No. exterior*</label>
                              <input type="text" className="form-control input" name="noExterior" />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col-2">
                            <div className="form-group">
                              <label for="noInterior">No. interior</label>
                              <input type="text" className="form-control input" name="noInterior" />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                    </div>
                    <div className="row m-2">
                        <div className="col">
                            <div className="form-group">
                              <label for="colonia">Colonia *</label>
                              <input type="text" className="form-control input" name="colonia" />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col-3">
                            <div className="form-group">
                              <label for="codigopostal">Código Postal *</label>
                              <input type="number" className="form-control input" name="codigopostal" maxLength='5' />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                    </div>
                    <div className="row m-2">
                        <div className="col">
                           <div className="form-group">
                             <label for="pais">Pais</label>
                             <select className="form-control" name="pais" id="pais" disabled>
                               <option>México</option>
                             </select>
                           </div>
                        </div>
                        <div className="col">
                           <div className="form-group">
                             <label for="estado">Estado *</label>
                             <select className="form-control" name="estado" id="estado">
                               <option>Aguascalientes</option>
                               <option>Nuevo León</option>
                               <option>Veracruz</option>
                             </select>
                           </div>
                        </div>
                        <div className="col">
                           <div className="form-group">
                             <label for="ciudad">Ciudad *</label>
                             <select className="form-control" name="ciudad" id="ciudad">
                               <option value='1'>Monterrey</option>
                               <option>San Pedro Garza García</option>
                               <option>Guadalupe</option>
                               <option>Escobedo</option>
                               <option>Apodaca</option>
                             </select>
                           </div>
                        </div>
                    </div>
                    <hr />
                    <div className="row">
                        <legend>Acceso</legend>
                    </div>
                    <div className="row m-2">
                        <div className="col-6">
                            <div className="form-group">
                              <label for="colonia">Correo Electrónico *</label>
                              <input type="text" className="form-control input" name="colonia" />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col-1"><h1 id='check'><i className='fas fa-check'></i></h1></div>
                    </div>
                    <div className="row m-2">
                    <div className="col">
                            <div className="form-group">
                              <label for="contrasena">Contraseña *</label>
                              <input type="password" className="form-control input" name="contrasena" maxLength='5' />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col">
                            <div className="form-group">
                              <label for="contrasena">Confirmar contraseña *</label>
                              <input type="password" className="form-control input" name="contrasena" maxLength='5' />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                    </div>
                    <div className="row mt-2 ml-2 mr-2 mb-5">
                        <div className="col-12">
                            <button type="submit" class="button is-primary">Registrar</button>
                        </div>
                    </div>
                </form>
            </div>
        </Fragment>
    );
}
 
export default Signup;
