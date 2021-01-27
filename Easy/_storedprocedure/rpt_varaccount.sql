
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


--setuser 'amministrazione'

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_varaccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_varaccount]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--rpt_varaccount 2019,1,1
CREATE   PROCEDURE rpt_varaccount
	@yvar          	int, 
	@nvarbegin   	int,
	@nvarend     	int,
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null,
	@showcentridicosto char(1)
	AS
BEGIN

DECLARE @idsortingkind1 int
DECLARE @idsortingkind2 int
DECLARE @idsortingkind3 int
SELECT	@idsortingkind1 = idsortingkind1,	@idsortingkind2 = idsortingkind2,	@idsortingkind3 = idsortingkind3	FROM config WHERE ayear = @yvar

DECLARE @sortingkind1 varchar(50)
SELECT  @sortingkind1 = description FROM sortingkind WHERE idsorkind = @idsortingkind1

DECLARE @sortingkind2 varchar(50)
SELECT  @sortingkind2 = description FROM sortingkind WHERE idsorkind = @idsortingkind2

DECLARE @sortingkind3 varchar(50)
SELECT  @sortingkind3 = description FROM sortingkind WHERE idsorkind = @idsortingkind3


if ( @showcentridicosto ='S')
-- Estrae tutte le info, come in origine
	Begin
	SELECT  
		accountvar.yvar,
		accountvar.nvar,
		accountvardetail.rownum,
		accountvar.description,
		accountvar.enactment,
		accountvar.nenactment,
		CONVERT(Datetime, accountvar.enactmentdate) as enactmentdate,--ho fetto il convert perchè il crystal il type date lo intende come string 
		CONVERT(Datetime, accountvar.adate) as adate,
		accountvarstatus.description as accountvarstatus,
		case when (accountvar.variationkind = 5) then 'Richiesta Previsione di Budget' else variationkind.description end  as variationkind,
		upb.codeupb,
		upb.title as upb,
		account.codeacc,
		account.title as account,
		CASE 		when (( account.flagaccountusage & 64) = 0)  then 'N'  ELSE 'S' END as costi,  
		CASE 		when (( account.flagaccountusage & 128) = 0)  then 'N'  ELSE 'S' END as ricavi,  
		CASE 		when (( account.flagaccountusage & 256) = 0)  then 'N'  ELSE 'S' END as immobilizzazioni, 
		accountvardetail.description as detaildescription,
		ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount, 2) as amount,
		ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount2, 2) as amount2,
		ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount3, 2) as amount3,
		ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount4, 2) as amount4,
		ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount5, 2) as amount5,
		manager.title as manager,
		@sortingkind1 as sortingkind1, S1.sortcode as sortcode1, S1.description as description1,
		@sortingkind2 as sortingkind2, S2.sortcode as sortcode2, S2.description as description2,
		@sortingkind3 as sortingkind3, S3.sortcode as sortcode3, S3.description as description3
			FROM accountvar 
			JOIN accountvardetail		ON accountvar.yvar = accountvardetail.yvar AND accountvar.nvar = accountvardetail.nvar
			JOIN upb					ON accountvardetail.idupb = upb.idupb		
			JOIN account 				ON accountvardetail.idacc = account.idacc
			JOIN accountvarstatus		ON accountvarstatus.idaccountvarstatus = accountvar.idaccountvarstatus
			JOIN variationkind			ON variationkind.idvariationkind = accountvar.variationkind
			left outer join manager		on accountvar.idman = manager.idman
			left outer join costpartition				on costpartition.idcostpartition = accountvardetail.idcostpartition
			left outer join costpartitiondetail			on costpartition.idcostpartition = costpartitiondetail.idcostpartition
			LEFT OUTER JOIN sorting S1			on isnull(accountvardetail.idsor1, costpartitiondetail.idsor1) = S1.idsor  														
			LEFT OUTER JOIN sorting S2			on isnull(accountvardetail.idsor2,costpartitiondetail.idsor2) = S2.idsor  														
			LEFT OUTER JOIN sorting S3			on isnull(accountvardetail.idsor3, costpartitiondetail.idsor3) = S3.idsor 
			WHERE
				accountvar.yvar = @yvar
				AND ((accountvar.nvar BETWEEN @nvarbegin AND @nvarend) OR 
		     			 (@nvarbegin IS NULL) OR (@nvarend IS NULL))
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)		     	     
			ORDER BY accountvar.nvar
	end
if ( @showcentridicosto ='N')
-- Estrae tutte le info, come era in origine
	Begin
	
	SELECT  
		accountvar.yvar,
		accountvar.nvar,
		accountvar.description,
		accountvar.enactment,
		accountvar.nenactment,
		CONVERT(Datetime, accountvar.enactmentdate) as enactmentdate,--ho fetto il convert perchè il crystal il type date lo intende come string 
		CONVERT(Datetime, accountvar.adate) as adate,
		accountvarstatus.description as accountvarstatus,
		case when (accountvar.variationkind = 5) then 'Richiesta Previsione di Budget' else variationkind.description end  as variationkind,
		upb.codeupb,
		upb.title as upb,
		account.codeacc,
		account.title as account,
		CASE 		when (( account.flagaccountusage & 64) = 0)  then 'N'  ELSE 'S' END as costi,  
		CASE 		when (( account.flagaccountusage & 128) = 0)  then 'N'  ELSE 'S' END as ricavi,  
		CASE 		when (( account.flagaccountusage & 256) = 0)  then 'N'  ELSE 'S' END as immobilizzazioni,  
		accountvardetail.description as detaildescription,
		sum( accountvardetail.amount ) as amount,
		sum( accountvardetail.amount2 ) as amount2,
		sum( accountvardetail.amount3 ) as amount3,
		sum( accountvardetail.amount4 ) as amount4,
		sum( accountvardetail.amount5 ) as amount5,		
		manager.title as manager,
		null as sortingkind1, null as sortcode1,  null as description1,
		null as sortingkind2, null as sortcode2,  null as description2,
		null as sortingkind3, null as sortcode3,  null as description3
			FROM accountvar 
			JOIN accountvardetail		ON accountvar.yvar = accountvardetail.yvar AND accountvar.nvar = accountvardetail.nvar
			JOIN upb					ON accountvardetail.idupb = upb.idupb		
			JOIN account 				ON accountvardetail.idacc = account.idacc
			JOIN accountvarstatus		ON accountvarstatus.idaccountvarstatus = accountvar.idaccountvarstatus
			JOIN variationkind			ON variationkind.idvariationkind = accountvar.variationkind
			left outer join manager		on accountvar.idman = manager.idman
			WHERE
				accountvar.yvar = @yvar
				AND ((accountvar.nvar BETWEEN @nvarbegin AND @nvarend) OR 
		     			 (@nvarbegin IS NULL) OR (@nvarend IS NULL))
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)		     	     
			
	group by 
accountvar.yvar, accountvar.nvar, accountvar.description, accountvar.enactment, accountvar.nenactment,
		accountvar.enactmentdate, accountvar.adate, accountvarstatus.description,variationkind.description,
		accountvar.variationkind,
		upb.codeupb, upb.title,	account.codeacc,
		account.title, account.flagaccountusage, accountvardetail.description,	manager.title
ORDER BY accountvar.nvar
	end

END







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

