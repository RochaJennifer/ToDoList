# 🚀 ToDoList API 

Este projeto foi desenvolvido como um laboratório prático para o meu aprofundamento no ecossistema **.NET**e **C#**.

## 🎨 Interface do Projeto
Abaixo, a demonstração da interface personalizada da API:

![Preview da API Lilás](Interface API.png)

## 🛠️ Tecnologias e Ferramentas

* **Linguagem**: C#.
* **Framework**: ASP.NET Core 10.
* **Banco de Dados**: PostgreSQL para persistência de dados relacional.
* **ORM**: Entity Framework Core (Code-First).
* **Interface**: Documentação Swagger UI customizada via CSS.
* **Ambiente de Desenvolvimento**: Linux (Debian).

## 🧠 Desafios Técnicos e Aprendizados

1. **Injeção de Dependência (DI)**: Configurei o ciclo de vida do contexto do banco de dados no `Program.cs`, garantindo um código mais desacoplado e fácil de manter.
2. **Persistência de Dados**: Migrei a lógica de armazenamento de uma lista estática em memória para uma estrutura no PostgreSQL.
3. **Gerenciamento de Migrations**: Utilizei o EF Core para versionar e aplicar o schema do banco de dados diretamente pelo terminal.
4. **Customização de UI**: Injetei estilos personalizados no Swagger através da `wwwroot` para criar uma interface lilás com alta legibilidade, facilitando o processo de testes das rotas.

## 📂 Estrutura do Projeto

* `/Controllers`: Lógica de gerenciamento das rotas da API.
* `/Data`: Configuração do contexto do banco de dados (EF Core).
* `/Entities`: Modelagem da entidade `Tarefa`.
* `/wwwroot`: Arquivos estáticos de design (CSS personalizado).

## 💻 Como Executar

```bash
# Clone o repositório
git clone [https://github.com/seu-usuario/seu-repositorio.git](https://github.com/seu-usuario/seu-repositorio.git)

# Atualize a connection string no appsettings.json
# Execute as migrations
dotnet ef database update

# Inicie a aplicação
dotnet run
