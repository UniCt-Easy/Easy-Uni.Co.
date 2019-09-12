-- CREAZIONE VISTA itinerationrefundview
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationrefundview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationrefundview]
GO


CREATE  VIEW itinerationrefundview 
(
	yitineration,
	nitineration,
	nrefund,
	idcurrency,
	currency,
	iditinerationrefundkind,
	codeitinerationrefundkind,
	itinerationrefundkind,
	iditinerationrefundkindgroup,
	itinerationrefundkindgroup,
	description,
	amount,
	exchangerate,
	extraallowance,
	advancepercentage,
	starttime,
	stoptime,
	flagitalian,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	itinerationrefund.yitineration,
	itinerationrefund.nitineration,
	itinerationrefund.nrefund,
	itinerationrefund.idcurrency,
	currency.description,
	itinerationrefund.iditinerationrefundkind,
	itinerationrefundkind.codeitinerationrefundkind,
	itinerationrefundkind.description,
	itinerationrefundkindgroup.iditinerationrefundkindgroup,
	itinerationrefundkindgroup.description,
	itinerationrefund.description,
	itinerationrefund.amount,
	itinerationrefund.exchangerate,
	itinerationrefund.extraallowance,
	itinerationrefund.advancepercentage,
	itinerationrefund.starttime,
	itinerationrefund.stoptime,
	itinerationrefund.flag_geo,
	itinerationrefund.cu, 
	itinerationrefund.ct, 
	itinerationrefund.lu, 
	itinerationrefund.lt
FROM itinerationrefund
LEFT OUTER JOIN currency
	ON currency.idcurrency = itinerationrefund.idcurrency
LEFT OUTER JOIN itinerationrefundkind
	ON itinerationrefundkind.iditinerationrefundkind = itinerationrefund.iditinerationrefundkind
LEFT OUTER JOIN itinerationrefundkindgroup
	ON itinerationrefundkindgroup.iditinerationrefundkindgroup = itinerationrefundkind.iditinerationrefundkindgroup


GO

-- VERIFICA DI itinerationrefundview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'itinerationrefundview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'advancepercentage')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '9',field = 'advancepercentage',col_precision = '19' where tablename = 'itinerationrefundview' AND field = 'advancepercentage'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','8','decimal','','S','System.Decimal','decimal(19,8)','N','itinerationrefundview','N','','9','advancepercentage','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'amount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'itinerationrefundview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','itinerationrefundview','N','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'codeitinerationrefundkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '20',field = 'codeitinerationrefundkind',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'codeitinerationrefundkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','itinerationrefundview','N','','20','codeitinerationrefundkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','itinerationrefundview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','itinerationrefundview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'currency')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '50',field = 'currency',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'currency'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','itinerationrefundview','N','','50','currency','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'description')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(150)','N','itinerationrefundview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'exchangerate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'float',defaultvalue = '',allownull = 'S',systemtype = 'System.Double',sqldeclaration = 'float',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '8',field = 'exchangerate',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'exchangerate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','float','','S','System.Double','float','N','itinerationrefundview','N','','8','exchangerate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'extraallowance')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '9',field = 'extraallowance',col_precision = '19' where tablename = 'itinerationrefundview' AND field = 'extraallowance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','itinerationrefundview','N','','9','extraallowance','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'flagitalian')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '1',field = 'flagitalian',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'flagitalian'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','itinerationrefundview','N','','1','flagitalian','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'idcurrency')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '20',field = 'idcurrency',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'idcurrency'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','itinerationrefundview','N','','20','idcurrency','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'iditinerationrefundkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '4',field = 'iditinerationrefundkind',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'iditinerationrefundkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','itinerationrefundview','N','','4','iditinerationrefundkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'iditinerationrefundkindgroup')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '4',field = 'iditinerationrefundkindgroup',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'iditinerationrefundkindgroup'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','itinerationrefundview','N','','4','iditinerationrefundkindgroup','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'itinerationrefundkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '150',field = 'itinerationrefundkind',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'itinerationrefundkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','itinerationrefundview','N','','150','itinerationrefundkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'itinerationrefundkindgroup')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '100',field = 'itinerationrefundkindgroup',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'itinerationrefundkindgroup'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','itinerationrefundview','N','','100','itinerationrefundkindgroup','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','itinerationrefundview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','itinerationrefundview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'nitineration')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'S',format = '',col_len = '4',field = 'nitineration',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'nitineration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','itinerationrefundview','S','','4','nitineration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'nrefund')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'S',format = '',col_len = '2',field = 'nrefund',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'nrefund'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','itinerationrefundview','S','','2','nrefund','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'starttime')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '8',field = 'starttime',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'starttime'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','itinerationrefundview','N','','8','starttime','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'stoptime')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'N',format = '',col_len = '8',field = 'stoptime',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'stoptime'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','itinerationrefundview','N','','8','stoptime','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationrefundview' AND field = 'yitineration')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'itinerationrefundview',denynull = 'S',format = '',col_len = '2',field = 'yitineration',col_precision = '' where tablename = 'itinerationrefundview' AND field = 'yitineration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','itinerationrefundview','S','','2','yitineration','')
GO

-- VERIFICA DI itinerationrefundview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'itinerationrefundview')
UPDATE customobject set isreal = 'N' where objectname = 'itinerationrefundview'
ELSE
INSERT INTO customobject (objectname, isreal) values('itinerationrefundview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER auditcheck --
UPDATE [auditcheck] SET message = 'Classificazione delle spese della missione %<itinerationrefundkind.codeitinerationrefundkind>% già esistente' WHERE idaudit = 'SYSTM001' AND idcheck = '1' AND opkind = 'I' AND tablename = 'itinerationrefundkind'
GO


IF exists(SELECT * FROM [auditcheck] WHERE idaudit = 'SYSTM001' AND idcheck = '3' AND opkind = 'I' AND tablename = 'itinerationrefundkind')
UPDATE [auditcheck] SET flag_both = 'S',flag_cash = 'S',flag_comp = 'S',flag_credit = 'N',flag_proceeds = 'N',lt = {ts '2007-11-13 16:10:40.640'},lu = 'SARA',message = 'Codice del tipo rimborso spese %<codeitinerationrefundkind>% già esistente',precheck = 'S',sqlcmd = '[(SELECT count(*) 
from itinerationrefundkind 
where codeitinerationrefundkind  = %<itinerationrefundkind.codeitinerationrefundkind>%)]{I} = 0' WHERE idaudit = 'SYSTM001' AND idcheck = '3' AND opkind = 'I' AND tablename = 'itinerationrefundkind'
ELSE
INSERT INTO [auditcheck] (idaudit,idcheck,opkind,tablename,flag_both,flag_cash,flag_comp,flag_credit,flag_proceeds,lt,lu,message,precheck,sqlcmd) VALUES ('SYSTM001','3','I','itinerationrefundkind','S','S','S','N','N',{ts '2007-11-13 16:10:40.640'},'SARA','Codice del tipo rimborso spese %<codeitinerationrefundkind>% già esistente','S','[(SELECT count(*) 
from itinerationrefundkind 
where codeitinerationrefundkind  = %<itinerationrefundkind.codeitinerationrefundkind>%)]{I} = 0')
GO

-- FINE GENERAZIONE SCRIPT --

