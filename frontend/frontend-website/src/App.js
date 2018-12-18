import React from 'react';
import './App.css';
import {BrowserRouter as Router, Route} from "react-router-dom";
import SearchContainer from './components/front1/containers/SearchContainer';
import ProductViewContainer from './components/front1/containers/ProductViewContainer';
import {Provider} from 'react-redux';
import PropTypes from 'prop-types';
import {LoginPageContainer} from "./components/front2/containers/LoginPageContainer";
import {RegisterViewContainer} from "./components/front2/containers/RegisterViewContainer";
import {EditProductViewContainer} from "./components/front2/containers/EditProductViewContainer";

const App = ({store}) => (
    <Provider store={store}>
        <Router>
            <div>
                <Route exact path="/login" component={LoginPageContainer}/>
                <Route path="/search" component={SearchContainer}/>
                <Route path="/product" component={ProductViewContainer}/>
                <Route path="/register" component={RegisterViewContainer}/>
                <Route path="/edit_product/:id" component={EditProductViewContainer}/>
            </div>
        </Router>
    </Provider>
);

App.propTypes = {
    store: PropTypes.object.isRequired
}

export default App;
