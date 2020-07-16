/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿-- Aggiornamento tabelle in cui è presente MOVKIND
-- Le tabelle dipendenti sono:
-- expenseinvoice, expenseitineration, expensemandate, expenseprofservice, expensevar, incomeestimate, incomeinvoice, incomevar, pettycashoperationitineration

-- Passo 0.bis: Rimozione dei Trigger NON CI SONO TRIGGER
IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseinvoice' and C.name = 'movkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseinvoice] ADD movkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [expenseinvoice] ALTER COLUMN movkindint smallint NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseitineration' and C.name = 'movkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseitineration] ADD movkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [expenseitineration] ALTER COLUMN movkindint smallint NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensemandate' and C.name = 'movkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensemandate] ADD movkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [expensemandate] ALTER COLUMN movkindint smallint NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseprofservice' and C.name = 'movkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseprofservice] ADD movkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [expenseprofservice] ALTER COLUMN movkindint smallint NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'movkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensevar] ADD movkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [expensevar] ALTER COLUMN movkindint smallint NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeestimate' and C.name = 'movkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeestimate] ADD movkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [incomeestimate] ALTER COLUMN movkindint smallint NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeinvoice' and C.name = 'movkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeinvoice] ADD movkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [incomeinvoice] ALTER COLUMN movkindint smallint NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomevar' and C.name = 'movkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomevar] ADD movkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [incomevar] ALTER COLUMN movkindint smallint NULL 
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationitineration' and C.name = 'movkindint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationitineration] ADD movkindint smallint NULL
END
ELSE
BEGIN
	ALTER TABLE [pettycashoperationitineration] ALTER COLUMN movkindint smallint NULL 
END
GO

-- LOOKUP ORDIN = 1; DOCUM = 1; ESTIM = 1; IMPON = 2; IMPOS = 3; SALDO = 4; ANGIR = 5; ANPAG = 6
UPDATE expenseinvoice SET movkindint = 
CASE
	WHEN movkind = 'DOCUM' THEN 1
	WHEN movkind = 'IMPON' THEN 3
	WHEN movkind = 'IMPOS' THEN 2
	ELSE 1
END
GO

UPDATE expenseitineration SET movkindint = 
CASE
	WHEN movkind = 'SALDO' THEN 4
	WHEN movkind = 'ANGIR' THEN 5
	WHEN movkind = 'ANPAG' THEN 6
	ELSE 4
END
GO

UPDATE expensemandate SET movkindint = 
CASE
	WHEN movkind = 'ORDIN' THEN 1
	WHEN movkind = 'IMPON' THEN 3
	WHEN movkind = 'IMPOS' THEN 2
	ELSE 1
END
GO

UPDATE expenseprofservice SET movkindint = 
CASE
	WHEN movkind = 'DOCUM' THEN 1
	WHEN movkind = 'IMPON' THEN 3
	WHEN movkind = 'IMPOS' THEN 2
	ELSE 1
END
GO

UPDATE expensevar SET movkindint = 
CASE
	WHEN movkind = 'DOCUM' THEN 1
	WHEN movkind = 'IMPON' THEN 3
	WHEN movkind = 'IMPOS' THEN 2
END
GO

UPDATE incomeestimate SET movkindint = 
CASE
	WHEN movkind = 'ESTIM' THEN 1
	WHEN movkind = 'IMPON' THEN 3
	WHEN movkind = 'IMPOS' THEN 2
	ELSE 1
END
GO

UPDATE incomeinvoice SET movkindint = 
CASE
	WHEN movkind = 'DOCUM' THEN 1
	WHEN movkind = 'IMPON' THEN 3
	WHEN movkind = 'IMPOS' THEN 2
	ELSE 1
END
GO

UPDATE incomevar SET movkindint = 
CASE
	WHEN movkind = 'DOCUM' THEN 1
	WHEN movkind = 'IMPON' THEN 3
	WHEN movkind = 'IMPOS' THEN 2
END
GO

UPDATE pettycashoperationitineration SET movkindint = 
CASE
	WHEN movkind = 'SALDO' THEN 4
	WHEN movkind = 'ANGIR' THEN 5
	WHEN movkind = 'ANPAG' THEN 6
	ELSE 5
END
GO

-- Attenzione MOVKIND deve restare NULLABLE solo su incomevar e expensevar
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseinvoice'
		and C.name ='movkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseinvoice] DROP COLUMN movkind
	DELETE FROM columntypes WHERE tablename = 'expenseinvoice' AND field = 'movkind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseitineration'
		and C.name ='movkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseitineration] DROP COLUMN movkind
	DELETE FROM columntypes WHERE tablename = 'expenseitineration' AND field = 'movkind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensemandate'
		and C.name ='movkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensemandate] DROP COLUMN movkind
	DELETE FROM columntypes WHERE tablename = 'expensemandate' AND field = 'movkind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseprofservice'
		and C.name ='movkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseprofservice] DROP COLUMN movkind
	DELETE FROM columntypes WHERE tablename = 'expenseprofservice' AND field = 'movkind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensevar'
		and C.name ='movkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensevar] DROP COLUMN movkind
	DELETE FROM columntypes WHERE tablename = 'expensevar' AND field = 'movkind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeestimate'
		and C.name ='movkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeestimate] DROP COLUMN movkind
	DELETE FROM columntypes WHERE tablename = 'incomeestimate' AND field = 'movkind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeinvoice'
		and C.name ='movkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeinvoice] DROP COLUMN movkind
	DELETE FROM columntypes WHERE tablename = 'incomeinvoice' AND field = 'movkind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomevar'
		and C.name ='movkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomevar] DROP COLUMN movkind
	DELETE FROM columntypes WHERE tablename = 'incomevar' AND field = 'movkind'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationitineration'
		and C.name ='movkind'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationitineration] DROP COLUMN movkind
	DELETE FROM columntypes WHERE tablename = 'pettycashoperationitineration' AND field = 'movkind'
END
GO

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseinvoice' and C.name = 'movkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseinvoice] ADD movkind smallint NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseitineration' and C.name = 'movkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseitineration] ADD movkind smallint NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensemandate' and C.name = 'movkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensemandate] ADD movkind smallint NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expenseprofservice' and C.name = 'movkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expenseprofservice] ADD movkind smallint NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensevar' and C.name = 'movkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensevar] ADD movkind smallint NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeestimate' and C.name = 'movkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeestimate] ADD movkind smallint NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomeinvoice' and C.name = 'movkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomeinvoice] ADD movkind smallint NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomevar' and C.name = 'movkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incomevar] ADD movkind smallint NULL
END

IF NOT EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationitineration' and C.name = 'movkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pettycashoperationitineration] ADD movkind smallint NULL
END
GO

UPDATE expenseinvoice SET movkind = movkindint
GO

UPDATE expenseitineration SET movkind = movkindint
GO

UPDATE expensemandate SET movkind = movkindint
GO

UPDATE expenseprofservice SET movkind = movkindint
GO

UPDATE expensevar SET movkind = movkindint
GO

UPDATE incomeestimate SET movkind = movkindint
GO

UPDATE incomeinvoice SET movkind = movkindint
GO

UPDATE incomevar SET movkind = movkindint
GO

UPDATE pettycashoperationitineration SET movkind = movkindint
GO

ALTER TABLE [expenseinvoice] ALTER COLUMN movkind smallint NOT NULL 
GO

ALTER TABLE [expenseitineration] ALTER COLUMN movkind smallint NOT NULL 
GO

ALTER TABLE [expensemandate] ALTER COLUMN movkind smallint NOT NULL 
GO

ALTER TABLE [expenseprofservice] ALTER COLUMN movkind smallint NOT NULL 
GO

ALTER TABLE [incomeestimate] ALTER COLUMN movkind smallint NOT NULL 
GO

ALTER TABLE [incomeinvoice] ALTER COLUMN movkind smallint NOT NULL 
GO

ALTER TABLE [pettycashoperationitineration] ALTER COLUMN movkind smallint NOT NULL 
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseinvoice'
		and C.name ='movkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseinvoice] DROP COLUMN movkindint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseitineration'
		and C.name ='movkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseitineration] DROP COLUMN movkindint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensemandate'
		and C.name ='movkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensemandate] DROP COLUMN movkindint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseprofservice'
		and C.name ='movkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseprofservice] DROP COLUMN movkindint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensevar'
		and C.name ='movkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensevar] DROP COLUMN movkindint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeestimate'
		and C.name ='movkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeestimate] DROP COLUMN movkindint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeinvoice'
		and C.name ='movkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeinvoice] DROP COLUMN movkindint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomevar'
		and C.name ='movkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomevar] DROP COLUMN movkindint
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'pettycashoperationitineration'
		and C.name ='movkindint'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [pettycashoperationitineration] DROP COLUMN movkindint
END
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenseinvoice' AND field = 'movkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 14:23:01.933'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 14:23:01.933'} WHERE tablename = 'expenseinvoice' AND field = 'movkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expenseinvoice','movkind','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-12-03 14:23:01.933'},'''NINO''','NINO',{ts '2007-12-03 14:23:01.933'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenseitineration' AND field = 'movkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 14:23:02.403'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 14:23:02.403'} WHERE tablename = 'expenseitineration' AND field = 'movkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expenseitineration','movkind','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-12-03 14:23:02.403'},'''NINO''','NINO',{ts '2007-12-03 14:23:02.403'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensemandate' AND field = 'movkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 14:23:03.293'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 14:23:03.293'} WHERE tablename = 'expensemandate' AND field = 'movkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expensemandate','movkind','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-12-03 14:23:03.293'},'''NINO''','NINO',{ts '2007-12-03 14:23:03.293'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expenseprofservice' AND field = 'movkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 14:23:04.293'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 14:23:04.293'} WHERE tablename = 'expenseprofservice' AND field = 'movkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expenseprofservice','movkind','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-12-03 14:23:04.293'},'''NINO''','NINO',{ts '2007-12-03 14:23:04.293'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'expensevar' AND field = 'movkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-03 14:23:06.090'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 14:23:06.090'} WHERE tablename = 'expensevar' AND field = 'movkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('expensevar','movkind','N','smallint','2',null,null,'System.Int16','smallint','S','',null,'N',{ts '2007-12-03 14:23:06.090'},'''NINO''','NINO',{ts '2007-12-03 14:23:06.090'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomeestimate' AND field = 'movkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 14:22:59.107'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 14:22:59.107'} WHERE tablename = 'incomeestimate' AND field = 'movkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('incomeestimate','movkind','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-12-03 14:22:59.107'},'''NINO''','NINO',{ts '2007-12-03 14:22:59.107'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomeinvoice' AND field = 'movkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 14:23:13.120'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 14:23:13.120'} WHERE tablename = 'incomeinvoice' AND field = 'movkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('incomeinvoice','movkind','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-12-03 14:23:13.120'},'''NINO''','NINO',{ts '2007-12-03 14:23:13.120'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'incomevar' AND field = 'movkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'S',defaultvalue = '',format = null,denynull = 'N',lastmodtimestamp = {ts '2007-12-03 14:23:05.200'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 14:23:05.200'} WHERE tablename = 'incomevar' AND field = 'movkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('incomevar','movkind','N','smallint','2',null,null,'System.Int16','smallint','S','',null,'N',{ts '2007-12-03 14:23:05.200'},'''NINO''','NINO',{ts '2007-12-03 14:23:05.200'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'pettycashoperationitineration' AND field = 'movkind')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'smallint',col_len = '2',col_precision = null,col_scale = null,systemtype = 'System.Int16',sqldeclaration = 'smallint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-12-03 14:22:59.417'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-12-03 14:22:59.417'} WHERE tablename = 'pettycashoperationitineration' AND field = 'movkind'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('pettycashoperationitineration','movkind','N','smallint','2',null,null,'System.Int16','smallint','N','',null,'S',{ts '2007-12-03 14:22:59.417'},'''NINO''','NINO',{ts '2007-12-03 14:22:59.417'})
GO
	