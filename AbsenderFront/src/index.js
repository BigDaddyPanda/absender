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

/**
 * Initializing function
 */
ReactDOM.render( <
  App / > ,
  document.getElementById("root")
);