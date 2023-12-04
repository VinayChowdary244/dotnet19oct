                   
import { useState } from 'react';
import './App.css';
import ProductListing from './Components/ProductListing';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

import RegisterUser from './Components/RegisterUser';
import Products from './Components/Products';
import Protected from './Protected';
import Menu from './Components/Menu';
import Cart from './Components/Cart';





function App() {
  var products =[
    {
       "id":101,
       "name":"Pencil",
       "quantity":10,
       "price":5
   },
   {
       "id":102,
       "name":"Pen",
       "quantity":3,
       "price":25
   },
   {
       "id":103,
       "name":"Eraser",
       "quantity":7,
       "price":3
   }
]
var [cart,setCart]=useState([]);
var addToCart=(pid)=>{
  setCart([...cart,pid])
  console.log(cart)
  
}
// var [IsLoggedIn,setLoggedIn]=useState(false);
// var changeState=()=>{
//   var token = localStorage.getItem("token");
//   if(token){
//     setLoggedIn(true);
//   }
// }

  return (
    <div>
      <BrowserRouter>
        <Menu/>
        <Routes>
          <Route path='/' element={<RegisterUser/>}/>
          <Route path="products" element={<ProductListing products={products}/>}/>
          <Route path="shop" element={<Protected>
              <Products/>
            </Protected>
          }/>
          <Route path="cart" element={<Cart/>}/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;