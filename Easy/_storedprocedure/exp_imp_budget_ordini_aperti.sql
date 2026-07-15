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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_imp_budget_ordini_aperti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_imp_budget_ordini_aperti]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser'amm' 
--setuser 'amministrazione' 
-- exp_imp_budget_ordini_aperti 2025
CREATE  PROCEDURE  [exp_imp_budget_ordini_aperti](
	@ayear 			int 
) 
AS BEGIN

DECLARE @sql NVARCHAR(MAX)

SET @sql = N'
WITH contratto(contratto, esercizio, numero, idepexp, description)
AS
(
	select mk.description, m.yman, m.nman, md.idepexp, m.description
	from mandatedetail md
	join mandate m ON m.idmankind = md.idmankind and m.yman = md.yman and m.nman = md.nman
	join mandatekind mk ON m.idmankind = mk.idmankind
	group by mk.description, m.yman, m.nman, md.idepexp, m.description
)
SELECT
    epexp.yepexp [Eserc. Impegno Budget],
    epexp.nepexp [Num. Impegno Budget],
    epexp.description [Descr. Impegno Budget],
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
    epexp.flagvariation [Nota di variazione],
    ET.curramount [' + CAST(@ayear AS NVARCHAR(4)) + '],
    case when epexp.nphase = 1 then ET.available else null end [Disp. ' + CAST(@ayear AS NVARCHAR(4)) + '],
    ET.curramount2 [' + CAST(@ayear + 1 AS NVARCHAR(4)) + '],
    case when epexp.nphase = 1 then ET.available2 else null end [Disp. ' + CAST(@ayear + 1 AS NVARCHAR(4)) + '],
    ET.curramount3 [' + CAST(@ayear + 2 AS NVARCHAR(4)) + '],
    case when epexp.nphase = 1 then ET.available3 else null end [Disp. ' + CAST(@ayear + 2 AS NVARCHAR(4)) + '],
    ET.curramount4 [' + CAST(@ayear + 3 AS NVARCHAR(4)) + '],
    case when epexp.nphase = 1 then ET.available4 else null end [Disp. ' + CAST(@ayear + 3 AS NVARCHAR(4)) + '],
    ET.curramount5 [' + CAST(@ayear + 4 AS NVARCHAR(4)) + '],
    case when epexp.nphase = 1 then ET.available5 else null end [Disp. ' + CAST(@ayear + 4 AS NVARCHAR(4)) + '],
    case when epexp.nphase = 2 then
        isnull(ET.curramount,0)+isnull(ET.curramount2,0)+isnull(ET.curramount3,0)+isnull(ET.curramount4,0)+isnull(ET.curramount5,0)-
        (case when epexp.flagvariation =''N'' 
                    then ISNULL(ET.cost,0)
                    else -ISNULL(ET.cost,0)
        end)     
        else null
    end [Disp.per Costi],
    epexp.adate [Data contabile],
    epexp.start [Inizio Competenza],
    epexp.stop [Fine Competenza],
    epexp.doc [Documento],
    epexp.docdate [Data Documento],
    case when epexp.nphase = 2 then
            case when epexp.flagvariation =''N'' 
                    then ISNULL(ET.cost,0)
                    else -ISNULL(ET.cost,0)
            end         
        else null
    end [Costi totali],
    case when epexp.nphase = 2 then
        case when epexp.flagvariation =''N'' 
                    then     ISNULL(ISNULL(ET.debit,0),0)
                    else     -ISNULL(ET.debit,0)
        end 
        else null
    end [Debiti totali],
    isnull(EY.amount,0)+isnull(EY.amount2,0)+isnull(EY.amount3,0)+isnull(EY.amount4,0)+isnull(EY.amount5,0) [Totale Iniziale Pluriennale],
    case when epexp.nphase = 1 then
            isnull(ET.available,0)+isnull(ET.available2,0)+isnull(ET.available3,0)+isnull(ET.available4,0)+isnull(ET.available5,0)
        else 
            null
    end    [Totale Disp. Pluriennale],
    isnull(ET.curramount,0)+isnull(ET.curramount2,0)+isnull(ET.curramount3,0)+isnull(ET.curramount4,0)+isnull(ET.curramount5,0) [Totale Corrente Pluriennale]
FROM epexp
left outer JOIN registry ON epexp.idreg= registry.idreg
join epexpyear EY on epexp.idepexp= EY.idepexp
join epexptotal ET on ET.idepexp= EY.idepexp and EY.ayear=ET.ayear
join account A on EY.idacc=A.idacc
join upb U on U.idupb=EY.idupb
left outer join epexp par on epexp.paridepexp=par.idepexp
left outer join manager on manager.idman= epexp.idman
LEFT OUTER JOIN accmotive ON accmotive.idaccmotive = epexp.idaccmotive
left join contratto c on c.idepexp = epexp.idepexp
WHERE epexp.yepexp = ' + CAST(@ayear AS NVARCHAR(4)) + '
and epexp.nphase = 2
order by epexp.yepexp, epexp.nepexp'

EXEC sp_executesql @sql

END