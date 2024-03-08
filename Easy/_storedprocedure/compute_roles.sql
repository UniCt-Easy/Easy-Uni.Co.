
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

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_roles]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_roles]
GO
--setuser 'amministrazione'
--select * from flowchartuser
--compute_roles '01-01-2020','seg_fcaprilli'
CREATE PROCEDURE compute_roles
(
	@currdate date,
	@idcustomuser varchar(50)
)
AS BEGIN
		select U.idflowchart,
			isnull(U.title,F.title) as  title,
			U.ndetail,
			(U.idflowchart+'§'+convert(varchar(10),U.ndetail)) as k
			from flowchartuser U 
			join flowchart F on U.idflowchart=F.idflowchart where
					F.ayear=year(@currdate) and
					U.idcustomuser = @idcustomuser and 
						(U.start is null or U.start<= @currdate) and
						(U.stop is null or U.stop>= @currdate)
		order by 2
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

