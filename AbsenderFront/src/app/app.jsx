import React, { Component } from 'react'
import { createBrowserHistory } from "history";
import { Router, Route, Switch, Redirect } from "react-router-dom";
import WelcomeLayout from '../layouts/Welcome/WelcomeLayout';

const hist = createBrowserHistory();

export default class App extends Component {
    render() {
        return (
            <Router history={hist}>
                <Switch>
                    {/* <Route path="/admin" render={props => <AdminLayout {...props} />} />
                    <Route path="/rtl" render={props => <RTLLayout {...props} />} />
                <Redirect from="/" to="/admin/dashboard" /> */}
                    <Route path="/welcome" render={props => <WelcomeLayout {...props} />} />
                </Switch>
            </Router>
        );
    }
}
