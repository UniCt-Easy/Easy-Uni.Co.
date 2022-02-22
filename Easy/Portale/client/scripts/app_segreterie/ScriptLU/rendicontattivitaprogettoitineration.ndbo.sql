
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE TABELLA rendicontattivitaprogettoitineration --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoitineration]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [rendicontattivitaprogettoitineration] (
iditineration int NOT NULL,
idrendicontattivitaprogetto int NOT NULL,
idworkpackage int NOT NULL,
idprogetto int NOT NULL,
 CONSTRAINT xpkrendicontattivitaprogettoitineration PRIMARY KEY (iditineration,
idrendicontattivitaprogetto,
idworkpackage,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA rendicontattivitaprogettoitineration --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoitineration' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoitineration] ADD iditineration int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoitineration') and col.name = 'iditineration' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoitineration] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoitineration' and C.name = 'idrendicontattivitaprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoitineration] ADD idrendicontattivitaprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoitineration') and col.name = 'idrendicontattivitaprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoitineration] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoitineration' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoitineration] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoitineration') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoitineration] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoitineration' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoitineration] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoitineration') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoitineration] drop constraint '+@vincolo)
END
GO

