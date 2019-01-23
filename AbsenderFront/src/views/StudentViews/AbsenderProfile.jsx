import React, { Component } from 'react'
// import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { mapStateToProps, multipleActionsMapDispatchToProps } from '../../redux/_helpers';
import {
    Col, Card, CardBody, CardText, CardFooter, Button, Fade
} from 'reactstrap'
class AbsenderProfile extends Component {
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
                <Card className="card-user">
                    <CardBody className=" px-1">
                        <CardText />
                        <div className="author">
                            <div className="block block-one" />
                            <div className="block block-two" />
                            <div className="block block-three" />
                            <div className="block block-four" />
                            <a href="#pablo" onClick={e => e.preventDefault()}>
                                <img
                                    alt="..."
                                    className="avatar"
                                    src={require("assets/img/emilyz.jpg")}
                                />
                                <h5 className="title">#123</h5>
                            </a>
                            <p className="h3">Marine Ma</p>
                        </div>
                        <div className=" px-4  justify-content-end card-description">
                        </div>
                    </CardBody>
                    <CardFooter>
                        <div className="button-container">

                            <Button style={{
                                cursor: "pointer",
                                fontSize: "2em"
                            }} className="px-2 h-100" outline color="warning" onClick={this.toggle}> Absent
                            </Button>
                            <Button style={{
                                cursor: "pointer",
                                fontSize: "2em"
                            }} className="px-2 h-100" color="success"> Present
                            </Button>
                        </div>
                    </CardFooter>
                </Card>
            </Fade>
        )
    }
}


const connectedAbsenderProfile = connect(mapStateToProps, multipleActionsMapDispatchToProps([]))(AbsenderProfile);
export { connectedAbsenderProfile as AbsenderProfile }; 