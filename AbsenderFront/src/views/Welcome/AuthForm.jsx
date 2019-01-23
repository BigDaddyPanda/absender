import React, { Component } from 'react';
import {
    Container, Col, Form,
    FormGroup, Label, Input,
    Button, FormText, FormFeedback,
} from 'reactstrap';
import './AuthForm.css';
import { connect } from 'react-redux'
import { mapStateToProps, multipleActionsMapDispatchToProps, history } from '../../redux/_helpers';

class AuthForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            'email': '',
            'password': '',
            validate: {
                emailState: '',
            },
        }
        this.handleChange = this.handleChange.bind(this);
    }

    validateEmail(e) {
        const emailRex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        const { validate } = this.state
        if (emailRex.test(e)) {
            validate.emailState = 'has-success'
        } else {
            validate.emailState = 'has-danger'
        }
        this.setState({ validate })
    }

    handleChange = async (event) => {
        const { target } = event;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const { name } = target;
        await this.setState({
            [name]: value,
        });
    }

    submitForm(e) { 
        this.validateEmail(this.state.email)
        console.log(this.state.email);
        history.push('student/dashboard')
    }

    render() {
        const { email, password } = this.state;
        return (
            <Container className="AuthForm">
                <h2>Welcome to Absender</h2>
                <Form className="form" onSubmit={(e) => this.submitForm(e)}>
                    <Col>
                        <FormGroup>
                            <Label>Username</Label>
                            <Input
                                type="email"
                                name="email"
                                id="exampleEmail"
                                placeholder="myemail@email.com"
                                value={email}
                                valid={this.state.validate.emailState === 'has-success'}
                                invalid={this.state.validate.emailState === 'has-danger'}
                                onChange={(e) => {
                                    this.handleChange(e)
                                }}
                            />
                            {/* <FormFeedback valid>
                                That's a tasty looking email you've got there.
              </FormFeedback> */}
                            <FormFeedback>
                                {"Uh oh! Looks like there is an issue with your email. Please input a correct email."}
                            </FormFeedback>
                            <FormText>Your username is most likely your email.</FormText>
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup>
                            <Label for="examplePassword">Password</Label>
                            <Input
                                type="password"
                                name="password"
                                id="examplePassword"
                                placeholder="********"
                                value={password}
                                onChange={(e) => this.handleChange(e)}
                            />
                        </FormGroup>
                    </Col>
                    <Col className="ml-auto">
                        <Button onClick={(e) => this.submitForm(e)}>Submit</Button>
                    </Col>
                </Form>
            </Container>
        );
    }
}

const connectedAuthForm = connect(mapStateToProps, multipleActionsMapDispatchToProps([]))(AuthForm);
export { connectedAuthForm as AuthForm };
// export default AuthForm;
