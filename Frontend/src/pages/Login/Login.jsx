import { useState } from "react";
import {loginUser} from "../../services/authService";
import { useNavigate } from "react-router-dom";
import './Login.css'

function Login() {
    const [username, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const goToRegister = () => {
        navigate('/register');  
      };

    const handleLogin = async (e) => {
        e.preventDefault();
        try{
            const response = await loginUser(username, password);
            console.log('Logged', response.data);
            alert('Login realizado com sucesso!')
        }catch (error){
            console.log('Error during login: ', error);
            alert('Erro de autenticacao: Revise o login ou a senha.')
        }
    }
    return(
        <div className="login-container-master">

            <div class="titulo-top">
                <h1 class="boasvindas">Bem vindo ao <span class="detalhe-boasvindas">ConectaCliente</span> </h1>
                <h2 class="subtitulo">Seu sistema de gerenciamento de Ecommerce</h2>
            </div>

            <div class="login-container">
                <h1>Login</h1>
                <form onSubmit={handleLogin}>
                    <input type="username" value={username} onChange={e => setUserName(e.target.value)} placeholder="Username" />
                    <input type="password" value={password} onChange={e => setPassword(e.target.value)} placeholder="Senha" />
                    <button type="submit">Entrar</button>
                </form>
                <p>Não possui acesso? <a href="#" onClick={goToRegister}><span>Cadastre-se!</span></a></p>
            </div>

        </div>
        
    );
}

export default Login;