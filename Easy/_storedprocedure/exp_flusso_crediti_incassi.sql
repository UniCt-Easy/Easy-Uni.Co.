
/*
Easy
Copyright (C) 2022 Universit‡ degli Studi di Catania (www.unict.it)
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
					--  annullati A
)
AS BEGIN
-- exp_flusso_crediti_incassi null, null,null, null, null,null,'T',null,null,'S',null,null,null,null,null
--setuser 'amm'

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
    C.stop as 'Data fine validit√†',
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
	left outer join registryreference REG		on C.idreg = REG.idreg
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
	left outer join incomelink					ON incomelink.idparent = ED.idinc_taxable --and incomelink.idparent <>incomelink.idchild
    left outer join incomelast IL2				ON incomelink.idchild = IL2.idinc	
    left outer join income INCCA				ON IL2.idinc= INCCA.idinc
	left outer join proceeds PCA				ON IL2.kpro = PCA.kpro
	
	WHERE (@ayear is null OR YEAR(C.datacreazioneflusso) = @ayear) AND
		  (C.idflusso   = @idflussocrediti OR @idflussocrediti IS NULL) AND
		  (I.idflusso   = @idflussoincassi OR @idflussoincassi IS NULL) AND
		  (C.idreg = @idreg OR @idreg IS NULL) AND
		  (C.iuv = @iuv OR @iuv IS NULL) AND
		  (C.iduniqueformcode = @iduniqueformcode OR @iduniqueformcode IS NULL) AND
		  (incomelink.idchild is null or incomelink.idchild= IL2.idinc ) AND
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
		 )
		 AND
		 (
			(@filterflusso = 'T')
			OR 
			(@filterflusso = 'S' AND ( (C.cu = 'import_flussostudenti' AND  C.filename = 'Importato da webservice')))
			OR
			(@filterflusso = 'N' AND NOT( (C.cu = 'import_flussostudenti' AND   C.filename = 'Importato da webservice')))
		 )
		 AND
		 (REG.flagdefault is null or REG.flagdefault = 'S')
 
		 
END

