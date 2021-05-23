import React, {Fragment, useState} from 'react';
import { BrowserRouter, Route, Redirect } from 'react-router-dom';
import Navbar from './components/Navbar/Navbar';
import Signup from './components/Signup/Signup';
import Main from 'components/Main/Main';
import Homedetail from 'components/HomeDetail/Homedetail';
import './App.css';
import Reservation from 'components/reserve/Reservation';

function App() {
  
  return (
      <Fragment>
        <BrowserRouter basename={'/pethouse'}>
        <Navbar />
        <Redirect from="/" to="/home"/>
            <Route exact path="/home" component = {Main} />
            <Route exact path="/signup" component={Signup} />
            <Route path="/details" component={Homedetail} />
            <Route path="/reservation" component={Reservation}/>
        </BrowserRouter>
      </Fragment>
      
  );
}

export default App;
