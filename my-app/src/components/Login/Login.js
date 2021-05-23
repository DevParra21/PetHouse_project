import React, { Component, Fragment, useRef, useEffect, useCallback } from 'react';
import { Link } from 'react-router-dom';
import styled from 'styled-components';
import {MdClose} from 'react-icons/md';
import {useSpring, animated} from 'react-spring';


const Background = styled.div`
width:100%;
height: 100%;
background: rgba(0,0,0,0.8);
position:fixed;
display:flex;
justify-content:center;
align-items:center;
z-index: 9;
`

const ModalWrapper = styled.div`
   width:800px;
   height:${window.height};
   box-shadow: 0 5px 16px rgba(0,0,0,0.2);
   background: #FFF;
   color:#000;
   display: grid;
   grid-template-columns: 1fr 1fr;
   position: relative;
   z-index:10;
   border-radius: 10px;
`
const ModalImg = styled.img`
    width:100%;
    height:100%;
    border-radius:10px 0 0  10px;
    background:#000;
`
const ModalContent = styled.div`
    display:flex;
    flex-direction:column;
    justify-content:center;
    align-items: center;
    line-height: 1.8;
    color:#141414;
    p{
        margin-bottom:1rem;
    }

    button{
        padding:10px 24px;
        background:#141414;
        color:#fff;
        border:none;
    }
`

const CloseModalButton = styled(MdClose)`
    cursor:pointer;
    position:absolute;
    top:20px;
    right:20px;
    width:32px;
    height:32px;
    padding:0;
    z-index:0;
`


const Login = ({showModal, setShowModal}) => {

    const modalRef = useRef();

    const animation = useSpring({
        opacity: showModal ? 1 : 0,
        transform: showModal ? `translateY(0%)` : `translateY(-100%)`
    })

    const closeModal = (e) =>{
        if(modalRef.current === e.target)
            setShowModal(false);
    };

    return ( 
        <Fragment>
         {showModal ? (
             <Background ref={modalRef} onClick={closeModal}>
                 <animated.div style={animation}>
                 <ModalWrapper showModal={showModal}>
                     <ModalImg src='https://image.freepik.com/vector-gratis/pet-house-perro-gato-vintage-logo_7688-1573.jpg' alt='camera' />
                     <ModalContent className="container-fluid">
                         <form>
                            <div className="row mt-5">
                                <div className="col">
                                    <small>Correo Electrónico</small>
                                    <input className='form-control' type='email'/>
                                    <small className="error">Por favor ingrese un correo válido</small>
                                </div>
                            </div>
                            <div className="row mt-3">
                                <div className="col">
                                    <small>Contraseña</small>
                                    <input className='form-control' type='password'/>
                                    <small className="error">Correo o Contraseña incorrecta.</small>
                                </div>
                            </div>
                            <div className="row mt-5">
                                <div className="col">
                                    <small><a href={'#'}>Olvidé mi contraseña</a></small>
                                </div>
                                <div className="col">
                                <button type='submit' className="button is-link mt-2">Iniciar Sesión</button>
                                </div>
                            </div>
                            <div className="row mt-3">
                                <div className="col-lg-3"></div>
                                <div className="col-lg-7 align-self-center">
                                    <small><Link to='/signup' style={{textDecoration: 'none'}} onClick={() => setShowModal(prev => !prev)}>Aún no estoy registrado</Link></small>
                                </div>
                                <div className="col-lg-1"></div>
                            </div>
                         </form>
                     </ModalContent>
                     <CloseModalButton aria-label='Close modal' onClick={() => setShowModal(prev => !prev)} />
                 </ModalWrapper>
                 </animated.div>
             </Background>
           ) : null} 
            </Fragment>
     );
}
 
export default Login;