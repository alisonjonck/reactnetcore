import React, { Component } from 'react';
import FeedInfoTable from './FeedInfoTable';
import MostUsedInfo from './MostUsedInfo';
import MockWarning from './MockWarning'

export class FeedInfo extends Component {
  static displayName = FeedInfo.name;

  constructor (props) {
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

  getContents () {
    var state = this.state;
    
    return (
      <div>
        {state.isMocked && <MockWarning />}
        <MostUsedInfo words={state.mostUsed10} />
        <FeedInfoTable topics={state.topics} />
      </div>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Carregando...</em></p>
      : this.getContents();

    return (
      <div>
        <h1>Resultados de Análise para o Feed</h1>
        {contents}
      </div>
    );
  }
}
