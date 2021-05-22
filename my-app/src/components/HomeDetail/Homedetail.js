import React ,{ Fragment } from 'react';
import  CarouselDetail  from '../Carousel';
import './Homedetail.css';
import 'bootstrap/dist/css/bootstrap.min.css';


const Maindetail = () => {
    return (  
        <Fragment>
            <div className="container">
                <h1 className="title">Nombre de Hogar</h1>
                <CarouselDetail />
                <h1 className="title">Información General</h1>
                <h3 className="description">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                </h3>
                <div className="row">
                    <div className="col">
                        <div className="float-right">
                            <span className="money">$ 999.99 MXN</span>
                            <a className="button is-primary">Reservar</a>
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col">
                        <h1>Dirección</h1>
                    </div>
                </div>
                <div className="row mt-5 ml-3">
                    <div className="col">
                        <div><label>Calle: </label> <span>Nombre de Calle</span></div>
                    </div>
                    <div className="col">
                        <div><label>No ext: </label> <span>No exterior</span></div>
                    </div>
                </div>
            </div>
        </Fragment>
    );
}
 
export default Maindetail;