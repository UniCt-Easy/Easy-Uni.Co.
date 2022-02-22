
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


-- CREAZIONE VISTA showcasedetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[showcasedetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [showcasedetailview]
GO



--setuser 'amm'
-- select * from showcasedetailview


CREATE  view [showcasedetailview]
as
(
	select showcasedetail.idshowcase as idshowcase,
		   showcase.idstore as idstore,
		   stocktotalview.store as store,
		   showcasedetail.idlist as idlist,
		   stocktotalview.list as list,
		   stocktotalview.intcode as intcode,
		   stocktotalview.idlistclass as idlistclass,
		   stocktotalview.codelistclass as codelistclass,
		   stocktotalview.listclass as listclass,
		   stocktotalview.number as number,
		   stocktotalview.ordered as ordered,
		   stocktotalview.booked as booked,
		   showcasedetail.idinvkind as idinvkind,
		   showcasedetail.competencystart as competencystart,
		   showcasedetail.competencystop as competencystop,
		   showcasedetail.idupb_iva as idupb_iva,
		   tassonomia_pagopa.title as tassonomia,
		   tassonomia_pagopa.causale as codicetassonomia

	from showcasedetail join showcase on (showcasedetail.idshowcase=showcase.idshowcase)
						join stocktotalview on (showcasedetail.idlist=stocktotalview.idlist and showcase.idstore=stocktotalview.idstore)
						left outer join list on list.idlist=showcasedetail.idlist
						left outer join tassonomia_pagopa on tassonomia_pagopa.idtassonomia=list.idtassonomia
)



GO

