
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


-- CREAZIONE VISTA expensepayrollview
IF EXISTS(select * from sysobjects where id = object_id(N'[expensepayrollview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expensepayrollview]
GO



CREATE   VIEW [expensepayrollview]
(
	idpayroll, idexp, fiscalyear, npayroll, 
	nphase, phase, ymov, nmov, 
	parentidexp, parentymov,parentnmov, 
	formerymov,formernmov,
	ayear, idfin, 
	codefin, finance, 
	idupb,	codeupb,upb,
	idreg,registry,
	idman, manager,
	doc, docdate, description, 
	amount,
	ayearstartamount, 
	curramount, available, 
	autokind,
	idpayment, 
	totflag,
	flagarrear, 
	expiration, adate, cu, 
	ct, lu, lt, 
	idcon,
	idaccmotive,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS
SELECT
	expensepayroll.idpayroll, expense.idexp, payroll.fiscalyear, 
	payroll.npayroll, 
	expense.nphase, expensephase.description , expense.ymov, expense.nmov, 
	expense.parentidexp, parentexpense.ymov, parentexpense.nmov,
	former.ymov,former.nmov,
	expenseyear.ayear, expenseyear.idfin, 
	fin.codefin, fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg, registry.title,
	expense.idman, manager.title ,
	expense.doc, expense.docdate, expense.description, 
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount, expensetotal.available,  
	expense.autokind, 
	expense.idpayment, 
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.expiration, expense.adate, expensepayroll.cu, 
	expensepayroll.ct, expensepayroll.lu, expensepayroll.lt, 
	payroll.idcon,
	parasubcontract.idaccmotive,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05
FROM expensepayroll
JOIN payroll				ON payroll.idpayroll = expensepayroll.idpayroll 
JOIN config					ON config.ayear = payroll.fiscalyear 
JOIN expense				ON expense.idexp=expensepayroll.idexp 
JOIN expensephase			ON expensephase.nphase = expense.nphase 
JOIN expenseyear			ON expenseyear.idexp = expense.idexp 
JOIN expensetotal			ON expensetotal.idexp = expenseyear.idexp 
								AND expensetotal.ayear = expenseyear.ayear 
JOIN parasubcontract		ON parasubcontract.idcon = payroll.idcon
LEFT OUTER JOIN expense parentexpense					ON expense.parentidexp = parentexpense.idexp 
LEFT OUTER JOIN expense former							ON expense.idformerexpense = former.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear		ON expensetotal_firstyear.idexp = expense.idexp
															AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting		ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
															AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN fin				ON fin.idfin = expenseyear.idfin 
LEFT OUTER JOIN upb				ON  upb.idupb = expenseyear.idupb 
LEFT OUTER JOIN registry		ON registry.idreg = expense.idreg 
LEFT OUTER JOIN manager			ON manager.idman = expense.idman 






GO

-- VERIFICA DI expensepayrollview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'expensepayrollview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','adate','3','''assistenza17''','date','expensepayrollview','','','','','N','N','date','assistenza17','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','amount','9','''assistenza17''','decimal(19,2)','expensepayrollview','','19','','2','S','N','decimal','assistenza17','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','autokind','1','''assistenza17''','tinyint','expensepayrollview','','','','','S','N','tinyint','assistenza17','System.Byte')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','available','9','''assistenza17''','decimal(19,2)','expensepayrollview','','19','','2','S','N','decimal','assistenza17','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ayear','2','''assistenza17''','smallint','expensepayrollview','','','','','N','N','smallint','assistenza17','System.Int16')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','ayearstartamount','9','''assistenza17''','decimal(19,2)','expensepayrollview','','19','','2','S','N','decimal','assistenza17','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','codefin','50','''assistenza17''','varchar(50)','expensepayrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','codeupb','50','''assistenza17''','varchar(50)','expensepayrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','ct','8','''assistenza17''','datetime','expensepayrollview','','','','','S','N','datetime','assistenza17','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','cu','64','''assistenza17''','varchar(64)','expensepayrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','curramount','9','''assistenza17''','decimal(19,2)','expensepayrollview','','19','','2','S','N','decimal','assistenza17','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','description','150','''assistenza17''','varchar(150)','expensepayrollview','','','','','N','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','35','''assistenza17''','varchar(35)','expensepayrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','docdate','3','''assistenza17''','date','expensepayrollview','','','','','S','N','date','assistenza17','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','expiration','3','''assistenza17''','date','expensepayrollview','','','','','S','N','date','assistenza17','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','finance','150','''assistenza17''','varchar(150)','expensepayrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','fiscalyear','4','''assistenza17''','int','expensepayrollview','','','','','N','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','flagarrear','1','''assistenza17''','varchar(1)','expensepayrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','formernmov','4','''assistenza17''','int','expensepayrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','formerymov','2','''assistenza17''','smallint','expensepayrollview','','','','','S','N','smallint','assistenza17','System.Int16')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idaccmotive','36','''assistenza17''','varchar(36)','expensepayrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idcon','8','''assistenza17''','varchar(8)','expensepayrollview','','','','','N','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idexp','4','''assistenza17''','int','expensepayrollview','','','','','N','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idfin','4','''assistenza17''','int','expensepayrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idman','4','''assistenza17''','int','expensepayrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idpayment','4','''assistenza17''','int','expensepayrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idpayroll','4','''assistenza17''','int','expensepayrollview','','','','','N','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idreg','4','''assistenza17''','int','expensepayrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor01','4','''assistenza17''','int','expensepayrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor02','4','''assistenza17''','int','expensepayrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor03','4','''assistenza17''','int','expensepayrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor04','4','''assistenza17''','int','expensepayrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idsor05','4','''assistenza17''','int','expensepayrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza17''','varchar(36)','expensepayrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','lt','8','''assistenza17''','datetime','expensepayrollview','','','','','S','N','datetime','assistenza17','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','lu','64','''assistenza17''','varchar(64)','expensepayrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','manager','150','''assistenza17''','varchar(150)','expensepayrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','nmov','4','''assistenza17''','int','expensepayrollview','','','','','N','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','npayroll','4','''assistenza17''','int','expensepayrollview','','','','','N','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','nphase','1','''assistenza17''','tinyint','expensepayrollview','','','','','N','N','tinyint','assistenza17','System.Byte')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','parentidexp','4','''assistenza17''','int','expensepayrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','parentnmov','4','''assistenza17''','int','expensepayrollview','','','','','S','N','int','assistenza17','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','parentymov','2','''assistenza17''','smallint','expensepayrollview','','','','','S','N','smallint','assistenza17','System.Int16')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','phase','50','''assistenza17''','varchar(50)','expensepayrollview','','','','','N','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','registry','100','''assistenza17''','varchar(100)','expensepayrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','totflag','1','''assistenza17''','tinyint','expensepayrollview','','','','','S','N','tinyint','assistenza17','System.Byte')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','upb','150','''assistenza17''','varchar(150)','expensepayrollview','','','','','S','N','varchar','assistenza17','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ymov','2','''assistenza17''','smallint','expensepayrollview','','','','','N','N','smallint','assistenza17','System.Int16')
GO

-- VERIFICA DI expensepayrollview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'expensepayrollview')
UPDATE customobject set isreal = 'N' where objectname = 'expensepayrollview'
ELSE
INSERT INTO customobject (objectname, isreal) values('expensepayrollview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

