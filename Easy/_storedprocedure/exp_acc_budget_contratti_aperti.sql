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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_acc_budget_contratti_aperti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_acc_budget_contratti_aperti]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser'amm' 
--setuser 'amministrazione' 
-- exp_acc_budget_contratti_aperti 2024
CREATE  PROCEDURE  [exp_acc_budget_contratti_aperti](
	@ayear 			int 
) 
AS BEGIN

DECLARE @sql NVARCHAR(MAX)

SET @sql = N'
WITH contratto(contratto, esercizio, numero, idepacc, description)
AS
(
	select ek.description, e.yestim, e.nestim, ed.idepacc, e.description
	from estimatedetail ed
	join estimate e ON e.idestimkind = ed.idestimkind and e.yestim = ed.yestim and e.nestim = ed.nestim
	join estimatekind ek ON e.idestimkind = ek.idestimkind
	group by ek.description, e.yestim, e.nestim, ed.idepacc, e.description
)
SELECT
	epacc.yepacc [Eserc. Accertamento Budget],
	epacc.nepacc [Num. Accertamento Budget],
	epacc.description [Descr. Accertamento Budget],
	c.contratto [Contratto],
	c.esercizio [Eserc. Contratto],
	c.numero [Num. Contratto],
	c.description [Descr. Contratto],
	registry.title [Fornitore/Cliente],
    registry.cf [Codice Fiscale],
    registry.p_iva [Partita Iva],
	A.codeacc [Codice conto], 
    A.title [Conto],
    U.codeupb [Cod. U.P.B.], 
    U.title [U.P.B.],
    epacc.flagvariation [Nota di variazione],
	ET.curramount [' + CAST(@ayear AS NVARCHAR(4)) + '],
    case when epacc.nphase = 1 then ET.available else null end [Disp. ' + CAST(@ayear AS NVARCHAR(4)) + '],
    ET.curramount2 [' + CAST(@ayear + 1 AS NVARCHAR(4)) + '],
    case when epacc.nphase = 1 then ET.available2 else null end [Disp. ' + CAST(@ayear + 1 AS NVARCHAR(4)) + '],
    ET.curramount3 [' + CAST(@ayear + 2 AS NVARCHAR(4)) + '],
    case when epacc.nphase = 1 then ET.available3 else null end [Disp. ' + CAST(@ayear + 2 AS NVARCHAR(4)) + '],
    ET.curramount4 [' + CAST(@ayear + 3 AS NVARCHAR(4)) + '],
    case when epacc.nphase = 1 then ET.available4 else null end [Disp. ' + CAST(@ayear + 3 AS NVARCHAR(4)) + '],
    ET.curramount5 [' + CAST(@ayear + 4 AS NVARCHAR(4)) + '],
    case when epacc.nphase = 1 then ET.available5 else null end [Disp. ' + CAST(@ayear + 4 AS NVARCHAR(4)) + '],
	case when epacc.nphase = 2 then
		isnull(ET.curramount,0)+isnull(ET.curramount2,0)+isnull(ET.curramount3,0)+isnull(ET.curramount4,0)+isnull(ET.curramount5,0)-
			case when epacc.flagvariation =''N'' 
					then ISNULL(ET.revenue,0)
					else -ISNULL(ET.revenue,0)
			end	
		else null
	end [Disp.per Ricavi],
	epacc.adate [Data contabile],
    epacc.start [Inizio Competenza],
    epacc.stop [Fine Competenza],
    epacc.doc [Documento],
    epacc.docdate [Data Documento],
	case when epacc.nphase = 2 then
		case when epacc.flagvariation =''N'' 
					then ISNULL(ET.revenue,0)
					else -ISNULL(ET.revenue,0)
		end	
		else null
	end [Ricavi totali],
	case when epacc.flagvariation =''N'' 
					then ISNULL(ET.credit,0)
					else -ISNULL(ET.credit,0)
	end [Crediti totali],
	isnull(EY.amount,0)+isnull(EY.amount2,0)+isnull(EY.amount3,0)+isnull(EY.amount4,0)+isnull(EY.amount5,0) [Tolale Iniziale Pluriennale],
	case when epacc.nphase = 1 then
			isnull(ET.available,0)+isnull(ET.available2,0)+isnull(ET.available3,0)+isnull(ET.available4,0)+isnull(ET.available5,0)
		else 
			null
	end [Totale Disp. Pluriennale],
	isnull(ET.curramount,0)+isnull(ET.curramount2,0)+isnull(ET.curramount3,0)+isnull(ET.curramount4,0)+isnull(ET.curramount5,0) [Totale Corrente Pluriennale]
FROM epacc
left outer JOIN registry ON epacc.idreg= registry.idreg
join epaccyear EY on epacc.idepacc= EY.idepacc
join epacctotal ET on ET.idepacc= EY.idepacc and EY.ayear=ET.ayear
join account A on EY.idacc=A.idacc
join upb U on U.idupb=EY.idupb
left outer join epacc par on epacc.paridepacc=par.idepacc
left outer join manager on manager.idman= epacc.idman
LEFT OUTER JOIN accmotive   on accmotive.idaccmotive = epacc.idaccmotive
left join contratto c on c.idepacc = epacc.idepacc
WHERE epacc.yepacc = ' + CAST(@ayear AS NVARCHAR(4)) + '
and epacc.nphase = 2
order by epacc.yepacc, epacc.nepacc'

EXEC sp_executesql @sql

END