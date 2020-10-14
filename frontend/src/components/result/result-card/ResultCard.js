import React from 'react';
import {
    boxStyle,
    placeHolderStyle,
    titleHolderStyle,
    titleTextStyle
} from './ResultCard.style';

const ResulCard = props => {
    return (
        <div className={boxStyle}>
            <div data-testid='place' className={placeHolderStyle}>
                {props.place}
            </div>
            <div className={titleHolderStyle}>
                <p data-testid='movieName' className={titleTextStyle}>{props.movieName}</p>
            </div>
        </div>
    );
};

export default ResulCard;