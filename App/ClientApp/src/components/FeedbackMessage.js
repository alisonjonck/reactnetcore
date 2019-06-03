import React, { Component } from 'react';
import './MockWarning.css';

const warningStyle = {
    padding: 15,
    backgroundColor: 'rgb(250, 145, 84)',
    color: '#282828',
    fontWeight: 'bold',
    margin: 20
};

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

    render() {
        var state = this.state;

        return (
            !state.removeWarning
                ? (
                    <div style={warningStyle} className={!state.showWarning ? 'mock-warning hide' : 'mock-warning'}>
                        <span>Demonstração realizada com dados do exemplo feeds.xml:</span>
                    </div>
                )
                : null
        );
    }
}
