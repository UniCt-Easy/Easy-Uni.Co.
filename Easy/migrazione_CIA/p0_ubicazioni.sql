-- Da eseguire sul db di CIA
update  CARICO_SCARICO_INVENT_DETT
set ubicazione = replace(ubicazione,'?','°' )
where ubicazione like '%?%'

GO