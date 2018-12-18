import React, { Component } from 'react';
import PropTypes from 'prop-types'

class ProductIcon extends Component {

  render() {

    return (
      <div>
        <p href={`/product?id=${this.props.id}`}>{name}</p>
      </div>
    );
  }
}

SearchContainer.propTypes = {
  id: PropTypes.number,
  name: PropTypes.string,
}

export default ProductIcon