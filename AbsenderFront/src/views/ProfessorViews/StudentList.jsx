import React, { Component } from 'react'
import {
    Card,
    CardBody,
    CardTitle,
    Button,
    ButtonGroup,
    CardHeader,
    Row,
    Col,
} from "reactstrap";
import classNames from 'classnames'
import { connect } from 'react-redux'
import { multipleActionsMapDispatchToProps, mapStateToProps } from '../../redux/_helpers';
import { AbsenderProfile, RowProfile } from '../StudentViews';
import { getPerfectScrollBar, destroyPerfectScrollBar, updatePerfectScrollBar } from '../../designUtils';
import { AbsenderList } from './AbsenderList';
var ps;
class StudentList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            display_style: "full"
        };
    }
    componentDidMount() {
        ps = getPerfectScrollBar(ps, this.refs.mainPanelSt);
    }
    componentWillUnmount() {
        ps = destroyPerfectScrollBar(ps);
    }
    componentDidUpdate(e) {
        ps = updatePerfectScrollBar(ps, e, this.refs.mainPanelSt)
    }

    setDisplayType = name => {
        this.setState({
            display_style: name
        });
    };
    render() {
        const { display_style } = this.state
        return (
            <>
                <div className="content" ref="mainPanelSt">

                    <Row>
                        <Col xs="12">
                            <Card className="card-chart">
                                <CardHeader>
                                    <Row>
                                        <Col className="text-left" sm="6">
                                            <h5 className="card-category">Liste de Presence</h5>
                                            <CardTitle tag="h2">3 GL BD - A</CardTitle>
                                        </Col>
                                        <Col sm="6">
                                            <ButtonGroup
                                                className="btn-group-toggle float-right"
                                                data-toggle="buttons"
                                            >
                                                <Button
                                                    tag="label"
                                                    className={classNames("btn-simple", {
                                                        active: display_style === "full"
                                                    })}
                                                    color="info"
                                                    id="0"
                                                    size="sm"
                                                    onClick={() => this.setDisplayType("full")}
                                                >
                                                    <input
                                                        defaultChecked
                                                        className="d-none"
                                                        name="options"
                                                        type="radio"
                                                    />
                                                    <span className="d-none d-sm-block d-md-block d-lg-block d-xl-block">
                                                        {`Full Mode`}
                                                    </span>
                                                    <span className="d-block d-sm-none">
                                                        <i className="tim-icons icon-bullet-list-67" />
                                                    </span>
                                                </Button>
                                                <Button
                                                    color="info"
                                                    id="1"
                                                    size="sm"
                                                    tag="label"
                                                    className={classNames("btn-simple", {
                                                        active: display_style === "absender"
                                                    })}
                                                    onClick={() => this.setDisplayType("absender")}
                                                >
                                                    <input
                                                        className="d-none"
                                                        name="options"
                                                        type="radio"
                                                    />
                                                    <span className="d-none d-sm-block d-md-block d-lg-block d-xl-block">
                                                        {`Absender Mode`}</span>
                                                    <span className="d-block d-sm-none">
                                                        <i className="tim-icons icon-single-02" />
                                                    </span>
                                                </Button>
                                            </ButtonGroup>
                                        </Col>
                                    </Row>
                                </CardHeader>
                                <CardBody>
                                    {display_style === "absender" ? <AbsenderList /> : <RowProfile />}
                                </CardBody>
                                <CardBody>

                                    <div className="text-right">
                                        <input type="checkbox" />{" Je consigne avoir vérifié la Liste"}<br />
                                        <Button className="ml-auto" color="success" size="sm" >Soumettre</Button>

                                    </div>
                                </CardBody>

                            </Card>
                        </Col>
                    </Row>
                </div>
            </>
        )
    }
}
const connectedStudentList = connect(mapStateToProps, multipleActionsMapDispatchToProps([]))(StudentList);
export { connectedStudentList as StudentList }; 