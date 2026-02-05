# API de Clientes

API simples em .NET 8 para cadastro e listagem de clientes, utilizando Controllers e Entity Framework Core com SQLite.

## 🚀 Tecnologias Utilizadas

- **.NET 8 SDK**
- **ASP.NET Core Web API (Controllers)**
- **Entity Framework Core 8**
- **SQLite**
- **AutoMapper**
- **Swagger/OpenAPI**

## 🔧 Decisões Técnicas

1.  **Arquitetura e DTOs**: O projeto utiliza **DTOs** para desacoplar as entidades de domínio (`Cliente`) dos contratos externos da API (`ClienteDto`, `ClienteCreateDto`). Isso melhora a segurança e permite evoluir o modelo de dados sem quebrar a API.
2.  **AutoMapper**: Implementado para realizar a conversão automática entre Entidades e DTOs, reduzindo código repetitivo e simplificando os Controllers.
3.  **Entity Framework Core**:
    - **Fluent API**: As configurações de validação e mapeamento do banco de dados (chaves, índices únicos, tamanhos de campo) foram centralizadas no `OnModelCreating` do `ClientesDbContext`, mantendo as classes de domínio limpas.
4.  **Validação e Tratamento de Erros**:
    - **Data Annotations**: Usadas nos DTOs de entrada para garantir dados válidos (ex: formato de email, campos obrigatórios).
    - **Status HTTP**: A API retorna `409 Conflict` para emails duplicados e `201 Created` para sucessos, seguindo boas práticas REST.
5.  **Persistência**: Utilização do SQLite por ser leve e não exigir instalação de servidor de banco de dados. O banco é criado automaticamente na inicialização (`EnsureCreated`).

## 🏃 Como Rodar o Projeto

### Pré-requisitos
- .NET 8 SDK instalado

### Passos

1.  Clone o repositório ou navegue até a pasta do projeto.
2.  Execute o comando para rodar a aplicação:
    ```bash
    dotnet run
    ```
3.  Acesse o Swagger para testar os endpoints:
    - URL: `https://localhost:5000/swagger`.

## 📌 Endpoints

### 1️⃣ Cadastrar cliente
**POST** `/Clientes`

Corpo da requisição (JSON):
```json
{
  "nome": "João Silva",
  "email": "joao@email.com"
}
```

### 2️⃣ Listar clientes
**GET** `/Clientes`

Retorna a lista de todos os clientes cadastrados.
# ApiClientes
