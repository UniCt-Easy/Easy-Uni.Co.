
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

-- VERIFICA DI registry IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registry'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','int','nino','idreg','4','S','int','System.Int32','','','''nino''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','char(1)','nino','active','1','S','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(400)','nino','annotation','400','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','char(1)','nino','authorization_free','1','N','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(20)','nino','badgecode','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','date','nino','birthdate','3','N','date','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(12)','nino','ccp','12','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(16)','nino','cf','16','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','datetime','nino','ct','8','S','datetime','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','varchar(64)','nino','cu','64','S','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(200)','nino','email_fe','200','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(200)','nino','extension','200','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(40)','nino','extmatricula','40','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','char(1)','nino','flag_pa','1','N','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','char(1)','nino','flagbankitaliaproceeds','1','N','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(40)','nino','foreigncf','40','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(50)','nino','forename','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','char(1)','nino','gender','1','N','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(36)','nino','idaccmotivecredit','36','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(36)','nino','idaccmotivedebit','36','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(2)','nino','idcategory','2','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(20)','nino','idcentralizedcategory','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','int','nino','idcity','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','int','nino','idexternal','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(20)','nino','idmaritalstatus','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','int','nino','idnation','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(2)','nino','idregistryclass','2','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','int','nino','idregistrykind','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(20)','nino','idtitle','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(7)','nino','ipa_fe','7','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(100)','nino','ipa_perlapa','100','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(50)','nino','location','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','datetime','nino','lt','8','S','datetime','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','varchar(64)','nino','lu','64','S','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(50)','nino','maritalsurname','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','char(1)','nino','multi_cf','1','N','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(15)','nino','p_iva','15','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(200)','nino','pec_fe','200','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','int','nino','residence','4','S','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','image','nino','rtf','16','N','image','System.Byte[]','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(20)','nino','sdi_defrifamm','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','char(1)','nino','sdi_norifamm','1','N','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(50)','nino','surname','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','varchar(101)','nino','title','101','S','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','int','nino','toredirect','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','text','nino','txt','16','N','text','System.String','','','''nino''','','N')
GO

-- VERIFICA DI registry IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registry')
UPDATE customobject set isreal = 'S' where objectname = 'registry'
ELSE
INSERT INTO customobject (objectname, isreal) values('registry', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry')
UPDATE [tabledescr] SET description = 'Anagrafica',idapplication = '4',isdbo = 'S',lt = {ts '2021-09-07 11:27:36.643'},lu = 'Generator',title = 'Anagrafica' WHERE tablename = 'registry'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry','Anagrafica','4','S',{ts '2021-09-07 11:27:36.643'},'Generator','Anagrafica')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'attivo',kind = 'S',lt = {ts '1900-01-01 02:59:57.380'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','registry','1',null,null,'attivo','S',{ts '1900-01-01 02:59:57.380'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annotation' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '400',col_precision = null,col_scale = null,description = 'Annotazioni',kind = 'S',lt = {ts '1900-01-01 03:00:15.987'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(400)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'annotation' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annotation','registry','400',null,null,'Annotazioni','S',{ts '1900-01-01 03:00:15.987'},'nino','N','varchar(400)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'authorization_free' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Esente ai fini dell''autorizzazione EQUITALIA. (S/N)',kind = 'C',lt = {ts '1900-01-01 02:59:04.323'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'authorization_free' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('authorization_free','registry','1',null,null,'Esente ai fini dell''autorizzazione EQUITALIA. (S/N)','C',{ts '1900-01-01 02:59:04.323'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'badgecode' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Codice badge',kind = 'S',lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'badgecode' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('badgecode','registry','20',null,null,'Codice badge','S',{ts '2016-02-03 09:45:20.063'},'assistenza','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'birthdate' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di nascita',kind = 'S',lt = {ts '2019-09-02 17:25:36.273'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'birthdate' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('birthdate','registry','3',null,null,'Data di nascita','S',{ts '2019-09-02 17:25:36.273'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ccp' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '12',col_precision = null,col_scale = null,description = 'Conto corrente postale di Riscossione',kind = 'S',lt = {ts '1900-01-01 02:59:04.333'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(12)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'ccp' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ccp','registry','12',null,null,'Conto corrente postale di Riscossione','S',{ts '1900-01-01 02:59:04.333'},'nino','N','varchar(12)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cf' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'Codice fiscale',kind = 'S',lt = {ts '1900-01-01 03:00:10.587'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(16)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cf' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cf','registry','16',null,null,'Codice fiscale','S',{ts '1900-01-01 03:00:10.587'},'nino','N','varchar(16)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:48.140'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:48.140'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:45.573'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:45.573'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'email_fe' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-30 10:52:15.377'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'email_fe' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('email_fe','registry','200',null,null,null,'S',{ts '2019-04-30 10:52:15.377'},'assistenza','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'extension' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = 'tabella che estende il record',kind = 'S',lt = {ts '2019-04-30 10:53:07.933'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'extension' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('extension','registry','200',null,null,'tabella che estende il record','S',{ts '2019-04-30 10:53:07.933'},'assistenza','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'extmatricula' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '40',col_precision = null,col_scale = null,description = 'Matricola',kind = 'S',lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(40)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'extmatricula' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('extmatricula','registry','40',null,null,'Matricola','S',{ts '2016-02-03 09:45:20.063'},'assistenza','N','varchar(40)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flag_pa' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Applica lo split payment  (per le fatture di vendita)',kind = 'C',lt = {ts '2016-02-07 08:46:13.517'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flag_pa' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flag_pa','registry','1',null,null,'Applica lo split payment  (per le fatture di vendita)','C',{ts '2016-02-07 08:46:13.517'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagbankitaliaproceeds' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Regolarizzazione Riscossioni presso  T.P.S. - Banca d''Italia',kind = 'C',lt = {ts '1900-01-01 02:59:04.353'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagbankitaliaproceeds' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagbankitaliaproceeds','registry','1',null,null,'Regolarizzazione Riscossioni presso  T.P.S. - Banca d''Italia','C',{ts '1900-01-01 02:59:04.353'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'foreigncf' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '40',col_precision = null,col_scale = null,description = 'Codice fiscale estero',kind = 'S',lt = {ts '1900-01-01 02:59:04.357'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(40)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'foreigncf' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('foreigncf','registry','40',null,null,'Codice fiscale estero','S',{ts '1900-01-01 02:59:04.357'},'nino','N','varchar(40)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'forename' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Nome',kind = 'S',lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'forename' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('forename','registry','50',null,null,'Nome','S',{ts '2016-02-03 09:45:20.063'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'gender' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Sesso (M/F)',kind = 'C',lt = {ts '1900-01-01 02:59:04.363'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'gender' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('gender','registry','1',null,null,'Sesso (M/F)','C',{ts '1900-01-01 02:59:04.363'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotivecredit' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'ID Causale per i crediti (tabella accmotive)',kind = 'S',lt = {ts '2016-02-03 09:51:28.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotivecredit' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotivecredit','registry','36',null,null,'ID Causale per i crediti (tabella accmotive)','S',{ts '2016-02-03 09:51:28.413'},'assistenza','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotivedebit' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'Id della causale di debito (tabella accmotive) ',kind = 'S',lt = {ts '1900-01-01 03:00:14.753'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotivedebit' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotivedebit','registry','36',null,null,'Id della causale di debito (tabella accmotive) ','S',{ts '1900-01-01 03:00:14.753'},'nino','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcategory' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'ID Categoria (tabella category)',kind = 'S',lt = {ts '1900-01-01 03:00:30.487'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(2)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idcategory' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcategory','registry','2',null,null,'ID Categoria (tabella category)','S',{ts '1900-01-01 03:00:30.487'},'nino','N','varchar(2)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcentralizedcategory' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'ID Classificazione centralizzata anagrafica (tabella centralizedcategory)',kind = 'S',lt = {ts '1900-01-01 03:00:30.490'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idcentralizedcategory' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcentralizedcategory','registry','20',null,null,'ID Classificazione centralizzata anagrafica (tabella centralizedcategory)','S',{ts '1900-01-01 03:00:30.490'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcity' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id città (tabella geo_city)',kind = 'S',lt = {ts '1900-01-01 03:00:02.247'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcity' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcity','registry','4',null,null,'id città (tabella geo_city)','S',{ts '1900-01-01 03:00:02.247'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idexternal' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id chiave in altri database, usato in migrazioni o simili',kind = 'S',lt = {ts '2016-02-03 09:51:28.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idexternal' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idexternal','registry','4',null,null,'Id chiave in altri database, usato in migrazioni o simili','S',{ts '2016-02-03 09:51:28.413'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idmaritalstatus' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'ID Stato civile (tabella maritalstatus)',kind = 'S',lt = {ts '1900-01-01 03:00:30.697'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idmaritalstatus' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idmaritalstatus','registry','20',null,null,'ID Stato civile (tabella maritalstatus)','S',{ts '1900-01-01 03:00:30.697'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id nazione (tabella geo_nation)',kind = 'S',lt = {ts '1900-01-01 03:00:14.990'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation','registry','4',null,null,'Id nazione (tabella geo_nation)','S',{ts '1900-01-01 03:00:14.990'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id anagrafica (tabella registry)',kind = 'S',lt = {ts '1900-01-01 02:59:52.460'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry','4',null,null,'id anagrafica (tabella registry)','S',{ts '1900-01-01 02:59:52.460'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryclass' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'ID Tipologie classificazione (tabella registryclass)',kind = 'S',lt = {ts '1900-01-01 03:00:30.737'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(2)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idregistryclass' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryclass','registry','2',null,null,'ID Tipologie classificazione (tabella registryclass)','S',{ts '1900-01-01 03:00:30.737'},'nino','N','varchar(2)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistrykind' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'ID Classificazione Anagrafica (tabella registrykind)',kind = 'S',lt = {ts '1900-01-01 03:00:30.740'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistrykind' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistrykind','registry','4',null,null,'ID Classificazione Anagrafica (tabella registrykind)','S',{ts '1900-01-01 03:00:30.740'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtitle' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'ID Titolo (tabella title)',kind = 'S',lt = {ts '1900-01-01 03:00:30.837'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idtitle' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtitle','registry','20',null,null,'ID Titolo (tabella title)','S',{ts '1900-01-01 03:00:30.837'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ipa_fe' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '7',col_precision = null,col_scale = null,description = 'Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.',kind = 'S',lt = {ts '2019-09-02 17:25:36.273'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(7)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'ipa_fe' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ipa_fe','registry','7',null,null,'Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.','S',{ts '2019-09-02 17:25:36.273'},'assistenza','N','varchar(7)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ipa_perlapa' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '100',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-09-07 11:27:36.647'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(100)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'ipa_perlapa' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ipa_perlapa','registry','100',null,null,'','S',{ts '2021-09-07 11:27:36.647'},'Generator','N','varchar(100)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'location' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'ubicazione',kind = 'S',lt = {ts '1900-01-01 03:00:11.413'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'location' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('location','registry','50',null,null,'ubicazione','S',{ts '1900-01-01 03:00:11.413'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:42.897'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:42.897'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:39.927'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:39.927'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'maritalsurname' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Cognome acquisito',kind = 'S',lt = {ts '2016-02-03 09:51:28.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'maritalsurname' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('maritalsurname','registry','50',null,null,'Cognome acquisito','S',{ts '2016-02-03 09:51:28.413'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'multi_cf' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Consenti duplicazione CF/P. IVA (S/N)',kind = 'C',lt = {ts '1900-01-01 02:59:04.423'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'multi_cf' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('multi_cf','registry','1',null,null,'Consenti duplicazione CF/P. IVA (S/N)','C',{ts '1900-01-01 02:59:04.423'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'p_iva' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '15',col_precision = null,col_scale = null,description = 'Partita iva',kind = 'S',lt = {ts '1900-01-01 02:59:04.427'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(15)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'p_iva' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('p_iva','registry','15',null,null,'Partita iva','S',{ts '1900-01-01 02:59:04.427'},'nino','N','varchar(15)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pec_fe' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-30 10:52:15.377'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'pec_fe' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pec_fe','registry','200',null,null,null,'S',{ts '2019-04-30 10:52:15.377'},'assistenza','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'residence' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo residenza (chiave di tabella residence)',kind = 'C',lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'residence' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('residence','registry','4',null,null,'Tipo residenza (chiave di tabella residence)','C',{ts '2016-02-03 09:45:20.063'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rtf' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'allegati',kind = 'S',lt = {ts '1900-01-01 02:59:58.567'},lu = 'nino',primarykey = 'N',sql_declaration = 'image',sql_type = 'image',system_type = 'System.Byte[]' WHERE colname = 'rtf' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rtf','registry','16',null,null,'allegati','S',{ts '1900-01-01 02:59:58.567'},'nino','N','image','image','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sdi_defrifamm' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Rif.Amministrazione di default per fattura elettronica',kind = 'S',lt = {ts '1900-01-01 02:59:04.437'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'sdi_defrifamm' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sdi_defrifamm','registry','20',null,null,'Rif.Amministrazione di default per fattura elettronica','S',{ts '1900-01-01 02:59:04.437'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sdi_norifamm' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica',kind = 'S',lt = {ts '1900-01-01 02:59:04.440'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'sdi_norifamm' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sdi_norifamm','registry','1',null,null,'Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica','S',{ts '1900-01-01 02:59:04.440'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'surname' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Cognome',kind = 'S',lt = {ts '1900-01-01 03:00:15.383'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'surname' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('surname','registry','50',null,null,'Cognome','S',{ts '1900-01-01 03:00:15.383'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '101',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-09-02 17:25:36.273'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(101)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','registry','101',null,null,'Denominazione','S',{ts '2019-09-02 17:25:36.273'},'assistenza','N','varchar(101)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'toredirect' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'E'' stato usato in qualche migrazione',kind = 'S',lt = {ts '2016-10-09 09:46:41.937'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'toredirect' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('toredirect','registry','4',null,null,'E'' stato usato in qualche migrazione','S',{ts '2016-10-09 09:46:41.937'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'note testuali',kind = 'S',lt = {ts '1900-01-01 02:59:58.263'},lu = 'nino',primarykey = 'N',sql_declaration = 'text',sql_type = 'text',system_type = 'System.String' WHERE colname = 'txt' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt','registry','16',null,null,'note testuali','S',{ts '1900-01-01 02:59:58.263'},'nino','N','text','text','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colvalue --
IF exists(SELECT * FROM [colvalue] WHERE colname = 'authorization_free' AND tablename = 'registry' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Non esente ai fini dell''autorizzazione EQUITALIA.' WHERE colname = 'authorization_free' AND tablename = 'registry' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('authorization_free','registry','N',null,{ts '2016-01-29 14:10:19.543'},'lu','Non esente ai fini dell''autorizzazione EQUITALIA.')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'authorization_free' AND tablename = 'registry' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Esente ai fini dell''autorizzazione EQUITALIA.' WHERE colname = 'authorization_free' AND tablename = 'registry' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('authorization_free','registry','S',null,{ts '2016-01-29 14:10:19.543'},'lu','Esente ai fini dell''autorizzazione EQUITALIA.')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flag_pa' AND tablename = 'registry' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:46:13.517'},lu = 'Nino',title = 'Non applicare lo split payment  (per le fatture di vendita)' WHERE colname = 'flag_pa' AND tablename = 'registry' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flag_pa','registry','N',null,{ts '2016-02-07 08:46:13.517'},'Nino','Non applicare lo split payment  (per le fatture di vendita)')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flag_pa' AND tablename = 'registry' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:46:13.517'},lu = 'Nino',title = 'Applica lo split payment  (per le fatture di vendita)' WHERE colname = 'flag_pa' AND tablename = 'registry' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flag_pa','registry','S',null,{ts '2016-02-07 08:46:13.517'},'Nino','Applica lo split payment  (per le fatture di vendita)')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagbankitaliaproceeds' AND tablename = 'registry' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'La regolarizzazione delle riscossioni avviene norm' WHERE colname = 'flagbankitaliaproceeds' AND tablename = 'registry' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagbankitaliaproceeds','registry','N',null,{ts '2016-01-29 14:10:19.543'},'lu','La regolarizzazione delle riscossioni avviene norm')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagbankitaliaproceeds' AND tablename = 'registry' AND value = 'S')
UPDATE [colvalue] SET description = 'Si tratta presumibilmente di un ente  pubblico',lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Regolarizzazione riscoss. presso Banca d''Italia' WHERE colname = 'flagbankitaliaproceeds' AND tablename = 'registry' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagbankitaliaproceeds','registry','S','Si tratta presumibilmente di un ente  pubblico',{ts '2016-01-29 14:10:19.543'},'lu','Regolarizzazione riscoss. presso Banca d''Italia')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'gender' AND tablename = 'registry' AND value = 'F')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Femmina' WHERE colname = 'gender' AND tablename = 'registry' AND value = 'F'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('gender','registry','F',null,{ts '2016-01-29 14:10:19.543'},'lu','Femmina')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'gender' AND tablename = 'registry' AND value = 'M')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Maschio' WHERE colname = 'gender' AND tablename = 'registry' AND value = 'M'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('gender','registry','M',null,{ts '2016-01-29 14:10:19.543'},'lu','Maschio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'multi_cf' AND tablename = 'registry' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Non consentire duplicazione cf/p.iva (la norma)' WHERE colname = 'multi_cf' AND tablename = 'registry' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('multi_cf','registry','N',null,{ts '2016-01-29 14:10:19.543'},'lu','Non consentire duplicazione cf/p.iva (la norma)')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'multi_cf' AND tablename = 'registry' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Consenti duplicazione CF/P. IVA' WHERE colname = 'multi_cf' AND tablename = 'registry' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('multi_cf','registry','S',null,{ts '2016-01-29 14:10:19.543'},'lu','Consenti duplicazione CF/P. IVA')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'residence' AND tablename = 'registry' AND value = '1')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',title = 'Residente in Italia (coderesidence I)' WHERE colname = 'residence' AND tablename = 'registry' AND value = '1'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('residence','registry','1',null,{ts '2016-02-03 09:45:20.063'},'assistenza','Residente in Italia (coderesidence I)')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'residence' AND tablename = 'registry' AND value = '2')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',title = 'Residente in altri paesi dell''UE (coderesidence J)' WHERE colname = 'residence' AND tablename = 'registry' AND value = '2'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('residence','registry','2',null,{ts '2016-02-03 09:45:20.063'},'assistenza','Residente in altri paesi dell''UE (coderesidence J)')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'residence' AND tablename = 'registry' AND value = '3')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',title = 'Trasferimenti interni (code residence U)' WHERE colname = 'residence' AND tablename = 'registry' AND value = '3'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('residence','registry','3',null,{ts '2016-02-03 09:45:20.063'},'assistenza','Trasferimenti interni (code residence U)')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'residence' AND tablename = 'registry' AND value = '4')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',title = 'Residente fuori dall''UE (coderesidence X)' WHERE colname = 'residence' AND tablename = 'registry' AND value = '4'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('residence','registry','4',null,{ts '2016-02-03 09:45:20.063'},'assistenza','Residente fuori dall''UE (coderesidence X)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '67')
UPDATE [relation] SET childtable = 'registry',description = 'ID Causale per i crediti (tabella accmotive)',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Anagrafica' WHERE idrelation = '67'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('67','registry','ID Causale per i crediti (tabella accmotive)',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '68')
UPDATE [relation] SET childtable = 'registry',description = 'Id della causale di debito (tabella accmotive) ',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Anagrafica' WHERE idrelation = '68'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('68','registry','Id della causale di debito (tabella accmotive) ',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '351')
UPDATE [relation] SET childtable = 'registry',description = 'ID Categoria (tabella category)',lt = {ts '2017-05-20 09:19:42.160'},lu = 'lu',parenttable = 'category',title = 'Anagrafica' WHERE idrelation = '351'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('351','registry','ID Categoria (tabella category)',{ts '2017-05-20 09:19:42.160'},'lu','category','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '354')
UPDATE [relation] SET childtable = 'registry',description = 'ID Classificazione centralizzata anagrafica (tabella centralizedcategory)',lt = {ts '2017-05-20 09:19:42.290'},lu = 'lu',parenttable = 'centralizedcategory',title = 'Anagrafica' WHERE idrelation = '354'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('354','registry','ID Classificazione centralizzata anagrafica (tabella centralizedcategory)',{ts '2017-05-20 09:19:42.290'},'lu','centralizedcategory','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '869')
UPDATE [relation] SET childtable = 'registry',description = 'id città (tabella geo_city)',lt = {ts '2017-05-20 09:19:52.420'},lu = 'lu',parenttable = 'geo_city',title = 'Anagrafica' WHERE idrelation = '869'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('869','registry','id città (tabella geo_city)',{ts '2017-05-20 09:19:52.420'},'lu','geo_city','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '893')
UPDATE [relation] SET childtable = 'registry',description = 'Id nazione (tabella geo_nation)',lt = {ts '2017-05-20 09:19:52.760'},lu = 'lu',parenttable = 'geo_nation',title = 'Anagrafica' WHERE idrelation = '893'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('893','registry','Id nazione (tabella geo_nation)',{ts '2017-05-20 09:19:52.760'},'lu','geo_nation','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1057')
UPDATE [relation] SET childtable = 'registry',description = 'Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.',lt = {ts '2017-05-20 09:19:55.467'},lu = 'lu',parenttable = 'ipa',title = 'Anagrafica' WHERE idrelation = '1057'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1057','registry','Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.',{ts '2017-05-20 09:19:55.467'},'lu','ipa','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1226')
UPDATE [relation] SET childtable = 'registry',description = 'ID Stato civile (tabella maritalstatus)',lt = {ts '2017-05-20 09:20:00.003'},lu = 'lu',parenttable = 'maritalstatus',title = 'Anagrafica' WHERE idrelation = '1226'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1226','registry','ID Stato civile (tabella maritalstatus)',{ts '2017-05-20 09:20:00.003'},'lu','maritalstatus','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2111')
UPDATE [relation] SET childtable = 'registry',description = 'ID Tipologie classificazione (tabella registryclass)',lt = {ts '2017-05-20 09:20:06.217'},lu = 'lu',parenttable = 'registryclass',title = 'Anagrafica' WHERE idrelation = '2111'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2111','registry','ID Tipologie classificazione (tabella registryclass)',{ts '2017-05-20 09:20:06.217'},'lu','registryclass','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2113')
UPDATE [relation] SET childtable = 'registry',description = 'ID Classificazione Anagrafica (tabella registrykind)',lt = {ts '2017-05-20 09:20:06.390'},lu = 'lu',parenttable = 'registrykind',title = 'Anagrafica' WHERE idrelation = '2113'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2113','registry','ID Classificazione Anagrafica (tabella registrykind)',{ts '2017-05-20 09:20:06.390'},'lu','registrykind','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2722')
UPDATE [relation] SET childtable = 'registry',description = 'ID Titolo (tabella title)',lt = {ts '2017-05-20 09:20:11.763'},lu = 'lu',parenttable = 'title',title = 'Anagrafica' WHERE idrelation = '2722'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2722','registry','ID Titolo (tabella title)',{ts '2017-05-20 09:20:11.763'},'lu','title','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3115')
UPDATE [relation] SET childtable = 'registry',description = 'Tipo residenza (chiave di tabella residence)',lt = {ts '2017-05-22 15:16:57.787'},lu = 'nino',parenttable = 'residence',title = 'Anagrafica' WHERE idrelation = '3115'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3115','registry','Tipo residenza (chiave di tabella residence)',{ts '2017-05-22 15:16:57.787'},'nino','residence','Anagrafica')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '67' AND parentcol = 'idaccmotive')
UPDATE [relationcol] SET childcol = 'idaccmotivecredit',lt = {ts '2017-05-20 09:19:36.287'},lu = 'lu' WHERE idrelation = '67' AND parentcol = 'idaccmotive'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('67','idaccmotive','idaccmotivecredit',{ts '2017-05-20 09:19:36.287'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

