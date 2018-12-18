import React, { Component } from 'react';
import { getProduct, getRecommendedProducts } from  '../../../actions/ProductViewActions'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import * as qs from 'query-string'
import ProductIcon from '../ProductIcon'

class ProductViewContainer extends Component {

  componentDidMount() {
    const id = qs.parse(this.props.location.search, { ignoreQueryPrefix: true }).id;
    this.props.getProduct(id);
    this.props.getRecommendedProducts(0); // TODO userId
  }

  render() {
    const id = qs.parse(this.props.location.search, { ignoreQueryPrefix: true }).id;
    return (
      <div>
        <p>{`id: ${id}`}</p>
        {this.props.product &&
        <div>
          <p>{`nazwa: ${this.props.product.Name}`}</p>
          <p>{`opis: ${this.props.product.Description}`}</p>
        </div>
        }
        <p>rekomendowane: </p>
        <div>
          {this.props.recommendedProducts &&
            <div>
              {this.props.recommendedProducts.map((value) => (
                <ProductIcon id={value.Product_id} name = {value.Name} />
              ))}
            </div>
          }
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state) => ({
  product: state.product.product,
  recommendedProducts: state.product.recommendedProducts,
})

const mapDispatchToProps = dispatch => bindActionCreators(
  {
    getProduct,
    getRecommendedProducts
  },
  dispatch,
)

export default connect(
  mapStateToProps,
  mapDispatchToProps,
)(ProductViewContainer)
