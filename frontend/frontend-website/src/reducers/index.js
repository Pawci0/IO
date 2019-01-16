import {combineReducers} from 'redux'
import ProductReducer from './ProductReducer';
import SearchReducer, * as fromSearch from './SearchReducer';
import {authenticationReducer} from "./front2/authenticationReducer"
import {registrationReducer} from "./front2/registrationReducer";
import editProductViewReducer from "./front2/editProductReducer";

export const getMyTest = (state) => fromSearch.getTest(state);

export default combineReducers({
    product: ProductReducer,
    search: SearchReducer,
    authentication: authenticationReducer,
    registration: registrationReducer,
    editProduct: editProductViewReducer
})