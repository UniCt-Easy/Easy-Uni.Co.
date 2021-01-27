
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
if exists (select * from dbo.sysobjects where id = object_id(N'[trg_updatearrearsepexp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_updatearrearsepexp]
GO


CREATE  PROCEDURE [trg_updatearrearsepexp]
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


DECLARE @new2 decimal(19,2)
DECLARE @new3 decimal(19,2)
DECLARE @new4 decimal(19,2)
DECLARE @new5 decimal(19,2)
	declare @trasferisci char(1)
DECLARE @lastphase tinyint
DECLARE @newayear int
SELECT @newayear = @ayear + 1
declare @debit decimal(19,2)
declare @rateo decimal(19,2)
declare @accantonamento decimal(19,2)
declare @cost  decimal(19,2)
declare @existnewyear int
declare @is_variation char(1) 

	SELECT  @oldarrear = isnull(EY.amount,0),	
			@old2 = isnull(EY.amount2,0), @old3=isnull(EY.amount3,0), @old4= isnull(EY.amount4,0), @old5=isnull(EY.amount5,0),			
			@existnewyear = EY.idepexp	
	FROM epexpyear EY				
	WHERE EY.idepexp = @idmov AND EY.ayear = @newayear
	
	select @is_variation =  isnull(E.flagvariation,'N') from epexp E where E.idepexp=@idmov

	select  @debit   = isnull(ET.debit,0),
			@cost    = isnull(ET.cost,0),
			@rateo   = isnull(ET.rateo,0),
			@accantonamento = isnull(ET.accantonamento,0)	
	from epexptotal ET 		where  ET.idepexp=@idmov and ET.ayear=@ayear		

	--gli impegni si chiudono con i costi in dare
	--gli impegni-variazione si chiudono con i costi in avere

	--vogliamo che @amount abbia un segno tale che sommato sia conforme alla chiusura dell'impegno
	--le scritture sui conti di costo passano l'importo giusto, ossia negativo se in dare e positivo se in avere
	
	--visto che di norma il costo è in dare e quindi è negativo, per gli impegni normali basta sommarlo col suo valore
	--per le variazioni di impegno invece il costo vogliamo che si chiuda in avere ossia quando è positivo,
	--  quindi in questo caso dobbiamo cambiarlo di segno
	if  (@is_variation = 'S')
	Begin
		-- se NON è una variazione, il costo diventa di nuovo NORMALIZZATO 
		-- se E' una variazione, il costo "rimane" OPPOSTO perchè deve essere trattato diversamente  
		SET @amount = - isnull(@amount,0)
		SET @amount2 = - isnull(@amount2,0)	
		SET @amount3 = - isnull(@amount3,0)	
		SET @amount4 = - isnull(@amount4,0)	
		SET @amount5 = - isnull(@amount5,0)	
	End

	set @new2 = ISNULL(@amount2,0)+isnull(@old2,0)
	set @new3 = ISNULL(@amount3,0)+isnull(@old3,0)
	set @new4 = ISNULL(@amount4,0)+isnull(@old4,0)
	set @new5 = ISNULL(@amount5,0)+isnull(@old5,0)
	set @newarrear=isnull(@oldarrear,0)+isnull(@amount,0)+isnull(@amount2,0)

	set @trasferisci='N'

	if (@newarrear<>0 or @new2<>0 or @new3<>0 or @new4<>0 or @new5<>0 or @debit<>0 or @rateo<>0 or @accantonamento<>0)  BEGIN
		set  @trasferisci='S'
	END


	if (@trasferisci='N') and @nphase=1 and exists
		 (select * from  epexp E 
			join epexpyear EY on E.idepexp = EY.idepexp 
				where  E.paridepexp=@idmov			and EY.ayear=  @newayear
			 )
	begin
		set  @trasferisci='S'
	end
		

	if (@trasferisci='N') and exists			 
		(SELECT epexpvar.idepexp
					FROM epexpvar								
						WHERE epexpvar.idepexp = @idmov and epexpvar.yvar=@newayear)	
	 begin
		set  @trasferisci='S'
	end
	
	if (@existnewyear is not null) 
	begin	
		if (@trasferisci='S')									
		begin 
			update epexpyear set amount=@newarrear, amount2=@new3, amount3=@new4, amount4=@new5, amount5=null,					
					 lu = 'trg_updatearrearsepexp', lt = GETDATE() 
					 where  idepexp = @idmov AND ayear = @newayear
		end
		else 
		begin
			delete from epexpyear where idepexp = @idmov AND ayear = @newayear
		end		
	end
	else
	begin
		if (@trasferisci='S') begin
			SELECT @oldidacc = idacc from  epexpyear EY 	
				WHERE EY.idepexp = @idmov AND EY.ayear = @ayear


			SELECT @newidacc = newidacc FROM accountlookup 	WHERE oldidacc = @oldidacc

			if (@idupb is null) SELECT @idupb = idupb FROM epexpyear 	WHERE idepexp = @idmov and ayear = @ayear
			if(	@newidacc is not null and @idupb is not null 	)
				begin 
						INSERT INTO epexpyear	(idepexp,ayear,idacc,idupb,amount,amount2, amount3, amount4,amount5, cu,ct,lu,lt)
					VALUES(@idmov,@newayear,@newidacc,@idupb,@newarrear,@new3,@new4, @new5, null, 'trg_updatearrearsepexp',GETDATE(),'trg_updatearrearsepexp',GETDATE())
				end
		end
	END


END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

