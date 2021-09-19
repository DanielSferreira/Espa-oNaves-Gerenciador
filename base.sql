create database SWShipsManage;

use SWShipsManage;

create table Pilotos(
    Id int PRIMARY KEY,
    Name varchar(100) NOT NULL,
);

create table NavesEspaciais(
    Id int PRIMARY KEY,
    Name varchar(100) NOT NULL,
    Model varchar(100) NOT NULL,
);

create table Planetas(
    Id int PRIMARY KEY,
    Name varchar(100) NOT NULL,
);

create table PilotoNaves(
    Id int PRIMARY KEY,
    IdPiloto int NOT NULL,
    IdNave int NOT NULL,
    IdPlaneta int NOT NULL,
    Autorizado bit
);

create table HistoricoViagens(
    Id int PRIMARY KEY,
    IdPiloto int NOT NULL,
    IdPlaneta int NOT NULL,
    dtSaida DateTime NOT NULL,
    dtChegada DateTime NOT NULL
);

ALTER TABLE PilotoNaves ADD CONSTRAINT viagem_to_piloto FOREIGN KEY (IdPiloto) REFERENCES Pilotos(Id);
ALTER TABLE PilotoNaves ADD CONSTRAINT viagem_to_nave FOREIGN KEY (IdNave) REFERENCES NavesEspaciais(Id);
ALTER TABLE PilotoNaves ADD CONSTRAINT viagem_to_planeta FOREIGN KEY (IdPlaneta) REFERENCES Planetas(Id);

ALTER TABLE HistoricoViagens ADD CONSTRAINT history_to_piloto FOREIGN KEY (IdPiloto) REFERENCES Pilotos(Id);
ALTER TABLE HistoricoViagens ADD CONSTRAINT history_to_nave FOREIGN KEY (IdNave) REFERENCES NavesEspaciais(Id);
ALTER TABLE HistoricoViagens ADD CONSTRAINT history_to_planeta FOREIGN KEY (IdPlaneta) REFERENCES Planetas(Id);







