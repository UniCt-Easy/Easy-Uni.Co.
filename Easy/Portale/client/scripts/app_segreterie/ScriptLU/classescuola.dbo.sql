
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


-- CREAZIONE TABELLA classescuola --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[classescuola]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[classescuola] (
idclassescuola int NOT NULL,
idclassescuolaarea int NULL,
idclassescuolakind nvarchar(50) NULL,
idcorsostudionorma int NULL,
indicecineca int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
obbform nvarchar(max) NULL,
prospocc nvarchar(max) NULL,
sigla varchar(50) NULL,
title varchar(256) NOT NULL,
 CONSTRAINT xpkclassescuola PRIMARY KEY (idclassescuola
)
)
END
GO

-- VERIFICA STRUTTURA classescuola --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuola' and C.name = 'idclassescuola' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuola] ADD idclassescuola int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuola') and col.name = 'idclassescuola' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuola] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuola' and C.name = 'idclassescuolaarea' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuola] ADD idclassescuolaarea int NULL 
END
ELSE
	ALTER TABLE [classescuola] ALTER COLUMN idclassescuolaarea int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuola' and C.name = 'idclassescuolakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuola] ADD idclassescuolakind nvarchar(50) NULL 
END
ELSE
	ALTER TABLE [classescuola] ALTER COLUMN idclassescuolakind nvarchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuola' and C.name = 'idcorsostudionorma' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuola] ADD idcorsostudionorma int NULL 
END
ELSE
	ALTER TABLE [classescuola] ALTER COLUMN idcorsostudionorma int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuola' and C.name = 'indicecineca' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuola] ADD indicecineca int NULL 
END
ELSE
	ALTER TABLE [classescuola] ALTER COLUMN indicecineca int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuola' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuola] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuola') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuola] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuola] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuola' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuola] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuola') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuola] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuola] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuola' and C.name = 'obbform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuola] ADD obbform nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [classescuola] ALTER COLUMN obbform nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuola' and C.name = 'prospocc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuola] ADD prospocc nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [classescuola] ALTER COLUMN prospocc nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuola' and C.name = 'sigla' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuola] ADD sigla varchar(50) NULL 
END
ELSE
	ALTER TABLE [classescuola] ALTER COLUMN sigla varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuola' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuola] ADD title varchar(256) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuola') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuola] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [classescuola] ALTER COLUMN title varchar(256) NOT NULL
GO


-- GENERAZIONE DATI PER classescuola --
IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '1')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '2',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = null,title = 'SCUOLA DI PITTURA' WHERE idclassescuola = '1'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('1',null,'A1','2',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,null,null,'SCUOLA DI PITTURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '2')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '2',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = null,title = 'SCUOLA DI SCULTURA' WHERE idclassescuola = '2'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('2',null,'A1','2',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,null,null,'SCUOLA DI SCULTURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '3')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '8',indicecineca = null,lt = {ts '2019-03-18 13:14:48.297'},lu = 'ASSISTENZA',obbform = 'Al termine degli studi relativi al Diploma Accademico di primo livello in Arpa, gli studenti devono
aver acquisito le conoscenze delle tecniche e le competenze specifiche tali da consentire loro di
realizzare concretamente la propria idea artistica. A tal fine sarà dato particolare rilievo allo studio
del repertorio più rappresentativo dello strumento - incluso quello d’insieme - e delle relative prassi
esecutive, anche con la finalità di sviluppare la capacità dello studente di interagire all’interno di
gruppi musicali diversamente composti. Tali obiettivi dovranno essere raggiunti anche favorendo lo
sviluppo della capacità percettiva dell’udito e di memorizzazione e con l’acquisizione di specifiche
conoscenze relative ai modelli organizzativi, compositivi ed analitici della musica ed alla loro
interazione.
Specifica cura dovrà essere dedicata all’acquisizione di adeguate tecniche di controllo posturale ed
emozionale. Al termine del Triennio gli studenti devono aver acquisito una conoscenza
approfondita degli aspetti stilistici, storici estetici generali e relativi al proprio specifico indirizzo.
Inoltre, con riferimento alla specificità dei singoli corsi, lo studente dovrà possedere adeguate
competenze riferite all’ambito dell’improvvisazione. E’ obiettivo formativo del corso anche
l’acquisizione di adeguate competenze nel campo dell’informatica musicale nonché quelle relative
ad una seconda lingua comunitaria. ',prospocc = 'Il corso offre allo studente possibilità di impiego nei seguenti ambiti:
- Strumentista solista
- Strumentista in gruppi da camera
- Strumentista in formazioni orchestrali da camera
- Strumentista in formazioni orchestrali sinfoniche
- Strumentista in formazioni orchestrali per il teatro musicale ',sigla = 'DCPL01',title = 'SCUOLA DI ARPA' WHERE idclassescuola = '3'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('3',null,'A1','8',null,{ts '2019-03-18 13:14:48.297'},'ASSISTENZA','Al termine degli studi relativi al Diploma Accademico di primo livello in Arpa, gli studenti devono
aver acquisito le conoscenze delle tecniche e le competenze specifiche tali da consentire loro di
realizzare concretamente la propria idea artistica. A tal fine sarà dato particolare rilievo allo studio
del repertorio più rappresentativo dello strumento - incluso quello d’insieme - e delle relative prassi
esecutive, anche con la finalità di sviluppare la capacità dello studente di interagire all’interno di
gruppi musicali diversamente composti. Tali obiettivi dovranno essere raggiunti anche favorendo lo
sviluppo della capacità percettiva dell’udito e di memorizzazione e con l’acquisizione di specifiche
conoscenze relative ai modelli organizzativi, compositivi ed analitici della musica ed alla loro
interazione.
Specifica cura dovrà essere dedicata all’acquisizione di adeguate tecniche di controllo posturale ed
emozionale. Al termine del Triennio gli studenti devono aver acquisito una conoscenza
approfondita degli aspetti stilistici, storici estetici generali e relativi al proprio specifico indirizzo.
Inoltre, con riferimento alla specificità dei singoli corsi, lo studente dovrà possedere adeguate
competenze riferite all’ambito dell’improvvisazione. E’ obiettivo formativo del corso anche
l’acquisizione di adeguate competenze nel campo dell’informatica musicale nonché quelle relative
ad una seconda lingua comunitaria. ','Il corso offre allo studente possibilità di impiego nei seguenti ambiti:
- Strumentista solista
- Strumentista in gruppi da camera
- Strumentista in formazioni orchestrali da camera
- Strumentista in formazioni orchestrali sinfoniche
- Strumentista in formazioni orchestrali per il teatro musicale ','DCPL01','SCUOLA DI ARPA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '5')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '2',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = null,title = 'SCUOLA DI DECORAZIONE ' WHERE idclassescuola = '5'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('5',null,'A1','2',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,null,null,'SCUOLA DI DECORAZIONE ')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '6')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '2',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = null,title = 'SCUOLA DI GRAFICA ' WHERE idclassescuola = '6'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('6',null,'A1','2',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,null,null,'SCUOLA DI GRAFICA ')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '7')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '2',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = null,title = 'SCUOLA DI SCENOGRAFIA ' WHERE idclassescuola = '7'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('7',null,'A1','2',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,null,null,'SCUOLA DI SCENOGRAFIA ')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '8')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '2',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = null,title = 'SCUOLA DI PROGETTAZIONE ARTISTICA PER L''IMPRESA ' WHERE idclassescuola = '8'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('8',null,'A1','2',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,null,null,'SCUOLA DI PROGETTAZIONE ARTISTICA PER L''IMPRESA ')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '9')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '2',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = null,title = 'SCUOLA DI RESTAURO ' WHERE idclassescuola = '9'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('9',null,'A1','2',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,null,null,'SCUOLA DI RESTAURO ')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '10')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '2',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = null,title = 'SCUOLA DI NUOVE TECNOLOGIE DELL''ARTE' WHERE idclassescuola = '10'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('10',null,'A1','2',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,null,null,'SCUOLA DI NUOVE TECNOLOGIE DELL''ARTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '11')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '2',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = null,title = 'SCUOLA DI COMUNICAZIONE E VALORIZZAZIONE DEL PATRIMONIO ARTISTICO CONTEMPORANEO ' WHERE idclassescuola = '11'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('11',null,'A1','2',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,null,null,'SCUOLA DI COMUNICAZIONE E VALORIZZAZIONE DEL PATRIMONIO ARTISTICO CONTEMPORANEO ')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '12')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '2',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = null,title = 'SCUOLA DI DIDATTICA DELL''ARTE ' WHERE idclassescuola = '12'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('12',null,'A1','2',null,{ts '2018-06-11 11:35:00.653'},'ferdinando',null,null,null,'SCUOLA DI DIDATTICA DELL''ARTE ')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '14')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '8',indicecineca = null,lt = {ts '2019-09-05 09:23:28.387'},lu = 'ASSISTENZA',obbform = null,prospocc = null,sigla = 'DCPL57',title = 'SCUOLA DI VIOLONCELLO' WHERE idclassescuola = '14'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('14',null,'A1','8',null,{ts '2019-09-05 09:23:28.387'},'ASSISTENZA',null,null,'DCPL57','SCUOLA DI VIOLONCELLO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '17')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '1',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '1',title = 'Biotecnologie' WHERE idclassescuola = '17'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('17','2','LT','33','1',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'1','Biotecnologie')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '18')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '2',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '2',title = 'Scienze dei servizi giuridici' WHERE idclassescuola = '18'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('18','3','LT','33','2',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'2','Scienze dei servizi giuridici')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '19')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '3',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '3',title = 'Scienze della mediazione linguistica' WHERE idclassescuola = '19'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('19','4','LT','33','3',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'3','Scienze della mediazione linguistica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '20')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '4',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '4',title = 'Scienze dell''architettura e dell''ingegneria edile' WHERE idclassescuola = '20'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('20','2','LT','33','4',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'4','Scienze dell''architettura e dell''ingegneria edile')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '21')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '5',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '5',title = 'Lettere' WHERE idclassescuola = '21'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('21','4','LT','33','5',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'5','Lettere')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '22')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '6',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '6',title = 'Scienze del servizio sociale' WHERE idclassescuola = '22'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('22','3','LT','33','6',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'6','Scienze del servizio sociale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '23')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '7',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '7',title = 'Urbanistica e scienze della pianificazione territoriale e ambientale' WHERE idclassescuola = '23'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('23','2','LT','33','7',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'7','Urbanistica e scienze della pianificazione territoriale e ambientale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '24')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '8',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '8',title = 'Ingegneria civile e ambientale' WHERE idclassescuola = '24'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('24','2','LT','33','8',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'8','Ingegneria civile e ambientale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '25')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '9',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '9',title = 'Ingegneria dell''informazione' WHERE idclassescuola = '25'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('25','2','LT','33','9',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'9','Ingegneria dell''informazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '26')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '10',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '10',title = 'Ingegneria industriale' WHERE idclassescuola = '26'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('26','2','LT','33','10',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'10','Ingegneria industriale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '27')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '11',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '11',title = 'Lingue e culture moderne' WHERE idclassescuola = '27'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('27','4','LT','33','11',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'11','Lingue e culture moderne')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '28')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '12',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '12',title = 'Scienze biologiche' WHERE idclassescuola = '28'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('28','2','LT','33','12',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'12','Scienze biologiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '29')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '13',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '13',title = 'Scienze dei beni culturali' WHERE idclassescuola = '29'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('29','4','LT','33','13',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'13','Scienze dei beni culturali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '30')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '14',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '14',title = 'Scienze della comunicazione' WHERE idclassescuola = '30'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('30','3','LT','33','14',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'14','Scienze della comunicazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '31')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '15',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '15',title = 'Scienze politiche e delle relazioni internazionali' WHERE idclassescuola = '31'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('31','3','LT','33','15',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'15','Scienze politiche e delle relazioni internazionali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '32')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '16',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '16',title = 'Scienze della Terra' WHERE idclassescuola = '32'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('32','2','LT','33','16',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'16','Scienze della Terra')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '33')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '17',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '17',title = 'Scienze dell''economia e della gestione aziendale' WHERE idclassescuola = '33'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('33','3','LT','33','17',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'17','Scienze dell''economia e della gestione aziendale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '34')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '18',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '18',title = 'Scienze dell''educazione e della formazione' WHERE idclassescuola = '34'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('34','4','LT','33','18',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'18','Scienze dell''educazione e della formazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '35')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '19',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '19',title = 'Scienze dell''amministrazione' WHERE idclassescuola = '35'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('35','3','LT','33','19',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'19','Scienze dell''amministrazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '36')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '20',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '20',title = 'Scienze e tecnologie agrarie, agroalimentari e forestali' WHERE idclassescuola = '36'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('36','2','LT','33','20',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'20','Scienze e tecnologie agrarie, agroalimentari e forestali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '37')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '21',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '21',title = 'Scienze e tecnologie chimiche' WHERE idclassescuola = '37'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('37','2','LT','33','21',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'21','Scienze e tecnologie chimiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '38')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '22',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '22',title = 'Scienze e tecnologie della navigazione marittima e aerea' WHERE idclassescuola = '38'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('38','2','LT','33','22',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'22','Scienze e tecnologie della navigazione marittima e aerea')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '39')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '23',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '23',title = 'Scienze e tecnologie delle arti figurative, della musica, dello spettacolo e della moda' WHERE idclassescuola = '39'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('39','4','LT','33','23',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'23','Scienze e tecnologie delle arti figurative, della musica, dello spettacolo e della moda')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '40')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '24',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '24',title = 'Scienze e tecnologie farmaceutiche' WHERE idclassescuola = '40'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('40','1','LT','33','24',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'24','Scienze e tecnologie farmaceutiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '41')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '25',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '25',title = 'Scienze e tecnologie fisiche' WHERE idclassescuola = '41'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('41','2','LT','33','25',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'25','Scienze e tecnologie fisiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '42')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '26',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '26',title = 'Scienze e tecnologie informatiche' WHERE idclassescuola = '42'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('42','2','LT','33','26',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'26','Scienze e tecnologie informatiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '43')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '27',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '27',title = 'Scienze e tecnologie per l''ambiente e la natura' WHERE idclassescuola = '43'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('43','2','LT','33','27',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'27','Scienze e tecnologie per l''ambiente e la natura')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '44')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '28',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '28',title = 'Scienze economiche' WHERE idclassescuola = '44'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('44','3','LT','33','28',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'28','Scienze economiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '45')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '29',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '29',title = 'Filosofia' WHERE idclassescuola = '45'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('45','4','LT','33','29',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'29','Filosofia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '46')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '30',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '30',title = 'Scienze geografiche' WHERE idclassescuola = '46'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('46','4','LT','33','30',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'30','Scienze geografiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '47')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '31',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '31',title = 'Scienze giuridiche' WHERE idclassescuola = '47'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('47','3','LT','33','31',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'31','Scienze giuridiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '48')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '32',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '32',title = 'Scienze matematiche' WHERE idclassescuola = '48'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('48','2','LT','33','32',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'32','Scienze matematiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '49')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '33',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '33',title = 'Scienze delle attivita motorie e sportive' WHERE idclassescuola = '49'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('49','2','LT','33','33',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'33','Scienze delle attivita motorie e sportive')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '50')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '34',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '34',title = 'Scienze e tecniche psicologiche' WHERE idclassescuola = '50'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('50','3','LT','33','34',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'34','Scienze e tecniche psicologiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '51')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '35',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '35',title = 'Scienze sociali per la cooperazione, lo sviluppo e la pace' WHERE idclassescuola = '51'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('51','3','LT','33','35',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'35','Scienze sociali per la cooperazione, lo sviluppo e la pace')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '52')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '36',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '36',title = 'Scienze sociologiche' WHERE idclassescuola = '52'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('52','3','LT','33','36',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'36','Scienze sociologiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '53')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '37',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '37',title = 'Scienze statistiche' WHERE idclassescuola = '53'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('53','2','LT','33','37',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'37','Scienze statistiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '54')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '38',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '38',title = 'Scienze storiche' WHERE idclassescuola = '54'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('54','4','LT','33','38',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'38','Scienze storiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '55')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '39',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '39',title = 'Scienze del turismo' WHERE idclassescuola = '55'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('55','3','LT','33','39',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'39','Scienze del turismo')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '56')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '40',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '40',title = 'Scienze e tecnologie zootecniche e delle produzioni animali' WHERE idclassescuola = '56'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('56','2','LT','33','40',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'40','Scienze e tecnologie zootecniche e delle produzioni animali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '57')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '41',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '41',title = 'Tecnologie per la conservazione e il restauro dei beni culturali' WHERE idclassescuola = '57'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('57','2','LT','33','41',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'41','Tecnologie per la conservazione e il restauro dei beni culturali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '58')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '42',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '42',title = 'Disegno industriale' WHERE idclassescuola = '58'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('58','2','LT','33','42',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'42','Disegno industriale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '59')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '43',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SNT/1',title = 'Professioni sanitarie, infermieristiche e professione sanitaria ostetrica' WHERE idclassescuola = '59'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('59','1','LT','33','43',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SNT/1','Professioni sanitarie, infermieristiche e professione sanitaria ostetrica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '60')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '44',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SNT/2',title = 'Professioni sanitarie della riabilitazione' WHERE idclassescuola = '60'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('60','1','LT','33','44',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SNT/2','Professioni sanitarie della riabilitazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '61')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '45',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SNT/3',title = 'Professioni sanitarie tecniche' WHERE idclassescuola = '61'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('61','1','LT','33','45',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SNT/3','Professioni sanitarie tecniche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '62')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '46',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SNT/4',title = 'Professioni sanitarie della prevenzione' WHERE idclassescuola = '62'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('62','1','LT','33','46',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SNT/4','Professioni sanitarie della prevenzione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '63')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LT',idcorsostudionorma = '33',indicecineca = '47',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'DS/1',title = 'Scienze della difesa e della sicurezza' WHERE idclassescuola = '63'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('63','3','LT','33','47',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'DS/1','Scienze della difesa e della sicurezza')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '64')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1001',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '1/S',title = 'Specialistiche in antropologia culturale ed etnologia' WHERE idclassescuola = '64'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('64','4','LS','33','1001',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'1/S','Specialistiche in antropologia culturale ed etnologia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '65')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1002',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '2/S',title = 'Specialistiche in archeologia' WHERE idclassescuola = '65'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('65','4','LS','33','1002',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'2/S','Specialistiche in archeologia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '66')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1003',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '3/S',title = 'Specialistiche in architettura del paesaggio' WHERE idclassescuola = '66'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('66','2','LS','33','1003',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'3/S','Specialistiche in architettura del paesaggio')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '67')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'TU',idcorsostudionorma = '33',indicecineca = '1004',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '4/S',title = 'Specialistiche in architettura e ingegneria edile' WHERE idclassescuola = '67'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('67','2','TU','33','1004',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'4/S','Specialistiche in architettura e ingegneria edile')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '68')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1005',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '5/S',title = 'Specialistiche in archivistica e biblioteconomia' WHERE idclassescuola = '68'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('68','4','LS','33','1005',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'5/S','Specialistiche in archivistica e biblioteconomia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '69')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1006',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '6/S',title = 'Specialistiche in biologia' WHERE idclassescuola = '69'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('69','2','LS','33','1006',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'6/S','Specialistiche in biologia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '70')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1007',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '7/S',title = 'Specialistiche in biotecnologie agrarie' WHERE idclassescuola = '70'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('70','2','LS','33','1007',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'7/S','Specialistiche in biotecnologie agrarie')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '71')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1008',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '8/S',title = 'Specialistiche in biotecnologie industriali' WHERE idclassescuola = '71'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('71','2','LS','33','1008',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'8/S','Specialistiche in biotecnologie industriali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '72')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1009',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '9/S',title = 'Specialistiche in biotecnologie mediche, veterinarie e farmaceutiche' WHERE idclassescuola = '72'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('72','2','LS','33','1009',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'9/S','Specialistiche in biotecnologie mediche, veterinarie e farmaceutiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '73')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1010',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '10/S',title = 'Specialistiche in conservazione dei beni architettonici e ambientali' WHERE idclassescuola = '73'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('73','4','LS','33','1010',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'10/S','Specialistiche in conservazione dei beni architettonici e ambientali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '74')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1011',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '11/S',title = 'Specialistiche in conservazione dei beni scientifici e della civilta industriale' WHERE idclassescuola = '74'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('74','4','LS','33','1011',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'11/S','Specialistiche in conservazione dei beni scientifici e della civilta industriale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '75')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1012',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '12/S',title = 'Specialistiche in conservazione e restauro del patrimonio storico-artistico' WHERE idclassescuola = '75'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('75','4','LS','33','1012',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'12/S','Specialistiche in conservazione e restauro del patrimonio storico-artistico')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '76')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1013',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '13/S',title = 'Specialistiche in editoria, comunicazione multimediale e giornalismo' WHERE idclassescuola = '76'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('76','4','LS','33','1013',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'13/S','Specialistiche in editoria, comunicazione multimediale e giornalismo')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '77')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'TU',idcorsostudionorma = '33',indicecineca = '1014',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '14/S',title = 'Specialistiche in farmacia e farmacia industriale' WHERE idclassescuola = '77'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('77','1','TU','33','1014',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'14/S','Specialistiche in farmacia e farmacia industriale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '78')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1015',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '15/S',title = 'Specialistiche in filologia e letterature dell''antichita' WHERE idclassescuola = '78'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('78','4','LS','33','1015',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'15/S','Specialistiche in filologia e letterature dell''antichita')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '79')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1016',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '16/S',title = 'Specialistiche in filologia moderna' WHERE idclassescuola = '79'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('79','4','LS','33','1016',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'16/S','Specialistiche in filologia moderna')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '80')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1017',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '17/S',title = 'Specialistiche in filosofia e storia della scienza' WHERE idclassescuola = '80'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('80','4','LS','33','1017',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'17/S','Specialistiche in filosofia e storia della scienza')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '81')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1018',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '18/S',title = 'Specialistiche in filosofia teoretica, morale, politica ed estetica' WHERE idclassescuola = '81'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('81','4','LS','33','1018',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'18/S','Specialistiche in filosofia teoretica, morale, politica ed estetica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '82')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1019',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '19/S',title = 'Specialistiche in finanza' WHERE idclassescuola = '82'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('82','3','LS','33','1019',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'19/S','Specialistiche in finanza')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '83')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1020',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '20/S',title = 'Specialistiche in fisica' WHERE idclassescuola = '83'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('83','2','LS','33','1020',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'20/S','Specialistiche in fisica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '84')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1021',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '21/S',title = 'Specialistiche in geografia' WHERE idclassescuola = '84'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('84','4','LS','33','1021',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'21/S','Specialistiche in geografia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '85')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1022',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '22/S',title = 'Specialistiche in giurisprudenza' WHERE idclassescuola = '85'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('85','3','LS','33','1022',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'22/S','Specialistiche in giurisprudenza')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '86')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1023',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '23/S',title = 'Specialistiche in informatica' WHERE idclassescuola = '86'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('86','2','LS','33','1023',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'23/S','Specialistiche in informatica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '87')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1024',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '24/S',title = 'Specialistiche in informatica per le discipline umanistiche' WHERE idclassescuola = '87'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('87','2','LS','33','1024',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'24/S','Specialistiche in informatica per le discipline umanistiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '88')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1025',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '25/S',title = 'Specialistiche in ingegneria aerospaziale e astronautica' WHERE idclassescuola = '88'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('88','2','LS','33','1025',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'25/S','Specialistiche in ingegneria aerospaziale e astronautica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '89')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1026',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '26/S',title = 'Specialistiche in ingegneria biomedica' WHERE idclassescuola = '89'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('89','2','LS','33','1026',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'26/S','Specialistiche in ingegneria biomedica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '90')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1027',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '27/S',title = 'Specialistiche in ingegneria chimica' WHERE idclassescuola = '90'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('90','2','LS','33','1027',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'27/S','Specialistiche in ingegneria chimica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '91')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1028',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '28/S',title = 'Specialistiche in ingegneria civile' WHERE idclassescuola = '91'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('91','2','LS','33','1028',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'28/S','Specialistiche in ingegneria civile')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '92')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1029',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '29/S',title = 'Specialistiche in ingegneria dell''automazione' WHERE idclassescuola = '92'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('92','2','LS','33','1029',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'29/S','Specialistiche in ingegneria dell''automazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '93')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1030',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '30/S',title = 'Specialistiche in ingegneria delle telecomunicazioni' WHERE idclassescuola = '93'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('93','2','LS','33','1030',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'30/S','Specialistiche in ingegneria delle telecomunicazioni')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '94')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1031',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '31/S',title = 'Specialistiche in ingegneria elettrica' WHERE idclassescuola = '94'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('94','2','LS','33','1031',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'31/S','Specialistiche in ingegneria elettrica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '95')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1032',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '32/S',title = 'Specialistiche in ingegneria elettronica' WHERE idclassescuola = '95'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('95','2','LS','33','1032',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'32/S','Specialistiche in ingegneria elettronica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '96')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1033',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '33/S',title = 'Specialistiche in ingegneria energetica e nucleare' WHERE idclassescuola = '96'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('96','2','LS','33','1033',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'33/S','Specialistiche in ingegneria energetica e nucleare')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '97')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1034',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '34/S',title = 'Specialistiche in ingegneria gestionale' WHERE idclassescuola = '97'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('97','2','LS','33','1034',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'34/S','Specialistiche in ingegneria gestionale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '98')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1035',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '35/S',title = 'Specialistiche in ingegneria informatica' WHERE idclassescuola = '98'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('98','2','LS','33','1035',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'35/S','Specialistiche in ingegneria informatica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '99')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1036',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '36/S',title = 'Specialistiche in ingegneria meccanica' WHERE idclassescuola = '99'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('99','2','LS','33','1036',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'36/S','Specialistiche in ingegneria meccanica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '100')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1037',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '37/S',title = 'Specialistiche in ingegneria navale' WHERE idclassescuola = '100'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('100','2','LS','33','1037',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'37/S','Specialistiche in ingegneria navale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '101')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1038',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '38/S',title = 'Specialistiche in ingegneria per l''ambiente e il territorio' WHERE idclassescuola = '101'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('101','2','LS','33','1038',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'38/S','Specialistiche in ingegneria per l''ambiente e il territorio')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '102')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1039',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '39/S',title = 'Specialistiche in interpretariato di conferenza' WHERE idclassescuola = '102'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('102','4','LS','33','1039',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'39/S','Specialistiche in interpretariato di conferenza')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '103')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1040',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '40/S',title = 'Specialistiche in lingua e cultura italiana' WHERE idclassescuola = '103'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('103','4','LS','33','1040',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'40/S','Specialistiche in lingua e cultura italiana')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '104')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1041',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '41/S',title = 'Specialistiche in lingue e letterature afroasiatiche' WHERE idclassescuola = '104'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('104','4','LS','33','1041',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'41/S','Specialistiche in lingue e letterature afroasiatiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '105')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1042',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '42/S',title = 'Specialistiche in lingue e letterature moderne euroamericane' WHERE idclassescuola = '105'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('105','4','LS','33','1042',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'42/S','Specialistiche in lingue e letterature moderne euroamericane')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '106')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1043',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '43/S',title = 'Specialistiche in lingue straniere per la comunicazione internazionale' WHERE idclassescuola = '106'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('106','4','LS','33','1043',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'43/S','Specialistiche in lingue straniere per la comunicazione internazionale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '107')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1044',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '44/S',title = 'Specialistiche in linguistica' WHERE idclassescuola = '107'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('107','4','LS','33','1044',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'44/S','Specialistiche in linguistica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '108')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1045',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '45/S',title = 'Specialistiche in matematica' WHERE idclassescuola = '108'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('108','2','LS','33','1045',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'45/S','Specialistiche in matematica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '109')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'TU',idcorsostudionorma = '33',indicecineca = '1046',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '46/S',title = 'Specialistiche in medicina e chirurgia' WHERE idclassescuola = '109'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('109','1','TU','33','1046',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'46/S','Specialistiche in medicina e chirurgia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '110')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'TU',idcorsostudionorma = '33',indicecineca = '1047',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '47/S',title = 'Specialistiche in medicina veterinaria' WHERE idclassescuola = '110'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('110','1','TU','33','1047',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'47/S','Specialistiche in medicina veterinaria')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '111')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1048',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '48/S',title = 'Specialistiche in metodi per l''analisi valutativa dei sistemi complessi' WHERE idclassescuola = '111'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('111','3','LS','33','1048',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'48/S','Specialistiche in metodi per l''analisi valutativa dei sistemi complessi')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '112')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1049',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '49/S',title = 'Specialistiche in metodi per la ricerca empirica nelle scienze sociali' WHERE idclassescuola = '112'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('112','3','LS','33','1049',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'49/S','Specialistiche in metodi per la ricerca empirica nelle scienze sociali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '113')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1050',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '50/S',title = 'Specialistiche in modellistica matematico-fisica per l''ingegneria' WHERE idclassescuola = '113'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('113','2','LS','33','1050',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'50/S','Specialistiche in modellistica matematico-fisica per l''ingegneria')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '114')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1051',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '51/S',title = 'Specialistiche in musicologia e beni musicali' WHERE idclassescuola = '114'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('114','4','LS','33','1051',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'51/S','Specialistiche in musicologia e beni musicali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '115')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'TU',idcorsostudionorma = '33',indicecineca = '1052',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '52/S',title = 'Specialistiche in odontoiatria e protesi dentaria' WHERE idclassescuola = '115'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('115','1','TU','33','1052',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'52/S','Specialistiche in odontoiatria e protesi dentaria')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '116')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1053',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '53/S',title = 'Specialistiche in organizzazione e gestione dei servizi per lo sport e le attivita motorie' WHERE idclassescuola = '116'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('116','2','LS','33','1053',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'53/S','Specialistiche in organizzazione e gestione dei servizi per lo sport e le attivita motorie')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '117')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1054',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '54/S',title = 'Specialistiche in pianificazione territoriale urbanistica e ambientale' WHERE idclassescuola = '117'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('117','2','LS','33','1054',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'54/S','Specialistiche in pianificazione territoriale urbanistica e ambientale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '118')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1055',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '55/S',title = 'Specialistiche in progettazione e gestione dei sistemi turistici' WHERE idclassescuola = '118'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('118','3','LS','33','1055',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'55/S','Specialistiche in progettazione e gestione dei sistemi turistici')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '119')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1056',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '56/S',title = 'Specialistiche in programmazione e gestione dei servizi educativi e formativi' WHERE idclassescuola = '119'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('119','3','LS','33','1056',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'56/S','Specialistiche in programmazione e gestione dei servizi educativi e formativi')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '120')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1057',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '57/S',title = 'Specialistiche in programmazione e gestione delle politiche e dei servizi sociali' WHERE idclassescuola = '120'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('120','3','LS','33','1057',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'57/S','Specialistiche in programmazione e gestione delle politiche e dei servizi sociali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '121')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1058',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '58/S',title = 'Specialistiche in psicologia' WHERE idclassescuola = '121'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('121','3','LS','33','1058',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'58/S','Specialistiche in psicologia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '122')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1059',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '59/S',title = 'Specialistiche in pubblicita e comunicazione d''impresa' WHERE idclassescuola = '122'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('122','3','LS','33','1059',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'59/S','Specialistiche in pubblicita e comunicazione d''impresa')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '123')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1060',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '60/S',title = 'Specialistiche in relazioni internazionali' WHERE idclassescuola = '123'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('123','3','LS','33','1060',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'60/S','Specialistiche in relazioni internazionali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '124')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1061',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '61/S',title = 'Specialistiche in scienza e ingegneria dei materiali' WHERE idclassescuola = '124'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('124','2','LS','33','1061',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'61/S','Specialistiche in scienza e ingegneria dei materiali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '125')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1062',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '62/S',title = 'Specialistiche in scienze chimiche' WHERE idclassescuola = '125'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('125','2','LS','33','1062',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'62/S','Specialistiche in scienze chimiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '126')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1063',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '63/S',title = 'Specialistiche in scienze cognitive' WHERE idclassescuola = '126'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('126','4','LS','33','1063',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'63/S','Specialistiche in scienze cognitive')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '127')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1064',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '64/S',title = 'Specialistiche in scienze dell''economia' WHERE idclassescuola = '127'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('127','3','LS','33','1064',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'64/S','Specialistiche in scienze dell''economia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '128')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1065',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '65/S',title = 'Specialistiche in scienze dell''educazione degli adulti e della formazione continua' WHERE idclassescuola = '128'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('128','3','LS','33','1065',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'65/S','Specialistiche in scienze dell''educazione degli adulti e della formazione continua')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '129')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1066',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '66/S',title = 'Specialistiche in scienze dell''universo' WHERE idclassescuola = '129'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('129','2','LS','33','1066',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'66/S','Specialistiche in scienze dell''universo')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '130')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1067',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '67/S',title = 'Specialistiche in scienze della comunicazione sociale e istituzionale' WHERE idclassescuola = '130'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('130','3','LS','33','1067',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'67/S','Specialistiche in scienze della comunicazione sociale e istituzionale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '131')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1068',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '68/S',title = 'Specialistiche in scienze della natura' WHERE idclassescuola = '131'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('131','2','LS','33','1068',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'68/S','Specialistiche in scienze della natura')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '132')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1069',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '69/S',title = 'Specialistiche in scienze della nutrizione umana' WHERE idclassescuola = '132'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('132','2','LS','33','1069',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'69/S','Specialistiche in scienze della nutrizione umana')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '133')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1070',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '70/S',title = 'Specialistiche in scienze della politica' WHERE idclassescuola = '133'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('133','3','LS','33','1070',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'70/S','Specialistiche in scienze della politica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '134')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1071',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '71/S',title = 'Specialistiche in scienze delle pubbliche amministrazioni' WHERE idclassescuola = '134'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('134','3','LS','33','1071',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'71/S','Specialistiche in scienze delle pubbliche amministrazioni')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '135')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1072',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '72/S',title = 'Specialistiche in scienze delle religioni' WHERE idclassescuola = '135'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('135','4','LS','33','1072',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'72/S','Specialistiche in scienze delle religioni')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '136')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1073',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '73/S',title = 'Specialistiche in scienze dello spettacolo e della produzione multimediale' WHERE idclassescuola = '136'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('136','3','LS','33','1073',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'73/S','Specialistiche in scienze dello spettacolo e della produzione multimediale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '137')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1074',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '74/S',title = 'Specialistiche in scienze e gestione delle risorse rurali e forestali' WHERE idclassescuola = '137'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('137','2','LS','33','1074',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'74/S','Specialistiche in scienze e gestione delle risorse rurali e forestali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '138')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1075',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '75/S',title = 'Specialistiche in scienze e tecnica dello sport' WHERE idclassescuola = '138'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('138','2','LS','33','1075',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'75/S','Specialistiche in scienze e tecnica dello sport')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '139')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1076',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '76/S',title = 'Specialistiche in scienze e tecniche delle attivita motorie preventive e adattative' WHERE idclassescuola = '139'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('139','2','LS','33','1076',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'76/S','Specialistiche in scienze e tecniche delle attivita motorie preventive e adattative')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '140')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1077',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '77/S',title = 'Specialistiche in scienze e tecnologie agrarie' WHERE idclassescuola = '140'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('140','2','LS','33','1077',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'77/S','Specialistiche in scienze e tecnologie agrarie')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '141')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1078',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '78/S',title = 'Specialistiche in scienze e tecnologie agroalimentari' WHERE idclassescuola = '141'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('141','2','LS','33','1078',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'78/S','Specialistiche in scienze e tecnologie agroalimentari')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '142')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1079',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '79/S',title = 'Specialistiche in scienze e tecnologie agrozootecniche' WHERE idclassescuola = '142'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('142','2','LS','33','1079',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'79/S','Specialistiche in scienze e tecnologie agrozootecniche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '143')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1080',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '80/S',title = 'Specialistiche in scienze e tecnologie dei sistemi di navigazione' WHERE idclassescuola = '143'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('143','2','LS','33','1080',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'80/S','Specialistiche in scienze e tecnologie dei sistemi di navigazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '144')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1081',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '81/S',title = 'Specialistiche in scienze e tecnologie della chimica industriale' WHERE idclassescuola = '144'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('144','2','LS','33','1081',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'81/S','Specialistiche in scienze e tecnologie della chimica industriale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '145')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1082',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '82/S',title = 'Specialistiche in scienze e tecnologie per l''ambiente e il territorio' WHERE idclassescuola = '145'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('145','2','LS','33','1082',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'82/S','Specialistiche in scienze e tecnologie per l''ambiente e il territorio')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '146')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1083',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '83/S',title = 'Specialistiche in scienze economiche per l''ambiente e la cultura' WHERE idclassescuola = '146'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('146','3','LS','33','1083',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'83/S','Specialistiche in scienze economiche per l''ambiente e la cultura')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '147')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1084',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '84/S',title = 'Specialistiche in scienze economico-aziendali' WHERE idclassescuola = '147'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('147','3','LS','33','1084',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'84/S','Specialistiche in scienze economico-aziendali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '148')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1085',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '85/S',title = 'Specialistiche in scienze geofisiche' WHERE idclassescuola = '148'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('148','2','LS','33','1085',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'85/S','Specialistiche in scienze geofisiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '149')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1086',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '86/S',title = 'Specialistiche in scienze geologiche' WHERE idclassescuola = '149'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('149','2','LS','33','1086',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'86/S','Specialistiche in scienze geologiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '150')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1087',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '87/S',title = 'Specialistiche in scienze pedagogiche' WHERE idclassescuola = '150'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('150','3','LS','33','1087',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'87/S','Specialistiche in scienze pedagogiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '151')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1088',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '88/S',title = 'Specialistiche in scienze per la cooperazione allo sviluppo' WHERE idclassescuola = '151'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('151','3','LS','33','1088',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'88/S','Specialistiche in scienze per la cooperazione allo sviluppo')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '152')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1089',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '89/S',title = 'Specialistiche in sociologia' WHERE idclassescuola = '152'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('152','3','LS','33','1089',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'89/S','Specialistiche in sociologia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '153')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1090',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '90/S',title = 'Specialistiche in statistica demografica e sociale' WHERE idclassescuola = '153'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('153','3','LS','33','1090',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'90/S','Specialistiche in statistica demografica e sociale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '154')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1091',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '91/S',title = 'Specialistiche in statistica economica, finanziaria ed attuariale' WHERE idclassescuola = '154'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('154','3','LS','33','1091',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'91/S','Specialistiche in statistica economica, finanziaria ed attuariale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '155')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1092',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '92/S',title = 'Specialistiche in statistica per la ricerca sperimentale' WHERE idclassescuola = '155'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('155','3','LS','33','1092',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'92/S','Specialistiche in statistica per la ricerca sperimentale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '156')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1093',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '93/S',title = 'Specialistiche in storia antica' WHERE idclassescuola = '156'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('156','4','LS','33','1093',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'93/S','Specialistiche in storia antica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '157')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1094',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '94/S',title = 'Specialistiche in storia contemporanea' WHERE idclassescuola = '157'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('157','4','LS','33','1094',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'94/S','Specialistiche in storia contemporanea')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '158')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1095',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '95/S',title = 'Specialistiche in storia dell''arte' WHERE idclassescuola = '158'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('158','4','LS','33','1095',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'95/S','Specialistiche in storia dell''arte')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '159')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1096',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '96/S',title = 'Specialistiche in storia della filosofia' WHERE idclassescuola = '159'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('159','4','LS','33','1096',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'96/S','Specialistiche in storia della filosofia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '160')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1097',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '97/S',title = 'Specialistiche in storia medievale' WHERE idclassescuola = '160'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('160','4','LS','33','1097',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'97/S','Specialistiche in storia medievale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '161')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1098',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '98/S',title = 'Specialistiche in storia moderna' WHERE idclassescuola = '161'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('161','4','LS','33','1098',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'98/S','Specialistiche in storia moderna')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '162')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1099',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '99/S',title = 'Specialistiche in studi europei' WHERE idclassescuola = '162'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('162','3','LS','33','1099',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'99/S','Specialistiche in studi europei')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '163')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1100',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '100/S',title = 'Specialistiche in tecniche e metodi per la societa dell''informazione' WHERE idclassescuola = '163'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('163','3','LS','33','1100',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'100/S','Specialistiche in tecniche e metodi per la societa dell''informazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '164')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1101',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '101/S',title = 'Specialistiche in teoria della comunicazione' WHERE idclassescuola = '164'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('164','3','LS','33','1101',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'101/S','Specialistiche in teoria della comunicazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '165')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1102',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '102/S',title = 'Specialistiche in teoria e tecniche della normazione e dell''informazione giuridica' WHERE idclassescuola = '165'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('165','3','LS','33','1102',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'102/S','Specialistiche in teoria e tecniche della normazione e dell''informazione giuridica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '166')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1103',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '103/S',title = 'Specialistiche in teorie e metodi del disegno industriale' WHERE idclassescuola = '166'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('166','2','LS','33','1103',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'103/S','Specialistiche in teorie e metodi del disegno industriale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '167')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1104',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '104/S',title = 'Specialistiche in traduzione letteraria e in traduzione tecnico-scientifica' WHERE idclassescuola = '167'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('167','4','LS','33','1104',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'104/S','Specialistiche in traduzione letteraria e in traduzione tecnico-scientifica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '168')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1105',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'DS/S',title = 'Specialistiche nelle scienze della difesa e della sicurezza' WHERE idclassescuola = '168'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('168','3','LS','33','1105',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'DS/S','Specialistiche nelle scienze della difesa e della sicurezza')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '169')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1106',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SNT_SPEC/1',title = 'Specialistiche nelle scienze infermieristiche e ostetriche' WHERE idclassescuola = '169'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('169','1','LS','33','1106',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SNT_SPEC/1','Specialistiche nelle scienze infermieristiche e ostetriche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '170')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1107',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SNT_SPEC/2',title = 'Specialistiche nelle scienze delle professioni sanitarie della riabilitazione' WHERE idclassescuola = '170'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('170','1','LS','33','1107',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SNT_SPEC/2','Specialistiche nelle scienze delle professioni sanitarie della riabilitazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '171')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1108',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SNT_SPEC/3',title = 'Specialistiche nelle scienze delle professioni sanitarie tecniche' WHERE idclassescuola = '171'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('171','1','LS','33','1108',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SNT_SPEC/3','Specialistiche nelle scienze delle professioni sanitarie tecniche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '172')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'LS',idcorsostudionorma = '33',indicecineca = '1109',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SNT_SPEC/4',title = 'Specialistiche nelle scienze delle professioni sanitarie della prevenzione' WHERE idclassescuola = '172'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('172','1','LS','33','1109',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SNT_SPEC/4','Specialistiche nelle scienze delle professioni sanitarie della prevenzione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '173')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2001',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-1',title = 'Beni culturali' WHERE idclassescuola = '173'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('173','4','MT','34','2001',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-1','Beni culturali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '174')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2002',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-2',title = 'Biotecnologie' WHERE idclassescuola = '174'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('174','2','MT','34','2002',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-2','Biotecnologie')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '175')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2003',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-3',title = 'Discipline delle arti figurative, della musica, dello spettacolo e della moda' WHERE idclassescuola = '175'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('175','4','MT','34','2003',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-3','Discipline delle arti figurative, della musica, dello spettacolo e della moda')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '176')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2004',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-4',title = 'Disegno industriale' WHERE idclassescuola = '176'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('176','2','MT','34','2004',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-4','Disegno industriale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '177')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2005',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-5',title = 'Filosofia' WHERE idclassescuola = '177'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('177','4','MT','34','2005',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-5','Filosofia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '178')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2006',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-6',title = 'Geografia' WHERE idclassescuola = '178'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('178','4','MT','34','2006',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-6','Geografia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '179')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2007',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-7',title = 'Ingegneria civile e ambientale' WHERE idclassescuola = '179'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('179','2','MT','34','2007',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-7','Ingegneria civile e ambientale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '180')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2008',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-8',title = 'Ingegneria dell''informazione' WHERE idclassescuola = '180'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('180','2','MT','34','2008',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-8','Ingegneria dell''informazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '181')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2009',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-9',title = 'Ingegneria industriale' WHERE idclassescuola = '181'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('181','2','MT','34','2009',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-9','Ingegneria industriale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '182')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2010',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-10',title = 'Lettere' WHERE idclassescuola = '182'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('182','4','MT','34','2010',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-10','Lettere')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '183')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2011',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-11',title = 'Lingue e culture moderne' WHERE idclassescuola = '183'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('183','4','MT','34','2011',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-11','Lingue e culture moderne')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '184')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2012',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-12',title = 'Mediazione linguistica' WHERE idclassescuola = '184'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('184','4','MT','34','2012',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-12','Mediazione linguistica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '185')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2013',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-13',title = 'Scienze biologiche' WHERE idclassescuola = '185'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('185','2','MT','34','2013',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-13','Scienze biologiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '186')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2014',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-14',title = 'Scienze dei servizi giuridici' WHERE idclassescuola = '186'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('186','3','MT','34','2014',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-14','Scienze dei servizi giuridici')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '187')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2015',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-15',title = 'Scienze del turismo' WHERE idclassescuola = '187'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('187','3','MT','34','2015',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-15','Scienze del turismo')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '188')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2016',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-16',title = 'Scienze dell''amministrazione e dell''organizzazione' WHERE idclassescuola = '188'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('188','3','MT','34','2016',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-16','Scienze dell''amministrazione e dell''organizzazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '189')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2017',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-17',title = 'Scienze dell''architettura' WHERE idclassescuola = '189'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('189','2','MT','34','2017',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-17','Scienze dell''architettura')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '190')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2018',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-18',title = 'Scienze dell''economia e della gestione aziendale' WHERE idclassescuola = '190'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('190','3','MT','34','2018',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-18','Scienze dell''economia e della gestione aziendale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '191')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2019',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-19',title = 'Scienze dell''educazione e della formazione' WHERE idclassescuola = '191'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('191','4','MT','34','2019',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-19','Scienze dell''educazione e della formazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '192')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2020',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-20',title = 'Scienze della comunicazione' WHERE idclassescuola = '192'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('192','3','MT','34','2020',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-20','Scienze della comunicazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '193')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2021',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-21',title = 'Scienze della pianificazione territoriale, urbanistica, paesaggistica e ambientale' WHERE idclassescuola = '193'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('193','2','MT','34','2021',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-21','Scienze della pianificazione territoriale, urbanistica, paesaggistica e ambientale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '194')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2022',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-22',title = 'Scienze delle attivit? motorie e sportive' WHERE idclassescuola = '194'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('194','2','MT','34','2022',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-22','Scienze delle attivit? motorie e sportive')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '195')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2023',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-23',title = 'Scienze e tecniche dell''edilizia' WHERE idclassescuola = '195'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('195','2','MT','34','2023',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-23','Scienze e tecniche dell''edilizia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '196')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2024',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-24',title = 'Scienze e tecniche psicologiche' WHERE idclassescuola = '196'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('196','3','MT','34','2024',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-24','Scienze e tecniche psicologiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '197')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2025',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-25',title = 'Scienze e tecnologie agrarie e forestali' WHERE idclassescuola = '197'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('197','2','MT','34','2025',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-25','Scienze e tecnologie agrarie e forestali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '198')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2026',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-26',title = 'Scienze e tecnologie alimentari' WHERE idclassescuola = '198'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('198','2','MT','34','2026',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-26','Scienze e tecnologie alimentari')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '199')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2027',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-27',title = 'Scienze e tecnologie chimiche' WHERE idclassescuola = '199'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('199','2','MT','34','2027',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-27','Scienze e tecnologie chimiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '200')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2028',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-28',title = 'Scienze e tecnologie della navigazione' WHERE idclassescuola = '200'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('200','2','MT','34','2028',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-28','Scienze e tecnologie della navigazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '201')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2029',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-29',title = 'Scienze e tecnologie farmaceutiche' WHERE idclassescuola = '201'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('201','1','MT','34','2029',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-29','Scienze e tecnologie farmaceutiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '202')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2030',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-30',title = 'Scienze e tecnologie fisiche' WHERE idclassescuola = '202'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('202','2','MT','34','2030',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-30','Scienze e tecnologie fisiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '203')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2031',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-31',title = 'Scienze e tecnologie informatiche' WHERE idclassescuola = '203'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('203','2','MT','34','2031',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-31','Scienze e tecnologie informatiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '204')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2032',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-32',title = 'Scienze e tecnologie per l''ambiente e la natura' WHERE idclassescuola = '204'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('204','2','MT','34','2032',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-32','Scienze e tecnologie per l''ambiente e la natura')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '205')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2033',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-33',title = 'Scienze economiche' WHERE idclassescuola = '205'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('205','3','MT','34','2033',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-33','Scienze economiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '206')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2034',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-34',title = 'Scienze geologiche' WHERE idclassescuola = '206'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('206','2','MT','34','2034',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-34','Scienze geologiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '207')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2035',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-35',title = 'Scienze matematiche' WHERE idclassescuola = '207'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('207','2','MT','34','2035',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-35','Scienze matematiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '208')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2036',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-36',title = 'Scienze politiche e delle relazioni internazionali' WHERE idclassescuola = '208'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('208','3','MT','34','2036',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-36','Scienze politiche e delle relazioni internazionali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '209')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2037',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-37',title = 'Scienze sociali per la cooperazione, lo sviluppo e la pace' WHERE idclassescuola = '209'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('209','3','MT','34','2037',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-37','Scienze sociali per la cooperazione, lo sviluppo e la pace')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '210')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2038',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-38',title = 'Scienze zootecniche e tecnologie delle produzioni animali' WHERE idclassescuola = '210'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('210','2','MT','34','2038',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-38','Scienze zootecniche e tecnologie delle produzioni animali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '211')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2039',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-39',title = 'Servizio sociale' WHERE idclassescuola = '211'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('211','3','MT','34','2039',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-39','Servizio sociale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '212')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2040',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-40',title = 'Sociologia' WHERE idclassescuola = '212'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('212','3','MT','34','2040',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-40','Sociologia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '213')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2041',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-41',title = 'Statistica' WHERE idclassescuola = '213'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('213','2','MT','34','2041',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-41','Statistica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '214')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2042',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-42',title = 'Storia' WHERE idclassescuola = '214'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('214','4','MT','34','2042',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-42','Storia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '215')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2044',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L-43',title = 'Diagnostica per la conservazione dei beni culturali' WHERE idclassescuola = '215'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('215','2','MT','34','2044',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L-43','Diagnostica per la conservazione dei beni culturali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '216')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2046',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L/SNT1',title = 'Professioni sanitarie, infermieristiche e professione sanitaria ostetrica' WHERE idclassescuola = '216'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('216','1','MT','34','2046',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L/SNT1','Professioni sanitarie, infermieristiche e professione sanitaria ostetrica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '217')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2047',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L/SNT2',title = 'Professioni sanitarie della riabilitazione' WHERE idclassescuola = '217'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('217','1','MT','34','2047',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L/SNT2','Professioni sanitarie della riabilitazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '218')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2048',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L/SNT3',title = 'Professioni sanitarie tecniche' WHERE idclassescuola = '218'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('218','1','MT','34','2048',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L/SNT3','Professioni sanitarie tecniche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '219')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2049',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L/SNT4',title = 'Professioni sanitarie della prevenzione' WHERE idclassescuola = '219'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('219','1','MT','34','2049',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L/SNT4','Professioni sanitarie della prevenzione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '220')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2051',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L/SC',title = 'Scienze criminologiche e della sicurezza' WHERE idclassescuola = '220'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('220','3','MT','34','2051',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L/SC','Scienze criminologiche e della sicurezza')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '221')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2052',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L/DS',title = 'Scienze della difesa e della sicurezza' WHERE idclassescuola = '221'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('221','3','MT','34','2052',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L/DS','Scienze della difesa e della sicurezza')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '222')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MT',idcorsostudionorma = '34',indicecineca = '2053',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L/GASTR',title = 'Scienze, culture e politiche della gastronomia' WHERE idclassescuola = '222'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('222','3','MT','34','2053',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L/GASTR','Scienze, culture e politiche della gastronomia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '223')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LM',idcorsostudionorma = '34',indicecineca = '3001',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LMG/01',title = 'Magistrali in giurisprudenza' WHERE idclassescuola = '223'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('223','3','LM','34','3001',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LMG/01','Magistrali in giurisprudenza')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '224')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3002',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-1',title = 'Antropologia culturale ed etnologia' WHERE idclassescuola = '224'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('224','4','MS','34','3002',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-1','Antropologia culturale ed etnologia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '225')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3003',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-2',title = 'Archeologia' WHERE idclassescuola = '225'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('225','4','MS','34','3003',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-2','Archeologia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '226')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3004',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-3',title = 'Architettura del paesaggio' WHERE idclassescuola = '226'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('226','2','MS','34','3004',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-3','Architettura del paesaggio')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '227')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3005',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-4',title = 'Architettura e ingegneria edile-architettura' WHERE idclassescuola = '227'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('227','2','MS','34','3005',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-4','Architettura e ingegneria edile-architettura')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '228')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3006',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-5',title = 'Archivistica e biblioteconomia' WHERE idclassescuola = '228'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('228','4','MS','34','3006',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-5','Archivistica e biblioteconomia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '229')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3007',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-6',title = 'Biologia' WHERE idclassescuola = '229'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('229','2','MS','34','3007',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-6','Biologia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '230')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3008',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-7',title = 'Biotecnologie agrarie' WHERE idclassescuola = '230'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('230','2','MS','34','3008',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-7','Biotecnologie agrarie')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '231')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3009',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-8',title = 'Biotecnologie industriali' WHERE idclassescuola = '231'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('231','2','MS','34','3009',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-8','Biotecnologie industriali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '232')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3010',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-9',title = 'Biotecnologie mediche, veterinarie e farmaceutiche' WHERE idclassescuola = '232'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('232','2','MS','34','3010',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-9','Biotecnologie mediche, veterinarie e farmaceutiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '233')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3011',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-10',title = 'Conservazione dei beni architettonici e ambientali' WHERE idclassescuola = '233'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('233','4','MS','34','3011',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-10','Conservazione dei beni architettonici e ambientali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '234')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3012',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-11',title = 'Scienze per la conservazione dei beni culturali' WHERE idclassescuola = '234'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('234','4','MS','34','3012',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-11','Scienze per la conservazione dei beni culturali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '235')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3013',lt = {ts '2020-05-19 10:43:13.967'},lu = 'riccardotest{0001}',obbform = 'La classe ha come obiettivo la formazione di designer capaci di promuovere dinamiche
d''innovazione di prodotti e sistemi di prodotti in grado di supportare la finalizzazione
strategica del progetto in tutti gli ambiti di applicazione del design. La figure formate devono
in particolare:
- possedere conoscenze approfondite sui prodotti industriali (siano essi di natura materiale o
immateriale), negli aspetti tecnico-produttivi, tecnico-funzionali e formali; sui prodotti
intermedi (materiali, semilavorati, componenti) e sui processi che accompagnano il ciclo di
sviluppo e di vita del prodotto (progettuali, di ingegnerizzazione, produttivi, distributivi,
d''uso);
- possedere conoscenze sul contesto fisico di produzione e d''uso dei prodotti relative agli
aspetti qualitativi che contribuiscono a migliorare la percezione e fruizione di un ambiente, ai
requisiti ambientali dei prodotti, a processi comunicativi e di consumo finalizzati a strategie di
""sostenibilità"";
- possedere conoscenze approfondite sulle dinamiche di costruzione dell''identità di marca in
relazione alla progettazione dei sistemi di servizio associati al prodotto, dei luoghi e delle
modalità di vendita e comunicazione;
- possedere conoscenze specifiche sui contesti socio-culturali di riferimento, sulle dinamiche
d''uso e consumo dei prodotti e sulle dinamiche di mercato in relazione alle ricadute che tali
fenomeni hanno sulle strategie produttive, comunicative, distributive dell''impresa;
- possedere un''ampia preparazione nelle discipline storico-critiche e nelle scienze umane in
grado di fornire strumenti interpretativi relativamente ai diversi contesti di applicazione della
pratica del progetto;
- avere conoscenze nel campo dell''organizzazione aziendale (cultura d''impresa) e dell''etica
professionale;
- possedere capacità relazionali e di gestione del lavoro di gruppo all''interno di progetti
complessi;
- essere in grado di utilizzare fluentemente, in forma scritta e orale, almeno una lingua
dell''Unione Europea oltre l''italiano, con riferimento anche ai lessici disciplinari.
I principali sbocchi occupazionali e i settori di riferimento previsti dai corsi di laurea
magistrale della classe sono la libera professione, le istituzioni e gli enti pubblici e privati, gli
studi e le società di progettazione, le imprese e le aziende che operano nell''area del design in
tutti i settori di applicazione della disciplina e nei settori emergenti che esprimono domanda di
profili con competenze progettuali avanzate.
Ai fini indicati, i curricula dei corsi di laurea magistrale possono essere declinati all''interno
delle aree che esplorano le più consolidate prassi e fenomenologie professionali che vanno dal
designer di prodotto che opera all''interno di molteplici ambiti merceologici – apparecchi
d''illuminazione, nautica, trasporti, elettronica di consumo, macchine utensili – includendo tutti
i settori relativi ai beni di consumo, durevoli e strumentali che rappresentano ambiti di
vocazione dell''economia nazionale; al designer che opera all''interno di tutti i settori più
avanzati della comunicazione – dall''editoria multimediale al web design, dal progetto dei
sistemi segnaletici all''immagine coordinata e all''identità di marca, sino alla progettazione
dell''immagine cinetica (video e cinematografica) – includendo tutti i settori emergenti della
comunicazione legati ai new media e alle nuove tecnologie; dal designer che opera nell''ambito
della progettazione di ambienti complessi con particolare riferimento alle dinamiche
contemporanee di evoluzione di contesti urbani e territoriali e di riconversione di spazi e
attrezzature, nonché di allestimento e valorizzazione del patrimonio territoriale e ambientale
attraverso l''exhibit design e l''allestimento per i beni culturali; al designer che opera all''interno
di tutti i settori legati all''ambito moda – dall''abbigliamento, agli accessori, al progetto tessile,
sino alla progettazione del sistema di artefatti che concorre aveicolare l''identità d''impresa in
contesti nei quali la vocazione produttiva tende ad includere l''ambito dei prodotti per la casa,
dei servizi e della comunicazione – nonché figure professionali di designer che sviluppano
competenze specifiche quali quelle della progettazione ecocompatibile.
Gli ambiti sopra declinati configurano sia percorsi di laurea magistrale in settori strategici con
l''obiettivo di formare profili a supporto della competitività a livello globale delle imprese, dei
sistemi territoriali, dei giacimenti culturali sia percorsi di laurea magistrale con forti aperture
multidisciplinari in grado di formare profili nuovi e sperimentali rispetto a settori emergenti
come il ""design strategico"" e ""il design dei servizi"" o a settori nei quali sono presenti processi
di ibridazione delle competenze progettuali con quelle manageriali o di gestione dei processi di
sviluppo e messa in produzione dei prodotti industriali, come il ""design management"" e il
""design engineering"".
Nel curriculum magistrale riveste comunque specifica importanza l''approfondimento della
natura strategica delle scelte progettuali, mirate allo sviluppo di prodotti, sistemi di
comunicazione, spaziali e relazionali anche attraverso processi di progettazione integrata; è
posta attenzione inoltre alla sperimentazione di metodologie progettuali avanzate e orientate
alla sostenibilità sociale e ambientale.
In relazione a obiettivi specifici, i curriculum prevedono attività esterne come tirocini
formativi presso enti o istituti di ricerca, laboratori, aziende e amministrazioni pubbliche, e
soggiorni di studio presso altre università italiane ed europee, anche nel quadro di accordi
Internazionali.',prospocc = null,sigla = 'LM-12',title = 'Design' WHERE idclassescuola = '235'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('235','2','MS','34','3013',{ts '2020-05-19 10:43:13.967'},'riccardotest{0001}','La classe ha come obiettivo la formazione di designer capaci di promuovere dinamiche
d''innovazione di prodotti e sistemi di prodotti in grado di supportare la finalizzazione
strategica del progetto in tutti gli ambiti di applicazione del design. La figure formate devono
in particolare:
- possedere conoscenze approfondite sui prodotti industriali (siano essi di natura materiale o
immateriale), negli aspetti tecnico-produttivi, tecnico-funzionali e formali; sui prodotti
intermedi (materiali, semilavorati, componenti) e sui processi che accompagnano il ciclo di
sviluppo e di vita del prodotto (progettuali, di ingegnerizzazione, produttivi, distributivi,
d''uso);
- possedere conoscenze sul contesto fisico di produzione e d''uso dei prodotti relative agli
aspetti qualitativi che contribuiscono a migliorare la percezione e fruizione di un ambiente, ai
requisiti ambientali dei prodotti, a processi comunicativi e di consumo finalizzati a strategie di
""sostenibilità"";
- possedere conoscenze approfondite sulle dinamiche di costruzione dell''identità di marca in
relazione alla progettazione dei sistemi di servizio associati al prodotto, dei luoghi e delle
modalità di vendita e comunicazione;
- possedere conoscenze specifiche sui contesti socio-culturali di riferimento, sulle dinamiche
d''uso e consumo dei prodotti e sulle dinamiche di mercato in relazione alle ricadute che tali
fenomeni hanno sulle strategie produttive, comunicative, distributive dell''impresa;
- possedere un''ampia preparazione nelle discipline storico-critiche e nelle scienze umane in
grado di fornire strumenti interpretativi relativamente ai diversi contesti di applicazione della
pratica del progetto;
- avere conoscenze nel campo dell''organizzazione aziendale (cultura d''impresa) e dell''etica
professionale;
- possedere capacità relazionali e di gestione del lavoro di gruppo all''interno di progetti
complessi;
- essere in grado di utilizzare fluentemente, in forma scritta e orale, almeno una lingua
dell''Unione Europea oltre l''italiano, con riferimento anche ai lessici disciplinari.
I principali sbocchi occupazionali e i settori di riferimento previsti dai corsi di laurea
magistrale della classe sono la libera professione, le istituzioni e gli enti pubblici e privati, gli
studi e le società di progettazione, le imprese e le aziende che operano nell''area del design in
tutti i settori di applicazione della disciplina e nei settori emergenti che esprimono domanda di
profili con competenze progettuali avanzate.
Ai fini indicati, i curricula dei corsi di laurea magistrale possono essere declinati all''interno
delle aree che esplorano le più consolidate prassi e fenomenologie professionali che vanno dal
designer di prodotto che opera all''interno di molteplici ambiti merceologici – apparecchi
d''illuminazione, nautica, trasporti, elettronica di consumo, macchine utensili – includendo tutti
i settori relativi ai beni di consumo, durevoli e strumentali che rappresentano ambiti di
vocazione dell''economia nazionale; al designer che opera all''interno di tutti i settori più
avanzati della comunicazione – dall''editoria multimediale al web design, dal progetto dei
sistemi segnaletici all''immagine coordinata e all''identità di marca, sino alla progettazione
dell''immagine cinetica (video e cinematografica) – includendo tutti i settori emergenti della
comunicazione legati ai new media e alle nuove tecnologie; dal designer che opera nell''ambito
della progettazione di ambienti complessi con particolare riferimento alle dinamiche
contemporanee di evoluzione di contesti urbani e territoriali e di riconversione di spazi e
attrezzature, nonché di allestimento e valorizzazione del patrimonio territoriale e ambientale
attraverso l''exhibit design e l''allestimento per i beni culturali; al designer che opera all''interno
di tutti i settori legati all''ambito moda – dall''abbigliamento, agli accessori, al progetto tessile,
sino alla progettazione del sistema di artefatti che concorre aveicolare l''identità d''impresa in
contesti nei quali la vocazione produttiva tende ad includere l''ambito dei prodotti per la casa,
dei servizi e della comunicazione – nonché figure professionali di designer che sviluppano
competenze specifiche quali quelle della progettazione ecocompatibile.
Gli ambiti sopra declinati configurano sia percorsi di laurea magistrale in settori strategici con
l''obiettivo di formare profili a supporto della competitività a livello globale delle imprese, dei
sistemi territoriali, dei giacimenti culturali sia percorsi di laurea magistrale con forti aperture
multidisciplinari in grado di formare profili nuovi e sperimentali rispetto a settori emergenti
come il ""design strategico"" e ""il design dei servizi"" o a settori nei quali sono presenti processi
di ibridazione delle competenze progettuali con quelle manageriali o di gestione dei processi di
sviluppo e messa in produzione dei prodotti industriali, come il ""design management"" e il
""design engineering"".
Nel curriculum magistrale riveste comunque specifica importanza l''approfondimento della
natura strategica delle scelte progettuali, mirate allo sviluppo di prodotti, sistemi di
comunicazione, spaziali e relazionali anche attraverso processi di progettazione integrata; è
posta attenzione inoltre alla sperimentazione di metodologie progettuali avanzate e orientate
alla sostenibilità sociale e ambientale.
In relazione a obiettivi specifici, i curriculum prevedono attività esterne come tirocini
formativi presso enti o istituti di ricerca, laboratori, aziende e amministrazioni pubbliche, e
soggiorni di studio presso altre università italiane ed europee, anche nel quadro di accordi
Internazionali.',null,'LM-12','Design')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '236')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'LM',idcorsostudionorma = '34',indicecineca = '3014',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-13',title = 'Farmacia e farmacia industriale' WHERE idclassescuola = '236'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('236','1','LM','34','3014',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-13','Farmacia e farmacia industriale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '237')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3015',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-14',title = 'Filologia moderna' WHERE idclassescuola = '237'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('237','4','MS','34','3015',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-14','Filologia moderna')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '238')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3016',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-15',title = 'Filologia, letterature e storia dell''antichit?' WHERE idclassescuola = '238'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('238','4','MS','34','3016',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-15','Filologia, letterature e storia dell''antichit?')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '239')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3017',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-16',title = 'Finanza' WHERE idclassescuola = '239'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('239','3','MS','34','3017',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-16','Finanza')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '240')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3018',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-17',title = 'Fisica' WHERE idclassescuola = '240'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('240','2','MS','34','3018',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-17','Fisica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '241')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3019',lt = {ts '2020-05-18 13:03:03.847'},lu = 'riccardotest{0001}',obbform = 'Le lauree di questa classe forniscono vaste ed approfondite competenze teoriche,
metodologiche, sperimentali ed applicative nelle aree fondamentali dell''informatica che
costituiscono la base concettuale e tecnologica per l''approccio informatico allo studio dei
problemi e per la progettazione, produzione ed utilizzazione della varietà di applicazioni
richieste nella Società dell''Informazione per organizzare, gestire ed accedere ad informazioni e
conoscenze. Il laureato magistrale in questa classe sarà quindi in grado di effettuare la
pianificazione, la progettazione, lo sviluppo, la direzione lavori, la stima, il collaudo e la
gestione di impianti e sistemi complessi o innovativi per la generazione, la trasmissione e
l''elaborazione delle informazioni, anche quando implichino l''uso di metodologie avanzate,
innovative o sperimentali. Questo obiettivo viene perseguito allargando ed approfondendo le
conoscenze teoriche, metodologiche, sistemistiche e tecnologiche, in tutte le discipline che
costituiscono elementi culturali fondamentali dell''informatica. Cio'' rende possibile al laureato
magistrale sia di individuare nuovi sviluppi teorici delle discipline informatiche e dei relativi
campi di applicazione, sia di operare a livello progettuale e decisionale in tutte le aree
dell''informatica.
I laureati nei corsi di laurea magistrale della classe devono in particolare:
- possedere solide conoscenze sia dei fondamenti che degli aspetti applicativi dei vari settori
dell''informatica;
- conoscere approfonditamente il metodo scientifico di indagine e comprendere e utilizzare gli
strumenti di matematica discreta e del continuo, di matematica applicata e di fisica, che sono
di supporto all''informatica ed alle sue applicazioni;
- conoscere in modo approfondito i principi, le strutture e l''utilizzo dei sistemi di elaborazione;
- conoscere fondamenti, tecniche e metodi di progettazione e realizzazione di sistemi
informatici, sia di base sia applicativi;
- avere conoscenza di diversi settori di applicazione;
- possedere elementi di cultura aziendale e professionale;
- essere in grado di utilizzare fluentemente, in forma scritta e orale, almeno una lingua
dell''Unione Europea oltre l''italiano, con riferimento anche ai lessici disciplinari;
- essere in grado di lavorare con ampia autonomia, anche assumendo responsabilità di progetti
e strutture.
Gli ambiti occupazionali e professionali di riferimento per i laureati magistrali della classe
sono quelli della progettazione, organizzazione, gestione e manutenzione di sistemi informatici
complessi o innovativi (con specifico riguardo ai requisiti di affidabilità, prestazioni e
sicurezza), sia in imprese produttrici nelle aree dei sistemi informatici e delle reti, sia nelle
imprese, nelle pubbliche amministrazioni e, più in generale, in tutte le organizzazioni che
utilizzano sistemi informatici complessi. Si esemplificano come particolarmente rilevanti per
lo sbocco occupazionale e professionale:
- i sistemi informatici per i settori dell''industria, dei servizi, dell''ambiente e territorio, della
sanità, della scienza, della cultura, dei beni culturali e della pubblica amministrazione;
- le applicazioni innovative nell''ambito dell''elaborazione di immagini e suoni, del
riconoscimento e della visione artificiale, delle reti neurali, dell''intelligenza artificiale e del
soft computing, della simulazione computazionale, della sicurezza e riservatezza dei dati e del
loro accesso, della grafica computazionale, dell''interazione utente-elaboratore e dei sistemi
multimediali.
Ai fini indicati, i curricula dei corsi di laurea magistrale della classe:
- prevedono lezioni ed esercitazioni di laboratorio oltre a congrue attività progettuali autonome
e congrue attività individuali in laboratorio;
- prevedono, in relazione a obiettivi specifici, attività esterne come tirocini formativi presso
aziende, strutture della pubblica amministrazione e laboratori, oltre a soggiorni di studio presso
altre università italiane ed europee, anche nel quadro di accordi internazionali. ',prospocc = null,sigla = 'LM-18',title = 'Informatica' WHERE idclassescuola = '241'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('241','2','MS','34','3019',{ts '2020-05-18 13:03:03.847'},'riccardotest{0001}','Le lauree di questa classe forniscono vaste ed approfondite competenze teoriche,
metodologiche, sperimentali ed applicative nelle aree fondamentali dell''informatica che
costituiscono la base concettuale e tecnologica per l''approccio informatico allo studio dei
problemi e per la progettazione, produzione ed utilizzazione della varietà di applicazioni
richieste nella Società dell''Informazione per organizzare, gestire ed accedere ad informazioni e
conoscenze. Il laureato magistrale in questa classe sarà quindi in grado di effettuare la
pianificazione, la progettazione, lo sviluppo, la direzione lavori, la stima, il collaudo e la
gestione di impianti e sistemi complessi o innovativi per la generazione, la trasmissione e
l''elaborazione delle informazioni, anche quando implichino l''uso di metodologie avanzate,
innovative o sperimentali. Questo obiettivo viene perseguito allargando ed approfondendo le
conoscenze teoriche, metodologiche, sistemistiche e tecnologiche, in tutte le discipline che
costituiscono elementi culturali fondamentali dell''informatica. Cio'' rende possibile al laureato
magistrale sia di individuare nuovi sviluppi teorici delle discipline informatiche e dei relativi
campi di applicazione, sia di operare a livello progettuale e decisionale in tutte le aree
dell''informatica.
I laureati nei corsi di laurea magistrale della classe devono in particolare:
- possedere solide conoscenze sia dei fondamenti che degli aspetti applicativi dei vari settori
dell''informatica;
- conoscere approfonditamente il metodo scientifico di indagine e comprendere e utilizzare gli
strumenti di matematica discreta e del continuo, di matematica applicata e di fisica, che sono
di supporto all''informatica ed alle sue applicazioni;
- conoscere in modo approfondito i principi, le strutture e l''utilizzo dei sistemi di elaborazione;
- conoscere fondamenti, tecniche e metodi di progettazione e realizzazione di sistemi
informatici, sia di base sia applicativi;
- avere conoscenza di diversi settori di applicazione;
- possedere elementi di cultura aziendale e professionale;
- essere in grado di utilizzare fluentemente, in forma scritta e orale, almeno una lingua
dell''Unione Europea oltre l''italiano, con riferimento anche ai lessici disciplinari;
- essere in grado di lavorare con ampia autonomia, anche assumendo responsabilità di progetti
e strutture.
Gli ambiti occupazionali e professionali di riferimento per i laureati magistrali della classe
sono quelli della progettazione, organizzazione, gestione e manutenzione di sistemi informatici
complessi o innovativi (con specifico riguardo ai requisiti di affidabilità, prestazioni e
sicurezza), sia in imprese produttrici nelle aree dei sistemi informatici e delle reti, sia nelle
imprese, nelle pubbliche amministrazioni e, più in generale, in tutte le organizzazioni che
utilizzano sistemi informatici complessi. Si esemplificano come particolarmente rilevanti per
lo sbocco occupazionale e professionale:
- i sistemi informatici per i settori dell''industria, dei servizi, dell''ambiente e territorio, della
sanità, della scienza, della cultura, dei beni culturali e della pubblica amministrazione;
- le applicazioni innovative nell''ambito dell''elaborazione di immagini e suoni, del
riconoscimento e della visione artificiale, delle reti neurali, dell''intelligenza artificiale e del
soft computing, della simulazione computazionale, della sicurezza e riservatezza dei dati e del
loro accesso, della grafica computazionale, dell''interazione utente-elaboratore e dei sistemi
multimediali.
Ai fini indicati, i curricula dei corsi di laurea magistrale della classe:
- prevedono lezioni ed esercitazioni di laboratorio oltre a congrue attività progettuali autonome
e congrue attività individuali in laboratorio;
- prevedono, in relazione a obiettivi specifici, attività esterne come tirocini formativi presso
aziende, strutture della pubblica amministrazione e laboratori, oltre a soggiorni di studio presso
altre università italiane ed europee, anche nel quadro di accordi internazionali. ',null,'LM-18','Informatica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '242')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3020',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-19',title = 'Informazione e sistemi editoriali' WHERE idclassescuola = '242'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('242','4','MS','34','3020',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-19','Informazione e sistemi editoriali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '243')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3021',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-20',title = 'Ingegneria aerospaziale e astronautica' WHERE idclassescuola = '243'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('243','2','MS','34','3021',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-20','Ingegneria aerospaziale e astronautica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '244')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3022',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-21',title = 'Ingegneria biomedica' WHERE idclassescuola = '244'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('244','2','MS','34','3022',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-21','Ingegneria biomedica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '245')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3023',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-22',title = 'Ingegneria chimica' WHERE idclassescuola = '245'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('245','2','MS','34','3023',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-22','Ingegneria chimica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '246')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3024',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-23',title = 'Ingegneria civile' WHERE idclassescuola = '246'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('246','2','MS','34','3024',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-23','Ingegneria civile')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '247')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3025',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-24',title = 'Ingegneria dei sistemi edilizi' WHERE idclassescuola = '247'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('247','2','MS','34','3025',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-24','Ingegneria dei sistemi edilizi')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '248')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3026',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-25',title = 'Ingegneria dell''automazione' WHERE idclassescuola = '248'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('248','2','MS','34','3026',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-25','Ingegneria dell''automazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '249')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3027',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-26',title = 'Ingegneria della sicurezza' WHERE idclassescuola = '249'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('249','2','MS','34','3027',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-26','Ingegneria della sicurezza')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '250')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3028',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-27',title = 'Ingegneria delle telecomunicazioni' WHERE idclassescuola = '250'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('250','2','MS','34','3028',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-27','Ingegneria delle telecomunicazioni')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '251')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3029',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-28',title = 'Ingegneria elettrica' WHERE idclassescuola = '251'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('251','2','MS','34','3029',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-28','Ingegneria elettrica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '252')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3030',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-29',title = 'Ingegneria elettronica' WHERE idclassescuola = '252'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('252','2','MS','34','3030',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-29','Ingegneria elettronica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '253')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3031',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-30',title = 'Ingegneria energetica e nucleare' WHERE idclassescuola = '253'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('253','2','MS','34','3031',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-30','Ingegneria energetica e nucleare')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '254')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3032',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-31',title = 'Ingegneria gestionale' WHERE idclassescuola = '254'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('254','2','MS','34','3032',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-31','Ingegneria gestionale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '255')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3033',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-32',title = 'Ingegneria informatica' WHERE idclassescuola = '255'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('255','2','MS','34','3033',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-32','Ingegneria informatica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '256')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3034',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-33',title = 'Ingegneria meccanica' WHERE idclassescuola = '256'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('256','2','MS','34','3034',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-33','Ingegneria meccanica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '257')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3035',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-34',title = 'Ingegneria navale' WHERE idclassescuola = '257'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('257','2','MS','34','3035',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-34','Ingegneria navale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '258')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3036',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-35',title = 'Ingegneria per l''ambiente e il territorio' WHERE idclassescuola = '258'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('258','2','MS','34','3036',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-35','Ingegneria per l''ambiente e il territorio')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '259')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3037',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-36',title = 'Lingue e letterature dell''Africa e dell''Asia' WHERE idclassescuola = '259'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('259','4','MS','34','3037',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-36','Lingue e letterature dell''Africa e dell''Asia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '260')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3038',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-37',title = 'Lingue e letterature moderne europee e americane' WHERE idclassescuola = '260'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('260','4','MS','34','3038',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-37','Lingue e letterature moderne europee e americane')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '261')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3039',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-38',title = 'Lingue moderne per la comunicazione e la cooperazione internazionale' WHERE idclassescuola = '261'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('261','4','MS','34','3039',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-38','Lingue moderne per la comunicazione e la cooperazione internazionale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '262')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3040',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-39',title = 'Linguistica' WHERE idclassescuola = '262'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('262','4','MS','34','3040',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-39','Linguistica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '263')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3041',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-40',title = 'Matematica' WHERE idclassescuola = '263'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('263','2','MS','34','3041',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-40','Matematica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '264')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'LM',idcorsostudionorma = '34',indicecineca = '3042',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-41',title = 'Medicina e chirurgia' WHERE idclassescuola = '264'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('264','1','LM','34','3042',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-41','Medicina e chirurgia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '265')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'LM',idcorsostudionorma = '34',indicecineca = '3043',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-42',title = 'Medicina veterinaria' WHERE idclassescuola = '265'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('265','1','LM','34','3043',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-42','Medicina veterinaria')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '266')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3044',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-43',title = 'Metodologie informatiche per le discipline umanistiche' WHERE idclassescuola = '266'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('266','2','MS','34','3044',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-43','Metodologie informatiche per le discipline umanistiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '267')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3045',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-44',title = 'Modellistica matematico-fisica per l''ingegneria' WHERE idclassescuola = '267'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('267','2','MS','34','3045',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-44','Modellistica matematico-fisica per l''ingegneria')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '268')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3046',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-45',title = 'Musicologia e beni musicali' WHERE idclassescuola = '268'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('268','4','MS','34','3046',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-45','Musicologia e beni musicali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '269')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'LM',idcorsostudionorma = '34',indicecineca = '3047',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-46',title = 'Odontoiatria e protesi dentaria' WHERE idclassescuola = '269'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('269','1','LM','34','3047',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-46','Odontoiatria e protesi dentaria')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '270')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3048',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-47',title = 'Organizzazione e gestione dei servizi per lo sport e le attivit? motorie' WHERE idclassescuola = '270'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('270','2','MS','34','3048',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-47','Organizzazione e gestione dei servizi per lo sport e le attivit? motorie')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '271')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3049',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-48',title = 'Pianificazione territoriale urbanistica e ambientale' WHERE idclassescuola = '271'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('271','2','MS','34','3049',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-48','Pianificazione territoriale urbanistica e ambientale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '272')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3050',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-49',title = 'Progettazione e gestione dei sistemi turistici' WHERE idclassescuola = '272'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('272','3','MS','34','3050',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-49','Progettazione e gestione dei sistemi turistici')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '273')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3051',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-50',title = 'Programmazione e gestione dei servizi educativi' WHERE idclassescuola = '273'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('273','3','MS','34','3051',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-50','Programmazione e gestione dei servizi educativi')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '274')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3052',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-51',title = 'Psicologia' WHERE idclassescuola = '274'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('274','3','MS','34','3052',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-51','Psicologia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '275')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3053',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-52',title = 'Relazioni internazionali' WHERE idclassescuola = '275'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('275','3','MS','34','3053',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-52','Relazioni internazionali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '276')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3054',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-53',title = 'Scienza e ingegneria dei materiali' WHERE idclassescuola = '276'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('276','2','MS','34','3054',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-53','Scienza e ingegneria dei materiali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '277')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3055',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-54',title = 'Scienze chimiche' WHERE idclassescuola = '277'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('277','2','MS','34','3055',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-54','Scienze chimiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '278')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3056',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-55',title = 'Scienze cognitive' WHERE idclassescuola = '278'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('278','4','MS','34','3056',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-55','Scienze cognitive')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '279')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3057',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-56',title = 'Scienze dell''economia' WHERE idclassescuola = '279'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('279','3','MS','34','3057',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-56','Scienze dell''economia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '280')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3058',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-57',title = 'Scienze dell''educazione degli adulti e della formazione continua' WHERE idclassescuola = '280'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('280','3','MS','34','3058',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-57','Scienze dell''educazione degli adulti e della formazione continua')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '281')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3059',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-58',title = 'Scienze dell''universo' WHERE idclassescuola = '281'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('281','2','MS','34','3059',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-58','Scienze dell''universo')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '282')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3060',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-59',title = 'Scienze della comunicazione pubblica, d''impresa e pubblicit?' WHERE idclassescuola = '282'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('282','3','MS','34','3060',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-59','Scienze della comunicazione pubblica, d''impresa e pubblicit?')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '283')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3061',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-60',title = 'Scienze della natura' WHERE idclassescuola = '283'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('283','2','MS','34','3061',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-60','Scienze della natura')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '284')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3062',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-61',title = 'Scienze della nutrizione umana' WHERE idclassescuola = '284'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('284','2','MS','34','3062',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-61','Scienze della nutrizione umana')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '285')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3063',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-62',title = 'Scienze della politica' WHERE idclassescuola = '285'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('285','3','MS','34','3063',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-62','Scienze della politica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '286')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3064',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-63',title = 'Scienze delle pubbliche amministrazioni' WHERE idclassescuola = '286'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('286','3','MS','34','3064',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-63','Scienze delle pubbliche amministrazioni')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '287')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3065',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-64',title = 'Scienze delle religioni' WHERE idclassescuola = '287'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('287','4','MS','34','3065',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-64','Scienze delle religioni')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '288')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3066',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-65',title = 'Scienze dello spettacolo e produzione multimediale' WHERE idclassescuola = '288'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('288','3','MS','34','3066',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-65','Scienze dello spettacolo e produzione multimediale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '289')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3067',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-66',title = 'Sicurezza informatica' WHERE idclassescuola = '289'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('289','2','MS','34','3067',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-66','Sicurezza informatica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '290')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3068',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-67',title = 'Scienze e tecniche delle attivit? motorie preventive e adattate' WHERE idclassescuola = '290'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('290','2','MS','34','3068',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-67','Scienze e tecniche delle attivit? motorie preventive e adattate')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '291')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3069',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-68',title = 'Scienze e tecniche dello sport' WHERE idclassescuola = '291'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('291','2','MS','34','3069',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-68','Scienze e tecniche dello sport')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '292')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3070',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-69',title = 'Scienze e tecnologie agrarie' WHERE idclassescuola = '292'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('292','2','MS','34','3070',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-69','Scienze e tecnologie agrarie')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '293')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3071',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-70',title = 'Scienze e tecnologie alimentari' WHERE idclassescuola = '293'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('293','2','MS','34','3071',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-70','Scienze e tecnologie alimentari')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '294')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3072',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-71',title = 'Scienze e tecnologie della chimica industriale' WHERE idclassescuola = '294'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('294','2','MS','34','3072',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-71','Scienze e tecnologie della chimica industriale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '295')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3073',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-72',title = 'Scienze e tecnologie della navigazione' WHERE idclassescuola = '295'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('295','2','MS','34','3073',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-72','Scienze e tecnologie della navigazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '296')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3074',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-73',title = 'Scienze e tecnologie forestali ed ambientali' WHERE idclassescuola = '296'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('296','2','MS','34','3074',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-73','Scienze e tecnologie forestali ed ambientali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '297')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3075',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-74',title = 'Scienze e tecnologie geologiche' WHERE idclassescuola = '297'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('297','2','MS','34','3075',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-74','Scienze e tecnologie geologiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '298')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3076',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-75',title = 'Scienze e tecnologie per l''ambiente e il territorio' WHERE idclassescuola = '298'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('298','2','MS','34','3076',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-75','Scienze e tecnologie per l''ambiente e il territorio')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '299')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3077',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-76',title = 'Scienze economiche per l''ambiente e la cultura' WHERE idclassescuola = '299'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('299','3','MS','34','3077',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-76','Scienze economiche per l''ambiente e la cultura')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '300')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3078',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-77',title = 'Scienze economico-aziendali' WHERE idclassescuola = '300'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('300','3','MS','34','3078',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-77','Scienze economico-aziendali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '301')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3079',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-78',title = 'Scienze filosofiche' WHERE idclassescuola = '301'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('301','4','MS','34','3079',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-78','Scienze filosofiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '302')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3080',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-79',title = 'Scienze geofisiche' WHERE idclassescuola = '302'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('302','2','MS','34','3080',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-79','Scienze geofisiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '303')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3081',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-80',title = 'Scienze geografiche' WHERE idclassescuola = '303'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('303','4','MS','34','3081',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-80','Scienze geografiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '304')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3082',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-81',title = 'Scienze per la cooperazione allo sviluppo' WHERE idclassescuola = '304'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('304','3','MS','34','3082',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-81','Scienze per la cooperazione allo sviluppo')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '305')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3083',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-82',title = 'Scienze statistiche' WHERE idclassescuola = '305'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('305','3','MS','34','3083',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-82','Scienze statistiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '306')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3084',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-83',title = 'Scienze statistiche attuariali e finanziarie' WHERE idclassescuola = '306'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('306','3','MS','34','3084',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-83','Scienze statistiche attuariali e finanziarie')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '307')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3085',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-84',title = 'Scienze storiche' WHERE idclassescuola = '307'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('307','4','MS','34','3085',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-84','Scienze storiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '308')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3086',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-85',title = 'Scienze pedagogiche' WHERE idclassescuola = '308'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('308','3','MS','34','3086',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-85','Scienze pedagogiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '309')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3087',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-86',title = 'Scienze zootecniche e tecnologie  animali' WHERE idclassescuola = '309'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('309','2','MS','34','3087',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-86','Scienze zootecniche e tecnologie  animali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '310')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3088',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-87',title = 'Servizio sociale e politiche sociali' WHERE idclassescuola = '310'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('310','3','MS','34','3088',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-87','Servizio sociale e politiche sociali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '311')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3089',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-88',title = 'Sociologia e ricerca sociale' WHERE idclassescuola = '311'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('311','3','MS','34','3089',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-88','Sociologia e ricerca sociale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '312')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3090',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-89',title = 'Storia dell''arte' WHERE idclassescuola = '312'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('312','4','MS','34','3090',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-89','Storia dell''arte')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '313')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3091',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-90',title = 'Studi europei' WHERE idclassescuola = '313'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('313','3','MS','34','3091',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-90','Studi europei')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '314')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3092',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-91',title = 'Tecniche e metodi per la societa dell''informazione' WHERE idclassescuola = '314'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('314','3','MS','34','3092',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-91','Tecniche e metodi per la societa dell''informazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '315')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3093',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-92',title = 'Teorie della comunicazione' WHERE idclassescuola = '315'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('315','3','MS','34','3093',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-92','Teorie della comunicazione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '316')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3094',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-93',title = 'Teorie e metodologie dell''e-learning e della media education' WHERE idclassescuola = '316'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('316','4','MS','34','3094',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-93','Teorie e metodologie dell''e-learning e della media education')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '317')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3095',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-94',title = 'Traduzione specialistica e interpretariato' WHERE idclassescuola = '317'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('317','4','MS','34','3095',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-94','Traduzione specialistica e interpretariato')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '318')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3109',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM/SNT1',title = 'Scienze infermieristiche e ostetriche' WHERE idclassescuola = '318'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('318','1','MS','34','3109',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM/SNT1','Scienze infermieristiche e ostetriche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '319')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3110',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM/SNT2',title = 'Scienze riabilitative delle professioni sanitarie' WHERE idclassescuola = '319'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('319','1','MS','34','3110',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM/SNT2','Scienze riabilitative delle professioni sanitarie')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '320')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3111',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM/SNT3',title = 'Scienze delle professioni sanitarie tecniche' WHERE idclassescuola = '320'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('320','1','MS','34','3111',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM/SNT3','Scienze delle professioni sanitarie tecniche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '321')
UPDATE [classescuola] SET idclassescuolaarea = '1',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3112',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM/SNT4',title = 'Scienze delle professioni sanitarie della prevenzione' WHERE idclassescuola = '321'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('321','1','MS','34','3112',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM/SNT4','Scienze delle professioni sanitarie della prevenzione')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '322')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3115',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM/SC',title = 'Scienze criminologiche applicate all''investigazione e alla sicurezza' WHERE idclassescuola = '322'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('322','3','MS','34','3115',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM/SC','Scienze criminologiche applicate all''investigazione e alla sicurezza')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '323')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3118',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM/DS',title = 'Scienze della difesa e della sicurezza' WHERE idclassescuola = '323'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('323','3','MS','34','3118',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM/DS','Scienze della difesa e della sicurezza')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '324')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'LM',idcorsostudionorma = '34',indicecineca = '3119',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-4 C.U.',title = 'Architettura e ingegneria edile-architettura (quinquennale)' WHERE idclassescuola = '324'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('324','2','LM','34','3119',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-4 C.U.','Architettura e ingegneria edile-architettura (quinquennale)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '325')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LM',idcorsostudionorma = '34',indicecineca = '3120',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-85 bis',title = 'Scienze della formazione primaria' WHERE idclassescuola = '325'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('325','4','LM','34','3120',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-85 bis','Scienze della formazione primaria')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '326')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3121',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-14.',title = 'Filologia moderna (abilitazione A043)' WHERE idclassescuola = '326'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('326','4','MS','34','3121',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-14.','Filologia moderna (abilitazione A043)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '327')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3122',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-37.',title = 'Lingue e letterature moderne europee e americane (abilitazione A045)' WHERE idclassescuola = '327'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('327','4','MS','34','3122',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-37.','Lingue e letterature moderne europee e americane (abilitazione A045)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '328')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3123',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-95',title = 'Classe di abilitazione A059 - Matematica e scienze nella scuola secondaria di I grado' WHERE idclassescuola = '328'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('328','2','MS','34','3123',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-95','Classe di abilitazione A059 - Matematica e scienze nella scuola secondaria di I grado')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '329')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LM',idcorsostudionorma = '34',indicecineca = '3124',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LMR/02',title = 'Conservazione e restauro dei beni culturali' WHERE idclassescuola = '329'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('329','4','LM','34','3124',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LMR/02','Conservazione e restauro dei beni culturali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '330')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3125',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-67.',title = 'Scienze e tecniche delle attivit? motorie preventive e adattate (abilitazione A030)' WHERE idclassescuola = '330'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('330','2','MS','34','3125',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-67.','Scienze e tecniche delle attivit? motorie preventive e adattate (abilitazione A030)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '331')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3126',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-45.',title = 'Musicologia e beni musicali (abilitazione A032)' WHERE idclassescuola = '331'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('331','2','MS','34','3126',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-45.','Musicologia e beni musicali (abilitazione A032)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '332')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3127',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-96',title = 'Classe di abilitazione A033 - Tecnologia' WHERE idclassescuola = '332'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('332','2','MS','34','3127',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-96','Classe di abilitazione A033 - Tecnologia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '333')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = '34',indicecineca = '3128',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-68.',title = 'Scienze e tecniche dello sport (abilitazione A030)' WHERE idclassescuola = '333'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('333','2','MS','34','3128',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-68.','Scienze e tecniche dello sport (abilitazione A030)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '334')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LM',idcorsostudionorma = '34',indicecineca = '3129',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-85 bis.',title = 'Scienze della formazione primaria (nota 54 29/4/11) (BZ)' WHERE idclassescuola = '334'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('334','4','LM','34','3129',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-85 bis.','Scienze della formazione primaria (nota 54 29/4/11) (BZ)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '335')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LM',idcorsostudionorma = '34',indicecineca = '3130',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-85 bis,',title = 'Scienze della formazione primaria (nota 54 29/4/11) (AO)' WHERE idclassescuola = '335'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('335','4','LM','34','3130',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-85 bis,','Scienze della formazione primaria (nota 54 29/4/11) (AO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '336')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LM',idcorsostudionorma = '34',indicecineca = '3131',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-85 bis:',title = 'Scienze della formazione primaria (nota 54 29/4/11) (UD)' WHERE idclassescuola = '336'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('336','4','LM','34','3131',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-85 bis:','Scienze della formazione primaria (nota 54 29/4/11) (UD)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '337')
UPDATE [classescuola] SET idclassescuolaarea = '4',idclassescuolakind = 'LM',idcorsostudionorma = '34',indicecineca = '3132',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM-85 bis..',title = 'Scienze della formazione primaria (nota 54 29/4/11) (BZ)' WHERE idclassescuola = '337'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('337','4','LM','34','3132',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM-85 bis..','Scienze della formazione primaria (nota 54 29/4/11) (BZ)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '338')
UPDATE [classescuola] SET idclassescuolaarea = '3',idclassescuolakind = 'LM',idcorsostudionorma = null,indicecineca = '3133',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM/GASTR',title = 'Scienze economiche  e sociali della gastronomia' WHERE idclassescuola = '338'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('338','3','LM',null,'3133',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM/GASTR','Scienze economiche  e sociali della gastronomia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '339')
UPDATE [classescuola] SET idclassescuolaarea = '2',idclassescuolakind = 'MS',idcorsostudionorma = null,indicecineca = '3134',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'LM/SC-GIUR',title = 'Scienze Giuridiche' WHERE idclassescuola = '339'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('339','2','MS',null,'3134',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'LM/SC-GIUR','Scienze Giuridiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '340')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SD',idcorsostudionorma = '30',indicecineca = '5001',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5001',title = 'Classe Medicina clinica generale' WHERE idclassescuola = '340'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('340','6','SD','30','5001',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5001','Classe Medicina clinica generale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '341')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SD',idcorsostudionorma = '30',indicecineca = '5002',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5002',title = 'Classe Medicina specialistica' WHERE idclassescuola = '341'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('341','6','SD','30','5002',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5002','Classe Medicina specialistica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '342')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SD',idcorsostudionorma = '30',indicecineca = '5003',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5003',title = 'Classe Neuroscienze e scienze cliniche del comportamento' WHERE idclassescuola = '342'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('342','6','SD','30','5003',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5003','Classe Neuroscienze e scienze cliniche del comportamento')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '343')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SD',idcorsostudionorma = '30',indicecineca = '5004',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5004',title = 'Classe Medicina clinica dell''et? evolutiva' WHERE idclassescuola = '343'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('343','6','SD','30','5004',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5004','Classe Medicina clinica dell''et? evolutiva')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '344')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SC',idcorsostudionorma = '30',indicecineca = '5005',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5005',title = 'Classe delle Chirurgie generali' WHERE idclassescuola = '344'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('344','6','SC','30','5005',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5005','Classe delle Chirurgie generali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '345')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SC',idcorsostudionorma = '30',indicecineca = '5006',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5006',title = 'Classe delle Chirurgie specialistiche' WHERE idclassescuola = '345'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('345','6','SC','30','5006',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5006','Classe delle Chirurgie specialistiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '346')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SC',idcorsostudionorma = '30',indicecineca = '5007',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5007',title = 'Classe delle Chirurgie del distretto testa e collo' WHERE idclassescuola = '346'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('346','6','SC','30','5007',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5007','Classe delle Chirurgie del distretto testa e collo')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '347')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SC',idcorsostudionorma = '30',indicecineca = '5008',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5008',title = 'Classe delle Chirurgie cardio-toraco-vascolari' WHERE idclassescuola = '347'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('347','6','SC','30','5008',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5008','Classe delle Chirurgie cardio-toraco-vascolari')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '348')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '30',indicecineca = '5009',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5009',title = 'Classe della Medicina diagnostica e di laboratorio' WHERE idclassescuola = '348'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('348','6','SS','30','5009',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5009','Classe della Medicina diagnostica e di laboratorio')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '349')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '30',indicecineca = '5010',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5010',title = 'Classe della diagnostica per immagini e radioterapia' WHERE idclassescuola = '349'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('349','6','SS','30','5010',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5010','Classe della diagnostica per immagini e radioterapia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '350')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '30',indicecineca = '5011',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5011',title = 'Classe dei servizi clinici specialistici' WHERE idclassescuola = '350'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('350','6','SS','30','5011',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5011','Classe dei servizi clinici specialistici')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '351')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '30',indicecineca = '5012',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5012',title = 'Classe dei servizi clinici biomedici' WHERE idclassescuola = '351'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('351','6','SS','30','5012',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5012','Classe dei servizi clinici biomedici')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '352')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '30',indicecineca = '5013',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5013',title = 'Classe delle specializzazioni in odontoiatria' WHERE idclassescuola = '352'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('352','6','SS','30','5013',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5013','Classe delle specializzazioni in odontoiatria')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '353')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '30',indicecineca = '5014',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5014',title = 'Classe della sanit? pubblica' WHERE idclassescuola = '353'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('353','6','SS','30','5014',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5014','Classe della sanit? pubblica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '354')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '30',indicecineca = '5015',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5015',title = 'Classe della farmaceutica' WHERE idclassescuola = '354'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('354','6','SS','30','5015',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5015','Classe della farmaceutica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '355')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '30',indicecineca = '5016',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5016',title = 'Classe della fisica sanitaria' WHERE idclassescuola = '355'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('355','6','SS','30','5016',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5016','Classe della fisica sanitaria')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '356')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SC',idcorsostudionorma = '30',indicecineca = '5065',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5005-6',title = 'Classe delle Chirurgie generali' WHERE idclassescuola = '356'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('356','6','SC','30','5065',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5005-6','Classe delle Chirurgie generali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '357')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SC',idcorsostudionorma = '30',indicecineca = '5066',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5006-6',title = 'Classe delle Chirurgie specialistiche' WHERE idclassescuola = '357'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('357','6','SC','30','5066',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5006-6','Classe delle Chirurgie specialistiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '358')
UPDATE [classescuola] SET idclassescuolaarea = '8',idclassescuolakind = 'SV',idcorsostudionorma = '30',indicecineca = '5101',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAV-5101',title = 'Classe della Sanit? animale' WHERE idclassescuola = '358'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('358','8','SV','30','5101',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAV-5101','Classe della Sanit? animale')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '359')
UPDATE [classescuola] SET idclassescuolaarea = '8',idclassescuolakind = 'SV',idcorsostudionorma = '30',indicecineca = '5102',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAV-5102',title = 'Classe dell''igiene della produzione, trasformazione, commercializzazione, conservazione e trasporto degli alimenti di origine animale e loro derivati' WHERE idclassescuola = '359'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('359','8','SV','30','5102',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAV-5102','Classe dell''igiene della produzione, trasformazione, commercializzazione, conservazione e trasporto degli alimenti di origine animale e loro derivati')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '360')
UPDATE [classescuola] SET idclassescuolaarea = '8',idclassescuolakind = 'SV',idcorsostudionorma = '30',indicecineca = '5103',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAV-5103',title = 'Classe dell''igiene degli allevamenti e delle produzioni zootecniche' WHERE idclassescuola = '360'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('360','8','SV','30','5103',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAV-5103','Classe dell''igiene degli allevamenti e delle produzioni zootecniche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '361')
UPDATE [classescuola] SET idclassescuolaarea = '5',idclassescuolakind = 'SB',idcorsostudionorma = '30',indicecineca = '5201',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAB-5201',title = 'Beni archeologici' WHERE idclassescuola = '361'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('361','5','SB','30','5201',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAB-5201','Beni archeologici')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '362')
UPDATE [classescuola] SET idclassescuolaarea = '5',idclassescuolakind = 'SB',idcorsostudionorma = '30',indicecineca = '5202',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAB-5202',title = 'Beni architettonici e del paesaggio' WHERE idclassescuola = '362'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('362','5','SB','30','5202',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAB-5202','Beni architettonici e del paesaggio')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '363')
UPDATE [classescuola] SET idclassescuolaarea = '5',idclassescuolakind = 'SB',idcorsostudionorma = '30',indicecineca = '5203',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAB-5203',title = 'Beni storici artistici' WHERE idclassescuola = '363'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('363','5','SB','30','5203',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAB-5203','Beni storici artistici')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '364')
UPDATE [classescuola] SET idclassescuolaarea = '5',idclassescuolakind = 'SB',idcorsostudionorma = '30',indicecineca = '5204',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAB-5204',title = 'Beni archivistici e librari' WHERE idclassescuola = '364'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('364','5','SB','30','5204',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAB-5204','Beni archivistici e librari')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '365')
UPDATE [classescuola] SET idclassescuolaarea = '5',idclassescuolakind = 'SB',idcorsostudionorma = '30',indicecineca = '5205',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAB-5205',title = 'Beni demoetnoantropologici' WHERE idclassescuola = '365'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('365','5','SB','30','5205',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAB-5205','Beni demoetnoantropologici')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '366')
UPDATE [classescuola] SET idclassescuolaarea = '5',idclassescuolakind = 'SB',idcorsostudionorma = '30',indicecineca = '5206',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAB-5206',title = 'Beni musicali' WHERE idclassescuola = '366'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('366','5','SB','30','5206',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAB-5206','Beni musicali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '367')
UPDATE [classescuola] SET idclassescuolaarea = '5',idclassescuolakind = 'SB',idcorsostudionorma = '30',indicecineca = '5207',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAB-5207',title = 'Beni scientifici e tecnologici' WHERE idclassescuola = '367'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('367','5','SB','30','5207',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAB-5207','Beni scientifici e tecnologici')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '368')
UPDATE [classescuola] SET idclassescuolaarea = '5',idclassescuolakind = 'SB',idcorsostudionorma = '30',indicecineca = '5208',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAB-5208',title = 'Beni naturali e territoriali' WHERE idclassescuola = '368'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('368','5','SB','30','5208',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAB-5208','Beni naturali e territoriali')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '369')
UPDATE [classescuola] SET idclassescuolaarea = '7',idclassescuolakind = 'SP',idcorsostudionorma = '30',indicecineca = '5301',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAP-5301',title = 'Area psicologica' WHERE idclassescuola = '369'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('369','7','SP','30','5301',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAP-5301','Area psicologica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '370')
UPDATE [classescuola] SET idclassescuolaarea = '7',idclassescuolakind = 'SP',idcorsostudionorma = '30',indicecineca = '5303',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAP-5303',title = 'Area psicologica dm 10/3/2010' WHERE idclassescuola = '370'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('370','7','SP','30','5303',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAP-5303','Area psicologica dm 10/3/2010')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '371')
UPDATE [classescuola] SET idclassescuolaarea = '9',idclassescuolakind = 'SR',idcorsostudionorma = '30',indicecineca = '5401',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAR-5401',title = 'Valutazione e Gestione del Rischio Chimico' WHERE idclassescuola = '371'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('371','9','SR','30','5401',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAR-5401','Valutazione e Gestione del Rischio Chimico')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '372')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SD',idcorsostudionorma = '29',indicecineca = '5501',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5501',title = 'Classe della Medicina clinica generale e specialistica' WHERE idclassescuola = '372'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('372','6','SD','29','5501',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5501','Classe della Medicina clinica generale e specialistica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '373')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SD',idcorsostudionorma = '29',indicecineca = '5503',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5503',title = 'Classe delle Neuroscienze e scienze cliniche del comportamento' WHERE idclassescuola = '373'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('373','6','SD','29','5503',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5503','Classe delle Neuroscienze e scienze cliniche del comportamento')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '374')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SD',idcorsostudionorma = '29',indicecineca = '5504',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5504',title = 'Classe della Medicina clinica dell''et? evolutiva' WHERE idclassescuola = '374'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('374','6','SD','29','5504',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5504','Classe della Medicina clinica dell''et? evolutiva')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '375')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SC',idcorsostudionorma = '29',indicecineca = '5505',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5505',title = 'Classe delle Chirurgie generali e specialistiche' WHERE idclassescuola = '375'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('375','6','SC','29','5505',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5505','Classe delle Chirurgie generali e specialistiche')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '376')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SC',idcorsostudionorma = '29',indicecineca = '5507',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5507',title = 'Classe delle Chirurgie del distretto testa e collo' WHERE idclassescuola = '376'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('376','6','SC','29','5507',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5507','Classe delle Chirurgie del distretto testa e collo')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '377')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SC',idcorsostudionorma = '29',indicecineca = '5508',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5508',title = 'Classe delle Chirurgie cardio-toraco-vascolari' WHERE idclassescuola = '377'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('377','6','SC','29','5508',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5508','Classe delle Chirurgie cardio-toraco-vascolari')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '378')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '29',indicecineca = '5509',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5509',title = 'Classe della Medicina diagnostica e di laboratorio' WHERE idclassescuola = '378'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('378','6','SS','29','5509',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5509','Classe della Medicina diagnostica e di laboratorio')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '379')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '29',indicecineca = '5510',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5510',title = 'Classe della diagnostica per immagini e radioterapia' WHERE idclassescuola = '379'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('379','6','SS','29','5510',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5510','Classe della diagnostica per immagini e radioterapia')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '380')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '29',indicecineca = '5511',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5511',title = 'Classe dei servizi clinici specialistici' WHERE idclassescuola = '380'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('380','6','SS','29','5511',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5511','Classe dei servizi clinici specialistici')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '381')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '29',indicecineca = '5512',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5512',title = 'Classe dei servizi clinici specialistici biomedici' WHERE idclassescuola = '381'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('381','6','SS','29','5512',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5512','Classe dei servizi clinici specialistici biomedici')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '382')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '29',indicecineca = '5513',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5513',title = 'Classe delle specializzazioni in odontoiatria' WHERE idclassescuola = '382'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('382','6','SS','29','5513',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5513','Classe delle specializzazioni in odontoiatria')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '383')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '29',indicecineca = '5514',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5514',title = 'Classe della sanit? pubblica' WHERE idclassescuola = '383'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('383','6','SS','29','5514',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5514','Classe della sanit? pubblica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '384')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '29',indicecineca = '5515',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5515',title = 'Classe della farmaceutica' WHERE idclassescuola = '384'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('384','6','SS','29','5515',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5515','Classe della farmaceutica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '385')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '29',indicecineca = '5516',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5516',title = 'Classe della fisica sanitaria' WHERE idclassescuola = '385'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('385','6','SS','29','5516',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5516','Classe della fisica sanitaria')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '386')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SD',idcorsostudionorma = '29',indicecineca = '5517',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5517',title = 'Classe Medicina clinica generale e specialistica (4 anni)' WHERE idclassescuola = '386'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('386','6','SD','29','5517',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5517','Classe Medicina clinica generale e specialistica (4 anni)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '387')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SC',idcorsostudionorma = '29',indicecineca = '5518',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5518',title = 'Classe delle Chirurgie del distretto testa e collo (4 anni)' WHERE idclassescuola = '387'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('387','6','SC','29','5518',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5518','Classe delle Chirurgie del distretto testa e collo (4 anni)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '388')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '29',indicecineca = '5519',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5519',title = 'Classe dei servizi clinici specialistici (4 anni)' WHERE idclassescuola = '388'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('388','6','SS','29','5519',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5519','Classe dei servizi clinici specialistici (4 anni)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '389')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '29',indicecineca = '5520',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5520',title = 'Classe della sanit? pubblica' WHERE idclassescuola = '389'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('389','6','SS','29','5520',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5520','Classe della sanit? pubblica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '390')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '29',indicecineca = '5521',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5509.',title = 'Classe della Medicina diagnostica e di laboratorio (non medici)' WHERE idclassescuola = '390'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('390','6','SS','29','5521',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5509.','Classe della Medicina diagnostica e di laboratorio (non medici)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '391')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '29',indicecineca = '5522',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5512.',title = 'Classe dei servizi clinici specialistici biomedici (non medici)' WHERE idclassescuola = '391'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('391','6','SS','29','5522',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5512.','Classe dei servizi clinici specialistici biomedici (non medici)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '392')
UPDATE [classescuola] SET idclassescuolaarea = '6',idclassescuolakind = 'SS',idcorsostudionorma = '29',indicecineca = '5523',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'SAS-5520.',title = 'Classe della sanit? pubblica (non medici)' WHERE idclassescuola = '392'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('392','6','SS','29','5523',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'SAS-5520.','Classe della sanit? pubblica (non medici)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '393')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6001',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A030',title = 'SCIENZE MOTORIE E SPORTIVE' WHERE idclassescuola = '393'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('393',null,'TF',null,'6001',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A030','SCIENZE MOTORIE E SPORTIVE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '394')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6002',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A032',title = 'MUSICA' WHERE idclassescuola = '394'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('394',null,'TF',null,'6002',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A032','MUSICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '395')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6003',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A033',title = 'TECNOLOGIA' WHERE idclassescuola = '395'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('395',null,'TF',null,'6003',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A033','TECNOLOGIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '396')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6004',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A043',title = 'ITALIANO, STORIA  E GEOGRAFIA NELLA SCUOLA SECONDARIA DI I GRADO' WHERE idclassescuola = '396'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('396',null,'TF',null,'6004',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A043','ITALIANO, STORIA  E GEOGRAFIA NELLA SCUOLA SECONDARIA DI I GRADO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '397')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6005',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A059',title = 'MATEMATICHE E SCIENZE NELLA SCUOLA SECONDARIA DI I GRADO' WHERE idclassescuola = '397'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('397',null,'TF',null,'6005',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A059','MATEMATICHE E SCIENZE NELLA SCUOLA SECONDARIA DI I GRADO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '398')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6006',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A245',title = 'LINGUA STRANIERA (FRANCESE)' WHERE idclassescuola = '398'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('398',null,'TF',null,'6006',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A245','LINGUA STRANIERA (FRANCESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '399')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6007',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A345',title = 'LINGUA STRANIERA (INGLESE) ' WHERE idclassescuola = '399'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('399',null,'TF',null,'6007',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A345','LINGUA STRANIERA (INGLESE) ')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '400')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6008',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A080',title = 'ITALIANO NELLA SCUOLA MEDIA CON LINGUA DI INSEGNAMENTO SLOVENA' WHERE idclassescuola = '400'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('400',null,'TF',null,'6008',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A080','ITALIANO NELLA SCUOLA MEDIA CON LINGUA DI INSEGNAMENTO SLOVENA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '401')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6009',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A085',title = 'SLOVENO,STORIA ED EDCIVICA E GEOGRAFIA NELLA SCUOLA MEDIA CON LINGUA SLOVENA' WHERE idclassescuola = '401'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('401',null,'TF',null,'6009',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A085','SLOVENO,STORIA ED EDCIVICA E GEOGRAFIA NELLA SCUOLA MEDIA CON LINGUA SLOVENA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '402')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6010',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A090',title = 'CULTURA LADINA' WHERE idclassescuola = '402'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('402',null,'TF',null,'6010',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A090','CULTURA LADINA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '403')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6011',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A091',title = 'ITALIANO (SECONDA LINGUA) NELLA SCUOLA MEDIA IN LINGUA TEDESCA' WHERE idclassescuola = '403'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('403',null,'TF',null,'6011',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A091','ITALIANO (SECONDA LINGUA) NELLA SCUOLA MEDIA IN LINGUA TEDESCA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '404')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6012',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A097',title = 'TEDESCO (SECONDA LINGUA) NELLA SCUOLA MEDIA IN LINGUA ITALIANA DELLA PROV DI BOLZANO' WHERE idclassescuola = '404'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('404',null,'TF',null,'6012',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A097','TEDESCO (SECONDA LINGUA) NELLA SCUOLA MEDIA IN LINGUA ITALIANA DELLA PROV DI BOLZANO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '405')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6013',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A098',title = 'TEDESCO,STORIA ED ED.CIVICA,GEOGRAFIA SC.MEDIA LING.TEDESCA E CON LINGINS.TEDLOC.LAD' WHERE idclassescuola = '405'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('405',null,'TF',null,'6013',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A098','TEDESCO,STORIA ED ED.CIVICA,GEOGRAFIA SC.MEDIA LING.TEDESCA E CON LINGINS.TEDLOC.LAD')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '406')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6014',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A013',title = 'CHIMICA E TECNOLOGIE CHIMICHE' WHERE idclassescuola = '406'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('406',null,'TF',null,'6014',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A013','CHIMICA E TECNOLOGIE CHIMICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '407')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6015',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A016',title = 'COSTRUZIONI, TECNOLOGIA DELLE COSTRUZIONI E DISEGNO TECNICO' WHERE idclassescuola = '407'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('407',null,'TF',null,'6015',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A016','COSTRUZIONI, TECNOLOGIA DELLE COSTRUZIONI E DISEGNO TECNICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '408')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6016',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A017',title = 'DISCIPLINE ECONOMICO-AZIENDALI' WHERE idclassescuola = '408'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('408',null,'TF',null,'6016',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A017','DISCIPLINE ECONOMICO-AZIENDALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '409')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6017',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A019',title = 'DISCIPLINE GIURIDICHE ED ECONOMICHE' WHERE idclassescuola = '409'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('409',null,'TF',null,'6017',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A019','DISCIPLINE GIURIDICHE ED ECONOMICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '410')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6018',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A020',title = 'DISCIPLINE MECCANICHE E TECNOLOGIA' WHERE idclassescuola = '410'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('410',null,'TF',null,'6018',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A020','DISCIPLINE MECCANICHE E TECNOLOGIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '411')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6019',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A029',title = 'EDUCAZIONE FISICA NEGLI ISTITUTI E SCUOLE DI ISTRUZIONE SECONDARIA II GRADO' WHERE idclassescuola = '411'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('411',null,'TF',null,'6019',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A029','EDUCAZIONE FISICA NEGLI ISTITUTI E SCUOLE DI ISTRUZIONE SECONDARIA II GRADO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '412')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6020',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A034',title = 'ELETTRONICA' WHERE idclassescuola = '412'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('412',null,'TF',null,'6020',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A034','ELETTRONICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '413')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6021',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A035',title = 'ELETTROTECNICA ED APPLICAZIONI' WHERE idclassescuola = '413'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('413',null,'TF',null,'6021',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A035','ELETTROTECNICA ED APPLICAZIONI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '414')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6022',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A036',title = 'FILOSOFIA, PSICOLOGIA E SCIENZE DELL''EDUCAZIONE' WHERE idclassescuola = '414'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('414',null,'TF',null,'6022',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A036','FILOSOFIA, PSICOLOGIA E SCIENZE DELL''EDUCAZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '415')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6023',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A037',title = 'FILOSOFIA E STORIA' WHERE idclassescuola = '415'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('415',null,'TF',null,'6023',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A037','FILOSOFIA E STORIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '416')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6024',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A038',title = 'FISICA' WHERE idclassescuola = '416'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('416',null,'TF',null,'6024',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A038','FISICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '417')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6025',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A039',title = 'GEOGRAFIA' WHERE idclassescuola = '417'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('417',null,'TF',null,'6025',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A039','GEOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '418')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6026',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A042',title = 'INFORMATICA' WHERE idclassescuola = '418'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('418',null,'TF',null,'6026',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A042','INFORMATICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '419')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6027',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A047',title = 'MATEMATICA' WHERE idclassescuola = '419'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('419',null,'TF',null,'6027',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A047','MATEMATICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '420')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6028',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A048',title = 'MATEMATICA APPLICATA' WHERE idclassescuola = '420'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('420',null,'TF',null,'6028',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A048','MATEMATICA APPLICATA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '421')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6029',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A049',title = 'MATEMATICA E FISICA' WHERE idclassescuola = '421'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('421',null,'TF',null,'6029',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A049','MATEMATICA E FISICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '422')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6030',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A050',title = 'MATERIE LETTERARIE NEGLI ISTITUTI DI ISTRUZIONE SECONDARIA DI II GRADO' WHERE idclassescuola = '422'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('422',null,'TF',null,'6030',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A050','MATERIE LETTERARIE NEGLI ISTITUTI DI ISTRUZIONE SECONDARIA DI II GRADO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '423')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6031',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A051',title = 'MATERIE LETTERARIE E LATINO NEI LICEI E NELL''ISTITUTO MAGISTRALE' WHERE idclassescuola = '423'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('423',null,'TF',null,'6031',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A051','MATERIE LETTERARIE E LATINO NEI LICEI E NELL''ISTITUTO MAGISTRALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '424')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6032',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A052',title = 'MATERIE LETTERARIE, LATINO E GRECO NEL LICEO CLASSICO' WHERE idclassescuola = '424'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('424',null,'TF',null,'6032',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A052','MATERIE LETTERARIE, LATINO E GRECO NEL LICEO CLASSICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '425')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6033',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A057',title = 'SCIENZA DEGLI ALIMENTI' WHERE idclassescuola = '425'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('425',null,'TF',null,'6033',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A057','SCIENZA DEGLI ALIMENTI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '426')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6034',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A058',title = 'SCIENZE E MECCANICA AGRARIA, TECNICHE DI GESTIONE AZIENDALE, FITOPATOLOGIA ED ENTOMOLOGIA AGRARIA' WHERE idclassescuola = '426'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('426',null,'TF',null,'6034',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A058','SCIENZE E MECCANICA AGRARIA, TECNICHE DI GESTIONE AZIENDALE, FITOPATOLOGIA ED ENTOMOLOGIA AGRARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '427')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6035',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A060',title = 'SCIENZE NATURALI, CHIMICA E GEOGRAFIA, MICROBIOLOGIA' WHERE idclassescuola = '427'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('427',null,'TF',null,'6035',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A060','SCIENZE NATURALI, CHIMICA E GEOGRAFIA, MICROBIOLOGIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '428')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6036',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A061',title = 'STORIA DELL''ARTE' WHERE idclassescuola = '428'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('428',null,'TF',null,'6036',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A061','STORIA DELL''ARTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '429')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6037',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A071',title = 'TECNOLOGIA E DISEGNO TECNICO' WHERE idclassescuola = '429'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('429',null,'TF',null,'6037',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A071','TECNOLOGIA E DISEGNO TECNICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '430')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6038',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A072',title = 'TOPOGRAFIA GENERALE, COSTRUZIONI RURALI E DISEGNO' WHERE idclassescuola = '430'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('430',null,'TF',null,'6038',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A072','TOPOGRAFIA GENERALE, COSTRUZIONI RURALI E DISEGNO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '431')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6039',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A246',title = 'LINGUA E CIVILTA'' STRANIERA (FRANCESE)' WHERE idclassescuola = '431'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('431',null,'TF',null,'6039',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A246','LINGUA E CIVILTA'' STRANIERA (FRANCESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '432')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6040',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A346',title = 'LINGUA E CIVILTA'' STRANIERA (INGLESE)' WHERE idclassescuola = '432'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('432',null,'TF',null,'6040',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A346','LINGUA E CIVILTA'' STRANIERA (INGLESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '433')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6041',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A446',title = 'LINGUA E CIVILTA'' STRANIERA (SPAGNOLO)' WHERE idclassescuola = '433'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('433',null,'TF',null,'6041',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A446','LINGUA E CIVILTA'' STRANIERA (SPAGNOLO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '434')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6042',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A546',title = 'LINGUA E CIVILTA'' STRANIERA (TEDESCO)' WHERE idclassescuola = '434'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('434',null,'TF',null,'6042',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A546','LINGUA E CIVILTA'' STRANIERA (TEDESCO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '435')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6043',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A646',title = 'LINGUA E CIVILTA'' STRANIERA (RUSSO)' WHERE idclassescuola = '435'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('435',null,'TF',null,'6043',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A646','LINGUA E CIVILTA'' STRANIERA (RUSSO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '436')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6044',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A111',title = 'LINGUA E CIVILTA'' STRANIERA (CINESE)' WHERE idclassescuola = '436'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('436',null,'TF',null,'6044',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A111','LINGUA E CIVILTA'' STRANIERA (CINESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '437')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6045',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A112',title = 'LINGUA E CIVILTA'' STRANIERA (ARABO)' WHERE idclassescuola = '437'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('437',null,'TF',null,'6045',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A112','LINGUA E CIVILTA'' STRANIERA (ARABO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '438')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6046',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'XXXX',title = 'Altra lingua straniera' WHERE idclassescuola = '438'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('438',null,'TF',null,'6046',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'XXXX','Altra lingua straniera')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '439')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6047',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A081',title = 'LINGUA E LETTERE ITALIANE NEGLI ISTITUTI DI ISTRSECONDARIA DI II GRADO LINGUA SLOVENA' WHERE idclassescuola = '439'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('439',null,'TF',null,'6047',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A081','LINGUA E LETTERE ITALIANE NEGLI ISTITUTI DI ISTRSECONDARIA DI II GRADO LINGUA SLOVENA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '440')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6048',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A082',title = 'MATERIE LETTERARIE NEGLI ISTITUTI DI II GRADO DI LINGUA SLOVENA' WHERE idclassescuola = '440'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('440',null,'TF',null,'6048',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A082','MATERIE LETTERARIE NEGLI ISTITUTI DI II GRADO DI LINGUA SLOVENA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '441')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6049',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A083',title = 'MATERIE LETTERARIE E LATINO NEI LICEI E ISTITUTI MAGISTRALI DI LINGUA SLOVENA' WHERE idclassescuola = '441'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('441',null,'TF',null,'6049',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A083','MATERIE LETTERARIE E LATINO NEI LICEI E ISTITUTI MAGISTRALI DI LINGUA SLOVENA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '442')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6050',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A084',title = 'MATERIE LETTERARIE, LATINO E GRECO NEI LICEI CLASSICI  DI LINGUA SLOVENA' WHERE idclassescuola = '442'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('442',null,'TF',null,'6050',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A084','MATERIE LETTERARIE, LATINO E GRECO NEI LICEI CLASSICI  DI LINGUA SLOVENA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '443')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6051',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A086',title = 'DATTILOGRAFIA E STENOGRAFIA NEGLI ISTITUTI DI II GRADO DI LINGUA SLOVENA' WHERE idclassescuola = '443'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('443',null,'TF',null,'6051',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A086','DATTILOGRAFIA E STENOGRAFIA NEGLI ISTITUTI DI II GRADO DI LINGUA SLOVENA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '444')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6052',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A087',title = 'TRATTAMENTO TESTI, CALCOLO, CONTAB.ELETTRON.ED  APPLICAZGESTIONALI CON LINGUA SLOVENA' WHERE idclassescuola = '444'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('444',null,'TF',null,'6052',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A087','TRATTAMENTO TESTI, CALCOLO, CONTAB.ELETTRON.ED  APPLICAZGESTIONALI CON LINGUA SLOVENA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '445')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6053',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A092',title = 'LINGUA E LETTERE ITALIANE (SECONDA LINGUA) NEGLI ISTITUTI DI II GRADO IN LINGUA TEDESCA' WHERE idclassescuola = '445'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('445',null,'TF',null,'6053',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A092','LINGUA E LETTERE ITALIANE (SECONDA LINGUA) NEGLI ISTITUTI DI II GRADO IN LINGUA TEDESCA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '446')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6054',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A093',title = 'MATERIE LETTERARIE NEGLI ISTITUTI DI II GRADO IN LINGUA TEDESCA E LOCLADINE' WHERE idclassescuola = '446'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('446',null,'TF',null,'6054',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A093','MATERIE LETTERARIE NEGLI ISTITUTI DI II GRADO IN LINGUA TEDESCA E LOCLADINE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '447')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6055',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A094',title = 'MATERIE LETTERARIE E LATINO NEI LICEI E IST.MAGISTRALI IN LINGUA TEDESCA E LOC.LADINE' WHERE idclassescuola = '447'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('447',null,'TF',null,'6055',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A094','MATERIE LETTERARIE E LATINO NEI LICEI E IST.MAGISTRALI IN LINGUA TEDESCA E LOC.LADINE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '448')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6056',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A095',title = 'MATERIE LETTERARIE, LATINO E GRECO NEI LICEI CLASSICI  IN LINGUA TEDESCA E LOC.LADINE' WHERE idclassescuola = '448'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('448',null,'TF',null,'6056',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A095','MATERIE LETTERARIE, LATINO E GRECO NEI LICEI CLASSICI  IN LINGUA TEDESCA E LOC.LADINE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '449')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6057',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A096',title = 'TEDESCO (SECLINGUA) NEGLI ISTITUTI DI II GRADO IN LINGITALDELLA PROV.BOLZANO' WHERE idclassescuola = '449'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('449',null,'TF',null,'6057',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A096','TEDESCO (SECLINGUA) NEGLI ISTITUTI DI II GRADO IN LINGITALDELLA PROV.BOLZANO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '450')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6058',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A099',title = 'DATTILOGRAFIA E STENOGRAFIA NEGLI ISTITUTI DI II GRADO IN LINGUA TEDESCA E LOC.LADINE' WHERE idclassescuola = '450'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('450',null,'TF',null,'6058',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A099','DATTILOGRAFIA E STENOGRAFIA NEGLI ISTITUTI DI II GRADO IN LINGUA TEDESCA E LOC.LADINE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '451')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6059',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A100',title = 'TRATTAMENTO TESTI, CALCOLO, CONTAB.ELETTRONICA ED APPLICAZ. GESTION.LINGUA TEDESCA LOC.LAD' WHERE idclassescuola = '451'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('451',null,'TF',null,'6059',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A100','TRATTAMENTO TESTI, CALCOLO, CONTAB.ELETTRONICA ED APPLICAZ. GESTION.LINGUA TEDESCA LOC.LAD')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '452')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6060',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C999',title = '-' WHERE idclassescuola = '452'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('452',null,'TF',null,'6060',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C999','-')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '453')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6061',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A001',title = 'AEROTECNICA E COSTRUZIONI AERONAUTICHE' WHERE idclassescuola = '453'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('453',null,'TF',null,'6061',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A001','AEROTECNICA E COSTRUZIONI AERONAUTICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '454')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6062',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A002',title = 'ANATOMIA, FISIOPATOLOGIA OCULARE E LABORATORIO DI MISURE OFTALMICHE' WHERE idclassescuola = '454'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('454',null,'TF',null,'6062',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A002','ANATOMIA, FISIOPATOLOGIA OCULARE E LABORATORIO DI MISURE OFTALMICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '455')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6063',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A003',title = 'ARTE DEL DISEGNO ANIMATO' WHERE idclassescuola = '455'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('455',null,'TF',null,'6063',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A003','ARTE DEL DISEGNO ANIMATO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '456')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6064',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A004',title = 'ARTE DEL TESSUTO DELLA MODA E DEL COSTUME' WHERE idclassescuola = '456'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('456',null,'TF',null,'6064',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A004','ARTE DEL TESSUTO DELLA MODA E DEL COSTUME')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '457')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6065',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A005',title = 'ARTE DEL VETRO' WHERE idclassescuola = '457'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('457',null,'TF',null,'6065',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A005','ARTE DEL VETRO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '458')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6066',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A006',title = 'ARTE DELLA CERAMICA' WHERE idclassescuola = '458'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('458',null,'TF',null,'6066',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A006','ARTE DELLA CERAMICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '459')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6067',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A007',title = 'ARTE DELLA FOTOGRAFIA E GRAFICA PUBBLICITARIA' WHERE idclassescuola = '459'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('459',null,'TF',null,'6067',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A007','ARTE DELLA FOTOGRAFIA E GRAFICA PUBBLICITARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '460')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6068',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A008',title = 'ARTI DELLA GRAFICA E DELL''INCISIONE' WHERE idclassescuola = '460'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('460',null,'TF',null,'6068',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A008','ARTI DELLA GRAFICA E DELL''INCISIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '461')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6069',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A009',title = 'ARTE DELLA STAMPA E DEL RESTAURO DEL LIBRO' WHERE idclassescuola = '461'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('461',null,'TF',null,'6069',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A009','ARTE DELLA STAMPA E DEL RESTAURO DEL LIBRO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '462')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6070',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A010',title = 'ARTI DEI METALLI E DELL''OREFICERIA' WHERE idclassescuola = '462'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('462',null,'TF',null,'6070',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A010','ARTI DEI METALLI E DELL''OREFICERIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '463')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6071',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A011',title = 'ARTE MINERARIA' WHERE idclassescuola = '463'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('463',null,'TF',null,'6071',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A011','ARTE MINERARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '464')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6072',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A012',title = 'CHIMICA AGRARIA' WHERE idclassescuola = '464'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('464',null,'TF',null,'6072',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A012','CHIMICA AGRARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '465')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6073',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A014',title = 'CIRCOLAZIONE AEREA TELECOMUNICAZIONI AERONAUTICHE ED ESERCITAZIONI' WHERE idclassescuola = '465'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('465',null,'TF',null,'6073',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A014','CIRCOLAZIONE AEREA TELECOMUNICAZIONI AERONAUTICHE ED ESERCITAZIONI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '466')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6074',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A015',title = 'COSTRUZIONI NAVALI E TEORIA DELLA NAVE' WHERE idclassescuola = '466'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('466',null,'TF',null,'6074',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A015','COSTRUZIONI NAVALI E TEORIA DELLA NAVE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '467')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6075',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A018',title = 'DISCIPLINE GEOMETRICHE, ARCHITETTONICHE ARREDAMENTO E SCENOTECNICA' WHERE idclassescuola = '467'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('467',null,'TF',null,'6075',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A018','DISCIPLINE GEOMETRICHE, ARCHITETTONICHE ARREDAMENTO E SCENOTECNICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '468')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6076',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A021',title = 'DISCIPLINE PITTORICHE' WHERE idclassescuola = '468'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('468',null,'TF',null,'6076',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A021','DISCIPLINE PITTORICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '469')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6077',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A022',title = 'DISCIPLINE PLASTICHE' WHERE idclassescuola = '469'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('469',null,'TF',null,'6077',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A022','DISCIPLINE PLASTICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '470')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6078',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A023',title = 'DISEGNO E MODELLAZIONE ODONTOTECNICA' WHERE idclassescuola = '470'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('470',null,'TF',null,'6078',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A023','DISEGNO E MODELLAZIONE ODONTOTECNICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '471')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6079',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A024',title = 'DISEGNO E STORIA DEL COSTUME' WHERE idclassescuola = '471'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('471',null,'TF',null,'6079',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A024','DISEGNO E STORIA DEL COSTUME')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '472')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6080',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A025',title = 'DISEGNO E STORIA DELL''ARTE' WHERE idclassescuola = '472'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('472',null,'TF',null,'6080',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A025','DISEGNO E STORIA DELL''ARTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '473')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6081',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A026',title = 'DISEGNO TECNICO' WHERE idclassescuola = '473'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('473',null,'TF',null,'6081',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A026','DISEGNO TECNICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '474')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6082',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A027',title = 'DISEGNO TECNICO ED ARTISTICO' WHERE idclassescuola = '474'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('474',null,'TF',null,'6082',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A027','DISEGNO TECNICO ED ARTISTICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '475')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6083',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A028',title = 'ARTE E IMMAGINE' WHERE idclassescuola = '475'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('475',null,'TF',null,'6083',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A028','ARTE E IMMAGINE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '476')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6084',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A031',title = 'EDUCAZIONE MUSICALE NEGLI ISTITUTI DI ISTRUZIONE SECONDARIA DI II GRADO' WHERE idclassescuola = '476'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('476',null,'TF',null,'6084',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A031','EDUCAZIONE MUSICALE NEGLI ISTITUTI DI ISTRUZIONE SECONDARIA DI II GRADO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '477')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6085',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A040',title = 'IGIENE, ANATOMIA, FISIOLOGIA, PATOLOGIA GENERALE E DELL''APPARATO MASTICATORIO' WHERE idclassescuola = '477'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('477',null,'TF',null,'6085',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A040','IGIENE, ANATOMIA, FISIOLOGIA, PATOLOGIA GENERALE E DELL''APPARATO MASTICATORIO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '478')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6086',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A041',title = 'IGIENE MENTALE E PSICHIATRIA INFANTILE' WHERE idclassescuola = '478'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('478',null,'TF',null,'6086',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A041','IGIENE MENTALE E PSICHIATRIA INFANTILE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '479')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6087',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A044',title = 'LINGUAGGIO PER LA CINEMATOGRAFIA E LA TELEVISIONE' WHERE idclassescuola = '479'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('479',null,'TF',null,'6087',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A044','LINGUAGGIO PER LA CINEMATOGRAFIA E LA TELEVISIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '480')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6088',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A046',title = 'LINGUA E CIVILTA'' STRANIERA' WHERE idclassescuola = '480'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('480',null,'TF',null,'6088',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A046','LINGUA E CIVILTA'' STRANIERA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '481')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6089',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A053',title = 'METEOROLOGIA AERONAUTICA ED ESERCITAZIONI' WHERE idclassescuola = '481'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('481',null,'TF',null,'6089',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A053','METEOROLOGIA AERONAUTICA ED ESERCITAZIONI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '482')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6090',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A054',title = 'MINERALOGIA E GEOLOGIA' WHERE idclassescuola = '482'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('482',null,'TF',null,'6090',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A054','MINERALOGIA E GEOLOGIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '483')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6091',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A055',title = 'NAVIGAZIONE AEREA ED ESERCITAZIONI' WHERE idclassescuola = '483'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('483',null,'TF',null,'6091',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A055','NAVIGAZIONE AEREA ED ESERCITAZIONI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '484')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6092',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A056',title = 'NAVIGAZIONE, ARTE NAVALE ED ELEMENTI DI COSTRUZIONI NAVALI' WHERE idclassescuola = '484'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('484',null,'TF',null,'6092',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A056','NAVIGAZIONE, ARTE NAVALE ED ELEMENTI DI COSTRUZIONI NAVALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '485')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6093',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A062',title = 'TECNICA DELLA REGISTRAZIONE DEL SUONO' WHERE idclassescuola = '485'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('485',null,'TF',null,'6093',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A062','TECNICA DELLA REGISTRAZIONE DEL SUONO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '486')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6094',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A063',title = 'TECNICA DELLA RIPRESA CINEMATOGRAFICA E TELEVISIVA' WHERE idclassescuola = '486'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('486',null,'TF',null,'6094',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A063','TECNICA DELLA RIPRESA CINEMATOGRAFICA E TELEVISIVA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '487')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6095',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A064',title = 'TECNICA E ORGANIZZAZIONE DELLA PRODUZIONE CINEMATOGRAFICA E TELEVISIVA' WHERE idclassescuola = '487'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('487',null,'TF',null,'6095',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A064','TECNICA E ORGANIZZAZIONE DELLA PRODUZIONE CINEMATOGRAFICA E TELEVISIVA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '488')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6096',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A065',title = 'TECNICA FOTOGRAFICA' WHERE idclassescuola = '488'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('488',null,'TF',null,'6096',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A065','TECNICA FOTOGRAFICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '489')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6097',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A066',title = 'TECNOLOGIA CERAMICA' WHERE idclassescuola = '489'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('489',null,'TF',null,'6097',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A066','TECNOLOGIA CERAMICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '490')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6098',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A067',title = 'TECNOLOGIA FOTOGRAFICA, CINEMATOGRAFICA E TELEVISIVA' WHERE idclassescuola = '490'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('490',null,'TF',null,'6098',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A067','TECNOLOGIA FOTOGRAFICA, CINEMATOGRAFICA E TELEVISIVA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '491')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6099',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A068',title = 'TECNOLOGIE DELL''ABBIGLIAMENTO' WHERE idclassescuola = '491'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('491',null,'TF',null,'6099',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A068','TECNOLOGIE DELL''ABBIGLIAMENTO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '492')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6100',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A069',title = 'TECNOLOGIE  GRAFICHE ED IMPIANTI GRAFICI' WHERE idclassescuola = '492'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('492',null,'TF',null,'6100',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A069','TECNOLOGIE  GRAFICHE ED IMPIANTI GRAFICI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '493')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6101',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A070',title = 'TECNOLOGIE TESSILI' WHERE idclassescuola = '493'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('493',null,'TF',null,'6101',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A070','TECNOLOGIE TESSILI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '494')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6102',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A073',title = 'VITA DI RELAZIONE NEGLI ISTITUTI PROFESSIONALI DI STATO PER NON VEDENTI' WHERE idclassescuola = '494'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('494',null,'TF',null,'6102',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A073','VITA DI RELAZIONE NEGLI ISTITUTI PROFESSIONALI DI STATO PER NON VEDENTI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '495')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6103',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A074',title = 'ZOOTECNICA E SCIENZA DELLA PRODUZIONE ANIMALE' WHERE idclassescuola = '495'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('495',null,'TF',null,'6103',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A074','ZOOTECNICA E SCIENZA DELLA PRODUZIONE ANIMALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '496')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6104',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A075',title = 'DATTILOGRAFIA E STENOGRAFIA' WHERE idclassescuola = '496'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('496',null,'TF',null,'6104',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A075','DATTILOGRAFIA E STENOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '497')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6105',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A076',title = 'TRATTAMENTO TESTI, CALCOLO, CONTABILITA'' ELETTRONICA ED APPLICAZIONI GESTIONALI' WHERE idclassescuola = '497'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('497',null,'TF',null,'6105',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A076','TRATTAMENTO TESTI, CALCOLO, CONTABILITA'' ELETTRONICA ED APPLICAZIONI GESTIONALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '498')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6106',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A445',title = 'LINGUA STRANIERA (SPAGNOLO)' WHERE idclassescuola = '498'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('498',null,'TF',null,'6106',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A445','LINGUA STRANIERA (SPAGNOLO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '499')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6107',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A545',title = 'LINGUA STRANIERA (TEDESCO)' WHERE idclassescuola = '499'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('499',null,'TF',null,'6107',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A545','LINGUA STRANIERA (TEDESCO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '500')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6108',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A645',title = 'LINGUA STRANIERA (RUSSO)' WHERE idclassescuola = '500'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('500',null,'TF',null,'6108',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A645','LINGUA STRANIERA (RUSSO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '501')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6109',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A745',title = 'LINGUA STRANIERA (ALBANESE)' WHERE idclassescuola = '501'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('501',null,'TF',null,'6109',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A745','LINGUA STRANIERA (ALBANESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '502')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6110',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A746',title = 'LINGUA E CIVILTA'' STRANIERA (ALBANESE)' WHERE idclassescuola = '502'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('502',null,'TF',null,'6110',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A746','LINGUA E CIVILTA'' STRANIERA (ALBANESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '503')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6111',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A846',title = 'LINGUA E CIVILTA'' STRANIERA (SLOVENO)' WHERE idclassescuola = '503'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('503',null,'TF',null,'6111',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A846','LINGUA E CIVILTA'' STRANIERA (SLOVENO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '504')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6112',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A946',title = 'LINGUA E CIVILTA'' STRANIERA (SERBO-CROATO)' WHERE idclassescuola = '504'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('504',null,'TF',null,'6112',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A946','LINGUA E CIVILTA'' STRANIERA (SERBO-CROATO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '505')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6113',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A998',title = 'CLASSE DI CONCORSO SOPPRESSA AI SENSI DEL D.M3.9.82' WHERE idclassescuola = '505'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('505',null,'TF',null,'6113',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A998','CLASSE DI CONCORSO SOPPRESSA AI SENSI DEL D.M3.9.82')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '506')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6114',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A999',title = 'CLASSE DI CONCORSO SOPPRESSA AI SENSI DEL D.M3.9.82' WHERE idclassescuola = '506'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('506',null,'TF',null,'6114',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A999','CLASSE DI CONCORSO SOPPRESSA AI SENSI DEL D.M3.9.82')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '507')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6115',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C010',title = 'ADDETTO ALL''UFFICIO TECNICO' WHERE idclassescuola = '507'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('507',null,'TF',null,'6115',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C010','ADDETTO ALL''UFFICIO TECNICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '508')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6116',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C020',title = 'ATTIVITA'' PRATICHE SPECIALI' WHERE idclassescuola = '508'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('508',null,'TF',null,'6116',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C020','ATTIVITA'' PRATICHE SPECIALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '509')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6117',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C030',title = 'CONVERSAZIONE IN LINGUA STRANIERA' WHERE idclassescuola = '509'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('509',null,'TF',null,'6117',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C030','CONVERSAZIONE IN LINGUA STRANIERA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '510')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6118',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C031',title = 'CONVERSAZIONE IN LINGUA STRANIERA (FRANCESE)' WHERE idclassescuola = '510'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('510',null,'TF',null,'6118',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C031','CONVERSAZIONE IN LINGUA STRANIERA (FRANCESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '511')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6119',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C032',title = 'CONVERSAZIONE IN LINGUA STRANIERA (INGLESE)' WHERE idclassescuola = '511'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('511',null,'TF',null,'6119',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C032','CONVERSAZIONE IN LINGUA STRANIERA (INGLESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '512')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6120',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C033',title = 'CONVERSAZIONE IN LINGUA STRANIERA (SPAGNOLO)' WHERE idclassescuola = '512'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('512',null,'TF',null,'6120',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C033','CONVERSAZIONE IN LINGUA STRANIERA (SPAGNOLO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '513')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6121',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C034',title = 'CONVERSAZIONE IN LINGUA STRANIERA (TEDESCO)' WHERE idclassescuola = '513'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('513',null,'TF',null,'6121',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C034','CONVERSAZIONE IN LINGUA STRANIERA (TEDESCO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '514')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6122',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C035',title = 'CONVERSAZIONE IN LINGUA STRANIERA (RUSSO)' WHERE idclassescuola = '514'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('514',null,'TF',null,'6122',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C035','CONVERSAZIONE IN LINGUA STRANIERA (RUSSO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '515')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6123',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C036',title = 'CONVERSAZIONE IN LINGUA STRANIERA (ALBANESE)' WHERE idclassescuola = '515'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('515',null,'TF',null,'6123',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C036','CONVERSAZIONE IN LINGUA STRANIERA (ALBANESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '516')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6124',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C037',title = 'CONVERSAZIONE IN LINGUA STRANIERA (SLOVENO)' WHERE idclassescuola = '516'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('516',null,'TF',null,'6124',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C037','CONVERSAZIONE IN LINGUA STRANIERA (SLOVENO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '517')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6125',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C038',title = 'CONVERSAZIONE IN LINGUA STRANIERA (SERBO CROATO)' WHERE idclassescuola = '517'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('517',null,'TF',null,'6125',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C038','CONVERSAZIONE IN LINGUA STRANIERA (SERBO CROATO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '518')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6126',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C040',title = 'ESERCITAZIONI AERONAUTICHE' WHERE idclassescuola = '518'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('518',null,'TF',null,'6126',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C040','ESERCITAZIONI AERONAUTICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '519')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6127',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C050',title = 'ESERCITAZIONI AGRARIE' WHERE idclassescuola = '519'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('519',null,'TF',null,'6127',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C050','ESERCITAZIONI AGRARIE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '520')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6128',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C060',title = 'ESERCITAZIONI CERAMICHE DI DECORAZIONE' WHERE idclassescuola = '520'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('520',null,'TF',null,'6128',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C060','ESERCITAZIONI CERAMICHE DI DECORAZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '521')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6129',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C070',title = 'ESERCITAZIONI DI ABBIGLIAMENTO E MODA' WHERE idclassescuola = '521'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('521',null,'TF',null,'6129',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C070','ESERCITAZIONI DI ABBIGLIAMENTO E MODA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '522')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6130',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C080',title = 'ESERCITAZIONI DI CIRCOLAZIONE AEREA' WHERE idclassescuola = '522'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('522',null,'TF',null,'6130',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C080','ESERCITAZIONI DI CIRCOLAZIONE AEREA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '523')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6131',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C090',title = 'ESERCITAZIONI DI COMUNICAZIONI' WHERE idclassescuola = '523'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('523',null,'TF',null,'6131',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C090','ESERCITAZIONI DI COMUNICAZIONI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '524')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6132',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C100',title = 'ESERCITAZIONI DI DISEGNO ARTISTICO DI TESSUTI' WHERE idclassescuola = '524'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('524',null,'TF',null,'6132',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C100','ESERCITAZIONI DI DISEGNO ARTISTICO DI TESSUTI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '525')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6133',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C110',title = 'ESERCITAZIONI DI ECONOMIA DOMESTICA' WHERE idclassescuola = '525'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('525',null,'TF',null,'6133',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C110','ESERCITAZIONI DI ECONOMIA DOMESTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '526')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6134',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C120',title = 'ESERCITAZIONI DI MODELLISMO, FORMATURE E PLASTICA, FOGGIATURA E RIFINITURA' WHERE idclassescuola = '526'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('526',null,'TF',null,'6134',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C120','ESERCITAZIONI DI MODELLISMO, FORMATURE E PLASTICA, FOGGIATURA E RIFINITURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '527')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6135',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C130',title = 'ESERCITAZIONI DI ODONTOTECNICA' WHERE idclassescuola = '527'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('527',null,'TF',null,'6135',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C130','ESERCITAZIONI DI ODONTOTECNICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '528')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6136',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C140',title = 'ESERCITAZIONI DI OFFICINA MECCANICA, AGRICOLA E DI MACCHINE AGRICOLE' WHERE idclassescuola = '528'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('528',null,'TF',null,'6136',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C140','ESERCITAZIONI DI OFFICINA MECCANICA, AGRICOLA E DI MACCHINE AGRICOLE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '529')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6137',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C150',title = 'ESERCITAZIONI DI PORTINERIA E PRATICA DI AGENZIA' WHERE idclassescuola = '529'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('529',null,'TF',null,'6137',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C150','ESERCITAZIONI DI PORTINERIA E PRATICA DI AGENZIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '530')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6138',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C160',title = 'ESERCITAZIONE DI TECNOLOGIA CERAMICA' WHERE idclassescuola = '530'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('530',null,'TF',null,'6138',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C160','ESERCITAZIONE DI TECNOLOGIA CERAMICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '531')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6139',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C170',title = 'ESERCITAZIONI DI TEORIA DELLA NAVE E DI COSTRUZIONI NAVALI' WHERE idclassescuola = '531'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('531',null,'TF',null,'6139',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C170','ESERCITAZIONI DI TEORIA DELLA NAVE E DI COSTRUZIONI NAVALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '532')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6140',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C180',title = 'ESERCITAZIONI NAUTICHE' WHERE idclassescuola = '532'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('532',null,'TF',null,'6140',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C180','ESERCITAZIONI NAUTICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '533')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6141',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C190',title = 'ESERCITAZIONI PRATICHE PER CENTRALINISTI TELEFONICI' WHERE idclassescuola = '533'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('533',null,'TF',null,'6141',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C190','ESERCITAZIONI PRATICHE PER CENTRALINISTI TELEFONICI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '534')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6142',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C200',title = 'ESERCITAZIONI PRATICHE DI OTTICA' WHERE idclassescuola = '534'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('534',null,'TF',null,'6142',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C200','ESERCITAZIONI PRATICHE DI OTTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '535')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6143',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C210',title = 'GABINETTO FISIOTERAPICO' WHERE idclassescuola = '535'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('535',null,'TF',null,'6143',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C210','GABINETTO FISIOTERAPICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '536')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6144',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C220',title = 'LABORATORIO DI TECNOL.TESSILI E DELL''ABBIGLIAMENTO E REPARTI DI LAVORAZ.TESSILI E ABBIGL' WHERE idclassescuola = '536'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('536',null,'TF',null,'6144',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C220','LABORATORIO DI TECNOL.TESSILI E DELL''ABBIGLIAMENTO E REPARTI DI LAVORAZ.TESSILI E ABBIGL')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '537')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6145',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C230',title = 'LABORATORIO DI AEROTECNICA, COSTRUZIONI E TECNOLOGIE AERONAUTICHE' WHERE idclassescuola = '537'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('537',null,'TF',null,'6145',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C230','LABORATORIO DI AEROTECNICA, COSTRUZIONI E TECNOLOGIE AERONAUTICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '538')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6146',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C240',title = 'LABORATORIO DI CHIMICA E CHIMICA INDUSTRIALE' WHERE idclassescuola = '538'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('538',null,'TF',null,'6146',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C240','LABORATORIO DI CHIMICA E CHIMICA INDUSTRIALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '539')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6147',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C250',title = 'LABORATORIO DI COSTRUZIONE, VERNICIATURA E RESTAURO DI STRUMENTI AD ARCO' WHERE idclassescuola = '539'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('539',null,'TF',null,'6147',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C250','LABORATORIO DI COSTRUZIONE, VERNICIATURA E RESTAURO DI STRUMENTI AD ARCO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '540')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6148',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C260',title = 'LABORATORIO DI ELETTRONICA' WHERE idclassescuola = '540'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('540',null,'TF',null,'6148',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C260','LABORATORIO DI ELETTRONICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '541')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6149',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C270',title = 'LABORATORIO DI ELETTROTECNICA' WHERE idclassescuola = '541'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('541',null,'TF',null,'6149',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C270','LABORATORIO DI ELETTROTECNICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '542')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6150',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C280',title = 'LABORATORIO DI FISICA ATOMICA E NUCLEARE E STRUMENTI' WHERE idclassescuola = '542'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('542',null,'TF',null,'6150',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C280','LABORATORIO DI FISICA ATOMICA E NUCLEARE E STRUMENTI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '543')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6151',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C290',title = 'LABORATORIO DI FISICA E FISICA APPLICATA' WHERE idclassescuola = '543'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('543',null,'TF',null,'6151',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C290','LABORATORIO DI FISICA E FISICA APPLICATA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '544')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6152',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C300',title = 'LABORATORIO DI INFORMATICA GESTIONALE' WHERE idclassescuola = '544'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('544',null,'TF',null,'6152',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C300','LABORATORIO DI INFORMATICA GESTIONALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '545')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6153',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C310',title = 'LABORATORIO DI INFORMATICA INDUSTRIALE' WHERE idclassescuola = '545'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('545',null,'TF',null,'6153',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C310','LABORATORIO DI INFORMATICA INDUSTRIALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '546')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6154',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C320',title = 'LABORATORIO MECCANICO-TECNOLOGICO' WHERE idclassescuola = '546'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('546',null,'TF',null,'6154',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C320','LABORATORIO MECCANICO-TECNOLOGICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '547')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6155',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C330',title = 'LABORATORIO DI OREFICERIA' WHERE idclassescuola = '547'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('547',null,'TF',null,'6155',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C330','LABORATORIO DI OREFICERIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '548')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6156',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C340',title = 'LABORATORIO DI PROGETTAZIONE TECNICA PER LA CERAMICA' WHERE idclassescuola = '548'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('548',null,'TF',null,'6156',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C340','LABORATORIO DI PROGETTAZIONE TECNICA PER LA CERAMICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '549')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6157',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C350',title = 'LABORATORIO DI TECNICA MICROBIOLOGICA' WHERE idclassescuola = '549'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('549',null,'TF',null,'6157',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C350','LABORATORIO DI TECNICA MICROBIOLOGICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '550')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6158',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C360',title = 'LABORATORIO DI TECNOLOGIA CARTARIA ED ESERCITAZIONI DI CARTIERA' WHERE idclassescuola = '550'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('550',null,'TF',null,'6158',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C360','LABORATORIO DI TECNOLOGIA CARTARIA ED ESERCITAZIONI DI CARTIERA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '551')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6159',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C370',title = 'LABORATORIO E REPARTI DI LAVORAZIONE DEL LEGNO' WHERE idclassescuola = '551'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('551',null,'TF',null,'6159',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C370','LABORATORIO E REPARTI DI LAVORAZIONE DEL LEGNO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '552')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6160',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C380',title = 'LABORATORIO E REPARTI DI LAVORAZIONE PER LE ARTI GRAFICHE' WHERE idclassescuola = '552'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('552',null,'TF',null,'6160',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C380','LABORATORIO E REPARTI DI LAVORAZIONE PER LE ARTI GRAFICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '553')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6161',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C390',title = 'LABORATORIO E REPARTI DI LAVORAZIONE PER L''INDUSTRIA MINERARIA' WHERE idclassescuola = '553'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('553',null,'TF',null,'6161',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C390','LABORATORIO E REPARTI DI LAVORAZIONE PER L''INDUSTRIA MINERARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '554')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6162',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C400',title = 'LABORATORIO PER LE INDUSTRIE CERAMICHE' WHERE idclassescuola = '554'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('554',null,'TF',null,'6162',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C400','LABORATORIO PER LE INDUSTRIE CERAMICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '555')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6163',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C410',title = 'LABORATORIO TECNOLOGICO PER IL MARMO-REPARTI ARCHITETTURA, MACCHINE' WHERE idclassescuola = '555'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('555',null,'TF',null,'6163',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C410','LABORATORIO TECNOLOGICO PER IL MARMO-REPARTI ARCHITETTURA, MACCHINE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '556')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6164',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C420',title = 'LABORATORIO TECNOLOGICO PER IL MARMO-REPARTI SCULTURA,SMODELLATURA,DECORAZIONE E ORNATO' WHERE idclassescuola = '556'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('556',null,'TF',null,'6164',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C420','LABORATORIO TECNOLOGICO PER IL MARMO-REPARTI SCULTURA,SMODELLATURA,DECORAZIONE E ORNATO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '557')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6165',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C430',title = 'LABORATORIO TECNOLOGICO PER L''EDILIZIA ED ESERCITAZIONI DI TOPOGRAFIA' WHERE idclassescuola = '557'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('557',null,'TF',null,'6165',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C430','LABORATORIO TECNOLOGICO PER L''EDILIZIA ED ESERCITAZIONI DI TOPOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '558')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6166',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C440',title = 'MASSOCHINESITERAPIA' WHERE idclassescuola = '558'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('558',null,'TF',null,'6166',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C440','MASSOCHINESITERAPIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '559')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6167',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C450',title = 'METODOLOGIE OPERATIVE NEI SERVIZI SOCIALI' WHERE idclassescuola = '559'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('559',null,'TF',null,'6167',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C450','METODOLOGIE OPERATIVE NEI SERVIZI SOCIALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '560')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6168',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C460',title = 'REPARTI DI LAVORAZIONE PER IL MONTAGGIO CINEMATOGRAFICO E TELEVISIVO' WHERE idclassescuola = '560'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('560',null,'TF',null,'6168',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C460','REPARTI DI LAVORAZIONE PER IL MONTAGGIO CINEMATOGRAFICO E TELEVISIVO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '561')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6169',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C470',title = 'REPARTI DI LAVORAZIONE PER LA REGISTRAZIONE DEL SUONO' WHERE idclassescuola = '561'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('561',null,'TF',null,'6169',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C470','REPARTI DI LAVORAZIONE PER LA REGISTRAZIONE DEL SUONO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '562')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6170',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C480',title = 'REPARTI DI LAVORAZIONE PER LA RIPRESA CINEMATOGRAFICA E TELEVISIVA' WHERE idclassescuola = '562'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('562',null,'TF',null,'6170',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C480','REPARTI DI LAVORAZIONE PER LA RIPRESA CINEMATOGRAFICA E TELEVISIVA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '563')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6171',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C490',title = 'REPARTI DI LAVORAZIONE PER LE ARTI FOTOGRAFICHE' WHERE idclassescuola = '563'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('563',null,'TF',null,'6171',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C490','REPARTI DI LAVORAZIONE PER LE ARTI FOTOGRAFICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '564')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6172',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C500',title = 'TECNICA DEI SERVIZI ED ESERCITAZIONI PRATICHE DI CUCINA' WHERE idclassescuola = '564'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('564',null,'TF',null,'6172',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C500','TECNICA DEI SERVIZI ED ESERCITAZIONI PRATICHE DI CUCINA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '565')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6173',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C510',title = 'TECNICA DEI SERVIZI ED ESERCITAZIONI PRATICHE DI SALA BAR' WHERE idclassescuola = '565'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('565',null,'TF',null,'6173',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C510','TECNICA DEI SERVIZI ED ESERCITAZIONI PRATICHE DI SALA BAR')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '566')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6174',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C520',title = 'TECNICA DEI SERVIZI E PRATICA OPERATIVA' WHERE idclassescuola = '566'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('566',null,'TF',null,'6174',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C520','TECNICA DEI SERVIZI E PRATICA OPERATIVA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '567')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6175',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C555',title = 'ESERCITAZIONI DI PRATICA PROFESSIONALE' WHERE idclassescuola = '567'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('567',null,'TF',null,'6175',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C555','ESERCITAZIONI DI PRATICA PROFESSIONALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '568')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6176',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D601',title = 'ARTE DELLA LAVORAZIONE DEI METALLI' WHERE idclassescuola = '568'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('568',null,'TF',null,'6176',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D601','ARTE DELLA LAVORAZIONE DEI METALLI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '569')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6177',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D602',title = 'ARTE DELL''OREFICERIA, DELLA LAVORAZIONE DELLE PIETRE DURE E DELLE GEMME' WHERE idclassescuola = '569'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('569',null,'TF',null,'6177',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D602','ARTE DELL''OREFICERIA, DELLA LAVORAZIONE DELLE PIETRE DURE E DELLE GEMME')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '570')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6178',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D603',title = 'ARTE DEL DISEGNO D''ANIMAZIONE' WHERE idclassescuola = '570'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('570',null,'TF',null,'6178',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D603','ARTE DEL DISEGNO D''ANIMAZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '571')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6179',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D604',title = 'ARTE DELLA RIPRESA E MONTAGGIO PER IL DISEGNO ANIMATO' WHERE idclassescuola = '571'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('571',null,'TF',null,'6179',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D604','ARTE DELLA RIPRESA E MONTAGGIO PER IL DISEGNO ANIMATO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '572')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6180',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D605',title = 'ARTE DELLA TESSITURA E DELLA DECORAZIONE DEI TESSUTI' WHERE idclassescuola = '572'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('572',null,'TF',null,'6180',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D605','ARTE DELLA TESSITURA E DELLA DECORAZIONE DEI TESSUTI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '573')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6181',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D606',title = 'ARTE DELLA LAVORAZIONE DEL VETRO E DELLA VETRATA' WHERE idclassescuola = '573'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('573',null,'TF',null,'6181',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D606','ARTE DELLA LAVORAZIONE DEL VETRO E DELLA VETRATA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '574')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6182',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D607',title = 'ARTE DEL RESTAURO DELLA CERAMICA E DEL VETRO' WHERE idclassescuola = '574'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('574',null,'TF',null,'6182',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D607','ARTE DEL RESTAURO DELLA CERAMICA E DEL VETRO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '575')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6183',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D608',title = 'ARTE DELLA DECORAZIONE E COTTURA DEI PRODOTTI CERAMICI' WHERE idclassescuola = '575'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('575',null,'TF',null,'6183',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D608','ARTE DELLA DECORAZIONE E COTTURA DEI PRODOTTI CERAMICI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '576')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6184',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D609',title = 'ARTE DELLA FORMATURA E FOGGIATURA' WHERE idclassescuola = '576'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('576',null,'TF',null,'6184',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D609','ARTE DELLA FORMATURA E FOGGIATURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '577')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6185',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D610',title = 'ARTE DELLA FOTOGRAFIA E DELLA CINEMATOGRAFIA' WHERE idclassescuola = '577'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('577',null,'TF',null,'6185',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D610','ARTE DELLA FOTOGRAFIA E DELLA CINEMATOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '578')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6186',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D611',title = 'ARTE DELAA XILOGRAFIA, CALCOGRAFIA E LITOGRAFIA' WHERE idclassescuola = '578'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('578',null,'TF',null,'6186',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D611','ARTE DELAA XILOGRAFIA, CALCOGRAFIA E LITOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '579')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6187',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D612',title = 'ARTE DELLA SERIGRAFIA E DELLA FOTOINCISIONE' WHERE idclassescuola = '579'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('579',null,'TF',null,'6187',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D612','ARTE DELLA SERIGRAFIA E DELLA FOTOINCISIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '580')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6188',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D613',title = 'ARTE DELLA TIPOGRAFIA E DELLA GRAFICA PUBBLICITARIA' WHERE idclassescuola = '580'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('580',null,'TF',null,'6188',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D613','ARTE DELLA TIPOGRAFIA E DELLA GRAFICA PUBBLICITARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '581')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6189',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D614',title = 'ARTE DEL TAGLIO E CONFEZIONE' WHERE idclassescuola = '581'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('581',null,'TF',null,'6189',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D614','ARTE DEL TAGLIO E CONFEZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '582')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6190',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D615',title = 'ARTE DELLA DECORAZIONE PITTORICA E SCENOGRAFICA' WHERE idclassescuola = '582'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('582',null,'TF',null,'6190',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D615','ARTE DELLA DECORAZIONE PITTORICA E SCENOGRAFICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '583')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6191',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D616',title = 'ARTE DELLA MODELLISTICA, DELL''ARREDAMENTO E DELLA SCENOTECNICA' WHERE idclassescuola = '583'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('583',null,'TF',null,'6191',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D616','ARTE DELLA MODELLISTICA, DELL''ARREDAMENTO E DELLA SCENOTECNICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '584')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6192',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D617',title = 'ARTE DELLA LEGATORIA E DEL RESTAURO DEL LIBRO' WHERE idclassescuola = '584'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('584',null,'TF',null,'6192',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D617','ARTE DELLA LEGATORIA E DEL RESTAURO DEL LIBRO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '585')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6193',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D618',title = 'ARTE DELL''EBANISTERIA, DELL''INTAGLIO E DELL''INTARSIO' WHERE idclassescuola = '585'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('585',null,'TF',null,'6193',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D618','ARTE DELL''EBANISTERIA, DELL''INTAGLIO E DELL''INTARSIO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '586')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6194',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D619',title = 'ARTE DELLE LACCHE, DELLA DORATURA E DEL RESTAURO' WHERE idclassescuola = '586'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('586',null,'TF',null,'6194',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D619','ARTE DELLE LACCHE, DELLA DORATURA E DEL RESTAURO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '587')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6195',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D620',title = 'ARTE DEL MOSAICO E DEL COMMESSO' WHERE idclassescuola = '587'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('587',null,'TF',null,'6195',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D620','ARTE DEL MOSAICO E DEL COMMESSO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '588')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6196',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D621',title = 'ARTE DELLA LAVORAZIONE DEL MARMO E DELLA PIETRA' WHERE idclassescuola = '588'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('588',null,'TF',null,'6196',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D621','ARTE DELLA LAVORAZIONE DEL MARMO E DELLA PIETRA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '589')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6197',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D622',title = 'LABORATORIO TECNOLOGICO DELLE ARTI DELLA CERAMICA DEL VETRO E DEL CRISTALLO' WHERE idclassescuola = '589'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('589',null,'TF',null,'6197',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D622','LABORATORIO TECNOLOGICO DELLE ARTI DELLA CERAMICA DEL VETRO E DEL CRISTALLO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '590')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6198',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F010',title = 'ACCOMPAGNATORI AL PIANOFORTE' WHERE idclassescuola = '590'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('590',null,'TF',null,'6198',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F010','ACCOMPAGNATORI AL PIANOFORTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '591')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6199',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F020',title = 'ARMONIA COMPLEMENTARE' WHERE idclassescuola = '591'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('591',null,'TF',null,'6199',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F020','ARMONIA COMPLEMENTARE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '592')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6200',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F030',title = 'ARMONIA CONTRAPPUNTO FUGA E COMPOSIZIONE' WHERE idclassescuola = '592'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('592',null,'TF',null,'6200',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F030','ARMONIA CONTRAPPUNTO FUGA E COMPOSIZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '593')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6201',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F040',title = 'ARMONIA E CONTRAPPUNTO' WHERE idclassescuola = '593'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('593',null,'TF',null,'6201',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F040','ARMONIA E CONTRAPPUNTO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '594')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6202',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F050',title = 'ARPA' WHERE idclassescuola = '594'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('594',null,'TF',null,'6202',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F050','ARPA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '595')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6203',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F060',title = 'ARTE SCENICA' WHERE idclassescuola = '595'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('595',null,'TF',null,'6203',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F060','ARTE SCENICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '596')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6204',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F070',title = 'BIBLIOTECARIO' WHERE idclassescuola = '596'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('596',null,'TF',null,'6204',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F070','BIBLIOTECARIO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '597')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6205',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F080',title = 'CANTO' WHERE idclassescuola = '597'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('597',null,'TF',null,'6205',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F080','CANTO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '598')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6206',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F090',title = 'CHITARRA' WHERE idclassescuola = '598'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('598',null,'TF',null,'6206',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F090','CHITARRA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '599')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6207',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F100',title = 'CLARINETTO' WHERE idclassescuola = '599'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('599',null,'TF',null,'6207',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F100','CLARINETTO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '600')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6208',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F110',title = 'CLAVICEMBALO' WHERE idclassescuola = '600'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('600',null,'TF',null,'6208',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F110','CLAVICEMBALO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '601')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6209',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F120',title = 'COMPOSIZIONE POLIFONICA VOCALE' WHERE idclassescuola = '601'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('601',null,'TF',null,'6209',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F120','COMPOSIZIONE POLIFONICA VOCALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '602')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6210',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F130',title = 'CONTRABBASSO' WHERE idclassescuola = '602'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('602',null,'TF',null,'6210',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F130','CONTRABBASSO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '603')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6211',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F140',title = 'CORNO' WHERE idclassescuola = '603'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('603',null,'TF',null,'6211',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F140','CORNO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '604')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6212',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F150',title = 'DIREZIONE D''ORCHESTRA' WHERE idclassescuola = '604'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('604',null,'TF',null,'6212',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F150','DIREZIONE D''ORCHESTRA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '605')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6213',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F160',title = 'ESERCITAZIONI CORALI' WHERE idclassescuola = '605'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('605',null,'TF',null,'6213',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F160','ESERCITAZIONI CORALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '606')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6214',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F170',title = 'ESERCITAZIONI ORCHESTRALI' WHERE idclassescuola = '606'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('606',null,'TF',null,'6214',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F170','ESERCITAZIONI ORCHESTRALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '607')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6215',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F180',title = 'FAGOTTO' WHERE idclassescuola = '607'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('607',null,'TF',null,'6215',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F180','FAGOTTO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '608')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6216',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F190',title = 'FLAUTO' WHERE idclassescuola = '608'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('608',null,'TF',null,'6216',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F190','FLAUTO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '609')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6217',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F200',title = 'LETTERATURA ITALIANA' WHERE idclassescuola = '609'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('609',null,'TF',null,'6217',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F200','LETTERATURA ITALIANA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '610')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6218',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F210',title = 'LETTERATURA POETICA E DRAMMATICA' WHERE idclassescuola = '610'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('610',null,'TF',null,'6218',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F210','LETTERATURA POETICA E DRAMMATICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '611')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6219',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F220',title = 'LETTURA DELLA PARTITURA' WHERE idclassescuola = '611'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('611',null,'TF',null,'6219',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F220','LETTURA DELLA PARTITURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '612')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6220',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F230',title = 'MUSICA CORALE E DIREZIONE DI CORO' WHERE idclassescuola = '612'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('612',null,'TF',null,'6220',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F230','MUSICA CORALE E DIREZIONE DI CORO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '613')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6221',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F240',title = 'MUSICA DA CAMERA' WHERE idclassescuola = '613'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('613',null,'TF',null,'6221',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F240','MUSICA DA CAMERA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '614')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6222',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F250',title = 'MUSICA D''INSIEME STRUMENTI AD ARCO' WHERE idclassescuola = '614'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('614',null,'TF',null,'6222',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F250','MUSICA D''INSIEME STRUMENTI AD ARCO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '615')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6223',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F260',title = 'MUSICA D''INSIEME STRUMENTI A FIATO' WHERE idclassescuola = '615'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('615',null,'TF',null,'6223',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F260','MUSICA D''INSIEME STRUMENTI A FIATO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '616')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6224',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F280',title = 'OBOE' WHERE idclassescuola = '616'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('616',null,'TF',null,'6224',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F280','OBOE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '617')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6225',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F290',title = 'ORGANO E COMPOSIZIONE ORGANISTICA' WHERE idclassescuola = '617'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('617',null,'TF',null,'6225',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F290','ORGANO E COMPOSIZIONE ORGANISTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '618')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6226',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F300',title = 'ORGANO COMPLEMENTARE E CANTO GREGORIANO' WHERE idclassescuola = '618'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('618',null,'TF',null,'6226',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F300','ORGANO COMPLEMENTARE E CANTO GREGORIANO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '619')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6227',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F310',title = 'PIANOFORTE' WHERE idclassescuola = '619'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('619',null,'TF',null,'6227',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F310','PIANOFORTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '620')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6228',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F320',title = 'PIANOFORTE COMPLEMENTARE' WHERE idclassescuola = '620'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('620',null,'TF',null,'6228',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F320','PIANOFORTE COMPLEMENTARE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '621')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6229',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F330',title = 'STORIA DELLA MUSICA E STORIA ED ESTETICA MUSICALE' WHERE idclassescuola = '621'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('621',null,'TF',null,'6229',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F330','STORIA DELLA MUSICA E STORIA ED ESTETICA MUSICALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '622')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6230',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F340',title = 'STRUMENTAZIONE PER BANDA' WHERE idclassescuola = '622'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('622',null,'TF',null,'6230',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F340','STRUMENTAZIONE PER BANDA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '623')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6231',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F350',title = 'TEORIA SOLFEGGIO E DETTATO MUSICALE' WHERE idclassescuola = '623'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('623',null,'TF',null,'6231',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F350','TEORIA SOLFEGGIO E DETTATO MUSICALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '624')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6232',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F360',title = 'TROMBA E TROMBONE' WHERE idclassescuola = '624'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('624',null,'TF',null,'6232',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F360','TROMBA E TROMBONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '625')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6233',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F370',title = 'VIOLA' WHERE idclassescuola = '625'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('625',null,'TF',null,'6233',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F370','VIOLA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '626')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6234',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F380',title = 'VIOLA COMPLEMENTARE' WHERE idclassescuola = '626'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('626',null,'TF',null,'6234',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F380','VIOLA COMPLEMENTARE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '627')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6235',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F390',title = 'VIOLINO' WHERE idclassescuola = '627'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('627',null,'TF',null,'6235',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F390','VIOLINO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '628')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6236',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F400',title = 'VIOLINO COMPLEMENTARE' WHERE idclassescuola = '628'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('628',null,'TF',null,'6236',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F400','VIOLINO COMPLEMENTARE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '629')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6237',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F410',title = 'VIOLONCELLO' WHERE idclassescuola = '629'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('629',null,'TF',null,'6237',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F410','VIOLONCELLO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '630')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6238',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F420',title = 'MUSICA SACRA' WHERE idclassescuola = '630'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('630',null,'TF',null,'6238',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F420','MUSICA SACRA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '631')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6239',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F430',title = 'FUGA E COMPOSIZIONE' WHERE idclassescuola = '631'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('631',null,'TF',null,'6239',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F430','FUGA E COMPOSIZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '632')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6240',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F440',title = 'SASSOFONO' WHERE idclassescuola = '632'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('632',null,'TF',null,'6240',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F440','SASSOFONO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '633')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6241',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F450',title = 'STRUMENTI A PERCUSSIONE' WHERE idclassescuola = '633'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('633',null,'TF',null,'6241',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F450','STRUMENTI A PERCUSSIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '634')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6242',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F460',title = 'BASSO TUBA' WHERE idclassescuola = '634'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('634',null,'TF',null,'6242',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F460','BASSO TUBA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '635')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6243',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F470',title = 'PEDAGOGIA MUSICALE PER DIDATTICA DELLA MUSICA' WHERE idclassescuola = '635'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('635',null,'TF',null,'6243',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F470','PEDAGOGIA MUSICALE PER DIDATTICA DELLA MUSICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '636')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6244',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F480',title = 'ELEMENTI DI COMPOSIZIONE PER DIDATTICA DELLA MUSICA' WHERE idclassescuola = '636'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('636',null,'TF',null,'6244',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F480','ELEMENTI DI COMPOSIZIONE PER DIDATTICA DELLA MUSICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '637')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6245',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F490',title = 'DIREZIONE DI CORO E REPERTORIO CORALE PER DIDATTICA DELLA MUSICA' WHERE idclassescuola = '637'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('637',null,'TF',null,'6245',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F490','DIREZIONE DI CORO E REPERTORIO CORALE PER DIDATTICA DELLA MUSICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '638')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6246',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F500',title = 'STORIA DELLA MUSICA PER DIDATTICA DELLA MUSICA' WHERE idclassescuola = '638'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('638',null,'TF',null,'6246',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F500','STORIA DELLA MUSICA PER DIDATTICA DELLA MUSICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '639')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6247',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F510',title = 'PRATICA DELLA LETTURA VOCALE E PIANISTICA PER DIDATTICA DELLA MUSICA' WHERE idclassescuola = '639'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('639',null,'TF',null,'6247',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F510','PRATICA DELLA LETTURA VOCALE E PIANISTICA PER DIDATTICA DELLA MUSICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '640')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6248',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F520',title = 'FISARMONICA' WHERE idclassescuola = '640'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('640',null,'TF',null,'6248',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F520','FISARMONICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '641')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6249',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F530',title = 'FLAUTO DOLCE' WHERE idclassescuola = '641'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('641',null,'TF',null,'6249',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F530','FLAUTO DOLCE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '642')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6250',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F540',title = 'JAZZ' WHERE idclassescuola = '642'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('642',null,'TF',null,'6250',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F540','JAZZ')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '643')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6251',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F550',title = 'LIUTO' WHERE idclassescuola = '643'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('643',null,'TF',null,'6251',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F550','LIUTO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '644')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6252',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F560',title = 'MANDOLINO' WHERE idclassescuola = '644'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('644',null,'TF',null,'6252',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F560','MANDOLINO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '645')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6253',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F570',title = 'MUSICA ELETTRONICA' WHERE idclassescuola = '645'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('645',null,'TF',null,'6253',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F570','MUSICA ELETTRONICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '646')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6254',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F580',title = 'MUSICA VOCALE DA CAMERA' WHERE idclassescuola = '646'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('646',null,'TF',null,'6254',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F580','MUSICA VOCALE DA CAMERA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '647')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6255',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F590',title = 'PREPOLIFONIA' WHERE idclassescuola = '647'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('647',null,'TF',null,'6255',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F590','PREPOLIFONIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '648')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6256',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'F600',title = 'VIOLA DA GAMBA' WHERE idclassescuola = '648'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('648',null,'TF',null,'6256',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'F600','VIOLA DA GAMBA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '649')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6257',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G010',title = 'PITTURA' WHERE idclassescuola = '649'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('649',null,'TF',null,'6257',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G010','PITTURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '650')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6258',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G020',title = 'SCULTURA' WHERE idclassescuola = '650'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('650',null,'TF',null,'6258',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G020','SCULTURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '651')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6259',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G030',title = 'SCENOGRAFIA' WHERE idclassescuola = '651'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('651',null,'TF',null,'6259',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G030','SCENOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '652')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6260',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G040',title = 'DECORAZIONE' WHERE idclassescuola = '652'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('652',null,'TF',null,'6260',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G040','DECORAZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '653')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6261',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G060',title = 'STILE, STORIA DELL''ARTE E DEL COSTUME' WHERE idclassescuola = '653'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('653',null,'TF',null,'6261',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G060','STILE, STORIA DELL''ARTE E DEL COSTUME')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '654')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6262',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G070',title = 'ANATOMIA ARTISTICA' WHERE idclassescuola = '654'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('654',null,'TF',null,'6262',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G070','ANATOMIA ARTISTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '655')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6263',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G080',title = 'TECNICHE DELL''INCISIONE' WHERE idclassescuola = '655'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('655',null,'TF',null,'6263',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G080','TECNICHE DELL''INCISIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '656')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6264',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G090',title = 'PLASTICA ORNAMENTALE' WHERE idclassescuola = '656'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('656',null,'TF',null,'6264',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G090','PLASTICA ORNAMENTALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '657')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6265',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G100',title = 'TECNICHE GRAFICHE SPECIALI' WHERE idclassescuola = '657'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('657',null,'TF',null,'6265',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G100','TECNICHE GRAFICHE SPECIALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '658')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6266',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G110',title = 'TECNICHE DI FONDERIA' WHERE idclassescuola = '658'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('658',null,'TF',null,'6266',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G110','TECNICHE DI FONDERIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '659')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6267',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G120',title = 'TECNICHE DELLA SCULTURA' WHERE idclassescuola = '659'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('659',null,'TF',null,'6267',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G120','TECNICHE DELLA SCULTURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '660')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6268',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G130',title = 'RESTAURO IND1' WHERE idclassescuola = '660'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('660',null,'TF',null,'6268',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G130','RESTAURO IND1')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '661')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6269',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G140',title = 'RESTAURO IND2' WHERE idclassescuola = '661'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('661',null,'TF',null,'6269',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G140','RESTAURO IND2')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '662')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6270',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G150',title = 'RESTAURO IND3' WHERE idclassescuola = '662'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('662',null,'TF',null,'6270',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G150','RESTAURO IND3')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '663')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6271',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G160',title = 'ELEMENTI DI ARCHITETTURA E URBANISTICA' WHERE idclassescuola = '663'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('663',null,'TF',null,'6271',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G160','ELEMENTI DI ARCHITETTURA E URBANISTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '664')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6272',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G170',title = 'METODOLOGIA DELLA PROGETTAZIONE' WHERE idclassescuola = '664'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('664',null,'TF',null,'6272',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G170','METODOLOGIA DELLA PROGETTAZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '665')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6273',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G180',title = 'MODELLISTICA' WHERE idclassescuola = '665'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('665',null,'TF',null,'6273',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G180','MODELLISTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '666')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6274',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G190',title = 'PEDAGOGIA E DIDATTICA DELL '' ARTE' WHERE idclassescuola = '666'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('666',null,'TF',null,'6274',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G190','PEDAGOGIA E DIDATTICA DELL '' ARTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '667')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6275',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G200',title = 'FOTOGRAFIA' WHERE idclassescuola = '667'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('667',null,'TF',null,'6275',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G200','FOTOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '668')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6276',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G210',title = 'COSTUME PER LO SPETTACOLO' WHERE idclassescuola = '668'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('668',null,'TF',null,'6276',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G210','COSTUME PER LO SPETTACOLO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '669')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6277',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G220',title = 'TEORIA E METODO DEI MASS MEDIA' WHERE idclassescuola = '669'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('669',null,'TF',null,'6277',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G220','TEORIA E METODO DEI MASS MEDIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '670')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6278',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G230',title = 'TEORIA DELLA PERCEZIONE E PSICOLOGIA DELLE FORME' WHERE idclassescuola = '670'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('670',null,'TF',null,'6278',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G230','TEORIA DELLA PERCEZIONE E PSICOLOGIA DELLE FORME')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '671')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6279',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G240',title = 'DESIGN' WHERE idclassescuola = '671'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('671',null,'TF',null,'6279',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G240','DESIGN')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '672')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6280',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G250',title = 'SCENOTECNICA' WHERE idclassescuola = '672'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('672',null,'TF',null,'6280',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G250','SCENOTECNICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '673')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6281',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G260',title = 'STORIA DELLO SPETTACOLO' WHERE idclassescuola = '673'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('673',null,'TF',null,'6281',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G260','STORIA DELLO SPETTACOLO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '674')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6282',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G270',title = 'TECNICHE PITTORICHE' WHERE idclassescuola = '674'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('674',null,'TF',null,'6282',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G270','TECNICHE PITTORICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '675')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6283',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G280',title = 'ESTETICA' WHERE idclassescuola = '675'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('675',null,'TF',null,'6283',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G280','ESTETICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '676')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6284',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G290',title = 'STORIA E METODOLOGIA DELLA CRITICA D'' ARTE' WHERE idclassescuola = '676'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('676',null,'TF',null,'6284',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G290','STORIA E METODOLOGIA DELLA CRITICA D'' ARTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '677')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6285',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G300',title = 'BENI CULTURALI E AMBIENTALI' WHERE idclassescuola = '677'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('677',null,'TF',null,'6285',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G300','BENI CULTURALI E AMBIENTALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '678')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6286',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G310',title = 'ANTROPOLOGIA CULTURALE' WHERE idclassescuola = '678'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('678',null,'TF',null,'6286',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G310','ANTROPOLOGIA CULTURALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '679')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6287',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G320',title = 'REGIA' WHERE idclassescuola = '679'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('679',null,'TF',null,'6287',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G320','REGIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '680')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6288',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G330',title = 'TECNICHE ED USO DEL MARMO, DELLE PIETRE E DELLE PIETRE DURE' WHERE idclassescuola = '680'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('680',null,'TF',null,'6288',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G330','TECNICHE ED USO DEL MARMO, DELLE PIETRE E DELLE PIETRE DURE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '681')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6289',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'G340',title = 'FENOMENOLOGIA DELLE ARTI CONTEMPORANEE' WHERE idclassescuola = '681'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('681',null,'TF',null,'6289',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'G340','FENOMENOLOGIA DELLE ARTI CONTEMPORANEE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '682')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6290',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'H010',title = 'ASSISTENTE DI PITTURA' WHERE idclassescuola = '682'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('682',null,'TF',null,'6290',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'H010','ASSISTENTE DI PITTURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '683')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6291',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'H020',title = 'ASSISTENTE DI SCULTURA' WHERE idclassescuola = '683'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('683',null,'TF',null,'6291',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'H020','ASSISTENTE DI SCULTURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '684')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6292',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'H030',title = 'ASSISTENTE DI SCENOGRAFIA' WHERE idclassescuola = '684'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('684',null,'TF',null,'6292',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'H030','ASSISTENTE DI SCENOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '685')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6293',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'H040',title = 'ASSISTENTE DI DECORAZIONE' WHERE idclassescuola = '685'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('685',null,'TF',null,'6293',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'H040','ASSISTENTE DI DECORAZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '686')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6294',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'H060',title = 'ASSISTENTE DI STILE, STORIA DELL''ARTE E DEL COSTUME' WHERE idclassescuola = '686'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('686',null,'TF',null,'6294',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'H060','ASSISTENTE DI STILE, STORIA DELL''ARTE E DEL COSTUME')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '687')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6295',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'H070',title = 'ASSISTENTE DI ANATOMIA ARTISTICA' WHERE idclassescuola = '687'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('687',null,'TF',null,'6295',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'H070','ASSISTENTE DI ANATOMIA ARTISTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '688')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6296',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'H080',title = 'ASSISTENTE DI TECNICHE DELL''INCISIONE' WHERE idclassescuola = '688'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('688',null,'TF',null,'6296',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'H080','ASSISTENTE DI TECNICHE DELL''INCISIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '689')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6297',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'H090',title = 'ASSISTENTE DI PLASTICA ORNAMENTALE' WHERE idclassescuola = '689'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('689',null,'TF',null,'6297',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'H090','ASSISTENTE DI PLASTICA ORNAMENTALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '690')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6298',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L010',title = 'TEORIA DELLA PERCEZIONE E PSICOLOGIA DELLA FORMA' WHERE idclassescuola = '690'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('690',null,'TF',null,'6298',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L010','TEORIA DELLA PERCEZIONE E PSICOLOGIA DELLA FORMA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '691')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6299',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L020',title = 'TEORIA E METODO DEI MASS MEDIA' WHERE idclassescuola = '691'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('691',null,'TF',null,'6299',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L020','TEORIA E METODO DEI MASS MEDIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '692')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6300',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L030',title = 'PEDAGOGIA E DIDATTICHE SPECIALI DELL''INSEGNAMENTO' WHERE idclassescuola = '692'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('692',null,'TF',null,'6300',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L030','PEDAGOGIA E DIDATTICHE SPECIALI DELL''INSEGNAMENTO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '693')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6301',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L040',title = 'TECNICA DELLA FOTOGRAFIA' WHERE idclassescuola = '693'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('693',null,'TF',null,'6301',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L040','TECNICA DELLA FOTOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '694')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6302',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L050',title = 'TECNICHE GRAFICHE SPECIALI' WHERE idclassescuola = '694'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('694',null,'TF',null,'6302',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L050','TECNICHE GRAFICHE SPECIALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '695')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6303',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L060',title = 'MODELLISTICA' WHERE idclassescuola = '695'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('695',null,'TF',null,'6303',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L060','MODELLISTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '696')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6304',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'L070',title = 'ASPETTI PROPEDEUTICI E METODOLOGICI DELLA PROGETTAZIONE' WHERE idclassescuola = '696'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('696',null,'TF',null,'6304',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'L070','ASPETTI PROPEDEUTICI E METODOLOGICI DELLA PROGETTAZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '697')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6305',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M011',title = 'TECNICHE PITTORICHE' WHERE idclassescuola = '697'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('697',null,'TF',null,'6305',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M011','TECNICHE PITTORICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '698')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6306',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M012',title = 'RESTAURO (ANALISI STORICA,CRITICA,TECNICA, METODOLOGIA  D''INTERVENTO)' WHERE idclassescuola = '698'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('698',null,'TF',null,'6306',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M012','RESTAURO (ANALISI STORICA,CRITICA,TECNICA, METODOLOGIA  D''INTERVENTO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '699')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6307',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M013',title = 'DESIGN (TECNICA E METODO PROGETTUALE)' WHERE idclassescuola = '699'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('699',null,'TF',null,'6307',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M013','DESIGN (TECNICA E METODO PROGETTUALE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '700')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6308',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M014',title = 'ASPETTI STORICI E SOCIO-ECONOMICI DELLA PROGETTAZIONE' WHERE idclassescuola = '700'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('700',null,'TF',null,'6308',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M014','ASPETTI STORICI E SOCIO-ECONOMICI DELLA PROGETTAZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '701')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6309',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M021',title = 'TECNOLOGIA ED USO DEL MARMO, DELLE PIETRE E DELLE PIETRE DURE' WHERE idclassescuola = '701'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('701',null,'TF',null,'6309',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M021','TECNOLOGIA ED USO DEL MARMO, DELLE PIETRE E DELLE PIETRE DURE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '702')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6310',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M022',title = 'TECNOLOGIA ED USO DELLE ARENARIE E DEI MATERIALI SINTETICI' WHERE idclassescuola = '702'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('702',null,'TF',null,'6310',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M022','TECNOLOGIA ED USO DELLE ARENARIE E DEI MATERIALI SINTETICI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '703')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6311',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M023',title = 'TECNICHE DI FONDERIA (TEORIA E PRATICA DI FORMATURA E  DI MICRO E MACRO FUSIONE)' WHERE idclassescuola = '703'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('703',null,'TF',null,'6311',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M023','TECNICHE DI FONDERIA (TEORIA E PRATICA DI FORMATURA E  DI MICRO E MACRO FUSIONE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '704')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6312',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M031',title = 'STORIA DELLO SPETTACOLO, DEL COSTUME TEATRALE EDELLE   ARTI SCENICHE' WHERE idclassescuola = '704'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('704',null,'TF',null,'6312',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M031','STORIA DELLO SPETTACOLO, DEL COSTUME TEATRALE EDELLE   ARTI SCENICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '705')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6313',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M032',title = 'SCENOTECNICA' WHERE idclassescuola = '705'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('705',null,'TF',null,'6313',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M032','SCENOTECNICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '706')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6314',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M033',title = 'ELEMENTI DI ARCHITETTURA E URBANISTICA' WHERE idclassescuola = '706'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('706',null,'TF',null,'6314',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M033','ELEMENTI DI ARCHITETTURA E URBANISTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '707')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6315',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M034',title = 'TECNICHE DEL COSTUME TEATRALE' WHERE idclassescuola = '707'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('707',null,'TF',null,'6315',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M034','TECNICHE DEL COSTUME TEATRALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '708')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6316',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M040',title = 'BENI CULTURALI' WHERE idclassescuola = '708'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('708',null,'TF',null,'6316',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M040','BENI CULTURALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '709')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6317',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M050',title = 'ELEMENTI DI LETTERATURA MODERNA E CONTEMPORANEA' WHERE idclassescuola = '709'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('709',null,'TF',null,'6317',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M050','ELEMENTI DI LETTERATURA MODERNA E CONTEMPORANEA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '710')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6318',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M060',title = 'ILLUMINOTECNICA' WHERE idclassescuola = '710'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('710',null,'TF',null,'6318',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M060','ILLUMINOTECNICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '711')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6319',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M070',title = 'NUOVI MATERIALI E STRUTTURE LINGUAGGIO VISIVO' WHERE idclassescuola = '711'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('711',null,'TF',null,'6319',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M070','NUOVI MATERIALI E STRUTTURE LINGUAGGIO VISIVO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '712')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6320',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M080',title = 'STORIA DEL COSTUME' WHERE idclassescuola = '712'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('712',null,'TF',null,'6320',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M080','STORIA DEL COSTUME')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '713')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6321',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M090',title = 'STORIA DELL''ARTE CONTEMPORANEA E PROBLEMI DELLE AVANGUARDIE' WHERE idclassescuola = '713'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('713',null,'TF',null,'6321',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M090','STORIA DELL''ARTE CONTEMPORANEA E PROBLEMI DELLE AVANGUARDIE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '714')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6322',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M100',title = 'ESTETICA' WHERE idclassescuola = '714'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('714',null,'TF',null,'6322',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M100','ESTETICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '715')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6323',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M110',title = 'ANTROPOLOGIA CULTURALE E SOCIOLOGIA DELL''ARTE' WHERE idclassescuola = '715'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('715',null,'TF',null,'6323',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M110','ANTROPOLOGIA CULTURALE E SOCIOLOGIA DELL''ARTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '716')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6324',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M120',title = 'RICERCA E TECNICA DEI MATERIALI ARTISTICI DELLA SCULTURA' WHERE idclassescuola = '716'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('716',null,'TF',null,'6324',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M120','RICERCA E TECNICA DEI MATERIALI ARTISTICI DELLA SCULTURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '717')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6325',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M130',title = 'SEMIOLOGIA' WHERE idclassescuola = '717'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('717',null,'TF',null,'6325',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M130','SEMIOLOGIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '718')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6326',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M140',title = 'STUDIO DELL''AMBIENTE E TECNICHE DI RAPPRESENTAZIONE' WHERE idclassescuola = '718'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('718',null,'TF',null,'6326',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M140','STUDIO DELL''AMBIENTE E TECNICHE DI RAPPRESENTAZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '719')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6327',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M150',title = 'ARREDAMENTO TEATRALE' WHERE idclassescuola = '719'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('719',null,'TF',null,'6327',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M150','ARREDAMENTO TEATRALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '720')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6328',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M160',title = 'ANTROPOLOGIA CULTURALE-ETNOLOGIA' WHERE idclassescuola = '720'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('720',null,'TF',null,'6328',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M160','ANTROPOLOGIA CULTURALE-ETNOLOGIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '721')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6329',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M170',title = 'TEORIA E TECNICA DELLA RIPRESA CINEMATOGRAFICA' WHERE idclassescuola = '721'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('721',null,'TF',null,'6329',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M170','TEORIA E TECNICA DELLA RIPRESA CINEMATOGRAFICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '722')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6330',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M180',title = 'MACCHINERIA TEATRALE' WHERE idclassescuola = '722'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('722',null,'TF',null,'6330',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M180','MACCHINERIA TEATRALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '723')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6331',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M190',title = 'ESTETICA SPERIMENTALE' WHERE idclassescuola = '723'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('723',null,'TF',null,'6331',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M190','ESTETICA SPERIMENTALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '724')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6332',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M200',title = 'ARCHEOLOGIA' WHERE idclassescuola = '724'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('724',null,'TF',null,'6332',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M200','ARCHEOLOGIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '725')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6333',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M210',title = 'RICERCHE SOCIOLOGICHE NELL''ARTE' WHERE idclassescuola = '725'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('725',null,'TF',null,'6333',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M210','RICERCHE SOCIOLOGICHE NELL''ARTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '726')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6334',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M220',title = 'GRAFICA PUBBLICITARIA' WHERE idclassescuola = '726'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('726',null,'TF',null,'6334',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M220','GRAFICA PUBBLICITARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '727')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6335',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M230',title = 'STUDIO TEC.VALORI ARTIST.SPONTANEI MEDIANTE ESPRES.GRAFICA,PLAST.,PITTANTICHITA'' ITAL' WHERE idclassescuola = '727'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('727',null,'TF',null,'6335',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M230','STUDIO TEC.VALORI ARTIST.SPONTANEI MEDIANTE ESPRES.GRAFICA,PLAST.,PITTANTICHITA'' ITAL')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '728')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6336',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M240',title = 'TRADIZIONI POPOLARI ABRUZZESI' WHERE idclassescuola = '728'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('728',null,'TF',null,'6336',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M240','TRADIZIONI POPOLARI ABRUZZESI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '729')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6337',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M250',title = 'SOCIOLOGIA DELL''ARTE' WHERE idclassescuola = '729'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('729',null,'TF',null,'6337',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M250','SOCIOLOGIA DELL''ARTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '730')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6338',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M260',title = 'STORIA E CIVILTA'' DELL''UOMO' WHERE idclassescuola = '730'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('730',null,'TF',null,'6338',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M260','STORIA E CIVILTA'' DELL''UOMO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '731')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6339',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M270',title = 'ELEMENTI DI REGIA' WHERE idclassescuola = '731'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('731',null,'TF',null,'6339',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M270','ELEMENTI DI REGIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '732')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6340',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M280',title = 'TECNICHE DELL''ANIMAZIONE' WHERE idclassescuola = '732'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('732',null,'TF',null,'6340',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M280','TECNICHE DELL''ANIMAZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '733')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6341',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M290',title = 'STORIA DELLA MUSICA' WHERE idclassescuola = '733'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('733',null,'TF',null,'6341',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M290','STORIA DELLA MUSICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '734')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6342',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M300',title = 'RILEVAZIONE BENI CULTURALI' WHERE idclassescuola = '734'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('734',null,'TF',null,'6342',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M300','RILEVAZIONE BENI CULTURALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '735')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6343',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M310',title = 'SCUOLA SERALE ARTEFICI' WHERE idclassescuola = '735'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('735',null,'TF',null,'6343',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M310','SCUOLA SERALE ARTEFICI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '736')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6344',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M320',title = 'ELEMENTI DI STORIA POLITICA E SOCIALE' WHERE idclassescuola = '736'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('736',null,'TF',null,'6344',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M320','ELEMENTI DI STORIA POLITICA E SOCIALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '737')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6345',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M330',title = 'ARREDAMENTO' WHERE idclassescuola = '737'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('737',null,'TF',null,'6345',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M330','ARREDAMENTO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '738')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6346',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M340',title = 'LETTERATURA CONTEMPORANEA' WHERE idclassescuola = '738'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('738',null,'TF',null,'6346',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M340','LETTERATURA CONTEMPORANEA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '739')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6347',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M350',title = 'TECNICA DELLA REGIA' WHERE idclassescuola = '739'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('739',null,'TF',null,'6347',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M350','TECNICA DELLA REGIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '740')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6348',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M360',title = 'SERIGRAFIA' WHERE idclassescuola = '740'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('740',null,'TF',null,'6348',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M360','SERIGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '741')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6349',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M370',title = 'CORRENTI ARTISTICHE CONTEMPORANEE E D''AVANGUARDIA' WHERE idclassescuola = '741'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('741',null,'TF',null,'6349',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M370','CORRENTI ARTISTICHE CONTEMPORANEE E D''AVANGUARDIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '742')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6350',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M380',title = 'MOSAICO' WHERE idclassescuola = '742'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('742',null,'TF',null,'6350',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M380','MOSAICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '743')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6351',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M390',title = 'LETTERATURA ITALIANA E STRANIERA' WHERE idclassescuola = '743'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('743',null,'TF',null,'6351',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M390','LETTERATURA ITALIANA E STRANIERA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '744')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6352',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M400',title = 'CALCOGRAFIA' WHERE idclassescuola = '744'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('744',null,'TF',null,'6352',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M400','CALCOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '745')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6353',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M410',title = 'VARIE TECNICHE DELLA SCULTURA' WHERE idclassescuola = '745'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('745',null,'TF',null,'6353',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M410','VARIE TECNICHE DELLA SCULTURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '746')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6354',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M420',title = 'FORMATURA' WHERE idclassescuola = '746'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('746',null,'TF',null,'6354',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M420','FORMATURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '747')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6355',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M430',title = 'ELEMENTI DI REGIA TEATRALE, CINEMATOGRAFICA, TELEVISIVA' WHERE idclassescuola = '747'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('747',null,'TF',null,'6355',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M430','ELEMENTI DI REGIA TEATRALE, CINEMATOGRAFICA, TELEVISIVA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '748')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6356',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M440',title = 'LAVORAZIONE DEL LEGNO' WHERE idclassescuola = '748'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('748',null,'TF',null,'6356',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M440','LAVORAZIONE DEL LEGNO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '749')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6357',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M450',title = 'SCENOGRAFIA TELEVISIVA' WHERE idclassescuola = '749'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('749',null,'TF',null,'6357',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M450','SCENOGRAFIA TELEVISIVA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '750')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6358',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M460',title = 'STORIA DELLA CRITICA D''ARTE CONTEMPORANEA' WHERE idclassescuola = '750'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('750',null,'TF',null,'6358',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M460','STORIA DELLA CRITICA D''ARTE CONTEMPORANEA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '751')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6359',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M470',title = 'CORRENTI ARTISTICHE CONTEMPORANEE' WHERE idclassescuola = '751'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('751',null,'TF',null,'6359',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M470','CORRENTI ARTISTICHE CONTEMPORANEE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '752')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6360',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'M480',title = 'SCUOLA LIBERA DEL NUDO' WHERE idclassescuola = '752'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('752',null,'TF',null,'6360',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'M480','SCUOLA LIBERA DEL NUDO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '753')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6361',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N010',title = 'ANALISI DELLA MUSICA' WHERE idclassescuola = '753'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('753',null,'TF',null,'6361',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N010','ANALISI DELLA MUSICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '754')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6362',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N020',title = 'ASSISTENTE MUSICALE (RADIO,TV,DISCHI E APPARECCHIATURE ELETTRONICHE)' WHERE idclassescuola = '754'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('754',null,'TF',null,'6362',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N020','ASSISTENTE MUSICALE (RADIO,TV,DISCHI E APPARECCHIATURE ELETTRONICHE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '755')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6363',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N030',title = 'BASSO TUBA' WHERE idclassescuola = '755'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('755',null,'TF',null,'6363',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N030','BASSO TUBA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '756')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6364',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N040',title = 'DIDATTICA DELLA MUSICA' WHERE idclassescuola = '756'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('756',null,'TF',null,'6364',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N040','DIDATTICA DELLA MUSICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '757')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6365',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N050',title = 'DIREZIONE D''ORCHESTRA PER AVVIAMENTO AL TEATRO LIRICO' WHERE idclassescuola = '757'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('757',null,'TF',null,'6365',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N050','DIREZIONE D''ORCHESTRA PER AVVIAMENTO AL TEATRO LIRICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '758')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6366',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AB77',title = 'Chitarra' WHERE idclassescuola = '758'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('758',null,'TF',null,'6366',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AB77','Chitarra')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '759')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6367',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N060',title = 'INFORMATICA MUSICALE' WHERE idclassescuola = '759'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('759',null,'TF',null,'6367',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N060','INFORMATICA MUSICALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '760')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6368',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AC77',title = 'Clarinetto' WHERE idclassescuola = '760'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('760',null,'TF',null,'6368',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AC77','Clarinetto')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '761')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6369',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N070',title = 'ITALIANO, LATINO, STORIA ED EDUCAZIONE CIVICA' WHERE idclassescuola = '761'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('761',null,'TF',null,'6369',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N070','ITALIANO, LATINO, STORIA ED EDUCAZIONE CIVICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '762')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6370',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AD77',title = 'Corno' WHERE idclassescuola = '762'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('762',null,'TF',null,'6370',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AD77','Corno')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '763')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6371',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AE77',title = 'Fagotto' WHERE idclassescuola = '763'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('763',null,'TF',null,'6371',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AE77','Fagotto')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '764')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6372',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N080',title = 'LINGUA STRANIERA' WHERE idclassescuola = '764'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('764',null,'TF',null,'6372',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N080','LINGUA STRANIERA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '765')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6373',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AF77',title = 'Fisarmonica' WHERE idclassescuola = '765'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('765',null,'TF',null,'6373',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AF77','Fisarmonica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '766')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6374',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N090',title = 'ACCORDATURA DI STRUMENTI A TASTIERA' WHERE idclassescuola = '766'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('766',null,'TF',null,'6374',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N090','ACCORDATURA DI STRUMENTI A TASTIERA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '767')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6375',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AG77',title = 'Flauto' WHERE idclassescuola = '767'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('767',null,'TF',null,'6375',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AG77','Flauto')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '768')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6376',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N100',title = 'LIUTERIA' WHERE idclassescuola = '768'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('768',null,'TF',null,'6376',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N100','LIUTERIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '769')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6377',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N110',title = 'MANDOLINO' WHERE idclassescuola = '769'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('769',null,'TF',null,'6377',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N110','MANDOLINO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '770')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6378',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N120',title = 'MUSICA ELETTRONICA' WHERE idclassescuola = '770'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('770',null,'TF',null,'6378',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N120','MUSICA ELETTRONICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '771')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6379',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N130',title = 'MUSICA JAZZ' WHERE idclassescuola = '771'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('771',null,'TF',null,'6379',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N130','MUSICA JAZZ')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '772')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6380',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N140',title = 'MUSICA SACRA, LITURGICA, LITURGICA PREPOLIFONICA' WHERE idclassescuola = '772'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('772',null,'TF',null,'6380',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N140','MUSICA SACRA, LITURGICA, LITURGICA PREPOLIFONICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '773')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6381',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N150',title = 'MUSICA VOCALE DA CAMERA' WHERE idclassescuola = '773'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('773',null,'TF',null,'6381',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N150','MUSICA VOCALE DA CAMERA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '774')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6382',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AH77',title = 'Oboe' WHERE idclassescuola = '774'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('774',null,'TF',null,'6382',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AH77','Oboe')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '775')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6383',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N170',title = 'STORIA DELL''ARTE' WHERE idclassescuola = '775'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('775',null,'TF',null,'6383',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N170','STORIA DELL''ARTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '776')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6384',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N180',title = 'STRUMENTI ANTICHI(LIUTO,FLAUTI DOLCI,VIOLA ETC.)' WHERE idclassescuola = '776'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('776',null,'TF',null,'6384',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N180','STRUMENTI ANTICHI(LIUTO,FLAUTI DOLCI,VIOLA ETC.)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '777')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6385',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AI77',title = 'Percussioni' WHERE idclassescuola = '777'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('777',null,'TF',null,'6385',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AI77','Percussioni')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '778')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6386',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N200',title = 'PROPEDEUTICA MUSICALE' WHERE idclassescuola = '778'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('778',null,'TF',null,'6386',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N200','PROPEDEUTICA MUSICALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '779')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6387',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AJ77',title = 'Pianoforte' WHERE idclassescuola = '779'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('779',null,'TF',null,'6387',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AJ77','Pianoforte')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '780')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6388',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N210',title = 'COLLABORAZIONE PIANISTICA' WHERE idclassescuola = '780'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('780',null,'TF',null,'6388',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N210','COLLABORAZIONE PIANISTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '781')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6389',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AK77',title = 'Saxofono' WHERE idclassescuola = '781'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('781',null,'TF',null,'6389',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AK77','Saxofono')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '782')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6390',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N220',title = 'CLARINETTO BASSO' WHERE idclassescuola = '782'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('782',null,'TF',null,'6390',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N220','CLARINETTO BASSO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '783')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6391',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N230',title = 'DIZIONE, RECITAZIONE E STORIA DEL TEATRO' WHERE idclassescuola = '783'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('783',null,'TF',null,'6391',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N230','DIZIONE, RECITAZIONE E STORIA DEL TEATRO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '784')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6392',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AL77',title = 'Tromba' WHERE idclassescuola = '784'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('784',null,'TF',null,'6392',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AL77','Tromba')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '785')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6393',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N240',title = 'MATERIE LETTERARIE' WHERE idclassescuola = '785'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('785',null,'TF',null,'6393',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N240','MATERIE LETTERARIE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '786')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6394',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N250',title = 'ORIENTAMENTO MUSICALE' WHERE idclassescuola = '786'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('786',null,'TF',null,'6394',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N250','ORIENTAMENTO MUSICALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '787')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6395',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AM77',title = 'Violino' WHERE idclassescuola = '787'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('787',null,'TF',null,'6395',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AM77','Violino')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '788')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6396',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'N260',title = 'PRATICA PIANISTICA' WHERE idclassescuola = '788'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('788',null,'TF',null,'6396',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'N260','PRATICA PIANISTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '789')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6397',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P010',title = 'TECNICA DELLA DANZA' WHERE idclassescuola = '789'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('789',null,'TF',null,'6397',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P010','TECNICA DELLA DANZA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '790')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6398',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P020',title = 'TEORIA DELLA DANZA' WHERE idclassescuola = '790'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('790',null,'TF',null,'6398',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P020','TEORIA DELLA DANZA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '791')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6399',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P030',title = 'PROPEDEUTICA DELLA DANZA (CORSO STRAORDINARIO)' WHERE idclassescuola = '791'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('791',null,'TF',null,'6399',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P030','PROPEDEUTICA DELLA DANZA (CORSO STRAORDINARIO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '792')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6400',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P040',title = 'STORIA DELLA DANZA' WHERE idclassescuola = '792'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('792',null,'TF',null,'6400',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P040','STORIA DELLA DANZA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '793')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6401',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P050',title = 'COMPOSIZIONE' WHERE idclassescuola = '793'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('793',null,'TF',null,'6401',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P050','COMPOSIZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '794')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6402',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P060',title = 'ACCOMPAGNATORE AL PIANOFORTE' WHERE idclassescuola = '794'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('794',null,'TF',null,'6402',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P060','ACCOMPAGNATORE AL PIANOFORTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '795')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6403',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P070',title = 'STORIA DELLA MUSICA' WHERE idclassescuola = '795'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('795',null,'TF',null,'6403',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P070','STORIA DELLA MUSICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '796')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6404',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P080',title = 'STORIA DELL''ARTE PER ACCADEMIA NAZIONALE DI DANZA' WHERE idclassescuola = '796'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('796',null,'TF',null,'6404',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P080','STORIA DELL''ARTE PER ACCADEMIA NAZIONALE DI DANZA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '797')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6405',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P090',title = 'SOLFEGGIO' WHERE idclassescuola = '797'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('797',null,'TF',null,'6405',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P090','SOLFEGGIO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '798')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6406',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P100',title = 'COMUNICAZIONI VISIVE (CORSO SPECIALE)' WHERE idclassescuola = '798'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('798',null,'TF',null,'6406',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P100','COMUNICAZIONI VISIVE (CORSO SPECIALE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '799')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6407',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P110',title = 'INGLESE PRESSO ACCADEMIA NAZIONALE DI DANZA (CORSO SPECIALE)' WHERE idclassescuola = '799'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('799',null,'TF',null,'6407',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P110','INGLESE PRESSO ACCADEMIA NAZIONALE DI DANZA (CORSO SPECIALE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '800')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6408',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P120',title = 'FRANCESE PRESSO ACCADEMIA NAZIONALE DI DANZA (CORSO SPECIALE)' WHERE idclassescuola = '800'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('800',null,'TF',null,'6408',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P120','FRANCESE PRESSO ACCADEMIA NAZIONALE DI DANZA (CORSO SPECIALE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '801')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6409',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P130',title = 'REPERTORIO (CORSO SPECIALE)' WHERE idclassescuola = '801'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('801',null,'TF',null,'6409',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P130','REPERTORIO (CORSO SPECIALE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '802')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6410',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'P140',title = 'ANATOMIA E FISIOLOGIA DEL MOVIMENTO (CORSO SPECIALE)' WHERE idclassescuola = '802'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('802',null,'TF',null,'6410',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'P140','ANATOMIA E FISIOLOGIA DEL MOVIMENTO (CORSO SPECIALE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '803')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6411',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'Q010',title = 'STORIA DELLO SPETTACOLO' WHERE idclassescuola = '803'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('803',null,'TF',null,'6411',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'Q010','STORIA DELLO SPETTACOLO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '804')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6412',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'Q020',title = 'STORIA DEL TEATRO' WHERE idclassescuola = '804'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('804',null,'TF',null,'6412',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'Q020','STORIA DEL TEATRO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '805')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6413',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'Q030',title = 'STORIA DELLA MUSICA' WHERE idclassescuola = '805'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('805',null,'TF',null,'6413',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'Q030','STORIA DELLA MUSICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '806')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6414',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'Q040',title = 'TRUCCO E MASCHERA' WHERE idclassescuola = '806'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('806',null,'TF',null,'6414',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'Q040','TRUCCO E MASCHERA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '807')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6415',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'Q050',title = 'EDUCAZIONE ALLA VOCE' WHERE idclassescuola = '807'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('807',null,'TF',null,'6415',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'Q050','EDUCAZIONE ALLA VOCE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '808')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6416',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'Q060',title = 'CANTO' WHERE idclassescuola = '808'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('808',null,'TF',null,'6416',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'Q060','CANTO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '809')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6417',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'Q070',title = 'DANZA' WHERE idclassescuola = '809'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('809',null,'TF',null,'6417',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'Q070','DANZA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '810')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6418',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'Q080',title = 'SCHERMA ED ACROBATICA' WHERE idclassescuola = '810'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('810',null,'TF',null,'6418',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'Q080','SCHERMA ED ACROBATICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '811')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6419',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'Q090',title = 'ACCOMPAGNATORE AL PIANOFORTE' WHERE idclassescuola = '811'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('811',null,'TF',null,'6419',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'Q090','ACCOMPAGNATORE AL PIANOFORTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '812')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6420',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AA77',title = 'Arpa' WHERE idclassescuola = '812'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('812',null,'TF',null,'6420',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AA77','Arpa')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '813')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6421',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AN77',title = 'Violoncello' WHERE idclassescuola = '813'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('813',null,'TF',null,'6421',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AN77','Violoncello')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '814')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6501',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AA46',title = 'LINGUA e CIV. STRANIERA (CINESE)' WHERE idclassescuola = '814'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('814',null,'TF',null,'6501',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AA46','LINGUA e CIV. STRANIERA (CINESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '815')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6502',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AB46',title = 'LINGUA e CIV. STRANIERA (GIAPPONESE)' WHERE idclassescuola = '815'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('815',null,'TF',null,'6502',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AB46','LINGUA e CIV. STRANIERA (GIAPPONESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '816')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6503',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AC46',title = 'LINGUA e CIV. STRANIERA (EBRAICO)' WHERE idclassescuola = '816'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('816',null,'TF',null,'6503',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AC46','LINGUA e CIV. STRANIERA (EBRAICO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '817')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6504',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AD46',title = 'LINGUA e CIV. STRANIERA (ARABO)' WHERE idclassescuola = '817'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('817',null,'TF',null,'6504',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AD46','LINGUA e CIV. STRANIERA (ARABO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '818')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6505',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AE46',title = 'LINGUA e CIV. STRANIERA (NEOGRECO)' WHERE idclassescuola = '818'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('818',null,'TF',null,'6505',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AE46','LINGUA e CIV. STRANIERA (NEOGRECO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '819')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6506',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AF46',title = 'LINGUA e CIV. STRANIERA (PORTOGHESE)' WHERE idclassescuola = '819'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('819',null,'TF',null,'6506',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AF46','LINGUA e CIV. STRANIERA (PORTOGHESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '820')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6507',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AC02',title = 'A029,A030: EDUCAZIONE FISICA NEGLI ISTITUTI E SCUOLE DI ISTRUZIONE SECONDARIA II GRADO, SCIENZE MOTORIE E SPORTIVE' WHERE idclassescuola = '820'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('820',null,'TF',null,'6507',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AC02','A029,A030: EDUCAZIONE FISICA NEGLI ISTITUTI E SCUOLE DI ISTRUZIONE SECONDARIA II GRADO, SCIENZE MOTORIE E SPORTIVE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '821')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6508',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AC03',title = 'A031,A032: EDUCAZIONE MUSICALE NEGLI ISTITUTI DI ISTRUZIONE SECONDARIA DI II GRADO,  MUSICA' WHERE idclassescuola = '821'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('821',null,'TF',null,'6508',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AC03','A031,A032: EDUCAZIONE MUSICALE NEGLI ISTITUTI DI ISTRUZIONE SECONDARIA DI II GRADO,  MUSICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '822')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6509',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AC05',title = 'A043,A050: ITALIANO, STORIA  E GEOGRAFIA NELLA SCUOLA SECONDARIA DI I GRADO, MATERIE LETTERARIE NEGLI ISTITUTI DI ISTRUZIONE SECONDARIA DI II GRADO' WHERE idclassescuola = '822'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('822',null,'TF',null,'6509',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AC05','A043,A050: ITALIANO, STORIA  E GEOGRAFIA NELLA SCUOLA SECONDARIA DI I GRADO, MATERIE LETTERARIE NEGLI ISTITUTI DI ISTRUZIONE SECONDARIA DI II GRADO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '823')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6510',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AC06',title = 'A245,A246: LINGUA STRANIERA (FRANCESE), LINGUA E CIVILTA'' STRANIERA (FRANCESE)' WHERE idclassescuola = '823'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('823',null,'TF',null,'6510',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AC06','A245,A246: LINGUA STRANIERA (FRANCESE), LINGUA E CIVILTA'' STRANIERA (FRANCESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '824')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6511',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AC07',title = 'A345,A346: LINGUA STRANIERA (INGLESE) , LINGUA E CIVILTA'' STRANIERA (INGLESE)' WHERE idclassescuola = '824'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('824',null,'TF',null,'6511',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AC07','A345,A346: LINGUA STRANIERA (INGLESE) , LINGUA E CIVILTA'' STRANIERA (INGLESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '825')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6512',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AC08',title = 'A445,A446: LINGUA STRANIERA (SPAGNOLO), LINGUA E CIVILTA'' STRANIERA (SPAGNOLO)' WHERE idclassescuola = '825'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('825',null,'TF',null,'6512',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AC08','A445,A446: LINGUA STRANIERA (SPAGNOLO), LINGUA E CIVILTA'' STRANIERA (SPAGNOLO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '826')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6513',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AC09',title = 'A545,A546: LINGUA STRANIERA (TEDESCO), LINGUA E CIVILTA'' STRANIERA (TEDESCO)' WHERE idclassescuola = '826'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('826',null,'TF',null,'6513',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AC09','A545,A546: LINGUA STRANIERA (TEDESCO), LINGUA E CIVILTA'' STRANIERA (TEDESCO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '827')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'TF',idcorsostudionorma = null,indicecineca = '6514',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AC01',title = 'A025,A028: DISEGNO E STORIA DELL''ARTE, ARTE E IMMAGINE' WHERE idclassescuola = '827'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('827',null,'TF',null,'6514',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AC01','A025,A028: DISEGNO E STORIA DELL''ARTE, ARTE E IMMAGINE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '828')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7001',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A030-PAS',title = 'SCIENZE MOTORIE E SPORTIVE' WHERE idclassescuola = '828'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('828',null,'PS',null,'7001',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A030-PAS','SCIENZE MOTORIE E SPORTIVE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '829')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7002',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A032-PAS',title = 'EDUCAZIONE MUSICALE NELLA SCUOLA MEDIA' WHERE idclassescuola = '829'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('829',null,'PS',null,'7002',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A032-PAS','EDUCAZIONE MUSICALE NELLA SCUOLA MEDIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '830')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7003',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A033-PAS',title = 'EDUCAZIONE TECNICA NELLA SCUOLA MEDIA' WHERE idclassescuola = '830'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('830',null,'PS',null,'7003',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A033-PAS','EDUCAZIONE TECNICA NELLA SCUOLA MEDIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '831')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7004',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A043-PAS',title = 'ITALIANO, STORIA  E GEOGRAFIA NELLA SCUOLA SECONDARIA DI I GRADO' WHERE idclassescuola = '831'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('831',null,'PS',null,'7004',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A043-PAS','ITALIANO, STORIA  E GEOGRAFIA NELLA SCUOLA SECONDARIA DI I GRADO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '832')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7005',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A059-PAS',title = 'MATEMATICHE E SCIENZE NELLA SCUOLA SECONDARIA DI I GRADO' WHERE idclassescuola = '832'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('832',null,'PS',null,'7005',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A059-PAS','MATEMATICHE E SCIENZE NELLA SCUOLA SECONDARIA DI I GRADO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '833')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7006',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A245-PAS',title = 'LINGUA STRANIERA (FRANCESE)' WHERE idclassescuola = '833'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('833',null,'PS',null,'7006',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A245-PAS','LINGUA STRANIERA (FRANCESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '834')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7007',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A345-PAS',title = 'LINGUA STRANIERA (INGLESE) ' WHERE idclassescuola = '834'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('834',null,'PS',null,'7007',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A345-PAS','LINGUA STRANIERA (INGLESE) ')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '835')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7008',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A080-PAS',title = 'ITALIANO NELLA SCUOLA MEDIA CON LINGUA DI INSEGNAMENTO SLOVENA' WHERE idclassescuola = '835'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('835',null,'PS',null,'7008',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A080-PAS','ITALIANO NELLA SCUOLA MEDIA CON LINGUA DI INSEGNAMENTO SLOVENA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '836')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7009',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A085-PAS',title = 'SLOVENO,STORIA ED EDCIVICA E GEOGRAFIA NELLA SCUOLA MEDIA CON LINGUA SLOVENA' WHERE idclassescuola = '836'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('836',null,'PS',null,'7009',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A085-PAS','SLOVENO,STORIA ED EDCIVICA E GEOGRAFIA NELLA SCUOLA MEDIA CON LINGUA SLOVENA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '837')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7012',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A097-PAS',title = 'TEDESCO (SECONDA LINGUA) NELLA SCUOLA MEDIA IN LINGUA ITALIANA DELLA PROV DI BOLZANO' WHERE idclassescuola = '837'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('837',null,'PS',null,'7012',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A097-PAS','TEDESCO (SECONDA LINGUA) NELLA SCUOLA MEDIA IN LINGUA ITALIANA DELLA PROV DI BOLZANO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '838')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7014',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A013-PAS',title = 'CHIMICA E TECNOLOGIE CHIMICHE' WHERE idclassescuola = '838'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('838',null,'PS',null,'7014',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A013-PAS','CHIMICA E TECNOLOGIE CHIMICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '839')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7015',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A016-PAS',title = 'COSTRUZIONI, TECNOLOGIA DELLE COSTRUZIONI E DISEGNO TECNICO' WHERE idclassescuola = '839'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('839',null,'PS',null,'7015',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A016-PAS','COSTRUZIONI, TECNOLOGIA DELLE COSTRUZIONI E DISEGNO TECNICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '840')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7016',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A017-PAS',title = 'DISCIPLINE ECONOMICO-AZIENDALI' WHERE idclassescuola = '840'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('840',null,'PS',null,'7016',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A017-PAS','DISCIPLINE ECONOMICO-AZIENDALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '841')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7017',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A019-PAS',title = 'DISCIPLINE GIURIDICHE ED ECONOMICHE' WHERE idclassescuola = '841'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('841',null,'PS',null,'7017',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A019-PAS','DISCIPLINE GIURIDICHE ED ECONOMICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '842')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7018',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A020-PAS',title = 'DISCIPLINE MECCANICHE E TECNOLOGIA' WHERE idclassescuola = '842'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('842',null,'PS',null,'7018',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A020-PAS','DISCIPLINE MECCANICHE E TECNOLOGIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '843')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7019',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A029-PAS',title = 'EDUCAZIONE FISICA NEGLI ISTITUTI E SCUOLE DI ISTRUZIONE SECONDARIA II GRADO' WHERE idclassescuola = '843'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('843',null,'PS',null,'7019',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A029-PAS','EDUCAZIONE FISICA NEGLI ISTITUTI E SCUOLE DI ISTRUZIONE SECONDARIA II GRADO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '844')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7020',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A034-PAS',title = 'ELETTRONICA' WHERE idclassescuola = '844'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('844',null,'PS',null,'7020',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A034-PAS','ELETTRONICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '845')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7021',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A035-PAS',title = 'ELETTROTECNICA ED APPLICAZIONI' WHERE idclassescuola = '845'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('845',null,'PS',null,'7021',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A035-PAS','ELETTROTECNICA ED APPLICAZIONI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '846')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7022',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A036-PAS',title = 'FILOSOFIA, PSICOLOGIA E SCIENZE DELL''EDUCAZIONE' WHERE idclassescuola = '846'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('846',null,'PS',null,'7022',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A036-PAS','FILOSOFIA, PSICOLOGIA E SCIENZE DELL''EDUCAZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '847')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7023',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A037-PAS',title = 'FILOSOFIA E STORIA' WHERE idclassescuola = '847'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('847',null,'PS',null,'7023',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A037-PAS','FILOSOFIA E STORIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '848')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7024',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A038-PAS',title = 'FISICA' WHERE idclassescuola = '848'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('848',null,'PS',null,'7024',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A038-PAS','FISICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '849')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7025',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A039-PAS',title = 'GEOGRAFIA' WHERE idclassescuola = '849'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('849',null,'PS',null,'7025',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A039-PAS','GEOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '850')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7026',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A042-PAS',title = 'INFORMATICA' WHERE idclassescuola = '850'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('850',null,'PS',null,'7026',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A042-PAS','INFORMATICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '851')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7027',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A047-PAS',title = 'MATEMATICA' WHERE idclassescuola = '851'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('851',null,'PS',null,'7027',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A047-PAS','MATEMATICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '852')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7028',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A048-PAS',title = 'MATEMATICA APPLICATA' WHERE idclassescuola = '852'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('852',null,'PS',null,'7028',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A048-PAS','MATEMATICA APPLICATA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '853')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7029',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A049-PAS',title = 'MATEMATICA E FISICA' WHERE idclassescuola = '853'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('853',null,'PS',null,'7029',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A049-PAS','MATEMATICA E FISICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '854')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7030',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A050-PAS',title = 'MATERIE LETTERARIE NEGLI ISTITUTI DI ISTRUZIONE SECONDARIA DI II GRADO' WHERE idclassescuola = '854'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('854',null,'PS',null,'7030',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A050-PAS','MATERIE LETTERARIE NEGLI ISTITUTI DI ISTRUZIONE SECONDARIA DI II GRADO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '855')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7031',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A051-PAS',title = 'MATERIE LETTERARIE E LATINO NEI LICEI E NELL''ISTITUTO MAGISTRALE' WHERE idclassescuola = '855'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('855',null,'PS',null,'7031',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A051-PAS','MATERIE LETTERARIE E LATINO NEI LICEI E NELL''ISTITUTO MAGISTRALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '856')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7032',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A052-PAS',title = 'MATERIE LETTERARIE, LATINO E GRECO NEL LICEO CLASSICO' WHERE idclassescuola = '856'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('856',null,'PS',null,'7032',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A052-PAS','MATERIE LETTERARIE, LATINO E GRECO NEL LICEO CLASSICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '857')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7033',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A057-PAS',title = 'SCIENZA DEGLI ALIMENTI' WHERE idclassescuola = '857'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('857',null,'PS',null,'7033',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A057-PAS','SCIENZA DEGLI ALIMENTI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '858')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7034',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A058-PAS',title = 'SCIENZE E MECCANICA AGRARIA, TECNICHE DI GESTIONE AZIENDALE, FITOPATOLOGIA ED ENTOMOLOGIA AGRARIA' WHERE idclassescuola = '858'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('858',null,'PS',null,'7034',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A058-PAS','SCIENZE E MECCANICA AGRARIA, TECNICHE DI GESTIONE AZIENDALE, FITOPATOLOGIA ED ENTOMOLOGIA AGRARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '859')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7035',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A060-PAS',title = 'SCIENZE NATURALI, CHIMICA E GEOGRAFIA, MICROBIOLOGIA' WHERE idclassescuola = '859'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('859',null,'PS',null,'7035',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A060-PAS','SCIENZE NATURALI, CHIMICA E GEOGRAFIA, MICROBIOLOGIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '860')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7036',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A061-PAS',title = 'STORIA DELL''ARTE' WHERE idclassescuola = '860'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('860',null,'PS',null,'7036',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A061-PAS','STORIA DELL''ARTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '861')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7037',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A071-PAS',title = 'TECNOLOGIA E DISEGNO TECNICO' WHERE idclassescuola = '861'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('861',null,'PS',null,'7037',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A071-PAS','TECNOLOGIA E DISEGNO TECNICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '862')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7038',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A072-PAS',title = 'TOPOGRAFIA GENERALE, COSTRUZIONI RURALI E DISEGNO' WHERE idclassescuola = '862'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('862',null,'PS',null,'7038',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A072-PAS','TOPOGRAFIA GENERALE, COSTRUZIONI RURALI E DISEGNO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '863')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7039',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A246-PAS',title = 'LINGUA E CIVILTA'' STRANIERA (FRANCESE)' WHERE idclassescuola = '863'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('863',null,'PS',null,'7039',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A246-PAS','LINGUA E CIVILTA'' STRANIERA (FRANCESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '864')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7040',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A346-PAS',title = 'LINGUA E CIVILTA'' STRANIERA (INGLESE)' WHERE idclassescuola = '864'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('864',null,'PS',null,'7040',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A346-PAS','LINGUA E CIVILTA'' STRANIERA (INGLESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '865')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7041',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A446-PAS',title = 'LINGUA E CIVILTA'' STRANIERA (SPAGNOLO)' WHERE idclassescuola = '865'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('865',null,'PS',null,'7041',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A446-PAS','LINGUA E CIVILTA'' STRANIERA (SPAGNOLO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '866')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7042',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A546-PAS',title = 'LINGUA E CIVILTA'' STRANIERA (TEDESCO)' WHERE idclassescuola = '866'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('866',null,'PS',null,'7042',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A546-PAS','LINGUA E CIVILTA'' STRANIERA (TEDESCO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '867')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7043',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A646-PAS',title = 'LINGUA E CIVILTA'' STRANIERA (RUSSO)' WHERE idclassescuola = '867'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('867',null,'PS',null,'7043',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A646-PAS','LINGUA E CIVILTA'' STRANIERA (RUSSO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '868')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7047',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A081-PAS',title = 'LINGUA E LETTERE ITALIANE NEGLI ISTITUTI DI ISTRSECONDARIA DI II GRADO LINGUA SLOVENA' WHERE idclassescuola = '868'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('868',null,'PS',null,'7047',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A081-PAS','LINGUA E LETTERE ITALIANE NEGLI ISTITUTI DI ISTRSECONDARIA DI II GRADO LINGUA SLOVENA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '869')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7048',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A082-PAS',title = 'MATERIE LETTERARIE NEGLI ISTITUTI DI II GRADO DI LINGUA SLOVENA' WHERE idclassescuola = '869'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('869',null,'PS',null,'7048',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A082-PAS','MATERIE LETTERARIE NEGLI ISTITUTI DI II GRADO DI LINGUA SLOVENA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '870')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7061',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A001-PAS',title = 'AEROTECNICA E COSTRUZIONI AERONAUTICHE' WHERE idclassescuola = '870'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('870',null,'PS',null,'7061',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A001-PAS','AEROTECNICA E COSTRUZIONI AERONAUTICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '871')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7062',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A002-PAS',title = 'ANATOMIA, FISIOPATOLOGIA OCULARE E LABORATORIO DI MISURE OFTALMICHE' WHERE idclassescuola = '871'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('871',null,'PS',null,'7062',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A002-PAS','ANATOMIA, FISIOPATOLOGIA OCULARE E LABORATORIO DI MISURE OFTALMICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '872')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7063',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A003-PAS',title = 'ARTE DEL DISEGNO ANIMATO' WHERE idclassescuola = '872'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('872',null,'PS',null,'7063',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A003-PAS','ARTE DEL DISEGNO ANIMATO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '873')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7064',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A004-PAS',title = 'ARTE DEL TESSUTO DELLA MODA E DEL COSTUME' WHERE idclassescuola = '873'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('873',null,'PS',null,'7064',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A004-PAS','ARTE DEL TESSUTO DELLA MODA E DEL COSTUME')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '874')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7066',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A006-PAS',title = 'ARTE DELLA CERAMICA' WHERE idclassescuola = '874'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('874',null,'PS',null,'7066',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A006-PAS','ARTE DELLA CERAMICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '875')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7067',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A007-PAS',title = 'ARTE DELLA FOTOGRAFIA E GRAFICA PUBBLICITARIA' WHERE idclassescuola = '875'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('875',null,'PS',null,'7067',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A007-PAS','ARTE DELLA FOTOGRAFIA E GRAFICA PUBBLICITARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '876')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7068',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A008-PAS',title = 'ARTI DELLA GRAFICA E DELL''INCISIONE' WHERE idclassescuola = '876'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('876',null,'PS',null,'7068',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A008-PAS','ARTI DELLA GRAFICA E DELL''INCISIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '877')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7069',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A009-PAS',title = 'ARTE DELLA STAMPA E DEL RESTAURO DEL LIBRO' WHERE idclassescuola = '877'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('877',null,'PS',null,'7069',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A009-PAS','ARTE DELLA STAMPA E DEL RESTAURO DEL LIBRO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '878')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7070',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A010-PAS',title = 'ARTI DEI METALLI E DELL''OREFICERIA' WHERE idclassescuola = '878'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('878',null,'PS',null,'7070',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A010-PAS','ARTI DEI METALLI E DELL''OREFICERIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '879')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7071',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A011-PAS',title = 'ARTE MINERARIA' WHERE idclassescuola = '879'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('879',null,'PS',null,'7071',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A011-PAS','ARTE MINERARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '880')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7072',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A012-PAS',title = 'CHIMICA AGRARIA' WHERE idclassescuola = '880'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('880',null,'PS',null,'7072',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A012-PAS','CHIMICA AGRARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '881')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7073',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A014-PAS',title = 'CIRCOLAZIONE AEREA TELECOMUNICAZIONI AERONAUTICHE ED ESERCITAZIONI' WHERE idclassescuola = '881'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('881',null,'PS',null,'7073',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A014-PAS','CIRCOLAZIONE AEREA TELECOMUNICAZIONI AERONAUTICHE ED ESERCITAZIONI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '882')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7074',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A015-PAS',title = 'COSTRUZIONI NAVALI E TEORIA DELLA NAVE' WHERE idclassescuola = '882'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('882',null,'PS',null,'7074',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A015-PAS','COSTRUZIONI NAVALI E TEORIA DELLA NAVE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '883')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7075',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A018-PAS',title = 'DISCIPLINE GEOMETRICHE, ARCHITETTONICHE ARREDAMENTO E SCENOTECNICA' WHERE idclassescuola = '883'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('883',null,'PS',null,'7075',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A018-PAS','DISCIPLINE GEOMETRICHE, ARCHITETTONICHE ARREDAMENTO E SCENOTECNICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '884')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7076',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A021-PAS',title = 'DISCIPLINE PITTORICHE' WHERE idclassescuola = '884'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('884',null,'PS',null,'7076',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A021-PAS','DISCIPLINE PITTORICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '885')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7077',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A022-PAS',title = 'DISCIPLINE PLASTICHE' WHERE idclassescuola = '885'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('885',null,'PS',null,'7077',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A022-PAS','DISCIPLINE PLASTICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '886')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7078',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A023-PAS',title = 'DISEGNO E MODELLAZIONE ODONTOTECNICA' WHERE idclassescuola = '886'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('886',null,'PS',null,'7078',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A023-PAS','DISEGNO E MODELLAZIONE ODONTOTECNICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '887')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7079',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A024-PAS',title = 'DISEGNO E STORIA DEL COSTUME' WHERE idclassescuola = '887'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('887',null,'PS',null,'7079',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A024-PAS','DISEGNO E STORIA DEL COSTUME')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '888')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7080',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A025-PAS',title = 'DISEGNO E STORIA DELL''ARTE' WHERE idclassescuola = '888'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('888',null,'PS',null,'7080',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A025-PAS','DISEGNO E STORIA DELL''ARTE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '889')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7082',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A027-PAS',title = 'DISEGNO TECNICO ED ARTISTICO' WHERE idclassescuola = '889'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('889',null,'PS',null,'7082',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A027-PAS','DISEGNO TECNICO ED ARTISTICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '890')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7083',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A028-PAS',title = 'EDUCAZIONE ARTISTICA' WHERE idclassescuola = '890'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('890',null,'PS',null,'7083',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A028-PAS','EDUCAZIONE ARTISTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '891')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7084',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A031-PAS',title = 'EDUCAZIONE MUSICALE NEGLI ISTITUTI DI ISTRUZIONE SECONDARIA DI II GRADO' WHERE idclassescuola = '891'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('891',null,'PS',null,'7084',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A031-PAS','EDUCAZIONE MUSICALE NEGLI ISTITUTI DI ISTRUZIONE SECONDARIA DI II GRADO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '892')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7085',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A040-PAS',title = 'IGIENE, ANATOMIA, FISIOLOGIA, PATOLOGIA GENERALE E DELL''APPARATO MASTICATORIO' WHERE idclassescuola = '892'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('892',null,'PS',null,'7085',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A040-PAS','IGIENE, ANATOMIA, FISIOLOGIA, PATOLOGIA GENERALE E DELL''APPARATO MASTICATORIO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '893')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7087',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A044-PAS',title = 'LINGUAGGIO PER LA CINEMATOGRAFIA E LA TELEVISIONE' WHERE idclassescuola = '893'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('893',null,'PS',null,'7087',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A044-PAS','LINGUAGGIO PER LA CINEMATOGRAFIA E LA TELEVISIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '894')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7089',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A053-PAS',title = 'METEOROLOGIA AERONAUTICA ED ESERCITAZIONI' WHERE idclassescuola = '894'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('894',null,'PS',null,'7089',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A053-PAS','METEOROLOGIA AERONAUTICA ED ESERCITAZIONI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '895')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7090',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A054-PAS',title = 'MINERALOGIA E GEOLOGIA' WHERE idclassescuola = '895'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('895',null,'PS',null,'7090',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A054-PAS','MINERALOGIA E GEOLOGIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '896')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7091',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A055-PAS',title = 'NAVIGAZIONE AEREA ED ESERCITAZIONI' WHERE idclassescuola = '896'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('896',null,'PS',null,'7091',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A055-PAS','NAVIGAZIONE AEREA ED ESERCITAZIONI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '897')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7092',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A056-PAS',title = 'NAVIGAZIONE, ARTE NAVALE ED ELEMENTI DI COSTRUZIONI NAVALI' WHERE idclassescuola = '897'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('897',null,'PS',null,'7092',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A056-PAS','NAVIGAZIONE, ARTE NAVALE ED ELEMENTI DI COSTRUZIONI NAVALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '898')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7093',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A062-PAS',title = 'TECNICA DELLA REGISTRAZIONE DEL SUONO' WHERE idclassescuola = '898'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('898',null,'PS',null,'7093',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A062-PAS','TECNICA DELLA REGISTRAZIONE DEL SUONO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '899')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7094',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A063-PAS',title = 'TECNICA DELLA RIPRESA CINEMATOGRAFICA E TELEVISIVA' WHERE idclassescuola = '899'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('899',null,'PS',null,'7094',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A063-PAS','TECNICA DELLA RIPRESA CINEMATOGRAFICA E TELEVISIVA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '900')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7095',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A064-PAS',title = 'TECNICA E ORGANIZZAZIONE DELLA PRODUZIONE CINEMATOGRAFICA E TELEVISIVA' WHERE idclassescuola = '900'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('900',null,'PS',null,'7095',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A064-PAS','TECNICA E ORGANIZZAZIONE DELLA PRODUZIONE CINEMATOGRAFICA E TELEVISIVA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '901')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7096',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A065-PAS',title = 'TECNICA FOTOGRAFICA' WHERE idclassescuola = '901'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('901',null,'PS',null,'7096',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A065-PAS','TECNICA FOTOGRAFICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '902')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7099',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A068-PAS',title = 'TECNOLOGIE DELL''ABBIGLIAMENTO' WHERE idclassescuola = '902'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('902',null,'PS',null,'7099',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A068-PAS','TECNOLOGIE DELL''ABBIGLIAMENTO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '903')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7100',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A069-PAS',title = 'TECNOLOGIE  GRAFICHE ED IMPIANTI GRAFICI' WHERE idclassescuola = '903'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('903',null,'PS',null,'7100',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A069-PAS','TECNOLOGIE  GRAFICHE ED IMPIANTI GRAFICI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '904')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7101',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A070-PAS',title = 'TECNOLOGIE TESSILI' WHERE idclassescuola = '904'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('904',null,'PS',null,'7101',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A070-PAS','TECNOLOGIE TESSILI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '905')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7103',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A074-PAS',title = 'ZOOTECNICA E SCIENZA DELLA PRODUZIONE ANIMALE' WHERE idclassescuola = '905'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('905',null,'PS',null,'7103',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A074-PAS','ZOOTECNICA E SCIENZA DELLA PRODUZIONE ANIMALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '906')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7104',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A075-PAS',title = 'DATTILOGRAFIA E STENOGRAFIA' WHERE idclassescuola = '906'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('906',null,'PS',null,'7104',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A075-PAS','DATTILOGRAFIA E STENOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '907')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7105',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A076-PAS',title = 'TRATTAMENTO TESTI, CALCOLO, CONTABILITA'' ELETTRONICA ED APPLICAZIONI GESTIONALI' WHERE idclassescuola = '907'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('907',null,'PS',null,'7105',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A076-PAS','TRATTAMENTO TESTI, CALCOLO, CONTABILITA'' ELETTRONICA ED APPLICAZIONI GESTIONALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '908')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7106',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A445-PAS',title = 'LINGUA STRANIERA (SPAGNOLO)' WHERE idclassescuola = '908'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('908',null,'PS',null,'7106',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A445-PAS','LINGUA STRANIERA (SPAGNOLO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '909')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7107',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A545-PAS',title = 'LINGUA STRANIERA (TEDESCO)' WHERE idclassescuola = '909'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('909',null,'PS',null,'7107',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A545-PAS','LINGUA STRANIERA (TEDESCO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '910')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7110',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A746-PAS',title = 'LINGUA E CIVILTA'' STRANIERA (ALBANESE)' WHERE idclassescuola = '910'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('910',null,'PS',null,'7110',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A746-PAS','LINGUA E CIVILTA'' STRANIERA (ALBANESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '911')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7111',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A846-PAS',title = 'LINGUA E CIVILTA'' STRANIERA (SLOVENO)' WHERE idclassescuola = '911'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('911',null,'PS',null,'7111',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A846-PAS','LINGUA E CIVILTA'' STRANIERA (SLOVENO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '912')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7112',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A946-PAS',title = 'LINGUA E CIVILTA'' STRANIERA (SERBO-CROATO)' WHERE idclassescuola = '912'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('912',null,'PS',null,'7112',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A946-PAS','LINGUA E CIVILTA'' STRANIERA (SERBO-CROATO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '913')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7115',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C010-PAS',title = 'ADDETTO ALL''UFFICIO TECNICO' WHERE idclassescuola = '913'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('913',null,'PS',null,'7115',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C010-PAS','ADDETTO ALL''UFFICIO TECNICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '914')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7116',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C020-PAS',title = 'ATTIVITA'' PRATICHE SPECIALI' WHERE idclassescuola = '914'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('914',null,'PS',null,'7116',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C020-PAS','ATTIVITA'' PRATICHE SPECIALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '915')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7118',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C031-PAS',title = 'CONVERSAZIONE IN LINGUA STRANIERA (FRANCESE)' WHERE idclassescuola = '915'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('915',null,'PS',null,'7118',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C031-PAS','CONVERSAZIONE IN LINGUA STRANIERA (FRANCESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '916')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7119',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C032-PAS',title = 'CONVERSAZIONE IN LINGUA STRANIERA (INGLESE)' WHERE idclassescuola = '916'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('916',null,'PS',null,'7119',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C032-PAS','CONVERSAZIONE IN LINGUA STRANIERA (INGLESE)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '917')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7120',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C033-PAS',title = 'CONVERSAZIONE IN LINGUA STRANIERA (SPAGNOLO)' WHERE idclassescuola = '917'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('917',null,'PS',null,'7120',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C033-PAS','CONVERSAZIONE IN LINGUA STRANIERA (SPAGNOLO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '918')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7121',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C034-PAS',title = 'CONVERSAZIONE IN LINGUA STRANIERA (TEDESCO)' WHERE idclassescuola = '918'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('918',null,'PS',null,'7121',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C034-PAS','CONVERSAZIONE IN LINGUA STRANIERA (TEDESCO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '919')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7125',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C038-PAS',title = 'CONVERSAZIONE IN LINGUA STRANIERA (SERBO CROATO)' WHERE idclassescuola = '919'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('919',null,'PS',null,'7125',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C038-PAS','CONVERSAZIONE IN LINGUA STRANIERA (SERBO CROATO)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '920')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7126',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C040-PAS',title = 'ESERCITAZIONI AERONAUTICHE' WHERE idclassescuola = '920'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('920',null,'PS',null,'7126',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C040-PAS','ESERCITAZIONI AERONAUTICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '921')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7127',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C050-PAS',title = 'ESERCITAZIONI AGRARIE' WHERE idclassescuola = '921'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('921',null,'PS',null,'7127',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C050-PAS','ESERCITAZIONI AGRARIE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '922')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7129',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C070-PAS',title = 'ESERCITAZIONI DI ABBIGLIAMENTO E MODA' WHERE idclassescuola = '922'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('922',null,'PS',null,'7129',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C070-PAS','ESERCITAZIONI DI ABBIGLIAMENTO E MODA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '923')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7130',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C080-PAS',title = 'ESERCITAZIONI DI CIRCOLAZIONE AEREA' WHERE idclassescuola = '923'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('923',null,'PS',null,'7130',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C080-PAS','ESERCITAZIONI DI CIRCOLAZIONE AEREA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '924')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7131',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C090-PAS',title = 'ESERCITAZIONI DI COMUNICAZIONI' WHERE idclassescuola = '924'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('924',null,'PS',null,'7131',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C090-PAS','ESERCITAZIONI DI COMUNICAZIONI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '925')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7132',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C100-PAS',title = 'ESERCITAZIONI DI DISEGNO ARTISTICO DI TESSUTI' WHERE idclassescuola = '925'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('925',null,'PS',null,'7132',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C100-PAS','ESERCITAZIONI DI DISEGNO ARTISTICO DI TESSUTI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '926')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7133',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C110-PAS',title = 'ESERCITAZIONI DI ECONOMIA DOMESTICA' WHERE idclassescuola = '926'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('926',null,'PS',null,'7133',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C110-PAS','ESERCITAZIONI DI ECONOMIA DOMESTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '927')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7135',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C130-PAS',title = 'ESERCITAZIONI DI ODONTOTECNICA' WHERE idclassescuola = '927'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('927',null,'PS',null,'7135',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C130-PAS','ESERCITAZIONI DI ODONTOTECNICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '928')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7136',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C140-PAS',title = 'ESERCITAZIONI DI OFFICINA MECCANICA, AGRICOLA E DI MACCHINE AGRICOLE' WHERE idclassescuola = '928'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('928',null,'PS',null,'7136',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C140-PAS','ESERCITAZIONI DI OFFICINA MECCANICA, AGRICOLA E DI MACCHINE AGRICOLE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '929')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7137',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C150-PAS',title = 'ESERCITAZIONI DI PORTINERIA E PRATICA DI AGENZIA' WHERE idclassescuola = '929'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('929',null,'PS',null,'7137',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C150-PAS','ESERCITAZIONI DI PORTINERIA E PRATICA DI AGENZIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '930')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7139',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C170-PAS',title = 'ESERCITAZIONI DI TEORIA DELLA NAVE E DI COSTRUZIONI NAVALI' WHERE idclassescuola = '930'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('930',null,'PS',null,'7139',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C170-PAS','ESERCITAZIONI DI TEORIA DELLA NAVE E DI COSTRUZIONI NAVALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '931')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7140',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C180-PAS',title = 'ESERCITAZIONI NAUTICHE' WHERE idclassescuola = '931'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('931',null,'PS',null,'7140',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C180-PAS','ESERCITAZIONI NAUTICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '932')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7141',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C190-PAS',title = 'ESERCITAZIONI PRATICHE PER CENTRALINISTI TELEFONICI' WHERE idclassescuola = '932'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('932',null,'PS',null,'7141',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C190-PAS','ESERCITAZIONI PRATICHE PER CENTRALINISTI TELEFONICI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '933')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7142',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C200-PAS',title = 'ESERCITAZIONI PRATICHE DI OTTICA' WHERE idclassescuola = '933'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('933',null,'PS',null,'7142',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C200-PAS','ESERCITAZIONI PRATICHE DI OTTICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '934')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7144',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C220-PAS',title = 'LABORATORIO DI TECNOL.TESSILI E DELL''ABBIGLIAMENTO E REPARTI DI LAVORAZ.TESSILI E ABBIGL' WHERE idclassescuola = '934'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('934',null,'PS',null,'7144',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C220-PAS','LABORATORIO DI TECNOL.TESSILI E DELL''ABBIGLIAMENTO E REPARTI DI LAVORAZ.TESSILI E ABBIGL')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '935')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7145',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C230-PAS',title = 'LABORATORIO DI AEROTECNICA, COSTRUZIONI E TECNOLOGIE AERONAUTICHE' WHERE idclassescuola = '935'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('935',null,'PS',null,'7145',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C230-PAS','LABORATORIO DI AEROTECNICA, COSTRUZIONI E TECNOLOGIE AERONAUTICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '936')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7146',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C240-PAS',title = 'LABORATORIO DI CHIMICA E CHIMICA INDUSTRIALE' WHERE idclassescuola = '936'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('936',null,'PS',null,'7146',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C240-PAS','LABORATORIO DI CHIMICA E CHIMICA INDUSTRIALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '937')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7147',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C250-PAS',title = 'LABORATORIO DI COSTRUZIONE, VERNICIATURA E RESTAURO DI STRUMENTI AD ARCO' WHERE idclassescuola = '937'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('937',null,'PS',null,'7147',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C250-PAS','LABORATORIO DI COSTRUZIONE, VERNICIATURA E RESTAURO DI STRUMENTI AD ARCO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '938')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7148',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C260-PAS',title = 'LABORATORIO DI ELETTRONICA' WHERE idclassescuola = '938'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('938',null,'PS',null,'7148',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C260-PAS','LABORATORIO DI ELETTRONICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '939')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7149',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C270-PAS',title = 'LABORATORIO DI ELETTROTECNICA' WHERE idclassescuola = '939'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('939',null,'PS',null,'7149',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C270-PAS','LABORATORIO DI ELETTROTECNICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '940')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7150',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C280-PAS',title = 'LABORATORIO DI FISICA ATOMICA E NUCLEARE E STRUMENTI' WHERE idclassescuola = '940'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('940',null,'PS',null,'7150',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C280-PAS','LABORATORIO DI FISICA ATOMICA E NUCLEARE E STRUMENTI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '941')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7151',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C290-PAS',title = 'LABORATORIO DI FISICA E FISICA APPLICATA' WHERE idclassescuola = '941'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('941',null,'PS',null,'7151',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C290-PAS','LABORATORIO DI FISICA E FISICA APPLICATA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '942')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7152',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C300-PAS',title = 'LABORATORIO DI INFORMATICA GESTIONALE' WHERE idclassescuola = '942'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('942',null,'PS',null,'7152',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C300-PAS','LABORATORIO DI INFORMATICA GESTIONALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '943')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7153',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C310-PAS',title = 'LABORATORIO DI INFORMATICA INDUSTRIALE' WHERE idclassescuola = '943'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('943',null,'PS',null,'7153',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C310-PAS','LABORATORIO DI INFORMATICA INDUSTRIALE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '944')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7154',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C320-PAS',title = 'LABORATORIO MECCANICO-TECNOLOGICO' WHERE idclassescuola = '944'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('944',null,'PS',null,'7154',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C320-PAS','LABORATORIO MECCANICO-TECNOLOGICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '945')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7155',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C330-PAS',title = 'LABORATORIO DI OREFICERIA' WHERE idclassescuola = '945'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('945',null,'PS',null,'7155',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C330-PAS','LABORATORIO DI OREFICERIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '946')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7157',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C350-PAS',title = 'LABORATORIO DI TECNICA MICROBIOLOGICA' WHERE idclassescuola = '946'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('946',null,'PS',null,'7157',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C350-PAS','LABORATORIO DI TECNICA MICROBIOLOGICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '947')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7158',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C360-PAS',title = 'LABORATORIO DI TECNOLOGIA CARTARIA ED ESERCITAZIONI DI CARTIERA' WHERE idclassescuola = '947'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('947',null,'PS',null,'7158',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C360-PAS','LABORATORIO DI TECNOLOGIA CARTARIA ED ESERCITAZIONI DI CARTIERA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '948')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7159',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C370-PAS',title = 'LABORATORIO E REPARTI DI LAVORAZIONE DEL LEGNO' WHERE idclassescuola = '948'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('948',null,'PS',null,'7159',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C370-PAS','LABORATORIO E REPARTI DI LAVORAZIONE DEL LEGNO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '949')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7160',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C380-PAS',title = 'LABORATORIO E REPARTI DI LAVORAZIONE PER LE ARTI GRAFICHE' WHERE idclassescuola = '949'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('949',null,'PS',null,'7160',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C380-PAS','LABORATORIO E REPARTI DI LAVORAZIONE PER LE ARTI GRAFICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '950')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7161',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C390-PAS',title = 'LABORATORIO E REPARTI DI LAVORAZIONE PER L''INDUSTRIA MINERARIA' WHERE idclassescuola = '950'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('950',null,'PS',null,'7161',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C390-PAS','LABORATORIO E REPARTI DI LAVORAZIONE PER L''INDUSTRIA MINERARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '951')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7164',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C420-PAS',title = 'LABORATORIO TECNOLOGICO PER IL MARMO-REPARTI SCULTURA,SMODELLATURA,DECORAZIONE E ORNATO' WHERE idclassescuola = '951'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('951',null,'PS',null,'7164',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C420-PAS','LABORATORIO TECNOLOGICO PER IL MARMO-REPARTI SCULTURA,SMODELLATURA,DECORAZIONE E ORNATO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '952')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7165',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C430-PAS',title = 'LABORATORIO TECNOLOGICO PER L''EDILIZIA ED ESERCITAZIONI DI TOPOGRAFIA' WHERE idclassescuola = '952'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('952',null,'PS',null,'7165',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C430-PAS','LABORATORIO TECNOLOGICO PER L''EDILIZIA ED ESERCITAZIONI DI TOPOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '953')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7166',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C440-PAS',title = 'MASSOCHINESITERAPIA' WHERE idclassescuola = '953'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('953',null,'PS',null,'7166',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C440-PAS','MASSOCHINESITERAPIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '954')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7167',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C450-PAS',title = 'METODOLOGIE OPERATIVE NEI SERVIZI SOCIALI' WHERE idclassescuola = '954'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('954',null,'PS',null,'7167',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C450-PAS','METODOLOGIE OPERATIVE NEI SERVIZI SOCIALI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '955')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7168',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C460-PAS',title = 'REPARTI DI LAVORAZIONE PER IL MONTAGGIO CINEMATOGRAFICO E TELEVISIVO' WHERE idclassescuola = '955'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('955',null,'PS',null,'7168',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C460-PAS','REPARTI DI LAVORAZIONE PER IL MONTAGGIO CINEMATOGRAFICO E TELEVISIVO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '956')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7169',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C470-PAS',title = 'REPARTI DI LAVORAZIONE PER LA REGISTRAZIONE DEL SUONO' WHERE idclassescuola = '956'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('956',null,'PS',null,'7169',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C470-PAS','REPARTI DI LAVORAZIONE PER LA REGISTRAZIONE DEL SUONO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '957')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7170',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C480-PAS',title = 'REPARTI DI LAVORAZIONE PER LA RIPRESA CINEMATOGRAFICA E TELEVISIVA' WHERE idclassescuola = '957'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('957',null,'PS',null,'7170',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C480-PAS','REPARTI DI LAVORAZIONE PER LA RIPRESA CINEMATOGRAFICA E TELEVISIVA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '958')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7171',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C490-PAS',title = 'REPARTI DI LAVORAZIONE PER LE ARTI FOTOGRAFICHE' WHERE idclassescuola = '958'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('958',null,'PS',null,'7171',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C490-PAS','REPARTI DI LAVORAZIONE PER LE ARTI FOTOGRAFICHE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '959')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7172',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C500-PAS',title = 'TECNICA DEI SERVIZI ED ESERCITAZIONI PRATICHE DI CUCINA' WHERE idclassescuola = '959'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('959',null,'PS',null,'7172',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C500-PAS','TECNICA DEI SERVIZI ED ESERCITAZIONI PRATICHE DI CUCINA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '960')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7173',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C510-PAS',title = 'TECNICA DEI SERVIZI ED ESERCITAZIONI PRATICHE DI SALA BAR' WHERE idclassescuola = '960'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('960',null,'PS',null,'7173',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C510-PAS','TECNICA DEI SERVIZI ED ESERCITAZIONI PRATICHE DI SALA BAR')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '961')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7174',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'C520-PAS',title = 'TECNICA DEI SERVIZI E PRATICA OPERATIVA' WHERE idclassescuola = '961'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('961',null,'PS',null,'7174',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'C520-PAS','TECNICA DEI SERVIZI E PRATICA OPERATIVA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '962')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7176',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D601-PAS',title = 'ARTE DELLA LAVORAZIONE DEI METALLI' WHERE idclassescuola = '962'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('962',null,'PS',null,'7176',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D601-PAS','ARTE DELLA LAVORAZIONE DEI METALLI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '963')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7177',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D602-PAS',title = 'ARTE DELL''OREFICERIA, DELLA LAVORAZIONE DELLE PIETRE DURE E DELLE GEMME' WHERE idclassescuola = '963'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('963',null,'PS',null,'7177',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D602-PAS','ARTE DELL''OREFICERIA, DELLA LAVORAZIONE DELLE PIETRE DURE E DELLE GEMME')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '964')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7178',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D603-PAS',title = 'ARTE DEL DISEGNO D''ANIMAZIONE' WHERE idclassescuola = '964'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('964',null,'PS',null,'7178',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D603-PAS','ARTE DEL DISEGNO D''ANIMAZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '965')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7179',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D604-PAS',title = 'ARTE DELLA RIPRESA E MONTAGGIO PER IL DISEGNO ANIMATO' WHERE idclassescuola = '965'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('965',null,'PS',null,'7179',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D604-PAS','ARTE DELLA RIPRESA E MONTAGGIO PER IL DISEGNO ANIMATO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '966')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7180',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D605-PAS',title = 'ARTE DELLA TESSITURA E DELLA DECORAZIONE DEI TESSUTI' WHERE idclassescuola = '966'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('966',null,'PS',null,'7180',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D605-PAS','ARTE DELLA TESSITURA E DELLA DECORAZIONE DEI TESSUTI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '967')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7183',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D608-PAS',title = 'ARTE DELLA DECORAZIONE E COTTURA DEI PRODOTTI CERAMICI' WHERE idclassescuola = '967'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('967',null,'PS',null,'7183',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D608-PAS','ARTE DELLA DECORAZIONE E COTTURA DEI PRODOTTI CERAMICI')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '968')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7184',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D609-PAS',title = 'ARTE DELLA FORMATURA E FOGGIATURA' WHERE idclassescuola = '968'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('968',null,'PS',null,'7184',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D609-PAS','ARTE DELLA FORMATURA E FOGGIATURA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '969')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7185',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D610-PAS',title = 'ARTE DELLA FOTOGRAFIA E DELLA CINEMATOGRAFIA' WHERE idclassescuola = '969'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('969',null,'PS',null,'7185',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D610-PAS','ARTE DELLA FOTOGRAFIA E DELLA CINEMATOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '970')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7186',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D611-PAS',title = 'ARTE DELAA XILOGRAFIA, CALCOGRAFIA E LITOGRAFIA' WHERE idclassescuola = '970'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('970',null,'PS',null,'7186',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D611-PAS','ARTE DELAA XILOGRAFIA, CALCOGRAFIA E LITOGRAFIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '971')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7187',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D612-PAS',title = 'ARTE DELLA SERIGRAFIA E DELLA FOTOINCISIONE' WHERE idclassescuola = '971'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('971',null,'PS',null,'7187',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D612-PAS','ARTE DELLA SERIGRAFIA E DELLA FOTOINCISIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '972')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7188',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D613-PAS',title = 'ARTE DELLA TIPOGRAFIA E DELLA GRAFICA PUBBLICITARIA' WHERE idclassescuola = '972'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('972',null,'PS',null,'7188',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D613-PAS','ARTE DELLA TIPOGRAFIA E DELLA GRAFICA PUBBLICITARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '973')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7189',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D614-PAS',title = 'ARTE DEL TAGLIO E CONFEZIONE' WHERE idclassescuola = '973'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('973',null,'PS',null,'7189',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D614-PAS','ARTE DEL TAGLIO E CONFEZIONE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '974')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7190',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D615-PAS',title = 'ARTE DELLA DECORAZIONE PITTORICA E SCENOGRAFICA' WHERE idclassescuola = '974'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('974',null,'PS',null,'7190',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D615-PAS','ARTE DELLA DECORAZIONE PITTORICA E SCENOGRAFICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '975')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7191',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D616-PAS',title = 'ARTE DELLA MODELLISTICA, DELL''ARREDAMENTO E DELLA SCENOTECNICA' WHERE idclassescuola = '975'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('975',null,'PS',null,'7191',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D616-PAS','ARTE DELLA MODELLISTICA, DELL''ARREDAMENTO E DELLA SCENOTECNICA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '976')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7193',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D618-PAS',title = 'ARTE DELL''EBANISTERIA, DELL''INTAGLIO E DELL''INTARSIO' WHERE idclassescuola = '976'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('976',null,'PS',null,'7193',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D618-PAS','ARTE DELL''EBANISTERIA, DELL''INTAGLIO E DELL''INTARSIO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '977')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7194',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D619-PAS',title = 'ARTE DELLE LACCHE, DELLA DORATURA E DEL RESTAURO' WHERE idclassescuola = '977'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('977',null,'PS',null,'7194',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D619-PAS','ARTE DELLE LACCHE, DELLA DORATURA E DEL RESTAURO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '978')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7195',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D620-PAS',title = 'ARTE DEL MOSAICO E DEL COMMESSO' WHERE idclassescuola = '978'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('978',null,'PS',null,'7195',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D620-PAS','ARTE DEL MOSAICO E DEL COMMESSO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '979')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7196',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D621-PAS',title = 'ARTE DELLA LAVORAZIONE DEL MARMO E DELLA PIETRA' WHERE idclassescuola = '979'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('979',null,'PS',null,'7196',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D621-PAS','ARTE DELLA LAVORAZIONE DEL MARMO E DELLA PIETRA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '980')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7197',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'D622-PAS',title = 'LABORATORIO TECNOLOGICO DELLE ARTI DELLA CERAMICA DEL VETRO E DEL CRISTALLO' WHERE idclassescuola = '980'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('980',null,'PS',null,'7197',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'D622-PAS','LABORATORIO TECNOLOGICO DELLE ARTI DELLA CERAMICA DEL VETRO E DEL CRISTALLO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '981')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7366',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AB77-PAS',title = 'Chitarra' WHERE idclassescuola = '981'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('981',null,'PS',null,'7366',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AB77-PAS','Chitarra')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '982')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7368',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AC77-PAS',title = 'Clarinetto' WHERE idclassescuola = '982'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('982',null,'PS',null,'7368',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AC77-PAS','Clarinetto')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '983')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7370',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AD77-PAS',title = 'Corno' WHERE idclassescuola = '983'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('983',null,'PS',null,'7370',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AD77-PAS','Corno')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '984')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7371',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AE77-PAS',title = 'Fagotto' WHERE idclassescuola = '984'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('984',null,'PS',null,'7371',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AE77-PAS','Fagotto')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '985')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7373',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AF77-PAS',title = 'Fisarmonica' WHERE idclassescuola = '985'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('985',null,'PS',null,'7373',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AF77-PAS','Fisarmonica')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '986')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7375',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AG77-PAS',title = 'Flauto' WHERE idclassescuola = '986'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('986',null,'PS',null,'7375',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AG77-PAS','Flauto')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '987')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7382',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AH77-PAS',title = 'Oboe' WHERE idclassescuola = '987'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('987',null,'PS',null,'7382',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AH77-PAS','Oboe')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '988')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7385',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AI77-PAS',title = 'Percussioni' WHERE idclassescuola = '988'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('988',null,'PS',null,'7385',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AI77-PAS','Percussioni')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '989')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7387',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AJ77-PAS',title = 'Pianoforte' WHERE idclassescuola = '989'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('989',null,'PS',null,'7387',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AJ77-PAS','Pianoforte')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '990')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7389',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AK77-PAS',title = 'Saxofono' WHERE idclassescuola = '990'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('990',null,'PS',null,'7389',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AK77-PAS','Saxofono')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '991')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7392',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AL77-PAS',title = 'Tromba' WHERE idclassescuola = '991'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('991',null,'PS',null,'7392',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AL77-PAS','Tromba')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '992')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7395',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AM77-PAS',title = 'Violino' WHERE idclassescuola = '992'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('992',null,'PS',null,'7395',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AM77-PAS','Violino')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '993')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7420',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AA77-PAS',title = 'Arpa' WHERE idclassescuola = '993'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('993',null,'PS',null,'7420',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AA77-PAS','Arpa')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '994')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7421',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AN77-PAS',title = 'Violoncello' WHERE idclassescuola = '994'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('994',null,'PS',null,'7421',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AN77-PAS','Violoncello')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '995')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7422',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'A845-PAS',title = 'LINGUA STRANIERA (SLOVENO) ' WHERE idclassescuola = '995'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('995',null,'PS',null,'7422',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'A845-PAS','LINGUA STRANIERA (SLOVENO) ')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '996')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7423',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AA46-PAS',title = 'LINGUA E CIVILTA'' STRANIERA CINESE' WHERE idclassescuola = '996'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('996',null,'PS',null,'7423',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AA46-PAS','LINGUA E CIVILTA'' STRANIERA CINESE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '997')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7424',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AB46-PAS',title = 'LINGUA E CIVILTA'' STRANIERA GIAPPONESE' WHERE idclassescuola = '997'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('997',null,'PS',null,'7424',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AB46-PAS','LINGUA E CIVILTA'' STRANIERA GIAPPONESE')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '998')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'CT',idcorsostudionorma = null,indicecineca = '7900',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'CSS',title = 'Classe generica per il conseguimento della specializzazione per le attivit? di sostegno didattico' WHERE idclassescuola = '998'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('998',null,'CT',null,'7900',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'CSS','Classe generica per il conseguimento della specializzazione per le attivit? di sostegno didattico')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '999')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'CL',idcorsostudionorma = null,indicecineca = '7901',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'CLIL-60',title = 'Generica classe per Perfezionamento insegnamento di disciplina non linguistica in lingua (60 CFU)' WHERE idclassescuola = '999'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('999',null,'CL',null,'7901',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'CLIL-60','Generica classe per Perfezionamento insegnamento di disciplina non linguistica in lingua (60 CFU)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '1000')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'CL',idcorsostudionorma = null,indicecineca = '7902',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'CLIL-20',title = 'Generica classe per Perfezionamento insegnamento di disciplina non linguistica in lingua (20 CFU)' WHERE idclassescuola = '1000'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('1000',null,'CL',null,'7902',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'CLIL-20','Generica classe per Perfezionamento insegnamento di disciplina non linguistica in lingua (20 CFU)')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '1001')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7990',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'AA00-PAS',title = 'INSEGNAMENTO SCUOLA PRIMARIA' WHERE idclassescuola = '1001'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('1001',null,'PS',null,'7990',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'AA00-PAS','INSEGNAMENTO SCUOLA PRIMARIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '1002')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'PS',idcorsostudionorma = null,indicecineca = '7991',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = 'EE00-PAS',title = 'INSEGNAMENTO SCUOLA INFANZIA' WHERE idclassescuola = '1002'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('1002',null,'PS',null,'7991',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'EE00-PAS','INSEGNAMENTO SCUOLA INFANZIA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '1003')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = null,idcorsostudionorma = null,indicecineca = '99997',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '99997',title = 'Classe generica per le scuole di specializzazione riformate' WHERE idclassescuola = '1003'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('1003',null,null,null,'99997',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'99997','Classe generica per le scuole di specializzazione riformate')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '1004')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = null,idcorsostudionorma = null,indicecineca = '99998',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '99998',title = 'Classe non richiesta' WHERE idclassescuola = '1004'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('1004',null,null,null,'99998',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'99998','Classe non richiesta')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '1005')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = null,idcorsostudionorma = null,indicecineca = '99999',lt = {ts '2018-11-06 11:35:00.653'},lu = 'ferdinando',obbform = null,prospocc = null,sigla = '99999',title = 'Classe non definita' WHERE idclassescuola = '1005'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('1005',null,null,null,'99999',{ts '2018-11-06 11:35:00.653'},'ferdinando',null,null,'99999','Classe non definita')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '1007')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '8',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = 'Al termine degli studi relativi al Diploma Accademico di primo livello in Arpa rinascimentale e
barocca, gli studenti devono aver acquisito le conoscenze delle tecniche storiche e le competenze
specifiche tali da consentire loro di realizzare concretamente la propria idea artistica. A tal fine sarà
dato particolare rilievo allo studio del repertorio più rappresentativo dello strumento - incluso quello
d’insieme - e delle relative prassi esecutive, anche con la finalità di sviluppare la capacità dello
studente di interagire all’interno di gruppi musicali diversamente composti. Tali obiettivi dovranno
essere raggiunti anche favorendo lo sviluppo della capacità percettiva dell’udito e di
memorizzazione e con l’acquisizione di specifiche conoscenze relative ai modelli organizzativi,
compositivi ed analitici della musica ed alla loro interazione.
Specifica cura dovrà essere dedicata all’acquisizione di adeguate tecniche di controllo posturale ed
emozionale. Al termine del Triennio gli studenti devono aver acquisito una conoscenza approfondita
degli aspetti stilistici, storici estetici generali e relativi al proprio specifico indirizzo. Inoltre, con
riferimento alla specificità dei singoli corsi, lo studente dovrà possedere adeguate competenze
riferite all’ambito dell’improvvisazione e all’ornamentazione. E’ obiettivo formativo del corso anche
l’acquisizione di adeguate competenze nel campo dell’informatica musicale nonché quelle relative
ad una seconda lingua comunitaria. ',prospocc = 'Il corso offre allo studente possibilità di impiego nei seguenti ambiti:
- Strumentista solista
- Strumentista in gruppi da camera
- Strumentista in formazioni orchestrali
- Strumentista in formazioni orchestrali per il teatro musicale
- Continuista nel repertorio da camera e nel teatro musicale ',sigla = 'DCPL02',title = 'SCUOLA DI ARPA -  ARPA RINASCIMENTALE E BAROCCA' WHERE idclassescuola = '1007'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('1007',null,'A1','8',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','Al termine degli studi relativi al Diploma Accademico di primo livello in Arpa rinascimentale e
barocca, gli studenti devono aver acquisito le conoscenze delle tecniche storiche e le competenze
specifiche tali da consentire loro di realizzare concretamente la propria idea artistica. A tal fine sarà
dato particolare rilievo allo studio del repertorio più rappresentativo dello strumento - incluso quello
d’insieme - e delle relative prassi esecutive, anche con la finalità di sviluppare la capacità dello
studente di interagire all’interno di gruppi musicali diversamente composti. Tali obiettivi dovranno
essere raggiunti anche favorendo lo sviluppo della capacità percettiva dell’udito e di
memorizzazione e con l’acquisizione di specifiche conoscenze relative ai modelli organizzativi,
compositivi ed analitici della musica ed alla loro interazione.
Specifica cura dovrà essere dedicata all’acquisizione di adeguate tecniche di controllo posturale ed
emozionale. Al termine del Triennio gli studenti devono aver acquisito una conoscenza approfondita
degli aspetti stilistici, storici estetici generali e relativi al proprio specifico indirizzo. Inoltre, con
riferimento alla specificità dei singoli corsi, lo studente dovrà possedere adeguate competenze
riferite all’ambito dell’improvvisazione e all’ornamentazione. E’ obiettivo formativo del corso anche
l’acquisizione di adeguate competenze nel campo dell’informatica musicale nonché quelle relative
ad una seconda lingua comunitaria. ','Il corso offre allo studente possibilità di impiego nei seguenti ambiti:
- Strumentista solista
- Strumentista in gruppi da camera
- Strumentista in formazioni orchestrali
- Strumentista in formazioni orchestrali per il teatro musicale
- Continuista nel repertorio da camera e nel teatro musicale ','DCPL02','SCUOLA DI ARPA -  ARPA RINASCIMENTALE E BAROCCA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '1008')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '8',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = 'Al termine degli studi relativi al Diploma Accademico di primo livello in Basso Elettrico, gli studenti
devono aver acquisito le conoscenze delle tecniche e le competenze specifiche tali da consentire loro
di realizzare concretamente la propria idea artistica. A tal fine sarà dato particolare rilievo allo studio
del repertorio più rappresentativo dello strumento - incluso quello d’insieme - e delle relative prassi
esecutive, anche con la finalità di sviluppare la capacità dello studente di interagire all’interno di
gruppi musicali diversamente composti. Tali obiettivi dovranno essere raggiunti anche favorendo lo
sviluppo della capacità percettiva dell’udito e di memorizzazione e con l’acquisizione di specifiche
conoscenze relative ai modelli organizzativi, compositivi ed analitici della musica ed alla loro
interazione.
Specifica cura dovrà essere dedicata all’acquisizione di adeguate tecniche di controllo posturale ed
emozionale. Al termine del Triennio gli studenti devono aver acquisito una conoscenza approfondita
degli aspetti stilistici, storici estetici generali e relativi al proprio specifico indirizzo. Inoltre, con
riferimento alla specificità dei singoli corsi, lo studente dovrà possedere adeguate competenze riferite
all’ambito dell’improvvisazione. E’ obiettivo formativo del corso anche l’acquisizione di adeguate
competenze nel campo dell’informatica musicale nonché quelle relative ad una seconda lingua
comunitaria.',prospocc = 'Il corso offre allo studente possibilità di impiego nei seguenti ambiti:
- Strumentista solista jazz e popular
- Strumentista in gruppi jazz e popular
- Strumentista in formazioni orchestrali jazz e popular',sigla = 'DCPL03',title = 'SCUOLA DI JAZZ - BASSO ELETTRICO' WHERE idclassescuola = '1008'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('1008',null,'A1','8',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','Al termine degli studi relativi al Diploma Accademico di primo livello in Basso Elettrico, gli studenti
devono aver acquisito le conoscenze delle tecniche e le competenze specifiche tali da consentire loro
di realizzare concretamente la propria idea artistica. A tal fine sarà dato particolare rilievo allo studio
del repertorio più rappresentativo dello strumento - incluso quello d’insieme - e delle relative prassi
esecutive, anche con la finalità di sviluppare la capacità dello studente di interagire all’interno di
gruppi musicali diversamente composti. Tali obiettivi dovranno essere raggiunti anche favorendo lo
sviluppo della capacità percettiva dell’udito e di memorizzazione e con l’acquisizione di specifiche
conoscenze relative ai modelli organizzativi, compositivi ed analitici della musica ed alla loro
interazione.
Specifica cura dovrà essere dedicata all’acquisizione di adeguate tecniche di controllo posturale ed
emozionale. Al termine del Triennio gli studenti devono aver acquisito una conoscenza approfondita
degli aspetti stilistici, storici estetici generali e relativi al proprio specifico indirizzo. Inoltre, con
riferimento alla specificità dei singoli corsi, lo studente dovrà possedere adeguate competenze riferite
all’ambito dell’improvvisazione. E’ obiettivo formativo del corso anche l’acquisizione di adeguate
competenze nel campo dell’informatica musicale nonché quelle relative ad una seconda lingua
comunitaria.','Il corso offre allo studente possibilità di impiego nei seguenti ambiti:
- Strumentista solista jazz e popular
- Strumentista in gruppi jazz e popular
- Strumentista in formazioni orchestrali jazz e popular','DCPL03','SCUOLA DI JAZZ - BASSO ELETTRICO')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '1010')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '8',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = 'Al termine degli studi relativi al Diploma Accademico di primo livello in Basso tuba, gli studenti
devono aver acquisito le conoscenze delle tecniche e le competenze specifiche tali da consentire
loro di realizzare concretamente la propria idea artistica. A tal fine sarà dato particolare rilievo allo
studio del repertorio più rappresentativo dello strumento - incluso quello d’insieme - e delle
relative prassi esecutive, anche con la finalità di sviluppare la capacità dello studente di interagire
all’interno di gruppi musicali diversamente composti. Tali obiettivi dovranno essere raggiunti anche
favorendo lo sviluppo della capacità percettiva dell’udito e di memorizzazione e con l’acquisizione
di specifiche conoscenze relative ai modelli organizzativi, compositivi ed analitici della musica ed
alla loro interazione.
Specifica cura dovrà essere dedicata all’acquisizione di adeguate tecniche di controllo posturale ed
emozionale. Al termine del Triennio gli studenti devono aver acquisito una conoscenza
approfondita degli aspetti stilistici, storici estetici generali e relativi al proprio specifico indirizzo.
Inoltre, con riferimento alla specificità dei singoli corsi, lo studente dovrà possedere adeguate
competenze riferite all’ambito dell’improvvisazione. E’ obiettivo formativo del corso anche
l’acquisizione di adeguate competenze nel campo dell’informatica musicale nonché quelle relative
ad una seconda lingua comunitaria.',prospocc = 'Il corso offre allo studente possibilità di impiego nei seguenti ambiti:
- Strumentista solista
- Strumentista in gruppi da camera
- Strumentista in formazioni orchestrali da camera
- Strumentista in formazioni orchestrali sinfoniche
- Strumentista in formazioni orchestrali per il teatro musicale
- Strumentista in formazioni orchestrali a fiato ',sigla = 'DCPL04',title = 'SCUOLA DI BASSO TUBA' WHERE idclassescuola = '1010'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('1010',null,'A1','8',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','Al termine degli studi relativi al Diploma Accademico di primo livello in Basso tuba, gli studenti
devono aver acquisito le conoscenze delle tecniche e le competenze specifiche tali da consentire
loro di realizzare concretamente la propria idea artistica. A tal fine sarà dato particolare rilievo allo
studio del repertorio più rappresentativo dello strumento - incluso quello d’insieme - e delle
relative prassi esecutive, anche con la finalità di sviluppare la capacità dello studente di interagire
all’interno di gruppi musicali diversamente composti. Tali obiettivi dovranno essere raggiunti anche
favorendo lo sviluppo della capacità percettiva dell’udito e di memorizzazione e con l’acquisizione
di specifiche conoscenze relative ai modelli organizzativi, compositivi ed analitici della musica ed
alla loro interazione.
Specifica cura dovrà essere dedicata all’acquisizione di adeguate tecniche di controllo posturale ed
emozionale. Al termine del Triennio gli studenti devono aver acquisito una conoscenza
approfondita degli aspetti stilistici, storici estetici generali e relativi al proprio specifico indirizzo.
Inoltre, con riferimento alla specificità dei singoli corsi, lo studente dovrà possedere adeguate
competenze riferite all’ambito dell’improvvisazione. E’ obiettivo formativo del corso anche
l’acquisizione di adeguate competenze nel campo dell’informatica musicale nonché quelle relative
ad una seconda lingua comunitaria.','Il corso offre allo studente possibilità di impiego nei seguenti ambiti:
- Strumentista solista
- Strumentista in gruppi da camera
- Strumentista in formazioni orchestrali da camera
- Strumentista in formazioni orchestrali sinfoniche
- Strumentista in formazioni orchestrali per il teatro musicale
- Strumentista in formazioni orchestrali a fiato ','DCPL04','SCUOLA DI BASSO TUBA')
GO

IF exists(SELECT * FROM [classescuola] WHERE idclassescuola = '1011')
UPDATE [classescuola] SET idclassescuolaarea = null,idclassescuolakind = 'A1',idcorsostudionorma = '8',indicecineca = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',obbform = 'Al termine degli studi relativi al Diploma Accademico di primo livello in Batteria e percussioni
jazz, gli studenti devono aver acquisito le conoscenze delle tecniche e le competenze specifiche
tali da consentire loro di realizzare concretamente la propria idea artistica. A tal fine sarà dato
particolare rilievo allo studio del repertorio più rappresentativo del canto per la popular music -
incluso quello d’insieme - e delle relative prassi esecutive, anche con la finalità di sviluppare la
capacità dello studente di interagire all’interno di gruppi musicali diversamente composti. Tali
obiettivi dovranno essere raggiunti anche favorendo lo sviluppo della capacità percettiva dell’udito
e di memorizzazione e con l’acquisizione di specifiche conoscenze relative ai modelli organizzativi,
compositivi ed analitici della musica ed alla loro interazione.
Specifica cura dovrà essere dedicata all’acquisizione di adeguate tecniche di controllo posturale ed
emozionale. Al termine del Triennio gli studenti devono aver acquisito una conoscenza
approfondita degli aspetti stilistici, storici estetici generali e relativi al proprio specifico indirizzo.
Inoltre, con riferimento alla specificità dei singoli corsi, lo studente dovrà possedere adeguate
competenze riferite all’ambito dell’improvvisazione. E’ obiettivo formativo del corso anche
l’acquisizione di adeguate competenze nel campo dell’informatica musicale nonché quelle relative
ad una seconda lingua comunitaria. ',prospocc = 'Il corso offre allo studente possibilità di impiego nei seguenti ambiti:
- Strumentista solista jazz e popular
- Strumentista in gruppi jazz e popular
- Strumentista in formazioni orchestrali jazz e popular ',sigla = 'DCPL05',title = 'SCUOLA DI JAZZ - BATTERIA E PERCUSSIONI JAZZ' WHERE idclassescuola = '1011'
ELSE
INSERT INTO [classescuola] (idclassescuola,idclassescuolaarea,idclassescuolakind,idcorsostudionorma,indicecineca,lt,lu,obbform,prospocc,sigla,title) VALUES ('1011',null,'A1','8',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','Al termine degli studi relativi al Diploma Accademico di primo livello in Batteria e percussioni
jazz, gli studenti devono aver acquisito le conoscenze delle tecniche e le competenze specifiche
tali da consentire loro di realizzare concretamente la propria idea artistica. A tal fine sarà dato
particolare rilievo allo studio del repertorio più rappresentativo del canto per la popular music -
incluso quello d’insieme - e delle relative prassi esecutive, anche con la finalità di sviluppare la
capacità dello studente di interagire all’interno di gruppi musicali diversamente composti. Tali
obiettivi dovranno essere raggiunti anche favorendo lo sviluppo della capacità percettiva dell’udito
e di memorizzazione e con l’acquisizione di specifiche conoscenze relative ai modelli organizzativi,
compositivi ed analitici della musica ed alla loro interazione.
Specifica cura dovrà essere dedicata all’acquisizione di adeguate tecniche di controllo posturale ed
emozionale. Al termine del Triennio gli studenti devono aver acquisito una conoscenza
approfondita degli aspetti stilistici, storici estetici generali e relativi al proprio specifico indirizzo.
Inoltre, con riferimento alla specificità dei singoli corsi, lo studente dovrà possedere adeguate
competenze riferite all’ambito dell’improvvisazione. E’ obiettivo formativo del corso anche
l’acquisizione di adeguate competenze nel campo dell’informatica musicale nonché quelle relative
ad una seconda lingua comunitaria. ','Il corso offre allo studente possibilità di impiego nei seguenti ambiti:
- Strumentista solista jazz e popular
- Strumentista in gruppi jazz e popular
- Strumentista in formazioni orchestrali jazz e popular ','DCPL05','SCUOLA DI JAZZ - BATTERIA E PERCUSSIONI JAZZ')
GO

