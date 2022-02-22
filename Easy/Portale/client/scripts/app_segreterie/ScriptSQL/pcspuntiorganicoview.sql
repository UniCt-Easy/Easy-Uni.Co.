
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


-- CREAZIONE VISTA pcspuntiorganicoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pcspuntiorganicoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[pcspuntiorganicoview]
GO

CREATE VIEW [dbo].[pcspuntiorganicoview]
AS
SELECT *
FROM (
	SELECT annoelab AS year,
	contrattokind_title,isdoc,
	DATA,
	CONCAT(COLUMN_NAME,
		  CASE annorif WHEN annoelab THEN 0
					   WHEN annoelab+1 THEN 1
					   WHEN annoelab+2 THEN 2
					   WHEN annoelab+3 THEN 3
					   END
	) AS PIV_COL
	FROM   (
------------------------------------	
		select annoelab, 
		annorif,
		contrattokind_title,
		SUM(puntipiu) AS puntipiu,
		SUM(puntimeno) as puntimeno,
		SUM(importo) AS importo,
		sum(importoateneo) as importoateneo,
		sum(importoesterno) as importoesterno,
		isdoc
		from (

			------------------------assunzioni simulate inizio ----------------------------		
			SELECT  
			annoelab, 
			annorif,
			contrattokind_title,
			SUM(puntiorganico) AS puntipiu,
			puntimeno,
			SUM(totale) AS importo,
			SUM(totaleateneo) AS importoateneo,
			SUM(totaleesterno) AS importoesterno,
			isdoc
			from (
				----------------- annoelab = annorif----------------------
				
				SELECT dbo.pcsassunzionisimulate.year AS annoelab, 
				dbo.pcsassunzionisimulate.year AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzionisimulate.year = YEAR(pcsassunzionisimulate.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale * isnull(numeropersoneassunzione,1) as totale,
				totale * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				--,pcsassunzionisimulate.data
				FROM dbo.pcsassunzionisimulate
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzionisimulate.idcontrattokind
				WHERE dbo.pcsassunzionisimulate.year = YEAR(pcsassunzionisimulate.data)
				
				UNION 
				SELECT dbo.pcsassunzionisimulate.year AS annoelab, 
				dbo.pcsassunzionisimulate.year +1 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzionisimulate.year+1 = YEAR(pcsassunzionisimulate.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale1 * isnull(numeropersoneassunzione,1) as totale1,
				totale1 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale1 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzionisimulate
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzionisimulate.idcontrattokind
				WHERE dbo.pcsassunzionisimulate.year = YEAR(pcsassunzionisimulate.data)
				
				UNION 
				SELECT dbo.pcsassunzionisimulate.year AS annoelab, 
				dbo.pcsassunzionisimulate.year +2 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzionisimulate.year+2 = YEAR(pcsassunzionisimulate.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale2 * isnull(numeropersoneassunzione,1) as totale2,
				totale2 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale2 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzionisimulate
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzionisimulate.idcontrattokind
				WHERE dbo.pcsassunzionisimulate.year = YEAR(pcsassunzionisimulate.data)
				UNION 
				SELECT dbo.pcsassunzionisimulate.year AS annoelab, 
				dbo.pcsassunzionisimulate.year +3 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzionisimulate.year+3 = YEAR(pcsassunzionisimulate.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale3 * isnull(numeropersoneassunzione,1) as totale3,
				totale3 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale3 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzionisimulate
				JOIN dbo.contrattokind  ck ON ck.idcontrattokind = pcsassunzionisimulate.idcontrattokind
				WHERE dbo.pcsassunzionisimulate.year = YEAR(pcsassunzionisimulate.data)
				-----------------------------+1
				UNION 
				SELECT dbo.pcsassunzionisimulate.year AS annoelab, 
				dbo.pcsassunzionisimulate.year +1 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzionisimulate.year+1 = YEAR(pcsassunzionisimulate.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale1 * isnull(numeropersoneassunzione,1) as totale1,
				totale1 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale1 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				--,pcsassunzionisimulate.data,dbo.pcsassunzionisimulate.year+1
				FROM dbo.pcsassunzionisimulate
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzionisimulate.idcontrattokind
				WHERE dbo.pcsassunzionisimulate.year+1 = YEAR(pcsassunzionisimulate.data)
				
				UNION 
				SELECT dbo.pcsassunzionisimulate.year AS annoelab, 
				dbo.pcsassunzionisimulate.year +2 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzionisimulate.year+2 = YEAR(pcsassunzionisimulate.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale2 * isnull(numeropersoneassunzione,1) as totale2,
				totale2 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale2 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzionisimulate
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzionisimulate.idcontrattokind
				WHERE dbo.pcsassunzionisimulate.year+1 = YEAR(pcsassunzionisimulate.data)
				UNION 
				SELECT dbo.pcsassunzionisimulate.year AS annoelab, 
				dbo.pcsassunzionisimulate.year +3 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzionisimulate.year+3 = YEAR(pcsassunzionisimulate.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale3 * isnull(numeropersoneassunzione,1) as totale3,
				totale3 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale3 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzionisimulate
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzionisimulate.idcontrattokind
				WHERE dbo.pcsassunzionisimulate.year+1 = YEAR(pcsassunzionisimulate.data)				

				-------------------+2
						UNION 
				SELECT dbo.pcsassunzionisimulate.year AS annoelab, 
				dbo.pcsassunzionisimulate.year +2 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzionisimulate.year+2 = YEAR(pcsassunzionisimulate.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale2 * isnull(numeropersoneassunzione,1) as totale2,
				totale2 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale2 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzionisimulate
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzionisimulate.idcontrattokind
				WHERE dbo.pcsassunzionisimulate.year+2 = YEAR(pcsassunzionisimulate.data)
				UNION 
				SELECT dbo.pcsassunzionisimulate.year AS annoelab, 
				dbo.pcsassunzionisimulate.year +3 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzionisimulate.year+3 = YEAR(pcsassunzionisimulate.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale3 * isnull(numeropersoneassunzione,1) as totale3,
				totale3 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale3 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzionisimulate
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzionisimulate.idcontrattokind
				WHERE dbo.pcsassunzionisimulate.year+2 = YEAR(pcsassunzionisimulate.data)		
				---------------------+3

				UNION 
				SELECT dbo.pcsassunzionisimulate.year AS annoelab, 
				dbo.pcsassunzionisimulate.year +3 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzionisimulate.year+3 = YEAR(pcsassunzionisimulate.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale3 * isnull(numeropersoneassunzione,1) as totale3,
				totale3 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale3 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzionisimulate
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzionisimulate.idcontrattokind
				WHERE dbo.pcsassunzionisimulate.year+3 = YEAR(pcsassunzionisimulate.data)		

			) zz

			GROUP BY contrattokind_title, annoelab, annorif,puntimeno, isdoc		
				
			------------------------assunzioni simulate fine ----------------------------		
			UNION

			------------------------assunzioni inizio ----------------------------		
			SELECT  
			annoelab, 
			annorif,
			contrattokind_title,
			SUM(puntiorganico) AS puntipiu,
			puntimeno,
			SUM(totale) AS importo,
			SUM(totaleateneo) AS importoateneo,
			SUM(totaleesterno) AS importoesterno,
			isdoc
			from (
				----------------- annoelab = annorif----------------------
				
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzioni.year = YEAR(pcsassunzioni.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale * isnull(numeropersoneassunzione,1) as totale,
				totale * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				--,pcsassunzioni.data
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year = YEAR(pcsassunzioni.data)
				
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +1 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzioni.year+1 = YEAR(pcsassunzioni.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale1 * isnull(numeropersoneassunzione,1) as totale1,
				totale1 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale1 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year = YEAR(pcsassunzioni.data)
				
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +2 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzioni.year+2 = YEAR(pcsassunzioni.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale2 * isnull(numeropersoneassunzione,1) as totale2,
				totale2 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale2 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year = YEAR(pcsassunzioni.data)
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +3 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzioni.year+3 = YEAR(pcsassunzioni.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale3 * isnull(numeropersoneassunzione,1) as totale3,
				totale3 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale3 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind  ck ON ck.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year = YEAR(pcsassunzioni.data)
				-----------------------------+1
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +1 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzioni.year+1 = YEAR(pcsassunzioni.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale1 * isnull(numeropersoneassunzione,1) as totale1,
				totale1 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale1 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				--,pcsassunzioni.data,dbo.pcsassunzioni.year+1
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year+1 = YEAR(pcsassunzioni.data)
				
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +2 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzioni.year+2 = YEAR(pcsassunzioni.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale2 * isnull(numeropersoneassunzione,1) as totale2,
				totale2 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale2 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year+1 = YEAR(pcsassunzioni.data)
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +3 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzioni.year+3 = YEAR(pcsassunzioni.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale3 * isnull(numeropersoneassunzione,1) as totale3,
				totale3 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale3 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year+1 = YEAR(pcsassunzioni.data)				

				-------------------+2
						UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +2 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzioni.year+2 = YEAR(pcsassunzioni.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale2 * isnull(numeropersoneassunzione,1) as totale2,
				totale2 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale2 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year+2 = YEAR(pcsassunzioni.data)
				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +3 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzioni.year+3 = YEAR(pcsassunzioni.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale3 * isnull(numeropersoneassunzione,1) as totale3,
				totale3 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale3 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year+2 = YEAR(pcsassunzioni.data)		
				---------------------+3

				UNION 
				SELECT dbo.pcsassunzioni.year AS annoelab, 
				dbo.pcsassunzioni.year +3 AS annorif,
				ck.title AS contrattokind_title,
				CASE WHEN dbo.pcsassunzioni.year+3 = YEAR(pcsassunzioni.data) THEN puntiorganico * isnull(numeropersoneassunzione,1) ELSE 0 END as puntiorganico,
				0 AS puntimeno,
				totale3 * isnull(numeropersoneassunzione,1) as totale3,
				totale3 * isnull(numeropersoneassunzione,1) * isnull(percentuale,100) / 100 as totaleateneo,
				totale3 * isnull(numeropersoneassunzione,1) * (100 - isnull(percentuale,100)) / 100 as totaleesterno,
				isnull(ck.tempdef,'N') as isdoc
				FROM dbo.pcsassunzioni
				JOIN dbo.contrattokind ck ON ck.idcontrattokind = pcsassunzioni.idcontrattokind
				WHERE dbo.pcsassunzioni.year+3 = YEAR(pcsassunzioni.data)		

			) zz

			GROUP BY contrattokind_title, annoelab, annorif,puntimeno, isdoc		
				
			------------------------assunzioni fine ----------------------------		
			UNION

			---------------stipendioannuo ------------------------

			SELECT * from (
				
				select
				annoelab ,
				annorif,
				title,
				puntipiu,
				sum(puntimeno) as puntimeno,
				sum(importo) as importo,
				sum(importoateneo) as importoateneo,
				sum(importoesterno) as importoesterno,
				isdoc
				from (

				----------------- annoelab = annorif----------------------

				select 
				sa.idstipendioannuo,
				aa.year as annoelab ,
				sa.year as annorif,
				ck.title,
				0 as puntipiu,
				CASE WHEN isnull(YEAR(c.stop),sa.year+4) = sa.year THEN ((isnull(ck.puntiorganico,0) /100) * isnull(c.percentualesufondiateneo,100)) ELSE 0 END as puntimeno,
				
				CASE 
				WHEN isnull(YEAR(c.stop),sa.year+4) >= sa.year THEN sa.totale
				ELSE 0 
				END as importo,
				CASE 
					WHEN isnull(YEAR(c.stop),sa.year+4) > sa.year THEN sa.totale * isnull(c.percentualesufondiateneo,100) /100
					WHEN isnull(YEAR(c.stop),sa.year+4) = sa.year THEN sa.totale / 12 * MONTH(c.stop) * isnull(c.percentualesufondiateneo,100) /100  
					ELSE 0 END 
				as importoateneo,
				CASE WHEN isnull(YEAR(c.stop),sa.year+4) > sa.year THEN 
					(CASE WHEN ck.tempdef = 'S' THEN ((sa.totale * ((aa.incrementodocenti1 + 100)/100)) /100)  ELSE sa.totale END) * (100 - isnull(c.percentualesufondiateneo,100) )/100 
				ELSE 0 END as importoesterno,
				isnull(ck.tempdef,'N') as isdoc
				from analisiannuale aa
				inner join stipendioannuo sa on sa.year= aa.year 
				inner join contratto c on c.idcontratto = sa.idcontratto
				inner join contrattokind ck on ck.idcontrattokind = c.idcontrattokind
				
				UNION
				-----------------------------+1

				select 
				sa.idstipendioannuo,
				aa.year as annoelab ,
				sa.year+1 as annorif,
				ck.title,
				0 as puntipiu,
				CASE WHEN isnull(YEAR(c.stop),sa.year+4) = sa.year+1 THEN ((isnull(ck.puntiorganico,0) /100) * isnull(c.percentualesufondiateneo,100)) ELSE 0 END as puntimeno,
				CASE 
					WHEN isnull(YEAR(c.stop),sa.year+4) > sa.year+1 THEN (CASE WHEN ck.tempdef = 'S' THEN ((sa.totale * ((aa.incrementodocenti1 + 100)/100)) )  ELSE sa.totale END)  
					WHEN isnull(YEAR(c.stop),sa.year+4) = sa.year+1 THEN (CASE WHEN ck.tempdef = 'S' THEN ((sa.totale * ((aa.incrementodocenti1 + 100)/100)) )  ELSE sa.totale END) /12*MONTH(c.stop)     
					ELSE 0 
				END as importo,
				CASE 
					WHEN isnull(YEAR(c.stop),sa.year+4) > sa.year+1 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100))  ELSE sa.totale END)  * isnull(c.percentualesufondiateneo,100) /100
					WHEN isnull(YEAR(c.stop),sa.year+4) = sa.year+1 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100))  ELSE sa.totale END)/12*MONTH(c.stop) * isnull(c.percentualesufondiateneo,100) /100  
					ELSE 0 END 
				as importoateneo,
				CASE WHEN isnull(YEAR(c.stop),sa.year+4) > sa.year+1 THEN 
					(CASE WHEN ck.tempdef = 'S' THEN ((sa.totale * ((aa.incrementodocenti1 + 100)/100)) )  ELSE sa.totale END) * (100 - isnull(c.percentualesufondiateneo,100) )/100 
				ELSE 0 END as importoesterno,
				isnull(ck.tempdef,'N') as isdoc
				from analisiannuale aa
				inner join stipendioannuo sa on sa.year= aa.year 
				inner join contratto c on c.idcontratto = sa.idcontratto
				inner join contrattokind ck on ck.idcontrattokind = c.idcontrattokind

				UNION
				-----------------------------+2

				select 
				sa.idstipendioannuo,
				aa.year as annoelab ,
				sa.year+2 as annorif,
				ck.title,
				0 as puntipiu,
				CASE WHEN isnull(YEAR(c.stop),sa.year+4) = sa.year+2 THEN ((isnull(ck.puntiorganico,0) /100) * isnull(c.percentualesufondiateneo,100)) ELSE 0 END as puntimeno,
				CASE 
					WHEN isnull(YEAR(c.stop),sa.year+4) > sa.year+2 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100)) ELSE sa.totale END)
					WHEN isnull(YEAR(c.stop),sa.year+4) = sa.year+2 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100)) ELSE sa.totale END) /12*MONTH(c.stop)     
					ELSE 0 END as importo,
				CASE 
					WHEN isnull(YEAR(c.stop),sa.year+4) > sa.year+2 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100)) ELSE sa.totale END) * isnull(c.percentualesufondiateneo,100) /100
					WHEN isnull(YEAR(c.stop),sa.year+4) = sa.year+2 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100)) ELSE sa.totale END) / 12 * MONTH(c.stop) * isnull(c.percentualesufondiateneo,100) /100  
					ELSE 0 END 
				as importoateneo,
				CASE 
					WHEN isnull(YEAR(c.stop),sa.year+4) > sa.year+2 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100)) ELSE sa.totale END) * (100 - isnull(c.percentualesufondiateneo,100)) /100
					WHEN isnull(YEAR(c.stop),sa.year+4) = sa.year+2 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100)) ELSE sa.totale END) / 12 * MONTH(c.stop) * (100 - isnull(c.percentualesufondiateneo,100)) /100  
					ELSE 0 END 
				as importoesterno,
				isnull(ck.tempdef,'N') as isdoc
				from analisiannuale aa
				inner join stipendioannuo sa on sa.year= aa.year 
				inner join contratto c on c.idcontratto = sa.idcontratto
				inner join contrattokind ck on ck.idcontrattokind = c.idcontrattokind

				UNION
				-----------------------------+3

				select 
				sa.idstipendioannuo,
				aa.year as annoelab ,
				sa.year+3 as annorif,
				ck.title,
				0 as puntipiu,
				CASE WHEN isnull(YEAR(c.stop),sa.year+4) = sa.year+3 THEN ((isnull(ck.puntiorganico,0) /100) * isnull(c.percentualesufondiateneo,100)) ELSE 0 END as puntimeno,
				CASE 
					WHEN isnull(YEAR(c.stop),sa.year+4) > sa.year+3 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100)* ((aa.incrementodocenti3 + 100)/100))  ELSE sa.totale END)  
					WHEN isnull(YEAR(c.stop),sa.year+4) = sa.year+3 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100)* ((aa.incrementodocenti3 + 100)/100))  ELSE sa.totale END)/12*MONTH(c.stop)   
					ELSE 0 END 
				as importo,
				CASE 
					WHEN isnull(YEAR(c.stop),sa.year+4) > sa.year+3 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100)* ((aa.incrementodocenti3 + 100)/100))  ELSE sa.totale END)  * isnull(c.percentualesufondiateneo,100) /100
					WHEN isnull(YEAR(c.stop),sa.year+4) = sa.year+3 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100)* ((aa.incrementodocenti3 + 100)/100))  ELSE sa.totale END) / 12 * MONTH(c.stop) * isnull(c.percentualesufondiateneo,100) /100
					ELSE 0 END 
				as importoateneo,
				CASE 
					WHEN isnull(YEAR(c.stop),sa.year+4) > sa.year+3 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100)* ((aa.incrementodocenti3 + 100)/100))  ELSE sa.totale END)  * (100 - isnull(c.percentualesufondiateneo,100)) /100
					WHEN isnull(YEAR(c.stop),sa.year+4) = sa.year+3 THEN (CASE WHEN ck.tempdef = 'S' THEN (sa.totale * ((aa.incrementodocenti1 + 100)/100)* ((aa.incrementodocenti2 + 100)/100)* ((aa.incrementodocenti3 + 100)/100))  ELSE sa.totale END) / 12 * MONTH(c.stop) * (100 - isnull(c.percentualesufondiateneo,100)) /100
					ELSE 0 END 
				as importoesterno,
				isnull(ck.tempdef,'N') as isdoc
				from analisiannuale aa
				inner join stipendioannuo sa on sa.year= aa.year 
				inner join contratto c on c.idcontratto = sa.idcontratto
				inner join contrattokind ck on ck.idcontrattokind = c.idcontrattokind


				) ss

				group by annoelab ,
				annorif,
				title,
				puntipiu,
				isdoc
				
			) tbl1

		) tbl2
		group by annoelab, 
		annorif,
		contrattokind_title,isdoc
		--order by contrattokind_title,annoelab, annorif
		-----------------------------------------------------
				
	) AS GROUPED_VIEW
       CROSS APPLY (VALUES ('puntipiu',puntipiu),
						   ('puntimeno',puntimeno),
                           ('importo',importo),
                           ('importoateneo',importoateneo),
                           ('importoesterno',importoesterno)
						   ) CS(COLUMN_NAME, DATA)) A
       PIVOT (SUM(DATA)
             FOR PIV_COL IN([puntipiu0],
							[puntimeno0],
                            [importo0],
                            [importoateneo0],
                            [importoesterno0],
                            [puntipiu1],
							[puntimeno1],
                            [importo1],
                            [importoateneo1],
                            [importoesterno1],
                            [puntipiu2],
							[puntimeno2],
                            [importo2],
                            [importoateneo2],
                            [importoesterno2],
							[puntipiu3],
							[puntimeno3],
                            [importo3],
                            [importoateneo3],
                            [importoesterno3]
							)) PV



GO



-- VERIFICA DI pcspuntiorganicoview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'pcspuntiorganicoview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcspuntiorganicoview','varchar(50)','Generator','contrattokind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importo0','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importo1','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importo2','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importo3','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoateneo0','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoateneo1','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoateneo2','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoateneo3','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoesterno0','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoesterno1','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoesterno2','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','importoesterno3','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcspuntiorganicoview','char(1)','Generator','isdoc','1','S','char','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntimeno0','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntimeno1','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntimeno2','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntimeno3','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntipiu0','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntipiu1','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntipiu2','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcspuntiorganicoview','decimal(38,4)','Generator','puntipiu3','17','N','decimal','System.Decimal','','4','','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcspuntiorganicoview','int','Generator','year','4','S','int','System.Int32','','','','','N')
GO

-- VERIFICA DI pcspuntiorganicoview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'pcspuntiorganicoview')
UPDATE customobject set isreal = 'N' where objectname = 'pcspuntiorganicoview'
ELSE
INSERT INTO customobject (objectname, isreal) values('pcspuntiorganicoview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

