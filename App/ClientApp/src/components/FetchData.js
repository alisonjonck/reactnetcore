import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor (props) {
    super(props);
    this.state = { topics: [], loading: true };

    fetch('api/FeedData/ReturnsFeedInfo')
      .then(response => response.json())
      .then(data => {
        this.setState({ topics: data.topics, loading: false });
      });
  }

  static renderForecastsTable (topics) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Título</th>
            <th>Título sem artigos/prep.</th>
            <th>Qtd. de palavras</th>
            <th>Qtd. de palavras sem artigos/prep.</th>
          </tr>
        </thead>
        <tbody>
          {topics.map(topic =>
            <tr key={topic.value}>
              <td>{topic.value}</td>
              <td>{topic.valueWithoutPrepositions}</td>
              <td>{topic.wordCount}</td>
              <td>{topic.wordCountWithoutPrepositions}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.topics);

    return (
      <div>
        <h1>Resultados de Análise para o Feed</h1>
        <p>Abaixo seguem informações detalhadas das análises realizadas nos últimos 10 tópicos listados no feed de notícias da Minuto Serguros.</p>
        {contents}
      </div>
    );
  }
}
