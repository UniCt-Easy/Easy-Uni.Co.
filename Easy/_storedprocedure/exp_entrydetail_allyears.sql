/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_entrydetail_allyears]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_entrydetail_allyears]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- --
--SETUSER 'amministrazione'
-- exec [exp_entrydetail_allyears] 'CB0908010503', '000100030001000100010001', 16224
CREATE    PROCEDURE [exp_entrydetail_allyears]
(
	@codeacc varchar(50) = null,
	@idupb varchar(36) = null,
	@idreg int = null
) 
AS BEGIN

--DECLARE @codeacc varchar(50)
--SELECT @codeacc = codeacc
--    from account
--    where idacc = @idacc

SELECT
	EV.yentry AS "Eserc. Scrittura",
	EV.nentry AS "Num. Scrittura",
	EV.entrykind AS "Tipo",
	EV.ndetail AS "Num. Dettaglio",
	EV.codeacc AS "Cod. Conto",
	EV.account AS "Conto",
	EV.patpart AS "Parte Stato Patrim.",
	EV.codepatrimony AS "Cod. Stato Patrim.",
	EV.placcpart AS "Parte Conto. Econ.",
	EV.codeplaccount AS "Cod. Conto Econ.",
	EV.idreg AS ".Codice Anagrafica",
	EV.registry AS "Cliente/Fornitore",
	EV.codeupb AS "Cod. U.P.B.",
	EV.upb AS "U.P.B.",
	EV.give AS "Dare",
	EV.have AS "Avere",
	EV.amount AS "Saldo",
	EV.adate AS "DataContabile",
	EV.detaildescription AS "Descrizione dettaglio",
	EV.description AS "Descrizione Scrittura",
	EV.codemotive AS "Cod. Causale",
	EV.accmotive AS "Causale",
	EV.competencystart AS "Inizio competenza",
	EV.competencystop AS "Fine competenza",
	EV.nepexp AS "Numero Impegno di Budget",
	EV.yepexp AS "Anno Impegno di Budget",
	EV.nepacc AS "Numero Accertamento di Budget",
	EV.yepacc AS "Anno Accertamento di Budget",
	EV.sortcode1 AS "Classificazione 1",
	EV.sortcode2 AS "Classificazione 2",
	EV.sortcode3 AS "Classificazione 3",
	EV.idrelated AS "Chiave EP documento",
	EV.idrelateddetail AS "Chiave EP dettaglio",
	EV.doc AS "Documento",
	EV.docdate AS "DataDocumento"
	--EV.flagaccountusage AS ".flag Tipo conto",
	--EV.flagregistry AS ".Flag Anagrafica",
	--EV.flagupb AS ".Flag UPB",
	--EV.identrykind AS ".ID Tipo Scrittura",
	--EV.official AS ".Ufficiale"
FROM entrydetailview EV
WHERE
	(EV.codeacc like @codeacc or @codeacc is null) AND
	(EV.idupb like @idupb or @idupb is null) AND
	(EV.idreg = @idreg or @idreg is null)
ORDER BY
	EV.adate,
	EV.yentry,
	EV.nentry,
	EV.ndetail
 
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO				

					