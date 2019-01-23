import React from "react";
// nodejs library that concatenates classes
import classNames from "classnames";
// react plugin used to create charts
import { Line } from "react-chartjs-2";
import { connect } from 'react-redux'

// reactstrap components
import {
    Button, 
    Card,
    CardHeader,
    CardBody,
    CardTitle, 
    Table,
    Row,
    Col,
    UncontrolledTooltip,
    CardText,
    CardFooter
} from "reactstrap";

// core components
import {
    chartExample1, 
} from "variables/charts.jsx";
import { mapStateToProps, multipleActionsMapDispatchToProps } from "../../redux/_helpers";

class StudentDashboard extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            bigChartData: "data1"
        };
    }
    setBgChartData = name => {
        this.setState({
            bigChartData: name
        });
    };
    render() {
        return (
            <>
                <div className="content">

                    <Row>
                        <Col lg="8" md="12">
                            <Card >
                                <CardHeader>
                                    <h6 className="title d-inline">Notification d'Absence</h6>
                                    {/* <p className="card-category d-inline"> today</p> */}
                                    {/* <UncontrolledDropdown>
                                        <DropdownToggle
                                            caret
                                            className="btn-icon"
                                            color="link"
                                            data-toggle="dropdown"
                                            type="button"
                                        >
                                            <i className="tim-icons icon-settings-gear-63" />
                                        </DropdownToggle>
                                        <DropdownMenu aria-labelledby="dropdownMenuLink" right>
                                            <DropdownItem
                                                href="#pablo"
                                                onClick={e => e.preventDefault()}
                                            >
                                                {"Action"}
                                            </DropdownItem>
                                            <DropdownItem
                                                href="#pablo"
                                                onClick={e => e.preventDefault()}
                                            >
                                                {"Another action"}
                                            </DropdownItem>
                                            <DropdownItem
                                                href="#pablo"
                                                onClick={e => e.preventDefault()}
                                            >
                                                {"Something else"}
                                            </DropdownItem>
                                        </DropdownMenu>
                                    </UncontrolledDropdown> */}
                                </CardHeader>
                                <CardBody>
                                    <div className="table-full-width table-responsive">
                                        <Table striped>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <p className="title">Seance NoSQL</p>
                                                        <p className="text-muted">
                                                            {"Par Mr. AAAA 27/07/2018 10:45"}
                                                        </p>
                                                    </td>
                                                    <td className="td-actions text-right">
                                                        <Button
                                                            color="link"
                                                            id="tooltip636901683"
                                                            title=""
                                                            type="button"
                                                        >
                                                            <i className="tim-icons icon-alert-circle-exc" />
                                                        </Button>
                                                        <UncontrolledTooltip
                                                            delay={0}
                                                            target="tooltip636901683"
                                                            placement="right"
                                                        >
                                                            {"Signaler Faute"}
                                                        </UncontrolledTooltip>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </Table>
                                    </div>
                                </CardBody>
                            </Card>
                        </Col>
                        <Col md="4">
                            <Card className="card-user">
                                <CardBody>
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
                                                src={require("assets/img/mike.jpg")}
                                            />
                                            <h5 className="title">Samir Lahnin</h5>
                                        </a>
                                        <p className="description">3 GL-BD -A</p>
                                    </div>
                                    {/* <div className="card-description">
                                        Do not be scared of the truth because we need to restart the
                                        human foundation in truth And I love you like Kanye loves
                                        Kanye I love Rick Owens’ bed design but the back is...
                                    </div> */}
                                </CardBody>
                                <CardFooter>
                                    <div className="button-container">
                                        <Button className="btn-icon btn-round"  >
                                            <i className="tim-icons icon-pencil" />
                                        </Button>
                                    </div>
                                </CardFooter>
                            </Card>
                        </Col>
                    </Row>

                    <Row>
                        <Col xs="12">
                            <Card className="card-chart">
                                <CardHeader>
                                    <Row>
                                        <Col className="text-left" sm="6">
                                            <h5 className="card-category">Total Shipments</h5>
                                            <CardTitle tag="h2">Performance</CardTitle>
                                        </Col>
                                    </Row>
                                </CardHeader>
                                <CardBody>
                                    <div className="chart-area">
                                        <Line
                                            data={chartExample1[this.state.bigChartData]}
                                            options={chartExample1.options}
                                        />
                                    </div>
                                </CardBody>
                            </Card>
                        </Col>
                    </Row>
                </div>
            </>
        );
    }
}

const connectedStudentDashboard = connect(mapStateToProps, multipleActionsMapDispatchToProps([]))(StudentDashboard);
export { connectedStudentDashboard as StudentDashboard }; 
