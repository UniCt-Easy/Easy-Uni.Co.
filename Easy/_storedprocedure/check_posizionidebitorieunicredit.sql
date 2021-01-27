
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_posizionidebitorieunicredit ]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_posizionidebitorieunicredit ]
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE        PROCEDURE [check_posizionidebitorieunicredit](
    @n int
)
AS BEGIN


CREATE TABLE #error (message varchar(400))


-- controllo presenza  Codice Ente nel cassiere
IF(
select TOP  1 T.agencycodefortransmission from treasurer T
	JOIN flussocrediti F
	on isnull(T.idsor01,'') = isnull(F.idsor01,'') and   isnull(T.idsor02,'') = isnull(F.idsor02,'') and isnull(T.idsor03,'') = isnull(F.idsor03,'') 
				and isnull(T.idsor04,'') = isnull(F.idsor04,'') and   isnull(T.idsor05,'') = isnull(F.idsor05,'') 
	WHERE F.idflusso = @n		
) is null
Begin
	INSERT INTO #error (message)
	SELECT 'Manca il Codice Cliente censito sulla Piattaforma Incassi ed attribuito alla PA. Andare nella maschera Opzioni - Tesoriere - Tesoriere, ed inserire Codice Ente'
End

-- Controllo presenza del campo Codice Tipo Flusso censito ed associato al servizio d’incasso sulla Piattaforma Incassi, come comunicato dalla Banca per ogni servizio( flussocrediticode)
IF(
select TOP  1 T.flussocrediticode from treasurer T
	JOIN flussocrediti F
	on isnull(T.idsor01,'') = isnull(F.idsor01,'') and   isnull(T.idsor02,'') = isnull(F.idsor02,'') and isnull(T.idsor03,'') = isnull(F.idsor03,'') 
				and isnull(T.idsor04,'') = isnull(F.idsor04,'') and   isnull(T.idsor05,'') = isnull(F.idsor05,'') 
	WHERE F.idflusso = @n		
) is null
Begin
	INSERT INTO #error (message)
	SELECT 'Manca il Codice Tipo Flusso censito ed associato al servizio d’incasso sulla Piattaforma Incassi. Andare nella maschera Opzioni - Tesoriere - Tesoriere, ed inserire Codice Ente'
End


-- Controllo presenza data scadenza nel dettaglio C.A.
IF(
(SELECT COUNT(*) FROM flussocreditidetail FD
	where FD.idflusso = @n and FD.expirationdate is null) > 0)
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Il dettaglio: ' + FD.description + ', relativo al Contratto Attivo: '+ K.description +' / Eserc. '+CONVERT(varchar(6), ED.yestim) + ' / Num. '+ CONVERT(varchar(6), ED.nestim)
	+ ', non ha Data Scadenza.'
	FROM flussocreditidetail FD
	JOIN estimatedetail ED
		on ED.idestimkind = FD.idestimkind and ED.yestim = FD.yestim and  ED.nestim = FD.nestim and ED.rownum = FD.rownum
	join estimatekind K
		on ED.idestimkind = K.idestimkind
	where FD.idflusso = @n and FD.expirationdate is null
	)
END

-- Controllo presenza data scadenza nella Fattura di Vendita
IF(
(SELECT COUNT(*) FROM flussocreditidetail FD
	where FD.idflusso = @n and FD.expirationdate is null) > 0)
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Il dettaglio: ' + FD.description + ', relativo alla fattura: '+ K.description + ' / Eserc. '+CONVERT(varchar(6), I.yinv) + ' / Num. '+ CONVERT(varchar(6), I.ninv)
	+ ', non ha Data Scadenza.'
	FROM flussocreditidetail FD
	JOIN invoice I
		on I.idinvkind = FD.idinvkind and I.yinv = FD.yinv and  I.ninv = FD.nestim 
	join invoicekind K
		on I.idinvkind = K.idinvkind
	where FD.idflusso = @n and FD.expirationdate is null
	)
END
-- Controllo CF e p.iva nei C.A.
IF(
SELECT COUNT(*)
	FROM flussocrediti F
	JOIN flussocreditidetail FD
		on F.idflusso = FD.idflusso
	JOIN estimate E
		on E.idestimkind = FD.idestimkind and E.yestim = FD.yestim and  E.nestim = FD.nestim 
	JOIN registry R
		on R.idreg = E.idreg
	WHERE F.idflusso = @n and R.cf is null and R.p_iva is null and R.foreigncf is null)>0
Begin
	INSERT INTO #error (message)
	(SELECT 'L''anagrafica: ' + R.title + ', codice: '+CONVERT(varchar(10), R.idreg) + ', è priva di Codice Fiscale, Partita IVA e CF estero. Valorizzare almeno un dato.'
	FROM flussocrediti F
	JOIN flussocreditidetail FD
		on F.idflusso = FD.idflusso
	JOIN estimate E
		on E.idestimkind = FD.idestimkind and E.yestim = FD.yestim and  E.nestim = FD.nestim 
	JOIN registry R
		on R.idreg = E.idreg
	WHERE F.idflusso = @n and R.cf is null and R.p_iva is null and R.foreigncf is null
	)	
End	

-- Controllo CF e p.iva nelle Fatture di Vendita
IF(
SELECT COUNT(*)
	FROM flussocrediti F
	JOIN flussocreditidetail FD
		on F.idflusso = FD.idflusso
	JOIN invoice I
		on I.idinvkind = FD.idinvkind and I.yinv = FD.yinv and I.ninv = FD.ninv
	JOIN registry R
		on R.idreg = I.idreg
	WHERE F.idflusso = @n and R.cf is null and R.p_iva is null and R.foreigncf is null)>0
Begin
	INSERT INTO #error (message)
	(SELECT 'L''anagrafica: ' + R.title + ', codice: '+CONVERT(varchar(10), R.idreg) + ', è priva di Codice Fiscale, Partita IVA e CF estero. Valorizzare almeno un dato.'
	FROM flussocrediti F
	JOIN flussocreditidetail FD
		on F.idflusso = FD.idflusso
	JOIN invoice I
		on I.idinvkind = FD.idinvkind and I.yinv = FD.yinv and I.ninv = FD.ninv
	JOIN registry R
		on R.idreg = I.idreg
	WHERE F.idflusso = @n and R.cf is null and R.p_iva is null and R.foreigncf is null
	)	
End		

SELECT * FROM #error




END


GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

--exec check_posizionidebitorieunicredit  25
