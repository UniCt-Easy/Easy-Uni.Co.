
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


-- CREAZIONE VISTA casualcontractworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[casualcontractworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [casualcontractworkpackageview]
GO


CREATE VIEW [casualcontractworkpackageview]
as
select 
	C.ycon, C.ncon, C.description as descriptioncasualcontract,
	substring('Contratto Occasionale '+ convert(varchar(4), C.ycon) + '/' + convert(varchar(10), C.ncon),1,35)  as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'cascon' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.feegross,
	EL.idexp as idexppayed,
	--Calcola il pagato con i Mov. di spesa
	isnull(EY.amount,0) + 
		+
	   ISNULL((SELECT SUM(V1.amount)     FROM expensecasualcontract EC1     
	   JOIN expenselink ELK1 ON ELK.idparent = EC1.idexp    
	   JOIN expenselast EL1       ON EL.idexp=ELK.idchild    
	   JOIN expensevar V1  ON V1.idexp = EL.idexp    
	   WHERE (ISNULL(v1.autokind,0)<> 4)  and EL1.idexp = EL.idexp
		),0) 
	AS exppayedamount,
	null as idpettycash, null as yoperation, null as noperation,
	null as pettycashpayedamount,
	PC.idprogettocosto
from casualcontract C 
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = C.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
--Va in LEFT per mostrare anche il compenso non ancora pagato
left outer join expensecasualcontract EC on EC.ncon= C.ncon AND EC.ycon=C.ycon
left outer	JOIN expenselink ELK   ON ELK.idparent = EC.idexp  and ELK.idchild <>elk.idparent
left outer JOIN expenselast EL    ON EL.idexp=ELK.idchild    
left outer JOIN expenseyear EY    ON EL.idexp=EY.idexp    
left outer join progettocosto PC
	on 'cascon' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) = PC.idrelated
	and PC.idexp = EL.idexp	 
UNION all
select 
	C.ycon, C.ncon, C.description as descriptioncasualcontract,
	'Contratto Occasionale '+ convert(varchar(4), C.ycon) + '/' + convert(varchar(10), C.ncon) as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'cascon' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.feegross,
	null as idexppayed,
	null AS exppayedamount,
	PCO.idpettycash, PCO.yoperation, PCO.noperation,
	-- Calcola il pagato col fondo economale
	isnull(PO.amount,0)  as pettycashpayedamount,
	PC.idprogettocosto
from casualcontract C 
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = C.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
--Va in LEFT per mostrare anche il compenso non ancora pagato
LEFT OUTER join  pettycashoperationcasualcontract PCO ON PCO.ycon = C.ycon AND PCO.ncon = C.ncon
left outer JOIN pettycashoperation PO ON PCO.idpettycash = PO.idpettycash AND PCO.yoperation = PO.yoperation AND PCO.noperation = PO.noperation    
left outer join progettocosto PC
	on 'cascon' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) = PC.idrelated
	and PCO.idpettycash = PC.idpettycash AND PCO.yoperation = PC.yoperation AND PCO.noperation = PC.noperation    	 

GO

-- VERIFICA DI casualcontractworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'casualcontractworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','adate','3','''assistenza''','date','casualcontractworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptioncasualcontract','150','''assistenza''','varchar(150)','casualcontractworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','casualcontractworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','37','''assistenza''','varchar(37)','casualcontractworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','docdate','3','''assistenza''','date','casualcontractworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','exppayedamount','17','''assistenza''','decimal(38,2)','casualcontractworkpackageview','','38','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','feegross','9','''assistenza''','decimal(19,2)','casualcontractworkpackageview','','19','','2','N','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexppayed','4','''assistenza''','int','casualcontractworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idpettycash','4','''assistenza''','int','casualcontractworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','casualcontractworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','casualcontractworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','casualcontractworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','casualcontractworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','26','''assistenza''','varchar(26)','casualcontractworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza''','varchar(36)','casualcontractworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','casualcontractworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ncon','4','''assistenza''','int','casualcontractworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','noperation','4','''assistenza''','int','casualcontractworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','pettycashpayedamount','9','''assistenza''','decimal(19,2)','casualcontractworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','2048','''assistenza''','nvarchar(2048)','casualcontractworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','start','3','''assistenza''','date','casualcontractworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','stop','3','''assistenza''','date','casualcontractworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','casualcontractworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ycon','4','''assistenza''','int','casualcontractworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','yoperation','2','''assistenza''','smallint','casualcontractworkpackageview','','','','','S','N','smallint','assistenza','System.Int16')
GO

-- VERIFICA DI casualcontractworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'casualcontractworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'casualcontractworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('casualcontractworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA invoicedetailexpworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicedetailexpworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicedetailexpworkpackageview]
GO


-- Per invoicedetail è sufficiente che progettocosto vada in join con idrelated, perchè l'idrelated ha il rownum


CREATE        VIEW [invoicedetailexpworkpackageview]
as
select 
	I.idinvkind, I.yinv, I.ninv,
		CASE
			WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
			WHEN ((invoicekind.flag&1)<>0) THEN 'V'
		END as flagbuysell, 
		CASE
			WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
			WHEN ((invoicekind.flag&4)<>0) THEN 'S'
		END as flagvariation ,
	I.description as descriptioninvoice,
	substring('Doc.IVA:' + I.doc,1,35) as doc,
	I.docdate,
	Idet.rownum,
	Idet.idupb,
	'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	IDET.idexp_taxable,
	IDET.idexp_iva,
	-- Indica che la fattura è stata pagata col fondo economale.
	NULL AS idpettycash, NULL as yoperation, NULL as noperation,--PCI.idpettycash , PCI.yoperation, PCI.noperation,
	-- IMPONIBILE 
		CONVERT(decimal(19,2),
		ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
		  CONVERT(DECIMAL(19,10),I.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0)))
		 ,2
		)) as taxable_euro,
	-- IVA
	CONVERT(decimal(19,2),ROUND(IDET.tax,2))
			 as iva_euro,
-- Calcola il pagato
		case 
			when IDET.idexp_taxable IS NULL and  IDET.idexp_iva IS  NULL then 0
			when IDET.idexp_taxable IS not NULL and  IDET.idexp_iva IS  not NULL 
					then CONVERT(decimal(19,2),
						ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
						CONVERT(DECIMAL(19,10),I.exchangerate) *	  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0))) ,2)) 
						+ CONVERT(decimal(19,2),ROUND(IDET.tax,2)	)
			when IDET.idexp_taxable IS NULL and  IDET.idexp_iva IS not NULL then CONVERT(decimal(19,2),ROUND(IDET.tax,2)	)
			when IDET.idexp_taxable IS not NULL and  IDET.idexp_iva IS  NULL then CONVERT(decimal(19,2),
							ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
							CONVERT(DECIMAL(19,10),I.exchangerate) *	 (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0))) ,2))
		end AS payedamount,
	PC.idprogettocosto
from invoice I 
JOIN invoicekind 		
	ON invoicekind.idinvkind = I.idinvkind
join invoicedetail IDET 
	ON I.idinvkind = IDET.idinvkind  and I.yinv = IDET.yinv and I.ninv = IDET.ninv
join progettotipocostoaccmotive PM 	
	on PM.idaccmotive = Idet.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
join progetto P 
	on PM.idprogetto = P.idprogetto
join workpackageupb WPU 
	on WPU.idprogetto = P.idprogetto and WPU.idupb = IDET.idupb
join workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage

left outer join progettocosto PC
	on 'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) = PC.idrelated
UNION all
select 
	I.idinvkind, I.yinv, I.ninv,
		CASE
			WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
			WHEN ((invoicekind.flag&1)<>0) THEN 'V'
		END as flagbuysell, 
		CASE
			WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
			WHEN ((invoicekind.flag&4)<>0) THEN 'S'
		END as flagvariation ,
	I.description as descriptioninvoice,
	I.doc,
	I.docdate,
	Idet.rownum,
	Idet.idupb,
	'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	NULL,--IDET.idexp_taxable,
	NULL,--IDET.idexp_iva,
	-- Indica che la fattura è stata pagata col fondo economale.
	PCI.idpettycash , PCI.yoperation, PCI.noperation,
	-- IMPONIBILE 
		CONVERT(decimal(19,2),
		ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
		  CONVERT(DECIMAL(19,10),I.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0)))
		 ,2
		)) as taxable_euro,
	-- IVA
	CONVERT(decimal(19,2),ROUND(IDET.tax,2))
			 as iva_euro,
-- Calcola il pagato
			CONVERT(decimal(19,2),
				ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
					CONVERT(DECIMAL(19,10),I.exchangerate) *	  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0))) ,2))
				+
				CONVERT(decimal(19,2),ROUND(IDET.tax,2)	)
		AS payedamount,
	PC.idprogettocosto
from invoice I 
JOIN invoicekind 		
	ON invoicekind.idinvkind = I.idinvkind
join invoicedetail IDET 
	ON I.idinvkind = IDET.idinvkind  and I.yinv = IDET.yinv and I.ninv = IDET.ninv
join progettotipocostoaccmotive PM 	
	on PM.idaccmotive = Idet.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
join progetto P 
	on PM.idprogetto = P.idprogetto
join workpackageupb WPU 
	on WPU.idprogetto = P.idprogetto and WPU.idupb = IDET.idupb
join workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
join pettycashoperationinvoice PCI
	on  PCI.idinvkind = I.idinvkind and PCI.yinv = I.yinv and PCI.ninv = I.ninv
left outer join progettocosto PC
	on 'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) = PC.idrelated
	and PCI.idpettycash = PC.idpettycash AND PCI.yoperation = PC.yoperation AND PCI.noperation = PC.noperation    	 



GO

-- VERIFICA DI invoicedetailexpworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'invoicedetailexpworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','descriptioninvoice','150','''assistenza''','varchar(150)','invoicedetailexpworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','invoicedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','35','''assistenza''','varchar(35)','invoicedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','docdate','3','''assistenza''','date','invoicedetailexpworkpackageview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','flagbuysell','1','''assistenza''','varchar(1)','invoicedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','flagvariation','1','''assistenza''','varchar(1)','invoicedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexp_iva','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexp_taxable','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idinvkind','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idpettycash','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','39','''assistenza''','varchar(39)','invoicedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza''','varchar(36)','invoicedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','iva_euro','9','''assistenza''','decimal(19,2)','invoicedetailexpworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ninv','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','noperation','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','payedamount','13','''assistenza''','decimal(20,2)','invoicedetailexpworkpackageview','','20','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','2048','''assistenza''','nvarchar(2048)','invoicedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','rownum','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','taxable_euro','9','''assistenza''','decimal(19,2)','invoicedetailexpworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','invoicedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','yinv','2','''assistenza''','smallint','invoicedetailexpworkpackageview','','','','','N','N','smallint','assistenza','System.Int16')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','yoperation','2','''assistenza''','smallint','invoicedetailexpworkpackageview','','','','','S','N','smallint','assistenza','System.Int16')
GO

-- VERIFICA DI invoicedetailexpworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'invoicedetailexpworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'invoicedetailexpworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('invoicedetailexpworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA itinerationworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationworkpackageview]
GO


--select  * from itinerationworkpackageview

CREATE        VIEW [itinerationworkpackageview]
as
select 
	C.iditineration,
	C.yitineration, C.nitineration, C.description as descriptionitineration,
	'Mis.  '+ convert(varchar(4), C.yitineration) + '/' + convert(varchar(10), C.nitineration) as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 	convert(varchar(14),nitineration) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.totalgross,
	EL.idexp as idexppayed,
	isnull(EY.amount,0) AS exppayedamount,
	null as idpettycash, 
	null as yoperation, 
	null as noperation,
	null as  pettycashpayedamount,
	PC.idprogettocosto
from itineration C 
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = C.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
-- Legge il pagato con i movimenti di spesa
left outer join expenseitineration EC on EC.iditineration = C.iditineration
left outer	JOIN expenselink ELK   ON ELK.idparent = EC.idexp  and ELK.idchild <>elk.idparent
left outer JOIN expenselast EL    ON EL.idexp=ELK.idchild    
left outer JOIN expenseyear EY    ON EL.idexp=EY.idexp    
left outer join progettocosto PC
	on 'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 	convert(varchar(14),nitineration)= PC.idrelated
	and PC.idexp = EL.idexp	 
UNION all
select 
	C.iditineration,
	C.yitineration, C.nitineration, C.description as descriptionitineration,
	'Mis.  '+ convert(varchar(4), C.yitineration) + '/' + convert(varchar(10), C.nitineration) as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 	convert(varchar(14),nitineration) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.totalgross,
	NULL as idexppayed,
	NULL AS exppayedamount,
	PCO.idpettycash, PCO.yoperation, PCO.noperation,
	isnull(PO.amount,0)  as pettycashpayedamount,
	PC.idprogettocosto
from itineration C 
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = C.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
--- Legge il pagato con la piccola spesa
LEFT OUTER join  pettycashoperationitineration PCO ON PCO.iditineration = C.iditineration
left outer JOIN pettycashoperation PO ON PCO.idpettycash = PO.idpettycash AND PCO.yoperation = PO.yoperation AND PCO.noperation = PO.noperation    
left outer join progettocosto PC
	on 'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 	convert(varchar(14),nitineration)= PC.idrelated
	and PCO.idpettycash = PC.idpettycash AND PCO.yoperation = PC.yoperation AND PCO.noperation = PC.noperation    	 

GO

-- VERIFICA DI itinerationworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'itinerationworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','adate','3','''assistenza''','date','itinerationworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','descriptionitineration','150','''assistenza''','varchar(150)','itinerationworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','itinerationworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','21','''assistenza''','varchar(21)','itinerationworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','docdate','3','''assistenza''','date','itinerationworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','exppayedamount','9','''assistenza''','decimal(19,2)','itinerationworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexppayed','4','''assistenza''','int','itinerationworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','iditineration','4','''assistenza''','int','itinerationworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idpettycash','4','''assistenza''','int','itinerationworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','itinerationworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','itinerationworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','itinerationworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','itinerationworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','31','''assistenza''','varchar(31)','itinerationworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza''','varchar(36)','itinerationworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','itinerationworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','nitineration','4','''assistenza''','int','itinerationworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','noperation','4','''assistenza''','int','itinerationworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','pettycashpayedamount','9','''assistenza''','decimal(19,2)','itinerationworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','2048','''assistenza''','nvarchar(2048)','itinerationworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','start','3','''assistenza''','date','itinerationworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','stop','3','''assistenza''','date','itinerationworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','itinerationworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','totalgross','9','''assistenza''','decimal(19,2)','itinerationworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','yitineration','2','''assistenza''','smallint','itinerationworkpackageview','','','','','N','N','smallint','assistenza','System.Int16')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','yoperation','2','''assistenza''','smallint','itinerationworkpackageview','','','','','S','N','smallint','assistenza','System.Int16')
GO

-- VERIFICA DI itinerationworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'itinerationworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'itinerationworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('itinerationworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA payrollworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[payrollworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payrollworkpackageview]
GO

-- select  * from payrollworkpackageview
CREATE        VIEW [payrollworkpackageview]
as
select 
C.idpayroll,
	CC.ycon, CC.ncon,
	CC.duty as description,
	'Cedolino ' + convert(varchar(4), C.fiscalyear) + '/' + convert(varchar(10), C.npayroll) +
	' contr.' +	convert(varchar(4), CC.ycon) + '/' + convert(varchar(10), CC.ncon) 	 as doc,
	disbursementdate as docdate,
	C.start, C.stop,
	C.idupb,
	'payroll' + '§' + convert(varchar(5),C.idpayroll) + '§'  + 	convert(varchar(4),C.fiscalyear) + '§'  + convert(varchar(14),C.npayroll) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.feegross,
	EL.idexp as idexppayed,
	-- Legge il pagato
	isnull(EY.amount,0) + 
		+
	   ISNULL((SELECT SUM(V1.amount)     FROM expensepayroll EC1     
	   JOIN expenselink ELK1 ON ELK.idparent = EC1.idexp    
	   JOIN expenselast EL1       ON EL.idexp=ELK.idchild    
	   JOIN expensevar V1  ON V1.idexp = EL.idexp    
	   WHERE (ISNULL(v1.autokind,0)<> 4)  and EL1.idexp = EL.idexp
		),0) 
	AS exppayedamount,
	PC.idprogettocosto
from payroll C 
join parasubcontract CC ON C.idcon = CC.idcon and C.flagbalance='N'
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = CC.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
--Va in LEFT per mostrare anche il compenso non ancora pagato
left outer join expensepayroll EC on EC.idpayroll= C.idpayroll
left outer	JOIN expenselink ELK   ON ELK.idparent = EC.idexp  and ELK.idchild <>elk.idparent
left outer JOIN expenselast EL    ON EL.idexp=ELK.idchild    
left outer JOIN expenseyear EY    ON EL.idexp=EY.idexp    
left outer join progettocosto PC
	on 'payroll' + '§' + convert(varchar(5),C.idpayroll) + '§'  + 	convert(varchar(4),C.fiscalyear) + '§'  + convert(varchar(14),C.npayroll) = PC.idrelated
	and PC.idexp = EL.idexp

	


GO

-- VERIFICA DI payrollworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'payrollworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','description','150','''assistenza''','varchar(150)','payrollworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','payrollworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','46','''assistenza''','varchar(46)','payrollworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','docdate','3','''assistenza''','date','payrollworkpackageview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','exppayedamount','17','''assistenza''','decimal(38,2)','payrollworkpackageview','','38','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','feegross','9','''assistenza''','decimal(19,2)','payrollworkpackageview','','19','','2','N','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexppayed','4','''assistenza''','int','payrollworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idpayroll','4','''assistenza''','int','payrollworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','payrollworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','payrollworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','payrollworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','payrollworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','33','''assistenza''','varchar(33)','payrollworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','38','''assistenza''','varchar(38)','payrollworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','payrollworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ncon','20','''assistenza''','varchar(20)','payrollworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','2048','''assistenza''','nvarchar(2048)','payrollworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','start','3','''assistenza''','date','payrollworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','stop','3','''assistenza''','date','payrollworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','payrollworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ycon','4','''assistenza''','int','payrollworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

-- VERIFICA DI payrollworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'payrollworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'payrollworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('payrollworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA rendicontattivitaprogettoworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettoworkpackageview]
GO


CREATE        VIEW [rendicontattivitaprogettoworkpackageview]
as
select	
		RA.idreg, 
		RA.idworkpackage, 
		RA.idprogetto,
		PTC.idprogettotipocosto,
		null as amount,
		PC.idprogettocosto,
		RA.idrendicontattivitaprogetto,
		RDETT.idrendicontattivitaprogettoora,
		RDETT.data,--data in cui ha lavorato
		isnull(sum(RDETT.ore),0) as ore,-- ore lavorate
		CO.idcontrattokind, --tipo del contratto corrente
		CO.idcontratto, --tipo del contratto corrente
		RA.description,
		--configurazione
		PK.oredivisionecostostipendio,
		isnull(PK.stipendioannoprec, 'N') as stipendioannoprec,
		--progetto
		PUM.costoorario,
		--stipendio
		--CE.totale as totale_cedolino,
		--SA.totale as totale_stipendioannuo,
		CASE WHEN isnull(PK.stipendioannoprec, 'N') = 'S' 
			THEN isnull(SA.totale,0) / isnull(PK.oredivisionecostostipendio,1)
			ELSE isnull(CE.totale,0) / (isnull(PK.oredivisionecostostipendio,12) /12) END as costoorario_stipendio,
		--inquadramento
		--I.costolordoannuooneri as totale_inquadramento,
		isnull(I.costolordoannuooneri,0) / isnull(PK.oredivisionecostostipendio,1) as costoorario_inquadramento,
		--tipologia di contratto
		--CK.costolordoannuooneri as totale_contrattokind,
		isnull(CK.costolordoannuooneri,0) / isnull(PK.oredivisionecostostipendio,1) as costoorario_contrattokind

from rendicontattivitaprogetto RA
JOIN rendicontattivitaprogettoora RDETT on RA.idrendicontattivitaprogetto =RDETT.idrendicontattivitaprogetto
join (	select rapo.idrendicontattivitaprogettoora, ( select top 1 C.idcontratto from contratto C  where C.idreg = rap.idreg
			and rapo.data between C.start and  isnull(C.stop,{d '2079-01-01'})
			order by C.start desc) as idcontratto
		from rendicontattivitaprogettoora rapo 
		inner join rendicontattivitaprogetto rap on rap.idrendicontattivitaprogetto = rapo.idrendicontattivitaprogetto)   
		contrattovigente on contrattovigente.idrendicontattivitaprogettoora = RDETT.idrendicontattivitaprogettoora
left outer join contratto CO on CO.idcontratto = contrattovigente.idcontratto
left outer join cedolino CE on CE.idcontratto = CO.idcontratto AND CE.year = YEAR(RDETT.data) and CE.idmese = MONTH(RDETT.data) 
left outer join stipendioannuo SA on SA.idcontratto = CO.idcontratto AND SA.year = YEAR(RDETT.data)  
left outer join inquadramento I on I.idinquadramento = CO.idinquadramento
inner join contrattokind CK on CK.idcontrattokind = CO.idcontrattokind
--join registry_docenti R on RA.idreg = R.idreg --> DOCENTI
join progettotipocostocontrattokind PTC on PTC.idcontrattokind = CO.idcontrattokind and PTC.idprogetto = RA.idprogetto
join progetto P on P.idprogetto = RA.idprogetto
join progettokind PK on P.idprogettokind = PK.idprogettokind
join progettoudrmembro PUM on PUM.idprogetto = P.idprogetto and PUM.idreg = RA.idreg
left outer join progettocosto PC on PC.idrendicontattivitaprogetto = RA.idrendicontattivitaprogetto and PTC.idprogettotipocosto = PC.idprogettotipocosto
group by RA.idreg, RA.idworkpackage,RA.idprogetto, PTC.idprogettotipocosto, PC.idprogettocosto,	RA.idrendicontattivitaprogetto,	RDETT.idrendicontattivitaprogettoora, RDETT.data,
		CO.idcontrattokind,CO.idcontratto, RA.description,  PUM.costoorario, I.costolordoannuooneri, CK.costolordoannuooneri, PK.oredivisionecostostipendio, PK.stipendioannoprec,CE.totale, SA.totale

GO

-- VERIFICA DI rendicontattivitaprogettoworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettoworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','amount','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','data','3','''assistenza''','date','rendicontattivitaprogettoworkpackageview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','description','-1','''assistenza''','varchar(max)','rendicontattivitaprogettoworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idcontrattokind','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idreg','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idrendicontattivitaprogetto','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idrendicontattivitaprogettoora','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ore','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','oredivisionecostostipendio','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','stipendioannoprec','-1','''assistenza''','char(1)','rendicontattivitaprogettoworkpackageview','','','','','S','N','char','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','costoorario','10','''assistenza''','decimal','rendicontattivitaprogettoworkpackageview','','','','','S','N','decimal','assistenza','Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','costoorario_stipendio','10','''assistenza''','decimal','rendicontattivitaprogettoworkpackageview','','','','','S','N','decimal','assistenza','Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','costoorario_inquadramento','10','''assistenza''','decimal','rendicontattivitaprogettoworkpackageview','','','','','S','N','decimal','assistenza','Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','costoorario_contrattokind','10','''assistenza''','decimal','rendicontattivitaprogettoworkpackageview','','','','','S','N','decimal','assistenza','Decimal')
GO

-- VERIFICA DI rendicontattivitaprogettoworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettoworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettoworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettoworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA rendicontattivitaprogettoworkpackagericavoview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoworkpackagericavoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettoworkpackagericavoview]
GO


CREATE        VIEW [rendicontattivitaprogettoworkpackagericavoview]
as
select	
		RA.idreg, 
		RA.idworkpackage, 
		RA.idprogetto,
		PTC.idprogettotipocosto,
		null as amount,
		PC.idprogettoricavo,
		RA.idrendicontattivitaprogetto,
		RDETT.idrendicontattivitaprogettoora,
		RDETT.data,--data in cui ha lavorato
		isnull(sum(RDETT.ore),0) as ore,-- ore lavorate
		CO.idcontrattokind, --tipo del contratto corrente
		CO.idcontratto, -- contratto corrente
		RA.description,
		--configurazione
		PK.oredivisionecostostipendio,
		isnull(PK.stipendioannoprec, 'N') as stipendioannoprec,
		PK.stipendiocomericavo,
		--progetto
		PUM.ricavoorario,
		--stipendio
		--CE.totale as totale_cedolino,
		--SA.totale as totale_stipendioannuo,
		CASE WHEN PK.stipendiocomericavo = 'S' THEN
			CASE WHEN isnull(PK.stipendioannoprec, 'N') = 'S' 
				THEN isnull(SA.totale,0) / isnull(PK.oredivisionecostostipendio,1)
				ELSE isnull(CE.totale,0) / (isnull(PK.oredivisionecostostipendio,12) /12) END 
		ELSE 0 END as costoorario_stipendio,
		--inquadramento
		--I.costolordoannuooneri as totale_inquadramento,
		CASE WHEN PK.stipendiocomericavo = 'S' THEN
		isnull(I.costolordoannuooneri,0) / isnull(PK.oredivisionecostostipendio,1) 
		ELSE 0 END  as costoorario_inquadramento,
		--tipologia di contratto
		--CK.costolordoannuooneri as totale_contrattokind,
		CASE WHEN PK.stipendiocomericavo = 'S' THEN
		isnull(CK.costolordoannuooneri,0) / isnull(PK.oredivisionecostostipendio,1) 
		ELSE 0 END  as costoorario_contrattokind

from rendicontattivitaprogetto RA
JOIN rendicontattivitaprogettoora RDETT on RA.idrendicontattivitaprogetto =RDETT.idrendicontattivitaprogetto
join (	select rapo.idrendicontattivitaprogettoora, ( select top 1 C.idcontratto from contratto C  where C.idreg = rap.idreg
			and rapo.data between C.start and  isnull(C.stop,{d '2079-01-01'})
			order by C.start desc) as idcontratto
		from rendicontattivitaprogettoora rapo 
		inner join rendicontattivitaprogetto rap on rap.idrendicontattivitaprogetto = rapo.idrendicontattivitaprogetto)   
		contrattovigente on contrattovigente.idrendicontattivitaprogettoora = RDETT.idrendicontattivitaprogettoora
left outer join contratto CO on CO.idcontratto = contrattovigente.idcontratto
left outer join cedolino CE on CE.idcontratto = CO.idcontratto AND CE.year = YEAR(RDETT.data) and CE.idmese = MONTH(RDETT.data) 
left outer join stipendioannuo SA on SA.idcontratto = CO.idcontratto AND SA.year = YEAR(RDETT.data)  
left outer join inquadramento I on I.idinquadramento = CO.idinquadramento
inner join contrattokind CK on CK.idcontrattokind = CO.idcontrattokind
--join registry_docenti R on RA.idreg = R.idreg --> DOCENTI
join progettotiporicavocontrattokind PTC on PTC.idcontrattokind = CO.idcontrattokind and PTC.idprogetto = RA.idprogetto
join progetto P on P.idprogetto = RA.idprogetto
join progettokind PK on P.idprogettokind = PK.idprogettokind
join progettoudrmembro PUM on PUM.idprogetto = P.idprogetto and PUM.idreg = RA.idreg
left outer join progettoricavo PC on PC.idrendicontattivitaprogetto = RA.idrendicontattivitaprogetto and PTC.idprogettotipocosto = PC.idprogettotipocosto
group by RA.idreg, RA.idworkpackage,RA.idprogetto, PTC.idprogettotipocosto, PC.idprogettoricavo,	RA.idrendicontattivitaprogetto,	RDETT.idrendicontattivitaprogettoora, RDETT.data,
		CO.idcontrattokind,CO.idcontratto, RA.description,  PUM.ricavoorario, I.costolordoannuooneri, CK.costolordoannuooneri, PK.oredivisionecostostipendio, PK.stipendioannoprec, PK.stipendiocomericavo, CE.totale, SA.totale

GO

-- VERIFICA DI rendicontattivitaprogettoworkpackagericavoview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettoworkpackagericavoview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','amount','4','''assistenza''','int','rendicontattivitaprogettoworkpackagericavoview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','data','3','''assistenza''','date','rendicontattivitaprogettoworkpackagericavoview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','description','-1','''assistenza''','varchar(max)','rendicontattivitaprogettoworkpackagericavoview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idcontrattokind','4','''assistenza''','int','rendicontattivitaprogettoworkpackagericavoview','','','','','S','N','int','assistenza','System.Int32')
GO


INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idcontratto','4','''assistenza''','int','rendicontattivitaprogettoworkpackagericavoview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','rendicontattivitaprogettoworkpackagericavoview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettoricavo','4','''assistenza''','int','rendicontattivitaprogettoworkpackagericavoview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','rendicontattivitaprogettoworkpackagericavoview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idreg','4','''assistenza''','int','rendicontattivitaprogettoworkpackagericavoview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idrendicontattivitaprogetto','4','''assistenza''','int','rendicontattivitaprogettoworkpackagericavoview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idrendicontattivitaprogettoora','4','''assistenza''','int','rendicontattivitaprogettoworkpackagericavoview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','rendicontattivitaprogettoworkpackagericavoview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ore','4','''assistenza''','int','rendicontattivitaprogettoworkpackagericavoview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','oredivisionecostostipendio','4','''assistenza''','int','rendicontattivitaprogettoworkpackagericavoview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','stipendioannoprec','-1','''assistenza''','char(1)','rendicontattivitaprogettoworkpackagericavoview','','','','','S','N','char','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','stipendiocomericavo','-1','''assistenza''','char(1)','rendicontattivitaprogettoworkpackagericavoview','','','','','S','N','char','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','ricavoorario','10','''assistenza''','decimal','rendicontattivitaprogettoworkpackagericavoview','','','','','S','N','decimal','assistenza','Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','costoorario_stipendio','10','''assistenza''','decimal','rendicontattivitaprogettoworkpackagericavoview','','','','','S','N','decimal','assistenza','Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','costoorario_inquadramento','10','''assistenza''','decimal','rendicontattivitaprogettoworkpackagericavoview','','','','','S','N','decimal','assistenza','Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','costoorario_contrattokind','10','''assistenza''','decimal','rendicontattivitaprogettoworkpackagericavoview','','','','','S','N','decimal','assistenza','Decimal')
GO

-- VERIFICA DI rendicontattivitaprogettoworkpackagericavoview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettoworkpackagericavoview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettoworkpackagericavoview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettoworkpackagericavoview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA taxworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[taxworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [taxworkpackageview]
GO



CREATE        VIEW [taxworkpackageview]
as
select 
	T.taxcode, 
	expense.ymov,
	T.description as tax,
	expensetax.competencydate,
	expenseyear.idupb,
	null as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PTT.idprogettotipocosto as idprogettotipocosto,
	EL.idexp as idexppayed,
	expensetax.admintax,
	PC.idprogettocosto,
	null AS exppayedamount
from tax T 
JOIN progettotipocostotax PTT 	
	on T.taxcode = PTT.taxcode 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PTT.idprogetto   and  PTC.idprogettotipocosto = PTT.idprogettotipocosto
JOIN progetto P 
	on PTT.idprogetto = P.idprogetto

join expensetax  	ON T.taxcode = expensetax.taxcode
JOIN expense 	ON expensetax.idexp = expense.idexp
JOIN expenselast EL	ON expense.idexp = EL.idexp 
join expenseyear on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = expenseyear.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
left outer join progettocosto PC
	on expensetax.idexp = PC.idexp


GO

-- VERIFICA DI taxworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'taxworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','admintax','9','''assistenza''','decimal(19,2)','taxworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','competencydate','3','''assistenza''','date','taxworkpackageview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','taxworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idexppayed','4','''assistenza''','int','taxworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','taxworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','taxworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','taxworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','taxworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','4','''assistenza''','int','taxworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza''','varchar(36)','taxworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','taxworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','2048','''assistenza''','nvarchar(2048)','taxworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','tax','50','''assistenza''','varchar(50)','taxworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','taxcode','4','''assistenza''','int','taxworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','taxworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ymov','2','''assistenza''','smallint','taxworkpackageview','','','','','N','N','smallint','assistenza','System.Int16')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','exppayedamount','9','''assistenza''','decimal(19,2)','taxworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO


-- VERIFICA DI taxworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'taxworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'taxworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('taxworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA wageadditionworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[wageadditionworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [wageadditionworkpackageview]
GO



CREATE        VIEW [wageadditionworkpackageview]
as
select 
	C.ycon, C.ncon, C.description as descriptionwageaddition,
	'Altri Compensi '+ convert(varchar(4), C.ycon) + '/' + convert(varchar(10), C.ncon) as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'wageadd' + '§' + convert(varchar(4), C.ycon) + '§'  +  convert(varchar(14), C.ncon) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.feegross,
	EL.idexp as idexppayed,
	-- Legge il pagato
	isnull(EY.amount,0) + 
		+
	   ISNULL((SELECT SUM(V1.amount)     FROM expensewageaddition EC1     
	   JOIN expenselink ELK1 ON ELK.idparent = EC1.idexp    
	   JOIN expenselast EL1       ON EL.idexp=ELK.idchild    
	   JOIN expensevar V1  ON V1.idexp = EL.idexp    
	   WHERE (ISNULL(v1.autokind,0)<> 4)  and EL1.idexp = EL.idexp
		),0) 
	AS exppayedamount,
	PC.idprogettocosto
from wageaddition C 
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = C.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
--Va in LEFT per mostrare anche il compenso non ancora pagato
left outer join expensewageaddition EC on EC.ncon= C.ncon AND EC.ycon=C.ycon
left outer	JOIN expenselink ELK   ON ELK.idparent = EC.idexp  and ELK.idchild <>elk.idparent
left outer JOIN expenselast EL    ON EL.idexp=ELK.idchild    
left outer JOIN expenseyear EY    ON EL.idexp=EY.idexp    
left outer join progettocosto PC
	on 'wageadd' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) = PC.idrelated
	and PC.idexp = EL.idexp




GO

-- VERIFICA DI wageadditionworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'wageadditionworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','adate','3','''assistenza''','date','wageadditionworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','descriptionwageaddition','150','''assistenza''','varchar(150)','wageadditionworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','wageadditionworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','30','''assistenza''','varchar(30)','wageadditionworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','docdate','3','''assistenza''','date','wageadditionworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','exppayedamount','17','''assistenza''','decimal(38,2)','wageadditionworkpackageview','','38','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','feegross','9','''assistenza''','decimal(19,2)','wageadditionworkpackageview','','19','','2','N','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexppayed','4','''assistenza''','int','wageadditionworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','wageadditionworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','wageadditionworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','wageadditionworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','wageadditionworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','27','''assistenza''','varchar(27)','wageadditionworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza''','varchar(36)','wageadditionworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','wageadditionworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ncon','4','''assistenza''','int','wageadditionworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','2048','''assistenza''','nvarchar(2048)','wageadditionworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','start','3','''assistenza''','date','wageadditionworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','stop','3','''assistenza''','date','wageadditionworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','wageadditionworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ycon','4','''assistenza''','int','wageadditionworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

-- VERIFICA DI wageadditionworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'wageadditionworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'wageadditionworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('wageadditionworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getoremaxgg]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getoremaxgg]
GO

CREATE VIEW [dbo].[getoremaxgg]
AS
SELECT        dbo.contratto.idreg, dbo.contratto.start, dbo.contratto.stop, dbo.contrattokind.oremaxgg, dbo.contrattokind.title
FROM            dbo.contratto INNER JOIN
                         dbo.contrattokind ON dbo.contratto.idcontrattokind = dbo.contrattokind.idcontrattokind
GO



