
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


-- Per il momento è una tabella temporanea, poi quando faremo la migrazione, diventarà una tabella fisica

IF  EXISTS(select * from sysobjects where id = object_id(N'[lookup_anagrafica]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE lookup_anagrafica
END

create table lookup_anagrafica(
codice varchar(10),
tipo char(1),
idreg int identity(1,1),
CONSTRAINT xpklookup_anagrafica PRIMARY KEY (tipo, codice)
)
go

insert into lookup_anagrafica(tipo, codice)
select 'A', codice from anagrafico

insert into lookup_anagrafica(tipo, codice)
select 'D', codice from dipendenti


insert into lookup_anagrafica(tipo, codice)
select distinct 'U', CODICE_ANAG from CURR_DOCUMENTO_CONTABILE 
	where CODICE_ANAG is not null
		AND CODICE_ANAG not in (select codice from ANAGRAFICO)
		and CODICE_ANAG not in (select codice from DIPENDENTI)
		AND (NOME is not null or COGNOME is not null or RAGIONE_SOCIALE is not null )
order by CODICE_ANAG


-- select * from lookup_anagrafica order by idreg



