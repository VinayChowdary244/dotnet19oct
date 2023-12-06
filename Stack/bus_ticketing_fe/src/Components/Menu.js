import { Link, NavLink } from "react-router-dom";
import './Menu.css'
function Menu(){
    return (
<nav className="navbar navbar-expand-lg navbar-light bg-light">
  
  <div className="collapse navbar-collapse" id="navbarNav">
    <ul className="navbar-nav">
     
    <li className="nav-item">
        <NavLink className="nav-link" to="/redBus" >Home</NavLink>
      </li>
      <li className="nav-item">
        <NavLink className="nav-link" to="/buses" >Buses</NavLink>
      </li>
      <li className="nav-item">
        <NavLink className="nav-link" to="/updateUser" >UpdateUserDetails</NavLink>
      </li>
      <li className="nav-item">
        <NavLink className="nav-link" to="/bookingList" >Bookings</NavLink>
      </li>
      <li className="nav-item">
        <NavLink className="nav-link" to="/users" >Users</NavLink>
      </li>
      <li className="nav-item">
        <NavLink className="nav-link" to="/userHistory" >UserHistory</NavLink>
      </li>
      <li className="nav-item">
       <NavLink className="nav-link" to="/registerUser">Register</NavLink>
      </li>
      <li className="nav-item">
       <NavLink className="nav-link" to="/busDetails">BusDetails</NavLink>
      </li>
      
      

    </ul>
  </div>
</nav>
    );
}

export default Menu;

