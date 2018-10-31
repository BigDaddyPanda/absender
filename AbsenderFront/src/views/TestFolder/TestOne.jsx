import React, { Component } from 'react'
import {
    Alert,
    Card,
    CardTitle,
    CardBody,
    CardHeader,
    Row,
    Col
} from "reactstrap";

import { PanelHeader } from "components";

export default class TestOne extends Component {
    constructor(props) {
        super(props);
        this.state = {
            api_response: "true"
        };
    }
    componentDidMount(){
        fetch("https://localhost:44312/api/Absences/test",{method:"GET"}).then((response) => {

            let responseContentType = response.headers.get("content-type");
            if (responseContentType && responseContentType.indexOf("application/json") !== -1) {
                return response.json();
            } else {
                return response.text();
            }
        }).then(response=>{
            this.setState({
                api_response:response
            })
        })
    }
    render() {
        const { api_response } = this.state
        return (
            <div>
                <PanelHeader
                    content={
                        <div className="header text-center">
                            <h2 className="title">Test Module</h2>
                            
                        </div>
                    }
                />
                <div className="content">
                    <Row>
                        <Col md={6} xs={12}>
                            <Card>
                                <CardHeader>
                                    <CardTitle tag="h4">Heyy</CardTitle>
                                </CardHeader>
                                <CardBody>
                                    <Alert color="info">
                                        <span>{api_response}</span>
                                    </Alert>
                                </CardBody>
                            </Card>
                        </Col>
                    </Row>


                </div>
            </div>
        )
    }
}
