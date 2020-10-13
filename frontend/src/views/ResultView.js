import React from 'react';
import { Redirect } from 'react-router-dom';
import Header from '../components/header/Header';

const selectionTitle = 'Resultado Final';
const selectionSubTitle = 'Veja resultado final do Campeonato de filmes de forma simples e rápida';

const ResulCard = props => {
    return (
        <div className='flex w-full w-32 mt-4'>
            <div className='px-4 py-4 bg-gray-700 text-center font-bold text-white text-4xl'>
                {props.place}
            </div>
            <div className='w-full pl-16 bg-white text-xl'>
                <p className='my-auto'>{props.movieName}</p>
            </div>
        </div>
    );
}

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