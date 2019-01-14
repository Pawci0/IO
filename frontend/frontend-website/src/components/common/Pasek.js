import React, { Component } from 'react';
import { connect } from 'react-redux'

class Pasek extends Component {

  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div>
          {
          !this.props.user &&
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
          this.props.user &&
          <div>
          <span>
            <a href="/search">wyloguj </a>
          </span>
          </div>
          }
          <hr></hr>
          <br></br>
      </div>
    );
  }
};

const mapStateToProps = (state) => ({
    user: state.user,
  })
  
  export default connect(
    mapStateToProps,
  )(Pasek)
  

