
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bolladicarico]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bolladicarico]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE rpt_bolladicarico(
	@yddt_in	smallint ,
	@nddt_in	varchar(10),
	@start	datetime,
	@stop	datetime,
	@idstore int
)
AS BEGIN


-- exec rpt_bolladicarico 2010,'0','ZZZ',null

DECLARE @minoplevel tinyint
SELECT @minoplevel = min(nlevel)
FROM  stocklocationlevel
WHERE (flag&2)<>0

SELECT
	D.yddt_in,
	D.nddt_in, 
	D.adate,-- data bolla
	convert(varchar(400),D.terms) as terms, -- termine di consegna
	L.intcode, -- codice articolo
	L.description as list, --- descrizione  articolo
	U.description as unit,-- unita di carico
	ISNULL(SUM(S.number),0) AS number,	-- q.tà caricata
	R.title as registry,-- fornitore
	SL1.stocklocationcode AS stocklocationcode1,
	SL1.description as stocklocation1,
	SL2.stocklocationcode AS stocklocationcode2,
	SL2.description as stocklocation2,
	SL3.stocklocationcode AS stocklocationcode3,
	SL3.description as stocklocation3,
	SL4.stocklocationcode AS stocklocationcode4,
	SL4.description as stocklocation4,
	M.description as store	
FROM ddt_in D
JOIN stock S
	ON D.idddt_in = S.idddt_in
JOIN list L
	ON L.idlist = S.idlist
JOIN unit U
	ON U.idunit = L.idunit
JOIN store M
	ON M.idstore = D.idstore	
JOIN registry R
	ON R.idreg = D.idreg
LEFT OUTER JOIN stocklocation SL4							
	ON SL4.idstocklocation = S.idstocklocation AND SL4.nlevel = @minoplevel
LEFT OUTER JOIN stocklocation SL3
	ON SL3.idstocklocation = SL4.paridstocklocation 
LEFT OUTER JOIN stocklocation SL2
	ON SL2.idstocklocation = SL3.paridstocklocation 
LEFT OUTER JOIN stocklocation SL1
	ON SL1.idstocklocation = SL2.paridstocklocation 
WHERE 
	(@nddt_in IS NULL OR  nddt_in like '%' + @nddt_in + '%')
	AND (@nddt_in IS NOT NULL OR (D.adate BETWEEN isnull(@start, convert(datetime,'01-01-'+convert(varchar(4),datepart(year,@yddt_in),105))) 
			AND 	isnull(@stop, convert(datetime,'31-12-'+convert(varchar(4),datepart(year,@yddt_in),105)))) )
	AND ( D.idstore = @idstore OR @idstore IS NULL )
	AND D.yddt_in = @yddt_in
GROUP BY 	
	D.yddt_in,
	D.nddt_in, 
	D.adate,-- data bolla
	convert(varchar(400),D.terms), -- termine di consegna
	L.intcode, -- codice articolo
	L.description, --- descrizione  articolo
	U.description,-- unita di carico
	R.title,-- fornitore
	SL1.stocklocationcode, SL1.description,
	SL2.stocklocationcode, SL2.description,
	SL3.stocklocationcode, SL3.description,
	SL4.stocklocationcode, SL4.description,
	M.description


END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





