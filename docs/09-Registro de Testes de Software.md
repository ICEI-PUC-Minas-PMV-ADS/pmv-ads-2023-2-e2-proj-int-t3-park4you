# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

Para cada caso de teste definido no Plano de Testes de Software, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!!!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos (obs.: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso).

CT-01 – Cadastrar Usuário
RF-04 - A aplicação deve oferecer um cadastro divido entre locatário e prestador da vaga.
- Acessar o navegador
- Informar o endereço do site:
  http://park4you-001-site1.anytempurl.com/
- Visualizar a página principal
CT-01
![Alt text](<img/página logada.JPG>)
Durante os testes a página principal apresentou alguns erros na formatação das imagens, pa´gina carregou sem erros.

- Acessar página de Login> acessos não apresentaram erro
CT-01
![Alt text](<img/página login e cadastro.JPG>)
- Cadastrar usuário> cadastro realizado com sucesso, não apresentou erro.
CT-01
![Alt text](<img/Pagina cadastro usuário.JPG>)

CT-01
![Alt text](<img/Usuários cadastrados.JPG>)

CT-01 Teste realizado com êxito, cadastro realizada com sucesso, cadastros devidamente realizados.

Erro apresentado> usuário está visualizando todos os cadastros.

Cadastro do perfil de Administrador

Cadastro do Gestor da aplicação:
![Alt text](<img/Cadastro gestor 1.JPG>)

Confirmação de senha de segurança para permissão do cadastro, demonstrandoo assim segurança do cadastro.

![Alt text](<img/login gestor confirmação.JPG>)

Edição de cadastro, apresenta todas as opções funcionais:

![Alt text](<img/Confirmação de cadastro de usuários.JPG>)

Erro apresentado, o usuário visualiza o cadastro dos outros usuários.

CT-02 – Efetuar login
RF-12 - A aplicação permitirá o login do usuário Locador/Locatário após o seu cadastro.
- Acessar o navegador
- Informar o endereço do Site:

  http://park4you-001-site1.anytempurl.com/

- Visualizar a página principal 

![Alt text](<img/página logada.JPG>)

- Acessar página de Login
CT-02
![Alt text](<img/página login e cadastro.JPG>)

CT-02
-Acesso devidamente testados, login realizado com sucesso.
-E-mails e senhas inválidos- apresentou mensagem de erro conforme previsto

COLOCAR ERRO DE LOGIN AQUIII

CT-03 – Cadastrar Vagas
RF-10 -A aplicação deve permitir que o usuário (prestador)(Locador)possa disponibilizar(cadastrar) suas vagas a partir de seu cadastro e login
- Acessar o navegador
- Informar o endereço do site
 http://park4you-001-site1.anytempurl.com/
- Visualizar a página principal
![Alt text](<img/página logada.JPG>)
  
CT-03
Acessar página de Login
![Alt text](<img/página login e cadastro.JPG>)
CT-03
![Alt text](<img/teste 07.JPG>)
- Informar Email e Senha

- Acessar o ícone "Cadastrar Vagas"
CT-03
![Alt text](<img/página de cadastro de vaga.JPG>)
CT-03
![Alt text](<img/cadastro de vaga.JPG>)
CT-03
Cadastro realizado com sucesso, vaga cadastrada.

Opçoes disponíveis:

Editar cadastro, caso seja necessário realizar alguma alteração no cadastro do usuário:
![Alt text](<img/editar cadastro de vaga 1.JPG>)

Detalhes da vaga
![Alt text](<img/detalhes da vaga 2.JPG>)

CT-04 – Pesquisar Vagas 
RF-02 - A aplicação deve apresentar, para cada localidade cadastrada de evento, imagens e descrição da vaga disponível.
RF-05 A aplicação deve oferecer uma funcionalidade de filtro/pesquisa para permitir ao usuário localizar vagas de acordo com seu interesse
RF-07 A aplicação deve permitir o compartilhamento de vagas disponíveis para locatários, através de um botão.

Durante os testes foi possível pesquisar a vaga,considerando o evento, os outros filtros precisam ser ajustados, como o de pesquisa por data e/ou quantidade de veículos:

![Alt text](<img/Show da virada.JPG>)

Reserva da vaga:
![Alt text](<img/Confirmação de reserva.JPG>)

Erro apresentado:
![Alt text](<img/confirmação de reserva erro.JPG>)


	
## Avaliação

A aplicação possui uma ideia central muito interessante para os usuários, apresentou alguns erros que podem ser solucionados para a implementação de forma segura.

