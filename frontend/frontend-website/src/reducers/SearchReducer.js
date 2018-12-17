import { SEARCH_GET_PRODUCTS } from '../actions/actions'

const initialState = {
    test: 'tescik sracz dziala',
    products: [],
}

export const getTest = (state) => state.test;

const SearchReducer = (state = initialState, action) => {
    if (action.type === SEARCH_GET_PRODUCTS) {
        console.log('action received');
        return {
            ...state,
            products: action.data,
            test: 'dispatched',
          }
      }
    return state;
  }
  
  export default SearchReducer