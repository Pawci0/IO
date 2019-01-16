import React, {Component} from 'react';
import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { getProductsUsers } from '../../../actions/SearchPageActions'
import { bindActionCreators } from 'redux'
import ProductIcon from '../ProductIcon';
import Pasek from '../../common/Pasek';
import * as qs from 'query-string'

class SearchContainer extends Component {

  constructor(props) {
    super(props);
    this.state = {page: 0, score: "ignore", phrase: "e"};
  }

  scoreChange = (event) => {
    this.setState({page: this.state.page, score: event.target.value, phrase: this.state.phrase});
    event.preventDefault()
  }

  phraseChange = (event) => {
    this.setState({page: this.state.page, score: this.state.score, phrase: event.target.value});
    event.preventDefault()
  }

  getProductsUsersBind = (event) => {
    this.props.getProductsUsers(this.state.phrase, this.state.score, this.state.page*5+1, 55);
    event.preventDefault()
  }

  next = () => {
    this.setState({page: this.state.page+1, score: this.state.score, phrase: this.state.phrase});
  }

  prev = () => {
    this.setState({page: this.state.page-1, score: this.state.score, phrase: this.state.phrase});
  }

  render() {
    const scores = ["ignore", "ascending", "descending"];
    const userId = qs.parse(this.props.location.search, { ignoreQueryPrefix: true }).userid;
    return (
      <div>
        <Pasek userId={userId} />
        <form onSubmit={this.getProductsUsersBind}>
        <label>
          <select value={this.state.score} onChange={this.scoreChange}>
            {scores.map((val) => (
              <option value={val}>{val}</option>
             ))}
          </select>
        </label>
        <input type="text" onChange={this.phraseChange} />
        <button type="submit">szukaj</button>
        </form>
        <div>
          {this.props.products.map((value) => (
            <ProductIcon userId={userId} link={'/product'} id={value.Product_id} name = {value.Name} />
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
