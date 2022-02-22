
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


-- CREAZIONE TABELLA perfsogliakind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfsogliakind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfsogliakind] (
idperfsogliakind varchar(50) NOT NULL,
 CONSTRAINT xpkperfsogliakind PRIMARY KEY (idperfsogliakind
)
)
END
GO

-- VERIFICA STRUTTURA perfsogliakind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfsogliakind' and C.name = 'idperfsogliakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfsogliakind] ADD idperfsogliakind varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfsogliakind') and col.name = 'idperfsogliakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfsogliakind] drop constraint '+@vincolo)
END
GO

-- VERIFICA DI perfsogliakind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfsogliakind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfsogliakind','varchar(50)','assistenza','idperfsogliakind','50','S','varchar','System.String','','','''assistenza''','','S')
GO

-- VERIFICA DI perfsogliakind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfsogliakind')
UPDATE customobject set isreal = 'S' where objectname = 'perfsogliakind'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfsogliakind', 'S')
GO

-- GENERAZIONE DATI PER perfsogliakind --
IF exists(SELECT * FROM [perfsogliakind] WHERE idperfsogliakind = 'ECCELLENZA')
UPDATE [perfsogliakind] SET WHERE idperfsogliakind = 'ECCELLENZA'
ELSE
INSERT INTO [perfsogliakind] (idperfsogliakind) VALUES ('ECCELLENZA')
GO

IF exists(SELECT * FROM [perfsogliakind] WHERE idperfsogliakind = 'SOGLIA')
UPDATE [perfsogliakind] SET WHERE idperfsogliakind = 'SOGLIA'
ELSE
INSERT INTO [perfsogliakind] (idperfsogliakind) VALUES ('SOGLIA')
GO

IF exists(SELECT * FROM [perfsogliakind] WHERE idperfsogliakind = 'TARGET')
UPDATE [perfsogliakind] SET WHERE idperfsogliakind = 'TARGET'
ELSE
INSERT INTO [perfsogliakind] (idperfsogliakind) VALUES ('TARGET')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'perfsogliakind')
UPDATE [tabledescr] SET description = 'Tipi di soglia',idapplication = null,isdbo = 'N',lt = {ts '2021-05-20 12:22:19.223'},lu = 'assistenza',title = 'Tipi di soglia' WHERE tablename = 'perfsogliakind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('perfsogliakind','Tipi di soglia',null,'N',{ts '2021-05-20 12:22:19.223'},'assistenza','Tipi di soglia')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idperfsogliakind' AND tablename = 'perfsogliakind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Denominazione del tipo di soglia',kind = 'S',lt = {ts '2021-10-28 10:55:09.443'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idperfsogliakind' AND tablename = 'perfsogliakind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idperfsogliakind','perfsogliakind','50',null,null,'Denominazione del tipo di soglia','S',{ts '2021-10-28 10:55:09.443'},'assistenza','S','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

