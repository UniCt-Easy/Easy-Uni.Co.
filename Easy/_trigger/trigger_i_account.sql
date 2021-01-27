
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


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_account]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_account]
GO

CREATE       TRIGGER [trigger_i_account] ON [account] FOR INSERT
AS BEGIN
IF (@@ROWCOUNT = 0) RETURN

DECLARE @idacc varchar(38)
DECLARE @ayear smallint
DECLARE @codeacc varchar(50)
DECLARE	@paridacc varchar(38)
DECLARE	@nlevel tinyint
DECLARE	@printingorder varchar(50)
DECLARE	@title varchar(150)
DECLARE	@flag int
DECLARE	@cu varchar(64)
DECLARE	@ct datetime
DECLARE	@lu varchar(64)
DECLARE	@lt datetime
DECLARE @flagcompetency	char(1)
DECLARE @flagloss	char(1)
DECLARE @flagprofit	char(1)
DECLARE @flagregistry	char(1)
DECLARE @flagtransitory	char(1)
DECLARE @flagupb	char(1)
DECLARE @idaccountkind	varchar(20)
DECLARE @patrimony_sign	char(1)
DECLARE @placcount_sign	char(1)
DECLARE @idpatrimony varchar(31)
DECLARE @idplaccount varchar(31)
DECLARE @flagaccountusage int

SELECT	
	@idacc = idacc, @ayear = ayear, @flag = flag, 
	@codeacc = codeacc, @paridacc = paridacc,
	@nlevel = nlevel,
	@printingorder = printingorder,
	@title = title, 
	@idpatrimony =idpatrimony, 	@idplaccount = idplaccount,
	@flagregistry = flagregistry,  @flagtransitory = flagtransitory,  @flagupb = flagupb,
	@flagprofit = flagprofit, 	@flagloss = flagloss, 
	@idaccountkind = idaccountkind,
	@placcount_sign = placcount_sign, @patrimony_sign = patrimony_sign, @flagcompetency = flagcompetency,
	@cu = cu, @ct = ct, @lu = lu, @lt = lt
FROM inserted

	if not exists  (select * from commonconfig where ayear = @ayear + 1) return 

	DECLARE @newidacc varchar(38)

	-- Quando viene ribaltata una voce del Piano dei Conti nell'esercizio successivo bisogna controllare innanzitutto che non ce ne sia già una esistente
	
	SELECT @newidacc = idacc
	FROM account
	WHERE (ayear = @ayear + 1)
		AND (codeacc = @codeacc)
		
	DECLARE @existsaccount char(1)

	IF (@newidacc IS NOT NULL)
	BEGIN
		SET @existsaccount = 'S'
	END
	ELSE
	BEGIN
		SET @existsaccount = 'N'
	END


IF (@existsaccount = 'N')
Begin
		CREATE TABLE #accountlookup (oldidacc varchar(31), newidacc varchar(31))
			
		INSERT #accountlookup
		EXECUTE closeyear_fillaccountlookup @ayear

		SET @newidacc = SUBSTRING(CONVERT(char(4), @ayear + 1), 3, 2) +	
							SUBSTRING(@idacc, 3, DATALENGTH(@idacc) - 2)

		DECLARE @err_condition char(1)
		SET @err_condition = 'N'
	
		DECLARE @newparidacc varchar(38)
		IF (@paridacc IS NOT NULL)
		BEGIN
			SELECT @newparidacc = newidacc FROM #accountlookup WHERE oldidacc = @paridacc
			IF ((@newparidacc IS NULL) OR (ISNULL((SELECT COUNT(*) FROM account WHERE idacc = @newparidacc),0) = 0))
			BEGIN
				SET @err_condition = 'S'
			END
		END

		IF (@err_condition = 'N')
		BEGIN
				CREATE TABLE #patrimonylookup (oldidpatrimony varchar(31), newidpatrimony varchar(31))

				INSERT #patrimonylookup
				EXECUTE closeyear_fillpatrimonylookup @ayear
				
				DECLARE @newidpatrimony varchar(31)
				SELECT @newidpatrimony = newidpatrimony FROM #patrimonylookup WHERE oldidpatrimony = @idpatrimony

				CREATE TABLE #placcountlookup (oldidplaccount varchar(31), newidplaccount varchar(31))
					
				INSERT #placcountlookup
				EXECUTE closeyear_fillplaccountlookup @ayear

				DECLARE @newidplaccount varchar(31)
				SELECT @newidplaccount = newidplaccount FROM #placcountlookup WHERE oldidplaccount = @idplaccount


				IF (@err_condition = 'N') AND NOT EXISTS (select * from account where idacc = @newidacc)
					BEGIN
					   INSERT INTO account(
						idacc, ayear, codeacc, paridacc,flagaccountusage,
						nlevel, printingorder, title, flag,
						idpatrimony,idplaccount,
						flagregistry, flagtransitory, flagupb,flagprofit,flagloss, 
						idaccountkind,placcount_sign,patrimony_sign, flagcompetency,
						cu, ct, lu, lt
					   )
					   VALUES(
						@newidacc, @ayear + 1, @codeacc, @newparidacc,@flagaccountusage,
						@nlevel, @printingorder, @title, @flag, 
						@newidpatrimony, @newidplaccount,
						@flagregistry, @flagtransitory, @flagupb, @flagprofit, @flagloss, 
						@idaccountkind, @placcount_sign, @patrimony_sign, @flagcompetency,
						'trigger_account_copy', GETDATE(), 'trigger_account_copy', GETDATE()
					   )
					  END
				
		END

End


END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


