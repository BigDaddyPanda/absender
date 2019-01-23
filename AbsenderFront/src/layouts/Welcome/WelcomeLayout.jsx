import React, { Component } from 'react'
import { connect } from 'react-redux'
import { mapStateToProps, multipleActionsMapDispatchToProps } from '../../redux/_helpers';
import { AuthForm } from '../../views/Welcome';

class WelcomeLayout extends Component {
  render() {
    return (
      <div>
        <AuthForm />
      </div>
    )
  }
}
const connectedWelcomeLayout = connect(mapStateToProps, multipleActionsMapDispatchToProps([]))(WelcomeLayout);
export { connectedWelcomeLayout as WelcomeLayout }; 
