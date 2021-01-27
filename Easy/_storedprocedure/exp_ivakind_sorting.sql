
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_ivakind_sorting]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_ivakind_sorting]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 CREATE    PROCEDURE [exp_ivakind_sorting]
AS
BEGIN

	SELECT 	
	ivakind.codeivakind as 'Codice',
    ivakind.description as 'Descrizione',
    ivakind.unabatabilitypercentage*100 as '% Indetraibilità',
    ivakind.rate*100 as '% Aliquota',
	case when (flag & 1<>0) then 'S'else 'N' end as 'Attività IST.',
	case when (flag & 2<>0) then 'S'else 'N' end as 'Attività COMM.',
	case when (flag & 4<>0) then 'S'else 'N' end as 'Attività PROM.',

	case when (flag & 64<>0) then 'S'else 'N' end as 'Applicabilità Italia',
	case when (flag & 128<>0) then 'S'else 'N' end as 'Applicabilità Intra-UE',
	case when (flag & 256<>0) then 'S'else 'N' end as 'Applicabilità Extra-UE',
	sorting.sortcode as 'Cod.Classificazione',
	sorting.description as 'Descrizione Class.',
	ivakind.annotations as 'Annotazioni',
	fenature.description as 'Natura FE'
	FROM ivakind
	LEFT OUTER JOIN ivakindsorting
		on ivakind.idivakind = ivakindsorting.idivakind
	left outer join sorting
		on sorting.idsor = ivakindsorting.idsor
	left outer join fenature
		on ivakind.idfenature = fenature.idfenature
		
 

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


