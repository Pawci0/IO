import {EDIT_PRODUCT} from "./actions";
import {UPDATE_PRODUCT} from "./actions";
import {ADD_PRODUCT} from "./actions";
import * as appRequests from "../utils/AppRequests.js"


const getProductAction = (product) => ({type: EDIT_PRODUCT, data: product});
const updateProductAction = () => ({type: UPDATE_PRODUCT});
const addProductAction = () => ({type: ADD_PRODUCT});


export const getProduct = (id) => dispatch => {
    appRequests.getProduct(id).then((product) => {
        dispatch(getProductAction(product))
    });
};

export const editProduct = (product, id) => dispatch => {
    product.categoryId = 1;
    product.productId = id;
    product.userId = userId;
    appRequests.editProduct(product).then(() => {
        dispatch(updateProductAction());
    })
};

