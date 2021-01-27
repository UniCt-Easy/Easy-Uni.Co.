
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


if exists (select * from dbo.sysobjects where id = object_id(N'[f_get_esterometrosede]') and OBJECTPROPERTY(id, N'IsTableFunction') = 1)
drop function [f_get_esterometrosede]
 
GO
 
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser 'amministrazione'
-- exec get_esterometrosede 2018,1,'A'
--select * from f_get_esterometrosede(2019,2,null,'A')
CREATE FUNCTION [f_get_esterometrosede](
	@esercizio int,		-- anno solare
	@trimestre int,		-- vale 1 o 2 o 3 o 4
	@mese int,			-- vale da 1 1 12
	@kind char(1) 
	) 
RETURNS @result TABLE (	idaddresskind int,
    idreg int,
	address varchar(60),	
	location varchar(60),
	cap varchar(20),		
	province varchar(2),
	nation varchar(2))  
AS BEGIN
DECLARE @meseinizio int
DECLARE @mesefine int
 
IF (@mese is not null)
BEGIN
	SELECT @meseinizio = @mese
	SELECT @mesefine = @mese
END 
ELSE
BEGIN
	SELECT 
		@meseinizio= case	
			when @trimestre = 1 then 1
			when @trimestre = 2 then 4
			when @trimestre = 3 then 7
			when @trimestre = 4 then 10
			End,
		@mesefine = case
			when @trimestre = 1 then 3
			when @trimestre = 2 then 6
			when @trimestre = 3 then 9
			when @trimestre = 4 then 12
	END
END
----------------- Calcola la Sede dell' Anagrafica ------------------------------------------
DECLARE @dateindi datetime
SELECT @dateindi = CONVERT(datetime, '31-12-'+ CONVERT(varchar(4),@esercizio), 105)

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_FAT'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand
 
INSERT INTO @result	 
SELECT distinct 
	registryaddress.idaddresskind,
	I.idreg, 
	substring(registryaddress.address,1,60),
	SUBSTRING(isnull(geo_city.title, registryaddress.location), 1, 60),
	registryaddress.cap,
	geo_country.province,
	ISNULL(geo_nation_agency.value,'IT')
FROM invoice I
join invoicekind IK
	on I.idinvkind = IK.idinvkind
JOIN ivaregister IR
	ON IR.idinvkind = I.idinvkind
	AND IR.yinv = I.yinv
	AND IR.ninv = I.ninv
JOIN ivaregisterkind IRK
	ON IRK.idivaregisterkind = IR.idivaregisterkind
JOIN registryaddress
	on I.idreg = registryaddress.idreg
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
JOIN geo_nation_agency
	 ON geo_nation_agency.idnation = registryaddress.idnation 
	 AND geo_nation_agency.idagency = 6 -- ente ISO   
	 AND geo_nation_agency.idcode = 1 -- codifica nazioni ISO
	 AND geo_nation_agency.version = 1
	 AND geo_nation_agency.stop IS NULL
	 AND geo_nation_agency.idnation <>1  --- nazione diversa da Italia
WHERE registryaddress.active <>'N' 
	AND registryaddress.start = 
		(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND cdi.start <= @dateindi
			AND cdi.idreg = registryaddress.idreg)
	AND month(I.adate) between @meseinizio and @mesefine and YEAR(I.adate) = @esercizio
	AND isnull(IK.enable_fe,'N')='N' --> dobbiamo escludere i tipo :  Utilizzabile nella Fattura Elettronica = S
	AND (
		 @kind = 'V' AND ((IK.flag&1)<>0)  /* Vendita	*/AND I.idsdi_vendita is null /* Esclude le F.E.*/
		OR
		@kind = 'A' AND ((IK.flag&1)=0)  /* Acquisto*/	AND I.idsdi_acquisto is null /* Esclude le F.E.*/
		)
	AND IRK.flagactivity = 2-- Commerciale 
	AND isnull(IRK.compensation,'N') = 'N' -- Esclude i registri corrispettivi
	AND IRK.registerclass = @kind
	AND (isnull(I.flagbit,0)&8)=0   --- non escludere da invio dati fatture
	AND (isnull(I.flagbit,0)&1)=0   --- no bolletta doganale
	 
DELETE FROM @result
	WHERE [@result].idaddresskind != @nostand
	AND EXISTS (
		SELECT * FROM @result r2 
		WHERE [@result].idreg = r2.idreg
		AND r2.idaddresskind = @nostand
	)
DELETE FROM @result
	WHERE [@result].idaddresskind not in (@nostand, @stand)
	AND EXISTS (
		SELECT * FROM @result r2 
		WHERE [@result].idreg = r2.idreg
		AND r2.idaddresskind = @stand
	)
DELETE  FROM @result
	WHERE (
		SELECT COUNT(*) FROM @result r2 
		WHERE [@result].idreg = r2.idreg
	)>1
 
 
RETURN
end

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
