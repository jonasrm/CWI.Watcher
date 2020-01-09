<br />
<p align="center">
  <h1 align="center">CWI.Watcher</h1>

  <p align="center">
    Sistema de análise de dados de venda que irá importar lotes de arquivos e produzir um relatório baseado em informações presentes no mesmo.
    <br />
    <br />
    <a href="https://github.com/jonasrm/CWI.Watcher">Home</a>
    ·
    <a href="https://github.com/jonasrm/CWI.Watcher/issues">Report Bug</a>
    ·
    <a href="https://github.com/jonasrm/CWI.Watcher/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
## Table of Contents

* [Enunciado](#enunciado)
* [Sobre a aplicação](#sobre-a-aplicação)
  * [Execução](#execução)
* [Indefinições da Especificação](#enunciado)
* [Melhorias Evolutivas](#melhorias-evolutivas)


## Enunciado


### Objetivo da prova
O objetivo da prova é testarmos suas habilidades em desenvolvimento de software. Iremos
avaliar mais do que o funcionamento da solução proposta, avaliaremos a sua abordagem, a
sua capacidade analítica, boas práticas de engenharia de software, performance e
escalabilidade da solução.



### Descrição
Criar um sistema de análise de dados de venda que irá importar lotes de arquivos e produzir
um relatório baseado em informações presentes no mesmo.
Existem 3 tipos de dados dentro dos arquivos e eles podem ser distinguidos pelo seu
identificador que estará presente na primeira coluna de cada linha, onde o separador de
colunas é o caractere **“ç”**.




**Dados do vendedor**

Os dados do vendedor possuem o identificador **001** e seguem o seguinte formato:
```sh
001çCPFçNameçSalary
```




**Dados do cliente**

Os dados do cliente possuem o identificador **002** e seguem o seguinte formato:
```sh
002çCNPJçNameçBusiness Area
```




**Dados de venda**

Os dados de venda possuem o identificador **003** e seguem o seguinte formato:
```sh
003çSale IDç[Item ID-Item Quantity-Item Price]çSalesman name
```




**Exemplo de conteúdo total do arquivo:**

```sh
001ç1234567891234çPedroç50000
001ç3245678865434çPauloç40000.99
002ç2345675434544345çJose da SilvaçRural
002ç2345675433444345çEduardo PereiraçRural
003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro
003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çPaulo
```


O sistema deverá ler continuamente todos os arquivos dentro do diretório padrão
HOMEPATH/data/in e colocar o arquivo de saída em HOMEPATH/data/out.
No arquivo de saída o sistema deverá possuir os seguintes dados:
- Quantidade de clientes no arquivo de entrada
- Quantidade de vendedores no arquivo de entrada
- ID da venda mais cara
- O pior vendedor




### Requisitos técnicos

- O sistema deve rodar continuamente e capturar novos arquivos assim que eles sejam
inseridos no diretório padrão.
- Você tem total liberdade para escolher qualquer biblioteca externa se achar
necessário.





## Sobre a Aplicação
- Foi desenvolvida em C# .Net Core 3.0 para plataforma Windows.
- Para facilitar o desenvolvimento, execução, testes e avaliação foi implementado um "Console Application" que é executado de tempos em tempos.
- Entendo que a solução final tem características de serviço agendado, por exemplo um Windows Service.




### Execução
- Para executar basta executar `CWI.Watcher.exe (milissegundos)` - onde milissegundos é a periodicidade de execução - por exemplo `CWI.Watcher.exe 15000` executa o programa a cada 15 segundos.
- Em modo "Debug" a aplicação é executada a cada 10 segundos.
- A periodicidade é um fator crucial que afeta a concepção de lotes e performance, deve ser avaliada de acordo com a necessidade e criticidade do processo.




## Indefinições da Especificação
- Qual o tratamento caso existam subdiretórios dentro da pasta de entrada.
- Um mesmo arquivo deve ser processado novamente - poderia ser implementado um controle com hash para evitar que um arquivo com o mesmo conteúdo seja processado mais de uma vez.
- Qual o tipo de arquivo, portanto foi apenas considerados arquivos de texto puro com variações de extensões parametrizadas.
- A relação entre as entidades está implicita, porém não existe ação mapeada entidades sem suas respectivas correspondentes - por exemplo, a entidade venda sem a entidade vendedor.
- Necessidade de validar os dados como por exemplo CPF e CNPJ.




## Melhorias Evolutivas
- Alterar o delimitar "ç" para outro, por exemplo ";".
- Implementar testes unitários.
- Implementar injeção de dependência.
- Agregar um repositório para armazenar logs, configurações e controles.
- Mecanismo de aviso de falhas, por exemplo envio de e-mail.
- Utilização de threads para processamento paralelo.
- Implementar specification para validações.
- Se necessário uma ação instantânea ao haver alteração no diretório poderia ser utilizado a função "FileSystemWatcher".
- Refatorar possíveis gargalos, por exemplo substituir "List" por "Array".
- Trtar melhor as ocorrências de falha, especificar qual arquivo deu erro, qual linha e qual o tipo de erro.





