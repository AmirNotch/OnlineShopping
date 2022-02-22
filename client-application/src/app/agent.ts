import axios, { AxiosResponse } from "axios";
import { Product, ManagerLogs } from "./models/product";

axios.defaults.baseURL = 'http://localhost:5002/';

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    getLogs: (url: string) => axios.get(url).then(responseBody),
    postDone: (url: string, body: {}) => axios.post(url).then(responseBody),
}

const Products = {
    list: () => requests.get('/Product'),
    create: (product: Product[]) => axios.post<void>('/Product', product),
    listLogs: () => requests.get('/Manager'),
    createLogs: (log: ManagerLogs) => axios.post<void>('/Manager', log)
} 

const agent = {
    Products
}

export default agent;