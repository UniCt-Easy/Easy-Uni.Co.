
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensoprestocc_spese]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensoprestocc_spese]
GO


--exec rpt_compensoprestocc_spese 2009,152
CREATE  PROCEDURE [rpt_compensoprestocc_spese]
	@ayear int,
	@ycon int,
	@ncon int
AS
BEGIN
	IF (@ayear IS NULL) 
	BEGIN
		SELECT
			casualcontractrefund.ycon,
			casualcontractrefund.ncon,
			casualcontractrefund.ayear,
			casualcontractrefund.nrefund,
			casualcontractrefund.amount,
			casualrefund.description,
			casualrefund.deduction 
		FROM  	casualcontractrefund	
		LEFT OUTER JOIN casualrefund
			ON   casualcontractrefund.idlinkedrefund = casualrefund.idlinkedrefund
		WHERE 
			casualcontractrefund.ycon = @ycon AND  casualcontractrefund.ncon = @ncon
		ORDER BY  casualcontractrefund.ayear, casualcontractrefund.nrefund
	END
	ELSE
	BEGIN
		SELECT
			casualcontractrefund.ycon,
			casualcontractrefund.ncon,
			casualcontractrefund.ayear,
			casualcontractrefund.nrefund,
			casualcontractrefund.amount,
			casualrefund.description,
			casualrefund.deduction 
		FROM  	casualcontractrefund	
		LEFT OUTER JOIN casualrefund
			ON   casualcontractrefund.idlinkedrefund = casualrefund.idlinkedrefund
		WHERE 
			casualcontractrefund.ycon  = @ycon AND  casualcontractrefund.ncon = @ncon
		AND	casualcontractrefund.ayear = @ayear
		ORDER BY  casualcontractrefund.ayear, casualcontractrefund.nrefund
	END
END 

go

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
