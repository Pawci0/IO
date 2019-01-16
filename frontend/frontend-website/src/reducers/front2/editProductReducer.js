import {EDIT_PRODUCT} from "../../actions/actions";
import {UPDATE_PRODUCT} from "../../actions/actions";

const initialState = {
    product: {}
};

const editProductViewReducer = (state = initialState, action) => {
    switch (action.type) {
        case EDIT_PRODUCT:
            return {
                ...state,
                product: action.data,
            };
        case UPDATE_PRODUCT:
            return {
                ...state
            };
        default:
            return state
    }
};

export default editProductViewReducer