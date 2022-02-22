
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_export_siope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_export_siope]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- setuser 'amministrazione'
-- exec  compute_export_siope 2021
CREATE PROCEDURE [compute_export_siope]
(
	@ayear smallint
)
AS BEGIN
DECLARE @codesorkind_siopespese varchar(20)

IF (@ayear<= 2017) 
	BEGIN
		 SET @codesorkind_siopespese   = '07U_SIOPE'
	END
ELSE
	BEGIN
		 SET @codesorkind_siopespese   = 'SIOPE_U_18'
	END

	declare @idsorkind_siope int
	select  @idsorkind_siope = idsorkind from sortingkind where codesorkind=@codesorkind_siopespese

	IF EXISTS (SELECT * FROM license WHERE ISNULL(p_iva, CF)='02044190615')
	Begin
		select  @ayear as 'Anno',
			S.sortcode as 'Codice SIOPE',
			S.description as 'Descrizione SIOPE',
			R.p_iva as 'P.Iva',
			R.title as 'ragione sociale',
			sum(ES.amount) as 'Pagato',
			pt.transmissiondate as 'Data Pagamento'
		
			from expenselast EL
				join expensesorted ES on EL.idexp=ES.idexp
				join sorting S on ES.idsor=S.idsor
				join expense E on E.idexp=EL.idexp
				join registry R on E.idreg=R.idreg
				join payment p ON el.KPAY=P.KPAY
				JOIN PAYMENTTRANSMISSION pt ON PT.KPAYMENTTRANSMISSION = p.KPAYMENTTRANSMISSION
				WHERE pt.YPAYMENTTRANSMISSION=@AYEAR
				AND S.idsorkind = @idsorkind_siope --TASK 10547 Aggiunta condizione (prima la variabile @idsorkind_siope era dichiarata, valorizzata ma non usata)
				AND S.sortcode NOT BETWEEN '1111' AND '1471' --RISORSE UMANE
				AND S.sortcode NOT in ('1530','1560','1581') --del ramo 15% vanno pubblicate le voci elencate nel task 11445
				AND S.sortcode NOT BETWEEN '4311' AND '4337' --IMPOSTE e TASSE
				AND S.sortcode NOT BETWEEN '5110' AND '5120' --Altre spese correnti
				AND S.sortcode NOT BETWEEN '8110' AND '8500' --RIMBORSO DI PRESTITI
				AND S.sortcode NOT BETWEEN '9110' AND '9999' --PARTITE DI GIRO
				group by S.sortcode,isnull(R.cf,R.foreigncf),p_iva,R.title,S.description,pt.transmissiondate
				order by S.sortcode,isnull(R.cf,R.foreigncf),p_iva
	End
	else
		Begin
		select  @ayear as 'Anno',
			S.sortcode as 'Codice SIOPE',
			S.description as 'Descrizione SIOPE',
			isnull(R.cf,R.foreigncf) as 'C.F.',
			R.p_iva as 'P.Iva',
			R.title as 'ragione sociale',
			sum(ES.amount) as 'Pagato',
			pt.transmissiondate as 'Data Pagamento'
		
			from expenselast EL
				join expensesorted ES on EL.idexp=ES.idexp
				join sorting S on ES.idsor=S.idsor
				join expense E on E.idexp=EL.idexp
				join registry R on E.idreg=R.idreg
				join payment p ON el.KPAY=P.KPAY
				JOIN PAYMENTTRANSMISSION pt ON PT.KPAYMENTTRANSMISSION = p.KPAYMENTTRANSMISSION
				WHERE pt.YPAYMENTTRANSMISSION=@AYEAR
				AND S.idsorkind = @idsorkind_siope --TASK 10547 Aggiunta condizione (prima la variabile @idsorkind_siope era dichiarata, valorizzata ma non usata)
				AND S.sortcode NOT BETWEEN '1111' AND '1471' --RISORSE UMANE
				AND S.sortcode NOT in ('1530','1560','1581') --del ramo 15% vanno pubblicate le voci elencate nel task 11445
				AND S.sortcode NOT BETWEEN '4311' AND '4337' --IMPOSTE e TASSE
				AND S.sortcode NOT BETWEEN '5110' AND '5120' --Altre spese correnti
				AND S.sortcode NOT BETWEEN '8110' AND '8500' --RIMBORSO DI PRESTITI
				AND S.sortcode NOT BETWEEN '9110' AND '9999' --PARTITE DI GIRO
				group by S.sortcode,isnull(R.cf,R.foreigncf),p_iva,R.title,S.description,pt.transmissiondate
				order by S.sortcode,isnull(R.cf,R.foreigncf),p_iva
	End

END
GO

