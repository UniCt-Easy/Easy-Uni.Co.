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

  if exists (select * from dbo.sysobjects where id = object_id(N'[exp_incassipluriennalianagraficaupb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_incassipluriennalianagraficaupb]
GO

 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE [exp_incassipluriennalianagraficaupb](
	@ayearstart smallint ,
	@ayearstop smallint ,
	@idreg int =null,
	@idupb varchar(36)='%',
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null

)

AS BEGIN


DECLARE @maxphase tinyint
SELECT @maxphase = MAX(nphase) FROM incomephase

select 					
					 I.phase as 'Fase',
					 I.ymov as 'Eserc.Mov.',
					 I.nmov as 'Num.Mov.',
					 I.codefin as 'Voce Bil.',
					 finance as 'Denom. Bil.',
					 I.codeupb as 'Cod. U.P.B.',
					 I.upb as 'U.P.B.',
					 I.registry as 'Versante',
					 I.cf as 'C.F.',
					 I.p_iva as 'P.Iva',
					 I.manager as 'Responsabile',
					 I.ypro as 'Eserc.Rev.',
					 I.npro as 'Num.Rev.',
					 I.idpro as 'Num. SUB (trasmissione)',
					 I.doc as 'Documento',
					 I.docdate as 'Data Doc.',
					 I.description as 'Descrizione',
					 I.amount as 'Importo Originale',
					 I.ayearstartamount as 'Imp.Esercizio',
					 I.curramount as 'Imp.Corrente',
					 I.available as 'Disponibile',
					 I.unpartitioned as 'Da Assegnare',
					 I.nbill as 'Bolletta',
					 I.flagarrear as '.Competenza',
					 I.ypayment as 'Eserc.Pagamento.',
					 I.npayment as 'Num.Pagamento.',
					 I.descrpayment as 'Descr.Pagamento.',
					 I.adate as 'Data Contabile',
					 I.nproceedstransmission as 'Distinta Trasmissione',
					 I.transmissiondate as 'Data Trasmissione',
					 I.cupcode as 'CUP',
					 I.codeacccredit as 'Cod.Causale Credito',
					 I.accountcredit as 'Causale Credito',
					 I.nexp_linked as 'N.mov.spesa p.giro'
from incomeview I
join upb U on I.idupb = U.idupb
where nphase = @maxphase
	and ( I.ymov >=@ayearstart or @ayearstart is null)
	and ( I.ymov <=@ayearstop or @ayearstop is null)
	and ( I.idreg = @idreg or @idreg is null)
	and (I.idupb like @idupb or @idupb is null)
	and (@idreg is not null or @idupb is not null)
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05) 
ORDER BY  I.ymov, I.nmov 
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

