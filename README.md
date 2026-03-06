# 🔐 CheckPassword.API

API de autenticação desenvolvida em **ASP.NET Core** com foco em **segurança, autenticação e construção de APIs REST**.

O projeto implementa um fluxo completo de **registro de usuários, login e geração de token JWT**, além de rotas protegidas.

---

# 🚀 Tecnologias Utilizadas

- **C#**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQLite**
- **JWT (JSON Web Token)**
- **BCrypt** para criptografia de senha
- **Swagger / OpenAPI** para documentação da API

---

# 📦 Funcionalidades

✔ Registro de usuário  
✔ Senha armazenada com **criptografia BCrypt**  
✔ Autenticação de login  
✔ Geração de **token JWT**  
✔ Rotas protegidas utilizando **[Authorize]**  
✔ Persistência de dados com **Entity Framework + SQLite**  
✔ Documentação interativa com **Swagger**

---

# 🏗 Estrutura do Projeto

```
CheckPassword.API
│
├── Controllers
│   └── AuthController.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Entities
│   └── User.cs
│
├── Services
│   └── TokenService.cs
│
└── Program.cs
```

---

# ⚙️ Como executar o projeto

### 1️⃣ Clonar o repositório

```bash
git clone https://github.com/seu-usuario/checkpassword-api.git
```

### 2️⃣ Entrar na pasta do projeto

```bash
cd CheckPassword.API
```

### 3️⃣ Restaurar dependências

```bash
dotnet restore
```

### 4️⃣ Criar o banco de dados

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5️⃣ Executar a API

```bash
dotnet run
```

---

# 📚 Testando a API

Após executar o projeto, abra:

```
https://localhost:xxxx/swagger
```

No Swagger é possível testar todos os endpoints da API.

---

## Registro de usuário

`POST /api/auth/register`

```json
{
  "nome": "Hugo",
  "email": "hugo@email.com",
  "senha": "123456"
}
```

---

## Login

`POST /api/auth/login`

A resposta retornará um **token JWT**.

---

## Rota protegida

`GET /api/auth/me`

É necessário enviar o token no header:

```
Authorization: Bearer SEU_TOKEN
```

---

# 🔐 Segurança

O projeto utiliza:

- **BCrypt** para hash seguro de senhas
- **JWT** para autenticação baseada em token
- **[Authorize]** para proteger endpoints

---

# 🎯 Objetivo do Projeto

Este projeto foi desenvolvido com foco em:

- Conhecer a autenticação com **JWT**
- Trabalhar com **ASP.NET Core Web API**
- Utilizar **Entity Framework Core** com SQLite
- Aplicar boas práticas de desenvolvimento backend

---

# 👨‍💻 Autor

**Hugo Nascimento Gonçalves**

Estudante de **Ciência da Computação** com foco em desenvolvimento backend.
