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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_historyproceeds]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_historyproceeds]
GO
--setuser 'amministrazione'
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec exp_historyproceeds 2024, {d '2024-12-15'}, null
CREATE    PROCEDURE [exp_historyproceeds]
	@ayear 		int,
	@date 		datetime,
	@idtreasurer int --,
	--@documentiesitati char(1) --Considera tutti i mandati e reversali dell'esercizio esitati nell'esercizio

AS BEGIN

SELECT
	hpv.ymov as 'Esercizio Movimento',
	hpv.nmov as 'Numero Movimento',
	hpv.adate as 'Data Movimento',
	sum(hpv.amount) as 'Importo',
	isnull(
		(select sum(IV.amount)
		FROM   incomevar IV
		JOIN historyproceedsview HPV2 on HPV2.idinc = IV.idinc
		where IV.idinc = hpv.idinc
		and	IV.yvar = @ayear
		and HPV2.ymov = @ayear
		AND (HPV2.idtreasurer = @idtreasurer		 or @idtreasurer is null)		
		--AND ( (HPV2.totflag & 1) =0)-- Competenza
		AND (
		(HPV2.competencydate < @date
  			AND ( 
				((IV.autokind <> 11) AND(IV.autokind <> 10)) 
				OR IV.autokind is null
          						)
		)
		OR
		(IV.adate < @date
			AND ((IV.autokind = 11)OR(IV.autokind = 10 )) 
		) 
		)
		)
	,0)	
	as 'Variazioni',
	hpv.flagarrear as 'Tipo Movimento',
	hpv.ypro as 'Esercizio Reversale',
	hpv.npro as 'Numero Reversale',
	p.adate as 'Data Reversale',
	hpv.competencydate as 'Data Esitazione'
FROM historyproceedsview hpv
join proceeds p on p.kpro = hpv.kpro 
where hpv.competencydate < @date
and hpv.ymov = @ayear
and (hpv.idtreasurer = @idtreasurer or @idtreasurer is null)
group by hpv.ymov, hpv.nmov, hpv.adate, hpv.idinc, hpv.flagarrear, hpv.ypro, hpv.npro, p.adate, hpv.competencydate
order by hpv.competencydate, hpv.npro

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO