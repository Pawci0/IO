import React, { Component } from 'react';
import PropTypes from 'prop-types'

class ProductIcon extends Component {

  render() {

    return (
      <div>
        <a href={`/product?id=${this.props.id}`}>{this.props.name}</a>
      </div>
    );
  }
}

ProductIcon.propTypes = {
  id: PropTypes.number,
  name: PropTypes.string,
}

export default ProductIcon