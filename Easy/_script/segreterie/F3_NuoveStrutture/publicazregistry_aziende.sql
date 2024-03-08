
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


--[DBO]--
-- CREAZIONE TABELLA publicazregistry_aziende --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[publicazregistry_aziende]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[publicazregistry_aziende] (
idreg_aziende int NOT NULL,
idpublicaz int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkpublicazregistry_aziende PRIMARY KEY (idreg_aziende,
idpublicaz
)
)
END
GO

-- VERIFICA STRUTTURA publicazregistry_aziende --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazregistry_aziende' and C.name = 'idreg_aziende' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazregistry_aziende] ADD idreg_aziende int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazregistry_aziende') and col.name = 'idreg_aziende' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazregistry_aziende] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazregistry_aziende' and C.name = 'idpublicaz' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazregistry_aziende] ADD idpublicaz int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazregistry_aziende') and col.name = 'idpublicaz' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazregistry_aziende] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazregistry_aziende' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazregistry_aziende] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazregistry_aziende') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazregistry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicazregistry_aziende] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazregistry_aziende' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazregistry_aziende] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazregistry_aziende') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazregistry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicazregistry_aziende] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazregistry_aziende' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazregistry_aziende] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazregistry_aziende') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazregistry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicazregistry_aziende] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'publicazregistry_aziende' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [publicazregistry_aziende] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('publicazregistry_aziende') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [publicazregistry_aziende] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [publicazregistry_aziende] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI publicazregistry_aziende IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'publicazregistry_aziende'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazregistry_aziende','int','ASSISTENZA','idpublicaz','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazregistry_aziende','int','ASSISTENZA','idreg_aziende','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazregistry_aziende','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazregistry_aziende','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazregistry_aziende','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','publicazregistry_aziende','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI publicazregistry_aziende IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'publicazregistry_aziende')
UPDATE customobject set isreal = 'S' where objectname = 'publicazregistry_aziende'
ELSE
INSERT INTO customobject (objectname, isreal) values('publicazregistry_aziende', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'publicazregistry_aziende')
UPDATE [tabledescr] SET description = '2.4.34 Enti promotori della 2.4.27 pubblicazione in caso si tratti di ?Atti?',idapplication = null,isdbo = 'N',lt = {ts '2018-07-17 17:18:26.143'},lu = 'assistenza',title = 'Enti promotori della pubblicazione in caso si tratti di ?Atti?' WHERE tablename = 'publicazregistry_aziende'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('publicazregistry_aziende','2.4.34 Enti promotori della 2.4.27 pubblicazione in caso si tratti di ?Atti?',null,'N',{ts '2018-07-17 17:18:26.143'},'assistenza','Enti promotori della pubblicazione in caso si tratti di ?Atti?')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'publicazregistry_aziende')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:18:30.373'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'publicazregistry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','publicazregistry_aziende','8',null,null,null,'S',{ts '2018-07-17 17:18:30.373'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'publicazregistry_aziende')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:18:30.373'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'publicazregistry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','publicazregistry_aziende','64',null,null,null,'S',{ts '2018-07-17 17:18:30.373'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpublicaz' AND tablename = 'publicazregistry_aziende')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Publicazione',kind = 'S',lt = {ts '2019-02-22 17:13:43.287'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpublicaz' AND tablename = 'publicazregistry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpublicaz','publicazregistry_aziende','4',null,null,'Publicazione','S',{ts '2019-02-22 17:13:43.287'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_aziende' AND tablename = 'publicazregistry_aziende')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ente promotore',kind = 'S',lt = {ts '2019-02-22 17:13:43.287'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_aziende' AND tablename = 'publicazregistry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_aziende','publicazregistry_aziende','4',null,null,'Ente promotore','S',{ts '2019-02-22 17:13:43.287'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'publicazregistry_aziende')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:18:30.373'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'publicazregistry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','publicazregistry_aziende','8',null,null,null,'S',{ts '2018-07-17 17:18:30.373'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'publicazregistry_aziende')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 17:18:30.373'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'publicazregistry_aziende'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','publicazregistry_aziende','64',null,null,null,'S',{ts '2018-07-17 17:18:30.373'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3212')
UPDATE [relation] SET childtable = 'publicazregistry_aziende',description = 'Enti promotori',lt = {ts '2018-12-07 18:46:01.757'},lu = 'assistenza',parenttable = 'publicaz',title = 'publicazregistry_aziende' WHERE idrelation = '3212'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3212','publicazregistry_aziende','Enti promotori',{ts '2018-12-07 18:46:01.757'},'assistenza','publicaz','publicazregistry_aziende')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3214')
UPDATE [relation] SET childtable = 'publicazregistry_aziende',description = 'Atti promossi',lt = {ts '2018-12-07 19:02:14.003'},lu = 'assistenza',parenttable = 'registry_aziende',title = 'publicazregistry_aziende' WHERE idrelation = '3214'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3214','publicazregistry_aziende','Atti promossi',{ts '2018-12-07 19:02:14.003'},'assistenza','registry_aziende','publicazregistry_aziende')
GO

-- FINE GENERAZIONE SCRIPT --

