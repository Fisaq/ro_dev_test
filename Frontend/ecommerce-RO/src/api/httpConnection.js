import axios from 'axios';

const connect = axios.create({
    baseURL: import.meta.VITE_API_URL
});

export default connect;