import React from 'react';
import ReactDOM from 'react-dom';
import MostUsedInfo from '../../../components/Orgs/MostUsedInfo/MostUsedInfo';

it('renders without crashing', () => {
    const div = document.createElement('div');
    ReactDOM.render(
        <MostUsedInfo words={[{
            value: 'word count',
            count: 2
        }]}
        />
        , div);
});
