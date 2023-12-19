# UMBIT.UsersBlogs.API
## Descrição
Este repositório contém uma aplicação .NET Core que utiliza o banco de dados MariaDB e pode ser executada facilmente usando Docker Compose. O Docker Compose simplifica o processo de execução da aplicação e do banco de dados com uma única linha de comando.

## Requisitos
.NET Core SDK
Docker
Docker Compose
## Configuração do Banco de Dados
Caso a execução seja LOCAL cetitifique de ter o BD intalado e configure as informações de conexão no arquivo appsettings.json ou secret.json:

```console
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=mariadb;Port=3306;Database=seu_banco_de_dados;User=seu_usuario;Password=sua_senha;"
  }
}
```

Substitua seu_banco_de_dados, seu_usuario e sua_senha pelos valores apropriados. Se a execução for via DOCKER essa informação é passada por varaivel de ambiente no arquivo docker compose. 

## Executando a Aplicação via Docker Compose
Abra um terminal na raiz do projeto.

Execute o seguinte comando para construir e iniciar os contêineres definidos no arquivo docker-compose.yml:

```console
docker-compose up -d
```
Isso iniciará a aplicação .NET Core e o MariaDB em contêineres separados.

Acesse a aplicação em http://localhost:4950/swagger.

## Desenvolvimento Local
Para executar a aplicação localmente sem Docker Compose, utilize o seguinte comando na raiz do projeto:

bash
Copy code
dotnet run
Acesse a aplicação em http://localhost:4950.
