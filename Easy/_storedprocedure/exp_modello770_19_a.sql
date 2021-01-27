
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modello770_19_a]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_19_a]
GO
 
CREATE     PROCEDURE [exp_modello770_19_a]
AS BEGIN

	CREATE TABLE #recorda
	(
		progr int,
		quadro varchar(3),
		riga int,
		colonna varchar(3),
		stringa varchar(100),
		intero int,
		data datetime
	)
	--setuser  'amministrazione'
	--[exp_modello770_19_a]
	DECLARE @cf varchar(11)
	DECLARE @departmentcode varchar(10)
	
	select @cf = isnull(cf, p_iva) from license
	if @cf is null
	begin
		SELECT @cf = paramvalue FROM generalreportparameter WHERE idparam = 'License_f'
	end
	IF (@cf IS NULL)
	BEGIN
		SELECT @cf = paramvalue FROM generalreportparameter WHERE idparam = 'License_P_Iva'	
	END

	SELECT @departmentcode = departmentcode	FROM license

	DECLARE @tipofornitore int
	SET @tipofornitore = 6
	--1 Tipo record
	INSERT INTO #recorda (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRA', 1, '01', 'A')
	--3 Codice fornitura
	INSERT INTO #recorda (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRA', 1, '03', '77019')
	--4 Tipo fornitore
	INSERT INTO #recorda (progr, quadro, riga, colonna, intero) VALUES(1, 'HRA', 1, '04', @tipofornitore)
	--5 Codice fiscale del fornitore
	INSERT INTO #recorda (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRA', 1, '05', @cf)
	-- I campi 07 e 08 non vengono inseriti in quanto effettuiamo un unico invio (non superiamo la soglia di 1,38 MB compressi)
	--9 Campo utente
	INSERT INTO #recorda (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRA', 1, '09', @departmentcode)
	SELECT * FROM #recorda WHERE stringa IS NOT NULL OR intero IS NOT NULL OR data IS NOT NULL
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
