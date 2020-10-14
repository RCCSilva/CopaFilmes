import React, { useState } from 'react';
import CheckBox from '../check-box/CheckBox';
import {
    boxStyle,
    innerBoxStyle,
    yearStyle
} from './SelectionBox.style';

const SelectionBox = props => {
    const [selected, setSelected] = useState(false);

    const afterClickEffects = () => setSelected(!selected);

    const clickHandler = () => {
        
        if (selected) {
            props.removeHandler();
            afterClickEffects()
        } else {
            props.addHandler(afterClickEffects);
        }
    }

    return (
        <div
            onClick={clickHandler} 
            className={boxStyle}>
            <div>
                <CheckBox selected={selected}/>
            </div>
            <div className={innerBoxStyle}>
                <p data-testid='title'>{props.title}</p>
                <p data-testid='year' className={yearStyle}>{props.year}</p>
            </div>
        </div>
    );
};

export default SelectionBox;