import {
    bindActionCreators
  } from 'redux';
  //Redux Util for connect function
  export const mapStateToProps = state => {
    const { ...rest
    } = state;
    return rest;
  }
  
  export const mapDispatchToProps = (actionCreators) => (dispatch) => {
    return bindActionCreators(actionCreators, dispatch);
  }
  export const multipleActionsMapDispatchToProps = (actionCreators) => (dispatch) => {
    let all_actions = {}
    actionCreators.forEach(element => {
      all_actions = {
        ...all_actions,
        ...element
      }
    });
    return bindActionCreators(all_actions, dispatch);
  }
  