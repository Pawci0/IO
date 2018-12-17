const initialState = {
    test: 'tescik dziala',
}

const productView = (state = initialState, action) => {
    switch (action.type) {
      case 'GET_PRODUCT':
        return [
          ...state,
            // state.productId = action.data.productId ... TODO
        ]
      default:
        return state
    }
  }
  
  export default productView