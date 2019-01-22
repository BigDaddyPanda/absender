import React from "react";
import ReactDOM from "react-dom";
/**
 * Driving Application Main Component
 */
import App from "./app/app";

/**
 * Css tricks
 */
import "assets/scss/black-dashboard-react.scss";
import "assets/demo/demo.css";
import "assets/css/nucleo-icons.css";

import { Provider } from 'react-redux';
import { store } from './redux/_helpers';
/**
 * Initializing function
 */
ReactDOM.render( <Provider store={store}><App/></Provider>,
  document.getElementById("root")
);