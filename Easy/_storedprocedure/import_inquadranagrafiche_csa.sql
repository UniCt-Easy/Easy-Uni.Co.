
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


if exists (select * from dbo.sysobjects where id = object_id(N'[import_inquadranagrafiche_csa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [import_inquadranagrafiche_csa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec import_inquadranagrafiche_csa null
CREATE  PROCEDURE [import_inquadranagrafiche_csa](
	@LinkedServer varchar(200),
	@dbservername varchar(200),
	@matricolastart int,
	@matricolastop int
)
AS BEGIN

DECLARE @istance nvarchar(200)

DECLARE @EASY_INQUADRAMENTI nvarchar(4000)  -- Nome della vista degli inquadramenti
DECLARE @PAGAMENTI nvarchar(4000) -- Nome della vista delle mod. di pagamento delle anagrafiche.


IF(@LinkedServer is not null)
-- Si connette usando il LINKEDSERVER
Begin
	if ((select isnull(istance,'') from linkedserveraccess)<>'')
	Begin
		SET @istance = (SELECT istance FROM linkedserveraccess)+'.'
	End
	Else
	Begin
		SET @istance=''
	End

	DECLARE @OPENQUERY nvarchar(4000)
	SET @OPENQUERY = ' OPENQUERY('+ @LinkedServer + ','''

	SET @EASY_INQUADRAMENTI = @OPENQUERY + 'SELECT * FROM '+@istance+'EASY_INQUADRAMENTI'')' 
	SET @PAGAMENTI = @OPENQUERY + 'SELECT * FROM '+@istance+'EASY_MODALITA_PAGAMENTO_ANAGRAFICA'')' 
End
Else
-- Si connette usando il DB / SERVER
Begin
	-- SET @dbservername='[LILITH].[LKUGOVEASY].[DBO]'

	SET @EASY_INQUADRAMENTI = @dbservername +'.EASY_INQUADRAMENTI'
	SET @PAGAMENTI = @dbservername+'.EASY_MODALITA_PAGAMENTO_ANAGRAFICA' 
End


DECLARE @query_EASY_INQUADRAMENTI nvarchar(4000)
DECLARE @query_PAGAMENTI nvarchar(4000)


CREATE TABLE #INQUADRAMENTI
(
	matricola varchar(40),
	---------------------------------------------------------------
	------------INQUADRAMENTO E REDDITO ANNUO PRESUNTO-------------
	---------------------------------------------------------------
	datadecorrenza datetime,		-- --in_vigore_Econ, inizio validità inquadramento
	in_vigore_giur datetime, 
	imponpresunto decimal(19,2),	-- reddito annuo presunto
	classestipendiale int,			-- classe stipendiale
	codicequalifica	varchar(20),	-- codice qualifica
	codicequalifica_bdm	varchar(20),	-- codice qualifica
	iddaliaposition int,
	ruolo	varchar(4),
	termine datetime, 
	comparto	char (1),
	------------------------ note per l'utente ---------------------
	dettaglio varchar(300)
)

DECLARE @where_ANAGRAFICA nvarchar(1000)

IF (ISNULL(@matricolastart,0) <> 0 AND ISNULL(@matricolastop,0) <> 0)
BEGIN 
	SET @where_ANAGRAFICA = 
	' WHERE (XXX.matricola >= ' +  CONVERT(varchar(20),@matricolastart) + ' ) AND ' +
	'       (XXX.matricola <= ' +  CONVERT(varchar(20),@matricolastop)  + ' ) '
END
ELSE
 IF (ISNULL(@matricolastart,0) <> 0 )
	BEGIN
		SET @where_ANAGRAFICA = 
		' WHERE (XXX.matricola >= ' +  CONVERT(varchar(20),@matricolastart) + ' ) '
	END
	ELSE
		 IF (ISNULL(@matricolastop,0) <> 0 )
	BEGIN
		SET @where_ANAGRAFICA = 
		' WHERE (XXX.matricola <= ' +  CONVERT(varchar(20),@matricolastop) + ' ) '
	END

SET @query_EASY_INQUADRAMENTI = '
 INSERT INTO #INQUADRAMENTI(
	matricola,
	ruolo,
	comparto,
	datadecorrenza,
	termine,
	in_vigore_giur,
	imponpresunto
)

SELECT 
	I.matricola, 
	I.ruolo,
	I.comparto,
	I.datadecorrenza,
	I.termine,
	isnull(I.datadelibera,I.datadecorrenza),
	null--	I.imponibilepresunto
FROM ' + @EASY_INQUADRAMENTI + ' as I ' +
ISNULL(REPLACE(@where_ANAGRAFICA,'XXX.','I.'),'')  + 
' GROUP BY I.matricola,I.ruolo,I.comparto,I.datadecorrenza,
	I.termine,
	I.datadelibera' 

EXEC (@query_EASY_INQUADRAMENTI) 

-- UPDATE per valorizzare EVENTUALMENTE idposition
UPDATE #INQUADRAMENTI SET codicequalifica = idposition, 
				imponpresunto = supposedtaxable
			FROM csapositionlookup CSA_P
			WHERE CSA_P.csa_compartment = #INQUADRAMENTI.comparto 
				AND CSA_P.csa_role = #INQUADRAMENTI.Ruolo 

-- UPDATE per valorizzare EVENTUALMENTE iddaliaposition
UPDATE #INQUADRAMENTI SET iddaliaposition = dalia_position.iddaliaposition 
			FROM dalia_position 
			WHERE dalia_position.codedaliaposition = #INQUADRAMENTI.codicequalifica_bdm 
				 
CREATE TABLE #ModPagamento
(
	matricola varchar(40),
	---------------------------------------------------------------
	---------------------MODALITA' DI PAGAMENTO--------------------
	---------------------------------------------------------------
	idpaymethod int,		-- tipo codificato della modalità di pagamento
	idchargehandling int,   -- tipo codificato trattamento delle spese bancarie
	flag int,				-- flag esente da spese bancarie
	nomemod   varchar(50),	-- nome della modalità di pagamento
	abi	 varchar(20),		-- codice ABI Ist. Bancario
	cab	varchar(20), 		-- codice CAB Sportello
	cc	varchar(30),		-- codice del conto corrente
	cin	varchar(20),		-- codice CIN deve essere di 5 caratteri
	delegato int,			-- codice di un delegato (riferito ad altra REAL_ANAGRAFICA)
	valuta varchar(3), 		-- codice ISO 4217 della valuta
	tiposcadenza int,	 	-- tipo scadenza codificato
	ggscadenza	int,		-- numero dei giorni scadenza
	iban varchar(50),		-- codice IBAN
	data_in datetime, 
	data_fin datetime,
	---------- Ruolo di CSA -------------------------
	ruolo	varchar(4),
	comparto char(1),
	------------------------ note per l'utente ---------------------
	avviso varchar(300),
	dettaglio varchar(300),
	idModPagamento int IDENTITY(1,1)
)


SET @query_PAGAMENTI	= '
INSERT INTO #ModPagamento
(
	matricola,
	---------------------MODALITA'' DI PAGAMENTO--------------------
	idpaymethod,
	flag,
	idchargehandling,		
	nomemod, 	
	abi,		
	cab, 		
	cc,		
	cin,		
	--delegato, 	
	valuta, 	
	--tiposcadenza,
	--ggscadenza,
	iban
 )
SELECT  DISTINCT
	P.matricola,
	P_LOOKUP.idpaymethod,
	P_LOOKUP.flag,	
	P_LOOKUP.idchargehandling,
	P.CodiceModPagamento,			
	P.abi,	
	P.cab, 	
	P.cc,	
	P.cin,	
	-- delegato,
	valuta,
	-- tiposcadenza,
	--GGscadenza,
	iban
FROM '+ @PAGAMENTI + ' as P
JOIN csapaymethodlookup P_LOOKUP		
	ON P_LOOKUP.csa_kind = P.CodiceModPagamento ' +
	ISNULL(REPLACE(@where_ANAGRAFICA,'XXX.','P.'),'')

EXEC (@query_PAGAMENTI)



SELECT 
	C.matricola,
	---------------------------------------------------------------
	---------------------MODALITA' DI PAGAMENTO--------------------
	---------------------------------------------------------------
	null as idpaymethod,-- è quella di Easy ottenuta tramite il lookup
	null as idchargehandling,
	null as flag,
	null as nomemod ,
	null as abi,
	null as cab,
	null as cc,
	null as cin,
	null as delegato,
	null as valuta ,
	null as tiposcadenza,
	null as ggscadenza,
	null as iban,
	---------------------------------------------------------------
	------------INQUADRAMENTO E REDDITO ANNUO PRESUNTO-------------
	---------------------------------------------------------------
	C.datadecorrenza,
	case when (year(isnull(termine,1900))='2222') 
		then {d '2078-12-31'}
		else C.termine
	end AS termine,
	C.in_vigore_giur,
	C.classestipendiale,

	C.codicequalifica ,-- è l'idposition di Easy
	C.iddaliaposition ,-- è l'iddaliaposition di Easy
	C.imponpresunto	,  -- è l'imponibile presunto di Easy
	'N' as avviso,
	null as dettaglio,
	C.comparto,
	C.ruolo,
	'I' as rowkind
FROM #INQUADRAMENTI C

UNION 

SELECT 
	P.matricola,
	---------------------------------------------------------------
	---------------------MODALITA' DI PAGAMENTO--------------------
	---------------------------------------------------------------
	P.idpaymethod,-- è quella di Easy ottenuta tramite il lookup
	P.idchargehandling,-- è quella di Easy ottenuta tramite il lookup
	P.flag,-- è quella di Easy ottenuta tramite il lookup
	P.nomemod ,
	P.abi,
	P.cab,
	P.cc,
	P.cin,
	P.delegato,
	P.valuta ,
	P.tiposcadenza,
	P.ggscadenza,
	P.iban,
	---------------------------------------------------------------
	------------INQUADRAMENTO E REDDITO ANNUO PRESUNTO-------------
	---------------------------------------------------------------
	null as datadecorrenza,
	null as termine,
	null as in_vigore_giur,
	null as classestipendiale,

	null as codicequalifica ,-- è l'idposition di Easy
	null as iddaliaposition,-- è l'iddaliaposition di Easy
	null as imponpresunto	,  -- è l'imponibile presunto di Easy
	isnull(p.avviso,'N') as avviso,
	case 
		when (isnull(P.avviso,'N')='S')  then 'Sono state riscontrate più Mod.Pagamento'
		else NULL
	end as dettaglio,
	null as comparto,
	null as ruolo,
	'P' as rowkind
 FROM #ModPagamento P
ordER BY matricola
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

