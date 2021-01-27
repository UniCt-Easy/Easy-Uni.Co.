
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




if exists (select * from dbo.sysobjects where id = object_id(N'[exp_verificalimiti_vocibilancio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_verificalimiti_vocibilancio]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [exp_verificalimiti_vocibilancio]
(@ayear int)
AS BEGIN
SELECT  
    fin.ayear as 'Esercizio',
    upb.codeUpb as 'Codice UPB',
    upb.title as 'Descrizione UPB',
	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End as 'E/S',
	fin.codeFin as 'Voce di Bilancio',
    fin.title as 'Descrizione voce di bilancio',
	finyear.limit as 'Limite',  
	sorting.sortcode as 'Attributo di sicurezza',
	upb.idupb as 'IDUPB'
FROM finyear 
 JOIN fin ON finyear.idfin = fin.idfin
 JOIN upb ON finyear.idupb = upb.idupb
 JOIN sorting ON sorting.idsor = upb.idsor01
 WHERE (finyear.ayear = @ayear and ISNULL(finyear.limit,0) > 0 ) 
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
