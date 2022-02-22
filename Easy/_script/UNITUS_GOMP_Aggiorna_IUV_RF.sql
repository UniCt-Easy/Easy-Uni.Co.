
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

/****** Object:  StoredProcedure [dbo].[Aggiorna_IUV_RF]    Script Date: 26/04/2021 09:35:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Aggiorna_IUV_RF]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	

	-- IUV RF
	update amministrazione.flussocreditidetail set amministrazione.flussocreditidetail.IUV = inc.IUV, 
		   amministrazione.flussocreditidetail.lu ='Script_Allinea_IUV_RF_ORIG'+ cre.IUV, 
		   amministrazione.flussocreditidetail.lt=getdate()
	from amministrazione.flussoincassidetailview inc
	join amministrazione.flussocreditidetail cre
	on substring(cre.iuv, 1, len(cre.IUV) -2) =
	substring(inc.IUV, len('RF02000000000'), len('0000005252198'))
	where inc.IUV like 'RF%'
	and inc.ayear > 2020

END
GO


