-- CREAZIONE VISTA totestimatedetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[totestimatedetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [totestimatedetailview]
GO


CREATE                           VIEW [totestimatedetailview]
(
	idestimkind,
	yestim,
	nestim,
	taxabletotal,
	ivatotal
)
	AS SELECT
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
-- Aggiunto il comando CONVERT davanti ai campi FLOAT per non perdere informazione in fase di
-- prodotto. La perdita causa un errato arrotondamento
-- Il controllo non dovrebbe più servire se si cambia il tipo di campo a decimal(19,6) da float
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN estimatedetail.idinc_taxable IS NOT NULL THEN
			    ROUND(estimatedetail.taxable * estimatedetail.number * 
				  CONVERT(decimal(19,6),estimate.exchangerate) *
				  (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2
				)
			ELSE
			   0
		    END
			
		   ),0)
		),
	   CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		 CASE
		 WHEN estimatedetail.idinc_iva IS NOT NULL THEN
			ROUND(estimatedetail.tax ,2)
		  ELSE 0
		END
		),0)
	   )
-- Fine Modifica
	FROM estimatedetail (NOLOCK)
	JOIN estimate (NOLOCK)
  	ON estimatedetail.idestimkind = estimate.idestimkind
	AND estimatedetail.yestim = estimate.yestim
  	AND estimatedetail.nestim = estimate.nestim
	WHERE estimatedetail.stop is null
	GROUP BY estimatedetail.idestimkind, estimatedetail.yestim, estimatedetail.nestim




GO

-- VERIFICA DI totestimatedetailview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'totestimatedetailview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'totestimatedetailview' AND field = 'idestimkind')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'totestimatedetailview',denynull = 'S',format = '',col_len = '20',field = 'idestimkind',col_precision = '' where tablename = 'totestimatedetailview' AND field = 'idestimkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''NINO''','','varchar','','N','System.String','varchar(20)','N','totestimatedetailview','S','','20','idestimkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'totestimatedetailview' AND field = 'ivatotal')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'totestimatedetailview',denynull = 'N',format = '',col_len = '9',field = 'ivatotal',col_precision = '19' where tablename = 'totestimatedetailview' AND field = 'ivatotal'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','totestimatedetailview','N','','9','ivatotal','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'totestimatedetailview' AND field = 'nestim')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'totestimatedetailview',denynull = 'S',format = '',col_len = '4',field = 'nestim',col_precision = '' where tablename = 'totestimatedetailview' AND field = 'nestim'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','totestimatedetailview','S','','4','nestim','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'totestimatedetailview' AND field = 'taxabletotal')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'totestimatedetailview',denynull = 'N',format = '',col_len = '9',field = 'taxabletotal',col_precision = '19' where tablename = 'totestimatedetailview' AND field = 'taxabletotal'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','totestimatedetailview','N','','9','taxabletotal','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'totestimatedetailview' AND field = 'yestim')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'totestimatedetailview',denynull = 'S',format = '',col_len = '2',field = 'yestim',col_precision = '' where tablename = 'totestimatedetailview' AND field = 'yestim'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smallint','','N','System.Int16','smallint','N','totestimatedetailview','S','','2','yestim','')
GO

-- VERIFICA DI totestimatedetailview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'totestimatedetailview')
UPDATE customobject set isreal = 'N' where objectname = 'totestimatedetailview'
ELSE
INSERT INTO customobject (objectname, isreal) values('totestimatedetailview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

