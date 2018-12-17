import { combineReducers } from 'redux'
import ProductReducer from './ProductReducer';
import SearchReducer, * as fromSearch from './SearchReducer';

export const getMyTest = (state) => fromSearch.getTest(state);

export default combineReducers({
    product: ProductReducer,
    search: SearchReducer,
})