
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_cud_07]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_cud_07]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE      PROCEDURE [exp_cud_07] as
begin
	CREATE TABLE #recordg
	(
		progr int,
		quadro varchar(3),
		riga int,
		colonna varchar(3),
		stringa varchar(100),
		intero int,
		data datetime
	)
	insert into #recordg exec exp_modello770_07_g

	create table #cud (
		cf varchar(100),--codice fiscale
		agencyname varchar(100),--denominazione
		location varchar(100),--comune
		country varchar(100),--prov
		cap varchar(100),--cap
		address varchar(100),--indirizzo
		phonenumber varchar(100),--telefono
		email varchar(100),--email
		codiceattivita varchar(100),
		DA001001 varchar(100),
		DA001002 varchar(100),
		DA001003 varchar(100),
		DA001004 varchar(100),
		DA001005a varchar(100),
		DA001005b varchar(100),
		DA001005c varchar(100),
		DA001006 varchar(100),
		DA001007 varchar(100),
		DA001011 varchar(100),
		DA001012 varchar(100),
		DA001013 varchar(100),
		DB001001 int,
		DB001002 int,
		DB001003 int,
		DB001005 int,
		DB001006 int,
		DB001007 int,
		DB001A07 int,
		DB001017 int,
		DB001018 int,
		DB001019 int,
		DB001020 int,
		DB001021 int,
		DB001026 int,
		DB001027 int,
		DB001035 varchar(1),
		DB001036 varchar(1),
		DB001045 int,
		DCXXX012 int,
		DCXXX013 int,
		DCXXX014 int,
		DCXXX015 int,
		DCXXX016 int,
		DCXXX017a varchar(100),
		DCXXX017b varchar(100),
		DCXXX017c varchar(100),
		DCXXX017d varchar(100),
		DCXXX017e varchar(100),
		DCXXX017f varchar(100),
		DCXXX017g varchar(100),
		DCXXX017h varchar(100),
		DCXXX017i varchar(100),
		DCXXX017j varchar(100),
		DCXXX017k varchar(100),
		DCXXX017l varchar(100),
		DCXXX070 varchar(100)
	)

	create table #collaboratori (cf varchar(16), progr int)
	insert into #collaboratori select distinct stringa, progr from #recordg where quadro='DA' and colonna='001'
	
	insert into #cud (da001001) select distinct stringa from #recordg where quadro='DA' and colonna='001'

	update #cud set
		cf = ISNULL(license.cf, license.p_iva),
		agencyname = license.agencyname,
		location = license.location,
		country = license.country,
		cap = license.cap,
		address = license.address1,
		codiceattivita = '80301'
		FROM license


--	update #cud set tipo = stringa from #recordg where #cud.progr=#recordg.progr and quadro='HRG' and colonna='04'
--	update #cud set chiave = stringa from #recordg where #cud.progr=#recordg.progr and quadro='HRG' and colonna='08'

--	update #cud set DA001001 = stringa from #recordg, #collaboratori where #cud.da001001=#collaboratori.cf 
--		and #collaboratori.progr=#recordg.progr and quadro='DA' and colonna='001'
	update #cud set DA001002 = stringa from #recordg, #collaboratori where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DA' and colonna='002'
	update #cud set DA001003 = stringa from #recordg, #collaboratori where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DA' and colonna='003'
	update #cud set DA001004 = stringa from #recordg, #collaboratori where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DA' and colonna='004'
	update #cud set DA001005a = day(data) from #recordg, #collaboratori where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DA' and colonna='005'
	update #cud set DA001005b = month(data) from #recordg, #collaboratori where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DA' and colonna='005'
	update #cud set DA001005c = year(data) from #recordg, #collaboratori where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DA' and colonna='005'
	update #cud set DA001006 = stringa from #recordg, #collaboratori where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DA' and colonna='006'
	update #cud set DA001007 = stringa from #recordg, #collaboratori where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DA' and colonna='007'
	update #cud set DA001011 = stringa from #recordg, #collaboratori where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DA' and colonna='011'
	update #cud set DA001012 = stringa from #recordg, #collaboratori where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DA' and colonna='012'
	update #cud set DA001013 = stringa from #recordg, #collaboratori where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DA' and colonna='013'
	update #cud set DB001001 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='001')
	update #cud set DB001002 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='002')
	update #cud set DB001003 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='003')
	update #cud set DB001005 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='005')
	update #cud set DB001006 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='006')
	update #cud set DB001007 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='007')
	update #cud set DB001A07 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='A07')
	update #cud set DB001017 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='017')
	update #cud set DB001018 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='018')
	update #cud set DB001019 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='019')
	update #cud set DB001020 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='020')
	update #cud set DB001021 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='021')
	update #cud set DB001026 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='026')
	update #cud set DB001027 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='027')
	update #cud set DB001035 = 'X' where (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='035')>0
	update #cud set DB001036 = 'X' where (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='036')>0
	update #cud set DB001045 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DB' and colonna='045')
	update #cud set DCXXX012 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='012')
	update #cud set DCXXX013 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='013')
	update #cud set DCXXX014 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='014')
	update #cud set DCXXX015 = (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf 
		and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='015')
	update #cud set DCXXX016 = case when (select sum(intero) from #collaboratori, #recordg where #cud.da001001=#collaboratori.cf
		and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='016')>0 then 'X' end from #recordg 
	update #cud set DCXXX017a = 'X' where 
		(select sum(cast(substring(stringa, 1,1) as int)) from #collaboratori, #recordg 
		where #cud.da001001=#collaboratori.cf and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='017') >0
	update #cud set DCXXX017b = 'X' where 
		(select sum(cast(substring(stringa, 2,1) as int)) from #collaboratori, #recordg 
		where #cud.da001001=#collaboratori.cf and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='017') >0
	update #cud set DCXXX017c = 'X' where 
		(select sum(cast(substring(stringa, 3,1) as int)) from #collaboratori, #recordg 
		where #cud.da001001=#collaboratori.cf and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='017') >0
	update #cud set DCXXX017d = 'X' where 
		(select sum(cast(substring(stringa, 4,1) as int)) from #collaboratori, #recordg 
		where #cud.da001001=#collaboratori.cf and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='017') >0
	update #cud set DCXXX017e = 'X' where 
		(select sum(cast(substring(stringa, 5,1) as int)) from #collaboratori, #recordg 
		where #cud.da001001=#collaboratori.cf and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='017') >0
	update #cud set DCXXX017f = 'X' where 
		(select sum(cast(substring(stringa, 6,1) as int)) from #collaboratori, #recordg 
		where #cud.da001001=#collaboratori.cf and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='017') >0
	update #cud set DCXXX017g = 'X' where 
		(select sum(cast(substring(stringa, 7,1) as int)) from #collaboratori, #recordg 
		where #cud.da001001=#collaboratori.cf and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='017') >0
	update #cud set DCXXX017h = 'X' where 
		(select sum(cast(substring(stringa, 8,1) as int)) from #collaboratori, #recordg 
		where #cud.da001001=#collaboratori.cf and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='017') >0
	update #cud set DCXXX017i = 'X' where 
		(select sum(cast(substring(stringa, 9,1) as int)) from #collaboratori, #recordg 
		where #cud.da001001=#collaboratori.cf and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='017') >0
	update #cud set DCXXX017j = 'X' where 
		(select sum(cast(substring(stringa,10,1) as int)) from #collaboratori, #recordg 
		where #cud.da001001=#collaboratori.cf and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='017') >0
	update #cud set DCXXX017k = 'X' where 
		(select sum(cast(substring(stringa,11,1) as int)) from #collaboratori, #recordg 
		where #cud.da001001=#collaboratori.cf and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='017') >0
	update #cud set DCXXX017l = 'X' where 
		(select sum(cast(substring(stringa,12,1) as int)) from #collaboratori, #recordg 
		where #cud.da001001=#collaboratori.cf and #collaboratori.progr=#recordg.progr and quadro='DC' and colonna='017') >0

	select * from #cud order by da001001
end



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

