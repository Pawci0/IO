import * as React from "react";
import * as a from "axios";
import * as qs from "query-string";
import {bindActionCreators} from "redux";
import {getProductsUsers} from "../../../actions/SearchPageActions";
import connect from "react-redux/es/connect/connect";

const axios = a.default;

class EditProductViewContainer extends React.Component {

    constructor(props) {
        super(props);
        this.state = {};
        this.editProduct = this.editProduct.bind(this);
    }

    async componentDidMount() {
        const id = qs.parse(this.props.location.search, {ignoreQueryPrefix: true}).id;
        const product = await this.getProductData(id);
        this.setState((state, props) => product,
            () => {
                console.log("Edit product view container: componentDidMount()")
            });
    }

    async getProductData(productId) {
        return {
            Product_id: productId,
            Name: 'Koszulka',
            Category_Name: 'odzież',
            User_Username: 'Abba',
            Description: 'MammaMia',
            Score: '10'
        }
        // return await axios.get("bekędowcy geje");
    }
}

const mapStateToProps = (state) => ({
    products: state.search.products,
});

const mapDispatchToProps = dispatch => bindActionCreators(
    {
        getProductsUsers
    },
    dispatch,
);

export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(SearchContainer)