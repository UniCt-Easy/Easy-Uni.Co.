
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_evaluatearrearsepacc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_evaluatearrearsepacc]
GO
-- setuser 'amm'
-- setuser 'amministrazione'
-- exec trg_evaluatearrearsepacc 3, 2015
CREATE  PROCEDURE [trg_evaluatearrearsepacc](
	@idmov int,
	@ayear int
)
AS BEGIN

DECLARE @oldidacc varchar(38)
DECLARE @newidacc varchar(38)
DECLARE @idupb varchar(36)
DECLARE @existyear int
DECLARE @newarrear decimal(19,2)
DECLARE @currentamount decimal(19,2)

DECLARE @newayear int
SELECT @newayear = @ayear + 1

DECLARE @amount2 decimal(19,2)
DECLARE @amount3 decimal(19,2)
DECLARE @amount4 decimal(19,2)
DECLARE @amount5 decimal(19,2)
declare @credit decimal(19,2)
declare @rateo decimal(19,2)
declare @revenue  decimal(19,2)
declare @is_variation char(1) 

DECLARE @nphase tinyint

	SELECT @currentamount = ISNULL(ET.curramount, 0),
			@amount2 = isnull(ET.curramount2,0),
			@amount3 = isnull(ET.curramount3,0),
			@amount4 = isnull(ET.curramount4,0),
			@amount5 = isnull(ET.curramount5,0),
			@credit   = isnull(ET.credit,0),
			@revenue    = isnull(ET.revenue,0),
			@rateo   = isnull(ET.rateo,0),		
			@nphase = E.nphase,
			@oldidacc = EY.idacc,
			@idupb    = EY.idupb,
			@is_variation = isnull(E.flagvariation,'N')
	FROM epacctotal ET
		join epacc E on E.idepacc= ET.idepacc
		join epaccyear EY on ET.ayear=EY.ayear and ET.idepacc=EY.idepacc		
	WHERE ET.idepacc = @idmov 		AND ET.ayear = @ayear

	select 	@existyear = newyear.idepacc
		from epacctotal newyear where newyear.idepacc=@idmov and newyear.ayear=@newayear

	DECLARE @payed decimal(19,2)	
	if(@nphase = 1)
	Begin
		SELECT @payed =  sum(ET.revenue), @credit=sum(ET.credit),@rateo=SUM(ET.rateo)
		from epacctotal ET
		join epacc on ET.idepacc=epacc.idepacc
		WHERE epacc.paridepacc = @idmov and ET.ayear=@ayear
	End

	if(@nphase = 2)
	Begin
		SELECT @payed =  @revenue
	End

	
	-- scrittura crediti a ricavi
	-- non si deve cambiare il segno di @payed
	-- se l'accertamento di budget è marcato come variazione
	-- allora di nuovo si cambia il segno
	-- questo relativamente alla modifica che sta operando Sara
	-- stiamo aggiungendo un flag "nota di variazione" sull'impegno e acc. di budget

	-- il costo di solito si movimenta in negativo, ma il totalizzatore ha già ricevuto un cambio di segno per cui rappresenta l'effettivo costo
	--   con valore già normalizzato
	-- NON lo stiamo cambiando di segno quindi ora il ricavo è NORMALE, come se fosse stato preso dalle SCRITTURE

	if  (@is_variation = 'S')   begin	--era ='S'
		-- se NON è una variazione, il ricavo RIMANE  NORMALE
		-- se E' una variazione, il ricavo diventa OPPOSTO perchè deve essere trattato diversamente  
		 set @payed = -@payed
	end
	

	-- SE NON è una variazione, sottraiamo il ricavo (che è NORMALE)
	-- SE E' una variazione il ricavo è negativo LO SOMMIAMO infatti le variazioni lavorano con logica inversa
	-- d'altronde se tutto va bene le scritture associate alla variazione movimenteranno il costo in DARE anzichè in AVERE 
	--		e quindi alla fine saranno comunque SOTTRATTE
	SELECT @newarrear = ISNULL(@currentamount, 0) - ISNULL(@payed, 0) + isnull(@amount2,0)

	declare @trasferisci char(1)
	set @trasferisci='N'
	if (isnull(@newarrear,0) <>0 or  isnull(@amount3,0) <>0 or  isnull(@amount4,0)<>0 or  isnull(@amount5,0) <>0
		or isnull(@credit,0)<>0 or isnull(@rateo,0)<>0 ) BEGIN
			set  @trasferisci='S'
	END

	if (@trasferisci='N' and @nphase=1)
	begin
		if EXISTS 	(SELECT epaccyear.idepacc 	FROM epaccyear
								JOIN epacc 					ON epacc.idepacc = epaccyear.idepacc
									WHERE epacc.paridepacc = @idmov 	AND epaccyear.ayear = @newayear) 
		begin
			set @trasferisci='S'
		end
							
	end	

	IF (@existyear is not null)
	BEGIN
		IF (@trasferisci='N')			
		BEGIN
				DELETE FROM epaccyear	WHERE idepacc = @idmov	AND ayear = @newayear
		END
		ELSE
		BEGIN	
				SELECT @newidacc = newidacc from  accountlookup	WHERE oldidacc = @oldidacc		
				if(	@newidacc is not null and @idupb is not null 	) begin	
					UPDATE epaccyear
					SET amount = @newarrear, 	amount2=@amount3, amount3=@amount4, amount4=@amount5, amount5=null,		
									idacc=@newidacc, idupb=@idupb,
									lu = 'trg_evaluatearrearsepacc', lt = GETDATE()
					WHERE idepacc = @idmov	AND ayear = @newayear
				end 
		END
	END
	ELSE
	BEGIN
		SET @newidacc = NULL
		SELECT @newidacc = newidacc from  accountlookup	WHERE oldidacc = @oldidacc
		
		if (@trasferisci='S' and @newidacc is not  null and @idupb is not null) 
		begin								
				INSERT INTO epaccyear 	(idepacc,ayear,idacc,idupb,amount,	amount2, amount3, amount4, amount5,	cu,ct,lu,lt)
						VALUES(@idmov,@newayear,@newidacc,@idupb,@newarrear, @amount3, @amount4, @amount5,null,
								'trg_evaluatearrearsepacc',GETDATE(),'trg_evaluatearrearsepacc',GETDATE())
		end
	END
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


