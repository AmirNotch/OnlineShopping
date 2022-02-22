import { render } from "@testing-library/react";
import { Item, Segment, Image, Card } from "semantic-ui-react";
import { Product, ProductInBox } from "../../../app/models/product";


interface Props {
    products: Product[];
}


export default function ProductDetails({ products }: Props ){
    //TotalBox.push({id: 'dawd', title: 'dwadaw', photo: 'dwadawd', cost: 2})

    var allcost = 0;
    var count = 1;
    
    return (
        <Segment>
            <Card.Group itemsPerRow={1} stackable>
                {products.map(product => (
                    <Card key={product.id}>
                        {allcost += product.cost}
                        <Card.Content>
                        <Image
                        floated='right'
                        size='mini'
                        src={`/assets/categoryImages/${product.photo}.jpg` || `/assets/categoryImages/${product.photo}.jpeg`}
                        />
                        <Card.Header as='a'>{product.title}</Card.Header>
                        <Card.Header as='b'>{count++}</Card.Header>
                        <Card.Description>
                        {product.cost + ' Тенге'}
                        </Card.Description>
                        </Card.Content>
                    </Card>
                ))}
                
                <Item.Header as='a'>Общая стоимость:  </Item.Header>
                <Item.Meta>{allcost + ' тенге'}</Item.Meta>
        
            </Card.Group>
        </Segment>
    )
}