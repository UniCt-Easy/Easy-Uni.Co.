
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


if OBJECTPROPERTY(object_id('exp_flusso_crediti_incassi'), 'IsProcedure') = 1
	drop procedure exp_flusso_crediti_incassi
go

--setuser 'amm'
--setuser 'amministrazione'
 --sp_help [exp_flusso_crediti_incassi]
 -- exp_flusso_crediti_incassi 2023,null,60689,null,null,null,'C','1/1/2023 00:00:00',null,'T',null,null,null,null,null
CREATE  PROCEDURE [exp_flusso_crediti_incassi]
(	
	@ayear int,
	@idflussocrediti int,
	@idflussoincassi int,
	@idreg int, 
	@iuv varchar(100),
	@iduniqueformcode varchar(100),
	@kind char(1),
	@dataincasso_start datetime,
	@dataincasso_stop datetime,
	@filterflusso char(1), --T tutti,  S solo flusso studenti, N diversi da flussostudenti
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null	
	--- tutti    T
					--- incassati nel range  mettere data inizio e data fine   R
					--  non ancora incassati (non specificare alcuna data)   N
					--- incassati dopo data fine (inserire solo data fine)   D
					--- incassati prima della data inizio (inserire solo data inizio)  P
					--  annullati A (non esiste il flusso incassi)
					-- Dettagli incassi per i quali non è stato ancora elaborato l'incasso E 
					-- caso in cui esiste il flussoincassi ma non esiste il flussocrediti I
					-- caso in cui è stato annullato il credito, ma esiste il flusso incassi C
)
AS BEGIN
-- exp_flusso_crediti_incassi null, null,233988, null, null,null,'E',null,null,'T',null,null,null,null,null
--setuser 'amm'
DECLARE @nphase  int
SELECT @nphase = max(nphase) FROM incomephase  
select 
	I.dataincasso as 'Data Flusso Incassi',
	I.ayear as 'Esercizio incasso',
	I.idflusso as 'Numero Flusso Incasso',
	I.iddetail as 'N.Dettaglio Flusso Incasso',	
	C.idflusso  as 'N.Flusso crediti', 
    C.iddetail as 'N.Dettaglio Flusso Crediti',
    C.istransmitted as 'Trasmesso',
    C.registry as 'Versante',
	REG.email as 'E-mail',
    C.docdate as 'Data Doc.',
    C.description as 'Descrizione',
    C.importoversamento as 'Imponibile dettaglio flusso crediti',--'importo versamento',
	C.tax as 'IVA dettaglio flusso credito',
    C.estimkind_det as 'Tipo Contratto Attivo',
    C.yestim as 'Eserc.Contratto Attivo',
    C.nestim as 'Num.Contratto Attivo',
	ED.rownum as 'Dettaglio Contratto Attivo',
    C.invoicekind as 'Tipo doc.Iva',
    C. yinv as 'Eserc.Fattura',
    C.ninv as 'Num.Fattura',
	ID.rownum as 'Dettaglio Fattura',
    C.upb as 'UPB',
    C.upb_iva as 'UPB iva',
    C.iduniqueformcode as 'Codice Bollettino Univoco',
    C.nform as 'Numero Bollettino',
    C.cf as 'CF',
	C.p_iva as 'Piva',
    C.iuv as 'IUV',
    C.annulment as 'Data annullamento',
    C.stop as 'Data fine validità',
    C.datacreazioneflusso as 'Data creazione flusso',
    C.causalecredito as 'Causale credito',
    C.casualeentroanno as 'Casuale entro anno', 
    C.casualepostanno as 'Causale post anno',
    C.casualericavo as 'Causale ricavo',
    C.causalebilentrata as 'Causale bilancio entrata',
    C.competencystart as 'Inizio Comp.Economica',
    C.competencystop as 'Fine Comp.Economica',
    C.codiceavviso as 'Codice Avviso',
    --C.idunivoco as 'Progr.generale tra tutti i dettagli credito',
    C.expirationdate as 'Scadenza',
	----- flusso incassi		
	I.causale as 'Causale',
	I.importotale as 'Importo Totale Flusso Incasso',
	I.nbill as 'N.Bolletta',
	I.iuv as 'Codice IUV',
	I.iduniqueformcode as 'Codice Bollettino',
	I.importo as 'Importo',
	I.active as 'Attivo',
	I.elaborato as 'Elaborato',
	INCCA.ymov as 'Eserc.Incasso Contratto attivo',
	INCCA.nmov as 'Num.Incasso Contratto attivo',
	PCA.ypro as 'Eserc.Reversale Contratto attivo',
	PCA.npro as 'Num.Reversale Contratto attivo',	
	INCF.ymov as 'Eserc.Incasso imponibile fattura',
	INCF.nmov as 'Num.Incasso imponibile fattura',
	PF.ypro as 'Eserc.Reversale imponibile fattura',
	PF.npro as 'Num.Reversale imponibile fattura',
	INCF2.ymov as 'Eserc.Incasso iva fattura',
	INCF2.nmov as 'Num.Incasso iva fattura',
	PF2.ypro as 'Eserc.Reversale iva fattura',
	PF2.npro as 'Num.Reversale iva fattura',
	C.cu,
	C.filename 
	from flussocreditidetailview C
	left outer join flussoincassidetailview I	ON C.IUV = I.IUV or C.iduniqueformcode = I.iduniqueformcode
	left outer join registryreference REG		on C.idreg = REG.idreg AND 	(REG.flagdefault is null or REG.flagdefault = 'S')
	--FATTURA
	left outer join invoicedetail ID			ON (C.idinvkind = ID.idinvkind AND C.yinv = ID.yinv AND C.ninv = ID.ninv AND C.invrownum = ID.rownum)
	left outer join incomelast IL1				ON ID.idinc_taxable = IL1.idinc
	left outer join income INCF					ON INCF.idinc = IL1.idinc 
	left outer join proceeds PF					ON IL1.kpro = PF.kpro
	
	left outer join incomelast ILI				ON ID.idinc_iva = ILI.idinc
	left outer join income INCF2				ON INCF2.idinc = ILI.idinc 
	left outer join proceeds PF2				ON ILI.kpro = PF2.kpro

	--CONTRATTO ATTIVO
	left outer join estimatedetail ED			ON (C.idestimkind = ED.idestimkind AND C.yestim = ED.yestim AND C.nestim = ED.nestim AND C.rownum = ED.rownum)
	left outer join incomelink					ON incomelink.idparent = ED.idinc_taxable  and ( isnull(incomelink.idparent,0) <> isnull(incomelink.idchild,0) OR @nphase = 1) 
    left outer join incomelast IL2				ON incomelink.idchild = IL2.idinc	
    left outer join income INCCA				ON IL2.idinc= INCCA.idinc
	left outer join proceeds PCA				ON IL2.kpro = PCA.kpro
	
	WHERE (@ayear is null OR YEAR(C.datacreazioneflusso) = @ayear) AND
		  (C.idflusso   = @idflussocrediti OR @idflussocrediti IS NULL) AND
		  (I.idflusso   = @idflussoincassi OR @idflussoincassi IS NULL) AND
		  (C.idreg = @idreg OR @idreg IS NULL) AND
		  (C.iuv = @iuv OR @iuv IS NULL) AND
		  (C.iduniqueformcode = @iduniqueformcode OR @iduniqueformcode IS NULL) AND
		  (@idsor01 IS NULL OR C.idsor01 = @idsor01) AND
		  (@idsor02 IS NULL OR C.idsor02 = @idsor02) AND 
		  (@idsor03 IS NULL OR C.idsor03 = @idsor03) AND
		  (@idsor04 IS NULL OR C.idsor04 = @idsor04) AND
		  (@idsor05 IS NULL OR C.idsor05 = @idsor05)
		  AND
		  (
			(@kind = 'T')  		  --- tutti    T
			OR
			(@kind = 'R' AND I.dataincasso >= @dataincasso_start AND  I.dataincasso <= @dataincasso_stop
						 AND @dataincasso_start IS NOT NULL AND @dataincasso_stop IS NOT NULL)  -- incassati nel range  mettere data inizio e data fine   R
			OR
			(@kind = 'N' AND I.dataincasso  IS NULL and C.stop is null and C.annulment is null)  --  non ancora incassati (non specificare alcuna data)   N	
			OR
			(@kind = 'A' AND I.dataincasso  IS NULL AND C.stop is not null)  -- ANNULLATI 	
			OR
			(@kind = 'D' AND  I.dataincasso >= ISNULL(@dataincasso_start, @dataincasso_stop) )  --   incassati dopo data fine (inserire solo una data)   D 
			OR
			(@kind = 'P' AND  I.dataincasso <= ISNULL(@dataincasso_start, @dataincasso_stop) )  --   incassati prima della data inizio (inserire solo una data)  P
			OR
			(@kind = 'E' AND IL2.idinc IS NULL AND IL1.idinc IS NULL 
			AND (I.dataincasso >= @dataincasso_start or @dataincasso_start IS NULL) AND (I.dataincasso <= @dataincasso_stop or @dataincasso_stop IS NULL)
			and C.stop is null and C.annulment is null) -- Dettagli incassi per i quali non è stato ancora elaborato l'incasso
			OR
			(@kind = 'C' 
			AND (I.dataincasso >= @dataincasso_start or @dataincasso_start IS NULL) AND (I.dataincasso <= @dataincasso_stop or @dataincasso_stop IS NULL)
			and C.annulment is not null) -- Dettagli incassi per i quali è stato annullato il credito
		 )
		 AND
		 (
			(@filterflusso = 'T')
			OR 
			(@filterflusso = 'S' AND ( (C.cu = 'import_flussostudenti' AND  C.filename = 'Importato da webservice')))
			OR
			(@filterflusso = 'N' AND NOT( (C.cu = 'import_flussostudenti' AND   C.filename = 'Importato da webservice')))
		 )
		  
UNION
	-- caso in cui esiste il flussoincassi ma non esiste il flussocrediti
	select 
		I.dataincasso as 'Data Flusso Incassi',
		I.ayear as 'Esercizio incasso',
		I.idflusso as 'Numero Flusso Incasso',
		I.iddetail as 'N.Dettaglio Flusso Incasso',	
		C.idflusso  as 'N.Flusso crediti', 
		C.iddetail as 'N.Dettaglio Flusso Crediti',
		C.istransmitted as 'Trasmesso',
		C.registry as 'Versante',
		null as 'E-mail',
		C.docdate as 'Data Doc.',
		C.description as 'Descrizione',
		C.importoversamento as 'Imponibile dettaglio flusso crediti',--'importo versamento',
		C.tax as 'IVA dettaglio flusso credito',
		C.estimkind_det as 'Tipo Contratto Attivo',
		C.yestim as 'Eserc.Contratto Attivo',
		C.nestim as 'Num.Contratto Attivo',
		null as 'Dettaglio Contratto Attivo',
		C.invoicekind as 'Tipo doc.Iva',
		C. yinv as 'Eserc.Fattura',
		C.ninv as 'Num.Fattura',
		null as 'Dettaglio Fattura',
		C.upb as 'UPB',
		C.upb_iva as 'UPB iva',
		C.iduniqueformcode as 'Codice Bollettino Univoco',
		C.nform as 'Numero Bollettino',
		C.cf as 'CF',
		C.p_iva as 'Piva',
		C.iuv as 'IUV',
		C.annulment as 'Data annullamento',
		C.stop as 'Data fine validità',
		C.datacreazioneflusso as 'Data creazione flusso',
		C.causalecredito as 'Causale credito',
		C.casualeentroanno as 'Casuale entro anno', 
		C.casualepostanno as 'Causale post anno',
		C.casualericavo as 'Causale ricavo',
		C.causalebilentrata as 'Causale bilancio entrata',
		C.competencystart as 'Inizio Comp.Economica',
		C.competencystop as 'Fine Comp.Economica',
		C.codiceavviso as 'Codice Avviso',
		--C.idunivoco as 'Progr.generale tra tutti i dettagli credito',
		C.expirationdate as 'Scadenza',
		----- flusso incassi		
		I.causale as 'Causale',
		I.importotale as 'Importo Totale Flusso Incasso',
		I.nbill as 'N.Bolletta',
		I.iuv as 'Codice IUV',
		I.iduniqueformcode as 'Codice Bollettino',
		I.importo as 'Importo',
		I.active as 'Attivo',
		I.elaborato as 'Elaborato',
		null as 'Eserc.Incasso Contratto attivo',
		null as 'Num.Incasso Contratto attivo',
		null as 'Eserc.Reversale Contratto attivo',
		null as 'Num.Reversale Contratto attivo',	
		null as 'Eserc.Incasso imponibile fattura',
		null as 'Num.Incasso imponibile fattura',
		null as 'Eserc.Reversale imponibile fattura',
		null as 'Num.Reversale imponibile fattura',
		null as 'Eserc.Incasso iva fattura',
		null as 'Num.Incasso iva fattura',
		null as 'Eserc.Reversale iva fattura',
		null as 'Num.Reversale iva fattura',
		C.cu,
		C.filename 
		from flussoincassidetailview I
		left outer join flussocreditidetailview C	ON C.IUV = I.IUV or C.iduniqueformcode = I.iduniqueformcode
	
		WHERE (I.idflusso = @idflussoincassi OR @idflussoincassi IS NULL) AND
			  (C.idflusso IS NULL) AND
			  @kind in ('T', 'N', 'E', 'I')
			  AND (I.dataincasso >= @dataincasso_start or @dataincasso_start IS NULL) AND (I.dataincasso <= @dataincasso_stop or @dataincasso_stop IS NULL)
	
		ORDER BY  I.dataincasso DESC
		 
END

