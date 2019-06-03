import React, { Component } from 'react';
import FeedInfoTable from './FeedInfoTable';
import MostUsedInfo from './MostUsedInfo';
import MockWarning from './MockWarning'

const wrapperStyle = {
  marginBottom: 60
};

export class FeedInfo extends Component {
  static displayName = FeedInfo.name;

  constructor(props) {
    super(props);
    this.state = { topics: [], loading: true };

    fetch('api/FeedData/ReturnsFeedInfo')
      .then(response => response.json())
      .then(data => {
        this.setState({
          topics: data.topics,
          mostUsed10: data.mostUsed10,
          isMocked: data.isMocked,
          loading: false
        });
      });
  }

  getContents() {
    var state = this.state;

    return (
      <div>
        {state.isMocked && <MockWarning />}
        <MostUsedInfo words={state.mostUsed10} />
        <FeedInfoTable topics={state.topics} />
      </div>
    );
  }

  throtleRequest() {
    var me = this,
      queryString = this.state.isMocked ? "" : "isThrottle=true";

    this.setState({ loading: true });

    fetch('api/FeedData/ReturnsFeedInfo?' + queryString)
      .then(response => response.json())
      .then(data => {
        me.setState({
          topics: data.topics,
          mostUsed10: data.mostUsed10,
          isMocked: data.isMocked,
          loading: false
        });
      });
  }

  getSimulateThrottleBtn() {
    var text = this.state.isMocked ? "Tentar reconectar" : "Simular throttle";

    return (
      <div>
        <button disabled={this.state.loading} onClick={this.throtleRequest.bind(this)}>
          {text}
        </button>
      </div>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Carregando...</em></p>
      : this.getContents();

    return (
      <div style={wrapperStyle}>
        <h1>Resultados de Análise para o Feed</h1>
        {this.getSimulateThrottleBtn()}
        {contents}
        <hr />
      </div>
    );
  }
}
