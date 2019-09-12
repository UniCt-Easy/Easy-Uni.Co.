-- CREAZIONE VISTA revenuearrears
IF EXISTS(select * from sysobjects where id = object_id(N'[revenuearrears]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [revenuearrears]
GO



CREATE         VIEW [revenuearrears]
(
	ayear,
	idinc,
	ymov,
	nmov,
	adate,
	residualamount,
	flagarrear
)
AS
SELECT
i1.ayear,e1.idinc,e1.ymov,e1.nmov,e1.adate,
ISNULL(i2.curramount,0.0) - ISNULL(	(SELECT SUM(ISNULL(i3.curramount,0.0)) 	FROM income e3
	 JOIN incometotal i3	ON e3.idinc = i3.idinc
	JOIN incomelast ls		ON e3.idinc = ls.idinc
	JOIN incomelink ilk 	ON ilk.idchild = i3.idinc AND  ilk.idparent = e1.idinc
	 JOIN proceeds d1	    ON d1.kpro = ls.kpro
	 JOIN proceedstransmission t1	 ON t1.kproceedstransmission = d1.kproceedstransmission	
	 WHERE i3.ayear = i1.ayear),0.0),
   	CASE
		when (( i2.flag & 1)=0) then 'C'
		when (( i2.flag & 1)=1) then 'R'
	End AS flagarrear
FROM income e1
INNER JOIN incomeyear i1 	ON e1.idinc = i1.idinc 
INNER JOIN incometotal i2	ON i1.idinc = i2.idinc	AND i1.ayear = i2.ayear
INNER JOIN config p1		ON p1.assessmentphasecode = e1.nphase	AND p1.ayear = i1.ayear
WHERE 
	 i2.curramount >
	ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) 
		FROM income e3
		 JOIN incometotal i3	ON e3.idinc = i3.idinc	 
		JOIN incomelast ls	    ON e3.idinc = ls.idinc
		JOIN incomelink ilk		ON ilk.idchild = i3.idinc AND ilk.idparent = e1.idinc 
		JOIN proceeds d1 	    ON d1.kpro = ls.kpro
	 	JOIN proceedstransmission t1	ON t1.kproceedstransmission = d1.kproceedstransmission
	 	WHERE i3.ayear = i1.ayear),0.0)

GO

-- VERIFICA DI revenuearrears IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'revenuearrears'
IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrears' AND field = 'adate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'revenuearrears',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'revenuearrears' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','revenuearrears','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrears' AND field = 'ayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'revenuearrears',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'revenuearrears' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','revenuearrears','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrears' AND field = 'flagarrear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'revenuearrears',denynull = 'N',format = '',col_len = '1',field = 'flagarrear',col_precision = '' where tablename = 'revenuearrears' AND field = 'flagarrear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(1)','N','revenuearrears','N','','1','flagarrear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrears' AND field = 'idinc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'revenuearrears',denynull = 'S',format = '',col_len = '4',field = 'idinc',col_precision = '' where tablename = 'revenuearrears' AND field = 'idinc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','revenuearrears','S','','4','idinc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrears' AND field = 'nmov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'revenuearrears',denynull = 'S',format = '',col_len = '4',field = 'nmov',col_precision = '' where tablename = 'revenuearrears' AND field = 'nmov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','revenuearrears','S','','4','nmov','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrears' AND field = 'residualamount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(38,2)',iskey = 'N',tablename = 'revenuearrears',denynull = 'N',format = '',col_len = '17',field = 'residualamount',col_precision = '38' where tablename = 'revenuearrears' AND field = 'residualamount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(38,2)','N','revenuearrears','N','','17','residualamount','38')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'revenuearrears' AND field = 'ymov')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'revenuearrears',denynull = 'S',format = '',col_len = '2',field = 'ymov',col_precision = '' where tablename = 'revenuearrears' AND field = 'ymov'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','revenuearrears','S','','2','ymov','')
GO

-- VERIFICA DI revenuearrears IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'revenuearrears')
UPDATE customobject set isreal = 'N' where objectname = 'revenuearrears'
ELSE
INSERT INTO customobject (objectname, isreal) values('revenuearrears', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

