
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


-- CREAZIONE VISTA totestimateview
IF EXISTS(select * from sysobjects where id = object_id(N'[totestimateview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [totestimateview]
GO


CREATE                               VIEW [totestimateview]
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
-- prodotto. La perdita causa un errato arotondamento
-- Il controllo non dovrebbe più servire se si cambia il tipo di campo a decimal(19,6) da float
	ISNULL(CONVERT(decimal(19,2),
		SUM(
		    ROUND(estimatedetail.taxable * estimatedetail.number * 
			  CONVERT(decimal(19,6),estimate.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2
			 )
		   )
		),0),
	ISNULL(
		CONVERT(decimal(19,2),
			SUM(
				ROUND(estimatedetail.tax ,2)
			)
		)
	,0)
	FROM estimatedetail (NOLOCK)
	JOIN estimate (NOLOCK)
  	ON estimatedetail.idestimkind = estimate.idestimkind
	AND estimatedetail.yestim = estimate.yestim
  	AND estimatedetail.nestim = estimate.nestim
	WHERE estimatedetail.stop is null
	GROUP BY estimatedetail.idestimkind, estimatedetail.yestim, estimatedetail.nestim




GO

-- VERIFICA DI totestimateview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'totestimateview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'totestimateview' AND field = 'idestimkind')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'totestimateview',denynull = 'S',format = '',col_len = '20',field = 'idestimkind',col_precision = '' where tablename = 'totestimateview' AND field = 'idestimkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''NINO''','','varchar','','N','System.String','varchar(20)','N','totestimateview','S','','20','idestimkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'totestimateview' AND field = 'ivatotal')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'totestimateview',denynull = 'S',format = '',col_len = '9',field = 'ivatotal',col_precision = '19' where tablename = 'totestimateview' AND field = 'ivatotal'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','N','System.Decimal','decimal(19,2)','N','totestimateview','S','','9','ivatotal','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'totestimateview' AND field = 'nestim')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'totestimateview',denynull = 'S',format = '',col_len = '4',field = 'nestim',col_precision = '' where tablename = 'totestimateview' AND field = 'nestim'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','int','','N','System.Int32','int','N','totestimateview','S','','4','nestim','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'totestimateview' AND field = 'taxabletotal')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'totestimateview',denynull = 'S',format = '',col_len = '9',field = 'taxabletotal',col_precision = '19' where tablename = 'totestimateview' AND field = 'taxabletotal'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','2','decimal','','N','System.Decimal','decimal(19,2)','N','totestimateview','S','','9','taxabletotal','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'totestimateview' AND field = 'yestim')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'totestimateview',denynull = 'S',format = '',col_len = '2',field = 'yestim',col_precision = '' where tablename = 'totestimateview' AND field = 'yestim'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smallint','','N','System.Int16','smallint','N','totestimateview','S','','2','yestim','')
GO

-- VERIFICA DI totestimateview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'totestimateview')
UPDATE customobject set isreal = 'N' where objectname = 'totestimateview'
ELSE
INSERT INTO customobject (objectname, isreal) values('totestimateview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

