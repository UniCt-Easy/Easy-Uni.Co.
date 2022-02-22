
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


-- CREAZIONE TABELLA registry --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry] (
idreg int NOT NULL,
active char(1) NOT NULL,
annotation varchar(400) NULL,
authorization_free char(1) NULL,
badgecode varchar(20) NULL,
birthdate date NULL,
ccp varchar(12) NULL,
cf varchar(16) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
email_fe varchar(200) NULL,
extension varchar(200) NULL,
extmatricula varchar(40) NULL,
flag_pa char(1) NULL,
flagbankitaliaproceeds char(1) NULL,
foreigncf varchar(40) NULL,
forename varchar(50) NULL,
gender char(1) NULL,
idaccmotivecredit varchar(36) NULL,
idaccmotivedebit varchar(36) NULL,
idcategory varchar(2) NULL,
idcentralizedcategory varchar(20) NULL,
idcity int NULL,
idexternal int NULL,
idmaritalstatus varchar(20) NULL,
idnation int NULL,
idregistryclass varchar(2) NULL,
idregistrykind int NULL,
idtitle varchar(20) NULL,
ipa_fe varchar(7) NULL,
ipa_perlapa varchar(100) NULL,
location varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maritalsurname varchar(50) NULL,
multi_cf char(1) NULL,
p_iva varchar(15) NULL,
pec_fe varchar(200) NULL,
residence int NOT NULL,
rtf image NULL,
sdi_defrifamm varchar(20) NULL,
sdi_norifamm char(1) NULL,
surname varchar(50) NULL,
title varchar(101) NOT NULL,
toredirect int NULL,
txt text NULL,
 CONSTRAINT xpkregistry PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'annotation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD annotation varchar(400) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN annotation varchar(400) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'authorization_free' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD authorization_free char(1) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN authorization_free char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'badgecode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD badgecode varchar(20) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN badgecode varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'birthdate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD birthdate date NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN birthdate date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'ccp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD ccp varchar(12) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN ccp varchar(12) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD cf varchar(16) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN cf varchar(16) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'email_fe' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD email_fe varchar(200) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN email_fe varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'extension' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD extension varchar(200) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN extension varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'extmatricula' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD extmatricula varchar(40) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN extmatricula varchar(40) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'flag_pa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD flag_pa char(1) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN flag_pa char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'flagbankitaliaproceeds' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD flagbankitaliaproceeds char(1) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN flagbankitaliaproceeds char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'foreigncf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD foreigncf varchar(40) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN foreigncf varchar(40) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'forename' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD forename varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN forename varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'gender' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD gender char(1) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN gender char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idaccmotivecredit' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idaccmotivecredit varchar(36) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idaccmotivecredit varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idaccmotivedebit' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idaccmotivedebit varchar(36) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idaccmotivedebit varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idcategory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idcategory varchar(2) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idcategory varchar(2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idcentralizedcategory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idcentralizedcategory varchar(20) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idcentralizedcategory varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idcity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idcity int NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idcity int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idexternal' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idexternal int NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idexternal int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idmaritalstatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idmaritalstatus varchar(20) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idmaritalstatus varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idnation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idnation int NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idnation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idregistryclass' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idregistryclass varchar(2) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idregistryclass varchar(2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idregistrykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idregistrykind int NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idregistrykind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idtitle' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idtitle varchar(20) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idtitle varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'ipa_fe' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD ipa_fe varchar(7) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN ipa_fe varchar(7) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'ipa_perlapa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD ipa_perlapa varchar(100) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN ipa_perlapa varchar(100) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'location' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD location varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN location varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'maritalsurname' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD maritalsurname varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN maritalsurname varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'multi_cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD multi_cf char(1) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN multi_cf char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'p_iva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD p_iva varchar(15) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN p_iva varchar(15) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'pec_fe' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD pec_fe varchar(200) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN pec_fe varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'residence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD residence int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'residence' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN residence int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'rtf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD rtf image NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'sdi_defrifamm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD sdi_defrifamm varchar(20) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN sdi_defrifamm varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'sdi_norifamm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD sdi_norifamm char(1) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN sdi_norifamm char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'surname' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD surname varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN surname varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD title varchar(101) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN title varchar(101) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'toredirect' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD toredirect int NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN toredirect int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'txt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD txt text NULL 
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1registry' and id=object_id('registry'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1registry
     ON registry (p_iva )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1registry
     ON registry (p_iva )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2registry' and id=object_id('registry'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2registry
     ON registry (idregistrykind )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2registry
     ON registry (idregistrykind )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3registry' and id=object_id('registry'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3registry
     ON registry (cf )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3registry
     ON registry (cf )
ON [PRIMARY]
END
GO

