
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


-- CREAZIONE VISTA mandatedetailexpworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[mandatedetailexpworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandatedetailexpworkpackageview]
GO


-- Per mandatedetail è sufficiente che progettocosto vada in join con idrelated, perchè l'idrelated ha il rownum


CREATE        VIEW [mandatedetailexpworkpackageview]
as
select 
	I.idmankind, I.yman, I.nman,
	I.description as descriptionmandate,
	substring('Doc.CP:' + I.doc,1,35) as doc,
	I.docdate,
	DET.rownum,
	DET.idupb,
	'man' + '§' + convert(varchar(4), DET.idmankind) + '§'  + convert(varchar(4), DET.yman) + '§'  + convert(varchar(14),DET.nman)+ '§'  + convert(varchar(10),DET.rownum) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	v.idexp as idexppayed,
	-- IMPONIBILE 
		CONVERT(decimal(19,2),
		ROUND(DET.taxable * ISNULL(DET.npackage, DET.number) * 
		  CONVERT(DECIMAL(19,10),I.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(DET.discount, 0.0)))
		 ,2
		)) as taxable_euro,
	-- IVA
	CONVERT(decimal(19,2),ROUND(DET.tax,2))
			 as iva_euro,
-- Calcola il pagato
	ISNULL(v.amount,0) AS payedamount,
	PC.idprogettocosto
from mandate I 
JOIN mandatekind 		
	ON mandatekind.idmankind = I.idmankind
join mandatedetail DET 
	ON I.idmankind = DET.idmankind  and I.yman = DET.yman and I.nman = DET.nman
join progettotipocostoaccmotive PM 	
	on PM.idaccmotive = DET.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
join progetto P 
	on PM.idprogetto = P.idprogetto
left outer join expenselastmandatedetail v 
	on v.idmankind = DET.idmankind AND v.yman = DET.yman AND v.nman = DET.nman AND v.rownum = DET.rownum 

join workpackageupb WPU 
	on WPU.idprogetto = P.idprogetto and WPU.idupb = DET.idupb
join workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage

left outer join progettocosto PC
	on 'man' + '§' + convert(varchar(4), DET.idmankind) + '§'  + convert(varchar(4), DET.yman) + '§'  + convert(varchar(14),DET.nman)+ '§'  + convert(varchar(10),DET.rownum) = PC.idrelated
WHERE mandatekind.linktoinvoice = 'N'

GO

-- VERIFICA DI mandatedetailexpworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'mandatedetailexpworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','descriptionmandate','150','''assistenza''','varchar(150)','mandatedetailexpworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','mandatedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','35','''assistenza''','varchar(35)','mandatedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','docdate','3','''assistenza''','date','mandatedetailexpworkpackageview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexppayed','4','''assistenza''','int','mandatedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idmankind','20','''assistenza''','varchar(20)','mandatedetailexpworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','mandatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','mandatedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','mandatedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','mandatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','39','''assistenza''','varchar(39)','mandatedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza''','varchar(36)','mandatedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','mandatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','iva_euro','9','''assistenza''','decimal(19,2)','mandatedetailexpworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','nman','4','''assistenza''','int','mandatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','payedamount','9','''assistenza''','decimal(19,2)','mandatedetailexpworkpackageview','','19','','2','N','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','4000','''assistenza''','nvarchar(4000)','mandatedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','rownum','4','''assistenza''','int','mandatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','taxable_euro','9','''assistenza''','decimal(19,2)','mandatedetailexpworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','mandatedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','yman','2','''assistenza''','smallint','mandatedetailexpworkpackageview','','','','','N','N','smallint','assistenza','System.Int16')
GO

-- VERIFICA DI mandatedetailexpworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'mandatedetailexpworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'mandatedetailexpworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('mandatedetailexpworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

