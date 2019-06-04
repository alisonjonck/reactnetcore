import React from 'react';
import Text from '../../Atoms/Text/Text';

export default (props) => {
    return (
        <table className='table table-striped'>
        <thead>
          <tr>
            {props.headers.map((header, index) => <td key={index}><Text bold>{header}</Text></td>)}
          </tr>
        </thead>
        <tbody>
          {
            props.rows.map(row => (
                <tr key={row[0]}>  
                    {row.map((value, index) => <td key={index}><Text>{value}</Text></td>)}
                </tr>
            ))
          }
        </tbody>
      </table>
    );
}