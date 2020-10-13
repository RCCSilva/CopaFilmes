import React from 'react';
import {
    baseStyle,
    selectedStyle
} from './CheckBox.style'

const CheckBox = props => {
    return (
        <div
            data-testid='checkbox' 
            className={baseStyle + (props.selected ? selectedStyle : '')}>
        </div>
    );
};

export default CheckBox;