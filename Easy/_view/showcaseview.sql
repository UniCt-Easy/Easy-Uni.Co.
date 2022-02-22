
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


-- CREAZIONE VISTA showcaseview
IF EXISTS(select * from sysobjects where id = object_id(N'[showcaseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [showcaseview]
GO
--setuser 'amm'

CREATE  view showcaseview as
(
	select showcase.idshowcase ,
	showcase.title ,
	showcase.description ,
	showcase.paymentexpiring ,
	showcase.idstore ,
	store.description as store ,
	store.deliveryaddress,
	showcase.flagldapvisibility 
    from showcase 
	join store on showcase.idstore = store.idstore 
)


GO


