import {GET_PRODUCT_ACTION} from './actions';
import {GET_RECOMMENDED_ACTION} from './actions';
import {RATE_PRODUCT_ACTION} from './actions';

const getProductAction = (product) => ({type: GET_PRODUCT_ACTION, data: product})
const getRecommendedProductsAction = (products) => ({type: GET_RECOMMENDED_ACTION, data: products})
const RateProductAction = (isSuccess) => ({type: RATE_PRODUCT_ACTION, data: {isSuccess}})

export const getProduct = (id) => dispatch => {
    // request response TODO
    // data mocking for now WIKTOR


    const mock = {
        products: [
            {
                Product_id: '1',
                Name: 'wiertarka',
                Category_Name: 'narzedzia',
                User_Username: 'Starozytny_Anarchista',
                Description: 'Najlepsza kurwa wiertarka świata, każdy powinien sobie taką załatwić.',
                Score: '9'
            },
            {
                Product_id: '2',
                Name: 'Piesek Leszek',
                Category_Name: 'kreskówka',
                User_Username: 'Bracia_Fagot',
                Description: 'Polecam i pozdrawiam, wbijać na moją stronke.',
                Score: '10'
            },
            {
                Product_id: '3',
                Name: 'Koszulka',
                Category_Name: 'odzież',
                User_Username: 'LeszekW',
                Description: 'Wiara w konstytucję to najlepsze co możecie dla siebie zrobić',
                Score: '10'
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
                Product_id: '5',
                Name: 'Jerozolima',
                Category_Name: 'Miejsca',
                User_Username: 'DeusVolt',
                Description: 'Niby ziemia święta to trza dobrze ocenić ale jednak trochę za dużo tych pogan',
                Score: '6'
            },
            {
                Product_id: '6',
                Name: 'Sórówka z wczoraj',
                Category_Name: 'Jedzienie',
                User_Username: 'Głodny Juzio',
                Description: 'Zimna ale sycąca, trochę sucha ale niczego innego nie było w lodówce',
                Score: '7'
            },
            {
                Product_id: '7',
                Name: 'Drukarka',
                Category_Name: 'Sprzęt',
                User_Username: 'BGC',
                Description: 'Zabierzcie to odemnie tylko papier żre i nic nie drukuje',
                Score: '1'
            },
            {
                Product_id: '8',
                Name: 'Kapral Kabura',
                Category_Name: 'kreskówka',
                User_Username: 'Bracia_Fagot',
                Description: 'Wbijajcie na moją stronke www.carton.org',
                Score: '8'
            },
            {
                Product_id: '9',
                Name: 'Niegrzeczna Zosia',
                Category_Name: 'ludzie',
                User_Username: 'MamaZosi',
                Description: 'Zosia była niegrzeczna więc oddam za darmo. Tylko odbiór osobisty, kontakt Priv.',
                Score: '3'
            },
            {
                Product_id: '10',
                Name: '500+',
                Category_Name: 'inicjatywy',
                User_Username: 'MamaZosi',
                Description: 'Najlepsze co się temu państwu przydażyło.',
                Score: '10'
            },
        ]
    };

    const payload = {
        product: mock.products[id - 1]
    };

    dispatch(getProductAction(payload.product));
};

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

    dispatch(getRecommendedProductsAction(payload.products));
};

export const rateProduct = (userId) => dispatch => {
    // request response TODO
    // data mocking for now


    const isSuccess = true;

    dispatch(RateProductAction(isSuccess));
};

export const addProduct = (product) => dispatch => {
    // request response TODO
    alert(JSON.stringify(product));
};