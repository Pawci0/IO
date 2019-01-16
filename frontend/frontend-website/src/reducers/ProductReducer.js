import { GET_PRODUCT_ACTION } from '../actions/actions';
import { GET_RECOMMENDED_ACTION } from '../actions/actions';
import { RATE_PRODUCT_ACTION } from '../actions/actions';

const initialState = {
    product: {},
    recommendedProducts: [],
    rateIsSuccess: {},
}

const productView = (state = initialState, action) => {
    switch (action.type) {
      case GET_PRODUCT_ACTION:
        return {
          ...state,
          product: action.data,
        }
      case GET_RECOMMENDED_ACTION:
        return {
          ...state,
          recommendedProducts: action.data,
        }
      case RATE_PRODUCT_ACTION:
        return {
          ...state,
          rateIsSuccess: action.data,
        }
      default:
        return state
    }
  }
  
  export default productView