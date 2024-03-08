
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_transmission_adpv2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_transmission_adpv2]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
--setuser 'amministrazione'
-- setuser 'amm'
 
CREATE    PROCEDURE [check_transmission_adpv2]
 --Questa stored procedure effettua i controlli precedenti la trasmissione
 --di incarichi al Web Service di AdP v. 2.0
 --Sono esclusi i controlli di correttezza dei singoli incarichi salvati, già contenuti in
 --meta_serviceregistry, metodo IsValid poichè si assume che se sono stati salvati sono corretti
 --Escludo da questa stored procedure anche i controlli  relativi alle credenziali
 --di accesso ai servizi
(
	@rolekind char(1), -- > D Dipendente , C consulente
	@transmissionkind char(1), --> I inserimento, Modifica, Cancellazione
	@yservreg int,
	@fromnservreg  int,
	@tonservreg  int,
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null	
)
AS BEGIN
-- exec check_transmission_adpv2  'C','I',2021, 1, 1000
-- Estrazione di tutti gli incarichi che si cerca di trasmettere aventi come filtro solo la tipologia incaricati
-- Dipendente o Consulente, esercizio e estremi incarico (da numero a numero)
 
SELECT * INTO #serviceregistry 
FROM serviceregistry S
WHERE S.yservreg = @yservreg and 
(S.nservreg BETWEEN @fromnservreg AND @tonservreg  OR isnull(@fromnservreg,0) = 0 OR isnull(@tonservreg,0) = 0)
 
AND ((S.employkind  IN ('D') AND @rolekind = 'D')
OR  (S.employkind  IN( 'C', 'A') AND @rolekind = 'C')
)
AND
(
(S.idsor01 = @idsor01  OR @idsor01 IS null) AND 
(S.idsor02 = @idsor02  OR @idsor02 IS null) AND
(S.idsor03 = @idsor03  OR @idsor03 IS null) AND
(S.idsor04 = @idsor04  OR @idsor04 IS null) AND
(S.idsor05 = @idsor05  OR @idsor05 IS null) 	
)
  
----DROP TABLE #serviceregistry
--SELECT * INTO #serviceregistry 
--FROM serviceregistry
--WHERE yservreg = 1999 and nservreg BETWEEN 1 AND 1000;
--select * from #serviceregistry
--sp_help serviceregistry

--select * from serviceregistry
/*  1) C e D, @transmissionkind  I,  M , C Tipologia incarico non si può trasmettere
	string filter_tipologia =
				"(idserviceregistrykind is null OR idserviceregistrykind  in (select idserviceregistrykind from serviceregistrykind where " +
				QHS.CmpEq("totransmit", "S") + "))";

	2) C e D @transmissionkind  ='I' Controllo Flag 
		string filtroNuovoIncarico =
			" (is_delivered ='N' and is_annulled='N' and is_blocked = 'N' and  website_annulled = 'N') ";
	3)  C e D  @transmissionkind  ='I'   QHS.IsNotNull("codiceaooipa"), QHS.IsNotNull("codiceuoipa")
	4)  D  @transmissionkind  ='I' 		// per i dipendenti filtra solo quelli che non appartengono ad altra amministrazione
				// ovvero non hanno un indirizzo del tipo anagrafe delle prestazioni
				filter_own = "(idreg not in (select idreg from registryaddress where "
				             + QHS.AppAnd(QHS.CmpEq("idaddresskind", idaddresskind), QHS.CmpEq("active", "S")) + "))";
				not_filter_own = "(idreg in (select idreg from registryaddress where "
				                 + QHS.AppAnd(QHS.CmpEq("idaddresskind", idaddresskind), QHS.CmpEq("active", "S")) +
				                 "))";
	5) D  @transmissionkind  ='I' 	// Per i Dipendenti deve escludere gli incarichi con data conferimento NULL
				filter_IncarichiEsclusi = QHS.AppAnd(filtereserc_service,
					QHS.DoPar(QHS.AppOr(QHS.IsNull("authorizationdate"), not_filter_own))
				);
			}
	6) C   @transmissionkind  ='I'  //Per i Consulenti, deve escludere gli incarichi con data affidamento NULL e data inizio null
				filter_IncarichiEsclusi = QHS.AppAnd(filtereserc_service,
					QHS.DoPar(QHS.AppOr(QHS.IsNull("expectationsdate"), QHS.IsNull("start"))));

	7)  D if (tipo.ToUpper() == "D") { //kind = D   @transmissionkind  ='I' 
				filterIncarichi = QHS.AppAnd(QHS.CmpEq("employkind", "D"),
					filtereserc_service, filter_own, security,
					QHS.IsNotNull("authorizationdate"),
					QHS.IsNotNull("ordinancelink"));
				if (codicePaIpa == null) filterIncarichi = QHS.AppAnd(filterIncarichi, QHS.IsNotNull("codicepaipa"));
			}
 
	9) C e D  Filtro sicurezza Ente    @transmissionkind  ='I' 
			string securityServiceagency = Conn.SelectCondition("serviceagency", true);
			securityServiceagency = QHS.AppAnd(securityServiceagency, getFilterSicurezza());
			if (securityServiceagency.ToString() == "") securityServiceagency = null;
			DataTable serviceagency =
				DataAccess.RUN_SELECT(meta.Conn, "serviceagency", "*", null, securityServiceagency, false);
			if (serviceagency.Rows.Count == 0) {
				QueryCreator.ShowError(this,
					"Inserire il Codice Ente. Andare in Compensi - Banca dati incarichi - Codice Ente.",
					"Filtro applicato:" + securityServiceagency);
				return false;
			}
		10) C e D  Incarico da correggere	  @transmissionkind  ='I'  string mess = (tipo.ToUpper() == "D" ? "Dipendenti" : "Consulenti");
			if (DS.serviceregistry.Select(QHC.CmpEq("is_blocked", 'S')).Length != 0) {
				show(this, "Ci sono Incarichi di " + mess + " in sospeso");
				return false;
			}


			// Modifiche
					//pagamenti di prestazioni trasmesse
									string filtroModificaIncarico = " (is_delivered ='S' and is_changed = 'S' and is_blocked = 'N') ";
			string filtereser_service = QHS.AppAnd(QHS.CmpLe("yservreg", esercizio),
				QHS.CmpEq("is_delivered", "S"),
				QHS.CmpEq("is_blocked", "N"),
				QHS.CmpEq("is_changed","S"),
				filter_own
			);
			// solo per i dipendenti
			string filter_own = "";
			if (tipo.ToUpper() == "D") {
				// per i dipendenti filtri solo quelli che non appartengono ad altra amministrazione
				// ovvero non hanno un indirizzo del tipo anagrafe delle prestazioni
				filter_own = QHS.FieldNotIn("idreg", Address.Select(), "idreg");
			}

			string securityServiceRegistry = Conn.SelectCondition("serviceregistry", true);
			if (securityServiceRegistry != null && securityServiceRegistry != "") {
				filter_own = QHS.AppAnd(filter_own, securityServiceRegistry);
			}

			Filtro sicurezza applicato alla trasmissione
			string getFilterSicurezza() {
			string filter = "";
			if (meta.IsEmpty) return "";
			DataRow curr = DS.servicetrasmission.Rows[0];
			for (int i = 1; i <= 5; i++) {
				string field = "idsor0" + i.ToString();
				if (curr[field] != DBNull.Value) filter = QHS.AppAnd(filter, QHS.CmpEq(field, curr[field]));
			}

			return filter;
		}


		string filtroCancellaIncarico = " (is_delivered ='N' and is_annulled='S' and is_blocked = 'N') ";

		string filtroNuovoPagamento = " (is_delivered ='N' and payedamount > '0' and is_blocked = 'N') ";

		string filtroModificaPagamento = " (is_delivered ='S' and is_changed ='S' and is_blocked = 'N') ";
*/
CREATE TABLE #logerror(
	cod_errore int,
	severity char(1),
	tipologia_incarico varchar(200),
	yservreg int,
	nservreg int,
	employkind char(1),
    title varchar(200),
	cf varchar(50),
	description varchar(1000),
	errore varchar(1000),
	soluzione varchar(1000)
)
 
-- Controllo degli errori  
-- 1) Tipologia incarico non si può trasmettere
INSERT INTO #logerror
(cod_errore, severity,tipologia_incarico, yservreg,nservreg,employkind, title,cf,description,errore,soluzione)
SELECT 1, 'E', sk.description, s.yservreg, s.nservreg,
s.employkind, s.title, s.cf, s.description, 
'La Tipologia incarico: ' + sk.description + ' non è abilitata per la trasmissione a Perla PA. Incarico  ' + convert(varchar(10), s.yservreg) + '/n°' + convert(varchar(10), s.nservreg) ,
'Controllare la configurazione Compensi --> Banca Dati Incarichi --> Tipologia incarico'
FROM #serviceregistry s
LEFT OUTER JOIN serviceregistrykind sk ON sk.idserviceregistrykind = s.idserviceregistrykind
WHERE  s.idserviceregistrykind IS NOT NULL AND 
UPPER(ISNULL(sk.totransmit,'S')) = 'N'
AND ((s.employkind  IN ('D') AND @rolekind = 'D')
OR  (s.employkind  IN ('C', 'A')  AND @rolekind = 'C')
)
  
/*
is_delivered Incarico Trasmesso	N	System.String
is_annulled	 Incarico Annullato	N	System.String
is_blocked	 Incarico Bloccato	N	System.String
is_changed	 Incarico da Modificare	N	System.String
*/
 

 -- 2) Inserimento nuovo incarico consulente o dipendente, controllo sui flag nuovo incarico
INSERT INTO #logerror
(cod_errore, severity,tipologia_incarico, yservreg,nservreg,employkind, title,cf,description,errore,soluzione)
SELECT 2, 'E', sk.description, s.yservreg, s.nservreg,
s.employkind, s.title, s.cf, s.description, 
'L''incarico ' + convert(varchar(10), s.yservreg) + '/n°' + convert(varchar(10), s.nservreg) +
' non si può trasmettere ' + CASE
	WHEN ISNULL(s.is_delivered,'N') = 'S' THEN 'in quanto già Trasmesso'
	WHEN ISNULL(s.is_annulled,'N')  = 'S' THEN 'in quanto Annullato'
	WHEN ISNULL(s.is_blocked,'N')  = 'S' THEN 'in quanto da Correggere'
	WHEN ISNULL(s.is_changed,'N')  = 'S' THEN 'in quanto da Modificare'
	WHEN ISNULL(s.website_annulled,'N')  = 'S' THEN 'in quanto Annullato sul sito istituzionale'
	ELSE ''
 END    , 'Controllare che l''incarico non sia già TRASMESSO, nè BLOCCATO, nè ANNULLATO neanche sul Sito Istituzionale ' 
FROM #serviceregistry s
LEFT OUTER JOIN serviceregistrykind sk ON sk.idserviceregistrykind = s.idserviceregistrykind
WHERE  	NOT( s.is_delivered ='N' and s.is_annulled='N' and s.is_blocked = 'N' and  s.website_annulled = 'N')  
AND @transmissionkind  ='I'
AND ((s.employkind  IN ('D') AND @rolekind = 'D')
OR  (s.employkind  IN ('C', 'A')  AND @rolekind = 'C')
)
  

  -- 3) Inserimento nuovo incarico consulente o dipendente, controllo codice AOO oppure UOO valorizzato
INSERT INTO #logerror
(cod_errore, severity,tipologia_incarico, yservreg,nservreg,employkind, title,cf,description,errore,soluzione)
SELECT 3, 'E', sk.description,s.yservreg, s.nservreg,
s.employkind, s.title, s.cf, s.description, 
'L''incarico ' + convert(varchar(10), s.yservreg) + '/n°' + convert(varchar(10), s.nservreg) +
' non si può trasmettere perchè deve avere almeno uno dei due codici AOO oppure UOO valorizzato'   ,
'Controllare la presenza di almeno uno dei due codici(AOO oppure UOO) in Compensi --> Banca Dati Incarichi --> Gestione incarichi'
FROM #serviceregistry s
LEFT OUTER JOIN serviceregistrykind sk ON sk.idserviceregistrykind = s.idserviceregistrykind
WHERE  s.codiceaooipa IS NULL AND s.codiceuoipa IS NULL  
AND @transmissionkind  ='I'

-- 4) Inserimento nuovo incarico dipendente, controllo che non appartengano ad altra amministrazione
-- ovvero   hanno un indirizzo del tipo anagrafe delle prestazioni

DECLARE  @codeaddress   varchar(50) = '07_SW_ANP';
DECLARE  @idaddresskind int  
SELECT   @idaddresskind =  idaddress FROM address WHERE codeaddress = @codeaddress 

INSERT INTO #logerror
(cod_errore, severity,tipologia_incarico,yservreg,nservreg,employkind, title,cf,description,errore,soluzione)
SELECT 4, 'W', sk.description,s.yservreg, s.nservreg,
s.employkind, s.title, s.cf, s.description, 
'L''incarico Dipendente/Dipendente di Altra Amm. ' + convert(varchar(10), s.yservreg) + '/n°' + convert(varchar(10), s.nservreg) +
' non si può trasmettere perchè appartiene ad altra amministrazione'   , 'Se possiede un indirizzo del tipo 07_SW_ANP - Anagrafe delle prestazioni, la trasmissione compete all''Ente di appartenenza'
FROM #serviceregistry s
LEFT OUTER JOIN serviceregistrykind sk ON sk.idserviceregistrykind = s.idserviceregistrykind
WHERE s.employkind  <> 'C' and  (s.idreg  in (select idreg from registryaddress 
						where idaddresskind = @idaddresskind  and active = 'S')) 
AND @transmissionkind  =  'I'
 
 
-- 5) Inserimento nuovo incarico per i Dipendenti deve escludere gli incarichi con data conferimento NULL 
INSERT INTO #logerror
(cod_errore, severity,tipologia_incarico, yservreg,nservreg,employkind, title,cf,description,errore,soluzione)
SELECT 5, 'E', sk.description,s.yservreg, s.nservreg,
s.employkind, s.title, s.cf, s.description, 
'L''incarico Dipendente' + convert(varchar(10), s.yservreg) + '/n°' + convert(varchar(10), s.nservreg) +
' non si può trasmettere perchè la data conferimento incarico  è assente'   , 'Tranne se Dipendente di Altra Amm. con un indirizzo del tipo 07_SW_ANP - Anagrafe delle Prestazioni '
FROM #serviceregistry s
LEFT OUTER JOIN serviceregistrykind sk ON sk.idserviceregistrykind = s.idserviceregistrykind
WHERE s.employkind ='D' 
AND (s.idreg  not in (select idreg from registryaddress 
						where idaddresskind = @idaddresskind  and active = 'S')) 
AND s.authorizationdate is null 
AND @transmissionkind  = 'I'
AND @rolekind		   = 'D'


-- 6) Inserimento nuovo incarico per i Consulenti  deve escludere gli incarichi con data affidamento NULL e data inizio null
INSERT INTO #logerror
(cod_errore, severity,tipologia_incarico, yservreg,nservreg,employkind, title,cf,description,errore,soluzione)
SELECT 6, 'E', sk.description,s.yservreg, s.nservreg,
s.employkind, s.title, s.cf, s.description, 
'L''incarico a Consulente ' + convert(varchar(10), s.yservreg) + '/n°' + convert(varchar(10), s.nservreg) +
' non si può trasmettere perchè la data affidamento incarico o la data inizio o  il Link al decreto di conferimento Incarico sono assenti'   ,
' controllare che sia stata impostata la Data Affidamento Incarico e la Data Inizio e  il Link al decreto di conferimento Incarico'
FROM #serviceregistry s
LEFT OUTER JOIN serviceregistrykind sk ON sk.idserviceregistrykind = s.idserviceregistrykind
WHERE  s.employkind in ('C','A')
AND ( s.expectationsdate is null
OR s.start is null
OR s.ordinancelink is null) 
AND @transmissionkind  = 'I'
AND @rolekind		   = 'C'

	--7)  D if (tipo.ToUpper() == "D") { //kind = D   @transmissionkind  ='I' 
	--			filterIncarichi = QHS.AppAnd(QHS.CmpEq("employkind", "D"),
	--				filtereserc_service, filter_own, security,
	--				QHS.IsNotNull("authorizationdate"),
	--				QHS.IsNotNull("ordinancelink"));
	--			if (codicePaIpa == null) filterIncarichi = QHS.AppAnd(filterIncarichi, QHS.IsNotNull("codicepaipa"));
	--		}

-- Uniconfig lettura parametri  
DECLARE @codicePaIpa varchar(10)
DECLARE @codiceAooIpa varchar(10)
DECLARE @codiceUoIpa varchar(10)
DECLARE @codiceFiscalePa  varchar(50)

SELECT  @codicePaIpa = perla_codicepaipa,
		@codiceAooIpa = perla_codiceaoopa,
		@codiceUoIpa= perla_codiceuopa,
		@codiceFiscalePa = perla_codicefiscalepa
FROM uniconfig
 

-- 7) Inserimento nuovo incarico per i Dipendenti della propria amministrazione deve escludere gli incarichi con data Autorizzazione NULL e Link al decreto di conferimento Incarico null
INSERT INTO #logerror
(cod_errore, severity,tipologia_incarico,yservreg,nservreg,employkind, title,cf,description,errore,soluzione)
SELECT 7, 'E', sk.description,s.yservreg, s.nservreg,
s.employkind, s.title, s.cf, s.description, 
'L''incarico a Dipendente ' + convert(varchar(10), s.yservreg) + '/n°' + convert(varchar(10), s.nservreg) +
' non si può trasmettere perchè la data di conferimento/autorizzazione o il Link al decreto di conferimento Incarico sono assenti'   ,
' controllare che sia stata impostata sia la data di conferimento/autorizzazione che il Link al decreto di conferimento Incarico'
FROM #serviceregistry s
LEFT OUTER JOIN serviceregistrykind sk ON sk.idserviceregistrykind = s.idserviceregistrykind
WHERE s.employkind ='D' 
AND  (s.idreg  not in (select idreg from registryaddress 
						where idaddresskind = @idaddresskind  and active = 'S')) 
AND (s.ordinancelink is null 
OR authorizationdate IS NULL)
AND @transmissionkind  = 'I'
AND @rolekind		   = 'D'



-- 8) Inserimento nuovo incarico per i Dipendenti della propria amministrazione deve escludere gli incarichi con codice Ipa della PA NULLO
INSERT INTO #logerror
(cod_errore, severity,tipologia_incarico, yservreg,nservreg,employkind, title,cf,description,errore,soluzione)
SELECT 8, 'E', sk.description, s.yservreg, s.nservreg,
s.employkind, s.title, s.cf, s.description, 
'L''incarico a Consulente ' + convert(varchar(10), s.yservreg) + '/n°' + convert(varchar(10), s.nservreg) +
' non si può trasmettere perchè ha codice IPA - PA nullo'   ,
' controllare che nella configurazione pluriennale sia stata impostato il codice IPA e che sia coerente con quello dell''incarico'
FROM #serviceregistry s
LEFT OUTER JOIN serviceregistrykind sk ON sk.idserviceregistrykind = s.idserviceregistrykind
WHERE  s.employkind  IN ('C','A')
AND ((s.idreg  not in (select idreg from registryaddress 
						where idaddresskind = @idaddresskind  and active = 'S')) )
AND @transmissionkind  = 'I'
AND @rolekind		   = 'C'
AND (@codicePaIpa IS NOT NULL AND  s.codicepaipa is null)
 

-- 9) Compatibilità attributi sicurezza serviceagency -- serviceregistry
INSERT INTO #logerror
(cod_errore, severity,tipologia_incarico, yservreg,nservreg,employkind, title,cf,description,errore,soluzione)
SELECT 9, 'E', sk.description, s.yservreg, s.nservreg,
s.employkind, s.title, s.cf, s.description, 
'L''incarico  ' + convert(varchar(10), s.yservreg) + '/n°' + convert(varchar(10), s.nservreg) +
' non è compatibile con gli attributi sicurezza dell''Ente ' + sa.pa_code  + ' ' + sa.pa_title + ' - cf ' + sa.pa_cf   ,
' Controllare la coerenza attributi di sicurezza tra Ente (Compensi --> Banca Dati Incarichi --> Codice Ente) e Incarico '
FROM #serviceregistry s
LEFT OUTER JOIN serviceregistrykind sk ON sk.idserviceregistrykind = s.idserviceregistrykind
JOIN serviceagency sa ON sa.pa_code = s.pa_code
WHERE NOT
(
(sa.idsor01 is null OR s.idsor01 = sa.idsor01) AND 
(sa.idsor02 is null OR s.idsor02 = sa.idsor02) AND 
(sa.idsor03 is null OR s.idsor03 = sa.idsor03) AND 
(sa.idsor04 is null OR s.idsor04 = sa.idsor04) AND 
(sa.idsor01 is null OR s.idsor05 = sa.idsor05)   
)
AND @transmissionkind  = 'I'
AND ((s.employkind  IN ('D')AND @rolekind = 'D')
OR  (s.employkind  IN ( 'C', 'A')  AND @rolekind = 'C')
)

 -- 10) Modifica nuovo incarico consulente o dipendente, controllo sui flag   incarico
INSERT INTO #logerror
(cod_errore, severity,tipologia_incarico, yservreg,nservreg,employkind, title,cf,description,errore,soluzione)
SELECT 10, 'E',sk.description, s.yservreg, s.nservreg,
s.employkind, s.title, s.cf, s.description, 
'La modifica dell''incarico ' + convert(varchar(10), s.yservreg) + '/n°' + convert(varchar(10), s.nservreg) +
' non si può trasmettere ' + CASE
	WHEN ISNULL(s.is_delivered,'N') = 'N' THEN 'in quanto l''incarico non è stato ancora Trasmesso'
	-- WHEN ISNULL(s.is_annulled,'N')  = 'S' THEN 'in quanto Annullato'
	WHEN ISNULL(s.is_blocked,'N')  = 'S' THEN 'in quanto da Correggere'
	WHEN ISNULL(s.is_changed,'N')  = 'N' THEN 'in quanto non è da Modificare'
	-- WHEN ISNULL(s.website_annulled,'N')  = 'S' THEN 'in quanto Annullato sul sito istituzionale'
	ELSE ''
 END  ,'deve essere già TRASMESSO, non DA CORREGGERE, MODIFICATO '   
FROM #serviceregistry s
LEFT OUTER JOIN serviceregistrykind sk ON sk.idserviceregistrykind = s.idserviceregistrykind
WHERE  	NOT(is_delivered ='S' and is_changed ='S' and is_blocked = 'N')  
AND @transmissionkind  ='M'
AND ((s.employkind  IN ('D') AND @rolekind = 'D')
OR  (s.employkind IN ('C', 'A')  AND @rolekind = 'C')
)
  

 -- 11) Cancellazione nuovo incarico consulente o dipendente, controllo sui flag   incarico
INSERT INTO #logerror
(cod_errore, severity,tipologia_incarico, yservreg,nservreg,employkind, title,cf,description,errore,soluzione)
SELECT 11, 'E', sk.description, s.yservreg, s.nservreg,
s.employkind, s.title, s.cf, s.description, 
'La cancellazione dell''incarico ' + convert(varchar(10), s.yservreg) + '/n°' + convert(varchar(10), s.nservreg) +
' non si può trasmettere ' + CASE
	WHEN ISNULL(s.is_delivered,'N') = 'N' THEN 'in quanto incarico non ancora Trasmesso'
	WHEN ISNULL(s.is_annulled,'N')  = 'N' THEN 'in quanto incarico non Annullato'
	WHEN ISNULL(s.is_blocked,'N')  = 'S' THEN 'in quanto incarico da Correggere'
	-- WHEN ISNULL(s.is_changed,'N')  = 'S' THEN 'in quanto da Modificare'
	-- WHEN ISNULL(s.website_annulled,'N')  = 'S' THEN 'in quanto non Annullato sul sito istituzionale'
	ELSE ''
 END    ,  'Deve essere già TRASMESSO, non DA CORREGGERE, ANNULLATO ' 
FROM #serviceregistry s
LEFT OUTER JOIN serviceregistrykind sk ON sk.idserviceregistrykind = s.idserviceregistrykind
WHERE  	NOT ( is_delivered ='N' and is_annulled='S' and is_blocked = 'N')  
AND @transmissionkind  ='C'
AND ((s.employkind  IN ('D') AND @rolekind = 'D')
OR  (s.employkind  IN('C', 'A') AND @rolekind = 'C')
)
  
--select * from serviceagency
 

 

SELECT 
	cod_errore,
	severity ,
	tipologia_incarico as 'Tipologia incarico',
	yservreg as 'esercizio',
	nservreg 'numero',
	CASE  employkind 
		WHEN 'C' THEN 'Consulente'
		WHEN 'A' THEN 'Dipendente di Altra Amministrazione'
		ELSE 'Dipendente'
	END as 'Tipo Incaricato',
    title as 'Incaricato',
	cf,
	description as 'Descrizione',
	errore,
	soluzione 
FROM #logerror
ORDER BY cod_errore,title,yservreg, nservreg
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 exec check_transmission_adpv2  'D','I',2023, null, 0

 
 --- testare 4 5 6 7
