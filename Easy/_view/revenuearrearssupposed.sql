
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


-- CREAZIONE VISTA revenuearrearssupposed
IF EXISTS(select * from sysobjects where id = object_id(N'[revenuearrearssupposed]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [revenuearrearssupposed]
GO


CREATE VIEW [revenuearrearssupposed]
AS
-- Residui Attivi Presunti Anni Precedenti
SELECT DISTINCT 
	i1.ayear,
	e1.idinc,
	e1.ymov,
	e1.nmov,
	e1.adate,
	ISNULL(i2.curramount,0.0) - ISNULL(
		(SELECT SUM(ISNULL(i3.curramount,0.0)) 
		FROM income e3
		JOIN incometotal i3
			 ON e3.idinc = i3.idinc
		JOIN incomelast ls
			 ON e3.idinc = ls.idinc
		JOIN incomelink ilk
			ON ilk.idchild = i3.idinc
		WHERE ilk.idparent = e1.idinc    -- i3.idinc LIKE e1.idinc + '%'
	 		--AND e3.nphase = (SELECT MAX(nphase) FROM incomephase)
			AND i3.ayear = i1.ayear)
		,0.0) 	AS residualamount,
	--i1.flagarrear,
   	CASE
		when (( i2.flag & 1)=0) then 'C'
		when (( i2.flag & 1)=1) then 'R'
	End AS flagarrear,
	e1.expiration
FROM income e1
INNER JOIN incomeyear i1    
	ON e1.idinc = i1.idinc 
INNER JOIN incometotal i2
	ON i1.idinc = i2.idinc
	AND i1.ayear = i2.ayear
INNER JOIN config p1
	ON p1.assessmentphasecode = e1.nphase --i1.nphase
	AND p1.ayear = i1.ayear
WHERE (( i2.flag & 1)=1)--i1.flagarrear = 'R'
	AND i2.curramount >
		ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) 
			FROM income e3
			JOIN incometotal i3
	 			ON e3.idinc = i3.idinc
			JOIN incomelast ls
			 	ON e3.idinc = ls.idinc
			JOIN incomelink ilk
				ON ilk.idchild = i3.idinc
	 		WHERE ilk.idparent = e1.idinc    -- i3.idinc LIKE e1.idinc + '%'
	 			--AND e3.nphase = (SELECT MAX(nphase) FROM incomephase)
				AND i3.ayear = i1.ayear),0.0)
	AND e1.expiration IS NOT NULL

-- Residui Attivi Presunti Anno in corso
UNION
SELECT DISTINCT 
	i1.ayear,
	e1.idinc,
	e1.ymov,
	e1.nmov,
	e1.adate,
	ISNULL(i2.curramount,0.0) - ISNULL(
			(SELECT SUM(ISNULL(i3.curramount,0.0)) FROM income e3
	 		JOIN incometotal i3
	 			ON e3.idinc = i3.idinc
			JOIN incomelink ilk
				ON ilk.idchild = i3.idinc
			JOIN incomelast ls
			 	ON e3.idinc = ls.idinc
	 		WHERE ilk.idparent = e1.idinc    -- i3.idinc LIKE e1.idinc + '%'
	 			--AND e3.nphase = (SELECT MAX(nphase) FROM incomephase)
	 			AND i3.ayear = i1.ayear)
			,0.0)
			AS residualamount,
	--i1.flagarrear,
	CASE
		when (( i2.flag & 1)=0) then 'C'
		when (( i2.flag & 1)=1) then 'R'
	End,
	e1.expiration
FROM income e1
INNER JOIN incomeyear i1 
	ON e1.idinc = i1.idinc 
INNER JOIN incometotal i2
	ON i1.idinc = i2.idinc
	AND i1.ayear = i2.ayear
INNER JOIN config p1
	ON p1.assessmentphasecode = e1.nphase --i1.nphase
	AND p1.ayear = i1.ayear
WHERE (( i2.flag & 1)=0)
	AND i2.curramount >
		ISNULL(
		(SELECT SUM(ISNULL(i3.curramount,0.0)) 
		FROM income e3
	 	JOIN incometotal i3
			ON e3.idinc = i3.idinc
		JOIN incomelink ilk
			ON ilk.idchild = i3.idinc
		JOIN incomelast ls
			 ON e3.idinc = ls.idinc
		WHERE ilk.idparent = e1.idinc    -- i3.idinc LIKE e1.idinc + '%'
	 		--AND e3.nphase = (SELECT MAX(nphase) FROM incomephase)
		AND i3.ayear = i1.ayear)
		,0.0)
	AND e1.expiration IS NOT NULL







GO

-- VERIFICA DI revenuearrearssupposed IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'revenuearrearssupposed'
IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrearssupposed' AND field = 'adate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'revenuearrearssupposed',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'revenuearrearssupposed' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','revenuearrearssupposed','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrearssupposed' AND field = 'ayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'revenuearrearssupposed',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'revenuearrearssupposed' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smallint','','N','System.Int16','smallint','N','revenuearrearssupposed','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrearssupposed' AND field = 'expiration')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'revenuearrearssupposed',denynull = 'N',format = '',col_len = '4',field = 'expiration',col_precision = '' where tablename = 'revenuearrearssupposed' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','revenuearrearssupposed','N','','4','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrearssupposed' AND field = 'flagarrear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'revenuearrearssupposed',denynull = 'N',format = '',col_len = '1',field = 'flagarrear',col_precision = '' where tablename = 'revenuearrearssupposed' AND field = 'flagarrear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(1)','N','revenuearrearssupposed','N','','1','flagarrear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrearssupposed' AND field = 'idinc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'revenuearrearssupposed',denynull = 'S',format = '',col_len = '4',field = 'idinc',col_precision = '' where tablename = 'revenuearrearssupposed' AND field = 'idinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','revenuearrearssupposed','S','','4','idinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrearssupposed' AND field = 'nmov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'revenuearrearssupposed',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'revenuearrearssupposed' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','revenuearrearssupposed','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrearssupposed' AND field = 'residualamount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(38,2)',iskey = 'N',tablename = 'revenuearrearssupposed',denynull = 'N',format = '',col_len = '17',field = 'residualamount',col_precision = '38' where tablename = 'revenuearrearssupposed' AND field = 'residualamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(38,2)','N','revenuearrearssupposed','N','','17','residualamount','38')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrearssupposed' AND field = 'ymov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'revenuearrearssupposed',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'revenuearrearssupposed' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smallint','','N','System.Int16','smallint','N','revenuearrearssupposed','S','','2','ymov','')
GO

-- VERIFICA DI revenuearrearssupposed IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'revenuearrearssupposed')
UPDATE customobject set isreal = 'N' where objectname = 'revenuearrearssupposed'
ELSE
INSERT INTO customobject (objectname, isreal) values('revenuearrearssupposed', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

