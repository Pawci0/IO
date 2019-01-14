import * as React from "react";
// import * as a from "axios";
import connect from "react-redux/es/connect/connect";
import {userActions} from "../../../actions/userActions";
import {Link} from "react-router-dom";

// const axios = a.default;

class AddProductViewContainer extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            product: {
                description: '',
                category: ''
            },
            submitted: false
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        const {name, value} = event.target;
        const {product} = this.state;
        this.setState({
            product: {
                ...product,
                [name]: value
            }
        });
    }

    handleSubmit(event) {
        event.preventDefault();

        this.setState({submitted: true});
        const {product} = this.state;
        const {dispatch} = this.props;
        if (product.description && product.category) {
            dispatch(userActions.register(product));
        }
    }

    render() {
        const {registering} = this.props;
        const {product, submitted} = this.state;
        return (
            <div className="col-md-6 col-md-offset-3">
                <h2>Register</h2>
                <form name="form" onSubmit={this.handleSubmit}>
                    <div className={'form-group' + (submitted && !product.category ? ' has-error' : '')}>
                        <label htmlFor="category">Category</label>
                        <input type="text" className="form-control" name="category" value={product.category}
                               onChange={this.handleChange}/>
                        {submitted && !product.category &&
                        <div className="help-block">Category is required</div>
                        }
                    </div>
                    <div className={'form-group' + (submitted && !product.description ? ' has-error' : '')}>
                        <label htmlFor="description">Description</label>
                        <input type="text" className="form-control" name="description" value={product.description}
                               onChange={this.handleChange}/>
                        {submitted && !product.description &&
                        <div className="help-block">Description is required</div>
                        }
                    </div>
                    <div className="form-group">
                        <button className="btn btn-primary">Add Thing</button>
                        {registering &&
                        <img
                            src="data:image/gif;base64,R0lGODlhEAAQAPIAAP///wAAAMLCwkJCQgAAAGJiYoKCgpKSkiH/C05FVFNDQVBFMi4wAwEAAAAh/hpDcmVhdGVkIHdpdGggYWpheGxvYWQuaW5mbwAh+QQJCgAAACwAAAAAEAAQAAADMwi63P4wyklrE2MIOggZnAdOmGYJRbExwroUmcG2LmDEwnHQLVsYOd2mBzkYDAdKa+dIAAAh+QQJCgAAACwAAAAAEAAQAAADNAi63P5OjCEgG4QMu7DmikRxQlFUYDEZIGBMRVsaqHwctXXf7WEYB4Ag1xjihkMZsiUkKhIAIfkECQoAAAAsAAAAABAAEAAAAzYIujIjK8pByJDMlFYvBoVjHA70GU7xSUJhmKtwHPAKzLO9HMaoKwJZ7Rf8AYPDDzKpZBqfvwQAIfkECQoAAAAsAAAAABAAEAAAAzMIumIlK8oyhpHsnFZfhYumCYUhDAQxRIdhHBGqRoKw0R8DYlJd8z0fMDgsGo/IpHI5TAAAIfkECQoAAAAsAAAAABAAEAAAAzIIunInK0rnZBTwGPNMgQwmdsNgXGJUlIWEuR5oWUIpz8pAEAMe6TwfwyYsGo/IpFKSAAAh+QQJCgAAACwAAAAAEAAQAAADMwi6IMKQORfjdOe82p4wGccc4CEuQradylesojEMBgsUc2G7sDX3lQGBMLAJibufbSlKAAAh+QQJCgAAACwAAAAAEAAQAAADMgi63P7wCRHZnFVdmgHu2nFwlWCI3WGc3TSWhUFGxTAUkGCbtgENBMJAEJsxgMLWzpEAACH5BAkKAAAALAAAAAAQABAAAAMyCLrc/jDKSatlQtScKdceCAjDII7HcQ4EMTCpyrCuUBjCYRgHVtqlAiB1YhiCnlsRkAAAOwAAAAAAAAAAAA=="
                            alt={""}/>
                        }
                        <Link to="/search" className="btn btn-link">Cancel</Link>
                    </div>
                </form>
            </div>
        );
    }
}

function mapStateToProps(state) {
    const {registering} = state.registration;
    return {
        registering
    };
}

const addProductViewContainer = connect(mapStateToProps)(AddProductViewContainer);
export {addProductViewContainer as AddProductViewContainer};