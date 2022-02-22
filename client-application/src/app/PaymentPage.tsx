import React, { ChangeEvent, useState } from "react";
import { NavLink } from "react-router-dom";
import { Button, Container, Form, Header, Segment } from "semantic-ui-react";
import agent from "./agent";
import { Product } from "./models/product";




var products: Product[] = []
var productfirst: string

// var initialState = Product ?? {

// }




export default function PaymentPage() {
    var storedNames = JSON.parse(localStorage.products);
// const [productAddress, setProductAddress] = useState(productfirst)
// const [productCard, setProductCard] = useState(products)

function handlePostLogs(product: Product[]) {

    for(var i = 0; i < product.length; i++) {
      product[i].address = address
      product[i].cardNumber = CardNumber
      }

    agent.Products.create(product).then(() => {
        localStorage.removeItem("products")
    })
  }

function adding () {
    handlePostLogs(storedNames)
}

var address: string
var CardNumber: string

function handleInputChange(event: ChangeEvent<HTMLInputElement> ) {
    const { name, value } = event.target;
    address = value
    // console.log(name)
    //console.log(value)
}

function handleInputChange1(event: ChangeEvent<HTMLInputElement>) {
    const {name, value} = event.target;
    CardNumber = value
    // setProductCard({...productCard, [name]: value})
}

    return(
        <Segment>
            <Form onSubmit={adding} >
                <Form.Input placeholder = 'Address' onChange={handleInputChange}/>
                <Form.Input placeholder = 'CardNumber' onChange={handleInputChange1}/>
                <Button positive type = 'submit' content = 'Подтвердить'/>
            </Form>
        </Segment>
    )
}