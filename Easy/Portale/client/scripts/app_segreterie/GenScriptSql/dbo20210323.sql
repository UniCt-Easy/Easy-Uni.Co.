
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


IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[userkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN

CREATE TABLE [dbo].[userkind](
	[userkind] [int] NOT NULL,
	[title] [varchar](64) NULL,
 CONSTRAINT [PK_userkind] PRIMARY KEY CLUSTERED 
(
	[userkind] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[usertype](
	[usertype] [varchar](50) NOT NULL,
 CONSTRAINT [PK_usertype] PRIMARY KEY CLUSTERED 
(
	[usertype] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


INSERT [dbo].[userkind] ([userkind], [title]) VALUES (3, N'WEB')

INSERT [dbo].[userkind] ([userkind], [title]) VALUES (5, N'SSO')

INSERT [dbo].[usertype] ([usertype]) VALUES (N'amministrativi')

INSERT [dbo].[usertype] ([usertype]) VALUES (N'docenti')

INSERT [dbo].[usertype] ([usertype]) VALUES (N'studenti')

END

-- CREAZIONE TABELLA registrationuser --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrationuser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrationuser] (
idregistrationuser int NOT NULL,
cf varchar(16) NULL,
email varchar(1024) NULL,
esercizio int NULL,
forename varchar(49) NULL,
idregistrationuserstatus int NULL,
login varchar(60) NULL,
matricola varchar(50) NULL,
surname varchar(50) NULL,
userkind int NULL,
usertype varchar(50) NULL,
 CONSTRAINT xpkregistrationuser PRIMARY KEY (idregistrationuser
)
)
END
GO

-- VERIFICA STRUTTURA registrationuser --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'idregistrationuser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD idregistrationuser int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registrationuser') and col.name = 'idregistrationuser' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registrationuser] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD cf varchar(16) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN cf varchar(16) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'email' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD email varchar(1024) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN email varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'esercizio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD esercizio int NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN esercizio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'forename' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD forename varchar(49) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN forename varchar(49) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'idregistrationuserstatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD idregistrationuserstatus int NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN idregistrationuserstatus int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'login' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD login varchar(60) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN login varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'matricola' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD matricola varchar(50) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN matricola varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'surname' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD surname varchar(50) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN surname varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'userkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD userkind int NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN userkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuser' and C.name = 'usertype' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuser] ADD usertype varchar(50) NULL 
END
ELSE
	ALTER TABLE [registrationuser] ALTER COLUMN usertype varchar(50) NULL
GO

-- CREAZIONE TABELLA registrationuserflowchart --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrationuserflowchart]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrationuserflowchart] (
idregistrationuser int NOT NULL,
idflowchart varchar(34) NOT NULL,
 CONSTRAINT xpkregistrationuserflowchart PRIMARY KEY (idregistrationuser,
idflowchart
)
)
END
GO

-- VERIFICA STRUTTURA registrationuserflowchart --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuserflowchart' and C.name = 'idregistrationuser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuserflowchart] ADD idregistrationuser int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registrationuserflowchart') and col.name = 'idregistrationuser' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registrationuserflowchart] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuserflowchart' and C.name = 'idflowchart' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuserflowchart] ADD idflowchart varchar(34) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registrationuserflowchart') and col.name = 'idflowchart' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registrationuserflowchart] drop constraint '+@vincolo)
END
GO

-- CREAZIONE TABELLA registrationuserstatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrationuserstatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registrationuserstatus] (
idregistrationuserstatus int NOT NULL,
title varchar(64) NULL,
 CONSTRAINT xpkregistrationuserstatus PRIMARY KEY (idregistrationuserstatus
)
)
END
GO

-- VERIFICA STRUTTURA registrationuserstatus --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuserstatus' and C.name = 'idregistrationuserstatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuserstatus] ADD idregistrationuserstatus int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registrationuserstatus') and col.name = 'idregistrationuserstatus' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registrationuserstatus] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrationuserstatus' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registrationuserstatus] ADD title varchar(64) NULL 
END
ELSE
	ALTER TABLE [registrationuserstatus] ALTER COLUMN title varchar(64) NULL
GO

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

-- CREAZIONE TABELLA rendicont --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicont]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[rendicont] (
idreg_docenti int NOT NULL,
aa varchar(9) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(1024) NULL,
 CONSTRAINT xpkrendicont PRIMARY KEY (idreg_docenti,
aa
)
)
END
GO

-- VERIFICA STRUTTURA rendicont --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD idreg_docenti int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD aa varchar(9) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicont') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicont] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicont' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicont] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [rendicont] ALTER COLUMN title varchar(1024) NULL
GO

-- CREAZIONE TABELLA rendicontaltro --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontaltro]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[rendicontaltro] (
idrendicontaltro int NOT NULL,
aa varchar(9) NOT NULL,
idreg_docenti int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data date NOT NULL,
idrendicontaltrokind int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ore decimal(9,2) NOT NULL,
 CONSTRAINT xpkrendicontaltro PRIMARY KEY (idrendicontaltro,
aa,
idreg_docenti
)
)
END
GO

-- VERIFICA STRUTTURA rendicontaltro --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'idrendicontaltro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD idrendicontaltro int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'idrendicontaltro' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD aa varchar(9) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD idreg_docenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD data date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'data' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN data date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'idrendicontaltrokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD idrendicontaltrokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'idrendicontaltrokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN idrendicontaltrokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontaltro' and C.name = 'ore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontaltro] ADD ore decimal(9,2) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontaltro') and col.name = 'ore' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontaltro] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontaltro] ALTER COLUMN ore decimal(9,2) NOT NULL
GO



-- CREAZIONE VISTA protocollosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[protocollosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[protocollosegview]
GO

CREATE VIEW [dbo].[protocollosegview] AS SELECT CASE WHEN protocollo.annullato = 'S' THEN 'Si' WHEN protocollo.annullato = 'N' THEN 'No' END AS protocollo_annullato, protocollo.codiceammipa AS protocollo_codiceammipa, protocollo.codiceregistro AS protocollo_codiceregistro, protocollo.ct AS protocollo_ct, protocollo.cu AS protocollo_cu, protocollo.dataannullamento AS protocollo_dataannullamento, [dbo].aoo.title AS aoo_title, protocollo.idaoo, registryorigine.title AS registryorigine_title, protocollo.idreg_origine, protocollo.lt AS protocollo_lt, protocollo.lu AS protocollo_lu, protocollo.oggetto AS protocollo_oggetto, protocollo.originecodiceaoo AS protocollo_originecodiceaoo, protocollo.origineidamm AS protocollo_origineidamm, protocollo.originemail AS protocollo_originemail, protocollo.protanno, protocollo.protdata AS protocollo_protdata, protocollo.protnumero, protocollo.testo AS protocollo_testo, isnull('Numero di protocollo: ' + CAST( protocollo.protnumero AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno di protocollo: ' + CAST( protocollo.protanno AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Codice Registro (univoco nell''Istituto): ' + protocollo.codiceregistro + '; ','') as dropdown_title FROM [dbo].protocollo WITH (NOLOCK)  LEFT OUTER JOIN [dbo].aoo WITH (NOLOCK) ON protocollo.idaoo = [dbo].aoo.idaoo LEFT OUTER JOIN [dbo].registry AS registryorigine WITH (NOLOCK) ON protocollo.idreg_origine = registryorigine.idreg WHERE  protocollo.protanno IS NOT NULL  AND protocollo.protnumero IS NOT NULL 
GO

-- CREAZIONE VISTA registrationuserauthview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrationuserauthview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrationuserauthview]
GO

CREATE VIEW [dbo].[registrationuserauthview] AS SELECT  registrationuser.cf AS registrationuser_cf, registrationuser.email AS registrationuser_email, registrationuser.esercizio AS registrationuser_esercizio, registrationuser.forename AS registrationuser_forename, registrationuser.idregistrationuser, [dbo].registrationuserstatus.title AS registrationuserstatus_title, registrationuser.idregistrationuserstatus AS registrationuser_idregistrationuserstatus, registrationuser.login AS registrationuser_login, registrationuser.matricola AS registrationuser_matricola, registrationuser.surname, registrationuser.userkind AS registrationuser_userkind, [dbo].usertype.usertype AS usertype_usertype, registrationuser.usertype AS registrationuser_usertype, isnull('Cognome: ' + registrationuser.surname + '; ','') + ' ' + isnull('Nome: ' + registrationuser.forename + '; ','') + ' ' + isnull('Codice fiscale: ' + registrationuser.cf + '; ','') as dropdown_title FROM [dbo].registrationuser WITH (NOLOCK)  LEFT OUTER JOIN [dbo].registrationuserstatus WITH (NOLOCK) ON registrationuser.idregistrationuserstatus = [dbo].registrationuserstatus.idregistrationuserstatus LEFT OUTER JOIN [dbo].usertype WITH (NOLOCK) ON registrationuser.usertype = [dbo].usertype.usertype WHERE  registrationuser.idregistrationuser IS NOT NULL 
GO

-- CREAZIONE VISTA registrationuserusrview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrationuserusrview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrationuserusrview]
GO

CREATE VIEW [dbo].[registrationuserusrview] AS SELECT  registrationuser.cf AS registrationuser_cf, registrationuser.email AS registrationuser_email, registrationuser.esercizio AS registrationuser_esercizio, registrationuser.forename AS registrationuser_forename, registrationuser.idregistrationuser, [dbo].registrationuserstatus.title AS registrationuserstatus_title, registrationuser.idregistrationuserstatus AS registrationuser_idregistrationuserstatus, registrationuser.login AS registrationuser_login, registrationuser.matricola AS registrationuser_matricola, registrationuser.surname, registrationuser.userkind AS registrationuser_userkind, [dbo].usertype.usertype AS usertype_usertype, registrationuser.usertype AS registrationuser_usertype, isnull('Cognome: ' + registrationuser.surname + '; ','') + ' ' + isnull('Nome: ' + registrationuser.forename + '; ','') + ' ' + isnull('Codice fiscale: ' + registrationuser.cf + '; ','') as dropdown_title FROM [dbo].registrationuser WITH (NOLOCK)  LEFT OUTER JOIN [dbo].registrationuserstatus WITH (NOLOCK) ON registrationuser.idregistrationuserstatus = [dbo].registrationuserstatus.idregistrationuserstatus LEFT OUTER JOIN [dbo].usertype WITH (NOLOCK) ON registrationuser.usertype = [dbo].usertype.usertype WHERE  registrationuser.idregistrationuser IS NOT NULL 
GO

-- CREAZIONE VISTA registryamministrativiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryamministrativiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryamministrativiview]
GO

CREATE VIEW [dbo].[registryamministrativiview] AS SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, [dbo].category.description AS category_description, registry.idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory, [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, [dbo].maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus, [dbo].geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg, [dbo].registryclass.description AS registryclass_description, registry.idregistryclass, [dbo].registrykind.description AS registrykind_description, registry.idregistrykind AS registry_idregistrykind, [dbo].title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, [dbo].residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title AS registry_title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_amministrativi.ct AS registry_amministrativi_ct, registry_amministrativi.cu AS registry_amministrativi_cu, registry_amministrativi.cv AS registry_amministrativi_cv, [dbo].contrattokind.title AS contrattokind_title, registry_amministrativi.idcontrattokind AS registry_amministrativi_idcontrattokind, registry_amministrativi.idreg AS registry_amministrativi_idreg, registry_amministrativi.lt AS registry_amministrativi_lt, registry_amministrativi.lu AS registry_amministrativi_lu, isnull('Titolo: ' + [dbo].title.description + '; ','') + ' ' + isnull('Cognome: ' + registry.surname + '; ','') + ' ' + isnull('Nome: ' + registry.forename + '; ','') + ' ' + isnull('Codice fiscale: ' + registry.cf + '; ','') as dropdown_title FROM [dbo].registry WITH (NOLOCK)  INNER JOIN registry_amministrativi WITH (NOLOCK) ON registry.idreg = registry_amministrativi.idreg LEFT OUTER JOIN [dbo].category WITH (NOLOCK) ON registry.idcategory = [dbo].category.idcategory LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity LEFT OUTER JOIN [dbo].maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = [dbo].maritalstatus.idmaritalstatus LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registry.idnation = [dbo].geo_nation.idnation LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass LEFT OUTER JOIN [dbo].registrykind WITH (NOLOCK) ON registry.idregistrykind = [dbo].registrykind.idregistrykind LEFT OUTER JOIN [dbo].title WITH (NOLOCK) ON registry.idtitle = [dbo].title.idtitle LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON registry.residence = [dbo].residence.idresidence LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON registry_amministrativi.idcontrattokind = [dbo].contrattokind.idcontrattokind WHERE  registry.idreg IS NOT NULL  AND registry_amministrativi.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA registrydocentiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrydocentiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrydocentiview]
GO

CREATE VIEW [dbo].[registrydocentiview] AS SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, registry.idcategory AS registry_idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory, [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, [dbo].maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus, [dbo].geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg, [dbo].registryclass.description AS registryclass_description, registry.idregistryclass, registry.idregistrykind AS registry_idregistrykind, [dbo].title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, [dbo].residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_docenti.ct AS registry_docenti_ct, registry_docenti.cu AS registry_docenti_cu, registry_docenti.cv AS registry_docenti_cv, [dbo].classconsorsuale.title AS classconsorsuale_title, registry_docenti.idclassconsorsuale, [dbo].contrattokind.title AS contrattokind_title, registry_docenti.idcontrattokind AS registry_docenti_idcontrattokind, [dbo].fonteindicebibliometrico.title AS fonteindicebibliometrico_title, registry_docenti.idfonteindicebibliometrico AS registry_docenti_idfonteindicebibliometrico, registry_docenti.idreg AS registry_docenti_idreg, registry_registry_istitutiistituti.title AS registryistituti_title, registry_docenti.idreg_istituti, [dbo].sasd.codice AS sasd_codice, [dbo].sasd.title AS sasd_title, registry_docenti.idsasd, [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, registry_docenti.idstruttura, registry_docenti.indicebibliometrico AS registry_docenti_indicebibliometrico, registry_docenti.lt AS registry_docenti_lt, registry_docenti.lu AS registry_docenti_lu, registry_docenti.matricola AS registry_docenti_matricola, registry_docenti.ricevimento AS registry_docenti_ricevimento, registry_docenti.soggiorno AS registry_docenti_soggiorno, isnull('Denominazione: ' + registry.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + [dbo].strutturakind.title + '; ','') as dropdown_title FROM [dbo].registry WITH (NOLOCK)  INNER JOIN registry_docenti WITH (NOLOCK) ON registry.idreg = registry_docenti.idreg LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity LEFT OUTER JOIN [dbo].maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = [dbo].maritalstatus.idmaritalstatus LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registry.idnation = [dbo].geo_nation.idnation LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass LEFT OUTER JOIN [dbo].title WITH (NOLOCK) ON registry.idtitle = [dbo].title.idtitle LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON registry.residence = [dbo].residence.idresidence LEFT OUTER JOIN [dbo].classconsorsuale WITH (NOLOCK) ON registry_docenti.idclassconsorsuale = [dbo].classconsorsuale.idclassconsorsuale LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON registry_docenti.idcontrattokind = [dbo].contrattokind.idcontrattokind LEFT OUTER JOIN [dbo].fonteindicebibliometrico WITH (NOLOCK) ON registry_docenti.idfonteindicebibliometrico = [dbo].fonteindicebibliometrico.idfonteindicebibliometrico LEFT OUTER JOIN [dbo].registry_istituti AS registry_istitutiistituti WITH (NOLOCK) ON registry_docenti.idreg_istituti = registry_istitutiistituti.idreg LEFT OUTER JOIN [dbo].registry AS registry_registry_istitutiistituti WITH (NOLOCK) ON registry_istitutiistituti.idreg = registry_registry_istitutiistituti.idreg LEFT OUTER JOIN [dbo].sasd WITH (NOLOCK) ON registry_docenti.idsasd = [dbo].sasd.idsasd LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON registry_docenti.idstruttura = [dbo].struttura.idstruttura LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind WHERE  registry.idreg IS NOT NULL  AND registry_docenti.idreg IS NOT NULL 
GO

