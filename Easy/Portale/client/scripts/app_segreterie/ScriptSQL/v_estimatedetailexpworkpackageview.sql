
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


-- CREAZIONE VISTA estimatedetailexpworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[estimatedetailexpworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [estimatedetailexpworkpackageview]
GO


-- Per estimatedetail è sufficiente che progettoricavo vada in join con idrelated, perchè l'idrelated ha il rownum


CREATE        VIEW [estimatedetailexpworkpackageview]
as
select 
	I.idestimkind, I.yestim, I.nestim,
	I.description as descriptionestimate,
	substring('Doc.CA:' + I.doc,1,35) as doc,
	I.docdate,
	DET.rownum,
	DET.idupb,
	'estim' + '§' + convert(varchar(4), DET.idestimkind) + '§'  + convert(varchar(4), DET.yestim) + '§'  + convert(varchar(14),DET.nestim)+ '§'  + convert(varchar(10),DET.rownum) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	v.idinc as idincproceed,
	-- IMPONIBILE 
		CONVERT(decimal(19,2),
		ROUND(DET.taxable * DET.number * 
		  CONVERT(DECIMAL(19,10),I.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(DET.discount, 0.0)))
		 ,2
		)) as taxable_euro,
	-- IVA
	CONVERT(decimal(19,2),ROUND(DET.tax,2))
			 as iva_euro,
-- Calcola il pagato
	ISNULL(v.amount, 0) AS proceedamount,
	PC.idprogettoricavo
from estimate I 
JOIN estimatekind 		
	ON estimatekind.idestimkind = I.idestimkind
join estimatedetail DET 
	ON I.idestimkind = DET.idestimkind  and I.yestim = DET.yestim and I.nestim = DET.nestim
join progettotiporicavoaccmotive PM 	
	on PM.idaccmotive = DET.idaccmotive 
join progettotipocosto PTC		/*Tipo voce ricavo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
join progetto P 
	on PM.idprogetto = P.idprogetto
join workpackageupb WPU 
	on WPU.idprogetto = P.idprogetto and WPU.idupb = DET.idupb
join workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
left outer join incomelastestimatedetail v 
				on	v.idestimkind = DET.idestimkind AND	 v.yestim = DET.yestim AND	 v.nestim = DET.nestim AND		 v.rownum = DET.rownum
left outer join progettoricavo PC
	on 'estim' + '§' + convert(varchar(4), DET.idestimkind) + '§'  + convert(varchar(4), DET.yestim) + '§'  + convert(varchar(14),DET.nestim)+ '§'  + convert(varchar(10),DET.rownum) = PC.idrelated
WHERE estimatekind.linktoinvoice = 'N'

GO

-- VERIFICA DI estimatedetailexpworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'estimatedetailexpworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','descriptionestimate','150','''assistenza''','varchar(150)','estimatedetailexpworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','estimatedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','35','''assistenza''','varchar(35)','estimatedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','docdate','3','''assistenza''','date','estimatedetailexpworkpackageview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idestimkind','20','''assistenza''','varchar(20)','estimatedetailexpworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idincproceed','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettoricavo','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotiporicavo','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','41','''assistenza''','varchar(41)','estimatedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza''','varchar(36)','estimatedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','iva_euro','9','''assistenza''','decimal(19,2)','estimatedetailexpworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','nestim','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','proceedamount','9','''assistenza''','decimal(19,2)','estimatedetailexpworkpackageview','','19','','2','N','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','4000','''assistenza''','nvarchar(4000)','estimatedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','rownum','4','''assistenza''','int','estimatedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','taxable_euro','9','''assistenza''','decimal(19,2)','estimatedetailexpworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','estimatedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','yestim','2','''assistenza''','smallint','estimatedetailexpworkpackageview','','','','','N','N','smallint','assistenza','System.Int16')
GO

-- VERIFICA DI estimatedetailexpworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'estimatedetailexpworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'estimatedetailexpworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('estimatedetailexpworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

