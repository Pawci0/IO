import {userConstants} from '../../constants/userConstants';

const initialState = {
    user:{
    }
}

export function authenticationReducer(state = initialState, action) {
    switch (action.type) {
        case userConstants.LOGIN_REQUEST:
            return {
                loggingIn: true,
                user: action.user
            };
        case userConstants.LOGIN_SUCCESS:
            console.log("userId w reducerze");
            console.log(window.location);
            window.location = window.location.href.replace("login", `search?userid=${action.user.id}`);
            return {
                loggedIn: true,
                user: action.user
            };
        case userConstants.LOGIN_FAILURE:
            return {};
        case userConstants.LOGOUT:
            return {};
        default:
            return initialState;
    }
}