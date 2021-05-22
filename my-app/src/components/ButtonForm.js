import React, { Component } from 'react';
import './ButtonForm.css';


const STYLE=[
    'is-primary',
    'is-link'
]

const SIZE=[
    'is-small',
    'is-normal',
    'is-medium',
    'is-large'
]

export const ButtonForm = ({
    children,
    type,
    onClick,
    buttonStyle,
    buttonSize
}) =>{
    const checkButtonStyle = STYLE.includes(buttonStyle) ? buttonStyle : STYLE[0];
    const checkButtonSize = SIZE.includes(buttonSize) ? buttonSize : SIZE[0];
    return (
        <button className={`button ${checkButtonStyle} ${checkButtonSize}`} onClick={onClick}
        type={type}>{children}</button>
    )
}