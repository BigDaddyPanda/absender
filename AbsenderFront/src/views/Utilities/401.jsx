import React, { Component } from 'react';
import { PanelHeader } from "components";

export default class Page401 extends Component {
    render() {
        return (
            <div>
                <PanelHeader
                    content={
                        <div className="header text-center">
                            <h2 className="title">Vous n'êtes pas autorisé à être ici</h2>
                            
                        </div>
                    }
                />
            </div>
        )
    }
}
