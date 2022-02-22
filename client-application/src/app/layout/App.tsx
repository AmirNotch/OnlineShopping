import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import axios from 'axios';
import { Button, Container, Header, List, Menu } from 'semantic-ui-react';
import { Product, ProductForPost, ProductInBox } from '../models/product';
import NavBar from './NavBar';
import ProductDashboard from '../../features/products/dashboard/ProductDashboard';
import agent from '../agent';
import { NavLink, Route, Routes } from 'react-router-dom';
import ManagerPage from '../ManagerPage';
import PaymentPage from '../PaymentPage';
import ListOfHistory from '../ListOfHistory';

function App() {
  const [products, setProducts] = useState<Product[]>([]);
  const [BoxResult, setBoxResult] = useState<Product[]>([]);
  
  var TotalBox: Product[] = []

  useEffect(() => {
    agent.Products.list().then(response => {
      setProducts(response);
    })
    console.log(products)
  }, [])

  if(localStorage.hasOwnProperty('products')){

  } else {
    localStorage.setItem('products', JSON.stringify(products));
  }
  
  
  function addedProductInGoods(product: Product){
    BoxResult.push(product)
    console.log(BoxResult) 
  }

  function minusProductInGoods(product: Product){
    BoxResult.filter(item => item.id !== product.id)
    console.log(BoxResult) 
  }

  return (
    <>
        <NavBar product={products} setProducts={setProducts}/>
        <Container style={{marginTop: '7em'}}>
          <Routes>
            <Route path='/' element={<ProductDashboard products={products}/>} />
            <Route path='/manager' element={<ManagerPage/>} />
            <Route path='/paymentPage' element={<PaymentPage/>} />
            <Route path='/listOfHistory' element={<ListOfHistory/>} />
          </Routes>
                 
        </Container>
    </>
  );
}

export default App;
