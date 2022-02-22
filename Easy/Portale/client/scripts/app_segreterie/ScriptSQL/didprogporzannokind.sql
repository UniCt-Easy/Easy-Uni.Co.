
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


-- CREAZIONE TABELLA didprogporzannokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogporzannokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[didprogporzannokind] (
iddidprogporzannokind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkdidprogporzannokind PRIMARY KEY (iddidprogporzannokind
)
)
END
GO

-- VERIFICA STRUTTURA didprogporzannokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzannokind' and C.name = 'iddidprogporzannokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzannokind] ADD iddidprogporzannokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzannokind') and col.name = 'iddidprogporzannokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzannokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzannokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzannokind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzannokind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzannokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogporzannokind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzannokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzannokind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzannokind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzannokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogporzannokind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprogporzannokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprogporzannokind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprogporzannokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprogporzannokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [didprogporzannokind] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI didprogporzannokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'didprogporzannokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannokind','int','assistenza','iddidprogporzannokind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannokind','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannokind','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannokind','varchar(50)','assistenza','title','50','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI didprogporzannokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'didprogporzannokind')
UPDATE customobject set isreal = 'S' where objectname = 'didprogporzannokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('didprogporzannokind', 'S')
GO

-- GENERAZIONE DATI PER didprogporzannokind --
IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '1')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',title = 'Mensile' WHERE iddidprogporzannokind = '1'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('1',{ts '2018-06-11 11:35:00.653'},'ferdinando','Mensile')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '2')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Bimestrale' WHERE iddidprogporzannokind = '2'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('2',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Bimestrale')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '3')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Trimestrale' WHERE iddidprogporzannokind = '3'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('3',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Trimestrale')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '4')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Quadrimestrale' WHERE iddidprogporzannokind = '4'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('4',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Quadrimestrale')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '5')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Semestrale' WHERE iddidprogporzannokind = '5'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('5',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Semestrale')
GO

IF exists(SELECT * FROM [didprogporzannokind] WHERE iddidprogporzannokind = '6')
UPDATE [didprogporzannokind] SET ct = {ts '2018-06-11 11:35:00.653'},cu = 'Ferdinando',title = 'Annuale' WHERE iddidprogporzannokind = '6'
ELSE
INSERT INTO [didprogporzannokind] (iddidprogporzannokind,ct,cu,title) VALUES ('6',{ts '2018-06-11 11:35:00.653'},'Ferdinando','Annuale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'didprogporzannokind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO semestri, trimestri, ecc',idapplication = '2',isdbo = 'S',lt = {ts '2022-01-11 15:28:57.453'},lu = 'Generator',title = 'VOCABOLARIO semestri, trimestri, ecc' WHERE tablename = 'didprogporzannokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('didprogporzannokind','VOCABOLARIO semestri, trimestri, ecc','2','S',{ts '2022-01-11 15:28:57.453'},'Generator','VOCABOLARIO semestri, trimestri, ecc')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'didprogporzannokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:41:38.620'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'didprogporzannokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','didprogporzannokind','8',null,null,null,'S',{ts '2018-07-19 17:41:38.620'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'didprogporzannokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:41:38.620'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'didprogporzannokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','didprogporzannokind','64',null,null,null,'S',{ts '2018-07-19 17:41:38.620'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogporzannokind' AND tablename = 'didprogporzannokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:41:38.620'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogporzannokind' AND tablename = 'didprogporzannokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogporzannokind','didprogporzannokind','4',null,null,null,'S',{ts '2018-07-19 17:41:38.620'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'didprogporzannokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 17:41:38.620'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'didprogporzannokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','didprogporzannokind','50',null,null,null,'S',{ts '2018-07-19 17:41:38.620'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3290')
UPDATE [relation] SET childtable = 'didprogporzannokind',description = 'porzione d''anno di cui si indica la durata',lt = {ts '2018-07-19 17:42:27.337'},lu = 'assistenza',parenttable = 'didprogporzanno',title = null WHERE idrelation = '3290'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3290','didprogporzannokind','porzione d''anno di cui si indica la durata',{ts '2018-07-19 17:42:27.337'},'assistenza','didprogporzanno',null)
GO

-- FINE GENERAZIONE SCRIPT --

