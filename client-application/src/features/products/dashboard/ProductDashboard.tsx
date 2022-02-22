import React from "react";
import { NavLink } from "react-router-dom";
import { Button, Grid, List } from "semantic-ui-react";
import agent from "../../../app/agent";
import { Product } from "../../../app/models/product";
import ProductDetails from "../details/ProductDetails";
import ProductList from "./ProductList";

interface Props {
    products: Product[];
    // BoxResulted: Product[] | undefined;
    // selectProduct: (product: Product) => void;
    // minusProduct: (product: Product) => void;
}

function handlePostLogs(product: Product[]) {

    for(var i = 0; i < product.length; i++) {
      product[i].address = 'Саина'
      product[i].cardNumber = 9999999999999
      }

    agent.Products.create(product).then(() => {
      console.log(product)
      console.log(product)

    })
  }

var TotalBox: Product[] = []
  
function addedElement(product: Product) {
    TotalBox.push(product);
    TotalBox = TotalBox.filter(product => product.id.length > 10);
    localStorage.setItem('products', JSON.stringify(TotalBox));
    console.log(TotalBox) 
}

const findDuplicates = (arr: Product[]) => {
    let sorted_arr = arr.slice().sort(); // You can define the comparing function here. 
    // JS by default uses a crappy string compare.
    // (we use slice to clone the array so the
    // original array won't be modified)
    let results = [];
    for (let i = 0; i < sorted_arr.length - 1; i++) {
      if (sorted_arr[i + 1] == sorted_arr[i]) {
        results.push(sorted_arr[i]);
      }
    }
    return results;
  }

function minusElement(product: Product) {
  if (findDuplicates(TotalBox).length !== 0) {
      TotalBox = TotalBox.filter((value, index, self) =>
        index === self.findIndex((t) => (
        t.id === value.id && t.title === value.title
    ))
) 
} else {
    TotalBox = TotalBox.filter(item => item !== product)
}
  
    TotalBox = TotalBox.filter(product => product.id.length > 10);
    localStorage.setItem('products', JSON.stringify(TotalBox));
    console.log(TotalBox) 
}

// function handlePostLogs(product: Product[]){
//     agent.Products.create(product).then(() => {

//     })
// }



export default function ProductDashboard({products}: Props) {

    //var TotalBox: Product[] = []
    return(
        <Grid>
            <Grid.Column width='10'>
                <ProductList products={products} 
                            addedElement={addedElement} 
                            minusElement={minusElement}
                             

                />    
            </Grid.Column>
            <Grid.Column width='6'>
                {TotalBox &&
                <ProductDetails products={TotalBox}/> }
                <Button as={NavLink} to='/paymentPage' positive content ='Оплатить'/>
 
            </Grid.Column>
        </Grid>
    )
}