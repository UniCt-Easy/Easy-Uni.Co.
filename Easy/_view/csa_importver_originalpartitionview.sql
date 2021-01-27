
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


-- CREAZIONE VISTA csa_importver_originalpartitionview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importver_originalpartitionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importver_originalpartitionview]
GO

 -- setuser 'amministrazione'
 
 -- select * from [csa_importver_originalpartitionview]
 CREATE VIEW  [csa_importver_originalpartitionview]
 (
 			kind, idcsa_import,idver,ndetail, idinc, idexp, ymov, nmov, nphase, ayear,amount, originalamount, movkind, idcsa_agency,idreg,registry, description
 )
 AS SELECT  'Entrata', PV.idcsa_import, PV.idver, PV.ndetail, 
			income.idinc, null, income.ymov, income.nmov, income.nphase,incomeyear.ayear,
			PV.amount, PV.originalamount,V.idcsa_agency,PV.movkind,income.idreg, registry_agency.title, income.description
			from  income   
			JOIN  incomeyear ON income.idinc = incomeyear.idinc  
			JOIN  incomelast ON income.idinc = incomelast.idinc  
		 	JOIN  incomevar ON incomevar.idinc = incomelast.idinc  
			JOIN  registry as registry_agency ON registry_agency.idreg = income.idreg 
			JOIN  csa_importver_partition_income PV ON PV.idinc = incomelast.idinc
			--    tipo movimento automatismo versamento CSA
			JOIN csa_importver V ON PV.idcsa_import = V.idcsa_import AND PV.idver = V.idver
			WHERE incomevar.autokind  = 32
UNION ALL
SELECT		'Spesa', PV.idcsa_import, PV.idver, PV.ndetail,
			null, expense.idexp, expense.ymov, expense.nmov,expense.nphase, expenseyear.ayear,
			PV.amount, PV.originalamount, PV.movkind,V.idcsa_agency,expense.idreg, registry_agency.title,expense.description
			from  expense  
			JOIN  expenseyear ON expense.idexp = expenseyear.idexp  
			JOIN  expenselast ON expense.idexp = expenselast.idexp  
			JOIN  expensevar ON expensevar.idexp = expenselast.idexp  
			JOIN  registry as registry_agency ON registry_agency.idreg = expense.idreg 
			JOIN  csa_importver_partition_expense PV ON PV.idexp = expenselast.idexp
			-- tipo movimento automatismo versamento CSA
			JOIN csa_importver V ON PV.idcsa_import = V.idcsa_import AND PV.idver = V.idver
			WHERE expensevar.autokind  = 32






 

 
GO

-- VERIFICA DI csa_importver_originalpartitionview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'csa_importver_originalpartitionview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','amount','9','''assistenza4''','decimal(19,2)','csa_importver_originalpartitionview','','19','','2','S','N','decimal','assistenza4','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ayear','2','''assistenza4''','smallint','csa_importver_originalpartitionview','','','','','N','N','smallint','assistenza4','System.Int16')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','description','150','''assistenza4''','varchar(150)','csa_importver_originalpartitionview','','','','','N','N','varchar','assistenza4','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idcsa_agency','4','''assistenza4''','int','csa_importver_originalpartitionview','','','','','S','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idcsa_import','4','''assistenza4''','int','csa_importver_originalpartitionview','','','','','N','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexp','4','''assistenza4''','int','csa_importver_originalpartitionview','','','','','S','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idinc','4','''assistenza4''','int','csa_importver_originalpartitionview','','','','','S','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idreg','4','''assistenza4''','int','csa_importver_originalpartitionview','','','','','S','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idver','4','''assistenza4''','int','csa_importver_originalpartitionview','','','','','N','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','kind','7','''assistenza4''','varchar(7)','csa_importver_originalpartitionview','','','','','N','N','varchar','assistenza4','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','movkind','4','''assistenza4''','int','csa_importver_originalpartitionview','','','','','S','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ndetail','4','''assistenza4''','int','csa_importver_originalpartitionview','','','','','N','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','nmov','4','''assistenza4''','int','csa_importver_originalpartitionview','','','','','N','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','nphase','1','''assistenza4''','tinyint','csa_importver_originalpartitionview','','','','','N','N','tinyint','assistenza4','System.Byte')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','originalamount','9','''assistenza4''','decimal(19,2)','csa_importver_originalpartitionview','','19','','2','S','N','decimal','assistenza4','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','registry','100','''assistenza4''','varchar(100)','csa_importver_originalpartitionview','','','','','N','N','varchar','assistenza4','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ymov','2','''assistenza4''','smallint','csa_importver_originalpartitionview','','','','','N','N','smallint','assistenza4','System.Int16')
GO

-- VERIFICA DI csa_importver_originalpartitionview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'csa_importver_originalpartitionview')
UPDATE customobject set isreal = 'N' where objectname = 'csa_importver_originalpartitionview'
ELSE
INSERT INTO customobject (objectname, isreal) values('csa_importver_originalpartitionview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

