
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_entrydetail_centri_driver]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_entrydetail_centri_driver]
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- setuser 'amministrazione'
-- exec exp_entrydetail_centri_driver 2023, NULL, NULL,NULL, NULL , NULL, NULL  

 
CREATE PROCEDURE exp_entrydetail_centri_driver
(
	@ayear int,
	@idsor1 int = null, --Centro di Costo
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
)
AS 
BEGIN

-- Scritture con idrelated delle fatture
		select 
		v.yentry as [Eserc. Scrittura],
		v.nentry as [Num. Scrittura],
		v.ndetail as [Num. Dettaglio],
		v.codeacc as [Cod. Conto],
		v.account as [Conto],
		v.patpart as [Parte Stato Patrim.],
		v.codepatrimony as [Cod. Stato Patrim.],
		v.placcpart as [Parte Conto. Econ.],
		v.codeplaccount as [Cod. Conto Econ.],
		v.registry as [Cliente/Fornitore],
		v.codeupb as [Cod. U.P.B.],
		v.upb as [U.P.B.],
		v.give as [Dare],
		v.have as [Avere],
		v.detaildescription as [Descrizione dettaglio],
		v.description as [Descrizione Scrittura],
		v.codemotive as [Cod. Causale],
		v.accmotive as [Causale],
		v.competencystart as [Inizio competenza],
		v.competencystop as [Fine competenza],
		v.nepexp as [Numero Impegno di Budget],
		v.yepexp as [Anno Impegno di Budget],
		v.nepacc as [Numero Accertamento di Budget],
		v.yepacc as [Anno Accertamento di Budget],
		v.adate as [Data contabile],
		v.amount as [Importo],
		v.doc as [Documento],
		v.docdate as [Data Documento],
		v.official as [Ufficiale],
		s.sortcode as [Cod. Centro di Costo],
		s.start as [Inizio Validità Centro di Costo],
		s.stop as [Fine Validità Centro di Costo],
		case 
			when s.idsor is null then null
			when exists (select * from sorting where paridsor = s.idsor) then 'N'
			else 'S' 
		end as [Ultimo Livello Centro di Costo],
		s2.sortcode as [Obiettivo Piano Integrato],
		d.costpartitioncode [Driver di ripartizione],
		d.active as [Driver Attivo]
		--v.idrelateddetail ,
		--'inv§'+convert(varchar(10),i.idinvkind)+'§'+convert(varchar(10),i.yinv)+'§'+convert(varchar(10),i.ninv)+'§'+convert(varchar(10),i.rownum)
		from entrydetailview v
		left outer join sorting s on v.idsor1 = s.idsor
		left outer join sorting s2 on v.idsor2 = s2.idsor
		left outer join invoicedetail i on v.idrelateddetail = 'inv§'+convert(varchar(10),i.idinvkind)+'§'+convert(varchar(10),i.yinv)+'§'+convert(varchar(10),i.ninv)+'§'+convert(varchar(10),i.rownum)
		left outer join costpartition d on i.idcostpartition = d.idcostpartition
		-- conti di costo o di ricavo
		join account a on a.idacc = v.idacc and ((a.flagaccountusage & 64)<>0 or (a.flagaccountusage & 128)<>0) and a.ayear = @ayear
		where v.yentry = @ayear and v.idrelateddetail is not null and v.idrelateddetail like 'inv%'
		AND (@idsor01 IS NULL OR v.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR v.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR v.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR v.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR v.idsor05 = @idsor05)
		--AND (@costpartition IS NULL OR i.idcostpartition = @costpartition) -- Driver di Ripartizione
		AND (@idsor1 IS NULL OR v.idsor1 = @idsor1)  -- Centro di Costo

		UNION
		-- Scritture di fatture con idrelated dei contratti passivi nei dettagli
		select 
		v.yentry as [Eserc. Scrittura],
		v.nentry as [Num. Scrittura],
		v.ndetail as [Num. Dettaglio],
		v.codeacc as [Cod. Conto],
		v.account as [Conto],
		v.patpart as [Parte Stato Patrim.],
		v.codepatrimony as [Cod. Stato Patrim.],
		v.placcpart as [Parte Conto. Econ.],
		v.codeplaccount as [Cod. Conto Econ.],
		v.registry as [Cliente/Fornitore],
		v.codeupb as [Cod. U.P.B.],
		v.upb as [U.P.B.],
		v.give as [Dare],
		v.have as [Avere],
		v.detaildescription as [Descrizione dettaglio],
		v.description as [Descrizione Scrittura],
		v.codemotive as [Cod. Causale],
		v.accmotive as [Causale],
		v.competencystart as [Inizio competenza],
		v.competencystop as [Fine competenza],
		v.nepexp as [Numero Impegno di Budget],
		v.yepexp as [Anno Impegno di Budget],
		v.nepacc as [Numero Accertamento di Budget],
		v.yepacc as [Anno Accertamento di Budget],
		v.adate as [Data contabile],
		v.amount as [Importo],
		v.doc as [Documento],
		v.docdate as [Data Documento],
		v.official as [Ufficiale],
		s.sortcode as [Cod. Centro di Costo],
		s.start as [Inizio Validità Centro di Costo],
		s.stop as [Fine Validità Centro di Costo],
		case 
			when s.idsor is null then null
			when exists (select * from sorting where paridsor = s.idsor) then 'N'
			else 'S' 
		end as [Ultimo Livello Centro di Costo],
		s2.sortcode as [Obiettivo Piano Integrato],
		CASE WHEN d.idcostpartition  IS NOT NULL THEN  d.costpartitioncode --- prendo il driver dal dettaglio contratto passivo
		     ELSE /*prendo il driver dal dettaglio fattura*/
		    (select top 1 di.costpartitioncode from invoicedetail id   left outer join costpartition di on id.idcostpartition = di.idcostpartition 
				   WHERE  id.idmankind = i.idmankind and id.manrownum = i.rownum and id.yman = i.yman and id.nman = i.nman  and di.idcostpartition  is not null) 
		END  AS [Driver di ripartizione],
		CASE WHEN d.idcostpartition is not null then d.active 
			ELSE 
			(select top 1 di.active from invoicedetail id left outer join costpartition di on id.idcostpartition = di.idcostpartition
					where id.idmankind = i.idmankind and id.manrownum = i.rownum and id.yman = i.yman and id.nman = i.nman and di.idcostpartition is not null)
		END as [Driver Attivo]
		--v.idrelateddetail ,
		--'man§'+convert(varchar(10),i.idmankind)+'§'+convert(varchar(10),i.yman)+'§'+convert(varchar(10),i.nman)+'§'+convert(varchar(10),i.idgroup)
		from entrydetailview v
		left outer join sorting s on v.idsor1 = s.idsor
		left outer join sorting s2 on v.idsor2 = s2.idsor
		left outer join mandatedetail i on v.idrelateddetail = 'man§'+convert(varchar(10),i.idmankind)+'§'+convert(varchar(10),i.yman)+'§'+convert(varchar(10),i.nman)+'§'+convert(varchar(10),i.idgroup)
     	left outer join costpartition d on i.idcostpartition = d.idcostpartition  --- centro di costo dettaglio contratto passivo
		-- conti di costo o di ricavo
		join account a on a.idacc = v.idacc and ((a.flagaccountusage & 64)<>0 or (a.flagaccountusage & 128)<>0) and a.ayear = @ayear
		where v.yentry = @ayear and v.idrelateddetail is not null and v.idrelateddetail like 'man%' and v.idrelated  like 'inv%'
		AND (@idsor01 IS NULL OR v.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR v.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR v.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR v.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR v.idsor05 = @idsor05)
		--AND (@costpartition IS NULL OR i.idcostpartition = @costpartition) -- Driver di Ripartizione
		AND (@idsor1 IS NULL OR v.idsor1 = @idsor1)  -- Centro di Costo

		UNION
		-- Scritture di contratti passivi con idrelated dei contratti passivi
		select 
		v.yentry as [Eserc. Scrittura],
		v.nentry as [Num. Scrittura],
		v.ndetail as [Num. Dettaglio],
		v.codeacc as [Cod. Conto],
		v.account as [Conto],
		v.patpart as [Parte Stato Patrim.],
		v.codepatrimony as [Cod. Stato Patrim.],
		v.placcpart as [Parte Conto. Econ.],
		v.codeplaccount as [Cod. Conto Econ.],
		v.registry as [Cliente/Fornitore],
		v.codeupb as [Cod. U.P.B.],
		v.upb as [U.P.B.],
		v.give as [Dare],
		v.have as [Avere],
		v.detaildescription as [Descrizione dettaglio],
		v.description as [Descrizione Scrittura],
		v.codemotive as [Cod. Causale],
		v.accmotive as [Causale],
		v.competencystart as [Inizio competenza],
		v.competencystop as [Fine competenza],
		v.nepexp as [Numero Impegno di Budget],
		v.yepexp as [Anno Impegno di Budget],
		v.nepacc as [Numero Accertamento di Budget],
		v.yepacc as [Anno Accertamento di Budget],
		v.adate as [Data contabile],
		v.amount as [Importo],
		v.doc as [Documento],
		v.docdate as [Data Documento],
		v.official as [Ufficiale],
		s.sortcode as [Cod. Centro di Costo],
		s.start as [Inizio Validità Centro di Costo],
		s.stop as [Fine Validità Centro di Costo],
		case 
			when s.idsor is null then null
			when exists (select * from sorting where paridsor = s.idsor) then 'N'
			else 'S' 
		end as [Ultimo Livello Centro di Costo],
		s2.sortcode as [Obiettivo Piano Integrato],
		d.costpartitioncode [Driver di ripartizione],
		d.active as [Driver Attivo]
		--v.idrelateddetail ,
		--'man§'+convert(varchar(10),i.idmankind)+'§'+convert(varchar(10),i.yman)+'§'+convert(varchar(10),i.nman)+'§'+convert(varchar(10),i.idgroup)
		from entrydetailview v
		left outer join sorting s on v.idsor1 = s.idsor
		left outer join sorting s2 on v.idsor2 = s2.idsor
		left outer join mandatedetail i on v.idrelateddetail = 'man§'+convert(varchar(10),i.idmankind)+'§'+convert(varchar(10),i.yman)+'§'+convert(varchar(10),i.nman)+'§'+convert(varchar(10),i.idgroup)
	 	left outer join costpartition d on i.idcostpartition = d.idcostpartition  --- centro di costo dettaglio contratto passivo
		-- conti di costo o di ricavo
		join account a on a.idacc = v.idacc and ((a.flagaccountusage & 64)<>0 or (a.flagaccountusage & 128)<>0) and a.ayear = @ayear
		where v.yentry = @ayear and v.idrelateddetail is not null and v.idrelateddetail like 'man%' and v.idrelated    like 'man%'
		AND (@idsor01 IS NULL OR v.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR v.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR v.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR v.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR v.idsor05 = @idsor05)
		--AND (@costpartition IS NULL OR i.idcostpartition = @costpartition) -- Driver di Ripartizione
		AND (@idsor1 IS NULL OR v.idsor1 = @idsor1)  -- Centro di Costo

		UNION
		-- Scritture con idrelated dei contratti passivi
		select 
		v.yentry as [Eserc. Scrittura],
		v.nentry as [Num. Scrittura],
		v.ndetail as [Num. Dettaglio],
		v.codeacc as [Cod. Conto],
		v.account as [Conto],
		v.patpart as [Parte Stato Patrim.],
		v.codepatrimony as [Cod. Stato Patrim.],
		v.placcpart as [Parte Conto. Econ.],
		v.codeplaccount as [Cod. Conto Econ.],
		v.registry as [Cliente/Fornitore],
		v.codeupb as [Cod. U.P.B.],
		v.upb as [U.P.B.],
		v.give as [Dare],
		v.have as [Avere],
		v.detaildescription as [Descrizione dettaglio],
		v.description as [Descrizione Scrittura],
		v.codemotive as [Cod. Causale],
		v.accmotive as [Causale],
		v.competencystart as [Inizio competenza],
		v.competencystop as [Fine competenza],
		v.nepexp as [Numero Impegno di Budget],
		v.yepexp as [Anno Impegno di Budget],
		v.nepacc as [Numero Accertamento di Budget],
		v.yepacc as [Anno Accertamento di Budget],
		v.adate as [Data contabile],
		v.amount as [Importo],
		v.doc as [Documento],
		v.docdate as [Data Documento],
		v.official as [Ufficiale],
		s.sortcode as [Cod. Centro di Costo],
		s.start as [Inizio Validità Centro di Costo],
		s.stop as [Fine Validità Centro di Costo],
		case 
			when s.idsor is null then null
			when exists (select * from sorting where paridsor = s.idsor) then 'N'
			else 'S' 
		end as [Ultimo Livello Centro di Costo],
		s2.sortcode as [Obiettivo Piano Integrato],
		NULL [Driver di ripartizione],
		NULL as [Driver Attivo]
		--v.idrelateddetail,
		from entrydetailview v
		left outer join sorting s on v.idsor1 = s.idsor
		left outer join sorting s2 on v.idsor2 = s2.idsor
		-- conti di costo o di ricavo
		join account a on a.idacc = v.idacc and ((a.flagaccountusage & 64)<>0 or (a.flagaccountusage & 128)<>0) and a.ayear = @ayear
		where v.yentry = @ayear and (isnull(v.idrelateddetail,'') not like 'man%') and (isnull(v.idrelateddetail,'') not like 'inv%')
		AND (@idsor01 IS NULL OR v.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR v.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR v.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR v.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR v.idsor05 = @idsor05)
		--AND (@costpartition IS NULL OR i.costpartition = @costpartition) -- Driver di Ripartizione
		AND (@idsor1 IS NULL OR v.idsor1 = @idsor1)  -- Centro di Costo
		ORDER by 1,2 asc ,3 asc


END 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 

