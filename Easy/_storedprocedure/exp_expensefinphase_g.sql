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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_expensefinphase_g]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_expensefinphase_g]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser'amministrazione' 
 
CREATE PROCEDURE [exp_expensefinphase_g]
@ayear int,
@start datetime,
@stop  datetime,
@idupb varchar(36),
@showchildupb char(1),
@codefin varchar(50),
@idman int,
@nphase tinyint,
@sintesi char(1),
@idsor01 int = null,
@idsor02 int = null,
@idsor03 int = null,
@idsor04 int = null,
@idsor05 int = null	 

AS BEGIN 
--	exec exp_expensefinphase_g '2013', {ts '2013-01-01 00:00:00.000'}, {ts '2013-11-06 00:00:00.000'}, '%', 'N', null, null,1,'S' 
SET @codefin = ISNULL(@codefin,'')+'%'
IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb+'%' 
END


/*
Aggiunto il parametro alla sp in seguito al task 5002.
DECLARE @finphase tinyint
SELECT @finphase = appropriationphasecode FROM config WHERE ayear = @ayear
IF @finphase IS NULL
BEGIN
	SELECT @finphase = expensefinphase FROM uniconfig
END
*/

if (@sintesi ='N')
BEGIN
SELECT
ayear [Esercizio]
,EXPENSEVIEW.codeupb [UPB]
,EXPENSEVIEW.upb [Denominazione UPB]
,manager [Responsabile]
,phase [Fase]
,ymov [Eser. Mov.]
,nmov [Num. Mov.] 
,codefin [Cod. Bilancio]
,finance [Den. Bilancio]
,registry [Percipiente]
,adate [Data Movimento]
,description [Descrizione]
,doc	[Documento Collegato]
,docdate [Data Doc. Collegato]
,curramount	[Importo Movimento]
	,CASE
		when npay is null then available
		when npay is not null then 0
	End [Disp. Movimento]
,ypay [Eser. Mandato]
,npay [Num. Mandato]
,paymentadate [Data Mandato]
,service [Prestazione]
	,CASE
		when flagarrear='C' then 'Competenza'
		when flagarrear='R' then 'Residui'
	End [Conto C/R]
,transmissiondate [Data Trasmissione in Banca]
,npaymenttransmission [Num. Distinta Trasm.] 
,UPB.start  [Data inizio UPB]
,UPB.stop  [Data Fine UPB]
,UPB.cupcode   [CUP UPB]
FROM EXPENSEVIEW
LEFT OUTER JOIN UPB on UPB.idupb =  EXPENSEVIEW.idupb
WHERE adate BETWEEN @start AND @stop 
	AND ((nphase = @nphase) OR (@nphase is null))
	AND ayear = @ayear 
	AND codefin LIKE @codefin 
	AND (EXPENSEVIEW.idman = @idman or @idman is null)
	AND (EXPENSEVIEW.idupb LIKE @idupb)
	AND (@idsor01 IS NULL OR EXPENSEVIEW.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR EXPENSEVIEW.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR EXPENSEVIEW.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR EXPENSEVIEW.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR EXPENSEVIEW.idsor05 = @idsor05)
END

ELSE /*VERSIONE SINTETICA*/
BEGIN
SELECT
ayear [Esercizio]
,EXPENSEVIEW.codeupb [UPB]
,EXPENSEVIEW.upb	[Denominazione UPB]
,manager [Responsabile]
,phase [Fase]
--,ymov [Eser. Mov.]
--,nmov [Num. Mov.] 
,codefin [Cod. Bilancio]
--,finance [Den. Bilancio]
,registry [Percipiente]
,adate [Data Movimento]
,description [Descrizione]
,doc	[Documento Collegato]
,docdate [Data Doc. Collegato]
,curramount	[Importo Movimento]
--	,CASE
--		when npay is null then available
--		when npay is not null then 0
--	End [Disp. Movimento]
--,ypay [Eser. Mandato]
,npay [Num. Mandato]
,paymentadate [Data Mandato]
--,service [Prestazione]
--	,CASE
--		when flagarrear='C' then 'Competenza'
--		when flagarrear='R' then 'Residui'
--	End [Conto C/R]
,transmissiondate [Data Trasmissione in Banca]
,UPB.start  [Data inizio UPB]
,UPB.stop  [Data Fine UPB]
,UPB.cupcode   [CUP UPB]
--,npaymenttransmission [Num. Distinta Trasm.]
FROM EXPENSEVIEW
LEFT OUTER JOIN UPB on UPB.idupb =  EXPENSEVIEW.idupb
WHERE adate BETWEEN @start AND @stop 
	AND ((nphase = @nphase) OR (@nphase is null))
	AND ayear = @ayear 
	AND codefin LIKE @codefin 
	AND (EXPENSEVIEW.idman = @idman or @idman is null)
	AND (EXPENSEVIEW.idupb LIKE @idupb)
	AND (@idsor01 IS NULL OR EXPENSEVIEW.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR EXPENSEVIEW.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR EXPENSEVIEW.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR EXPENSEVIEW.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR EXPENSEVIEW.idsor05 = @idsor05)
END

END



GO


