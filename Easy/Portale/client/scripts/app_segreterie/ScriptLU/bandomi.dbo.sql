
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


-- CREAZIONE TABELLA bandomi --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[bandomi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[bandomi] (
idbandomi int NOT NULL,
aa nvarchar(9) NULL,
cfminimi decimal(9,2) NULL,
codice varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datariferimentorequisiti date NULL,
durata int NULL,
idaccordoscambiomi int NOT NULL,
idassicurazione int NULL,
idbandomobilitaintkind int NOT NULL,
idduratakind int NULL,
idgraduatoria int NULL,
idprogrammami int NOT NULL,
idresidence int NULL,
idstruttura int NOT NULL,
iscrittonellanno char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maxpreferenze int NULL,
mediaminima decimal(9,2) NULL,
nessundebito char(1) NULL,
numeroesamiminimo int NULL,
startcandidature datetime NOT NULL,
startgraduatoria datetime NOT NULL,
startpermanenza date NULL,
startpresentazione datetime NOT NULL,
stopcadidature datetime NOT NULL,
stopgraduatoria datetime NOT NULL,
stoppermanenza date NULL,
stoppresentazione datetime NOT NULL,
testodomanda varchar(max) NULL,
title varchar(max) NOT NULL,
titolodomanda varchar(max) NULL,
 CONSTRAINT xpkbandomi PRIMARY KEY (idbandomi
)
)
END
GO

-- VERIFICA STRUTTURA bandomi --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idbandomi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idbandomi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'idbandomi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD aa nvarchar(9) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN aa nvarchar(9) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'cfminimi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD cfminimi decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN cfminimi decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD codice varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'codice' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN codice varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'datariferimentorequisiti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD datariferimentorequisiti date NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN datariferimentorequisiti date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'durata' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD durata int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN durata int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idaccordoscambiomi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idaccordoscambiomi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'idaccordoscambiomi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idaccordoscambiomi int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idassicurazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idassicurazione int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idassicurazione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idbandomobilitaintkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idbandomobilitaintkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'idbandomobilitaintkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idbandomobilitaintkind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idduratakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idduratakind int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idduratakind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idgraduatoria' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idgraduatoria int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idgraduatoria int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idprogrammami' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idprogrammami int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'idprogrammami' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idprogrammami int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idresidence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idresidence int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idresidence int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idstruttura int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'iscrittonellanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD iscrittonellanno char(1) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN iscrittonellanno char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'maxpreferenze' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD maxpreferenze int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN maxpreferenze int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'mediaminima' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD mediaminima decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN mediaminima decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'nessundebito' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD nessundebito char(1) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN nessundebito char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'numeroesamiminimo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD numeroesamiminimo int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN numeroesamiminimo int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'startcandidature' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD startcandidature datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'startcandidature' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN startcandidature datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'startgraduatoria' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD startgraduatoria datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'startgraduatoria' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN startgraduatoria datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'startpermanenza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD startpermanenza date NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN startpermanenza date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'startpresentazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD startpresentazione datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'startpresentazione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN startpresentazione datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'stopcadidature' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD stopcadidature datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'stopcadidature' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN stopcadidature datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'stopgraduatoria' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD stopgraduatoria datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'stopgraduatoria' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN stopgraduatoria datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'stoppermanenza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD stoppermanenza date NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN stoppermanenza date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'stoppresentazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD stoppresentazione datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'stoppresentazione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN stoppresentazione datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'testodomanda' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD testodomanda varchar(max) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN testodomanda varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD title varchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN title varchar(max) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'titolodomanda' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD titolodomanda varchar(max) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN titolodomanda varchar(max) NULL
GO

