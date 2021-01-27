
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


-- CREAZIONE VISTA allfinlookup
IF EXISTS(select * from sysobjects where id = object_id(N'[allfinlookup]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [allfinlookup]
GO




CREATE    VIEW allfinlookup
(
	oldidfin,
	ayear,
	newidfin
)
AS
select idfin,F.ayear,idfin from fin F 
UNION ALL
select idfin,F.ayear+1,K1.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
UNION ALL
select idfin,F.ayear+2,K2.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
UNION ALL
select idfin,F.ayear+3,K3.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
UNION ALL
select idfin,F.ayear+4,K4.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
	join finlookup K4 on K4.oldidfin= K3.newidfin
UNION ALL
select idfin,F.ayear+5,K5.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
	join finlookup K4 on K4.oldidfin= K3.newidfin
	join finlookup K5 on K5.oldidfin= K4.newidfin
UNION ALL
select idfin,F.ayear+6,K6.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
	join finlookup K4 on K4.oldidfin= K3.newidfin
	join finlookup K5 on K5.oldidfin= K4.newidfin
	join finlookup K6 on K6.oldidfin= K5.newidfin
UNION ALL
select idfin,F.ayear+7,K7.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
	join finlookup K4 on K4.oldidfin= K3.newidfin
	join finlookup K5 on K5.oldidfin= K4.newidfin
	join finlookup K6 on K6.oldidfin= K5.newidfin
	join finlookup K7 on K7.oldidfin= K6.newidfin
UNION ALL
select idfin,F.ayear+8,K8.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
	join finlookup K4 on K4.oldidfin= K3.newidfin
	join finlookup K5 on K5.oldidfin= K4.newidfin
	join finlookup K6 on K6.oldidfin= K5.newidfin
	join finlookup K7 on K7.oldidfin= K6.newidfin
	join finlookup K8 on K8.oldidfin= K7.newidfin
UNION ALL
select idfin,F.ayear+9,K9.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
	join finlookup K4 on K4.oldidfin= K3.newidfin
	join finlookup K5 on K5.oldidfin= K4.newidfin
	join finlookup K6 on K6.oldidfin= K5.newidfin
	join finlookup K7 on K7.oldidfin= K6.newidfin
	join finlookup K8 on K8.oldidfin= K7.newidfin
	join finlookup K9 on K9.oldidfin= K8.newidfin




GO

-- VERIFICA DI allfinlookup IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'allfinlookup'
IF exists(SELECT * FROM columntypes WHERE tablename = 'allfinlookup' AND field = 'ayear')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'allfinlookup',denynull = 'N',format = '',col_len = '4',field = 'ayear',col_precision = '' where tablename = 'allfinlookup' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','allfinlookup','N','','4','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allfinlookup' AND field = 'newidfin')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'allfinlookup',denynull = 'S',format = '',col_len = '4',field = 'newidfin',col_precision = '' where tablename = 'allfinlookup' AND field = 'newidfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','allfinlookup','S','','4','newidfin','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'allfinlookup' AND field = 'oldidfin')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'allfinlookup',denynull = 'S',format = '',col_len = '4',field = 'oldidfin',col_precision = '' where tablename = 'allfinlookup' AND field = 'oldidfin'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','allfinlookup','S','','4','oldidfin','')
GO

-- VERIFICA DI allfinlookup IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'allfinlookup')
UPDATE customobject set isreal = 'N' where objectname = 'allfinlookup'
ELSE
INSERT INTO customobject (objectname, isreal) values('allfinlookup', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

