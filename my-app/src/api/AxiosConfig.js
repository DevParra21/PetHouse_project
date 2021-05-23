import axios from 'axios';

export const axiosBase = axios.create({
    baseURL:"https://localhost:44337/api"
});