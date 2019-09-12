-- CREAZIONE VISTA itinerationavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationavailable]
GO


CREATE  VIEW [itinerationavailable]
	(
	iditineration,
	yitineration,
	nitineration,
	description,
	idreg,
	registry,
	start,
	stop,
	totalgross,
	totadvance,
	active
	)
	AS SELECT
	itineration.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	itineration.description,
	itineration.idreg,
	registry.title,
	itineration.start,
	itineration.stop,
	itineration.totalgross,
	itineration.totadvance,
	itineration.active
	FROM itineration (NOLOCK)
	JOIN registry (NOLOCK)
	ON registry.idreg = itineration.idreg
	WHERE itineration.totalgross >
		ISNULL(
		(SELECT SUM(expenseyear_starting.amount)  
		FROM expenseitineration mov
		JOIN expense s
		ON s.idexp = mov.idexp
		LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  			ON expensetotal_firstyear.idexp = s.idexp
  			AND ((expensetotal_firstyear.flag & 2) <> 0 )
		LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
		WHERE mov.iditineration = itineration.iditineration
		AND (mov.movkind = 4 OR mov.movkind = 6)
		)
	,0) +
	ISNULL(
		(SELECT SUM(v.amount)
		FROM expenseitineration mov
		JOIN expense s
		ON s.idexp = mov.idexp
		JOIN expensevar v
		ON v.idexp = mov.idexp
		WHERE mov.iditineration = itineration.iditineration
		AND (mov.movkind = 4 OR mov.movkind = 6)
		AND (ISNULL(v.autokind,'')<>4)
		)
	,0) +
	ISNULL(
		(SELECT SUM(p.amount)
		FROM pettycashoperationitineration mov
		JOIN pettycashoperation p
		ON mov.idpettycash = p.idpettycash
		AND mov.yoperation = p.yoperation
		AND mov.noperation = p.noperation
		WHERE mov.iditineration = itineration.iditineration
		AND mov.movkind = 6)
	,0)

GO

-- VERIFICA DI itinerationavailable IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'itinerationavailable'
IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationavailable' AND field = 'active')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'itinerationavailable',denynull = 'N',format = '',col_len = '1',field = 'active',col_precision = '' where tablename = 'itinerationavailable' AND field = 'active'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','char','','S','System.String','char(1)','N','itinerationavailable','N','','1','active','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationavailable' AND field = 'description')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'itinerationavailable',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'itinerationavailable' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(150)','N','itinerationavailable','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationavailable' AND field = 'iditineration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationavailable',denynull = 'S',format = '',col_len = '4',field = 'iditineration',col_precision = '' where tablename = 'itinerationavailable' AND field = 'iditineration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','itinerationavailable','S','','4','iditineration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationavailable' AND field = 'idreg')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationavailable',denynull = 'S',format = '',col_len = '4',field = 'idreg',col_precision = '' where tablename = 'itinerationavailable' AND field = 'idreg'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','itinerationavailable','S','','4','idreg','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationavailable' AND field = 'nitineration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationavailable',denynull = 'S',format = '',col_len = '4',field = 'nitineration',col_precision = '' where tablename = 'itinerationavailable' AND field = 'nitineration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','int','','N','System.Int32','int','N','itinerationavailable','S','','4','nitineration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationavailable' AND field = 'registry')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'itinerationavailable',denynull = 'S',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'itinerationavailable' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','varchar','','N','System.String','varchar(100)','N','itinerationavailable','S','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationavailable' AND field = 'start')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'itinerationavailable',denynull = 'S',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'itinerationavailable' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','itinerationavailable','S','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationavailable' AND field = 'stop')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'itinerationavailable',denynull = 'S',format = '',col_len = '4',field = 'stop',col_precision = '' where tablename = 'itinerationavailable' AND field = 'stop'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smalldatetime','','N','System.DateTime','smalldatetime','N','itinerationavailable','S','','4','stop','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationavailable' AND field = 'totadvance')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'itinerationavailable',denynull = 'N',format = '',col_len = '9',field = 'totadvance',col_precision = '19' where tablename = 'itinerationavailable' AND field = 'totadvance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','itinerationavailable','N','','9','totadvance','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationavailable' AND field = 'totalgross')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'itinerationavailable',denynull = 'N',format = '',col_len = '9',field = 'totalgross',col_precision = '19' where tablename = 'itinerationavailable' AND field = 'totalgross'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','itinerationavailable','N','','9','totalgross','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationavailable' AND field = 'yitineration')
UPDATE columntypes set createuser = 'PINO',lastmoduser = '''PINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'itinerationavailable',denynull = 'S',format = '',col_len = '2',field = 'yitineration',col_precision = '' where tablename = 'itinerationavailable' AND field = 'yitineration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('PINO','''PINO''','','smallint','','N','System.Int16','smallint','N','itinerationavailable','S','','2','yitineration','')
GO

-- VERIFICA DI itinerationavailable IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'itinerationavailable')
UPDATE customobject set isreal = 'N' where objectname = 'itinerationavailable'
ELSE
INSERT INTO customobject (objectname, isreal) values('itinerationavailable', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

