
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


-- CREAZIONE TABELLA learningagrtrainer --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[learningagrtrainer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[learningagrtrainer] (
idlearningagrtrainer int NOT NULL,
idiscrizionebmi int NOT NULL,
idbandomi int NOT NULL,
idreg int NOT NULL,
address varchar(100) NULL,
assicurazienda char(1) NULL,
assicuraziendacivile char(1) NULL,
assicuraziendaspost char(1) NULL,
assicuraziendaviagg char(1) NULL,
assicuristituto char(1) NOT NULL,
assicuristitutocivile char(1) NULL,
assicuristitutospost char(1) NULL,
assicuristitutoviagg char(1) NULL,
cap varchar(20) NULL,
capacitaacquis varchar(max) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
ectscf int NULL,
ectstitle varchar(max) NULL,
idcity int NULL,
idlearningagrkind int NOT NULL,
idlearningagrtrainerkind int NOT NULL,
idlearningagrtrainervalut int NULL,
idnation int NULL,
idreg_aziende int NULL,
location varchar(20) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
oresettimana int NOT NULL,
pianomonit varchar(max) NOT NULL,
pianovalut varchar(max) NOT NULL,
programma varchar(max) NOT NULL,
registrainemd char(1) NULL,
registraintor char(1) NULL,
sostaltro decimal(9,2) NULL,
sostazienda decimal(9,2) NULL,
start date NOT NULL,
stop date NOT NULL,
title varchar(max) NOT NULL,
voto int NULL,
 CONSTRAINT xpklearningagrtrainer PRIMARY KEY (idlearningagrtrainer,
idiscrizionebmi,
idbandomi,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA learningagrtrainer --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'idlearningagrtrainer' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD idlearningagrtrainer int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'idlearningagrtrainer' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'idiscrizionebmi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD idiscrizionebmi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'idiscrizionebmi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'idbandomi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD idbandomi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'idbandomi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'address' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD address varchar(100) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN address varchar(100) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'assicurazienda' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD assicurazienda char(1) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN assicurazienda char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'assicuraziendacivile' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD assicuraziendacivile char(1) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN assicuraziendacivile char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'assicuraziendaspost' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD assicuraziendaspost char(1) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN assicuraziendaspost char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'assicuraziendaviagg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD assicuraziendaviagg char(1) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN assicuraziendaviagg char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'assicuristituto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD assicuristituto char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'assicuristituto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN assicuristituto char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'assicuristitutocivile' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD assicuristitutocivile char(1) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN assicuristitutocivile char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'assicuristitutospost' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD assicuristitutospost char(1) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN assicuristitutospost char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'assicuristitutoviagg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD assicuristitutoviagg char(1) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN assicuristitutoviagg char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'cap' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD cap varchar(20) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN cap varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'capacitaacquis' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD capacitaacquis varchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'capacitaacquis' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN capacitaacquis varchar(max) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'ectscf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD ectscf int NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN ectscf int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'ectstitle' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD ectstitle varchar(max) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN ectstitle varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'idcity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD idcity int NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN idcity int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'idlearningagrkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD idlearningagrkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'idlearningagrkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN idlearningagrkind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'idlearningagrtrainerkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD idlearningagrtrainerkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'idlearningagrtrainerkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN idlearningagrtrainerkind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'idlearningagrtrainervalut' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD idlearningagrtrainervalut int NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN idlearningagrtrainervalut int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'idnation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD idnation int NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN idnation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'idreg_aziende' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD idreg_aziende int NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN idreg_aziende int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'location' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD location varchar(20) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN location varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'oresettimana' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD oresettimana int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'oresettimana' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN oresettimana int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'pianomonit' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD pianomonit varchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'pianomonit' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN pianomonit varchar(max) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'pianovalut' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD pianovalut varchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'pianovalut' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN pianovalut varchar(max) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'programma' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD programma varchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'programma' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN programma varchar(max) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'registrainemd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD registrainemd char(1) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN registrainemd char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'registraintor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD registraintor char(1) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN registraintor char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'sostaltro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD sostaltro decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN sostaltro decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'sostazienda' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD sostazienda decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN sostazienda decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD start date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'start' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN start date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD stop date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'stop' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN stop date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD title varchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('learningagrtrainer') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [learningagrtrainer] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN title varchar(max) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'learningagrtrainer' and C.name = 'voto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [learningagrtrainer] ADD voto int NULL 
END
ELSE
	ALTER TABLE [learningagrtrainer] ALTER COLUMN voto int NULL
GO

-- VERIFICA DI learningagrtrainer IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'learningagrtrainer'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','int','ASSISTENZA','idbandomi','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','int','ASSISTENZA','idiscrizionebmi','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','int','ASSISTENZA','idlearningagrtrainer','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','varchar(100)','ASSISTENZA','address','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','char(1)','ASSISTENZA','assicurazienda','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','char(1)','ASSISTENZA','assicuraziendacivile','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','char(1)','ASSISTENZA','assicuraziendaspost','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','char(1)','ASSISTENZA','assicuraziendaviagg','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','char(1)','ASSISTENZA','assicuristituto','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','char(1)','ASSISTENZA','assicuristitutocivile','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','char(1)','ASSISTENZA','assicuristitutospost','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','char(1)','ASSISTENZA','assicuristitutoviagg','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','varchar(20)','ASSISTENZA','cap','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','varchar(max)','ASSISTENZA','capacitaacquis','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','int','ASSISTENZA','ectscf','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','varchar(max)','ASSISTENZA','ectstitle','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','int','ASSISTENZA','idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','int','ASSISTENZA','idlearningagrkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','int','ASSISTENZA','idlearningagrtrainerkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','int','ASSISTENZA','idlearningagrtrainervalut','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','int','ASSISTENZA','idreg_aziende','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','varchar(20)','ASSISTENZA','location','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','int','ASSISTENZA','oresettimana','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','varchar(max)','ASSISTENZA','pianomonit','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','varchar(max)','ASSISTENZA','pianovalut','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','varchar(max)','ASSISTENZA','programma','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','char(1)','ASSISTENZA','registrainemd','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','char(1)','ASSISTENZA','registraintor','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','decimal(9,2)','ASSISTENZA','sostaltro','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','decimal(9,2)','ASSISTENZA','sostazienda','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','date','ASSISTENZA','start','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','date','ASSISTENZA','stop','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','learningagrtrainer','varchar(max)','ASSISTENZA','title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','learningagrtrainer','int','ASSISTENZA','voto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI learningagrtrainer IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'learningagrtrainer')
UPDATE customobject set isreal = 'S' where objectname = 'learningagrtrainer'
ELSE
INSERT INTO customobject (objectname, isreal) values('learningagrtrainer', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'learningagrtrainer')
UPDATE [tabledescr] SET description = '2.2.29 Learning Agreement for traineership (contratto di formazione)
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 13:08:45.223'},lu = 'assistenza',title = 'Learning Agreement for traineership (contratto di formazione)' WHERE tablename = 'learningagrtrainer'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('learningagrtrainer','2.2.29 Learning Agreement for traineership (contratto di formazione)
',null,'N',{ts '2018-07-27 13:08:45.223'},'assistenza','Learning Agreement for traineership (contratto di formazione)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'address' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '100',col_precision = null,col_scale = null,description = 'Indirizzo',kind = 'S',lt = {ts '2019-09-24 13:22:40.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(100)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'address' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('address','learningagrtrainer','100',null,null,'Indirizzo','S',{ts '2019-09-24 13:22:40.997'},'assistenza','N','varchar(100)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'assicurazienda' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Assicurazione dell''azienda',kind = 'S',lt = {ts '2019-02-25 10:57:40.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'assicurazienda' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assicurazienda','learningagrtrainer','1',null,null,'Assicurazione dell''azienda','S',{ts '2019-02-25 10:57:40.640'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'assicuraziendacivile' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Copertura responsabilità civile',kind = 'S',lt = {ts '2019-02-25 10:57:40.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'assicuraziendacivile' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assicuraziendacivile','learningagrtrainer','1',null,null,'Copertura responsabilità civile','S',{ts '2019-02-25 10:57:40.640'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'assicuraziendaspost' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Copertura infortuni negli spostamenti per e dal lavoro',kind = 'S',lt = {ts '2019-02-25 10:57:40.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'assicuraziendaspost' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assicuraziendaspost','learningagrtrainer','1',null,null,'Copertura infortuni negli spostamenti per e dal lavoro','S',{ts '2019-02-25 10:57:40.640'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'assicuraziendaviagg' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Copertura viaggi di lavoro',kind = 'S',lt = {ts '2019-02-25 10:57:40.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'assicuraziendaviagg' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assicuraziendaviagg','learningagrtrainer','1',null,null,'Copertura viaggi di lavoro','S',{ts '2019-02-25 10:57:40.640'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'assicuristituto' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Assicurazione dell''istituto',kind = 'S',lt = {ts '2019-02-25 10:57:40.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'assicuristituto' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assicuristituto','learningagrtrainer','1',null,null,'Assicurazione dell''istituto','S',{ts '2019-02-25 10:57:40.640'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'assicuristitutocivile' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Copertura responsabilità civile',kind = 'S',lt = {ts '2019-02-25 10:57:40.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'assicuristitutocivile' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assicuristitutocivile','learningagrtrainer','1',null,null,'Copertura responsabilità civile','S',{ts '2019-02-25 10:57:40.640'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'assicuristitutospost' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Copertura infortuni negli spostamenti per e dal lavoro',kind = 'S',lt = {ts '2019-02-25 10:57:40.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'assicuristitutospost' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assicuristitutospost','learningagrtrainer','1',null,null,'Copertura infortuni negli spostamenti per e dal lavoro','S',{ts '2019-02-25 10:57:40.640'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'assicuristitutoviagg' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Copertura viaggi di lavoro',kind = 'S',lt = {ts '2019-02-25 10:57:40.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'assicuristitutoviagg' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assicuristitutoviagg','learningagrtrainer','1',null,null,'Copertura viaggi di lavoro','S',{ts '2019-02-25 10:57:40.640'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cap' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'CAP',kind = 'S',lt = {ts '2019-09-24 13:22:40.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cap' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cap','learningagrtrainer','20',null,null,'CAP','S',{ts '2019-09-24 13:22:40.997'},'assistenza','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'capacitaacquis' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Capacità e competenze che verranno acquisite',kind = 'S',lt = {ts '2019-02-25 10:57:40.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'capacitaacquis' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('capacitaacquis','learningagrtrainer','-1',null,null,'Capacità e competenze che verranno acquisite','S',{ts '2019-02-25 10:57:40.640'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-25 10:52:29.303'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','learningagrtrainer','8',null,null,null,'S',{ts '2019-02-25 10:52:29.303'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-25 10:52:29.303'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','learningagrtrainer','64',null,null,null,'S',{ts '2019-02-25 10:52:29.303'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ectscf' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di crediti ECTS',kind = 'S',lt = {ts '2019-02-25 11:01:38.317'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'ectscf' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ectscf','learningagrtrainer','4',null,null,'Numero di crediti ECTS','S',{ts '2019-02-25 11:01:38.317'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ectstitle' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Titolo ECTS',kind = 'S',lt = {ts '2019-02-25 11:01:38.320'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'ectstitle' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ectstitle','learningagrtrainer','-1',null,null,'Titolo ECTS','S',{ts '2019-02-25 11:01:38.320'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandomi' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-28 17:04:33.543'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandomi' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandomi','learningagrtrainer','4',null,null,null,'S',{ts '2019-11-28 17:04:33.543'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcity' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Città',kind = 'S',lt = {ts '2019-09-24 13:22:40.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcity' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcity','learningagrtrainer','4',null,null,'Città','S',{ts '2019-09-24 13:22:40.997'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idiscrizionebmi' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Iscrizione al bando di mobilità internazionale',kind = 'S',lt = {ts '2019-11-28 17:04:33.543'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idiscrizionebmi' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idiscrizionebmi','learningagrtrainer','4',null,null,'Iscrizione al bando di mobilità internazionale','S',{ts '2019-11-28 17:04:33.543'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlearningagrkind' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Fase del tirocinio',kind = 'S',lt = {ts '2019-02-25 11:35:03.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlearningagrkind' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlearningagrkind','learningagrtrainer','4',null,null,'Fase del tirocinio','S',{ts '2019-02-25 11:35:03.723'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlearningagrtrainer' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:08:46.910'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlearningagrtrainer' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlearningagrtrainer','learningagrtrainer','4',null,null,null,'S',{ts '2018-07-27 13:08:46.910'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlearningagrtrainerkind' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2019-02-25 11:35:03.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlearningagrtrainerkind' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlearningagrtrainerkind','learningagrtrainer','4',null,null,'Tipologia','S',{ts '2019-02-25 11:35:03.723'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlearningagrtrainervalut' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo di valutazione finale',kind = 'S',lt = {ts '2019-02-25 11:35:03.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlearningagrtrainervalut' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlearningagrtrainervalut','learningagrtrainer','4',null,null,'Tipo di valutazione finale','S',{ts '2019-02-25 11:35:03.723'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Nazione',kind = 'S',lt = {ts '2019-09-24 13:22:40.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation','learningagrtrainer','4',null,null,'Nazione','S',{ts '2019-09-24 13:22:40.997'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-28 17:04:33.543'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','learningagrtrainer','4',null,null,null,'S',{ts '2019-11-28 17:04:33.543'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_aziende' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Azienda o ente',kind = 'S',lt = {ts '2019-02-25 11:35:03.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_aziende' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_aziende','learningagrtrainer','4',null,null,'Azienda o ente','S',{ts '2019-02-25 11:35:03.723'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'location' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Località',kind = 'S',lt = {ts '2019-09-24 13:22:40.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'location' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('location','learningagrtrainer','20',null,null,'Località','S',{ts '2019-09-24 13:22:40.997'},'assistenza','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-25 10:52:29.307'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','learningagrtrainer','8',null,null,null,'S',{ts '2019-02-25 10:52:29.307'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-25 10:52:29.307'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','learningagrtrainer','64',null,null,null,'S',{ts '2019-02-25 10:52:29.307'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oresettimana' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore di lavoro alla settimana ',kind = 'S',lt = {ts '2019-02-25 11:39:56.477'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oresettimana' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oresettimana','learningagrtrainer','4',null,null,'Ore di lavoro alla settimana ','S',{ts '2019-02-25 11:39:56.477'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pianomonit' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Piano di monitoraggio',kind = 'S',lt = {ts '2019-02-25 11:39:56.480'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'pianomonit' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pianomonit','learningagrtrainer','-1',null,null,'Piano di monitoraggio','S',{ts '2019-02-25 11:39:56.480'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pianovalut' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Piano di valutazione',kind = 'S',lt = {ts '2019-02-25 11:39:56.480'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'pianovalut' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pianovalut','learningagrtrainer','-1',null,null,'Piano di valutazione','S',{ts '2019-02-25 11:39:56.480'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'programma' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:08:46.910'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'programma' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('programma','learningagrtrainer','-1',null,null,null,'S',{ts '2018-07-27 13:08:46.910'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'registrainemd' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Registra l’attività nell’Europass Mobility Document',kind = 'S',lt = {ts '2019-02-25 11:39:56.480'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'registrainemd' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('registrainemd','learningagrtrainer','1',null,null,'Registra l’attività nell’Europass Mobility Document','S',{ts '2019-02-25 11:39:56.480'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'registraintor' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Registra l’attività nel Transcript of records',kind = 'S',lt = {ts '2019-02-25 11:39:56.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'registraintor' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('registraintor','learningagrtrainer','1',null,null,'Registra l’attività nel Transcript of records','S',{ts '2019-02-25 11:39:56.483'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sostaltro' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Sostegni di qualunque altro tipo dell’azienda',kind = 'S',lt = {ts '2019-02-25 11:40:43.197'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'sostaltro' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sostaltro','learningagrtrainer','5','9','2','Sostegni di qualunque altro tipo dell’azienda','S',{ts '2019-02-25 11:40:43.197'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sostazienda' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Sostegno economico dell’azienda',kind = 'S',lt = {ts '2019-02-25 11:40:43.197'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'sostazienda' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sostazienda','learningagrtrainer','5','9','2','Sostegno economico dell’azienda','S',{ts '2019-02-25 11:40:43.197'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data inizio periodo ',kind = 'S',lt = {ts '2019-02-25 10:57:40.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','learningagrtrainer','3',null,null,'Data inizio periodo ','S',{ts '2019-02-25 10:57:40.640'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data fine periodo ',kind = 'S',lt = {ts '2019-02-25 10:57:40.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','learningagrtrainer','3',null,null,'Data fine periodo ','S',{ts '2019-02-25 10:57:40.640'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Titolo del tirocinio ',kind = 'S',lt = {ts '2019-02-25 10:57:40.640'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','learningagrtrainer','-1',null,null,'Titolo del tirocinio ','S',{ts '2019-02-25 10:57:40.640'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'voto' AND tablename = 'learningagrtrainer')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:08:46.913'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'voto' AND tablename = 'learningagrtrainer'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('voto','learningagrtrainer','4',null,null,null,'S',{ts '2018-07-27 13:08:46.913'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

