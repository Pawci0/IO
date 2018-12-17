import React, { Component } from 'react';
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { getProducts } from '../../../actions/SearchPageActions'

class SearchContainer extends Component {
  constructor(props) {
    super(props);
    console.log('asd asd');
  }
  h = () => {console.log('dsadgg');}

  render() {

    return (
      <div>
        Search my ass
        <div>{this.props.test}</div>
        <p onClick={getProducts()}>click me</p>
      </div>
    );
  }
}

SearchContainer.propTypes = {
  test: PropTypes.string,
}

const mapStateToProps = (state) => ({
  test: state.search.test,
})

export default connect(
  mapStateToProps,
  { getProducts },
)(SearchContainer)
