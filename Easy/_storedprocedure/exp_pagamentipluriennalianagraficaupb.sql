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


  if exists (select * from dbo.sysobjects where id = object_id(N'[exp_pagamentipluriennalianagraficaupb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_pagamentipluriennalianagraficaupb]
GO

 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE [exp_pagamentipluriennalianagraficaupb](
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
	SELECT @maxphase = MAX(nphase) FROM expensephase

select 
					 E.phase as 'Fase',
					 E.ymov as 'Eserc.Mov.',
					 E.nmov as 'Num.Mov.',
					 E.codefin as 'Voce Bil.',
					 E.finance as 'Denom. Bil.',
					 E.codeupb as 'Cod. U.P.B.',
					 E.upb as 'U.P.B.',
					 E.registry as 'Percipiente',
					 E.manager as 'Responsabile',
					 E.doc as 'Documento',
					 E.docdate as 'Data Doc.',
					 E.description as 'Descrizione',
					 E.amount as 'Importo Originale',
					 E.ayearstartamount as 'Imp.Esercizio',
					 E.curramount as 'Imp.Corrente',
					 E.netamount as 'Importo Netto',
					 E.available as 'Disponibile',
					 E.adate as 'Data Contabile',
					 E.ypay as 'Eserc.Mand.',
					 E.npay as 'Num.Mand.',
					 E.idpay as 'Num. SUB (trasmissione)',
					 E.paymentadate as 'Data Cont. Mand.',
					 E.npaymenttransmission as 'Distinta Trasmissione',
					 E.transmissiondate as 'Data Trasmissione',
					 E.cigcode as 'CIG',
					 E.cupcode as 'CUP',
					 E.codeaccdebit as 'Cod.Causale Debito',
					 E.accountdebit as 'Causale Debito',
					 E.nbill as 'Bolletta',
					 E.cc as '.Conto'
from expenseview E
join upb U on E.idupb = U.idupb
where E.nphase = @maxphase
and ( E.ymov >=@ayearstart or @ayearstart is null)
and ( E.ymov <=@ayearstop or @ayearstop is null)
and ( E.idreg = @idreg or @idreg is null)
and (E.idupb like @idupb or @idupb is null)
and (@idreg is not null or @idupb is not null)
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
ORDER BY  E.ymov, E.nmov 
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
