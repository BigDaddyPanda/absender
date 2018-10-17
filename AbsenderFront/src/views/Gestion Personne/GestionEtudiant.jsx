import React from "react";
import { Card, CardTitle, CardHeader, CardBody, Row, Col, Breadcrumb, BreadcrumbItem, Button, Table, UncontrolledCollapse, Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
// import { Link } from "react-router-dom";
import { PanelHeader } from "components";
import RestUtilities from "../../utils/RestUtilities";
import { thead, tbody } from "variables/general";
import { etudiant_headline } from "../../variables/utilities";

const optionReducer = (list_class,designationFiliere,coursSoir=false)=>{
    return [...new Set(list_class.filter(cls=>cls.filiereGroupe.designationFiliere===designationFiliere&&cls.estCoursSoire===coursSoir).flatMap(cls=>cls.filiereGroupe.designationOption))]
}


class GestionEtudiant extends React.Component {
    state = {
        list_filiere: null,
        list_option: null,
        list_classes: null,
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
    render_icon_div = (group, key) => {
        return <Col
            key={key}
            xs={12}
            md={2}
        >
            <Button block color="primary"
                onClick={() => this.matchClassMembers(group)}
                xs={12}>
                <div className="font-icon-detail">
                    <h3>{group.designationGroupe}</h3>
                    <p>{group.nombreEtudiant}</p>
                    {/* <i className={"now-ui-icons arrows-1_minimal-down"} /> */}
                </div>
            </Button>
        </Col>
    }


    componentWillMount() {
        RestUtilities.get("api/Groupes").then(response => {
            // console.log(response);
            // var list_option = list_filiere.forEach(element=> {
                
            // });
            this.setState({
                list_classes: response.content,
                list_filiere: [...new Set(response.content.map(item => item.filiereGroupe.designationFiliere))],
                // list_option: [...new Set(response.content.map(item => item.filiereGroupe.designationOption))]

            })
            // console.log(this.state.list_option);


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
                        {
                            ["Jour","Soir"].map(ClassTime => {return <Card key={ClassTime}>
                                <CardHeader>
                                    <h5 className="title">Cours {ClassTime==="Soir"?"de":"du"} {ClassTime}</h5>
                                    <p className="category">Cliquez pour étendre la liste des classes</p>
                                </CardHeader>
                                <CardBody className="all-icons">
                                    {
                                        list_filiere && list_filiere.map(filiere => {
                                            const optionRed = optionReducer(list_classes,filiere,ClassTime==="Soir");
                                            console.log(optionRed);
                                            
                                            return optionRed.length===0?null:<div key={filiere}>
                                                <Breadcrumb id={"toggler" + ClassTime +filiere} >
                                                    <BreadcrumbItem active>Classes {filiere}</BreadcrumbItem>
                                                </Breadcrumb>
                                                <UncontrolledCollapse toggler={"#toggler" + ClassTime +filiere}>
                                                    <Card>
                                                        <CardBody>
                                                            {
                                                                
                                                                optionRed
                                                                .map(
                                                                    xoption => {
                                                                        // console.log(xoption, "#mapping");
                            
                                                                        return (
                                                                            <div key={xoption}>
                                                                                <CardHeader>
                                                                                    <h6 className="title">Groupes des {xoption}</h6>
                                                                                </CardHeader>
                                                                                <Row>
                                                                                    {
                                                                                        list_classes && list_classes.filter(x =>x.estCoursSoire===(ClassTime==="Soir") && x.filiereGroupe.designationFiliere === filiere && x.filiereGroupe.designationOption === xoption).map((group, key) => { return this.render_icon_div(group, key); })
                                                                                    }
                                                                                </Row>
                                                                            </div>
                                                                        )
                                                                    }
                                                                )
                                                            }
                            
                                                        </CardBody>
                                                    </Card>
                                                </UncontrolledCollapse>
                                            </div>
                                        })
                                    }
                            
                                </CardBody>
                            </Card>}
                            )
                            
                        }
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
                                        <tbody>
                                            {list_etudiant&&list_etudiant.length}
                                        </tbody>
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
