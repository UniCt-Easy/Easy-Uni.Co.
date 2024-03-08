
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_compensoprestprof_spese]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_compensoprestprof_spese]
GO


--exec rpt_compensoprestprof_spese_1 2006,1
CREATE  PROCEDURE [rpt_compensoprestprof_spese]
	@ycon int,
	@ncon int
AS
BEGIN
	SELECT
		profservicerefund.ycon,
		profservicerefund.ncon,
		profservicerefund.nrefund,
		profservicerefund.amount,
		profrefund.description
	FROM  profservicerefund	
	LEFT OUTER JOIN profrefund
		ON   profservicerefund.idlinkedrefund = profrefund.idlinkedrefund
	WHERE 
	(profservicerefund.ycon = @ycon AND  profservicerefund.ncon = @ncon)
	ORDER BY profservicerefund.nrefund
		
END 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

