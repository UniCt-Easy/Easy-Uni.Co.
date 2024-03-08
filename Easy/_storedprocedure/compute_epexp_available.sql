
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_epexp_available]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_epexp_available]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
if not exists (select * from systypes where name = 'epexp_list') begin 
	CREATE TYPE dbo.epexp_list AS TABLE   (idepexp int, childsamount decimal(19,2))  
end
GO

CREATE        PROCEDURE [compute_epexp_available]
(
	@ayear int,
	@lista_idepexp dbo.epexp_list  READONLY 
)
AS BEGIN
--setuser 'amministrazione'
--setuser 'amm'
 
-------------------------------------------------------------------------------------------
---  STORED PROCEDURE PER IL CALCOLO DELLA PREVISIONE DISPONIBILE PREIMPEGNO DI BUDGET  ---
-------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------- 
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
	idepexp int,
	yepexp int,
	nepexp int,
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
	idepexp,
	yepexp,
	nepexp,
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
	epexp.idepexp,
	epexp.yepexp,
	epexp.nepexp,
	epexp.description,
    ISNULL(epexptotal.curramount,0),
	ISNULL( [@lista_idepexp].childsamount,0),
	ISNULL(epexptotal.available,0) - ISNULL( [@lista_idepexp].childsamount,0),
	ISNULL(epexptotal.curramount2,0),
	ISNULL(epexptotal.curramount3,0),
	ISNULL(epexptotal.curramount4,0),
	ISNULL(epexptotal.curramount5,0),
	ISNULL(epexptotal.available,0),
	ISNULL(epexptotal.available2,0),
	ISNULL(epexptotal.available3,0),
	ISNULL(epexptotal.available4,0),
	ISNULL(epexptotal.available5,0)
	FROM epexp
	JOIN epexpyear ON epexpyear.idepexp = epexp.idepexp AND epexpyear.ayear = @ayear 
	JOIN epexptotal ON epexpyear.idepexp = epexptotal.idepexp AND epexptotal.ayear = @ayear 
	JOIN account			ON epexpyear.idacc = account.idacc
	JOIN upb				ON epexpyear.idupb = upb.idupb
	JOIN @lista_idepexp	ON   [@lista_idepexp].idepexp = epexp.idepexp
	WHERE (ISNULL(epexptotal.available,0) - ISNULL( [@lista_idepexp].childsamount,0)) < 0
 
 SELECT 
	codeacc as 'Cod. conto',
	account as 'Conto',
	codeupb as 'Cod. Upb',
	upb as 'Upb',
	yepexp as 'Eserc. Preimpegno',
	nepexp as 'Num. Preimpegno',
	description as 'Descr. Preimpegno',
	ISNULL(curramount,0) as 'Imp. Corrente Preimpegno', 
	ISNULL(totamount,0) as 'Importo Impegni da generare',
	ISNULL(available,0) as 'Disponibile Preimpegno Budget',
	ISNULL(newavailable,0) as 'Nuovo Disponibile Preimpegno Budget'
FROM #result

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


