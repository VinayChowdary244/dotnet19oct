function ProductListing(props){


    return(
        <div>
            {props.products.map((product)=>
                    <div key={product.id} className="alert alert-primary">
                        Product Name : {product.name}
                        <br/>
                        Product Price : {product.price}
                        <br/>
                        Product Quantity: {product.quantity}
                        <br/>
                        <button className="btn btn-primary" onClick={()=>{props.onAddClick(product.id)}}>Add To Cart</button>
                </div>)}
        </div>
    )
}

export default ProductListing;