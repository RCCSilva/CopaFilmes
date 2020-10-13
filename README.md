# Copa Filmes

Projeto para gerenciar uma copa de filmes. O usuário seleciona 8 filmes e, de acordo com notas preestabelecidas, obtém o filme vencedor e o segundo lugar.

## 1. Rodando os serviços em ambiente local

Inicie os serivços com `docker-compose up` e acesse `http://localhost:9876`.

## 2. Rodando os testes de backend e frontend

```
docker-compose -f docker-compose.test.yml run
```

## 3. Resumo

O sistema está separado em dois projetos. O `backend` foi desenvolvido com `.NET Core 3.1`, enquanto o `frontend`, com `React`.

### 3.1. Backend

Basicamente, o modelo adotado segue o sentindo fluxo de dados: `Controllers -> Services -> Builders`. Isto é, a entrada de dados é pelos _endpoints_ definidos na pasta `Controllers` que somente definem os protocolos de comunicação externa, no caso, HTTP. Em seguida, os `Controllers` fazem as devidas chamadas para os classes de serviço (pasta `Services`), que são responsáveis por aplicar a lógica de negócio. Por fim, as lógicas que dizem respeito a __criação__ de objetos está definida dentro da pasta `Builders`. As classes que representam o domínio estão definidas na pasta `Models`.

Os _endpoints_ disponíveis dentro da pasta `Controllers`:

- `GET /movie`: Devolve uma lista com os filmes disponíveis.
- `POST /worldcup`: Recebe uma lista de IDs dos filmes para criar uma copa do mundo.

`Services` disponíveis:

- `MovieService`:
    - `GetAll`: Retorna todos os filmes disponíveis.
    - `GetByMovieId`: Retorna os filmes de acordo com uma lista de IDs.

- `WorldCupService`:
    - `Create`: Cria um um objeto `WorldCup` dado uma lista de filmes.

### 3.2. Frontend
