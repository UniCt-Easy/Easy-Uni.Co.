
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_csa_available_deferred]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_csa_available_deferred]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE  PROCEDURE [check_csa_available_deferred]
(
	@ayear		  int   --- esercizio originale dell'importazione CSA (corrispo9nde all'esercizio precedente per i pagamenti posticipati)
)
AS BEGIN

/*
setuser 'amm'
setuser 'amministrazione'
exec [check_csa_available_deferred] 2019
*/
 
--SET      @res = 0	
CREATE TABLE #errors (errordescr varchar(255), errorcode int, blockingerror char(1))
         
IF ((SELECT COUNT(*) FROM csa_importver_deferred_parentview where parentayear = @ayear AND available<0 ) > 0) 
--25) Movimenti padre con disponibile insufficiente
BEGIN
	INSERT INTO #errors VALUES('Movimenti padre con disponibile insufficiente' , 1,'S')
END
---DECIDIAMO DI COMMENTARE PER IL MOMENTO IL CODICE ERRORE 2)  
/*
DECLARE @fin_kind tinyint
SELECT  @fin_kind = fin_kind FROM config WHERE ayear = @ayear
 
CREATE TABLE #output_1
(
	idfin int,
	idupb varchar(36),
	phase  varchar(400),
	codefin varchar(50),
	fin varchar(400),
	codeupb varchar(50),
	upb varchar(400),
	available_1  decimal(19,2),
	available_2  decimal(19,2),
	available_3  decimal(19,2),		
	available_4  decimal(19,2)
)
CREATE TABLE #output_2
(
	idfin int,
	idupb varchar(36),
	phase  varchar(400),
	codefin varchar(50),
	fin varchar(400),
	codeupb varchar(50),
	upb varchar(400),
	available_1  decimal(19,2),
	available_2  decimal(19,2)
)
if (@fin_kind=3) begin
insert into #output_1	exec exp_csa_deferred_fin_upb_available @ayear
IF ((SELECT COUNT(*) FROM #output_1) > 0) 
--26) Coppie Bilancio - UPB con previsione disponibile insufficiente
BEGIN
	INSERT INTO #errors VALUES('Coppie Bilancio - UPB con previsione disponibile insufficiente' , 2,'N')
END 
end
else begin

insert into #output_2	exec exp_csa_deferred_fin_upb_available @ayear 
IF ((SELECT COUNT(*) FROM #output_2) > 0) 
--26) Coppie Bilancio - UPB con previsione disponibile insufficiente
BEGIN
	INSERT INTO #errors VALUES('Coppie Bilancio - UPB con previsione disponibile insufficiente' , 2,'N')
END 
end
*/

--DROP TABLE #output
--DROP TABLE #output_1   
--DROP TABLE #output_2      
SELECT * FROM #errors

END

 
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
