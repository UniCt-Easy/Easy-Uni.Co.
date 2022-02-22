
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


-- CREAZIONE TABELLA progettostatuskind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettostatuskind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettostatuskind] (
idprogettostatuskind int NOT NULL,
contributo char(1) NULL,
contributoente char(1) NULL,
contributoenterichiesto char(1) NULL,
contributorichiesto char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkprogettostatuskind PRIMARY KEY (idprogettostatuskind
)
)
END
GO

-- VERIFICA STRUTTURA progettostatuskind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'idprogettostatuskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD idprogettostatuskind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'idprogettostatuskind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'contributo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD contributo char(1) NULL 
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN contributo char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'contributoente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD contributoente char(1) NULL 
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN contributoente char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'contributoenterichiesto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD contributoenterichiesto char(1) NULL 
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN contributoenterichiesto char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'contributorichiesto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD contributorichiesto char(1) NULL 
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN contributorichiesto char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettostatuskind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettostatuskind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettostatuskind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettostatuskind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettostatuskind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER progettostatuskind --
IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '1')
UPDATE [progettostatuskind] SET contributo = null,contributoente = null,contributoenterichiesto = null,contributorichiesto = null,ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '1',title = 'Bozza' WHERE idprogettostatuskind = '1'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,contributo,contributoente,contributoenterichiesto,contributorichiesto,ct,cu,lt,lu,sortcode,title) VALUES ('1',null,null,null,null,{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','1','Bozza')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '2')
UPDATE [progettostatuskind] SET contributo = null,contributoente = null,contributoenterichiesto = null,contributorichiesto = null,ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '2',title = 'Inserito' WHERE idprogettostatuskind = '2'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,contributo,contributoente,contributoenterichiesto,contributorichiesto,ct,cu,lt,lu,sortcode,title) VALUES ('2',null,null,null,null,{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','2','Inserito')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '3')
UPDATE [progettostatuskind] SET contributo = null,contributoente = null,contributoenterichiesto = null,contributorichiesto = null,ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '3',title = 'Non presentato' WHERE idprogettostatuskind = '3'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,contributo,contributoente,contributoenterichiesto,contributorichiesto,ct,cu,lt,lu,sortcode,title) VALUES ('3',null,null,null,null,{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','3','Non presentato')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '4')
UPDATE [progettostatuskind] SET contributo = null,contributoente = null,contributoenterichiesto = null,contributorichiesto = null,ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '4',title = 'Presentato' WHERE idprogettostatuskind = '4'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,contributo,contributoente,contributoenterichiesto,contributorichiesto,ct,cu,lt,lu,sortcode,title) VALUES ('4',null,null,null,null,{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','4','Presentato')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '5')
UPDATE [progettostatuskind] SET contributo = null,contributoente = null,contributoenterichiesto = null,contributorichiesto = null,ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinandio',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '5',title = 'Escluso' WHERE idprogettostatuskind = '5'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,contributo,contributoente,contributoenterichiesto,contributorichiesto,ct,cu,lt,lu,sortcode,title) VALUES ('5',null,null,null,null,{ts '2019-10-19 09:05:00.000'},'ferdinandio',{ts '2019-10-19 09:05:00.000'},'ferdinando','5','Escluso')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '6')
UPDATE [progettostatuskind] SET contributo = null,contributoente = null,contributoenterichiesto = null,contributorichiesto = null,ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '6',title = 'Approvato in negoziazione' WHERE idprogettostatuskind = '6'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,contributo,contributoente,contributoenterichiesto,contributorichiesto,ct,cu,lt,lu,sortcode,title) VALUES ('6',null,null,null,null,{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','6','Approvato in negoziazione')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '7')
UPDATE [progettostatuskind] SET contributo = null,contributoente = null,contributoenterichiesto = null,contributorichiesto = null,ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '7',title = 'Validazione risorse umane' WHERE idprogettostatuskind = '7'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,contributo,contributoente,contributoenterichiesto,contributorichiesto,ct,cu,lt,lu,sortcode,title) VALUES ('7',null,null,null,null,{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','7','Validazione risorse umane')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '8')
UPDATE [progettostatuskind] SET contributo = null,contributoente = null,contributoenterichiesto = null,contributorichiesto = null,ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '8',title = 'Operativo' WHERE idprogettostatuskind = '8'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,contributo,contributoente,contributoenterichiesto,contributorichiesto,ct,cu,lt,lu,sortcode,title) VALUES ('8',null,null,null,null,{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','8','Operativo')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '9')
UPDATE [progettostatuskind] SET contributo = null,contributoente = null,contributoenterichiesto = null,contributorichiesto = null,ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '9',title = 'Rinuncia-Trasferimento-Revoca' WHERE idprogettostatuskind = '9'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,contributo,contributoente,contributoenterichiesto,contributorichiesto,ct,cu,lt,lu,sortcode,title) VALUES ('9',null,null,null,null,{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','9','Rinuncia-Trasferimento-Revoca')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '10')
UPDATE [progettostatuskind] SET contributo = null,contributoente = null,contributoenterichiesto = null,contributorichiesto = null,ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '10',title = 'Sospeso' WHERE idprogettostatuskind = '10'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,contributo,contributoente,contributoenterichiesto,contributorichiesto,ct,cu,lt,lu,sortcode,title) VALUES ('10',null,null,null,null,{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','10','Sospeso')
GO

IF exists(SELECT * FROM [progettostatuskind] WHERE idprogettostatuskind = '11')
UPDATE [progettostatuskind] SET contributo = null,contributoente = null,contributoenterichiesto = null,contributorichiesto = null,ct = {ts '2019-10-19 09:05:00.000'},cu = 'ferdinando',lt = {ts '2019-10-19 09:05:00.000'},lu = 'ferdinando',sortcode = '11',title = 'Concluso' WHERE idprogettostatuskind = '11'
ELSE
INSERT INTO [progettostatuskind] (idprogettostatuskind,contributo,contributoente,contributoenterichiesto,contributorichiesto,ct,cu,lt,lu,sortcode,title) VALUES ('11',null,null,null,null,{ts '2019-10-19 09:05:00.000'},'ferdinando',{ts '2019-10-19 09:05:00.000'},'ferdinando','11','Concluso')
GO

