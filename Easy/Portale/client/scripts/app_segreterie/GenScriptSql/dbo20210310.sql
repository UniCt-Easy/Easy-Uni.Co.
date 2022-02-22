
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


-- CREAZIONE TABELLA contrattokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contrattokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[contrattokind] (
idcontrattokind int NOT NULL,
active char(1) NOT NULL,
assegnoaggiuntivo char(1) NULL,
costolordoannuo decimal(9,2) NULL,
costolordoannuooneri decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(256) NULL,
elementoperequativo char(1) NULL,
indennitadiateneo char(1) NULL,
indennitadiposizione char(1) NULL,
indvacancacontrattuale char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
oremaxcompitididatempoparziale int NULL,
oremaxcompitididatempopieno int NULL,
oremaxdidatempoparziale int NULL,
oremaxdidatempopieno int NULL,
oremaxgg int NULL,
oremaxtempoparziale int NULL,
oremaxtempopieno int NULL,
oremincompitididatempoparziale int NULL,
oremincompitididatempopieno int NULL,
oremindidatempoparziale int NULL,
oremindidatempopieno int NULL,
oremintempoparziale int NULL,
oremintempopieno int NULL,
orestraordinariemax int NULL,
parttime char(1) NULL,
scatto char(1) NULL,
sortcode int NOT NULL,
tempdef char(1) NULL,
title varchar(50) NOT NULL,
totaletredicesima char(1) NULL,
tredicesimaindennitaintegrativaspeciale char(1) NULL,
 CONSTRAINT xpkcontrattokind PRIMARY KEY (idcontrattokind
)
)
END
GO

-- VERIFICA STRUTTURA contrattokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'assegnoaggiuntivo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD assegnoaggiuntivo char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN assegnoaggiuntivo char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'costolordoannuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD costolordoannuo decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN costolordoannuo decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'costolordoannuooneri' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD costolordoannuooneri decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN costolordoannuooneri decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'elementoperequativo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD elementoperequativo char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN elementoperequativo char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'indennitadiateneo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD indennitadiateneo char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN indennitadiateneo char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'indennitadiposizione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD indennitadiposizione char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN indennitadiposizione char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'indvacancacontrattuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD indvacancacontrattuale char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN indvacancacontrattuale char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxcompitididatempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxcompitididatempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxcompitididatempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxcompitididatempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxcompitididatempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxcompitididatempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxdidatempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxdidatempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxdidatempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxdidatempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxdidatempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxdidatempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxgg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxgg int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxgg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxtempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxtempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxtempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxtempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxtempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxtempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremincompitididatempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremincompitididatempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremincompitididatempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremincompitididatempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremincompitididatempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremincompitididatempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremindidatempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremindidatempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremindidatempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremindidatempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremindidatempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremindidatempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremintempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremintempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremintempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremintempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremintempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremintempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'orestraordinariemax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD orestraordinariemax int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN orestraordinariemax int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'parttime' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD parttime char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN parttime char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'scatto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD scatto char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN scatto char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'tempdef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD tempdef char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN tempdef char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN title varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'totaletredicesima' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD totaletredicesima char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN totaletredicesima char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'tredicesimaindennitaintegrativaspeciale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD tredicesimaindennitaintegrativaspeciale char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN tredicesimaindennitaintegrativaspeciale char(1) NULL
GO


-- GENERAZIONE DATI PER contrattokind --
IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '1')
UPDATE [contrattokind] SET active = 'N',assegnoaggiuntivo = null,costolordoannuo = '68371.12',costolordoannuooneri = '68371.12',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'CCNL 15.03.2001 del comparto Scuola, tabella A, colonna 9 (ex livello VIII);',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-10-06 17:54:18.603'},lu = 'riccardotest{ADMSEG1}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = '8',oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '250',oremincompitididatempopieno = '350',oremindidatempoparziale = '90',oremindidatempopieno = '120',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',scatto = null,sortcode = '1',tempdef = 'S',title = 'Professore di I fascia ordinario',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '1'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,scatto,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('1','N',null,'68371.12','68371.12',{ts '2018-06-11 11:35:00.653'},'ferdinando','CCNL 15.03.2001 del comparto Scuola, tabella A, colonna 9 (ex livello VIII);',null,null,null,null,{ts '2020-10-06 17:54:18.603'},'riccardotest{ADMSEG1}',null,null,null,null,'8','1228','1720','250','350','90','120',null,null,null,'N',null,'1','S','Professore di I fascia ordinario',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '2')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '69',costolordoannuooneri = '40000',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'CCNL 15.03.2001 del comparto Scuola, tabella A, colonne 8 e 6 (ex livello VII ed ex livello VI bis);',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:32:46.783'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '250',oremincompitididatempopieno = '350',oremindidatempoparziale = '90',oremindidatempopieno = '120',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',scatto = null,sortcode = '4',tempdef = 'S',title = 'Professore di II fascia associato confermato',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '2'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,scatto,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('2','S',null,'69','40000',{ts '2018-06-11 11:35:00.653'},'ferdinando','CCNL 15.03.2001 del comparto Scuola, tabella A, colonne 8 e 6 (ex livello VII ed ex livello VI bis);',null,null,null,null,{ts '2020-05-21 10:32:46.783'},'riccardotest{0001}',null,null,null,null,null,'1228','1720','250','350','90','120',null,null,null,'N',null,'4','S','Professore di II fascia associato confermato',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '3')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Dirigente o funzionario tecnico-scientifico, scientifico o amministrativo delle amministrazioni preposte alla tutela dei beni culturali;',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-04-29 18:44:18.550'},lu = 'riccardotest',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'S',scatto = null,sortcode = '13',tempdef = 'N',title = 'Funzionario beni culturali',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '3'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,scatto,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('3','S',null,null,'40000',{ts '2018-06-11 11:35:00.653'},'ferdinando','Dirigente o funzionario tecnico-scientifico, scientifico o amministrativo delle amministrazioni preposte alla tutela dei beni culturali;',null,null,null,null,{ts '2020-04-29 18:44:18.550'},'riccardotest',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'S',null,'13','N','Funzionario beni culturali',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '4')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2018-06-11 17:35:00.653'},cu = 'ferdinando',description = 'Studioso o professionista di chiara fama',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-04-29 18:44:26.160'},lu = 'riccardotest',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'S',scatto = null,sortcode = '12',tempdef = 'N',title = 'Studioso o professionista di chiara fama',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '4'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,scatto,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('4','S',null,null,'40000',{ts '2018-06-11 17:35:00.653'},'ferdinando','Studioso o professionista di chiara fama',null,null,null,null,{ts '2020-04-29 18:44:26.160'},'riccardotest',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'S',null,'12','N','Studioso o professionista di chiara fama',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '7')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '40',costolordoannuooneri = '40000',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Ricercatore a tempo indeterminato (ruolo ad esaurimento)',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:35:34.217'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = '200',oremaxcompitididatempopieno = '350',oremaxdidatempoparziale = '200',oremaxdidatempopieno = '350',oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '200',oremincompitididatempopieno = '300',oremindidatempoparziale = '60',oremindidatempopieno = '80',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',scatto = null,sortcode = '5',tempdef = 'S',title = 'Ricercatore Universitario',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '7'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,scatto,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('7','S',null,'40','40000',{ts '2018-06-11 11:35:00.653'},'ferdinando','Ricercatore a tempo indeterminato (ruolo ad esaurimento)',null,null,null,null,{ts '2020-05-21 10:35:34.217'},'riccardotest{0001}','200','350','200','350',null,'1228','1720','200','300','60','80',null,null,null,'N',null,'5','S','Ricercatore Universitario',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '8')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '40',costolordoannuooneri = '40000',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Ricercatore a tempo determinato di cui all’articolo 24, comma 3, lettera b) Legge 240 del 2010. Si tratta di contratti triennali non rinnovabili al termine dei quali è possibile accedere direttamente al ruolo di Professore di II fascia.',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:44:02.570'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = '350',oremaxdidatempoparziale = null,oremaxdidatempopieno = '120',oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = '60',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',scatto = null,sortcode = '7',tempdef = 'N',title = 'Ricercatore a tempo determinato 240/2010 lett. b ',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '8'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,scatto,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('8','S',null,'40','40000',{ts '2018-06-11 11:35:00.653'},'ferdinando','Ricercatore a tempo determinato di cui all’articolo 24, comma 3, lettera b) Legge 240 del 2010. Si tratta di contratti triennali non rinnovabili al termine dei quali è possibile accedere direttamente al ruolo di Professore di II fascia.',null,null,null,null,{ts '2020-05-21 10:44:02.570'},'riccardotest{0001}',null,'350',null,'120',null,null,'1720',null,null,null,'60',null,null,null,'N',null,'7','N','Ricercatore a tempo determinato 240/2010 lett. b ',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '9')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2020-04-29 18:15:37.457'},cu = 'riccardotest',description = 'Assistenti universitari (ruolo ad esaurimento)',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-04-29 18:15:37.457'},lu = 'riccardotest',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'S',scatto = null,sortcode = '9',tempdef = 'N',title = 'Assistenti universitari',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '9'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,scatto,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('9','S',null,null,'40000',{ts '2020-04-29 18:15:37.457'},'riccardotest','Assistenti universitari (ruolo ad esaurimento)',null,null,null,null,{ts '2020-04-29 18:15:37.457'},'riccardotest',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'S',null,'9','N','Assistenti universitari',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '10')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '40',costolordoannuooneri = '40000',ct = {ts '2020-04-29 18:20:27.437'},cu = 'riccardotest',description = 'Ricercatore a tempo determinato di cui all’articolo 24, comma 3, lettera a) Legge 240 del 2010. Si tratta di contratti della durata di 3 anni, rinnovabile per ulteriori due 2 anni.',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:43:04.853'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = '200',oremaxcompitididatempopieno = '350',oremaxdidatempoparziale = '80',oremaxdidatempopieno = '120',oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = '20',oremindidatempopieno = '30',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',scatto = null,sortcode = '6',tempdef = 'S',title = 'Ricercatore a tempo determinato 240/2010 lett. a',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '10'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,scatto,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('10','S',null,'40','40000',{ts '2020-04-29 18:20:27.437'},'riccardotest','Ricercatore a tempo determinato di cui all’articolo 24, comma 3, lettera a) Legge 240 del 2010. Si tratta di contratti della durata di 3 anni, rinnovabile per ulteriori due 2 anni.',null,null,null,null,{ts '2020-05-21 10:43:04.853'},'riccardotest{0001}','200','350','80','120',null,'1228','1720',null,null,'20','30',null,null,null,'N',null,'6','S','Ricercatore a tempo determinato 240/2010 lett. a',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '11')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'S',costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2020-04-29 18:34:23.643'},cu = 'riccardotest',description = 'Ogni contratto individuale può avere una durata minima di un anno e massima di  tre anni. La durata complessiva dei rapporti come assegnista di ricerca del singolo soggetto non può comunque essere superiore a sei anni.',elementoperequativo = 'S',indennitadiateneo = 'S',indennitadiposizione = 'S',indvacancacontrattuale = 'S',lt = {ts '2021-02-23 17:14:20.070'},lu = 'ferdinando.giannetti{SEGADM}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',scatto = 'S',sortcode = '10',tempdef = 'N',title = 'Assegnista di ricerca',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = 'S' WHERE idcontrattokind = '11'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,scatto,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('11','S','S',null,'40000',{ts '2020-04-29 18:34:23.643'},'riccardotest','Ogni contratto individuale può avere una durata minima di un anno e massima di  tre anni. La durata complessiva dei rapporti come assegnista di ricerca del singolo soggetto non può comunque essere superiore a sei anni.','S','S','S','S',{ts '2021-02-23 17:14:20.070'},'ferdinando.giannetti{SEGADM}',null,null,null,null,null,null,'1720',null,null,null,null,null,null,null,'N','S','10','N','Assegnista di ricerca',null,'S')
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '12')
UPDATE [contrattokind] SET active = 'N',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2020-04-29 18:40:30.430'},cu = 'riccardotest',description = 'CCNL 15.03.2001 del comparto Scuola, tabella A, colonna 9 (ex livello VIII); Professore straordinario a tempo determinato prevista dall’articolo 1, comma 12 della Legge 230 del 2005.',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:28:50.070'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '250',oremincompitididatempopieno = '350',oremindidatempoparziale = '90',oremindidatempopieno = '120',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',scatto = null,sortcode = '2',tempdef = 'S',title = 'Professore di I fascia straordinario',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '12'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,scatto,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('12','N',null,null,'40000',{ts '2020-04-29 18:40:30.430'},'riccardotest','CCNL 15.03.2001 del comparto Scuola, tabella A, colonna 9 (ex livello VIII); Professore straordinario a tempo determinato prevista dall’articolo 1, comma 12 della Legge 230 del 2005.',null,null,null,null,{ts '2020-05-21 10:28:50.070'},'riccardotest{0001}',null,null,null,null,null,'1228','1720','250','350','90','120',null,null,null,'N',null,'2','S','Professore di I fascia straordinario',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '13')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '69000',costolordoannuooneri = '69000',ct = {ts '2020-04-29 18:42:56.617'},cu = 'riccardotest',description = 'CCNL 15.03.2001 del comparto Scuola, tabella A, colonne 8 e 6 (ex livello VII ed ex livello VI bis);',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-10-07 11:39:45.057'},lu = 'riccardotest{ADMSEG1}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '250',oremincompitididatempopieno = '350',oremindidatempoparziale = '90',oremindidatempopieno = '120',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',scatto = null,sortcode = '3',tempdef = 'S',title = 'Professore di II fascia associato non confermato',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '13'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,scatto,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('13','S',null,'69000','69000',{ts '2020-04-29 18:42:56.617'},'riccardotest','CCNL 15.03.2001 del comparto Scuola, tabella A, colonne 8 e 6 (ex livello VII ed ex livello VI bis);',null,null,null,null,{ts '2020-10-07 11:39:45.057'},'riccardotest{ADMSEG1}',null,null,null,null,null,'1228','1720','250','350','90','120',null,null,null,'N',null,'3','S','Professore di II fascia associato non confermato',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '14')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '40000',costolordoannuooneri = '40000',ct = {ts '2020-05-20 11:32:07.807'},cu = 'riccardotest{0001}',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-10-21 15:27:32.890'},lu = 'riccardotest{ADMSEG1}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = '9',oremaxtempoparziale = null,oremaxtempopieno = '1512',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = '250',parttime = 'S',scatto = null,sortcode = '20',tempdef = 'N',title = 'Personale tecnico amministrativo',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '14'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,scatto,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('14','S',null,'40000','40000',{ts '2020-05-20 11:32:07.807'},'riccardotest{0001}',null,null,null,null,null,{ts '2020-10-21 15:27:32.890'},'riccardotest{ADMSEG1}',null,null,null,null,'9',null,'1512',null,null,null,null,null,null,'250','S',null,'20','N','Personale tecnico amministrativo',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '15')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2020-05-20 11:33:03.170'},cu = 'riccardotest{0001}',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:33:16.633'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = '40',oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',scatto = null,sortcode = '11',tempdef = 'N',title = 'Dottorandi di ricerca',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '15'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,scatto,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('15','S',null,null,'40000',{ts '2020-05-20 11:33:03.170'},'riccardotest{0001}',null,null,null,null,null,{ts '2020-05-21 10:33:16.633'},'riccardotest{0001}',null,'40',null,null,null,null,'1720',null,null,null,null,null,null,null,'N',null,'11','N','Dottorandi di ricerca',null,null)
GO

-- CREAZIONE TABELLA contrattokindposition --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contrattokindposition]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[contrattokindposition] (
idcontrattokind int NOT NULL,
idposition int NOT NULL,
ct datetime NOT NULL,
cu varchar(60) NOT NULL,
lt datetime NOT NULL,
lu varchar(60) NOT NULL,
 CONSTRAINT xpkcontrattokindposition PRIMARY KEY (idcontrattokind,
idposition
)
)
END
GO

-- VERIFICA STRUTTURA contrattokindposition --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindposition' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindposition] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokindposition') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokindposition] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindposition' and C.name = 'idposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindposition] ADD idposition int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokindposition') and col.name = 'idposition' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokindposition] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindposition' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindposition] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokindposition') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokindposition] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokindposition] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindposition' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindposition] ADD cu varchar(60) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokindposition') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokindposition] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokindposition] ALTER COLUMN cu varchar(60) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindposition' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindposition] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokindposition') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokindposition] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokindposition] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokindposition' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokindposition] ADD lu varchar(60) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokindposition') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokindposition] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokindposition] ALTER COLUMN lu varchar(60) NOT NULL
GO

-- CREAZIONE TABELLA istanza_eq --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanza_eq]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[istanza_eq] (
idistanza int NOT NULL,
idreg int NOT NULL,
idistanzakind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
iddichiar_titolo_seg int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkistanza_eq PRIMARY KEY (idistanza,
idreg,
idistanzakind
)
)
END
GO

-- VERIFICA STRUTTURA istanza_eq --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanza_eq' and C.name = 'idistanza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanza_eq] ADD idistanza int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanza_eq') and col.name = 'idistanza' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanza_eq] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanza_eq' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanza_eq] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanza_eq') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanza_eq] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanza_eq' and C.name = 'idistanzakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanza_eq] ADD idistanzakind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanza_eq') and col.name = 'idistanzakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanza_eq] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanza_eq' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanza_eq] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanza_eq') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanza_eq] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istanza_eq] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanza_eq' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanza_eq] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanza_eq') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanza_eq] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istanza_eq] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanza_eq' and C.name = 'iddichiar_titolo_seg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanza_eq] ADD iddichiar_titolo_seg int NULL 
END
ELSE
	ALTER TABLE [istanza_eq] ALTER COLUMN iddichiar_titolo_seg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanza_eq' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanza_eq] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanza_eq') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanza_eq] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istanza_eq] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'istanza_eq' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [istanza_eq] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('istanza_eq') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [istanza_eq] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [istanza_eq] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- CREAZIONE TABELLA registry_amministrativi --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry_amministrativi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry_amministrativi] (
idreg int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
cv nvarchar(max) NULL,
idcontrattokind int NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkregistry_amministrativi PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry_amministrativi --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_amministrativi') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_amministrativi] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'cv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD cv nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN cv nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN lu varchar(64) NULL
GO

-- CREAZIONE TABELLA registry_docenti --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry_docenti]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry_docenti] (
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cv nvarchar(max) NULL,
idclassconsorsuale int NULL,
idcontrattokind int NULL,
idfonteindicebibliometrico int NULL,
idreg_istituti int NULL,
idsasd int NULL,
idstruttura int NULL,
indicebibliometrico int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
matricola varchar(50) NULL,
ricevimento nvarchar(max) NULL,
soggiorno varchar(255) NULL,
 CONSTRAINT xpkregistry_docenti PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry_docenti --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'cv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD cv nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN cv nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idclassconsorsuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idclassconsorsuale int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idclassconsorsuale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idfonteindicebibliometrico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idfonteindicebibliometrico int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idfonteindicebibliometrico int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idreg_istituti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idreg_istituti int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idreg_istituti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'indicebibliometrico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD indicebibliometrico int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN indicebibliometrico int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'matricola' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD matricola varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN matricola varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'ricevimento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD ricevimento nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN ricevimento nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'soggiorno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD soggiorno varchar(255) NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN soggiorno varchar(255) NULL
GO

-- CREAZIONE TABELLA rendicont --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicont]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[rendicont] (
idreg_docenti int NOT NULL,
aa varchar(9) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(1024) NULL,
 CONSTRAINT xpkrendicont PRIMARY KEY (idreg_docenti,
aa
)
)
END
GO

-- VERIFICA STRUTTURA rendicont --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD idreg_docenti int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD aa varchar(9) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN title varchar(1024) NULL
GO

-- CREAZIONE TABELLA rendicontaltro --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontaltro]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[rendicontaltro] (
idrendicontaltro int NOT NULL,
aa varchar(9) NOT NULL,
idreg_docenti int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data date NOT NULL,
idrendicontaltrokind int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ore decimal(9,2) NOT NULL,
 CONSTRAINT xpkrendicontaltro PRIMARY KEY (idrendicontaltro,
aa,
idreg_docenti
)
)
END
GO

-- VERIFICA STRUTTURA rendicontaltro --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'idrendicontaltro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD idrendicontaltro int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'idrendicontaltro' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD aa varchar(9) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD idreg_docenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD data date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'data' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN data date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'idrendicontaltrokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD idrendicontaltrokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'idrendicontaltrokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN idrendicontaltrokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'ore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD ore decimal(9,2) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'ore' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN ore decimal(9,2) NOT NULL
GO

-- CREAZIONE VISTA contrattokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contrattokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[contrattokinddefaultview]
GO

CREATE VIEW [dbo].[contrattokinddefaultview] AS SELECT CASE WHEN contrattokind.active = 'S' THEN 'Si' WHEN contrattokind.active = 'N' THEN 'No' END AS contrattokind_active,CASE WHEN contrattokind.assegnoaggiuntivo = 'S' THEN 'Si' WHEN contrattokind.assegnoaggiuntivo = 'N' THEN 'No' END AS contrattokind_assegnoaggiuntivo, contrattokind.costolordoannuo AS contrattokind_costolordoannuo, contrattokind.costolordoannuooneri AS contrattokind_costolordoannuooneri, contrattokind.ct AS contrattokind_ct, contrattokind.cu AS contrattokind_cu, contrattokind.description AS contrattokind_description,CASE WHEN contrattokind.elementoperequativo = 'S' THEN 'Si' WHEN contrattokind.elementoperequativo = 'N' THEN 'No' END AS contrattokind_elementoperequativo, contrattokind.idcontrattokind,CASE WHEN contrattokind.indennitadiateneo = 'S' THEN 'Si' WHEN contrattokind.indennitadiateneo = 'N' THEN 'No' END AS contrattokind_indennitadiateneo,CASE WHEN contrattokind.indennitadiposizione = 'S' THEN 'Si' WHEN contrattokind.indennitadiposizione = 'N' THEN 'No' END AS contrattokind_indennitadiposizione,CASE WHEN contrattokind.indvacancacontrattuale = 'S' THEN 'Si' WHEN contrattokind.indvacancacontrattuale = 'N' THEN 'No' END AS contrattokind_indvacancacontrattuale, contrattokind.lt AS contrattokind_lt, contrattokind.lu AS contrattokind_lu, contrattokind.oremaxcompitididatempoparziale AS contrattokind_oremaxcompitididatempoparziale, contrattokind.oremaxcompitididatempopieno AS contrattokind_oremaxcompitididatempopieno, contrattokind.oremaxdidatempoparziale AS contrattokind_oremaxdidatempoparziale, contrattokind.oremaxdidatempopieno AS contrattokind_oremaxdidatempopieno, contrattokind.oremaxgg AS contrattokind_oremaxgg, contrattokind.oremaxtempoparziale AS contrattokind_oremaxtempoparziale, contrattokind.oremaxtempopieno AS contrattokind_oremaxtempopieno, contrattokind.oremincompitididatempoparziale AS contrattokind_oremincompitididatempoparziale, contrattokind.oremincompitididatempopieno AS contrattokind_oremincompitididatempopieno, contrattokind.oremindidatempoparziale AS contrattokind_oremindidatempoparziale, contrattokind.oremindidatempopieno AS contrattokind_oremindidatempopieno, contrattokind.oremintempoparziale AS contrattokind_oremintempoparziale, contrattokind.oremintempopieno AS contrattokind_oremintempopieno, contrattokind.orestraordinariemax AS contrattokind_orestraordinariemax,CASE WHEN contrattokind.parttime = 'S' THEN 'Si' WHEN contrattokind.parttime = 'N' THEN 'No' END AS contrattokind_parttime,CASE WHEN contrattokind.scatto = 'S' THEN 'Si' WHEN contrattokind.scatto = 'N' THEN 'No' END AS contrattokind_scatto, contrattokind.sortcode AS contrattokind_sortcode,CASE WHEN contrattokind.tempdef = 'S' THEN 'Si' WHEN contrattokind.tempdef = 'N' THEN 'No' END AS contrattokind_tempdef, contrattokind.title,CASE WHEN contrattokind.totaletredicesima = 'S' THEN 'Si' WHEN contrattokind.totaletredicesima = 'N' THEN 'No' END AS contrattokind_totaletredicesima,CASE WHEN contrattokind.tredicesimaindennitaintegrativaspeciale = 'S' THEN 'Si' WHEN contrattokind.tredicesimaindennitaintegrativaspeciale = 'N' THEN 'No' END AS contrattokind_tredicesimaindennitaintegrativaspeciale, isnull('Tipologia: ' + contrattokind.title + '; ','') as dropdown_title FROM [dbo].contrattokind WITH (NOLOCK)  WHERE  contrattokind.idcontrattokind IS NOT NULL 
GO


-- GENERAZIONE DATI PER contrattokinddefaultview --
-- CREAZIONE VISTA getregistrydocentiamministrativi
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getregistrydocentiamministrativi]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getregistrydocentiamministrativi]
GO




CREATE VIEW [dbo].[getregistrydocentiamministrativi]
AS
SELECT
	dbo.registry.idreg, dbo.registry.forename, dbo.registry.surname, dbo.registry.cf, 
	i.title as istituto, dbo.sasd.codice as ssd, struttura.title as struttura, 
	(select top 1 title from contrattokind ck where ck.idcontrattokind = 
		(select top 1 idcontrattokind from contratto c where c.idreg = d.idreg )) as contratto
FROM dbo.registry 
	INNER JOIN dbo.registry_docenti d ON dbo.registry.idreg = d.idreg 
	LEFT OUTER JOIN sasd on sasd.idsasd = d.idsasd
	LEFT OUTER JOIN registry i on i.idreg = d.idreg_istituti
	LEFT OUTER JOIN struttura on struttura.idstruttura = d.idstruttura
UNION
SELECT
	dbo.registry.idreg, dbo.registry.forename, dbo.registry.surname, dbo.registry.cf, 
	(select top 1 title from registry i where i.idreg = 
		(select top 1 ip.idreg from istitutoprinc ip)) as istituto, null as ssd, null as struttura, 
	(select top 1 title from contrattokind ck where ck.idcontrattokind = 
		(select top 1 idcontrattokind from contratto c where c.idreg = a.idreg )) as contratto
FROM dbo.registry 
	INNER JOIN dbo.registry_amministrativi a ON dbo.registry.idreg = a.idreg
WHERE dbo.registry.idreg not in (select idreg from registry_docenti)

GO

-- CREAZIONE VISTA istanzaeq_segview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzaeq_segview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzaeq_segview]
GO

CREATE VIEW [dbo].[istanzaeq_segview] AS SELECT  istanza.aa, istanza.ct AS istanza_ct, istanza.cu AS istanza_cu, istanza.data AS istanza_data, istanza.extension AS istanza_extension, [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, istanza.idcorsostudio, [dbo].didprog.title AS didprog_title, [dbo].annoaccademico.aa AS annoaccademico_aa, [dbo].sede.title AS sede_title, istanza.iddidprog, [dbo].iscrizione.anno AS iscrizione_anno, [dbo].iscrizione.iddidprog AS iscrizione_iddidprog, annoaccademico_iscrizione.aa AS annoaccademico_iscrizione_aa, istanza.idiscrizione, istanza.idistanza, istanza.idistanzakind, registry_registry_studentistudenti.title AS registrystudenti_title, istanza.idreg_studenti, [dbo].statuskind.title AS statuskind_title, istanza.idstatuskind AS istanza_idstatuskind, istanza.lt AS istanza_lt, istanza.lu AS istanza_lu, istanzaparent.idistanzakind AS istanzaparent_idistanzakind, istanzaparent.idreg_studenti AS istanzaparent_idreg_studenti, annoaccademico_istanza.aa AS annoaccademico_istanza_aa, istanzaparent.data AS istanzaparent_data, didprog_istanza.title AS didprog_istanza_title, didprog_istanza.aa AS didprog_istanza_aa, didprog_istanza.idsede AS didprog_istanza_idsede, statuskind_istanza.title AS statuskind_istanza_title, iscrizione_istanza.anno AS iscrizione_istanza_anno, iscrizione_istanza.iddidprog AS iscrizione_istanza_iddidprog, iscrizione_istanza.aa AS iscrizione_istanza_aa, istanza.paridistanza, istanza.protanno AS istanza_protanno, istanza.protnumero AS istanza_protnumero, istanza_eq.ct AS istanza_eq_ct, istanza_eq.cu AS istanza_eq_cu, dichiar_dichiar_titolotitolo_seg.iddichiarkind AS dichiartitolo_seg_iddichiarkind, dichiar_dichiar_titolotitolo_seg.idreg AS dichiartitolo_seg_idreg, dichiar_dichiar_titolotitolo_seg.aa AS dichiartitolo_seg_aa, dichiar_dichiar_titolotitolo_seg.date AS dichiartitolo_seg_date, istanza_eq.iddichiar_titolo_seg, istanza_eq.idistanza AS istanza_eq_idistanza, istanza_eq.idistanzakind AS istanza_eq_idistanzakind, istanza_eq.idreg AS istanza_eq_idreg, istanza_eq.lt AS istanza_eq_lt, istanza_eq.lu AS istanza_eq_lu, isnull('Studente: ' + registry_registry_studentistudenti.title + '; ','') + ' ' + isnull('Anno accademico: ' + istanza.aa + '; ','') + ' ' + isnull('Codice Anno accademico: ' + [dbo].annoaccademico.aa + '; ','') + ' ' + isnull('Codice Anno accademico: ' + annoaccademico_istanza.aa + '; ','') + ' ' + isnull('Codice Anno accademico: ' + annoaccademico_iscrizione.aa + '; ','') + ' ' + isnull('Didattica programmata: ' + [dbo].didprog.title + '; ','') + ' ' + isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Denominazione Didattica programmata: ' + didprog_istanza.title + '; ','') + ' ' + isnull('Stato Status: ' + statuskind_istanza.title + '; ','') + ' ' + isnull('Anno accademico Didattica programmata: ' + didprog_istanza.aa + '; ','') + ' ' + isnull('Sede Didattica programmata: ' + CAST( didprog_istanza.idsede AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno di corso Iscrizione: ' + CAST( iscrizione_istanza.anno AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Didattica programmata Iscrizione: ' + CAST( iscrizione_istanza.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno accademico Iscrizione: ' + iscrizione_istanza.aa + '; ','') as dropdown_title FROM [dbo].istanza WITH (NOLOCK)  INNER JOIN istanza_eq WITH (NOLOCK) ON istanza.idistanza = istanza_eq.idistanza AND istanza.idistanzakind = istanza_eq.idistanzakind AND istanza.idreg_studenti = istanza_eq.idreg LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON istanza.idcorsostudio = [dbo].corsostudio.idcorsostudio LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON istanza.iddidprog = [dbo].didprog.iddidprog LEFT OUTER JOIN [dbo].annoaccademico WITH (NOLOCK) ON didprog.aa = [dbo].annoaccademico.aa LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede LEFT OUTER JOIN [dbo].iscrizione WITH (NOLOCK) ON istanza.idiscrizione = [dbo].iscrizione.idiscrizione LEFT OUTER JOIN [dbo].annoaccademico AS annoaccademico_iscrizione WITH (NOLOCK) ON iscrizione.aa = annoaccademico_iscrizione.aa LEFT OUTER JOIN [dbo].registry_studenti AS registry_studentistudenti WITH (NOLOCK) ON istanza.idreg_studenti = registry_studentistudenti.idreg LEFT OUTER JOIN [dbo].registry AS registry_registry_studentistudenti WITH (NOLOCK) ON registry_studentistudenti.idreg = registry_registry_studentistudenti.idreg LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON istanza.idstatuskind = [dbo].statuskind.idstatuskind LEFT OUTER JOIN [dbo].istanza AS istanzaparent WITH (NOLOCK) ON istanza.paridistanza = istanzaparent.idistanza LEFT OUTER JOIN [dbo].annoaccademico AS annoaccademico_istanza WITH (NOLOCK) ON istanza.aa = annoaccademico_istanza.aa LEFT OUTER JOIN [dbo].didprog AS didprog_istanza WITH (NOLOCK) ON istanza.iddidprog = didprog_istanza.iddidprog LEFT OUTER JOIN [dbo].statuskind AS statuskind_istanza WITH (NOLOCK) ON istanza.idstatuskind = statuskind_istanza.idstatuskind LEFT OUTER JOIN [dbo].iscrizione AS iscrizione_istanza WITH (NOLOCK) ON istanza.idiscrizione = iscrizione_istanza.idiscrizione LEFT OUTER JOIN [dbo].dichiar_titolo AS dichiar_titolotitolo_seg WITH (NOLOCK) ON istanza_eq.iddichiar_titolo_seg = dichiar_titolotitolo_seg.iddichiar LEFT OUTER JOIN [dbo].dichiar AS dichiar_dichiar_titolotitolo_seg WITH (NOLOCK) ON dichiar_titolotitolo_seg.iddichiar = dichiar_dichiar_titolotitolo_seg.iddichiar WHERE  istanza.idistanza IS NOT NULL  AND istanza.idistanzakind = 1 AND istanza.idistanzakind IS NOT NULL  AND istanza.idreg_studenti IS NOT NULL  AND istanza.idstatuskind in (select idstatuskind from statuskind where istanze = 'S') AND istanza_eq.idistanza IS NOT NULL  AND istanza_eq.idistanzakind =1 AND istanza_eq.idistanzakind IS NOT NULL  AND istanza_eq.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA registryamministrativiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryamministrativiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryamministrativiview]
GO

CREATE VIEW [dbo].[registryamministrativiview] AS SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, [dbo].category.description AS category_description, registry.idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory, [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, [dbo].maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus, [dbo].geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg, [dbo].registryclass.description AS registryclass_description, registry.idregistryclass, [dbo].registrykind.description AS registrykind_description, registry.idregistrykind AS registry_idregistrykind, [dbo].title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, [dbo].residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title AS registry_title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_amministrativi.ct AS registry_amministrativi_ct, registry_amministrativi.cu AS registry_amministrativi_cu, registry_amministrativi.cv AS registry_amministrativi_cv, [dbo].contrattokind.title AS contrattokind_title, registry_amministrativi.idcontrattokind AS registry_amministrativi_idcontrattokind, registry_amministrativi.idreg AS registry_amministrativi_idreg, registry_amministrativi.lt AS registry_amministrativi_lt, registry_amministrativi.lu AS registry_amministrativi_lu, isnull('Titolo: ' + [dbo].title.description + '; ','') + ' ' + isnull('Cognome: ' + registry.surname + '; ','') + ' ' + isnull('Nome: ' + registry.forename + '; ','') + ' ' + isnull('Codice fiscale: ' + registry.cf + '; ','') as dropdown_title FROM [dbo].registry WITH (NOLOCK)  INNER JOIN registry_amministrativi WITH (NOLOCK) ON registry.idreg = registry_amministrativi.idreg LEFT OUTER JOIN [dbo].category WITH (NOLOCK) ON registry.idcategory = [dbo].category.idcategory LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity LEFT OUTER JOIN [dbo].maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = [dbo].maritalstatus.idmaritalstatus LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registry.idnation = [dbo].geo_nation.idnation LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass LEFT OUTER JOIN [dbo].registrykind WITH (NOLOCK) ON registry.idregistrykind = [dbo].registrykind.idregistrykind LEFT OUTER JOIN [dbo].title WITH (NOLOCK) ON registry.idtitle = [dbo].title.idtitle LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON registry.residence = [dbo].residence.idresidence LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON registry_amministrativi.idcontrattokind = [dbo].contrattokind.idcontrattokind WHERE  registry.idreg IS NOT NULL  AND registry_amministrativi.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA registrydefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrydefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrydefaultview]
GO



CREATE VIEW [dbo].[registrydefaultview] AS SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'S' THEN 'Si' WHEN registry.gender = 'N' THEN 'No' END AS registry_gender, [dbo].category.description AS category_description, registry.idcategory, [dbo].centralizedcategory.description AS centralizedcategory_description, registry.idcentralizedcategory, [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, [dbo].maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus, [dbo].geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg, [dbo].registryclass.description AS registryclass_description, registry.idregistryclass, [dbo].registrykind.description AS registrykind_description, registry.idregistrykind AS registry_idregistrykind, [dbo].title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, [dbo].residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, isnull('Denominazione: ' + registry.title + '; ','') as dropdown_title FROM [dbo].registry WITH (NOLOCK)  LEFT OUTER JOIN [dbo].category WITH (NOLOCK) ON registry.idcategory = [dbo].category.idcategory LEFT OUTER JOIN [dbo].centralizedcategory WITH (NOLOCK) ON registry.idcentralizedcategory = [dbo].centralizedcategory.idcentralizedcategory LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity LEFT OUTER JOIN [dbo].maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = [dbo].maritalstatus.idmaritalstatus LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registry.idnation = [dbo].geo_nation.idnation LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass LEFT OUTER JOIN [dbo].registrykind WITH (NOLOCK) ON registry.idregistrykind = [dbo].registrykind.idregistrykind LEFT OUTER JOIN [dbo].title WITH (NOLOCK) ON registry.idtitle = [dbo].title.idtitle LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON registry.residence = [dbo].residence.idresidence WHERE  registry.idreg IS NOT NULL 

GO

-- CREAZIONE VISTA registrydocentiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrydocentiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrydocentiview]
GO

CREATE VIEW [dbo].[registrydocentiview] AS SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, registry.idcategory AS registry_idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory, [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, [dbo].maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus, [dbo].geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg, [dbo].registryclass.description AS registryclass_description, registry.idregistryclass, registry.idregistrykind AS registry_idregistrykind, [dbo].title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, [dbo].residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_docenti.ct AS registry_docenti_ct, registry_docenti.cu AS registry_docenti_cu, registry_docenti.cv AS registry_docenti_cv, [dbo].classconsorsuale.title AS classconsorsuale_title, registry_docenti.idclassconsorsuale, [dbo].contrattokind.title AS contrattokind_title, registry_docenti.idcontrattokind AS registry_docenti_idcontrattokind, [dbo].fonteindicebibliometrico.title AS fonteindicebibliometrico_title, registry_docenti.idfonteindicebibliometrico AS registry_docenti_idfonteindicebibliometrico, registry_docenti.idreg AS registry_docenti_idreg, registry_registry_istitutiistituti.title AS registryistituti_title, registry_docenti.idreg_istituti, [dbo].sasd.codice AS sasd_codice, [dbo].sasd.title AS sasd_title, registry_docenti.idsasd, [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, registry_docenti.idstruttura, registry_docenti.indicebibliometrico AS registry_docenti_indicebibliometrico, registry_docenti.lt AS registry_docenti_lt, registry_docenti.lu AS registry_docenti_lu, registry_docenti.matricola AS registry_docenti_matricola, registry_docenti.ricevimento AS registry_docenti_ricevimento, registry_docenti.soggiorno AS registry_docenti_soggiorno, isnull('Denominazione: ' + registry.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + [dbo].strutturakind.title + '; ','') as dropdown_title FROM [dbo].registry WITH (NOLOCK)  INNER JOIN registry_docenti WITH (NOLOCK) ON registry.idreg = registry_docenti.idreg LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity LEFT OUTER JOIN [dbo].maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = [dbo].maritalstatus.idmaritalstatus LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registry.idnation = [dbo].geo_nation.idnation LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass LEFT OUTER JOIN [dbo].title WITH (NOLOCK) ON registry.idtitle = [dbo].title.idtitle LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON registry.residence = [dbo].residence.idresidence LEFT OUTER JOIN [dbo].classconsorsuale WITH (NOLOCK) ON registry_docenti.idclassconsorsuale = [dbo].classconsorsuale.idclassconsorsuale LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON registry_docenti.idcontrattokind = [dbo].contrattokind.idcontrattokind LEFT OUTER JOIN [dbo].fonteindicebibliometrico WITH (NOLOCK) ON registry_docenti.idfonteindicebibliometrico = [dbo].fonteindicebibliometrico.idfonteindicebibliometrico LEFT OUTER JOIN [dbo].registry_istituti AS registry_istitutiistituti WITH (NOLOCK) ON registry_docenti.idreg_istituti = registry_istitutiistituti.idreg LEFT OUTER JOIN [dbo].registry AS registry_registry_istitutiistituti WITH (NOLOCK) ON registry_istitutiistituti.idreg = registry_registry_istitutiistituti.idreg LEFT OUTER JOIN [dbo].sasd WITH (NOLOCK) ON registry_docenti.idsasd = [dbo].sasd.idsasd LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON registry_docenti.idstruttura = [dbo].struttura.idstruttura LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind WHERE  registry.idreg IS NOT NULL  AND registry_docenti.idreg IS NOT NULL 
GO

