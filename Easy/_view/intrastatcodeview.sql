
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


-- CREAZIONE VISTA intrastatcodeview
IF EXISTS(select * from sysobjects where id = object_id(N'[intrastatcodeview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [intrastatcodeview]
GO







--Pino Rana, elaborazione del 10/08/2005 15:18:12
CREATE                                VIEW intrastatcodeview 
  (
	ayear,
	idintrastatcode,
	code,
	description,
	idintrastatmeasure,
	measurecode,
	measuredescription,
	lt,
	lu
  )
  AS SELECT
	intrastatcode.ayear,
	intrastatcode.idintrastatcode,
	intrastatcode.code,
	intrastatcode.description,
	intrastatcode.idintrastatmeasure,
	intrastatmeasure.code,
	intrastatmeasure.description,
	intrastatcode.lt,
	intrastatcode.lu
  	FROM intrastatcode (NOLOCK)
	LEFT OUTER JOIN intrastatmeasure (NOLOCK)	ON intrastatcode.idintrastatmeasure = intrastatmeasure.idintrastatmeasure


GO

-- VERIFICA DI intrastatcodeview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'intrastatcodeview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','intrastatcodeview','S','','2','ayear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(8)','N','intrastatcodeview','S','','8','code','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(200)','N','intrastatcodeview','S','','200','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','intrastatcodeview','S','','4','idintrastatcode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','intrastatcodeview','N','','4','idintrastatmeasure','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','intrastatcodeview','N','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','intrastatcodeview','N','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(10)','N','intrastatcodeview','S','','10','measurecode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','intrastatcodeview','S','','50','measuredescription','')
GO

-- VERIFICA DI intrastatcodeview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'intrastatcodeview')
UPDATE customobject set isreal = 'N' where objectname = 'intrastatcodeview'
ELSE
INSERT INTO customobject (objectname, isreal) values('intrastatcodeview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

