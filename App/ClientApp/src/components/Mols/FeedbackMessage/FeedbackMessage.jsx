import React, { Component } from 'react';
import Text from '../../Atoms/Text/Text';

import './FeedbackMessage.css';

const feedbackStyle = {
    padding: 15,
    backgroundColor: '#ffd7a5',
    color: '#282828',
    fontWeight: 'bold',
    margin: 20
};

const infoStyle = {
    backgroundColor: '#a8efff'
};

export default class FeedbackMessage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            showWarning: true,
            removeWarning: false
        };
    }

    componentDidMount() {
        var me = this;

        this.showWarningFn = setTimeout(() => me.setState({ showWarning: false }), 5000);
        this.removeWarningFn = setTimeout(() => me.setState({ removeWarning: true }), 7000);
    }

    componentWillUnmount() {
        if (this.showWarningFn) {
            clearTimeout(this.showWarningFn);
        }

        if (this.removeWarningFn) {
            clearTimeout(this.removeWarningFn);
        }
    }

    render() {
        var state = this.state,
            isInfo = this.props.isInfo,
            className = !isInfo ? 'mock-warning' : 'mock-info',
            message = this.props.message,
            style = Object.assign({}, feedbackStyle, isInfo && infoStyle);

        return (
            !state.removeWarning
                ? (
                    <div style={style} className={!state.showWarning ? `${className} hide` : `${className}`}>
                        <Text>{message}</Text>
                    </div>
                )
                : null
        );
    }
}
