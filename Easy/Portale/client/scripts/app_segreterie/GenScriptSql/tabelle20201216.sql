
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


--setuser 'amministrazione'
--[DBO]--
-- CREAZIONE TABELLA assetdiary --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[assetdiary]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[assetdiary] (
idassetdiary int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idasset int NOT NULL,
idpiece int NULL,
idprogetto int NOT NULL,
idreg int NOT NULL,
idworkpackage int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
orepreventivate int NULL,
 CONSTRAINT xpkassetdiary PRIMARY KEY (idassetdiary
)
)
END
GO

-- VERIFICA STRUTTURA assetdiary --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idassetdiary' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idassetdiary int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idassetdiary' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idasset' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idasset int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idasset' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idasset int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idpiece' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idpiece int NULL 
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idpiece int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idprogetto int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idreg int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idworkpackage int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'orepreventivate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD orepreventivate int NULL 
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN orepreventivate int NULL
GO

-- VERIFICA DI assetdiary IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetdiary'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idassetdiary','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idasset','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiary','int','ASSISTENZA','idpiece','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiary','int','ASSISTENZA','orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI assetdiary IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetdiary')
UPDATE customobject set isreal = 'S' where objectname = 'assetdiary'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetdiary', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'assetdiary')
UPDATE [tabledescr] SET description = 'Diari di utilizzo dei beni strumentali relativi al workpackage di un progetto',idapplication = null,isdbo = 'S',lt = {ts '2020-06-05 16:00:02.353'},lu = 'assistenza',title = 'Diari di utilizzo dei beni strumentali' WHERE tablename = 'assetdiary'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('assetdiary','Diari di utilizzo dei beni strumentali relativi al workpackage di un progetto',null,'S',{ts '2020-06-05 16:00:02.353'},'assistenza','Diari di utilizzo dei beni strumentali')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.140'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','assetdiary','8',null,null,null,'S',{ts '2020-06-05 15:58:18.140'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.140'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','assetdiary','64',null,null,null,'S',{ts '2020-06-05 15:58:18.140'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idasset' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Bene strumentale',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idasset' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idasset','assetdiary','4',null,null,'Bene strumentale','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idassetdiary' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.140'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idassetdiary' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idassetdiary','assetdiary','4',null,null,null,'S',{ts '2020-06-05 15:58:18.140'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpiece' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero parte',kind = 'S',lt = {ts '2020-06-18 10:33:39.790'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpiece' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpiece','assetdiary','4',null,null,'Numero parte','S',{ts '2020-06-18 10:33:39.790'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','assetdiary','4',null,null,'Progetto','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Operatore',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','assetdiary','4',null,null,'Operatore','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','assetdiary','4',null,null,'Workpackage','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','assetdiary','8',null,null,null,'S',{ts '2020-06-05 15:58:18.143'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','assetdiary','64',null,null,null,'S',{ts '2020-06-05 15:58:18.143'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'orepreventivate' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore di utilizzo complessive preventivate',kind = 'S',lt = {ts '2020-06-18 10:33:39.793'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'orepreventivate' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('orepreventivate','assetdiary','4',null,null,'Ore di utilizzo complessive preventivate','S',{ts '2020-06-18 10:33:39.793'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA getprogettocostoliquidatoview
IF EXISTS(select * from sysobjects where id = object_id(N'[getprogettocostoliquidatoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getprogettocostoliquidatoview]
GO


CREATE VIEW [amministrazione].[getprogettocostoliquidatoview]
AS
SELECT      dbo.progettocosto.idprogettocosto, rp.idprogettorp, dbo.progettocosto.idprogetto, dbo.workpackage.raggruppamento, dbo.workpackage.title AS workpackage_title, dbo.progettotipocosto.title AS progettotipocosto_title, dbo.progettotipocosto.ammissibilita, dbo.progettocosto.amount, 
                         dbo.contrattokind.title AS contrattokind_title, dbo.rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, dbo.progettocosto.doc, dbo.progettocosto.docdate, amministrazione.banktransaction.transactiondate,
                          dbo.expense.description, dbo.expense.ymov, dbo.expense.nmov, amministrazione.pettycash.description AS pettycash_description, amministrazione.pettycash.pettycode AS pettycash_pettycode, dbo.progettocosto.yoperation, 
                         dbo.progettocosto.noperation
FROM            dbo.progettocosto INNER JOIN
                         dbo.workpackage ON dbo.progettocosto.idworkpackage = dbo.workpackage.idworkpackage INNER JOIN
                         dbo.progettotipocosto ON dbo.progettocosto.idprogettotipocosto = dbo.progettotipocosto.idprogettotipocosto LEFT OUTER JOIN
                         dbo.expense ON dbo.progettocosto.idexp = dbo.expense.idexp LEFT OUTER JOIN
                         dbo.rendicontattivitaprogetto ON dbo.progettocosto.idrendicontattivitaprogetto = dbo.rendicontattivitaprogetto.idrendicontattivitaprogetto LEFT OUTER JOIN
                         amministrazione.pettycash ON dbo.progettocosto.idpettycash = amministrazione.pettycash.idpettycash LEFT OUTER JOIN
                         dbo.contrattokind ON dbo.progettocosto.idcontrattokind = dbo.contrattokind.idcontrattokind LEFT OUTER JOIN
                         amministrazione.expenseyear ON dbo.expense.idexp = amministrazione.expenseyear.idexp LEFT OUTER JOIN
                         amministrazione.banktransaction ON amministrazione.expenseyear.ayear = amministrazione.banktransaction.yban AND dbo.expense.idexp = amministrazione.banktransaction.idexp
					inner join progettorp rp on rp.idprogetto= dbo.progettocosto.idprogetto 
					and amministrazione.banktransaction.transactiondate >= rp.start and amministrazione.banktransaction.transactiondate <= rp.stop

GO

-- VERIFICA DI getprogettocostoliquidatoview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getprogettocostoliquidatoview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','decimal(5,2)','assistenza','ammissibilita','5','N','decimal','System.Decimal','','2','''assistenza''','5','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','decimal(9,2)','assistenza','amount','5','N','decimal','System.Decimal','','2','''assistenza''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','varchar(50)','assistenza','contrattokind_title','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','varchar(150)','assistenza','description','150','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','varchar(35)','assistenza','doc','35','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','date','assistenza','docdate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoliquidatoview','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoliquidatoview','int','assistenza','idprogettocosto','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoliquidatoview','int','assistenza','idprogettorp','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','int','assistenza','nmov','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','int','assistenza','noperation','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','varchar(50)','assistenza','pettycash_description','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','varchar(20)','assistenza','pettycash_pettycode','20','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','varchar(2048)','assistenza','progettotipocosto_title','2048','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','nvarchar(2048)','assistenza','raggruppamento','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','varchar(max)','assistenza','rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','date','assistenza','transactiondate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','nvarchar(2048)','assistenza','workpackage_title','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','smallint','assistenza','ymov','2','N','smallint','System.Int16','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoview','smallint','assistenza','yoperation','2','N','smallint','System.Int16','','','''assistenza''','','N')
GO

-- VERIFICA DI getprogettocostoliquidatoview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getprogettocostoliquidatoview')
UPDATE customobject set isreal = 'N' where objectname = 'getprogettocostoliquidatoview'
ELSE
INSERT INTO customobject (objectname, isreal) values('getprogettocostoliquidatoview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA getprogettocostoview
IF EXISTS(select * from sysobjects where id = object_id(N'[getprogettocostoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getprogettocostoview]
GO



CREATE VIEW [amministrazione].[getprogettocostoview]
AS
SELECT      dbo.progettocosto.idprogettocosto, rp.idprogettorp, dbo.progettocosto.idprogetto, dbo.workpackage.raggruppamento, dbo.workpackage.title AS workpackage_title, dbo.progettotipocosto.title AS progettotipocosto_title, dbo.progettotipocosto.ammissibilita, dbo.progettocosto.amount, 
                         dbo.contrattokind.title AS contrattokind_title, dbo.rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, dbo.progettocosto.doc, dbo.progettocosto.docdate, amministrazione.banktransaction.transactiondate,
                          dbo.expense.description, dbo.expense.ymov, dbo.expense.nmov, amministrazione.pettycash.description AS pettycash_description, amministrazione.pettycash.pettycode AS pettycash_pettycode, dbo.progettocosto.yoperation, 
                         dbo.progettocosto.noperation
FROM            dbo.progettocosto INNER JOIN
                         dbo.workpackage ON dbo.progettocosto.idworkpackage = dbo.workpackage.idworkpackage INNER JOIN
                         dbo.progettotipocosto ON dbo.progettocosto.idprogettotipocosto = dbo.progettotipocosto.idprogettotipocosto LEFT OUTER JOIN
                         dbo.expense ON dbo.progettocosto.idexp = dbo.expense.idexp LEFT OUTER JOIN
                         dbo.rendicontattivitaprogetto ON dbo.progettocosto.idrendicontattivitaprogetto = dbo.rendicontattivitaprogetto.idrendicontattivitaprogetto LEFT OUTER JOIN
                         amministrazione.pettycash ON dbo.progettocosto.idpettycash = amministrazione.pettycash.idpettycash LEFT OUTER JOIN
                         dbo.contrattokind ON dbo.progettocosto.idcontrattokind = dbo.contrattokind.idcontrattokind LEFT OUTER JOIN
                         amministrazione.expenseyear ON dbo.expense.idexp = amministrazione.expenseyear.idexp LEFT OUTER JOIN
                         amministrazione.banktransaction ON amministrazione.expenseyear.ayear = amministrazione.banktransaction.yban AND dbo.expense.idexp = amministrazione.banktransaction.idexp
					inner join progettorp rp on rp.idprogetto= dbo.progettocosto.idprogetto 
					and dbo.progettocosto.docdate >= rp.start and dbo.progettocosto.docdate <= rp.stop

GO

-- VERIFICA DI getprogettocostoview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getprogettocostoview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','decimal(5,2)','assistenza','ammissibilita','5','N','decimal','System.Decimal','','2','''assistenza''','5','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','decimal(9,2)','assistenza','amount','5','N','decimal','System.Decimal','','2','''assistenza''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(50)','assistenza','contrattokind_title','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(150)','assistenza','description','150','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(35)','assistenza','doc','35','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','date','assistenza','docdate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoview','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoview','int','assistenza','idprogettocosto','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoview','int','assistenza','idprogettorp','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','int','assistenza','nmov','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','int','assistenza','noperation','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(50)','assistenza','pettycash_description','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(20)','assistenza','pettycash_pettycode','20','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(2048)','assistenza','progettotipocosto_title','2048','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','nvarchar(2048)','assistenza','raggruppamento','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(max)','assistenza','rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','date','assistenza','transactiondate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','nvarchar(2048)','assistenza','workpackage_title','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','smallint','assistenza','ymov','2','N','smallint','System.Int16','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','smallint','assistenza','yoperation','2','N','smallint','System.Int16','','','''assistenza''','','N')
GO

-- VERIFICA DI getprogettocostoview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getprogettocostoview')
UPDATE customobject set isreal = 'N' where objectname = 'getprogettocostoview'
ELSE
INSERT INTO customobject (objectname, isreal) values('getprogettocostoview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progetto] (
idprogetto int NOT NULL,
budget decimal(14,2) NULL,
budgetcalcolato decimal(14,2) NULL,
budgetcalcolatodate datetime NULL,
capofilatxt nvarchar(2048) NULL,
codiceidentificativo varchar(2048) NULL,
contributo decimal(14,2) NULL,
contributoente decimal(14,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cup varchar(15) NULL,
data date NULL,
datacontabile date NULL,
description nvarchar(max) NULL,
durata int NULL,
finanziatoretxt nvarchar(2048) NULL,
idcorsostudio int NULL,
idcurrency int NULL,
idduratakind int NULL,
idprogettokind int NULL,
idprogettostatuskind int NULL,
idreg int NULL,
idreg_aziende int NULL,
idreg_aziende_fin int NULL,
idregistryprogfin int NULL,
idregistryprogfinbando int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start date NULL,
stop date NULL,
title nvarchar(4000) NULL,
titolobreve nvarchar(2048) NULL,
totalbudget decimal(14,2) NULL,
totalcontributo decimal(14,2) NULL,
url varchar(1024) NULL,
 CONSTRAINT xpkprogetto PRIMARY KEY (idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progetto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'budget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD budget decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN budget decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'budgetcalcolato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD budgetcalcolato decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN budgetcalcolato decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'budgetcalcolatodate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD budgetcalcolatodate datetime NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN budgetcalcolatodate datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'capofilatxt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD capofilatxt nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN capofilatxt nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'codiceidentificativo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD codiceidentificativo varchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN codiceidentificativo varchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'contributo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD contributo decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN contributo decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'contributoente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD contributoente decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN contributoente decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'cup' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD cup varchar(15) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN cup varchar(15) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD data date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'datacontabile' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD datacontabile date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN datacontabile date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'durata' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD durata int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN durata int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'finanziatoretxt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD finanziatoretxt nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN finanziatoretxt nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idcorsostudio int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idcorsostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idcurrency int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idcurrency int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idduratakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idduratakind int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idduratakind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idprogettokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idprogettokind int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idprogettokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idprogettostatuskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idprogettostatuskind int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idprogettostatuskind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idreg_aziende' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idreg_aziende int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idreg_aziende int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idreg_aziende_fin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idreg_aziende_fin int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idreg_aziende_fin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idregistryprogfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idregistryprogfin int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idregistryprogfin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idregistryprogfinbando' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idregistryprogfinbando int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idregistryprogfinbando int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD start date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD stop date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD title nvarchar(4000) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN title nvarchar(4000) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'titolobreve' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD titolobreve nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN titolobreve nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'totalbudget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD totalbudget decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN totalbudget decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'totalcontributo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD totalcontributo decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN totalcontributo decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'url' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD url varchar(1024) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN url varchar(1024) NULL
GO

-- VERIFICA DI progetto IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progetto'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','budget','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','budgetcalcolato','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','datetime','assistenza','budgetcalcolatodate','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(2048)','assistenza','capofilatxt','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','varchar(2048)','assistenza','codiceidentificativo','2048','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','contributo','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','contributoente','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','varchar(15)','assistenza','cup','15','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','date','assistenza','data','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','date','assistenza','datacontabile','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(max)','assistenza','description','0','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','durata','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(2048)','assistenza','finanziatoretxt','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idcorsostudio','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idcurrency','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idduratakind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idprogettokind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idprogettostatuskind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idreg','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idreg_aziende','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idreg_aziende_fin','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idregistryprogfin','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idregistryprogfinbando','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','date','assistenza','start','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','date','assistenza','stop','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(4000)','assistenza','title','4000','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(2048)','assistenza','titolobreve','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','totalbudget','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','totalcontributo','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','varchar(1024)','assistenza','url','1024','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI progetto IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progetto')
UPDATE customobject set isreal = 'S' where objectname = 'progetto'
ELSE
INSERT INTO customobject (objectname, isreal) values('progetto', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progetto')
UPDATE [tabledescr] SET description = 'Progetto di ricerca',idapplication = null,isdbo = 'N',lt = {ts '2020-05-20 14:00:37.623'},lu = 'assistenza',title = 'Progetto di ricerca' WHERE tablename = 'progetto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progetto','Progetto di ricerca',null,'N',{ts '2020-05-20 14:00:37.623'},'assistenza','Progetto di ricerca')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'budget' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Costo totale per l''ateneo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budget' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budget','progetto','9','14','2','Costo totale per l''ateneo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'budgetcalcolato' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Costo totale effettivo per l''ateneo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budgetcalcolato' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budgetcalcolato','progetto','9','14','2','Costo totale effettivo per l''ateneo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'budgetcalcolatodate' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Calcolato il',kind = 'S',lt = {ts '2020-10-26 10:44:21.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'budgetcalcolatodate' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budgetcalcolatodate','progetto','8',null,null,'Calcolato il','S',{ts '2020-10-26 10:44:21.677'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'capofilatxt' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Ente capofila non censito',kind = 'S',lt = {ts '2020-10-26 10:22:18.617'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'capofilatxt' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('capofilatxt','progetto','2048',null,null,'Ente capofila non censito','S',{ts '2020-10-26 10:22:18.617'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codiceidentificativo' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Codice identificativo',kind = 'S',lt = {ts '2020-10-30 08:33:43.240'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codiceidentificativo' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codiceidentificativo','progetto','2048',null,null,'Codice identificativo','S',{ts '2020-10-30 08:33:43.240'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributo' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Cofinanziamento richiesto all''ateneo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contributo' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributo','progetto','9','14','2','Cofinanziamento richiesto all''ateneo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributoente' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Contributo totale richiesto dall''ateneo all’ente finanziatore',kind = 'S',lt = {ts '2020-11-04 16:51:02.247'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contributoente' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributoente','progetto','9','14','2','Contributo totale richiesto dall''ateneo all’ente finanziatore','S',{ts '2020-11-04 16:51:02.247'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progetto','8',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progetto','64',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cup' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '15',col_precision = null,col_scale = null,description = 'Codice univoco progetto (CUP)',kind = 'S',lt = {ts '2020-10-30 17:51:30.213'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(15)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cup' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cup','progetto','15',null,null,'Codice univoco progetto (CUP)','S',{ts '2020-10-30 17:51:30.213'},'assistenza','N','varchar(15)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di presentazione',kind = 'S',lt = {ts '2020-05-25 13:14:10.947'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','progetto','3',null,null,'Data di presentazione','S',{ts '2020-05-25 13:14:10.947'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datacontabile' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data chiusura contablile',kind = 'S',lt = {ts '2020-12-09 12:56:24.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datacontabile' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datacontabile','progetto','3',null,null,'Data chiusura contablile','S',{ts '2020-12-09 12:56:24.963'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-05-20 14:03:58.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','progetto','0',null,null,'Descrizione','S',{ts '2020-05-20 14:03:58.150'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'durata' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:11:44.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'durata' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('durata','progetto','4',null,null,null,'S',{ts '2020-05-25 13:11:44.723'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanziatoretxt' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Ente finanziatore non censito',kind = 'S',lt = {ts '2020-10-26 10:22:18.617'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'finanziatoretxt' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanziatoretxt','progetto','2048',null,null,'Ente finanziatore non censito','S',{ts '2020-10-26 10:22:18.617'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Didattica',kind = 'S',lt = {ts '2020-06-05 15:48:03.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','progetto','4',null,null,'Didattica','S',{ts '2020-06-05 15:48:03.440'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcurrency' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice valuta',kind = 'S',lt = {ts '2020-11-02 18:34:42.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcurrency' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcurrency','progetto','4',null,null,'Codice valuta','S',{ts '2020-11-02 18:34:42.180'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idduratakind' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Espressa in',kind = 'S',lt = {ts '2020-05-25 13:14:10.947'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idduratakind' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idduratakind','progetto','4',null,null,'Espressa in','S',{ts '2020-05-25 13:14:10.947'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice interno',kind = 'S',lt = {ts '2020-10-30 08:33:16.517'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progetto','4',null,null,'Codice interno','S',{ts '2020-10-30 08:33:16.517'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettokind' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo di progetto o attività',kind = 'S',lt = {ts '2020-11-04 16:52:57.667'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettokind' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettokind','progetto','4',null,null,'Tipo di progetto o attività','S',{ts '2020-11-04 16:52:57.667'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettostatuskind' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato del progetto o attività',kind = 'S',lt = {ts '2020-09-30 16:14:37.087'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettostatuskind' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettostatuskind','progetto','4',null,null,'Stato del progetto o attività','S',{ts '2020-09-30 16:14:37.087'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Principal investigator / Responsabile di progetto ',kind = 'S',lt = {ts '2020-07-15 17:09:18.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','progetto','4',null,null,'Principal investigator / Responsabile di progetto ','S',{ts '2020-07-15 17:09:18.147'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_aziende' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ente capofila',kind = 'S',lt = {ts '2020-06-12 15:56:06.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_aziende' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_aziende','progetto','4',null,null,'Ente capofila','S',{ts '2020-06-12 15:56:06.547'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_aziende_fin' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ente finanziatore',kind = 'S',lt = {ts '2020-06-12 15:56:06.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_aziende_fin' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_aziende_fin','progetto','4',null,null,'Ente finanziatore','S',{ts '2020-06-12 15:56:06.547'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryprogfin' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Programma di finanziamento',kind = 'S',lt = {ts '2020-06-12 15:56:06.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistryprogfin' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryprogfin','progetto','4',null,null,'Programma di finanziamento','S',{ts '2020-06-12 15:56:06.547'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryprogfinbando' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Bando di riferimento',kind = 'S',lt = {ts '2020-06-12 18:11:47.253'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistryprogfinbando' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryprogfinbando','progetto','4',null,null,'Bando di riferimento','S',{ts '2020-06-12 18:11:47.253'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progetto','8',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progetto','64',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di inizio',kind = 'S',lt = {ts '2020-06-05 15:48:03.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','progetto','3',null,null,'Data di inizio','S',{ts '2020-06-05 15:48:03.440'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di fine',kind = 'S',lt = {ts '2020-06-05 15:48:03.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','progetto','3',null,null,'Data di fine','S',{ts '2020-06-05 15:48:03.440'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4000',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(4000)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progetto','4000',null,null,'Titolo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','nvarchar(4000)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'titolobreve' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo breve o acronimo',kind = 'S',lt = {ts '2020-05-20 14:03:58.153'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'titolobreve' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('titolobreve','progetto','2048',null,null,'Titolo breve o acronimo','S',{ts '2020-05-20 14:03:58.153'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totalbudget' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Costo globale del progetto per tutto il partenariato',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totalbudget' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totalbudget','progetto','9','14','2','Costo globale del progetto per tutto il partenariato','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totalcontributo' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Contributo globale del progetto per tutto il partenariato',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totalcontributo' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totalcontributo','progetto','9','14','2','Contributo globale del progetto per tutto il partenariato','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'url' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'URL del sito del progetto',kind = 'S',lt = {ts '2020-11-02 18:28:26.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'url' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('url','progetto','1024',null,null,'URL del sito del progetto','S',{ts '2020-11-02 18:28:26.997'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettorp --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettorp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettorp] (
idprogettorp int NOT NULL,
idprogetto int NOT NULL,
start date NULL,
stop date NULL,
 CONSTRAINT xpkprogettorp PRIMARY KEY (idprogettorp,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettorp --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettorp' and C.name = 'idprogettorp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettorp] ADD idprogettorp int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettorp') and col.name = 'idprogettorp' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettorp] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettorp' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettorp] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettorp') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettorp] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettorp' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettorp] ADD start date NULL 
END
ELSE
	ALTER TABLE [progettorp] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettorp' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettorp] ADD stop date NULL 
END
ELSE
	ALTER TABLE [progettorp] ALTER COLUMN stop date NULL
GO

-- VERIFICA DI progettorp IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettorp'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettorp','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettorp','int','assistenza','idprogettorp','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettorp','date','assistenza','start','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettorp','date','assistenza','stop','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

-- VERIFICA DI progettorp IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettorp')
UPDATE customobject set isreal = 'S' where objectname = 'progettorp'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettorp', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettorp')
UPDATE [tabledescr] SET description = 'Reporting periods',idapplication = null,isdbo = 'N',lt = {ts '2020-12-15 15:18:22.503'},lu = 'assistenza',title = 'Reporting periods' WHERE tablename = 'progettorp'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettorp','Reporting periods',null,'N',{ts '2020-12-15 15:18:22.503'},'assistenza','Reporting periods')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettorp')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-12-15 15:17:14.070'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettorp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettorp','4',null,null,null,'S',{ts '2020-12-15 15:17:14.070'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettorp' AND tablename = 'progettorp')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-12-15 15:17:14.070'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettorp' AND tablename = 'progettorp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettorp','progettorp','4',null,null,null,'S',{ts '2020-12-15 15:17:14.070'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'progettorp')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di inizio',kind = 'S',lt = {ts '2020-12-15 15:18:09.613'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'progettorp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','progettorp','3',null,null,'Data di inizio','S',{ts '2020-12-15 15:18:09.613'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'progettorp')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di fine',kind = 'S',lt = {ts '2020-12-15 15:18:09.613'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'progettorp'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','progettorp','3',null,null,'Data di fine','S',{ts '2020-12-15 15:18:09.613'},'assistenza','N','date','date','System.DateTime')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA assetdiarydocview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[assetdiarydocview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[assetdiarydocview]
GO

CREATE VIEW [dbo].[assetdiarydocview] AS SELECT  assetdiary.ct AS assetdiary_ct, assetdiary.cu AS assetdiary_cu, assetdiary.idasset AS assetdiary_idasset, assetdiary.idassetdiary, amministrazione.assetacquire.description AS assetacquire_description, amministrazione.assetacquire.idinv AS assetacquire_idinv, amministrazione.asset.idasset AS asset_idasset, amministrazione.asset.idpiece AS asset_idpiece, amministrazione.inventory.description AS inventory_description, amministrazione.asset.ninventory AS asset_ninventory, amministrazione.asset.rfid AS asset_rfid, assetdiary.idpiece, progetto.titolobreve AS progetto_titolobreve, assetdiary.idprogetto, assetdiary.idreg AS assetdiary_idreg, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, assetdiary.idworkpackage AS assetdiary_idworkpackage, assetdiary.lt AS assetdiary_lt, assetdiary.lu AS assetdiary_lu, assetdiary.orepreventivate AS assetdiary_orepreventivate, isnull('Descrizione Descrizione: ' + amministrazione.assetacquire.description + '; ','') + ' ' + isnull('Class. Inv. Descrizione: ' + CAST( amministrazione.assetacquire.idinv AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( amministrazione.asset.idasset AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( amministrazione.asset.idpiece AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( amministrazione.asset.ninventory AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + amministrazione.asset.rfid + '; ','') + ' ' + isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Descrizione Inventario: ' + amministrazione.inventory.description + '; ','') as dropdown_title FROM assetdiary WITH (NOLOCK)  LEFT OUTER JOIN amministrazione.asset WITH (NOLOCK) ON assetdiary.idasset = amministrazione.asset.idasset AND assetdiary.idpiece = amministrazione.asset.idpiece LEFT OUTER JOIN amministrazione.assetacquire WITH (NOLOCK) ON asset.nassetacquire = amministrazione.assetacquire.nassetacquire LEFT OUTER JOIN amministrazione.inventory WITH (NOLOCK) ON asset.idinventory = amministrazione.inventory.idinventory LEFT OUTER JOIN progetto WITH (NOLOCK) ON assetdiary.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON assetdiary.idworkpackage = workpackage.idworkpackage WHERE  assetdiary.idassetdiary IS NOT NULL 
GO

-- VERIFICA DI assetdiarydocview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetdiarydocview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','int','','asset_idasset','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','int','','asset_idpiece','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','int','','asset_ninventory','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','varchar(30)','','asset_rfid','30','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','varchar(150)','','assetacquire_description','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','int','','assetacquire_idinv','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','datetime','','assetdiary_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','varchar(64)','','assetdiary_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','int','','assetdiary_idasset','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','int','','assetdiary_idreg','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','int','','assetdiary_idworkpackage','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','datetime','','assetdiary_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','varchar(64)','','assetdiary_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','int','','assetdiary_orepreventivate','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','nvarchar(2713)','','dropdown_title','2713','S','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','int','','idassetdiary','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','int','','idpiece','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','int','','idprogetto','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','varchar(50)','','inventory_description','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','nvarchar(2048)','','progetto_titolobreve','2048','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','nvarchar(2048)','','workpackage_raggruppamento','2048','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','nvarchar(2048)','','workpackage_title','2048','N','nvarchar','System.String','','','','','N')
GO

-- VERIFICA DI assetdiarydocview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetdiarydocview')
UPDATE customobject set isreal = 'N' where objectname = 'assetdiarydocview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetdiarydocview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA getprogettocostoliquidatoviewdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getprogettocostoliquidatoviewdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getprogettocostoliquidatoviewdefaultview]
GO

CREATE VIEW [dbo].[getprogettocostoliquidatoviewdefaultview] AS SELECT  getprogettocostoliquidatoview.ammissibilita AS getprogettocostoliquidatoview_ammissibilita, getprogettocostoliquidatoview.amount AS getprogettocostoliquidatoview_amount, getprogettocostoliquidatoview.contrattokind_title AS getprogettocostoliquidatoview_contrattokind_title, getprogettocostoliquidatoview.description AS getprogettocostoliquidatoview_description, getprogettocostoliquidatoview.doc AS getprogettocostoliquidatoview_doc, getprogettocostoliquidatoview.docdate AS getprogettocostoliquidatoview_docdate, getprogettocostoliquidatoview.idprogetto, getprogettocostoliquidatoview.idprogettocosto, getprogettocostoliquidatoview.idprogettorp, getprogettocostoliquidatoview.nmov AS getprogettocostoliquidatoview_nmov, getprogettocostoliquidatoview.noperation AS getprogettocostoliquidatoview_noperation, getprogettocostoliquidatoview.pettycash_description AS getprogettocostoliquidatoview_pettycash_description, getprogettocostoliquidatoview.pettycash_pettycode AS getprogettocostoliquidatoview_pettycash_pettycode, getprogettocostoliquidatoview.progettotipocosto_title AS getprogettocostoliquidatoview_progettotipocosto_title, getprogettocostoliquidatoview.raggruppamento, getprogettocostoliquidatoview.rendicontattivitaprogetto_description AS getprogettocostoliquidatoview_rendicontattivitaprogetto_description, getprogettocostoliquidatoview.transactiondate AS getprogettocostoliquidatoview_transactiondate, getprogettocostoliquidatoview.workpackage_title AS getprogettocostoliquidatoview_workpackage_title, getprogettocostoliquidatoview.ymov AS getprogettocostoliquidatoview_ymov, getprogettocostoliquidatoview.yoperation AS getprogettocostoliquidatoview_yoperation, isnull('Raggruppamento: ' + getprogettocostoliquidatoview.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + getprogettocostoliquidatoview.workpackage_title + '; ','') + ' ' + isnull('Voce di costo: ' + getprogettocostoliquidatoview.progettotipocosto_title + '; ','') as dropdown_title FROM amministrazione.getprogettocostoliquidatoview WITH (NOLOCK)  WHERE  getprogettocostoliquidatoview.idprogetto IS NOT NULL  AND getprogettocostoliquidatoview.idprogettocosto IS NOT NULL  AND getprogettocostoliquidatoview.idprogettorp IS NOT NULL 
GO

-- VERIFICA DI getprogettocostoliquidatoviewdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getprogettocostoliquidatoviewdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoliquidatoviewdefaultview','nvarchar(4000)','','dropdown_title','4000','S','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','decimal(5,2)','','getprogettocostoliquidatoview_ammissibilita','5','N','decimal','System.Decimal','','2','','5','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','decimal(9,2)','','getprogettocostoliquidatoview_amount','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','varchar(50)','','getprogettocostoliquidatoview_contrattokind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','varchar(150)','','getprogettocostoliquidatoview_description','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','varchar(35)','','getprogettocostoliquidatoview_doc','35','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','date','','getprogettocostoliquidatoview_docdate','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','int','','getprogettocostoliquidatoview_nmov','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','int','','getprogettocostoliquidatoview_noperation','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','varchar(50)','','getprogettocostoliquidatoview_pettycash_description','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','varchar(20)','','getprogettocostoliquidatoview_pettycash_pettycode','20','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','varchar(2048)','','getprogettocostoliquidatoview_progettotipocosto_title','2048','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','varchar(max)','','getprogettocostoliquidatoview_rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','date','','getprogettocostoliquidatoview_transactiondate','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','nvarchar(2048)','','getprogettocostoliquidatoview_workpackage_title','2048','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','smallint','','getprogettocostoliquidatoview_ymov','2','N','smallint','System.Int16','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','smallint','','getprogettocostoliquidatoview_yoperation','2','N','smallint','System.Int16','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoliquidatoviewdefaultview','int','','idprogetto','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoliquidatoviewdefaultview','int','','idprogettocosto','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoliquidatoviewdefaultview','int','','idprogettorp','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoliquidatoviewdefaultview','nvarchar(2048)','','raggruppamento','2048','N','nvarchar','System.String','','','','','N')
GO

-- VERIFICA DI getprogettocostoliquidatoviewdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getprogettocostoliquidatoviewdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'getprogettocostoliquidatoviewdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('getprogettocostoliquidatoviewdefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA getprogettocostoviewdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getprogettocostoviewdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getprogettocostoviewdefaultview]
GO

CREATE VIEW [dbo].[getprogettocostoviewdefaultview] AS SELECT  getprogettocostoview.ammissibilita AS getprogettocostoview_ammissibilita, getprogettocostoview.amount AS getprogettocostoview_amount, getprogettocostoview.contrattokind_title AS getprogettocostoview_contrattokind_title, getprogettocostoview.description AS getprogettocostoview_description, getprogettocostoview.doc AS getprogettocostoview_doc, getprogettocostoview.docdate AS getprogettocostoview_docdate, getprogettocostoview.idprogetto, getprogettocostoview.idprogettocosto, getprogettocostoview.idprogettorp, getprogettocostoview.nmov AS getprogettocostoview_nmov, getprogettocostoview.noperation AS getprogettocostoview_noperation, getprogettocostoview.pettycash_description AS getprogettocostoview_pettycash_description, getprogettocostoview.pettycash_pettycode AS getprogettocostoview_pettycash_pettycode, getprogettocostoview.progettotipocosto_title AS getprogettocostoview_progettotipocosto_title, getprogettocostoview.raggruppamento, getprogettocostoview.rendicontattivitaprogetto_description AS getprogettocostoview_rendicontattivitaprogetto_description, getprogettocostoview.transactiondate AS getprogettocostoview_transactiondate, getprogettocostoview.workpackage_title AS getprogettocostoview_workpackage_title, getprogettocostoview.ymov AS getprogettocostoview_ymov, getprogettocostoview.yoperation AS getprogettocostoview_yoperation, isnull('Raggruppamento: ' + getprogettocostoview.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + getprogettocostoview.workpackage_title + '; ','') + ' ' + isnull('Voce di costo: ' + getprogettocostoview.progettotipocosto_title + '; ','') as dropdown_title FROM amministrazione.getprogettocostoview WITH (NOLOCK)  WHERE  getprogettocostoview.idprogetto IS NOT NULL  AND getprogettocostoview.idprogettocosto IS NOT NULL  AND getprogettocostoview.idprogettorp IS NOT NULL 
GO

-- VERIFICA DI getprogettocostoviewdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getprogettocostoviewdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoviewdefaultview','nvarchar(4000)','','dropdown_title','4000','S','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','decimal(5,2)','','getprogettocostoview_ammissibilita','5','N','decimal','System.Decimal','','2','','5','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','decimal(9,2)','','getprogettocostoview_amount','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','varchar(50)','','getprogettocostoview_contrattokind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','varchar(150)','','getprogettocostoview_description','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','varchar(35)','','getprogettocostoview_doc','35','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','date','','getprogettocostoview_docdate','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','int','','getprogettocostoview_nmov','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','int','','getprogettocostoview_noperation','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','varchar(50)','','getprogettocostoview_pettycash_description','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','varchar(20)','','getprogettocostoview_pettycash_pettycode','20','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','varchar(2048)','','getprogettocostoview_progettotipocosto_title','2048','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','varchar(max)','','getprogettocostoview_rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','date','','getprogettocostoview_transactiondate','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','nvarchar(2048)','','getprogettocostoview_workpackage_title','2048','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','smallint','','getprogettocostoview_ymov','2','N','smallint','System.Int16','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','smallint','','getprogettocostoview_yoperation','2','N','smallint','System.Int16','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoviewdefaultview','int','','idprogetto','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoviewdefaultview','int','','idprogettocosto','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoviewdefaultview','int','','idprogettorp','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoviewdefaultview','nvarchar(2048)','','raggruppamento','2048','N','nvarchar','System.String','','','','','N')
GO

-- VERIFICA DI getprogettocostoviewdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getprogettocostoviewdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'getprogettocostoviewdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('getprogettocostoviewdefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA progettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[progettosegview]
GO

CREATE VIEW [dbo].[progettosegview] AS SELECT  progetto.budget AS progetto_budget, progetto.budgetcalcolato AS progetto_budgetcalcolato, progetto.budgetcalcolatodate AS progetto_budgetcalcolatodate, progetto.capofilatxt AS progetto_capofilatxt, progetto.codiceidentificativo AS progetto_codiceidentificativo, progetto.contributo AS progetto_contributo, progetto.contributoente AS progetto_contributoente, progetto.ct AS progetto_ct, progetto.cu AS progetto_cu, progetto.cup AS progetto_cup, progetto.data AS progetto_data, progetto.datacontabile AS progetto_datacontabile, progetto.description AS progetto_description, progetto.durata AS progetto_durata, progetto.finanziatoretxt AS progetto_finanziatoretxt, corsostudio.title AS corsostudio_title, corsostudio.annoistituz AS corsostudio_annoistituz, progetto.idcorsostudio, currency.codecurrency AS currency_codecurrency, progetto.idcurrency, duratakind.title AS duratakind_title, progetto.idduratakind AS progetto_idduratakind, progetto.idprogetto, progettokind.title AS progettokind_title, progetto.idprogettokind AS progetto_idprogettokind, progettostatuskind.title AS progettostatuskind_title, progetto.idprogettostatuskind AS progetto_idprogettostatuskind, registry.title AS registry_title, progetto.idreg, registry_registry_aziendeaziende.title AS registryaziende_title, progetto.idreg_aziende, registry_registry_aziendeaziende_fin.title AS registryaziende_fin_title, progetto.idreg_aziende_fin, registryprogfin.title AS registryprogfin_title, registryprogfin.code AS registryprogfin_code, progetto.idregistryprogfin AS progetto_idregistryprogfin, registryprogfinbando.title AS registryprogfinbando_title, registryprogfinbando.number AS registryprogfinbando_number, registryprogfinbando.scadenza AS registryprogfinbando_scadenza, progetto.idregistryprogfinbando AS progetto_idregistryprogfinbando, progetto.lt AS progetto_lt, progetto.lu AS progetto_lu, progetto.start AS progetto_start, progetto.stop AS progetto_stop, progetto.title AS progetto_title, progetto.titolobreve, progetto.totalbudget AS progetto_totalbudget, progetto.totalcontributo AS progetto_totalcontributo, progetto.url AS progetto_url, isnull('Titolo breve o acronimo: ' + progetto.titolobreve + '; ','') as dropdown_title FROM progetto WITH (NOLOCK)  LEFT OUTER JOIN corsostudio WITH (NOLOCK) ON progetto.idcorsostudio = corsostudio.idcorsostudio LEFT OUTER JOIN currency WITH (NOLOCK) ON progetto.idcurrency = currency.idcurrency LEFT OUTER JOIN duratakind WITH (NOLOCK) ON progetto.idduratakind = duratakind.idduratakind LEFT OUTER JOIN progettokind WITH (NOLOCK) ON progetto.idprogettokind = progettokind.idprogettokind LEFT OUTER JOIN progettostatuskind WITH (NOLOCK) ON progetto.idprogettostatuskind = progettostatuskind.idprogettostatuskind LEFT OUTER JOIN registry WITH (NOLOCK) ON progetto.idreg = registry.idreg LEFT OUTER JOIN registry_aziende AS registry_aziendeaziende WITH (NOLOCK) ON progetto.idreg_aziende = registry_aziendeaziende.idreg LEFT OUTER JOIN registry AS registry_registry_aziendeaziende WITH (NOLOCK) ON registry_aziendeaziende.idreg = registry_registry_aziendeaziende.idreg LEFT OUTER JOIN registry_aziende AS registry_aziendeaziende_fin WITH (NOLOCK) ON progetto.idreg_aziende_fin = registry_aziendeaziende_fin.idreg LEFT OUTER JOIN registry AS registry_registry_aziendeaziende_fin WITH (NOLOCK) ON registry_aziendeaziende_fin.idreg = registry_registry_aziendeaziende_fin.idreg LEFT OUTER JOIN registryprogfin WITH (NOLOCK) ON progetto.idregistryprogfin = registryprogfin.idregistryprogfin LEFT OUTER JOIN registryprogfinbando WITH (NOLOCK) ON progetto.idregistryprogfinbando = registryprogfinbando.idregistryprogfinbando WHERE  progetto.idprogetto IS NOT NULL 
GO

-- VERIFICA DI progettosegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettosegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','corsostudio_annoistituz','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(1024)','ASSISTENZA','corsostudio_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(20)','','currency_codecurrency','20','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','nvarchar(2075)','ASSISTENZA','dropdown_title','2075','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(50)','ASSISTENZA','duratakind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','','idcurrency','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','idreg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','idreg_aziende','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','idreg_aziende_fin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_budget','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_budgetcalcolato','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','datetime','ASSISTENZA','progetto_budgetcalcolatodate','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','progetto_capofilatxt','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(2048)','','progetto_codiceidentificativo','2048','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_contributo','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_contributoente','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','datetime','ASSISTENZA','progetto_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','varchar(64)','ASSISTENZA','progetto_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(15)','ASSISTENZA','progetto_cup','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','ASSISTENZA','progetto_data','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','','progetto_datacontabile','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(max)','ASSISTENZA','progetto_description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_durata','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','progetto_finanziatoretxt','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idduratakind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idprogettokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idprogettostatuskind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idregistryprogfin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idregistryprogfinbando','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','datetime','ASSISTENZA','progetto_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','varchar(64)','ASSISTENZA','progetto_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','ASSISTENZA','progetto_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','ASSISTENZA','progetto_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(4000)','ASSISTENZA','progetto_title','4000','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_totalbudget','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','','progetto_totalcontributo','9','N','decimal','System.Decimal','','2','','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(1024)','','progetto_url','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','progettokind_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(50)','ASSISTENZA','progettostatuskind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(101)','ASSISTENZA','registryaziende_fin_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(101)','ASSISTENZA','registryaziende_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','registryprogfin_code','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','registryprogfin_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','registryprogfinbando_number','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','ASSISTENZA','registryprogfinbando_scadenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','registryprogfinbando_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','titolobreve','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettosegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettosegview')
UPDATE customobject set isreal = 'N' where objectname = 'progettosegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettosegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE PROCEDURE [amministrazione].[compute_assetdiaryora]
IF EXISTS (select * from sysobjects where id = object_id(N'[amministrazione].[compute_assetdiaryora]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [amministrazione].[compute_assetdiaryora]
GO
CREATE PROCEDURE [amministrazione].[compute_assetdiaryora] 
(
	@max_ayear int, 
	@max_mese int,
	@idprogetto int
)
as begin 
--185.56.8.51,5839
-- Per ogni mese si calcola la proporzione di ore di utilizzo dell'asset

	create table #oremesicespite(sommeore int, mese int, idasset int, idpiece int, ayear int)
	--sommeore : indica quante ore è stato usato il bene nel mese indicato @max_mese

	;WITH curr_asset (idassetdiary, idpiece) as
	(
	select idassetdiary, idpiece 
	from 	assetdiary
	where idprogetto = @idprogetto
	group by idassetdiary, idpiece 
	)
	insert into #oremesicespite(sommeore, idasset, idpiece , ayear, mese)
	select	sum(DATEDIFF(hour, ADETT.start, ADETT.stop)) as SommaOreDx,
			AD.idasset, 
			AD.idpiece, --, AD.idprogetto
			year(ADETT.start), month(ADETT.start)
	 from assetdiary AD 
	join  assetdiaryora ADETT 
		on AD.idassetdiary = ADETT.idassetdiary
	join asset A 
		on AD.idasset = A.idasset and AD.idpiece = A.idpiece
	join curr_asset CA
		on CA.idassetdiary = A.idasset and CA.idpiece = A.idpiece
		where month(ADETT.start) <= @max_mese 
		and year (ADETT.start) <= @max_ayear		
		-- Vanno considerati solo i cespiti che hanno una class. inventariale associata ad un Tipo costo
		and exists (select * from  assetacquire	
				JOIN inventorytree 		ON inventorytree.idinv = assetacquire.idinv
				join inventorytreelink  on  inventorytreelink.idchild = assetacquire.idinv
				join progettotipocostoinventorytree on progettotipocostoinventorytree.idinv = inventorytreelink.idparent
				where assetacquire.nassetacquire = A.nassetacquire
			)
	group by year(ADETT.start),month(ADETT.start), AD.idasset, AD.idpiece --, AD.idprogetto
	
	-- Per ogni cespite calcola l'ammortamento annuo e poi farà diviso 12
	DECLARE @dec_31 datetime
	declare @assetvalue_to_date decimal(19,2)
	declare @actualvalue_to_date decimal(19,2)

	DECLARE @idasset int
	DECLARE @idpiece int
	DECLARE @ayear int
	
	create table #ammortamenti(importo decimal(19,2), idasset int, idpiece int, ayear int)
	
	DECLARE amt_crs1 INSENSITIVE CURSOR FOR
	SELECT 
		idasset, idpiece, ayear
	FROM #oremesicespite
	FOR READ ONLY
	OPEN amt_crs1
	
	FETCH NEXT FROM amt_crs1 INTO @idasset, @idpiece, @ayear
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SELECT  @dec_31 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear), 105)
		EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue_to_date OUTPUT, @actualvalue_to_date OUTPUT 
		if (@assetvalue_to_date>0)
		begin
			-- in questa tebella metterà tutti i valori dell'Ammortamento, cosÃ¬ dopo potrà fare direttamente il JOIN piuttosto che fare l'UPDATE su #oremesicespite
			insert into #ammortamenti(importo, idasset, idpiece, ayear)
			values(@actualvalue_to_date, @idasset, @idpiece, @ayear) 
		end
	
		FETCH NEXT FROM amt_crs1 INTO  @idasset, @idpiece, @ayear
		END

	DEALLOCATE amt_crs1
	
	--Calcola il valore da scrivere in amount di assetdiaryora come:
	-- (ore dell'i-esima riga di assetdiaryora / Somma delle ore di quell'asset) * Ammortamento cespite
	select case when isnull(AMM.importo,0)>0
			then CONVERT(decimal(19,2), DATEDIFF(hour, ADETT.start, ADETT.stop)) /(convert(decimal(19,2),O.sommeore))  
									* ( isnull(AMM.importo,1)/12) 
			else  CONVERT(decimal(19,2), DATEDIFF(hour, ADETT.start, ADETT.stop)) /(convert(decimal(19,2),O.sommeore))  
			end	as amount ,
	ADETT.idassetdiary, ADETT.idassetdiaryora
	from assetdiary A 
	join  assetdiaryora ADETT 
		on A.idassetdiary = ADETT.idassetdiary and A.idprogetto = @idprogetto --> deve valorizzare solo le righe del progetto specificato.
	join #oremesicespite O
		on A.idasset = O.idasset and A.idpiece = O.idpiece
	LEFT OUTER join #ammortamenti AMM
		on AMM.idasset = O.idasset and AMM.idpiece = O.idpiece and AMM.ayear = O.ayear
	where O.sommeore<>0 and O.mese = month(ADETT.start) and O.ayear = year(ADETT.start)
	order by ADETT.idassetdiary, ADETT.idassetdiaryora

	drop table #oremesicespite

END
GO SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[GenerateDidProgCurricula]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GenerateDidProgCurricula]
GO

CREATE PROCEDURE [dbo].[GenerateDidProgCurricula]
	@iddidprog int,
	@user varchar(60)
AS
BEGIN
	SET NOCOUNT ON;

	--declare @iddidprog int = 4;
	--declare @user varchar(60) = 'ferdinando';


	declare @idcorsostudio int = (SELECT idcorsostudio FROM didprog WHERE iddidprog = @iddidprog);
	declare @iddidprogsuddannokind int = (SELECT iddidprogsuddannokind FROM didprog WHERE iddidprog = @iddidprog);
	declare @aa varchar(9) = (SELECT aa FROM didprog WHERE iddidprog = @iddidprog);
	
	declare @durata int = (SELECT durata FROM corsostudio WHERE idcorsostudio = @idcorsostudio);
	declare @idduratakind int = (SELECT idduratakind FROM corsostudio WHERE idcorsostudio = @idcorsostudio);

	--CURRICULUM
	IF(@iddidprogsuddannokind is not null and @durata is not null and  @idduratakind is not null)
	BEGIN
		IF(NOT EXISTS(SELECT * FROM didprogcurr WHERE iddidprog = @iddidprog))
		BEGIN
			
			INSERT INTO [dbo].[didprogcurr]
					   ([iddidprogcurr]
					   ,[iddidprog]
					   ,[title]
					   ,[codice]
					   ,[codicemiur]
					   ,[ct]
					   ,[cu]
					   ,[lt]
					   ,[lu]
					   ,[idcorsostudio])
				 VALUES
					   ((SELECT isnull(MAX(iddidprogcurr),0) FROM didprogcurr) + 1
					   ,@iddidprog
					   ,'Curriculum unico'
					   ,''
					   ,''
					   ,GETDATE()
					   ,@user
					   ,GETDATE()
					   ,@user
					   ,@idcorsostudio);
		END
		DECLARE @iddidprogcurr int = (SELECT TOP 1 iddidprogcurr FROM didprogcurr WHERE iddidprog = @iddidprog);

		--ORIENTAMENTO
		IF(NOT EXISTS(SELECT * FROM didprogori WHERE iddidprog = @iddidprog))
		BEGIN
			INSERT INTO [dbo].[didprogori]
					   ([iddidprogori]
					   ,[iddidprogcurr]
					   ,[iddidprog]
					   ,[title]
					   ,[codice]
					   ,[ct]
					   ,[cu]
					   ,[lt]
					   ,[lu]
					   ,[idcorsostudio])
				 VALUES
					   ((SELECT isnull(MAX(iddidprogori),0) FROM didprogori) + 1 
					   ,@iddidprogcurr
					   ,@iddidprog
					   ,'Orientamento unico'
					   ,''
					   ,GETDATE()
					   ,@user
					   ,GETDATE()
					   ,@user
					   ,@idcorsostudio);
		END
		DECLARE @iddidprogori int = (SELECT TOP 1 iddidprogori FROM didprogori WHERE iddidprog = @iddidprog AND iddidprogcurr = @iddidprogcurr);

		--SUDDIVISIONE DEL CORSO  
		IF(@idduratakind = 1) --ANNI
		BEGIN
			DECLARE @numsuddivisioni INT = 1;
			IF(@iddidprogsuddannokind = 1) SET @numsuddivisioni = 12; --MENSILI
			IF(@iddidprogsuddannokind = 2) SET @numsuddivisioni = 6; --BIMESTRI
			IF(@iddidprogsuddannokind = 3) SET @numsuddivisioni = 4; --TRIMESTRI
			IF(@iddidprogsuddannokind = 4) SET @numsuddivisioni = 3; --QUADRIMESTRI
			IF(@iddidprogsuddannokind = 5) SET @numsuddivisioni = 2; --SEMESTRI
			IF(@iddidprogsuddannokind = 6) SET @numsuddivisioni = 1; --ANNUALE

			DECLARE @aacurr varchar(9) = @aa;
			DECLARE @cnt INT = 0;
			WHILE @cnt < @durata
			BEGIN

				DECLARE @iddidproganno int = (SELECT isnull(MAX(iddidproganno),0) FROM didproganno) + 1;
				INSERT INTO [dbo].[didproganno]
						   ([iddidproganno]
						   ,[iddidprogori]
						   ,[iddidprogcurr]
						   ,[iddidprog]
						   ,[anno]
						   ,[aa]
						   ,[cf]
						   ,[ct]
						   ,[cu]
						   ,[lt]
						   ,[lu]
						   ,[idcorsostudio]
						   ,[title])
					 VALUES
						   (@iddidproganno
						   ,@iddidprogori
						   ,@iddidprogcurr
						   ,@iddidprog
						   ,@cnt + 1
						   ,@aacurr
						   ,60
						   ,GETDATE()
						   ,@user
						   ,GETDATE()
						   ,@user
						   ,@idcorsostudio
						   ,CAST(@cnt + 1 as nvarchar(2)) + ' anno');
				--SUDDIVISIONE TEMPORALE
				DECLARE @cntsudd INT = 0;
				WHILE @cntsudd < @numsuddivisioni
				BEGIN
					INSERT INTO [dbo].[didprogporzanno]
							   ([iddidprogporzanno]
							   ,[iddidproganno]
							   ,[iddidprogori]
							   ,[iddidprogcurr]
							   ,[iddidprog]
							   ,[indice]
							   ,[iddidprogporzannokind]
							   ,[start]
							   ,[stop]
							   ,[ct]
							   ,[cu]
							   ,[lt]
							   ,[lu]
							   ,[idcorsostudio]
							   ,[aa]
							   ,[title])
						 VALUES

							   ((SELECT isnull(MAX(iddidprogporzanno),0) FROM didprogporzanno) + 1
							   ,@iddidproganno
							   ,@iddidprogori
							   ,@iddidprogcurr
							   ,@iddidprog
							   ,@cntsudd +1
							   ,@iddidprogsuddannokind
							   ,NULL
							   ,NULL
							   ,GETDATE()
							   ,@user
							   ,GETDATE()
							   ,@user
							   ,@idcorsostudio
							   ,@aacurr
							   ,CAST(@cntsudd +1 as nvarchar(2)) + CASE
							   WHEN @iddidprogsuddannokind = 1 THEN ' mese'
							   WHEN @iddidprogsuddannokind = 2 THEN ' bimestre'
							   WHEN @iddidprogsuddannokind = 3 THEN ' trimestre'
							   WHEN @iddidprogsuddannokind = 4 THEN ' quadrimestre'
							   WHEN @iddidprogsuddannokind = 5 THEN ' semestre'
							   WHEN @iddidprogsuddannokind = 6 THEN ' annualità'
							   END)
					SET @cntsudd = @cntsudd + 1;
				END
				SET @cnt = @cnt + 1;
				SET @aacurr = CAST( (CAST(LEFT(@aa,4) AS int) + @cnt + 1) AS varchar(4))  + '/' + CAST( (CAST(RIGHT(@aa,4) AS int) + @cnt + 1) AS varchar(4));
			END
		END
	END
END
GO
--[DBO]--
-- CREAZIONE PROCEDURE [dbo].[GenerateProgettoDetail]
IF EXISTS (select * from sysobjects where id = object_id(N'[dbo].[GenerateProgettoDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[GenerateProgettoDetail]
GO
CREATE PROCEDURE [dbo].[GenerateProgettoDetail]
	@idprogettokind int ,
	@idprogetto int,
	@user varchar(64)
AS
BEGIN
	SET NOCOUNT ON;

	-----------test-------------------------
	--declare @idprogettokind int = 2
	--declare @idprogetto int = 1
	--declare @user varchar(64) = 'utentetest'
	----------------------------------------
	
	--WORKPACKAGE
	INSERT INTO [dbo].[workpackage]
           ([idworkpackage]
           ,[idprogetto]
           ,[title]
           ,[description]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idworkpackage),0)   from workpackage) + ROW_NUMBER() OVER(ORDER BY wpk.idworkpackagekind ASC) as idworkpackage,
		@idprogetto as idprogetto,
		wpk.title,
		'' as [description],
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
	FROM workpackagekind wpk
	WHERE idprogettokind = @idprogettokind and not exists (	select x.title 
															from workpackage x 
															where x.idprogetto = @idprogetto and x.title = wpk.title)

	--VOCI COSTO
	INSERT INTO [dbo].[progettotipocosto]
           ([idprogettotipocosto]
           ,[idprogettotipocostokind]
           ,[idprogetto]
           ,[sortcode]
           ,[ammissibilita]
		   ,[title]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idprogettotipocosto),0)   from progettotipocosto) + ROW_NUMBER() OVER(ORDER BY ptcck.idprogettotipocostokind ASC) as idprogettotipocosto,
		ptcck.idprogettotipocostokind,
		@idprogetto as idprogetto,
		null as sortcode,
		100 as ammissibilita,
		ptcck.title,
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
		--,title
	FROM progettotipocostokind ptcck
	WHERE idprogettokind = @idprogettokind and not exists (	select x.idprogettotipocostokind 
															from progettotipocosto x 
															where x.idprogetto = @idprogetto and x.idprogettotipocostokind = ptcck.idprogettotipocostokind)

	--progettotipocostokindaccmotive: causali economico patrimoniali

	INSERT INTO [dbo].[progettotipocostoaccmotive]
           ([idprogetto]
           ,[idprogettotipocosto]
           ,[idaccmotive]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
			@idprogetto as idprogetto
			,ptc.idprogettotipocosto
			,ptcka.idaccmotive
			,getdate() as ct
			,@user as cu
			,getdate() as lt
			,@user as lu
	FROM progettotipocostokindaccmotive ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostoaccmotive x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.idaccmotive = ptcka.idaccmotive)

	--progettotipocostokindcontrattokind: tipologia di contratti

	INSERT INTO [dbo].[progettotipocostocontrattokind]
           ([idprogettotipocosto]
           ,[idcontrattokind]
           ,[idprogetto]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
			 ptc.idprogettotipocosto
			,ptcka.idcontrattokind
			,@idprogetto as idprogetto
			,getdate() as ct
			,@user as cu
			,getdate() as lt
			,@user as lu
	FROM progettotipocostokindcontrattokind ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostocontrattokind x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.idcontrattokind = ptcka.idcontrattokind)

	--progettotipocostokindinventorytree: classificazioni inventariali

	INSERT INTO [dbo].[progettotipocostoinventorytree]
           ([idprogettotipocosto]
           ,[idinv]
           ,[idprogetto]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
			 ptc.idprogettotipocosto
			,ptcka.idinv
			,@idprogetto as idprogetto
			,getdate() as ct
			,@user as cu
			,getdate() as lt
			,@user as lu
	FROM progettotipocostokindinventorytree ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostoinventorytree x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.idinv = ptcka.idinv)

	--progettotipocostokindtax: tipi di ritenuta

	INSERT INTO [dbo].[progettotipocostotax]
           ([idprogettotipocosto]
           ,[taxcode]
           ,[idprogetto]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
			 ptc.idprogettotipocosto
			,ptcka.taxcode
			,@idprogetto as idprogetto
			,getdate() as ct
			,@user as cu
			,getdate() as lt
			,@user as lu
	FROM progettotipocostokindtax ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostotax x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.taxcode = ptcka.taxcode)

	--CATEGORIE COSTO
	INSERT INTO [dbo].[progettobudget]
           ([idprogettobudget]
           ,[idprogetto]
           ,[idworkpackage]
           ,[idprogettotipocosto]
           ,[budget]
           ,[sortcode]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idprogettobudget),0) from [progettobudget]) + ROW_NUMBER() OVER(ORDER BY ptcc.idprogettotipocostokind ASC) as [idprogettobudget],
		@idprogetto as idprogetto,
		wp.idworkpackage,
		ptcc.idprogettotipocosto,
		0 as budget,
		ROW_NUMBER() OVER(ORDER BY ptcc.sortcode ASC) as sortcode,
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
	from workpackage wp inner join progettotipocosto ptcc on wp.idprogetto = ptcc.idprogetto
	where wp.idprogetto = @idprogetto and ptcc.idprogetto = @idprogetto and not exists (select x.idprogettobudget 
																						from progettobudget x 
																						where x.idprogetto = @idprogetto and x.idworkpackage = wp.idworkpackage and x.idprogettotipocosto = ptcc.idprogettotipocosto)
	order by wp.idworkpackage,ptcc.sortcode

	--TESTI
	INSERT INTO [dbo].[progettotesto]
           ([idprogettotesto]
           ,[idprogetto]
           ,[title]
           ,[description]
           ,[sortcode]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idprogettotesto),0) from progettotesto) + ROW_NUMBER() OVER(ORDER BY ptk.idprogettotestokind ASC) as idprogettotesto,
        @idprogetto as idprogetto,
        ptk.titolo,
        '' as [description],
        ptk.sortcode,
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
	FROM progettotestokind ptk
	WHERE ptk.idprogettokind = @idprogettokind and not exists (	select x.title 
																from progettotesto x 
																where x.idprogetto = @idprogetto and x.title = ptk.titolo)

	--ALLEGATI
	INSERT INTO [dbo].[progettoattach]
           ([idprogettoattach]
		   ,[idattach]
           ,[idprogetto]
           ,[title]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idprogettoattach),0) from progettoattach) + ROW_NUMBER() OVER(ORDER BY ptk.idprogettoattachkind ASC) as idprogettoattach,
		null as idattach,
        @idprogetto as idprogetto,
        ptk.title,
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
	FROM progettoattachkind ptk
	WHERE ptk.idprogettokind = @idprogettokind and not exists (	select x.title 
																from progettoattach x 
																where x.idprogetto = @idprogetto and x.title = ptk.title)


END


exec menuweb_addentry @idmenuwebparent = NULL, @idx = 1, @tableName = null, @editType = null, @label = 'Tutti i Menù';
exec menuweb_addentry @idmenuwebparent = 1, @idx = 29, @tableName = null, @editType = null, @label = 'Menù dell''applicazione delle segreterie';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 400, @tableName = null, @editType = null, @label = 'Amministrazione';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 81, @tableName = null, @editType = null, @label = 'Segreteria didattica';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 83, @tableName = null, @editType = null, @label = 'Segreteria amministrativa';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 296, @tableName = null, @editType = null, @label = 'Progetti di ricerca e attività istituzionali';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 41, @tableName = null, @editType = null, @label = 'Elenchi';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 143, @tableName = null, @editType = null, @label = 'Configurazioni';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 177, @tableName = null, @editType = null, @label = 'Tipologie';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 244, @tableName = null, @editType = null, @label = 'Definizione delle tasse';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 57, @tableName = 'sasd', @editType = 'default', @label = 'Settori artistico-scientifico disciplinari';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 72, @tableName = 'classconsorsuale', @editType = 'default', @label = 'Classi di concorso MIUR';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 145, @tableName = 'ccnl', @editType = 'default', @label = 'Contratti Collettivi Nazionali del Lavoro';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 170, @tableName = 'areadidattica', @editType = 'default', @label = 'Aeree didattiche';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 178, @tableName = 'istattitolistudio', @editType = 'default', @label = 'Titoli di studio ISTAT';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 180, @tableName = 'classescuola', @editType = 'default', @label = 'Scuole / Classi di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 186, @tableName = 'upb', @editType = 'default', @label = 'Unità previsionali di base';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 191, @tableName = 'geo_nation', @editType = 'seg', @label = 'Nazioni';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 193, @tableName = 'geo_continent', @editType = 'default', @label = 'Continenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 194, @tableName = 'geo_country', @editType = 'seg', @label = 'Province';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 195, @tableName = 'geo_region', @editType = 'seg', @label = 'Regioni';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 196, @tableName = 'geo_city', @editType = 'seg', @label = 'Comuni';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 197, @tableName = 'corsostudionorma', @editType = 'default', @label = 'Normativa dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 213, @tableName = 'corsostudiolivello', @editType = 'default', @label = 'Livelli dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 239, @tableName = 'geo_continent', @editType = 'anagrafica_easyweb', @label = 'Continenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 270, @tableName = 'pianostudiostatus', @editType = 'default', @label = 'Stati dei piani di studio';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 278, @tableName = 'nace', @editType = 'default', @label = 'Classificazione delle attività economiche nella Comunità Europea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 279, @tableName = 'ateco', @editType = 'default', @label = 'Classificazione ATECO';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 292, @tableName = 'sasdgruppo', @editType = 'default', @label = 'Gruppo';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 293, @tableName = 'classescuolaarea', @editType = 'default', @label = 'Area della scuola / classe di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 294, @tableName = 'classescuolakind', @editType = 'default', @label = 'Tipologia della scuola / classe di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 295, @tableName = 'ambitoareadisc', @editType = 'default', @label = 'Ambiti o aree disciplinari';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 302, @tableName = 'progettostatuskind', @editType = 'default', @label = 'Stati delle attività o progetti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 303, @tableName = 'settoreerc', @editType = 'seg', @label = 'Settori dell''European Research Council';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 304, @tableName = 'fonteindicebibliometrico', @editType = 'seg', @label = 'Fonti degli indici bibliometrici';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 306, @tableName = 'settoreerc', @editType = 'segprog', @label = 'Settori dell''European Research Council';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 307, @tableName = 'tax', @editType = 'seg', @label = 'Tipi di ritenuta';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 310, @tableName = 'changes', @editType = 'default', @label = 'Cambiamento per learning agreement';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 311, @tableName = 'changeskind', @editType = 'default', @label = 'Tipo di cambiamenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 344, @tableName = 'stipendiokind', @editType = 'default', @label = 'Tabelle stipendiali';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 346, @tableName = 'naturagiur', @editType = 'default', @label = 'Natura giuridica';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 347, @tableName = 'numerodip', @editType = 'default', @label = 'Numero dipendenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 348, @tableName = 'inventorytree', @editType = 'seg', @label = 'Classificazione inventariale';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 353, @tableName = 'isced2013', @editType = 'default', @label = 'International Standard Classification of Education (ISCED)';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 354, @tableName = 'cefr', @editType = 'default', @label = 'Quadro europeo comune di riferimento per le lingue';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 357, @tableName = 'bandomobilitaintkind', @editType = 'default', @label = 'Tipologa del bando di mobilità internanzionale';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 397, @tableName = 'currency', @editType = 'default', @label = 'Valute';
exec menuweb_addentry @idmenuwebparent = 81, @idx = 82, @tableName = null, @editType = null, @label = 'Anagrafiche';
exec menuweb_addentry @idmenuwebparent = 81, @idx = 179, @tableName = null, @editType = null, @label = 'Didattica';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 45, @tableName = 'location', @editType = 'aula', @label = 'Aule';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 77, @tableName = 'registry', @editType = 'anagrafica', @label = 'Anagrafica';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 79, @tableName = 'registry', @editType = 'docenti', @label = 'Docenti';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 136, @tableName = 'publicaz', @editType = 'default', @label = 'Pubblicazione';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 182, @tableName = 'insegn', @editType = 'default', @label = 'Insegnamenti o Campi disciplinari';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 218, @tableName = 'aula', @editType = 'default', @label = 'Aule';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 220, @tableName = 'edificio', @editType = 'default', @label = 'Edifici';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 84, @tableName = null, @editType = null, @label = 'Iscrizioni, rinnovi, conseguimenti e decadenze';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 86, @tableName = null, @editType = null, @label = 'Anagrafiche';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 280, @tableName = null, @editType = null, @label = 'Istanze e delibere';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 283, @tableName = null, @editType = null, @label = 'Protocollo';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 313, @tableName = null, @editType = null, @label = 'Tirocini';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 349, @tableName = null, @editType = null, @label = 'Mobilità internazionale';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 358, @tableName = null, @editType = null, @label = 'Diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 367, @tableName = null, @editType = null, @label = 'Dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 369, @tableName = null, @editType = null, @label = 'Contabilità studenti';
exec menuweb_addentry @idmenuwebparent = 84, @idx = 274, @tableName = 'iscrizione', @editType = 'seg', @label = 'Iscrizioni';
exec menuweb_addentry @idmenuwebparent = 84, @idx = 308, @tableName = 'decadenza', @editType = 'seg', @label = 'Decadenza';
exec menuweb_addentry @idmenuwebparent = 84, @idx = 381, @tableName = 'sostenimento', @editType = 'segcons', @label = 'Conseguimento del titolo';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 42, @tableName = 'registry', @editType = 'default', @label = 'Anagrafica Generale';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 51, @tableName = 'registry', @editType = 'aziende', @label = 'Enti e Aziende';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 52, @tableName = 'registry', @editType = 'istituti', @label = 'Istituti';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 53, @tableName = 'registry', @editType = 'istitutiesteri', @label = 'Istituti esteri';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 174, @tableName = 'registry', @editType = 'studenti', @label = 'Studenti';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 187, @tableName = 'aoo', @editType = 'default', @label = 'Aree organizzative interne';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 212, @tableName = 'sede', @editType = 'default', @label = 'Sedi';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 214, @tableName = 'registry', @editType = 'default', @label = 'Anagrafica generale';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 215, @tableName = 'struttura', @editType = 'default', @label = 'Struttura / Unità organizzativa';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 300, @tableName = 'registry', @editType = 'amministrativi', @label = 'Personale Amministrativo';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 146, @tableName = 'menuweb', @editType = 'tree', @label = 'Menù';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 233, @tableName = 'registry', @editType = 'user', @label = 'Pagina di registrazione';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 241, @tableName = 'questionario', @editType = 'default', @label = 'Questionari';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 242, @tableName = 'graduatoriavar', @editType = 'default', @label = 'Variabili delle graduatorie';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 243, @tableName = 'registry', @editType = 'istituti_princ', @label = 'Istituto in gestione';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 277, @tableName = 'graduatoria', @editType = 'default', @label = 'Definizioni delle graduatorie';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 135, @tableName = 'contrattokind', @editType = 'default', @label = 'Tipologie di contratto';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 137, @tableName = 'publicazkind', @editType = 'default', @label = 'Tipologie di pubblicazione ';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 139, @tableName = 'rendicontaltrokind', @editType = 'default', @label = 'Tipologia delle attività da rendicontare oltre le lezioni ';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 141, @tableName = 'studdirittokind', @editType = 'default', @label = 'Categoria dello studente per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 142, @tableName = 'studprenotkind', @editType = 'default', @label = 'Tipologia di studente durante la prenotazione';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 171, @tableName = 'corsostudiokind', @editType = 'default', @label = 'Tipologie dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 172, @tableName = 'istitutokind', @editType = 'default', @label = 'Tipologia di istituto';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 176, @tableName = 'registryclass', @editType = 'default', @label = 'Tipologia fiscale';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 183, @tableName = 'valutazionekind', @editType = 'default', @label = 'Tipologia di valutazione di una attività didattica';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 211, @tableName = 'strutturakind', @editType = 'default', @label = 'Tipologia delle strutture';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 217, @tableName = 'tipoattform', @editType = 'default', @label = 'Tipologia delle attività formative';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 221, @tableName = 'valutazionekind', @editType = 'seg_child', @label = 'Tipologia di valutazione di una attività didattica';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 223, @tableName = 'aulakind', @editType = 'default', @label = 'Tipologie delle aule';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 225, @tableName = 'affidamentokind', @editType = 'default', @label = 'Tipologie di affidamento';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 227, @tableName = 'erogazkind', @editType = 'default', @label = 'Tipologie di erogazione della didattica';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 229, @tableName = 'sessionekind', @editType = 'default', @label = 'Tipologie di sessione';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 230, @tableName = 'appellokind', @editType = 'default', @label = 'Tipologie di appello';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 263, @tableName = 'istanzakind', @editType = 'default', @label = 'Tipologie di istanza';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 264, @tableName = 'ofakind', @editType = 'default', @label = 'Titologie di obblighi formativi aggiuntivi';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 265, @tableName = 'questionariodomkind', @editType = 'default', @label = 'Tipologie di  domande del questionario';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 266, @tableName = 'questionariokind', @editType = 'default', @label = 'Tipologie di questionario';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 267, @tableName = 'tirociniocandidaturakind', @editType = 'default', @label = 'Tipologia di candidatura ad un tirocinio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 268, @tableName = 'tirociniostato', @editType = 'default', @label = 'Stato dei tirocini';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 269, @tableName = 'appelloazionekind', @editType = 'default', @label = 'Titologie di azione in appello';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 271, @tableName = 'sostenimentoesito', @editType = 'default', @label = 'Esito';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 290, @tableName = 'dichiarkind', @editType = 'default', @label = 'Tipi di dichiarazione';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 298, @tableName = 'orakind', @editType = 'seg', @label = 'Tipologia di ore';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 305, @tableName = 'progettoactivitykind', @editType = 'default', @label = 'Tipo di attività o progetto';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 345, @tableName = 'duratakind', @editType = 'default', @label = 'Tipo di durata';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 365, @tableName = 'accreditokind', @editType = 'default', @label = 'Tipi di accredito in una richiesta di partecipazione al bando per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 366, @tableName = 'convalidakind', @editType = 'default', @label = 'Tipologie di convalida';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 376, @tableName = 'dichiardisabilkind', @editType = 'default', @label = 'Tipologie di disabilità';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 377, @tableName = 'dichiardisabilsuppkind', @editType = 'default', @label = 'Tipologie dichiarazioni disabilita';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 382, @tableName = 'dichiaraltrekind', @editType = 'default', @label = 'Tipologia delle altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 383, @tableName = 'dichiaraltrekind', @editType = 'elenchi', @label = 'Tipologia delle altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 392, @tableName = 'bandodsiscresitokind', @editType = 'default', @label = 'Esito della partecipazione al bando per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 401, @tableName = 'progettoudrmembrokind', @editType = 'default', @label = 'Tipologia di membro delle unità di personale';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 181, @tableName = 'didprog', @editType = 'default', @label = 'Didattiche programmate';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 188, @tableName = 'corsostudio', @editType = 'default', @label = 'Corsi di studio';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 219, @tableName = 'diderog', @editType = 'default', @label = 'Didattica Erogata';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 226, @tableName = 'appello', @editType = 'default', @label = 'Appelli';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 228, @tableName = 'sessione', @editType = 'default', @label = 'Sessioni di esami';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 232, @tableName = 'corsostudio', @editType = 'ingresso', @label = 'Prove di ammissione';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 272, @tableName = 'corsostudio', @editType = 'dotmas', @label = 'Master';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 273, @tableName = 'corsostudio', @editType = 'stato', @label = 'Esami di stato';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 276, @tableName = 'pianostudio', @editType = 'segstud', @label = 'Piani di studio';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 312, @tableName = 'pratica', @editType = 'segstud', @label = 'Pratica di convalida/riconoscimento/dispensa';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 391, @tableName = 'getcostididattica', @editType = 'default', @label = 'Riepilogo dei costi degli affidamenti';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 246, @tableName = 'costoscontodef', @editType = 'default', @label = 'Costi';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 247, @tableName = 'costoscontodef', @editType = 'sconti', @label = 'Sconti';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 248, @tableName = 'costoscontodef', @editType = 'more', @label = 'Indennità / More';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 249, @tableName = 'costoscontodefdettagliokind', @editType = 'default', @label = 'Voci dei dettaglio debito';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 250, @tableName = 'esonero', @editType = 'default', @label = 'Definizione degli esoneri generici';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 251, @tableName = 'esonero', @editType = 'carriera', @label = 'Definizione degli esoneri  derivanti dalla carriera';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 252, @tableName = 'esonero', @editType = 'disabil', @label = 'Definizione degli esoneri di invalidità';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 253, @tableName = 'esonero', @editType = 'titolostudio', @label = 'Definizione degli esoneri per titoli di studio conseguiti';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 254, @tableName = 'fasciaisee', @editType = 'default', @label = 'Fasce ISEE';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 255, @tableName = 'pagamentokind', @editType = 'default', @label = 'Tipologie di pagamento';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 256, @tableName = 'ratakind', @editType = 'default', @label = 'Rate';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 257, @tableName = 'tassaconf', @editType = 'default', @label = 'Definizione dei costi generici';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 258, @tableName = 'tassaconfkind', @editType = 'default', @label = 'Definizione delle tasse generiche';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 259, @tableName = 'tassacsingconf', @editType = 'default', @label = 'Definizione dei costi dei corsi singoli';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 260, @tableName = 'tassaiscrizioneconf', @editType = 'default', @label = 'Definizione delle tasse di iscrizione';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 261, @tableName = 'tassaistanzaconf', @editType = 'default', @label = 'Definizione dei costi delle istanze';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 262, @tableName = 'costoscontodefkind', @editType = 'default', @label = 'Tipologia tra Costo, Sconto, Mora, indennizzo';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 287, @tableName = 'istanza', @editType = 'imm_segpre', @label = 'Istanze di preimmatricolazione';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 288, @tableName = 'istanza', @editType = 'imm_seg', @label = 'Istanze di immatricolazione';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 289, @tableName = 'istanza', @editType = 'imm_segrin', @label = 'Istanze di rinnovo iscrizione';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 385, @tableName = 'istanza', @editType = 'rin_seg', @label = 'Istanza di rinuncia agli studi';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 386, @tableName = 'istanza', @editType = 'tru_seg', @label = 'Istanza di trasferimento in uscita';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 387, @tableName = 'istanza', @editType = 'eq_seg', @label = 'Istanza di equipollenza ';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 388, @tableName = 'istanza', @editType = 'cert_seg', @label = 'Richiesta di certificato';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 389, @tableName = 'istanza', @editType = 'sosp_seg', @label = 'Istanza di sospensione degli studi';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 390, @tableName = 'delibera', @editType = 'seg', @label = 'Delibere';
exec menuweb_addentry @idmenuwebparent = 283, @idx = 284, @tableName = 'protocollo', @editType = 'seg', @label = 'Registrazioni di protocollo';
exec menuweb_addentry @idmenuwebparent = 283, @idx = 285, @tableName = 'protocollodockind', @editType = 'seg', @label = 'Tipo di documento protocollato';
exec menuweb_addentry @idmenuwebparent = 283, @idx = 286, @tableName = 'protocollorifkind', @editType = 'seg', @label = 'Tipo di documento di riferimento';
exec menuweb_addentry @idmenuwebparent = 296, @idx = 297, @tableName = 'progetto', @editType = 'seg', @label = 'Progetti e attività';
exec menuweb_addentry @idmenuwebparent = 296, @idx = 299, @tableName = 'progettokind', @editType = 'seg', @label = 'Tipi di progetto o attività';
exec menuweb_addentry @idmenuwebparent = 313, @idx = 342, @tableName = 'convenzione', @editType = 'seg', @label = 'Convenzioni';
exec menuweb_addentry @idmenuwebparent = 313, @idx = 343, @tableName = 'tirocinioproposto', @editType = 'seg', @label = 'Proposte di tirocinio';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 350, @tableName = 'programmami', @editType = 'seg', @label = 'Programmi di cooperazione';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 351, @tableName = 'accordoscambiomi', @editType = 'seg', @label = 'Accordi bilaterali';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 352, @tableName = 'bandomi', @editType = 'seg', @label = 'Bandi di mobilità';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 356, @tableName = 'assicurazione', @editType = 'default', @label = 'Assicurazione';
exec menuweb_addentry @idmenuwebparent = 358, @idx = 359, @tableName = 'bandods', @editType = 'seg', @label = 'Bandi di diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 359, @idx = 360, @tableName = 'bandods', @editType = 'seg', @label = 'Bandi di diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 371, @tableName = 'dichiar', @editType = 'altrititoli_seg', @label = 'Altri titoli';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 378, @tableName = 'dichiar', @editType = 'altre_seg', @label = 'Altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 379, @tableName = 'dichiar', @editType = 'disabil_seg', @label = 'Dichiarazione di disabilità';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 380, @tableName = 'dichiar', @editType = 'isee_seg', @label = 'Attestazione ISEE';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 384, @tableName = 'dichiar', @editType = 'titolo_seg', @label = 'Dichiarazione titoli di studio';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 408, @tableName = 'registry', @editType = 'admin', @label = 'Funzioni di amministrazione';
--docenti
exec menuweb_addentry @idmenuwebparent = 29, @idx = 415, @tableName = null, @editType = null, @label = 'I miei dati';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 416, @tableName = null, @editType = null, @label = 'I miei corsi';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 421, @tableName = null, @editType = null, @label = 'Le mie attività di ricerca e istituzionali';
exec menuweb_addentry @idmenuwebparent = 421, @idx = 417, @tableName = 'assetdiary', @editType = 'doc', @label = 'Diari di utilizzo di beni strumentali';
exec menuweb_addentry @idmenuwebparent = 416, @idx = 418, @tableName = 'affidamento', @editType = 'doc', @label = 'Affidamento';
exec menuweb_addentry @idmenuwebparent = 421, @idx = 419, @tableName = 'rendicontattivitaprogetto', @editType = 'doc', @label = 'Attività di ricerca';
exec menuweb_addentry @idmenuwebparent = 415, @idx = 420, @tableName = 'registry', @editType = 'docenti_doc', @label = 'Dati personali';

--menuï»¿

exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND01', @message = 'Non è possibile mettere la stessa causale ep su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa causale ep su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idaccmotive, idprogettokind  
	from progettotipocostokindaccmotive
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idaccmotive, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND02', @message = 'Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idcontrattokind, idprogettokind  
	from progettotipocostokindcontrattokind
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idcontrattokind, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND03', @message = 'Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idinv, idprogettokind  
	from progettotipocostokindinventorytree
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idinv, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogettokind  
	from progettotipocostokindtax
	where idprogettokind = %<progettokind.idprogettokind>%
	group by taxcode, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO01', @message = 'Non è possibile mettere la stessa causale ep su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa causale ep su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idaccmotive, idprogetto  
	from progettotipocostoaccmotive
	where idprogetto = %<progetto.idprogetto>%
	group by idaccmotive, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO02', @message = 'Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idcontrattokind, idprogetto  
	from progettotipocostocontrattokind
	where idprogetto = %<progetto.idprogetto>%
	group by idcontrattokind, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO03', @message = 'Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idinv, idprogetto  
	from progettotipocostoinventorytree
	where idprogetto = %<progetto.idprogetto>%
	group by idinv, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogetto  
	from progettotipocostotax
	where idprogetto = %<progetto.idprogetto>%
	group by taxcode, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogetto  
	from progettotipocostotax
	where idprogetto = %<progetto.idprogetto>%
	group by taxcode, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogetto  
	from progettotipocostotax
	where idprogetto = %<progetto.idprogetto>%
	group by taxcode, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell'ente su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogetto  
	from progettotipocostotax
	where idprogetto = %<progetto.idprogetto>%
	group by taxcode, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
--rule	

--LANCIARE SOLO DOPO LO SCRIPT CHE GENERA IL MENU'!!!!!!!!!!!!!!!!!!!!!!!!

--query per la generazione dell'elenco delle variabili di sicurezza da associare
--select variablename  from [restrictedfunction] where idrestrictedfunction in (
--	select idrestrictedfunction 
--	from amministrazione.[FlowChartrestrictedfunction] 
--	where idflowchart = (select top 1 idflowchart from amministrazione.flowchart where codeflowchart = 'SEGDOC')
--	)
--order by variablename

--verifica esistenza nodi
--select * from [amministrazione].[flowchart] where idflowchart in ('202099','202098','20','202096')
IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202099')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202099'
           ,null
           ,2020
           ,null
           ,'SEGADM'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'20'
           ,null
           ,1
           ,'Segreterie Amministratori'
           ,null
           ,null
           ,null)
GO

IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202098')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202098'
           ,null
           ,2020
           ,null
           ,'SEGPRG'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'20'
           ,null
           ,1
           ,'Segreterie Progetti Amministratori'
           ,null
           ,null
           ,null)
GO

IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202096')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202096'
           ,null
           ,2020
           ,null
           ,'SEGDOC'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'20'
           ,null
           ,1
           ,'Docenti'
           ,null
           ,null
           ,null)
GO


IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202095')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202095'
           ,null
           ,2020
           ,null
           ,'SEGAMM'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'20'
           ,null
           ,1
           ,'Personale amministrativo'
           ,null
           ,null
           ,null)
GO

--diritti Docenti

INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202096'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'mr_415'
,'mr_416'
,'mr_417'
,'mr_418'
,'mr_419'
,'mr_420'
,'mr_421'
,'mw_417'
,'mw_418'
,'mw_419'
,'mw_420'
,'all_upb'
,'all_man'
)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202096' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)

--diritti Personale amministrativo

INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202095'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'mr_415'
,'mr_416'
,'mr_417'
,'mr_418'
,'mr_419'
,'mr_420'
,'mr_421'
,'mw_417'
,'mw_418'
,'mw_419'
,'mw_420'
,'all_upb'
,'all_man'
)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202095' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)


--diritti Amministratori segreterie

INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202099'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'mandato'
,'reversale'
,'compensi'
,'bilancio'
,'upb'
,'spesa'
,'entrata'
,'ordine'
,'trasmissione'
,'esitazione'
,'fondoec'
,'annullamento'
,'cespiti'
,'iva'
,'anag_c'
,'anag_l'
,'econopatr'
,'liquidazione'
,'stampe'
,'classificazione'
,'contrattivo'
,'impegni'
,'accertamenti'
,'ordinegrande'
,'organigramma'
,'management'
,'dichiarazione'
,'imposta'
,'configurazione'
,'anagrafeprestazioni'
,'consolidamento'
,'man_ufficiale'
,'rev_ufficiale'
,'multiprint'
,'banca'
,'crediti'
,'incassi'
,'coana'
,'contcompensi'
,'contiva'
,'contcontratti'
,'previsione'
,'assestamento'
,'list_man'
,'responsabile'
,'contrattivogrande'
,'list_mfin'
,'list_mupb'
,'menu'
,'anagrafica'
,'sel_cp'
,'sel_ca'
,'bilancio_read'
,'anagrafica_read'
,'spesa_read'
,'entrata_read'
,'trasmissione_read'
,'fondoec_read'
,'adm_localconfig'
,'adm_backup'
,'adm_ondemand'
,'adm_menuupdate'
,'varspesa'
,'varentrata'
,'tax_clawback'
,'endofyear_entry'
,'all_fin'
,'all_upb'
,'all_man'
,'all_mandatekind'
,'all_estimatekind'
,'all_invoicekind'
,'all_pettycash'
,'list_estimatekind'
,'list_invoicekind'
,'list_pettycash'
,'list_mandatekind'
,'fattura'
,'del_invoice'
,'cespiti_read'
,'liquidazioneiva'
,'anag_d'
,'classificazione_mod'
,'anag_dis'
,'chiusura'
,'anag_config'
,'anag_procedure'
,'adm_magazzino'
,'ric_magazzino'
,'config_magazzino'
,'pre_accertamenti'
,'post_accertamenti'
,'pre_impegni'
,'post_impegni'
,'dipendenti'
,'missioni'
,'occasionali'
,'cococo'
,'professionali'
,'stipendi'
,'eco_entry'
,'all_authmodel'
,'list_authmodel'
,'crea_card'
,'admin_card'
,'var_bilancio'
,'asspendenti'
,'movimprotetta'
,'saldicassa'
,'finvarapproved'
,'manage_estimatekind'
,'manage_mandatekind'
,'manage_invoicekind'
,'storniapprove'
,'sitfinanziaria_read'
,'finanziamenti'
,'trasmissione_ap'
,'edit_limit'
,'stornimedesimocapitoloapprove'
,'finvarcredit'
,'sel_fatture'
,'trasmissione_abilita'
,'certificazionecrediti'
,'fe_ipa_rifamm'
,'fe_ipa'
,'fe_all'
,'manage_split_payment'
,'accetta_fe'
,'rifiuta_fe'
,'creaincontabilita_fe'
,'cambia_rifamm'
,'tipologiaincarichi_ap'
,'var_budget'
,'storno_budget'
,'storno_budget_approve'
,'var_budget_approve'
,'edit_epexpresidui'
,'flussostudenti'
,'flussomovimenti'
,'config_bil_sottosezionali'
,'mov_protettecomp'
,'ct_stornocompetenzaclass'
,'pat'
,'UPBsecurity'
,'edit_epaccresidui'
,'flag_escludidacu'
,'notcreacontabilita'
,'flag_authorizationfree'
,'config_stipendi'
,'stipendi_ct'
,'conf_classauto'
,'upd_paymentcompetency'
,'config_account'
,'mw_40'
,'mr_1'
,'mr_29'
,'mr_400'
,'mr_81'
,'mr_83'
,'mr_296'
,'mr_41'
,'mr_143'
,'mr_177'
,'mr_244'
,'mr_57'
,'mw_57'
,'mr_72'
,'mw_72'
,'mr_145'
,'mw_145'
,'mr_170'
,'mw_170'
,'mr_178'
,'mw_178'
,'mr_180'
,'mw_180'
,'mr_186'
,'mw_186'
,'mr_191'
,'mw_191'
,'mr_193'
,'mw_193'
,'mr_194'
,'mw_194'
,'mr_195'
,'mw_195'
,'mr_196'
,'mw_196'
,'mr_197'
,'mw_197'
,'mr_213'
,'mw_213'
,'mr_239'
,'mw_239'
,'mr_270'
,'mw_270'
,'mr_278'
,'mw_278'
,'mr_279'
,'mw_279'
,'mr_292'
,'mw_292'
,'mr_293'
,'mw_293'
,'mr_294'
,'mw_294'
,'mr_295'
,'mw_295'
,'mr_302'
,'mw_302'
,'mr_303'
,'mw_303'
,'mr_304'
,'mw_304'
,'mr_306'
,'mw_306'
,'mr_307'
,'mw_307'
,'mr_310'
,'mw_310'
,'mr_311'
,'mw_311'
,'mr_344'
,'mw_344'
,'mr_346'
,'mw_346'
,'mr_347'
,'mw_347'
,'mr_348'
,'mw_348'
,'mr_353'
,'mw_353'
,'mr_354'
,'mw_354'
,'mr_357'
,'mw_357'
,'mr_397'
,'mw_397'
,'mr_82'
,'mr_179'
,'mr_45'
,'mw_45'
,'mr_77'
,'mw_77'
,'mr_79'
,'mw_79'
,'mr_136'
,'mw_136'
,'mr_182'
,'mw_182'
,'mr_218'
,'mw_218'
,'mr_220'
,'mw_220'
,'mr_84'
,'mr_86'
,'mr_280'
,'mr_283'
,'mr_313'
,'mr_349'
,'mr_358'
,'mr_367'
,'mr_369'
,'mr_274'
,'mw_274'
,'mr_308'
,'mw_308'
,'mr_381'
,'mw_381'
,'mr_42'
,'mw_42'
,'mr_51'
,'mw_51'
,'mr_52'
,'mw_52'
,'mr_53'
,'mw_53'
,'mr_174'
,'mw_174'
,'mr_187'
,'mw_187'
,'mr_212'
,'mw_212'
,'mr_215'
,'mw_215'
,'mr_300'
,'mw_300'
,'mr_146'
,'mw_146'
,'mr_233'
,'mw_233'
,'mr_241'
,'mw_241'
,'mr_242'
,'mw_242'
,'mr_243'
,'mw_243'
,'mr_277'
,'mw_277'
,'mr_135'
,'mw_135'
,'mr_137'
,'mw_137'
,'mr_139'
,'mw_139'
,'mr_141'
,'mw_141'
,'mr_142'
,'mw_142'
,'mr_171'
,'mw_171'
,'mr_172'
,'mw_172'
,'mr_176'
,'mw_176'
,'mr_183'
,'mw_183'
,'mr_211'
,'mw_211'
,'mr_217'
,'mw_217'
,'mr_221'
,'mw_221'
,'mr_223'
,'mw_223'
,'mr_225'
,'mw_225'
,'mr_227'
,'mw_227'
,'mr_229'
,'mw_229'
,'mr_230'
,'mw_230'
,'mr_263'
,'mw_263'
,'mr_264'
,'mw_264'
,'mr_265'
,'mw_265'
,'mr_266'
,'mw_266'
,'mr_267'
,'mw_267'
,'mr_268'
,'mw_268'
,'mr_269'
,'mw_269'
,'mr_271'
,'mw_271'
,'mr_290'
,'mw_290'
,'mr_298'
,'mw_298'
,'mr_305'
,'mw_305'
,'mr_345'
,'mw_345'
,'mr_365'
,'mw_365'
,'mr_366'
,'mw_366'
,'mr_376'
,'mw_376'
,'mr_377'
,'mw_377'
,'mr_382'
,'mw_382'
,'mr_383'
,'mw_383'
,'mr_392'
,'mw_392'
,'mr_401'
,'mw_401'
,'mr_181'
,'mw_181'
,'mr_188'
,'mw_188'
,'mr_219'
,'mw_219'
,'mr_226'
,'mw_226'
,'mr_228'
,'mw_228'
,'mr_232'
,'mw_232'
,'mr_272'
,'mw_272'
,'mr_273'
,'mw_273'
,'mr_276'
,'mw_276'
,'mr_312'
,'mw_312'
,'mr_391'
,'mw_391'
,'mr_246'
,'mw_246'
,'mr_247'
,'mw_247'
,'mr_248'
,'mw_248'
,'mr_249'
,'mw_249'
,'mr_250'
,'mw_250'
,'mr_251'
,'mw_251'
,'mr_252'
,'mw_252'
,'mr_253'
,'mw_253'
,'mr_254'
,'mw_254'
,'mr_255'
,'mw_255'
,'mr_256'
,'mw_256'
,'mr_257'
,'mw_257'
,'mr_258'
,'mw_258'
,'mr_259'
,'mw_259'
,'mr_260'
,'mw_260'
,'mr_261'
,'mw_261'
,'mr_262'
,'mw_262'
,'mr_287'
,'mw_287'
,'mr_288'
,'mw_288'
,'mr_289'
,'mw_289'
,'mr_385'
,'mw_385'
,'mr_386'
,'mw_386'
,'mr_387'
,'mw_387'
,'mr_388'
,'mw_388'
,'mr_389'
,'mw_389'
,'mr_390'
,'mw_390'
,'mr_284'
,'mw_284'
,'mr_285'
,'mw_285'
,'mr_286'
,'mw_286'
,'mr_297'
,'mw_297'
,'mr_299'
,'mw_299'
,'mr_342'
,'mw_342'
,'mr_343'
,'mw_343'
,'mr_350'
,'mw_350'
,'mr_351'
,'mw_351'
,'mr_352'
,'mw_352'
,'mr_356'
,'mw_356'
,'mr_359'
,'mw_359'
,'mr_360'
,'mw_360'
,'mr_371'
,'mw_371'
,'mr_378'
,'mw_378'
,'mr_379'
,'mw_379'
,'mr_380'
,'mw_380'
,'mr_384'
,'mw_384'
,'mr_402'
,'mw_402'
,'mr_403'
,'mw_403'
,'mr_404'
,'mw_404'
,'mr_408'
,'mw_408'
)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202099' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)


--diriti Amministratori progetti
INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202098'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'anag_config',
'anagrafica',
'anagrafica_read',
'all_upb',
'all_man',
'mr_135',
'mr_136',
'mr_137',
'mr_143',
'mr_176',
'mr_177',
'mr_179',
'mr_211',
'mr_212',
'mr_215',
'mr_272',
'mr_283',
'mr_284',
'mr_285',
'mr_286',
'mr_29',
'mr_296',
'mr_297',
'mr_299',
'mr_300',
'mr_302',
'mr_303',
'mr_304',
'mr_305',
'mr_306',
'mr_307',
'mr_344',
'mr_348',
'mr_397',
'mr_400',
'mr_401',
'mr_41',
'mr_51',
'mr_52',
'mr_53',
'mr_79',
'mr_81',
'mr_82',
'mr_83',
'mr_86',
'mw_135',
'mw_136',
'mw_137',
'mw_211',
'mw_212',
'mw_215',
'mw_284',
'mw_285',
'mw_286',
'mw_297',
'mw_299',
'mw_300',
'mw_302',
'mw_303',
'mw_304',
'mw_305',
'mw_306',
'mw_401',
'mw_51',
'mw_52',
'mw_53',
'mw_79'
,'mr_408'
,'mw_408'
)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202098' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)





ï»¿ INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('duratakind', 'default', 'duratakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progetto', 'seg', 'progettosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('naturagiur', 'default', 'naturagiurdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accmotive', 'seg', 'accmotivesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('address', 'seg', 'addresssegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'default', 'affidamentodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'seg', 'affidamentosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamentokind', 'default', 'affidamentokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ambitoareadisc', 'default', 'ambitoareadiscdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aoo', 'default', 'aoodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aoo', 'princ', 'aooprincview', 'princ', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appello', 'default', 'appellodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appello', 'erogata', 'appelloerogataview', 'erogata', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appelloazionekind', 'default', 'appelloazionekinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appellokind', 'default', 'appellokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('areadidattica', 'default', 'areadidatticadefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('asset', 'seg', 'assetsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ateco', 'default', 'atecodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'appello', 'attivformappelloview', 'appello', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'default', 'attivformdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'erogata', 'attivformerogataview', 'erogata', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'gruppo', 'attivformgruppoview', 'gruppo', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'proped', 'attivformpropedview', 'proped', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aula', 'default', 'auladefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aula', 'seg_child', 'aulaseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aulakind', 'default', 'aulakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('canale', 'erogata', 'canaleerogataview', 'erogata', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ccnl', 'default', 'ccnldefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('changeskind', 'default', 'changeskinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classconsorsuale', 'default', 'classconsorsualedefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classescuola', 'default', 'classescuoladefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classescuolakind', 'default', 'classescuolakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('contrattokind', 'default', 'contrattokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('convenzione', 'seg', 'convenzionesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'default', 'corsostudiodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'dotmas', 'corsostudiodotmasview', 'dotmas', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'ingresso', 'corsostudioingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'stato', 'corsostudiostatoview', 'stato', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudiokind', 'default', 'corsostudiokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudiolivello', 'default', 'corsostudiolivellodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudionorma', 'default', 'corsostudionormadefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodef', 'more', 'costoscontodefmoreview', 'more', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodef', 'sconti', 'costoscontodefscontiview', 'sconti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodefkind', 'default', 'costoscontodefkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('decadenza', 'seg', 'decadenzasegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'seg', 'dichiarsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiarkind', 'default', 'dichiarkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('diderog', 'default', 'diderogdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'default', 'didprogdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'dotmas', 'didprogdotmasview', 'dotmas', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'ingresso', 'didprogingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'stato', 'didprogstatoview', 'stato', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didproganno', 'default', 'didprogannodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogori', 'default', 'didprogoridefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogori', 'sceltacorso', 'didprogorisceltacorsoview', 'sceltacorso', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogporzanno', 'default', 'didprogporzannodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('edificio', 'default', 'edificiodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('edificio', 'seg_child', 'edificioseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('erogazkind', 'default', 'erogazkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'default', 'esonerodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'carriera', 'esonerocarrieraview', 'carriera', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'disabil', 'esonerodisabilview', 'disabil', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'titolostudio', 'esonerotitolostudioview', 'titolostudio', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('expense', 'seg', 'expensesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'default', 'fasciaiseedefdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'more', 'fasciaiseedefmoreview', 'more', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'sconti', 'fasciaiseedefscontiview', 'sconti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fonteindicebibliometrico', 'seg', 'fonteindicebibliometricosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'default', 'geo_citydefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'seg', 'geo_citysegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'segchild', 'geo_citysegchildview', 'segchild', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_country', 'seg', 'geo_countrysegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_country', 'segchild', 'geo_countrysegchildview', 'segchild', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'lingue', 'geo_nationlingueview', 'lingue', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'seg', 'geo_nationsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'segchild', 'geo_nationsegchildview', 'segchild', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_region', 'seg', 'geo_regionsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('graduatoriavar', 'default', 'graduatoriavardefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inquadramento', 'default', 'inquadramentodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('insegn', 'default', 'insegndefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('insegninteg', 'default', 'insegnintegdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'default', 'iscrizionedefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'didprog', 'iscrizionedidprogview', 'didprog', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'dotmas', 'iscrizionedotmasview', 'dotmas', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'ingresso', 'iscrizioneingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seg', 'iscrizionesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstu', 'iscrizioneseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstuacc', 'iscrizioneseganagstuaccview', 'seganagstuacc', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstumast', 'iscrizioneseganagstumastview', 'seganagstumast', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstusing', 'iscrizioneseganagstusingview', 'seganagstusing', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstustato', 'iscrizioneseganagstustatoview', 'seganagstustato', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'stato', 'iscrizionestatoview', 'stato', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'seganagstusonpre', 'istanzaseganagstusonpreview', 'seganagstusonpre', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seg', 'istanzaimm_segview', 'imm_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagstu', 'istanzaimm_seganagstuview', 'imm_seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagstupre', 'istanzaimm_seganagstupreview', 'imm_seganagstupre', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagsturin', 'istanzaimm_seganagsturinview', 'imm_seganagsturin', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_segpre', 'istanzaimm_segpreview', 'imm_segpre', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_segrin', 'istanzaimm_segrinview', 'imm_segrin', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'pas_seganagstu', 'istanzapas_seganagstuview', 'pas_seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanzakind', 'default', 'istanzakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('itineration', 'seg', 'itinerationsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nace', 'default', 'nacedefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagstu', 'nullaostaimm_seganagstuview', 'imm_seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagstupre', 'nullaostaimm_seganagstupreview', 'imm_seganagstupre', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagsturin', 'nullaostaimm_seganagsturinview', 'imm_seganagsturin', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ofakind', 'default', 'ofakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('orakind', 'seg', 'orakindsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pagamentokind', 'default', 'pagamentokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pettycash', 'seg', 'pettycashsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pianostudio', 'segstud', 'pianostudiosegstudview', 'segstud', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pianostudiostatus', 'default', 'pianostudiostatusdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pratica', 'segstud', 'praticasegstudview', 'segstud', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoactivitykind', 'default', 'progettoactivitykinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettokind', 'seg', 'progettokindsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettotipocosto', 'seg', 'progettotipocostosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollo', 'seg', 'protocollosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollodockind', 'seg', 'protocollodockindsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollorifkind', 'seg', 'protocollorifkindsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'aula', 'provaaulaview', 'aula', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'default', 'provadefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'dotmas', 'provadotmasview', 'dotmas', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'ingresso', 'provaingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'stato', 'provastatoview', 'stato', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicazkind', 'default', 'publicazkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionario', 'default', 'questionariodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionariodomkind', 'default', 'questionariodomkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionariokind', 'default', 'questionariokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'default', 'ratadefdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'more', 'ratadefmoreview', 'more', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'sconti', 'ratadefscontiview', 'sconti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratakind', 'default', 'ratakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'default', 'registrydefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'amministrativi', 'registryamministrativiview', 'amministrativi', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'aziende', 'registryaziendeview', 'aziende', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'docenti', 'registrydocentiview', 'docenti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istituti', 'registryistitutiview', 'istituti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istituti_princ', 'registryistituti_princview', 'istituti_princ', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istitutiesteri', 'registryistitutiesteriview', 'istitutiesteri', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'studenti', 'registrystudentiview', 'studenti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'user', 'registryuserview', 'user', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryaddress', 'seg', 'registryaddresssegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryaddress', 'user', 'registryaddressuserview', 'user', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'aziende', 'registryclassaziendeview', 'aziende', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'default', 'registryclassdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'persone', 'registryclasspersoneview', 'persone', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryprogfin', 'seg', 'registryprogfinsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryprogfinbando', 'seg', 'registryprogfinbandosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontaltrokind', 'default', 'rendicontaltrokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'anag', 'rendicontattivitaprogettoanagview', 'anag', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'anagamm', 'rendicontattivitaprogettoanagammview', 'anagamm', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'seg', 'rendicontattivitaprogettosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasd', 'default', 'sasddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasdgruppo', 'default', 'sasdgruppodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'default', 'sededefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'seg_child', 'sedeseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'seg_child_azienda', 'sedeseg_child_aziendaview', 'seg_child_azienda', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sessione', 'default', 'sessionedefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sessionekind', 'default', 'sessionekinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('settoreerc', 'seg', 'settoreercsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('settoreerc', 'segprog', 'settoreercsegprogview', 'segprog', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'default', 'sostenimentodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'didprog', 'sostenimentodidprogview', 'didprog', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'ingresso', 'sostenimentoingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstu', 'sostenimentoseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstuacc', 'sostenimentoseganagstuaccview', 'seganagstuacc', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstuconsmast', 'sostenimentoseganagstuconsmastview', 'seganagstuconsmast', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstusing', 'sostenimentoseganagstusingview', 'seganagstusing', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstustato', 'sostenimentoseganagstustatoview', 'seganagstustato', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'segstud', 'sostenimentosegstudview', 'segstud', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimentoesito', 'default', 'sostenimentoesitodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('stipendiokind', 'default', 'stipendiokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'default', 'strutturadefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'princ', 'strutturaprincview', 'princ', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'seg_child', 'strutturaseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('strutturakind', 'default', 'strutturakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('studdirittokind', 'default', 'studdirittokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('studprenotkind', 'default', 'studprenotkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaconf', 'default', 'tassaconfdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaconfkind', 'default', 'tassaconfkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassacsingconf', 'default', 'tassacsingconfdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaiscrizioneconf', 'default', 'tassaiscrizioneconfdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaistanzaconf', 'default', 'tassaistanzaconfdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tax', 'seg', 'taxsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tipoattform', 'default', 'tipoattformdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirociniocandidaturakind', 'default', 'tirociniocandidaturakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirocinioprogetto', 'seg', 'tirocinioprogettosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirocinioproposto', 'seg', 'tirociniopropostosegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirociniostato', 'default', 'tirociniostatodefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('titolostudio', 'docenti', 'titolostudiodocentiview', 'docenti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('upb', 'default', 'upbdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('upb', 'seg', 'upbsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inventorytree', 'seg', 'inventorytreesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accordoscambiomi', 'seg', 'accordoscambiomisegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandomi', 'seg', 'bandomisegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('cefr', 'default', 'cefrdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('cefrlanglevel', 'default', 'cefrlangleveldefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assicurazione', 'default', 'assicurazionedefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandomobilitaintkind', 'default', 'bandomobilitaintkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizionebmi', 'seg', 'iscrizionebmisegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizionebmiattach', 'seg', 'iscrizionebmiattachsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandods', 'seg', 'bandodssegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('learningagrstud', 'seg', 'learningagrstudsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tipologiastudente', 'seg', 'tipologiastudentesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('learningagrtrainer', 'seg', 'learningagrtrainersegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accreditokind', 'default', 'accreditokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'isee_seganagstu', 'dichiarisee_seganagstuview', 'isee_seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'disabil_seganagstu', 'dichiardisabil_seganagstuview', 'disabil_seganagstu', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiardisabilkind', 'default', 'dichiardisabilkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiardisabilsuppkind', 'default', 'dichiardisabilsuppkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'disabil_seg', 'dichiardisabil_segview', 'disabil_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'isee_seg', 'dichiarisee_segview', 'isee_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'altrititoli_seg', 'dichiaraltrititoli_segview', 'altrititoli_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'altre_seg', 'dichiaraltre_segview', 'altre_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'segcons', 'sostenimentosegconsview', 'segcons', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiaraltrekind', 'default', 'dichiaraltrekinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'titolo_seg', 'dichiartitolo_segview', 'titolo_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'rin_seg', 'istanzarin_segview', 'rin_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'tru_seg', 'istanzatru_segview', 'tru_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('titolostudio', 'segtitolo', 'titolostudiosegtitoloview', 'segtitolo', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'eq_seg', 'istanzaeq_segview', 'eq_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'cert_seg', 'istanzacert_segview', 'cert_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'sosp_seg', 'istanzasosp_segview', 'sosp_seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanzaattach', 'seg', 'istanzaattachsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('delibera', 'seg', 'deliberasegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getdocentiperssd', 'seg', 'getdocentiperssdsegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getcostididattica', 'default', 'getcostididatticadefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getregistrydocentiamministrativi', 'default', 'getregistrydocentiamministratividefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getcostididattica', 'erogata', 'getcostididatticaerogataview', 'erogata', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('workpackage', 'seg', 'workpackagesegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accmotive', 'default', 'accmotivedefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetacquire', 'seg', 'assetacquiresegview', 'seg', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicaz', 'default', 'publicazdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicaz', 'docenti', 'publicazdocentiview', 'docenti', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoudrmembrokind', 'default', 'progettoudrmembrokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoasset', 'default', 'progettoassetdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'doc', 'affidamentodocview', 'doc', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'doc', 'rendicontattivitaprogettodocview', 'doc', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'docenti_doc', 'registrydocenti_docview', 'docenti_doc', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetdiary', 'doc', 'assetdiarydocview', 'doc', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sal', 'default', 'saldefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getprogettocostoview', 'default', 'getprogettocostoviewdefaultview', 'default', NULL, NULL, NULL, NULL)
 INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getprogettocostoliquidatoview', 'default', 'getprogettocostoliquidatoviewdefaultview', 'default', NULL, NULL, NULL, NULL)
 --insert
