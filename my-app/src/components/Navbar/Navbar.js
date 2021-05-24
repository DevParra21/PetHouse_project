import React, { Component, Fragment, useState } from 'react';
import { Link } from 'react-router-dom';
import { MenuItems } from  './MenuItems';
import { Button, ButtonLanding } from '../Button';
import './Navbar.css';
import Login from 'components/Login/Login';

const Navbar = () => {

    const[showBars, setShowBars] = useState(false);
    const[showModal, setShowModal] = useState(false);

    const ChangeToBars = () =>{
        setShowBars(prev => !prev);
    }

    const ShowModal = () =>{
        setShowModal(prev => !prev);
    }

    return ( 
        <Fragment>
        <Login showModal={showModal} setShowModal={setShowModal} />
        <nav className="NavbarItems">
            <h1 className="navbar-logotipo"><Link to="/home" style={{textDecoration: 'none', color: '#FF9500'}} >PetHouse</Link><small id="registeredMark">&trade;</small><i className="fas fa-paw"></i></h1>
            <div className="menu-icon" onClick={ChangeToBars}>
                <i className= {showBars ? 'fas fa-times' : 'fas fa-bars'}></i>
            </div>
            <ul className={showBars ? 'nav-menu active' : 'nav-menu'}>
                {MenuItems.map((item, index)=>{
                    return (
                        <li key={index}>
                            <a className={item.cName} href={item.url}>{item.title}</a>
                        </li>
                    );
                })}
            </ul>
            <ButtonLanding buttonStyle={"is-primary"} onClick={ShowModal}>Log in</ButtonLanding>
        </nav>
        
        </Fragment>
     );
}
 
export default Navbar;
// class Navbar extends Component {

//     const [showLogin, setShowLogin] = useState(false)

//     state = {
//         clicked:false
//     }

//     handleClick = () =>{
//         this.setState({clicked: !this.state.clicked})
//     }

//     render(){
//         return(
//             <nav className="NavbarItems">
//                 <h1 className="navbar-logotipo"><Link to="/home" style={{textDecoration: 'none', color: '#FF9500'}} >PetHouse</Link><small id="registeredMark">&trade;</small><i className="fas fa-paw"></i></h1>
//                 <div className="menu-icon" onClick={this.handleClick}>
//                     <i className= {this.state.clicked ? 'fas fa-times' : 'fas fa-bars'}></i>
//                 </div>
//                 <ul className={this.state.clicked ? 'nav-menu active' : 'nav-menu'}>
//                     {MenuItems.map((item, index)=>{
//                         return (
//                             <li key={index}>
//                                 <a className={item.cName} href={item.url}>{item.title}</a>
//                             </li>
//                         );
//                     })}
//                 </ul>
//                 <Button><Link to="/signup" className="link">Regístrate</Link></Button>
//             </nav>
//         )
//     }
// }

// export default Navbar;