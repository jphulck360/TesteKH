A Aplicação está organizada na seguinte forma:

1) APIMineral (API)
2) TesteKingHost (Aplicação exemplo para consumir os dados da API)



* Descrição:
1.1) Foi realizada a construção de uma API chamada APIMineral, onde são listados:
 - ID do mineral
 - Nome do mineral
 - Descrição
 - Concluído
 - Data de criação
 - Data de atualização
 
 
 
* Métodos da API
- public Mineral AddMineral(Mineral mineral)
- public GetMineral()
- public void DeleteMineral(int id)
- public Mineral UpdateMineral(Mineral mineral)



2.1)
Foi criada uma aplicação de exemplo, para consumir os dados desta API.
