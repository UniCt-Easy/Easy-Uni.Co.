
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


-- Aggiornamento tabella FINVAR e tabelle dipendenti
-- Le tabelle dipendenti sono:

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER
if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_finvar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_finvar]
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finvar' and C.name = 'variationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finvar] ADD variationkindint tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [finvar] ALTER COLUMN variationkindint tinyint NULL 
END
GO

-- Codifica - N (Normale) = 1; R (Ripartizione) = 2; A (Assestamento) = 3; S (Storno) = 4
UPDATE finvar SET variationkindint =
CASE
	WHEN variationkind = 'N' THEN 1
	WHEN variationkind = 'R' THEN 2
	WHEN variationkind = 'A' THEN 3
	WHEN variationkind = 'S' THEN 4
	ELSE 1
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finvar'
		and C.name ='variationkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finvar] DROP COLUMN variationkind
	DELETE FROM columntypes WHERE tablename = 'finvar' AND field = 'variationkind'
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finvar' and C.name = 'variationkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [finvar] ADD variationkind tinyint NULL
END
ELSE
BEGIN
	ALTER TABLE [finvar] ALTER COLUMN variationkind tinyint NULL 
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finvar' and C.name = 'variationkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finvar SET variationkind = variationkindint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'finvar'
		and C.name ='variationkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [finvar] DROP COLUMN variationkindint
END
GO

ALTER TABLE [finvar] ALTER COLUMN variationkind tinyint NOT NULL 
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'finvar' AND field = 'variationkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-24 17:16:31.967'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-24 17:16:31.967'} WHERE tablename = 'finvar' AND field = 'variationkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('finvar','variationkind','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-24 17:16:31.967'},'''NINO''','NINO',{ts '2007-10-24 17:16:31.967'})
GO
