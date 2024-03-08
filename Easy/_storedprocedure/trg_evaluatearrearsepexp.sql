
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_evaluatearrearsepexp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_evaluatearrearsepexp]
GO
-- setuser 'amm'
-- setuser 'amministrazione'
-- exec trg_evaluatearrearsepexp 1, 2015
CREATE  PROCEDURE [trg_evaluatearrearsepexp](
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
declare @debit decimal(19,2)
declare @rateo decimal(19,2)
declare @accantonamento decimal(19,2)
declare @cost  decimal(19,2)
declare @is_variation char(1) 

DECLARE @nphase tinyint

	SELECT @currentamount = ISNULL(ET.curramount, 0),
			@amount2 = isnull(ET.curramount2,0),
			@amount3 = isnull(ET.curramount3,0),
			@amount4 = isnull(ET.curramount4,0),
			@amount5 = isnull(ET.curramount5,0),
			@debit   = isnull(ET.debit,0),
			@cost    = isnull(ET.cost,0),
			@rateo   = isnull(ET.rateo,0),
			@accantonamento = isnull(ET.accantonamento,0),
			@nphase = E.nphase,
			@oldidacc = EY.idacc,
			@idupb    = EY.idupb,
			@is_variation = isnull(E.flagvariation,'N')
	FROM epexptotal ET
		join epexp E on E.idepexp= ET.idepexp
		join epexpyear EY on ET.ayear=EY.ayear and ET.idepexp=EY.idepexp
	WHERE ET.idepexp = @idmov 		AND ET.ayear = @ayear

	select	@existyear = newyear.idepexp
		from epexpyear newyear 	where newyear.idepexp=@idmov and newyear.ayear=@newayear
		
	DECLARE @payed decimal(19,2)	
	if(@nphase = 1)
	Begin
		SELECT @payed =  -sum(ET.cost), @debit=sum(ET.debit), @rateo=sum(ET.rateo), @accantonamento=sum(ET.accantonamento)
		from epexptotal ET
		join epexp on ET.idepexp=epexp.idepexp
		WHERE epexp.paridepexp = @idmov and ET.ayear=@ayear
	End
	if(@nphase = 2)
	Begin
		SELECT @payed =  -@cost
	End

	--il costo di solito si movimenta in negativo, ma il totalizzatore ha già ricevuto un cambio di segno per cui rappresenta l'effettivo costo
	--   con valore già normalizzato 
	--tuttavia qui lo stiamo cambiando di segno quindi ora il costo è di nuovo OPPOSTO, come se fosse stato preso dalle SCRITTURE
	
	
	if  (@is_variation = 'N')
	Begin
		-- se NON è una variazione, il costo diventa di nuovo NORMALIZZATO 
		-- se E' una variazione, il costo "rimane" OPPOSTO perchè deve essere trattato diversamente  
		SET @payed = - @payed	/* Cambiamo il segno perchè il costo si movimenta in dare che è negativo. Se non lo facessimo, nel calcolo di 
								 @newarrear, il pagato diverrebbe positivo e farebbe aumentare il residuo, invece che ridurlo.
								 Se invece fosse una variazione	non cambiamo il segno, perchè il costo si movimenta in avere che è positivo.	*/
	End

	-- SE NON è una variazione, sottraiamo il costo (che è positivo)
	-- SE E' una variazione il costo è negativo LO SOMMIAMO infatti le variazioni lavorano con logica inversa
	-- d'altronde se tutto va bene le scritture associate alla variazione movimenteranno il costo in AVERE anzichè in DARE 
	--		e quindi alla fine saranno comunque SOTTRATTE

	SELECT @newarrear = ISNULL(@currentamount, 0) - ISNULL(@payed, 0) + isnull(@amount2,0)

	declare @trasferisci char(1)
	set @trasferisci='N'
	if (isnull(@newarrear,0) <>0 or  isnull(@amount3,0) <>0 or  isnull(@amount4,0)<>0 or  isnull(@amount5,0) <>0
		or isnull(@debit,0)<>0 or isnull(@rateo,0)<>0  or isnull(@accantonamento,0)<>0)
	BEGIN
			set  @trasferisci='S'
	END

	if (@trasferisci='N' and @nphase=1)
	begin
		if EXISTS 	(SELECT epexpyear.idepexp 	FROM epexpyear
								JOIN epexp 					ON epexp.idepexp = epexpyear.idepexp
									WHERE epexp.paridepexp = @idmov 	AND epexpyear.ayear = @newayear) 
		begin
			set @trasferisci='S'
		end
							
	end

	IF (@existyear is not null)
	BEGIN
		IF (@trasferisci='N')			
		BEGIN
				DELETE FROM epexpyear	WHERE idepexp = @idmov	AND ayear = @newayear
		END
		ELSE
		BEGIN
				SELECT @newidacc = newidacc from  accountlookup	WHERE oldidacc = @oldidacc	
				if(	@newidacc is not null and @idupb is not null 	) begin						
					UPDATE epexpyear	
					SET amount = @newarrear, amount2=@amount3, amount3=@amount4, amount4=@amount5, amount5=null,	
								idacc=@newidacc, idupb=@idupb,				
								lu = 'trg_evaluatearrearsepexp', lt = GETDATE()
						WHERE idepexp = @idmov		AND ayear = @newayear
				end
		END
	END
	ELSE
	BEGIN
		SET @newidacc = NULL
		SELECT @newidacc = newidacc from  accountlookup	WHERE oldidacc = @oldidacc

		if(	(@trasferisci='S')		and  	@newidacc is not null and @idupb is not null 	)
		Begin
			INSERT INTO epexpyear 	(idepexp,ayear,idacc,idupb,amount,	amount2, amount3, amount4, amount5,	cu,ct,lu,lt)
						VALUES(@idmov,@newayear,@newidacc,@idupb,@newarrear, @amount3, @amount4, @amount5, null,	
								'trg_evaluatearrearsepexp',GETDATE(),'trg_evaluatearrearsepexp',GETDATE())
		End
	END
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


