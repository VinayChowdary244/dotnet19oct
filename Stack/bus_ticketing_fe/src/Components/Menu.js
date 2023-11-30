import { Link } from "react-router-dom";
import './Menu.css'
function Menu(){
    return (
<nav className="navbar navbar-expand-lg navbar-light bg-light">
  
  <div className="collapse navbar-collapse" id="navbarNav">
    <ul className="navbar-nav">
     
    <li className="nav-item">
        <Link className="nav-link" to="/redBus" >Home</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="/buses" >Buses</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="/updateUser" >UpdateUserDetails</Link>
      </li>
     
      
     
      <li className="nav-item">
        <Link className="nav-link" to="/registerUser" >Register</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="/loginUser" >Login</Link>
      </li>
      

    </ul>
  </div>
</nav>
    );
}

export default Menu;

