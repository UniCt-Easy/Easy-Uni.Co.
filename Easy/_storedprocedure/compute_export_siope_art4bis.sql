/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_export_siope_art4bis]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_export_siope_art4bis]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 
-- setuser 'amministrazione'
-- exec  [compute_export_siope_art4bis] 2025, NULL
--go
-- exec  [compute_export_siope_art4bis_test] 2025, NULL
CREATE PROCEDURE [compute_export_siope_art4bis]
(
	@ayear smallint,
	@trimestre int null
)
AS BEGIN
DECLARE @codesorkind_siopespese varchar(20)
SET @codesorkind_siopespese   = 'SIOPE_U_18'
 
declare @idsorkind_siope int
select  @idsorkind_siope = idsorkind from sortingkind where codesorkind=@codesorkind_siopespese

	/*
	USCITE CORRENTI
	- acquisto di beni e servizi = Siope con codici simili a 103%
	- contributi in conto esercizio= Siope con codici simili a 104% (??)
	- interessi passivi = Siope con codici simili a 107%
	- altre spese per attività finanziarie = Siope con codici simili a 304% "Altre spese per incremento di attività finanziarie"
	- altre spese correnti = Siope con codici simili a 110%

	USCITE IN CONTO CAPITALE
	-investimenti in beni materiali= Siope con codici simili a 20201%
	-investimenti in beni immateriali = Siope con codici simili a 20203%
	-investimenti in attività finanziarie = Siope con codici simili a 3%
	- contributi in conto capitale = Siope con codici simili a 203% 
	- altre spese in conto capitale = Siope con codici simili a 205%
	*/
--- UNISALENTO
-- -Non mappare il codice Siope 205%

--- Siope 1080201001 mappare con Altre spese correnti
--- Siope 1089901001 e 1089999999 mappare con Altre spese per attività finanziarie

SELECT  @ayear as 'Anno di riferimento del pagamento',
	DATEPART(q,pt.transmissiondate) as 'Trimestre',
	S.sortcode as 'Codice SIOPE',
	S.description as 'Descrizione SIOPE',
	CASE WHEN 
		(S.sortcode LIKE '103'+'%' OR  --acquisto di beni e servizi 
			S.sortcode LIKE '104'+'%' OR  --contributi in conto esercizio
			S.sortcode LIKE '107'+'%' OR  --interessi passivi
			S.sortcode LIKE '110'+'%' OR   --altre spese correnti
			S.sortcode LIKE '1080201001'+'%' OR	-- 'altre spese correnti'
			S.sortcode LIKE '1089901001'+'%' OR	 --'altre spese per attività finanziarie'
			S.sortcode LIKE '1089999999'+'%' OR   -- 'altre spese per attività finanziarie'
			S.sortcode LIKE '304'+'%'   --altre spese per incremento di attività finanziarie
			) THEN 'Uscite Correnti'
	WHEN (
			S.sortcode LIKE '20201'+'%' OR   --investimenti in beni materiali
			S.sortcode LIKE '20203'+'%' OR   --investimenti in beni immateriali
			S.sortcode LIKE '3'+'%' OR		  --investimenti in attività finanziarie
			S.sortcode LIKE '203'+'%'  	  --contributi in conto capitale
 
			) THEN  'Uscite in Conto Capitale'
		ELSE NULL
	END as 'Categoria di spesa',

	CASE WHEN S.sortcode LIKE '103'+'%' THEN 'acquisto di beni e servizi' 
		WHEN S.sortcode LIKE '104'+'%' THEN 'contributi in conto esercizio'
		WHEN S.sortcode LIKE '107'+'%' THEN 'interessi passivi'
		WHEN S.sortcode LIKE '1080201001'+'%' THEN	 'altre spese correnti'
		WHEN S.sortcode LIKE '1089901001'+'%' THEN	 'altre spese per attività finanziarie'
		WHEN S.sortcode LIKE '1089999999'+'%' THEN	 'altre spese per attività finanziarie'
		WHEN S.sortcode LIKE '304'+'%' THEN 'altre spese per incremento di attività finanziarie'
		WHEN S.sortcode LIKE '110'+'%' THEN 'altre spese correnti'
		WHEN S.sortcode LIKE '20201'+'%' THEN   'investimenti in beni materiali'
		WHEN S.sortcode LIKE '20203'+'%' THEN   'investimenti in beni immateriali'
		WHEN S.sortcode LIKE '3'+'%' THEN		 'investimenti in attività finanziarie'
		WHEN S.sortcode LIKE '203'+'%' THEN	 'contributi in conto capitale'
		ELSE NULL
	END as 'Tipologia di spesa', 
	--R.p_iva ,
	--R.cf, 
	--R.foreigncf ,
	--CASE
	-- Estrae la parte numerica se partita iva IT dopo eventuale prefisso paese di 2 lettere solo se non si tratta di persona fisica
	--WHEN R.idregistryclass  in('21','23','24','25') AND 
	--LEN(RTRIM(LTRIM(
	--		CASE 
	--		WHEN  
	--		LEFT(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf)))), 2) LIKE '[A-Z][A-Z]'
	--		AND LEFT(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf)))), 2) LIKE 'IT' 
	--		THEN SUBSTRING(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf)))), 3, LEN(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf))))) - 2)
	--		ELSE ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf))))
	--		END))) = 11
	--		AND ISNUMERIC(
	--		CASE 
	--		WHEN LEFT(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf)))), 2) LIKE '[A-Z][A-Z]' 
	--		AND LEFT(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf)))), 2) LIKE 'IT' 
	--		THEN SUBSTRING(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf)))), 3, LEN(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf))))) - 2)
	--		ELSE ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf))))
	--		END) = 1
	--THEN 
	--		CASE 
	--		WHEN LEFT(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf)))), 2) LIKE '[A-Z][A-Z]' 
	--		AND LEFT(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf)))), 2) LIKE 'IT' 
	--		THEN SUBSTRING(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf)))), 3, LEN(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf))))) - 2)
	--		ELSE ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf))))
	--		END
	----- partita iva estera UE
	--WHEN  R.idregistryclass  in('21','23','24','25') AND   
	--		LEFT(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf)))), 2) LIKE '[A-Z][A-Z]' 
	--		AND LEFT(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf)))), 2) IN
	--		('AT','BE','BG','CY','DK','EE','FI','FR','DE','EL','EU','IE','XI','LV',
	--			'LT','LU','MT','NL','PL','PT','CZ','GB','RO','SK','SI','ES','SE','HU')
	--	THEN 
	--		ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf))))
	--	--- partita iva estera CHE Svizzera
	--WHEN  R.idregistryclass  in('21','23','24','25') AND   
	--		LEFT(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf)))), 3) LIKE '[A-Z][A-Z][A-Z]' 
	--		AND LEFT(ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf)))), 3) IN
	--		('CHE')
	--	THEN 
	--		ltrim(rtrim(isnull(R.p_iva,isnull(R.cf,R.foreigncf))))
	--ELSE '' --persona fisica oppure formato errato
--END  + ' ' + 
	CASE
		WHEN (R.idregistryclass  in('21','23','24','25') and isnull(RD.coderesidence,'I') = 'I')  THEN 'Altro soggetto pubblico e privato' 
		WHEN (R.idregistryclass  in('21','23','24','25') and isnull(RD.coderesidence,'I') <> 'I') THEN 'Soggetto estero' 
		/*
		Società, enti commerciali, ditte individuali e studi associati
		Persona Fisica
		Enti non commerciali ed istituzioni internazionali
		*/
		WHEN (R.idregistryclass  = '22'   or  len(ltrim(rtrim(isnull(R.cf,R.foreigncf) )) )  = 16)    THEN 'Persona Fisica'
		ELSE 'Altro soggetto pubblico e privato'
	END
	as 'Beneficiario',
	--R.title, 
	--R.idregistryclass, 
	FORMAT(SUM(ES.amount), 'N2', 'it-IT') as 'Importo'
	from expenselast EL
		JOIN expensesorted ES on EL.idexp=ES.idexp
		JOIN sorting S on ES.idsor=S.idsor
		JOIN expense E on E.idexp=EL.idexp
		JOIN registry R on E.idreg=R.idreg
		LEFT OUTER JOIN residence RD on R.residence = RD.idresidence
		JOIN payment p ON el.KPAY=P.KPAY
		JOIN PAYMENTTRANSMISSION pt ON PT.KPAYMENTTRANSMISSION = p.KPAYMENTTRANSMISSION
		WHERE pt.YPAYMENTTRANSMISSION=@AYEAR
		AND S.idsorkind = @idsorkind_siope --TASK 10547 Aggiunta condizione (prima la variabile @idsorkind_siope era dichiarata, valorizzata ma non usata)
		AND (S.sortcode LIKE '103'+'%' OR  --acquisto di beni e servizi 
			S.sortcode LIKE '104'+'%' OR  --contributi in conto esercizio
			S.sortcode LIKE '107'+'%' OR  --interessi passivi
			S.sortcode LIKE '304'+'%' OR  --altre spese per incremento di attività finanziarie
			S.sortcode LIKE '110'+'%' OR   --altre spese correnti
			S.sortcode LIKE '20201'+'%' OR   --investimenti in beni materiali
			S.sortcode LIKE '20203'+'%' OR   --investimenti in beni immateriali
			S.sortcode LIKE '3'+'%'	OR		  --investimenti in attività finanziarie
			S.sortcode LIKE '203'+'%' OR	  --contributi in conto capitale
			S.sortcode LIKE '1080201001'+'%' OR	-- 'altre spese correnti'
			S.sortcode LIKE '1089901001'+'%' OR	 --'altre spese per attività finanziarie'
			S.sortcode LIKE '1089999999'+'%'     -- 'altre spese per attività finanziarie'
			)
		AND (DATEPART(q,pt.transmissiondate) = @trimestre or @trimestre IS NULL)
	 
		group by S.sortcode,R.cf, R.foreigncf ,p_iva,R.title,S.description,DATEPART(q,pt.transmissiondate ),R.idregistryclass,
		R.residence, RD.coderesidence
		having SUM(ES.amount) <> 0
		order by DATEPART(q,pt.transmissiondate ),S.sortcode,R.cf, R.foreigncf ,p_iva
 
 
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec  [compute_export_siope_art4bis] 2025, NULL
--go
--exec  [compute_export_siope_art4bis_test] 2025, NULL
