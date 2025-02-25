
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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


namespace FirmaRemotaUsign.ApiModels
{
	/// <summary>
	/// Upload - POST
	/// </summary>
	public class Upload : ApiModel<Upload>
	{
		public override string getMethod() { return "upload/{0}?{1}"; }
		public override string getService() { return "api/public/"; }
		public override bool needAuthorize() { return true; }
        public override bool isPost() { return true; }
    }

	public enum TipoFirma
	{
        PADES,
		GRAPHIC,
		REQUIRED,
		XADES,
		CADES
    }

    // file				(obbligatorio)	che non può essere nullo, deve essere un oggetto di tipo MultipartFile che corrisponde al documento che si vuole allegare al processo.
    // typeFirma		(obbligatorio)	i valori possibili sono: “PADES”, "GRAPHIC", "REQUIRED", “XADES”, “CADES” (default nel caso in cui il valore specificato non sia ritenuto valido)
    // isChild			(obbligatorio)	Se il valore è settato a "true" il file viene inserito come figlio del primo file caricato nel processo. Il primo file caricato quindi deve essere sempre il padre (se esiste) e non potrà mai avere isChild =true.
    // flMarcaTemporale (obbligatorio)	Se il valore è settato a “true” il documento verrà firmato apponendo una marca temporale.
    // isNote							Da settare a true se si intende caricare il file come "file nota". Questo tipo di file serve solamente per dare indicazioni all'utente firmatario, ma non viene firmato all'interno del processo. Ogni processo di firma può avere uno e uno solo file di nota, ogni nuovo "file  nota" sovrascrive quello caricato precedentemente.
    // signature_page					Il valore indica la pagina dove apporre la nuova firma grafica (valido solo se vengono valorizzati tutti i seguenti campi: signature_page, signature_bottom, signature_left, signature_width, signature_height)
    // signature_bottom					Il valore indica la posizione a partire dal fondo della pagina dove apporre la nuova firma grafica (valido solo se vengono valorizzati tutti i seguenti campi: signature_page, signature_bottom, signature_left, signature_width, signature_height)
    // signature_left					Il valore indica la posizione a partire dal lato sinistro della pagina dove apporre la nuova firma grafica (valido solo se vengono valorizzati tutti i seguenti campi: signature_page, signature_bottom, signature_left, signature_width, signature_height)
    // signature_width					Il valore indica la larghezza della nuova firma grafica (valido solo se vengono valorizzati tutti i seguenti campi: signature_page, signature_bottom, signature_left, signature_width, signature_height)
    // signature_height					Il valore indica la altezza della nuova firma grafica  (valido solo se vengono valorizzati tutti i seguenti campi: signature_page, signature_bottom, signature_left, signature_width, signature_heigh

    // es: 'https://unina2.webfirma.pp.cineca.it:443/my-web-firma/api/public/upload/asdadad?typeFirma=PADES&isChild=true&flMarcaTemporale=true&isNote=true&signature_page=1&signature_bottom=10&signature_left=10&signature_width=100&signature_height=100'
}
