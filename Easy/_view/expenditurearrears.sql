
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


-- CREAZIONE VISTA expenditurearrears
IF EXISTS(select * from sysobjects where id = object_id(N'[expenditurearrears]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expenditurearrears]
GO







CREATE  VIEW [expenditurearrears]
(
	ayear,
	idexp,
	ymov,
	nmov,
	adate,
	residualamount,
	totflag,
	flagarrear
)
AS
SELECT 
i1.ayear,s1.idexp,s1.ymov,s1.nmov,s1.adate,
ISNULL(i2.curramount,0.0) - ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) FROM expense s3
	 JOIN expensetotal i3	 ON s3.idexp = i3.idexp
	 JOIN expenselast l1	 ON l1.idexp = s3.idexp
	 JOIN expenselink el	 ON el.idparent = s1.idexp	 AND el.idchild = s3.idexp
	 JOIN payment d1	 ON d1.kpay = l1.kpay
	 JOIN paymenttransmission t1	 ON t1.kpaymenttransmission = d1.kpaymenttransmission
	 WHERE i3.ayear = i1.ayear),0.0),
	i2.flag,
CASE
	WHEN ((i2.flag&1)=0) THEN 'C'
	WHEN ((i2.flag&1)=1) THEN 'R'
END
FROM expense s1
INNER JOIN expenseyear i1 ON s1.idexp = i1.idexp 
INNER JOIN expensetotal i2 ON i1.idexp = i2.idexp  AND i1.ayear = i2.ayear
INNER JOIN config p1 ON p1.appropriationphasecode = s1.nphase AND p1.ayear = i1.ayear
WHERE i2.curramount >
	ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) FROM expense s3
	 JOIN expensetotal i3 	 ON s3.idexp = i3.idexp
	 JOIN expenselast l1	 ON l1.idexp = s3.idexp
	 JOIN expenselink el	 ON el.idparent = s1.idexp	 AND el.idchild = s3.idexp
	 JOIN payment d1	 ON d1.kpay = l1.kpay 
	 JOIN paymenttransmission t1	 ON t1.kpaymenttransmission = d1.kpaymenttransmission
	 WHERE i3.ayear = i1.ayear),0.0)


GO

-- VERIFICA DI expenditurearrears IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'expenditurearrears'
IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrears' AND field = 'adate')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'expenditurearrears',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'expenditurearrears' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','expenditurearrears','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrears' AND field = 'ayear')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'expenditurearrears',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'expenditurearrears' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','expenditurearrears','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrears' AND field = 'flagarrear')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'expenditurearrears',denynull = 'N',format = '',col_len = '1',field = 'flagarrear',col_precision = '' where tablename = 'expenditurearrears' AND field = 'flagarrear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','S','System.String','varchar(1)','N','expenditurearrears','N','','1','flagarrear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrears' AND field = 'idexp')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expenditurearrears',denynull = 'S',format = '',col_len = '4',field = 'idexp',col_precision = '' where tablename = 'expenditurearrears' AND field = 'idexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','expenditurearrears','S','','4','idexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrears' AND field = 'nmov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'expenditurearrears',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'expenditurearrears' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','expenditurearrears','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrears' AND field = 'residualamount')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(38,2)',iskey = 'N',tablename = 'expenditurearrears',denynull = 'N',format = '',col_len = '17',field = 'residualamount',col_precision = '38' where tablename = 'expenditurearrears' AND field = 'residualamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(38,2)','N','expenditurearrears','N','','17','residualamount','38')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrears' AND field = 'totflag')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'expenditurearrears',denynull = 'N',format = '',col_len = '1',field = 'totflag',col_precision = '' where tablename = 'expenditurearrears' AND field = 'totflag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','tinyint','','S','System.Byte','tinyint','N','expenditurearrears','N','','1','totflag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'expenditurearrears' AND field = 'ymov')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'expenditurearrears',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'expenditurearrears' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','expenditurearrears','S','','2','ymov','')
GO

-- VERIFICA DI expenditurearrears IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'expenditurearrears')
UPDATE customobject set isreal = 'N' where objectname = 'expenditurearrears'
ELSE
INSERT INTO customobject (objectname, isreal) values('expenditurearrears', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

