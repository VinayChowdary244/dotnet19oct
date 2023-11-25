import { useState } from "react";
import './RegisterUser.css';
import axios from "axios";

function RegisterUser(){
    const roles =["User","Admin"];
    const [username,setUsername] = useState("");
    const [email,setEmail] = useState("");
    const [phone,setPhone] = useState("");
    const [city,setCity] = useState("");
    const [pincode,setPincode] = useState("");
    const [password,setPassword] = useState("");
    const [repassword,setrePassword] = useState("");
    const [role,setRole] = useState("");
    var [usernameError,setUsernameError]=useState("");
    var checkUSerData = ()=>{
        if(username=='')
        {
            setUsernameError("Username cannot be empty");
            return false;
        }
           
        if(password=='')
            return false;
        if(role=='Select Role')
            return false;
        return true;
    }
    const signUp = (event)=>{
        event.preventDefault();
        var checkData = checkUSerData();
        if(checkData==false)
        {
            alert('please check yor data')
            return;
        }
        
        axios.post("http://localhost:5110/api/Customer",{
            username: username,
            email: email,
            phone: phone,
            city: city,
            pincode: pincode,
            role:	role,
            password:password
    })
        .then((userData)=>{
            console.log(userData)
        })
        .catch((err)=>{
            console.log(err)
        })
    }
    
    return(
            <form className="registerForm">

            <label className="form-control">Username</label>
            <input type="text" className="form-control" value={username}            
                    onChange={(e)=>{setUsername(e.target.value)}}/>
                    label{usernameError}

            <label className="form-control">Email</label>
            <input type="text" className="form-control" value={email}
                    onChange={(e)=>{setEmail(e.target.value)}}/>

            <label className="form-control">Phone</label>
            <input type="text" className="form-control" value={phone}
                    onChange={(e)=>{setPhone(e.target.value)}}/>

            <label className="form-control">City</label>
            <input type="text" className="form-control" value={city}
                    onChange={(e)=>{setCity(e.target.value)}}/>

            <label className="form-control">Pincode</label>
            <input type="number" className="form-control" value={pincode}
                    onChange={(e)=>{setPincode(e.target.value)}}/>

            <label className="-alert alert-danger">{usernameError}</label>
            <label className="form-control">Password</label>

            <input type="password" className="form-control" value={password}
                    onChange={(e)=>{setPassword(e.target.value)}}/>
            <label className="form-control">Re-Type Password</label>

            <input type="text" className="form-control" value={repassword}
                    onChange={(e)=>{setrePassword(e.target.value)}}/>
            <label className="form-control">Role</label>
            
            <select className="form-select" onChange={(e)=>{setRole(e.target.value)}}>
                <option value="select">Select Role</option>
                {roles.map((r)=>
                    <option value={r} key={r}>{r}</option>
                )}
            </select>
            <br/>
            <button className="btn btn-primary button" onClick={signUp}>Sign Up</button>
            
            <button className="btn btn-danger button">Cancel</button>
        </form>
    );
}

export default RegisterUser;