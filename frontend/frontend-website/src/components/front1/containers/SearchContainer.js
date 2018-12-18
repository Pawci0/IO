import React, { Component } from 'react';
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { getProductsUsers } from '../../../actions/SearchPageActions'
import { bindActionCreators } from 'redux'

class SearchContainer extends Component {
  constructor(props) {
    super(props);
  }

  render() {

    return (
      <div>
        Search my ass
        {this.props.products[0] &&
        <div>{this.props.products[0].id}</div>
        }
        <button onClick={this.props.getProductsUsers}>click me</button>
      </div>
    );
  }
}

SearchContainer.propTypes = {
  products: PropTypes.array,
}

const mapStateToProps = (state) => ({
  products: state.search.products,
})

const mapDispatchToProps = dispatch => bindActionCreators(
  {
    getProductsUsers
  },
  dispatch,
)

export default connect(
  mapStateToProps,
  mapDispatchToProps,
)(SearchContainer)
