import React, { useState, useEffect } from 'react';
import { Redirect } from 'react-router-dom';
import { getMovies } from '../../../services/MovieService';
import { createWorldCup } from '../../../services/WorldCupService';
import SelectionBox from '../selection-box/SelectionBox';
import {
    boxStyle,
    errorMessageStyle,
    headerBoxStyle,
    selectedBoxStyle,
    createWorldCupButtonStyle,
    selectionBoxRowsStyle
} from './SelectionForm.style';

const maxMovieAmount = 8;

const SelectionForm = props => {
    const [movies, setMovies] = useState([]);
    const [selectedMovies, setSelectedMovies] = useState([]);
    const [redirectToResult, setRedirectToResult] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');

    useEffect(() => {
        if (movies.length === 0) {
            getMovies()
                .then(response => setMovies(response.data))
                .catch(error => console.log(error))
        }
    }, [movies]);

    const addSelectedMovie = (movie, afterEffects) => {
        if (selectedMovies.length < maxMovieAmount) {
            setSelectedMovies(selectedMovies.concat(movie.id));
            afterEffects();
        };
    };

    const removeSelectedMovie = movie => {
        setSelectedMovies(selectedMovies.filter(movieId => movieId !== movie.id));
    };

    const buildSelectionBox = () => {
        const selectionBoxes = movies.map(movie => {
            console.log(movie.id);
            return (
                <SelectionBox
                    key={movie.id}
                    addHandler={(afterEffects) => addSelectedMovie(movie, afterEffects)}
                    removeHandler={() => removeSelectedMovie(movie)}
                    title={movie.title} 
                    year={movie.year}/>
            )
        })

        return selectionBoxes;
    }

    const createWorldCupHandler = async () => {
        if (selectedMovies.length === maxMovieAmount) {
            await createWorldCup(selectedMovies)
                .then(response => props.createWoldCupHandler(response.data))
                .catch(error => console.log(error));
            
            setRedirectToResult(true);
        } else {
            setErrorMessage('Por favor, selecione 8 filmes antes de gerar o campeonato!')
        };
    };

    const createErrorMessageBox = () => {
        return (
            <div className={errorMessageStyle}>
                {errorMessage}
            </div>
        );
    };

    return (
        <div className={boxStyle}>

            {redirectToResult ? <Redirect to={'/result'}/> : <div></div>}

            {errorMessage ? createErrorMessageBox() : <div></div>}
           
            <div className={headerBoxStyle}>
                <div className={selectedBoxStyle}>
                    <p>Selecionados</p>
                    <p>{selectedMovies.length} de 8 filmes</p>
                </div>
                <button
                    onClick={createWorldCupHandler}
                    className={createWorldCupButtonStyle}>
                    GERAR MEU CAMPEONATO
                </button>
            </div>

            <div className={selectionBoxRowsStyle}>
                {buildSelectionBox()}
            </div>
        </div>
    );
}

export default SelectionForm;