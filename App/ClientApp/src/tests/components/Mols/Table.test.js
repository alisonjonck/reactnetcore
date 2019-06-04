import React from 'react';
import ReactDOM from 'react-dom';
import Table from '../../../components/Mols/Table/Table';

it('renders without crashing', () => {
    const div = document.createElement('div');
    ReactDOM.render(
        <Table headers={["Header 1"]} rows={[["Row 1 value"]]} />
        , div);
});
