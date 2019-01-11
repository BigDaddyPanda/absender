import React, { Component } from 'react'
import { createBrowserHistory } from "history";
import { Router, Route, Switch, Redirect } from "react-router-dom";

const hist = createBrowserHistory();

export default class App extends Component {
    render() {
        return (
            <Router history={hist}>
                <Switch>
                    {/* <Route path="/admin" render={props => <AdminLayout {...props} />} />
                    <Route path="/rtl" render={props => <RTLLayout {...props} />} />
                    <Redirect from="/" to="/admin/dashboard" /> */}
                </Switch>
            </Router>
        );
    }
}
