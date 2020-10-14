# Copa Filmes

Projeto para gerenciar uma copa de filmes. O usuário seleciona 8 filmes e, de acordo com notas preestabelecidas, obtém o filme vencedor e o segundo lugar.

## 1. Rodando os serviços em ambiente local

Inicie os serivços com `docker-compose up` e acesse `http://localhost:5000`.

Caso você opte por rodar "manualmente" com VisualStudio ou `dotnet run`, verifique qual a porta que está sendo utilizada. Talvez você precise alterar a variável `baseServiceUrl` dentro de `frontend/src/config.js` para garantir as chamadas da página web com o _backend_.

## 2. Resumo

O sistema está separado em dois projetos. O `backend` foi desenvolvido com `.NET Core 3.1`, enquanto o `frontend`, com `React 16.13.1`.

### 2.1. Backend

#### 2.1.1. Resumo

Basicamente, o modelo adotado segue o sentindo fluxo de dados: `Controllers -> Services -> Builders`. Isto é, a entrada de dados é pelos _endpoints_ definidos na pasta `Controllers` que somente definem os protocolos de comunicação externa, no caso, HTTP. Em seguida, os `Controllers` fazem as devidas chamadas para os classes de serviço (pasta `Services`), que são responsáveis por aplicar a lógica de negócio. Por fim, as lógicas que dizem respeito a __criação__ de objetos está definida dentro da pasta `Builders`. As classes que representam o domínio estão definidas na pasta `Models`.

A entidade básica é o `WorldCup`. Uma copa do mundo (`WorldCup`) contém um jogo de copa do mundo (`WorldCupGame`), que por sua vez contém referências para os outros jogos que o precederam (`PriorGameA`, `PriorGameB`) e uma referência para a partida (`Game`). O jogo (`Game`) é o "embate" entre dois filmes (`Movie`), que no momento é decidido pela nota (`Movie#Rating`) do filme. Embora fosse possível ter a lógica de `Game` e `WorldCupGame` em uma única classe, entendi que se tratavam de dois conceitos distintos. De um lado, você possui a ideia de um jogo de copa do mundo, ou seja, um jogo que possui outros antecendentes que explicam o porquê de vermos dois filmes em uma determinada partida (`Game`). Por outro lado, não necessariamente toda partida (`Game`) é uma partidade de copa do mundo (`WorldCupGame`) e separar isso uma class a parte (`Game`) me permite ter mais versatilidade para criar jogos de diferentes maneiras caso seja necessário.

#### 2.1.2. Classes e Funcionalidades

Os _endpoints_ disponíveis dentro da pasta `Controllers`:

- `GET /movie`: Devolve uma lista com os filmes disponíveis.
- `POST /worldcup`: Recebe uma lista de IDs dos filmes para criar uma copa do mundo.

`Services` disponíveis:

- `MovieService`:
    - `GetAll`: Retorna todos os filmes disponíveis.
    - `GetByMovieId`: Retorna os filmes de acordo com uma lista de IDs.

- `WorldCupService`:
    - `Create`: Cria um um objeto `WorldCup` dado uma lista de filmes.

`Builders` disponíveis:
    - `WorldCupBuilder`: Responsável por retornar um objeto `WorldCup` dado uma lista de filmes (`Movie`).
    - `WorldCupGamerBuilder`: Retornar um `WorldCupGame` a partir de uma lista de filmes (`Movie`).

### 3.2. Frontend

No front, a ideia é seguir o seguinte fluxo: `Views -> Components -> Services`. Uma `View` controla o que será mostrado para o usuário em uma determinada rota. No caso, a rota `/` traz a visualização necessária para selecionar os filmes e a rota `/result` traz o resultado final, desde que o usuário tenha selecionado anteriormente os filmes para a Copa do Mundo. Se não o tiver feito, o usuário é redirecionado para a rota `/`.