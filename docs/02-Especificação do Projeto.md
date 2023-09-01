# 2. ESPECIFICAÇÃO DO PROJETO 
Pudemos definir o problema e seus pontos relevantes neste projeto através de uma consolidada participação dos usuários, em uma pesquisa realizada pelos integrantes da equipe, nas áreas dos eventos onde havia grande público, bem como demanda por estacionamentos nos arredores desses eventos, como em um estádio de futebol, onde se realizava uma partida de futebol, shows e eventos.
Assim os detalhes desse processo de pesquisa de campo, foram consolidadas na forma de personas e histórias de usuários, a qual seguem abaixo.  

## Personas

**Jorge Henrique** tem 51 anos, é advogado e contador, pós graduado. O seu objetivo ao usar à aplicação, é ter o Conforto em poder ir aos estádios de futebol com seu carro e segurança. Tem como motivação conforto, segurança e praticidade. Possui um carro Honda Civic.


**Bianca Gomes** tem 19 anos, é universitária e esta graduando em odontologia. Para Binca, o objetivo para usuar a aplicação, é ter praticidade em estacionar próximo aos eventos que gosta de ir com seu próprio carro, uma vez que frequentemente vai ao Estadio de Futebol para assistir jogos e shows. Sua motivação é ter tranquilidade, segurança e praticidade.

**Maria Eduarda** já aposentada, com 60 anos, tem o objetivo de usar a aplicação no intuito de fazer renda extra para complementar sua aposentadoria. Considerando que ela tem um espaço amplo em sua residencia, e por residir próximo ao Estádio do Mineirão, Maria, tem o objetivo de oferecer seu espaço de garagem, e assim obter renda extra com aplicacao.

**Pedro Agostinho** tem 28 anos, e é trabalhador autônomo. Ele trabalha frequentemente em eventos no Mineirão ou entorno do Mineirão em dias de eventos. E tem com objetivo de usar a aplicação para poder usar seus veículos, carro e uma moto, para os dias que tem que ir trabalhar na região do Mineirão, e assim, ter a tranquilidade que ficará longas horas na região, e seu veículo estará seguro. Sua finalidade é ter segurança e tranquilidade.

## Histórias de Usuários

Com o ensejo de entender melhor as personas identificadas no projeto, foram identificadas as seguintes histórias de usuários. 


|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|JORGE  | Poder ir para eventos em seu próprio carro; Ter segurança que seu carro está seguro; Pagar preço justo pelo estacionamento.          | Para não depender de transporte público de aplicativos; Assim evita eventuais furtos; Não ser explorado financeiramente.               |
|BIANCA       | Ir a shows ou eventos esportivos com seu carro ou de amigos; Ter tranquilidade que o carro estará no local e sem avarias;                   | Evitar ter que pegar transporte público lotado, ou esperar muito tempo para conseguir uma corrida por carro de aplicativo; Porque em volta desses locais há muito vandalismo.  |
|MARIA  | Fazer renda extra para complementar a aposentadoria; Disponibilizar seu espaço no seu terreiro, onde cabe 5 carros.          | Porque a aposentadoria recebe pouco; E assim, poder receber pelo cuidado e zelo do patrimônio de terceiros.                |
|PEDRO      |Poder ir aos estádios/shows sem se preocupar em como ir embora ao final; Quando estiver a trabalho em eventos, poder estacionar o carro, durante todo dia, assim, ao final do trabalho, e caminhar poucos metros e saber que seu carro se encontra seguro.                  | Porque é mais fácil ir para sua casa de carro do que com transporte público; Porque as vezes é impossível encontrar local seguro para estacionar seu carro.  |


## Requisitos do Projeto

O escopo funcional do projeto é definido por meio dos requisitos funcionais que descrevem as possibilidades interação dos usuários, bem como os requisitos não funcionais que descrevem os aspectos que o sistema deverá apresentar de maneira geral. Estes requisitos são apresentados a seguir. 

### Requisitos Funcionais
A tabela a seguir apresenta os requisitos do projeto, identificando a prioridade em que os mesmos devem ser entregues. 

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-01 | A aplicação deve apresentar na página principal o serviço de vagas disponíveis próximo a localidade de interesse do cliente, que será baseado no google maps.  | ALTA | 
|RF-02 | A aplicação deve apresentar, para cada localidade cadastrada de evento, imagens e descrição da vaga disponível.   | ALTA |
|RF-03 | A aplicação deve permitir ao usuário (locatário) visualizar o trajeto da vaga disponível ao local do evento de interesse, conforme google maps.    | MÉDIA |
|RF-04 | A aplicação deve oferecer um cadastro dividido entre locatário e prestador da vaga.    | ALTA | 
|RF-05 | A aplicação deve oferecer uma funcionalidade de filtro/pesquisa para permitir ao usuário localizar vagas de acordo com seu interesse   | ALTA |
|RF-06 | A aplicação deve permitir visualizar as informações de contatos do mantenedor da aplicação.   | MÉDIA |
|RF-07 | A aplicação deve permitir o compartilhamento de vagas disponíveis para locatários, através de um botão.    | BAIXA |
|RF-08 | A aplicação deve permitir reservar e efetuar o pagamento com antecedência.    | ALTA |
|RF-09 | A aplicação deve permitir que usuários x prestador possam efetuar comentários.    | BAIXA |
|RF-10 | A aplicação deve permitir que o usuário (prestador)(Locador)possa disponibilizar(cadastrar) suas vagas a partir de seu cadastro e login.    | ALTA |
|RF-11 | A aplicação deverá suportar o pagamento das taxas vinculadas a locação da vaga através do PIX.    | ALTA |
|RF-12 | A aplicação permitirá o login do usuário (locatário) após o seu cadastro.    | ALTA |

### Requisitos não Funcionais
A tabela a seguir apresenta os requisitos não funcionais que o projeto deverá atender.

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|-----------|
|RNF-01 | A aplicação deve ser publicada em um ambiente acessível publicamente na Internet (Repl.it, GitHub Pages, Heroku);   | ALTA | 
|RNF-02 | A aplicação deverá ser responsiva permitindo a visualização em um celular de forma adequada.  |  ALTA | 
|RNF-03 | A aplicação deve ter bom nível de contraste entre os elementos da tela em conformidade    |  MÉDIA | 
|RNF-04 | A aplicação deve ser compatível com os principais navegadores do mercado (Google Chrome, Firefox, Microsoft Edge)   |  ALTA | 
|RNF-05 | A interface da aplicação deve ser simples e fácil de navegar, para que os usuários possam encontrar rapidamente as vagas de estacionamento.   |  ALTA | 
|RNF-06 | A linguagem utilizada no site deve ser simples e acessível para que todos os usuários possam entender as informações presentes.   |  ALTA | 


## Restrições

As questões que limitam a execução desse projeto e que se configuram como obrigações claras para o desenvolvimento do projeto em questão são apresentadas na tabela a seguir. 

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|RE-01 |O projeto deverá ser entregue no final do semestre letivo, não podendo extrapolar a data de XX/XX/XXXX   |
|RE-02 | O aplicativo deve se restringir às tecnologias básicas da Web no Frontend        |
|RE-03 | A equipe não pode subcontratar o desenvolvimento do trabalho.        |


## Diagrama de Casos de Uso

O diagrama contempla as principais ligações previstas entre casos de uso e atores e permite detalhar os Requisitos Funcionais identificados na etapa de elicitação. Lembrando que  não se utiliza diagramas de caso de uso para requisitos não-funcionais. 
Como atores é importante a identificação dos grupos de todos os envolvidos que interagem com o sistema, principalmente outros sistemas ou sensores. Eles são representados graficamente por bonecos-palito e serão nomeados pelos papéis nas interações nas quais estão envolvidos (ex. Cliente, Administrador). Lembre-se de que o próprio sistema não pode ser ator do diagrama que o modela. 
Em relação aos casos de uso, eles devem representar as interações ou transações dos atores com o sistema. Cada tipo possível é representada por uma elipse nomeada e os relacionamentos são indicados por linhas que podem ter setas nos casos em que se indica a origem da interação. Os nomes dos casos de uso representam verbos no infinitivo associados aos objetos com os quais se relacionam os verbos (ex. Cadastrar usuário, Visualizar relatório). Os tipos de relacionamentos mais comuns são associações entre atores e casos de uso, generalizações entre atores e entre casos de uso, inclusões e extensões entre casos de uso. 

