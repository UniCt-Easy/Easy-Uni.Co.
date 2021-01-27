
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


-- CREAZIONE VISTA csa_import_originalpartitionview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_import_originalpartitionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_import_originalpartitionview]
GO

 -- setuser 'amministrazione'
 
 -- select * from [csa_import_originalpartitionview]
 CREATE VIEW  [csa_import_originalpartitionview]
 (
 			kind, idcsa_import, idinc, idexp, ymov, nmov, nphase, ayear, movkind, idcsa_agency,idreg,registry, description
 )
 AS SELECT  'Entrata', PV.idcsa_import,  
			income.idinc, null, income.ymov, income.nmov, income.nphase,incomeyear.ayear,
			PV.movkind,null,income.idreg, registry_agency.title, income.description
			from  income   
			JOIN  incomeyear ON income.idinc = incomeyear.idinc  
			JOIN  incomelast ON income.idinc = incomelast.idinc  
		 	JOIN  incomevar ON incomevar.idinc = incomelast.idinc  
			JOIN  registry as registry_agency ON registry_agency.idreg = income.idreg 
			JOIN  csa_import_income PV ON PV.idinc = incomelast.idinc
			--    tipo movimento automatismo versamento CSA
			WHERE incomevar.autokind  = 32
UNION ALL
SELECT		'Spesa', PV.idcsa_import, 
			null, expense.idexp, expense.ymov, expense.nmov,expense.nphase, expenseyear.ayear,
			PV.movkind,null,expense.idreg, registry_agency.title,expense.description
			from  expense  
			JOIN  expenseyear ON expense.idexp = expenseyear.idexp  
			JOIN  expenselast ON expense.idexp = expenselast.idexp  
			JOIN  expensevar ON expensevar.idexp = expenselast.idexp  
			JOIN  registry as registry_agency ON registry_agency.idreg = expense.idreg 
			JOIN  csa_import_expense PV ON PV.idexp = expenselast.idexp
			-- tipo movimento automatismo versamento CSA
			WHERE expensevar.autokind  = 32




GO

-- VERIFICA DI csa_import_originalpartitionview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'csa_import_originalpartitionview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ayear','2','''assistenza4''','smallint','csa_import_originalpartitionview','','','','','N','N','smallint','assistenza4','System.Int16')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','description','150','''assistenza4''','varchar(150)','csa_import_originalpartitionview','','','','','N','N','varchar','assistenza4','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idcsa_agency','4','''assistenza4''','int','csa_import_originalpartitionview','','','','','S','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idcsa_import','4','''assistenza4''','int','csa_import_originalpartitionview','','','','','N','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexp','4','''assistenza4''','int','csa_import_originalpartitionview','','','','','S','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idinc','4','''assistenza4''','int','csa_import_originalpartitionview','','','','','S','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idreg','4','''assistenza4''','int','csa_import_originalpartitionview','','','','','S','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','kind','7','''assistenza4''','varchar(7)','csa_import_originalpartitionview','','','','','N','N','varchar','assistenza4','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','movkind','4','''assistenza4''','int','csa_import_originalpartitionview','','','','','N','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','nmov','4','''assistenza4''','int','csa_import_originalpartitionview','','','','','N','N','int','assistenza4','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','nphase','1','''assistenza4''','tinyint','csa_import_originalpartitionview','','','','','N','N','tinyint','assistenza4','System.Byte')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','registry','100','''assistenza4''','varchar(100)','csa_import_originalpartitionview','','','','','N','N','varchar','assistenza4','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ymov','2','''assistenza4''','smallint','csa_import_originalpartitionview','','','','','N','N','smallint','assistenza4','System.Int16')
GO

-- VERIFICA DI csa_import_originalpartitionview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'csa_import_originalpartitionview')
UPDATE customobject set isreal = 'N' where objectname = 'csa_import_originalpartitionview'
ELSE
INSERT INTO customobject (objectname, isreal) values('csa_import_originalpartitionview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

