const initialState = {
    test: 'tescik sracz dziala',
}

export const getTest = (state) => state.test;

const SearchReducer = (state = initialState, action) => {
    switch (action.type) {
      case 'INIT':
        return initialState
      default:
        return state
    }
  }
  
  export default SearchReducer