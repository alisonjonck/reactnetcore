import React, { Component } from 'react';
import './FeedbackMessage.css';

const warningStyle = {
    padding: 15,
    backgroundColor: 'rgb(250, 145, 84)',
    color: '#282828',
    fontWeight: 'bold',
    margin: 20
};

const successStyle = {
    color: '#FFF',
    backgroundColor: 'green'
}

export default class MockWarning extends Component {
    constructor(props) {
        super(props);
        this.state = {
            showWarning: true,
            removeWarning: false
        };
    }

    componentDidMount() {
        var me = this;

        setTimeout(() => me.setState({ showWarning: false }), 5000);
        setTimeout(() => me.setState({ removeWarning: true }), 7000);
    }

    getFeedBackText() {
        return this.props.isMocked
            ? "Demonstração realizada com dados do exemplo feeds.xml"
            : "Demonstração realizada com dados atualizados da API da Minuto Seguros"
    }

    render() {
        var state = this.state,
            isMocked = this.props.isMocked,
            className = isMocked ? 'mock-warning' : 'mock-info',
            feedBackText = this.getFeedBackText(),
            currentStyle = Object.assign({}, warningStyle, !isMocked && successStyle);

        return (
            !state.removeWarning
                ? (
                    <div style={currentStyle} className={!state.showWarning ? `${className} hide` : `${className}`}>
                        <span>{feedBackText}:</span>
                    </div>
                )
                : null
        );
    }
}
