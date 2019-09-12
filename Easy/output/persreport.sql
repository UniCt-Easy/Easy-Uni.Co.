DECLARE @expensephase char(1)
DECLARE @incomephase char(1)

select @expensephase = count(nphase) from expensephase
select @incomephase = count(nphase) from incomephase

--Configurazione partitari  a 2,3 o pi� fasi 

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


