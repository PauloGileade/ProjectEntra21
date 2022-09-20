# ProjectEntra21

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

Diante deste cenario o SCP será responsavel por controlar todas as entradas e saidas de BigBags na linha de produção, armazenando todos dados com consistencia e sendo capaz de gerar relatorios dos operadores para analises da sua produção, e exibindo em tempo real a produção dos operadores no Painel de Ordens.
![Template daora](https://user-images.githubusercontent.com/88987341/191126990-195d95ba-2bb4-4a36-945b-4eae93fb3da0.png)
O SCP utiliza-se das seguintes tecnologias, C# para BackEnd onde está registrada toda lógica, Banco de dados MySql para armazenamento dos dados da produção, ReactJS para FrontEnd responsável por exibir em tempo real o Painel de Ordens entre outras funcionalidades, Flutter para o controle e contagem da produção via leitura Qrcode.

![CriandoOrdem](https://user-images.githubusercontent.com/88987341/191139873-3c2d0498-7c1b-44b6-9f5b-7b379f4f2eeb.gif)
Desmonstração do abastecedor da celulá criando uma ordem para o operador da fase Inicial, inserindo 50 Bags de código 1 para costurar a alça.

