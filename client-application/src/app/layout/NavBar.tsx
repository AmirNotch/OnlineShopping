import React, { useState } from "react";
import { NavLink } from "react-router-dom";
import { Button, Container, Menu } from "semantic-ui-react";
import { Product } from "../models/product";

interface Props {
    product: Product[]
    setProducts: (product: Product[]) => void;
}


export default function NavBar({product, setProducts}: Props) {

    return(
        <Menu inverted top='top'>
            <Container>
                <Menu.Item as={NavLink} to='/' header>
                    <img src="/assets/Logo_of_Kaspi_bank.png" alt="logo" style={{marginRight: '10px'}}/>
                    Kaspi Products
                </Menu.Item>
                  <Menu.Item as={NavLink} to='/manager' name='ManagerPage'/>
                <Menu.Item>
                    <Button onClick={() => {
                      setProducts([...product])
                    }
                    }  positive content='Показать'/>    
                </Menu.Item>    
            </Container>
        </Menu>
    )
}