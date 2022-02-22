
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


-- CREAZIONE VISTA totmandatedetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[totmandatedetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [totmandatedetailview]
GO


CREATE  VIEW [totmandatedetailview]
(
	idmankind,
	yman,
	nman,
	taxabletotal,
	ivatotal
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
-- Modifica Rusciano Giuseppe
-- Aggiunto il comando CONVERT davanti ai campi FLOAT per non perdere informazione in fase di
-- prodotto. La perdita causa un errato arrotondamento
-- Il controllo non dovrebbe più servire se si cambia il tipo di campo a decimal(19,6) da float
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN mandatedetail.idexp_taxable IS NOT NULL THEN
			    ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
				  CONVERT(decimal(19,6),mandate.exchangerate) *
				  (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2
				)
			ELSE
			   0
		    END
			
		   ),0)
		),
	   CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		 CASE
		 WHEN mandatedetail.idexp_iva IS NOT NULL THEN
			ROUND(mandatedetail.tax ,2)
			
		  ELSE 0
		END
		),0)
	   )
-- Fine Modifica
	FROM mandatedetail (NOLOCK)
	JOIN mandate (NOLOCK)
  	ON mandatedetail.idmankind = mandate.idmankind
	AND mandatedetail.yman = mandate.yman
  	AND mandatedetail.nman = mandate.nman
	WHERE mandatedetail.stop is null --and (mandatedetail.idexp_iva  is not null OR mandatedetail.idexp_taxable is not null)
	GROUP BY mandatedetail.idmankind, mandatedetail.yman, mandatedetail.nman

GO

-- VERIFICA DI totmandatedetailview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'totmandatedetailview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'totmandatedetailview' AND field = 'idmankind')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'totmandatedetailview',denynull = 'S',format = '',col_len = '20',field = 'idmankind',col_precision = '' where tablename = 'totmandatedetailview' AND field = 'idmankind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''NINO''','','varchar','','N','System.String','varchar(20)','N','totmandatedetailview','S','','20','idmankind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'totmandatedetailview' AND field = 'ivatotal')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'totmandatedetailview',denynull = 'N',format = '',col_len = '9',field = 'ivatotal',col_precision = '19' where tablename = 'totmandatedetailview' AND field = 'ivatotal'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','totmandatedetailview','N','','9','ivatotal','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'totmandatedetailview' AND field = 'nman')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'totmandatedetailview',denynull = 'S',format = '',col_len = '4',field = 'nman',col_precision = '' where tablename = 'totmandatedetailview' AND field = 'nman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''NINO''','','int','','N','System.Int32','int','N','totmandatedetailview','S','','4','nman','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'totmandatedetailview' AND field = 'taxabletotal')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''SA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'totmandatedetailview',denynull = 'N',format = '',col_len = '9',field = 'taxabletotal',col_precision = '19' where tablename = 'totmandatedetailview' AND field = 'taxabletotal'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','totmandatedetailview','N','','9','taxabletotal','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'totmandatedetailview' AND field = 'yman')
UPDATE columntypes set createuser = 'SA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'totmandatedetailview',denynull = 'S',format = '',col_len = '2',field = 'yman',col_precision = '' where tablename = 'totmandatedetailview' AND field = 'yman'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''NINO''','','smallint','','N','System.Int16','smallint','N','totmandatedetailview','S','','2','yman','')
GO

-- VERIFICA DI totmandatedetailview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'totmandatedetailview')
UPDATE customobject set isreal = 'N' where objectname = 'totmandatedetailview'
ELSE
INSERT INTO customobject (objectname, isreal) values('totmandatedetailview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

