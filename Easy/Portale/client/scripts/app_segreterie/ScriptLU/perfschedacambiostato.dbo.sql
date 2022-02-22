
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


-- CREAZIONE TABELLA perfschedacambiostato --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfschedacambiostato]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfschedacambiostato] (
idperfschedacambiostato int NOT NULL,
idperfruolo varchar(50) NULL,
idperfruolo_mail varchar(50) NULL,
idperfschedastatus int NULL,
idperfschedastatus_to int NULL,
 CONSTRAINT xpkperfschedacambiostato PRIMARY KEY (idperfschedacambiostato
)
)
END
GO

-- VERIFICA STRUTTURA perfschedacambiostato --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedacambiostato' and C.name = 'idperfschedacambiostato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedacambiostato] ADD idperfschedacambiostato int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfschedacambiostato') and col.name = 'idperfschedacambiostato' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfschedacambiostato] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedacambiostato' and C.name = 'idperfruolo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedacambiostato] ADD idperfruolo varchar(50) NULL 
END
ELSE
	ALTER TABLE [perfschedacambiostato] ALTER COLUMN idperfruolo varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedacambiostato' and C.name = 'idperfruolo_mail' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedacambiostato] ADD idperfruolo_mail varchar(50) NULL 
END
ELSE
	ALTER TABLE [perfschedacambiostato] ALTER COLUMN idperfruolo_mail varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedacambiostato' and C.name = 'idperfschedastatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedacambiostato] ADD idperfschedastatus int NULL 
END
ELSE
	ALTER TABLE [perfschedacambiostato] ALTER COLUMN idperfschedastatus int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfschedacambiostato' and C.name = 'idperfschedastatus_to' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfschedacambiostato] ADD idperfschedastatus_to int NULL 
END
ELSE
	ALTER TABLE [perfschedacambiostato] ALTER COLUMN idperfschedastatus_to int NULL
GO

