# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

1.	Objetivos

O documento foi produzido com o objetivo de listar todos os requisitos da aplicação e testá-los de modo a encontrar falhas antes que o sistema seja disponibilizado para o cliente.

1.1	 O Sistema Park4You

Este é um sistema de estacionamento que visa identificar e oferecer aos clientes garagens livres próximas a eventos proporcionando ao usuário a praticidade de se deslocar no seu veículo já com o espaço reservado para estacionar. Para isto o sistema deve possuir um Banco de Dados para armazenar todas as informações necessárias para o pleno funcionamento do sistema.

1.2	 Escopo
Os testes buscarão medir os graus de acessibilidade, aceitação, visam também medir a robustez do sistema e sua confiabilidade de modo a entregar uma aplicação de qualidade aos usuários.


2. Palno de Testes de Software
 
| **Caso de Teste** 	| **CT-01 – Cadastrar Usuário** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-04 - A aplicação deve oferecr um cadastro divido entre locatário e prestador da vaga. |
| Objetivo do Teste 	| Verificar se o sistema disponibiliza o cadastro dos dois perfis, se a validação do CPF/CNPJ está ocorrendo. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site<br> - Visualizar a página principal<br> - Acessar página de Login<br> - Cadastrar usuário |
|Critério de Êxito | - ●	Sucesso no cadastro a partir de um CPF/CNPJ válido;<br>
●	Preenchimento de todos os campos obrigatórios. |
|  	|  	|
| Caso de Teste 	| CT-02 – Efetuar login	|
|Requisito Associado | RF-12	- A aplicação permitirá o login do usuário Locador/Locatário após o seu cadastro. |
| Objetivo do Teste 	| Verificar se o sistema controla o acesso dos usuários de forma efetiva, ou seja, os direciona para a tela correspondente ao seu perfil. |
| Passos 	| - Acessar o navegador<br> - Informar o endereço do Site<br> - Visualizar a página principal<br> - Acessar página de Login<br> - Informar Email e Senha |
|Critério de Êxito | ●	E-mails e senhas inválidos apresentar mensagem de erro<br>
●	E-mails não cadastrados direcionar para a tela de cadastro. |
|  	|  	|
| Caso de Teste 	| CT-03 – Cadastrar Vagas	|
|Requisito Associado | RF-10	-A aplicação deve permitir que o usuário (prestador)(Locador)possa disponibilizar(cadastrar) suas vagas a partir de seu cadastro e login |
| Objetivo do Teste 	| Verificar se a vaga existe, e se ela pertence ao responsável pelo cadastro. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site<br> - Visualizar a página principal<br> Acessar página de Login<br> - Informar Email e Senha <br> - Acessar o ícone "Cadastrar Vagas"<br>  |
|Critério de Êxito | - Liberação do cadastro a partir da aprovação da documentação da vaga. |
|  	|  	|
| Caso de Teste 	| CT-04 – Pesquisar Vagas	|
|Requisito Associado | RF-02	- A aplicação deve apresentar, para cada localidade cadastrada de evento, imagens e descrição da vaga disponível.<br> RF-05 A aplicação deve oferecer uma funcionalidade de filtro/pesquisa para permitir ao usuário localizar vagas de acordo com seu interesse<br> RF-07 A aplicação deve permitir o compartilhamento de vagas disponíveis para locatários, através de um botão. |
| Objetivo do Teste 	| Verificar se o sistema está conectado corretamente com um sistema de GPS;<br> Certificar que as imagens estão sendo carregadas corretamente;<br> Verificar que o “botão” compartilhar responde aos comandos corretamente.|
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site<br> - Visualizar a página principal<br> Acessar página de Login<br> - Informar Email e Senha <br> - Acessar o ícone "Vagas"<br>  |
|Critério de Êxito | -•	Ao clicar na vaga as imagens são carregadas de maneira ágil;<br>
•	Botão compartilhar ativo no layout da vaga. |
|  	|  	|
| Caso de Teste 	| CT-05 – Efetuar login	|
|Requisito Associado | RF-00Y	- A aplicação deve possuir opção de fazer login, sendo o login o endereço de e-mail. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar login. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://adota-pet.herokuapp.com/src/index.html<br> - Clicar no botão "Entrar" <br> - Preencher o campo de e-mail <br> - Preencher o campo da senha <br> - Visualizar a página principal<br> - Clicar em "Login" |
|Critério de Êxito | - O login foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-02 – Efetuar login	|
|Requisito Associado | RF-00Y	- A aplicação deve possuir opção de fazer login, sendo o login o endereço de e-mail. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar login. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://adota-pet.herokuapp.com/src/index.html<br> - Clicar no botão "Entrar" <br> - Preencher o campo de e-mail <br> - Preencher o campo da senha <br> - Visualizar a página principal<br> - Clicar em "Login" |
|Critério de Êxito | - O login foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-02 – Efetuar login	|
|Requisito Associado | RF-00Y	- A aplicação deve possuir opção de fazer login, sendo o login o endereço de e-mail. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar login. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://adota-pet.herokuapp.com/src/index.html<br> - Clicar no botão "Entrar" <br> - Preencher o campo de e-mail <br> - Preencher o campo da senha <br> - Visualizar a página principal<br> - Clicar em "Login" |
|Critério de Êxito | - O login foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-02 – Efetuar login	|
|Requisito Associado | RF-00Y	- A aplicação deve possuir opção de fazer login, sendo o login o endereço de e-mail. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar login. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://adota-pet.herokuapp.com/src/index.html<br> - Acessar página de Login<br> Clicar no botão "Entrar" <br> - Preencher o campo de e-mail <br> - Preencher o campo da senha <br> - Visualizar a página principal<br> - Clicar em "Login" |
|Critério de Êxito | - O login foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-02 – Efetuar login	|
|Requisito Associado | RF-00Y	- A aplicação deve possuir opção de fazer login, sendo o login o endereço de e-mail. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar login. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://adota-pet.herokuapp.com/src/index.html<br> - Acessar página de Login<br> Clicar no botão "Entrar" <br> - Preencher o campo de e-mail <br> - Preencher o campo da senha <br> - Visualizar a página principal<br> - Clicar em "Login" |
|Critério de Êxito | - O login foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-02 – Efetuar login	|
|Requisito Associado | RF-00Y	- A aplicação deve possuir opção de fazer login, sendo o login o endereço de e-mail. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar login. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://adota-pet.herokuapp.com/src/index.html<br> - Acessar página de Login<br> Clicar no botão "Entrar" <br> - Preencher o campo de e-mail <br> - Preencher o campo da senha <br> - Visualizar a página principal<br> - Clicar em "Login" |
|Critério de Êxito | - O login foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-02 – Efetuar login	|
|Requisito Associado | RF-00Y	- A aplicação deve possuir opção de fazer login, sendo o login o endereço de e-mail. |
| Objetivo do Teste 	| Verificar se o usuário consegue realizar login. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site https://adota-pet.herokuapp.com/src/index.html<br> - Acessar página de Login<br> Clicar no botão "Entrar" <br> - Preencher o campo de e-mail <br> - Preencher o campo da senha <br> - Visualizar a página principal<br> - Clicar em "Login" |
|Critério de Êxito | - O login foi realizado com sucesso. |

 
