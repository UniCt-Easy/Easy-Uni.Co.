
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expense]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expense]
GO

CREATE  TRIGGER [trigger_u_expense] ON [expense] FOR UPDATE
AS BEGIN
DECLARE @idexp int
DECLARE @nphase tinyint

IF UPDATE(parentidexp)
BEGIN
	DECLARE @newidparent int
	SELECT @idexp = idexp, @newidparent = parentidexp, @nphase = nphase FROM inserted
	
	IF (@newidparent IS NULL) RETURN
	CREATE TABLE #expenselink (idchild int)
	
	INSERT INTO #expenselink
	SELECT idchild
	FROM expenselink
	WHERE expenselink.idparent = @idexp
	
	UPDATE expenselink
	SET idparent = (SELECT idparent FROM expenselink EL2 WHERE EL2.idchild = @newidparent AND EL2.nlevel = expenselink.nlevel)
	FROM #expenselink T
	WHERE expenselink.idchild = T.idchild
	AND nlevel < @nphase
END

IF UPDATE(idreg)
BEGIN
	DECLARE @oldidreg int
	DECLARE @newidreg int

	SELECT @oldidreg = idreg FROM deleted

	SELECT @newidreg = idreg, @idexp = idexp, @nphase = nphase FROM inserted

	DECLARE @regphase tinyint
	SELECT @regphase = expenseregphase FROM uniconfig

	DECLARE @maxphase tinyint
	SELECT @maxphase = MAX(nphase) FROM expensephase

	IF (ISNULL(@oldidreg, -1) <> ISNULL(@newidreg, -1)) AND (@nphase = @maxphase)
	BEGIN
		DECLARE @idregistrypaymethod int
		DECLARE @idpaymethod varchar(20)
		DECLARE @cin varchar(20)
		DECLARE @iban varchar(50)
		DECLARE @idbank varchar(20)
		DECLARE @idcab varchar(20)
		DECLARE @cc varchar(30)
		DECLARE @paymentdescr varchar(150)
		DECLARE @iddeputy int
		DECLARE @refexternaldoc varchar(5)
		
		DECLARE @biccode varchar(20)
		DECLARE @extracode varchar(10)
		DECLARE @paymethod_flag int
		DECLARE @paymethod_allowdeputy char(1)
	
	
		SELECT 
			@idregistrypaymethod = idregistrypaymethod,
			@idpaymethod = idpaymethod,
			@iban = iban,
			@cin = cin,
			@idbank = idbank,
			@idcab = idcab,
			@cc = cc,
			@paymentdescr = paymentdescr,
			@iddeputy = iddeputy,
			@refexternaldoc = refexternaldoc,
			@biccode = biccode,
			@extracode = extracode
		FROM registrypaymethod
		WHERE idreg = @newidreg
			AND flagstandard = 'S'
			
		SELECT 
			@paymethod_flag = flag,
			@paymethod_allowdeputy = allowdeputy
		FROM paymethod
		WHERE idpaymethod = @idpaymethod
		
		
		UPDATE expenselast
		SET
			idregistrypaymethod = @idregistrypaymethod,
			idpaymethod = @idpaymethod,
			cin = @cin,
			iban = @iban,
			idbank = @idbank,
			idcab = @idcab,
			cc = @cc,
			paymentdescr = @paymentdescr,
			iddeputy = @iddeputy,
			refexternaldoc = @refexternaldoc,
			biccode = @biccode,
			extracode = @extracode,
			paymethod_flag = isnull(@paymethod_flag,0),
			paymethod_allowdeputy = @paymethod_allowdeputy,
			lu = '''TRIGGER''',
			lt = GETDATE()
		WHERE idexp = @idexp
	END

	IF (@nphase <> @regphase) RETURN

        IF (ISNULL(@oldidreg, -1) <> ISNULL(@newidreg, -1))
	BEGIN
		UPDATE expense
		SET idreg = @newidreg
		FROM expenselink
		WHERE expenselink.idparent = @idexp
		AND expenselink.idchild <> @idexp
		AND expense.idexp = expenselink.idchild
		AND ISNULL(expense.idreg,-1) = ISNULL(@oldidreg,-1)
	END

END
END

SET QUOTED_IDENTIFIER OFF 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

