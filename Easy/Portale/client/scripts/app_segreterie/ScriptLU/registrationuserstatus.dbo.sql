
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


-- GENERAZIONE DATI PER registrationuserstatus --
IF exists(SELECT * FROM [registrationuserstatus] WHERE idregistrationuserstatus = '1')
UPDATE [registrationuserstatus] SET title = 'In attesa' WHERE idregistrationuserstatus = '1'
ELSE
INSERT INTO [registrationuserstatus] (idregistrationuserstatus,title) VALUES ('1','In attesa')
GO

IF exists(SELECT * FROM [registrationuserstatus] WHERE idregistrationuserstatus = '2')
UPDATE [registrationuserstatus] SET title = 'Autorizzata' WHERE idregistrationuserstatus = '2'
ELSE
INSERT INTO [registrationuserstatus] (idregistrationuserstatus,title) VALUES ('2','Autorizzata')
GO

IF exists(SELECT * FROM [registrationuserstatus] WHERE idregistrationuserstatus = '3')
UPDATE [registrationuserstatus] SET title = 'Rifiutata' WHERE idregistrationuserstatus = '3'
ELSE
INSERT INTO [registrationuserstatus] (idregistrationuserstatus,title) VALUES ('3','Rifiutata')
GO

