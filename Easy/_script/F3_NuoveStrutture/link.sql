-- CREAZIONE TABELLA expenselink --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[expenselink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [expenselink] (
idchild int NOT NULL,
nlevel tinyint NOT NULL,
idparent int NOT NULL,
 CONSTRAINT xpkexpenselink PRIMARY KEY (idchild,
nlevel
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1expenselink' and id=object_id('expenselink'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenselink ON expenselink (idparent)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1expenselink
	ON expenselink (idparent)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2expenselink' and id=object_id('expenselink'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2expenselink ON expenselink (idparent, idchild)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2expenselink
	ON expenselink (idparent, idchild)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- VERIFICA STRUTTURA expenselink --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselink' and C.name = 'idchild' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselink] ADD idchild int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expenselink') and col.name = 'idchild' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expenselink] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselink' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselink] ADD nlevel tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expenselink') and col.name = 'nlevel' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expenselink] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenselink' and C.name = 'idparent' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenselink] ADD idparent int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('expenselink') and col.name = 'idparent' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [expenselink] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [expenselink] ALTER COLUMN idparent int NOT NULL
GO

-- VERIFICA DI expenselink IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'expenselink'
IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselink' AND field = 'idchild')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'S',tablename = 'expenselink',denynull = 'S',format = '',col_len = '4',field = 'idchild',col_precision = '' where tablename = 'expenselink' AND field = 'idchild'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','S','expenselink','S','','4','idchild','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselink' AND field = 'nlevel')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'S',tablename = 'expenselink',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'expenselink' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','S','expenselink','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenselink' AND field = 'idparent')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expenselink',denynull = 'S',format = '',col_len = '4',field = 'idparent',col_precision = '' where tablename = 'expenselink' AND field = 'idparent'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','expenselink','S','','4','idparent','')
GO

-- VERIFICA DI expenselink IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'expenselink')
UPDATE customobject set isreal = 'S' where objectname = 'expenselink'
ELSE
INSERT INTO customobject (objectname, isreal) values('expenselink', 'S')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE TABELLA finlink --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[finlink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [finlink] (
idchild int NOT NULL,
nlevel tinyint NOT NULL,
idparent int NOT NULL,
 CONSTRAINT xpkfinlink PRIMARY KEY (idchild,
nlevel
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1finlink' and id=object_id('finlink'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1finlink ON finlink (idparent)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1finlink
	ON finlink (idparent)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2finlink' and id=object_id('finlink'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2finlink ON finlink (idparent, idchild)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2finlink
	ON finlink (idparent, idchild)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- VERIFICA STRUTTURA finlink --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlink' and C.name = 'idchild' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlink] ADD idchild int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('finlink') and col.name = 'idchild' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [finlink] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlink' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlink] ADD nlevel tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('finlink') and col.name = 'nlevel' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [finlink] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finlink' and C.name = 'idparent' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finlink] ADD idparent int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('finlink') and col.name = 'idparent' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [finlink] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [finlink] ALTER COLUMN idparent int NOT NULL
GO

-- VERIFICA DI finlink IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'finlink'
IF exists(SELECT * FROM columntypes WHERE tablename = 'finlink' AND field = 'idchild')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'S',tablename = 'finlink',denynull = 'S',format = '',col_len = '4',field = 'idchild',col_precision = '' where tablename = 'finlink' AND field = 'idchild'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','S','finlink','S','','4','idchild','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlink' AND field = 'nlevel')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'S',tablename = 'finlink',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'finlink' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','S','finlink','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finlink' AND field = 'idparent')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'finlink',denynull = 'S',format = '',col_len = '4',field = 'idparent',col_precision = '' where tablename = 'finlink' AND field = 'idparent'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','finlink','S','','4','idparent','')
GO

-- VERIFICA DI finlink IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'finlink')
UPDATE customobject set isreal = 'S' where objectname = 'finlink'
ELSE
INSERT INTO customobject (objectname, isreal) values('finlink', 'S')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE TABELLA incomelink --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[incomelink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [incomelink] (
idchild int NOT NULL,
nlevel tinyint NOT NULL,
idparent int NOT NULL,
 CONSTRAINT xpkincomelink PRIMARY KEY (idchild,
nlevel
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1incomelink' and id=object_id('incomelink'))
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomelink ON incomelink (idparent)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi1incomelink
	ON incomelink (idparent)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2incomelink' and id=object_id('incomelink'))
BEGIN
	CREATE NONCLUSTERED INDEX xi2incomelink ON incomelink (idparent, idchild)
	WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
	CREATE NONCLUSTERED INDEX xi2incomelink
	ON incomelink (idparent, idchild)
	WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- VERIFICA STRUTTURA incomelink --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelink' and C.name = 'idchild' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomelink] ADD idchild int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('incomelink') and col.name = 'idchild' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [incomelink] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelink' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomelink] ADD nlevel tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('incomelink') and col.name = 'nlevel' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [incomelink] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomelink' and C.name = 'idparent' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomelink] ADD idparent int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('incomelink') and col.name = 'idparent' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [incomelink] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [incomelink] ALTER COLUMN idparent int NOT NULL
GO

-- VERIFICA DI incomelink IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'incomelink'
IF exists(SELECT * FROM columntypes WHERE tablename = 'incomelink' AND field = 'idchild')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'S',tablename = 'incomelink',denynull = 'S',format = '',col_len = '4',field = 'idchild',col_precision = '' where tablename = 'incomelink' AND field = 'idchild'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','S','incomelink','S','','4','idchild','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'incomelink' AND field = 'nlevel')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'S',tablename = 'incomelink',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'incomelink' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','S','incomelink','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'incomelink' AND field = 'idparent')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'incomelink',denynull = 'S',format = '',col_len = '4',field = 'idparent',col_precision = '' where tablename = 'incomelink' AND field = 'idparent'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','incomelink','S','','4','idparent','')
GO

-- VERIFICA DI incomelink IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'incomelink')
UPDATE customobject set isreal = 'S' where objectname = 'incomelink'
ELSE
INSERT INTO customobject (objectname, isreal) values('incomelink', 'S')
GO
-- FINE GENERAZIONE SCRIPT --

