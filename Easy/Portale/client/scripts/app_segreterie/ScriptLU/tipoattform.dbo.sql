
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


-- CREAZIONE TABELLA tipoattform --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tipoattform]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tipoattform] (
idtipoattform int NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(1) NOT NULL,
 CONSTRAINT xpktipoattform PRIMARY KEY (idtipoattform
)
)
END
GO

-- VERIFICA STRUTTURA tipoattform --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipoattform' and C.name = 'idtipoattform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipoattform] ADD idtipoattform int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipoattform') and col.name = 'idtipoattform' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipoattform] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipoattform' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipoattform] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [tipoattform] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipoattform' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipoattform] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipoattform') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipoattform] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipoattform] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipoattform' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipoattform] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipoattform') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipoattform] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipoattform] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tipoattform' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tipoattform] ADD title varchar(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tipoattform') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tipoattform] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tipoattform] ALTER COLUMN title varchar(1) NOT NULL
GO


-- GENERAZIONE DATI PER tipoattform --
IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '1')
UPDATE [tipoattform] SET description = 'Attività formative relative alla formazione di base',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'A' WHERE idtipoattform = '1'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('1','Attività formative relative alla formazione di base',{ts '2018-06-11 11:35:00.653'},'ferdinando','A')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '2')
UPDATE [tipoattform] SET description = 'Attività formative caratterizzanti il livello del corso',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'B' WHERE idtipoattform = '2'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('2','Attività formative caratterizzanti il livello del corso',{ts '2018-06-11 11:35:00.653'},'ferdinando','B')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '3')
UPDATE [tipoattform] SET description = 'Attività formative un uno o più ambiti affini o integrativi',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'C' WHERE idtipoattform = '3'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('3','Attività formative un uno o più ambiti affini o integrativi',{ts '2018-06-11 11:35:00.653'},'ferdinando','C')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '4')
UPDATE [tipoattform] SET description = 'Attività formative scelte dallo studente',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'D' WHERE idtipoattform = '4'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('4','Attività formative scelte dallo studente',{ts '2018-06-11 11:35:00.653'},'ferdinando','D')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '5')
UPDATE [tipoattform] SET description = 'Attività formative relative alla prova finale e al conseguimento del titolo',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'E' WHERE idtipoattform = '5'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('5','Attività formative relative alla prova finale e al conseguimento del titolo',{ts '2018-06-11 11:35:00.653'},'ferdinando','E')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '6')
UPDATE [tipoattform] SET description = 'Altre attività volte alla conoscenza di una lingua, abilità informatiche, relazionali o utili nell''inserimento del mondo del lavoro, tirocini formativi e di orientamento, ecc.',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'F' WHERE idtipoattform = '6'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('6','Altre attività volte alla conoscenza di una lingua, abilità informatiche, relazionali o utili nell''inserimento del mondo del lavoro, tirocini formativi e di orientamento, ecc.',{ts '2018-06-11 11:35:00.653'},'ferdinando','F')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '7')
UPDATE [tipoattform] SET description = 'Attività formative in ambiti disciplinari affini o integrativi a quelli di base e caratterizzanti, anche con riguardo alle culture di contesto e alla formazione interdisciplinare ',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'R' WHERE idtipoattform = '7'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('7','Attività formative in ambiti disciplinari affini o integrativi a quelli di base e caratterizzanti, anche con riguardo alle culture di contesto e alla formazione interdisciplinare ',{ts '2018-06-11 11:35:00.653'},'ferdinando','R')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '8')
UPDATE [tipoattform] SET description = 'Attività formative per stages, tirocinipresso imprese o enti pubblici o privati, ordini professionali',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'S' WHERE idtipoattform = '8'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('8','Attività formative per stages, tirocinipresso imprese o enti pubblici o privati, ordini professionali',{ts '2018-06-11 11:35:00.653'},'ferdinando','S')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '14')
UPDATE [tipoattform] SET description = '-',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = '9' WHERE idtipoattform = '14'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('14','-',{ts '2018-06-11 11:35:00.653'},'ferdinando','9')
GO

IF exists(SELECT * FROM [tipoattform] WHERE idtipoattform = '15')
UPDATE [tipoattform] SET description = 'Attività formative caratterizzanti transitate ed affini',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',title = 'T' WHERE idtipoattform = '15'
ELSE
INSERT INTO [tipoattform] (idtipoattform,description,lt,lu,title) VALUES ('15','Attività formative caratterizzanti transitate ed affini',{ts '2018-06-11 11:35:00.653'},'ferdinando','T')
GO

