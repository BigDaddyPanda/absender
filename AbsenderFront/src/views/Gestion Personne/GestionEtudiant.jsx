import React from "react";
import { Card, CardHeader, CardBody, Row, Col, Breadcrumb, BreadcrumbItem } from "reactstrap";
import {Link} from "react-router-dom";
import { PanelHeader } from "components";
import RestUtilities from "../../utils/RestUtilities";

// import icons from "variables/icons";
// import userAvatar from "assets/img/mike.jpg";

const Niveau =[
    "CPI-1",
    "CPI-2",
    "TIC",
    "C2I",
    "C3I",
    "C3I-CS",
    "C3I-CS",
    "C3I-CS",
]

// const tout_etudiant = [
//     {
//         id_universitaire: "1111",
//         nom: "11x11",
//         classe: "C2I",
//         face: userAvatar,
//     },
//     {
//         id_universitaire: "11211",
//         nom: "11111",
//         classe: "C2I",
//         face: userAvatar,
//     },
//     {
//         id_universitaire: "11131",
//         nom: "14111",
//         classe: "C2I",
//         face: userAvatar,
//     }
// ]


class GestionEtudiant extends React.Component {
    state={
        list_etudiants:null,
    }
    componentWillMount(){
        RestUtilities.get("api/Filieres").then(response=>{
            console.log(response);
            
        })
    }
    render() {
        return (
            <div>
                <PanelHeader size="sm" />
                <div className="content">
                    <Row>
                        <Col md={12}>
                            <Card>
                                <CardHeader>
                                    <h5 className="title">Liste des Etudiants</h5>
                                    <p className="category">Cliquez pour étendre la liste des classes</p>
                                </CardHeader>
                                <CardBody className="all-icons">
                                        <Breadcrumb>
                                            <BreadcrumbItem active>Classes Premiere Année</BreadcrumbItem>
                                            
                                        </Breadcrumb>
                                    <Row>
                                        {Niveau.map((prop, key) => {
                                            return (
                                                <Col
                                                xs={2}
                                                    key={key}
                                                >
                                                    <Link to="/"
                                                        xs={12}>
                                                    <div className="font-icon-detail">
                                                        <h3>{prop}</h3>
                                                        <p>Classe {prop} de Niv.</p>
                                                    </div>
                                                    </Link>
                                                </Col>
                                            );
                                        })}
                                        <Col
                                                xs={2}
                                                >
                                                    <Link to="/"
                                                        xs={12}>
                                                    <div className="font-icon-detail">
                                                        <h3>+</h3>
                                                        <p>Ajouter</p>
                                                    </div>
                                                    </Link>
                                                </Col>
                                    </Row>
                                </CardBody>
                            </Card>
                        </Col>
                    </Row>
                </div>
            </div>
        );
    }
}

export default GestionEtudiant;
