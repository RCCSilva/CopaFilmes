import React from 'react';
import { Redirect } from 'react-router-dom';
import Header from '../components/header/Header';
import ResulCard from '../components/result/result-card/ResultCard';

const selectionTitle = 'Resultado Final';
const selectionSubTitle = 'Veja resultado final do Campeonato de filmes de forma simples e rápida';

const ResultView = props => {
    if (props.worldCup === null) {
        return (
            <Redirect to={'/'}/>
        );
    };

    return (
        <div>
            <Header
                title={selectionTitle}
                subTitle={selectionSubTitle}/>
            <div className='mt-16'>
                <ResulCard place={'1º'} movieName={props.worldCup.worldCupGame.game.winner.title}/>
                <ResulCard place={'2º'}  movieName={props.worldCup.worldCupGame.game.looser.title}/>
            </div>
        </div>
    );
}

export default ResultView;