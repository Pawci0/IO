import * as endpoints from './AppEndpoints';
import { auth } from "./auth";
const Querystring = require('query-string');

let axios = require('axios');

const reloadAxios = async () => {
  const myaxios = require('axios');
  const a = await generateAuthToken();
  myaxios.defaults.headers.common['Authorization'] = a;
  return myaxios;
}

export const generateAuthToken = async () => {
    const data = {
        grant_type: 'password',
        client_id: '1',
        client_secret: 'asd',
        scope: 'asd',
        username: '1234',
        password: 'adminnimda'
      };
  
      let myauth;
  
    await axios.post(`${endpoints.url}:53026/token`, Querystring.stringify(data))   
     .then(response => {
        //console.log(response.data);
        myauth = response.data.access_token;
        //console.log('userresponse ' + response.data.access_token); 
      })   
     .catch((error) => {
        console.log('error ' + error);   
     });
  
  
  
  const AuthStr = 'Bearer '.concat(myauth); 
  return AuthStr;
}


export const searchProducts = async (phrase, sortType, pageIndex, pageSize) => {
  axios = await reloadAxios();
  return axios.get(`${endpoints.search}/${phrase}/${sortType}/${pageIndex}/${pageSize}`) //done
}

export const getRecommended = async (userId, amount) => {
  axios = await reloadAxios();
  return axios.get(`${endpoints.recommended}/${userId}/${amount}`);
}

export const getProduct = async (productId) => {
  axios = await reloadAxios();
  return axios.get(`${endpoints.product}/${productId}`);
}

export const getProductNoReload = async (productId) => {

  return axios.get(`${endpoints.product}/${productId}`);
}

export const updateProductCategory = async (categoryId) => {
  //axios = await reloadAxios();
  return axios.get(`${endpoints.category}/${categoryId}`);
}

export const updateProductRating = async (productId) => {
  //axios = await reloadAxios();
  return axios.get(`${endpoints.rating}/${productId}`);
  //return {data: {rating: 3}};
}

export const updateRating = async (userId, productId, score) => {
  //axios = await reloadAxios();
  const data = {
    productId: productId,
    userId: userId,
    value: score,
    comment: ""
  };
  return axios.post(`${endpoints.updateRating}`, data);
}