import React from 'react';
import {Button} from "../../common/Button";
import {Link} from "react-router-dom";


export class HomePageContainer extends React.Component {

    render() {
        return (
            <div>
                <div>
                    <Link to="register">
                        <Button className="raised" content="Register"/>
                    </Link>
                </div>
                <div>
                    <Link to="login">
                        <Button className="raised" content="Log in"/>
                    </Link>
                </div>
            </div>
        )
    }
}
