
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_epacc_available]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_epacc_available]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
if not exists (select * from systypes where name = 'epacc_list') begin 
	CREATE TYPE dbo.epacc_list AS TABLE   (idepacc int, childsamount decimal(19,2))  
end
GO

 
CREATE        PROCEDURE [compute_epacc_available]
(
	@ayear int,
	@lista_idepacc dbo.epacc_list  READONLY 
)
AS BEGIN
--setuser 'amministrazione'
--setuser 'amm'
 
------------------------------------------------------------------------------------------------
---  STORED PROCEDURE PER IL CALCOLO DELLA PREVISIONE DISPONIBILE PREACCERTAMENTO DI BUDGET  ---
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------ 
--sp_help upb

-- Tabella dei pagamenti
CREATE TABLE #result
(
	idacc varchar(38), 
	codeacc varchar(50),
	account varchar(150),
	idupb varchar(36),
	codeupb varchar(50),
	upb varchar(150),
	idepacc int,
	yepacc int,
	nepacc int,
	description varchar(150),
	curramount decimal(19,2),
	totamount decimal(19,2),
	newavailable decimal(19,2),
	curramount2 decimal(19,2),
	curramount3 decimal(19,2),
	curramount4 decimal(19,2),
	curramount5 decimal(19,2),
	available	decimal(19,2),
	available2 decimal(19,2),
	available3 decimal(19,2),
	available4 decimal(19,2),
	available5 decimal(19,2)
)


INSERT INTO #result
(
	idacc, 
	codeacc,
	account,
	idupb,
	codeupb,
	upb,
	idepacc,
	yepacc,
	nepacc,
	description,
	curramount,
	totamount,
	newavailable,
	curramount2,
	curramount3,
	curramount4,
	curramount5,
	available,
	available2,
	available3,
	available4,
	available5
)
SELECT  DISTINCT
	account.idacc,
	account.codeacc,
	account.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	epacc.idepacc,
	epacc.yepacc,
	epacc.nepacc,
	epacc.description,
    ISNULL(epacc.curramount,0),
	isnull([@lista_idepacc].childsamount,0),
	ISNULL(epacctotal.available,0) - isnull([@lista_idepacc].childsamount,0),
	ISNULL(epacctotal.curramount2,0),
	ISNULL(epacctotal.curramount3,0),
	ISNULL(epacctotal.curramount4,0),
	ISNULL(epacctotal.curramount5,0),
	ISNULL(epacctotal.available,0),
	ISNULL(epacctotal.available2,0),
	ISNULL(epacctotal.available3,0),
	ISNULL(epacctotal.available4,0),
	ISNULL(epacctotal.available5,0)
	FROM epacc
	JOIN epaccyear		ON epaccyear.idepacc = epacc.idepacc AND epaccyear.ayear = @ayear 
	JOIN epacctotal		ON epaccyear.idepacc = epacctotal.idepacc AND epacctotal.ayear = @ayear 
	JOIN account  		ON epaccyear.idacc = account.idacc
	JOIN upb			ON epaccyear.idupb = upb.idupb
	JOIN @lista_idepacc 	ON   [@lista_idepacc].idepacc = epacc.idepacc
		WHERE (ISNULL(epacctotal.available,0) - isnull([@lista_idepacc].childsamount,0)) < 0

		
 SELECT 
	codeacc as 'Cod. conto',
	account as 'Conto',
	codeupb as 'Cod. Upb',
	upb as 'Upb',
	yepacc as 'Eserc. Preaccertamento',
	nepacc as 'Num. Preaccertamento',
	description as 'Descr. Preaccertamento',
	ISNULL(curramount,0) as 'Importo. Corrente Preacc.', 
	ISNULL(totamount,0) as 'Importo Accertamenti',
	ISNULL(available,0) as 'Prev. Disponibile',
	ISNULL(newavailable,0) as 'Nuova Prev. Disponibile'
FROM #result
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


