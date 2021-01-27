
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_underwritingappropriation]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_underwritingappropriation]
GO

CREATE    TRIGGER [trigger_i_underwritingappropriation] ON [underwritingappropriation] FOR INSERT
AS BEGIN

	DECLARE @idexp int
	DECLARE @ayear int
	DECLARE @nphase tinyint
	DECLARE @idfin int
	DECLARE @idupb varchar(36)
	DECLARE @amount decimal(19,2)
	DECLARE @idunderwriting int
	DECLARE @flagarrear char(1)

	SELECT 
			@idunderwriting = W.idunderwriting,
			@idupb = EY.idupb,
			@idfin = EY.idfin,
			@amount = W.amount,
			@flagarrear =
			CASE
				WHEN ((ET.flag&1)=0) THEN 'C'
				WHEN ((ET.flag&1)=1) THEN 'R'
			END,
			@nphase = E.nphase
	FROM inserted W
	JOIN expense E
		ON W.idexp = E.idexp
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
		AND EY.ayear = E.ymov	
	JOIN expensetotal ET
		ON ET.idexp = E.idexp
		AND ET.ayear = E.ymov

			EXECUTE trg_upd_underwritingmovtotal 
			'E', 
			@idunderwriting,
			@idupb,
			@idfin,
			@flagarrear, 
			@nphase, 
			@amount
		
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

