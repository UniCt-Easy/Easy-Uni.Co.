
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


-- CREAZIONE VISTA estimateattachmentview
IF EXISTS(select * from sysobjects where id = object_id(N'[estimateattachmentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [estimateattachmentview]
GO


--drop view [estimateattachmentview]
--setuser 'amministrazione'
-- select * from [estimateattachmentview]
CREATE VIEW [estimateattachmentview] 
	(
	kpro,
	idinc,
	idestimkind,
	yestim,
	nestim,
	idattachment
	)
	AS SELECT
	IL.kpro,
	I.idinc,
	E.idestimkind,
	E.yestim,
	E.nestim,
	EA.idattachment
	FROM income I (NOLOCK)
	JOIN incomelast IL (NOLOCK) ON IL.idinc = I.idinc
	JOIN incomelink ILK (NOLOCK) ON ILK.idchild = IL.idinc
	JOIN incomeestimate IE (NOLOCK) ON IE.idinc = ILK.idparent
	JOIN estimate E (NOLOCK) ON  E.idestimkind = IE.idestimkind AND  E.yestim = IE.yestim AND E.nestim = IE.nestim
	JOIN (select idestimkind, yestim, nestim, idattachment from estimateattachment) EA ON E.idestimkind = EA.idestimkind AND E.yestim = EA.yestim AND E.nestim = EA.nestim
	

GO


