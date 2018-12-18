import React, {Component} from 'react';
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { getProductsUsers } from '../../../actions/SearchPageActions'
import { bindActionCreators } from 'redux'
import ProductIcon from '../ProductIcon';

class SearchContainer extends Component {
  render() {

    return (
      <div>
        <button onClick={this.props.getProductsUsers}>szukaj</button>
        <div>
          {this.props.products.map((value) => (
            <ProductIcon link={'/product'} id={value.Product_id} name = {value.Name} />
          ))}
        </div>
        
      </div>
    );
  }
}

SearchContainer.propTypes = {
    products: PropTypes.array,
};

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
