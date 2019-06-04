import React from 'react';
import ContentHeader from '../../Atoms/ContentHeader/ContentHeader';
import Table from '../../Mols/Table/Table';

const headers = [
  "Título",
  "Título sem artigos/prep.",
  "Qtd. de palavras",
  "Qtd. de palavras sem artigos/prep."
];

const getRows = (topics) => {
  return topics.map(topic => [
    topic.value,
    topic.valueWithoutPrepositions,
    topic.wordCount,
    topic.wordCountWithoutPrepositions
  ]);
};

export default (props) => {
  const rows = getRows(props.topics);

  return (
    <React.Fragment>
      <ContentHeader>{props.title}</ContentHeader>
      <Table headers={headers} rows={rows} />
    </React.Fragment>
  );
}
