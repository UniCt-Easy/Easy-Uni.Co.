
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



if exists (select * from dbo.sysobjects where id = object_id(N'[compute_account_upb_prevision]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_account_upb_prevision]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
if not exists (select * from systypes where name = 'account_upb_list') begin 
	CREATE TYPE dbo.account_upb_list AS TABLE      (idacc varchar(38), idupb varchar(36),amount decimal(19,2))  
end
GO

 
CREATE        PROCEDURE [compute_account_upb_prevision]
(
	@ayear int,
	@lista_idacc_idupb dbo.account_upb_list  READONLY 
)
AS BEGIN
--setuser 'amministrazione'
--setuser 'amm'
 --select * from @lista_idacc_idupb
-- select * from config
--------------------------------------------------------------------
---  STORED PROCEDURE PER IL CALCOLO DELLA PREVISIONE CONTO UPB  ---
--------------------------------------------------------------------
-------------------------------------------------------------------- 
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
	currentprev decimal(19,2),
	totamount decimal(19,2),
	available decimal (19,2),
	currentprev2 decimal(19,2),
	currentprev3 decimal(19,2),
	currentprev4 decimal(19,2),
	currentprev5 decimal(19,2),
	previsionvariation	decimal(19,2),
	previsionvariation2 decimal(19,2),
	previsionvariation3 decimal(19,2),
	previsionvariation4 decimal(19,2),
	previsionvariation5 decimal(19,2)

)

DECLARE @min_levelusable int 
SET @min_levelusable = (select min(nlevel) from accountlevel where ayear = @ayear and (flagusable='S'))
print @min_levelusable 
CREATE TABLE #PreimpegniPreAccertamenti
(
	idacc varchar(38), 
	idupb varchar(36),
	amount decimal(19,2)
)

INSERT INTO #PreimpegniPreAccertamenti(
	idacc, 
	idupb,
	amount
)
SELECT  
	 [@lista_idacc_idupb].idacc,
	 [@lista_idacc_idupb].idupb,
	sum(epexptotal.curramount) 
	from @lista_idacc_idupb
	JOIN epexpyear ON  [@lista_idacc_idupb].idacc LIKE SUBSTRING(epexpyear.idacc, 1, 4* @min_levelusable + 2) + '%' 
					AND  [@lista_idacc_idupb].idupb  = epexpyear.idupb  
	join epexp ON epexpyear.idepexp = epexp.idepexp
	JOIN epexptotal 
		ON epexpyear.idepexp = epexptotal.idepexp AND epexptotal.ayear = @ayear 
	WHERE epexpyear.ayear = @ayear  and epexp.nphase = 1
 group by 	[@lista_idacc_idupb].idacc,	 [@lista_idacc_idupb].idupb
	
INSERT INTO #result
(
	idacc, 
	codeacc,
	account,
	idupb,
	codeupb,
	upb,
	currentprev,
	totamount,
	available,
	currentprev2,
	currentprev3,
	currentprev4,
	currentprev5,
	previsionvariation ,
	previsionvariation2,
	previsionvariation3,
	previsionvariation4,
	previsionvariation5  
)
SELECT  DISTINCT
	account.idacc,
	account.codeacc,
	account.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	ISNULL((upbaccounttotal.currentprev),0)  +ISNULL((upbaccounttotal.previsionvariation),0) -  ISNULL(#PreimpegniPreAccertamenti.amount,0), 
	isnull(SUM([@lista_idacc_idupb].amount),0),
    ISNULL((upbaccounttotal.currentprev),0) +ISNULL((upbaccounttotal.previsionvariation),0) -  ISNULL(#PreimpegniPreAccertamenti.amount,0) - isnull(SUM([@lista_idacc_idupb].amount),0),
	ISNULL(SUM(upbaccounttotal.currentprev2),0),
	ISNULL(SUM(upbaccounttotal.currentprev3),0),
	ISNULL(SUM(upbaccounttotal.currentprev4),0),
	ISNULL(SUM(upbaccounttotal.currentprev5),0),
	ISNULL(SUM(upbaccounttotal.previsionvariation),0),
	ISNULL(SUM(upbaccounttotal.previsionvariation2),0),
	ISNULL(SUM(upbaccounttotal.previsionvariation3),0),
	ISNULL(SUM(upbaccounttotal.previsionvariation4),0),
	ISNULL(SUM(upbaccounttotal.previsionvariation5),0)
	FROM @lista_idacc_idupb
	JOIN account 
		ON   [@lista_idacc_idupb].idacc LIKE SUBSTRING(account.idacc, 1, 4* @min_levelusable + 2) + '%'
	JOIN upb 
		ON  [@lista_idacc_idupb].idupb = upb.idupb
	left outer JOIN upbaccounttotal 
			ON upbaccounttotal.idacc = account.idacc	AND  upbaccounttotal.idupb = upb.idupb
	left outer join #PreimpegniPreAccertamenti
		on #PreimpegniPreAccertamenti.idacc = [@lista_idacc_idupb].idacc and #PreimpegniPreAccertamenti.idupb = [@lista_idacc_idupb].idupb
	WHERE account.nlevel = @min_levelusable  

 group by 	account.idacc,
	account.codeacc,
	account.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	upbaccounttotal.currentprev, upbaccounttotal.previsionvariation,ISNULL(#PreimpegniPreAccertamenti.amount,0)
 HAVING (   ISNULL((upbaccounttotal.currentprev),0) +ISNULL((upbaccounttotal.previsionvariation),0) -  ISNULL(#PreimpegniPreAccertamenti.amount,0) - isnull(SUM([@lista_idacc_idupb].amount),0))  < 0



 select 
	codeacc as 'Cod. conto',
	account as 'Conto',
	codeupb as 'Cod. Upb',
	upb as 'Upb',
	ISNULL(currentprev,0) as 'Budget Disponibile', 
	ISNULL(totamount,0) as 'Importo Preimpegni/PreAccertamenti',
    ISNULL(available,0) as 'Prev. Disponibile'
  from #result
  order by codeupb


	
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

