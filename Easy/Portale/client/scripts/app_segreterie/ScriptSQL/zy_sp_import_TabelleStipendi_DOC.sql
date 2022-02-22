
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


ALTER  PROCEDURE [dbo].[sp_import_TabelleStipendi_DOC]
AS
/* DUBBI: contrattokind totaletredicesima scatto =S/N?*/
BEGIN

    --SELECT * FROM _tabellestipendi2020 WHERE inquadramento like'Ricercatore DPR 232/11 art.2  -t.definito %'

    /********* CORREZIONE ERRORI NEL FILE EXCEL ********************************************/
    UPDATE _TabelleStipendi2020
         SET INQUADRAMENTO = 'Prof.Associato DPR 232/11 art.2 - t.definito - cl. 10 - III anno'
    WHERE INQUADRAMENTO LIKE 'Prof.Associato DPR 232/11 art.2  -t.definito - cl. 10 - III anno';

    UPDATE _TabelleStipendi2020
         SET INQUADRAMENTO = 'Prof.Ordinario DPR 232/11 art.2 - t.definito - cl. 10 - III anno'
    WHERE INQUADRAMENTO LIKE 'Prof.Ordinario DPR 232/11 art.2  -t.definito - cl. 10 - III anno';

    UPDATE _TabelleStipendi2020
         SET INQUADRAMENTO = 'Ricercatore DPR 232/11 art.2 - t.definito - cl. 10 - III anno'
    WHERE INQUADRAMENTO LIKE 'Ricercatore DPR 232/11 art.2  -t.definito - cl. 10 - III anno';

    DELETE _TabelleStipendi2020
    WHERE ISNULL(INQUADRAMENTO, '') = '';
    /********************************************************************************************/

   DELETE contrattokind
   WHERE cu = 'import_stipendi';

    DELETE inquadramento
    WHERE cu = 'import_stipendi';

    DELETE stipendio
    WHERE cu = 'import_stipendi';
	
  --  CREATE TABLE #import_contrattokind
  --  (
  --      idcontrattokind INT IDENTITY(1, 1),
  --      active CHAR(1),
  --      assegnoaggiuntivo CHAR(1),
  --      ct DATETIME,
  --      lt DATETIME,
  --      cu VARCHAR(64),
  --      lu VARCHAR(64),
  --      description VARCHAR(256),
  --      parttime CHAR(1),
  --      sortcode INT,
  --      scatto CHAR(1),
		--tempdef CHAR(1),
  --      idcontrattokindtab INT,
		--operation CHAR(1),
		--siglaimportazione VARCHAR(2024)
  --  );
    CREATE TABLE #import_inquadramento
    (
        idinquadramento INT IDENTITY(1, 1),
        idcontrattokind INT,
        title VARCHAR(2048),
        ct DATETIME,
        lt DATETIME,
        cu VARCHAR(64),
        lu VARCHAR(64),
        tempdef CHAR(1),
        siglaimportazione VARCHAR(1024),
        idinquadramentotab INT,
        titlecontrattokind VARCHAR(256)
    );


    CREATE TABLE [dbo].[#import_stipendio]
    (
        [idstipendio] INT IDENTITY(1, 1),
        [idcontrattokind] [INT],
        [idinquadramento] [INT],
        [classe] [INT],
        [scatto] [INT],
        [stipendio] [DECIMAL](18, 2),
        [iis] [DECIMAL](18, 2),
        [assegno] [DECIMAL](18, 2),
        [irap] [DECIMAL](18, 2),
        [totale] [DECIMAL](18, 2),
        [lordo] [DECIMAL](18, 2),
        [siglaimportazione] [VARCHAR](1024),
        [idstipendiotab] [INT]
    );

    /* inserimento in contrattokind
	*/
 --   INSERT INTO #import_contrattokind
 --   (
 --       active,
 --      assegnoaggiuntivo,
 --       ct,
 --       lt,
 --       cu,
 --       lu,
 --       description,
 --       parttime,
	--	tempdef,
 --       sortcode,
 --       scatto,
	--	siglaimportazione
 --   )
 --   SELECT DISTINCT
 --          'S',
	--	   'S',
 --          --CASE
 --          --    WHEN ASS_AGG = 0 THEN
 --          --        'N'
 --          --    ELSE
 --          --        'S'
 --          --END,
 --          GETDATE(),
 --          GETDATE(),
 --          'import_stipendi',
 --          'import_stipendi',
 --          SUBSTRING(INQUADRAMENTO, 1, CHARINDEX(' DPR', INQUADRAMENTO)),
	--	   'N',
	--	   'N',
 --          --CHARINDEX('- t.',inquadramento)+1, 
 --          -- SUBSTRING(inquadramento,1,CHARINDEX('- cl.',inquadramento)-1),
 --          --CASE
 --          --    WHEN INQUADRAMENTO LIKE '%t.definito%' THEN
 --          --        'S'
 --          --    WHEN INQUADRAMENTO LIKE '%t.pieno%' THEN
 --          --        'N'
 --          --    ELSE
 --          --        ''
 --          --END AS parttime,
 --          1 AS sortcode,
 --          'S',
	--	         CASE SUBSTRING(INQUADRAMENTO, 1, CHARINDEX(' DPR', INQUADRAMENTO)) WHEN 'prof.associato'THEN 'Professori Associati'
	--			 WHEN 'prof.ordinario' THEN 'Professori Ordinari'
	--			 WHEN 'ricercatore' THEN'RU'
	--			 ELSE SUBSTRING(INQUADRAMENTO, 1, CHARINDEX(' DPR', INQUADRAMENTO))
	--			 end
 --   --,SUBSTRING(REPLACE(SUBSTRING( inquadramento,CHARINDEX ('cl.',inquadramento )+4,CHARINDEX ('cl.',inquadramento )+5),' ',''),1,1)
 --   FROM dbo._TabelleStipendi2020;
	--/*********** FETCH SULLA TABELLA _TabelleStipendi2020 per vedere se esistono già dei contrattikind */
	--DECLARE  @siglaimportazione varchar(1024)

	--DECLARE contact_cursor CURSOR FOR  
	----SELECT parttime, assegnoaggiuntivo,scatto,description  FROM #import_contrattokind 
	-- SELECT siglaimportazione  FROM #import_contrattokind 
	 
	--OPEN contact_cursor;  

	--FETCH NEXT FROM contact_cursor  
	----INTO @parttime, @assegnoaggiuntivo, @scatto, @description;  
	--INTO  @siglaimportazione
	--WHILE @@FETCH_STATUS = 0  
	--BEGIN  
  
	--	   -- Concatenate and display the current values in the variables.  
	--	   PRINT 'record: ' + @siglaimportazione-- + 'pt: ' +  @parttime  + ' ag: ' +@assegnoaggiuntivo+ ' sc: ' +@scatto

	--	   IF EXISTS (SELECT * FROM  contrattokind 
	--				WHERE siglaimportazione=@siglaimportazione )--AND scatto=@scatto AND assegnoaggiuntivo=@assegnoaggiuntivo AND parttime=@parttime)
	--				BEGIN	
	--				SELECT 'update '+@siglaimportazione
	--			UPDATE #import_contrattokind SET idcontrattokindtab = ck.idcontrattokind , operation ='U' 
	--			FROM dbo.contrattokind ck
	--			JOIN #import_contrattokind 
	--			--ON #import_contrattokind.assegnoaggiuntivo = ck.assegnoaggiuntivo
	--			on #import_contrattokind.siglaimportazione = ck.siglaimportazione 
	--			--AND ck.parttime = ck.parttime
	--			WHERE ck.siglaimportazione=@siglaimportazione 
	--			--AND ck.scatto=@scatto 
	--			--AND ck.assegnoaggiuntivo=@assegnoaggiuntivo 
	--			--AND ck.parttime=@parttime
	--			end
	--		ELSE 
	--			UPDATE #import_contrattokind SET operation ='I' 

	--	   -- This is executed as long as the previous fetch succeeds.  
	--	   FETCH NEXT FROM contact_cursor  
	--	 --  INTO  @parttime, @assegnoaggiuntivo, @scatto, @description; 
	--	      INTO   @siglaimportazione; 
	--END  
  
	--CLOSE contact_cursor;  
	--DEALLOCATE contact_cursor; 

	--/************************ fine fetch ***************************************************************/

    /* Inserimento in import_inquadramento */
    INSERT INTO #import_inquadramento
    (
        ct,
        lt,
        cu,
        lu,
        tempdef,
        title,
        siglaimportazione,
        titlecontrattokind
    )
    SELECT DISTINCT
           GETDATE(),
           GETDATE(),
           'import_stipendi',
           'import_stipendi',
           CASE
               WHEN INQUADRAMENTO LIKE '%t.definito%' THEN
                   'S'
               WHEN INQUADRAMENTO LIKE '%t.pieno%' THEN
                   'N'
               ELSE
                   ''
           END AS tempdef,
           SUBSTRING(INQUADRAMENTO, 1, CHARINDEX('- cl.', INQUADRAMENTO) - 1),
           SUBSTRING(INQUADRAMENTO, 1, CHARINDEX('- cl.', INQUADRAMENTO) - 1),
           SUBSTRING(INQUADRAMENTO, 1, CHARINDEX(' DPR', INQUADRAMENTO))
    --,SUBSTRING(REPLACE(SUBSTRING( inquadramento,CHARINDEX ('cl.',inquadramento )+4,CHARINDEX ('cl.',inquadramento )+5),' ',''),1,1)
    FROM dbo._TabelleStipendi2020;

    INSERT INTO dbo.#import_stipendio
    (
        classe,
        scatto,
        stipendio,-- stipendio base lordo
        iis,
        assegno,
        irap,
        totale, -- totale lordo dipendente
        lordo,	-- totale costo azienda
        siglaimportazione
    )
    SELECT REPLACE((SUBSTRING(
                        REPLACE(
                                   SUBSTRING(
                                                INQUADRAMENTO,
                                                CHARINDEX('cl.', INQUADRAMENTO) + 4,
												--       CHARINDEX('cl.', INQUADRAMENTO) + 5
                                                CHARINDEX('cl.', INQUADRAMENTO) + 6
                                            ),
                                   ' ',
                                   ''
                               ),
                        1,
                        2--1
                    )),'-',''),
           CASE
               WHEN REPLACE(INQUADRAMENTO, ' ', '') LIKE '%IIIanno%' THEN
                   3
               WHEN REPLACE(INQUADRAMENTO, ' ', '') LIKE '%IIanno%' THEN
                   2
               WHEN REPLACE(INQUADRAMENTO, ' ', '') LIKE '%Ianno%' THEN
                   1
               ELSE
                   0
           END,
           STIPENDIO_ANNUO,
           IIS,
           ASS_AGG,
           IRAP,
           TOTALE_COSTO_ANNUO,
           TOTALE_LORDO_ANNUO,
           INQUADRAMENTO
    FROM dbo._TabelleStipendi2020;

	--SELECT * FROM #import_stipendio
    /* Generazione della chiave da inserire nella tabella */
	DECLARE @maxcontratto INT
	SELECT @maxcontratto =  ISNULL(MAX(idcontrattokind) ,1)FROM contrattokind

    UPDATE #import_contrattokind
    SET idcontrattokindtab = idcontrattokind +
                             @maxcontratto
							 WHERE operation ='I'

    /* Generazione della chiave da inserire nella tabella */
    UPDATE #import_inquadramento
    SET idinquadramentotab = idinquadramento +
                             (
                                 SELECT MAX(idinquadramento)FROM dbo.inquadramento
                             );


    /* Aggiornamento della chiave da inserire nella tabella */
    UPDATE #import_inquadramento
    SET idcontrattokind = idcontrattokindtab
    FROM #import_contrattokind ck
        JOIN #import_inquadramento inq
            ON inq.titlecontrattokind = ck.description;


    /* Generazione della chiave da inserire nella tabella */
	DECLARE @maxstipendio INT
	SELECT @maxstipendio =  ISNULL(MAX(idstipendio) ,1)FROM stipendio
    
	UPDATE #import_stipendio
    SET idstipendiotab = idstipendio +  @maxstipendio

    UPDATE #import_stipendio
    SET idcontrattokind = inq.idcontrattokind,
        idinquadramento = inq.idinquadramentotab
    FROM #import_inquadramento inq
        JOIN #import_stipendio st
            ON st.siglaimportazione LIKE inq.title + '%';

    INSERT INTO inquadramento
    (
        idinquadramento,
        idcontrattokind,
        ct,
        lt,
        cu,
        lu,
        tempdef,
        title,
        siglaimportazione
    )
    SELECT DISTINCT
           idinquadramentotab,
           idcontrattokind,
           ct,
           lt,
           cu,
           lu,
           tempdef,
           title,
           siglaimportazione
    FROM #import_inquadramento;

    --INSERT INTO dbo.contrattokind
    --(
    --    idcontrattokind,
    --    active,
    --    assegnoaggiuntivo,
    --    ct,
    --    lt,
    --    cu,
    --    lu,
    --    description,
    --    parttime,
    --    sortcode,
    --    title,
    --    scatto
    --)
    --SELECT DISTINCT
    --       idcontrattokindtab,
    --       active,
    --       assegnoaggiuntivo,
    --       ct,
    --       lt,
    --       cu,
    --       lu,
    --       description,
    --       parttime,
    --       sortcode,
    --       description,
    --       scatto
    --FROM #import_contrattokind WHERE operation='I'


    INSERT INTO dbo.stipendio
    (
        idstipendio,
        idcontrattokind,
        idinquadramento,
        classe,
        scatto,
        stipendio,
        iis,
        assegno,
        irap,
        totale,
        lordo,
        siglaimportazione,
        ct,
        lt,
        cu,
        lu
    )
    SELECT idstipendiotab,
           idcontrattokind,
           idinquadramento,
           classe,
           scatto,
           stipendio,
           iis,
           assegno,
           irap,
           totale,
           lordo,
           siglaimportazione,
           GETDATE(),
           GETDATE(),
           'import_stipendi',
           'import_stipendi'
    FROM #import_stipendio;
	/*
    UPDATE dbo.contrattokind
    SET siglaesportazione = 'PO',
        siglaimportazione = 'Professori Ordinari',
        puntiorganico = 1
    WHERE cu = 'import_stipendi'
          AND title LIKE '%ordinario%';
    UPDATE dbo.contrattokind
    SET siglaesportazione = 'PA',
        siglaimportazione = 'Professori Associati',
        puntiorganico = 0.7
    WHERE cu = 'import_stipendi'
          AND title LIKE '%associato%';
    UPDATE dbo.contrattokind
    SET siglaesportazione = 'RU',
        siglaimportazione = 'Ricercatori',
        puntiorganico = 0.5
    WHERE cu = 'import_stipendi'
          AND title LIKE '%ricercatore%';
		  */
    SELECT MAX(lordo) AS lordo,
           MAX(totale) AS totale,
           inquadramento.siglaimportazione
    INTO #maxstipendio
    FROM stipendio
        JOIN inquadramento
            ON stipendio.siglaimportazione LIKE inquadramento.siglaimportazione + '%'
    GROUP BY inquadramento.siglaimportazione;

    UPDATE inquadramento
    SET costolordoannuo = lordo,
        costolordoannuooneri = totale
    FROM #maxstipendio
        JOIN inquadramento
            ON inquadramento.siglaimportazione = #maxstipendio.siglaimportazione;


/*SELECT *
    FROM contrattokind
    WHERE cu = 'import_stipendi'
    ORDER BY title;


    SELECT *
    FROM dbo.inquadramento
    WHERE cu = 'import_stipendi'
    ORDER BY title;
	
	SELECT * 
	FROM dbo.stipendio
	WHERE cu = 'import_stipendi'
    order by siglaimportazione*/

	----------------------------------------------------------------------------------------------------------------------------------

    INSERT INTO dbo.stipendio
    (
        idstipendio,
        idcontrattokind,
        idinquadramento,
        classe,
        scatto,
        stipendio,
        iis,
        assegno,
        irap,
        totale,
        lordo,
        siglaimportazione,
        ct,
        lt,
        cu,
        lu
    )
	SELECT 
		(select isnull(max(idstipendio),0) +1  from stipendio) + ROW_NUMBER() over (/*PARTITION BY idinquadramento*/ order by siglaimportazione)  as [idstipendio], * FROM (
   
   SELECT 
		CASE
			WHEN CHARINDEX('Associato', INQUADRAMENTO) > 0 THEN 2
			WHEN CHARINDEX('Ordinario', INQUADRAMENTO) > 0 THEN 1
			WHEN CHARINDEX('lett. A ', INQUADRAMENTO) > 0 THEN 10
			WHEN CHARINDEX('lett. B', INQUADRAMENTO) > 0 THEN 8
			WHEN CHARINDEX('Ricercatore', INQUADRAMENTO) > 0 THEN 7
		END as idcontrattokind,
		(select top 1 idinquadramento from inquadramento where  inquadramento LIKE title + '%'
		--title = CASE 
		--WHEN CHARINDEX('- classe', INQUADRAMENTO) > 0 THEN SUBSTRING(INQUADRAMENTO, 1, CHARINDEX('- classe', INQUADRAMENTO) -1) 
		--WHEN CHARINDEX('- classe', INQUADRAMENTO) = 0 THEN INQUADRAMENTO
		--END
		) as idinquadramento,
		REPLACE((SUBSTRING(
                        REPLACE(
                                   SUBSTRING(
                                                INQUADRAMENTO,
                                                CHARINDEX('cl.', INQUADRAMENTO) + 4,
												--       CHARINDEX('cl.', INQUADRAMENTO) + 5
                                                CHARINDEX('cl.', INQUADRAMENTO) + 6
                                            ),
                                   ' ',
                                   ''
                               ),
                        1,
                        2--1
                    )),'-','') as classe,
           CASE
               WHEN REPLACE(INQUADRAMENTO, ' ', '') LIKE '%IIIanno%' THEN
                   3
               WHEN REPLACE(INQUADRAMENTO, ' ', '') LIKE '%IIanno%' THEN
                   2
               WHEN REPLACE(INQUADRAMENTO, ' ', '') LIKE '%Ianno%' THEN
                   1
               ELSE
                   0
           END as scatto,
        STIPENDIO_ANNUO as tipendio,
        IIS,
        ASS_AGG as assegno,
        IRAP,
        TOTALE_COSTO_ANNUO as totale,
        TOTALE_LORDO_ANNUO as lordo,
        inquadramento as siglaimportazione,
		GETDATE() as ct,
		GETDATE() as lt,
		'import_stipendi' as cu,
		'import_stipendi' as lu
    FROM dbo._TabelleStipendi2020

	) tbl1


	----------------------------------------------------------------------------------------------------------------------------------
	INSERT INTO inquadramento
    (
        idinquadramento,
        idcontrattokind,
        ct,
        lt,
        cu,
        lu,
        tempdef,
        title,
        siglaimportazione
    )
	select 
	(select isnull(max(idinquadramento),0) +1  from inquadramento) + ROW_NUMBER() over (/*PARTITION BY idinquadramento*/ order by siglaimportazione)  as [idinquadramento], 
	*
	from (
		SELECT DISTINCT
			   CASE
			   WHEN CHARINDEX('Associato', INQUADRAMENTO) > 0 THEN 2
			   WHEN CHARINDEX('Ordinario', INQUADRAMENTO) > 0 THEN 1
			   WHEN CHARINDEX('lett. A ', INQUADRAMENTO) > 0 THEN 10
			   WHEN CHARINDEX('lett. B', INQUADRAMENTO) > 0 THEN 8
			   END as idcontrattokind,
			   GETDATE() as ct,
			   GETDATE() as lt,
			   'import_stipendi' as cu,
			   'import_stipendi' as lu,
			   CASE
				   WHEN INQUADRAMENTO LIKE '%t.definito%' THEN
					   'S'
				   WHEN INQUADRAMENTO LIKE '%t.pieno%' THEN
					   'N'
				   ELSE
					   ''
			   END AS tempdef,
			   CASE 
			   WHEN CHARINDEX('- classe', INQUADRAMENTO) > 0 THEN SUBSTRING(INQUADRAMENTO, 1, CHARINDEX('- classe', INQUADRAMENTO) -1) 
			   WHEN CHARINDEX('- classe', INQUADRAMENTO) = 0 THEN INQUADRAMENTO
			   END as title,
			   '' as siglaimportazione
		FROM _tabellaStipendialeDOCLegge240
	)tbl1

	

    INSERT INTO dbo.stipendio
    (
        idstipendio,
        idcontrattokind,
        idinquadramento,
        classe,
        scatto,
        stipendio,
        iis,
        assegno,
        irap,
        totale,
        lordo,
        siglaimportazione,
        ct,
        lt,
        cu,
        lu
    )
	SELECT 
		(select isnull(max(idstipendio),0) +1  from stipendio) + ROW_NUMBER() over (/*PARTITION BY idinquadramento*/ order by siglaimportazione)  as [idstipendio], * FROM (

			SELECT 
				   CASE
			   WHEN CHARINDEX('Associato', INQUADRAMENTO) > 0 THEN 2
			   WHEN CHARINDEX('Ordinario', INQUADRAMENTO) > 0 THEN 1
			   WHEN CHARINDEX('lett. A ', INQUADRAMENTO) > 0 THEN 10
			   WHEN CHARINDEX('lett. B', INQUADRAMENTO) > 0 THEN 8
			   END as idcontrattokind,
				(select top 1 idinquadramento from inquadramento where title = CASE 
			   WHEN CHARINDEX('- classe', INQUADRAMENTO) > 0 THEN SUBSTRING(INQUADRAMENTO, 1, CHARINDEX('- classe', INQUADRAMENTO) -1) 
			   WHEN CHARINDEX('- classe', INQUADRAMENTO) = 0 THEN INQUADRAMENTO
			   END) as idinquadramento,
				   classe,
				   scatto,
				   stipendio_annuo as stipendio,
				   iis,
				   ass_agg as assegno,
				   oneri_a_carico_amm_ne - oneri_a_carico_amm_ne_senza_irap as irap,
				   totale_costo_annuo as totale,
				   totale_lordo_annuo as lordo,
				   inquadramento as siglaimportazione,
				   GETDATE() as ct,
				   GETDATE() as lt,
				   'import_stipendi' as cu,
				   'import_stipendi' as lu
			   FROM _tabellaStipendialeDOCLegge240
	) TBL1

END;
