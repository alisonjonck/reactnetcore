import React from 'react';
import ReactDOM from 'react-dom';
import FeedInfoTable from '../../../components/Orgs/FeedInfoTable/FeedInfoTable';

it('renders without crashing', () => {
    const div = document.createElement('div');
    ReactDOM.render(
        <FeedInfoTable title={["Titulo 1"]} topics={
            [{
                "value": "value",
                "valueWithoutPrepositions": "valueWithoutPrepositions",
                "wordCount": "wordCount",
                "wordCountWithoutPrepositions": "wordCountWithoutPrepositions",
            }]}
        />
        , div);
});
