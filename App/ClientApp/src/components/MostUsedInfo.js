import React from 'react';

export default (props) => {
    var words = props.words;

    return (
        <div>
            <h4>Palavras mais frequentes:</h4>
            <ul>
                {
                    words.map((word) => (
                        <li>
                            <span>Palavra: <b>{word.value}</b></span>
                            <span> - </span>
                            <span>Ocorrencias: <b>{word.count}</b></span>
                        </li>
                    ))
                }
            </ul>
        </div>
    )
}