
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


-- [WEBSRV06\IMPORT].[Importazioni_140114].[dbo] --> Unina2
-- select * from [AULAINFORMATICA\TEST].[Importazioni_09012014].[dbo].FATTURA F  --> cassino
setuser

GO
IF  EXISTS(select * from sysobjects where id = object_id(N'[FATTURECIA]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE FATTURECIA
END
GO

DECLARE	@bilancio varchar(120) 
--SET @bilancio = 'A.00000' -- unisob
SET @bilancio = 'A.AMMCE' -- unina2


SELECT 
	F.numero_fattura,
	case when F.TIPO_FATTURA='C' and numero_fattura_collegata is null then  'ACQUISTI_COMM'
		 when F.TIPO_FATTURA='C' and numero_fattura_collegata is not null then  'NC su ACQUISTI_COMM'

		 when F.TIPO_FATTURA='I' and numero_fattura_collegata is null then  'ACQUISTI_IST'
		 when F.TIPO_FATTURA='I' and numero_fattura_collegata is not null then  'NC su ACQUISTI_IST'

		 when F.TIPO_FATTURA='P' and numero_fattura_collegata is null then  'ACQUISTI_PROM'
		 when F.TIPO_FATTURA='P' and numero_fattura_collegata is not null then  'NC su ACQUISTI_PROM'
	End as 'codtipofattura',		
	F.esercizio as 'annofattura',
	substring(F.numero_fattura,2,5) as 'numfattura',
	D.numero_dettaglio_f as 'nriga_fatt',
	case when F.nota_credito_debito ='F' then 'N'
		else 'S'
	end as 'notacredito',
	case
		when F.TIPO_FATTURA='C' and numero_fattura_collegata is null then  'ACQUISTI_COMM'
		when F.TIPO_FATTURA='I' and numero_fattura_collegata is null then  'ACQUISTI_IST'
		when F.TIPO_FATTURA='P' and numero_fattura_collegata is null then  'ACQUISTI_PROM'
		else null
	End as 'codtipofatturaprinc',
	D.esercizio_f_collegata as 'annofatturaprinc',
	substring(D.numero_fattura_collegata,2,5) as 'numfatturaprinc',
    F.NUMERO_FATTURA_FORNITORE as 'doc', 
	F.DATA_registrazione as 'datafatt',
    F.DATA_fattura as 'datadoc',
	F.NUMERO_FATTURA_FORNITORE
INTO FATTURECIA
FROM [CIA_unisob_03012014].[dbo].FATTURA F 
join [CIA_unisob_03012014].[dbo].fattura_dettaglio D
	on F.bilancio = D.bilancio 
	and F.numero_fattura = D.numero_fattura
	and F.esercizio = D.esercizio
where F.bilancio = @bilancio

GO
setuser'amministrazione'
GO

update invoicedetail set ninv = (select top 1 substring(numero_fattura,2,5)  from FATTURECIA F
							join invoice I
								ON F.numero_fattura = I.doc 
								and F.annofattura = I.yinv
							where I.idinvkind = invoicedetail.idinvkind
								and I.yinv = invoicedetail.yinv
								and I.ninv = invoicedetail.ninv
								)
where  invoicedetail.yinv <2014
	and invoicedetail.idinvkind in (select idinvkind from invoicekind where (flag&1)=0)-- fatture di acquisto

update expenseinvoice set ninv = (select top 1 substring(numero_fattura,2,5)  from FATTURECIA F
							join invoice I
								ON F.numero_fattura = I.doc 
								and F.annofattura = I.yinv
							where I.idinvkind = expenseinvoice.idinvkind
								and I.yinv = expenseinvoice.yinv
								and I.ninv = expenseinvoice.ninv
								)
where  expenseinvoice.yinv<2014
	and expenseinvoice.idinvkind in (select idinvkind from invoicekind where (flag&1)=0)-- fatture di acquisto

update incomeinvoice set ninv = (select top 1 substring(numero_fattura,2,5)  from FATTURECIA F
							join invoice I
								ON F.numero_fattura = I.doc 
								and F.annofattura = I.yinv
							where I.idinvkind = incomeinvoice.idinvkind
								and I.yinv = incomeinvoice.yinv
								and I.ninv = incomeinvoice.ninv
								)
where  incomeinvoice.yinv<2014
	and incomeinvoice.idinvkind in (select idinvkind from invoicekind where (flag&1)=0)-- fatture di acquisto

UPDATE invoice SET ninv = substring(doc,2,5)  
	where invoice.yinv <2014
	and invoice.idinvkind in (select idinvkind from invoicekind where (flag&1)=0)-- fatture di acquisto

UPDATE invoice SET adate= (select top 1 isnull(F.datafatt, F.datadoc) from FATTURECIA F
						where F.numero_fattura = invoice.doc and F.annofattura = invoice.yinv)
where invoice.yinv <2014
	and invoice.idinvkind in (select idinvkind from invoicekind where (flag&1)=0)-- fatture di acquisto

UPDATE invoice SET docdate= (select top 1 F.datadoc from FATTURECIA F
							where F.numero_fattura = invoice.doc and F.annofattura = invoice.yinv)
where invoice.yinv <2014
	and invoice.idinvkind in (select idinvkind from invoicekind where (flag&1)=0)-- fatture di acquisto

UPDATE invoicedetail SET ninv_main = (select F.numfatturaprinc  from FATTURECIA F
						join invoice I
								ON F.numero_fattura = I.doc 
								and F.annofattura = I.yinv
						where I.idinvkind = invoicedetail.idinvkind
								and I.yinv = invoicedetail.yinv
								and I.ninv = invoicedetail.ninv
								AND F.nriga_fatt = invoicedetail.rownum								)
where invoicedetail.yinv <2014
	and invoicedetail.idinvkind in (select idinvkind from invoicekind where (flag&1)=0)-- fatture di acquisto

-- L'update su doc deve essere l'ultimo.
UPDATE invoice SET doc = (select top 1 F.NUMERO_FATTURA_FORNITORE  from FATTURECIA F
						where F.numero_fattura = invoice.doc and F.annofattura = invoice.yinv)
where invoice.yinv <2014
	and invoice.idinvkind in (select idinvkind from invoicekind where (flag&1)=0)-- fatture di acquisto
								
INSERT INTO [ivaregister] (idivaregisterkind,nivaregister,yivaregister,ct,cu,idinvkind,lt,lu,ninv,protocolnum,yinv) 
select R.idivaregisterkind, I.ninv, I.yinv,getdate(),'script',I.idinvkind, getdate(),'script',I.ninv,I.ninv,I.yinv
from invoicekindregisterkind R
join invoice I
	ON R.idinvkind = I.idinvkind 
where I.yinv <2014
and not exists(select * from ivaregister R2 where
			 R2.idivaregisterkind = R.idivaregisterkind 
			and R2.yivaregister = I.yinv
			and R2.nivaregister = I.ninv)
