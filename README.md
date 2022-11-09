# Projeto-Minsait
Formação .Net e Angular - Minsait/Uniesp 10/202  
Ministrada pelo Professor:  [Rodolpho Pedra](https://www.linkedin.com/in/rodolphopedra/)
---
Esté repositorio é destinado para aplicação back and de desenvolver uma API utilizando dotnet 6 com Swagger, acesso ao banco de dados com Entity Framework.   
Deve conter as funções de CRUD:
- Ler
- Criar
- Atualizar
- Deletar
Desejável: aplicação em Docker
Tema: livre de sua Escolha.

# Aplicação 
## Aluno: Romenildo do Vale Ferreira 
#### Aplicação desenvolvida em:
<p align="center">
  
  ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
  ![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)
  ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Sever-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
  ![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)
 </p>
 
 Consistem em um Sistema de controle de Onibus de uma Rodoviaria. Onde pode vincular ônibus, Motoristas, Passageiros e Passagens;
 E assim gerenciando as importantes informações sobre as viagens e passageiros nos ônibus.

 # Como executar no docker Compose


## Pre-requisitos

- Docker Engine 19.03.7+

    - **Linux:** Follow all the steps present in the [official documentation](https://docs.docker.com/install/linux/docker-ce/ubuntu/#install-docker-ce)

    - **Windows:** Follow all the steps present in the [official documentation](https://docs.docker.com/docker-for-windows/install/#about-windows-containers)
- Docker Compose 1.25.4+
    -  Follow all the steps present in the [official documentation](https://docs.docker.com/compose/install/)

## Clonando o projeto

* Clone
```sh
git clone https://github.com/Romenildo/Projeto-Minsait.git

Ou com SSH

git clone git@github.com:Romenildo/Projeto-Minsait.git
```

## Environment variables

O arquivo `.env.example` especifica todas as variáveis de ambiente necessárias, copie e cole com o arquivo ` .env.example` chamado` .env` para fazer o Docker Compose usar as variáveis de ambiente definidas neste arquivo:

```sh
cp .env.example .env
```

## Construindo e iniciando o Container

```sh
docker-compose up --build
 ```

Ele irá construir os containers e rodar a plataforma conforme especificado no arquivo `docker-compose.yml`, abrindo uma tela de log com os logs de todos os serviços iniciados.

##### Parando a Execução


Para parar todos os containers criados pelo docker-compose, você precisa ir até a pasta onde está o docker-compose.yml e executar:
```sh
docker-compose down
 ```

Para parar somente um container:

```ssh
docker stop my_container
 ```
 
 # Documentação
 
 
## Diagrama de Classe v2
<p align="center">
  <img src="https://github.com/Romenildo/Treinamento-GIT/blob/master/diagramaDeClassev2.png" alt="Diagrama de Classe">
</p>

## Requisitos
### Requisitos gerais do sistema:
- Req_01: CRUD de Motoristas;✔️
- Req_02: Motorista só está associado a um Onibus;✔️
- Req_03: Motorista deve possuir uma cnh;✔️
- Req_04: CRUD de Cobradores;✔️
- Req_05: Cobrador só está associado a um Onibus;✔️
- Req_05: CRUD de Onibus;✔️
- Req_06: Onibus deve possuir Motorista, cobrador e a Passagem com a lista de Passageiros;✔️
- Req_07: CRUD de Passagens;✔️
- Req_08: CRUD de Passagens deve possuir o valor de cada destino;✔️
- Req_09: CRUD de Passagens na hora da compra deve calcular o seguro e tarifa do Passageiro;✔️
- Req_10: CRUD de Passagens deve gerar um qrCode final com as informações para o Passageiro;
- Req_11: CRUD de Passageiros;✔️
- Req_12: CRUD de Passageiros podem comprar passagens;✔️
- Req_13: CRUD de Passageiros podem cancelar sua passagem;
- Req_14: CRUD de Passageiros deve possuir a opçao de querer seguro(taxa: 4.50) ou não;✔️
- Req_15: CRUD de Passageiros com tipo de tarifa (Estudante) possuem 50% de desconto no proço final da passagem;✔️



## Caso de Uso

<p align="center">
  <img src="https://github.com/Romenildo/Treinamento-GIT/blob/master/CasoDeUso.png" alt="Caso de Uso">
</p>


## Fontes: 

[Aula 1 Rodolpho](https://freeleaf.notion.site/08-10-Introducao-NET-a992a090127c4f5b8b83377ba1f6c1f1)   
[Aula 2 Rodolpho](https://freeleaf.notion.site/22-10-Clean-code-e4e7e66a940442b192394fdc181faf7e)   
   
[Clean Code](https://balta.io/blog/clean-code )   
[Iniciar uma APi com aspNet 6.0(balta.io)](https://www.youtube.com/watch?v=QzCSN9wN4JA&t=1331s&ab_channel=balta.io)   
[Iniciar uma APi com aspNet 6.0](https://www.youtube.com/watch?v=2TxePNK0kc8&t  )   
[Fluent API](https://learn.microsoft.com/pt-br/ef/ef6/modeling/code-first/fluent/types-and-properties )
[Mapeamento](https://www.youtube.com/watch?v=PgEFUvHrxSE&ab_channel=CodingNight)           
                        
[Relacionamentos]( https://www.freecodecamp.org/portuguese/news/um-otimo-guia-sobre-como-construir-apis-rest-com-asp-net-core/)      
[Relacionamentos one-to-one](https://cursos.alura.com.br/forum/topico-relacionamento-one-to-one-no-entity-no-codefirst-38788)   
   
[Dtos](https://learn.microsoft.com/pt-br/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5)   
[Dtos video](https://www.youtube.com/watch?v=XJzbNj3_cqc&t=32s&ab_channel=PabloCodes)   
   
[Automapper](https://automapper.org/)   
[Automapper video](https://www.youtube.com/watch?v=EB8Pl9Axssk&ab_channel=PabloCodes)    
   
[conexão com docker: video](https://www.youtube.com/watch?v=VbEhMVcWOFs&t=605s&ab_channel=JoseCarlosMacoratti)   
[docker](https://docs.docker.com/samples/dotnet/)   
[docker-compose](https://docs.docker.com/compose/)   

