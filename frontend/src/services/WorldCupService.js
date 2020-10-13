import api from '../utils/api';

const createWorldCup = movies => {
    return api.post('/worldcup', {movies: movies});
}

export { createWorldCup };