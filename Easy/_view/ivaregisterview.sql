
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


-- CREAZIONE VISTA ivaregisterview
IF EXISTS(select * from sysobjects where id = object_id(N'[ivaregisterview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [ivaregisterview]
GO

CREATE                               VIEW ivaregisterview 
  (
	idivaregisterkind,
	ivaregisterkind,
	codeivaregisterkind,
	registerclass,
	yivaregister,
	nivaregister,
 	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flagdeferred,
	idreg,
	registry,
	doc,
	docdate,
	adate,
	protocolnum,
	cu,
	ct,
	lu,
	lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
  )
  AS SELECT
	ivaregister.idivaregisterkind,
	ivaregisterkind.description,
	ivaregisterkind.codeivaregisterkind,
	ivaregisterkind.registerclass,
	ivaregister.yivaregister,
	ivaregister.nivaregister,
 	ivaregister.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	ivaregister.yinv,
	ivaregister.ninv,
	invoice.flagdeferred,
	invoice.idreg,
	registry.title,
	invoice.doc,
	invoice.docdate,
	invoice.adate,
	ivaregister.protocolnum,
	ivaregister.cu,
	ivaregister.ct,
	ivaregister.lu,
	ivaregister.lt,
	isnull(invoice.idsor01,invoicekind.idsor01),
	isnull(invoice.idsor02,invoicekind.idsor02),
	isnull(invoice.idsor03,invoicekind.idsor03),
	isnull(invoice.idsor04,invoicekind.idsor04),
	isnull(invoice.idsor05,invoicekind.idsor05)		
  	FROM ivaregister (NOLOCK)
	JOIN ivaregisterkind (NOLOCK)
	ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	JOIN invoicekind (NOLOCK)
	ON invoicekind.idinvkind = ivaregister.idinvkind
	JOIN invoice (NOLOCK)
	ON invoice.idinvkind = ivaregister.idinvkind
  	AND invoice.yinv = ivaregister.yinv
  	AND invoice.ninv = ivaregister.ninv
	JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg



GO
