-- CREAZIONE TABELLA dbdepartment --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dbdepartment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dbdepartment] (
description varchar(150) NULL,
iddbdepartment varchar(50) NOT NULL,
iddep smallint NULL,
lt datetime NULL,
lu varchar(64) NULL,
start smallint NULL,
stop smallint NULL)
END
GO

-- CREAZIONE TABELLA dbuser --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dbuser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dbuser] (
forename varchar(50) NULL,
initpwd varchar(50) NULL,
login varchar(50) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
start datetime NULL,
stop datetime NULL,
surname varchar(50) NULL)
END
GO

-- CREAZIONE TABELLA dbaccess --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dbaccess]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[dbaccess] (
alpha1 varchar(66) NULL,
iddbdepartment varchar(50) NOT NULL,
login varchar(50) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL)
END
GO

