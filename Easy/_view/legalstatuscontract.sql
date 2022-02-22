
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


-- CREAZIONE VISTA legalstatuscontract
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[legalstatuscontract]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[legalstatuscontract]
GO



CREATE  VIEW [dbo].[legalstatuscontract]
	(
	idreg,
	idregistrylegalstatus,
	idposition,
	codeposition,
	position,
	incomeclass,
	incomeclassvalidity,
	maxincomeclass,
	start,
	stop,
	csa_compartment,csa_role, csa_class,csa_description
	)
	AS 

SELECT 
	registrylegalstatus.idreg,
	registrylegalstatus.idregistrylegalstatus,
	registrylegalstatus.idposition,
	position.codeposition,
	position.description,
	isnull(registrylegalstatus.incomeclass,0),
	registrylegalstatus.incomeclassvalidity,
	position.maxincomeclass,
	registrylegalstatus.start,
	registrylegalstatus.stop,
	registrylegalstatus.csa_compartment, 
	registrylegalstatus.csa_role, 
	registrylegalstatus.csa_class,
	csapositionlookup.csa_description
	FROM registrylegalstatus (NOLOCK)
	JOIN position (NOLOCK)
		ON position.idposition = registrylegalstatus.idposition
	LEFT OUTER JOIN csapositionlookup
		ON registrylegalstatus.idposition = csapositionlookup.idposition
		AND registrylegalstatus.csa_compartment = csapositionlookup.csa_compartment
		AND registrylegalstatus.csa_role = csapositionlookup.csa_role
		AND registrylegalstatus.csa_class = csapositionlookup.csa_class

	







GO

-- VERIFICA DI legalstatuscontract IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'legalstatuscontract'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','varchar','','N','System.String','varchar(20)','N','legalstatuscontract','S','','20','codeposition','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','varchar','','S','System.String','varchar(20)','N','legalstatuscontract','N','','20','csa_class','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','char','','S','System.String','char(1)','N','legalstatuscontract','N','','1','csa_compartment','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','varchar','','S','System.String','varchar(200)','N','legalstatuscontract','N','','200','csa_description','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','varchar','','S','System.String','varchar(4)','N','legalstatuscontract','N','','4','csa_role','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','int','','S','System.Int32','int','N','legalstatuscontract','N','','4','idposition','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','int','','N','System.Int32','int','N','legalstatuscontract','S','','4','idreg','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','int','','N','System.Int32','int','N','legalstatuscontract','S','','4','idregistrylegalstatus','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','smallint','','N','System.Int16','smallint','N','legalstatuscontract','S','','2','incomeclass','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','smalldatetime','','S','System.DateTime','smalldatetime','N','legalstatuscontract','N','','4','incomeclassvalidity','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','smallint','','S','System.Int16','smallint','N','legalstatuscontract','N','','2','maxincomeclass','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','varchar','','N','System.String','varchar(50)','N','legalstatuscontract','S','','50','position','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','smalldatetime','','N','System.DateTime','smalldatetime','N','legalstatuscontract','S','','4','start','0')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SA','''SA''','0','datetime','','S','System.DateTime','datetime','N','legalstatuscontract','N','','8','stop','0')
GO

-- VERIFICA DI legalstatuscontract IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'legalstatuscontract')
UPDATE customobject set isreal = 'N' where objectname = 'legalstatuscontract'
ELSE
INSERT INTO customobject (objectname, isreal) values('legalstatuscontract', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

