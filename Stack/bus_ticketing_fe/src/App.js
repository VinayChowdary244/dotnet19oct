import React, { useState, useEffect } from 'react';
import './App.css';
import RegisterUser from './Components/RegisterUser';
import UserLogin from './Components/UserLogin';
import BusSeatSelection from './Components/BusSeatSelection';
import { BrowserRouter as Router, Routes, Route, BrowserRouter } from 'react-router-dom';
import UpdateUser from './Components/UpdateUser';
import Menu from './Components/Menu';
import RedBus from './Components/redBus';
import Buses from './Components/Busses';
import UserHistory from './Components/UserHistory';
import BookingList from './Components/BookingList';
import Protected from './Protected';
import Users from './Components/Users';

function App() {
 
// var [seat,setSeat]=useState([]);
// var bookSeat=(bNo)=>{
//   setSeat([...seat,bNo])
//   console.log(seat)
  
// }

// var [IsLoggedIn, setLoggedIn] = useState(false);

// useEffect(() => {
//   var token = localStorage.getItem("token");
//   if (token) {
//     setLoggedIn(true);
//   }
// }, []);
  return (
    <div className="App">
 <BrowserRouter>
         <Menu/>
        <Routes>
        

        <Route path='/RegisterUser' element={<RegisterUser />} />
        <Route path='/' element={<RegisterUser />} />

        <Route path="/UserLogin" element={<UserLogin />} />
        <Route path="Buses" element={<Protected><Buses /></Protected>} />
        <Route path="BusSeatSelection" element={<Protected><BusSeatSelection /></Protected>} />
        <Route path="UpdateUser" element={<UpdateUser />} />
        <Route path="UserHistory" element={<UserHistory />} />
        <Route path="Users" element={<Protected><Users/></Protected>} />
        <Route path="BookingList" element={<Protected><BookingList /></Protected>} />
        <Route path="RedBus" element={<RedBus />} />
        </Routes>
      </BrowserRouter> 
    </div>
  );
}

export default App;
