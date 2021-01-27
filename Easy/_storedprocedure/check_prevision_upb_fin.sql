
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[check_prevision_upb_fin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_prevision_upb_fin]
GO

CREATE    procedure check_prevision_upb_fin(
@ayear 	 smallint,
@res     int out
) as
BEGIN
--declare @outvar int
--execute check_prevision_upb_fin 2007, @outvar OUT
--print   @outvar
DECLARE  @currentdate   datetime
DECLARE  @subtractdate  datetime
DECLARE  @lastdate  	datetime
SELECT 	 @currentdate = GetDate()
SELECT   @subtractdate = @currentdate - 30  
SELECT   @lastdate    =  lastdate FROM checkprevision 
--PRINT	 @currentdate
--PRINT	 @subtractdate
--PRINT	 @lastdate
SET      @res = 0
IF (@lastdate IS NULL OR @lastdate < @subtractdate)
	BEGIN
		DECLARE @fasebil tinyint
		select @fasebil = expensefinphase FROM uniconfig
		declare @fin_kind tinyint 
		select @fin_kind= fin_kind from config where ayear=@ayear		

		if  ( ( @fin_kind & 1)  <> 0 ) BEGIN
		if exists(select FY.idfin,FY.idupb from finyear FY 
				join finlast FL 
					on FL.idfin=FY.idfin
				join fin F on FY.idfin=F.idfin
				left outer join upbtotal UT 
					on  UT.idfin=FY.idfin and UT.idupb=FY.idupb
				left outer join upbexpensetotal UET 
					on UET.idfin=FY.idfin and UET.idupb=FY.idupb and UET.nphase=@fasebil
				WHERE (isnull(UT.currentprev,0)+isnull(UT.previsionvariation,0)	
					- isnull(UET.totalcompetency,0) ) < 0
				       and fy.ayear= @ayear
				       and (F.flag&1) <> 0
			) SET @res=1
		END
		ELSE 
		BEGIN
		if exists(select FY.idfin,FY.idupb from finyear FY 
				join finlast FL 
					on FL.idfin=FY.idfin
				join fin F on FY.idfin=F.idfin
				left outer join upbtotal UT 
					on  UT.idfin=FY.idfin and UT.idupb=FY.idupb
				left outer join upbexpensetotal UET 
					on UET.idfin=FY.idfin and UET.idupb=FY.idupb and UET.nphase=@fasebil
				WHERE (isnull(UT.currentprev,0)+isnull(UT.previsionvariation,0)	
					- isnull(UET.totalcompetency,0) -isnull(UET.totalarrears,0)) < 0
				       and fy.ayear= @ayear
				       and (F.flag&1) <> 0
					
			) SET @res=1
		END



		-- esegue l'update oppure l'insert su checkprevision
		DECLARE @rowcount int
		SET     @rowcount =  (SELECT COUNT(*) FROM checkprevision)
		IF  @res = 0 
		BEGIN
			IF (@rowcount >0) 
				UPDATE  checkprevision SET lastdate = @currentdate
			ELSE 
				INSERT INTO checkprevision(lastdate)
				VALUES(@currentdate)
		END

	END 
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

