import { SEARCH_PRODUCTS_USERS_ACTION } from './actions';

const getProductsUsersAction = (products) => ({ type: SEARCH_PRODUCTS_USERS_ACTION, data: products })

export const getProductsUsers = (/*kryteria*/) => dispatch => {
    // request response TODO
    // data mocking for now WIKTOR
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

    dispatch(getProductsUsersAction(payload.products));
}

