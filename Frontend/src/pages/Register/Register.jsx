import { useState } from "react";
import {registerUser} from "../../services/authService"
import { useNavigate } from "react-router-dom"
import './Register.css'

function Register() {
    const [username, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPswd, setConfirmPswd] = useState('');
    const navigate = useNavigate();

    const goToLogin = () => {
        navigate('/login');
      };

    const handleRegister = async (e) => {
        e.preventDefault();
        try{
            const response = await registerUser(username, password, confirmPswd);
            console.log('Registed', response.data);
            alert('Registro realizado com sucesso!')
        }catch (error){
            console.log('Error during register: ', error);
            alert('Erro durante cadatro.')
        }
    }
    return(
        <div className="register-container-master">

            <div class="titulo-top">
                <h1 class="boasvindas">Bem vindo ao <span class="detalhe-boasvindas">ConectaCliente</span> </h1>
                <h2 class="subtitulo">Seu sistema de gerenciamento de Ecommerce</h2>
            </div>

            <div class="register-container">
                <h1>Cadastro</h1>
                <form onSubmit={handleRegister}>
                    <input type="username" value={username} onChange={e => setUserName(e.target.value)} placeholder="Username" />
                    <input type="password" value={password} onChange={e => setPassword(e.target.value)} placeholder="Senha" />
                    <input type="password" value={confirmPswd} onChange={e => setConfirmPswd(e.target.value)} placeholder="Confirme a senha" />
                    <button onClick={goToLogin} type="submit">Cadastrar</button>
                </form>
            </div>

        </div>
        
    );
}

export default Register;