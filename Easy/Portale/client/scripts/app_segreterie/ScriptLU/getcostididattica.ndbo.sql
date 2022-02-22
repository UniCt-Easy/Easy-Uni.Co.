
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


-- CREAZIONE VISTA getcostididattica
IF EXISTS(select * from sysobjects where id = object_id(N'[getcostididattica]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getcostididattica]
GO


CREATE   VIEW [getcostididattica]
AS
select 
	--indici
	a.idcorsostudio,a.aa, a.idsede, a.iddidprog, a.iddidprogcurr, af.idinsegn, af.idinsegninteg , a.idaffidamento, a.idaffidamentokind, a.idreg_docenti, 
	isnull(ck.idcontrattokind,1000) as idcontrattokind,
	--label
	cs.title as corsostudio, s.title as sede, d.aa as aaprogrammata, cu.title as curriculum, i.denominazione as insegnamento, ii.denominazione as modulo, 
	isnull(ak.title,'') + ' ' + isnull(akco.title,'') as affidamento, 
	doc.title as docente, isnull(ck.title,'Ruolo non definito') as ruolo,
	--parametri da cui dipende il calcolo
	CASE WHEN isnull(ak.costoorariodacontratto,'N') = 'S' THEN 'SI' ELSE 'NO' END as costoorariodacontratto,
	 --ak.costoora,akco.costoora, c.costoora,ora,ripetizioni,
	--costo
	sum(ora*isnull(ripetizioni,1)* 
		CASE WHEN isnull(ak.costoorariodacontratto,'N') = 'S' THEN isnull(c.costoora,0) ELSE isnull(akco.costoora,0) END
	) as costo
from affidamentocaratteristicaora aco
	INNER JOIN affidamento a on a.idaffidamento = aco.idaffidamento
	inner join affidamentokind ak on ak.idaffidamentokind = a.idaffidamentokind
	left outer join affidamentokindcostoora akco on akco.idaffidamentokind = a.idaffidamentokind and akco.aa = a.aa
	inner join corsostudio as cs on cs.idcorsostudio = a.idcorsostudio
	inner join sede s on s.idsede = a.idsede
	inner join didprog d on d.iddidprog = a.iddidprog
	inner join didprogcurr cu on cu.iddidprogcurr = a.iddidprogcurr
	inner join attivform af on af.idattivform = a.idattivform 
	inner join insegn i on i.idinsegn = af.idinsegn
	left outer join insegninteg ii on ii.idinsegninteg = af.idinsegninteg 
	left outer join registry doc on doc.idreg = a.idreg_docenti
	left outer join getcontratti c on c.idreg = a.idreg_docenti and NOT(isnull(c.stop,'20400101') < a.start or c.start > a.stop)
	left outer join contrattokind ck on ck.idcontrattokind = c.idcontrattokind
group by a.idcorsostudio,a.aa, a.idsede, a.iddidprog, a.iddidprogcurr,af.idinsegn, af.idinsegninteg , a.idaffidamento, a.idaffidamentokind, a.idreg_docenti, ck.idcontrattokind,
	cs.title, s.title, d.aa, cu.title, i.denominazione, ii.denominazione, doc.title, ak.title, akco.title, ck.title,
	isnull(ak.costoorariodacontratto,'N')--,ak.costoora,akco.costoora, c.costoora,ora,ripetizioni
--order by a.idcorsostudio,a.aa, a.idsede, a.iddidprog, a.iddidprogcurr, a.idaffidamento, a.idreg_docenti, ck.idcontrattokind



GO

