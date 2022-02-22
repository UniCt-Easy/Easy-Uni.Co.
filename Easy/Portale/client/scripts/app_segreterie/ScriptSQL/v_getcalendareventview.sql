
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


--setuser 'amministrazione'
IF EXISTS(select * from sysobjects where id = object_id(N'[getcalendareventview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getcalendareventview]
GO

CREATE VIEW [getcalendareventview]
AS
select 'Pink' as color, description as title, start, stop, null as data, null as ore, idreg, 
	0 as idlezione, 0 as idassetdiary, 0 as idrendicontattivitaprogetto, 0 as iddidprog, 0 as idaffidamento, 0 as idsospensione, 0 as idrendicontaltro, 0 as idasset, 0 as idpiece
from itineration 
union
select 'LightBlue' as color, title, start, stop, null as data, null as ore, idreg_docenti as idreg, 
	idlezione, 0 as idassetdiary, 0 as idrendicontattivitaprogetto, iddidprog, idaffidamento, 0 as idsospensione, 0 as idrendicontaltro, 0 as idasset, 0 as idpiece
from lezioneview 
union
select 'Orange' as color, title, adow.start, adow.stop, null as data, null as ore, ad.idreg, 
	0 as idlezione, ad.idassetdiary, 0 as idrendicontattivitaprogetto, 0 as iddidprog, 0 as idaffidamento, 0 as idsospensione, 0 as idrendicontaltro, ad.idasset, ad.idpiece
from assetdiaryoraview adow
inner join assetdiary ad on adow.idassetdiary = ad.idassetdiary 
union
select 'Gold' as color, motivo as title, start, stop, null as data, null as ore, idreg, 
	0 as idlezione, 0 as idassetdiary, 0 as idrendicontattivitaprogetto, 0 as iddidprog, 0 as idaffidamento, idsospensione, 0 as idrendicontaltro, 0 as idasset, 0 as idpiece
from sospensione where idreg  <> (select idreg from istitutoprinc) 
union
select 'red' as color, motivo as title, start, stop, null as data, null as ore, idreg, 
	0 as idlezione, 0 as idassetdiary, 0 as idrendicontattivitaprogetto, 0 as iddidprog, 0 as idaffidamento, 0 as idsospensione, 0 as idrendicontaltro, 0 as idasset, 0 as idpiece
from sospensione where idreg  = (select idreg from istitutoprinc) 
union
select 'PaleGreen' as color, titleancestor as title, data as start, null as stop, data, ore, idreg, 
	0 as idlezione, 0 as idassetdiary, idrendicontattivitaprogetto, 0 as iddidprog, 0 as idaffidamento, 0 as idsospensione, 0 as idrendicontaltro, 0 as idasset, 0 as idpiece
from rendicontattivitaprogettooraview 
union
select 'Brown' as color, replace(cast(isnull(ra.ore,0) as varchar(10)),'.00','') + ' ore per ' + rak.title, data as start, null as stop, ra.data, ra.ore, idreg_docenti as idreg, 
	0 as idlezione, 0 as idassetdiary, 0 as idrendicontattivitaprogetto, 0 as iddidprog, 0 as idaffidamento,0 as idsospensione, idrendicontaltro, 0 as idasset, 0 as idpiece
from rendicontaltro ra inner join rendicontaltrokind rak on ra.idrendicontaltrokind = rak.idrendicontaltrokind 
GO


