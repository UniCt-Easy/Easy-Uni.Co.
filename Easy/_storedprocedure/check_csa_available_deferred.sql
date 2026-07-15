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

if exists (select * from dbo.sysobjects where id = object_id(N'[check_csa_available_deferred]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_csa_available_deferred]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE  PROCEDURE [check_csa_available_deferred]
(
	@ayear		  int,   --- esercizio originale dell'importazione CSA (corrisponde all'esercizio precedente per i pagamenti posticipati)
	@kind		  char(1) -- L-> Lordi || V-> Versamenti
)
AS BEGIN

/*
setuser 'amm'
setuser 'amministrazione'
exec [check_csa_available_deferred] 2019, 'L'
*/
 
--SET      @res = 0	
CREATE TABLE #errors (errordescr varchar(255), errorcode int, blockingerror char(1))
         
IF ((SELECT COUNT(*) FROM csa_movfin_deferred_parentview where parentayear = @ayear 
AND  (
		 (@kind = 'L'  AND var_autokind = 33)  --lordi posticipati
		 OR
		 (@kind = 'V'  OR  var_autokind = 32)  --versamenti posticipati
	 )
AND available<0 ) > 0) 
--25) Movimenti padre con disponibile insufficiente
BEGIN
	INSERT INTO #errors VALUES('Movimenti padre con disponibile insufficiente' , 1,'S')
END  
SELECT * FROM #errors

END

 
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 