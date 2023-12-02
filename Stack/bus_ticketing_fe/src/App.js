import React, { useState } from 'react';
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
import Users from './Components/Users';
import BookingList from './Components/BookingList';





function App() {
 
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
          <Route path="Buses" element={<Buses/>}/>
          
          <Route path="Seat" element={<seat/>}/>
          <Route path="BusSeatSelection" element={<BusSeatSelection/>}/>
          <Route path="UpdateUser" element={<UpdateUser/>}/>
          <Route path="RedBus" element={<RedBus/>}/>
          <Route path="LoginUser" element={<UserLogin/>}/>
          <Route path="RegisterUser" element={<RegisterUser/>}/>
          <Route path="UserHistory" element={<UserHistory/>}/>

          <Route path="Users" element={<Users/>}/>

          <Route path="BookingList" element={<BookingList/>}/>


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
