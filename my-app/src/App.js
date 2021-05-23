import DateFnsUtils from '@date-io/date-fns';
import { MuiPickersUtilsProvider } from '@material-ui/pickers';
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
        <MuiPickersUtilsProvider utils={DateFnsUtils}>
        </MuiPickersUtilsProvider>
        <BrowserRouter basename={'/pethouse'}>
        <Navbar />
        <Redirect from="/" to="/home"/>
            <Route exact path="/home" component = {Main} />
            <Route exact path="/signup" component={Signup} />
            <Route exact path="/details" component={Homedetail} />
            <Route exact path="/reservation" component={Reservation}/>
        </BrowserRouter>
      </Fragment>
      
  );
}

export default App;
