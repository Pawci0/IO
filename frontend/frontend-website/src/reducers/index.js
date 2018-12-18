import {combineReducers} from 'redux'
import ProductReducer from './ProductReducer';
import SearchReducer, * as fromSearch from './SearchReducer';
import {authenticationReducer} from "./front2/authenticationReducer"

export const getMyTest = (state) => fromSearch.getTest(state);

export default combineReducers({
    product: ProductReducer,
    search: SearchReducer,
    authentication: authenticationReducer
})