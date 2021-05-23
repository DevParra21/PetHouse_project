
import { MuiPickersUtilsProvider, KeyboardTimePicker, KeyboardDatePicker, } from '@material-ui/pickers';
import React, { Component, Fragment, useState } from 'react';
import {Create} from '../../api/UsuarioAPI';
import {useAlert} from "react-alert";
import './Signup.css';



const Signup = (props) => {
    const alert = useAlert();
    const [user, setUsers] = useState({
      name: "",
      pLastName: "",
      mLastName: "",
      birthDate: "",
      street: "",
      noExt: "",
      noInt: "",
      postalCode: "",
      ciudadId: 0,
      userName: "",
      email: "",
      phoneNumber: "",
      password:""
    });

    const onSubmit= async (e) =>{
      e.preventDefault();
      await Create(user);
      alert.success(`Registro finalizado con éxito. Bienvenido, ${user.name}! (serás redirigido automáticamente al inicio).`);
      setTimeout(_=>{
        props.history.push('/home');
      },3000);
      
    }

    const handleInputChange = (e) =>{
      const {name, value} = e.target;
      setUsers({
        ...user,
        [name]:value
      })
      console.log(name,value);
    }

    return (  
        <Fragment>
            <div className="container">
                <form action="POST" onSubmit={onSubmit}>
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
                              <input type="text" className="form-control input" name="name" value={user.name} required onChange={handleInputChange}/>
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col">
                            <div className="form-group">
                              <label for="pLastName">Apellido Paterno *</label>
                              <input type="text" className="form-control input" name="pLastName" value={user.pLastName} required onChange={handleInputChange} />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col">
                            <div className="form-group">
                              <label for="mLastName">Apellido Materno *</label>
                              <input type="text" className="form-control input" name="mLastName" value={user.mLastName} required onChange={handleInputChange} />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                    </div>
                    <div className="row m-2">
                        <div className="col-4">
                            <div className="form-group">
                              <label for="phoneNumber">Número Telefónico *</label>
                              <input type="number" className="form-control input" name="phoneNumber" maxLength='10' required value={user.phoneNumber} onChange={handleInputChange} />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col-4">
                            <div className="form-group">
                              <label for="birthDate">Fecha de Nacimiento</label>
                              <input type="date" className='input' name="birthDate" value={user.birthDate} onChange={handleInputChange} required/>
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
                              <label for="street">Calle *</label>
                              <input type="text" className="form-control input" name="street" value={user.street}  required onChange={handleInputChange}/>
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col-2">
                            <div className="form-group">
                              <label for="noExt">No. exterior*</label>
                              <input type="text" className="form-control input" name="noExt" value={user.noExt}  required onChange={handleInputChange}/>
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col-2">
                            <div className="form-group">
                              <label for="noInt">No. interior</label>
                              <input type="text" className="form-control input" name="noInt"  value={user.noInt} onChange={handleInputChange}/>
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                    </div>
                    <div className="row m-2">
                        {/* <div className="col">
                            <div className="form-group">
                              <label for="colonia">Colonia *</label>
                              <input type="text" className="form-control input" name="colonia" required />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div> */}
                        <div className="col-3">
                            <div className="form-group">
                              <label for="postalCode">Código Postal *</label>
                              <input type="number" className="form-control input" name="postalCode" value={user.postalCode} maxLength='5'  required onChange={handleInputChange}/>
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
                             <select className="form-control" name="estado" id="estado" onChange={handleInputChange}>
                               <option value="1" >Aguascalientes</option>
                               <option value="2">Nuevo León</option>
                               <option value="3">Veracruz</option>
                             </select>
                           </div>
                        </div>
                        <div className="col">
                           <div className="form-group">
                             <label for="ciudadId">Ciudad *</label>
                             <select className="form-control" name="ciudadId" id="ciudad" value={user.ciudadId} onChange={handleInputChange}>
                               <option value="1">Monterrey</option>
                               <option value="2">San Pedro Garza García</option>
                               <option value="3">Guadalupe</option>
                               <option value="4">Escobedo</option>
                               <option value="5">Apodaca</option>
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
                              <label for="email">Correo Electrónico *</label>
                              <input type="email" className="form-control input" name="email" value={user.email} required onChange={handleInputChange}/>
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col-1"><h1 id='check'><i className='fas fa-check'></i></h1></div>
                        <div className="col-5">
                            <div className="form-group">
                              <label for="userName">Nombre de Usuario *</label>
                              <input type="text" className="form-control input" name="userName" value={user.userName} required onChange={handleInputChange}/>
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                    </div>
                    <div className="row m-2">
                    <div className="col">
                            <div className="form-group">
                              <label for="password">Contraseña *</label>
                              <input type="password" className="form-control input" name="password" maxLength='25' value={user.password}  required onChange={handleInputChange} />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                        <div className="col">
                            <div className="form-group">
                              <label for="contrasena">Confirmar contraseña *</label>
                              <input type="password" className="form-control input" name="contrasena" maxLength='25' required onChange={handleInputChange} />
                              <small id="helpId" className="error">Help text</small>
                            </div>
                        </div>
                    </div>
                    <div className="row mt-2 ml-2 mr-2 mb-5">
                        <div className="col-12">
                            <button type="submit" class="button is-primary" >Registrar</button>
                        </div>
                    </div>
                </form>
            </div>
        </Fragment>
    );
}
 
export default Signup;
