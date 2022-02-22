
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


DECLARE @expensephase char(1)
DECLARE @incomephase char(1)

select @expensephase = count(nphase) from expensephase
select @incomephase = count(nphase) from incomephase

--Configurazione partitari  a 2,3 o più fasi 

if @expensephase = 2 
begin
	IF exists(SELECT * FROM  [report] WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND reportname = 'partitariobilcompetenza_S')
	UPDATE [report] SET  filename = 'partitario_competenza_2fasi.rpt' WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND  reportname = 'partitariobilcompetenza_S'
	
	IF exists(SELECT * FROM  [report] WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND reportname = 'partitariobilresidui_S')
	UPDATE [report] SET  filename = 'partitario_residui_2fasi.rpt' WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND  reportname = 'partitariobilresidui_S'
	
end

if @expensephase = 3 
begin
	IF exists(SELECT * FROM  [report] WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND reportname = 'partitariobilcompetenza_S')
	UPDATE [report] SET  filename = 'partitario_competenza_3fasi.rpt' WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND  reportname = 'partitariobilcompetenza_S'
	
	IF exists(SELECT * FROM  [report] WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND reportname = 'partitariobilresidui_S')
	UPDATE [report] SET  filename = 'partitario_residui_3fasi.rpt' WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND  reportname = 'partitariobilresidui_S'

end


if @expensephase > 3 
begin
	IF exists(SELECT * FROM  [report] WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND reportname = 'partitariobilcompetenza_S')
	UPDATE [report] SET  filename = 'partitario_competenza_4fasi_spesa.rpt' WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND  reportname = 'partitariobilcompetenza_S'
	
	IF exists(SELECT * FROM  [report] WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND reportname = 'partitariobilresidui_S')
	UPDATE [report] SET  filename = 'partitario_residui_3fasi.rpt' WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND  reportname = 'partitariobilresidui_S'

end



if @incomephase = 2 
begin
	IF exists(SELECT * FROM  [report] WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND reportname = 'partitariobilcompetenza_E')
	UPDATE [report] SET  filename = 'partitario_competenza_2fasi.rpt' WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND  reportname = 'partitariobilcompetenza_E'
	
	IF exists(SELECT * FROM  [report] WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND reportname = 'partitariobilresidui_E')
	UPDATE [report] SET  filename = 'partitario_residui_2fasi.rpt' WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND  reportname = 'partitariobilresidui_E'
	
end

if @incomephase >= 3 
begin
	IF exists(SELECT * FROM  [report] WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND reportname = 'partitariobilcompetenza_E')
	UPDATE [report] SET  filename = 'partitario_competenza_3fasi.rpt' WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND  reportname = 'partitariobilcompetenza_E'
	
	IF exists(SELECT * FROM  [report] WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND reportname = 'partitariobilresidui_E')
	UPDATE [report] SET  filename = 'partitario_residui_3fasi.rpt' WHERE modulename = 'Finanziaria' AND groupname = 'Partitari' AND  reportname = 'partitariobilresidui_E'

end


