import * as endpoints from './AppEndpoints';
import { auth } from "./auth";
const Querystring = require('query-string');

const axios = require('axios')

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
  
    axios.post(`${endpoints.url}:53026/token`, Querystring.stringify(data))   
     .then(response => {
        console.log(response.data);
        myauth = response.data.access_token;
        console.log('userresponse ' + response.data.access_token); 
      })   
     .catch((error) => {
        console.log('error ' + error);   
     });
  
  
  
  const AuthStr = 'Bearer '.concat(myauth); 
  axios.defaults.headers.common['Authorization'] = AuthStr;
}

export const searchProducts = (phrase, sortType, pageIndex, pageSize) => {
    axios.get(`${endpoints.search}/${phrase}/${sortType}/${pageIndex}/${pageSize}`) //done
  .then(function (response) {
    // todo response to js object
    return response;
  })
  .catch(function (error) {
    return null;
  });
}

export const getRecommended = (userId, amount) => {
    axios.get(`${endpoints.recommended}/${userId}/${amount}`) //done
  .then(function (response) {
    // todo response to js object
    return response;
  })
  .catch(function (error) {
    return null;
  });
}

export const getProduct = async (productId) => {
    let product = {
        productId: null,
        name: null,
        categoryId: null,
        userId: null,
        description: null
    };
    
    await axios.get(`${endpoints.product}/${productId}`)
    //await axios.get("http://localhost:53026/api/Product/5")
  .then(function (response) {
    product = response.json();
  })
  return product;
}

export const updateRating = (productId, score) => {
    axios.get(endpoints.updateRating)
  .then(function (response) {
    // todo response to js object
    return response;
  })
  .catch(function (error) {
    return null;
  });
}