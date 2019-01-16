import {GET_PRODUCT_ACTION} from './actions';
import {GET_RECOMMENDED_ACTION} from './actions';
import {RATE_PRODUCT_ACTION} from './actions';
import * as appRequests from '../utils/AppRequests';

const getProductAction = (product) => ({type: GET_PRODUCT_ACTION, data: product})
const getRecommendedProductsAction = (products) => ({type: GET_RECOMMENDED_ACTION, data: products})
const RateProductAction = (isSuccess) => ({type: RATE_PRODUCT_ACTION, data: {isSuccess}})

export const getProduct = (id) => dispatch => {
    console.log('getProduct siema');
    appRequests.getProduct(id).then(function (response) {
        const res = response.data;
        const newProduct = {
            Product_id: res.productId,
            Name: res.name,
            Description: res.description,
            Score: res.productId,
            Category_Name: res.categoryId,
            User_Username: res.userId,
        };
        console.log('getProduct otrzymany:');
        console.log(newProduct);
        dispatch(getProductAction(newProduct));

        appRequests.updateProductCategory(newProduct.Category_Name).then(function (response) {
            const res = response.data;
            const newProduct2 = {
                Product_id: newProduct.Product_id,
                Name: newProduct.Name,
                Description: newProduct.Description,
                Score: newProduct.productId,
                Category_Name: res.name,
                User_Username: newProduct.User_Username,
            };
            console.log('updateProductCategory otrzymany:');
            console.log(newProduct2);
            //dispatch(getProductAction(newProduct2));

            appRequests.updateProductUserName(newProduct2.User_Username).then(function (response) {
                const res = response.data;
                const newProduct3 = {
                    Product_id: newProduct2.Product_id,
                    Name: newProduct2.Name,
                    Description: newProduct2.Description,
                    Score: newProduct2.Score,
                    Category_Name: newProduct2.Category_Name,
                    User_Username: res.username,
                };
                console.log('updateProductUserName otrzymany:');
                console.log(newProduct3);
                //dispatch(getProductAction(newProduct3));


                appRequests.updateProductRating(newProduct3.Product_id).then(function (response) {
                    const res = response.data;
                    const newProduct4 = {
                        Product_id: newProduct3.Product_id,
                        Name: newProduct3.Name,
                        Description: newProduct3.Description,
                        Score: res,
                        Category_Name: newProduct3.Category_Name,
                        User_Username: newProduct3.User_Username,
                    };
                    console.log('updateProductScore otrzymany:');
                    console.log(newProduct4);
                    dispatch(getProductAction(newProduct4));
    
    
    
    
    
    
                }).catch((error) => {
                    console.log('error ' + error);
                });


            }).catch((error) => {
                console.log('error ' + error);
            });





            


        }).catch((error) => {
            console.log('error ' + error);
        });


    }).catch((error) => {
        console.log('error ' + error);
    });
}

export const getRecommendedProducts = (userId) => dispatch => {
    if (!userId) {
         userId = 1;
         console.log("nie ma usera!!");
    }
    appRequests.getRecommended(userId, 3).then(function (response) {
        const res = response.data;

        console.log('getRecommendedProducts otrzymany:');
        console.log(res);

        res.map((val) => {

            appRequests.updateProductCategory(val.categoryId).then(function (response) {
                const res = response.data;
                val.categoryId = res.name;

                appRequests.updateProductRating(val.productId).then(function (response) {
                    const res = response.data;
                    val.rating = res.rating;

                }).catch((error) => {
                    console.log('error ' + error);
                });

            }).catch((error) => {
                console.log('error ' + error);
            });


        });

        console.log('getRecommendedProducts po obrobce otrzymany:');
        console.log(res);
        const rec = [];
        res.map((val) => {
            rec.push({
                Product_id: val.productId,
                Name: val.name,
                Description: val.description,
                Score: val.productId,
                Category_Name: val.categoryId,
                User_Username: val.userId,
            });
        });
        dispatch(getRecommendedProductsAction(rec));

    }).catch((error) => {
        console.log('error ' + error);
    });


}

export const rateProduct = (userId, productId, score) => dispatch => {

    appRequests.updateRating(userId, productId, score).then(function (response) {
        const res = response.data;
        console.log('response z Rate');
        console.log(res);
        dispatch(RateProductAction(true));
    }).catch((error) => {
        console.log('error ' + error);
        dispatch(RateProductAction(false));
    });
}

export const addProduct = (product) => dispatch => {
    // request response TODO
    alert(JSON.stringify(product));
};