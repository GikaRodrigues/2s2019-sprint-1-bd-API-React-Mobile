Use M_OpFlix

Insert Into Categorias	(Categoria)
	Values				('Terror')
						,('Aventura')
						,('Acao')
						,('Comedia')
						,('Guerra');

--Insert Into Tipos	(Tipo)
--	Values			('Filme')
--					,('Serie');

Insert Into Usuarios	(Nome , CPF , Email , Senha , DataCriacao , Permissao)
	Values				('Administrador' , 275433708-32 , 'adm@mail.com' , '123456' , '' , 'Administrador')
						,('Leo' , 441556358-95 , 'l@mail.com' , '123456' , '' , 'Cliente')
						,('Pieri' , 419244538-78 , 'p@mail.com' , '123456' , '' , 'Cliente')
						,('Murilo' , 424877388-04 , 'm@mail.com' , '123456' , '' , 'Cliente')
						,('Helena' , 449658148-51 , 'h@mail.com' , '123456' , '' , 'Cliente');

Insert Into Lancamentos	(Titulo , Sinopse , Duracao , Tipo , DataLancamento , IdCategoria)
	Values				('Up' , 'Tem um veio e uma crianca com milhoes de baloes' , '110' , 'Filme' , '2009-09-04', 2)
						,('Vingadores Ultimato' , 'Ap�s Thanos eliminar metade das criaturas vivas, os Vingadores t�m de lidar com a perda de amigos e entes queridos.' , '180' , 'Filme' , '2019-04-25' , 3)
						,('A Grande Familia' , 'Uma fam�lia muito louca! Uma fam�lia muito careta. Uma fam�lia chata, engra�ada, alegre, triste.' , '30' , 'Serie' , '2001-03-29' , 4)
						,('O Grinch' , '�s v�speras do Natal, os moradores de Queml�ndia preparam a grande festa anual em celebra��o � data. Grinch, o pequeno ser verde e mal-humorado, detesta a festividade. 
						Ao lado de seu c�ozinho Max, ele cria um plano mal�fico: invadir as casas da vizinhan�a e sumir com todos os itens de Natal.' , '100' , 'Filme' , '2018-11-08' , 2);

--/////     EXTRAS     /////

Insert Into Lancamentos	(Titulo , Sinopse , Duracao , Tipo , DataLancamento , IdCategoria)
	Values				('Rei Leao' , 'Tra�do e exilado de seu reino, o le�ozinho Simba precisa descobrir como crescer e retomar seu destino como herdeiro real.' , '120' , 'Filme' , '2019-09-04' , 2)
						,('Deuses Americanos' , 'Centrado em uma guerra entre os velhos e os novos deuses. Os seres b�blicos e mitol�gicos est�o perdendo cada vez mais fi�is para novos deuses.' , '60' , 'Serie' , '2017-04-30' , 7)
						,('La Casa Papel 3� Temporada' , 'Oito habilidosos ladr�es se trancam na Casa da Moeda da Espanha com o ambicioso plano de realizar o maior roubo da hist�ria e levar com eles mais de 2 bilh�es de euros.' , '50' , 'Serie' , '2017-05-02' , 7)
						,('Velozes e Furiosos: Hobbs & Shaw' , 'Tem muita corrida' , '140' , 'Filme' , '2019-08-01' , 3)
						,('Ana Belle 3: De volta para casa' , 'Annabelle, aproveitando que os investigadores paranormais est�o fora de jogo, anima os letais e aterrorizantes objetos contidos na Sala dos Artefatos dos Warren.' , '100' , 'Filme' , '2019-06-27' , 1)
						,('Homem Haranha: Longe de casa' , 'Tem muita pancadaria' , '130' , 'Filme' , '2019-07-04' , 3);

--/////   Inserir novas categorias   ///////

Insert Into Categorias	(Categoria)
	Values				('Documentario')
						,('Drama')
						,('Ficcao Cientifica');


--/////   Deletar a Serie Deuses Americanos   ///////

Delete From Lancamentos Where IdLancamento = 6;

--/////   Coloca Helena com ADM   /////

Update Usuarios
Set Permissao = 'Administrador'
Where IdUsuarios = 5

--/////   Alterar a data do Rei Leao   /////

Update Lancamentos
Set DataLancamento = '1994-07-08'
Where IdLancamento = 5

--/////   Alterar nome de La Casa de Papel   /////

Update Lancamentos
Set Titulo = 'La Casa De Papel - 3� Temporada'
Where IdLancamento = 7


Insert Into Plataformas (Plataforma)
	Values				('Netflix')
						,('Amazon')
						,('Cinema')
						,('VHS');

Insert Into Favoritos (IdUsuario , IdLacamentos)
	Values				(5 , 9)
						,(2 , 10)
						,(3 , 2)
						,(4 , 4)
						,(5 , 1)
						,(3 , 2)
						,(5 , 7)
						,(2 , 9);

Insert Into PlataformaLancamentos (IdPlataforma , IdLancamento)
	Values				(1 , 2)
						,(2 , 2)
						,(3 , 1)
						,(4 , 10)
						,(2 , 3)
						,(3 , 9)
						,(4 , 9)
						,(2 , 10);