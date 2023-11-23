import logo from './logo.svg';
import './App.css';

import AddProduct from './Components/AddProduct';
import Products from './Components/Products';
import BusSeatSelection from './Components/SeatSelection';
import { useState } from "react";

function App() {
  //var scores = [90,100,56,89,73];
  return (
    <div className="App">
          <div className="container text-center">
        <div className="row">
          <div className="col">
            <Products/> 
          </div>
          <div className="col">
            <AddProduct/>
          </div>
        </div>
    </div>
      {/* <div>
          {scores.map((score)=>
            <li key={score}>{score}</li>
          )}
      </div> */}
      <br/> <br/> <br/> <br/>
      <div>
        <BusSeatSelection/>
      </div>
    </div>
  );
}





export default App;
