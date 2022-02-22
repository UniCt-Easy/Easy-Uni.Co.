
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


-- CREAZIONE VISTA taxsetupview
IF EXISTS(select * from sysobjects where id = object_id(N'[taxsetupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [taxsetupview]
GO






CREATE VIEW taxsetupview 
(
	taxcode,
	taxref,
	taxkind,
	ayear,
	flag,
	flagregionalagency,
	paymentagency,
	paymentagencytitle,
	idfinexpensecontra,
	codefinexpensecontra,
	finexpensecontra,
	idfinincomecontra,
	codefinincomecontra,
	finincomecontra,
	idfinincomeemploy,
	codefinincomeemploy,
	finincomeemploy,
	idfinexpenseemploy,
	codefinexpenseemploy,
	finexpenseemploy,
	flagadminfinance,
	idfinadmintax,
	codefinadmintax,
	finadmintax,
	idexpirationkind,
	expiringday,
	flagprevcurr,
	taxpaykind,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	taxsetup.taxcode,
	tax.taxref,
	tax.description,
	taxsetup.ayear,
	taxsetup.flag,
	CASE  -- bit 0 1 2 
		WHEN ((taxsetup.flag)&1) <> 0 THEN 'N'
		WHEN ((taxsetup.flag)&2) <> 0 THEN 'S'
		WHEN ((taxsetup.flag)&4) <> 0 THEN 'P'
	END,
	taxsetup.paymentagency,
	registry.title,
	taxsetup.idfinexpensecontra,
	bilancioversamento.codefin,
	bilancioversamento.title,
	taxsetup.idfinincomecontra,
	bilancioapplicazione.codefin,
	bilancioapplicazione.title,
	finincomeemploy.idfin,
	finincomeemploy.codefin,
	finincomeemploy.title,
	finexpenseemploy.idfin,
	finexpenseemploy.codefin,
	finexpenseemploy.title,
	taxsetup.flagadminfinance,
	taxsetup.idfinadmintax,
	bilanciocontributi.codefin,
	bilanciocontributi.title,
	taxsetup.idexpirationkind,
	taxsetup.expiringday,
	CASE 
		WHEN ((taxsetup.flag)&8) = 0 THEN 'C'
		WHEN ((taxsetup.flag)&8) <> 0 THEN 'P'
	END,
	taxsetup.taxpaykind,
	taxsetup.cu,
	taxsetup.ct,
	taxsetup.lu,
	taxsetup.lt
FROM taxsetup 
JOIN tax 
	ON tax.taxcode = taxsetup.taxcode
LEFT OUTER JOIN registry 
	ON registry.idreg = taxsetup.paymentagency
LEFT OUTER JOIN fin bilancioversamento 
	ON bilancioversamento.idfin = taxsetup.idfinexpensecontra
LEFT OUTER JOIN fin bilancioapplicazione 
	ON bilancioapplicazione.idfin = taxsetup.idfinincomecontra
LEFT OUTER JOIN fin bilanciocontributi 
	ON bilanciocontributi.idfin = taxsetup.idfinadmintax
LEFT OUTER JOIN fin finincomeemploy
	ON finincomeemploy.idfin = taxsetup.idfinincomeemploy
LEFT OUTER JOIN fin finexpenseemploy
	ON finexpenseemploy.idfin = taxsetup.idfinexpenseemploy



GO

-- VERIFICA DI taxsetupview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'taxsetupview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','N','System.Int16','smallint','N','taxsetupview','S','','2','ayear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','taxsetupview','N','','50','codefinadmintax','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','taxsetupview','N','','50','codefinexpensecontra','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','taxsetupview','N','','50','codefinexpenseemploy','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','taxsetupview','N','','50','codefinincomecontra','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','taxsetupview','N','','50','codefinincomeemploy','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','taxsetupview','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','taxsetupview','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','S','System.Int16','smallint','N','taxsetupview','N','','2','expiringday','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','taxsetupview','N','','150','finadmintax','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','taxsetupview','N','','150','finexpensecontra','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','taxsetupview','N','','150','finexpenseemploy','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','taxsetupview','N','','150','finincomecontra','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(150)','N','taxsetupview','N','','150','finincomeemploy','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','N','taxsetupview','S','','1','flag','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','N','System.String','char(1)','N','taxsetupview','S','','1','flagadminfinance','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(1)','N','taxsetupview','N','','1','flagprevcurr','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(1)','N','taxsetupview','N','','1','flagregionalagency','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','S','System.Int16','smallint','N','taxsetupview','N','','2','idexpirationkind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','taxsetupview','N','','4','idfinadmintax','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','taxsetupview','N','','4','idfinexpensecontra','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','taxsetupview','N','','4','idfinexpenseemploy','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','taxsetupview','N','','4','idfinincomecontra','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','taxsetupview','N','','4','idfinincomeemploy','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','N','System.DateTime','datetime','N','taxsetupview','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(64)','N','taxsetupview','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','taxsetupview','N','','4','paymentagency','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(100)','N','taxsetupview','N','','100','paymentagencytitle','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','taxsetupview','S','','4','taxcode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','taxsetupview','S','','50','taxkind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(1)','N','taxsetupview','N','','1','taxpaykind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','taxsetupview','S','','20','taxref','')
GO

-- VERIFICA DI taxsetupview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'taxsetupview')
UPDATE customobject set isreal = 'N' where objectname = 'taxsetupview'
ELSE
INSERT INTO customobject (objectname, isreal) values('taxsetupview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

