import api from '../utils/api';

const getMovies = () => {
    return api.get('/movie');
}

export { getMovies };