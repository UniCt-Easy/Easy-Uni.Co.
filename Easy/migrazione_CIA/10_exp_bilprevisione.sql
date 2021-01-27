
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


DROP  PROCEDURE exp_bilprevisione
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE exp_bilprevisione
( @bilancio varchar(50)  
)
AS
BEGIN
	/*  exp_bilprevisione 'A.AMMCE'
			"anno;Anno;Intero;4",
            "codicebil;Codice bilancio;Stringa;50",
            "partebil;Parte Bilancio (E/S);Codificato;1;E|S",
            "codiceupb;Codice UPB;Stringa;50",
            "residuiprec;Residui iniziali anno precedente;Numero;22",
            "residuicorr;Residui iniziali anno corrente;Numero;22",
            "prevprincprev;previsione principale anno precedente;Numero;22",
            "prevsecprev;previsione secondaria anno precedente;Numero;22",
            "prevprinccorr;previsione principale anno corrente;Numero;22",
            "prevseccorr;previsione secondaria anno corrente;Numero;22",
            "prevanno_2;previsione principale anno + 1;Numero;22",
            "prevanno_3;previsione principale anno + 2;Numero;22",
            "prevanno_4;previsione principale anno + 3;Numero;22",
            "prevanno_5;previsione principale anno + 4;Numero;22"
            
            
	Il bilancio di previsione è esportato a partire dalla tabella preventivo_ripartizione prendendo le versioni 0
	ma solo nel caso in cui lo stesso importo ci sia anche nella tabella preventivo nella versione 0
	
	
	*/
	select	 
	PP.esercizio as anno,
			LB.codefin as codicebil, 
			LB.finpart as partebil, 
		 	LU.codeupb as codiceupb, 
			SUM(convert(decimal(19,2),
				case when PP.esercizio>=2002 then PR.AMMONTARE else ROUND(PR.ammontare/1936.27,2) end 
				)) as prevprinccorr
		from preventivo_ripartizione PR 
			join preventivo P on P.chiave_piano=PR.chiave_piano and P.bilancio=PR.bilancio
			join piano_preventivi PP  on PP.chiave=PR.chiave_piano and PP.bilancio=PR.bilancio
			left outer join lookup_bilancio LB on PR.chiave_completa = LB.chiave_completa
			LEFT OUTER JOIN   lookup_upb LU
		ON  LU.chiave_completa = PR.UNITA_ORGANIZZATIVA
		where
				P.chiave_versione=0 AND PR.chiave_versione=0 
				AND PR.chiave_completa=P.chiave_completa 
				AND  convert(date,P.dacr)=convert(date,PR.dacr)
				AND PR.bilancio = @bilancio
				AND PR.AMMONTARE <> 0
				AND PP.stato_piano='D'
				AND PP.data_approvazione is not null
		group by PP.esercizio,LB.codefin,LB.finpart,LU.codeupb
END
GO
