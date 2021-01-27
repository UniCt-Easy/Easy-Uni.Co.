
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_elencoclientifornit_intestazione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_elencoclientifornit_intestazione]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE        procedure exp_elencoclientifornit_intestazione as 
begin
	declare @h05codicefiscale varchar(16)
	SELECT @h05codicefiscale = paramvalue FROM generalreportparameter WHERE idparam = 'License_f'

	declare @h06partitaiva varchar(16)
	SELECT @h06partitaiva = paramvalue FROM generalreportparameter WHERE idparam = 'License_P_Iva'	

	declare @h07cognome varchar(26)
	declare @h08nome varchar(25)
	declare @h09sesso varchar(1)
	declare @h10datadinascita datetime
	declare @h11comuneostatoesterodinascita varchar(40)
	declare @h12provinciadinascita varchar(2)

	declare @h13denominazione varchar(150)
	SELECT @h13denominazione = upper(departmentname) FROM license

	declare @h14comunedellasedelegale varchar(65)
	declare @h15provinciadellasedelegale varchar(2)
	select @h14comunedellasedelegale=geo_city.title, @h15provinciadellasedelegale=geo_country.province
		from geo_city
		join license on license.idcity=geo_city.idcity
		join geo_country on geo_country.idcountry=geo_city.idcountry

	declare @h16codicefiscaledelsoggettoobbligato varchar(16)

	declare @h17annodiriferimento int
	set @h17annodiriferimento = 2006

	declare @h18Progressivodellinviotelematico int
	declare @h19Numerototaledegliinviitelematici int
	declare @h20Codicefiscaledellintermediario varchar(16)
	declare @h21NumerodiiscrizioneallalbodelCAF int
	declare @h22Impegnoatrasmettere int
	declare @h23Datadellimpegno datetime

--TRACCIATO RECORD DI TESTA  - CONTRIBUENTE							
--DATI IDENTIFICATIVI DELLA FORNITURA							
	select 
		'ECF' as h02,
		'00' as h03,
		'38' as h04,
--CODICE FISCALE E PARTITA IVA DEL CONTRIBUENTE							
		@h05codicefiscale as h05,
		@h06partitaiva as h06,
--DATI IDENTIFICATIVI DEL CONTRIBUENTE (da impostare solo nel caso di persona fisica)							
		@h07cognome as h07,
		@h08nome as h08,
		@h09sesso as h09,
		@h10datadinascita as h10,
		@h11comuneostatoesterodinascita as h11,
		@h12provinciadinascita as h12,
--DATI IDENTIFICATIVI DEL CONTRIBUENTE (da impostare solo nel caso di persona non fisica)							
		@h13denominazione as h13,
		@h14comunedellasedelegale as h14,
		@h15provinciadellasedelegale as h15,
--CODICE FISCALE DEL SOGGETTO OBBLIGATO (se diverso dal contribuente)							
		@h16codicefiscaledelsoggettoobbligato as h16,
--ANNO DI RIFERIMENTO							
		@h17annodiriferimento as h17,
--COMUNICAZIONE SU PIU' INVII							
		@h18Progressivodellinviotelematico as h18,
		@h19Numerototaledegliinviitelematici as h19,
--IMPEGNO ALLA PRESENTAZIONE TELEMATICA							
		@h20Codicefiscaledellintermediario as h20,
		@h21NumerodiiscrizioneallalbodelCAF as h21,
		@h22Impegnoatrasmettere as h22,
		@h23Datadellimpegno as h23
--CARATTERI DI CONTROLLO							
--	INSERT INTO #record0 (progr, quadro, riga, colonna, stringa) VALUES(1, '00000024', @h24Filler)
--25	1798	1798	1	Carattere di controllo	AN	Vale sempre "A"	Dato obbligatorio
--26	1799	1800	2	Caratteri di fine riga	AN	Caratteri ASCII "CR" e "LF" (valori esadecimali "0D" "0A")	Dato obbligatorio


end




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

