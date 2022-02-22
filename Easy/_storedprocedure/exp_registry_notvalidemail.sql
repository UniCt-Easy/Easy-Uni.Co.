
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_registry_notvalidemail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_registry_notvalidemail]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE [exp_registry_notvalidemail]
(
	@ayear int
)
AS
BEGIN

SELECT distinct 
	r.idreg as "Codice", 
	r.title as 'Denominazione',
	CASE
		WHEN (r.cf is not null) THEN r.cf 
		WHEN (r.cf is null) AND (r.foreigncf is NOT NULL) THEN r.foreigncf
	END as 'Codice Fiscale',
	r.p_iva AS 'Partita Iva',
	rr.email as 'e-mail',
	case
		when ( rr.email not LIKE '_%@__%.__%') then 'E-mail malformata'
		when ( rr.email is null) then 'E-mail assente'
		/*when ( rr.email not like '%@%') then 'Manca @'
		when ( rr.email like '% %') then 'Presenza di spazi'
		when ( rr.email like '%[%' or rr.email like '%]%' or rr.email like '%(%' or rr.email like '%)%' 
				or rr.email like '%{%' or rr.email like '%}%' or rr.email like '%<%' or rr.email like '%>%') then 'Presenza di parentesi'
		else 'Ci sono caratteri non ammessi'	*/
		end
		AS 'Errore'
FROM registry r
	JOIN registryreference rr
		ON r.idreg = rr.idreg
		AND rr.flagdefault='S'
	JOIN expense		
		ON expense.idreg = R.idreg
	join expenseyear		
		on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
	JOIN expenselast EL	
		ON expenseyear.idexp = EL.idexp
	WHERE expenseyear.ayear = @ayear
	AND r.active ='S'
	and (rr.email is null or rr.email not LIKE '_%@__%.__%')

/*	and rr.email is not null
	and (
	rr.email not like '%@%' 
	or substring(rr.email, 1, PATINDEX('%@%',rr.email) -1)  like '%..'/*prima della @, tipo: nomeutente..@dominio */
	or substring(rr.email, 1, PATINDEX('%@%',rr.email) -1)  like '%.'/*prima della @, tipo: nomeutente.@dominio */
	or substring(rr.email, PATINDEX('%@%',rr.email)+1, len(rr.email)-PATINDEX('%@%',rr.email) )  like '.%'/* dopo @, tipo: nomeutente@.dominio*/
	or substring(rr.email, PATINDEX('%@%',rr.email)+1, len(rr.email)-PATINDEX('%@%',rr.email) ) like '..%'/*se dopo la @ ci sono due punti*/
	or rr.email like '%,%' or rr.email like '%*%'  or rr.email like '%;%'or rr.email like '%:%'
	or rr.email like '%[%' or rr.email like '%]%' or rr.email like '%(%' or rr.email like '%)%' 
	or rr.email like '%{%' or rr.email like '%}%' or rr.email like '%<%' or rr.email like '%>%'
	or rr.email like '%#%' or rr.email like '%€%' or rr.email like '%§%' or rr.email like '%!%'
	or rr.email like '%*%' or rr.email like '%+%' or rr.email like '%"%' or rr.email like '%''%'
	or rr.email like '%&%' or rr.email like '% %' or rr.email like '%ç%' or rr.email like '%|%'  
	or rr.email like '%£%' 
	)*/
	and EL.idser is not null
	
ORDER BY r.title

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 --exec exp_registry_notvalidemail 2017
