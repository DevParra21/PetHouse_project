import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import {transitions, positions, Provider as AlertProvider} from "react-alert";
import AlertTemplate from 'react-alert-template-basic';

const alertOptions ={
    position: positions.BOTTOM_CENTER,
    timeout:3000,
    offset:"30px",
    transitions:transitions.SCALE
}

ReactDOM.render(
    <React.StrictMode>
    <AlertProvider template={AlertTemplate} {...alertOptions}>
        <App />
    </AlertProvider>
    </React.StrictMode>
    , document.getElementById('root'));

