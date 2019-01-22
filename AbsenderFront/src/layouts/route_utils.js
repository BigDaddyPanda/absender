import React from 'react'
import {
    Route
} from 'react-router-dom'

export const getRoutesForLayout = (routes, layout_name) => {
    return routes.map((prop, key) => {
        if (prop.layout === layout_name) {
            return ( < Route path = {
                    prop.layout + prop.path
                }
                component = {
                    prop.component
                }
                key = {
                    key
                }
                />
            );
        } else {
            return null;
        }
    });
};