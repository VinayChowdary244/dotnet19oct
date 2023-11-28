
function DisplayProduct(props){

    return(
        <div>
            Product Name : {props.product.name}
            <br/>
            Product Price : {props.product.price}
            <br/>
            Product Quantity: {props.product.quantity}
            <br/>
            <button className="btn btn-primary" onClick={()=>{props.onAddClick(props.product.id)}}>Add To Cart</button>
        </div>
    );
    
    }
    
    export default DisplayProduct;
    