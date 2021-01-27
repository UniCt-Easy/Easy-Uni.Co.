
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_incomeestimate]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_incomeestimate]
GO

CREATE    TRIGGER [trigger_d_incomeestimate] ON incomeestimate 
FOR DELETE 
AS
	DECLARE @idinc int
	SELECT @idinc = idinc
	FROM deleted
	UPDATE estimatedetail SET idinc_iva = NULL
	WHERE idinc_iva = @idinc
	UPDATE estimatedetail SET idinc_taxable = NULL
	WHERE idinc_taxable = @idinc


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

