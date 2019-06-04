import React, { Component } from 'react';
import FeedInfoTable from '../../Orgs/FeedInfoTable/FeedInfoTable';
import MostUsedInfo from '../../Orgs/MostUsedInfo/MostUsedInfo';
import FeedbackMessage from '../../Mols/FeedbackMessage/FeedbackMessage'
import Header from '../../Atoms/Header/Header';

import feedService from '../../../services/feedService';

const exemploFeedsMessage = "Demonstração realizada com dados do exemplo feeds.xml:";
const atualizadosDaAPIMessage = "Demonstração realizada com dados atualizados da API da Minuto Seguros:";

const wrapperStyle = {
  marginBottom: 60
};

const headerStyle = {
  display: 'flex',
  justifyContent: 'space-between',
  alignItems: 'center'
};

export class FeedInfo extends Component {
  static displayName = FeedInfo.name;

  constructor(props) {
    super(props);
    this.state = { topics: [], loading: true, isMocked: true };
  }

  componentDidMount() {
    this.getInfo();
  }

  componentWillUnmount() {
    this.safeAbortXhr();
  }

  safeAbortXhr() {
    if (this.returnFeedInfoXhr) {
      this.returnFeedInfoXhr
        .catch(console.log.bind(null, 'safe abort component unmount'))
        .abort();
    }
  }
  
  getContents() {
    const state = this.state,
      feedbackText = state.isMocked ? exemploFeedsMessage : atualizadosDaAPIMessage;

    return (
      <div>
        <FeedbackMessage isInfo={!state.isMocked} message={feedbackText} />
        <MostUsedInfo words={state.mostUsed10} />
        <FeedInfoTable topics={state.topics} title={"Palavras importantes (últimos 10 posts):"} />
      </div>
    );
  }

  getInfo() {
    var me = this,
      queryString = this.state.isMocked ? "" : "isThrottle=true";

    this.setState({ loading: true });

    me.returnFeedInfoXhr = feedService.returnsFeedInfo(queryString)
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
        <button
          className="btn btn-primary"
          disabled={this.state.loading}
          onClick={this.getInfo.bind(this)}
        >
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
          <Header>{"Resultados de Análise para o Feed"}</Header>
          {this.getSimulateThrottleBtn()}
        </div>
        {contents}
        <hr />
      </div>
    );
  }
}
