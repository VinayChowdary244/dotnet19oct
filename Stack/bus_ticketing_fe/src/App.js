import React, { useState } from 'react';
import logo from './logo.svg';
import './App.css';
import AddBus from './Components/Addbus';
import RegisterUser from './Components/RegisterUser';
import GetBus from './Components/GetBusses';
import UserLogin from './Components/UserLogin';
import BusSeatSelection from './Components/BusSeatSelection';
import SearchBus from './Components/SearchBus';
//import { Route, Router } from 'react-router-dom';
import SearchForm from './Components/SearchForm';
import SearchResults from './Components/SearchResults';

import { BrowserRouter as Router, Routes, Route, BrowserRouter } from 'react-router-dom';
import UpdateUser from './Components/UpdateUser';
import Menu from './Components/Menu';
import BusListing from './Components/BusListing';
import RedBus from './Components/redBus';





function App() {
  var buses =[
    {
       "id":101,
       "type":"A/c",
       "seatNo":10,
       "cost":500
   },
   {
      "id":102,
      "type":"Non-A/c",
      "seatNo":2,
      "cost":800
   },
   {
      "id":103,
      "type":"Super-Deluxe",
      "seatNo":8,
      "cost":700
   }
]
var [seat,setSeat]=useState([]);
var bookSeat=(bNo)=>{
  setSeat([...seat,bNo])
  console.log(seat)
  
}

// var [IsLoggedIn,setLoggedIn]=useState(false);
// var changeState=()=>{
//   var token = localStorage.getItem("token");
//   if(token){
//     setLoggedIn(true);
//   }
// }
  return (
    <div className="App">
        {/*------------User Register and login--------------- <div className="row">
          <div className="col">
            <RegisterUser/> 
          </div>
          <div className="col">
            <UserLogin/>
          </div>
        </div> ---------------------------------------*/}



        {/* <div className="row">
          <div className="col">
            <BusSeatSelection/> 
          </div>
          <div className="col">
            
          </div>
        </div> */}

{/* <Router>
      <Routes>
        <Route path="/" element={<SearchForm />} />
        <Route path="/search-results" element={<SearchResults />} />
      </Routes>
    </Router>
 */}



        {/* <div className="row">
          <div className="col">
            <SearchBus/> 
          </div>
          <div className="col">
            
          </div>
        </div>  */}

        {/* <div className="row">
          <div className="col">
            <UpdateUser/> 
          </div>
          <div className="col">
            
          </div>
        </div>  */}
 <BrowserRouter>
         <Menu/>
        <Routes>
        

          <Route path='/' element={<RegisterUser/>}/>
          <Route path="Buses" element={<BusListing buses={buses}/>}/>
          
          <Route path="Seat" element={<seat/>}/>
          <Route path="BusSeatSelection" element={<BusSeatSelection/>}/>
          <Route path="UpdateUser" element={<UpdateUser/>}/>
          <Route path="SearchBus" element={<SearchBus/>}/>
          <Route path="RedBus" element={<RedBus/>}/>
          <Route path="LoginUser" element={<UserLogin/>}/>
          <Route path="RegisterUser" element={<RegisterUser/>}/>
        </Routes>
      </BrowserRouter> 





        {/*--------add and view busses----------- <div className="row">
          <div className="col">
            <GetBus/> 
          </div>
          <div className="col">
            <AddBus/>
          </div>
        </div> ------------------------------*/}















      {/* <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header> */}
    </div>
  );
}

export default App;
