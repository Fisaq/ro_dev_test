import { use } from "react";
import connect from "./api";

const apiURL = import.meta.env.VITE_API_URL;

export const loginUser = (username, password) => {
    return connect.post(`${apiURL}/api/auth/login`, {
        username, 
        password
    })
};

export const registerUser = (username, password, confirmPswd) => {
    if (password == confirmPswd){
        return connect.post(`${apiURL}/api/auth/register`, {
            username,
            confirmPswd
        });
    }
}