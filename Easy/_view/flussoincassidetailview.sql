
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


-- CREAZIONE VISTA flussoincassidetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[flussoincassidetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [flussoincassidetailview]
GO
--setuser 'amm'
-- clear_table_info 'flussoincassidetailview'
CREATE VIEW [flussoincassidetailview]
AS
SELECT   flussoincassidetail.idflusso, 
         flussoincassidetail.iddetail, 
		 flussoincassidetail.importo, 
		 flussoincassidetail.iuv, 
		 flussoincassidetail.cf, 
		 flussoincassidetail.lt, 
         flussoincassidetail.lu, 
		 flussoincassidetail.ct, 
		 flussoincassidetail.cu, 
		 flussoincassidetail.iduniqueformcode,
		 flussoincassi.codiceflusso,
		 flussoincassi.nbill,
		 flussoincassi.trn,
		 flussoincassi.dataincasso,
		 flussoincassi.ayear, 
		 flussoincassi.causale,
		 flussoincassi.importo as importotale,
		 flussoincassi.active,
		 flussoincassi.elaborato

FROM     flussoincassidetail 
	left outer JOIN flussoincassi 
	ON flussoincassidetail.idflusso = flussoincassi.idflusso

GO
