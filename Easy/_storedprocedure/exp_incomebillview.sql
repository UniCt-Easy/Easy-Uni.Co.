
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_incomebillview]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_incomebillview]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [exp_incomebillview]
(
	@ayear int,
	@start datetime,
	@stop datetime
)
AS BEGIN


DECLARE @maxphase tinyint
SELECT @maxphase = MAX(nphase) FROM incomephase
select 
	 E.phase as 'Fase',
	 E.ymov as 'Eserc.Mov.',
	 E.nmov as 'Num.Mov.',
	 E.adate as 'Data Contabile',
	 E.codefin as 'Voce Bil.',
	 E.finance as 'Denom. Bil.',
	 E.codeupb as 'Cod. U.P.B.',
	 E.upb as 'U.P.B.',
	 E.registry as 'Versante',
	 E.CF,
	 E.p_iva as 'Piva',
	 E.manager as 'Responsabile',
	 E.ypro as 'Eserc.Rev.',
	 E.npro as 'Num.Rev.',
	 E.idpro as 'Num. SUB (trasmissione)',
	 E.doc as 'Documento',
	 E.docdate as 'Data Doc.',
	 E.description as 'Descrizione',
	 E.amount as 'Importo Originale',
	 E.ayearstartamount as 'Imp.Esercizio',
	 E.curramount as 'Imp.Corrente',
	 --netamount as 'Importo Netto',
	 E.available as 'Disponibile',
	 E.unpartitioned as 'Da Assegnare',
	 B.nbill as 'Bolletta',
     B.adate as 'Data apertura Bolletta',
	 BT.transactiondate as 'Data esitazione',
	 BT.amount as 'Importo esitazione',
	 case when (b.total is not null) then convert(decimal(19,2), round( (BT.amount*100/b.total) ,2))
	 else null 
	 end as '% esitato dal movimento',
	 E.ypayment as 'Eserc.Pagamento.',
	 E.npayment as 'Num.Pagamento.',
	 E.descrpayment as 'Descr.Pagamento.',
	 --E.ymov as 'Eserc.Incasso',
	 --E.nmov as 'Num.Incasso',
	 E.nproceedstransmission as 'Distinta Trasmissione',
	 E.transmissiondate as 'Data Trasmissione',
	 E.codeacccredit as 'Cod.Causale Credito',
	 E.accountcredit as 'Causale Credito',
	 E.cu ,
	 E.lu
from billview B	
	left outer join incomeview E
			ON E.nbill = B.nbill and E.ymov = @ayear and E.nphase = @maxphase
	left outer join incomebill EB 
			on B.nbill = EB.nbill and  B.ybill = EB.ybill
	left outer join banktransaction BT on BT.nbill = B.nbill and BT.yban = @ayear and BT.kind = 'C' and BT.idinc = E.idinc
where B.ybill = @ayear
	and B.billkind = 'C'
	and B.adate between @start and @stop
order by   B.nbill, E.nmov
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 EXEC exp_incomebillview 2020, {ts '2020-01-01 00:00:00'}, {ts '2020-12-31 00:00:00'}
 
