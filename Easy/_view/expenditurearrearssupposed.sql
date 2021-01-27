
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


-- CREAZIONE VISTA expenditurearrearssupposed
IF EXISTS(select * from sysobjects where id = object_id(N'[expenditurearrearssupposed]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expenditurearrearssupposed]
GO





--Pino Rana, elaborazione del 10/08/2005 15:18:09
CREATE VIEW [expenditurearrearssupposed]
(
	ayear,
	idexp,
	ymov,
	nmov,
	adate,
	residualamount,
	totflag,
	flagarrear,
	expiration
)
AS
-- Residui Passivi Presunti Anni Precedenti
SELECT DISTINCT 
	i1.ayear,s1.idexp,s1.ymov,s1.nmov,s1.adate,
	ISNULL(i2.curramount,0.0) - 
	ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) FROM expense e3
	 	JOIN expensetotal i3
	 	ON e3.idexp = i3.idexp
		JOIN expenselast l1
	 	ON l1.idexp = e3.idexp
	 	JOIN expenselink el
	 	ON el.idparent = s1.idexp
	 	AND el.idchild = e3.idexp
		-- WHERE i3.idexp LIKE s1.idexp + '%'
		-- AND e3.nphase =
	 	-- (SELECT MAX(nphase) FROM expensephase)
	 	AND i3.ayear = i1.ayear),0.0)
	,i2.flag, 
	CASE
		WHEN ((i2.flag&1)=0) THEN 'C'
		WHEN ((i2.flag&1)=1) THEN 'R'
	END,
	s1.expiration
	FROM expense s1
	INNER JOIN expenseyear i1 
	ON s1.idexp = i1.idexp 
	INNER JOIN expensetotal i2
	ON i1.idexp = i2.idexp
	AND i1.ayear = i2.ayear
	INNER JOIN config p1
	ON p1.appropriationphasecode = s1.nphase
	AND p1.ayear = i1.ayear
	WHERE ((i2.flag&1)=1)  --'R'
	AND i2.curramount >
		ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) FROM expense e3
	 		JOIN expensetotal i3
			 ON e3.idexp = i3.idexp
	 		JOIN expenselast l1
	 		ON l1.idexp = e3.idexp
			 JOIN expenselink el
	 		ON el.idparent = s1.idexp
	 		AND el.idchild = e3.idexp
	 	WHERE 
		--i3.idexp LIKE s1.idexp + '%'
		-- AND e3.nphase =
		--(SELECT MAX(nphase) FROM expensephase)
	  	i3.ayear = i1.ayear),0.0)
	AND s1.expiration IS NOT NULL
-- Residui Passivi Presunti Anno in corso
UNION
SELECT DISTINCT 
	i1.ayear,s1.idexp,s1.ymov,s1.nmov,s1.adate,
	ISNULL(i2.curramount,0.0) - 
	ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) FROM expense e3
		 JOIN expensetotal i3
		 ON e3.idexp = i3.idexp
		  JOIN expenselast l1
		 ON l1.idexp = e3.idexp
		 JOIN expenselink el
		 ON el.idparent = s1.idexp
		 AND el.idchild = e3.idexp
		 WHERE 
			--i3.idexp LIKE s1.idexp + '%'
			-- AND e3.nphase =
			--(SELECT MAX(nphase) FROM expensephase)
		 	--AND 
		i3.ayear = i1.ayear),0.0)
	,i2.flag,
	CASE
		WHEN ((i2.flag&1)=0) THEN 'C'
		WHEN ((i2.flag&1)=1) THEN 'R'
	END,
	s1.expiration
FROM expense s1
INNER JOIN expenseyear i1 
ON s1.idexp = i1.idexp 
INNER JOIN expensetotal i2
ON i1.idexp = i2.idexp
AND i1.ayear = i2.ayear
INNER JOIN config p1
ON p1.appropriationphasecode = s1.nphase
AND p1.ayear = i1.ayear
WHERE ((i2.flag&1)=0)  --'C'
AND i2.curramount >
	  ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) FROM expense e3
	  JOIN expensetotal i3
	 	ON e3.idexp = i3.idexp
	  JOIN expenselast l1
	  	ON l1.idexp = e3.idexp
	  JOIN expenselink el
		ON el.idparent = s1.idexp
		AND el.idchild = e3.idexp
	 WHERE 
		--i3.idexp LIKE s1.idexp + '%'
		-- AND e3.nphase =
		--(SELECT MAX(nphase) FROM expensephase)
		-- AND 
		i3.ayear = i1.ayear),0.0)
AND s1.expiration IS NOT NULL







GO

-- VERIFICA DI expenditurearrearssupposed IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'expenditurearrearssupposed'
IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrearssupposed' AND field = 'adate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'expenditurearrearssupposed',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'expenditurearrearssupposed' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','expenditurearrearssupposed','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrearssupposed' AND field = 'ayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'expenditurearrearssupposed',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'expenditurearrearssupposed' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smallint','','N','System.Int16','smallint','N','expenditurearrearssupposed','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrearssupposed' AND field = 'expiration')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'expenditurearrearssupposed',denynull = 'N',format = '',col_len = '4',field = 'expiration',col_precision = '' where tablename = 'expenditurearrearssupposed' AND field = 'expiration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smalldatetime','','S','System.DateTime','smalldatetime','N','expenditurearrearssupposed','N','','4','expiration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrearssupposed' AND field = 'flagarrear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'expenditurearrearssupposed',denynull = 'N',format = '',col_len = '1',field = 'flagarrear',col_precision = '' where tablename = 'expenditurearrearssupposed' AND field = 'flagarrear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','varchar','','S','System.String','varchar(1)','N','expenditurearrearssupposed','N','','1','flagarrear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrearssupposed' AND field = 'idexp')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expenditurearrearssupposed',denynull = 'S',format = '',col_len = '4',field = 'idexp',col_precision = '' where tablename = 'expenditurearrearssupposed' AND field = 'idexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','expenditurearrearssupposed','S','','4','idexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrearssupposed' AND field = 'nmov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expenditurearrearssupposed',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'expenditurearrearssupposed' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','int','','N','System.Int32','int','N','expenditurearrearssupposed','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrearssupposed' AND field = 'residualamount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(38,2)',iskey = 'N',tablename = 'expenditurearrearssupposed',denynull = 'N',format = '',col_len = '17',field = 'residualamount',col_precision = '38' where tablename = 'expenditurearrearssupposed' AND field = 'residualamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(38,2)','N','expenditurearrearssupposed','N','','17','residualamount','38')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrearssupposed' AND field = 'totflag')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'expenditurearrearssupposed',denynull = 'N',format = '',col_len = '1',field = 'totflag',col_precision = '' where tablename = 'expenditurearrearssupposed' AND field = 'totflag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','tinyint','','S','System.Byte','tinyint','N','expenditurearrearssupposed','N','','1','totflag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrearssupposed' AND field = 'ymov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'expenditurearrearssupposed',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'expenditurearrearssupposed' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''NINO''','','smallint','','N','System.Int16','smallint','N','expenditurearrearssupposed','S','','2','ymov','')
GO

-- VERIFICA DI expenditurearrearssupposed IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'expenditurearrearssupposed')
UPDATE customobject set isreal = 'N' where objectname = 'expenditurearrearssupposed'
ELSE
INSERT INTO customobject (objectname, isreal) values('expenditurearrearssupposed', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

