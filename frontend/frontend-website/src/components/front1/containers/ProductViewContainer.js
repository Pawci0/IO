import React, { Component } from 'react';
import { getProduct, getRecommendedProducts, rateProduct } from  '../../../actions/ProductViewActions'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import * as qs from 'query-string'
import ProductIcon from '../ProductIcon'

class ProductViewContainer extends Component {

  constructor(props) {
    super(props);
    this.state = {id: undefined, score: 1};
  }

  componentDidMount() {

 // TODO userId
  }

  scoreSubmit = (event) => {
    this.props.rateProduct(1, qs.parse(this.props.location.search, { ignoreQueryPrefix: true }).id, this.state.score);
    event.preventDefault()
  }
  scoreChange = (event) => {
    this.setState({id: this.state.id, score: event.target.value});
    event.preventDefault()
  }


  render() {
    const scores = [1,2,3,4,5,6,7,8,9,10];
    const id = qs.parse(this.props.location.search, { ignoreQueryPrefix: true }).id;
    const userid = qs.parse(this.props.location.search, { ignoreQueryPrefix: true }).userid;
    if (!this.state.id) {
      this.setState({id: id, score: this.state.score});
      this.props.getProduct(id);
      this.props.getRecommendedProducts(userid);
    }
    return (
      <div>
        <p>{`id: ${id}`}</p>
        {this.props.product &&
        <div>
          <h1>{`nazwa: ${this.props.product.Name}`}</h1>
          <p>{`Ocena: ${this.props.product.Score}`}</p>
          <p>{`kategoria: ${this.props.product.Category_Name}`}</p>
          <p>{`Dodane przez: ${this.props.product.User_Username}`}</p>
          <p>{`opis: ${this.props.product.Description}`}</p>
        </div>
        }
        <form onSubmit={this.scoreSubmit}>
        <label>
          <select value={this.state.score} onChange={this.scoreChange}>
            {scores.map((val) => (
              <option value={val}>{val}</option>
             ))}
          </select>
        </label>
        <input type="submit" value="oceń" />
        </form>
        <p>rekomendowane: </p>
        <div>
          {this.props.recommendedProducts &&
            <div>
              {this.props.recommendedProducts.map((value) => (
                <ProductIcon userId={userid} link={'/product'} id={value.Product_id} name = {value.Name} />
              ))}
            </div>
          }
        </div>
        <div>
          <br></br>
          <a href={`/search?userid=${userid}`}>powrót do szukajki</a>
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state) => ({
  product: state.product.product,
  recommendedProducts: state.product.recommendedProducts,
  userId: state.authentication.user.id,
})

const mapDispatchToProps = dispatch => bindActionCreators(
  {
    getProduct,
    getRecommendedProducts,
    rateProduct
  },
  dispatch,
)

export default connect(
  mapStateToProps,
  mapDispatchToProps,
)(ProductViewContainer)
