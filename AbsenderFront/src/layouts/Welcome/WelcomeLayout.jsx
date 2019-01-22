import React, { Component } from 'react'
import { connect } from 'react-redux'
import { mapStateToProps, multipleActionsMapDispatchToProps } from '../../redux/_helpers';

class WelcomeLayout extends Component {
  render() {
    return (
      <div>
        Welcome To App
      </div>
    )
  }
}
const connectedWelcomeLayout = connect(mapStateToProps, multipleActionsMapDispatchToProps([]))(WelcomeLayout);
export { connectedWelcomeLayout as WelcomeLayout }; 
