
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


-- CREAZIONE VISTA invoicesellattachmentview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicesellattachmentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicesellattachmentview]
GO


--drop view [invoiceincomeattachmentview] 
 --setuser 'amministrazione'
-- select * from [invoicesellattachmentview]
CREATE VIEW [invoicesellattachmentview] 
	(
	kpro,
	idinc,
	idinvkind,
	yinv,
	ninv,
	idattachment
	)
	AS SELECT
	IL.kpro,
	I.idinc,
	IV.idinvkind,
	IV.yinv,
	IV.ninv,
	IA.idattachment
	FROM income I (NOLOCK)
	JOIN incomelast IL (NOLOCK) ON IL.idinc = I.idinc
	JOIN incomeinvoice II (NOLOCK) ON II.idinc = IL.idinc                                                       
	JOIN invoice IV (NOLOCK) ON  IV.idinvkind = II.idinvkind AND  IV.yinv = II.yinv AND IV.ninv = II.ninv
	JOIN (select idinvkind, yinv, ninv, idattachment from invoiceattachment) IA  ON IV.idinvkind = IA.idinvkind AND IV.yinv = IA.yinv AND IV.ninv = IA.ninv
	

GO
