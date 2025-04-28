# Rota das Oficinas

# **✅ Objetivo do Projeto**

Criar uma **Web API em .NET 8.0** que gerencie **vendas, produtos e clientes** de um e-commerce, com base no template fornecido pela empresa **Rota das Oficinas**.

---

## 🔧 **Funcionalidades obrigatórias da API:**

- CRUD de **Clientes**, **Produtos** e **Vendas**
- **Login com autenticação via token (JWT)**, levando em conta os **cargos dos funcionários**
- **Paginação** com:
    - Filtros
    - Ordenação
    - Tamanho e quantidade de páginas
- Endpoints REST funcionando via **Postman ou ferramenta similar**
- Análise de vendas por período:
    - Total de vendas
    - Renda total
    - Renda por produto
- Seguir os padrões de código do **template**
- Utilização de **GitFlow** e **commits semânticos**

---

## 🌟 **Diferenciais:**

- **Frontend (painel administrativo)**:
    - Tela de **Login/Cadastro de usuários**
- **Dockerização da API**

# 💡 Ferramentas Utilizadas no Projeto:

### ⚙️ **Backend (.NET API)**

| Finalidade | Ferramenta/Tecnologia | Observação |
| --- | --- | --- |
| Framework principal | **.NET 8.0 (ASP.NET Core Web API)** | Base do projeto |
| Linguagem | **C#** |  |
| ORM | **Entity Framework Core** | Acesso ao banco |
| Banco de Dados | PostgreSQL |  |
| Autenticação e Token | **JWT (JSON Web Token)** | Controle de login e cargos |
| Documentação da API | **Swagger** | Já vem no template |

### 🌐 **Frontend (ReactJS)**

| Finalidade | Ferramenta/Tecnologia | Observação |
| --- | --- | --- |
| Framework Frontend | **React.js**  |  |
| Comunicação com a API | **Axios** | Requisições HTTP |
