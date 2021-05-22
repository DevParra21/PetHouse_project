import React, {Fragment, useState} from 'react';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom';
import Navbar from './components/Navbar/Navbar';
import Signup from './components/Signup/Signup';
import Main from 'components/Main/Main';
import Homedetail from 'components/HomeDetail/Homedetail';
import './App.css';

function App() {
  
  return (
      <Fragment>
        <BrowserRouter>
        <Navbar />
        <Redirect 
          from="/"
          to="/home"/>
          <Switch>
            <Route 
              path="/home"
              component = {Main} />
            <Route
              exact
              path="/signup"
              render={() => <Signup/>} />
            <Route
              path="/details"
              render={() => <Homedetail/>} />
          </Switch>
        </BrowserRouter>
      </Fragment>
      
  );
}

export default App;
