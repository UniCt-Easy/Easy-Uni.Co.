
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


-- CREAZIONE TABELLA itineration --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[itineration]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [itineration] (
iditineration int NOT NULL,
active char(1) NULL,
adate date NOT NULL,
additionalannotations varchar(800) NULL,
admincarkm float NULL,
admincarkmcost decimal(19,6) NULL,
advanceapplied char(1) NULL,
advancepercentage decimal(19,8) NULL,
applierannotations varchar(800) NULL,
authdoc varchar(35) NULL,
authdocdate date NULL,
authneeded char(1) NULL,
authorizationdate date NOT NULL,
cancelreason varchar(400) NULL,
clause_accepted char(1) NULL,
completed char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datecompleted date NULL,
description varchar(150) NOT NULL,
flagmove int NULL,
flagoutside char(1) NULL,
flagownfunds char(1) NULL,
flagweb char(1) NULL,
footkm float NULL,
footkmcost decimal(19,6) NULL,
grossfactor float NULL,
idaccmotive varchar(36) NULL,
idaccmotivedebit varchar(36) NULL,
idaccmotivedebit_crg varchar(36) NULL,
idaccmotivedebit_datacrg date NULL,
idauthmodel int NULL,
iddalia_dipartimento int NULL,
iddalia_funzionale int NULL,
iddaliaposition int NULL,
iddaliarecruitmentmotive int NULL,
idforeigncountry int NULL,
iditineration_ref int NULL,
iditinerationstatus smallint NULL,
idman int NULL,
idreg int NOT NULL,
idregistrylegalstatus int NULL,
idregistrypaymethod int NULL,
idser int NOT NULL,
idsor_siope int NULL,
idsor01 int NULL,
idsor02 int NULL,
idsor03 int NULL,
idsor04 int NULL,
idsor05 int NULL,
idsor1 int NULL,
idsor2 int NULL,
idsor3 int NULL,
idupb varchar(36) NULL,
location varchar(65) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
netfee decimal(19,2) NULL,
nfood int NULL,
nitineration int NOT NULL,
noauthreason varchar(1000) NULL,
owncarkm float NULL,
owncarkmcost decimal(19,6) NULL,
rtf image NULL,
start date NOT NULL,
starttime datetime NULL,
stop date NOT NULL,
stoptime datetime NULL,
supposedamount decimal(19,2) NULL,
supposedfood decimal(19,2) NULL,
supposedliving decimal(19,2) NULL,
supposedtravel decimal(19,2) NULL,
totadvance decimal(19,2) NULL,
total decimal(19,2) NULL,
totalgross decimal(19,2) NULL,
txt text NULL,
vehicle_info varchar(200) NULL,
vehicle_motive varchar(2000) NULL,
webwarn varchar(400) NULL,
yitineration smallint NOT NULL,
 CONSTRAINT xpkitineration PRIMARY KEY (iditineration
)
)
END
GO

-- VERIFICA STRUTTURA itineration --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD iditineration int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'iditineration' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'adate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD adate date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'adate' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN adate date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'additionalannotations' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD additionalannotations varchar(800) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN additionalannotations varchar(800) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'admincarkm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD admincarkm float NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN admincarkm float NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'admincarkmcost' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD admincarkmcost decimal(19,6) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN admincarkmcost decimal(19,6) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'advanceapplied' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD advanceapplied char(1) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN advanceapplied char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'advancepercentage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD advancepercentage decimal(19,8) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN advancepercentage decimal(19,8) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'applierannotations' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD applierannotations varchar(800) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN applierannotations varchar(800) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'authdoc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD authdoc varchar(35) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN authdoc varchar(35) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'authdocdate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD authdocdate date NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN authdocdate date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'authneeded' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD authneeded char(1) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN authneeded char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'authorizationdate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD authorizationdate date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'authorizationdate' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN authorizationdate date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'cancelreason' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD cancelreason varchar(400) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN cancelreason varchar(400) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'clause_accepted' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD clause_accepted char(1) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN clause_accepted char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'completed' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD completed char(1) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN completed char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'datecompleted' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD datecompleted date NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN datecompleted date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD description varchar(150) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN description varchar(150) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'flagmove' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD flagmove int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN flagmove int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'flagoutside' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD flagoutside char(1) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN flagoutside char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'flagownfunds' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD flagownfunds char(1) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN flagownfunds char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'flagweb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD flagweb char(1) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN flagweb char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'footkm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD footkm float NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN footkm float NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'footkmcost' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD footkmcost decimal(19,6) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN footkmcost decimal(19,6) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'grossfactor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD grossfactor float NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN grossfactor float NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idaccmotive' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idaccmotive varchar(36) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idaccmotive varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idaccmotivedebit' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idaccmotivedebit varchar(36) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idaccmotivedebit varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idaccmotivedebit_crg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idaccmotivedebit_crg varchar(36) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idaccmotivedebit_crg varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idaccmotivedebit_datacrg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idaccmotivedebit_datacrg date NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idaccmotivedebit_datacrg date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idauthmodel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idauthmodel int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idauthmodel int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'iddalia_dipartimento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD iddalia_dipartimento int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN iddalia_dipartimento int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'iddalia_funzionale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD iddalia_funzionale int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN iddalia_funzionale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'iddaliaposition' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD iddaliaposition int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN iddaliaposition int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'iddaliarecruitmentmotive' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD iddaliarecruitmentmotive int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN iddaliarecruitmentmotive int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idforeigncountry' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idforeigncountry int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idforeigncountry int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'iditineration_ref' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD iditineration_ref int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN iditineration_ref int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'iditinerationstatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD iditinerationstatus smallint NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN iditinerationstatus smallint NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idman' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idman int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idman int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idreg int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idregistrylegalstatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idregistrylegalstatus int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idregistrylegalstatus int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idregistrypaymethod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idregistrypaymethod int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idregistrypaymethod int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idser' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idser int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'idser' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idser int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor_siope' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor_siope int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idsor_siope int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor01' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor01 int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idsor01 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor02' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor02 int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idsor02 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor03' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor03 int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idsor03 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor04' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor04 int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idsor04 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor05' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor05 int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idsor05 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor1' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor1 int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idsor1 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor2 int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idsor2 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor3' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idsor3 int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idsor3 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD idupb varchar(36) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN idupb varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'location' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD location varchar(65) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN location varchar(65) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'netfee' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD netfee decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN netfee decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'nfood' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD nfood int NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN nfood int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'nitineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD nitineration int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'nitineration' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN nitineration int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'noauthreason' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD noauthreason varchar(1000) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN noauthreason varchar(1000) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'owncarkm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD owncarkm float NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN owncarkm float NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'owncarkmcost' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD owncarkmcost decimal(19,6) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN owncarkmcost decimal(19,6) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'rtf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD rtf image NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD start date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'start' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN start date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'starttime' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD starttime datetime NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN starttime datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD stop date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'stop' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN stop date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'stoptime' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD stoptime datetime NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN stoptime datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'supposedamount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD supposedamount decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN supposedamount decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'supposedfood' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD supposedfood decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN supposedfood decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'supposedliving' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD supposedliving decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN supposedliving decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'supposedtravel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD supposedtravel decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN supposedtravel decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'totadvance' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD totadvance decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN totadvance decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'total' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD total decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN total decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'totalgross' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD totalgross decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN totalgross decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'txt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD txt text NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'vehicle_info' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD vehicle_info varchar(200) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN vehicle_info varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'vehicle_motive' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD vehicle_motive varchar(2000) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN vehicle_motive varchar(2000) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'webwarn' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD webwarn varchar(400) NULL 
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN webwarn varchar(400) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'yitineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [itineration] ADD yitineration smallint NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('itineration') and col.name = 'yitineration' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [itineration] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [itineration] ALTER COLUMN yitineration smallint NOT NULL
GO

IF EXISTS (SELECT * FROM sysindexes where name='ukitineration' and id=object_id('itineration'))
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukitineration
     ON itineration (yitineration, nitineration )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE UNIQUE NONCLUSTERED INDEX ukitineration
     ON itineration (yitineration, nitineration )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1itineration' and id=object_id('itineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1itineration
     ON itineration (idreg )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1itineration
     ON itineration (idreg )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2itineration' and id=object_id('itineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2itineration
     ON itineration (idser )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2itineration
     ON itineration (idser )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3itineration' and id=object_id('itineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3itineration
     ON itineration (yitineration, nitineration )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3itineration
     ON itineration (yitineration, nitineration )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi4itineration' and id=object_id('itineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi4itineration
     ON itineration (yitineration, idsor01 )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi4itineration
     ON itineration (yitineration, idsor01 )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi5itineration' and id=object_id('itineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi5itineration
     ON itineration (yitineration, idsor02 )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi5itineration
     ON itineration (yitineration, idsor02 )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi6itineration' and id=object_id('itineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi6itineration
     ON itineration (yitineration, idsor03 )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi6itineration
     ON itineration (yitineration, idsor03 )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi7itineration' and id=object_id('itineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi7itineration
     ON itineration (idsor04 )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi7itineration
     ON itineration (idsor04 )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi8itineration' and id=object_id('itineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi8itineration
     ON itineration (idsor05 )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi8itineration
     ON itineration (idsor05 )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi9itineration' and id=object_id('itineration'))
BEGIN
     CREATE NONCLUSTERED INDEX xi9itineration
     ON itineration (iditineration, iditineration_ref )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi9itineration
     ON itineration (iditineration, iditineration_ref )
ON [PRIMARY]
END
GO

