import React, { Component } from 'react'
import AdminNavbar from '../../components/Navbars/AdminNavbar';
import Sidebar from '../../components/Sidebar/Sidebar';
import Footer from '../../components/Footer/Footer';
import { mapStateToProps, multipleActionsMapDispatchToProps } from '../../redux/_helpers';
import { connect } from 'react-redux'
// import FixedPlugin from '';
import { FixedPlugin } from '../../components/FixedPlugin/FixedPlugin'
import { Professor_Routes } from '.';
import { Switch } from 'react-router-dom'
import { getRoutesForLayout } from '../route_utils';
import { getPerfectScrollBar, destroyPerfectScrollBar, updatePerfectScrollBar } from '../../designUtils';
var ps;
var logo = require("assets/img/favicon.png");
export default class ProfessorLayout extends Component {
  constructor(props) {
    super(props);
    this.state = {
      backgroundColor: "blue",
      sidebarOpened:
        document.documentElement.className.indexOf("nav-open") !== -1
    };
  }
  componentDidMount() {
    ps = getPerfectScrollBar(ps, this.refs.mainPanel);
  }
  componentWillUnmount() {
    ps = destroyPerfectScrollBar(ps);
  }
  componentDidUpdate(e) {
    ps = updatePerfectScrollBar(ps, e, this.refs.mainPanel)
  }
  // this function opens and closes the sidebar on small devices
  toggleSidebar = () => {
    document.documentElement.classList.toggle("nav-open");
    this.setState({ sidebarOpened: !this.state.sidebarOpened });
  };
  handleBgClick = color => {
    this.setState({ backgroundColor: color });
  };
  getBrandText = path => {
    for (let i = 0; i < Professor_Routes.length; i++) {
      if (
        this.props.location.pathname.indexOf(
          Professor_Routes[i].layout + Professor_Routes[i].path
        ) !== -1
      ) {
        return Professor_Routes[i].name;
      }
    }
    return "Brand";
  };
  render() {
    return (
      <>
        <div className="wrapper">
          <Sidebar
            {...this.props}
            routes={Professor_Routes}
            bgColor={this.state.backgroundColor}
            logo={{
              outterLink: "#",
              text: "Creative Tim",
              imgSrc: logo
            }}
            toggleSidebar={this.toggleSidebar}
          />
          <div
            className="main-panel"
            ref="mainPanel"
            data={this.state.backgroundColor}
          >
            <AdminNavbar
              {...this.props}
              brandText={this.getBrandText(this.props.location.pathname)}
              toggleSidebar={this.toggleSidebar}
              sidebarOpened={this.state.sidebarOpened}
            />
            <Switch>{getRoutesForLayout(Professor_Routes, "/professor")}</Switch>
            {// we don't want the Footer to be rendered on map page
              this.props.location.pathname.indexOf("maps") !== -1 ? null : (
                <Footer fluid />
              )}
          </div>
        </div>
        <FixedPlugin
          bgColor={this.state.backgroundColor}
          handleBgClick={this.handleBgClick}
        />
      </>
    )
  }
}

const connectedProfessorLayout = connect(mapStateToProps, multipleActionsMapDispatchToProps([]))(ProfessorLayout);
export { connectedProfessorLayout as ProfessorLayout }; 