import { SEARCH_PRODUCTS_USERS_ACTION } from '../actions/actions'

const initialState = {
    products: [],
}

export const getTest = (state) => state.test;

const SearchReducer = (state = initialState, action) => {

    switch (action.type) {
        case SEARCH_PRODUCTS_USERS_ACTION:
            return {
            ...state,
            products: action.data,
            }
        default:
            return state
        }
}
  
  export default SearchReducer