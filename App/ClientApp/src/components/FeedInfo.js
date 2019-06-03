import React, { Component } from 'react';
import FeedInfoTable from './FeedInfoTable';
import MostUsedInfo from './MostUsedInfo';
import FeedbackMessage from './FeedbackMessage'

const wrapperStyle = {
  marginBottom: 60
}, headerStyle = {
  display: 'flex',
  justifyContent: 'space-between',
  alignItems: 'center'
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
        {<FeedbackMessage isMocked={state.isMocked} />}
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
    var text = this.state.isMocked ? "Carregar da API" : "Carregar de feed.xml";

    return (
      <div>
        <button className="btn btn-primary" disabled={this.state.loading} onClick={this.throtleRequest.bind(this)}>
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
        <div style={headerStyle}>
          <h1>Resultados de Análise para o Feed</h1>
          {this.getSimulateThrottleBtn()}
        </div>
        {contents}
        <hr />
      </div>
    );
  }
}
