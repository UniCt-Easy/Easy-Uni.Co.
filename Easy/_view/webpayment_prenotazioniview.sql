
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


-- CREAZIONE VISTA webpayment_prenotazioniview
IF EXISTS(select * from sysobjects where id = object_id(N'[webpayment_prenotazioniview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [webpayment_prenotazioniview]
GO
--setuser setuser 'amm'
-- setuser setuser 'amministrazione'

--drop view webpayment_prenotazioniview
CREATE VIEW [webpayment_prenotazioniview] as
(
	select P.idwebpayment,
		P.ywebpayment,
		P.nwebpayment,
		P.forename,
		P.surname,
		P.email,
		P.idcustomuser,
		P.idflussocrediti,
		P.idlcard,
		P.iuv,
		P.idman,
		M.title as manager,
		R.idreg,
		R.title as registry,
		P.cf,
		R.p_iva,
		PS.idwebpaymentstatus,
		PS.description as webpaymentstatus,
		P.adate,
		P.qrcode,
		P.cu,
		P.ct,
		P.lu,
		P.lt 
	from webpayment P
	join registry R						on P.idreg = R.idreg
	left outer join manager M			on P.idman = M.idman
	join webpaymentstatus PS			on P.idwebpaymentstatus = PS.idwebpaymentstatus
)
 

GO


