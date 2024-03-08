
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_compensi_no_epexp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_compensi_no_epexp]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser'amm'inistrazione
--exec exp_compensi_no_epexp 2016
CREATE   PROCEDURE [exp_compensi_no_epexp]
(
	@ayear int
)
AS BEGIN


--Terzo controllo: Compensi senza movimenti di budget
--Esportare tutti i compensi che hanno il flag ‘Considera eseguito quindi pagabile’ ma che non hanno generato
--l’impegno di budget e la scrittura in EP. 
--Esportare i compensi senza il flag ‘Considera eseguito quindi pagabile’ che non abbiano l’upb 
--e la causale di costo/debito (in quanto generanno gli impegni di budget nell’esercizio in cui sarà apposto il flag)
 
SELECT 
		'Contratto occasionale' as 'Documento',ycon as 'Esercizio',ncon as 'Numero', description as 'Descrizione', null as 'Anno Fiscale', null as 'Cedolino',
		adate as 'Data Contabile',registry as 'Anagrafica',service as 'Prestazione', start as 'Inizio', stop as 'Fine',total as 'Compenso Lordo', datecompleted as 'Completato il',
		case 
			when ( year(stop) = @ayear and ISNULL(completed,'N') = 'N' and casualcontractview.idupb IS NULL AND casualcontractview.idaccmotive IS NULL)
				then 'Scrittura/impegno non generati perchè costo non di competenza dell''esercizio'
			when ( year(stop) = @ayear and ISNULL(completed,'N') = 'S')
				THEN 'Scrittura/impegno non generati sebbene la prestazione sia stata eseguita (flag "Considera eseguito e quindi pagabile" valorizzato)'
			else null
		end as 'Errore'
from casualcontractview where not exists
(select * from entry 
		 where idrelated = 'cascon' + '§' + convert(varchar(4),ycon) + '§'  + convert(varchar(14),ncon)
)
and not exists
(select * from epexp 
		 where idrelated = 'cascon' + '§' + convert(varchar(4),ycon) + '§'  + convert(varchar(14),ncon)
)
AND ycon = @ayear  
 
UNION 
SELECT 
		'Compenso a dipendente' as 'Dcoumento',ycon as 'Esercizio',ncon as 'Numero',description as 'Descrizione',  null as 'Anno Fiscale',null as 'Cedolino',
		adate as 'Data',registry as 'Anagrafica',service as 'Prestazione', start as 'Inizio', stop as 'Fine',feegross as 'Compenso Lordo',null as 'Completato il',
		case 
			when ( year(stop) = @ayear and ISNULL(completed,'N') = 'N' and wageadditionview.idupb IS NULL AND wageadditionview.idaccmotive IS NULL)
				then 'Scrittura/impegno non generati perchè costo non di competenza dell''esercizio'
			when ( year(stop) = @ayear and ISNULL(completed,'N') = 'S')
				THEN 'Scrittura/impegno non generati sebbene la prestazione sia stata eseguita (flag "Considera eseguito e quindi pagabile" valorizzato)'
			else null
		end as 'Errore'
from wageadditionview where not  exists
(select * from entry 
		 where idrelated = 'wageadd' + '§' + convert(varchar(4),ycon) + '§'  + 
		 convert(varchar(14),ncon)
)
AND not  exists
(select * from epexp 
		 where idrelated = 'wageadd' + '§' + convert(varchar(4),ycon) + '§'  + 
		 convert(varchar(14),ncon)
)
AND ycon = @ayear
 

UNION
SELECT 
		'Missione' as 'Documento', yitineration as 'Esercizio', nitineration as 'Numero',description as 'Descrizione', null as 'Anno Fiscale',null as 'Cedolino',
		adate as 'Data Contabile', registry as 'Anagrafica', service as 'Prestazione',start as 'Inizio', stop as 'Fine',totalgross as 'Compenso Lordo',datecompleted as 'Completato il', 
		case 
			when ( year(stop) = @ayear and ISNULL(completed,'N') = 'N' and itinerationview.idupb IS NULL AND itinerationview.idaccmotive IS NULL)
				then 'Scrittura/impegno non generati perchè costo non di competenza dell''esercizio'
			when ( year(stop) = @ayear and ISNULL(completed,'N') = 'S')
				THEN 'Scrittura/impegno non generati sebbene la missione sia stata eseguita (flag "Considera eseguito e quindi pagabile" valorizzato)'
			else null
		end
from itinerationview where  not exists
(select * from entry where idrelated = 'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 
	convert(varchar(14),nitineration)
)
and
  not exists
(select * from epexp where idrelated = 'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 
	convert(varchar(14),nitineration)
)
AND yitineration = @ayear and itinerationview.datecompleted is not null
 
UNION
 
SELECT 
		'Cedolino di Contratto Parasubordinati' as 'Documento',  C.ycon as 'Esercizio', C.ncon as 'Numero', NULL as 'Descrizione',C.fiscalyear as 'Anno fiscale', C.npayroll as 'Cedolino', 
		NULL as 'Data Contabile', C.registry as 'Anagrafica', C.service as 'Prestazione',C.start as 'Inizio', C.stop as 'Fine', feegross as 'Compenso Lordo',null as 'Completato il',
		case 
			when  (ISNULL(flagcomputed,'N') = 'N'  and year(C.stop)=@ayear )
				then 'Scrittura/impegno non generata perchè cedolino non calcolato' 
			when year(C.stop)<>@ayear 
				then 'Scrittura/impegno non generata perchè costo non di competenza dell''esercizio'
		else null
		end as 'Errore'
from payrollview C
where not  exists
(select * from entry where idrelated = 'payroll' + '§' + convert(varchar(5),C.idpayroll) + '§'  + 
		convert(varchar(4),C.fiscalyear) + '§'  + convert(varchar(14),C.npayroll))
and not  exists
(select * from epexp where idrelated = 'payroll' + '§' + convert(varchar(5),C.idpayroll) + '§'  + 
		convert(varchar(4),C.fiscalyear) + '§'  + convert(varchar(14),C.npayroll))
AND fiscalyear = @ayear
AND C.flagbalance<>'S'
 
 
 UNION

SELECT 'Import Stipendi da CSA' as 'Documento',   yimport as 'Esercizio', nimport as 'Numero', description  as 'Descrizione',null as 'Anno Fiscale', null as 'Cedolino',
adate as 'Data Contabile', null as 'Anagrafica', null as 'Prestazione', null as 'Inizio', null as 'Fine', null as 'Compenso Lordo',null as 'Completato il',
'Scrittura o Impegni di Budget non generati' as 'Errore'
from csa_import where not exists
(select * from entry where idrelated = 'csa_import' + '§' + convert(varchar(4),yimport) + '§'  + 
	convert(varchar(14),nimport)
)
and not exists
(select * from epexp where idrelated = 'csa_import' + '§' + convert(varchar(4),yimport) + '§'  + 
	convert(varchar(14),nimport)
)
AND yimport = @ayear
 

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
