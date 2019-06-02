import React from 'react';

export default (props) => {
  var topics = props.topics;

  return (
    <React.Fragment>
      <h4>Palavras importantes (últimos 10 posts)</h4>
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
    </React.Fragment>
  );
}
