import React, { Component } from 'react'
// import PropTypes from 'prop-types'
import { connect } from 'react-redux'
import { mapStateToProps, multipleActionsMapDispatchToProps } from '../../redux/_helpers';
import {
    Table, Card, CardBody, CardHeader, CardTitle, Fade, Button
} from 'reactstrap'
import RadioButtonGroup from '../../components/featured/RadioButtonGroup';
class RowProfile extends Component {
    constructor(props) {
        super(props);
        this.state = { fadeIn: true, defaultSelect: "Present", student_list: Array(10).fill() };
        this.toggle = this.toggle.bind(this);
    }



    toggle() {
        this.setState({
            fadeIn: !this.state.fadeIn
        });
    }
    setDs = (e) => {
        let { student_list } = this.state
        this.setState({ defaultSelect: e })
        for (let i = 0; i < student_list.length; i++) {
            student_list[i] = e

        }

    }
    render() {
        const { defaultSelect, student_list } = this.state
        return (

            <Fade in={this.state.fadeIn} className="px-3"  >
                <Table striped hover>
                    <thead className="text-primary">
                        <tr>
                            <th colSpan={2} className="text-right" >Marquer tous:
                            <Button onClick={() => this.setDs("Present")} color="link">Present</Button>
                                | <Button onClick={() => this.setDs("Absent")} color="link">Absent</Button></th>
                        </tr>
                        <tr>
                            <th style={{ width: "85%" }} >Nom &amp; Prenom</th>
                            <th style={{ width: "25%" }} >Country</th>
                            {/* <th style={{width:"25%"}} >Justificatif</th>  */}
                        </tr>
                    </thead>
                    <tbody>
                        {student_list.map((e, i) => {
                            return <tr key={i}>
                                <td>Etudiant {i}</td>
                                <td><RadioButtonGroup selected={e} items={["Absent", "Present"]} /></td>
                            </tr>
                        })}
                    </tbody>
                </Table>
            </Fade>
        )
    }
}


const connectedRowProfile = connect(mapStateToProps, multipleActionsMapDispatchToProps([]))(RowProfile);
export { connectedRowProfile as RowProfile }; 