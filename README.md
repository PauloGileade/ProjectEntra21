# ProjectEntra21
![TelaInicial](https://user-images.githubusercontent.com/88987341/191150852-459545b8-b179-4695-9989-ceafd63e9b5e.gif)
SCP ou Sistema de controle da produção, é uma aplicação criada para gerenciar o controle de contagem e o armazenamento de dados da produção de uma fabrica do ramo textil, esse sistema utiliza-se de leituras via Qrcode para rastrear os produtos e contabilizar a produção de cada operador nas suas respectivas celulas. 
    Esse sistema foi desenvolvido para substituir o gerenciamento manual de contagem e armazenamneto de dados da produção, onde cada operador era responsavel por contabilizar a sua produção atraves de separações das suas etiquetas que iria ser inseridas nos BigBags que estavam sendo produzidos.
    ![Template](https://user-images.githubusercontent.com/88987341/191122137-392e6069-a1d1-4ab8-a27e-e663d77cdb63.png)
    Nesta fábrica contém 6 celulás e todas seguem o mesmo padrão que está na Planta da Linha de produção acima, cada celulá tem 12 colaboradores e são divididas em 3 fases, 6 operadores ficam responsaveis por costurar as alças dos BigBags na fase Inicial, 3 ficam responsaveis por costurar o fundo dos BigBags na fase Intermediaria e 3 na fase Final costurando a tampa.
    Exemplo de como funciona a contagem da produção dos produtos sem o SCP, (O abastecedor fornece a quantidade de entrada dos BigBags a cada operador da fase Inicial juntamente com as etiquetas dos produtos que irão ser produzidos, e após abastecer o mesmo informa a quantidade total que foi inserida na celulá para a supervisora, sendo assim a contagem de cada operador funciona da seguinte forma, Operador recebeu 30 etiquetas, ao termino de uma hora o mesmo reconta suas etiquetas, se sobrou apenas 5 etiquetas, então a produção do operador foi de 25 bags em uma hora, a supervisora recolhe essa informação e anota em sua planilha manualmente ).
    
    Impactos negativos do gerenciamento manual da produção;

Baixa produtividade na linha de produção, pois os operadores perdem tempo na contagem de suas etiquetas.

Conflitos internos, pois ao haver um erro na contagem do operador ou do abastecedor, ira ser dificil aplicar a rastreabilidade das entradas e saidas dos BigBags na linha de produção.

Controle de contagem passivas a erros, o operador durante a produção pode se perde na sua contagem, calcular errado ou até mesmo omitir o valor exato.

Falhas no armazenamento de dados, onde a supervisora da celulá é responsavel por anotar toda contagem em sua planilha, deste modo poderá armazenar uma contagem incorreta da produção caso o operador não informe o valor exato.

Falta de acompanhamento da produção, os supervisores das celulás e os encarregados não tem um painel de vizualização da produção em tempo real.

Diante deste cenario o SCP será responsavel por controlar todas as entradas e saidas de BigBags na linha de produção, armazenando todos dados com consistencia e sendo capaz de gerar relatorios dos operadores para analises da sua produção, e exibindo em tempo real a produção dos operadores no Painel de Ordens que está logo abaixo.

https://user-images.githubusercontent.com/88987341/191147911-3ea6709e-1b83-4267-b4b7-2887e804bff7.mp4

O SCP utiliza-se das seguintes tecnologias, C# para BackEnd onde está registrada toda lógica, Banco de dados MySql para armazenamento dos dados da produção, ReactJS para FrontEnd responsável por exibir em tempo real o Painel de Ordens entre outras funcionalidades, Flutter para o controle e contagem da produção via leitura Qrcode.

![CriandoOrdem](https://user-images.githubusercontent.com/88987341/191139873-3c2d0498-7c1b-44b6-9f5b-7b379f4f2eeb.gif)
Logo acima está uma desmonstração do abastecedor da celulá criando uma ordem para o operador da fase Inicial, inserindo 50 Bags de código 1 para costurar a alça.

https://user-images.githubusercontent.com/88987341/191142229-d28ac068-ade1-46c1-b1bd-12a43137be0c.mp4

No video acima o abastecedor da fase intermediaría está bipando a etiqueta que contém as informações do operador, produto, celulá e a fase que operador está produzindo, e automaticamente a quantidade de saida da ordem é atualizada após a leitura da etiqueta que está inserida no BigBag logo após o operador colocar a Alça, o Fundo ou tampa do Bag que é transferido da fase Inicial para a intermediaría ou da fase intermediaría para a fase final de produção.
    Desta forma o fluxo de transferência de BigBags entre as fases irá funcionar da seguinte maneira, se a fase inicial entregar 50 Bags prontos com alças, automaticamente o abastecedor da fase intermediaría irá ter somente 50 Bags disponiveis para abastecimento dos 3 operadores que está produzindo na fase intermediaría, sendo assim o mesmo fluxo de transferência serve da fase intermediaría para a fase final.
    
    Impactos positivos do gerenciamento automatizado da produção;

Maior produtividade na linha de produção, pois os operadores não necessitaram contar suas entiquetas para separação antes de iniciar sua produção.

Maior segurança no armazenamento de dados, desta forma o SCP se encarregar de armazenar todos os dados da linha de produção, através das leituras via Qrcode.

Acompanhamento da produção em tempo real no Painel Ordens, deste modo os encarregados e os supervisores poderão analisar com uma maior precisão os gargalos na linha de produção.

Gerenciamento completo dos Operadores e BigBags na linha de produção, SCP fica responsavel por rastrear os Bags e calcular todos os dados referente a produção de cada operador.

Relatorios com maior precisão para analise da produção de cada operador nas suas respectivas fases.

![Template daora](https://user-images.githubusercontent.com/88987341/191149511-9cace5e2-8641-4b5a-9384-7c7772d30b5c.gif)
O SCP também irá disponibilizar ao usuario, telas para gerenciamento dos colaboradores, produtos, celulás, ordens e operações, como está no logo acima.

![TelaFinal](https://user-images.githubusercontent.com/88987341/191151106-f9127b27-743e-4a38-9c4e-11c1569c1030.gif)



