import React, { Component } from 'react';
import './Signup.css';

import {Input} from 'components/Input';
import {ButtonForm} from 'components/ButtonForm';

class Signup extends Component{

    render(){
        return(
            <form className="signup-form container is-max-desktop">
            <div className="columns">
                <div className="column">
                    <Input>Nombre</Input>   
                </div>
                <div className="column">
                    <Input>Apellido Paterno</Input>
                </div>
                <div className="column">
                    <Input>Apellido Materno</Input>
                </div>
            </div>
            <div className="columns">
                <div className="column">
                    <Input type="email">Correo Electronico</Input>
                </div>
            </div>
            <div className="columns">
                <div className="column">
                    <Input type="password">Contraseña</Input>
                </div>
            </div>
            <ButtonForm type="submit" className="is-link">Registrar</ButtonForm>
            </form>
        )
    }
}

export default Signup;