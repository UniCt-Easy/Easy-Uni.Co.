
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


-- CREAZIONE TABELLA strutturakind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strutturakind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[strutturakind] (
idstrutturakind int NOT NULL,
active char(1) NOT NULL,
description varchar(256) NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortCode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkstrutturakind PRIMARY KEY (idstrutturakind
)
)
END
GO

-- VERIFICA STRUTTURA strutturakind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturakind' and C.name = 'idstrutturakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturakind] ADD idstrutturakind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('strutturakind') and col.name = 'idstrutturakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [strutturakind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturakind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturakind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('strutturakind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [strutturakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [strutturakind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturakind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturakind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [strutturakind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturakind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturakind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [strutturakind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturakind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturakind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [strutturakind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturakind' and C.name = 'sortCode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturakind] ADD sortCode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('strutturakind') and col.name = 'sortCode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [strutturakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [strutturakind] ALTER COLUMN sortCode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturakind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturakind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('strutturakind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [strutturakind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [strutturakind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER strutturakind --
IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '1')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortCode = '2',title = 'Dipartimento' WHERE idstrutturakind = '1'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('1','S',null,{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','Dipartimento')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '2')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortCode = '3',title = 'Giunta di facoltà' WHERE idstrutturakind = '2'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('2','S',null,{ts '2019-02-28 18:02:19.867'},'Ferdinando','3','Giunta di facoltà')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '3')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortCode = '4',title = 'Giunta di dipartimento' WHERE idstrutturakind = '3'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('3','S',null,{ts '2019-02-28 18:02:19.867'},'Ferdinando','4','Giunta di dipartimento')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '4')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortCode = '5',title = 'Consiglio di corso di studi' WHERE idstrutturakind = '4'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('4','S',null,{ts '2019-02-28 18:02:19.867'},'Ferdinando','5','Consiglio di corso di studi')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '5')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortCode = '6',title = 'Consiglio di area didattica' WHERE idstrutturakind = '5'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('5','S',null,{ts '2019-02-28 18:02:19.867'},'Ferdinando','6','Consiglio di area didattica')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '6')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortCode = '7',title = 'Struttura di raccordo' WHERE idstrutturakind = '6'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('6','S',null,{ts '2019-02-28 18:02:19.867'},'Ferdinando','7','Struttura di raccordo')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '7')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortCode = '8',title = 'Segreteria' WHERE idstrutturakind = '7'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('7','S',null,{ts '2019-02-28 18:02:19.867'},'Ferdinando','8','Segreteria')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '8')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortCode = '9',title = 'Segreteria amministrativa' WHERE idstrutturakind = '8'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('8','S',null,{ts '2019-02-28 18:02:19.867'},'Ferdinando','9','Segreteria amministrativa')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '9')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortCode = '10',title = 'Segreteria didattica' WHERE idstrutturakind = '9'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('9','S',null,{ts '2019-02-28 18:02:19.867'},'Ferdinando','10','Segreteria didattica')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '10')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortCode = '11',title = 'Ufficio' WHERE idstrutturakind = '10'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('10','S',null,{ts '2019-02-28 18:02:19.867'},'Ferdinando','11','Ufficio')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '11')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortCode = '12',title = 'Altro' WHERE idstrutturakind = '11'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('11','S',null,{ts '2019-02-28 18:02:19.867'},'Ferdinando','12','Altro')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '12')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortCode = '1',title = 'Facoltà' WHERE idstrutturakind = '12'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('12','S',null,{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','Facoltà')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '13')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {d '2021-06-07'},lu = 'Ferdinando',sortCode = '13',title = 'Direzione generale' WHERE idstrutturakind = '13'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('13','S',null,{d '2021-06-07'},'Ferdinando','13','Direzione generale')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '14')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {d '2021-06-07'},lu = 'Ferdinando',sortCode = '14',title = 'Divisione' WHERE idstrutturakind = '14'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('14','S',null,{d '2021-06-07'},'Ferdinando','14','Divisione')
GO

IF exists(SELECT * FROM [strutturakind] WHERE idstrutturakind = '15')
UPDATE [strutturakind] SET active = 'S',description = null,lt = {d '2021-06-07'},lu = 'Ferdinando',sortCode = '15',title = 'Settore' WHERE idstrutturakind = '15'
ELSE
INSERT INTO [strutturakind] (idstrutturakind,active,description,lt,lu,sortCode,title) VALUES ('15','S',null,{d '2021-06-07'},'Ferdinando','15','Settore')
GO

