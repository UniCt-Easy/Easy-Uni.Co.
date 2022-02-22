
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


--[DBO]--
-- CREAZIONE TABELLA registryclass --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryclass]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registryclass] (
idregistryclass varchar(2) NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(150) NOT NULL,
flagbadgecode char(1) NOT NULL,
flagbadgecode_forced char(1) NOT NULL,
flagCF char(1) NOT NULL,
flagcf_forced char(1) NOT NULL,
flagcfbutton char(1) NULL,
flagextmatricula char(1) NOT NULL,
flagextmatricula_forced char(1) NOT NULL,
flagfiscalresidence char(1) NOT NULL,
flagfiscalresidence_forced char(1) NOT NULL,
flagforeigncf char(1) NOT NULL,
flagforeigncf_forced char(1) NOT NULL,
flaghuman char(1) NULL,
flaginfofromcfbutton char(1) NULL,
flagmaritalstatus char(1) NOT NULL,
flagmaritalstatus_forced char(1) NOT NULL,
flagmaritalsurname char(1) NOT NULL,
flagmaritalsurname_forced char(1) NOT NULL,
flagothers char(1) NOT NULL,
flagothers_forced char(1) NOT NULL,
flagp_iva char(1) NOT NULL,
flagp_iva_forced char(1) NOT NULL,
flagqualification char(1) NOT NULL,
flagqualification_forced char(1) NOT NULL,
flagresidence char(1) NOT NULL,
flagresidence_forced char(1) NOT NULL,
flagtitle char(1) NOT NULL,
flagtitle_forced char(1) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkregistryclass PRIMARY KEY (idregistryclass
)
)
END
GO

-- VERIFICA STRUTTURA registryclass --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'idregistryclass' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD idregistryclass varchar(2) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'idregistryclass' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD description varchar(150) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN description varchar(150) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagbadgecode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagbadgecode char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagbadgecode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagbadgecode char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagbadgecode_forced' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagbadgecode_forced char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagbadgecode_forced' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagbadgecode_forced char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagCF' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagCF char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagCF' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagCF char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagcf_forced' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagcf_forced char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagcf_forced' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagcf_forced char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagcfbutton' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagcfbutton char(1) NULL 
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagcfbutton char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagextmatricula' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagextmatricula char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagextmatricula' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagextmatricula char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagextmatricula_forced' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagextmatricula_forced char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagextmatricula_forced' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagextmatricula_forced char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagfiscalresidence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagfiscalresidence char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagfiscalresidence' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagfiscalresidence char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagfiscalresidence_forced' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagfiscalresidence_forced char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagfiscalresidence_forced' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagfiscalresidence_forced char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagforeigncf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagforeigncf char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagforeigncf' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagforeigncf char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagforeigncf_forced' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagforeigncf_forced char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagforeigncf_forced' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagforeigncf_forced char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flaghuman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flaghuman char(1) NULL 
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flaghuman char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flaginfofromcfbutton' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flaginfofromcfbutton char(1) NULL 
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flaginfofromcfbutton char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagmaritalstatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagmaritalstatus char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagmaritalstatus' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagmaritalstatus char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagmaritalstatus_forced' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagmaritalstatus_forced char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagmaritalstatus_forced' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagmaritalstatus_forced char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagmaritalsurname' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagmaritalsurname char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagmaritalsurname' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagmaritalsurname char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagmaritalsurname_forced' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagmaritalsurname_forced char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagmaritalsurname_forced' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagmaritalsurname_forced char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagothers' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagothers char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagothers' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagothers char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagothers_forced' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagothers_forced char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagothers_forced' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagothers_forced char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagp_iva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagp_iva char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagp_iva' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagp_iva char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagp_iva_forced' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagp_iva_forced char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagp_iva_forced' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagp_iva_forced char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagqualification' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagqualification char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagqualification' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagqualification char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagqualification_forced' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagqualification_forced char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagqualification_forced' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagqualification_forced char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagresidence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagresidence char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagresidence' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagresidence char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagresidence_forced' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagresidence_forced char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagresidence_forced' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagresidence_forced char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagtitle' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagtitle char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagtitle' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagtitle char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'flagtitle_forced' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD flagtitle_forced char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'flagtitle_forced' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN flagtitle_forced char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registryclass' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registryclass] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registryclass') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registryclass] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registryclass] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI registryclass IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryclass'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','varchar(2)','ASSISTENZA','idregistryclass','2','S','varchar','System.String','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclass','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','varchar(150)','ASSISTENZA','description','150','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagbadgecode','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagbadgecode_forced','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagCF','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagcf_forced','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclass','char(1)','ASSISTENZA','flagcfbutton','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagextmatricula','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagextmatricula_forced','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagfiscalresidence','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagfiscalresidence_forced','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagforeigncf','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagforeigncf_forced','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclass','char(1)','ASSISTENZA','flaghuman','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryclass','char(1)','ASSISTENZA','flaginfofromcfbutton','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagmaritalstatus','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagmaritalstatus_forced','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagmaritalsurname','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagmaritalsurname_forced','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagothers','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagothers_forced','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagp_iva','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagp_iva_forced','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagqualification','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagqualification_forced','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagresidence','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagresidence_forced','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagtitle','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','char(1)','ASSISTENZA','flagtitle_forced','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryclass','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registryclass IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryclass')
UPDATE customobject set isreal = 'S' where objectname = 'registryclass'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryclass', 'S')
GO

-- GENERAZIONE DATI PER registryclass --
IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '01')
UPDATE [registryclass] SET active = 'N',ct = {d '2003-01-01'},cu = '''DBO_PO''',description = 'Enti commerciali, ditte individuali e artigiani',flagbadgecode = 'N',flagbadgecode_forced = 'N',flagCF = 'S',flagcf_forced = 'N',flagcfbutton = 'N',flagextmatricula = 'N',flagextmatricula_forced = 'N',flagfiscalresidence = 'S',flagfiscalresidence_forced = 'S',flagforeigncf = 'N',flagforeigncf_forced = 'S',flaghuman = 'N',flaginfofromcfbutton = 'N',flagmaritalstatus = 'N',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'N',flagmaritalsurname_forced = 'N',flagothers = 'N',flagothers_forced = 'N',flagp_iva = 'S',flagp_iva_forced = 'S',flagqualification = 'N',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'S',flagtitle = 'S',flagtitle_forced = 'S',lt = {ts '2018-01-24 10:50:03.757'},lu = 'assistenza' WHERE idregistryclass = '01'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('01','N',{d '2003-01-01'},'''DBO_PO''','Enti commerciali, ditte individuali e artigiani','N','N','S','N','N','N','N','S','S','N','S','N','N','N','N','N','N','N','N','S','S','N','N','S','S','S','S',{ts '2018-01-24 10:50:03.757'},'assistenza')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '02')
UPDATE [registryclass] SET active = 'N',ct = {d '2003-01-01'},cu = '''DBO_PO''',description = 'Enti commerciali esteri',flagbadgecode = 'N',flagbadgecode_forced = 'N',flagCF = 'N',flagcf_forced = 'N',flagcfbutton = 'N',flagextmatricula = 'N',flagextmatricula_forced = 'N',flagfiscalresidence = 'S',flagfiscalresidence_forced = 'N',flagforeigncf = 'N',flagforeigncf_forced = 'N',flaghuman = 'N',flaginfofromcfbutton = 'N',flagmaritalstatus = 'N',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'N',flagmaritalsurname_forced = 'N',flagothers = 'N',flagothers_forced = 'N',flagp_iva = 'S',flagp_iva_forced = 'N',flagqualification = 'N',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'S',flagtitle = 'S',flagtitle_forced = 'S',lt = {ts '2004-04-28 10:24:03.000'},lu = '''DBO_PO''' WHERE idregistryclass = '02'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('02','N',{d '2003-01-01'},'''DBO_PO''','Enti commerciali esteri','N','N','N','N','N','N','N','S','N','N','N','N','N','N','N','N','N','N','N','S','N','N','N','S','S','S','S',{ts '2004-04-28 10:24:03.000'},'''DBO_PO''')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '03')
UPDATE [registryclass] SET active = 'N',ct = {d '2003-01-01'},cu = '''DBO_PO''',description = 'Enti pubblici e altri enti di natura non commerciale',flagbadgecode = 'N',flagbadgecode_forced = 'N',flagCF = 'S',flagcf_forced = 'S',flagcfbutton = 'N',flagextmatricula = 'S',flagextmatricula_forced = 'N',flagfiscalresidence = 'S',flagfiscalresidence_forced = 'N',flagforeigncf = 'N',flagforeigncf_forced = 'N',flaghuman = 'N',flaginfofromcfbutton = 'N',flagmaritalstatus = 'N',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'N',flagmaritalsurname_forced = 'N',flagothers = 'N',flagothers_forced = 'N',flagp_iva = 'S',flagp_iva_forced = 'N',flagqualification = 'N',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'S',flagtitle = 'S',flagtitle_forced = 'S',lt = {ts '2005-11-24 14:46:57.280'},lu = '''DBO_PO''' WHERE idregistryclass = '03'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('03','N',{d '2003-01-01'},'''DBO_PO''','Enti pubblici e altri enti di natura non commerciale','N','N','S','S','N','S','N','S','N','N','N','N','N','N','N','N','N','N','N','S','N','N','N','S','S','S','S',{ts '2005-11-24 14:46:57.280'},'''DBO_PO''')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '04')
UPDATE [registryclass] SET active = 'N',ct = {ts '2004-02-26 17:29:23.000'},cu = '''DBO_PO''',description = 'Istituzioni internazionali',flagbadgecode = 'N',flagbadgecode_forced = 'N',flagCF = 'N',flagcf_forced = 'N',flagcfbutton = 'N',flagextmatricula = 'N',flagextmatricula_forced = 'N',flagfiscalresidence = 'N',flagfiscalresidence_forced = 'N',flagforeigncf = 'S',flagforeigncf_forced = 'N',flaghuman = 'N',flaginfofromcfbutton = 'N',flagmaritalstatus = 'N',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'N',flagmaritalsurname_forced = 'N',flagothers = 'N',flagothers_forced = 'N',flagp_iva = 'S',flagp_iva_forced = 'N',flagqualification = 'N',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'S',flagtitle = 'S',flagtitle_forced = 'S',lt = {ts '2004-05-12 13:52:46.000'},lu = '''DBO_PO''' WHERE idregistryclass = '04'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('04','N',{ts '2004-02-26 17:29:23.000'},'''DBO_PO''','Istituzioni internazionali','N','N','N','N','N','N','N','N','N','S','N','N','N','N','N','N','N','N','N','S','N','N','N','S','S','S','S',{ts '2004-05-12 13:52:46.000'},'''DBO_PO''')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '05')
UPDATE [registryclass] SET active = 'S',ct = {ts '2004-02-26 17:30:35.000'},cu = '''DBO_PO''',description = 'Persona fisica senza P.Iva',flagbadgecode = 'S',flagbadgecode_forced = 'N',flagCF = 'S',flagcf_forced = 'S',flagcfbutton = 'S',flagextmatricula = 'S',flagextmatricula_forced = 'N',flagfiscalresidence = 'S',flagfiscalresidence_forced = 'S',flagforeigncf = 'N',flagforeigncf_forced = 'N',flaghuman = 'S',flaginfofromcfbutton = 'S',flagmaritalstatus = 'S',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'S',flagmaritalsurname_forced = 'N',flagothers = 'S',flagothers_forced = 'N',flagp_iva = 'N',flagp_iva_forced = 'N',flagqualification = 'S',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'N',flagtitle = 'N',flagtitle_forced = 'N',lt = {ts '2016-05-17 16:20:34.273'},lu = 'assistenza' WHERE idregistryclass = '05'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('05','S',{ts '2004-02-26 17:30:35.000'},'''DBO_PO''','Persona fisica senza P.Iva','S','N','S','S','S','S','N','S','S','N','N','S','S','S','N','S','N','S','N','N','N','S','N','S','N','N','N',{ts '2016-05-17 16:20:34.273'},'assistenza')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '06')
UPDATE [registryclass] SET active = 'N',ct = {ts '2004-02-26 17:31:09.000'},cu = '''DBO_PO''',description = 'Persona fisica con Codice identificativo o Fiscale estero',flagbadgecode = 'N',flagbadgecode_forced = 'N',flagCF = 'S',flagcf_forced = 'N',flagcfbutton = 'S',flagextmatricula = 'S',flagextmatricula_forced = 'N',flagfiscalresidence = 'S',flagfiscalresidence_forced = 'N',flagforeigncf = 'S',flagforeigncf_forced = 'S',flaghuman = 'S',flaginfofromcfbutton = 'S',flagmaritalstatus = 'S',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'S',flagmaritalsurname_forced = 'N',flagothers = 'S',flagothers_forced = 'N',flagp_iva = 'N',flagp_iva_forced = 'N',flagqualification = 'S',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'S',flagtitle = 'N',flagtitle_forced = 'N',lt = {ts '2014-09-18 11:04:39.363'},lu = 'assistenza' WHERE idregistryclass = '06'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('06','N',{ts '2004-02-26 17:31:09.000'},'''DBO_PO''','Persona fisica con Codice identificativo o Fiscale estero','N','N','S','N','S','S','N','S','N','S','S','S','S','S','N','S','N','S','N','N','N','S','N','S','S','N','N',{ts '2014-09-18 11:04:39.363'},'assistenza')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '07')
UPDATE [registryclass] SET active = 'N',ct = {ts '2004-02-26 17:31:51.000'},cu = '''DBO_PO''',description = 'Professionisti con P.Iva',flagbadgecode = 'N',flagbadgecode_forced = 'N',flagCF = 'S',flagcf_forced = 'N',flagcfbutton = 'S',flagextmatricula = 'N',flagextmatricula_forced = 'N',flagfiscalresidence = 'S',flagfiscalresidence_forced = 'S',flagforeigncf = 'N',flagforeigncf_forced = 'N',flaghuman = 'S',flaginfofromcfbutton = 'S',flagmaritalstatus = 'N',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'N',flagmaritalsurname_forced = 'N',flagothers = 'S',flagothers_forced = 'N',flagp_iva = 'S',flagp_iva_forced = 'S',flagqualification = 'S',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'N',flagtitle = 'N',flagtitle_forced = 'N',lt = {ts '2006-04-26 13:37:31.343'},lu = '''NINO''' WHERE idregistryclass = '07'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('07','N',{ts '2004-02-26 17:31:51.000'},'''DBO_PO''','Professionisti con P.Iva','N','N','S','N','S','N','N','S','S','N','N','S','S','N','N','N','N','S','N','S','S','S','N','S','N','N','N',{ts '2006-04-26 13:37:31.343'},'''NINO''')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '08')
UPDATE [registryclass] SET active = 'N',ct = {ts '2004-02-26 17:32:26.000'},cu = '''DBO_PO''',description = 'Studi Associati',flagbadgecode = 'N',flagbadgecode_forced = 'N',flagCF = 'S',flagcf_forced = 'S',flagcfbutton = 'N',flagextmatricula = 'N',flagextmatricula_forced = 'N',flagfiscalresidence = 'S',flagfiscalresidence_forced = 'S',flagforeigncf = 'N',flagforeigncf_forced = 'N',flaghuman = 'N',flaginfofromcfbutton = 'N',flagmaritalstatus = 'N',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'N',flagmaritalsurname_forced = 'N',flagothers = 'N',flagothers_forced = 'N',flagp_iva = 'S',flagp_iva_forced = 'S',flagqualification = 'N',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'N',flagtitle = 'S',flagtitle_forced = 'S',lt = {ts '2004-08-25 13:58:31.677'},lu = '''DBO_PO''' WHERE idregistryclass = '08'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('08','N',{ts '2004-02-26 17:32:26.000'},'''DBO_PO''','Studi Associati','N','N','S','S','N','N','N','S','S','N','N','N','N','N','N','N','N','N','N','S','S','N','N','S','N','S','S',{ts '2004-08-25 13:58:31.677'},'''DBO_PO''')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '09')
UPDATE [registryclass] SET active = 'N',ct = {ts '2004-02-26 17:32:53.000'},cu = '''DBO_PO''',description = 'Università degli Studi del Piemonte Orientale "Amedeo Avogadro"',flagbadgecode = 'N',flagbadgecode_forced = 'N',flagCF = 'S',flagcf_forced = 'S',flagcfbutton = 'N',flagextmatricula = 'N',flagextmatricula_forced = 'N',flagfiscalresidence = 'S',flagfiscalresidence_forced = 'S',flagforeigncf = 'N',flagforeigncf_forced = 'N',flaghuman = 'N',flaginfofromcfbutton = 'N',flagmaritalstatus = 'N',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'N',flagmaritalsurname_forced = 'N',flagothers = 'N',flagothers_forced = 'N',flagp_iva = 'S',flagp_iva_forced = 'S',flagqualification = 'N',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'S',flagtitle = 'S',flagtitle_forced = 'S',lt = {ts '2004-05-12 13:52:25.000'},lu = '''DBO_PO''' WHERE idregistryclass = '09'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('09','N',{ts '2004-02-26 17:32:53.000'},'''DBO_PO''','Università degli Studi del Piemonte Orientale "Amedeo Avogadro"','N','N','S','S','N','N','N','S','S','N','N','N','N','N','N','N','N','N','N','S','S','N','N','S','S','S','S',{ts '2004-05-12 13:52:25.000'},'''DBO_PO''')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '10')
UPDATE [registryclass] SET active = 'N',ct = {ts '2006-02-27 16:41:27.657'},cu = '''SARA''',description = 'Per Mandati Collettivi',flagbadgecode = 'N',flagbadgecode_forced = 'N',flagCF = 'N',flagcf_forced = 'N',flagcfbutton = 'N',flagextmatricula = 'N',flagextmatricula_forced = 'N',flagfiscalresidence = 'N',flagfiscalresidence_forced = 'N',flagforeigncf = 'N',flagforeigncf_forced = 'N',flaghuman = 'N',flaginfofromcfbutton = 'N',flagmaritalstatus = 'N',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'N',flagmaritalsurname_forced = 'N',flagothers = 'S',flagothers_forced = 'N',flagp_iva = 'N',flagp_iva_forced = 'N',flagqualification = 'N',flagqualification_forced = 'N',flagresidence = 'N',flagresidence_forced = 'N',flagtitle = 'S',flagtitle_forced = 'N',lt = {ts '2006-02-27 16:53:14.967'},lu = '''SARA''' WHERE idregistryclass = '10'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('10','N',{ts '2006-02-27 16:41:27.657'},'''SARA''','Per Mandati Collettivi','N','N','N','N','N','N','N','N','N','N','N','N','N','N','N','N','N','S','N','N','N','N','N','N','N','S','N',{ts '2006-02-27 16:53:14.967'},'''SARA''')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '21')
UPDATE [registryclass] SET active = 'S',ct = {ts '2005-12-23 14:43:09.453'},cu = 'Software and more',description = 'Società, enti commerciali, ditte individuali e studi associati',flagbadgecode = 'N',flagbadgecode_forced = 'N',flagCF = 'S',flagcf_forced = 'N',flagcfbutton = 'N',flagextmatricula = 'N',flagextmatricula_forced = 'N',flagfiscalresidence = 'S',flagfiscalresidence_forced = 'S',flagforeigncf = 'S',flagforeigncf_forced = 'N',flaghuman = 'N',flaginfofromcfbutton = 'N',flagmaritalstatus = 'N',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'N',flagmaritalsurname_forced = 'N',flagothers = 'S',flagothers_forced = 'N',flagp_iva = 'S',flagp_iva_forced = 'N',flagqualification = 'N',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'S',flagtitle = 'S',flagtitle_forced = 'N',lt = {ts '2005-12-23 15:13:21.453'},lu = 'Software and more' WHERE idregistryclass = '21'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('21','S',{ts '2005-12-23 14:43:09.453'},'Software and more','Società, enti commerciali, ditte individuali e studi associati','N','N','S','N','N','N','N','S','S','S','N','N','N','N','N','N','N','S','N','S','N','N','N','S','S','S','N',{ts '2005-12-23 15:13:21.453'},'Software and more')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '22')
UPDATE [registryclass] SET active = 'S',ct = {ts '2005-12-23 14:45:39.453'},cu = 'Software and more',description = 'Persona Fisica',flagbadgecode = 'S',flagbadgecode_forced = 'N',flagCF = 'S',flagcf_forced = 'S',flagcfbutton = 'S',flagextmatricula = 'S',flagextmatricula_forced = 'N',flagfiscalresidence = 'S',flagfiscalresidence_forced = 'N',flagforeigncf = 'S',flagforeigncf_forced = 'N',flaghuman = 'S',flaginfofromcfbutton = 'S',flagmaritalstatus = 'S',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'S',flagmaritalsurname_forced = 'N',flagothers = 'S',flagothers_forced = 'N',flagp_iva = 'S',flagp_iva_forced = 'N',flagqualification = 'S',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'S',flagtitle = 'N',flagtitle_forced = 'N',lt = {ts '2014-09-18 11:04:26.737'},lu = 'assistenza' WHERE idregistryclass = '22'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('22','S',{ts '2005-12-23 14:45:39.453'},'Software and more','Persona Fisica','S','N','S','S','S','S','N','S','N','S','N','S','S','S','N','S','N','S','N','S','N','S','N','S','S','N','N',{ts '2014-09-18 11:04:26.737'},'assistenza')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '23')
UPDATE [registryclass] SET active = 'S',ct = {ts '2005-12-23 14:49:12.640'},cu = 'Software and more',description = 'Enti non commerciali ed istituzioni internazionali',flagbadgecode = 'N',flagbadgecode_forced = 'N',flagCF = 'S',flagcf_forced = 'N',flagcfbutton = 'N',flagextmatricula = 'N',flagextmatricula_forced = 'N',flagfiscalresidence = 'S',flagfiscalresidence_forced = 'N',flagforeigncf = 'S',flagforeigncf_forced = 'N',flaghuman = 'N',flaginfofromcfbutton = 'N',flagmaritalstatus = 'N',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'N',flagmaritalsurname_forced = 'N',flagothers = 'S',flagothers_forced = 'N',flagp_iva = 'S',flagp_iva_forced = 'N',flagqualification = 'N',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'S',flagtitle = 'S',flagtitle_forced = 'N',lt = {ts '2005-12-28 14:32:58.627'},lu = 'Software and more' WHERE idregistryclass = '23'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('23','S',{ts '2005-12-23 14:49:12.640'},'Software and more','Enti non commerciali ed istituzioni internazionali','N','N','S','N','N','N','N','S','N','S','N','N','N','N','N','N','N','S','N','S','N','N','N','S','S','S','N',{ts '2005-12-28 14:32:58.627'},'Software and more')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '24')
UPDATE [registryclass] SET active = 'S',ct = {ts '2005-12-23 14:51:33.610'},cu = 'Software and more',description = 'Anagrafiche complementari',flagbadgecode = 'N',flagbadgecode_forced = 'N',flagCF = 'S',flagcf_forced = 'N',flagcfbutton = 'N',flagextmatricula = 'N',flagextmatricula_forced = 'N',flagfiscalresidence = 'N',flagfiscalresidence_forced = 'N',flagforeigncf = 'S',flagforeigncf_forced = 'N',flaghuman = 'N',flaginfofromcfbutton = 'N',flagmaritalstatus = 'N',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'N',flagmaritalsurname_forced = 'N',flagothers = 'S',flagothers_forced = 'N',flagp_iva = 'S',flagp_iva_forced = 'N',flagqualification = 'N',flagqualification_forced = 'N',flagresidence = 'N',flagresidence_forced = 'N',flagtitle = 'S',flagtitle_forced = 'N',lt = {ts '2005-12-23 15:13:12.813'},lu = 'Software and more' WHERE idregistryclass = '24'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('24','S',{ts '2005-12-23 14:51:33.610'},'Software and more','Anagrafiche complementari','N','N','S','N','N','N','N','N','N','S','N','N','N','N','N','N','N','S','N','S','N','N','N','N','N','S','N',{ts '2005-12-23 15:13:12.813'},'Software and more')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = '25')
UPDATE [registryclass] SET active = 'N',ct = {ts '2009-01-10 15:08:07.157'},cu = 'SARA',description = 'Anagrafica non utilizzabile',flagbadgecode = 'S',flagbadgecode_forced = 'N',flagCF = 'S',flagcf_forced = 'N',flagcfbutton = 'S',flagextmatricula = 'N',flagextmatricula_forced = 'N',flagfiscalresidence = 'S',flagfiscalresidence_forced = 'N',flagforeigncf = 'S',flagforeigncf_forced = 'N',flaghuman = 'S',flaginfofromcfbutton = 'S',flagmaritalstatus = 'S',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'S',flagmaritalsurname_forced = 'N',flagothers = 'S',flagothers_forced = 'N',flagp_iva = 'S',flagp_iva_forced = 'N',flagqualification = 'S',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'N',flagtitle = 'S',flagtitle_forced = 'N',lt = {ts '2009-01-10 15:43:32.217'},lu = 'SARA' WHERE idregistryclass = '25'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('25','N',{ts '2009-01-10 15:08:07.157'},'SARA','Anagrafica non utilizzabile','S','N','S','N','S','N','N','S','N','S','N','S','S','S','N','S','N','S','N','S','N','S','N','S','N','S','N',{ts '2009-01-10 15:43:32.217'},'SARA')
GO

IF exists(SELECT * FROM [registryclass] WHERE idregistryclass = 'OO')
UPDATE [registryclass] SET active = 'S',ct = {ts '2018-10-15 13:00:45.860'},cu = 'nino',description = 'Altro',flagbadgecode = 'S',flagbadgecode_forced = 'N',flagCF = 'S',flagcf_forced = 'N',flagcfbutton = 'S',flagextmatricula = 'S',flagextmatricula_forced = 'N',flagfiscalresidence = 'S',flagfiscalresidence_forced = 'N',flagforeigncf = 'S',flagforeigncf_forced = 'N',flaghuman = 'S',flaginfofromcfbutton = 'S',flagmaritalstatus = 'S',flagmaritalstatus_forced = 'N',flagmaritalsurname = 'S',flagmaritalsurname_forced = 'N',flagothers = 'S',flagothers_forced = 'N',flagp_iva = 'S',flagp_iva_forced = 'N',flagqualification = 'S',flagqualification_forced = 'N',flagresidence = 'S',flagresidence_forced = 'N',flagtitle = 'S',flagtitle_forced = 'N',lt = {ts '2018-10-15 13:00:45.860'},lu = 'nino' WHERE idregistryclass = 'OO'
ELSE
INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('OO','S',{ts '2018-10-15 13:00:45.860'},'nino','Altro','S','N','S','N','S','S','N','S','N','S','N','S','S','S','N','S','N','S','N','S','N','S','N','S','N','S','N',{ts '2018-10-15 13:00:45.860'},'nino')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registryclass')
UPDATE [tabledescr] SET description = 'Tipologie classificazione',idapplication =3,isdbo = 'S',lt = {ts '1900-01-01 03:00:29.847'},lu = 'nino',title = 'Tipologie classificazione' WHERE tablename = 'registryclass'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registryclass','Tipologie classificazione',null,'S',{ts '1900-01-01 03:00:29.847'},'nino','Tipologie classificazione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'attivo',kind = 'S',lt = {ts '1900-01-01 02:59:57.390'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','registryclass','1',null,null,'attivo','S',{ts '1900-01-01 02:59:57.390'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:48.153'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registryclass','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:48.153'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:45.587'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registryclass','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:45.587'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '1900-01-01 02:59:51.613'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','registryclass','150',null,null,'Descrizione','S',{ts '1900-01-01 02:59:51.613'},'nino','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagbadgecode' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Codice badge visibile',kind = 'C',lt = {ts '2016-02-07 08:48:20.153'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagbadgecode' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagbadgecode','registryclass','1',null,null,'Codice badge visibile','C',{ts '2016-02-07 08:48:20.153'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagbadgecode_forced' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Codice badge obbligatorio',kind = 'C',lt = {ts '2016-02-07 08:48:42.527'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagbadgecode_forced' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagbadgecode_forced','registryclass','1',null,null,'Codice badge obbligatorio','C',{ts '2016-02-07 08:48:42.527'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagCF' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Codice fiscale visibile',kind = 'C',lt = {ts '2016-02-07 08:49:13.700'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagCF' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagCF','registryclass','1',null,null,'Codice fiscale visibile','C',{ts '2016-02-07 08:49:13.700'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagcf_forced' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Codice fiscale obbligatorio',kind = 'C',lt = {ts '2016-02-07 08:49:32.973'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagcf_forced' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagcf_forced','registryclass','1',null,null,'Codice fiscale obbligatorio','C',{ts '2016-02-07 08:49:32.973'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagcfbutton' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Bottone "calcola codice fiscale" visibile',kind = 'C',lt = {ts '2016-02-07 08:50:07.823'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagcfbutton' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagcfbutton','registryclass','1',null,null,'Bottone "calcola codice fiscale" visibile','C',{ts '2016-02-07 08:50:07.823'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagextmatricula' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Matricola esterna visibile',kind = 'C',lt = {ts '2016-02-07 08:50:45.163'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagextmatricula' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagextmatricula','registryclass','1',null,null,'Matricola esterna visibile','C',{ts '2016-02-07 08:50:45.163'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagextmatricula_forced' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Matricola esterna obbligatoria',kind = 'C',lt = {ts '2016-02-07 08:51:12.460'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagextmatricula_forced' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagextmatricula_forced','registryclass','1',null,null,'Matricola esterna obbligatoria','C',{ts '2016-02-07 08:51:12.460'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagfiscalresidence' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Campo residenza visibile',kind = 'C',lt = {ts '2016-02-07 08:51:47.273'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagfiscalresidence' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagfiscalresidence','registryclass','1',null,null,'Campo residenza visibile','C',{ts '2016-02-07 08:51:47.273'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagfiscalresidence_forced' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'inserimento residenza obbligatorio',kind = 'C',lt = {ts '2016-02-07 08:52:17.603'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagfiscalresidence_forced' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagfiscalresidence_forced','registryclass','1',null,null,'inserimento residenza obbligatorio','C',{ts '2016-02-07 08:52:17.603'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagforeigncf' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Codice fiscale estero visibile',kind = 'C',lt = {ts '2016-02-07 08:52:48.557'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagforeigncf' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagforeigncf','registryclass','1',null,null,'Codice fiscale estero visibile','C',{ts '2016-02-07 08:52:48.557'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagforeigncf_forced' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Codice fiscale estero obbligatorio',kind = 'C',lt = {ts '2016-02-07 08:53:11.867'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagforeigncf_forced' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagforeigncf_forced','registryclass','1',null,null,'Codice fiscale estero obbligatorio','C',{ts '2016-02-07 08:53:11.867'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flaghuman' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Persona fisica',kind = 'C',lt = {ts '2016-02-07 08:53:38.933'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flaghuman' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flaghuman','registryclass','1',null,null,'Persona fisica','C',{ts '2016-02-07 08:53:38.933'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flaginfofromcfbutton' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Bottone "Comune, Data da C.F." visibile',kind = 'C',lt = {ts '2016-02-07 08:54:27.287'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flaginfofromcfbutton' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flaginfofromcfbutton','registryclass','1',null,null,'Bottone "Comune, Data da C.F." visibile','C',{ts '2016-02-07 08:54:27.287'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagmaritalstatus' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Campo stato civile visibile',kind = 'C',lt = {ts '2016-02-07 08:54:52.053'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagmaritalstatus' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagmaritalstatus','registryclass','1',null,null,'Campo stato civile visibile','C',{ts '2016-02-07 08:54:52.053'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagmaritalstatus_forced' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Campo stato civile obbligatorio',kind = 'C',lt = {ts '2016-02-07 08:55:21.207'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagmaritalstatus_forced' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagmaritalstatus_forced','registryclass','1',null,null,'Campo stato civile obbligatorio','C',{ts '2016-02-07 08:55:21.207'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagmaritalsurname' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Cognome acquisito visibile',kind = 'C',lt = {ts '2016-02-07 08:56:02.440'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagmaritalsurname' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagmaritalsurname','registryclass','1',null,null,'Cognome acquisito visibile','C',{ts '2016-02-07 08:56:02.440'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagmaritalsurname_forced' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Cognome acquisito obbligatorio',kind = 'C',lt = {ts '2016-02-07 08:56:23.737'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagmaritalsurname_forced' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagmaritalsurname_forced','registryclass','1',null,null,'Cognome acquisito obbligatorio','C',{ts '2016-02-07 08:56:23.737'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagothers' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'campo non usato',kind = 'S',lt = {ts '2016-02-07 08:58:37.797'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagothers' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagothers','registryclass','1',null,null,'campo non usato','S',{ts '2016-02-07 08:58:37.797'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagothers_forced' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'campo non usato',kind = 'S',lt = {ts '2016-02-07 09:02:19.743'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagothers_forced' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagothers_forced','registryclass','1',null,null,'campo non usato','S',{ts '2016-02-07 09:02:19.743'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagp_iva' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Partita iva visibile',kind = 'C',lt = {ts '2016-02-07 09:02:45.623'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagp_iva' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagp_iva','registryclass','1',null,null,'Partita iva visibile','C',{ts '2016-02-07 09:02:45.623'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagp_iva_forced' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Partita iva obbligatoria',kind = 'C',lt = {ts '2016-02-07 09:03:04.837'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagp_iva_forced' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagp_iva_forced','registryclass','1',null,null,'Partita iva obbligatoria','C',{ts '2016-02-07 09:03:04.837'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagqualification' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'campo "Titolo" visibile',kind = 'C',lt = {ts '2016-02-07 09:03:45.277'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagqualification' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagqualification','registryclass','1',null,null,'campo "Titolo" visibile','C',{ts '2016-02-07 09:03:45.277'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagqualification_forced' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'campo "Titolo" obbligatorio',kind = 'C',lt = {ts '2016-02-07 09:04:04.847'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagqualification_forced' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagqualification_forced','registryclass','1',null,null,'campo "Titolo" obbligatorio','C',{ts '2016-02-07 09:04:04.847'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagresidence' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Usato congiuntamente a flagresidence_forced per stabilire se l''indirizzo di residenza ? obbligatorio, Da solo non ha un gran significato poich? non esiste un campo indirizzo di residenza',kind = 'C',lt = {ts '2016-02-07 09:07:57.780'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagresidence' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagresidence','registryclass','1',null,null,'Usato congiuntamente a flagresidence_forced per stabilire se l''indirizzo di residenza ? obbligatorio, Da solo non ha un gran significato poich? non esiste un campo indirizzo di residenza','C',{ts '2016-02-07 09:07:57.780'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagresidence_forced' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Informazioni sulla residenza obbligatorie',kind = 'C',lt = {ts '2016-02-07 09:08:18.133'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagresidence_forced' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagresidence_forced','registryclass','1',null,null,'Informazioni sulla residenza obbligatorie','C',{ts '2016-02-07 09:08:18.133'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagtitle' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Campo Denominazione diverso da cognome+nome, inserito manualmente',kind = 'C',lt = {ts '2016-02-07 09:09:07.437'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagtitle' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagtitle','registryclass','1',null,null,'Campo Denominazione diverso da cognome+nome, inserito manualmente','C',{ts '2016-02-07 09:09:07.437'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagtitle_forced' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Non usato, il campo denominazione  ? sempre obbligatorio in un modo o nell''altro',kind = 'S',lt = {ts '2016-02-07 09:10:29.133'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagtitle_forced' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagtitle_forced','registryclass','1',null,null,'Non usato, il campo denominazione  ? sempre obbligatorio in un modo o nell''altro','S',{ts '2016-02-07 09:10:29.133'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryclass' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '1900-01-01 03:00:22.813'},lu = 'nino',primarykey = 'S',sql_declaration = 'varchar(2)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idregistryclass' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryclass','registryclass','2',null,null,'Codice','S',{ts '1900-01-01 03:00:22.813'},'nino','S','varchar(2)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:42.910'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registryclass','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:42.910'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registryclass')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:39.940'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registryclass'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registryclass','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:39.940'},'nino','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colvalue --
IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagbadgecode' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:48:20.153'},lu = 'Nino',title = 'Codice badge non visibile' WHERE colname = 'flagbadgecode' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagbadgecode','registryclass','N',null,{ts '2016-02-07 08:48:20.153'},'Nino','Codice badge non visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagbadgecode' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:48:20.153'},lu = 'Nino',title = 'Codice badge visibile' WHERE colname = 'flagbadgecode' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagbadgecode','registryclass','S',null,{ts '2016-02-07 08:48:20.153'},'Nino','Codice badge visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagbadgecode_forced' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:48:42.527'},lu = 'Nino',title = 'Codice badge non obbligatorio' WHERE colname = 'flagbadgecode_forced' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagbadgecode_forced','registryclass','N',null,{ts '2016-02-07 08:48:42.527'},'Nino','Codice badge non obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagbadgecode_forced' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:48:42.527'},lu = 'Nino',title = 'Codice badge obbligatorio' WHERE colname = 'flagbadgecode_forced' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagbadgecode_forced','registryclass','S',null,{ts '2016-02-07 08:48:42.527'},'Nino','Codice badge obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagCF' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:49:13.700'},lu = 'Nino',title = 'Codice fiscale non visibile' WHERE colname = 'flagCF' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagCF','registryclass','N',null,{ts '2016-02-07 08:49:13.700'},'Nino','Codice fiscale non visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagCF' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:49:13.700'},lu = 'Nino',title = 'Codice fiscale visibile' WHERE colname = 'flagCF' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagCF','registryclass','S',null,{ts '2016-02-07 08:49:13.700'},'Nino','Codice fiscale visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagcf_forced' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:49:32.973'},lu = 'Nino',title = 'Codice fiscale non obbligatorio' WHERE colname = 'flagcf_forced' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagcf_forced','registryclass','N',null,{ts '2016-02-07 08:49:32.973'},'Nino','Codice fiscale non obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagcf_forced' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:49:32.973'},lu = 'Nino',title = 'Codice fiscale obbligatorio' WHERE colname = 'flagcf_forced' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagcf_forced','registryclass','S',null,{ts '2016-02-07 08:49:32.973'},'Nino','Codice fiscale obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagcfbutton' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:50:07.823'},lu = 'Nino',title = 'Bottone "calcola codice fiscale" nascosto' WHERE colname = 'flagcfbutton' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagcfbutton','registryclass','N',null,{ts '2016-02-07 08:50:07.823'},'Nino','Bottone "calcola codice fiscale" nascosto')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagcfbutton' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:50:07.823'},lu = 'Nino',title = 'Bottone "calcola codice fiscale" visibile' WHERE colname = 'flagcfbutton' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagcfbutton','registryclass','S',null,{ts '2016-02-07 08:50:07.823'},'Nino','Bottone "calcola codice fiscale" visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagextmatricula' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:50:45.163'},lu = 'Nino',title = 'Matricola esterna nascosta' WHERE colname = 'flagextmatricula' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagextmatricula','registryclass','N',null,{ts '2016-02-07 08:50:45.163'},'Nino','Matricola esterna nascosta')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagextmatricula' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:50:45.163'},lu = 'Nino',title = 'Matricola esterna visibile' WHERE colname = 'flagextmatricula' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagextmatricula','registryclass','S',null,{ts '2016-02-07 08:50:45.163'},'Nino','Matricola esterna visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagextmatricula_forced' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:51:12.460'},lu = 'Nino',title = 'Matricola esterna non obbligatoria' WHERE colname = 'flagextmatricula_forced' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagextmatricula_forced','registryclass','N',null,{ts '2016-02-07 08:51:12.460'},'Nino','Matricola esterna non obbligatoria')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagextmatricula_forced' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:51:12.460'},lu = 'Nino',title = 'Matricola esterna obbligatoria' WHERE colname = 'flagextmatricula_forced' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagextmatricula_forced','registryclass','S',null,{ts '2016-02-07 08:51:12.460'},'Nino','Matricola esterna obbligatoria')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagfiscalresidence' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:51:47.273'},lu = 'Nino',title = 'Campo residenza non visibile' WHERE colname = 'flagfiscalresidence' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagfiscalresidence','registryclass','N',null,{ts '2016-02-07 08:51:47.273'},'Nino','Campo residenza non visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagfiscalresidence' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:51:47.273'},lu = 'Nino',title = 'Campo residenza visibile' WHERE colname = 'flagfiscalresidence' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagfiscalresidence','registryclass','S',null,{ts '2016-02-07 08:51:47.273'},'Nino','Campo residenza visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagfiscalresidence_forced' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:52:17.603'},lu = 'Nino',title = 'Inserimento residenza non obbligatorio' WHERE colname = 'flagfiscalresidence_forced' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagfiscalresidence_forced','registryclass','N',null,{ts '2016-02-07 08:52:17.603'},'Nino','Inserimento residenza non obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagfiscalresidence_forced' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:52:17.603'},lu = 'Nino',title = 'inserimento residenza obbligatorio' WHERE colname = 'flagfiscalresidence_forced' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagfiscalresidence_forced','registryclass','S',null,{ts '2016-02-07 08:52:17.603'},'Nino','inserimento residenza obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagforeigncf' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:52:48.557'},lu = 'Nino',title = 'Codice fiscale estero non visibile' WHERE colname = 'flagforeigncf' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagforeigncf','registryclass','N',null,{ts '2016-02-07 08:52:48.557'},'Nino','Codice fiscale estero non visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagforeigncf' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:52:48.557'},lu = 'Nino',title = 'Codice fiscale estero visibile' WHERE colname = 'flagforeigncf' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagforeigncf','registryclass','S',null,{ts '2016-02-07 08:52:48.557'},'Nino','Codice fiscale estero visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagforeigncf_forced' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:53:11.867'},lu = 'Nino',title = 'Codice fiscale estero non obbligatorio' WHERE colname = 'flagforeigncf_forced' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagforeigncf_forced','registryclass','N',null,{ts '2016-02-07 08:53:11.867'},'Nino','Codice fiscale estero non obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagforeigncf_forced' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:53:11.867'},lu = 'Nino',title = 'Codice fiscale estero obbligatorio' WHERE colname = 'flagforeigncf_forced' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagforeigncf_forced','registryclass','S',null,{ts '2016-02-07 08:53:11.867'},'Nino','Codice fiscale estero obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flaghuman' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:53:38.933'},lu = 'Nino',title = 'Non ? Persona fisica' WHERE colname = 'flaghuman' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flaghuman','registryclass','N',null,{ts '2016-02-07 08:53:38.933'},'Nino','Non ? Persona fisica')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flaghuman' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:53:38.933'},lu = 'Nino',title = 'Persona fisica' WHERE colname = 'flaghuman' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flaghuman','registryclass','S',null,{ts '2016-02-07 08:53:38.933'},'Nino','Persona fisica')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flaginfofromcfbutton' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:54:27.287'},lu = 'Nino',title = 'Bottone "Comune, Data da C.F. non visibile' WHERE colname = 'flaginfofromcfbutton' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flaginfofromcfbutton','registryclass','N',null,{ts '2016-02-07 08:54:27.287'},'Nino','Bottone "Comune, Data da C.F. non visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flaginfofromcfbutton' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:54:27.287'},lu = 'Nino',title = 'Bottone "Comune, Data da C.F." visibile' WHERE colname = 'flaginfofromcfbutton' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flaginfofromcfbutton','registryclass','S',null,{ts '2016-02-07 08:54:27.287'},'Nino','Bottone "Comune, Data da C.F." visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagmaritalstatus' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:54:52.053'},lu = 'Nino',title = 'Campo stato civile non visibile' WHERE colname = 'flagmaritalstatus' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagmaritalstatus','registryclass','N',null,{ts '2016-02-07 08:54:52.053'},'Nino','Campo stato civile non visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagmaritalstatus' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:54:52.053'},lu = 'Nino',title = 'Campo stato civile visibile' WHERE colname = 'flagmaritalstatus' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagmaritalstatus','registryclass','S',null,{ts '2016-02-07 08:54:52.053'},'Nino','Campo stato civile visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagmaritalstatus_forced' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:55:21.207'},lu = 'Nino',title = 'Campo stato civile non obbligatorio' WHERE colname = 'flagmaritalstatus_forced' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagmaritalstatus_forced','registryclass','N',null,{ts '2016-02-07 08:55:21.207'},'Nino','Campo stato civile non obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagmaritalstatus_forced' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:55:21.207'},lu = 'Nino',title = 'Campo stato civile obbligatorio' WHERE colname = 'flagmaritalstatus_forced' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagmaritalstatus_forced','registryclass','S',null,{ts '2016-02-07 08:55:21.207'},'Nino','Campo stato civile obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagmaritalsurname' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:56:02.440'},lu = 'Nino',title = 'Cognome acquisito non visibile' WHERE colname = 'flagmaritalsurname' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagmaritalsurname','registryclass','N',null,{ts '2016-02-07 08:56:02.440'},'Nino','Cognome acquisito non visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagmaritalsurname' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:56:02.440'},lu = 'Nino',title = 'Cognome acquisito visibile' WHERE colname = 'flagmaritalsurname' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagmaritalsurname','registryclass','S',null,{ts '2016-02-07 08:56:02.440'},'Nino','Cognome acquisito visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagmaritalsurname_forced' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:56:23.737'},lu = 'Nino',title = 'Cognome acquisito non obbligatorio' WHERE colname = 'flagmaritalsurname_forced' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagmaritalsurname_forced','registryclass','N',null,{ts '2016-02-07 08:56:23.737'},'Nino','Cognome acquisito non obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagmaritalsurname_forced' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:56:23.737'},lu = 'Nino',title = 'Cognome acquisito obbligatorio' WHERE colname = 'flagmaritalsurname_forced' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagmaritalsurname_forced','registryclass','S',null,{ts '2016-02-07 08:56:23.737'},'Nino','Cognome acquisito obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagp_iva' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:02:45.623'},lu = 'Nino',title = 'Partita iva non visibile' WHERE colname = 'flagp_iva' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagp_iva','registryclass','N',null,{ts '2016-02-07 09:02:45.623'},'Nino','Partita iva non visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagp_iva' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:02:45.623'},lu = 'Nino',title = 'Partita iva visibile' WHERE colname = 'flagp_iva' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagp_iva','registryclass','S',null,{ts '2016-02-07 09:02:45.623'},'Nino','Partita iva visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagp_iva_forced' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:03:04.837'},lu = 'Nino',title = 'Partita iva non obbligatoria' WHERE colname = 'flagp_iva_forced' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagp_iva_forced','registryclass','N',null,{ts '2016-02-07 09:03:04.837'},'Nino','Partita iva non obbligatoria')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagp_iva_forced' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:03:04.837'},lu = 'Nino',title = 'Partita iva obbligatoria' WHERE colname = 'flagp_iva_forced' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagp_iva_forced','registryclass','S',null,{ts '2016-02-07 09:03:04.837'},'Nino','Partita iva obbligatoria')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagqualification' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:03:45.277'},lu = 'Nino',title = 'campo "Titolo" non visibile' WHERE colname = 'flagqualification' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagqualification','registryclass','N',null,{ts '2016-02-07 09:03:45.277'},'Nino','campo "Titolo" non visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagqualification' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:03:45.277'},lu = 'Nino',title = 'campo "Titolo" visibile' WHERE colname = 'flagqualification' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagqualification','registryclass','S',null,{ts '2016-02-07 09:03:45.277'},'Nino','campo "Titolo" visibile')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagqualification_forced' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:04:04.847'},lu = 'Nino',title = 'campo "Titolo" non obbligatorio' WHERE colname = 'flagqualification_forced' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagqualification_forced','registryclass','N',null,{ts '2016-02-07 09:04:04.847'},'Nino','campo "Titolo" non obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagqualification_forced' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:04:04.847'},lu = 'Nino',title = 'campo "Titolo" obbligatorio' WHERE colname = 'flagqualification_forced' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagqualification_forced','registryclass','S',null,{ts '2016-02-07 09:04:04.847'},'Nino','campo "Titolo" obbligatorio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagresidence' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:07:57.780'},lu = 'Nino',title = 'Nascondi informazioni su residenza' WHERE colname = 'flagresidence' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagresidence','registryclass','N',null,{ts '2016-02-07 09:07:57.780'},'Nino','Nascondi informazioni su residenza')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagresidence' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = 'Potrebbe essere usato in qualche stampa',lt = {ts '2016-02-07 09:07:57.780'},lu = 'Nino',title = 'Informazioni sulla residenza visibili' WHERE colname = 'flagresidence' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagresidence','registryclass','S','Potrebbe essere usato in qualche stampa',{ts '2016-02-07 09:07:57.780'},'Nino','Informazioni sulla residenza visibili')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagresidence_forced' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:08:18.133'},lu = 'Nino',title = 'Informazioni sulla residenza non obbligatorie' WHERE colname = 'flagresidence_forced' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagresidence_forced','registryclass','N',null,{ts '2016-02-07 09:08:18.133'},'Nino','Informazioni sulla residenza non obbligatorie')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagresidence_forced' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:08:18.133'},lu = 'Nino',title = 'Informazioni sulla residenza obbligatorie' WHERE colname = 'flagresidence_forced' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagresidence_forced','registryclass','S',null,{ts '2016-02-07 09:08:18.133'},'Nino','Informazioni sulla residenza obbligatorie')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagtitle' AND tablename = 'registryclass' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:09:07.437'},lu = 'Nino',title = 'Campo Denominazione uguale a cognome+nome, inserito in automatico' WHERE colname = 'flagtitle' AND tablename = 'registryclass' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagtitle','registryclass','N',null,{ts '2016-02-07 09:09:07.437'},'Nino','Campo Denominazione uguale a cognome+nome, inserito in automatico')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagtitle' AND tablename = 'registryclass' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 09:09:07.437'},lu = 'Nino',title = 'Campo Denominazione diverso da cognome+nome, inserito manualmente' WHERE colname = 'flagtitle' AND tablename = 'registryclass' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagtitle','registryclass','S',null,{ts '2016-02-07 09:09:07.437'},'Nino','Campo Denominazione diverso da cognome+nome, inserito manualmente')
GO

-- FINE GENERAZIONE SCRIPT --

