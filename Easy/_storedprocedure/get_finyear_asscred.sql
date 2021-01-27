
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



if exists (select * from dbo.sysobjects where id = object_id(N'[get_finyear_asscred]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure get_finyear_asscred
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE      PROCEDURE get_finyear_asscred(
	@ayear int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
)

as BEGIN


CREATE TABLE #previsioni(codefin varchar(50), codeupb varchar(50), idupb varchar(36), idfin int, part char(1), prevision decimal(19,2), fin varchar(150), upb varchar(150), idrow int IDENTITY(1,1))

insert into #previsioni(codefin, codeupb, prevision, part, idupb, idfin, fin, upb)
	select F.codefin, U.codeupb,  FY.prevision, 
   		CASE
			when (( F.flag & 1)=0) then 'E'
			when (( F.flag & 1)<>0) then 'S'
		End as 'part',
		FY.idupb,	-- as 'InternalCodeUpb',
		FY.idfin,	-- as 'InternalCodeBilancio'
		F.title as fin,
		U.title as upb
	from finyear FY
	join finlast FL
		on FY.idfin=FL.idfin
	join fin F
		on F.idfin = FL.idfin
	join upb U
		on FY.idupb = U.idupb
	where FY.ayear = @ayear
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	/*and /*Se spesa, chiama: ct_get_income_asscred*/
	(F.flag &1<>0 and (select  count(*)
				from ct_asscred C 
				join ct_asscreddetail D
					on C.idct_asscred = D.idct_asscred
				join sorting S
					on S.idsor = C.idsor 
				join sortinglink
					on sortinglink.idparent = S.idsor 
				join upbsorting US
					on sortinglink.idchild = US.idsor
				where  US.idupb = FY.idupb and D.idfin_expense = FY.idfin) >0
	OR /*Se entrata, chiama: ct_get_expense_asscred*/
	F.flag &1=0 and (select count(*)
				from ct_asscred C 
				join ct_asscreddetail D
					on C.idct_asscred = D.idct_asscred
				join sorting S
					on S.idsor = C.idsor 
				join sortinglink
					on sortinglink.idparent = S.idsor 
				join upbsorting US
					on sortinglink.idchild = US.idsor
				where  US.idupb = FY.idupb and C.idfin_income = FY.idfin)>0
	)*/
-- Se spesa, chiama: ct_get_countincome_asscred
DECLARE	@idupb varchar(36)
DECLARE @idfin_expense int
DECLARE @idfin_income int
DECLARE @part char(1)
declare @x int

DECLARE rowcursor_exp INSENSITIVE CURSOR FOR
		SELECT idupb, idfin  
		FROM #previsioni
		where part = 'S'
		FOR READ ONLY
	OPEN rowcursor_exp FETCH  NEXT FROM rowcursor_exp 
	INTO @idupb, @idfin_expense
	WHILE @@FETCH_STATUS = 0
		BEGIN 
			exec ct_get_countincome_asscred @idupb, @idfin_expense, @x out
			if isnull(@x,0 ) =0
				begin
					delete from #previsioni where idfin = @idfin_expense and idupb = @idupb
				end	
		FETCH NEXT FROM rowcursor_exp INTO @idupb, @idfin_expense
		END 
	DEALLOCATE rowcursor_exp

DECLARE rowcursor_inc INSENSITIVE CURSOR FOR
		SELECT idupb, idfin  
		FROM #previsioni
		where part = 'E'
		FOR READ ONLY
	OPEN rowcursor_inc FETCH  NEXT FROM rowcursor_inc 
	INTO @idupb, @idfin_income
	WHILE @@FETCH_STATUS = 0
		BEGIN 
			exec ct_get_countexpense_asscred @idupb, @idfin_income, @x out
			if isnull(@x,0 ) =0
				begin
					delete from #previsioni where idfin = @idfin_income and idupb = @idupb
				end	
		FETCH NEXT FROM rowcursor_inc INTO @idupb, @idfin_income
		END 
	DEALLOCATE rowcursor_inc


select idrow, codefin, fin,  codeupb, upb, prevision, part, idupb, idfin from #previsioni
WHERE isnull(prevision,0)<>0

END

GO


-- exec get_finyear_asscred 2016, null, null, null, null, null
 
 
