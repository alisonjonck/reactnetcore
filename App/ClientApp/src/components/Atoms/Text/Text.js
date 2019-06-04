import React from 'react';

const textStyle = {
    fontSize: 12,
    color: '#282828'
};

const boldStyle = {
    fontWeight: 'bold'
};

export default (props) => {
    var style = Object.assign({}, textStyle, props.bold && boldStyle)
    
    return (
        <span style={style}>
            {props.text || props.children}
        </span>
    )
}