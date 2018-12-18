import React from 'react';
import './App.css';
import {BrowserRouter as Router, Route} from "react-router-dom";
import SearchContainer from './components/front1/containers/SearchContainer';
import ProductViewContainer from './components/front1/containers/ProductViewContainer';
import {Provider} from 'react-redux';
import PropTypes from 'prop-types';
import {HomePageContainer} from "./components/front2/containers/HomePageContainer";

const App = ({store}) => (
    <Provider store={store}>
        <Router>
            <div>
                <Route exact path="/" component={HomePageContainer}/>
                <Route path="/search" component={SearchContainer}/>
                <Route path="/product" component={ProductViewContainer}/>
            </div>
        </Router>
    </Provider>
);

App.propTypes = {
    store: PropTypes.object.isRequired
}

export default App;
