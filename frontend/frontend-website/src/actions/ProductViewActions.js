import { GET_PRODUCT } from './actions';

const getProduct = (products) => ({ type: SEARCH_GET_PRODUCTS, data: products })

export const getProducts = (/*kryteria*/) => dispatch => {
    // request response TODO
    // data mocking for now
    console.log('action dispatched');
    const payload = {
        products: [
            {
                id: '1',
                name: 'wiertarka',
            },
            {
                id: '2',
                name: 'suszarka',
            }
        ]
    };

    dispatch(searchGetProductsAction(payload.products));
}

