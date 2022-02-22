
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


-- CREAZIONE VISTA payrollview
IF EXISTS(select * from sysobjects where id = object_id(N'[payrollview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payrollview]
GO






CREATE VIEW [payrollview]
(
	idpayroll,
	fiscalyear,
	enabletaxrelief,
	currentrounding,
	feegross,
	netfee, 
	idupb,
	codeupb,
	ct,
	cu,
	disbursementdate,
	stop,
	start,
	flagcomputed,
	flagbalance, 
	flagsummarybalance,
	workingdays,
	idresidence,
	idcon,
	lt,
	lu,
	npayroll,
	ycon, 
	ncon,
	registry,
	idreg,
	matricula,
	idser, 
	service,
	codeser,
	residencecity,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	sortcode1
)
AS
SELECT
	payroll.idpayroll,
	payroll.fiscalyear,
	payroll.enabletaxrelief,
	payroll.currentrounding,
	payroll.feegross,
	payroll.netfee, 
	payroll.idupb,
	upb.codeupb,
	payroll.ct,
	payroll.cu,
	payroll.disbursementdate,
	payroll.stop,
	payroll.start,
	payroll.flagcomputed,
	payroll.flagbalance, 
	payroll.flagsummarybalance,
	payroll.workingdays,
	payroll.idresidence,
	payroll.idcon,
	payroll.lt,
	payroll.lu,
	payroll.npayroll,
	parasubcontract.ycon, 
	parasubcontract.ncon,
	registry.title,
	parasubcontract.idreg,
	parasubcontract.matricula,
	parasubcontract.idser,
	service.description,
	service.codeser,
	geo_city.title,
	isnull(parasubcontract.idsor01,upb.idsor01),
	isnull(parasubcontract.idsor02,upb.idsor02),
	isnull(parasubcontract.idsor03,upb.idsor03),
	isnull(parasubcontract.idsor04,upb.idsor04),
	isnull(parasubcontract.idsor05,upb.idsor05),
	sorting.sortcode
FROM payroll with (nolock)
JOIN parasubcontract with (nolock)			ON payroll.idcon = parasubcontract.idcon
LEFT OUTER JOIN sorting with (nolock)       ON parasubcontract.idsor1 = sorting.idsor
JOIN service with (nolock)					ON parasubcontract.idser = service.idser
INNER JOIN registry with (nolock)			ON parasubcontract.idreg = registry.idreg
LEFT OUTER JOIN geo_city with (nolock)		ON payroll.idresidence = geo_city.idcity
--LEFT OUTER JOIN upb  with (nolock)			ON upb.idupb = parasubcontract.idupb
LEFT OUTER JOIN expensepayroll  with (nolock)	ON payroll.idpayroll = expensepayroll.idpayroll
LEFT OUTER JOIN expense   with (nolock)		ON expense.idexp = expensepayroll.idexp
LEFT OUTER JOIN upb  ON upb.idupb = payroll.idupb


GO

-- VERIFICA DI payrollview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'payrollview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','codeser','20','''assistenza17''','varchar(20)','payrollview','','','','','N','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','codeupb','50','''assistenza17''','varchar(50)','payrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','ct','8','''assistenza17''','datetime','payrollview','','','','','S','N','datetime','assistenza17','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','cu','64','''assistenza17''','varchar(64)','payrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','currentrounding','9','''assistenza17''','decimal(19,2)','payrollview','','19','','2','N','N','decimal','assistenza17','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','disbursementdate','3','''assistenza17''','date','payrollview','','','','','S','N','date','assistenza17','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','enabletaxrelief','1','''assistenza17''','char(1)','payrollview','','','','','N','N','char','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','feegross','9','''assistenza17''','decimal(19,2)','payrollview','','19','','2','N','N','decimal','assistenza17','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','fiscalyear','4','''assistenza17''','int','payrollview','','','','','N','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','flagbalance','1','''assistenza17''','char(1)','payrollview','','','','','S','N','char','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','flagcomputed','1','''assistenza17''','char(1)','payrollview','','','','','N','N','char','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','flagsummarybalance','1','''assistenza17''','char(1)','payrollview','','','','','S','N','char','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idcon','8','''assistenza17''','varchar(8)','payrollview','','','','','N','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idpayroll','4','''assistenza17''','int','payrollview','','','','','N','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idreg','4','''assistenza17''','int','payrollview','','','','','N','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idresidence','4','''assistenza17''','int','payrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idser','4','''assistenza17''','int','payrollview','','','','','N','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor01','4','''assistenza17''','int','payrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor02','4','''assistenza17''','int','payrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor03','4','''assistenza17''','int','payrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor04','4','''assistenza17''','int','payrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor05','4','''assistenza17''','int','payrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','38','''assistenza17''','varchar(38)','payrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','lt','8','''assistenza17''','datetime','payrollview','','','','','S','N','datetime','assistenza17','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','lu','64','''assistenza17''','varchar(64)','payrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','matricula','4','''assistenza17''','int','payrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ncon','20','''assistenza17''','varchar(20)','payrollview','','','','','N','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','netfee','9','''assistenza17''','decimal(19,2)','payrollview','','19','','2','S','N','decimal','assistenza17','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','npayroll','4','''assistenza17''','int','payrollview','','','','','N','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','registry','100','''assistenza17''','varchar(100)','payrollview','','','','','N','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','residencecity','65','''assistenza17''','varchar(65)','payrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','service','50','''assistenza17''','varchar(50)','payrollview','','','','','N','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','sortcode1','50','''assistenza17''','varchar(50)','payrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','start','3','''assistenza17''','date','payrollview','','','','','N','N','date','assistenza17','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','stop','3','''assistenza17''','date','payrollview','','','','','N','N','date','assistenza17','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','workingdays','2','''assistenza17''','smallint','payrollview','','','','','N','N','smallint','assistenza17','System.Int16')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ycon','4','''assistenza17''','int','payrollview','','','','','N','N','int','assistenza17','System.Int32')
GO

-- VERIFICA DI payrollview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'payrollview')
UPDATE customobject set isreal = 'N' where objectname = 'payrollview'
ELSE
INSERT INTO customobject (objectname, isreal) values('payrollview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

