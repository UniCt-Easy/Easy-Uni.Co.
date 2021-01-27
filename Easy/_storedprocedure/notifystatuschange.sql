
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

-- notifyStatusChange 'RICH',2016,1
if exists (select * from dbo.sysobjects where id = object_id(N'[notifyStatusChange]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [notifyStatusChange]
GO

CREATE PROCEDURE [notifyStatusChange]
(
	@idcustomuser varchar(50),
	@idflowchart varchar(50),
	@idmankind varchar(20),
	@yman smallint,
	@nman int
) AS
BEGIN
	select 'x'
	
END


