
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_formattaNumero]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_formattaNumero]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE                                         procedure [compute_formattaNumero](
	@parametro double precision, 
	@precisione int,
	@0arrotonda1tronca int,
	@lunghezza int, 
	@decimali int, 
	@stringa varchar(150) output
) as begin
	declare @numero double precision
	set @numero = round(@parametro, @precisione, @0arrotonda1tronca)
	if (@precisione > 0) set @lunghezza = @lunghezza + 1
	set @stringa = str(@numero, @lunghezza, @decimali)
	set @stringa = replace(@stringa, ' ', '0')
	set @stringa = replace(@stringa, '.', '')
end



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

