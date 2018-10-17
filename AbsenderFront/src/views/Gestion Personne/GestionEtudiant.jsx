import React from "react";
import { Card,CardTitle, CardHeader, CardBody, Row, Col, Breadcrumb, BreadcrumbItem, Button,Table, UncontrolledCollapse, Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
// import { Link } from "react-router-dom";
import { PanelHeader } from "components";
import RestUtilities from "../../utils/RestUtilities";
import { thead, tbody } from "variables/general";
import { etudiant_headline } from "../../variables/utilities";

class GestionEtudiant extends React.Component {
    state = {
        list_classes: null,
        list_filiere: null,
        list_etudiant: null,
        display_list_etudiant: false,
    }
    dismiss_list_etudiant = () => {
        this.setState({
            list_etudiant: null,
            display_list_etudiant: false,
        })
    }
    matchClassMembers = () => {
        this.setState({
            list_etudiant: [{

            }],
            display_list_etudiant: true,
        })
    }
    render_icon_div = (element, key) => {
        return <Col
            key={key}
            xs={12}
            md={2}
        >
            <Button block color="primary"
                onClick={() => this.matchClassMembers(element)}
                xs={12}>
                <div className="font-icon-detail">
                    <h3>{element.designationOption + " " + element.designationClasse}</h3>
                    <i className={"now-ui-icons arrows-1_minimal-down"} />
                </div>
            </Button>
        </Col>
    }


    componentWillMount() {
        RestUtilities.get("api/Filieres").then(response => {
            console.log(response);
            this.setState({
                list_classes: response.content,
                list_filiere: [...new Set(response.content.map(item => item.designationFiliere))]

            })

        })
    }
    render() {
        const { list_classes, list_filiere, list_etudiant, display_list_etudiant } = this.state
        return (
            <div>
                <PanelHeader size="sm" />
                <div className="content">
                    <Row>
                        <Col md={12}>
                            <Card>
                                <CardHeader>
                                    <h5 className="title">Cours du Jour</h5>
                                    <p className="category">Cliquez pour étendre la liste des classes</p>
                                </CardHeader>
                                <CardBody className="all-icons">
                                    {
                                        list_filiere && list_filiere.map(e => {
                                            return <div key={e}>
                                                <Breadcrumb id={"toggler" + e} >
                                                    <BreadcrumbItem active>Classes {e}</BreadcrumbItem>
                                                </Breadcrumb>
                                                <UncontrolledCollapse toggler={"#toggler" + e}>
                                                    <Card>
                                                        <CardBody>
                                                            <Row>
                                                                {
                                                                    list_classes && list_classes.filter(x => !x.estCoursSoire && x.designationFiliere === e).map((e, key) => this.render_icon_div(e, key))
                                                                }
                                                            </Row>
                                                        </CardBody>
                                                    </Card>
                                                </UncontrolledCollapse>
                                            </div>
                                        })
                                    }

                                </CardBody>
                            </Card>

                            <Card>
                                <CardHeader>
                                    <h5 className="title">Cours de Soir</h5>
                                    <p className="category">Cliquez pour étendre la liste des classes</p>
                                </CardHeader>
                                <CardBody className="all-icons">
                                    <Breadcrumb id="toggler" >
                                        <BreadcrumbItem active>Classes Premiere Année</BreadcrumbItem>

                                    </Breadcrumb>
                                    <UncontrolledCollapse toggler="#toggler">
                                        <Card>
                                            <CardBody>
                                                <Row>
                                                    {
                                                        list_classes && list_classes.filter(x => x.estCoursSoire).map((e, key) => this.render_icon_div(e, key))
                                                    }
                                                </Row>
                                            </CardBody>
                                        </Card>
                                    </UncontrolledCollapse>

                                </CardBody>
                            </Card>
                        </Col>
                    </Row>
                </div>
                <Modal size="lg" isOpen={display_list_etudiant} toggle={this.dismiss_list_etudiant} className={this.props.className}>
                    <ModalHeader toggle={this.dismiss_list_etudiant}>Liste Etudiant</ModalHeader>
                    <ModalBody>
                        <Col xs={12}>
                            <Card className="card-plain">
                                <CardHeader>
                                    <CardTitle tag="h4">Table on Plain Background</CardTitle>
                                    <p className="category"> Here is a subtitle for this table</p>
                                </CardHeader>
                                <CardBody>
                                    <Table responsive>
                                        <thead className="text-primary">
                                            <tr>
                                                {etudiant_headline.map((prop, key) => {
                                                    if (key === thead.length - 1)
                                                        return (
                                                            <th key={key} className="text-right">
                                                                {prop}
                                                            </th>
                                                        );
                                                    return <th key={key}>{prop}</th>;
                                                })}
                                            </tr>
                                        </thead>
                                           </Table>
                                </CardBody>
                            </Card>
                        </Col>
                    </ModalBody>
                    <ModalFooter>
                        <Button color="primary" onClick={this.dismiss_list_etudiant}>Mettre à Jour</Button>{' '}
                        <Button color="secondary" onClick={this.dismiss_list_etudiant}>Décliner</Button>
                    </ModalFooter>
                </Modal>
            </div>
        );
    }
}

export default GestionEtudiant;
