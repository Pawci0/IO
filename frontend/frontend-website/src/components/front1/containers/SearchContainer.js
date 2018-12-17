import React, { Component } from 'react';
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { getMyTest } from '../../../reducers'
import { init } from '../../../actions/SearchPageActions'

class SearchContainer extends Component {
  constructor(props) {
    super(props);
    init();
  }

  render() {
    return (
      <div>
        Search my ass
        <div>{this.props.test}</div>
      </div>
    );
  }
}

SearchContainer.propTypes = {
  test: PropTypes.string,
}

const mapStateToProps = (state) => ({
  test: getMyTest(state),
})

export default connect(
  mapStateToProps,
  { init },
)(SearchContainer)
