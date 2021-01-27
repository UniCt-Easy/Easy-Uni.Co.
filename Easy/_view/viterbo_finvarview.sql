
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


-- CREAZIONE VISTA unifiedtaxcorrigeview
IF EXISTS(select * from sysobjects where id = object_id(N'[viterbo_finvarview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [viterbo_finvarview]
GO


CREATE      VIEW [viterbo_finvarview]

AS
SELECT        viterbo_finvar.yvar, viterbo_finvar.nvar, viterbo_finvar.adate, viterbo_finvar.description, viterbo_finvar.enactment, 
                         viterbo_finvar.enactmentdate, viterbo_finvar.flagcredit, viterbo_finvar.flagprevision, viterbo_finvar.flagproceeds, 
                         viterbo_finvar.flagsecondaryprev, viterbo_finvar.nenactment, viterbo_finvar.official, viterbo_finvar.nofficial, 
                         viterbo_finvar.variationkind, dbo.variationkind.description AS variationkinddescr, ISNULL
                             ((SELECT        SUM(D.amount) AS Expr1
                                 FROM            viterbo_finvardetail AS D INNER JOIN
                                                          fin AS F ON D.idfin = F.idfin
                                 WHERE        (D.yvar = viterbo_finvar.yvar) AND (D.nvar = viterbo_finvar.nvar) AND (F.flag & 1 = 0)), 0) AS incometotal, ISNULL
                             ((SELECT        SUM(D.amount) AS Expr1
                                 FROM            viterbo_finvardetail AS D INNER JOIN
                                                          fin AS F ON D.idfin = F.idfin
                                 WHERE        (D.yvar = viterbo_finvar.yvar) AND (D.nvar = viterbo_finvar.nvar) AND (F.flag & 1 <> 0)), 0) AS expensetotal, ISNULL
                             ((SELECT        SUM(D.amount) AS Expr1
                                 FROM            viterbo_finvardetail AS D INNER JOIN
                                                          fin AS F ON D.idfin = F.idfin
                                 WHERE        (D.yvar = viterbo_finvar.yvar) AND (D.nvar = viterbo_finvar.nvar) AND (F.flag & 1 = 0)), 0) - ISNULL
                             ((SELECT        SUM(D.amount) AS Expr1
                                 FROM            viterbo_finvardetail AS D INNER JOIN
                                                          fin AS F ON D.idfin = F.idfin
                                 WHERE        (D.yvar = viterbo_finvar.yvar) AND (D.nvar = viterbo_finvar.nvar) AND (F.flag & 1 <> 0)), 0) AS total, viterbo_finvar.ct, 
                         viterbo_finvar.cu, viterbo_finvar.lt, viterbo_finvar.lu, viterbo_finvar.idfinvarstatus, finvarstatus.description AS finvarstatus, 
                         viterbo_finvar.reason, viterbo_finvar.idenactment, enactment.yenactment, enactment.nenactment AS enactmentnumber, 
                         viterbo_finvar.idman, manager.title AS manager, viterbo_finvar.limit, 
                         (CASE WHEN viterbo_finvar.idfinvarstatus = 1 THEN '<center><img src="Immagini/bozza.png" title="Bozza" alt="Bozza"/></center>' WHEN viterbo_finvar.idfinvarstatus = 2 THEN '<center><img src="Immagini/richiesta.png" title="Richiesta" alt="Richiesta"/></center>'
                          WHEN viterbo_finvar.idfinvarstatus = 3 THEN '<center><img src="Immagini/dacorreggere.png" title="Da Correggere" alt="Da Correggere"/></center>' WHEN viterbo_finvar.idfinvarstatus = 4 THEN '<center><img src="Immagini/inserito.png" title="Inserito" alt="Inserito"/></center>'
                          WHEN viterbo_finvar.idfinvarstatus = 5 THEN '<center><img src="Immagini/approvato.png" title="Approvato" alt="Approvato"/></center>' WHEN viterbo_finvar.idfinvarstatus = 6 THEN '<center><img src="Immagini/annullato.png" title="Annullato" alt="Annullato"/></center>'
                          END) AS statusimage, finvarstatus.listingorder, viterbo_finvar.idsor01, viterbo_finvar.idsor02, viterbo_finvar.idsor03, 
                         viterbo_finvar.idsor04, viterbo_finvar.idsor05, finvarkind.idfinvarkind, finvarkind.codevarkind AS codefinvarkind, 
                         finvarkind.description AS finvarkind, viterbo_finvar.moneytransfer, viterbo_finvar.varflag, viterbo_finvar.annotation
FROM            viterbo_finvar WITH (nolock) INNER JOIN
                         dbo.variationkind WITH (nolock) ON dbo.variationkind.idvariationkind = viterbo_finvar.variationkind 
						 LEFT OUTER JOIN finvarstatus WITH (nolock) ON finvarstatus.idfinvarstatus = viterbo_finvar.idfinvarstatus 
						 LEFT OUTER JOIN enactment WITH (nolock) ON enactment.idenactment = viterbo_finvar.idenactment 
						 LEFT OUTER JOIN manager WITH (nolock) ON manager.idman = viterbo_finvar.idman 
						 LEFT OUTER JOIN finvarkind ON viterbo_finvar.idfinvarkind = finvarkind.idfinvarkind 
						

GO


