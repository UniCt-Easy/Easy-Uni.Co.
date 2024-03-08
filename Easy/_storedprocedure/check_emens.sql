
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_emens]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_emens]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
--setuser 'amministrazione'
 
CREATE    PROCEDURE check_emens
(
	@datacontabile datetime,
	@anno int,
	@meseinizio int,
	@mesefine int,
    @unified char(1)
)
AS BEGIN
--        exec check_emens {ts '2022-01-01 00:00:00'},2022, 1, 1,'N'

CREATE TABLE #logerror(
 
	severity char(1),
        departmentname varchar(500),
	errore varchar(400),
	soluzione varchar(400)
)

CREATE TABLE #mittente(
	cfpersonamittente varchar(16),
	ragsocmittente varchar(50),
	cfmittente varchar(16),
	cfsoftwarehouse varchar(16),
	flagesisteresponsabile char(1)
)

INSERT INTO #mittente
EXEC emens_getdatimittente @anno

DECLARE @curr_departmentname varchar(500)
SET  @curr_departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' and 
				(start is null or start <= @datacontabile) and
				(stop is null or stop >= @datacontabile)
				),'Manca Cfg. Parametri Tutte le stampe')


-- Controllo degli errori su #mittente
INSERT INTO #logerror
SELECT 'S',@curr_departmentname,'Non è stato selezionato un responsabile per la trasmissione dell''E-Mens',
'Andare in ''Configurazione - Responsabile Trasmissione - Configurazione'', ed inserire un responsabile per la trasmissione del modello E-Mens'
FROM #mittente WHERE flagesisteresponsabile = 'N'

INSERT INTO #logerror
SELECT 'S',@curr_departmentname,'Non è stato inserito il codice fiscale del mittente',
'Andare in ''Configurazione - Informazioni Ente'' ed inserire il codice fiscale'
FROM #mittente WHERE (cfmittente = '' OR cfmittente IS NULL)

INSERT INTO #logerror
SELECT 'S',@curr_departmentname,'Il codice fiscale del mittente non ha lunghezza pari a 11',
'Andare in ''Configurazione - Informazioni Ente'' e correggere il codice fiscale'
FROM #mittente WHERE (DATALENGTH(cfmittente) <> 11)

INSERT INTO #logerror
SELECT 'S',@curr_departmentname,'Non è stato inserito il codice fiscale del responsabile alla trasmissione dell''E-Mens',
'Andare in ''Anagrafiche - Anagrafica - Anagrafica'', scegliere il responsabile della trasmissione dell''E-Mens
 (precedentemente configurato in Configurazione - Responsabile Trasmissione - Configurazione) ed inserire il codice fiscale.'
FROM #mittente WHERE (cfpersonamittente = '' OR cfpersonamittente IS NULL)

  DECLARE @taxcode_INPS_M int
  DECLARE @taxcode_INPS_N int
  DECLARE @taxcode_INPS_P int
  DECLARE @taxcode_INPS_M_VISITING int
  DECLARE @taxcode_INPS_N_VISITING int
  
  SELECT @taxcode_INPS_M  =   taxcode from TAX where taxref = '07_INPS_M'
  SELECT @taxcode_INPS_N  =   taxcode from TAX where taxref = '07_INPS_N'
  SELECT @taxcode_INPS_P  =   taxcode from TAX where taxref = '07_INPS_P'
  SELECT @taxcode_INPS_M_VISITING  =   taxcode from TAX where taxref = '14_INPS_M_VISITING'
  SELECT @taxcode_INPS_N_VISITING  =   taxcode from TAX where taxref = '14_INPS_N_VISITING'
  	 
  DECLARE @idtaxratestart_INPS_M int
  DECLARE @idtaxratestart_INPS_N int
  DECLARE @idtaxratestart_INPS_P int
  DECLARE @idtaxratestart_INPS_M_VISITING int
  DECLARE @idtaxratestart_INPS_N_VISITING int

  SELECT @idtaxratestart_INPS_M = max(idtaxratestart) from taxratestart where taxcode  = @taxcode_INPS_M
  SELECT @idtaxratestart_INPS_N = max(idtaxratestart) from taxratestart where taxcode  = @taxcode_INPS_N
  SELECT @idtaxratestart_INPS_P = max(idtaxratestart) from taxratestart where taxcode  = @taxcode_INPS_P
  SELECT @idtaxratestart_INPS_M_VISITING = max(idtaxratestart) from taxratestart where taxcode  = @taxcode_INPS_M_VISITING
  SELECT @idtaxratestart_INPS_N_VISITING = max(idtaxratestart) from taxratestart where taxcode  = @taxcode_INPS_N_VISITING


	create table #config_corrente_inps
	(taxref varchar(20),
	tax varchar(200),
	 nbracket int,
	 employrate decimal(19,8))

		insert into #config_corrente_inps
		(taxref,tax,nbracket,employrate)
		select '07_INPS_M','INPS mutuati',nbracket as scaglione, employrate as aliquota 
		from taxratebracket where taxcode = @taxcode_INPS_M AND idtaxratestart = @idtaxratestart_INPS_M

		insert into #config_corrente_inps
		(taxref,tax,nbracket,employrate)
		 select '07_INPS_N','INPS non mutuati',
		 nbracket as scaglione, 
		 employrate as aliquota 
		 from taxratebracket 
		 where taxcode = @taxcode_INPS_N AND idtaxratestart = @idtaxratestart_INPS_N
		 
		 insert into #config_corrente_inps
		(taxref,tax,nbracket,employrate)
		select '07_INPS_P','INPS titolari di pensione diretta', nbracket as scaglione, employrate as aliquota 
		from taxratebracket where taxcode = @taxcode_INPS_P AND idtaxratestart = @idtaxratestart_INPS_P

		 insert into #config_corrente_inps
		(taxref,tax,nbracket,employrate)
		select '14_INPS_M_VISITING','INPS soggetti mutuati visiting professor', nbracket as scaglione, employrate as aliquota 
		from taxratebracket where taxcode = @taxcode_INPS_M_VISITING AND idtaxratestart = @idtaxratestart_INPS_M_VISITING
	
		insert into #config_corrente_inps
		(taxref,tax,nbracket,employrate)
		select '14_INPS_N_VISITING','INPS soggetti non mutuati visting professor', nbracket as scaglione, employrate as aliquota 
		from taxratebracket where taxcode = @taxcode_INPS_N_VISITING AND idtaxratestart = @idtaxratestart_INPS_N_VISITING

CREATE TABLE #listacollaboratori(
    departmentname varchar(500),
	cfcollaboratore varchar(16),
	cognome varchar(50),
	nome varchar(20),
	tiporapporto varchar(2),
	codiceattivita varchar(2),
	imponibile decimal(19,2),
	aliquota decimal(19,6),
	altraass varchar(3),
	dal smalldatetime,
	al smalldatetime,
	codicecomune varchar(20),
	codcalamita varchar(2),
	codcertificazione varchar(3),
	servicemodule varchar(20),
	taxref varchar(20),
	esiste_DIS_COLL_N char(1)
)

DECLARE @parentsp char(1)
SET @parentsp = 'E'

DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor
DECLARE @dip_nomesp varchar(300)

SET @crsdepartment = cursor FOR SELECT iddbdepartment FROM dbdepartment
where (start is null or start <= @anno ) AND ( stop is null or stop >= @anno)
OPEN @crsdepartment
FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 
Begin
		DELETE FROM #listacollaboratori
        IF (@unified = 'N') SET @iddbdepartment = user-- Se non deve consolidare, esegue la sp per 'user' ed esce dal WHILE tramite il BREAK.
        SET @dip_nomesp = @iddbdepartment + '.emens_daticollaboratore'
        
        INSERT INTO #listacollaboratori
        EXEC @dip_nomesp @anno,@meseinizio,@mesefine,@parentsp,@datacontabile

        DECLARE @epsilon decimal (19,4)
        SET @epsilon = 0.0005
       
 
	if (@anno >= Year(GetDate()))
	BEGIN
	        -- Controllo degli errori su #listacollaboratori
		 
			IF (SELECT COUNT(*)      FROM #listacollaboratori
	        WHERE taxref like '%INPS%' AND
				esiste_DIS_COLL_N = 'N' AND
				NOT EXISTS (select * FROM #config_corrente_inps  WHERE 
				aliquota   BETWEEN (	employrate -  @epsilon) AND (employrate + @epsilon)) ) > 0
			BEGIN
				INSERT INTO #logerror
				SELECT 'S',departmentname,'L''aliquota ' + CONVERT(varchar(20),aliquota*100)+ '%' + ' applicata a ' + cognome + ' ' + nome + ' è errata' ,''
				FROM #listacollaboratori
				WHERE NOT EXISTS (select * FROM #config_corrente_inps  WHERE 
				aliquota   BETWEEN (	employrate -  @epsilon) AND (employrate + @epsilon))
				AND  esiste_DIS_COLL_N = 'N' 
				
				INSERT INTO #logerror
				SELECT DISTINCT 'S', @iddbdepartment, 'L''aliquota corretta per ' + tax + ', scaglione ' + convert(varchar(4),nbracket) + ', deve essere ' + convert(varchar(20),employrate * 100) + '%'  ,''
				FROM   #config_corrente_inps JOIN #listacollaboratori ON #config_corrente_inps.taxref = #listacollaboratori.taxref 
				WHERE  esiste_DIS_COLL_N = 'N' AND NOT (aliquota   BETWEEN (	employrate -  @epsilon) AND (employrate + @epsilon) )
			END

-- Se il compenso prevedeva la ritenuta 'INPS contributo DIS_COLL', allora l'aliquota della ritenuta 'INPS soggetti non mutuati'va considerata maggiorata dello 1,31 %
			IF (SELECT COUNT(*)      FROM #listacollaboratori
	        WHERE taxref like '%INPS%' AND
				esiste_DIS_COLL_N = 'S' AND
				NOT EXISTS (select * FROM #config_corrente_inps  WHERE 
				aliquota BETWEEN (	employrate  + 0.0131 -  @epsilon) AND (employrate  + 0.0131 + @epsilon)) ) > 0
			BEGIN
				INSERT INTO #logerror
				SELECT 'S',departmentname,'L''aliquota ' + CONVERT(varchar(20),aliquota*100)+ '%' + ' applicata a ' + cognome + ' ' + nome + ' è errata...' ,''
				FROM #listacollaboratori
				WHERE NOT EXISTS (select * FROM #config_corrente_inps  WHERE 
				aliquota   BETWEEN (	employrate  +0.0131-  @epsilon) AND (employrate  +0.0131+ @epsilon))
				AND   esiste_DIS_COLL_N = 'S' 
				
				INSERT INTO #logerror
				SELECT DISTINCT 'S', @iddbdepartment, 'L''aliquota corretta per ' + tax + ', scaglione ' + convert(varchar(4),nbracket) + ', deve essere ' + convert(varchar(20),employrate +0.0131 * 100) + '%'  ,''
				FROM #config_corrente_inps JOIN #listacollaboratori ON #config_corrente_inps.taxref = #listacollaboratori.taxref 
				WHERE  esiste_DIS_COLL_N = 'S' AND NOT (aliquota   BETWEEN (	employrate  +0.0131-  @epsilon) AND (employrate  +0.0131 + @epsilon) )
			END
    END


        INSERT INTO #logerror
        SELECT 'S',departmentname,'Codice fiscale del collaboratore ' + cognome + ' ' + nome + ' assente',
        'Andare in in ''Anagrafiche - Anagrafica - Anagrafica e aggiungere il codice fiscale'
        FROM #listacollaboratori WHERE (cfcollaboratore = '' OR cfcollaboratore IS NULL)
        
        INSERT INTO #logerror
        SELECT 'S',departmentname,'Codice fiscale del collaboratore ' + cognome + ' ' + nome + ' non ha lunghezza pari a 16',
        'Andare in in ''Anagrafiche - Anagrafica - Anagrafica e correggere il codice fiscale'
        FROM #listacollaboratori WHERE (DATALENGTH(cfcollaboratore) <> 16)
        
        INSERT INTO #logerror
        SELECT 'S',departmentname,'La lunghezza del codice del comune per il collaboratore ' + cognome + ' ' + nome + 
        ' nel periodo ' + CONVERT(varchar(16),dal) + ' è differente dalla lunghezza standard di 4 caratteri',
        'Controllare il codice Belfiore del comune (idagency = 1, idcode = 1)'
        FROM #listacollaboratori WHERE DATALENGTH(codicecomune) <> 4
        
        INSERT INTO #logerror
        SELECT 'S',departmentname,'Al collaboratore ' + cognome + ' ' + nome + 
        ' non è stato associato il codice comune',
        'Andare in Configurazione\Informazioni ente ed inserire il comune dell''Ente. '
        FROM #listacollaboratori WHERE codicecomune IS NULL
		
		INSERT INTO #logerror
        SELECT 'S',departmentname,'Al percipiente ' + cognome + ' ' + nome + 
        ' non è stato associato il tipo rapporto Emens in corrispondenza ' + 
		' di una prestazione con ritenuta INPS effettuata presso ' + departmentname ,
        ' Controllare le prestazioni effettuate '
        FROM #listacollaboratori WHERE tiporapporto IS NULL AND servicemodule IN ('OCCASIONALE','COCOCO')
   
      
        DECLARE @cf varchar(16)
        DECLARE @cognome varchar(40)
        DECLARE @nome varchar(40)
        DECLARE @posizione char(1)
        DECLARE @departmentname varchar(500)
        -- Il cursore viene costruito in modo da considerare tutti i percipienti e il responsabile della trasmissione.
        -- Il responsabile della trasmissione è marcato con il valore R mentre i percipienti con P, in modo da parametrizzare
        -- il messaggio di output
        DECLARE listacoll_cursor INSENSITIVE CURSOR FOR
        SELECT DISTINCT cfcollaboratore,cognome,nome,'P' AS posizione,departmentname FROM #listacollaboratori
        UNION SELECT cfpersonamittente,NULL AS cognome,NULL AS nome,'R' AS posizione, @curr_departmentname AS departmentname FROM #mittente
        FOR READ ONLY
        OPEN listacoll_cursor
        FETCH NEXT FROM listacoll_cursor INTO @cf,@cognome,@nome,@posizione,@departmentname
        WHILE(@@FETCH_STATUS = 0)
         BEGIN
          DECLARE @i int
          DECLARE @tot_codfisc int
          DECLARE @sum_disp	int
          DECLARE @sum_pari	int
          DECLARE @lf char(1)
          SET @i = 0
          SET @tot_codfisc = 0
          SET @sum_disp = 0
          SET @sum_pari = 0
        	
          WHILE (@i < 8)
           BEGIN
        		SELECT @sum_disp = @sum_disp + oddposition
        		FROM buildcf
        		WHERE letter = SUBSTRING(@cf,2 * @i + 1,1)
        	
        		IF @i > 0
        		 BEGIN
        			SELECT @sum_pari = @sum_pari + evenposition
        			FROM buildcf
        			WHERE letter = SUBSTRING(@cf,2 * @i,1)
        		 END
        		SELECT @i = @i + 1
           END
           SELECT @tot_codfisc = @sum_disp + @sum_pari
           SELECT @lf = letter FROM buildcf WHERE evenposition = (@tot_codfisc % 26) AND kind <> 'N'
           DECLARE @cf_built varchar(16)
           SET @cf_built = SUBSTRING(@cf,1,LEN(@cf) - 1) + @lf
           SET @cf = UPPER(@cf)
           SET @cf_built = UPPER(@cf_built)
           IF (@cf <> @cf_built)
        	BEGIN
        		IF (@posizione = 'P')
        		 BEGIN
            		INSERT INTO #logerror
        			VALUES('S',@departmentname,'L''ultimo carattere del codice fiscale di ' + @cognome + ' ' + @nome + ' non è corretto',
        			'Andare in in ''Anagrafiche - Anagrafica - Anagrafica e correggere il codice fiscale')
        		 END
        		IF (@posizione = 'R')
        		 BEGIN
            		INSERT INTO #logerror
        			VALUES('S',@departmentname,'L''ultimo carattere del codice fiscale del responsabile della trasmissione non è corretto',
        			'Andare in in ''Anagrafiche - Anagrafica - Anagrafica e correggere il codice fiscale')
        		 END
        	END
           FETCH NEXT FROM listacoll_cursor INTO @cf,@cognome,@nome,@posizione,@departmentname	
         END
        CLOSE listacoll_cursor
        DEALLOCATE listacoll_cursor
        
-- cursore dipartimento
        IF (@unified = 'N') BREAK -- Se non deve consolidare esegue solo la sp per 'user'.
	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
END
CLOSE @crsdepartment
DEALLOCATE @crsdepartment

SELECT severity,
    departmentname as dipartimento,
	errore,
	soluzione 
FROM #logerror
ORDER BY dipartimento
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
