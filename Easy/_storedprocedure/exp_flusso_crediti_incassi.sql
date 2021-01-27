
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


 if exists (select * from dbo.sysobjects where id = object_id(N'[exp_flusso_crediti_incassi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_flusso_crediti_incassi]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
--setuser 'amministrazione'
 
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
	@dataincasso_stop datetime
	--- tutti    T
					--- incassati nel range  mettere data inizio e data fine   R
					--  non ancora incassati (non specificare alcuna data)   N
					--- incassati dopo data fine (inserire solo data fine)   D
					--- incassati prima della data inizio (inserire solo data inizio)  P
					--  annullati A
)
AS BEGIN

-- exp_flusso_crediti_incassi 2019, null,null, null, null,null,'R',{d '2019-01-01'},{d '2019-03-31'}


select 
	I.dataincasso as 'Data Incasso',
	C.idflusso  as 'N.Flusso crediti', 
    C.iddetail as 'N.Dettaglio',
    C.istransmitted as 'Trasmesso',
    C.registry as 'Versante',
    C.docdate as 'Data Doc.',
    C.description as 'Descrizione',
    C.importoversamento as 'importo versamento',
    C.estimkind_det as 'Tipo Contratto Attivo',
    C.yestim as 'Eserc.Contratto Attivo',
    C.nestim as 'Num.Contratto Attivo',
    C.invoicekind as 'Tipo doc.Iva',
    C. yinv as 'Eserc.Fattura',
    C.ninv as 'Num.Fattura',
    C.upb as 'UPB',
    C.upb_iva as 'UPB iva',
    C.iduniqueformcode as 'Codice Bollettino Univoco',
    C.nform as 'Numero Bollettino',
    C.cf as 'CF',
	C.p_iva as 'Piva',
    C.iuv as 'IUV',
    C.annulment as 'Data annullamento',
    C.stop as 'Data fine validità',
    C.datacreazioneflusso as 'data creazione flusso',
    C.causalecredito as 'causale credito',
    C.casualeentroanno as 'casuale entro anno',
    C.casualepostanno as 'causale post anno',
    C.casualericavo as 'casuale ricavo',
    C.causalebilentrata as 'causale bilancio entrata',
    C.competencystart as 'Inizio Comp.Economica',
    C.competencystop as 'Fine Comp.Economica',
    C.codiceavviso as 'Codice Avviso',
    C.idunivoco as 'Progr.generale tra tutti i dettagli credito',
    C.expirationdate as 'Scadenza',
	----- flusso incassi
	I.ayear as 'Esercizio incasso',
	I.iddetail as 'n.dettaglio',
	I.causale as 'Causale',
	I.importotale as 'Importo Totale',
	I.nbill as 'N.Bolletta',
	I.iuv as 'Codice IUV',
	I.iduniqueformcode as 'Codice Bollettino',
	I.importo as 'Importo',
	I.active as 'Attivo',
	I.elaborato as 'Elaborato',

	INCF.ymov as 'Eserc.Incasso fattura',
	INCF.nmov as 'Num.Incasso fattura',
	PF.ypro as 'Eserc.Reversale fattura',
	PF.npro as 'Num.Reversale fattura',
	INCCA.ymov as 'Eserc.Incasso Contratto attivo',
	INCCA.nmov as 'Num.Incasso Contratto attivo',
	PCA.ypro as 'Eserc.Reversale Contratto attivo',
	PCA.npro as 'Num.Reversale Contratto attivo'
	from flussocreditidetailview C
	left outer join flussoincassidetailview I	ON C.IUV = I.IUV or C.iduniqueformcode = I.iduniqueformcode
	--FATTURA
	left outer join invoicedetail ID			ON (C.idinvkind = ID.idinvkind AND C.yinv = ID.yinv AND C.ninv = ID.ninv AND C.invrownum = ID.rownum)
	left outer join incomelast IL1				ON ID.idinc_taxable = IL1.idinc
	left outer join income INCF					ON INCF.idinc = IL1.idinc 
	left outer join proceeds PF					ON IL1.kpro = PF.kpro

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
		  (incomelink.idchild is null or incomelink.idchild= IL2.idinc )
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
 
		 
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



