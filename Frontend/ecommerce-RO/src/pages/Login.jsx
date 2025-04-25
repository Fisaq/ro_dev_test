import { useState } from "react";
import { loginUser } from "../api/userApi";

function Login() {
    const [username, setUserName] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = async (e) => {
        e.preventDefault();
        try{
            const response = await loginUser(username, password);
            console.log('Logged', response.data);
        }catch (error){
            console.log('Error during login: ', error);
        }
    }
    return(
        <form onSubmit={handleLogin}>
            <input type="username" value={username} onChange={e => setUserName(e.target.value)} />
            <input type="password" value={password} onChange={e => setPassword(e.target.value)} />
            <button type="submit">Entrar</button>
        </form>
    );
}

export default Login;