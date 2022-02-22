
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


USE [UNITUS]
GO

/****** Object:  StoredProcedure [dbo].[Aggiorna_IdUniqueFormCode_Incassi]    Script Date: 26/04/2021 09:34:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Aggiorna_IdUniqueFormCode_Incassi]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	

	-- Incassi senza iduniqueformcode
	update inc set inc.iduniqueformcode = cre.iduniqueformcode, inc.lu ='Aggiorna_IdUniqueFormCode_Incassi', inc.lt=getdate()
	from amministrazione.flussoincassidetail inc
	join amministrazione.flussocreditidetail cre on cre.iuv = inc.iuv 
	where inc.iduniqueformcode is null
	and year(inc.ct) > 2020

END
GO


