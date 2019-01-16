import React, { Component } from 'react';
import { connect } from 'react-redux'

class Pasek extends Component {

  constructor(props) {
    super(props);
  }

  render() {
    console.log("siemaneczko userId: ");
    console.log(this.props.userId);
    return (
      <div>
          {
          !this.props.userId &&
          <div>
          <span>
            <a href="/login">zaloguj</a>
          </span>
          <span> lub </span>
          <span>
            <a href="/register">zarejestruj</a>
          </span>
          </div>
          }
          {
          this.props.userId &&
          <div>
          <span>
            <a href="/search">wyloguj </a>
          </span>
          <span>
            <a href={`/add_product?userid=${this.props.userId}`}>dodaj produkt </a>
          </span>
          </div>
          }
          <hr></hr>
          <br></br>
      </div>
    );
  }
};
  
  export default Pasek
  

