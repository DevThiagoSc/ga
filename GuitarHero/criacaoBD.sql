create database Guitar_Arena

use Guitar_Arena

create table jogador(
	id_jogador int not null primary key IDENTITY(1, 1),
	nome_jogador varchar(200) not null,
	pontuacao int
);

create table musica(
	id_musica int not null primary key IDENTITY(1, 1),
	nome_musica varchar(200) not null,
	pontuacao int
);

create table jogo(
	id_jogo int not null primary key IDENTITY(1, 1),
	pontuacao int,
	id_musica int FOREIGN KEY REFERENCES musica(id_musica),
	id_jogador int FOREIGN KEY REFERENCES jogador(id_jogador)
);

Insert into jogador(nome_jogador, pontuacao) values
	('Carlos', 100),
	('André', 1561),
	('Pedro', 865),
	('Maria', 10000);

select nome_jogador, pontuacao from jogador order by pontuacao desc

alter table musica drop column pontuacao;
alter table musica add banda varchar(40);
select * from jogo

insert into musica(nome_musica, banda) values ('Seven Nation Army', 'The White Stripes')

