import React, { Component } from 'react';
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { getProductsUsers } from '../../../actions/SearchPageActions'
import { bindActionCreators } from 'redux'

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
        <button onClick={this.props.getProductsUsers}>click me</button>
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
