import React from "react";
import { NavLink } from "react-router-dom";
import { Card, Segment, Image, Button, List } from "semantic-ui-react";
import App from "../../../app/layout/App";
import { Product, ProductInBox } from "../../../app/models/product";

interface Props {
    products: Product[];
    addedElement: (product: Product) => void;
    minusElement: (product: Product) => void;

}


export default function ProductList({ products, 
    addedElement, minusElement }: Props){
    return(
        <Segment>
            <Card.Group itemsPerRow={3} stackable>
                {products.map(product => (
                    <Card key={product.id}>
                        <Card.Content>
                        <Image
                        floated='right'
                        size='big'
                        src={`/assets/categoryImages/${product.photo}.jpg` || `/assets/categoryImages/${product.photo}.jpeg`}
                        />
                        <Card.Header as='a'>{product.title}</Card.Header>
                        <Card.Description>
                        {product.cost + ' Тенге'}
                        </Card.Description>
                        </Card.Content>
                        <Card.Content extra>
                        <div className='ui two buttons'>
                        {/* <Button onClick={() => addedElement({id: product.id, title: product.title, photo: product.photo, cost: product.cost})} positive content ='Create Activity' > */}
                        <Button onClick={() => addedElement(product)} positive content ='Create Activity' >
                        +
                        </Button>
                        <Button onClick={() => minusElement(product)} negative content ='Create Activity'>
                        -
                        </Button>
                        </div>
                        </Card.Content>
                    </Card>
                ))}
            <Card>
                
            </Card>
            </Card.Group>
        </Segment>
    )
}