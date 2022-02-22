
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


ALTER   PROCEDURE [dbo].[sp_import_TabelleStipendi_PTA]
AS
BEGIN

    DELETE stipendio  WHERE cu = 'import_stipendi_PTA';

 
	--select * from stipendio
	--delete stipendio where idcontrattokind in (17,18,19,20)

	  INSERT INTO stipendio
    (
		idstipendio,
		idcontrattokind,
		idinquadramento,
		stipendio,-- stipendio base lordo
        iis,
        irap,
        totale, -- totale costo azienda
        lordo,	-- totale lordo dipendente
        siglaimportazione,
		scatto,
		classe,
		ct,
		lt,
		cu,
		lu
    )

select 
	(select isnull(max(idstipendio),0) +1  from stipendio) + ROW_NUMBER() over (/*PARTITION BY idinquadramento*/ order by siglaimportazione)  as [idstipendio], 
	*,
	GETDATE(),
    GETDATE(),
    'import_stipendi_PTA',
    'import_stipendi_PTA'
	from (
    SELECT 
			
           --(select top 1 i.title i from inquadramento i where inquadr like i.siglaimportazione + '%' ) as idinquadramento,
           (select top 1 i.idcontrattokind i from inquadramento i where inquadr like i.siglaimportazione + '%') as idcontrattokind,
           (select top 1 i.idinquadramento i from inquadramento i where inquadr like i.siglaimportazione + '%') as idinquadramento,
           STIP_ANN as stipendio,
           IIS_ann as iis,
           IRAP_8_5 as irap,
		   Totale as totale,
           Totale_dip as lordo,
           inquadr as siglaimportazione,
		   replace(replace(replace(replace(inquadr,'B',''),'C',''),'D',''),'EP','') as scatto,
		   0 as classe
    FROM dbo._import_inquadramenti_PTA
	--order by _import_inquadramenti_PTA.inquadr
) tbl1;


	SELECT MAX(lordo) AS lordo,
           MAX(totale) AS totale,
           inquadramento.siglaimportazione
    INTO #maxstipendio
    FROM stipendio
        JOIN inquadramento
            ON stipendio.siglaimportazione LIKE inquadramento.siglaimportazione + '%'
    GROUP BY inquadramento.siglaimportazione;

    UPDATE inquadramento
    SET costolordoannuo = lordo, -- totale costo azienda
        costolordoannuooneri = totale -- totale lordo dipendente
    FROM #maxstipendio
        JOIN inquadramento
            ON inquadramento.siglaimportazione = #maxstipendio.siglaimportazione;
	
	drop table #maxstipendio
END;

