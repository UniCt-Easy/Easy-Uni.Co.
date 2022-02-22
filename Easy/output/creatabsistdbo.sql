
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

