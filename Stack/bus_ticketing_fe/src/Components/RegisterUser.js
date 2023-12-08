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
    const [usernameError,setUsernameError]=useState("");
    const [emailError,setEmailError]=useState("");
    const [phoneError,setPhoneError]=useState("");
    const [cityError,setCityError]=useState("");
    const [pincodeError,setPincodeError]=useState("");
    const [passwordError,setPasswordError]=useState("");
    const [repasswordError,setRePasswordError]=useState("");
    var checkUSerData = ()=>{
        if(username=='')
        {
            setUsernameError("Username cannot be empty");
            return false;
        }
        if(email=='')
        {
            setEmailError("Email cannot be empty");
            return false;
        }
        if(phone=='')
        {
            setPhoneError("Phone Number cannot be empty");
            return false;
        }
        if(city=='')
        {
            setCityError("City cannot be empty");
            return false;
        }
        if(pincode=='')
        {
            setPincodeError("Pincode cannot be empty");
            return false;
        }
           
        if(password==''){
            setPasswordError("Password cannot be Empty");
            return false;
        }
        if(password!=repassword){
            setRePasswordError("Password and Repassword should be same");
            return false;
        }

        
      return true;
    }
    const signUp = (event)=>{
        event.preventDefault();
        var checkData = checkUSerData();
        if(checkData==false)
        {
            alert('please check your data')
            return;
        }
        
        axios.post("http://localhost:5110/api/Customer",{
            username: username,
            role:	"User",
            password:password,
            email:email,
            city:city,
            phone:phone,
            pincode:pincode
    })
        .then((userData)=>{
            console.log(userData);
            alert("Registration Successfull!!")

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
           <label >{usernameError}</label>
            <label className="form-control">Email</label>
            <input type="email" className="form-control" value={email}
                    onChange={(e)=>{setEmail(e.target.value)}}/>
            <label >{emailError}</label>
             <label className="form-control">Phone</label>
            <input type="text" className="form-control" value={phone}
                    onChange={(e)=>{setPhone(e.target.value)}}/>
            <label >{phoneError}</label>
             <label className="form-control">City</label>
            <input type="text" className="form-control" value={city}
                    onChange={(e)=>{setCity(e.target.value)}}/>
            <label >{cityError}</label>
             <label className="form-control">Pincode</label>
            <input type="text" className="form-control" value={pincode}
                    onChange={(e)=>{setPincode(e.target.value)}}/>
            <label >{pincodeError}</label>
            <label className="form-control">Password</label>
            <input type="password" className="form-control" value={password}
                    onChange={(e)=>{setPassword(e.target.value)}}/>
            <label>{passwordError}</label>
            <label className="form-control">Re-Type Password</label>
            <input type="text" className="form-control" value={repassword}
                    onChange={(e)=>{setrePassword(e.target.value)}}/>
            <label>{repasswordError}</label>
           
            <br/>
            <button className="btn btn-primary button" onClick={signUp}>Sign Up</button>
            
            <button className="btn btn-danger button">Cancel</button>
            <div class="container signin">
                <br/>
   
  </div>
        </form>
    );
}

export default RegisterUser;