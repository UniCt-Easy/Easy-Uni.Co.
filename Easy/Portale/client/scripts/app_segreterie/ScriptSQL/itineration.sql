
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

-- VERIFICA DI itineration IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'itineration'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','int','ASSISTENZA','iditineration','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','char(1)','ASSISTENZA','active','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','date','ASSISTENZA','adate','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','varchar(800)','ASSISTENZA','additionalannotations','800','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','float','ASSISTENZA','admincarkm','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','decimal(19,6)','ASSISTENZA','admincarkmcost','9','N','decimal','System.Decimal','','6','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','char(1)','ASSISTENZA','advanceapplied','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','decimal(19,8)','ASSISTENZA','advancepercentage','9','N','decimal','System.Decimal','','8','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','varchar(800)','ASSISTENZA','applierannotations','800','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','varchar(35)','ASSISTENZA','authdoc','35','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','date','ASSISTENZA','authdocdate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','char(1)','ASSISTENZA','authneeded','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','date','ASSISTENZA','authorizationdate','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','varchar(400)','ASSISTENZA','cancelreason','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','char(1)','ASSISTENZA','clause_accepted','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','char(1)','ASSISTENZA','completed','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','date','ASSISTENZA','datecompleted','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','varchar(150)','ASSISTENZA','description','150','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','flagmove','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','char(1)','ASSISTENZA','flagoutside','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','char(1)','ASSISTENZA','flagownfunds','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','char(1)','ASSISTENZA','flagweb','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','float','ASSISTENZA','footkm','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','decimal(19,6)','ASSISTENZA','footkmcost','9','N','decimal','System.Decimal','','6','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','float','ASSISTENZA','grossfactor','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','varchar(36)','ASSISTENZA','idaccmotive','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','varchar(36)','ASSISTENZA','idaccmotivedebit','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','varchar(36)','ASSISTENZA','idaccmotivedebit_crg','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','date','ASSISTENZA','idaccmotivedebit_datacrg','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idauthmodel','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','iddalia_dipartimento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','iddalia_funzionale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','iddaliaposition','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','iddaliarecruitmentmotive','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idforeigncountry','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','iditineration_ref','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','smallint','ASSISTENZA','iditinerationstatus','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idman','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idregistrylegalstatus','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idregistrypaymethod','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','int','ASSISTENZA','idser','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idsor_siope','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idsor01','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idsor02','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idsor03','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idsor04','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idsor05','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idsor1','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idsor2','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','idsor3','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','varchar(36)','ASSISTENZA','idupb','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','varchar(65)','ASSISTENZA','location','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','decimal(19,2)','ASSISTENZA','netfee','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','int','ASSISTENZA','nfood','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','int','ASSISTENZA','nitineration','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','varchar(1000)','ASSISTENZA','noauthreason','1000','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','float','ASSISTENZA','owncarkm','8','N','float','System.Double','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','decimal(19,6)','ASSISTENZA','owncarkmcost','9','N','decimal','System.Decimal','','6','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','image','ASSISTENZA','rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','date','ASSISTENZA','start','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','datetime','ASSISTENZA','starttime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','date','ASSISTENZA','stop','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','datetime','ASSISTENZA','stoptime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','decimal(19,2)','ASSISTENZA','supposedamount','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','decimal(19,2)','ASSISTENZA','supposedfood','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','decimal(19,2)','ASSISTENZA','supposedliving','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','decimal(19,2)','ASSISTENZA','supposedtravel','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','decimal(19,2)','ASSISTENZA','totadvance','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','decimal(19,2)','ASSISTENZA','total','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','decimal(19,2)','ASSISTENZA','totalgross','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','text','ASSISTENZA','txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','varchar(200)','ASSISTENZA','vehicle_info','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','varchar(2000)','ASSISTENZA','vehicle_motive','2000','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','itineration','varchar(400)','ASSISTENZA','webwarn','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','itineration','smallint','ASSISTENZA','yitineration','2','S','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI itineration IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'itineration')
UPDATE customobject set isreal = 'S' where objectname = 'itineration'
ELSE
INSERT INTO customobject (objectname, isreal) values('itineration', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'itineration')
UPDATE [tabledescr] SET description = 'Missione',idapplication = '1',isdbo = 'N',lt = {ts '1900-01-01 03:00:29.637'},lu = 'nino',title = 'Missione' WHERE tablename = 'itineration'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('itineration','Missione','1','N',{ts '1900-01-01 03:00:29.637'},'nino','Missione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'attivo',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','itineration','1',null,null,'attivo','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'adate' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'data contabile',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'adate' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('adate','itineration','3',null,null,'data contabile','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'additionalannotations' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '800',col_precision = null,col_scale = null,description = 'Richieste aggiuntive sulla missione',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(800)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'additionalannotations' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('additionalannotations','itineration','800',null,null,'Richieste aggiuntive sulla missione','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','varchar(800)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'admincarkm' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Km percorsi con mezzo amministrazione',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'float',sql_type = 'float',system_type = 'System.Double' WHERE colname = 'admincarkm' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('admincarkm','itineration','8',null,null,'Km percorsi con mezzo amministrazione','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','float','float','System.Double')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'admincarkmcost' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '6',description = 'Costo a Km per utilizzo mezzo amministrazione',kind = 'S',lt = {ts '2016-02-05 09:24:06.983'},lu = 'Nino',primarykey = 'N',sql_declaration = 'decimal(19,6)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'admincarkmcost' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('admincarkmcost','itineration','9','19','6','Costo a Km per utilizzo mezzo amministrazione','S',{ts '2016-02-05 09:24:06.983'},'Nino','N','decimal(19,6)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'advanceapplied' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.830'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'advanceapplied' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('advanceapplied','itineration','1',null,null,null,'S',{ts '2019-05-03 11:27:44.830'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'advancepercentage' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '8',description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.830'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,8)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'advancepercentage' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('advancepercentage','itineration','9','19','8',null,'S',{ts '2019-05-03 11:27:44.830'},'assistenza','N','decimal(19,8)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'applierannotations' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '800',col_precision = null,col_scale = null,description = 'Appunti per il pagamento',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(800)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'applierannotations' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('applierannotations','itineration','800',null,null,'Appunti per il pagamento','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','varchar(800)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'authdoc' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '35',col_precision = null,col_scale = null,description = 'Doc. autorizzazione',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(35)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'authdoc' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('authdoc','itineration','35',null,null,'Doc. autorizzazione','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','varchar(35)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'authdocdate' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data autorizzazione',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'authdocdate' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('authdocdate','itineration','3',null,null,'Data autorizzazione','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'authemployer' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Autorizzazione da sede di appartenenza',kind = 'S',lt = {ts '2019-05-03 11:34:24.733'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'authemployer' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('authemployer','itineration','1',null,null,'Autorizzazione da sede di appartenenza','S',{ts '2019-05-03 11:34:24.733'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'authneeded' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Autorizzaz. richiesta',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'authneeded' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('authneeded','itineration','1',null,null,'Autorizzaz. richiesta','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'authorizationdate' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data autorizz.',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'authorizationdate' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('authorizationdate','itineration','3',null,null,'Data autorizz.','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cancelreason' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '400',col_precision = null,col_scale = null,description = 'Motivo rifiuto richiesta',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(400)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cancelreason' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cancelreason','itineration','400',null,null,'Motivo rifiuto richiesta','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','varchar(400)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'clause_accepted' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Accetta la clausola per utilizzo mezzo indicato',kind = 'C',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'clause_accepted' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('clause_accepted','itineration','1',null,null,'Accetta la clausola per utilizzo mezzo indicato','C',{ts '2019-06-13 13:24:10.857'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'completed' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Considera eseguito quindi pagabile',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'completed' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('completed','itineration','1',null,null,'Considera eseguito quindi pagabile','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','itineration','8',null,null,'data creazione','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','itineration','64',null,null,'nome utente creazione','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datecompleted' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'data acquisizione documentazione definitiva',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datecompleted' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datecompleted','itineration','3',null,null,'data acquisizione documentazione definitiva','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '150',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(150)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','itineration','150',null,null,'Descrizione','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','varchar(150)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'destination' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Presso',kind = 'S',lt = {ts '2019-05-03 11:34:24.733'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'destination' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('destination','itineration','2048',null,null,'Presso','S',{ts '2019-05-03 11:34:24.733'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'differentlocation' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Località non corrispondente a sede di servizio',kind = 'S',lt = {ts '2020-10-28 11:31:17.543'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'differentlocation' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('differentlocation','itineration','1',null,null,'Località non corrispondente a sede di servizio','S',{ts '2020-10-28 11:31:17.543'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'extension' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = 'Tabella che estende il record',kind = 'S',lt = {ts '2019-06-13 13:24:20.703'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'extension' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('extension','itineration','200',null,null,'Tabella che estende il record','S',{ts '2019-06-13 13:24:20.703'},'assistenza','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagmove' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.830'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'flagmove' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagmove','itineration','4',null,null,null,'S',{ts '2019-05-03 11:27:44.830'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagoutside' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagoutside' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagoutside','itineration','1',null,null,null,'S',{ts '2019-05-03 11:27:44.833'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagownfunds' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagownfunds' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagownfunds','itineration','1',null,null,null,'S',{ts '2019-05-03 11:27:44.833'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagweb' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Missione inserita mediante interfaccia web',kind = 'C',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagweb' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagweb','itineration','1',null,null,'Missione inserita mediante interfaccia web','C',{ts '2019-06-13 13:24:10.857'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'footkm' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Km percorsi a piedi',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'float',sql_type = 'float',system_type = 'System.Double' WHERE colname = 'footkm' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('footkm','itineration','8',null,null,'Km percorsi a piedi','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','float','float','System.Double')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'footkmcost' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '6',description = 'Costo a Km per percorso a piedi',kind = 'S',lt = {ts '2016-02-05 09:24:06.983'},lu = 'Nino',primarykey = 'N',sql_declaration = 'decimal(19,6)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'footkmcost' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('footkmcost','itineration','9','19','6','Costo a Km per percorso a piedi','S',{ts '2016-02-05 09:24:06.983'},'Nino','N','decimal(19,6)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'grossfactor' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Coeff. di lordizzazione',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'float',sql_type = 'float',system_type = 'System.Double' WHERE colname = 'grossfactor' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('grossfactor','itineration','8',null,null,'Coeff. di lordizzazione','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','float','float','System.Double')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotive' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'id causale (tabella acccmotive)',kind = 'S',lt = {ts '2019-06-13 13:24:10.857'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotive' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotive','itineration','36',null,null,'id causale (tabella acccmotive)','S',{ts '2019-06-13 13:24:10.857'},'assistenza','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotivedebit' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'Id della causale di debito (tabella accmotive) ',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotivedebit' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotivedebit','itineration','36',null,null,'Id della causale di debito (tabella accmotive) ','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotivedebit_crg' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'Id causale di debito - correzione (tabella accmotive)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotivedebit_crg' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotivedebit_crg','itineration','36',null,null,'Id causale di debito - correzione (tabella accmotive)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotivedebit_datacrg' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data correzione causale di debito',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'idaccmotivedebit_datacrg' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotivedebit_datacrg','itineration','3',null,null,'Data correzione causale di debito','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idauthmodel' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id modello autorizzativo (tabella authmodel)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idauthmodel' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idauthmodel','itineration','4',null,null,'id modello autorizzativo (tabella authmodel)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcity_start' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Località di partenza se diversa da quella di servizio',kind = 'S',lt = {ts '2020-10-28 11:31:17.550'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcity_start' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcity_start','itineration','4',null,null,'Località di partenza se diversa da quella di servizio','S',{ts '2020-10-28 11:31:17.550'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddaliaposition' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice qualifica Dalia',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddaliaposition' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddaliaposition','itineration','4',null,null,'Codice qualifica Dalia','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddaliarecruitmentmotive' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddaliarecruitmentmotive' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddaliarecruitmentmotive','itineration','4',null,null,null,'S',{ts '2019-05-03 11:27:44.833'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idforeigncountry' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idforeigncountry' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idforeigncountry','itineration','4',null,null,null,'S',{ts '2019-05-03 11:27:44.833'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iditineration' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id missione (tabella itineration)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iditineration' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iditineration','itineration','4',null,null,'id missione (tabella itineration)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iditineration_ref' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iditineration_ref' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iditineration_ref','itineration','4',null,null,null,'S',{ts '2019-05-03 11:27:44.833'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iditinerationstatus' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'ID Stato missione (tabella itinerationstatus)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'iditinerationstatus' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iditinerationstatus','itineration','2',null,null,'ID Stato missione (tabella itinerationstatus)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','smallint','smallint','System.Int16')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idman' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id responsabile (tabella manager)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idman' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idman','itineration','4',null,null,'id responsabile (tabella manager)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id anagrafica (tabella registry)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','itineration','4',null,null,'id anagrafica (tabella registry)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistrylegalstatus' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id progressivo pos. giuridica',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistrylegalstatus' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistrylegalstatus','itineration','4',null,null,'id progressivo pos. giuridica','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistrypaymethod' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistrypaymethod' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistrypaymethod','itineration','4',null,null,null,'S',{ts '2019-05-03 11:27:44.833'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idser' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'chiave prestazione (tabella service)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idser' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idser','itineration','4',null,null,'chiave prestazione (tabella service)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor_siope' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id della class. siope (idsor di sorting) per il costo',kind = 'S',lt = {ts '2018-03-23 14:12:37.207'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor_siope' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor_siope','itineration','4',null,null,'id della class. siope (idsor di sorting) per il costo','S',{ts '2018-03-23 14:12:37.207'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor01' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 1(tabella sorting)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor01' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor01','itineration','4',null,null,'id voce class.sicurezza 1(tabella sorting)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor02' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 2(tabella sorting)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor02' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor02','itineration','4',null,null,'id voce class.sicurezza 2(tabella sorting)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor03' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 3(tabella sorting)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor03' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor03','itineration','4',null,null,'id voce class.sicurezza 3(tabella sorting)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor04' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 4(tabella sorting)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor04' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor04','itineration','4',null,null,'id voce class.sicurezza 4(tabella sorting)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor05' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce class.sicurezza 5(tabella sorting)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor05' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor05','itineration','4',null,null,'id voce class.sicurezza 5(tabella sorting)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor1' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce analitica 1(tabella sorting)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor1' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor1','itineration','4',null,null,'id voce analitica 1(tabella sorting)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor2' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce analitica 2(tabella sorting)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor2' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor2','itineration','4',null,null,'id voce analitica 2(tabella sorting)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsor3' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id voce analitica 3(tabella sorting)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsor3' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsor3','itineration','4',null,null,'id voce analitica 3(tabella sorting)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idupb' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'id voce upb (tabella upb)',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idupb' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idupb','itineration','36',null,null,'id voce upb (tabella upb)','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'location' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '65',col_precision = null,col_scale = null,description = 'ubicazione',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(65)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'location' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('location','itineration','65',null,null,'ubicazione','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','varchar(65)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '2019-06-13 13:24:10.860'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','itineration','8',null,null,'data ultima modifica','S',{ts '2019-06-13 13:24:10.860'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '2019-06-13 13:24:10.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','itineration','64',null,null,'nome ultimo utente modifica','S',{ts '2019-06-13 13:24:10.863'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'netfee' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Importo Netto',kind = 'S',lt = {ts '1900-01-01 03:00:17.237'},lu = 'nino',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'netfee' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('netfee','itineration','9','19','2','Importo Netto','S',{ts '1900-01-01 03:00:17.237'},'nino','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nfood' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'nfood' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nfood','itineration','4',null,null,null,'S',{ts '2019-05-03 11:27:44.833'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nitineration' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Num. miss.',kind = 'S',lt = {ts '2019-06-13 13:24:10.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'nitineration' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nitineration','itineration','4',null,null,'Num. miss.','S',{ts '2019-06-13 13:24:10.863'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'noauthreason' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '1000',col_precision = null,col_scale = null,description = 'Motivo di rifiuto autorizzazione',kind = 'S',lt = {ts '2019-06-13 13:24:10.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1000)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'noauthreason' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('noauthreason','itineration','1000',null,null,'Motivo di rifiuto autorizzazione','S',{ts '2019-06-13 13:24:10.863'},'assistenza','N','varchar(1000)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'othervehicle' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Sussistenza motivi che prevedono utilizzo mezzi diversi da treno o aereo',kind = 'S',lt = {ts '2019-05-03 11:34:24.733'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'othervehicle' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('othervehicle','itineration','1',null,null,'Sussistenza motivi che prevedono utilizzo mezzi diversi da treno o aereo','S',{ts '2019-05-03 11:34:24.733'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'othervehiclereason' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Motivazioni',kind = 'S',lt = {ts '2019-05-03 11:34:24.733'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'othervehiclereason' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('othervehiclereason','itineration','-1',null,null,'Motivazioni','S',{ts '2019-05-03 11:34:24.733'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'owncarkm' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Km percorsi con mezzo proprio',kind = 'S',lt = {ts '2019-06-13 13:24:10.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'float',sql_type = 'float',system_type = 'System.Double' WHERE colname = 'owncarkm' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('owncarkm','itineration','8',null,null,'Km percorsi con mezzo proprio','S',{ts '2019-06-13 13:24:10.863'},'assistenza','N','float','float','System.Double')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'owncarkmcost' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '6',description = 'Costo a Km per utilizzo mezzo proprio',kind = 'S',lt = {ts '2016-02-05 09:24:06.983'},lu = 'Nino',primarykey = 'N',sql_declaration = 'decimal(19,6)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'owncarkmcost' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('owncarkmcost','itineration','9','19','6','Costo a Km per utilizzo mezzo proprio','S',{ts '2016-02-05 09:24:06.983'},'Nino','N','decimal(19,6)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'regulationaccept' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Conoscenza regolamento',kind = 'S',lt = {ts '2019-05-03 11:34:24.733'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'regulationaccept' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('regulationaccept','itineration','1',null,null,'Conoscenza regolamento','S',{ts '2019-05-03 11:34:24.733'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rtf' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'allegati',kind = 'S',lt = {ts '2019-06-13 13:24:10.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'image',sql_type = 'image',system_type = 'System.Byte[]' WHERE colname = 'rtf' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rtf','itineration','16',null,null,'allegati','S',{ts '2019-06-13 13:24:10.863'},'assistenza','N','image','image','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'data inizio',kind = 'S',lt = {ts '2019-06-13 13:24:10.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','itineration','3',null,null,'data inizio','S',{ts '2019-06-13 13:24:10.863'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'startreason' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Motivi che giustificano Località di partenza diversa diversa',kind = 'S',lt = {ts '2019-05-03 11:34:24.733'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'startreason' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('startreason','itineration','-1',null,null,'Motivi che giustificano Località di partenza diversa diversa','S',{ts '2019-05-03 11:34:24.733'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'starttime' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-05-14 16:07:21.700'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'starttime' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('starttime','itineration','8',null,null,null,'S',{ts '2019-05-14 16:07:21.700'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'data fine',kind = 'S',lt = {ts '2019-06-13 13:24:10.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','itineration','3',null,null,'data fine','S',{ts '2019-06-13 13:24:10.863'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stoptime' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-05-14 16:07:21.700'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stoptime' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stoptime','itineration','8',null,null,null,'S',{ts '2019-05-14 16:07:21.700'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'supposedamount' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'supposedamount' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('supposedamount','itineration','9','19','2',null,'S',{ts '2019-05-03 11:27:44.833'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'supposedfood' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'supposedfood' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('supposedfood','itineration','9','19','2',null,'S',{ts '2019-05-03 11:27:44.833'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'supposedliving' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'supposedliving' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('supposedliving','itineration','9','19','2',null,'S',{ts '2019-05-03 11:27:44.833'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'supposedtravel' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = null,kind = 'S',lt = {ts '2019-05-03 11:27:44.833'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'supposedtravel' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('supposedtravel','itineration','9','19','2',null,'S',{ts '2019-05-03 11:27:44.833'},'assistenza','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totadvance' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Anticipo',kind = 'S',lt = {ts '1900-01-01 03:00:17.243'},lu = 'nino',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totadvance' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totadvance','itineration','9','19','2','Anticipo','S',{ts '1900-01-01 03:00:17.243'},'nino','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'total' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Totale',kind = 'S',lt = {ts '1900-01-01 03:00:09.937'},lu = 'nino',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'total' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('total','itineration','9','19','2','Totale','S',{ts '1900-01-01 03:00:09.937'},'nino','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totalgross' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '9',col_precision = '19',col_scale = '2',description = 'Importo Lordo',kind = 'S',lt = {ts '1900-01-01 03:00:17.247'},lu = 'nino',primarykey = 'N',sql_declaration = 'decimal(19,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totalgross' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totalgross','itineration','9','19','2','Importo Lordo','S',{ts '1900-01-01 03:00:17.247'},'nino','N','decimal(19,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'note testuali',kind = 'S',lt = {ts '2019-06-13 13:24:10.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'text',sql_type = 'text',system_type = 'System.String' WHERE colname = 'txt' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt','itineration','16',null,null,'note testuali','S',{ts '2019-06-13 13:24:10.863'},'assistenza','N','text','text','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'vehicle_info' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = 'Dati identificativi del veicolo',kind = 'S',lt = {ts '2019-06-13 13:24:10.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'vehicle_info' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('vehicle_info','itineration','200',null,null,'Dati identificativi del veicolo','S',{ts '2019-06-13 13:24:10.863'},'assistenza','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'vehicle_motive' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '2000',col_precision = null,col_scale = null,description = 'Causale per utilizzo mezzo',kind = 'S',lt = {ts '2019-06-13 13:24:10.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2000)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'vehicle_motive' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('vehicle_motive','itineration','2000',null,null,'Causale per utilizzo mezzo','S',{ts '2019-06-13 13:24:10.863'},'assistenza','N','varchar(2000)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'webwarn' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '400',col_precision = null,col_scale = null,description = 'Avvisi per il Richiedente',kind = 'S',lt = {ts '2019-06-13 13:24:10.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(400)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'webwarn' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('webwarn','itineration','400',null,null,'Avvisi per il Richiedente','S',{ts '2019-06-13 13:24:10.863'},'assistenza','N','varchar(400)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'yitineration' AND tablename = 'itineration')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'Eserc. miss.',kind = 'S',lt = {ts '2019-06-13 13:24:10.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'yitineration' AND tablename = 'itineration'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('yitineration','itineration','2',null,null,'Eserc. miss.','S',{ts '2019-06-13 13:24:10.863'},'assistenza','N','smallint','smallint','System.Int16')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colvalue --
IF exists(SELECT * FROM [colvalue] WHERE colname = 'clause_accepted' AND tablename = 'itineration' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-05 09:24:06.983'},lu = 'Nino',title = 'Non accetta la clausola per utilizzo mezzo indicato' WHERE colname = 'clause_accepted' AND tablename = 'itineration' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('clause_accepted','itineration','N',null,{ts '2016-02-05 09:24:06.983'},'Nino','Non accetta la clausola per utilizzo mezzo indicato')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'clause_accepted' AND tablename = 'itineration' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-05 09:24:06.983'},lu = 'Nino',title = 'Accetta la clausola per utilizzo mezzo indicato' WHERE colname = 'clause_accepted' AND tablename = 'itineration' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('clause_accepted','itineration','S',null,{ts '2016-02-05 09:24:06.983'},'Nino','Accetta la clausola per utilizzo mezzo indicato')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagweb' AND tablename = 'itineration' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-05 09:24:06.983'},lu = 'Nino',title = 'Missione inserita mediante interfaccia windows' WHERE colname = 'flagweb' AND tablename = 'itineration' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagweb','itineration','N',null,{ts '2016-02-05 09:24:06.983'},'Nino','Missione inserita mediante interfaccia windows')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagweb' AND tablename = 'itineration' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-05 09:24:06.983'},lu = 'Nino',title = 'Missione inserita mediante interfaccia web' WHERE colname = 'flagweb' AND tablename = 'itineration' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagweb','itineration','S',null,{ts '2016-02-05 09:24:06.983'},'Nino','Missione inserita mediante interfaccia web')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '43')
UPDATE [relation] SET childtable = 'itineration',description = 'id causale (tabella acccmotive)',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Missione' WHERE idrelation = '43'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('43','itineration','id causale (tabella acccmotive)',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '44')
UPDATE [relation] SET childtable = 'itineration',description = 'Id della causale di debito (tabella accmotive) ',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Missione' WHERE idrelation = '44'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('44','itineration','Id della causale di debito (tabella accmotive) ',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '45')
UPDATE [relation] SET childtable = 'itineration',description = 'Id causale di debito - correzione (tabella accmotive)',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Missione' WHERE idrelation = '45'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('45','itineration','Id causale di debito - correzione (tabella accmotive)',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '289')
UPDATE [relation] SET childtable = 'itineration',description = 'id modello autorizzativo (tabella authmodel)',lt = {ts '2017-05-20 09:19:40.527'},lu = 'lu',parenttable = 'authmodel',title = 'Missione' WHERE idrelation = '289'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('289','itineration','id modello autorizzativo (tabella authmodel)',{ts '2017-05-20 09:19:40.527'},'lu','authmodel','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1086')
UPDATE [relation] SET childtable = 'itineration',description = 'ID Stato missione (tabella itinerationstatus)',lt = {ts '2017-05-20 09:19:56.457'},lu = 'lu',parenttable = 'itinerationstatus',title = 'Missione' WHERE idrelation = '1086'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1086','itineration','ID Stato missione (tabella itinerationstatus)',{ts '2017-05-20 09:19:56.457'},'lu','itinerationstatus','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1158')
UPDATE [relation] SET childtable = 'itineration',description = 'id responsabile (tabella manager)',lt = {ts '2017-05-20 09:19:59.413'},lu = 'lu',parenttable = 'manager',title = 'Missione' WHERE idrelation = '1158'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1158','itineration','id responsabile (tabella manager)',{ts '2017-05-20 09:19:59.413'},'lu','manager','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2070')
UPDATE [relation] SET childtable = 'itineration',description = 'id anagrafica (tabella registry)',lt = {ts '2017-05-20 09:20:05.860'},lu = 'lu',parenttable = 'registry',title = 'Missione' WHERE idrelation = '2070'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2070','itineration','id anagrafica (tabella registry)',{ts '2017-05-20 09:20:05.860'},'lu','registry','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2114')
UPDATE [relation] SET childtable = 'itineration',description = 'id anagrafica (tabella registry)',lt = {ts '2017-05-20 09:20:06.510'},lu = 'lu',parenttable = 'registrylegalstatus',title = 'Missione' WHERE idrelation = '2114'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2114','itineration','id anagrafica (tabella registry)',{ts '2017-05-20 09:20:06.510'},'lu','registrylegalstatus','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2124')
UPDATE [relation] SET childtable = 'itineration',description = 'id anagrafica (tabella registry)',lt = {ts '2017-05-20 09:20:06.810'},lu = 'lu',parenttable = 'registrytaxablestatus',title = 'Missione' WHERE idrelation = '2124'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2124','itineration','id anagrafica (tabella registry)',{ts '2017-05-20 09:20:06.810'},'lu','registrytaxablestatus','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2162')
UPDATE [relation] SET childtable = 'itineration',description = 'chiave prestazione (tabella service)',lt = {ts '2017-05-20 09:20:07.867'},lu = 'lu',parenttable = 'service',title = 'Missione' WHERE idrelation = '2162'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2162','itineration','chiave prestazione (tabella service)',{ts '2017-05-20 09:20:07.867'},'lu','service','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2367')
UPDATE [relation] SET childtable = 'itineration',description = 'id voce class.sicurezza 1(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Missione' WHERE idrelation = '2367'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2367','itineration','id voce class.sicurezza 1(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2368')
UPDATE [relation] SET childtable = 'itineration',description = 'id voce class.sicurezza 2(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Missione' WHERE idrelation = '2368'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2368','itineration','id voce class.sicurezza 2(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2369')
UPDATE [relation] SET childtable = 'itineration',description = 'id voce class.sicurezza 3(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Missione' WHERE idrelation = '2369'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2369','itineration','id voce class.sicurezza 3(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2370')
UPDATE [relation] SET childtable = 'itineration',description = 'id voce class.sicurezza 4(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Missione' WHERE idrelation = '2370'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2370','itineration','id voce class.sicurezza 4(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2371')
UPDATE [relation] SET childtable = 'itineration',description = 'id voce class.sicurezza 5(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Missione' WHERE idrelation = '2371'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2371','itineration','id voce class.sicurezza 5(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2372')
UPDATE [relation] SET childtable = 'itineration',description = 'id voce analitica 1(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Missione' WHERE idrelation = '2372'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2372','itineration','id voce analitica 1(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2373')
UPDATE [relation] SET childtable = 'itineration',description = 'id voce analitica 2(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Missione' WHERE idrelation = '2373'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2373','itineration','id voce analitica 2(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2374')
UPDATE [relation] SET childtable = 'itineration',description = 'id voce analitica 3(tabella sorting)',lt = {ts '2017-05-20 09:20:08.830'},lu = 'lu',parenttable = 'sorting',title = 'Missione' WHERE idrelation = '2374'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2374','itineration','id voce analitica 3(tabella sorting)',{ts '2017-05-20 09:20:08.830'},'lu','sorting','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2812')
UPDATE [relation] SET childtable = 'itineration',description = 'id voce upb (tabella upb)',lt = {ts '2017-05-20 09:20:13.387'},lu = 'lu',parenttable = 'upb',title = 'Missione' WHERE idrelation = '2812'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2812','itineration','id voce upb (tabella upb)',{ts '2017-05-20 09:20:13.387'},'lu','upb','Missione')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3073')
UPDATE [relation] SET childtable = 'itineration',description = 'Qualifica dalia',lt = {ts '2017-05-22 12:38:03.390'},lu = 'nino',parenttable = 'dalia_position',title = 'Missione' WHERE idrelation = '3073'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3073','itineration','Qualifica dalia',{ts '2017-05-22 12:38:03.390'},'nino','dalia_position','Missione')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '43' AND parentcol = 'idaccmotive')
UPDATE [relationcol] SET childcol = 'idaccmotive',lt = {ts '2017-05-20 09:19:36.287'},lu = 'lu' WHERE idrelation = '43' AND parentcol = 'idaccmotive'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('43','idaccmotive','idaccmotive',{ts '2017-05-20 09:19:36.287'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

