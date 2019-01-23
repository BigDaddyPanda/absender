import React, { Component } from 'react'
import {
    Card,
    CardHeader,
    CardBody,
    CardTitle,
    Table,
    Row,
    Col
} from "reactstrap";
import { connect } from 'react-redux'
import { mapStateToProps, multipleActionsMapDispatchToProps } from '../../redux/_helpers';
import { WeekTable, Days, ClassTimes } from '../../designUtils/week_design';

class Dashboard extends Component {
    render() {
        return (
            <>
                <div className="content">
                    <Row>
                        <Col md="12">
                            <Card>
                                <CardHeader>
                                    <CardTitle tag="h4">Emploi du Temps</CardTitle>
                                </CardHeader>
                                <CardBody>
                                    <Table className="tablesorter" responsive>
                                        <thead className="text-primary">
                                            <tr>
                                                <th className="text-center" style={{width:"12.5%"}} >Seance</th>
                                                {Days.map((e, i) => <th className="text-center" style={{width:"12.5%"}}  key={i}>{e}</th>)}
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {ClassTimes.map((e, i) => {
                                                return <tr key={i}>
                                                    <td className="text-center" style={{width:"12.5%"}} >{e}</td>
                                                    {Days.map((a, ii) => { return <td className="text-center" style={{width:"12.5%"}}  key={ii}>{WeekTable[a][e]["Group_Id"]}</td> })}
                                                </tr>
                                            })}
                                        </tbody>
                                        <tfoot></tfoot>
                                    </Table>
                                </CardBody>
                            </Card>
                        </Col>
                    </Row>
                </div>
            </>
        )
    }
}
const connectedDashboard = connect(mapStateToProps, multipleActionsMapDispatchToProps([]))(Dashboard);
export { connectedDashboard as ProfessorDashboard }; 