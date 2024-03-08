
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


using generaSQL;
using metadatalibrary;
using metaeasylibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ScriptRegenerator {
	class Program {

		//per il generatore di script
		private static string dbipport = "185.56.8.51,5839";
		private static string dbipportname = "unibas_easy";
		private static string dipartimento = "amministrazione";

		private static string connectionString = "Data Source=" + dbipport + ";Initial Catalog=" + dbipportname + ";Persist Security Info=True;User ID=assistenza;Password=123***********";

		private static List<string> scriptAlreadyCreated = new List<string>();
		private static bool rebuildScript = true;
		private static Segreterie.Generator.TextFileCollection fileContainer = new Segreterie.Generator.TextFileCollection();


		static void Main(string[] args)
		{

			var scripts = new List<string>();
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/affidamento.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/affidamentokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/affidamentoattach.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/affidamentocaratteristica.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/affidamentocaratteristicaora.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/ambitoareadisc.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/annoaccademico.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/aoo.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/assetdiary.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/assetdiaryora.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/areadidattica.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/ateco.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/attach.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/attivform.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/aula.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/ccnlregistry_aziende.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/canale.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/classconsorsuale.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/contratto.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/contrattokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/convenzione.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/corsostudio.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/corsostudiocaratteristica.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/diderog.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/didprog.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/didprogaccesso.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/didproganno.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/didprogcurr.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/didproggrupp.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/didprogori.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/didprognumchiusokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/didprogporzanno.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/didprogsuddannokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/duratakind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/edificio.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/erogazkind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/esoneroanskind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/fonteindicebibliometrico.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/graduatoria.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/insegn.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/insegncaratteristica.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/insegninteg.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/insegnintegcaratteristica.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/inquadramento.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/iscrizione.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/iscrizioneanno.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/istattitolistudio.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/istitutokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/istitutoprinc.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/lezione.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/menuweb.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/nace.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/naturagiur.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/numerodip.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progetto.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettoactivitykind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettoasset.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettoattach.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettoattachkind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettoattachkindprogettostatuskind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettobudget.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettobudgetvariazione.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettocosto.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettoproroga.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettoregistry_aziende.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettorp.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettosettoreerc.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettostatuskind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotesto.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotestokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotestokindprogettostatuskind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotimesheet.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotimesheetprogetto.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotipocosto.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotipocostoaccmotive.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotipocostocontrattokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotipocostoinventorytree.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotipocostokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotipocostokindaccmotive.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotipocostokindcontrattokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotipocostokindinventorytree.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotipocostokindtax.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettotipocostotax.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettoudr.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettoudrmembro.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/progettoudrmembrokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/protocollo.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/protocollodestinatario.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/protocollodoc.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/protocollodocelement.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/protocollodockind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/protocollorifkind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/prova.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/publicaz.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/publicazkeyword.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/publicazkind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/publicazkindpublicaz.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/publicazregistry_aziende.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/publicazregistry_docenti.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/registryprogfin.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/registryprogfinbando.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/registryprogfinbandoattach.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/registry_amministrativi.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/registry_aziende.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/registry_docenti.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/registry_istituti.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/registry_istitutiesteri.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/registry_studenti.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/rendicont.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/rendicontaltro.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/rendicontattivitaprogetto.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/rendicontattivitaprogettoora.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/rendicontlezionestud.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/sasd.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/sede.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/sessione.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/sessionekind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/settoreerc.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/sospensione.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/statuskind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/stipendiokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/struttura.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/strutturakind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/studdirittokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/studprenotkind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/tipoattform.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/titolokind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/titolostudio.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/workpackage.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/workpackagekind.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/workpackageupb.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/year.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_accmotivedefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_accmotivesegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_affidamentodefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_affidamentodocview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_affidamentosegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_assetdiarydocview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_assetdiaryoraview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_assetsegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_attivformappelloview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_attivformdefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_attivformerogataview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_attivformgruppoview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_attivformpropedview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_canaleerogataview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_contrattokinddefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_corsostudiodotmasview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_corsostudiostatoview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_diderogdefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_didprogdefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_didprogdotmasview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_didprogstatoview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_edificioseg_childview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_fonteindicebibliometricosegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_GenerateTimesheetView.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_geo_cityseg5view.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_getcontratti.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_getprogettocostoview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_getregistrydocentiamministrativi.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_getregistrydocentiamministratividefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_inventorytreesegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_duratakinddefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_progettoactivitykinddefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_progettoassetdefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_progettokindsegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_progettosegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_progettotipocostosegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_progettoudrmembrokinddefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_publicazdefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_publicazdocentiview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_publicazkinddefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registryaddresssegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registryamministrativiview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registryamministrativi_personaleview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registryaziendeview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registryclassaziendeview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registryclassdefaultview.sql");
			scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registrydefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registrydocentiview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registrydocenti_docview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registryistituti_princview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registryistitutiesteriview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registryistitutiview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registryprogfinbandosegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_registryprogfinsegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_rendicontattivitaprogettoanagammview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_rendicontattivitaprogettoanagview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_rendicontattivitaprogettodocview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_rendicontattivitaprogettooraview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_rendicontattivitaprogettosegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_sededefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_sedeseg_child_aziendaview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_sedeseg_childview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_settoreercsegprogview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_settoreercsegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_stipendiokinddefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_strutturadefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_strutturakinddefaultview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_strutturaprincview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_taxsegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_titolostudiodocentiview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_upbsegview.sql");
			//scripts.Add("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_workpackagesegview.sql");

			var vocs = new List<string>();
			vocs.Add("classconsorsuale");
			vocs.Add("contrattokind");
			vocs.Add("publicazkind");
			vocs.Add("sasd");
			vocs.Add("areadidattica");
			vocs.Add("istitutokind");
			vocs.Add("annoaccademico");
			vocs.Add("istattitolistudio");
			vocs.Add("strutturakind");
			vocs.Add("tipoattform");
			vocs.Add("affidamentokind");
			vocs.Add("erogazkind");
			vocs.Add("sessionekind");
			vocs.Add("nace"); 
			vocs.Add("ateco");
			vocs.Add("protocollodockind");
			vocs.Add("protocollorifkind");
			vocs.Add("tipoattform");
			vocs.Add("ambitoareadisc");
			vocs.Add("fonteindicebibliometrico");
			vocs.Add("progettoactivitykind");
			vocs.Add("progettostatuskind");
			vocs.Add("settoreerc");
			vocs.Add("settoreerc");
			vocs.Add("tax");
			vocs.Add("nace");
			vocs.Add("ateco");
			vocs.Add("inquadramento");
			vocs.Add("duratakind");
			vocs.Add("naturagiur");
			vocs.Add("numerodip");
			vocs.Add("currency");
			vocs.Add("progettoudrmembrokind");

			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				Segreterie.Generator.ConsoleWriter.connection = connection;

				var allfields = new List<Segreterie.Generator.field>();

				foreach (var s in scripts) {
					var tablename = s
						.Replace("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_Generate", "")
						.Replace("D:/progetti/Portale/client/app_segreterie/ScriptSQL/v_", "")
						.Replace("D:/progetti/Portale/client/app_segreterie/ScriptSQL/", "")
						.Replace(".sql", "");
					Segreterie.Generator.ConsoleWriter.Info(tablename);
					Segreterie.Generator.Program.WriteSQLScript(s, tablename, vocs.Contains(tablename), ref allfields, connection);
				}
				connection.Close();
			}
		}


	}

	


}