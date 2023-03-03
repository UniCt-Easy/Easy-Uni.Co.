cd..
rmdir /Q /S pacchettoEasyPagamenti
mkdir pacchettoEasyPagamenti
xcopy /S EasyPagamenti pacchettoEasyPagamenti
cd pacchettoEasyPagamenti
rmdir /Q /S cfg
rmdir /Q /S dll
rmdir /Q /S immagini
rmdir /Q /S Immagini_CheckBox
rmdir /Q /S ReportPDF
del *.bat
del *.pdf
del *.sln
del global.asax
del MetaMasterBootstrap.master
del MetaMasterBootstrap.master.cs
del web.config
del website.publishproj

rem Compress-Archive -Path D:\progetti\pacchettoEasyPagamenti -DestinationPath D:\pacchettoEasyPagamenti
pause