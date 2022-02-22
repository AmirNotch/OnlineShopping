export interface Product {
    id: string;
    title: string;
    cost: number;
    photo: string;
    address: string;
    cardNumber: number;
}

export interface ProductForPost {
    id: string;
    title: string;
    cost: number;
    photo: string;
    address: string;
    cardNumber: bigint;
}

export interface ProductInBox {
    id: string;
    title: string;
    cost: number;
    photo: string;
    count: number;
    costAll: number;
}

export class ProductinBox {
    id: string = '';
    title: string = '';
    cost: number = 0;
    photo: string = '';
}