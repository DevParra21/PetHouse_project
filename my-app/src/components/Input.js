import React, { Component } from 'react';
import './Input.css';

const STYLE=[
    'input',
    'input is-primary',
    'input is-link',
    'input--outline'
]

const SIZE=[
    'is-small',
    'is-medium',
    'is-large'
]

export const Input=({
    children, type, inputStyle, inputSize, isRounded
}) =>{
    const checkInputStyle = STYLE.includes(inputStyle) ?inputStyle : STYLE[0];
    const checkInputSize = STYLE.includes(inputSize) ? inputSize : SIZE[0];
    const checkIsRounded = isRounded ? 'is-rounded' : '';
    return(
        <div className="control">
            <span>{children}</span>
            <input className={`${checkInputStyle} ${checkInputSize} ${checkIsRounded}`} type={type} placeholder={children}/>
        </div>
    )
}