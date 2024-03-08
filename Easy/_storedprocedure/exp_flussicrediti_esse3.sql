
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_flussicrediti_esse3]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_flussicrediti_esse3]
GO
CREATE PROCEDURE [exp_flussicrediti_esse3] 
	@anno int = 2020 -- Anno Data contabile del bollettino
AS
BEGIN
SELECT FD.[idflusso] as 'ID flusso di credito',FD.[iddetail] 'Riga flusso di credito',ISNULL(FE.surname,R.[surname])  'Cognome',isnull(FE.forename,R.[forename]) 'Nome',FD.[importoversamento] 'Importo bollettino'
	,FD.[iduniqueformcode] as CodiceBollettino ,isnull(FD.[IUV],FI.[IUV]) 'IUV',isnull(FD.[cf], R.CF) 'CF',FE.[codicecausale] 'Descrizione Esse3', FE.[codicecorsolaurea] 'Codice Corso Laurea'
	,FE.[codicedipartimento] 'Codice Dipartimento', FE.[codicesede] 'Codice Sede',FE.[codicetassa] 'Codice Tassa', TA.Descrizione 'Tassa' ,FE.[codicevoce] 'Codice Voce', VO.Descrizione 'Voce'
	,FE.[competencystart] as 'Data Inizio Competenza'
	,FE.[competencystop] as 'Data Fine Competenza'
	,FD.causalecredito as 'Causale Credito'
	,FD.casualeentroanno as 'Casuale Annullo Entro Anno'
	,FD.casualepostanno as 'Casuale Annullo Anno Successivo'
	,FD.casualericavo as 'Casuale di Ricavo'
	,FD.causalebilentrata as 'Casuale di Bilancio di Entrata'
	,FE.[datacontabile] 'Data Contabile Bollettino'
	,FE.[datascadenza] 'Data Scadenza Bollettino'
	,FD.idestimkind 'Codice Tipo contratto Attivo'
	,FD.yestim 'Anno Contratto Attivo'
	,FD.nestim 'Num. Contratto Attivo'
	,FD.rownum 'Num. Riga Contratto Attivo'
	,FI.idflusso as 'Id flusso incasso'
	,FI.iddetail as 'Riga flusso di incasso'
	,FI.codiceflusso as 'Codice flusso'
	,FI.nbill as 'Sospeso di Entrata'	
	,FI.trn as 'TRN'
	,FI.causale as  'Causale incasso'
	,FI.Importo 'Importo del flusso'
	,FI.[iduniqueformcode] as CodiceBollettino
	,I3.Ymov 'Anno Incasso'
	,I3.nmov 'Numero Incasso'
	,I2.Ymov 'Anno Accertamento'
	,I2.nmov 'Numero Accertamento'
	,I3.codeupb 'Codice UPB'
	,I3.codefin 'Codice Bilancio'
	,I3.idreg 'Codice Anagrafica'
	,I3.npro 'Numero Reversale'
	,I3.curramount as 'Importo corrente'
	,I3.nbill as 'Num. Sospeso Attivo'
	,I3.nproceedstransmission as 'Num. Distinta di Trasmissione'
	,I3.transmissiondate as 'Data Distinta di Trasmissione'

  FROM flussocreditidetailview FD
  LEFT JOIN [flussocreditidetail_esse3] FE ON FE.[idflusso] = FD.[idflusso] AND FE.[iddetail] = FD.[iddetail] 
  LEFT JOIN estimatedetail ED ON ED.idestimkind = FD.idestimkind AND ED.yestim = FD.yestim AND ED.nestim = FD.nestim AND ED.rownum = FD.rownum
  LEFT JOIN Incomeview I3 ON I3.parentidinc = ED.idinc_taxable
  LEFT JOIN Income I2 ON I2.idinc = ED.idinc_taxable
  LEFT JOIN registry R on R.idreg = FD.idreg
  RIGHT JOIN flussoincassidetailview FI on FI.iduniqueformcode = FD.iduniqueformcode
  LEFT JOIN stip_voce VO on VO.codicevoce = FE.codicevoce
  LEFT JOIN stip_tassa TA on TA.codicetassa = FE.codicetassa
WHERE YEAR(FE.[datacontabile])= @anno OR YEAR(FI.[dataincasso])= @anno
ORDER BY FD.iduniqueformcode desc

-- [Amministrazione].[exp_flussicrediti_esse3] 2021

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

