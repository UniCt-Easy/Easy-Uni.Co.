
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


-- CREAZIONE VISTA ivapaydetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[ivapaydetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [ivapaydetailview]
GO







CREATE  VIEW [ivapaydetailview]
(
	yivapay,
	nivapay,
	start,
	stop,
	idivaregisterkind,
	codeivaregisterkind,
	description,
	registerclass,
	iva,
	ivadeferred,
	ivatotal,
	unabatable,
	unabatabledeferred,
	unabatabletotal,
	prorata,
	mixed,
	ivanet,
	ivanetdeferred,
	flagactivity,
	cu, 
	ct, 
	lu, 
	lt,
	idtreasurer,
	department
	)
	AS SELECT
	ivapaydetail.yivapay,
	ivapaydetail.nivapay,
	ivapay.start,
	ivapay.stop,
	ivapaydetail.idivaregisterkind,
	ivaregisterkind.codeivaregisterkind,
	ivaregisterkind.description,
	ivaregisterkind.registerclass,
	ivapaydetail.iva,
	ivapaydetail.ivadeferred,
	ISNULL(ivapaydetail.iva,0) + ISNULL(ivapaydetail.ivadeferred,0),
	ivapaydetail.unabatable,
	ivapaydetail.unabatabledeferred,
	ISNULL(ivapaydetail.unabatable,0) + ISNULL(ivapaydetail.unabatabledeferred,0),
	ivapaydetail.prorata,
	ivapaydetail.mixed,
	ivapaydetail.ivanet,
	ivapaydetail.ivanetdeferred,
	ivaregisterkind.flagactivity,
	ivapaydetail.cu, 
	ivapaydetail.ct, 
	ivapaydetail.lu,
	ivapaydetail.lt,
	ivaregisterkind.idtreasurer,
	isnull(treasurer.header,treasurer.description)
	FROM ivapaydetail (NOLOCK)
	JOIN ivaregisterkind (NOLOCK)
	ON ivaregisterkind.idivaregisterkind = ivapaydetail.idivaregisterkind
  JOIN ivapay (NOLOCK)
	ON ivapay.nivapay = ivapaydetail.nivapay
	AND ivapay.yivapay = ivapaydetail.yivapay
 left outer join treasurer (NOLOCK)
	ON treasurer.idtreasurer = ivaregisterkind.idtreasurer
	

GO

--clear_table_info 'ivapaydetailview'
--select * from ivapaydetailview
