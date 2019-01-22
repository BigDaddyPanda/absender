import React, { Component } from 'react'
import { createBrowserHistory } from "history";
import { Router, Route, Switch, Redirect } from "react-router-dom";
import { WelcomeLayout } from '../layouts/Welcome';
import Admin from '../layouts/Admin/Admin';
import ProfessorLayout from '../layouts/Professors/ProfessorLayout';

const hist = createBrowserHistory();

export default class App extends Component {
    render() {
        return (
            <Router history={hist}>
                <Switch>
                    {/* <Route path="/admin" render={props => <AdminLayout {...props} />} />
                    <Route path="/rtl" render={props => <RTLLayout {...props} />} />
                */}
                    <Route path="/admin" render={props => <Admin {...props} />} />
                    <Route path="/professor" render={props => <ProfessorLayout {...props} />} />
                    <Route path="/welcome" render={props => <WelcomeLayout {...props} />} />
                    <Redirect from="/*" to="/admin/dashboard" />
                </Switch>
            </Router>
        );
    }
}
