import React, { Component } from 'react'
// import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { mapStateToProps, multipleActionsMapDispatchToProps } from '../../redux/_helpers';
import {
    Col, Button, Row, Fade
} from 'reactstrap'
import { AbsenderProfile } from '../StudentViews';
class AbsenderList extends Component {
    constructor(props) {
        super(props);
        this.state = { fadeIn: true };
        this.toggle = this.toggle.bind(this);
    }



    toggle() {
        this.setState({
            fadeIn: !this.state.fadeIn
        });
    }
    render() {
        return (

            <Fade in={this.state.fadeIn} tag="h5" className="mt-3">
                <Row>

                    <Button className="btn-icon btn-round mx-auto my-auto col-xs-2" color="google">
                        <i className="tim-icons icon-double-left" />
                    </Button>
                    <Col md="8" className="justify-content-center">
                        <AbsenderProfile />
                    </Col>

                    <Button className="btn-icon btn-round mx-auto my-auto col-xs-2" color="google">
                        <i className="tim-icons icon-double-right" />
                    </Button>
                </Row>
            </Fade>
        )
    }
}


const connectedAbsenderProfile = connect(mapStateToProps, multipleActionsMapDispatchToProps([]))(AbsenderList);
export { connectedAbsenderProfile as AbsenderList }; 