import React from 'react';
import ContentHeader from '../../Atoms/ContentHeader/ContentHeader';
import Text from '../../Atoms/Text/Text';

export default (props) => {
    var words = props.words;

    return (
        <div>
            <ContentHeader>{"Palavras mais frequentes:"}</ContentHeader>
            <ul>
                {
                    words.map((word, index) => (
                        <li key={index}>
                            <Text>
                                <b>{word.value}</b>
                                {" - Ocorrência(s): "}
                                <b>{word.count}</b>
                            </Text>
                        </li>
                    ))
                }
            </ul>
        </div>
    )
}