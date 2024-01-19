# Autoglass
Implementacao de webapi em camadas com ddd, automapper e ef core

Desafio prático de Programação - Autoglass

O que desenvolver?
Você irá criar API para a gestão de produtos, com os seguintes recursos:

 Recuperar um registro por código;

 Listar registros  
Filtrando a partir de parâmetros e paginando a resposta

 Inserir
Criar validação para o campo data de fabricação que não poderá ser maior ou igual a
data de validade.

 Editar
Criar validação para o campo data de fabricação que não poderá ser maior ou igual a
data de validade.

 Excluir
A exclusão deverá ser lógica, atualizando o campo situação com o valor Inativo.

Campos no escopo de produtos são
   Código do produto (sequencial e não nulo)
   Descrição do produto (não nulo)
   Situação do produto (Ativo ou Inativo)
   Data de fabricação
   Data de validade
   Código do fornecedor
   Descrição do fornecedor
   CNPJ do fornecedor
  
Requisitos
Obrigatório
   Construir a Web-api em dotnet core ou dotnet 5.
   Construir a estrutura em camadas e em DDD.
  
Diferenciais
   Utilizar ORM
   Utilizar a biblioteca Automapper para fazer o mapeamento entity-DTO.
   Fazer teste unitários
