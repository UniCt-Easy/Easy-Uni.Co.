
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


-- CREAZIONE TABELLA timesheettemplate --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[timesheettemplate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[timesheettemplate] (
idtimesheettemplate varchar(60) NOT NULL,
 CONSTRAINT xpktimesheettemplate PRIMARY KEY (idtimesheettemplate
)
)
END
GO

-- VERIFICA STRUTTURA timesheettemplate --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'timesheettemplate' and C.name = 'idtimesheettemplate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [timesheettemplate] ADD idtimesheettemplate varchar(60) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('timesheettemplate') and col.name = 'idtimesheettemplate' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [timesheettemplate] drop constraint '+@vincolo)
END
GO


-- GENERAZIONE DATI PER timesheettemplate --
IF NOT exists(SELECT * FROM [timesheettemplate] WHERE idtimesheettemplate = 'HORIZON')

INSERT INTO [timesheettemplate] (idtimesheettemplate) VALUES ('HORIZON')
GO

IF NOT exists(SELECT * FROM [timesheettemplate] WHERE idtimesheettemplate = 'PON')

INSERT INTO [timesheettemplate] (idtimesheettemplate) VALUES ('PON')
GO

