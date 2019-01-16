import {EDIT_PRODUCT} from "./actions";
import {UPDATE_PRODUCT} from "./actions";
import {ADD_PRODUCT} from "./actions";

const getProductAction = (product) => ({type: EDIT_PRODUCT, data: product});
const updateProductAction = () => ({type: UPDATE_PRODUCT});
const addProductAction = () => ({type: ADD_PRODUCT});

export const getProduct = (id) => dispatch => {
    // request response TODO
    // data mocking for now WIKTOR
    const payload = {
        product:
            {
                Product_id: '3',
                Name: 'Koszulka',
                Category_Name: 'odzież',
                User_Username: 'LeszekW',
                Description: 'Wiara w konstytucję to najlepsze co możecie dla siebie zrobić',
                Score: '10'
            }
    };

    dispatch(getProductAction(payload.product));
};

export const editProduct = (product) => dispatch => {
    // TODO implement request

    dispatch(updateProductAction());
};

export const addProduct = (product) => dispatch => {
    // TODO implement request

    dispatch(updateProductAction());
}