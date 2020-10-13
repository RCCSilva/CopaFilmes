import axios from 'axios';

const api = axios.create({
    baseURL: "http://localhost:50986"
});

export default api;