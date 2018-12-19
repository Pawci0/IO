import * as React from "react";
// import * as a from "axios";
import * as qs from "query-string";
import {bindActionCreators} from "redux";
import connect from "react-redux/es/connect/connect";
import {editProduct, getProduct} from "../../../actions/editProductActions";

// const axios = a.default;

class EditProductViewContainer extends React.Component {

    constructor(props) {
        super(props);
        this.state = {};
    }

    render() {
        const id = qs.parse(this.props.location.search, {ignoreQueryPrefix: true}).id;
        return (
            <div>
                <p>{`id: ${id}`}</p>
                {this.props.product &&
                <div>
                    <form onSubmit={this.submit}>
                        <label>
                            Name:
                            <input type="text" name="name"
                                   defaultValue={this.props.product.Name}
                                   onChange={this.handleNameChange}/>
                        </label>
                        <p/>
                        <label>
                            Description:
                            <input type="text" name="name"
                                   defaultValue={this.props.product.Description}
                                   onChange={this.handleDescriptionChange}/>
                        </label>
                        <p/>
                        <input type="submit" value="Submit"/>
                    </form>
                </div>
                }
            </div>
        );
    }

    static getDerivedStateFromProps(nextProps, prevState) {
        const {product} = nextProps;
        if (product.Name && !prevState.product) {
            let s = {...prevState};
            s.product = product;
            return s;
        }
    }

    handleNameChange = (e) => {
        let s = this.state.product;
        s.Name = e.target.value;
        this.setState({product: s});
    };

    handleDescriptionChange = (e) => {
        let s = this.state.product;
        s.Description = e.target.value;
        this.setState({product: s});
    };

    submit = (e) => {
        e.preventDefault();
        alert(this.state.product.Name + " " + this.state.product.Description);
        // alert(this.props.product.Name + " " + this.props.product.Description);
    };

    componentDidMount() {
        const id = qs.parse(this.props.location.search, {ignoreQueryPrefix: true}).id;
        this.props.getProduct(id);
    }
}

const mapStateToProps = (state) => ({
    product: state.editProduct.product
});

const mapDispatchToProps = dispatch => bindActionCreators(
    {
        getProduct,
        editProduct
    },
    dispatch,
);

const editProductViewContainer = connect(mapStateToProps, mapDispatchToProps)(EditProductViewContainer);
export {editProductViewContainer as EditProductViewContainer};