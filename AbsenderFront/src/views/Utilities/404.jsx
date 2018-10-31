import React, { Component } from 'react';
import { PanelHeader } from "components";

export default class Page404 extends Component {
    render() {
        return (
            <div>
                <PanelHeader
                    content={
                        <div className="header text-center">
                            <h2 className="title">404. Non trouvé</h2>
                            
                        </div>
                    }
                />
            </div>
        )
    }
}
