import { SEARCH_PRODUCTS_USERS_ACTION } from './actions';
import * as appRequests from '../utils/AppRequests';

const getProductsUsersAction = (products) => ({ type: SEARCH_PRODUCTS_USERS_ACTION, data: products })

export const getProductsUsers = (phrase, sortType, pageIndex, pageSize) => dispatch => {
    // request response TODO
    // data mocking for now WIKTOR
    
    appRequests.searchProducts(phrase, sortType, pageIndex, pageSize).then(function (response) {
        const res = response.data;
        
        console.log('searchProducts otrzymany:');
        console.log(res);

        const rec = [];
        res.map((val) => {
            rec.push({
                Product_id: val.product_Id,
                Name: val.name,
            });
        });

        console.log('searchProducts po obrobce otrzymany:');
        console.log(rec);

        dispatch(getProductsUsersAction(rec));

    }).catch((error) => {
        console.log('error ' + error);   
    });




    
}

