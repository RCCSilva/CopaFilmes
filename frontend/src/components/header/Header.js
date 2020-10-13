import React from 'react';
import { 
    outerBoxStyle,
    innerBoxStyle,
    superTitleStyle,
    titleStyle,
    divisionStyle,
    subTitleStyle
} from './Header.style';

const Header = (props) => {
    return (
        <div className={outerBoxStyle}>
            <div className={innerBoxStyle}>
                <p data-testid='header-supertitle' className={superTitleStyle}>CAMPEONATO DE FILMES</p>
                <p data-testid='header-title' className={titleStyle}>{props.title}</p>
                <div className={divisionStyle}>-</div>
                <p data-testid='header-subtitle' className={subTitleStyle}>{props.subTitle}</p>
            </div>
        </div>
    );
}

export default Header;