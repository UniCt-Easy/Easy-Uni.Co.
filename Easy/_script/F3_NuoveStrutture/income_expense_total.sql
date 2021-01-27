
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


-- Cancellazione dei campi da INCOMETOTAL - EXPENSETOTAL
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incometotal'
		and C.name ='amount'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incometotal] DROP COLUMN amount
	DELETE FROM columntypes WHERE tablename = 'incometotal' AND field = 'amount'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expensetotal'
		and C.name ='amount'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expensetotal] DROP COLUMN amount
	DELETE FROM columntypes WHERE tablename = 'expensetotal' AND field = 'amount'
END
GO

-- Aggiunta del campo flag su INCOMETOTAL - EXPENSETOTAL
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incometotal' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incometotal] ADD flag tinyint NULL
END
ELSE
	ALTER TABLE [incometotal] ALTER COLUMN flag tinyint NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetotal' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensetotal] ADD flag tinyint NULL
END
ELSE
	ALTER TABLE [expensetotal] ALTER COLUMN flag tinyint NULL
GO

-- Valorizzazione dei nuovi flag su INCOMETOTAL - EXPENSETOTAL
UPDATE incometotal
SET flag = 
(SELECT 
	CASE 
		WHEN ISNULL(flagarrear,'C') = 'R' THEN 1
		ELSE 0
	END +
	CASE
		WHEN incomeyear.ayear = income.ymov THEN 2
		ELSE 0
	END
FROM incomeyear
JOIN income
ON incomeyear.idinc = income.idinc
WHERE incomeyear.idinc = incometotal.idinc
AND incomeyear.ayear = incometotal.ayear)
GO

UPDATE expensetotal
SET flag = 
(SELECT 
	CASE 
		WHEN ISNULL(flagarrear,'C') = 'R' THEN 1
		ELSE 0
	END +
	CASE
		WHEN expenseyear.ayear = expense.ymov THEN 2
		ELSE 0
	END
FROM expenseyear
JOIN expense
ON expenseyear.idexp = expense.idexp
WHERE expenseyear.idexp = expensetotal.idexp
AND expenseyear.ayear = expensetotal.ayear)
GO
-- Rimozione indici su campi di INCOMEYEAR - EXPENSEYEAR che saranno cancellati
IF EXISTS (SELECT * FROM sysindexes where name='xi5incomeyear' and id=object_id('incomeyear'))
	drop index incomeyear.xi5incomeyear
go

IF EXISTS (SELECT * FROM sysindexes where name='xi5expenseyear' and id=object_id('expenseyear'))
	drop index expenseyear.xi5expenseyear
go

-- Rimozione dei campi da INCOMEYEAR - EXPENSEYEAR
IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeyear'
		and C.name ='flagarrear'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeyear] DROP COLUMN flagarrear
	DELETE FROM columntypes WHERE tablename = 'incomeyear' AND field = 'flagarrear'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseyear'
		and C.name ='flagarrear'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseyear] DROP COLUMN flagarrear
	DELETE FROM columntypes WHERE tablename = 'expenseyear' AND field = 'flagarrear'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'incomeyear'
		and C.name ='nphase'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [incomeyear] DROP COLUMN nphase
	DELETE FROM columntypes WHERE tablename = 'incomeyear' AND field = 'nphase'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID 
		where t.name = 'expenseyear'
		and C.name ='nphase'
		AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo'))
	)
BEGIN
	ALTER TABLE [expenseyear] DROP COLUMN nphase
	DELETE FROM columntypes WHERE tablename = 'expenseyear' AND field = 'nphase'
END
GO

IF exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incometotal' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [incometotal] ALTER COLUMN flag tinyint NOT NULL
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensetotal' and C.name = 'flag' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [expensetotal] ALTER COLUMN flag tinyint NOT NULL
END
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'incometotal' AND field = 'flag')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'incometotal',denynull = 'S',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'incometotal' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision)
VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','N','incometotal','S','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expensetotal' AND field = 'flag')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'expensetotal',denynull = 'S',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'expensetotal' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision)
VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','N','expensetotal','S','','1','flag','')
GO

