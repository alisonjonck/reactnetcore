import React from 'react';
import ReactDOM from 'react-dom';
import FeedbackMessage from '../../../components/Mols/FeedbackMessage/FeedbackMessage';

it('renders without crashing', () => {
    const div = document.createElement('div');
    ReactDOM.render(
        <FeedbackMessage />
        , div);
});
