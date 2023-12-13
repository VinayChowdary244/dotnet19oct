import React, { useState, useEffect } from 'react';
import './App.css';
import RegisterUser from './Components/RegisterUser';
import UserLogin from './Components/UserLogin';
import BusSeatSelection from './Components/BusSeatSelection';
import { BrowserRouter as Router, Routes, Route, BrowserRouter } from 'react-router-dom';
import UpdateUser from './Components/UpdateUser';
import Menu from './Components/Menu';
import RedBus from './Components/redBus';
import Busses from './Components/Busses';
import UserHistory from './Components/UserHistory';
import BookingList from './Components/BookingList';
import Protected from './Protected';
import Users from './Components/Users';
import AddBus from './Components/Addbus';
import UpdateBus from './Components/UpdateBus';
import Logout from './Components/Logout';
import DriverDetails from './Components/DriverDetails';
import CancelledBookings from './Components/CancelledBookings';
import AdminMenu from './Components/AdminMenu';
import TicketCard from './Components/TicketCard';

import DashBoard from './Components/DashBoard';

function App() {

  return (
    
    
    <BrowserRouter>
    <div>
      <DashBoard/>
      <Routes>
        <Route path="Buses" element={<Protected><Busses /></Protected>} />
        <Route path="addBus" element={<Protected><AddBus/></Protected>}/>
        <Route path="updateBus" element={<Protected><UpdateBus/></Protected>}/>
        <Route path="UpdateUser" element={<UpdateUser />} />
        <Route path="Users" element={<Protected><Users/></Protected>} />
        <Route path="BookingList" element={<Protected><BookingList /></Protected>} />
        <Route path="Logout" element={<Logout/>}/>
        <Route path="CancelledBookings" element={<Protected><CancelledBookings/></Protected>}/>
        <Route path='/' element={<RegisterUser />} />
        <Route path="/UserLogin" element={<UserLogin />} />
        <Route path="BusSeatSelection" element={<Protected><BusSeatSelection /></Protected>} />
        <Route path="UserHistory" element={<Protected><UserHistory /></Protected>} />
        <Route path='/Redbus' element={<RedBus />} />
        <Route path="AdminMenu" element={<Protected><AdminMenu /></Protected>} />
        <Route path="Menu" element={<Protected><Menu /></Protected>} />
        <Route path="Logout" element={<Logout/>}/>
        <Route path="TicketCard" element={<TicketCard/>}/>

        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
