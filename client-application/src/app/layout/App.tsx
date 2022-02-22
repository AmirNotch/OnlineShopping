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

function App() {
  const [products, setProducts] = useState<Product[]>([]);
  const [BoxResult, setBoxResult] = useState<Product[]>([]);

  //var BoxResult: Product[] = [];
  
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

  // BoxResult.push(...products)
  return (
    <>
        {/* <Menu inverted top='top'>
            <Container>
                <Menu.Item as={NavLink} to='/' header>
                    <img src="/assets/Logo_of_Kaspi_bank.png" alt="logo" style={{marginRight: '10px'}}/>
                    Kaspi Products
                </Menu.Item>
                  <Menu.Item as={NavLink} to='/manager' name='ManagerPage'/>
                <Menu.Item>
                    <Button onClick={() => {
                      setProducts([...products])
                    }
                    }  positive content='Показать'/>    
                </Menu.Item>    
            </Container>
        </Menu> */}
        <NavBar product={products} setProducts={setProducts}/>
        <Container style={{marginTop: '7em'}}>
          <Routes>
            <Route path='/' element={<ProductDashboard products={products}/>} />
            <Route path='/manager' element={<ManagerPage/>} />
            <Route path='/paymentPage' element={<PaymentPage/>} />
          </Routes>
                 
        </Container>
    </>
  );
}

export default App;
