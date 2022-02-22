
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


setuser 'amministrazione'
---------------------------------------------------
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD idworkpackage int /*NOT NULL*/ DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN idworkpackage int /*NOT NULL*/
GO

UPDATE rendicontattivitaprogettoora
SET rendicontattivitaprogettoora.idworkpackage = rendicontattivitaprogetto.idworkpackage
FROM rendicontattivitaprogettoora INNER JOIN rendicontattivitaprogetto
ON rendicontattivitaprogettoora.idrendicontattivitaprogetto = rendicontattivitaprogetto.idrendicontattivitaprogetto


ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN idworkpackage int NOT NULL
GO

--BEGIN TRANSACTION
--SET QUOTED_IDENTIFIER ON
--SET ARITHABORT ON
--SET NUMERIC_ROUNDABORT OFF
--SET CONCAT_NULL_YIELDS_NULL ON
--SET ANSI_NULLS ON
--SET ANSI_PADDING ON
--SET ANSI_WARNINGS ON
--COMMIT
--BEGIN TRANSACTION
--GO
--ALTER TABLE amministrazione.rendicontattivitaprogettoora
--	DROP CONSTRAINT PK_rendicontattivitaprogettoora
--GO
--ALTER TABLE amministrazione.rendicontattivitaprogettoora ADD CONSTRAINT
--	PK_rendicontattivitaprogettoora PRIMARY KEY CLUSTERED 
--	(
--	idrendicontattivitaprogettoora,
--	idrendicontattivitaprogetto,
--	idworkpackage
--	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

--GO
--ALTER TABLE amministrazione.rendicontattivitaprogettoora SET (LOCK_ESCALATION = TABLE)
--GO
--COMMIT

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE Amministrazione.rendicontattivitaprogettoora
	DROP CONSTRAINT xpkrendicontattivitaprogettoora
GO
ALTER TABLE Amministrazione.rendicontattivitaprogettoora ADD CONSTRAINT
	xpkrendicontattivitaprogettoora PRIMARY KEY CLUSTERED 
	(
	idrendicontattivitaprogettoora,
	idrendicontattivitaprogetto,
	idworkpackage
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE Amministrazione.rendicontattivitaprogettoora SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

------------------------------------------------ rendicontattivitaprogetto

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE amministrazione.rendicontattivitaprogetto
	DROP CONSTRAINT xpkrendicontattivitaprogetto
GO
ALTER TABLE amministrazione.rendicontattivitaprogetto ADD CONSTRAINT
	xpkrendicontattivitaprogetto PRIMARY KEY CLUSTERED 
	(
	idrendicontattivitaprogetto,
	idworkpackage
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE amministrazione.rendicontattivitaprogetto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
-------------------------------------------------------

---------------------------------------------------
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD idworkpackage int /*NOT NULL*/ DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN idworkpackage int /*NOT NULL*/
GO

UPDATE assetdiaryora
SET assetdiaryora.idworkpackage = assetdiary.idworkpackage
FROM assetdiaryora INNER JOIN assetdiary
ON assetdiaryora.idassetdiary = assetdiary.idassetdiary


ALTER TABLE [assetdiaryora] ALTER COLUMN idworkpackage int NOT NULL
GO

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE amministrazione.assetdiaryora
	DROP CONSTRAINT xpkassetdiaryora
GO
ALTER TABLE amministrazione.assetdiaryora ADD CONSTRAINT
	xpkassetdiaryora PRIMARY KEY CLUSTERED 
	(
	idassetdiaryora,
	idassetdiary,
	idworkpackage
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE amministrazione.assetdiaryora SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
--------------------------------------------------------------------------
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE amministrazione.assetdiary
	DROP CONSTRAINT xpkassetdiary
GO
ALTER TABLE amministrazione.assetdiary ADD CONSTRAINT
	xpkassetdiary PRIMARY KEY CLUSTERED 
	(
	idassetdiary,
	idworkpackage
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE amministrazione.assetdiary SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


/****** Object:  Table [dbo].[year]    Script Date: 17/02/2021 17:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[year](
	[year] [int] NOT NULL,
 CONSTRAINT [PK_year] PRIMARY KEY CLUSTERED 
(
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[year] ([year]) VALUES (2000)
GO
INSERT [dbo].[year] ([year]) VALUES (2001)
GO
INSERT [dbo].[year] ([year]) VALUES (2002)
GO
INSERT [dbo].[year] ([year]) VALUES (2003)
GO
INSERT [dbo].[year] ([year]) VALUES (2004)
GO
INSERT [dbo].[year] ([year]) VALUES (2005)
GO
INSERT [dbo].[year] ([year]) VALUES (2007)
GO
INSERT [dbo].[year] ([year]) VALUES (2008)
GO
INSERT [dbo].[year] ([year]) VALUES (2009)
GO
INSERT [dbo].[year] ([year]) VALUES (2010)
GO
INSERT [dbo].[year] ([year]) VALUES (2011)
GO
INSERT [dbo].[year] ([year]) VALUES (2012)
GO
INSERT [dbo].[year] ([year]) VALUES (2013)
GO
INSERT [dbo].[year] ([year]) VALUES (2014)
GO
INSERT [dbo].[year] ([year]) VALUES (2015)
GO
INSERT [dbo].[year] ([year]) VALUES (2016)
GO
INSERT [dbo].[year] ([year]) VALUES (2017)
GO
INSERT [dbo].[year] ([year]) VALUES (2018)
GO
INSERT [dbo].[year] ([year]) VALUES (2019)
GO
INSERT [dbo].[year] ([year]) VALUES (2020)
GO
INSERT [dbo].[year] ([year]) VALUES (2021)
GO
INSERT [dbo].[year] ([year]) VALUES (2022)
GO
INSERT [dbo].[year] ([year]) VALUES (2023)
GO

-- CREAZIONE TABELLA progettotimesheet --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotimesheet]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotimesheet] (
idprogettotimesheet int NOT NULL,
idreg int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
lt datetime NULL,
lu varchar(60) NULL,
showactivitiesrow char(1) NULL,
title nvarchar(2048) NULL,
year int NULL,
 CONSTRAINT xpkprogettotimesheet PRIMARY KEY (idprogettotimesheet,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA progettotimesheet --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'idprogettotimesheet' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD idprogettotimesheet int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotimesheet') and col.name = 'idprogettotimesheet' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotimesheet] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotimesheet') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotimesheet] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN lu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'showactivitiesrow' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD showactivitiesrow char(1) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN showactivitiesrow char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN title nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheet' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheet] ADD year int NULL 
END
ELSE
	ALTER TABLE [progettotimesheet] ALTER COLUMN year int NULL
GO

-- VERIFICA DI progettotimesheet IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettotimesheet'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotimesheet','int','assistenza','idprogettotimesheet','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotimesheet','int','assistenza','idreg','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','datetime','assistenza','ct','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','varchar(60)','assistenza','cu','60','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','varchar(60)','assistenza','lu','60','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','char(1)','assistenza','showactivitiesrow','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','nvarchar(2048)','assistenza','title','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheet','int','assistenza','year','4','N','int','System.Int32','','','''assistenza''','','N')
GO

-- VERIFICA DI progettotimesheet IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettotimesheet')
UPDATE customobject set isreal = 'S' where objectname = 'progettotimesheet'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettotimesheet', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettotimesheet')
UPDATE [tabledescr] SET description = 'Timesheets',idapplication = null,isdbo = 'N',lt = {ts '2021-02-03 11:24:45.727'},lu = 'assistenza',title = 'Timesheets' WHERE tablename = 'progettotimesheet'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettotimesheet','Timesheets',null,'N',{ts '2021-02-03 11:24:45.727'},'assistenza','Timesheets')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:30:13.560'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettotimesheet','8',null,null,null,'S',{ts '2021-02-03 11:30:13.560'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:30:13.560'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettotimesheet','60',null,null,null,'S',{ts '2021-02-03 11:30:13.560'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotimesheet' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 12:19:10.057'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotimesheet' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotimesheet','progettotimesheet','4',null,null,null,'S',{ts '2021-02-03 12:19:10.057'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:30:13.563'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','progettotimesheet','4',null,null,null,'S',{ts '2021-02-03 11:30:13.563'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:30:13.563'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettotimesheet','8',null,null,null,'S',{ts '2021-02-03 11:30:13.563'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:30:13.563'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettotimesheet','60',null,null,null,'S',{ts '2021-02-03 11:30:13.563'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'showactivitiesrow' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Visualizza la riga con il totale giornaliero',kind = 'S',lt = {ts '2021-02-03 11:38:05.607'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'showactivitiesrow' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('showactivitiesrow','progettotimesheet','1',null,null,'Visualizza la riga con il totale giornaliero','S',{ts '2021-02-03 11:38:05.607'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2021-02-03 11:30:50.300'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progettotimesheet','2048',null,null,'Descrizione','S',{ts '2021-02-03 11:30:50.300'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'year' AND tablename = 'progettotimesheet')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno',kind = 'S',lt = {ts '2021-02-03 12:19:07.873'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'year' AND tablename = 'progettotimesheet'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('year','progettotimesheet','4',null,null,'Anno','S',{ts '2021-02-03 12:19:07.873'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --


-- CREAZIONE TABELLA progettotimesheetprogetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettotimesheetprogetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettotimesheetprogetto] (
idprogettotimesheet int NOT NULL,
idprogetto int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
lt datetime NULL,
lu varchar(60) NULL,
 CONSTRAINT xpkprogettotimesheetprogetto PRIMARY KEY (idprogettotimesheet,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettotimesheetprogetto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheetprogetto' and C.name = 'idprogettotimesheet' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheetprogetto] ADD idprogettotimesheet int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotimesheetprogetto') and col.name = 'idprogettotimesheet' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotimesheetprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheetprogetto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheetprogetto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotimesheetprogetto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotimesheetprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheetprogetto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheetprogetto] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotimesheetprogetto] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheetprogetto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheetprogetto] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheetprogetto] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheetprogetto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheetprogetto] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotimesheetprogetto] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotimesheetprogetto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotimesheetprogetto] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettotimesheetprogetto] ALTER COLUMN lu varchar(60) NULL
GO

-- VERIFICA DI progettotimesheetprogetto IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettotimesheetprogetto'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotimesheetprogetto','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotimesheetprogetto','int','assistenza','idprogettotimesheet','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheetprogetto','datetime','assistenza','ct','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheetprogetto','varchar(60)','assistenza','cu','60','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheetprogetto','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotimesheetprogetto','varchar(60)','assistenza','lu','60','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI progettotimesheetprogetto IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettotimesheetprogetto')
UPDATE customobject set isreal = 'S' where objectname = 'progettotimesheetprogetto'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettotimesheetprogetto', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettotimesheetprogetto')
UPDATE [tabledescr] SET description = 'Progetti da visualizzare nel timesheet',idapplication = null,isdbo = 'N',lt = {ts '2021-02-03 11:31:39.867'},lu = 'assistenza',title = 'Progetti da visualizzare nel timesheet' WHERE tablename = 'progettotimesheetprogetto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettotimesheetprogetto','Progetti da visualizzare nel timesheet',null,'N',{ts '2021-02-03 11:31:39.867'},'assistenza','Progetti da visualizzare nel timesheet')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettotimesheetprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:31:42.897'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettotimesheetprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettotimesheetprogetto','8',null,null,null,'S',{ts '2021-02-03 11:31:42.897'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettotimesheetprogetto')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:31:42.900'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettotimesheetprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettotimesheetprogetto','60',null,null,null,'S',{ts '2021-02-03 11:31:42.900'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettotimesheetprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:31:42.900'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettotimesheetprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettotimesheetprogetto','4',null,null,null,'S',{ts '2021-02-03 11:31:42.900'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotimesheet' AND tablename = 'progettotimesheetprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:31:42.900'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotimesheet' AND tablename = 'progettotimesheetprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotimesheet','progettotimesheetprogetto','4',null,null,null,'S',{ts '2021-02-03 11:31:42.900'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettotimesheetprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:31:42.900'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettotimesheetprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettotimesheetprogetto','8',null,null,null,'S',{ts '2021-02-03 11:31:42.900'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettotimesheetprogetto')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2021-02-03 11:31:42.900'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettotimesheetprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettotimesheetprogetto','60',null,null,null,'S',{ts '2021-02-03 11:31:42.900'},'assistenza','N','varchar(60)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --



-- CREAZIONE TABELLA assetdiary --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetdiary]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetdiary] (
idassetdiary int NOT NULL,
idworkpackage int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idasset int NOT NULL,
idpiece int NULL,
idprogetto int NOT NULL,
idreg int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
orepreventivate int NULL,
 CONSTRAINT xpkassetdiary PRIMARY KEY (idassetdiary,
idworkpackage
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

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
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

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
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

-- CREAZIONE TABELLA assetdiaryora --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[assetdiaryora]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [assetdiaryora] (
idassetdiaryora int NOT NULL,
idassetdiary int NOT NULL,
idworkpackage int NOT NULL,
amount decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start datetime NULL,
stop datetime NULL,
 CONSTRAINT xpkassetdiaryora PRIMARY KEY (idassetdiaryora,
idassetdiary,
idworkpackage
)
)
END
GO

-- VERIFICA STRUTTURA assetdiaryora --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'idassetdiaryora' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD idassetdiaryora int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'idassetdiaryora' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'idassetdiary' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD idassetdiary int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'idassetdiary' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'amount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD amount decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN amount decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD start datetime NULL 
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN start datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD stop datetime NULL 
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN stop datetime NULL
GO

-- VERIFICA DI assetdiaryora IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetdiaryora'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryora','int','ASSISTENZA','idassetdiary','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryora','int','ASSISTENZA','idassetdiaryora','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryora','int','','idworkpackage','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryora','decimal(9,2)','ASSISTENZA','amount','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryora','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryora','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryora','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiaryora','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryora','datetime','ASSISTENZA','start','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiaryora','datetime','ASSISTENZA','stop','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI assetdiaryora IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetdiaryora')
UPDATE customobject set isreal = 'S' where objectname = 'assetdiaryora'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetdiaryora', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'assetdiaryora')
UPDATE [tabledescr] SET description = 'Dettaglio delle ore di utilizzo di un bene strumentale',idapplication = null,isdbo = 'N',lt = {ts '2020-06-05 16:23:30.240'},lu = 'assistenza',title = 'Dettaglio delle ore' WHERE tablename = 'assetdiaryora'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('assetdiaryora','Dettaglio delle ore di utilizzo di un bene strumentale',null,'N',{ts '2020-06-05 16:23:30.240'},'assistenza','Dettaglio delle ore')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'amount' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = null,kind = 'S',lt = {ts '2020-06-23 16:49:01.053'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'amount' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('amount','assetdiaryora','5','9','2',null,'S',{ts '2020-06-23 16:49:01.053'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:23:32.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','assetdiaryora','8',null,null,null,'S',{ts '2020-06-05 16:23:32.147'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:23:32.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','assetdiaryora','64',null,null,null,'S',{ts '2020-06-05 16:23:32.147'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idassetdiary' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:23:32.147'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idassetdiary' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idassetdiary','assetdiaryora','4',null,null,null,'S',{ts '2020-06-05 16:23:32.147'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idassetdiaryora' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:23:32.147'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idassetdiaryora' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idassetdiaryora','assetdiaryora','4',null,null,null,'S',{ts '2020-06-05 16:23:32.147'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:23:32.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','assetdiaryora','8',null,null,null,'S',{ts '2020-06-05 16:23:32.147'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:23:32.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','assetdiaryora','64',null,null,null,'S',{ts '2020-06-05 16:23:32.147'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data e ora di inizio',kind = 'S',lt = {ts '2020-06-05 16:25:20.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','assetdiaryora','8',null,null,'Data e ora di inizio','S',{ts '2020-06-05 16:25:20.413'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'assetdiaryora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data e ora di fine',kind = 'S',lt = {ts '2020-06-05 16:25:20.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'assetdiaryora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','assetdiaryora','8',null,null,'Data e ora di fine','S',{ts '2020-06-05 16:25:20.413'},'assistenza','N','datetime','datetime','System.DateTime')
GO

-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE TABELLA progetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progetto] (
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

-- CREAZIONE TABELLA progettobudget --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettobudget]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettobudget] (
idprogettobudget int NOT NULL,
idprogetto int NOT NULL,
budget decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idprogettotipocosto int NULL,
idworkpackage int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NULL,
 CONSTRAINT xpkprogettobudget PRIMARY KEY (idprogettobudget,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettobudget --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idprogettobudget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idprogettobudget int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'idprogettobudget' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'budget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD budget decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN budget decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idprogettotipocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idprogettotipocosto int NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN idprogettotipocosto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idworkpackage int NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN idworkpackage int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN sortcode int NULL
GO

-- VERIFICA DI progettobudget IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettobudget'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','int','assistenza','idprogettobudget','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudget','decimal(9,2)','assistenza','budget','5','N','decimal','System.Decimal','','2','''assistenza''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudget','int','assistenza','idprogettotipocosto','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudget','int','assistenza','idworkpackage','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudget','int','assistenza','sortcode','4','N','int','System.Int32','','','''assistenza''','','N')
GO

-- VERIFICA DI progettobudget IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettobudget')
UPDATE customobject set isreal = 'S' where objectname = 'progettobudget'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettobudget', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettobudget')
UPDATE [tabledescr] SET description = 'Budget per le categorie di costo di un progetto ',idapplication = null,isdbo = 'N',lt = {ts '2020-06-18 12:14:40.277'},lu = 'assistenza',title = 'Budget per le categorie di costo di un progetto ' WHERE tablename = 'progettobudget'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettobudget','Budget per le categorie di costo di un progetto ',null,'N',{ts '2020-06-18 12:14:40.277'},'assistenza','Budget per le categorie di costo di un progetto ')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'budget' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Budget iniziale',kind = 'S',lt = {ts '2020-12-09 16:32:07.130'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budget' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budget','progettobudget','5','9','2','Budget iniziale','S',{ts '2020-12-09 16:32:07.130'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettobudget','8',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettobudget','64',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettobudget','4',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettobudget' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettobudget' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettobudget','progettobudget','4',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotipocosto' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Voce di costo',kind = 'S',lt = {ts '2020-06-18 12:17:09.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotipocosto' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotipocosto','progettobudget','4',null,null,'Voce di costo','S',{ts '2020-06-18 12:17:09.210'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2020-06-18 12:17:09.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','progettobudget','4',null,null,'Workpackage','S',{ts '2020-06-18 12:17:09.210'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettobudget','8',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettobudget','64',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordine di visualizzazione',kind = 'S',lt = {ts '2020-06-18 12:17:09.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','progettobudget','4',null,null,'Ordine di visualizzazione','S',{ts '2020-06-18 12:17:09.210'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE TABELLA progettosettoreerc --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progettosettoreerc]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progettosettoreerc] (
idprogetto int NOT NULL,
idsettoreerc int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkprogettosettoreerc PRIMARY KEY (idprogetto,
idsettoreerc
)
)
END
GO

-- VERIFICA STRUTTURA progettosettoreerc --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettosettoreerc' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettosettoreerc] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettosettoreerc') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettosettoreerc] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettosettoreerc' and C.name = 'idsettoreerc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettosettoreerc] ADD idsettoreerc int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettosettoreerc') and col.name = 'idsettoreerc' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettosettoreerc] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettosettoreerc' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettosettoreerc] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettosettoreerc') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettosettoreerc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettosettoreerc] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettosettoreerc' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettosettoreerc] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettosettoreerc') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettosettoreerc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettosettoreerc] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettosettoreerc' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettosettoreerc] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettosettoreerc') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettosettoreerc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettosettoreerc] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettosettoreerc' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettosettoreerc] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettosettoreerc') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettosettoreerc] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettosettoreerc] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI progettosettoreerc IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettosettoreerc'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosettoreerc','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosettoreerc','int','ASSISTENZA','idsettoreerc','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosettoreerc','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosettoreerc','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosettoreerc','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosettoreerc','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettosettoreerc IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettosettoreerc')
UPDATE customobject set isreal = 'S' where objectname = 'progettosettoreerc'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettosettoreerc', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettosettoreerc')
UPDATE [tabledescr] SET description = 'Settori ERC del progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-06-05 13:16:55.230'},lu = 'assistenza',title = 'Settori ERC' WHERE tablename = 'progettosettoreerc'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettosettoreerc','Settori ERC del progetto',null,'N',{ts '2020-06-05 13:16:55.230'},'assistenza','Settori ERC')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettosettoreerc')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 13:16:57.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettosettoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettosettoreerc','8',null,null,null,'S',{ts '2020-06-05 13:16:57.077'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettosettoreerc')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 13:16:57.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettosettoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettosettoreerc','64',null,null,null,'S',{ts '2020-06-05 13:16:57.080'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettosettoreerc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 13:16:57.080'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettosettoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettosettoreerc','4',null,null,null,'S',{ts '2020-06-05 13:16:57.080'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsettoreerc' AND tablename = 'progettosettoreerc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Settore ERC',kind = 'S',lt = {ts '2020-06-05 13:17:17.990'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsettoreerc' AND tablename = 'progettosettoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsettoreerc','progettosettoreerc','4',null,null,'Settore ERC','S',{ts '2020-06-05 13:17:17.990'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettosettoreerc')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 13:16:57.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettosettoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettosettoreerc','8',null,null,null,'S',{ts '2020-06-05 13:16:57.080'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettosettoreerc')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 13:16:57.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettosettoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettosettoreerc','64',null,null,null,'S',{ts '2020-06-05 13:16:57.080'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
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

-- VERIFICA DI registry_amministrativi IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registry_amministrativi'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_amministrativi','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','nvarchar(max)','ASSISTENZA','cv','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','int','ASSISTENZA','idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registry_amministrativi IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registry_amministrativi')
UPDATE customobject set isreal = 'S' where objectname = 'registry_amministrativi'
ELSE
INSERT INTO customobject (objectname, isreal) values('registry_amministrativi', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_amministrativi')
UPDATE [tabledescr] SET description = '2.7.8 Personale amministrativo',idapplication = null,isdbo = 'N',lt = {ts '2020-05-25 13:44:18.543'},lu = 'assistenza',title = 'Personale amministrativo' WHERE tablename = 'registry_amministrativi'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_amministrativi','2.7.8 Personale amministrativo',null,'N',{ts '2020-05-25 13:44:18.543'},'assistenza','Personale amministrativo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_amministrativi','8',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_amministrativi','64',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cv' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Curriculum vitae',kind = 'S',lt = {ts '2020-05-25 13:44:54.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'cv' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cv','registry_amministrativi','0',null,null,'Curriculum vitae','S',{ts '2020-05-25 13:44:54.460'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2020-05-25 13:44:54.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','registry_amministrativi','4',null,null,'Tipo','S',{ts '2020-05-25 13:44:54.460'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_amministrativi','4',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_amministrativi','8',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_amministrativi','64',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
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

-- VERIFICA DI registry_docenti IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registry_docenti'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','nvarchar(max)','ASSISTENZA','cv','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idclassconsorsuale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idfonteindicebibliometrico','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idreg_istituti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idsasd','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idstruttura','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','indicebibliometrico','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','varchar(50)','ASSISTENZA','matricola','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','nvarchar(max)','ASSISTENZA','ricevimento','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','varchar(255)','ASSISTENZA','soggiorno','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registry_docenti IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registry_docenti')
UPDATE customobject set isreal = 'S' where objectname = 'registry_docenti'
ELSE
INSERT INTO customobject (objectname, isreal) values('registry_docenti', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_docenti')
UPDATE [tabledescr] SET description = '2.4.20 docenti',idapplication = null,isdbo = 'N',lt = {ts '2018-11-29 16:25:52.000'},lu = 'Ferdinando',title = 'Docenti' WHERE tablename = 'registry_docenti'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_docenti','2.4.20 docenti',null,'N',{ts '2018-11-29 16:25:52.000'},'Ferdinando','Docenti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_docenti','8',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_docenti','64',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cv' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Curriculum Vitae',kind = 'S',lt = {ts '2018-11-27 13:37:14.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'cv' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cv','registry_docenti','0',null,null,'Curriculum Vitae','S',{ts '2018-11-27 13:37:14.000'},'Ferdinando','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassconsorsuale' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Classe consorsuale',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassconsorsuale' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassconsorsuale','registry_docenti','4',null,null,'Classe consorsuale','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2020-05-26 17:44:20.453'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','registry_docenti','4',null,null,'Tipo','S',{ts '2020-05-26 17:44:20.453'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idfonteindicebibliometrico' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Fonte',kind = 'S',lt = {ts '2020-05-25 13:46:28.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idfonteindicebibliometrico' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idfonteindicebibliometrico','registry_docenti','4',null,null,'Fonte','S',{ts '2020-05-25 13:46:28.367'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice Istituto',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_docenti','4',null,null,'Codice Istituto','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_istituti' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istituto, Ente o Azienda',kind = 'S',lt = {ts '2019-02-15 17:21:00.613'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_istituti' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_istituti','registry_docenti','4',null,null,'Istituto, Ente o Azienda','S',{ts '2019-02-15 17:21:00.613'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'SASD',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','registry_docenti','4',null,null,'SASD','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura di afferenza',kind = 'S',lt = {ts '2019-09-09 18:32:55.953'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','registry_docenti','4',null,null,'Struttura di afferenza','S',{ts '2019-09-09 18:32:55.953'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indicebibliometrico' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Indice bibliometrico (H-Index)',kind = 'S',lt = {ts '2020-05-25 13:46:28.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'indicebibliometrico' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indicebibliometrico','registry_docenti','4',null,null,'Indice bibliometrico (H-Index)','S',{ts '2020-05-25 13:46:28.367'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_docenti','8',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_docenti','64',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'matricola' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Matricola',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'matricola' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('matricola','registry_docenti','50',null,null,'Matricola','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ricevimento' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Orari di ricevimento',kind = 'S',lt = {ts '2018-11-27 13:28:30.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'ricevimento' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ricevimento','registry_docenti','0',null,null,'Orari di ricevimento','S',{ts '2018-11-27 13:28:30.000'},'Ferdinando','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'soggiorno' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '255',col_precision = null,col_scale = null,description = 'Permesso di soggiorno',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(255)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'soggiorno' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('soggiorno','registry_docenti','255',null,null,'Permesso di soggiorno','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','varchar(255)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE TABELLA rendicontattivitaprogetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [rendicontattivitaprogetto] (
idrendicontattivitaprogetto int NOT NULL,
idworkpackage int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datainizioprevista date NULL,
description varchar(max) NULL,
iditineration int NULL,
idprogetto int NOT NULL,
idreg int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
orepreventivate int NULL,
 CONSTRAINT xpkrendicontattivitaprogetto PRIMARY KEY (idrendicontattivitaprogetto,
idworkpackage
)
)
END
GO

-- VERIFICA STRUTTURA rendicontattivitaprogetto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'idrendicontattivitaprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD idrendicontattivitaprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'idrendicontattivitaprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'datainizioprevista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD datainizioprevista date NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN datainizioprevista date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD iditineration int NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN iditineration int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN idprogetto int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN idreg int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'orepreventivate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD orepreventivate int NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN orepreventivate int NULL
GO

-- VERIFICA DI rendicontattivitaprogetto IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogetto'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogetto','date','ASSISTENZA','datainizioprevista','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogetto','varchar(max)','ASSISTENZA','description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogetto','int','ASSISTENZA','iditineration','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogetto','int','ASSISTENZA','orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogetto IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogetto')
UPDATE customobject set isreal = 'S' where objectname = 'rendicontattivitaprogetto'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogetto', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'rendicontattivitaprogetto')
UPDATE [tabledescr] SET description = '2.7.3 Attivit? di progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-05-20 14:12:22.837'},lu = 'assistenza',title = 'Attivit? di progetto' WHERE tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('rendicontattivitaprogetto','2.7.3 Attivit? di progetto',null,'N',{ts '2020-05-20 14:12:22.837'},'assistenza','Attivit? di progetto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','rendicontattivitaprogetto','8',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','rendicontattivitaprogetto','64',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datainizioprevista' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data inizio prevista',kind = 'S',lt = {ts '2020-06-23 10:48:50.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datainizioprevista' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datainizioprevista','rendicontattivitaprogetto','3',null,null,'Data inizio prevista','S',{ts '2020-06-23 10:48:50.413'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','rendicontattivitaprogetto','-1',null,null,'Descrizione','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iditineration' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Missione',kind = 'S',lt = {ts '2020-06-23 10:48:50.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iditineration' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iditineration','rendicontattivitaprogetto','4',null,null,'Missione','S',{ts '2020-06-23 10:48:50.413'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','rendicontattivitaprogetto','4',null,null,'Progetto','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Partecipante',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','rendicontattivitaprogetto','4',null,null,'Partecipante','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogetto','rendicontattivitaprogetto','4',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','rendicontattivitaprogetto','4',null,null,'Workpackage','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','rendicontattivitaprogetto','8',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','rendicontattivitaprogetto','64',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'orepreventivate' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di ore preventivate',kind = 'S',lt = {ts '2020-06-23 10:48:50.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'orepreventivate' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('orepreventivate','rendicontattivitaprogetto','4',null,null,'Numero di ore preventivate','S',{ts '2020-06-23 10:48:50.413'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE TABELLA rendicontattivitaprogettoora --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoora]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [rendicontattivitaprogettoora] (
idrendicontattivitaprogettoora int NOT NULL,
idrendicontattivitaprogetto int NOT NULL,
idworkpackage int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data date NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ore int NULL,
 CONSTRAINT xpkrendicontattivitaprogettoora PRIMARY KEY (idrendicontattivitaprogettoora,
idrendicontattivitaprogetto,
idworkpackage
)
)
END
GO

-- VERIFICA STRUTTURA rendicontattivitaprogettoora --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'idrendicontattivitaprogettoora' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD idrendicontattivitaprogettoora int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'idrendicontattivitaprogettoora' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'idrendicontattivitaprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD idrendicontattivitaprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'idrendicontattivitaprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD data date NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'ore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD ore int NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN ore int NULL
GO

-- VERIFICA DI rendicontattivitaprogettoora IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettoora'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoora','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoora','int','ASSISTENZA','idrendicontattivitaprogettoora','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoora','int','','idworkpackage','4','S','int','System.Int32','','','','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoora','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoora','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoora','date','ASSISTENZA','data','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoora','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoora','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoora','int','ASSISTENZA','ore','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogettoora IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettoora')
UPDATE customobject set isreal = 'S' where objectname = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettoora', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'rendicontattivitaprogettoora')
UPDATE [tabledescr] SET description = 'Dettaglio giornaliero della 2.7.3 rendicontazione delle attivit? di progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-05-20 14:11:37.107'},lu = 'assistenza',title = 'Dettaglio giornaliero della attivit? di progetto' WHERE tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('rendicontattivitaprogettoora','Dettaglio giornaliero della 2.7.3 rendicontazione delle attivit? di progetto',null,'N',{ts '2020-05-20 14:11:37.107'},'assistenza','Dettaglio giornaliero della attivit? di progetto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:09:52.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','rendicontattivitaprogettoora','8',null,null,null,'S',{ts '2020-05-20 14:09:52.937'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:09:52.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','rendicontattivitaprogettoora','64',null,null,null,'S',{ts '2020-05-20 14:09:52.937'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data',kind = 'S',lt = {ts '2020-05-20 14:11:37.110'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','rendicontattivitaprogettoora','3',null,null,'Data','S',{ts '2020-05-20 14:11:37.110'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Attivit? di progetto',kind = 'S',lt = {ts '2020-05-20 14:11:37.110'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogetto','rendicontattivitaprogettoora','4',null,null,'Attivit? di progetto','S',{ts '2020-05-20 14:11:37.110'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogettoora' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 15:34:08.850'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogettoora' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogettoora','rendicontattivitaprogettoora','4',null,null,null,'S',{ts '2020-05-20 15:34:08.850'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:09:52.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','rendicontattivitaprogettoora','8',null,null,null,'S',{ts '2020-05-20 14:09:52.937'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:09:52.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','rendicontattivitaprogettoora','64',null,null,null,'S',{ts '2020-05-20 14:09:52.937'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ore' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di ore',kind = 'S',lt = {ts '2020-05-20 14:11:57.517'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'ore' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ore','rendicontattivitaprogettoora','4',null,null,'Numero di ore','S',{ts '2020-05-20 14:11:57.517'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA settoreerc --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[settoreerc]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[settoreerc] (
idsettoreerc int NOT NULL,
active char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description nvarchar(2048) NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpksettoreerc PRIMARY KEY (idsettoreerc
)
)
END
GO

-- VERIFICA STRUTTURA settoreerc --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'idsettoreerc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD idsettoreerc int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('settoreerc') and col.name = 'idsettoreerc' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [settoreerc] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD description nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN description nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'settoreerc' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [settoreerc] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [settoreerc] ALTER COLUMN title nvarchar(2048) NULL
GO

-- VERIFICA DI settoreerc IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'settoreerc'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','settoreerc','int','ASSISTENZA','idsettoreerc','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','nvarchar(2048)','ASSISTENZA','description','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','int','ASSISTENZA','sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreerc','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI settoreerc IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'settoreerc')
UPDATE customobject set isreal = 'S' where objectname = 'settoreerc'
ELSE
INSERT INTO customobject (objectname, isreal) values('settoreerc', 'S')
GO

-- GENERAZIONE DATI PER settoreerc --
IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '1')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '1',title = 'SH - SOCIAL SCIENCES AND HUMANITIES' WHERE idsettoreerc = '1'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','1','SH - SOCIAL SCIENCES AND HUMANITIES')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '2')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '2',title = 'SH1 Markets, Individuals and Institutions: Economics, finance and management ' WHERE idsettoreerc = '2'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','2','SH1 Markets, Individuals and Institutions: Economics, finance and management ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '3')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '3',title = 'SH1_1 Macroeconomics, development economics, economic growth ' WHERE idsettoreerc = '3'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','3','SH1_1 Macroeconomics, development economics, economic growth ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '4')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '4',title = 'SH1_2 International trade, international business, international management ' WHERE idsettoreerc = '4'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('4','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','4','SH1_2 International trade, international business, international management ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '5')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '5',title = 'SH1_3 Financial economics, monetary economics ' WHERE idsettoreerc = '5'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('5','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','5','SH1_3 Financial economics, monetary economics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '6')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '6',title = 'SH1_4 Banking, corporate finance, international finance, accounting, auditing, insurance ' WHERE idsettoreerc = '6'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('6','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','6','SH1_4 Banking, corporate finance, international finance, accounting, auditing, insurance ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '7')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '7',title = 'SH1_5 Labour economics, human resource management ' WHERE idsettoreerc = '7'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('7','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','7','SH1_5 Labour economics, human resource management ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '8')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '8',title = 'SH1_6 Econometrics, operations research ' WHERE idsettoreerc = '8'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('8','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','8','SH1_6 Econometrics, operations research ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '9')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '9',title = 'SH1_7 Behavioural economics, experimental economics, neuro-economics ' WHERE idsettoreerc = '9'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('9','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','9','SH1_7 Behavioural economics, experimental economics, neuro-economics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '10')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '10',title = 'SH1_8 Microeconomics, game theory ' WHERE idsettoreerc = '10'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('10','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','10','SH1_8 Microeconomics, game theory ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '11')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '11',title = 'SH1_9 Marketing ' WHERE idsettoreerc = '11'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('11','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','11','SH1_9 Marketing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '12')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '12',title = 'SH1_10 Management, organisational behaviour, operations management ' WHERE idsettoreerc = '12'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('12','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','12','SH1_10 Management, organisational behaviour, operations management ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '13')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '13',title = 'SH1_11 Industrial organisation, strategy, entrepreneurship ' WHERE idsettoreerc = '13'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('13','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','13','SH1_11 Industrial organisation, strategy, entrepreneurship ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '14')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '14',title = 'SH1_12 Technological change, innovation, research & development ' WHERE idsettoreerc = '14'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('14','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','14','SH1_12 Technological change, innovation, research & development ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '15')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '15',title = 'SH1_13 Public economics, political economics, law and economics ' WHERE idsettoreerc = '15'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('15','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','15','SH1_13 Public economics, political economics, law and economics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '16')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '16',title = 'SH1_14 History of economic thought, quantitative economic history, institutional economics, economic systems ' WHERE idsettoreerc = '16'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('16','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','16','SH1_14 History of economic thought, quantitative economic history, institutional economics, economic systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '17')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '17',title = 'SH2 The Social World, Diversity, Institutions and Values: Sociology, political science, law, communication, education ' WHERE idsettoreerc = '17'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('17','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','17','SH2 The Social World, Diversity, Institutions and Values: Sociology, political science, law, communication, education ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '18')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '18',title = 'SH2_1 Social structure, social mobility ' WHERE idsettoreerc = '18'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('18','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','18','SH2_1 Social structure, social mobility ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '19')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '19',title = 'SH2_2 Social inequalities, social exclusion, social integration ' WHERE idsettoreerc = '19'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('19','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','19','SH2_2 Social inequalities, social exclusion, social integration ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '20')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '20',title = 'SH2_3 Diversity and identities, gender, interethnic relations ' WHERE idsettoreerc = '20'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('20','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','20','SH2_3 Diversity and identities, gender, interethnic relations ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '21')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '21',title = 'SH2_4 Social policies, educational policies, welfare ' WHERE idsettoreerc = '21'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('21','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','21','SH2_4 Social policies, educational policies, welfare ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '22')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '22',title = 'SH2_5 Democratisation, social movements ' WHERE idsettoreerc = '22'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('22','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','22','SH2_5 Democratisation, social movements ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '23')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '23',title = 'SH2_6 Political systems, governance ' WHERE idsettoreerc = '23'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('23','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','23','SH2_6 Political systems, governance ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '24')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '24',title = 'SH2_7 Conflict and conflict resolution, violence ' WHERE idsettoreerc = '24'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('24','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','24','SH2_7 Conflict and conflict resolution, violence ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '25')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '25',title = 'SH2_8 Legal studies, constitutions, comparative law ' WHERE idsettoreerc = '25'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('25','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','25','SH2_8 Legal studies, constitutions, comparative law ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '26')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '26',title = 'SH2_9 Human rights ' WHERE idsettoreerc = '26'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('26','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','26','SH2_9 Human rights ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '27')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '27',title = 'SH2_10 International relations, global and transnational governance ' WHERE idsettoreerc = '27'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('27','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','27','SH2_10 International relations, global and transnational governance ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '28')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '28',title = 'SH2_11 Communication and information, networks, media ' WHERE idsettoreerc = '28'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('28','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','28','SH2_11 Communication and information, networks, media ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '29')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '29',title = 'SH3 Environment, Space and Population: Sustainability science, demography, geography, regional studies and planning, science and technology studies ' WHERE idsettoreerc = '29'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('29','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','29','SH3 Environment, Space and Population: Sustainability science, demography, geography, regional studies and planning, science and technology studies ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '30')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '30',title = 'SH3_1 Sustainability sciences, environment and resources ' WHERE idsettoreerc = '30'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('30','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','30','SH3_1 Sustainability sciences, environment and resources ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '31')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '31',title = 'SH3_2 Environmental and climate change, societal impact ' WHERE idsettoreerc = '31'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('31','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','31','SH3_2 Environmental and climate change, societal impact ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '32')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '32',title = 'SH3_3 Environmental and climate policy ' WHERE idsettoreerc = '32'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('32','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','32','SH3_3 Environmental and climate policy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '33')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '33',title = 'SH3_4 Population dynamics, households, family and fertility ' WHERE idsettoreerc = '33'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('33','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','33','SH3_4 Population dynamics, households, family and fertility ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '34')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '34',title = 'SH3_5 Health, ageing and society ' WHERE idsettoreerc = '34'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('34','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','34','SH3_5 Health, ageing and society ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '35')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '35',title = 'SH3_6 Transportation and logistics, tourism ' WHERE idsettoreerc = '35'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('35','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','35','SH3_6 Transportation and logistics, tourism ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '36')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '36',title = 'SH3_7 Spatial development, land use, regional planning ' WHERE idsettoreerc = '36'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('36','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','36','SH3_7 Spatial development, land use, regional planning ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '37')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '37',title = 'SH3_8 Urban, regional and rural studies ' WHERE idsettoreerc = '37'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('37','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','37','SH3_8 Urban, regional and rural studies ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '38')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '38',title = 'SH3_9 Human, social and economic geography ' WHERE idsettoreerc = '38'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('38','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','38','SH3_9 Human, social and economic geography ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '39')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '39',title = 'SH3_10 Geographic information systems, spatial data analysis ' WHERE idsettoreerc = '39'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('39','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','39','SH3_10 Geographic information systems, spatial data analysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '40')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '40',title = 'SH3_11 Social studies of science and technology ' WHERE idsettoreerc = '40'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('40','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','40','SH3_11 Social studies of science and technology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '41')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '41',title = 'SH4 The Human Mind and Its Complexity: Cognitive science, psychology, linguistics, philosophy of mind, education ' WHERE idsettoreerc = '41'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('41','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','41','SH4 The Human Mind and Its Complexity: Cognitive science, psychology, linguistics, philosophy of mind, education ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '42')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '42',title = 'SH4_1 Human development and its disorders, comparative cognition ' WHERE idsettoreerc = '42'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('42','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','42','SH4_1 Human development and its disorders, comparative cognition ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '43')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '43',title = 'SH4_2 Personality and social cognition, emotion ' WHERE idsettoreerc = '43'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('43','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','43','SH4_2 Personality and social cognition, emotion ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '44')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '44',title = 'SH4_3 Clinical and health psychology ' WHERE idsettoreerc = '44'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('44','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','44','SH4_3 Clinical and health psychology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '45')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '45',title = 'SH4_4 Neuropsychology ' WHERE idsettoreerc = '45'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('45','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','45','SH4_4 Neuropsychology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '46')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '46',title = 'SH4_5 Attention, perception, action, consciousness ' WHERE idsettoreerc = '46'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('46','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','46','SH4_5 Attention, perception, action, consciousness ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '47')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '47',title = 'SH4_6 Learning, memory, ageing ' WHERE idsettoreerc = '47'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('47','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','47','SH4_6 Learning, memory, ageing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '48')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '48',title = 'SH4_7 Reasoning, decision-making, intelligence ' WHERE idsettoreerc = '48'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('48','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','48','SH4_7 Reasoning, decision-making, intelligence ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '49')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '49',title = 'SH4_8 Language learning and processing (first and second languages) ' WHERE idsettoreerc = '49'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('49','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','49','SH4_8 Language learning and processing (first and second languages) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '50')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '50',title = 'SH4_9 Theoretical linguistics, computational linguistics ' WHERE idsettoreerc = '50'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('50','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','50','SH4_9 Theoretical linguistics, computational linguistics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '51')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '51',title = 'SH4_10 Language typology ' WHERE idsettoreerc = '51'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('51','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','51','SH4_10 Language typology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '52')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '52',title = 'SH4_11 Pragmatics, sociolinguistics, discourse analysis ' WHERE idsettoreerc = '52'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('52','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','52','SH4_11 Pragmatics, sociolinguistics, discourse analysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '53')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '53',title = 'SH4_12 Philosophy of mind, philosophy of language ' WHERE idsettoreerc = '53'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('53','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','53','SH4_12 Philosophy of mind, philosophy of language ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '54')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '54',title = 'SH4_13 Philosophy of science, epistemology and logic ' WHERE idsettoreerc = '54'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('54','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','54','SH4_13 Philosophy of science, epistemology and logic ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '55')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '55',title = 'SH4_14 Teaching and learning ' WHERE idsettoreerc = '55'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('55','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','55','SH4_14 Teaching and learning ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '56')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '56',title = 'SH5 Cultures and Cultural Production: Literature, philology, cultural studies, anthropology, arts, philosophy ' WHERE idsettoreerc = '56'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('56','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','56','SH5 Cultures and Cultural Production: Literature, philology, cultural studies, anthropology, arts, philosophy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '57')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '57',title = 'SH5_1 Classics, ancient literature and art ' WHERE idsettoreerc = '57'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('57','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','57','SH5_1 Classics, ancient literature and art ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '58')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '58',title = 'SH5_2 Theory and history of literature, comparative literature ' WHERE idsettoreerc = '58'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('58','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','58','SH5_2 Theory and history of literature, comparative literature ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '59')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '59',title = 'SH5_3 Philology and palaeography, historical linguistics ' WHERE idsettoreerc = '59'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('59','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','59','SH5_3 Philology and palaeography, historical linguistics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '60')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '60',title = 'SH5_4 Visual and performing arts, design, arts-based research ' WHERE idsettoreerc = '60'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('60','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','60','SH5_4 Visual and performing arts, design, arts-based research ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '61')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '61',title = 'SH5_5 Music and musicology, history of music ' WHERE idsettoreerc = '61'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('61','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','61','SH5_5 Music and musicology, history of music ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '62')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '62',title = 'SH5_6 History of art and architecture ' WHERE idsettoreerc = '62'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('62','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','62','SH5_6 History of art and architecture ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '63')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '63',title = 'SH5_7 Museums, exhibitions, conservation and restoration ' WHERE idsettoreerc = '63'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('63','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','63','SH5_7 Museums, exhibitions, conservation and restoration ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '64')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '64',title = 'SH5_8 Cultural studies, symbolic representation, religious studies ' WHERE idsettoreerc = '64'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('64','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','64','SH5_8 Cultural studies, symbolic representation, religious studies ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '65')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '65',title = 'SH5_9 Social anthropology, myth, ritual, kinship ' WHERE idsettoreerc = '65'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('65','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','65','SH5_9 Social anthropology, myth, ritual, kinship ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '66')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '66',title = 'SH5_10 Cultural heritage, cultural identities and memories ' WHERE idsettoreerc = '66'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('66','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','66','SH5_10 Cultural heritage, cultural identities and memories ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '67')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '67',title = 'SH5_11 Metaphysics, philosophical anthropology, aesthetics ' WHERE idsettoreerc = '67'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('67','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','67','SH5_11 Metaphysics, philosophical anthropology, aesthetics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '68')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '68',title = 'SH5_12 Ethics, social and political philosophy ' WHERE idsettoreerc = '68'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('68','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','68','SH5_12 Ethics, social and political philosophy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '69')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '69',title = 'SH5_13 History of philosophy ' WHERE idsettoreerc = '69'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('69','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','69','SH5_13 History of philosophy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '70')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '70',title = 'SH6 The Study of the Human Past: Archaeology and history ' WHERE idsettoreerc = '70'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('70','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','70','SH6 The Study of the Human Past: Archaeology and history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '71')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '71',title = 'SH6_1 Historiography, theory and methods of history ' WHERE idsettoreerc = '71'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('71','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','71','SH6_1 Historiography, theory and methods of history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '72')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '72',title = 'SH6_2 Archaeology, archaeometry, landscape archaeology ' WHERE idsettoreerc = '72'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('72','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','72','SH6_2 Archaeology, archaeometry, landscape archaeology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '73')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '73',title = 'SH6_3 Prehistory, palaeoanthropology, palaeodemography, protohistory ' WHERE idsettoreerc = '73'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('73','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','73','SH6_3 Prehistory, palaeoanthropology, palaeodemography, protohistory ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '74')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '74',title = 'SH6_4 Ancient history ' WHERE idsettoreerc = '74'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('74','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','74','SH6_4 Ancient history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '75')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '75',title = 'SH6_5 Medieval history ' WHERE idsettoreerc = '75'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('75','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','75','SH6_5 Medieval history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '76')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '76',title = 'SH6_6 Early modern history ' WHERE idsettoreerc = '76'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('76','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','76','SH6_6 Early modern history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '77')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '77',title = 'SH6_7 Modern and contemporary history ' WHERE idsettoreerc = '77'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('77','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','77','SH6_7 Modern and contemporary history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '78')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '78',title = 'SH6_8 Colonial and post-colonial history ' WHERE idsettoreerc = '78'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('78','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','78','SH6_8 Colonial and post-colonial history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '79')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '79',title = 'SH6_9 Global history, transnational history, comparative history, entangled histories ' WHERE idsettoreerc = '79'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('79','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','79','SH6_9 Global history, transnational history, comparative history, entangled histories ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '80')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '80',title = 'SH6_10 Social and economic history ' WHERE idsettoreerc = '80'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('80','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','80','SH6_10 Social and economic history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '81')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '81',title = 'SH6_11 Gender history ' WHERE idsettoreerc = '81'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('81','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','81','SH6_11 Gender history ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '82')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '82',title = 'SH6_12 History of ideas, intellectual history, history of science and techniques ' WHERE idsettoreerc = '82'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('82','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','82','SH6_12 History of ideas, intellectual history, history of science and techniques ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '83')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '83',title = 'SH6_13 Cultural history, history of collective identities and memories ' WHERE idsettoreerc = '83'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('83','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','83','SH6_13 Cultural history, history of collective identities and memories ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '84')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '84',title = 'PE - PHYSICAL SCIENCES AND ENGINEERING ' WHERE idsettoreerc = '84'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('84','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','84','PE - PHYSICAL SCIENCES AND ENGINEERING ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '85')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '85',title = 'PE1 Mathematics: All areas of mathematics, pure and applied, plus mathematical foundations of computer science, mathematical physics and statistics ' WHERE idsettoreerc = '85'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('85','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','85','PE1 Mathematics: All areas of mathematics, pure and applied, plus mathematical foundations of computer science, mathematical physics and statistics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '86')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '86',title = 'PE1_1 Logic and foundations ' WHERE idsettoreerc = '86'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('86','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','86','PE1_1 Logic and foundations ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '87')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '87',title = 'PE1_2 Algebra ' WHERE idsettoreerc = '87'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('87','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','87','PE1_2 Algebra ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '88')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '88',title = 'PE1_3 Number theory ' WHERE idsettoreerc = '88'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('88','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','88','PE1_3 Number theory ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '89')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '89',title = 'PE1_4 Algebraic and complex geometry ' WHERE idsettoreerc = '89'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('89','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','89','PE1_4 Algebraic and complex geometry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '90')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '90',title = 'PE1_5 Geometry ' WHERE idsettoreerc = '90'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('90','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','90','PE1_5 Geometry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '91')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '91',title = 'PE1_6 Topology ' WHERE idsettoreerc = '91'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('91','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','91','PE1_6 Topology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '92')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '92',title = 'PE1_7 Lie groups, Lie algebras ' WHERE idsettoreerc = '92'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('92','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','92','PE1_7 Lie groups, Lie algebras ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '93')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '93',title = 'PE1_8 Analysis ' WHERE idsettoreerc = '93'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('93','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','93','PE1_8 Analysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '94')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '94',title = 'PE1_9 Operator algebras and functional analysis ' WHERE idsettoreerc = '94'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('94','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','94','PE1_9 Operator algebras and functional analysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '95')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '95',title = 'PE1_10 ODE and dynamical systems ' WHERE idsettoreerc = '95'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('95','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','95','PE1_10 ODE and dynamical systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '96')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '96',title = 'PE1_11 Theoretical aspects of partial differential equations ' WHERE idsettoreerc = '96'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('96','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','96','PE1_11 Theoretical aspects of partial differential equations ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '97')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '97',title = 'PE1_12 Mathematical physics ' WHERE idsettoreerc = '97'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('97','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','97','PE1_12 Mathematical physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '98')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '98',title = 'PE1_13 Probability ' WHERE idsettoreerc = '98'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('98','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','98','PE1_13 Probability ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '99')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '99',title = 'PE1_14 Statistics ' WHERE idsettoreerc = '99'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('99','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','99','PE1_14 Statistics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '100')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '100',title = 'PE1_15 Discrete mathematics and combinatorics ' WHERE idsettoreerc = '100'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('100','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','100','PE1_15 Discrete mathematics and combinatorics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '101')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '101',title = 'PE1_16 Mathematical aspects of computer science ' WHERE idsettoreerc = '101'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('101','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','101','PE1_16 Mathematical aspects of computer science ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '102')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '102',title = 'PE1_17 Numerical analysis ' WHERE idsettoreerc = '102'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('102','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','102','PE1_17 Numerical analysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '103')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '103',title = 'PE1_18 Scientific computing and data processing ' WHERE idsettoreerc = '103'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('103','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','103','PE1_18 Scientific computing and data processing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '104')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '104',title = 'PE1_19 Control theory and optimisation ' WHERE idsettoreerc = '104'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('104','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','104','PE1_19 Control theory and optimisation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '105')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '105',title = 'PE1_20 Application of mathematics in sciences ' WHERE idsettoreerc = '105'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('105','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','105','PE1_20 Application of mathematics in sciences ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '106')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '106',title = 'PE1_21 Application of mathematics in industry and society ' WHERE idsettoreerc = '106'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('106','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','106','PE1_21 Application of mathematics in industry and society ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '107')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '107',title = 'PE2 Fundamental Constituents of Matter: Particle, nuclear, plasma, atomic, molecular, gas, and optical physics ' WHERE idsettoreerc = '107'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('107','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','107','PE2 Fundamental Constituents of Matter: Particle, nuclear, plasma, atomic, molecular, gas, and optical physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '108')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '108',title = 'PE2_1 Fundamental interactions and fields ' WHERE idsettoreerc = '108'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('108','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','108','PE2_1 Fundamental interactions and fields ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '109')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '109',title = 'PE2_2 Particle physics ' WHERE idsettoreerc = '109'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('109','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','109','PE2_2 Particle physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '110')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '110',title = 'PE2_3 Nuclear physics ' WHERE idsettoreerc = '110'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('110','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','110','PE2_3 Nuclear physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '111')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '111',title = 'PE2_4 Nuclear astrophysics ' WHERE idsettoreerc = '111'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('111','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','111','PE2_4 Nuclear astrophysics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '112')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '112',title = 'PE2_5 Gas and plasma physics ' WHERE idsettoreerc = '112'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('112','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','112','PE2_5 Gas and plasma physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '113')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '113',title = 'PE2_6 Electromagnetism ' WHERE idsettoreerc = '113'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('113','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','113','PE2_6 Electromagnetism ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '114')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '114',title = 'PE2_7 Atomic, molecular physics ' WHERE idsettoreerc = '114'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('114','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','114','PE2_7 Atomic, molecular physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '115')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '115',title = 'PE2_8 Ultra-cold atoms and molecules ' WHERE idsettoreerc = '115'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('115','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','115','PE2_8 Ultra-cold atoms and molecules ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '116')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '116',title = 'PE2_9 Optics, non-linear optics and nano-optics ' WHERE idsettoreerc = '116'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('116','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','116','PE2_9 Optics, non-linear optics and nano-optics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '117')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '117',title = 'PE2_10 Quantum optics and quantum information ' WHERE idsettoreerc = '117'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('117','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','117','PE2_10 Quantum optics and quantum information ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '118')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '118',title = 'PE2_11 Lasers, ultra-short lasers and laser physics ' WHERE idsettoreerc = '118'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('118','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','118','PE2_11 Lasers, ultra-short lasers and laser physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '119')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '119',title = 'PE2_12 Acoustics ' WHERE idsettoreerc = '119'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('119','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','119','PE2_12 Acoustics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '120')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '120',title = 'PE2_13 Relativity ' WHERE idsettoreerc = '120'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('120','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','120','PE2_13 Relativity ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '121')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '121',title = 'PE2_14 Thermodynamics ' WHERE idsettoreerc = '121'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('121','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','121','PE2_14 Thermodynamics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '122')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '122',title = 'PE2_15 Non-linear physics ' WHERE idsettoreerc = '122'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('122','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','122','PE2_15 Non-linear physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '123')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '123',title = 'PE2_16 General physics ' WHERE idsettoreerc = '123'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('123','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','123','PE2_16 General physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '124')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '124',title = 'PE2_17 Metrology and measurement ' WHERE idsettoreerc = '124'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('124','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','124','PE2_17 Metrology and measurement ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '125')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '125',title = 'PE2_18 Statistical physics (gases) ' WHERE idsettoreerc = '125'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('125','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','125','PE2_18 Statistical physics (gases) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '126')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '126',title = 'PE3 Condensed Matter Physics: Structure, electronic properties, fluids, nanosciences, biophysics ' WHERE idsettoreerc = '126'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('126','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','126','PE3 Condensed Matter Physics: Structure, electronic properties, fluids, nanosciences, biophysics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '127')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '127',title = 'PE3_1 Structure of solids and liquids ' WHERE idsettoreerc = '127'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('127','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','127','PE3_1 Structure of solids and liquids ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '128')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '128',title = 'PE3_2 Mechanical and acoustical properties of condensed matter, Lattice dynamics ' WHERE idsettoreerc = '128'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('128','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','128','PE3_2 Mechanical and acoustical properties of condensed matter, Lattice dynamics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '129')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '129',title = 'PE3_3 Transport properties of condensed matter ' WHERE idsettoreerc = '129'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('129','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','129','PE3_3 Transport properties of condensed matter ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '130')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '130',title = 'PE3_4 Electronic properties of materials, surfaces, interfaces, nanostructures, etc. ' WHERE idsettoreerc = '130'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('130','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','130','PE3_4 Electronic properties of materials, surfaces, interfaces, nanostructures, etc. ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '131')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '131',title = 'PE3_5 Semiconductors and insulators: material growth, physical properties ' WHERE idsettoreerc = '131'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('131','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','131','PE3_5 Semiconductors and insulators: material growth, physical properties ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '132')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '132',title = 'PE3_6 Macroscopic quantum phenomena: superconductivity, superfluidity, etc. ' WHERE idsettoreerc = '132'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('132','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','132','PE3_6 Macroscopic quantum phenomena: superconductivity, superfluidity, etc. ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '133')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '133',title = 'PE3_7 Spintronics ' WHERE idsettoreerc = '133'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('133','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','133','PE3_7 Spintronics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '134')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '134',title = 'PE3_8 Magnetism and strongly correlated systems ' WHERE idsettoreerc = '134'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('134','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','134','PE3_8 Magnetism and strongly correlated systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '135')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '135',title = 'PE3_9 Condensed matter ñ beam interactions (photons, electrons, etc.) ' WHERE idsettoreerc = '135'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('135','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','135','PE3_9 Condensed matter ñ beam interactions (photons, electrons, etc.) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '136')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '136',title = 'PE3_10 Nanophysics: nanoelectronics, nanophotonics, nanomagnetism, nanoelectromechanics, etc. ' WHERE idsettoreerc = '136'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('136','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','136','PE3_10 Nanophysics: nanoelectronics, nanophotonics, nanomagnetism, nanoelectromechanics, etc. ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '137')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '137',title = 'PE3_11 Mesoscopic physics ' WHERE idsettoreerc = '137'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('137','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','137','PE3_11 Mesoscopic physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '138')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '138',title = 'PE3_12 Molecular electronics ' WHERE idsettoreerc = '138'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('138','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','138','PE3_12 Molecular electronics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '139')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '139',title = 'PE3_13 Structure and dynamics of disordered systems: soft matter (gels, colloids, liquid crystals, etc.), glasses, defects, etc. ' WHERE idsettoreerc = '139'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('139','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','139','PE3_13 Structure and dynamics of disordered systems: soft matter (gels, colloids, liquid crystals, etc.), glasses, defects, etc. ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '140')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '140',title = 'PE3_14 Fluid dynamics (physics) ' WHERE idsettoreerc = '140'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('140','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','140','PE3_14 Fluid dynamics (physics) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '141')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '141',title = 'PE3_15 Statistical physics: phase transitions, noise and fluctuations, models of complex systems, etc. ' WHERE idsettoreerc = '141'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('141','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','141','PE3_15 Statistical physics: phase transitions, noise and fluctuations, models of complex systems, etc. ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '142')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '142',title = 'PE3_16 Physics of biological systems ' WHERE idsettoreerc = '142'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('142','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','142','PE3_16 Physics of biological systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '143')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '143',title = 'PE4 Physical and Analytical Chemical Sciences: Analytical chemistry, chemical theory, physical chemistry/chemical physics ' WHERE idsettoreerc = '143'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('143','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','143','PE4 Physical and Analytical Chemical Sciences: Analytical chemistry, chemical theory, physical chemistry/chemical physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '144')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '144',title = 'PE4_1 Physical chemistry ' WHERE idsettoreerc = '144'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('144','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','144','PE4_1 Physical chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '145')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '145',title = 'PE4_2 Spectroscopic and spectrometric techniques ' WHERE idsettoreerc = '145'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('145','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','145','PE4_2 Spectroscopic and spectrometric techniques ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '146')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '146',title = 'PE4_3 Molecular architecture and Structure ' WHERE idsettoreerc = '146'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('146','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','146','PE4_3 Molecular architecture and Structure ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '147')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '147',title = 'PE4_4 Surface science and nanostructures ' WHERE idsettoreerc = '147'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('147','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','147','PE4_4 Surface science and nanostructures ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '148')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '148',title = 'PE4_5 Analytical chemistry ' WHERE idsettoreerc = '148'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('148','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','148','PE4_5 Analytical chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '149')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '149',title = 'PE4_6 Chemical physics ' WHERE idsettoreerc = '149'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('149','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','149','PE4_6 Chemical physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '150')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '150',title = 'PE4_7 Chemical instrumentation ' WHERE idsettoreerc = '150'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('150','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','150','PE4_7 Chemical instrumentation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '151')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '151',title = 'PE4_8 Electrochemistry, electrodialysis, microfluidics, sensors ' WHERE idsettoreerc = '151'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('151','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','151','PE4_8 Electrochemistry, electrodialysis, microfluidics, sensors ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '152')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '152',title = 'PE4_9 Method development in chemistry ' WHERE idsettoreerc = '152'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('152','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','152','PE4_9 Method development in chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '153')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '153',title = 'PE4_10 Heterogeneous catalysis ' WHERE idsettoreerc = '153'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('153','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','153','PE4_10 Heterogeneous catalysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '154')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '154',title = 'PE4_11 Physical chemistry of biological systems ' WHERE idsettoreerc = '154'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('154','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','154','PE4_11 Physical chemistry of biological systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '155')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '155',title = 'PE4_12 Chemical reactions: mechanisms, dynamics, kinetics and catalytic reactions ' WHERE idsettoreerc = '155'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('155','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','155','PE4_12 Chemical reactions: mechanisms, dynamics, kinetics and catalytic reactions ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '156')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '156',title = 'PE4_13 Theoretical and computational chemistry ' WHERE idsettoreerc = '156'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('156','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','156','PE4_13 Theoretical and computational chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '157')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '157',title = 'PE4_14 Radiation and Nuclear chemistry ' WHERE idsettoreerc = '157'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('157','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','157','PE4_14 Radiation and Nuclear chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '158')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '158',title = 'PE4_15 Photochemistry ' WHERE idsettoreerc = '158'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('158','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','158','PE4_15 Photochemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '159')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '159',title = 'PE4_16 Corrosion ' WHERE idsettoreerc = '159'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('159','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','159','PE4_16 Corrosion ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '160')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '160',title = 'PE4_17 Characterisation methods of materials ' WHERE idsettoreerc = '160'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('160','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','160','PE4_17 Characterisation methods of materials ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '161')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '161',title = 'PE4_18 Environment chemistry ' WHERE idsettoreerc = '161'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('161','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','161','PE4_18 Environment chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '162')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '162',title = 'PE5 Synthetic Chemistry and Materials: Materials synthesis, structureproperties relations, functional and advanced materials, molecular architecture, organic chemistry ' WHERE idsettoreerc = '162'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('162','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','162','PE5 Synthetic Chemistry and Materials: Materials synthesis, structureproperties relations, functional and advanced materials, molecular architecture, organic chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '163')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '163',title = 'PE5_1 Structural properties of materials ' WHERE idsettoreerc = '163'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('163','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','163','PE5_1 Structural properties of materials ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '164')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '164',title = 'PE5_2 Solid state materials ' WHERE idsettoreerc = '164'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('164','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','164','PE5_2 Solid state materials ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '165')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '165',title = 'PE5_3 Surface modification ' WHERE idsettoreerc = '165'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('165','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','165','PE5_3 Surface modification ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '166')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '166',title = 'PE5_4 Thin films ' WHERE idsettoreerc = '166'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('166','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','166','PE5_4 Thin films ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '167')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '167',title = 'PE5_5 Ionic liquids ' WHERE idsettoreerc = '167'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('167','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','167','PE5_5 Ionic liquids ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '168')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '168',title = 'PE5_6 New materials: oxides, alloys, composite, organic-inorganic hybrid, nanoparticles ' WHERE idsettoreerc = '168'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('168','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','168','PE5_6 New materials: oxides, alloys, composite, organic-inorganic hybrid, nanoparticles ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '169')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '169',title = 'PE5_7 Biomaterials, biomaterials synthesis ' WHERE idsettoreerc = '169'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('169','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','169','PE5_7 Biomaterials, biomaterials synthesis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '170')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '170',title = 'PE5_8 Intelligent materials ñ self assembled materials ' WHERE idsettoreerc = '170'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('170','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','170','PE5_8 Intelligent materials ñ self assembled materials ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '171')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '171',title = 'PE5_9 Coordination chemistry ' WHERE idsettoreerc = '171'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('171','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','171','PE5_9 Coordination chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '172')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '172',title = 'PE5_10 Colloid chemistry ' WHERE idsettoreerc = '172'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('172','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','172','PE5_10 Colloid chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '173')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '173',title = 'PE5_11 Biological chemistry ' WHERE idsettoreerc = '173'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('173','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','173','PE5_11 Biological chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '174')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '174',title = 'PE5_12 Chemistry of condensed matter ' WHERE idsettoreerc = '174'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('174','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','174','PE5_12 Chemistry of condensed matter ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '175')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '175',title = 'PE5_13 Homogeneous catalysis ' WHERE idsettoreerc = '175'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('175','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','175','PE5_13 Homogeneous catalysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '176')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '176',title = 'PE5_14 Macromolecular chemistry ' WHERE idsettoreerc = '176'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('176','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','176','PE5_14 Macromolecular chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '177')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '177',title = 'PE5_15 Polymer chemistry ' WHERE idsettoreerc = '177'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('177','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','177','PE5_15 Polymer chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '178')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '178',title = 'PE5_16 Supramolecular chemistry ' WHERE idsettoreerc = '178'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('178','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','178','PE5_16 Supramolecular chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '179')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '179',title = 'PE5_17 Organic chemistry ' WHERE idsettoreerc = '179'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('179','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','179','PE5_17 Organic chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '180')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '180',title = 'PE5_18 Molecular chemistry ' WHERE idsettoreerc = '180'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('180','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','180','PE5_18 Molecular chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '181')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '181',title = 'PE5_19 Combinatorial chemistry ' WHERE idsettoreerc = '181'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('181','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','181','PE5_19 Combinatorial chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '182')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '182',title = 'PE6 Computer Science and Informatics: Informatics and information systems, computer science, scientific computing, intelligent systems ' WHERE idsettoreerc = '182'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('182','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','182','PE6 Computer Science and Informatics: Informatics and information systems, computer science, scientific computing, intelligent systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '183')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '183',title = 'PE6_1 Computer architecture, pervasive computing, ubiquitous computing ' WHERE idsettoreerc = '183'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('183','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','183','PE6_1 Computer architecture, pervasive computing, ubiquitous computing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '184')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '184',title = 'PE6_2 Computer systems, parallel/distributed systems, sensor networks, embedded systems, cyber-physical systems ' WHERE idsettoreerc = '184'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('184','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','184','PE6_2 Computer systems, parallel/distributed systems, sensor networks, embedded systems, cyber-physical systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '185')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '185',title = 'PE6_3 Software engineering, operating systems, computer languages ' WHERE idsettoreerc = '185'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('185','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','185','PE6_3 Software engineering, operating systems, computer languages ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '186')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '186',title = 'PE6_4 Theoretical computer science, formal methods, and quantum computing ' WHERE idsettoreerc = '186'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('186','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','186','PE6_4 Theoretical computer science, formal methods, and quantum computing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '187')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '187',title = 'PE6_5 Cryptology, security, privacy, quantum crypto ' WHERE idsettoreerc = '187'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('187','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','187','PE6_5 Cryptology, security, privacy, quantum crypto ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '188')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '188',title = 'PE6_6 Algorithms, distributed, parallel and network algorithms, algorithmic game theory ' WHERE idsettoreerc = '188'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('188','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','188','PE6_6 Algorithms, distributed, parallel and network algorithms, algorithmic game theory ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '189')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '189',title = 'PE6_7 Artificial intelligence, intelligent systems, multi agent systems ' WHERE idsettoreerc = '189'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('189','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','189','PE6_7 Artificial intelligence, intelligent systems, multi agent systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '190')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '190',title = 'PE6_8 Computer graphics, computer vision, multi media, computer games ' WHERE idsettoreerc = '190'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('190','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','190','PE6_8 Computer graphics, computer vision, multi media, computer games ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '191')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '191',title = 'PE6_9 Human computer interaction and interface, visualisation and natural language processing ' WHERE idsettoreerc = '191'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('191','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','191','PE6_9 Human computer interaction and interface, visualisation and natural language processing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '192')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '192',title = 'PE6_10 Web and information systems, database systems, information retrieval and digital libraries, data fusion ' WHERE idsettoreerc = '192'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('192','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','192','PE6_10 Web and information systems, database systems, information retrieval and digital libraries, data fusion ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '193')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '193',title = 'PE6_11 Machine learning, statistical data processing and applications using signal processing (e.g. speech, image, video) ' WHERE idsettoreerc = '193'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('193','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','193','PE6_11 Machine learning, statistical data processing and applications using signal processing (e.g. speech, image, video) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '194')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '194',title = 'PE6_12 Scientific computing, simulation and modelling tools ' WHERE idsettoreerc = '194'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('194','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','194','PE6_12 Scientific computing, simulation and modelling tools ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '195')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '195',title = 'PE6_13 Bioinformatics, biocomputing, and DNA and molecular computation ' WHERE idsettoreerc = '195'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('195','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','195','PE6_13 Bioinformatics, biocomputing, and DNA and molecular computation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '196')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '196',title = 'PE7 Systems and Communication Engineering: Electrical, electronic, communication, optical and systems engineering ' WHERE idsettoreerc = '196'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('196','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','196','PE7 Systems and Communication Engineering: Electrical, electronic, communication, optical and systems engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '197')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '197',title = 'PE7_1 Control engineering ' WHERE idsettoreerc = '197'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('197','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','197','PE7_1 Control engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '198')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '198',title = 'PE7_2 Electrical engineering: power components and/or systems ' WHERE idsettoreerc = '198'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('198','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','198','PE7_2 Electrical engineering: power components and/or systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '199')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '199',title = 'PE7_3 Simulation engineering and modelling ' WHERE idsettoreerc = '199'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('199','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','199','PE7_3 Simulation engineering and modelling ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '200')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '200',title = 'PE7_4 (Micro and nano) systems engineering ' WHERE idsettoreerc = '200'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('200','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','200','PE7_4 (Micro and nano) systems engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '201')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '201',title = 'PE7_5 (Micro and nano) electronic, optoelectronic and photonic components ' WHERE idsettoreerc = '201'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('201','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','201','PE7_5 (Micro and nano) electronic, optoelectronic and photonic components ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '202')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '202',title = 'PE7_6 Communication technology, high-frequency technology ' WHERE idsettoreerc = '202'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('202','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','202','PE7_6 Communication technology, high-frequency technology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '203')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '203',title = 'PE7_7 Signal processing ' WHERE idsettoreerc = '203'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('203','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','203','PE7_7 Signal processing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '204')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '204',title = 'PE7_8 Networks (communication networks, sensor networks, networks of robots, etc.) ' WHERE idsettoreerc = '204'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('204','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','204','PE7_8 Networks (communication networks, sensor networks, networks of robots, etc.) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '205')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '205',title = 'PE7_9 Man-machine-interfaces ' WHERE idsettoreerc = '205'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('205','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','205','PE7_9 Man-machine-interfaces ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '206')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '206',title = 'PE7_10 Robotics ' WHERE idsettoreerc = '206'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('206','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','206','PE7_10 Robotics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '207')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '207',title = 'PE7_11 Components and systems for applications (in e.g. medicine, biology, environment) ' WHERE idsettoreerc = '207'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('207','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','207','PE7_11 Components and systems for applications (in e.g. medicine, biology, environment) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '208')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '208',title = 'PE7_12 Electrical energy production, distribution, application ' WHERE idsettoreerc = '208'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('208','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','208','PE7_12 Electrical energy production, distribution, application ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '209')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '209',title = 'PE8 Products and Processes Engineering: Product design, process design and control, construction methods, civil engineering, energy processes, material engineering ' WHERE idsettoreerc = '209'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('209','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','209','PE8 Products and Processes Engineering: Product design, process design and control, construction methods, civil engineering, energy processes, material engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '210')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '210',title = 'PE8_1 Aerospace engineering ' WHERE idsettoreerc = '210'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('210','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','210','PE8_1 Aerospace engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '211')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '211',title = 'PE8_2 Chemical engineering, technical chemistry ' WHERE idsettoreerc = '211'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('211','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','211','PE8_2 Chemical engineering, technical chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '212')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '212',title = 'PE8_3 Civil engineering, architecture, maritime/hydraulic engineering, geotechnics, waste treatment ' WHERE idsettoreerc = '212'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('212','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','212','PE8_3 Civil engineering, architecture, maritime/hydraulic engineering, geotechnics, waste treatment ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '213')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '213',title = 'PE8_4 Computational engineering ' WHERE idsettoreerc = '213'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('213','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','213','PE8_4 Computational engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '214')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '214',title = 'PE8_5 Fluid mechanics, hydraulic-, turbo-, and piston engines ' WHERE idsettoreerc = '214'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('214','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','214','PE8_5 Fluid mechanics, hydraulic-, turbo-, and piston engines ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '215')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '215',title = 'PE8_6 Energy processes engineering ' WHERE idsettoreerc = '215'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('215','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','215','PE8_6 Energy processes engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '216')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '216',title = 'PE8_7 Mechanical and manufacturing engineering (shaping, mounting, joining, separation) ' WHERE idsettoreerc = '216'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('216','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','216','PE8_7 Mechanical and manufacturing engineering (shaping, mounting, joining, separation) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '217')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '217',title = 'PE8_8 Materials engineering (metals, ceramics, polymers, composites, etc.) ' WHERE idsettoreerc = '217'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('217','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','217','PE8_8 Materials engineering (metals, ceramics, polymers, composites, etc.) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '218')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '218',title = 'PE8_9 Production technology, process engineering ' WHERE idsettoreerc = '218'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('218','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','218','PE8_9 Production technology, process engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '219')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '219',title = 'PE8_10 Industrial design (product design, ergonomics, man-machine interfaces, etc.) ' WHERE idsettoreerc = '219'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('219','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','219','PE8_10 Industrial design (product design, ergonomics, man-machine interfaces, etc.) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '220')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '220',title = 'PE8_11 Sustainable design (for recycling, for environment, eco-design) ' WHERE idsettoreerc = '220'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('220','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','220','PE8_11 Sustainable design (for recycling, for environment, eco-design) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '221')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '221',title = 'PE8_12 Lightweight construction, textile technology ' WHERE idsettoreerc = '221'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('221','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','221','PE8_12 Lightweight construction, textile technology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '222')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '222',title = 'PE8_13 Industrial bioengineering ' WHERE idsettoreerc = '222'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('222','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','222','PE8_13 Industrial bioengineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '223')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '223',title = 'PE9 Universe Sciences: Astro-physics/chemistry/biology, solar system, stellar, galactic and extragalactic astronomy, planetary systems, cosmology, space science, instrumentation ' WHERE idsettoreerc = '223'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('223','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','223','PE9 Universe Sciences: Astro-physics/chemistry/biology, solar system, stellar, galactic and extragalactic astronomy, planetary systems, cosmology, space science, instrumentation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '224')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '224',title = 'PE9_1 Solar and interplanetary physics ' WHERE idsettoreerc = '224'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('224','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','224','PE9_1 Solar and interplanetary physics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '225')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '225',title = 'PE9_2 Planetary systems sciences ' WHERE idsettoreerc = '225'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('225','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','225','PE9_2 Planetary systems sciences ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '226')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '226',title = 'PE9_3 Interstellar medium ' WHERE idsettoreerc = '226'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('226','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','226','PE9_3 Interstellar medium ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '227')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '227',title = 'PE9_4 Formation of stars and planets ' WHERE idsettoreerc = '227'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('227','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','227','PE9_4 Formation of stars and planets ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '228')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '228',title = 'PE9_5 Astrobiology ' WHERE idsettoreerc = '228'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('228','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','228','PE9_5 Astrobiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '229')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '229',title = 'PE9_6 Stars and stellar systems ' WHERE idsettoreerc = '229'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('229','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','229','PE9_6 Stars and stellar systems ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '230')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '230',title = 'PE9_7 The Galaxy ' WHERE idsettoreerc = '230'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('230','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','230','PE9_7 The Galaxy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '231')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '231',title = 'PE9_8 Formation and evolution of galaxies ' WHERE idsettoreerc = '231'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('231','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','231','PE9_8 Formation and evolution of galaxies ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '232')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '232',title = 'PE9_9 Clusters of galaxies and large scale structures ' WHERE idsettoreerc = '232'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('232','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','232','PE9_9 Clusters of galaxies and large scale structures ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '233')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '233',title = 'PE9_10 High energy and particles astronomy ñ X-rays, cosmic rays, gamma rays, neutrinos ' WHERE idsettoreerc = '233'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('233','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','233','PE9_10 High energy and particles astronomy ñ X-rays, cosmic rays, gamma rays, neutrinos ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '234')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '234',title = 'PE9_11 Relativistic astrophysics ' WHERE idsettoreerc = '234'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('234','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','234','PE9_11 Relativistic astrophysics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '235')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '235',title = 'PE9_12 Dark matter, dark energy ' WHERE idsettoreerc = '235'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('235','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','235','PE9_12 Dark matter, dark energy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '236')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '236',title = 'PE9_13 Gravitational astronomy ' WHERE idsettoreerc = '236'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('236','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','236','PE9_13 Gravitational astronomy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '237')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '237',title = 'PE9_14 Cosmology ' WHERE idsettoreerc = '237'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('237','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','237','PE9_14 Cosmology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '238')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '238',title = 'PE9_15 Space Sciences ' WHERE idsettoreerc = '238'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('238','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','238','PE9_15 Space Sciences ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '239')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '239',title = 'PE9_16 Very large data bases: archiving, handling and analysis ' WHERE idsettoreerc = '239'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('239','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','239','PE9_16 Very large data bases: archiving, handling and analysis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '240')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '240',title = 'PE9_17 Instrumentation - telescopes, detectors and techniques ' WHERE idsettoreerc = '240'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('240','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','240','PE9_17 Instrumentation - telescopes, detectors and techniques ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '241')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '241',title = 'PE10 Earth System Science: Physical geography, geology, geophysics, atmospheric sciences, oceanography, climatology, cryology, ecology, global environmental change, biogeochemical cycles, natural resources management ' WHERE idsettoreerc = '241'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('241','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','241','PE10 Earth System Science: Physical geography, geology, geophysics, atmospheric sciences, oceanography, climatology, cryology, ecology, global environmental change, biogeochemical cycles, natural resources management ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '242')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '242',title = 'PE10_1 Atmospheric chemistry, atmospheric composition, air pollution ' WHERE idsettoreerc = '242'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('242','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','242','PE10_1 Atmospheric chemistry, atmospheric composition, air pollution ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '243')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '243',title = 'PE10_2 Meteorology, atmospheric physics and dynamics ' WHERE idsettoreerc = '243'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('243','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','243','PE10_2 Meteorology, atmospheric physics and dynamics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '244')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '244',title = 'PE10_3 Climatology and climate change ' WHERE idsettoreerc = '244'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('244','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','244','PE10_3 Climatology and climate change ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '245')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '245',title = 'PE10_4 Terrestrial ecology, land cover change ' WHERE idsettoreerc = '245'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('245','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','245','PE10_4 Terrestrial ecology, land cover change ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '246')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '246',title = 'PE10_5 Geology, tectonics, volcanology ' WHERE idsettoreerc = '246'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('246','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','246','PE10_5 Geology, tectonics, volcanology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '247')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '247',title = 'PE10_6 Palaeoclimatology, palaeoecology ' WHERE idsettoreerc = '247'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('247','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','247','PE10_6 Palaeoclimatology, palaeoecology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '248')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '248',title = 'PE10_7 Physics of earthís interior, seismology, volcanology ' WHERE idsettoreerc = '248'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('248','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','248','PE10_7 Physics of earthís interior, seismology, volcanology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '249')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '249',title = 'PE10_8 Oceanography (physical, chemical, biological, geological) ' WHERE idsettoreerc = '249'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('249','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','249','PE10_8 Oceanography (physical, chemical, biological, geological) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '250')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '250',title = 'PE10_9 Biogeochemistry, biogeochemical cycles, environmental chemistry ' WHERE idsettoreerc = '250'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('250','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','250','PE10_9 Biogeochemistry, biogeochemical cycles, environmental chemistry ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '251')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '251',title = 'PE10_10 Mineralogy, petrology, igneous petrology, metamorphic petrology ' WHERE idsettoreerc = '251'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('251','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','251','PE10_10 Mineralogy, petrology, igneous petrology, metamorphic petrology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '252')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '252',title = 'PE10_11 Geochemistry, crystal chemistry, isotope geochemistry, thermodynamics ' WHERE idsettoreerc = '252'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('252','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','252','PE10_11 Geochemistry, crystal chemistry, isotope geochemistry, thermodynamics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '253')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '253',title = 'PE10_12 Sedimentology, soil science, palaeontology, earth evolution ' WHERE idsettoreerc = '253'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('253','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','253','PE10_12 Sedimentology, soil science, palaeontology, earth evolution ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '254')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '254',title = 'PE10_13 Physical geography ' WHERE idsettoreerc = '254'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('254','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','254','PE10_13 Physical geography ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '255')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '255',title = 'PE10_14 Earth observations from space/remote sensing ' WHERE idsettoreerc = '255'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('255','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','255','PE10_14 Earth observations from space/remote sensing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '256')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '256',title = 'PE10_15 Geomagnetism, palaeomagnetism ' WHERE idsettoreerc = '256'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('256','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','256','PE10_15 Geomagnetism, palaeomagnetism ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '257')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '257',title = 'PE10_16 Ozone, upper atmosphere, ionosphere ' WHERE idsettoreerc = '257'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('257','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','257','PE10_16 Ozone, upper atmosphere, ionosphere ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '258')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '258',title = 'PE10_17 Hydrology, water and soil pollution ' WHERE idsettoreerc = '258'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('258','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','258','PE10_17 Hydrology, water and soil pollution ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '259')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '259',title = 'PE10_18 Cryosphere, dynamics of snow and ice cover, sea ice, permafrosts and ice sheets ' WHERE idsettoreerc = '259'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('259','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','259','PE10_18 Cryosphere, dynamics of snow and ice cover, sea ice, permafrosts and ice sheets ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '260')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '260',title = 'LS - LIFE SCIENCES ' WHERE idsettoreerc = '260'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('260','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','260','LS - LIFE SCIENCES ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '261')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '261',title = 'LS1 Molecular and Structural Biology and Biochemistry: Molecular synthesis, modification and interaction, biochemistry, biophysics, structural biology, metabolism, signal transduction ' WHERE idsettoreerc = '261'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('261','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','261','LS1 Molecular and Structural Biology and Biochemistry: Molecular synthesis, modification and interaction, biochemistry, biophysics, structural biology, metabolism, signal transduction ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '262')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '262',title = 'LS1_1 Molecular interactions ' WHERE idsettoreerc = '262'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('262','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','262','LS1_1 Molecular interactions ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '263')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '263',title = 'LS1_2 General biochemistry and metabolism ' WHERE idsettoreerc = '263'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('263','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','263','LS1_2 General biochemistry and metabolism ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '264')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '264',title = 'LS1_3 DNA synthesis, modification, repair, recombination and degradation ' WHERE idsettoreerc = '264'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('264','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','264','LS1_3 DNA synthesis, modification, repair, recombination and degradation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '265')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '265',title = 'LS1_4 RNA synthesis, processing, modification and degradation ' WHERE idsettoreerc = '265'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('265','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','265','LS1_4 RNA synthesis, processing, modification and degradation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '266')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '266',title = 'LS1_5 Protein synthesis, modification and turnover ' WHERE idsettoreerc = '266'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('266','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','266','LS1_5 Protein synthesis, modification and turnover ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '267')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '267',title = 'LS1_6 Lipid synthesis, modification and turnover ' WHERE idsettoreerc = '267'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('267','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','267','LS1_6 Lipid synthesis, modification and turnover ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '268')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '268',title = 'LS1_7 Carbohydrate synthesis, modification and turnover ' WHERE idsettoreerc = '268'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('268','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','268','LS1_7 Carbohydrate synthesis, modification and turnover ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '269')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '269',title = 'LS1_8 Biophysics (e.g. transport mechanisms, bioenergetics, fluorescence) ' WHERE idsettoreerc = '269'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('269','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','269','LS1_8 Biophysics (e.g. transport mechanisms, bioenergetics, fluorescence) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '270')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '270',title = 'LS1_9 Structural biology (crystallography and EM) ' WHERE idsettoreerc = '270'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('270','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','270','LS1_9 Structural biology (crystallography and EM) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '271')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '271',title = 'LS1_10 Structural biology (NMR) ' WHERE idsettoreerc = '271'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('271','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','271','LS1_10 Structural biology (NMR) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '272')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '272',title = 'LS1_11 Biochemistry and molecular mechanisms of signal transduction ' WHERE idsettoreerc = '272'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('272','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','272','LS1_11 Biochemistry and molecular mechanisms of signal transduction ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '273')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '273',title = 'LS2 Genetics, Genomics, Bioinformatics and Systems Biology: Molecular and population genetics, genomics, transcriptomics, proteomics, metabolomics, bioinformatics, computational biology, biostatistics, biological modelling and simulation, systems biology, genetic epidemiology ' WHERE idsettoreerc = '273'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('273','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','273','LS2 Genetics, Genomics, Bioinformatics and Systems Biology: Molecular and population genetics, genomics, transcriptomics, proteomics, metabolomics, bioinformatics, computational biology, biostatistics, biological modelling and simulation, systems biology, genetic epidemiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '274')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '274',title = 'LS2_1 Genomics, comparative genomics, functional genomics ' WHERE idsettoreerc = '274'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('274','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','274','LS2_1 Genomics, comparative genomics, functional genomics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '275')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '275',title = 'LS2_2 Transcriptomics ' WHERE idsettoreerc = '275'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('275','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','275','LS2_2 Transcriptomics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '276')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '276',title = 'LS2_3 Proteomics ' WHERE idsettoreerc = '276'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('276','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','276','LS2_3 Proteomics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '277')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '277',title = 'LS2_4 Metabolomics ' WHERE idsettoreerc = '277'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('277','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','277','LS2_4 Metabolomics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '278')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '278',title = 'LS2_5 Glycomics ' WHERE idsettoreerc = '278'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('278','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','278','LS2_5 Glycomics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '279')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '279',title = 'LS2_6 Molecular genetics, reverse genetics and RNAi ' WHERE idsettoreerc = '279'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('279','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','279','LS2_6 Molecular genetics, reverse genetics and RNAi ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '280')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '280',title = 'LS2_7 Quantitative genetics ' WHERE idsettoreerc = '280'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('280','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','280','LS2_7 Quantitative genetics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '281')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '281',title = 'LS2_8 Epigenetics and gene regulation ' WHERE idsettoreerc = '281'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('281','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','281','LS2_8 Epigenetics and gene regulation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '282')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '282',title = 'LS2_9 Genetic epidemiology ' WHERE idsettoreerc = '282'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('282','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','282','LS2_9 Genetic epidemiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '283')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '283',title = 'LS2_10 Bioinformatics ' WHERE idsettoreerc = '283'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('283','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','283','LS2_10 Bioinformatics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '284')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '284',title = 'LS2_11 Computational biology ' WHERE idsettoreerc = '284'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('284','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','284','LS2_11 Computational biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '285')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '285',title = 'LS2_12 Biostatistics ' WHERE idsettoreerc = '285'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('285','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','285','LS2_12 Biostatistics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '286')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '286',title = 'LS2_13 Systems biology ' WHERE idsettoreerc = '286'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('286','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','286','LS2_13 Systems biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '287')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '287',title = 'LS2_14 Biological systems analysis, modelling and simulation ' WHERE idsettoreerc = '287'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('287','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','287','LS2_14 Biological systems analysis, modelling and simulation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '288')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '288',title = 'LS3 Cellular and Developmental Biology: Cell biology, cell physiology, signal transduction, organogenesis, developmental genetics, pattern formation in plants and animals, stem cell biology ' WHERE idsettoreerc = '288'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('288','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','288','LS3 Cellular and Developmental Biology: Cell biology, cell physiology, signal transduction, organogenesis, developmental genetics, pattern formation in plants and animals, stem cell biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '289')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '289',title = 'LS3_1 Morphology and functional imaging of cells ' WHERE idsettoreerc = '289'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('289','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','289','LS3_1 Morphology and functional imaging of cells ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '290')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '290',title = 'LS3_2 Cell biology and molecular transport mechanisms ' WHERE idsettoreerc = '290'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('290','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','290','LS3_2 Cell biology and molecular transport mechanisms ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '291')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '291',title = 'LS3_3 Cell cycle and division ' WHERE idsettoreerc = '291'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('291','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','291','LS3_3 Cell cycle and division ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '292')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '292',title = 'LS3_4 Apoptosis ' WHERE idsettoreerc = '292'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('292','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','292','LS3_4 Apoptosis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '293')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '293',title = 'LS3_5 Cell differentiation, physiology and dynamics ' WHERE idsettoreerc = '293'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('293','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','293','LS3_5 Cell differentiation, physiology and dynamics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '294')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '294',title = 'LS3_6 Organelle biology ' WHERE idsettoreerc = '294'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('294','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','294','LS3_6 Organelle biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '295')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '295',title = 'LS3_7 Cell signalling and cellular interactions ' WHERE idsettoreerc = '295'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('295','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','295','LS3_7 Cell signalling and cellular interactions ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '296')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '296',title = 'LS3_8 Signal transduction ' WHERE idsettoreerc = '296'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('296','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','296','LS3_8 Signal transduction ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '297')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '297',title = 'LS3_9 Development, developmental genetics, pattern formation and embryology in animals ' WHERE idsettoreerc = '297'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('297','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','297','LS3_9 Development, developmental genetics, pattern formation and embryology in animals ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '298')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '298',title = 'LS3_10 Development, developmental genetics, pattern formation and embryology in plants ' WHERE idsettoreerc = '298'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('298','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','298','LS3_10 Development, developmental genetics, pattern formation and embryology in plants ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '299')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '299',title = 'LS3_11 Cell genetics ' WHERE idsettoreerc = '299'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('299','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','299','LS3_11 Cell genetics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '300')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '300',title = 'LS3_12 Stem cell biology ' WHERE idsettoreerc = '300'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('300','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','300','LS3_12 Stem cell biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '301')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '301',title = 'LS4 Physiology, Pathophysiology and Endocrinology: Organ physiology, pathophysiology, endocrinology, metabolism, ageing, tumorigenesis, cardiovascular disease, metabolic syndrome ' WHERE idsettoreerc = '301'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('301','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','301','LS4 Physiology, Pathophysiology and Endocrinology: Organ physiology, pathophysiology, endocrinology, metabolism, ageing, tumorigenesis, cardiovascular disease, metabolic syndrome ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '302')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '302',title = 'LS4_1 Organ physiology and pathophysiology ' WHERE idsettoreerc = '302'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('302','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','302','LS4_1 Organ physiology and pathophysiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '303')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '303',title = 'LS4_2 Comparative physiology and pathophysiology ' WHERE idsettoreerc = '303'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('303','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','303','LS4_2 Comparative physiology and pathophysiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '304')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '304',title = 'LS4_3 Endocrinology ' WHERE idsettoreerc = '304'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('304','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','304','LS4_3 Endocrinology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '305')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '305',title = 'LS4_4 Ageing ' WHERE idsettoreerc = '305'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('305','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','305','LS4_4 Ageing ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '306')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '306',title = 'LS4_5 Metabolism, biological basis of metabolism related disorders ' WHERE idsettoreerc = '306'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('306','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','306','LS4_5 Metabolism, biological basis of metabolism related disorders ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '307')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '307',title = 'LS4_6 Cancer and its biological basis ' WHERE idsettoreerc = '307'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('307','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','307','LS4_6 Cancer and its biological basis ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '308')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '308',title = 'LS4_7 Cardiovascular diseases ' WHERE idsettoreerc = '308'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('308','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','308','LS4_7 Cardiovascular diseases ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '309')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '309',title = 'LS4_8 Non-communicable diseases (except for neural/psychiatric, immunityrelated, metabolism-related disorders, cancer and cardiovascular diseases) ' WHERE idsettoreerc = '309'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('309','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','309','LS4_8 Non-communicable diseases (except for neural/psychiatric, immunityrelated, metabolism-related disorders, cancer and cardiovascular diseases) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '310')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '310',title = 'LS5 Neurosciences and Neural Disorders: Neurobiology, neuroanatomy, neurophysiology, neurochemistry, neuropharmacology, neuroimaging, systems neuroscience, neurological and psychiatric disorders ' WHERE idsettoreerc = '310'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('310','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','310','LS5 Neurosciences and Neural Disorders: Neurobiology, neuroanatomy, neurophysiology, neurochemistry, neuropharmacology, neuroimaging, systems neuroscience, neurological and psychiatric disorders ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '311')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '311',title = 'LS5_1 Neuroanatomy and neurophysiology ' WHERE idsettoreerc = '311'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('311','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','311','LS5_1 Neuroanatomy and neurophysiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '312')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '312',title = 'LS5_2 Molecular and cellular neuroscience ' WHERE idsettoreerc = '312'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('312','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','312','LS5_2 Molecular and cellular neuroscience ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '313')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '313',title = 'LS5_3 Neurochemistry and neuropharmacology ' WHERE idsettoreerc = '313'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('313','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','313','LS5_3 Neurochemistry and neuropharmacology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '314')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '314',title = 'LS5_4 Sensory systems (e.g. visual system, auditory system) ' WHERE idsettoreerc = '314'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('314','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','314','LS5_4 Sensory systems (e.g. visual system, auditory system) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '315')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '315',title = 'LS5_5 Mechanisms of pain ' WHERE idsettoreerc = '315'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('315','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','315','LS5_5 Mechanisms of pain ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '316')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '316',title = 'LS5_6 Developmental neurobiology ' WHERE idsettoreerc = '316'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('316','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','316','LS5_6 Developmental neurobiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '317')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '317',title = 'LS5_7 Cognition (e.g. learning, memory, emotions, speech) ' WHERE idsettoreerc = '317'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('317','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','317','LS5_7 Cognition (e.g. learning, memory, emotions, speech) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '318')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '318',title = 'LS5_8 Behavioural neuroscience (e.g. sleep, consciousness, handedness) ' WHERE idsettoreerc = '318'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('318','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','318','LS5_8 Behavioural neuroscience (e.g. sleep, consciousness, handedness) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '319')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '319',title = 'LS5_9 Systems neuroscience ' WHERE idsettoreerc = '319'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('319','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','319','LS5_9 Systems neuroscience ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '320')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '320',title = 'LS5_10 Neuroimaging and computational neuroscience ' WHERE idsettoreerc = '320'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('320','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','320','LS5_10 Neuroimaging and computational neuroscience ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '321')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '321',title = 'LS5_11 Neurological disorders (e.g. Alzheimerís disease, Huntingtonís disease, Parkinsonís disease) ' WHERE idsettoreerc = '321'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('321','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','321','LS5_11 Neurological disorders (e.g. Alzheimerís disease, Huntingtonís disease, Parkinsonís disease) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '322')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '322',title = 'LS5_12 Psychiatric disorders (e.g. schizophrenia, autism, Touretteís syndrome, obsessive compulsive disorder, depression, bipolar disorder, attention deficit hyperactivity disorder) ' WHERE idsettoreerc = '322'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('322','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','322','LS5_12 Psychiatric disorders (e.g. schizophrenia, autism, Touretteís syndrome, obsessive compulsive disorder, depression, bipolar disorder, attention deficit hyperactivity disorder) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '323')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '323',title = 'LS6 Immunity and Infection: The immune system and related disorders, infectious agents and diseases, prevention and treatment of infection ' WHERE idsettoreerc = '323'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('323','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','323','LS6 Immunity and Infection: The immune system and related disorders, infectious agents and diseases, prevention and treatment of infection ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '324')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '324',title = 'LS6_1 Innate immunity and inflammation ' WHERE idsettoreerc = '324'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('324','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','324','LS6_1 Innate immunity and inflammation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '325')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '325',title = 'LS6_2 Adaptive immunity ' WHERE idsettoreerc = '325'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('325','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','325','LS6_2 Adaptive immunity ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '326')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '326',title = 'LS6_3 Phagocytosis and cellular immunity ' WHERE idsettoreerc = '326'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('326','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','326','LS6_3 Phagocytosis and cellular immunity ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '327')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '327',title = 'LS6_4 Immunosignalling ' WHERE idsettoreerc = '327'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('327','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','327','LS6_4 Immunosignalling ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '328')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '328',title = 'LS6_5 Immunological memory and tolerance ' WHERE idsettoreerc = '328'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('328','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','328','LS6_5 Immunological memory and tolerance ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '329')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '329',title = 'LS6_6 Immunogenetics ' WHERE idsettoreerc = '329'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('329','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','329','LS6_6 Immunogenetics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '330')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '330',title = 'LS6_7 Microbiology ' WHERE idsettoreerc = '330'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('330','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','330','LS6_7 Microbiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '331')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '331',title = 'LS6_8 Virology ' WHERE idsettoreerc = '331'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('331','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','331','LS6_8 Virology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '332')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '332',title = 'LS6_9 Bacteriology ' WHERE idsettoreerc = '332'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('332','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','332','LS6_9 Bacteriology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '333')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '333',title = 'LS6_10 Parasitology ' WHERE idsettoreerc = '333'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('333','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','333','LS6_10 Parasitology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '334')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '334',title = 'LS6_11 Prevention and treatment of infection by pathogens (e.g. vaccination, antibiotics, fungicide) ' WHERE idsettoreerc = '334'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('334','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','334','LS6_11 Prevention and treatment of infection by pathogens (e.g. vaccination, antibiotics, fungicide) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '335')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '335',title = 'LS6_12 Biological basis of immunity related disorders (e.g. autoimmunity) ' WHERE idsettoreerc = '335'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('335','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','335','LS6_12 Biological basis of immunity related disorders (e.g. autoimmunity) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '336')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '336',title = 'LS6_13 Veterinary medicine and infectious diseases in animals ' WHERE idsettoreerc = '336'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('336','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','336','LS6_13 Veterinary medicine and infectious diseases in animals ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '337')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '337',title = 'LS7 Diagnostic Tools, Therapies and Public Health: Aetiology, diagnosis and treatment of disease, public health, epidemiology, pharmacology, clinical medicine, regenerative medicine, medical ethics ' WHERE idsettoreerc = '337'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('337','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','337','LS7 Diagnostic Tools, Therapies and Public Health: Aetiology, diagnosis and treatment of disease, public health, epidemiology, pharmacology, clinical medicine, regenerative medicine, medical ethics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '338')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '338',title = 'LS7_1 Medical engineering and technology ' WHERE idsettoreerc = '338'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('338','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','338','LS7_1 Medical engineering and technology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '339')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '339',title = 'LS7_2 Diagnostic tools (e.g. genetic, imaging) ' WHERE idsettoreerc = '339'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('339','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','339','LS7_2 Diagnostic tools (e.g. genetic, imaging) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '340')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '340',title = 'LS7_3 Pharmacology, pharmacogenomics, drug discovery and design, drug therapy ' WHERE idsettoreerc = '340'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('340','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','340','LS7_3 Pharmacology, pharmacogenomics, drug discovery and design, drug therapy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '341')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '341',title = 'LS7_4 Analgesia and Surgery ' WHERE idsettoreerc = '341'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('341','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','341','LS7_4 Analgesia and Surgery ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '342')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '342',title = 'LS7_5 Toxicology ' WHERE idsettoreerc = '342'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('342','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','342','LS7_5 Toxicology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '343')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '343',title = 'LS7_6 Gene therapy, cell therapy, regenerative medicine ' WHERE idsettoreerc = '343'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('343','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','343','LS7_6 Gene therapy, cell therapy, regenerative medicine ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '344')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '344',title = 'LS7_7 Radiation therapy ' WHERE idsettoreerc = '344'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('344','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','344','LS7_7 Radiation therapy ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '345')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '345',title = 'LS7_8 Health services, health care research ' WHERE idsettoreerc = '345'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('345','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','345','LS7_8 Health services, health care research ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '346')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '346',title = 'LS7_9 Public health and epidemiology ' WHERE idsettoreerc = '346'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('346','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','346','LS7_9 Public health and epidemiology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '347')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '347',title = 'LS7_10 Environment and health risks, occupational medicine ' WHERE idsettoreerc = '347'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('347','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','347','LS7_10 Environment and health risks, occupational medicine ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '348')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '348',title = 'LS7_11 Medical ethics ' WHERE idsettoreerc = '348'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('348','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','348','LS7_11 Medical ethics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '349')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '349',title = 'LS8 Evolutionary, Population and Environmental Biology: Evolution, ecology, animal behaviour, population biology, biodiversity, biogeography, marine biology, ecotoxicology, microbial ecology ' WHERE idsettoreerc = '349'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('349','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','349','LS8 Evolutionary, Population and Environmental Biology: Evolution, ecology, animal behaviour, population biology, biodiversity, biogeography, marine biology, ecotoxicology, microbial ecology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '350')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '350',title = 'LS8_1 Ecology (theoretical and experimental, population, species and community level) ' WHERE idsettoreerc = '350'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('350','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','350','LS8_1 Ecology (theoretical and experimental, population, species and community level) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '351')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '351',title = 'LS8_2 Population biology, population dynamics, population genetics ' WHERE idsettoreerc = '351'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('351','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','351','LS8_2 Population biology, population dynamics, population genetics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '352')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '352',title = 'LS8_3 Systems evolution, biological adaptation, phylogenetics, systematics, comparative biology ' WHERE idsettoreerc = '352'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('352','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','352','LS8_3 Systems evolution, biological adaptation, phylogenetics, systematics, comparative biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '353')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '353',title = 'LS8_4 Biodiversity, conservation biology, conservation genetics, invasion biology ' WHERE idsettoreerc = '353'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('353','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','353','LS8_4 Biodiversity, conservation biology, conservation genetics, invasion biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '354')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '354',title = 'LS8_5 Evolutionary biology: evolutionary ecology and genetics, co-evolution ' WHERE idsettoreerc = '354'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('354','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','354','LS8_5 Evolutionary biology: evolutionary ecology and genetics, co-evolution ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '355')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '355',title = 'LS8_6 Biogeography, macro-ecology ' WHERE idsettoreerc = '355'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('355','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','355','LS8_6 Biogeography, macro-ecology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '356')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '356',title = 'LS8_7 Animal behaviour ' WHERE idsettoreerc = '356'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('356','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','356','LS8_7 Animal behaviour ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '357')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '357',title = 'LS8_8 Environmental and marine biology ' WHERE idsettoreerc = '357'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('357','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','357','LS8_8 Environmental and marine biology ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '358')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '358',title = 'LS8_9 Environmental toxicology at the population and ecosystems level ' WHERE idsettoreerc = '358'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('358','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','358','LS8_9 Environmental toxicology at the population and ecosystems level ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '359')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '359',title = 'LS8_10 Microbial ecology and evolution ' WHERE idsettoreerc = '359'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('359','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','359','LS8_10 Microbial ecology and evolution ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '360')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '360',title = 'LS8_11 Species interactions (e.g. food-webs, symbiosis, parasitism, mutualism) ' WHERE idsettoreerc = '360'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('360','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','360','LS8_11 Species interactions (e.g. food-webs, symbiosis, parasitism, mutualism) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '361')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '361',title = 'LS9 Applied Life Sciences and Non-Medical Biotechnology: Applied plant and animal sciences, food sciences, forestry, industrial, environmental and non-medical biotechnologies, bioengineering, synthetic and chemical biology, biomimetics, bioremediation ' WHERE idsettoreerc = '361'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('361','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','361','LS9 Applied Life Sciences and Non-Medical Biotechnology: Applied plant and animal sciences, food sciences, forestry, industrial, environmental and non-medical biotechnologies, bioengineering, synthetic and chemical biology, biomimetics, bioremediation ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '362')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '362',title = 'LS9_1 Non-medical biotechnology and genetic engineering (including transgenic organisms, recombinant proteins, biosensors, bioreactors, microbiology) ' WHERE idsettoreerc = '362'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('362','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','362','LS9_1 Non-medical biotechnology and genetic engineering (including transgenic organisms, recombinant proteins, biosensors, bioreactors, microbiology) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '363')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '363',title = 'LS9_2 Synthetic biology, chemical biology and bio-engineering ' WHERE idsettoreerc = '363'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('363','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','363','LS9_2 Synthetic biology, chemical biology and bio-engineering ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '364')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '364',title = 'LS9_3 Animal sciences (including animal husbandry, aquaculture, fisheries, animal welfare) ' WHERE idsettoreerc = '364'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('364','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','364','LS9_3 Animal sciences (including animal husbandry, aquaculture, fisheries, animal welfare) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '365')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '365',title = 'LS9_4 Plant sciences (including crop production, plant breeding, agroecology, soil biology) ' WHERE idsettoreerc = '365'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('365','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','365','LS9_4 Plant sciences (including crop production, plant breeding, agroecology, soil biology) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '366')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '366',title = 'LS9_5 Food sciences (including food technology, nutrition) ' WHERE idsettoreerc = '366'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('366','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','366','LS9_5 Food sciences (including food technology, nutrition) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '367')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '367',title = 'LS9_6 Forestry and biomass production (including biofuels) ' WHERE idsettoreerc = '367'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('367','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','367','LS9_6 Forestry and biomass production (including biofuels) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '368')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '368',title = 'LS9_7 Environmental biotechnology (including bioremediation, biodegradation) ' WHERE idsettoreerc = '368'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('368','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','368','LS9_7 Environmental biotechnology (including bioremediation, biodegradation) ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '369')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '369',title = 'LS9_8 Biomimetics ' WHERE idsettoreerc = '369'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('369','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','369','LS9_8 Biomimetics ')
GO

IF exists(SELECT * FROM [settoreerc] WHERE idsettoreerc = '370')
UPDATE [settoreerc] SET active = 'S',ct = {ts '2020-07-01 11:22:06.253'},cu = 'ferdinando',description = '',lt = {ts '2020-07-01 11:22:06.253'},lu = 'ferdinando',sortcode = '370',title = 'LS9_9 Biohazards (including biological containment, biosafety, biosecurity)' WHERE idsettoreerc = '370'
ELSE
INSERT INTO [settoreerc] (idsettoreerc,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('370','S',{ts '2020-07-01 11:22:06.253'},'ferdinando','',{ts '2020-07-01 11:22:06.253'},'ferdinando','370','LS9_9 Biohazards (including biological containment, biosafety, biosecurity)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'settoreerc')
UPDATE [tabledescr] SET description = '2.7.6 Settori ERC',idapplication = null,isdbo = 'N',lt = {ts '2020-05-25 13:47:38.190'},lu = 'assistenza',title = 'Settori ERC' WHERE tablename = 'settoreerc'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('settoreerc','2.7.6 Settori ERC',null,'N',{ts '2020-05-25 13:47:38.190'},'assistenza','Settori ERC')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','settoreerc','1',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','settoreerc','8',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','settoreerc','64',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','settoreerc','2048',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsettoreerc' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsettoreerc' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsettoreerc','settoreerc','4',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','settoreerc','8',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','settoreerc','64',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','settoreerc','4',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'settoreerc')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:47:40.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'settoreerc'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','settoreerc','2048',null,null,null,'S',{ts '2020-05-25 13:47:40.527'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE TABELLA workpackage --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[workpackage]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [workpackage] (
idworkpackage int NOT NULL,
idprogetto int NOT NULL,
acronimo nvarchar(2048) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description nvarchar(max) NULL,
idstruttura int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
raggruppamento nvarchar(2048) NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkworkpackage PRIMARY KEY (idworkpackage,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA workpackage --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'acronimo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD acronimo nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN acronimo nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'raggruppamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD raggruppamento nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN raggruppamento nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN title nvarchar(2048) NULL
GO

-- VERIFICA DI workpackage IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'workpackage'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','int','assistenza','idworkpackage','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(2048)','assistenza','acronimo','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(max)','assistenza','description','0','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','int','assistenza','idstruttura','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(2048)','assistenza','raggruppamento','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(2048)','assistenza','title','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI workpackage IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'workpackage')
UPDATE customobject set isreal = 'S' where objectname = 'workpackage'
ELSE
INSERT INTO customobject (objectname, isreal) values('workpackage', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'workpackage')
UPDATE [tabledescr] SET description = 'Workpackage',idapplication = null,isdbo = 'N',lt = {ts '2020-05-20 14:05:03.637'},lu = 'assistenza',title = 'Workpackage' WHERE tablename = 'workpackage'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('workpackage','Workpackage',null,'N',{ts '2020-05-20 14:05:03.637'},'assistenza','Workpackage')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'acronimo' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-02 18:25:10.753'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'acronimo' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('acronimo','workpackage','2048',null,null,null,'S',{ts '2020-11-02 18:25:10.753'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','workpackage','8',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','workpackage','64',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','workpackage','0',null,null,'Descrizione','S',{ts '2020-05-20 14:05:52.450'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','workpackage','4',null,null,'Progetto','S',{ts '2020-05-20 14:05:52.450'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Dipartimento',kind = 'S',lt = {ts '2020-11-02 18:25:36.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','workpackage','4',null,null,'Dipartimento','S',{ts '2020-11-02 18:25:36.680'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idupb' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Unità previsionale di base (UPB)',kind = 'S',lt = {ts '2020-11-02 18:25:36.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idupb' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idupb','workpackage','50',null,null,'Unità previsionale di base (UPB)','S',{ts '2020-11-02 18:25:36.680'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','workpackage','4',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.637'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','workpackage','8',null,null,null,'S',{ts '2020-05-20 14:05:05.637'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.637'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','workpackage','64',null,null,null,'S',{ts '2020-05-20 14:05:05.637'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'raggruppamento' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-02 18:25:10.753'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'raggruppamento' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('raggruppamento','workpackage','2048',null,null,null,'S',{ts '2020-11-02 18:25:10.753'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','workpackage','2048',null,null,'Titolo','S',{ts '2020-05-20 14:05:52.450'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

/****** Object:  View [amministrazione].[timesheetview]    Script Date: 18/02/2021 13:31:55 ******/
IF EXISTS(select * from sysobjects where id = object_id(N'[amministrazione].[timesheetview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [amministrazione].[timesheetview]
GO
/****** Object:  View [amministrazione].[timesheetview]    Script Date: 18/02/2021 13:31:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [amministrazione].[timesheetview]
AS
SELECT        
	progetto.idprogetto,
	rendicontattivitaprogetto.idreg, 
	YEAR(rendicontattivitaprogettoora.data) AS anno, 
	rendicontattivitaprogettoora.data, 
	rendicontattivitaprogettoora.ore, 
	progetto.titolobreve AS progetto, 
    workpackage.title AS workpackage, 
	DAY(rendicontattivitaprogettoora.data) AS giorno, 
	MONTH(rendicontattivitaprogettoora.data) AS mese
FROM
	rendicontattivitaprogetto 
	INNER JOIN rendicontattivitaprogettoora ON rendicontattivitaprogetto.idrendicontattivitaprogetto = rendicontattivitaprogettoora.idrendicontattivitaprogetto 
	INNER JOIN progetto ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto 
	INNER JOIN workpackage ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage
UNION
SELECT        
	null as idprogetto,
	dbo.lezione.idreg_docenti, 
	YEAR(dbo.lezione.start) AS anno, 
	dbo.lezione.start as data, 
	DATEDIFF(hh, dbo.lezione.start, dbo.lezione.stop) as ore, 
	'Teaching activities' AS progetto, 
    'Teaching activities' AS workpackage, 
	DAY(dbo.lezione.start) AS giorno, 
	MONTH(dbo.lezione.start) AS mese
FROM
	dbo.lezione


GO


-- CREAZIONE VISTA assetdiarydocview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetdiarydocview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetdiarydocview]
GO

CREATE VIEW [assetdiarydocview] AS SELECT  assetdiary.ct AS assetdiary_ct, assetdiary.cu AS assetdiary_cu, assetdiary.idasset AS assetdiary_idasset, assetdiary.idassetdiary, assetacquire.description AS assetacquire_description, assetacquire.idinv AS assetacquire_idinv, asset.idasset AS asset_idasset, asset.idpiece AS asset_idpiece, inventory.description AS inventory_description, asset.ninventory AS asset_ninventory, asset.rfid AS asset_rfid, assetdiary.idpiece, progetto.titolobreve AS progetto_titolobreve, assetdiary.idprogetto, assetdiary.idreg AS assetdiary_idreg, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, assetdiary.idworkpackage, assetdiary.lt AS assetdiary_lt, assetdiary.lu AS assetdiary_lu, assetdiary.orepreventivate AS assetdiary_orepreventivate, isnull('Descrizione Descrizione: ' + assetacquire.description + '; ','') + ' ' + isnull('Class. Inv. Descrizione: ' + CAST( assetacquire.idinv AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( asset.idasset AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( asset.idpiece AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( asset.ninventory AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + asset.rfid + '; ','') + ' ' + isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Descrizione Inventario: ' + inventory.description + '; ','') as dropdown_title FROM assetdiary WITH (NOLOCK)  LEFT OUTER JOIN asset WITH (NOLOCK) ON assetdiary.idasset = asset.idasset AND assetdiary.idpiece = asset.idpiece LEFT OUTER JOIN assetacquire WITH (NOLOCK) ON asset.nassetacquire = assetacquire.nassetacquire LEFT OUTER JOIN inventory WITH (NOLOCK) ON asset.idinventory = inventory.idinventory LEFT OUTER JOIN progetto WITH (NOLOCK) ON assetdiary.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON assetdiary.idworkpackage = workpackage.idworkpackage WHERE  assetdiary.idassetdiary IS NOT NULL  AND assetdiary.idworkpackage IS NOT NULL 
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

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','int','','idworkpackage','4','S','int','System.Int32','','','','','N')
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

-- CREAZIONE VISTA progettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettosegview]
GO

CREATE VIEW [progettosegview] AS SELECT  progetto.budget AS progetto_budget, progetto.budgetcalcolato AS progetto_budgetcalcolato, progetto.budgetcalcolatodate AS progetto_budgetcalcolatodate, progetto.capofilatxt AS progetto_capofilatxt, progetto.codiceidentificativo AS progetto_codiceidentificativo, progetto.contributo AS progetto_contributo, progetto.contributoente AS progetto_contributoente, progetto.ct AS progetto_ct, progetto.cu AS progetto_cu, progetto.cup AS progetto_cup, progetto.data AS progetto_data, progetto.datacontabile AS progetto_datacontabile, progetto.description AS progetto_description, progetto.durata AS progetto_durata, progetto.finanziatoretxt AS progetto_finanziatoretxt, [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, progetto.idcorsostudio, [dbo].currency.codecurrency AS currency_codecurrency, progetto.idcurrency, [dbo].duratakind.title AS duratakind_title, progetto.idduratakind AS progetto_idduratakind, progetto.idprogetto, [dbo].progettokind.title AS progettokind_title, progetto.idprogettokind AS progetto_idprogettokind, [dbo].progettostatuskind.title AS progettostatuskind_title, progetto.idprogettostatuskind AS progetto_idprogettostatuskind, [dbo].registry.title AS registry_title, progetto.idreg, registry_registry_aziendeaziende.title AS registryaziende_title, progetto.idreg_aziende, registry_registry_aziendeaziende_fin.title AS registryaziende_fin_title, progetto.idreg_aziende_fin, [dbo].registryprogfin.title AS registryprogfin_title, [dbo].registryprogfin.code AS registryprogfin_code, progetto.idregistryprogfin AS progetto_idregistryprogfin, [dbo].registryprogfinbando.title AS registryprogfinbando_title, [dbo].registryprogfinbando.number AS registryprogfinbando_number, [dbo].registryprogfinbando.scadenza AS registryprogfinbando_scadenza, progetto.idregistryprogfinbando AS progetto_idregistryprogfinbando, progetto.lt AS progetto_lt, progetto.lu AS progetto_lu, progetto.start AS progetto_start, progetto.stop AS progetto_stop, progetto.title AS progetto_title, progetto.titolobreve, progetto.totalbudget AS progetto_totalbudget, progetto.totalcontributo AS progetto_totalcontributo, progetto.url AS progetto_url, isnull('Titolo breve o acronimo: ' + progetto.titolobreve + '; ','') as dropdown_title FROM progetto WITH (NOLOCK)  LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON progetto.idcorsostudio = [dbo].corsostudio.idcorsostudio LEFT OUTER JOIN [dbo].currency WITH (NOLOCK) ON progetto.idcurrency = [dbo].currency.idcurrency LEFT OUTER JOIN [dbo].duratakind WITH (NOLOCK) ON progetto.idduratakind = [dbo].duratakind.idduratakind LEFT OUTER JOIN [dbo].progettokind WITH (NOLOCK) ON progetto.idprogettokind = [dbo].progettokind.idprogettokind LEFT OUTER JOIN [dbo].progettostatuskind WITH (NOLOCK) ON progetto.idprogettostatuskind = [dbo].progettostatuskind.idprogettostatuskind LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON progetto.idreg = [dbo].registry.idreg LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende WITH (NOLOCK) ON progetto.idreg_aziende = registry_aziendeaziende.idreg LEFT OUTER JOIN [dbo].registry AS registry_registry_aziendeaziende WITH (NOLOCK) ON registry_aziendeaziende.idreg = registry_registry_aziendeaziende.idreg LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende_fin WITH (NOLOCK) ON progetto.idreg_aziende_fin = registry_aziendeaziende_fin.idreg LEFT OUTER JOIN [dbo].registry AS registry_registry_aziendeaziende_fin WITH (NOLOCK) ON registry_aziendeaziende_fin.idreg = registry_registry_aziendeaziende_fin.idreg LEFT OUTER JOIN [dbo].registryprogfin WITH (NOLOCK) ON progetto.idregistryprogfin = [dbo].registryprogfin.idregistryprogfin LEFT OUTER JOIN [dbo].registryprogfinbando WITH (NOLOCK) ON progetto.idregistryprogfinbando = [dbo].registryprogfinbando.idregistryprogfinbando WHERE  progetto.idprogetto IS NOT NULL 
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
-- CREAZIONE VISTA registryamministrativiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryamministrativiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryamministrativiview]
GO

CREATE VIEW [dbo].[registryamministrativiview] AS SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, [dbo].category.description AS category_description, registry.idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory, [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, [dbo].maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus, [dbo].geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg, [dbo].registryclass.description AS registryclass_description, registry.idregistryclass, [dbo].registrykind.description AS registrykind_description, registry.idregistrykind AS registry_idregistrykind, [dbo].title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, [dbo].residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title AS registry_title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_amministrativi.ct AS registry_amministrativi_ct, registry_amministrativi.cu AS registry_amministrativi_cu, registry_amministrativi.cv AS registry_amministrativi_cv, [dbo].contrattokind.title AS contrattokind_title, registry_amministrativi.idcontrattokind AS registry_amministrativi_idcontrattokind, registry_amministrativi.idreg AS registry_amministrativi_idreg, registry_amministrativi.lt AS registry_amministrativi_lt, registry_amministrativi.lu AS registry_amministrativi_lu, isnull('Titolo: ' + [dbo].title.description + '; ','') + ' ' + isnull('Cognome: ' + registry.surname + '; ','') + ' ' + isnull('Nome: ' + registry.forename + '; ','') + ' ' + isnull('Codice fiscale: ' + registry.cf + '; ','') as dropdown_title FROM [dbo].registry WITH (NOLOCK)  INNER JOIN registry_amministrativi WITH (NOLOCK) ON registry.idreg = registry_amministrativi.idreg LEFT OUTER JOIN [dbo].category WITH (NOLOCK) ON registry.idcategory = [dbo].category.idcategory LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity LEFT OUTER JOIN [dbo].maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = [dbo].maritalstatus.idmaritalstatus LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registry.idnation = [dbo].geo_nation.idnation LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass LEFT OUTER JOIN [dbo].registrykind WITH (NOLOCK) ON registry.idregistrykind = [dbo].registrykind.idregistrykind LEFT OUTER JOIN [dbo].title WITH (NOLOCK) ON registry.idtitle = [dbo].title.idtitle LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON registry.residence = [dbo].residence.idresidence LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON registry_amministrativi.idcontrattokind = [dbo].contrattokind.idcontrattokind WHERE  registry.idreg IS NOT NULL  AND registry_amministrativi.idreg IS NOT NULL 
GO

-- VERIFICA DI registryamministrativiview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryamministrativiview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','category_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','contrattokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','varchar(216)','ASSISTENZA','dropdown_title','216','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(65)','ASSISTENZA','geo_city_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(65)','ASSISTENZA','geo_nation_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','idcategory','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','idregistryclass','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','idtitle','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','maritalstatus_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','datetime','ASSISTENZA','registry_amministrativi_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(64)','ASSISTENZA','registry_amministrativi_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','nvarchar(max)','ASSISTENZA','registry_amministrativi_cv','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','registry_amministrativi_idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','int','ASSISTENZA','registry_amministrativi_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','datetime','ASSISTENZA','registry_amministrativi_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(64)','ASSISTENZA','registry_amministrativi_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(400)','ASSISTENZA','registry_annotation','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_authorization_free','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','registry_badgecode','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','date','ASSISTENZA','registry_birthdate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(12)','ASSISTENZA','registry_ccp','12','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(16)','ASSISTENZA','registry_cf','16','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','datetime','ASSISTENZA','registry_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','varchar(64)','ASSISTENZA','registry_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(200)','ASSISTENZA','registry_email_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(200)','ASSISTENZA','registry_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(40)','ASSISTENZA','registry_extmatricula','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_flag_pa','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_flagbankitaliaproceeds','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(40)','ASSISTENZA','registry_foreigncf','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registry_forename','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(7)','ASSISTENZA','registry_gender','7','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','registry_idcentralizedcategory','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','registry_idexternal','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','registry_idmaritalstatus','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','registry_idregistrykind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(7)','ASSISTENZA','registry_ipa_fe','7','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(100)','ASSISTENZA','registry_ipa_perlapa','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registry_location','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','datetime','ASSISTENZA','registry_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','varchar(64)','ASSISTENZA','registry_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registry_maritalsurname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_multi_cf','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(15)','ASSISTENZA','registry_p_iva','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(200)','ASSISTENZA','registry_pec_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','image','ASSISTENZA','registry_rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','registry_sdi_defrifamm','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_sdi_norifamm','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registry_surname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','varchar(101)','ASSISTENZA','registry_title','101','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','registry_toredirect','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','text','ASSISTENZA','registry_txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(150)','ASSISTENZA','registryclass_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registrykind_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','int','ASSISTENZA','residence','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(60)','ASSISTENZA','residence_description','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','title_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registryamministrativiview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryamministrativiview')
UPDATE customobject set isreal = 'N' where objectname = 'registryamministrativiview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryamministrativiview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA registrydocentiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrydocentiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrydocentiview]
GO

CREATE VIEW [dbo].[registrydocentiview] AS SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, registry.idcategory AS registry_idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory, [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, [dbo].maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus, [dbo].geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg, [dbo].registryclass.description AS registryclass_description, registry.idregistryclass, registry.idregistrykind AS registry_idregistrykind, [dbo].title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, [dbo].residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_docenti.ct AS registry_docenti_ct, registry_docenti.cu AS registry_docenti_cu, registry_docenti.cv AS registry_docenti_cv, [dbo].classconsorsuale.title AS classconsorsuale_title, registry_docenti.idclassconsorsuale, [dbo].contrattokind.title AS contrattokind_title, registry_docenti.idcontrattokind AS registry_docenti_idcontrattokind, [dbo].fonteindicebibliometrico.title AS fonteindicebibliometrico_title, registry_docenti.idfonteindicebibliometrico AS registry_docenti_idfonteindicebibliometrico, registry_docenti.idreg AS registry_docenti_idreg, registry_registry_istitutiistituti.title AS registryistituti_title, registry_docenti.idreg_istituti, [dbo].sasd.codice AS sasd_codice, [dbo].sasd.title AS sasd_title, registry_docenti.idsasd, [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, registry_docenti.idstruttura, registry_docenti.indicebibliometrico AS registry_docenti_indicebibliometrico, registry_docenti.lt AS registry_docenti_lt, registry_docenti.lu AS registry_docenti_lu, registry_docenti.matricola AS registry_docenti_matricola, registry_docenti.ricevimento AS registry_docenti_ricevimento, registry_docenti.soggiorno AS registry_docenti_soggiorno, isnull('Denominazione: ' + registry.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + [dbo].strutturakind.title + '; ','') as dropdown_title FROM [dbo].registry WITH (NOLOCK)  INNER JOIN registry_docenti WITH (NOLOCK) ON registry.idreg = registry_docenti.idreg LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity LEFT OUTER JOIN [dbo].maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = [dbo].maritalstatus.idmaritalstatus LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registry.idnation = [dbo].geo_nation.idnation LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass LEFT OUTER JOIN [dbo].title WITH (NOLOCK) ON registry.idtitle = [dbo].title.idtitle LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON registry.residence = [dbo].residence.idresidence LEFT OUTER JOIN [dbo].classconsorsuale WITH (NOLOCK) ON registry_docenti.idclassconsorsuale = [dbo].classconsorsuale.idclassconsorsuale LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON registry_docenti.idcontrattokind = [dbo].contrattokind.idcontrattokind LEFT OUTER JOIN [dbo].fonteindicebibliometrico WITH (NOLOCK) ON registry_docenti.idfonteindicebibliometrico = [dbo].fonteindicebibliometrico.idfonteindicebibliometrico LEFT OUTER JOIN [dbo].registry_istituti AS registry_istitutiistituti WITH (NOLOCK) ON registry_docenti.idreg_istituti = registry_istitutiistituti.idreg LEFT OUTER JOIN [dbo].registry AS registry_registry_istitutiistituti WITH (NOLOCK) ON registry_istitutiistituti.idreg = registry_registry_istitutiistituti.idreg LEFT OUTER JOIN [dbo].sasd WITH (NOLOCK) ON registry_docenti.idsasd = [dbo].sasd.idsasd LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON registry_docenti.idstruttura = [dbo].struttura.idstruttura LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind WHERE  registry.idreg IS NOT NULL  AND registry_docenti.idreg IS NOT NULL 
GO

-- VERIFICA DI registrydocentiview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrydocentiview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','classconsorsuale_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','contrattokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(192)','ASSISTENZA','dropdown_title','192','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','nvarchar(1024)','ASSISTENZA','fonteindicebibliometrico_title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(65)','ASSISTENZA','geo_city_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(65)','ASSISTENZA','geo_nation_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idclassconsorsuale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idreg_istituti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','idregistryclass','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idsasd','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idstruttura','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','idtitle','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','maritalstatus_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(400)','ASSISTENZA','registry_annotation','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_authorization_free','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','registry_badgecode','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','date','ASSISTENZA','registry_birthdate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(12)','ASSISTENZA','registry_ccp','12','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(16)','ASSISTENZA','registry_cf','16','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','datetime','ASSISTENZA','registry_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(64)','ASSISTENZA','registry_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','datetime','ASSISTENZA','registry_docenti_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(64)','ASSISTENZA','registry_docenti_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','nvarchar(max)','ASSISTENZA','registry_docenti_cv','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_docenti_idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_docenti_idfonteindicebibliometrico','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','int','ASSISTENZA','registry_docenti_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_docenti_indicebibliometrico','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','datetime','ASSISTENZA','registry_docenti_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(64)','ASSISTENZA','registry_docenti_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_docenti_matricola','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','nvarchar(max)','ASSISTENZA','registry_docenti_ricevimento','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(255)','ASSISTENZA','registry_docenti_soggiorno','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(200)','ASSISTENZA','registry_email_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(200)','ASSISTENZA','registry_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(40)','ASSISTENZA','registry_extmatricula','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_flag_pa','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_flagbankitaliaproceeds','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(40)','ASSISTENZA','registry_foreigncf','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_forename','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(7)','ASSISTENZA','registry_gender','7','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_idcategory','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','registry_idcentralizedcategory','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_idexternal','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','registry_idmaritalstatus','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_idregistrykind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(7)','ASSISTENZA','registry_ipa_fe','7','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(100)','ASSISTENZA','registry_ipa_perlapa','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_location','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','datetime','ASSISTENZA','registry_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(64)','ASSISTENZA','registry_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_maritalsurname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_multi_cf','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(15)','ASSISTENZA','registry_p_iva','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(200)','ASSISTENZA','registry_pec_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','image','ASSISTENZA','registry_rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','registry_sdi_defrifamm','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_sdi_norifamm','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_surname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_toredirect','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','text','ASSISTENZA','registry_txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(150)','ASSISTENZA','registryclass_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(101)','ASSISTENZA','registryistituti_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','int','ASSISTENZA','residence','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(60)','ASSISTENZA','residence_description','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','sasd_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(255)','ASSISTENZA','sasd_title','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(1024)','ASSISTENZA','struttura_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','','strutturakind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(101)','ASSISTENZA','title','101','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','title_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registrydocentiview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrydocentiview')
UPDATE customobject set isreal = 'N' where objectname = 'registrydocentiview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrydocentiview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA rendicontattivitaprogettoanagammview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoanagammview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettoanagammview]
GO

CREATE VIEW [rendicontattivitaprogettoanagammview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, itineration.description AS itineration_description, itineration.location AS itineration_location, itineration.starttime AS itineration_starttime, itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 
GO

-- VERIFICA DI rendicontattivitaprogettoanagammview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettoanagammview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','nvarchar(max)','ASSISTENZA','dropdown_title','0','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','int','','idworkpackage','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','varchar(150)','ASSISTENZA','itineration_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','varchar(65)','ASSISTENZA','itineration_location','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','datetime','ASSISTENZA','itineration_starttime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','datetime','ASSISTENZA','itineration_stoptime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','nvarchar(2048)','ASSISTENZA','progetto_titolobreve','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','datetime','ASSISTENZA','rendicontattivitaprogetto_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','date','ASSISTENZA','rendicontattivitaprogetto_datainizioprevista','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','varchar(max)','ASSISTENZA','rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','int','ASSISTENZA','rendicontattivitaprogetto_iditineration','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','int','ASSISTENZA','rendicontattivitaprogetto_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','datetime','ASSISTENZA','rendicontattivitaprogetto_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','int','ASSISTENZA','rendicontattivitaprogetto_orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','nvarchar(2048)','ASSISTENZA','workpackage_raggruppamento','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','nvarchar(2048)','ASSISTENZA','workpackage_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogettoanagammview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettoanagammview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettoanagammview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettoanagammview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA rendicontattivitaprogettoanagview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoanagview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettoanagview]
GO

CREATE VIEW [rendicontattivitaprogettoanagview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, itineration.description AS itineration_description, itineration.location AS itineration_location, itineration.starttime AS itineration_starttime, itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 
GO

-- VERIFICA DI rendicontattivitaprogettoanagview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettoanagview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','nvarchar(max)','ASSISTENZA','dropdown_title','0','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','int','','idworkpackage','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','varchar(150)','ASSISTENZA','itineration_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','varchar(65)','ASSISTENZA','itineration_location','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','datetime','ASSISTENZA','itineration_starttime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','datetime','ASSISTENZA','itineration_stoptime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','nvarchar(2048)','ASSISTENZA','progetto_titolobreve','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','datetime','ASSISTENZA','rendicontattivitaprogetto_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','date','ASSISTENZA','rendicontattivitaprogetto_datainizioprevista','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','varchar(max)','ASSISTENZA','rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','int','ASSISTENZA','rendicontattivitaprogetto_iditineration','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','int','ASSISTENZA','rendicontattivitaprogetto_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','datetime','ASSISTENZA','rendicontattivitaprogetto_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','int','ASSISTENZA','rendicontattivitaprogetto_orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','nvarchar(2048)','ASSISTENZA','workpackage_raggruppamento','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','nvarchar(2048)','ASSISTENZA','workpackage_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogettoanagview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettoanagview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettoanagview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettoanagview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA rendicontattivitaprogettodocview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettodocview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettodocview]
GO

CREATE VIEW [rendicontattivitaprogettodocview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, itineration.description AS itineration_description, itineration.location AS itineration_location, itineration.starttime AS itineration_starttime, itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 
GO

-- VERIFICA DI rendicontattivitaprogettodocview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettodocview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','nvarchar(max)','','dropdown_title','0','S','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','int','','idprogetto','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','int','','idrendicontattivitaprogetto','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','int','','idworkpackage','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','varchar(150)','','itineration_description','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','varchar(65)','','itineration_location','65','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','datetime','','itineration_starttime','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','datetime','','itineration_stoptime','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','nvarchar(2048)','','progetto_titolobreve','2048','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','datetime','','rendicontattivitaprogetto_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','varchar(64)','','rendicontattivitaprogetto_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','date','','rendicontattivitaprogetto_datainizioprevista','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','varchar(max)','','rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','int','','rendicontattivitaprogetto_iditineration','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','int','','rendicontattivitaprogetto_idreg','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','datetime','','rendicontattivitaprogetto_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','varchar(64)','','rendicontattivitaprogetto_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','int','','rendicontattivitaprogetto_orepreventivate','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','nvarchar(2048)','','workpackage_raggruppamento','2048','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','nvarchar(2048)','','workpackage_title','2048','N','nvarchar','System.String','','','','','N')
GO

-- VERIFICA DI rendicontattivitaprogettodocview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettodocview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettodocview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettodocview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA rendicontattivitaprogettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettosegview]
GO

CREATE VIEW [rendicontattivitaprogettosegview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description, itineration.description AS itineration_description, itineration.location AS itineration_location, itineration.starttime AS itineration_starttime, itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, rendicontattivitaprogetto.idprogetto AS rendicontattivitaprogetto_idprogetto, [dbo].registry.title AS registry_title, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = itineration.iditineration LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON rendicontattivitaprogetto.idreg = [dbo].registry.idreg WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 
GO

-- VERIFICA DI rendicontattivitaprogettosegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettosegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','varchar(max)','ASSISTENZA','description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','varchar(max)','ASSISTENZA','dropdown_title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','int','','idworkpackage','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','varchar(150)','ASSISTENZA','itineration_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','varchar(65)','ASSISTENZA','itineration_location','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','datetime','ASSISTENZA','itineration_starttime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','datetime','ASSISTENZA','itineration_stoptime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','datetime','ASSISTENZA','rendicontattivitaprogetto_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','date','ASSISTENZA','rendicontattivitaprogetto_datainizioprevista','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','int','ASSISTENZA','rendicontattivitaprogetto_iditineration','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','int','ASSISTENZA','rendicontattivitaprogetto_idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','int','ASSISTENZA','rendicontattivitaprogetto_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','datetime','ASSISTENZA','rendicontattivitaprogetto_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','int','ASSISTENZA','rendicontattivitaprogetto_orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogettosegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettosegview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettosegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettosegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA settoreercsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[settoreercsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[settoreercsegview]
GO

CREATE VIEW [dbo].[settoreercsegview] AS SELECT CASE WHEN settoreerc.active = 'S' THEN 'Si' WHEN settoreerc.active = 'N' THEN 'No' END AS settoreerc_active, settoreerc.ct AS settoreerc_ct, settoreerc.cu AS settoreerc_cu, settoreerc.description AS settoreerc_description, settoreerc.idsettoreerc, settoreerc.lt AS settoreerc_lt, settoreerc.lu AS settoreerc_lu, settoreerc.sortcode AS settoreerc_sortcode, settoreerc.title, isnull('Titolo: ' + settoreerc.title + '; ','') as dropdown_title FROM [dbo].settoreerc WITH (NOLOCK)  WHERE  settoreerc.idsettoreerc IS NOT NULL 
GO

-- VERIFICA DI settoreercsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'settoreercsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','settoreercsegview','nvarchar(2058)','ASSISTENZA','dropdown_title','2058','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','settoreercsegview','int','ASSISTENZA','idsettoreerc','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','varchar(2)','ASSISTENZA','settoreerc_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','datetime','ASSISTENZA','settoreerc_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','varchar(64)','ASSISTENZA','settoreerc_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','nvarchar(2048)','ASSISTENZA','settoreerc_description','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','datetime','ASSISTENZA','settoreerc_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','varchar(64)','ASSISTENZA','settoreerc_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','int','ASSISTENZA','settoreerc_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','settoreercsegview','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI settoreercsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'settoreercsegview')
UPDATE customobject set isreal = 'N' where objectname = 'settoreercsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('settoreercsegview', 'N')
GO

-- GENERAZIONE DATI PER settoreercsegview --
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA workpackagesegview
IF EXISTS(select * from sysobjects where id = object_id(N'[workpackagesegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [workpackagesegview]
GO

CREATE VIEW [workpackagesegview] AS SELECT  workpackage.acronimo AS workpackage_acronimo, workpackage.ct AS workpackage_ct, workpackage.cu AS workpackage_cu, workpackage.description AS workpackage_description, workpackage.idprogetto, [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, workpackage.idstruttura AS workpackage_idstruttura, workpackage.idworkpackage, workpackage.lt AS workpackage_lt, workpackage.lu AS workpackage_lu, workpackage.raggruppamento, workpackage.title AS workpackage_title, isnull('Raggruppamento: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Titolo: ' + workpackage.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + [dbo].strutturakind.title + '; ','') as dropdown_title FROM workpackage WITH (NOLOCK)  LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON workpackage.idstruttura = [dbo].struttura.idstruttura LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind WHERE  workpackage.idprogetto IS NOT NULL  AND workpackage.idworkpackage IS NOT NULL 
GO

-- VERIFICA DI workpackagesegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'workpackagesegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','nvarchar(4000)','ASSISTENZA','dropdown_title','4000','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(2048)','ASSISTENZA','raggruppamento','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','varchar(1024)','','struttura_title','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','varchar(50)','','strutturakind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(2048)','ASSISTENZA','workpackage_acronimo','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','datetime','ASSISTENZA','workpackage_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','varchar(64)','ASSISTENZA','workpackage_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(max)','ASSISTENZA','workpackage_description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','int','','workpackage_idstruttura','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','datetime','ASSISTENZA','workpackage_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','varchar(64)','ASSISTENZA','workpackage_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(2048)','ASSISTENZA','workpackage_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI workpackagesegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'workpackagesegview')
UPDATE customobject set isreal = 'N' where objectname = 'workpackagesegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('workpackagesegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE PROCEDURE [compute_assetdiaryora]
IF EXISTS (select * from sysobjects where id = object_id(N'[compute_assetdiaryora]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [compute_assetdiaryora]
GO
CREATE PROCEDURE [compute_assetdiaryora] 
(
	@max_ayear int, 
	@max_mese int,
	@idprogetto int
)
as begin 
--185.56.8.51,5839
-- Per ogni mese si calcola la proporzione di ore di utilizzo dell'asset

	create table #oremesicespite(sommeore int, mese int, idasset int, idpiece int, ayear int)
	--sommeore : indica quante ore Ã¨ stato usato il bene nel mese indicato @max_mese

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
	
	-- Per ogni cespite calcola l'ammortamento annuo e poi farÃ  diviso 12
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
			-- in questa tebella metterÃ  tutti i valori dell'Ammortamento, cosÃ¬ dopo potrÃ  fare direttamente il JOIN piuttosto che fare l'UPDATE su #oremesicespite
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
GO
--[DBO]--
-- CREAZIONE PROCEDURE [GenerateProgettoDetail]
IF EXISTS (select * from sysobjects where id = object_id(N'[GenerateProgettoDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [GenerateProgettoDetail]
GO
CREATE PROCEDURE [GenerateProgettoDetail]
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
	INSERT INTO [workpackage]
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
	FROM dbo.workpackagekind wpk
	WHERE idprogettokind = @idprogettokind and not exists (	select x.title 
															from workpackage x 
															where x.idprogetto = @idprogetto and x.title = wpk.title)

	--VOCI COSTO
	INSERT INTO [progettotipocosto]
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
	FROM dbo.progettotipocostokind ptcck
	WHERE idprogettokind = @idprogettokind and not exists (	select x.idprogettotipocostokind 
															from progettotipocosto x 
															where x.idprogetto = @idprogetto and x.idprogettotipocostokind = ptcck.idprogettotipocostokind)

	--progettotipocostokindaccmotive: causali economico patrimoniali

	INSERT INTO [progettotipocostoaccmotive]
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
	FROM dbo.progettotipocostokindaccmotive ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostoaccmotive x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.idaccmotive = ptcka.idaccmotive)

	--progettotipocostokindcontrattokind: tipologia di contratti

	INSERT INTO [progettotipocostocontrattokind]
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
	FROM dbo.progettotipocostokindcontrattokind ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostocontrattokind x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.idcontrattokind = ptcka.idcontrattokind)

	--progettotipocostokindinventorytree: classificazioni inventariali

	INSERT INTO [progettotipocostoinventorytree]
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
	FROM dbo.progettotipocostokindinventorytree ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostoinventorytree x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.idinv = ptcka.idinv)

	--progettotipocostokindtax: tipi di ritenuta

	INSERT INTO [progettotipocostotax]
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
	FROM dbo.progettotipocostokindtax ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostotax x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.taxcode = ptcka.taxcode)

	--CATEGORIE COSTO
	INSERT INTO [progettobudget]
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
	INSERT INTO [progettotesto]
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
	FROM dbo.progettotestokind ptk
	WHERE ptk.idprogettokind = @idprogettokind and not exists (	select x.title 
																from progettotesto x 
																where x.idprogetto = @idprogetto and x.title = ptk.titolo)

	--ALLEGATI
	INSERT INTO [progettoattach]
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
	FROM dbo.progettoattachkind ptk
	WHERE ptk.idprogettokind = @idprogettokind and not exists (	select x.title 
																from progettoattach x 
																where x.idprogetto = @idprogetto and x.title = ptk.title)


END
GO

IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'progettokindsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('progettokindsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'progettosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('progettosegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaseganagstusonpreview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaseganagstusonpreview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaimm_seganagstupreview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaimm_seganagstupreview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaimm_segrinview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaimm_segrinview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaimm_seganagsturinview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaimm_seganagsturinview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaimm_segview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaimm_segview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaimm_seganagstuview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaimm_seganagstuview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'istanzaimm_segpreview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('istanzaimm_segpreview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registrystudentiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registrystudentiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'learningagrtrainersegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('learningagrtrainersegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'iscrizionebmisegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('iscrizionebmisegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'bandomisegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('bandomisegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'settoreercsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('settoreercsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryamministrativi_personaleview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registryamministrativi_personaleview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registryamministrativiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registryamministrativiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registrydocenti_docview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registrydocenti_docview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'registrydocentiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('registrydocentiview')
GO

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'assetdiarydocview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('assetdiarydocview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontattivitaprogettosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('rendicontattivitaprogettosegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontattivitaprogettoanagammview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('rendicontattivitaprogettoanagammview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontattivitaprogettoanagview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('rendicontattivitaprogettoanagview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'workpackagesegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('workpackagesegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'rendicontattivitaprogettodocview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('rendicontattivitaprogettodocview')
GO
 --insert metadatamanagedtable
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaimm_seganagstupreview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaimm_seganagstupreview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaimm_seganagstupreview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaimm_segrinview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaimm_segrinview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaimm_segrinview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaimm_seganagsturinview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaimm_seganagsturinview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaimm_seganagsturinview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaimm_segview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaimm_segview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaimm_segview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaimm_seganagstuview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaimm_seganagstuview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaimm_seganagstuview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'istanzaimm_segpreview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('istanzaimm_segpreview', '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"' WHERE [tablename] = 'istanzaimm_segpreview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registrystudentiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registrystudentiview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registrystudentiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryamministrativi_personaleview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryamministrativi_personaleview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registryamministrativi_personaleview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registryamministrativiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registryamministrativiview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registryamministrativiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registrydocenti_docview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registrydocenti_docview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registrydocenti_docview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'registrydocentiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('registrydocentiview', '"idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idreg"' WHERE [tablename] = 'registrydocentiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettosegview', '"idprogetto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto"' WHERE [tablename] = 'progetto'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettokindsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettokindsegview', '"idprogettokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogettokind"' WHERE [tablename] = 'progettokind'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'settoreercsegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('settoreercsegview', '"idsettoreerc"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idsettoreerc"' WHERE [tablename] = 'settoreerc'
GO

GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'assetdiarydocview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('assetdiarydocview', '"idassetdiary"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idassetdiary"' WHERE [tablename] = 'assetdiary'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettosegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettosegview', '"idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogetto'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoanagammview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoanagammview', '"idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogetto'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoanagview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoanagview', '"idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogetto'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'workpackagesegview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('workpackagesegview', '"idprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto","idworkpackage"' WHERE [tablename] = 'workpackage'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettodocview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettodocview', '"idrendicontattivitaprogetto","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto","idworkpackage"' WHERE [tablename] = 'rendicontattivitaprogetto'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoanagview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoanagview', '"idrendicontattivitaprogetto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto"' WHERE [tablename] = 'rendicontattivitaprogetto'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoanagammview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettoanagammview', '"idrendicontattivitaprogetto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto"' WHERE [tablename] = 'rendicontattivitaprogetto'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettodocview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('rendicontattivitaprogettodocview', '"idrendicontattivitaprogetto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idrendicontattivitaprogetto"' WHERE [tablename] = 'rendicontattivitaprogetto'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'assetdiarydocview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('assetdiarydocview', '"idassetdiary","idworkpackage"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idassetdiary","idworkpackage"' WHERE [tablename] = 'assetdiary'
GO
 --insert metadataprimarykey

IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'progettokindsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('progettokindsegview', 'seg', 'progettoactivitykind_title asc , title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'progettoactivitykind_title asc , title asc ' WHERE [tablename] = 'progettokindsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'progettosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('progettosegview', 'seg', 'titolobreve asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'titolobreve asc ' WHERE [tablename] = 'progettosegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registrystudentiview' AND [listtype] = 'studenti')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registrystudentiview', 'studenti', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registrystudentiview' AND [listtype] = 'studenti'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'learningagrtrainersegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('learningagrtrainersegview', 'seg', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'learningagrtrainersegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'iscrizionebmisegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('iscrizionebmisegview', 'seg', 'registry_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'registry_title asc ' WHERE [tablename] = 'iscrizionebmisegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'bandomisegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('bandomisegview', 'seg', 'title desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title desc' WHERE [tablename] = 'bandomisegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'settoreercsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('settoreercsegview', 'seg', 'settoreerc_sortcode desc')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'settoreerc_sortcode desc' WHERE [tablename] = 'settoreercsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registrydocenti_docview' AND [listtype] = 'docenti_doc')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registrydocenti_docview', 'docenti_doc', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registrydocenti_docview' AND [listtype] = 'docenti_doc'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'registrydocentiview' AND [listtype] = 'docenti')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('registrydocentiview', 'docenti', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'registrydocentiview' AND [listtype] = 'docenti'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'assetdiarydocview' AND [listtype] = 'doc')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('assetdiarydocview', 'doc', 'progetto_titolobreve asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'progetto_titolobreve asc ' WHERE [tablename] = 'assetdiarydocview' AND [listtype] = 'doc'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontattivitaprogettosegview', 'seg', 'rendicontattivitaprogetto_datainizioprevista asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'rendicontattivitaprogetto_datainizioprevista asc ' WHERE [tablename] = 'rendicontattivitaprogettosegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettoanagammview' AND [listtype] = 'anagamm')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontattivitaprogettoanagammview', 'anagamm', 'rendicontattivitaprogetto_datainizioprevista asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'rendicontattivitaprogetto_datainizioprevista asc ' WHERE [tablename] = 'rendicontattivitaprogettoanagammview' AND [listtype] = 'anagamm'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettoanagview' AND [listtype] = 'anag')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontattivitaprogettoanagview', 'anag', 'rendicontattivitaprogetto_datainizioprevista asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'rendicontattivitaprogetto_datainizioprevista asc ' WHERE [tablename] = 'rendicontattivitaprogettoanagview' AND [listtype] = 'anag'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'workpackagesegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('workpackagesegview', 'seg', 'raggruppamento asc , workpackage_title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'raggruppamento asc , workpackage_title asc ' WHERE [tablename] = 'workpackagesegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettodocview' AND [listtype] = 'doc')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('rendicontattivitaprogettodocview', 'doc', 'rendicontattivitaprogetto_datainizioprevista asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'rendicontattivitaprogetto_datainizioprevista asc ' WHERE [tablename] = 'rendicontattivitaprogettodocview' AND [listtype] = 'doc'
GO
 --insert metadatasorting

IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'istanzaimm_segrinview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('istanzaimm_segrinview', 'imm_segrin', 'idistanzakind= 15')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idistanzakind= 15' WHERE [tablename] = 'istanzaimm_segrinview' AND [listtype] = 'imm_segrin'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'istanzaimm_segview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('istanzaimm_segview', 'imm_seg', 'idistanzakind = 14')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idistanzakind = 14' WHERE [tablename] = 'istanzaimm_segview' AND [listtype] = 'imm_seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'istanzaimm_segpreview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('istanzaimm_segpreview', 'imm_segpre', 'idistanzakind = 13')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = 'idistanzakind = 13' WHERE [tablename] = 'istanzaimm_segpreview' AND [listtype] = 'imm_segpre'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'registryamministrativi_personaleview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('registryamministrativi_personaleview', 'amministrativi_personale', '(idreg=''{usr$idreg}'')')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(idreg=''{usr$idreg}'')' WHERE [tablename] = 'registryamministrativi_personaleview' AND [listtype] = 'amministrativi_personale'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'registrydocenti_docview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('registrydocenti_docview', 'docenti_doc', '(idreg=''{usr$idreg}'')')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(idreg=''{usr$idreg}'')' WHERE [tablename] = 'registrydocenti_docview' AND [listtype] = 'docenti_doc'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'assetdiarydocview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('assetdiarydocview', 'doc', '(assetdiary_idreg =''{usr$idreg}'')')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(assetdiary_idreg =''{usr$idreg}'')' WHERE [tablename] = 'assetdiarydocview' AND [listtype] = 'doc'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatastaticfilter] WHERE [tablename] = 'rendicontattivitaprogettodocview')
INSERT INTO [dbo].[metadatastaticfilter] ([tablename], [listtype], [staticfilter]) VALUES ('rendicontattivitaprogettodocview', 'doc', '(rendicontattivitaprogetto_idreg=''{usr$idreg}'')')
ELSE 	
UPDATE [dbo].[metadatastaticfilter] SET [staticfilter] = '(rendicontattivitaprogetto_idreg=''{usr$idreg}'')' WHERE [tablename] = 'rendicontattivitaprogettodocview' AND [listtype] = 'doc'
GO
 --insert metadatastaticfilter 
 
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostokindsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostokindsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostokindsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostokindsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostokindsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostosegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettoattachkindsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoattachkindsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettoattachkindsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettoattachkindsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettoattachkindsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettoattachsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoattachsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettoattachsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettoattachsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettoattachsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettosettoreercsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettosettoreercsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettosettoreercsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettosettoreercsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettosettoreercsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'settoreercsegprogview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'settoreercsegprogview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'settoreercsegprogview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'settoreercsegprogview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'settoreercsegprogview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotimesheetdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotimesheetdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotimesheetdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotimesheetdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotimesheetdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotimesheetprogettodefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotimesheetprogettodefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotimesheetprogettodefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotimesheetprogettodefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotimesheetprogettodefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettorpdefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettorpdefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettorpdefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettorpdefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettorpdefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettoattachkindprogettostatuskinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettoattachkindprogettostatuskinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettoattachkindprogettostatuskinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettoattachkindprogettostatuskinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettoattachkindprogettostatuskinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotestokindprogettostatuskinddefaultview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotestokindprogettostatuskinddefaultview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotestokindprogettostatuskinddefaultview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotestokindprogettostatuskinddefaultview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotestokindprogettostatuskinddefaultview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotestokindsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotestokindsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotestokindsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotestokindsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotestokindsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettobudgetsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettobudgetsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettobudgetsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettobudgetsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettobudgetsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'rendicontattivitaprogettoorasegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'rendicontattivitaprogettoorasegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'rendicontattivitaprogettoorasegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'rendicontattivitaprogettoorasegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'rendicontattivitaprogettoorasegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'assetdiarysegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'assetdiarysegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'assetdiarysegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'assetdiarysegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'assetdiarysegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'assetdiaryorasegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'assetdiaryorasegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'assetdiaryorasegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'assetdiaryorasegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'assetdiaryorasegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'assetdiaryseganagview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'assetdiaryseganagview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'assetdiaryseganagview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'assetdiaryseganagview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'assetdiaryseganagview'
END
GO
 --delete ï»¿
-- GENERAZIONE DATI PER web_listredir --
IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'accmotive')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'accmotivedefaultview' WHERE listtype = 'default' AND tablename = 'accmotive'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','accmotive',null,null,null,null,'default','accmotivedefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'accmotive')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'accmotivesegview' WHERE listtype = 'seg' AND tablename = 'accmotive'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','accmotive',null,null,null,null,'seg','accmotivesegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'accordoscambiomi')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'accordoscambiomisegview' WHERE listtype = 'seg' AND tablename = 'accordoscambiomi'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','accordoscambiomi',null,null,null,null,'seg','accordoscambiomisegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'accreditokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'accreditokinddefaultview' WHERE listtype = 'default' AND tablename = 'accreditokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','accreditokind',null,null,null,null,'default','accreditokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'address')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'addresssegview' WHERE listtype = 'seg' AND tablename = 'address'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','address',null,null,null,null,'seg','addresssegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'affidamento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'affidamentodefaultview' WHERE listtype = 'default' AND tablename = 'affidamento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','affidamento',null,null,null,null,'default','affidamentodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'doc' AND tablename = 'affidamento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'doc',newtablename = 'affidamentodocview' WHERE listtype = 'doc' AND tablename = 'affidamento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('doc','affidamento',null,null,null,null,'doc','affidamentodocview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'affidamento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'affidamentosegview' WHERE listtype = 'seg' AND tablename = 'affidamento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','affidamento',null,null,null,null,'seg','affidamentosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'affidamentokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'affidamentokinddefaultview' WHERE listtype = 'default' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','affidamentokind',null,null,null,null,'default','affidamentokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ambitoareadisc')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'ambitoareadiscdefaultview' WHERE listtype = 'default' AND tablename = 'ambitoareadisc'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','ambitoareadisc',null,null,null,null,'default','ambitoareadiscdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'aoo')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'aoodefaultview' WHERE listtype = 'default' AND tablename = 'aoo'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','aoo',null,null,null,null,'default','aoodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'princ' AND tablename = 'aoo')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'princ',newtablename = 'aooprincview' WHERE listtype = 'princ' AND tablename = 'aoo'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('princ','aoo',null,null,null,null,'princ','aooprincview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'appello')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'appellodefaultview' WHERE listtype = 'default' AND tablename = 'appello'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','appello',null,null,null,null,'default','appellodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'appello')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'erogata',newtablename = 'appelloerogataview' WHERE listtype = 'erogata' AND tablename = 'appello'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('erogata','appello',null,null,null,null,'erogata','appelloerogataview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'appelloazionekind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'appelloazionekinddefaultview' WHERE listtype = 'default' AND tablename = 'appelloazionekind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','appelloazionekind',null,null,null,null,'default','appelloazionekinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'appellokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'appellokinddefaultview' WHERE listtype = 'default' AND tablename = 'appellokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','appellokind',null,null,null,null,'default','appellokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'areadidattica')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'areadidatticadefaultview' WHERE listtype = 'default' AND tablename = 'areadidattica'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','areadidattica',null,null,null,null,'default','areadidatticadefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'asset')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'assetsegview' WHERE listtype = 'seg' AND tablename = 'asset'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','asset',null,null,null,null,'seg','assetsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'assetacquire')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'assetacquiresegview' WHERE listtype = 'seg' AND tablename = 'assetacquire'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','assetacquire',null,null,null,null,'seg','assetacquiresegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'doc' AND tablename = 'assetdiary')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'doc',newtablename = 'assetdiarydocview' WHERE listtype = 'doc' AND tablename = 'assetdiary'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('doc','assetdiary',null,null,null,null,'doc','assetdiarydocview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'assicurazione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'assicurazionedefaultview' WHERE listtype = 'default' AND tablename = 'assicurazione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','assicurazione',null,null,null,null,'default','assicurazionedefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ateco')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'atecodefaultview' WHERE listtype = 'default' AND tablename = 'ateco'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','ateco',null,null,null,null,'default','atecodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'appello' AND tablename = 'attivform')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'appello',newtablename = 'attivformappelloview' WHERE listtype = 'appello' AND tablename = 'attivform'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('appello','attivform',null,null,null,null,'appello','attivformappelloview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'attivform')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'attivformdefaultview' WHERE listtype = 'default' AND tablename = 'attivform'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','attivform',null,null,null,null,'default','attivformdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'attivform')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'erogata',newtablename = 'attivformerogataview' WHERE listtype = 'erogata' AND tablename = 'attivform'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('erogata','attivform',null,null,null,null,'erogata','attivformerogataview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'gruppo' AND tablename = 'attivform')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'gruppo',newtablename = 'attivformgruppoview' WHERE listtype = 'gruppo' AND tablename = 'attivform'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('gruppo','attivform',null,null,null,null,'gruppo','attivformgruppoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'proped' AND tablename = 'attivform')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'proped',newtablename = 'attivformpropedview' WHERE listtype = 'proped' AND tablename = 'attivform'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('proped','attivform',null,null,null,null,'proped','attivformpropedview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'aula')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'auladefaultview' WHERE listtype = 'default' AND tablename = 'aula'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','aula',null,null,null,null,'default','auladefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'aula')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg_child',newtablename = 'aulaseg_childview' WHERE listtype = 'seg_child' AND tablename = 'aula'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg_child','aula',null,null,null,null,'seg_child','aulaseg_childview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'aulakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'aulakinddefaultview' WHERE listtype = 'default' AND tablename = 'aulakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','aulakind',null,null,null,null,'default','aulakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'bandods')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'bandodssegview' WHERE listtype = 'seg' AND tablename = 'bandods'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','bandods',null,null,null,null,'seg','bandodssegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'bandomi')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'bandomisegview' WHERE listtype = 'seg' AND tablename = 'bandomi'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','bandomi',null,null,null,null,'seg','bandomisegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'bandomobilitaintkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'bandomobilitaintkinddefaultview' WHERE listtype = 'default' AND tablename = 'bandomobilitaintkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','bandomobilitaintkind',null,null,null,null,'default','bandomobilitaintkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'canale')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'erogata',newtablename = 'canaleerogataview' WHERE listtype = 'erogata' AND tablename = 'canale'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('erogata','canale',null,null,null,null,'erogata','canaleerogataview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ccnl')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'ccnldefaultview' WHERE listtype = 'default' AND tablename = 'ccnl'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','ccnl',null,null,null,null,'default','ccnldefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'cefr')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'cefrdefaultview' WHERE listtype = 'default' AND tablename = 'cefr'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','cefr',null,null,null,null,'default','cefrdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'cefrlanglevel')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'cefrlangleveldefaultview' WHERE listtype = 'default' AND tablename = 'cefrlanglevel'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','cefrlanglevel',null,null,null,null,'default','cefrlangleveldefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'changeskind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'changeskinddefaultview' WHERE listtype = 'default' AND tablename = 'changeskind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','changeskind',null,null,null,null,'default','changeskinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'classconsorsuale')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'classconsorsualedefaultview' WHERE listtype = 'default' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','classconsorsuale',null,null,null,null,'default','classconsorsualedefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'classescuola')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'classescuoladefaultview' WHERE listtype = 'default' AND tablename = 'classescuola'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','classescuola',null,null,null,null,'default','classescuoladefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'classescuolakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'classescuolakinddefaultview' WHERE listtype = 'default' AND tablename = 'classescuolakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','classescuolakind',null,null,null,null,'default','classescuolakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'contrattokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'contrattokinddefaultview' WHERE listtype = 'default' AND tablename = 'contrattokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','contrattokind',null,null,null,null,'default','contrattokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'convenzione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'convenzionesegview' WHERE listtype = 'seg' AND tablename = 'convenzione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','convenzione',null,null,null,null,'seg','convenzionesegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'corsostudiodefaultview' WHERE listtype = 'default' AND tablename = 'corsostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','corsostudio',null,null,null,null,'default','corsostudiodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'corsostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'dotmas',newtablename = 'corsostudiodotmasview' WHERE listtype = 'dotmas' AND tablename = 'corsostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('dotmas','corsostudio',null,null,null,null,'dotmas','corsostudiodotmasview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'corsostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'ingresso',newtablename = 'corsostudioingressoview' WHERE listtype = 'ingresso' AND tablename = 'corsostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('ingresso','corsostudio',null,null,null,null,'ingresso','corsostudioingressoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'corsostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'stato',newtablename = 'corsostudiostatoview' WHERE listtype = 'stato' AND tablename = 'corsostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('stato','corsostudio',null,null,null,null,'stato','corsostudiostatoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudiokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'corsostudiokinddefaultview' WHERE listtype = 'default' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','corsostudiokind',null,null,null,null,'default','corsostudiokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudiolivello')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'corsostudiolivellodefaultview' WHERE listtype = 'default' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','corsostudiolivello',null,null,null,null,'default','corsostudiolivellodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudionorma')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'corsostudionormadefaultview' WHERE listtype = 'default' AND tablename = 'corsostudionorma'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','corsostudionorma',null,null,null,null,'default','corsostudionormadefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'more' AND tablename = 'costoscontodef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'more',newtablename = 'costoscontodefmoreview' WHERE listtype = 'more' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('more','costoscontodef',null,null,null,null,'more','costoscontodefmoreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'sconti' AND tablename = 'costoscontodef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'sconti',newtablename = 'costoscontodefscontiview' WHERE listtype = 'sconti' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('sconti','costoscontodef',null,null,null,null,'sconti','costoscontodefscontiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'costoscontodefkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'costoscontodefkinddefaultview' WHERE listtype = 'default' AND tablename = 'costoscontodefkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','costoscontodefkind',null,null,null,null,'default','costoscontodefkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'decadenza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'decadenzasegview' WHERE listtype = 'seg' AND tablename = 'decadenza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','decadenza',null,null,null,null,'seg','decadenzasegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'delibera')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'deliberasegview' WHERE listtype = 'seg' AND tablename = 'delibera'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','delibera',null,null,null,null,'seg','deliberasegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'altre_seg' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'altre_seg',newtablename = 'dichiaraltre_segview' WHERE listtype = 'altre_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('altre_seg','dichiar',null,null,null,null,'altre_seg','dichiaraltre_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'altrititoli_seg' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'altrititoli_seg',newtablename = 'dichiaraltrititoli_segview' WHERE listtype = 'altrititoli_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('altrititoli_seg','dichiar',null,null,null,null,'altrititoli_seg','dichiaraltrititoli_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'disabil_seg' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'disabil_seg',newtablename = 'dichiardisabil_segview' WHERE listtype = 'disabil_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('disabil_seg','dichiar',null,null,null,null,'disabil_seg','dichiardisabil_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'disabil_seganagstu' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'disabil_seganagstu',newtablename = 'dichiardisabil_seganagstuview' WHERE listtype = 'disabil_seganagstu' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('disabil_seganagstu','dichiar',null,null,null,null,'disabil_seganagstu','dichiardisabil_seganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'isee_seg' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'isee_seg',newtablename = 'dichiarisee_segview' WHERE listtype = 'isee_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('isee_seg','dichiar',null,null,null,null,'isee_seg','dichiarisee_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'isee_seganagstu' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'isee_seganagstu',newtablename = 'dichiarisee_seganagstuview' WHERE listtype = 'isee_seganagstu' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('isee_seganagstu','dichiar',null,null,null,null,'isee_seganagstu','dichiarisee_seganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'dichiarsegview' WHERE listtype = 'seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','dichiar',null,null,null,null,'seg','dichiarsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'titolo_seg' AND tablename = 'dichiar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'titolo_seg',newtablename = 'dichiartitolo_segview' WHERE listtype = 'titolo_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('titolo_seg','dichiar',null,null,null,null,'titolo_seg','dichiartitolo_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiaraltrekind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'dichiaraltrekinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','dichiaraltrekind',null,null,null,null,'default','dichiaraltrekinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiardisabilkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'dichiardisabilkinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiardisabilkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','dichiardisabilkind',null,null,null,null,'default','dichiardisabilkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiardisabilsuppkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'dichiardisabilsuppkinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiardisabilsuppkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','dichiardisabilsuppkind',null,null,null,null,'default','dichiardisabilsuppkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiarkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'dichiarkinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiarkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','dichiarkind',null,null,null,null,'default','dichiarkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'diderog')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'diderogdefaultview' WHERE listtype = 'default' AND tablename = 'diderog'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','diderog',null,null,null,null,'default','diderogdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didprog')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'didprogdefaultview' WHERE listtype = 'default' AND tablename = 'didprog'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','didprog',null,null,null,null,'default','didprogdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'didprog')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'dotmas',newtablename = 'didprogdotmasview' WHERE listtype = 'dotmas' AND tablename = 'didprog'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('dotmas','didprog',null,null,null,null,'dotmas','didprogdotmasview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'didprog')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'ingresso',newtablename = 'didprogingressoview' WHERE listtype = 'ingresso' AND tablename = 'didprog'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('ingresso','didprog',null,null,null,null,'ingresso','didprogingressoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'didprog')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'stato',newtablename = 'didprogstatoview' WHERE listtype = 'stato' AND tablename = 'didprog'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('stato','didprog',null,null,null,null,'stato','didprogstatoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didproganno')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'didprogannodefaultview' WHERE listtype = 'default' AND tablename = 'didproganno'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','didproganno',null,null,null,null,'default','didprogannodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didprogori')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'didprogoridefaultview' WHERE listtype = 'default' AND tablename = 'didprogori'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','didprogori',null,null,null,null,'default','didprogoridefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'sceltacorso' AND tablename = 'didprogori')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'sceltacorso',newtablename = 'didprogorisceltacorsoview' WHERE listtype = 'sceltacorso' AND tablename = 'didprogori'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('sceltacorso','didprogori',null,null,null,null,'sceltacorso','didprogorisceltacorsoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didprogporzanno')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'didprogporzannodefaultview' WHERE listtype = 'default' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','didprogporzanno',null,null,null,null,'default','didprogporzannodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'duratakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'duratakinddefaultview' WHERE listtype = 'default' AND tablename = 'duratakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','duratakind',null,null,null,null,'default','duratakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'edificio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'edificiodefaultview' WHERE listtype = 'default' AND tablename = 'edificio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','edificio',null,null,null,null,'default','edificiodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'edificio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg_child',newtablename = 'edificioseg_childview' WHERE listtype = 'seg_child' AND tablename = 'edificio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg_child','edificio',null,null,null,null,'seg_child','edificioseg_childview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'erogazkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'erogazkinddefaultview' WHERE listtype = 'default' AND tablename = 'erogazkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','erogazkind',null,null,null,null,'default','erogazkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'carriera' AND tablename = 'esonero')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'carriera',newtablename = 'esonerocarrieraview' WHERE listtype = 'carriera' AND tablename = 'esonero'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('carriera','esonero',null,null,null,null,'carriera','esonerocarrieraview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'esonero')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'esonerodefaultview' WHERE listtype = 'default' AND tablename = 'esonero'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','esonero',null,null,null,null,'default','esonerodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'disabil' AND tablename = 'esonero')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'disabil',newtablename = 'esonerodisabilview' WHERE listtype = 'disabil' AND tablename = 'esonero'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('disabil','esonero',null,null,null,null,'disabil','esonerodisabilview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'titolostudio' AND tablename = 'esonero')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'titolostudio',newtablename = 'esonerotitolostudioview' WHERE listtype = 'titolostudio' AND tablename = 'esonero'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('titolostudio','esonero',null,null,null,null,'titolostudio','esonerotitolostudioview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'expense')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'expensesegview' WHERE listtype = 'seg' AND tablename = 'expense'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','expense',null,null,null,null,'seg','expensesegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'fasciaiseedef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'fasciaiseedefdefaultview' WHERE listtype = 'default' AND tablename = 'fasciaiseedef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','fasciaiseedef',null,null,null,null,'default','fasciaiseedefdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'more' AND tablename = 'fasciaiseedef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'more',newtablename = 'fasciaiseedefmoreview' WHERE listtype = 'more' AND tablename = 'fasciaiseedef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('more','fasciaiseedef',null,null,null,null,'more','fasciaiseedefmoreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'sconti' AND tablename = 'fasciaiseedef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'sconti',newtablename = 'fasciaiseedefscontiview' WHERE listtype = 'sconti' AND tablename = 'fasciaiseedef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('sconti','fasciaiseedef',null,null,null,null,'sconti','fasciaiseedefscontiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'fonteindicebibliometrico')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'fonteindicebibliometricosegview' WHERE listtype = 'seg' AND tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','fonteindicebibliometrico',null,null,null,null,'seg','fonteindicebibliometricosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'geo_city')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'geo_citydefaultview' WHERE listtype = 'default' AND tablename = 'geo_city'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','geo_city',null,null,null,null,'default','geo_citydefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_city')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'geo_citysegview' WHERE listtype = 'seg' AND tablename = 'geo_city'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','geo_city',null,null,null,null,'seg','geo_citysegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg5' AND tablename = 'geo_city')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg5',newtablename = 'geo_cityseg5view' WHERE listtype = 'seg5' AND tablename = 'geo_city'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg5','geo_city',null,null,null,null,'seg5','geo_cityseg5view')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segchild' AND tablename = 'geo_city')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segchild',newtablename = 'geo_citysegchildview' WHERE listtype = 'segchild' AND tablename = 'geo_city'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segchild','geo_city',null,null,null,null,'segchild','geo_citysegchildview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_country')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'geo_countrysegview' WHERE listtype = 'seg' AND tablename = 'geo_country'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','geo_country',null,null,null,null,'seg','geo_countrysegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segchild' AND tablename = 'geo_country')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segchild',newtablename = 'geo_countrysegchildview' WHERE listtype = 'segchild' AND tablename = 'geo_country'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segchild','geo_country',null,null,null,null,'segchild','geo_countrysegchildview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'lingue' AND tablename = 'geo_nation')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'lingue',newtablename = 'geo_nationlingueview' WHERE listtype = 'lingue' AND tablename = 'geo_nation'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('lingue','geo_nation',null,null,null,null,'lingue','geo_nationlingueview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_nation')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'geo_nationsegview' WHERE listtype = 'seg' AND tablename = 'geo_nation'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','geo_nation',null,null,null,null,'seg','geo_nationsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segchild' AND tablename = 'geo_nation')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segchild',newtablename = 'geo_nationsegchildview' WHERE listtype = 'segchild' AND tablename = 'geo_nation'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segchild','geo_nation',null,null,null,null,'segchild','geo_nationsegchildview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_region')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'geo_regionsegview' WHERE listtype = 'seg' AND tablename = 'geo_region'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','geo_region',null,null,null,null,'seg','geo_regionsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getcostididattica')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'getcostididatticadefaultview' WHERE listtype = 'default' AND tablename = 'getcostididattica'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','getcostididattica',null,null,null,null,'default','getcostididatticadefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'getcostididattica')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'erogata',newtablename = 'getcostididatticaerogataview' WHERE listtype = 'erogata' AND tablename = 'getcostididattica'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('erogata','getcostididattica',null,null,null,null,'erogata','getcostididatticaerogataview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'getdocentiperssd')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'getdocentiperssdsegview' WHERE listtype = 'seg' AND tablename = 'getdocentiperssd'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','getdocentiperssd',null,null,null,null,'seg','getdocentiperssdsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getprogettocostoliquidatoview')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'getprogettocostoliquidatoviewdefaultview' WHERE listtype = 'default' AND tablename = 'getprogettocostoliquidatoview'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','getprogettocostoliquidatoview',null,null,null,null,'default','getprogettocostoliquidatoviewdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getprogettocostoview')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'getprogettocostoviewdefaultview' WHERE listtype = 'default' AND tablename = 'getprogettocostoview'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','getprogettocostoview',null,null,null,null,'default','getprogettocostoviewdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getregistrydocentiamministrativi')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'getregistrydocentiamministratividefaultview' WHERE listtype = 'default' AND tablename = 'getregistrydocentiamministrativi'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','getregistrydocentiamministrativi',null,null,null,null,'default','getregistrydocentiamministratividefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'graduatoriavar')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'graduatoriavardefaultview' WHERE listtype = 'default' AND tablename = 'graduatoriavar'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','graduatoriavar',null,null,null,null,'default','graduatoriavardefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'inquadramento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'inquadramentodefaultview' WHERE listtype = 'default' AND tablename = 'inquadramento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','inquadramento',null,null,null,null,'default','inquadramentodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'insegn')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'insegndefaultview' WHERE listtype = 'default' AND tablename = 'insegn'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','insegn',null,null,null,null,'default','insegndefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'insegninteg')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'insegnintegdefaultview' WHERE listtype = 'default' AND tablename = 'insegninteg'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','insegninteg',null,null,null,null,'default','insegnintegdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'inventorytree')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'inventorytreesegview' WHERE listtype = 'seg' AND tablename = 'inventorytree'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','inventorytree',null,null,null,null,'seg','inventorytreesegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'iscrizionedefaultview' WHERE listtype = 'default' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','iscrizione',null,null,null,null,'default','iscrizionedefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'didprog' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'didprog',newtablename = 'iscrizionedidprogview' WHERE listtype = 'didprog' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('didprog','iscrizione',null,null,null,null,'didprog','iscrizionedidprogview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'dotmas',newtablename = 'iscrizionedotmasview' WHERE listtype = 'dotmas' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('dotmas','iscrizione',null,null,null,null,'dotmas','iscrizionedotmasview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'ingresso',newtablename = 'iscrizioneingressoview' WHERE listtype = 'ingresso' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('ingresso','iscrizione',null,null,null,null,'ingresso','iscrizioneingressoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'iscrizionesegview' WHERE listtype = 'seg' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','iscrizione',null,null,null,null,'seg','iscrizionesegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstu' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstu',newtablename = 'iscrizioneseganagstuview' WHERE listtype = 'seganagstu' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstu','iscrizione',null,null,null,null,'seganagstu','iscrizioneseganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstuacc' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstuacc',newtablename = 'iscrizioneseganagstuaccview' WHERE listtype = 'seganagstuacc' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstuacc','iscrizione',null,null,null,null,'seganagstuacc','iscrizioneseganagstuaccview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstumast' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstumast',newtablename = 'iscrizioneseganagstumastview' WHERE listtype = 'seganagstumast' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstumast','iscrizione',null,null,null,null,'seganagstumast','iscrizioneseganagstumastview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstusing' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstusing',newtablename = 'iscrizioneseganagstusingview' WHERE listtype = 'seganagstusing' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstusing','iscrizione',null,null,null,null,'seganagstusing','iscrizioneseganagstusingview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstustato' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstustato',newtablename = 'iscrizioneseganagstustatoview' WHERE listtype = 'seganagstustato' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstustato','iscrizione',null,null,null,null,'seganagstustato','iscrizioneseganagstustatoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'iscrizione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'stato',newtablename = 'iscrizionestatoview' WHERE listtype = 'stato' AND tablename = 'iscrizione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('stato','iscrizione',null,null,null,null,'stato','iscrizionestatoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'iscrizionebmi')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'iscrizionebmisegview' WHERE listtype = 'seg' AND tablename = 'iscrizionebmi'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','iscrizionebmi',null,null,null,null,'seg','iscrizionebmisegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'iscrizionebmiattach')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'iscrizionebmiattachsegview' WHERE listtype = 'seg' AND tablename = 'iscrizionebmiattach'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','iscrizionebmiattach',null,null,null,null,'seg','iscrizionebmiattachsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'cert_seg' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'cert_seg',newtablename = 'istanzacert_segview' WHERE listtype = 'cert_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('cert_seg','istanza',null,null,null,null,'cert_seg','istanzacert_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'eq_seg' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'eq_seg',newtablename = 'istanzaeq_segview' WHERE listtype = 'eq_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('eq_seg','istanza',null,null,null,null,'eq_seg','istanzaeq_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seg' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seg',newtablename = 'istanzaimm_segview' WHERE listtype = 'imm_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seg','istanza',null,null,null,null,'imm_seg','istanzaimm_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seganagstu' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seganagstu',newtablename = 'istanzaimm_seganagstuview' WHERE listtype = 'imm_seganagstu' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seganagstu','istanza',null,null,null,null,'imm_seganagstu','istanzaimm_seganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seganagstupre' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seganagstupre',newtablename = 'istanzaimm_seganagstupreview' WHERE listtype = 'imm_seganagstupre' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seganagstupre','istanza',null,null,null,null,'imm_seganagstupre','istanzaimm_seganagstupreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seganagsturin' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seganagsturin',newtablename = 'istanzaimm_seganagsturinview' WHERE listtype = 'imm_seganagsturin' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seganagsturin','istanza',null,null,null,null,'imm_seganagsturin','istanzaimm_seganagsturinview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_segpre' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_segpre',newtablename = 'istanzaimm_segpreview' WHERE listtype = 'imm_segpre' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_segpre','istanza',null,null,null,null,'imm_segpre','istanzaimm_segpreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_segrin' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_segrin',newtablename = 'istanzaimm_segrinview' WHERE listtype = 'imm_segrin' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_segrin','istanza',null,null,null,null,'imm_segrin','istanzaimm_segrinview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'pas_seganagstu' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'pas_seganagstu',newtablename = 'istanzapas_seganagstuview' WHERE listtype = 'pas_seganagstu' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('pas_seganagstu','istanza',null,null,null,null,'pas_seganagstu','istanzapas_seganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'rin_seg' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'rin_seg',newtablename = 'istanzarin_segview' WHERE listtype = 'rin_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('rin_seg','istanza',null,null,null,null,'rin_seg','istanzarin_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstusonpre' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstusonpre',newtablename = 'istanzaseganagstusonpreview' WHERE listtype = 'seganagstusonpre' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstusonpre','istanza',null,null,null,null,'seganagstusonpre','istanzaseganagstusonpreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'sosp_seg' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'sosp_seg',newtablename = 'istanzasosp_segview' WHERE listtype = 'sosp_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('sosp_seg','istanza',null,null,null,null,'sosp_seg','istanzasosp_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'tru_seg' AND tablename = 'istanza')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'tru_seg',newtablename = 'istanzatru_segview' WHERE listtype = 'tru_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('tru_seg','istanza',null,null,null,null,'tru_seg','istanzatru_segview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'istanzaattach')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'istanzaattachsegview' WHERE listtype = 'seg' AND tablename = 'istanzaattach'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','istanzaattach',null,null,null,null,'seg','istanzaattachsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'istanzakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'istanzakinddefaultview' WHERE listtype = 'default' AND tablename = 'istanzakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','istanzakind',null,null,null,null,'default','istanzakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'itineration')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'itinerationsegview' WHERE listtype = 'seg' AND tablename = 'itineration'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','itineration',null,null,null,null,'seg','itinerationsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'learningagrstud')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'learningagrstudsegview' WHERE listtype = 'seg' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','learningagrstud',null,null,null,null,'seg','learningagrstudsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'learningagrtrainer')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'learningagrtrainersegview' WHERE listtype = 'seg' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','learningagrtrainer',null,null,null,null,'seg','learningagrtrainersegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'nace')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'nacedefaultview' WHERE listtype = 'default' AND tablename = 'nace'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','nace',null,null,null,null,'default','nacedefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'naturagiur')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'naturagiurdefaultview' WHERE listtype = 'default' AND tablename = 'naturagiur'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','naturagiur',null,null,null,null,'default','naturagiurdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seganagstu' AND tablename = 'nullaosta')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seganagstu',newtablename = 'nullaostaimm_seganagstuview' WHERE listtype = 'imm_seganagstu' AND tablename = 'nullaosta'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seganagstu','nullaosta',null,null,null,null,'imm_seganagstu','nullaostaimm_seganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seganagstupre' AND tablename = 'nullaosta')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seganagstupre',newtablename = 'nullaostaimm_seganagstupreview' WHERE listtype = 'imm_seganagstupre' AND tablename = 'nullaosta'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seganagstupre','nullaosta',null,null,null,null,'imm_seganagstupre','nullaostaimm_seganagstupreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'imm_seganagsturin' AND tablename = 'nullaosta')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'imm_seganagsturin',newtablename = 'nullaostaimm_seganagsturinview' WHERE listtype = 'imm_seganagsturin' AND tablename = 'nullaosta'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('imm_seganagsturin','nullaosta',null,null,null,null,'imm_seganagsturin','nullaostaimm_seganagsturinview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ofakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'ofakinddefaultview' WHERE listtype = 'default' AND tablename = 'ofakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','ofakind',null,null,null,null,'default','ofakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'orakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'orakindsegview' WHERE listtype = 'seg' AND tablename = 'orakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','orakind',null,null,null,null,'seg','orakindsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'pagamentokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'pagamentokinddefaultview' WHERE listtype = 'default' AND tablename = 'pagamentokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','pagamentokind',null,null,null,null,'default','pagamentokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'pettycash')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'pettycashsegview' WHERE listtype = 'seg' AND tablename = 'pettycash'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','pettycash',null,null,null,null,'seg','pettycashsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segstud' AND tablename = 'pianostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segstud',newtablename = 'pianostudiosegstudview' WHERE listtype = 'segstud' AND tablename = 'pianostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segstud','pianostudio',null,null,null,null,'segstud','pianostudiosegstudview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'pianostudiostatus')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'pianostudiostatusdefaultview' WHERE listtype = 'default' AND tablename = 'pianostudiostatus'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','pianostudiostatus',null,null,null,null,'default','pianostudiostatusdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segstud' AND tablename = 'pratica')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segstud',newtablename = 'praticasegstudview' WHERE listtype = 'segstud' AND tablename = 'pratica'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segstud','pratica',null,null,null,null,'segstud','praticasegstudview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'progetto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'progettosegview' WHERE listtype = 'seg' AND tablename = 'progetto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','progetto',null,null,null,null,'seg','progettosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'progettoactivitykind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'progettoactivitykinddefaultview' WHERE listtype = 'default' AND tablename = 'progettoactivitykind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','progettoactivitykind',null,null,null,null,'default','progettoactivitykinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'progettoasset')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'progettoassetdefaultview' WHERE listtype = 'default' AND tablename = 'progettoasset'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','progettoasset',null,null,null,null,'default','progettoassetdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'progettokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'progettokindsegview' WHERE listtype = 'seg' AND tablename = 'progettokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','progettokind',null,null,null,null,'seg','progettokindsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'progettotipocosto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'progettotipocostosegview' WHERE listtype = 'seg' AND tablename = 'progettotipocosto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','progettotipocosto',null,null,null,null,'seg','progettotipocostosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'progettoudrmembrokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'progettoudrmembrokinddefaultview' WHERE listtype = 'default' AND tablename = 'progettoudrmembrokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','progettoudrmembrokind',null,null,null,null,'default','progettoudrmembrokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'protocollo')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'protocollosegview' WHERE listtype = 'seg' AND tablename = 'protocollo'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','protocollo',null,null,null,null,'seg','protocollosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'protocollodockind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'protocollodockindsegview' WHERE listtype = 'seg' AND tablename = 'protocollodockind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','protocollodockind',null,null,null,null,'seg','protocollodockindsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'protocollorifkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'protocollorifkindsegview' WHERE listtype = 'seg' AND tablename = 'protocollorifkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','protocollorifkind',null,null,null,null,'seg','protocollorifkindsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'aula' AND tablename = 'prova')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'aula',newtablename = 'provaaulaview' WHERE listtype = 'aula' AND tablename = 'prova'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('aula','prova',null,null,null,null,'aula','provaaulaview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'prova')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'provadefaultview' WHERE listtype = 'default' AND tablename = 'prova'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','prova',null,null,null,null,'default','provadefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'prova')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'dotmas',newtablename = 'provadotmasview' WHERE listtype = 'dotmas' AND tablename = 'prova'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('dotmas','prova',null,null,null,null,'dotmas','provadotmasview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'prova')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'ingresso',newtablename = 'provaingressoview' WHERE listtype = 'ingresso' AND tablename = 'prova'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('ingresso','prova',null,null,null,null,'ingresso','provaingressoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'prova')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'stato',newtablename = 'provastatoview' WHERE listtype = 'stato' AND tablename = 'prova'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('stato','prova',null,null,null,null,'stato','provastatoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'publicaz')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'publicazdefaultview' WHERE listtype = 'default' AND tablename = 'publicaz'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','publicaz',null,null,null,null,'default','publicazdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'docenti' AND tablename = 'publicaz')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'docenti',newtablename = 'publicazdocentiview' WHERE listtype = 'docenti' AND tablename = 'publicaz'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('docenti','publicaz',null,null,null,null,'docenti','publicazdocentiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'publicazkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'publicazkinddefaultview' WHERE listtype = 'default' AND tablename = 'publicazkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','publicazkind',null,null,null,null,'default','publicazkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'questionario')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'questionariodefaultview' WHERE listtype = 'default' AND tablename = 'questionario'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','questionario',null,null,null,null,'default','questionariodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'questionariodomkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'questionariodomkinddefaultview' WHERE listtype = 'default' AND tablename = 'questionariodomkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','questionariodomkind',null,null,null,null,'default','questionariodomkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'questionariokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'questionariokinddefaultview' WHERE listtype = 'default' AND tablename = 'questionariokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','questionariokind',null,null,null,null,'default','questionariokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ratadef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'ratadefdefaultview' WHERE listtype = 'default' AND tablename = 'ratadef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','ratadef',null,null,null,null,'default','ratadefdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'more' AND tablename = 'ratadef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'more',newtablename = 'ratadefmoreview' WHERE listtype = 'more' AND tablename = 'ratadef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('more','ratadef',null,null,null,null,'more','ratadefmoreview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'sconti' AND tablename = 'ratadef')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'sconti',newtablename = 'ratadefscontiview' WHERE listtype = 'sconti' AND tablename = 'ratadef'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('sconti','ratadef',null,null,null,null,'sconti','ratadefscontiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ratakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'ratakinddefaultview' WHERE listtype = 'default' AND tablename = 'ratakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','ratakind',null,null,null,null,'default','ratakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'amministrativi' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'amministrativi',newtablename = 'registryamministrativiview' WHERE listtype = 'amministrativi' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('amministrativi','registry',null,null,null,null,'amministrativi','registryamministrativiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'amministrativi_personale' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'amministrativi_personale',newtablename = 'registryamministrativi_personaleview' WHERE listtype = 'amministrativi_personale' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('amministrativi_personale','registry',null,null,null,null,'amministrativi_personale','registryamministrativi_personaleview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'aziende' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'aziende',newtablename = 'registryaziendeview' WHERE listtype = 'aziende' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('aziende','registry',null,null,null,null,'aziende','registryaziendeview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'docenti' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'docenti',newtablename = 'registrydocentiview' WHERE listtype = 'docenti' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('docenti','registry',null,null,null,null,'docenti','registrydocentiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'docenti_doc' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'docenti_doc',newtablename = 'registrydocenti_docview' WHERE listtype = 'docenti_doc' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('docenti_doc','registry',null,null,null,null,'docenti_doc','registrydocenti_docview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'istituti' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'istituti',newtablename = 'registryistitutiview' WHERE listtype = 'istituti' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('istituti','registry',null,null,null,null,'istituti','registryistitutiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'istituti_princ' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'istituti_princ',newtablename = 'registryistituti_princview' WHERE listtype = 'istituti_princ' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('istituti_princ','registry',null,null,null,null,'istituti_princ','registryistituti_princview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'istitutiesteri' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'istitutiesteri',newtablename = 'registryistitutiesteriview' WHERE listtype = 'istitutiesteri' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('istitutiesteri','registry',null,null,null,null,'istitutiesteri','registryistitutiesteriview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'studenti' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'studenti',newtablename = 'registrystudentiview' WHERE listtype = 'studenti' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('studenti','registry',null,null,null,null,'studenti','registrystudentiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'user' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'user',newtablename = 'registryuserview' WHERE listtype = 'user' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('user','registry',null,null,null,null,'user','registryuserview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'registryaddress')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'registryaddresssegview' WHERE listtype = 'seg' AND tablename = 'registryaddress'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','registryaddress',null,null,null,null,'seg','registryaddresssegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segistituti' AND tablename = 'registryaddress')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segistituti',newtablename = 'registryaddresssegistitutiview' WHERE listtype = 'segistituti' AND tablename = 'registryaddress'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segistituti','registryaddress',null,null,null,null,'segistituti','registryaddresssegistitutiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'user' AND tablename = 'registryaddress')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'user',newtablename = 'registryaddressuserview' WHERE listtype = 'user' AND tablename = 'registryaddress'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('user','registryaddress',null,null,null,null,'user','registryaddressuserview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'aziende' AND tablename = 'registryclass')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'aziende',newtablename = 'registryclassaziendeview' WHERE listtype = 'aziende' AND tablename = 'registryclass'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('aziende','registryclass',null,null,null,null,'aziende','registryclassaziendeview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'persone' AND tablename = 'registryclass')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'persone',newtablename = 'registryclasspersoneview' WHERE listtype = 'persone' AND tablename = 'registryclass'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('persone','registryclass',null,null,null,null,'persone','registryclasspersoneview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'registryprogfin')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'registryprogfinsegview' WHERE listtype = 'seg' AND tablename = 'registryprogfin'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','registryprogfin',null,null,null,null,'seg','registryprogfinsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'registryprogfinbando')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'registryprogfinbandosegview' WHERE listtype = 'seg' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','registryprogfinbando',null,null,null,null,'seg','registryprogfinbandosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'rendicontaltrokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'rendicontaltrokinddefaultview' WHERE listtype = 'default' AND tablename = 'rendicontaltrokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','rendicontaltrokind',null,null,null,null,'default','rendicontaltrokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'anag' AND tablename = 'rendicontattivitaprogetto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'anag',newtablename = 'rendicontattivitaprogettoanagview' WHERE listtype = 'anag' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('anag','rendicontattivitaprogetto',null,null,null,null,'anag','rendicontattivitaprogettoanagview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'anagamm' AND tablename = 'rendicontattivitaprogetto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'anagamm',newtablename = 'rendicontattivitaprogettoanagammview' WHERE listtype = 'anagamm' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('anagamm','rendicontattivitaprogetto',null,null,null,null,'anagamm','rendicontattivitaprogettoanagammview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'doc' AND tablename = 'rendicontattivitaprogetto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'doc',newtablename = 'rendicontattivitaprogettodocview' WHERE listtype = 'doc' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('doc','rendicontattivitaprogetto',null,null,null,null,'doc','rendicontattivitaprogettodocview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'rendicontattivitaprogetto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'rendicontattivitaprogettosegview' WHERE listtype = 'seg' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','rendicontattivitaprogetto',null,null,null,null,'seg','rendicontattivitaprogettosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sal')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'saldefaultview' WHERE listtype = 'default' AND tablename = 'sal'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sal',null,null,null,null,'default','saldefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sasd')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sasddefaultview' WHERE listtype = 'default' AND tablename = 'sasd'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sasd',null,null,null,null,'default','sasddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sasdgruppo')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sasdgruppodefaultview' WHERE listtype = 'default' AND tablename = 'sasdgruppo'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sasdgruppo',null,null,null,null,'default','sasdgruppodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sede')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sededefaultview' WHERE listtype = 'default' AND tablename = 'sede'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sede',null,null,null,null,'default','sededefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'sede')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg_child',newtablename = 'sedeseg_childview' WHERE listtype = 'seg_child' AND tablename = 'sede'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg_child','sede',null,null,null,null,'seg_child','sedeseg_childview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg_child_azienda' AND tablename = 'sede')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg_child_azienda',newtablename = 'sedeseg_child_aziendaview' WHERE listtype = 'seg_child_azienda' AND tablename = 'sede'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg_child_azienda','sede',null,null,null,null,'seg_child_azienda','sedeseg_child_aziendaview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sessione')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sessionedefaultview' WHERE listtype = 'default' AND tablename = 'sessione'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sessione',null,null,null,null,'default','sessionedefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sessionekind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sessionekinddefaultview' WHERE listtype = 'default' AND tablename = 'sessionekind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sessionekind',null,null,null,null,'default','sessionekinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'settoreerc')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'settoreercsegview' WHERE listtype = 'seg' AND tablename = 'settoreerc'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','settoreerc',null,null,null,null,'seg','settoreercsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segprog' AND tablename = 'settoreerc')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segprog',newtablename = 'settoreercsegprogview' WHERE listtype = 'segprog' AND tablename = 'settoreerc'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segprog','settoreerc',null,null,null,null,'segprog','settoreercsegprogview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'treeusable' AND tablename = 'sorting')
UPDATE [web_listredir] SET ct = {ts '2018-07-31 10:32:50.150'},cu = 'sa',lt = {ts '2018-07-31 10:32:50.150'},lu = 'sa',newlisttype = 'tree',newtablename = 'sortingusable' WHERE listtype = 'treeusable' AND tablename = 'sorting'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('treeusable','sorting',{ts '2018-07-31 10:32:50.150'},'sa',{ts '2018-07-31 10:32:50.150'},'sa','tree','sortingusable')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sostenimentodefaultview' WHERE listtype = 'default' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sostenimento',null,null,null,null,'default','sostenimentodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'didprog' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'didprog',newtablename = 'sostenimentodidprogview' WHERE listtype = 'didprog' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('didprog','sostenimento',null,null,null,null,'didprog','sostenimentodidprogview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'ingresso',newtablename = 'sostenimentoingressoview' WHERE listtype = 'ingresso' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('ingresso','sostenimento',null,null,null,null,'ingresso','sostenimentoingressoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstu' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstu',newtablename = 'sostenimentoseganagstuview' WHERE listtype = 'seganagstu' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstu','sostenimento',null,null,null,null,'seganagstu','sostenimentoseganagstuview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstuacc' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstuacc',newtablename = 'sostenimentoseganagstuaccview' WHERE listtype = 'seganagstuacc' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstuacc','sostenimento',null,null,null,null,'seganagstuacc','sostenimentoseganagstuaccview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstuconsmast' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstuconsmast',newtablename = 'sostenimentoseganagstuconsmastview' WHERE listtype = 'seganagstuconsmast' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstuconsmast','sostenimento',null,null,null,null,'seganagstuconsmast','sostenimentoseganagstuconsmastview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstusing' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstusing',newtablename = 'sostenimentoseganagstusingview' WHERE listtype = 'seganagstusing' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstusing','sostenimento',null,null,null,null,'seganagstusing','sostenimentoseganagstusingview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seganagstustato' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seganagstustato',newtablename = 'sostenimentoseganagstustatoview' WHERE listtype = 'seganagstustato' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seganagstustato','sostenimento',null,null,null,null,'seganagstustato','sostenimentoseganagstustatoview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segcons' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segcons',newtablename = 'sostenimentosegconsview' WHERE listtype = 'segcons' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segcons','sostenimento',null,null,null,null,'segcons','sostenimentosegconsview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segstud' AND tablename = 'sostenimento')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segstud',newtablename = 'sostenimentosegstudview' WHERE listtype = 'segstud' AND tablename = 'sostenimento'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segstud','sostenimento',null,null,null,null,'segstud','sostenimentosegstudview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sostenimentoesito')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'sostenimentoesitodefaultview' WHERE listtype = 'default' AND tablename = 'sostenimentoesito'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','sostenimentoesito',null,null,null,null,'default','sostenimentoesitodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'stipendiokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'stipendiokinddefaultview' WHERE listtype = 'default' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','stipendiokind',null,null,null,null,'default','stipendiokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'struttura')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'strutturadefaultview' WHERE listtype = 'default' AND tablename = 'struttura'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','struttura',null,null,null,null,'default','strutturadefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'princ' AND tablename = 'struttura')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'princ',newtablename = 'strutturaprincview' WHERE listtype = 'princ' AND tablename = 'struttura'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('princ','struttura',null,null,null,null,'princ','strutturaprincview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'struttura')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg_child',newtablename = 'strutturaseg_childview' WHERE listtype = 'seg_child' AND tablename = 'struttura'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg_child','struttura',null,null,null,null,'seg_child','strutturaseg_childview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'strutturakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'strutturakinddefaultview' WHERE listtype = 'default' AND tablename = 'strutturakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','strutturakind',null,null,null,null,'default','strutturakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'studdirittokind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'studdirittokinddefaultview' WHERE listtype = 'default' AND tablename = 'studdirittokind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','studdirittokind',null,null,null,null,'default','studdirittokinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'studprenotkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'studprenotkinddefaultview' WHERE listtype = 'default' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','studprenotkind',null,null,null,null,'default','studprenotkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaconf')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tassaconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassaconf'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tassaconf',null,null,null,null,'default','tassaconfdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaconfkind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tassaconfkinddefaultview' WHERE listtype = 'default' AND tablename = 'tassaconfkind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tassaconfkind',null,null,null,null,'default','tassaconfkinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassacsingconf')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tassacsingconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassacsingconf'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tassacsingconf',null,null,null,null,'default','tassacsingconfdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaiscrizioneconf')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tassaiscrizioneconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tassaiscrizioneconf',null,null,null,null,'default','tassaiscrizioneconfdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaistanzaconf')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tassaistanzaconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassaistanzaconf'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tassaistanzaconf',null,null,null,null,'default','tassaistanzaconfdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tax')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'taxsegview' WHERE listtype = 'seg' AND tablename = 'tax'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','tax',null,null,null,null,'seg','taxsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tipoattform')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tipoattformdefaultview' WHERE listtype = 'default' AND tablename = 'tipoattform'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tipoattform',null,null,null,null,'default','tipoattformdefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tipologiastudente')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'tipologiastudentesegview' WHERE listtype = 'seg' AND tablename = 'tipologiastudente'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','tipologiastudente',null,null,null,null,'seg','tipologiastudentesegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tirociniocandidaturakind')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tirociniocandidaturakinddefaultview' WHERE listtype = 'default' AND tablename = 'tirociniocandidaturakind'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tirociniocandidaturakind',null,null,null,null,'default','tirociniocandidaturakinddefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tirocinioprogetto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'tirocinioprogettosegview' WHERE listtype = 'seg' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','tirocinioprogetto',null,null,null,null,'seg','tirocinioprogettosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tirocinioproposto')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'tirociniopropostosegview' WHERE listtype = 'seg' AND tablename = 'tirocinioproposto'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','tirocinioproposto',null,null,null,null,'seg','tirociniopropostosegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tirociniostato')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'tirociniostatodefaultview' WHERE listtype = 'default' AND tablename = 'tirociniostato'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','tirociniostato',null,null,null,null,'default','tirociniostatodefaultview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'docenti' AND tablename = 'titolostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'docenti',newtablename = 'titolostudiodocentiview' WHERE listtype = 'docenti' AND tablename = 'titolostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('docenti','titolostudio',null,null,null,null,'docenti','titolostudiodocentiview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'segtitolo' AND tablename = 'titolostudio')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'segtitolo',newtablename = 'titolostudiosegtitoloview' WHERE listtype = 'segtitolo' AND tablename = 'titolostudio'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('segtitolo','titolostudio',null,null,null,null,'segtitolo','titolostudiosegtitoloview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'upb')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'upbsegview' WHERE listtype = 'seg' AND tablename = 'upb'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','upb',null,null,null,null,'seg','upbsegview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'workpackage')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'seg',newtablename = 'workpackagesegview' WHERE listtype = 'seg' AND tablename = 'workpackage'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('seg','workpackage',null,null,null,null,'seg','workpackagesegview')
GO

 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'progetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'progettosegview' WHERE listtype = 'seg' AND tablename = 'progetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progetto', 'seg', 'progettosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstusonpre' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstusonpre', newtablename = 'istanzaseganagstusonpreview' WHERE listtype = 'seganagstusonpre' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'seganagstusonpre', 'istanzaseganagstusonpreview', 'seganagstusonpre', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seganagstupre' AND tablename = 'nullaosta')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seganagstupre', newtablename = 'nullaostaimm_seganagstupreview' WHERE listtype = 'imm_seganagstupre' AND tablename = 'nullaosta'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagstupre', 'nullaostaimm_seganagstupreview', 'imm_seganagstupre', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'didprog' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'didprog', newtablename = 'sostenimentodidprogview' WHERE listtype = 'didprog' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'didprog', 'sostenimentodidprogview', 'didprog', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'registryaddress')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'registryaddresssegview' WHERE listtype = 'seg' AND tablename = 'registryaddress'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryaddress', 'seg', 'registryaddresssegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg5' AND tablename = 'geo_city')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg5', newtablename = 'geo_cityseg5view' WHERE listtype = 'seg5' AND tablename = 'geo_city'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'seg5', 'geo_cityseg5view', 'seg5', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'amministrativi_personale' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'amministrativi_personale', newtablename = 'registryamministrativi_personaleview' WHERE listtype = 'amministrativi_personale' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'amministrativi_personale', 'registryamministrativi_personaleview', 'amministrativi_personale', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sal')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'saldefaultview' WHERE listtype = 'default' AND tablename = 'sal'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sal', 'default', 'saldefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'doc' AND tablename = 'assetdiary')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'doc', newtablename = 'assetdiarydocview' WHERE listtype = 'doc' AND tablename = 'assetdiary'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetdiary', 'doc', 'assetdiarydocview', 'doc', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'doc' AND tablename = 'rendicontattivitaprogetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'doc', newtablename = 'rendicontattivitaprogettodocview' WHERE listtype = 'doc' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'doc', 'rendicontattivitaprogettodocview', 'doc', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'doc' AND tablename = 'affidamento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'doc', newtablename = 'affidamentodocview' WHERE listtype = 'doc' AND tablename = 'affidamento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'doc', 'affidamentodocview', 'doc', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'docenti_doc' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'docenti_doc', newtablename = 'registrydocenti_docview' WHERE listtype = 'docenti_doc' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'docenti_doc', 'registrydocenti_docview', 'docenti_doc', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'progettoudrmembrokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'progettoudrmembrokinddefaultview' WHERE listtype = 'default' AND tablename = 'progettoudrmembrokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoudrmembrokind', 'default', 'progettoudrmembrokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'assetacquire')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'assetacquiresegview' WHERE listtype = 'seg' AND tablename = 'assetacquire'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetacquire', 'seg', 'assetacquiresegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'accmotive')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'accmotivedefaultview' WHERE listtype = 'default' AND tablename = 'accmotive'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accmotive', 'default', 'accmotivedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getregistrydocentiamministrativi')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'getregistrydocentiamministratividefaultview' WHERE listtype = 'default' AND tablename = 'getregistrydocentiamministrativi'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getregistrydocentiamministrativi', 'default', 'getregistrydocentiamministratividefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'getcostididattica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'getcostididatticadefaultview' WHERE listtype = 'default' AND tablename = 'getcostididattica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getcostididattica', 'default', 'getcostididatticadefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'getdocentiperssd')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'getdocentiperssdsegview' WHERE listtype = 'seg' AND tablename = 'getdocentiperssd'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getdocentiperssd', 'seg', 'getdocentiperssdsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'delibera')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'deliberasegview' WHERE listtype = 'seg' AND tablename = 'delibera'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('delibera', 'seg', 'deliberasegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'istanzaattach')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'istanzaattachsegview' WHERE listtype = 'seg' AND tablename = 'istanzaattach'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanzaattach', 'seg', 'istanzaattachsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'cert_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'cert_seg', newtablename = 'istanzacert_segview' WHERE listtype = 'cert_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'cert_seg', 'istanzacert_segview', 'cert_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'sosp_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'sosp_seg', newtablename = 'istanzasosp_segview' WHERE listtype = 'sosp_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'sosp_seg', 'istanzasosp_segview', 'sosp_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'tru_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'tru_seg', newtablename = 'istanzatru_segview' WHERE listtype = 'tru_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'tru_seg', 'istanzatru_segview', 'tru_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'eq_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'eq_seg', newtablename = 'istanzaeq_segview' WHERE listtype = 'eq_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'eq_seg', 'istanzaeq_segview', 'eq_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'titolo_seg' AND tablename = 'dichiar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'titolo_seg', newtablename = 'dichiartitolo_segview' WHERE listtype = 'titolo_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'titolo_seg', 'dichiartitolo_segview', 'titolo_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiaraltrekind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'dichiaraltrekinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiaraltrekind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiaraltrekind', 'default', 'dichiaraltrekinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segcons' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segcons', newtablename = 'sostenimentosegconsview' WHERE listtype = 'segcons' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'segcons', 'sostenimentosegconsview', 'segcons', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiardisabilsuppkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'dichiardisabilsuppkinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiardisabilsuppkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiardisabilsuppkind', 'default', 'dichiardisabilsuppkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiardisabilkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'dichiardisabilkinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiardisabilkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiardisabilkind', 'default', 'dichiardisabilkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'disabil_seg' AND tablename = 'dichiar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'disabil_seg', newtablename = 'dichiardisabil_segview' WHERE listtype = 'disabil_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'disabil_seg', 'dichiardisabil_segview', 'disabil_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'altre_seg' AND tablename = 'dichiar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'altre_seg', newtablename = 'dichiaraltre_segview' WHERE listtype = 'altre_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'altre_seg', 'dichiaraltre_segview', 'altre_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'altrititoli_seg' AND tablename = 'dichiar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'altrititoli_seg', newtablename = 'dichiaraltrititoli_segview' WHERE listtype = 'altrititoli_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'altrititoli_seg', 'dichiaraltrititoli_segview', 'altrititoli_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'isee_seg' AND tablename = 'dichiar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'isee_seg', newtablename = 'dichiarisee_segview' WHERE listtype = 'isee_seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'isee_seg', 'dichiarisee_segview', 'isee_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'bandodsiscresitokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'bandodsiscresitokinddefaultview' WHERE listtype = 'default' AND tablename = 'bandodsiscresitokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandodsiscresitokind', 'default', 'bandodsiscresitokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'accreditokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'accreditokinddefaultview' WHERE listtype = 'default' AND tablename = 'accreditokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accreditokind', 'default', 'accreditokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'bandodsservizio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'bandodsserviziosegview' WHERE listtype = 'seg' AND tablename = 'bandodsservizio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandodsservizio', 'seg', 'bandodsserviziosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'bandods')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'bandodssegview' WHERE listtype = 'seg' AND tablename = 'bandods'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandods', 'seg', 'bandodssegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'learningagrstud')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'learningagrstudsegview' WHERE listtype = 'seg' AND tablename = 'learningagrstud'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('learningagrstud', 'seg', 'learningagrstudsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'assicurazione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'assicurazionedefaultview' WHERE listtype = 'default' AND tablename = 'assicurazione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assicurazione', 'default', 'assicurazionedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'bandomobilitaintkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'bandomobilitaintkinddefaultview' WHERE listtype = 'default' AND tablename = 'bandomobilitaintkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandomobilitaintkind', 'default', 'bandomobilitaintkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'cefr')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'cefrdefaultview' WHERE listtype = 'default' AND tablename = 'cefr'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('cefr', 'default', 'cefrdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'accordoscambiomidett')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'accordoscambiomidettsegview' WHERE listtype = 'seg' AND tablename = 'accordoscambiomidett'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accordoscambiomidett', 'seg', 'accordoscambiomidettsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'iscrizionebmi')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'iscrizionebmisegview' WHERE listtype = 'seg' AND tablename = 'iscrizionebmi'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizionebmi', 'seg', 'iscrizionebmisegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'bandomi')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'bandomisegview' WHERE listtype = 'seg' AND tablename = 'bandomi'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandomi', 'seg', 'bandomisegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'accordoscambiomidettaz')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'accordoscambiomidettazsegview' WHERE listtype = 'seg' AND tablename = 'accordoscambiomidettaz'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accordoscambiomidettaz', 'seg', 'accordoscambiomidettazsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'accordoscambiomi')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'accordoscambiomisegview' WHERE listtype = 'seg' AND tablename = 'accordoscambiomi'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accordoscambiomi', 'seg', 'accordoscambiomisegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'location')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'locationdefaultview' WHERE listtype = 'default' AND tablename = 'location'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('location', 'default', 'locationdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'inventorytree')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'inventorytreesegview' WHERE listtype = 'seg' AND tablename = 'inventorytree'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inventorytree', 'seg', 'inventorytreesegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'naturagiur')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'naturagiurdefaultview' WHERE listtype = 'default' AND tablename = 'naturagiur'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('naturagiur', 'default', 'naturagiurdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'duratakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'duratakinddefaultview' WHERE listtype = 'default' AND tablename = 'duratakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('duratakind', 'default', 'duratakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'inquadramento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'inquadramentodefaultview' WHERE listtype = 'default' AND tablename = 'inquadramento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inquadramento', 'default', 'inquadramentodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'stipendiokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'stipendiokinddefaultview' WHERE listtype = 'default' AND tablename = 'stipendiokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('stipendiokind', 'default', 'stipendiokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tirocinioprogetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'tirocinioprogettosegview' WHERE listtype = 'seg' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirocinioprogetto', 'seg', 'tirocinioprogettosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'prova')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'dotmas', newtablename = 'provadotmasview' WHERE listtype = 'dotmas' AND tablename = 'prova'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'dotmas', 'provadotmasview', 'dotmas', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'prova')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'stato', newtablename = 'provastatoview' WHERE listtype = 'stato' AND tablename = 'prova'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'stato', 'provastatoview', 'stato', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tirocinioproposto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'tirociniopropostosegview' WHERE listtype = 'seg' AND tablename = 'tirocinioproposto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirocinioproposto', 'seg', 'tirociniopropostosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'convenzione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'convenzionesegview' WHERE listtype = 'seg' AND tablename = 'convenzione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('convenzione', 'seg', 'convenzionesegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'changeskind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'changeskinddefaultview' WHERE listtype = 'default' AND tablename = 'changeskind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('changeskind', 'default', 'changeskinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segstud' AND tablename = 'pratica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segstud', newtablename = 'praticasegstudview' WHERE listtype = 'segstud' AND tablename = 'pratica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pratica', 'segstud', 'praticasegstudview', 'segstud', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'pettycash')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'pettycashsegview' WHERE listtype = 'seg' AND tablename = 'pettycash'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pettycash', 'seg', 'pettycashsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'expense')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'expensesegview' WHERE listtype = 'seg' AND tablename = 'expense'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('expense', 'seg', 'expensesegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'decadenza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'decadenzasegview' WHERE listtype = 'seg' AND tablename = 'decadenza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('decadenza', 'seg', 'decadenzasegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'itineration')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'itinerationsegview' WHERE listtype = 'seg' AND tablename = 'itineration'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('itineration', 'seg', 'itinerationsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'tax')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'taxsegview' WHERE listtype = 'seg' AND tablename = 'tax'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tax', 'seg', 'taxsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segprog' AND tablename = 'settoreerc')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segprog', newtablename = 'settoreercsegprogview' WHERE listtype = 'segprog' AND tablename = 'settoreerc'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('settoreerc', 'segprog', 'settoreercsegprogview', 'segprog', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'settoreerc')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'settoreercsegview' WHERE listtype = 'seg' AND tablename = 'settoreerc'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('settoreerc', 'seg', 'settoreercsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'registryprogfinbando')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'registryprogfinbandosegview' WHERE listtype = 'seg' AND tablename = 'registryprogfinbando'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryprogfinbando', 'seg', 'registryprogfinbandosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'registryprogfin')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'registryprogfinsegview' WHERE listtype = 'seg' AND tablename = 'registryprogfin'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryprogfin', 'seg', 'registryprogfinsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'upb')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'upbsegview' WHERE listtype = 'seg' AND tablename = 'upb'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('upb', 'seg', 'upbsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'accmotive')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'accmotivesegview' WHERE listtype = 'seg' AND tablename = 'accmotive'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accmotive', 'seg', 'accmotivesegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'progettoactivitykind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'progettoactivitykinddefaultview' WHERE listtype = 'default' AND tablename = 'progettoactivitykind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoactivitykind', 'default', 'progettoactivitykinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'asset')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'assetsegview' WHERE listtype = 'seg' AND tablename = 'asset'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('asset', 'seg', 'assetsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'anagamm' AND tablename = 'rendicontattivitaprogetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'anagamm', newtablename = 'rendicontattivitaprogettoanagammview' WHERE listtype = 'anagamm' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'anagamm', 'rendicontattivitaprogettoanagammview', 'anagamm', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'anag' AND tablename = 'rendicontattivitaprogetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'anag', newtablename = 'rendicontattivitaprogettoanagview' WHERE listtype = 'anag' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'anag', 'rendicontattivitaprogettoanagview', 'anag', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'amministrativi' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'amministrativi', newtablename = 'registryamministrativiview' WHERE listtype = 'amministrativi' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'amministrativi', 'registryamministrativiview', 'amministrativi', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'fonteindicebibliometrico')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'fonteindicebibliometricosegview' WHERE listtype = 'seg' AND tablename = 'fonteindicebibliometrico'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fonteindicebibliometrico', 'seg', 'fonteindicebibliometricosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'progettokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'progettokindsegview' WHERE listtype = 'seg' AND tablename = 'progettokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettokind', 'seg', 'progettokindsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'orakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'orakindsegview' WHERE listtype = 'seg' AND tablename = 'orakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('orakind', 'seg', 'orakindsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'rendicontattivitaprogetto')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'rendicontattivitaprogettosegview' WHERE listtype = 'seg' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'seg', 'rendicontattivitaprogettosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'workpackage')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'workpackagesegview' WHERE listtype = 'seg' AND tablename = 'workpackage'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('workpackage', 'seg', 'workpackagesegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ambitoareadisc')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'ambitoareadiscdefaultview' WHERE listtype = 'default' AND tablename = 'ambitoareadisc'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ambitoareadisc', 'default', 'ambitoareadiscdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'classescuolakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'classescuolakinddefaultview' WHERE listtype = 'default' AND tablename = 'classescuolakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classescuolakind', 'default', 'classescuolakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sasdgruppo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sasdgruppodefaultview' WHERE listtype = 'default' AND tablename = 'sasdgruppo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasdgruppo', 'default', 'sasdgruppodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seganagsturin' AND tablename = 'nullaosta')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seganagsturin', newtablename = 'nullaostaimm_seganagsturinview' WHERE listtype = 'imm_seganagsturin' AND tablename = 'nullaosta'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagsturin', 'nullaostaimm_seganagsturinview', 'imm_seganagsturin', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seganagstu' AND tablename = 'nullaosta')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seganagstu', newtablename = 'nullaostaimm_seganagstuview' WHERE listtype = 'imm_seganagstu' AND tablename = 'nullaosta'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagstu', 'nullaostaimm_seganagstuview', 'imm_seganagstu', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstustato' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstustato', newtablename = 'sostenimentoseganagstustatoview' WHERE listtype = 'seganagstustato' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstustato', 'sostenimentoseganagstustatoview', 'seganagstustato', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstuconsmast' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstuconsmast', newtablename = 'sostenimentoseganagstuconsmastview' WHERE listtype = 'seganagstuconsmast' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstuconsmast', 'sostenimentoseganagstuconsmastview', 'seganagstuconsmast', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstuacc' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstuacc', newtablename = 'sostenimentoseganagstuaccview' WHERE listtype = 'seganagstuacc' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstuacc', 'sostenimentoseganagstuaccview', 'seganagstuacc', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'iscrizionedefaultview' WHERE listtype = 'default' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'default', 'iscrizionedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstu' AND tablename = 'pratica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstu', newtablename = 'praticaseganagstuview' WHERE listtype = 'seganagstu' AND tablename = 'pratica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pratica', 'seganagstu', 'praticaseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'sceltacorso' AND tablename = 'didprogori')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'sceltacorso', newtablename = 'didprogorisceltacorsoview' WHERE listtype = 'sceltacorso' AND tablename = 'didprogori'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogori', 'sceltacorso', 'didprogorisceltacorsoview', 'sceltacorso', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'dichiarkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'dichiarkinddefaultview' WHERE listtype = 'default' AND tablename = 'dichiarkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiarkind', 'default', 'dichiarkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'dichiar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'dichiarsegview' WHERE listtype = 'seg' AND tablename = 'dichiar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'seg', 'dichiarsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seganagsturin' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seganagsturin', newtablename = 'istanzaimm_seganagsturinview' WHERE listtype = 'imm_seganagsturin' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagsturin', 'istanzaimm_seganagsturinview', 'imm_seganagsturin', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_segrin' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_segrin', newtablename = 'istanzaimm_segrinview' WHERE listtype = 'imm_segrin' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_segrin', 'istanzaimm_segrinview', 'imm_segrin', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seg' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seg', newtablename = 'istanzaimm_segview' WHERE listtype = 'imm_seg' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seg', 'istanzaimm_segview', 'imm_seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seganagstu' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seganagstu', newtablename = 'istanzaimm_seganagstuview' WHERE listtype = 'imm_seganagstu' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagstu', 'istanzaimm_seganagstuview', 'imm_seganagstu', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_segpre' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_segpre', newtablename = 'istanzaimm_segpreview' WHERE listtype = 'imm_segpre' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_segpre', 'istanzaimm_segpreview', 'imm_segpre', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'protocollorifkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'protocollorifkindsegview' WHERE listtype = 'seg' AND tablename = 'protocollorifkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollorifkind', 'seg', 'protocollorifkindsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'protocollodockind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'protocollodockindsegview' WHERE listtype = 'seg' AND tablename = 'protocollodockind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollodockind', 'seg', 'protocollodockindsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'protocollo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'protocollosegview' WHERE listtype = 'seg' AND tablename = 'protocollo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollo', 'seg', 'protocollosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'imm_seganagstupre' AND tablename = 'istanza')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'imm_seganagstupre', newtablename = 'istanzaimm_seganagstupreview' WHERE listtype = 'imm_seganagstupre' AND tablename = 'istanza'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagstupre', 'istanzaimm_seganagstupreview', 'imm_seganagstupre', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ateco')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'atecodefaultview' WHERE listtype = 'default' AND tablename = 'ateco'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ateco', 'default', 'atecodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'nace')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'nacedefaultview' WHERE listtype = 'default' AND tablename = 'nace'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nace', 'default', 'nacedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstusing' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstusing', newtablename = 'sostenimentoseganagstusingview' WHERE listtype = 'seganagstusing' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstusing', 'sostenimentoseganagstusingview', 'seganagstusing', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segstud' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segstud', newtablename = 'sostenimentosegstudview' WHERE listtype = 'segstud' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'segstud', 'sostenimentosegstudview', 'segstud', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstusing' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstusing', newtablename = 'iscrizioneseganagstusingview' WHERE listtype = 'seganagstusing' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstusing', 'iscrizioneseganagstusingview', 'seganagstusing', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segstud' AND tablename = 'pianostudio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segstud', newtablename = 'pianostudiosegstudview' WHERE listtype = 'segstud' AND tablename = 'pianostudio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pianostudio', 'segstud', 'pianostudiosegstudview', 'segstud', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'didprog' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'didprog', newtablename = 'iscrizionedidprogview' WHERE listtype = 'didprog' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'didprog', 'iscrizionedidprogview', 'didprog', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'iscrizionesegview' WHERE listtype = 'seg' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seg', 'iscrizionesegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'stato', newtablename = 'iscrizionestatoview' WHERE listtype = 'stato' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'stato', 'iscrizionestatoview', 'stato', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'dotmas', newtablename = 'iscrizionedotmasview' WHERE listtype = 'dotmas' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'dotmas', 'iscrizionedotmasview', 'dotmas', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'didprog')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'stato', newtablename = 'didprogstatoview' WHERE listtype = 'stato' AND tablename = 'didprog'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'stato', 'didprogstatoview', 'stato', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'stato' AND tablename = 'corsostudio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'stato', newtablename = 'corsostudiostatoview' WHERE listtype = 'stato' AND tablename = 'corsostudio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'stato', 'corsostudiostatoview', 'stato', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'didprog')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'dotmas', newtablename = 'didprogdotmasview' WHERE listtype = 'dotmas' AND tablename = 'didprog'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'dotmas', 'didprogdotmasview', 'dotmas', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'dotmas' AND tablename = 'corsostudio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'dotmas', newtablename = 'corsostudiodotmasview' WHERE listtype = 'dotmas' AND tablename = 'corsostudio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'dotmas', 'corsostudiodotmasview', 'dotmas', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'pianostudiostatus')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'pianostudiostatusdefaultview' WHERE listtype = 'default' AND tablename = 'pianostudiostatus'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pianostudiostatus', 'default', 'pianostudiostatusdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'ingresso', newtablename = 'iscrizioneingressoview' WHERE listtype = 'ingresso' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'ingresso', 'iscrizioneingressoview', 'ingresso', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstu' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstu', newtablename = 'sostenimentoseganagstuview' WHERE listtype = 'seganagstu' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstu', 'sostenimentoseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstustato' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstustato', newtablename = 'iscrizioneseganagstustatoview' WHERE listtype = 'seganagstustato' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstustato', 'iscrizioneseganagstustatoview', 'seganagstustato', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstumast' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstumast', newtablename = 'iscrizioneseganagstumastview' WHERE listtype = 'seganagstumast' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstumast', 'iscrizioneseganagstumastview', 'seganagstumast', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstuacc' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstuacc', newtablename = 'iscrizioneseganagstuaccview' WHERE listtype = 'seganagstuacc' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstuacc', 'iscrizioneseganagstuaccview', 'seganagstuacc', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'ingresso', newtablename = 'sostenimentoingressoview' WHERE listtype = 'ingresso' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'ingresso', 'sostenimentoingressoview', 'ingresso', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sostenimentoesito')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sostenimentoesitodefaultview' WHERE listtype = 'default' AND tablename = 'sostenimentoesito'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimentoesito', 'default', 'sostenimentoesitodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seganagstu' AND tablename = 'iscrizione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seganagstu', newtablename = 'iscrizioneseganagstuview' WHERE listtype = 'seganagstu' AND tablename = 'iscrizione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstu', 'iscrizioneseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sostenimento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sostenimentodefaultview' WHERE listtype = 'default' AND tablename = 'sostenimento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'default', 'sostenimentodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'appello' AND tablename = 'attivform')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'appello', newtablename = 'attivformappelloview' WHERE listtype = 'appello' AND tablename = 'attivform'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'appello', 'attivformappelloview', 'appello', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'appelloazionekind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'appelloazionekinddefaultview' WHERE listtype = 'default' AND tablename = 'appelloazionekind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appelloazionekind', 'default', 'appelloazionekinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ofakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'ofakinddefaultview' WHERE listtype = 'default' AND tablename = 'ofakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ofakind', 'default', 'ofakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tirociniostato')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tirociniostatodefaultview' WHERE listtype = 'default' AND tablename = 'tirociniostato'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirociniostato', 'default', 'tirociniostatodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tirociniocandidaturakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tirociniocandidaturakinddefaultview' WHERE listtype = 'default' AND tablename = 'tirociniocandidaturakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirociniocandidaturakind', 'default', 'tirociniocandidaturakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'questionariodomkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'questionariodomkinddefaultview' WHERE listtype = 'default' AND tablename = 'questionariodomkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionariodomkind', 'default', 'questionariodomkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'questionariokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'questionariokinddefaultview' WHERE listtype = 'default' AND tablename = 'questionariokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionariokind', 'default', 'questionariokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'istanzakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'istanzakinddefaultview' WHERE listtype = 'default' AND tablename = 'istanzakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanzakind', 'default', 'istanzakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'costoscontodefkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'costoscontodefkinddefaultview' WHERE listtype = 'default' AND tablename = 'costoscontodefkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodefkind', 'default', 'costoscontodefkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'carriera' AND tablename = 'esonero')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'carriera', newtablename = 'esonerocarrieraview' WHERE listtype = 'carriera' AND tablename = 'esonero'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'carriera', 'esonerocarrieraview', 'carriera', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'titolostudio' AND tablename = 'esonero')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'titolostudio', newtablename = 'esonerotitolostudioview' WHERE listtype = 'titolostudio' AND tablename = 'esonero'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'titolostudio', 'esonerotitolostudioview', 'titolostudio', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'disabil' AND tablename = 'esonero')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'disabil', newtablename = 'esonerodisabilview' WHERE listtype = 'disabil' AND tablename = 'esonero'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'disabil', 'esonerodisabilview', 'disabil', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'esonero')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'esonerodefaultview' WHERE listtype = 'default' AND tablename = 'esonero'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'default', 'esonerodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaconf')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tassaconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassaconf'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaconf', 'default', 'tassaconfdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaistanzaconf')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tassaistanzaconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassaistanzaconf'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaistanzaconf', 'default', 'tassaistanzaconfdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaiscrizioneconf')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tassaiscrizioneconfdefaultview' WHERE listtype = 'default' AND tablename = 'tassaiscrizioneconf'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaiscrizioneconf', 'default', 'tassaiscrizioneconfdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tassaconfkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tassaconfkinddefaultview' WHERE listtype = 'default' AND tablename = 'tassaconfkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaconfkind', 'default', 'tassaconfkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'pagamentokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'pagamentokinddefaultview' WHERE listtype = 'default' AND tablename = 'pagamentokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pagamentokind', 'default', 'pagamentokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ratakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'ratakinddefaultview' WHERE listtype = 'default' AND tablename = 'ratakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratakind', 'default', 'ratakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'more' AND tablename = 'ratadef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'more', newtablename = 'ratadefmoreview' WHERE listtype = 'more' AND tablename = 'ratadef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'more', 'ratadefmoreview', 'more', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'more' AND tablename = 'fasciaiseedef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'more', newtablename = 'fasciaiseedefmoreview' WHERE listtype = 'more' AND tablename = 'fasciaiseedef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'more', 'fasciaiseedefmoreview', 'more', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'more' AND tablename = 'costoscontodef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'more', newtablename = 'costoscontodefmoreview' WHERE listtype = 'more' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodef', 'more', 'costoscontodefmoreview', 'more', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'sconti' AND tablename = 'ratadef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'sconti', newtablename = 'ratadefscontiview' WHERE listtype = 'sconti' AND tablename = 'ratadef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'sconti', 'ratadefscontiview', 'sconti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'sconti' AND tablename = 'fasciaiseedef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'sconti', newtablename = 'fasciaiseedefscontiview' WHERE listtype = 'sconti' AND tablename = 'fasciaiseedef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'sconti', 'fasciaiseedefscontiview', 'sconti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'sconti' AND tablename = 'costoscontodef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'sconti', newtablename = 'costoscontodefscontiview' WHERE listtype = 'sconti' AND tablename = 'costoscontodef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodef', 'sconti', 'costoscontodefscontiview', 'sconti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ratadef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'ratadefdefaultview' WHERE listtype = 'default' AND tablename = 'ratadef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'default', 'ratadefdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'fasciaiseedef')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'fasciaiseedefdefaultview' WHERE listtype = 'default' AND tablename = 'fasciaiseedef'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'default', 'fasciaiseedefdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'princ' AND tablename = 'aoo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'princ', newtablename = 'aooprincview' WHERE listtype = 'princ' AND tablename = 'aoo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aoo', 'princ', 'aooprincview', 'princ', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'princ' AND tablename = 'struttura')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'princ', newtablename = 'strutturaprincview' WHERE listtype = 'princ' AND tablename = 'struttura'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'princ', 'strutturaprincview', 'princ', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'istituti_princ' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'istituti_princ', newtablename = 'registryistituti_princview' WHERE listtype = 'istituti_princ' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istituti_princ', 'registryistituti_princview', 'istituti_princ', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'graduatoriavar')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'graduatoriavardefaultview' WHERE listtype = 'default' AND tablename = 'graduatoriavar'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('graduatoriavar', 'default', 'graduatoriavardefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'questionario')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'questionariodefaultview' WHERE listtype = 'default' AND tablename = 'questionario'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionario', 'default', 'questionariodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'proped' AND tablename = 'attivform')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'proped', newtablename = 'attivformpropedview' WHERE listtype = 'proped' AND tablename = 'attivform'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'proped', 'attivformpropedview', 'proped', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'user' AND tablename = 'registryaddress')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'user', newtablename = 'registryaddressuserview' WHERE listtype = 'user' AND tablename = 'registryaddress'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryaddress', 'user', 'registryaddressuserview', 'user', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'user' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'user', newtablename = 'registryuserview' WHERE listtype = 'user' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'user', 'registryuserview', 'user', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'aziende' AND tablename = 'registryclass')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'aziende', newtablename = 'registryclassaziendeview' WHERE listtype = 'aziende' AND tablename = 'registryclass'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'aziende', 'registryclassaziendeview', 'aziende', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'affidamento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'affidamentosegview' WHERE listtype = 'seg' AND tablename = 'affidamento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'seg', 'affidamentosegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'prova')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'provadefaultview' WHERE listtype = 'default' AND tablename = 'prova'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'default', 'provadefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'appellokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'appellokinddefaultview' WHERE listtype = 'default' AND tablename = 'appellokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appellokind', 'default', 'appellokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sessionekind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sessionekinddefaultview' WHERE listtype = 'default' AND tablename = 'sessionekind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sessionekind', 'default', 'sessionekinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sessione')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sessionedefaultview' WHERE listtype = 'default' AND tablename = 'sessione'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sessione', 'default', 'sessionedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'appello')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'appellodefaultview' WHERE listtype = 'default' AND tablename = 'appello'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appello', 'default', 'appellodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'erogazkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'erogazkinddefaultview' WHERE listtype = 'default' AND tablename = 'erogazkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('erogazkind', 'default', 'erogazkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'affidamentokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'affidamentokinddefaultview' WHERE listtype = 'default' AND tablename = 'affidamentokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamentokind', 'default', 'affidamentokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'gruppo' AND tablename = 'attivform')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'gruppo', newtablename = 'attivformgruppoview' WHERE listtype = 'gruppo' AND tablename = 'attivform'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'gruppo', 'attivformgruppoview', 'gruppo', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'appello')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'erogata', newtablename = 'appelloerogataview' WHERE listtype = 'erogata' AND tablename = 'appello'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appello', 'erogata', 'appelloerogataview', 'erogata', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'prova')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'ingresso', newtablename = 'provaingressoview' WHERE listtype = 'ingresso' AND tablename = 'prova'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'ingresso', 'provaingressoview', 'ingresso', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'aulakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'aulakinddefaultview' WHERE listtype = 'default' AND tablename = 'aulakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aulakind', 'default', 'aulakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'attivform')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'erogata', newtablename = 'attivformerogataview' WHERE listtype = 'erogata' AND tablename = 'attivform'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'erogata', 'attivformerogataview', 'erogata', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'diderog')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'diderogdefaultview' WHERE listtype = 'default' AND tablename = 'diderog'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('diderog', 'default', 'diderogdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'tipoattform')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'tipoattformdefaultview' WHERE listtype = 'default' AND tablename = 'tipoattform'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tipoattform', 'default', 'tipoattformdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'erogata' AND tablename = 'canale')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'erogata', newtablename = 'canaleerogataview' WHERE listtype = 'erogata' AND tablename = 'canale'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('canale', 'erogata', 'canaleerogataview', 'erogata', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'didprog')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'ingresso', newtablename = 'didprogingressoview' WHERE listtype = 'ingresso' AND tablename = 'didprog'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'ingresso', 'didprogingressoview', 'ingresso', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'ingresso' AND tablename = 'corsostudio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'ingresso', newtablename = 'corsostudioingressoview' WHERE listtype = 'ingresso' AND tablename = 'corsostudio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'ingresso', 'corsostudioingressoview', 'ingresso', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg_child_azienda' AND tablename = 'sede')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg_child_azienda', newtablename = 'sedeseg_child_aziendaview' WHERE listtype = 'seg_child_azienda' AND tablename = 'sede'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'seg_child_azienda', 'sedeseg_child_aziendaview', 'seg_child_azienda', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudiolivello')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'corsostudiolivellodefaultview' WHERE listtype = 'default' AND tablename = 'corsostudiolivello'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudiolivello', 'default', 'corsostudiolivellodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'address')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'addresssegview' WHERE listtype = 'seg' AND tablename = 'address'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('address', 'seg', 'addresssegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'sede')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg_child', newtablename = 'sedeseg_childview' WHERE listtype = 'seg_child' AND tablename = 'sede'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'seg_child', 'sedeseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'strutturakind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'strutturakinddefaultview' WHERE listtype = 'default' AND tablename = 'strutturakind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('strutturakind', 'default', 'strutturakinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'affidamento')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'affidamentodefaultview' WHERE listtype = 'default' AND tablename = 'affidamento'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'default', 'affidamentodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudionorma')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'corsostudionormadefaultview' WHERE listtype = 'default' AND tablename = 'corsostudionorma'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudionorma', 'default', 'corsostudionormadefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_city')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'geo_citysegview' WHERE listtype = 'seg' AND tablename = 'geo_city'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'seg', 'geo_citysegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segchild' AND tablename = 'geo_country')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segchild', newtablename = 'geo_countrysegchildview' WHERE listtype = 'segchild' AND tablename = 'geo_country'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_country', 'segchild', 'geo_countrysegchildview', 'segchild', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segchild' AND tablename = 'geo_city')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segchild', newtablename = 'geo_citysegchildview' WHERE listtype = 'segchild' AND tablename = 'geo_city'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'segchild', 'geo_citysegchildview', 'segchild', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_nation')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'geo_nationsegview' WHERE listtype = 'seg' AND tablename = 'geo_nation'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'seg', 'geo_nationsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_region')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'geo_regionsegview' WHERE listtype = 'seg' AND tablename = 'geo_region'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_region', 'seg', 'geo_regionsegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'lingue' AND tablename = 'geo_nation')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'lingue', newtablename = 'geo_nationlingueview' WHERE listtype = 'lingue' AND tablename = 'geo_nation'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'lingue', 'geo_nationlingueview', 'lingue', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'segchild' AND tablename = 'geo_nation')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'segchild', newtablename = 'geo_nationsegchildview' WHERE listtype = 'segchild' AND tablename = 'geo_nation'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'segchild', 'geo_nationsegchildview', 'segchild', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'geo_country')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'geo_countrysegview' WHERE listtype = 'seg' AND tablename = 'geo_country'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_country', 'seg', 'geo_countrysegview', 'seg', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'geo_city')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'geo_citydefaultview' WHERE listtype = 'default' AND tablename = 'geo_city'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'default', 'geo_citydefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'corsostudiodefaultview' WHERE listtype = 'default' AND tablename = 'corsostudio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'default', 'corsostudiodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'aoo')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'aoodefaultview' WHERE listtype = 'default' AND tablename = 'aoo'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aoo', 'default', 'aoodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'upb')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'upbdefaultview' WHERE listtype = 'default' AND tablename = 'upb'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('upb', 'default', 'upbdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'struttura')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg_child', newtablename = 'strutturaseg_childview' WHERE listtype = 'seg_child' AND tablename = 'struttura'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'seg_child', 'strutturaseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'classescuola')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'classescuoladefaultview' WHERE listtype = 'default' AND tablename = 'classescuola'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classescuola', 'default', 'classescuoladefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'insegninteg')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'insegnintegdefaultview' WHERE listtype = 'default' AND tablename = 'insegninteg'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('insegninteg', 'default', 'insegnintegdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'insegn')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'insegndefaultview' WHERE listtype = 'default' AND tablename = 'insegn'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('insegn', 'default', 'insegndefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'attivform')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'attivformdefaultview' WHERE listtype = 'default' AND tablename = 'attivform'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'default', 'attivformdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didprogporzanno')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'didprogporzannodefaultview' WHERE listtype = 'default' AND tablename = 'didprogporzanno'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogporzanno', 'default', 'didprogporzannodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didproganno')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'didprogannodefaultview' WHERE listtype = 'default' AND tablename = 'didproganno'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didproganno', 'default', 'didprogannodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didprogori')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'didprogoridefaultview' WHERE listtype = 'default' AND tablename = 'didprogori'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogori', 'default', 'didprogoridefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'didprog')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'didprogdefaultview' WHERE listtype = 'default' AND tablename = 'didprog'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'default', 'didprogdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'persone' AND tablename = 'registryclass')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'persone', newtablename = 'registryclasspersoneview' WHERE listtype = 'persone' AND tablename = 'registryclass'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'persone', 'registryclasspersoneview', 'persone', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'registryclass')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'registryclassdefaultview' WHERE listtype = 'default' AND tablename = 'registryclass'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'default', 'registryclassdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'docenti' AND tablename = 'titolostudio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'docenti', newtablename = 'titolostudiodocentiview' WHERE listtype = 'docenti' AND tablename = 'titolostudio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('titolostudio', 'docenti', 'titolostudiodocentiview', 'docenti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'docenti' AND tablename = 'publicaz')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'docenti', newtablename = 'publicazdocentiview' WHERE listtype = 'docenti' AND tablename = 'publicaz'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicaz', 'docenti', 'publicazdocentiview', 'docenti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'corsostudiokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'corsostudiokinddefaultview' WHERE listtype = 'default' AND tablename = 'corsostudiokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudiokind', 'default', 'corsostudiokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'areadidattica')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'areadidatticadefaultview' WHERE listtype = 'default' AND tablename = 'areadidattica'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('areadidattica', 'default', 'areadidatticadefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'aula')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg_child', newtablename = 'aulaseg_childview' WHERE listtype = 'seg_child' AND tablename = 'aula'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aula', 'seg_child', 'aulaseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'seg_child' AND tablename = 'edificio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg_child', newtablename = 'edificioseg_childview' WHERE listtype = 'seg_child' AND tablename = 'edificio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('edificio', 'seg_child', 'edificioseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'ccnl')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'ccnldefaultview' WHERE listtype = 'default' AND tablename = 'ccnl'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ccnl', 'default', 'ccnldefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'aula' AND tablename = 'prova')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'aula', newtablename = 'provaaulaview' WHERE listtype = 'aula' AND tablename = 'prova'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'aula', 'provaaulaview', 'aula', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'studprenotkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'studprenotkinddefaultview' WHERE listtype = 'default' AND tablename = 'studprenotkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('studprenotkind', 'default', 'studprenotkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'studdirittokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'studdirittokinddefaultview' WHERE listtype = 'default' AND tablename = 'studdirittokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('studdirittokind', 'default', 'studdirittokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'studenti' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'studenti', newtablename = 'registrystudentiview' WHERE listtype = 'studenti' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'studenti', 'registrystudentiview', 'studenti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sasd')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sasddefaultview' WHERE listtype = 'default' AND tablename = 'sasd'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasd', 'default', 'sasddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'rendicontaltrokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'rendicontaltrokinddefaultview' WHERE listtype = 'default' AND tablename = 'rendicontaltrokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontaltrokind', 'default', 'rendicontaltrokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'istitutiesteri' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'istitutiesteri', newtablename = 'registryistitutiesteriview' WHERE listtype = 'istitutiesteri' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istitutiesteri', 'registryistitutiesteriview', 'istitutiesteri', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'istituti' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'istituti', newtablename = 'registryistitutiview' WHERE listtype = 'istituti' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istituti', 'registryistitutiview', 'istituti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'aziende' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'aziende', newtablename = 'registryaziendeview' WHERE listtype = 'aziende' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'aziende', 'registryaziendeview', 'aziende', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'registrydefaultview' WHERE listtype = 'default' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'default', 'registrydefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'publicazkind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'publicazkinddefaultview' WHERE listtype = 'default' AND tablename = 'publicazkind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicazkind', 'default', 'publicazkinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'publicaz')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'publicazdefaultview' WHERE listtype = 'default' AND tablename = 'publicaz'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicaz', 'default', 'publicazdefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'struttura')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'strutturadefaultview' WHERE listtype = 'default' AND tablename = 'struttura'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'default', 'strutturadefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'sede')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'sededefaultview' WHERE listtype = 'default' AND tablename = 'sede'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'default', 'sededefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'edificio')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'edificiodefaultview' WHERE listtype = 'default' AND tablename = 'edificio'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('edificio', 'default', 'edificiodefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'aula')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'auladefaultview' WHERE listtype = 'default' AND tablename = 'aula'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aula', 'default', 'auladefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'docenti' AND tablename = 'registry')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'docenti', newtablename = 'registrydocentiview' WHERE listtype = 'docenti' AND tablename = 'registry'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'docenti', 'registrydocentiview', 'docenti', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'contrattokind')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'contrattokinddefaultview' WHERE listtype = 'default' AND tablename = 'contrattokind'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('contrattokind', 'default', 'contrattokinddefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT* FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'classconsorsuale')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'default', newtablename = 'classconsorsualedefaultview' WHERE listtype = 'default' AND tablename = 'classconsorsuale'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classconsorsuale', 'default', 'classconsorsualedefaultview', 'default', NULL, NULL, NULL, NULL)
GO
 IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND tablename = 'learningagrtrainer')
UPDATE[web_listredir] SET ct = null, cu = null, lt = null, lu = null, newlisttype = 'seg', newtablename = 'learningagrtrainersegview' WHERE listtype = 'seg' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('learningagrtrainer', 'seg', 'learningagrtrainersegview', 'seg', NULL, NULL, NULL, NULL)
GO
 --insert
------------------------DA LASCIARE IN FONDO COME PARACADUTE--------------------------------
IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'registry')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'lista',newtablename = 'registrymainview' WHERE listtype = 'default' AND tablename = 'registry'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','registry',null,null,null,null,'lista','registrymainview')
GO

IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'upb')
UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'upbview' WHERE listtype = 'default' AND tablename = 'upb'
ELSE
INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','upb',null,null,null,null,'default','upbview')
GO
--Verificare
--IF exists(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND tablename = 'registryclass')
--UPDATE [web_listredir] SET ct = null,cu = null,lt = null,lu = null,newlisttype = 'default',newtablename = 'registryclassdefaultview' WHERE listtype = 'default' AND tablename = 'registryclass'
--ELSE
--INSERT INTO [web_listredir] (listtype,tablename,ct,cu,lt,lu,newlisttype,newtablename) VALUES ('default','registryclass',null,null,null,null,'default','registryclassdefaultview')
--GO

-- ELIMINAZIONE DATI PER web_listredir --


IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'progettotimesheetdefaultview')
DELETE web_listredir WHERE newtablename = 'progettotimesheetdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'progettotimesheetprogettodefaultview')
DELETE web_listredir WHERE newtablename = 'progettotimesheetprogettodefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'progettorpdefaultview')
DELETE web_listredir WHERE newtablename = 'progettorpdefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'progettoattachkindprogettostatuskinddefaultview')
DELETE web_listredir WHERE newtablename = 'progettoattachkindprogettostatuskinddefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'default' AND newtablename = 'progettotestokindprogettostatuskinddefaultview')
DELETE web_listredir WHERE newtablename = 'progettotestokindprogettostatuskinddefaultview' and listtype = 'default'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettoattachkindsegview')
DELETE web_listredir WHERE newtablename = 'progettoattachkindsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettotestokindsegview')
DELETE web_listredir WHERE newtablename = 'progettotestokindsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettosettoreercsegview')
DELETE web_listredir WHERE newtablename = 'progettosettoreercsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'segprog' AND newtablename = 'settoreercsegprogview')
DELETE web_listredir WHERE newtablename = 'settoreercsegprogview' and listtype = 'segprog'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'progettobudgetsegview')
DELETE web_listredir WHERE newtablename = 'progettobudgetsegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'rendicontattivitaprogettoorasegview')
DELETE web_listredir WHERE newtablename = 'rendicontattivitaprogettoorasegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'assetdiarysegview')
DELETE web_listredir WHERE newtablename = 'assetdiarysegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seg' AND newtablename = 'assetdiaryorasegview')
DELETE web_listredir WHERE newtablename = 'assetdiaryorasegview' and listtype = 'seg'
GO
IF EXISTS(SELECT * FROM [web_listredir] WHERE listtype = 'seganag' AND newtablename = 'assetdiaryseganagview')
DELETE web_listredir WHERE newtablename = 'assetdiaryseganagview' and listtype = 'seganag'
GO
 --delete
