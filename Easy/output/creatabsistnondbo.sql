-- CREAZIONE TABELLA customobject --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[customobject]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [customobject] (
objectname varchar(50) NOT NULL,
description varchar(80) NULL,
isreal char(1) NOT NULL,
realtable varchar(50) NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(30) NULL,
 CONSTRAINT xpkcustomobject PRIMARY KEY (objectname
)
)
END
GO

-- CREAZIONE TABELLA columntypes --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[columntypes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [columntypes] (
tablename varchar(80) NOT NULL,
field varchar(80) NOT NULL,
iskey char(1) NOT NULL,
sqltype varchar(60) NOT NULL,
col_len int NULL,
col_precision int NULL,
col_scale int NULL,
systemtype varchar(80) NULL,
sqldeclaration varchar(80) NOT NULL,
allownull char(1) NOT NULL,
defaultvalue varchar(80) NULL,
format varchar(80) NULL,
denynull char(1) NOT NULL,
lastmodtimestamp datetime NULL,
lastmoduser varchar(30) NULL,
createuser varchar(30) NULL,
createtimestamp datetime NULL,
 CONSTRAINT xpkcolumntypes PRIMARY KEY (tablename,
field
)
)
END
GO

