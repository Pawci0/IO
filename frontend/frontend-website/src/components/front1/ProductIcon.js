import React, { Component } from 'react';
import PropTypes from 'prop-types'

class ProductIcon extends Component {

  render() {

    return (
      <div>
        <a href={`${this.props.link}?id=${this.props.id}`}>{this.props.name}</a>
      </div>
    );
  }
}

ProductIcon.propTypes = {
  id: PropTypes.number,
  name: PropTypes.string,
  link: PropTypes.string.isRequired,
}

export default ProductIcon