
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


-- setuser'amm'
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettoworkpackageview]
GO

CREATE        VIEW [rendicontattivitaprogettoworkpackageview]
as
select	RA.idreg, 
		RA.idworkpackage, 
		RA.idprogetto,
		PK.oredivisionecostostipendio,
		PTC.idprogettotipocosto,
		null as amount,
		PC.idprogettocosto,
		RA.idrendicontattivitaprogetto,
		RDETT.idrendicontattivitaprogettoora,
		RDETT.data,--data in cui ha lavorato
		isnull(sum(RDETT.ore),0) as ore,-- ore lavorate
		( select top 1 C.idcontrattokind from contratto C  where C.idreg = RA.idreg
			and RDETT.data between C.start and  isnull(C.stop,{d '2079-01-01'})
			order by C.start desc) as idcontrattokind,
		RA.description
		-- Mi leggo le ore lavorate e il Tipo contratto "corrente". Nella function farò la SUM ore lavorate di quel tipo contratto * costo orario
from rendicontattivitaprogetto RA
JOIN  rendicontattivitaprogettoora RDETT on RA.idrendicontattivitaprogetto =RDETT.idrendicontattivitaprogetto
join registry_docenti R on RA.idreg = R.idreg --> DOCENTI
join progettotipocostocontrattokind PTC
	 on PTC.idcontrattokind = R.idcontrattokind and PTC.idprogetto = RA.idprogetto
join progetto P
	on RA.idprogetto = RA.idprogetto
join progettokind PK
	on P.idprogettokind = PK.idprogettokind
left outer join progettocosto PC 
	on PC.idrendicontattivitaprogetto = RA.idrendicontattivitaprogetto and PTC.idprogettotipocosto = PC.idprogettotipocosto
group by RA.idreg, 		RA.idworkpackage, 		RA.idprogetto,
		PTC.idprogettotipocosto,			PC.idprogettocosto,	RA.idrendicontattivitaprogetto,	RDETT.idrendicontattivitaprogettoora,		RDETT.data,		RA.description,PK.oredivisionecostostipendio
UNION ALL	 

select	RA.idreg, 
		RA.idworkpackage, 
		RA.idprogetto,
		PK.oredivisionecostostipendio,
		PTC.idprogettotipocosto,
		null as amount,
		PC.idprogettocosto,
		RA.idrendicontattivitaprogetto,
		RDETT.idrendicontattivitaprogettoora,
		RDETT.data,--data in cui ha lavorato
		isnull(sum(RDETT.ore),0) as ore ,-- ore lavorate
		( select top 1 C.idcontrattokind from contratto C  where C.idreg = RA.idreg
			and RDETT.data between C.start and  isnull(C.stop,{d '2079-01-01'})
			order by C.start desc) as idcontrattokind,
		RA.description
		-- Mi leggo le ore lavorate e il Tipo contratto "corrente". Nella function farò la SUM ore lavorate di quel tipo contratto * costo orario
from rendicontattivitaprogetto RA
JOIN  rendicontattivitaprogettoora RDETT on RA.idrendicontattivitaprogetto =RDETT.idrendicontattivitaprogetto
join registry_amministrativi R on RA.idreg = R.idreg  --> AMMINISTRATIVI
join progettotipocostocontrattokind PTC
	 on PTC.idcontrattokind = R.idcontrattokind and PTC.idprogetto = RA.idprogetto
join progetto P
	on RA.idprogetto = RA.idprogetto
join progettokind PK
	on P.idprogettokind = PK.idprogettokind
left outer join progettocosto PC 
	on PC.idrendicontattivitaprogetto = RA.idrendicontattivitaprogetto and PTC.idprogettotipocosto = PC.idprogettotipocosto
group by RA.idreg, 		RA.idworkpackage, 		RA.idprogetto,
		PTC.idprogettotipocosto,			PC.idprogettocosto,	RA.idrendicontattivitaprogetto,	RDETT.idrendicontattivitaprogettoora,		RDETT.data,		RA.description, PK.oredivisionecostostipendio

go



		
		
