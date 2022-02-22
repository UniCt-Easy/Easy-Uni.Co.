
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


-- CREAZIONE VISTA wstransmissionview
IF EXISTS(select * from sysobjects where id = object_id(N'[wstransmissionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [wstransmissionview]
GO



CREATE     VIEW [wstransmissionview]
AS
SELECT  

	T.idwstransmission, T.idflussocrediti, T.idflussocreditidetail,
	S.idwstransmissionstatus,
	S.description as wstransmissionstatus,
	T.serverresponse,
	T.is_successtransaction,
	DETT_CRED.idreg, R.cf, DETT_CRED.iuv, 
	isnull(DETT_CRED.importoversamento,0) + isnull(DETT_CRED.tax,0) as importoversamento,
	CASE WHEN exists(select * from flussoincassi I
						join flussoincassidetail Idett 
							on I.idflusso = Idett.idflusso
						where Idett.iuv = DETT_CRED.iuv)
		THEN (select I.dataincasso from flussoincassi I
					join flussoincassidetail Idett 
					on I.idflusso = Idett.idflusso
				where Idett.iuv = DETT_CRED.iuv)

		WHEN exists	(select * from flussoricevutatelematica RT
					where RT.iuv = DETT_CRED.iuv and codiceesitopagamento=0)
				THEN (select RT.dataesitopagamento from flussoricevutatelematica RT
					where RT.iuv = DETT_CRED.iuv  and codiceesitopagamento=0) --> 0 Pagamento eseguit
		END
		as dataesitopagamento
,
	T.codeservice
 from wstransmission T
join flussocreditidetail DETT_CRED	           
	on T.idflussocrediti = DETT_CRED.idflusso 
	and T.idflussocreditidetail = DETT_CRED.iddetail
join registry R
	on DETT_CRED.idreg = R.idreg	
join wstransmissionstatus S
	on S.idwstransmissionstatus = T.idwstransmissionstatus





GO
