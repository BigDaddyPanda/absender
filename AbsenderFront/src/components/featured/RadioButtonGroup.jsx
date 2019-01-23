import React, { Component } from 'react'
import {
    ButtonGroup
    , Button
} from 'reactstrap'
import classNames from 'classnames'
export default class RadioButtonGroup extends Component {

    constructor(props) {
        super(props);
        this.state = {
            display_style: props.selected
        };
    }
    setDisplayType = name => {
        this.setState({
            display_style: name
        });
    };
    render() {
        const { items, selected } = this.props;
        const { display_style } = this.state
        return (
            <>
                <ButtonGroup
                    className="btn-group-toggle float-right"
                    data-toggle="buttons"
                >
                    {items.map((e, i) => {
                        return <Button
                            key={i}
                            tag="label"
                            className={classNames("btn-simple", {
                                active: selected === e
                            })}
                            color="info"
                            id="0"
                            size="sm"
                            onClick={() => this.setDisplayType(e)}
                        >
                            <input
                                defaultChecked
                                className="d-none"
                                name="options"
                                type="radio"
                            />
                            <span className="d-none d-sm-block d-md-block d-lg-block d-xl-block">
                                {e}
                            </span>
                            <span className="d-block d-sm-none">
                                <i className="tim-icons icon-bullet-list-67" />
                            </span>
                        </Button>
                    })}
                </ButtonGroup>
            </>
        )
    }
}
