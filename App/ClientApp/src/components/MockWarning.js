import React, { Component } from 'react';
import './MockWarning.css';

const warningStyle = {
    padding: 15,
    backgroundColor: '#ff4545',
    color: 'white',
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

        setTimeout(() => me.setState({ showWarning: false }), 3000);
        setTimeout(() => me.setState({ removeWarning: true }), 5000);
    }

    render() {
        var state = this.state;

        return (
            !state.removeWarning
                ? (
                    <div style={warningStyle} className={!state.showWarning ? 'mock-warning hide' : 'mock-warning'}>
                        <span>Dados reais não disponíveis no momento. Demonstração realizada com dados de exemplo:</span>
                    </div>
                )
                : null
        );
    }
}
