import React from 'react';

const textStyle = {
    color: '#282828'
};

export default (props) => {
    return (
        <h4 style={textStyle}>
            {props.text || props.children}
        </h4>
    )
}