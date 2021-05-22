import React, { Fragment } from 'react';
import Carousel from 'react-bootstrap/Carousel'
import 'bootstrap/dist/css/bootstrap.min.css';
import './Carousel.css';




const CarouselDetail = () => {


    return ( 
        
        <Carousel className="carrusel">
            <Carousel.Item>
                <img
                className="d-block w-100"
                src="https://bulma.io/images/placeholders/1280x960.png"
                alt="First slide"
                />
                <Carousel.Caption>
                <h3>First slide label</h3>
                <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                </Carousel.Caption>
            </Carousel.Item>
            <Carousel.Item>
            <img
            className="d-block w-100"
            src="https://bulma.io/images/placeholders/1280x960.png"
            alt="Second slide"
            />
            <Carousel.Caption>
            <h3>Second slide label</h3>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
            </Carousel.Caption>
            </Carousel.Item>
            <Carousel.Item>
            {/* <img
            className="d-block w-100"
            src="https://bulma.io/images/placeholders/1280x960.png"
            alt="Third slide"
            /> */}
            <figure className="image is-16by9">
                <iframe className="has-ratio" width="640" height="360" src="https://www.youtube.com/embed/YE7VzlLtp-4" frameborder="0" allowfullscreen></iframe>
            </figure>
            <Carousel.Caption>
            <h3>Third slide label</h3>
            <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
            </Carousel.Caption>
            </Carousel.Item>
        </Carousel>
     );
}
 
export default CarouselDetail;