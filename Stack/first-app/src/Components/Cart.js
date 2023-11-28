import { useState } from "react";

function Cart(props){
    
    return(
        <div>
          {props.cartItems.length==0?<div>No items is cart yet</div>:
           <div>
            <h1>Your cart</h1> 
            {props.cartItems.map((item)=>
               <li>{item}</li>
            )}
             </div>} 
        </div>
    )
}


export default Cart;