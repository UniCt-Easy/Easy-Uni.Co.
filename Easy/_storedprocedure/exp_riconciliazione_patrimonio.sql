
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


--setuser'amministrazione' 
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_riconciliazione_patrimonio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_riconciliazione_patrimonio]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


create PROCEDURE [exp_riconciliazione_patrimonio]
(
	@yentry int -- esercizio delle scritture da verificare

)
AS BEGIN

--declare @yentry int
--set @yentry = 2023
--select dateadd(yy, @yentry-2000, {d '2000-01-01'}) 
--select dateadd(yy, @yentry-2000, {d '2000-12-31'})



CREATE  TABLE #carichi(
	number int, 
	codeinv VARCHAR (50), 
	invtree VARCHAR (150),
	idinvkind int, 
	yinv smallint, 
	ninv int , 
	invrownum int 
)
insert into #carichi(number, codeinv , invtree ,idinvkind, yinv , ninv , invrownum  )
select sum(number) as number, max(inventorytree.codeinv) as codeinv, max(inventorytree.description) as invtree,
					assetacquire.idinvkind, assetacquire.yinv, assetacquire.ninv, assetacquire.invrownum 
FROM assetacquire  (NOLOCK)
join inventorytree on assetacquire.idinv = inventorytree.idinv
JOIN assetload		(nolock)				ON assetload.idassetload = assetacquire.idassetload
where assetload.ratificationdate between dateadd(yy, @yentry-2000, {d '2000-01-01'}) and dateadd(yy, @yentry-2000, {d '2000-12-31'})

group by assetacquire.idinvkind, assetacquire.yinv, assetacquire.ninv, assetacquire.invrownum

 

select 
	--dati da scrittura in partita doppia
	ed.yentry [Esercizio scrittura], 
	ed.nentry [Num Scrittura],
	ed.ndetail [Num Dettaglio], 
	ac.codeacc [Cod Conto], 
	ac.title [Conto],
	registry.title [Anagrafica dettaglio scrittura],
	ed.idreg [Codice anagrafica scrittura],
	upb.codeupb [Cod UPB ],
	CASE
		WHEN ISNULL(amount,0) < 0 THEN -amount
		ELSE NULL
	END [Importo Dare],

--dati da documento iva
	ik.description [Tipo Fattura],
	ik.codeinvkind [Codice Tipo Fattura],
	dd.yinv [Eserc Fattura],
	dd.ninv [Num Fattura],
	invoice.adate [Data registrazione fattura],
	registryinv.title [Anagrafica dettaglio fattura],
	invoice.idreg [Codice anagrafica fattura],
	invoice.description [Descrizione Fattura],
	dd.rownum [Num riga fattura],
	dd.detaildescription [Descrizione dettagli fatt],
	ISNULL(md.npackage, md.number)  [Qtà],
	list.intcode [listino],
	case 
		when md.idmankind is not null then inventorytree.codeinv
		else carichi.codeinv 
	end [Codice Class inventariale],
	case 
		when md.idmankind is not null then inventorytree.description
		else carichi.invtree 
	end [Descrizione Class inventariale],
	CONVERT(decimal(19,2),
			ROUND(dd.taxable * CONVERT(DECIMAL(19,10),invoice.exchangerate) *
				(1 - CONVERT(DECIMAL(19,6),ISNULL(dd.discount, 0.0)))
			,2
	)) [Importo imponibile Unitario fatt],
	'% ' + convert(varchar, dd.discount * 100) [Percentuale Sconto fatt],
	CONVERT(decimal(19,2), ROUND(dd.taxable * CONVERT(DECIMAL(19,10),ISNULL(invoice.exchangerate,1)) *
				  (1 - CONVERT(DECIMAL(19,6),ISNULL(dd.discount, 0.0))),
				  2))+
		CONVERT(decimal(19,2),ROUND(ISNULL(dd.tax,0),2)) [Importo costo Unitario (comprensivo di iva indetraibile) fatt],
	CONVERT(decimal(19,2),
			ROUND(dd.taxable * ISNULL(dd.npackage,dd.number) * CONVERT(DECIMAL(19,10),invoice.exchangerate) *
				(1 - CONVERT(DECIMAL(19,6),ISNULL(dd.discount, 0.0)))
			,2
	)) [Imponibile totale fatt],
	CONVERT(decimal(19,2), ROUND(dd.taxable * ISNULL(dd.npackage,dd.number) * CONVERT(DECIMAL(19,10),ISNULL(invoice.exchangerate,1)) *
				  (1 - CONVERT(DECIMAL(19,6),ISNULL(dd.discount, 0.0))),
				  2))+
		CONVERT(decimal(19,2),ROUND(ISNULL(dd.tax,0),2)) [Importo costo tot (comprensivo di iva indet) fatt],
	ivakind.description [Tipo IVA dettagli fatt],
	ivakind.rate [Aliquota Iva fatt],
	dd.tax [Iva dettagli fatt],
	isnull(dd.tax,0) - isnull(dd.unabatable,0) [Iva Detraibile unitaria fatt],
	--dd.rowtotal [Totale riga dettagli fatt],

	case 
		when carichi.idinvkind is not null then isnull(carichi.number, 0)
		else ma.loaded 
	end [Quantità inventariata Fatt], 

	case 
		when carichi.idinvkind is not null  then isnull(dd.taxable, 0)
		else 0 
	end [Importo Inventariato Fatt],

	case 
		when carichi.idinvkind is not null then  dd.number - isnull(carichi.number, 0) 
		else ma.residual 
	end [Quantità da inventariare Fatt],
	-- da contratto passivo
	md.idmankind [Codice Tipo contratto passivo],
	mk.description [Descrizione Tipo contratto passivo],
	md.nman [Ncontratto passivo],
	md.yman [Esercizio contratto passivo],
	md.rownum [N dettaglio contratto passivo],
	manager.title [Responsabile contratto passivo],
	listmd.intcode [listino pass],
	inventorytree.codeinv [Codice Class inventariale pass],
	inventorytree.description [Descrizione Class inventariale],
	md.detaildescription [Descrizione dettaglio contr pass],
	md.taxable [Importo Unitario dettagli contr pass],
	ivakindmd.description [Tipo IVA dettagli contr pass],
	md.tax [Iva dettagli contratt pass],
	ROUND(md.taxable * ISNULL(md.npackage,md.number) * 
			  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
			  (1 - CONVERT(DECIMAL(19,6),ISNULL(md.discount, 0.0))),2
			)+
		ROUND(md.tax,2) [Totale riga dettagli contr pass],
	ma.residual [Qtà da inventariare contr pass],
	ma.loaded [Qtà inventariata contr pass],
	CASE   
		WHEN (ma.loaded > 0)  THEN isnull(ma.taxable, 0) 
		ELSE 0
	END  [Importo inventariato contr pass],
		ISNULL(
		(SELECT SUM(iv.npackage)
		  FROM (SELECT DISTINCT 
						  invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv,
						  invoicedetail.idgroup as invidgroup,
						  isnull(invoicedetail.npackage,invoicedetail.number) as npackage
			FROM invoicedetail (NOLOCK)
 				WHERE	 invoicedetail.idmankind = md.idmankind AND
						 invoicedetail.yman = md.yman AND
						 invoicedetail.nman = md.nman AND
						 invoicedetail.manrownum = md.rownum 	
				) AS iv )  ,0) [Qtà fatturata],
		ISNULL(md.npackage, md.number) 
		- 
		ISNULL(
		(SELECT SUM(iv.npackage)
		  FROM (SELECT DISTINCT 
						  invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv,
						  invoicedetail.idgroup as invidgroup,
						  isnull(invoicedetail.npackage,invoicedetail.number) as npackage
			FROM invoicedetail  (NOLOCK)
 
				WHERE	 invoicedetail.idmankind = md.idmankind AND
						 invoicedetail.yman = md.yman AND
						 invoicedetail.nman = md.nman AND
						 invoicedetail.manrownum = md.rownum 	
				) AS iv )  ,0)   [Qtà da fatturare],
	location.locationcode [Codice Ubicazione],
	location.description [Descrizione ubicazione],
	case when md.assetkind = 'A' then 'Inventariabile'
		when md.assetkind = 'P' then 'Aumento di Valore'
		when md.assetkind = 'S' then 'Servizi'
		when md.assetkind = 'M' then 'Magazzino'
		when md.assetkind = 'O' then 'Altro'
		else '' end [Tipo bene (assetkind)],
	case when isnull(md.epkind, '') = 'F' then 'S' else 'N' end [Fattura da Ricevere],
	md.cu [cu],
	S01.sortcode + ' ' +   S01.description as [Attributo 1],
	md.ivanotes [ivanotes],
	md.lu [lu] 

from entrydetail ed   (NOLOCK)
JOIN entry e   (NOLOCK)
		ON ed.yentry = e.yentry AND ed.nentry = e.nentry  and   e.yentry = @yentry 
JOIN account ac on ac.idacc = ed.idacc  AND ac.idaccountkind = '0005'
left outer join invoicedetail dd    (NOLOCK) on ed.idrelated = ('inv§'+ convert(varchar(10),dd.idinvkind) + '§'+ convert(varchar(10),dd.yinv) + '§'+ convert(varchar(10),dd.ninv) + '§'+ convert(varchar(10),dd.rownum))
JOIN invoice 	   (NOLOCK)	ON invoice.ninv = dd.ninv	AND invoice.yinv = dd.yinv	AND invoice.idinvkind = dd.idinvkind
JOIN ivakind 		ON ivakind.idivakind = dd.idivakind
JOIN invoicekind ik 	ON ik.idinvkind = dd.idinvkind
JOIN registry   registryinv	  (NOLOCK)	ON registryinv.idreg = invoice.idreg
LEFT OUTER JOIN list  	ON list.idlist = dd.idlist
--JOIN invoicedetailavailable ia on ia.idinvkind = dd.idivakind and ia.yinv = dd.yinv and ia.ninv = dd.ninv and ia.invidgroup = dd.idgroup

LEFT OUTER JOIN mandatedetail  md  (NOLOCK) on dd.idmankind = md.idmankind and dd.yman = md.yman and dd.nman = md.nman and dd.manrownum = md.rownum
JOIN mandatekind mk				ON mk.idmankind = md.idmankind
JOIN mandate   (NOLOCK)		ON mandate.yman = md.yman	AND mandate.nman = md.nman	AND mandate.idmankind = md.idmankind
join mandatedetailavailable ma on ma.idmankind = md.idmankind and ma.yman = md.yman and ma.nman = md.nman and ma.idgroup = md.idgroup
LEFT OUTER JOIN registry   (NOLOCK)	ON ed.idreg = registry.idreg
LEFT OUTER JOIN upb		  (NOLOCK)	ON ed.idupb = upb.idupb

LEFT OUTER JOIN manager 		ON manager.idman = mandate.idman
LEFT OUTER JOIN inventorytree 	ON inventorytree.idinv = md.idinv

LEFT OUTER JOIN ivakind ivakindmd	ON ivakindmd.idivakind = md.idivakind
LEFT OUTER JOIN list listmd			ON listmd.idlist = md.idlist 
LEFT OUTER JOIN location   		ON location.idlocation=md.idlocation

LEFT OUTER JOIN #carichi as carichi 	on dd.idinvkind = carichi.idinvkind	AND dd.yinv = carichi.yinv	AND dd.ninv = carichi.ninv	AND dd.idgroup = carichi.invrownum
LEFT OUTER JOIN sorting S01				ON mandate.idsor01 = S01.idsor

where
 ed.idrelated like 'inv%'
 and 
--ed.yentry = @yentry
--and ed.idepexp is not null 
--AND ac.idaccountkind = '0005'
--AND 
not exists (select * from invoicedetail 
	where invoicedetail.ninv_main = dd.ninv
	and invoicedetail.yinv_main = dd.yinv
	and invoicedetail.idinvkind_main = dd.idinvkind
	--and invoicedetail.rownum_main = dd.rownum -- non è necessario interrogare il numero righe se dobbiamo escludere le fatture associate a NC
	)

ORDER BY 1 ,2 ,3


END

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

