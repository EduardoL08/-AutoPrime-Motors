# 🚗 AutoPrime Motors

> Sistema web completo para gerenciamento de concessionária de veículos.  
> Projeto acadêmico — Arquitetura de Aplicações Web 2026.1

---

## 📋 Sobre o Projeto

A **AutoPrime Motors** é uma plataforma de gestão para concessionárias de automóveis. O sistema permite o cadastro e gerenciamento de veículos, clientes e usuários com controle de acesso por perfil (admin/user).

---

## 🏗️ Arquitetura

```
autoprime-motors/
├── backend/                  # ASP.NET Core Web API (.NET 10)
│   ├── AutoPrime.API/
│   │   ├── Controllers/      # Endpoints REST
│   │   ├── Services/         # Regras de negócio
│   │   ├── Repositories/     # Acesso ao MongoDB
│   │   ├── Models/           # Entidades do domínio
│   │   ├── DTOs/             # Objetos de transferência
│   │   ├── Configurations/   # Configurações (Mongo, Swagger, JWT)
│   │   └── Middleware/       # Middlewares customizados
│   └── Dockerfile
├── frontend/                 # React + Vite
│   └── ...
├── mongo-init/               # Script de inicialização do MongoDB
├── docker-compose.yml
└── README.md
```

### Padrões utilizados

| Camada | Responsabilidade |
|--------|-----------------|
| **Controllers** | Receber requisições HTTP, retornar respostas |
| **Services** | Regras de negócio, orquestração |
| **Repositories** | Abstrair acesso ao banco de dados |
| **DTOs** | Trafegar dados entre camadas/cliente |
| **Models** | Representar entidades do domínio |

---

## 🛠️ Tecnologias

### Backend
- .NET 10 / ASP.NET Core Web API
- C# 13
- MongoDB 7.0 (NoSQL)
- JWT Authentication
- Swagger/OpenAPI
- xUnit (testes)
- FluentValidation
- BCrypt (hash de senhas)

### Frontend
- React 18
- React Router v6
- Axios
- Zustand (gerenciamento de estado)
- Tailwind CSS

### Infraestrutura
- Docker
- Docker Compose
- Mongo Express (UI do MongoDB)

---

## 🚀 Como Executar

### Pré-requisitos
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado
- Porta 5000, 27017 e 8081 disponíveis

### Subir o projeto completo

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/autoprime-motors.git
cd autoprime-motors

# Sobe todos os containers
docker compose up --build
```

### Acessos

| Serviço | URL |
|---------|-----|
| **API / Swagger** | http://localhost:5000 |
| **Mongo Express** | http://localhost:8081 |
| **Frontend** | http://localhost:3000 |

---

## 🔌 Variáveis de Ambiente

| Variável | Descrição | Padrão |
|----------|-----------|--------|
| `MongoDbSettings__ConnectionString` | String de conexão MongoDB | `mongodb://...` |
| `MongoDbSettings__DatabaseName` | Nome do banco | `autoprimemotors` |
| `JwtSettings__SecretKey` | Chave secreta JWT | — |
| `JwtSettings__ExpirationInHours` | Expiração do token (horas) | `8` |

---

## 📡 Endpoints Principais

### Health Check
```
GET /api/health
```

### Veículos *(próximas etapas)*
```
GET    /api/veiculos
GET    /api/veiculos/{id}
POST   /api/veiculos
PUT    /api/veiculos/{id}
DELETE /api/veiculos/{id}
```

### Clientes *(próximas etapas)*
```
GET    /api/clientes
GET    /api/clientes/{id}
POST   /api/clientes
PUT    /api/clientes/{id}
DELETE /api/clientes/{id}
```

### Autenticação *(próximas etapas)*
```
POST   /api/auth/register
POST   /api/auth/login
```

---

## 👥 Perfis de Acesso

| Perfil | Permissões |
|--------|-----------|
| **admin** | CRUD completo |
| **user** | Apenas leitura |

---

## 🧪 Testes

```bash
cd backend
dotnet test
```

---

## 📄 Licença

Projeto acadêmico — Sistemas de Informação 2026.1
