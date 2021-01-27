
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


if exists (select * from dbo.sysobjects where id = object_id(N'[get_upb_info]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [get_upb_info]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
IF NOT EXISTS (SELECT * FROM systypes where name = 'string_list') BEGIN 
	CREATE TYPE dbo.string_list  AS TABLE   (s varchar(36))  
END
GO
CREATE        PROCEDURE [get_upb_info]
(
	@lista_idupb dbo.string_list  READONLY 
)
AS BEGIN
--setuser 'amministrazione'
--setuser 'amm'
 
------------------------------------------------------------------------------------------------
-------------  STORED PROCEDURE PER IL CALCOLO DELLE INFORMAZIONI SULL'UPB  --------------------
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------ 
--sp_help upb

-- Tabella degli UPB
SELECT  DISTINCT
	idupb,
	codeupb,
	title,
	active,
	paridupb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cofogmpcode,
	uesiopecode,
	ct,
	cu,
	lt,
	lu
	FROM upb 
	JOIN @lista_idupb ON   [@lista_idupb].s = upb.idupb
		--JOIN @lista_id on e.idinc = [@lista_id].n
	
 
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


