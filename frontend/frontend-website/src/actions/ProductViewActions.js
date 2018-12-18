import { GET_PRODUCT_ACTION } from './actions';
import { GET_RECOMMENDED_ACTION } from './actions';
import { RATE_PRODUCT_ACTION } from './actions';

const getProductAction = (product) => ({ type: GET_PRODUCT_ACTION, data: product })
const getRecommendedProductsAction = (userId) => ({ type: GET_RECOMMENDED_ACTION, data: products })
const RateProductAction = (isSuccess) => ({ type: RATE_PRODUCT_ACTION, data: { isSuccess } })

export const getProduct = (id) => dispatch => {
    // request response TODO
    // data mocking for now WIKTOR

    const payload = {
        product:
            {
                id: '1',
                name: 'wiertarka',
            }
    };

    dispatch(getProductAction(payload.product));
}

export const getRecommendedProducts = (userId) => dispatch => {
    // request response TODO
    // data mocking for now WIKTOR

    const payload = {
        products: [
            {
                id: '1',
                name: 'wiertarka',
            },
        ]
    };

    dispatch(getRecommendedProductsAction(payload.product));
}

export const rateProduct = (userId) => dispatch => {
    // request response TODO
    // data mocking for now


    const isSuccess = true;

    dispatch(RateProductAction(isSuccess));
}

