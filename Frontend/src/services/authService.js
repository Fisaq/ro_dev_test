import connect from "./api";

const apiURL = import.meta.env.VITE_API_URL;

export const loginUser = (username, password) => {
    return connect.post(`${apiURL}/api/auth/login`, {
        username, 
        password
    })
};