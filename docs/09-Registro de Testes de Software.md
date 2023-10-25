# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

Para cada caso de teste definido no Plano de Testes de Software, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!!!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos (obs.: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso).

CT-01 – Cadastrar Usuário
RF-04 - A aplicação deve oferecer um cadastro divido entre locatário e prestador da vaga.
- Acessar o navegador
- Informar o endereço do site
- Visualizar a página principal
CT-01
 [Plano de Testes de Software](<img/teste 00.jpg>)
  
- Acessar página de Login
CT-01
![Plano de Testes de Software](<img/teste 01.jpg>)

- Cadastrar usuário
CT-01
![Plano de Testes de Software](<img/teste 02.jpg>)

CT-01
[Plano de Testes de Software](<img/teste 02.jpg>)

CT-01 Teste realizado com êxito, cadastro realizada com sucesso, cadastros devidamente realizados.

CT-02 – Efetuar login
RF-12 - A aplicação permitirá o login do usuário Locador/Locatário após o seu cadastro.
- Acessar o navegador
- Informar o endereço do Site
- Visualizar a página principal 
CT-02
![Alt text](<img/teste 05.jpg>)

- Acessar página de Login
CT-02
![Alt text](<img/teste 04.jpg>)

- Informar Email e Senha
CT-02
![Alt text](<img/teste 06.jpg>)

CT-02
-Acesso devidamente testados, login realizado com sucesso.
-E-mails e senhas inválidos- apresentou mensagem de erro

CT-03 – Cadastrar Vagas
RF-10 -A aplicação deve permitir que o usuário (prestador)(Locador)possa disponibilizar(cadastrar) suas vagas a partir de seu cadastro e login
- Acessar o navegador
- Informar o endereço do site
- Visualizar a página principal

  
CT-03
![Alt text](<img/teste 00.jpg>)
Acessar página de Login
CT-03
![Alt text](<img/teste 07.jpg>)
- Informar Email e Senha
- Acessar o ícone "Cadastrar Vagas"
CT-03
![Alt text](<img/teste 08.jpg>)
CT-03
![Alt text](<img/teste 09.jpg>)
CT-03
Cadastro realizado com sucesso, vaga cadastrada.

CT-04 – Pesquisar Vagas (Em desenvolvimento)
RF-02 - A aplicação deve apresentar, para cada localidade cadastrada de evento, imagens e descrição da vaga disponível.
RF-05 A aplicação deve oferecer uma funcionalidade de filtro/pesquisa para permitir ao usuário localizar vagas de acordo com seu interesse
RF-07 A aplicação deve permitir o compartilhamento de vagas disponíveis para locatários, através de um botão.

- Acessar o navegador
- Informar o endereço do site
- Visualizar a página principal
Acessar página de Login
- Informar Email e Senha
- Acessar o ícone "Vagas"
Critério de Êxito	Ao clicar na vaga as imagens são carregadas de maneira ágil;

CT-05 – Apresentar Vagas na região desejada (Em desenvolvimento)

RF-01 - A aplicação deve apresentar na página principal o serviço de vagas disponíveis próximo a localidade de interesse do cliente, que será baseado no google maps.

- Acessar o navegador
- Informar o endereço do site
- Visualizar a página principal
Acessar página de Login
- Informar Email e Senha
- Acessar o ícone "Vagas"
- Informar o CEP da região

Critério de Êxito	Informando o CEP as vagas da região são imediatamente carregadas.

CT-06 – Trajeto a pé até o evento (Em desenvolvimento)

RF-03 - A aplicação deve possuir opção de fazer login, sendo o login o endereço de e-mail.

- Acessar o navegador
- Informar o endereço do site
- Visualizar a página principal
Acessar página de Login
- Informar Email e Senha
- Acessar o ícone "Vagas"
- Informar o CEP da região
- Visualizar trajeto até o evento.

Critério de Êxito	O sistema com o auxílio do GPS carrega a distância e o melhor trajeto a pé da vaga ao evento.

CT-07 – Pagamento (Em desenvolvimento)
RF-08 A aplicação deve permitir reservar e efetuar o pagamento com antecedência.
RF-11 A aplicação deverá suportar o pagamento das taxas vinculadas a locação da vaga através do PIX.

- Acessar o navegador
- Informar o endereço do site
- Visualizar a página principal
Acessar página de Login
- Informar Email e Senha
- Acessar o ícone "Vagas"
- Informar o CEP da região
- Selecionar Vaga
Realizar pagamento.
Critério de Êxito	Efetuado o pagamento a vaga é reservada automaticamente e ficará indisponível para os outros usuários.
	

CT-08 – Comentários (Em desenvolvimento)
RF-09 - A aplicação deve permitir que usuários x prestador possam efetuar comentários.

- Acessar o navegador
- Informar o endereço do site
- Visualizar a página principal
Acessar página de Login
- Informar Email e Senha
- Acessar o ícone "Vagas"
- Selecionar vaga
- Realizar Comentários.

Critério de Êxito	Campo “comentários” disponibilizado;

CT-09 – Serviço de Atendimento ao Usuário (Em desenvolvimento)
RF-06 - A aplicação deve permitir visualizar as informações de contatos do mantenedor da aplicação.
- Acessar o navegador
- Informar o endereço do site
- Visualizar a página principal
Acessar página de Login
- Informar Email e Senha
- clicar no botão SAC.

Critério de Êxito	Ao clicar no SAC o usuário é direcionando para as opções chat, email, telefone.




## Avaliação

Discorra sobre os resultados do teste. Ressaltando pontos fortes e fracos identificados na solução. Comente como o grupo pretende atacar esses pontos nas próximas iterações. Apresente as falhas detectadas e as melhorias geradas a partir dos resultados obtidos nos testes.

> **Links Úteis**:
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)


[def]: <img/teste 03.jpg>