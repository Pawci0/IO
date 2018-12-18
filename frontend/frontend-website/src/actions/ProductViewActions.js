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
            Product_id: '3',
            Name: 'Koszulka',
            Category_Name: 'odzież',
            User_Username: 'LeszekW',
            Description: 'Wiara w konstytucję to najlepsze co możecie dla siebie zrobić',
            Score: '10'
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
                Product_id: '9',
                Name: 'Niegrzeczna Zosia',
                Category_Name: 'ludzie',
                User_Username: 'MamaZosi',
                Description: 'Zosia była niegrzeczna więc oddam za darmo. Tylko odbiór osobisty, kontakt Priv.',
                Score: '3'
            },
            {
                Product_id: '4',
                Name: 'Kuper Programisty',
                Category_Name: 'ludzie',
                User_Username: 'xXxHTMLGodxXx',
                Description: 'Nie polecam tego produktu pryszczaty, śmierdzi i czasem wychodzi brązowy płyn',
                Score: '2'
            },
            {
                Product_id: '3',
                Name: 'Koszulka',
                Category_Name: 'odzież',
                User_Username: 'LeszekW',
                Description: 'Wiara w konstytucję to najlepsze co możecie dla siebie zrobić',
                Score: '10'
            }
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

