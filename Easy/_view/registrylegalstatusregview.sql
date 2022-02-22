
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


-- CREAZIONE VISTA registrylegalstatusregview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrylegalstatusregview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrylegalstatusregview]
GO


CREATE    VIEW [DBO].[registrylegalstatusregview]
(
	idreg,
	registry,
	idregistrylegalstatus,
	start,
	idposition,
	codeposition,
	position,
	incomeclass,
	incomeclassvalidity,
	cu, 
	ct, 
	lu,
	lt,
	active,
	stop,
	csa_compartment,csa_role, csa_class

)
AS SELECT
	registrylegalstatus.idreg, 
	registry.title, 
	registrylegalstatus.idregistrylegalstatus,
	registrylegalstatus.start,
	registrylegalstatus.idposition, 
	position.codeposition,
	position.description,
	registrylegalstatus.incomeclass,
	registrylegalstatus.incomeclassvalidity,
	registrylegalstatus.cu, 
	registrylegalstatus.ct, 
	registrylegalstatus.lu,
	registrylegalstatus.lt,
	registrylegalstatus.active,
	registrylegalstatus.stop,
	registrylegalstatus.csa_compartment, 
	registrylegalstatus.csa_role, 
	registrylegalstatus.csa_class
FROM registrylegalstatus 
JOIN registry 
	ON registrylegalstatus.idreg = registry.idreg
LEFT OUTER JOIN position 
	ON registrylegalstatus.idposition = position.idposition 







GO

-- VERIFICA DI registrylegalstatusregview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrylegalstatusregview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','char','','S','System.String','char(1)','N','registrylegalstatusregview','N','','1','active','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','varchar','','S','System.String','varchar(20)','N','registrylegalstatusregview','N','','20','codeposition','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','varchar','','S','System.String','varchar(20)','N','registrylegalstatusregview','N','','20','csa_class','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','char','','S','System.String','char(1)','N','registrylegalstatusregview','N','','1','csa_compartment','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','varchar','','S','System.String','varchar(4)','N','registrylegalstatusregview','N','','4','csa_role','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','datetime','','S','System.DateTime','datetime','N','registrylegalstatusregview','N','','8','ct','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','varchar','','S','System.String','varchar(64)','N','registrylegalstatusregview','N','','64','cu','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','int','','S','System.Int32','int','N','registrylegalstatusregview','N','','4','idposition','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','int','','N','System.Int32','int','N','registrylegalstatusregview','S','','4','idreg','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','int','','N','System.Int32','int','N','registrylegalstatusregview','S','','4','idregistrylegalstatus','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','smallint','','S','System.Int16','smallint','N','registrylegalstatusregview','N','','2','incomeclass','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','smalldatetime','','S','System.DateTime','smalldatetime','N','registrylegalstatusregview','N','','4','incomeclassvalidity','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','datetime','','S','System.DateTime','datetime','N','registrylegalstatusregview','N','','8','lt','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','varchar','','S','System.String','varchar(64)','N','registrylegalstatusregview','N','','64','lu','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','varchar','','S','System.String','varchar(50)','N','registrylegalstatusregview','N','','50','position','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','varchar','','N','System.String','varchar(100)','N','registrylegalstatusregview','S','','100','registry','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','smalldatetime','','N','System.DateTime','smalldatetime','N','registrylegalstatusregview','S','','4','start','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','datetime','','S','System.DateTime','datetime','N','registrylegalstatusregview','N','','8','stop','0')
GO

-- VERIFICA DI registrylegalstatusregview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrylegalstatusregview')
UPDATE customobject set isreal = 'N' where objectname = 'registrylegalstatusregview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrylegalstatusregview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

