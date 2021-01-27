
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
 --setuser 'amm'
 --setuser 'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[trg_updatearrearsepacc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_updatearrearsepacc]
GO

CREATE  PROCEDURE [trg_updatearrearsepacc]
(
	@idmov int,
	@ayear int,
	@nphase tinyint,
	@oldidacc varchar(38),
	@idupb varchar(36),
	@amount decimal(19,2),
	@amount2 decimal(19,2),
	@amount3 decimal(19,2),
	@amount4 decimal(19,2),
	@amount5 decimal(19,2)
)
AS BEGIN

DECLARE @newidacc varchar(38)
DECLARE @newarrear decimal(19,2)
DECLARE @oldarrear decimal(19,2)

DECLARE @old2 decimal(19,2)
DECLARE @old3 decimal(19,2)
DECLARE @old4 decimal(19,2)
DECLARE @old5 decimal(19,2)

declare @trasferisci char(1)
DECLARE @new2 decimal(19,2)
DECLARE @new3 decimal(19,2)
DECLARE @new4 decimal(19,2)
DECLARE @new5 decimal(19,2)
DECLARE @lastphase tinyint
DECLARE @newayear int
SET  @newayear = @ayear + 1

declare @credit decimal(19,2)
declare @rateo decimal(19,2)
declare @revenue  decimal(19,2)
declare @existnewyear int
declare @is_variation char(1) 

	SELECT  @oldarrear = EY.amount,	
			@old2 = isnull(EY.amount2,0), @old3=isnull(EY.amount3,0), @old4= isnull(EY.amount4,0), @old5=isnull(EY.amount5,0),		
			@existnewyear = EY.idepacc		
	FROM epaccyear EY 	
	WHERE EY.idepacc = @idmov AND EY.ayear = @newayear

	select @is_variation =  isnull(E.flagvariation,'N') from epacc E where E.idepacc=@idmov

	select 	@credit   = isnull(ET.credit,0),
			@revenue  = isnull(ET.revenue,0),
			@rateo    = isnull(ET.rateo,0)
	from  epacctotal ET where ET.idepacc=@idmov and ET.ayear=@ayear			
	--gli accertamenti si chiudono con i ricavi in avere
	--gli accertamenti-variazione si chiudono con i ricavi in dare

	--le scritture sui conti di ricavo passano l'importo cambiato di segno, ossia negativo se in avere e positivo se in dare (*)

	--vogliamo che @amount abbia un segno tale che sommato sia conforme alla chiusura dell'accertamento
	if  (@is_variation = 'S')
	Begin
		--visto che di norma il ricavo è in avere ma importo negativo(*), per gli accertamenti normali basta sommarlo col suo valore
		-- per le variazioni di accertamento invece il ricavo vogliamo che si chiuda in dare ossia quando è positivo,
		--  quindi in questo caso dobbiamo cambiarlo di segno

		SET @amount  = - isnull(@amount,0)
		SET @amount2 = - isnull(@amount2,0)	
		SET @amount3 = - isnull(@amount3,0)	
		SET @amount4 = - isnull(@amount4,0)	
		SET @amount5 = - isnull(@amount5,0)	
	End

	set @new2 = ISNULL(@amount3,0)+isnull(@old2,0)
	set @new3 = ISNULL(@amount4,0)+isnull(@old3,0)
	set @new4 = ISNULL(@amount5,0)+isnull(@old4,0)
	--set @new5 = isnull(@old5,0)
	--set @newarrear=isnull(@oldarrear,0)+isnull(@amount,0)
	set @newarrear=isnull(@oldarrear,0)+isnull(@amount,0)+isnull(@amount2,0)
	print @newarrear
	
	set @trasferisci='N'
	if (@newarrear<>0 or @new2<>0 or @new3<>0 or @new4<>0 or @new5<>0 or isnull(@credit,0)<>0 or isnull(@rateo,0)<>0)  BEGIN
		set  @trasferisci='S'
	END
		
	if (@trasferisci='N') and @nphase=1 and exists
		 (select * from  epacc E 
				join epaccyear EY on E.idepacc = EY.idepacc 
				where  E.paridepacc=@idmov
						and EY.ayear=  @newayear
		 )
	 begin
		set  @trasferisci='S'
	end

	if (@existnewyear is not null) 
	begin	
		if (@trasferisci='S')			
		begin 
			update epaccyear set amount=@newarrear,amount2=@new2, amount3=@new3, amount4=@new4, amount5=@new5,					
					 lu = 'trg_updatearrearsepacc', lt = GETDATE() 
					 where  idepacc = @idmov AND ayear = @newayear
		end
		else 
		begin
			delete from epaccyear where idepacc = @idmov AND ayear = @newayear
		end
		
	end
	else
	begin
		
		
		if (@trasferisci='S')	 begin
			SELECT @oldidacc = idacc from  epaccyear EY 	
				WHERE EY.idepacc = @idmov AND EY.ayear = @ayear

			SELECT @newidacc = newidacc FROM accountlookup 	WHERE oldidacc = @oldidacc

			if (@idupb is null) SELECT @idupb = idupb FROM epaccyear 	WHERE idepacc = @idmov and ayear = @ayear

			if(	@newidacc is not null and @idupb is not null 	)
				begin 
					INSERT INTO epaccyear	(idepacc,ayear,idacc,idupb,amount,amount2, amount3, amount4,amount5,cu,ct,lu,lt)
						VALUES(@idmov,@newayear,@newidacc,@idupb,@newarrear,@new2,@new3,@new4, @new5, 
								'trg_updatearrearsepacc',GETDATE(),'trg_updatearrearsepacc',GETDATE())
				end
		end
	END


END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
