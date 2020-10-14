import axios from 'axios';
import { baseServiceUrl } from '../config';

const api = axios.create({
    baseURL: baseServiceUrl
});

export default api;