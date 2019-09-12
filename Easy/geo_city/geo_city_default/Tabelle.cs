/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

using System;
using System.Data;
using metadatalibrary;
using System.Windows.Forms;

namespace geo_city_default//geo_comune//
{
	/// <summary>
	/// Summary description for Tabelle.
	/// </summary>
	public class Tabelle
	{

		private DataRow[] rComuniDaAccoppiare = new DataRow[2];
		private VistaGeo_Comune.tutte_le_coppieRow rComuniDaDisaccoppiare;
		private int idProvinciaCorrente;
		private int[][] valoriDiMatching;
		private bool occupato;
		private string filtroIdProvincia;
		private VistaGeo_Comune.geo_importazione_datiRow rImportazioneDati;

        private const char LOG_INSERIMENTO = 'I';
		private const char LOG_MODIFICA = 'U';
		private const char LOG_CANCELLAZIONE = 'D';

		private DateTime COMUNE_CANCELLATO = new DateTime(1900, 1, 1);

		private const string CLN_GEO_DATA_FINE = "datafine";
		private const string CLN_GEO_DATA_INIZIO = "datainizio";
		private const string CLN_GEO_DENOMINAZIONE = "denominazione";
		private const string CLN_GEO_IDCOMUNE = "idcomune";
		private const string CLN_GEO_IDPROVINCIA = "idprovincia";
		private const string CLN_GEO_NUOVO_COMUNE = "nuovocomune";
		private const string CLN_GEO_VECCHIO_COMUNE = "vecchiocomune";

		private const string CLN_PROVINCIA_SIGLA = "sigla";
		
		private const string CLN_COMIMPORT_DENOMINAZIONE = "nome";
		private const string CLN_COMIMPORT_IDCOMUNE = "idcomune";
		private const string CLN_COMIMPORT_IDPROVINCIA = "idprovincia";
		private const string CLN_COMIMPORT_DATA_FINE = "datafine";
		private string[] CLN_COMIMPORT_VALORE = {"valore1","valore2"};
		
		private const string CLN_COPPIE_IDCOMUNE1 = "idcomune1";
		private const string CLN_COPPIE_IDCOMUNE2 = "idcomune2";
		private const string CLN_COPPIE_IDPROVINCIA1 = "idprovincia1";
		private const string CLN_COPPIE_IDPROVINCIA2 = "idprovincia2";
		private const string CLN_COPPIE_IS_NUOVO_1 = "isnuovo1";
		private const string CLN_COPPIE_IS_NUOVO_2 = "isnuovo2";
		private const string CLN_COPPIE_MATCHING = "matching";
		private const string CLN_COPPIE_NOME1 = "nome1";
		private const string CLN_COPPIE_NOME2 = "nome2";
		private const string CLN_COPPIE_PROVINCIA1 = "provincia1";
		private const string CLN_COPPIE_PROVINCIA2 = "provincia2";
		
		private const string CLN_DETTAGLI_CAP = "cap";
		private const string CLN_DETTAGLI_CATASTO = "catasto";
		private const string CLN_DETTAGLI_DATA_FINE = "data_fine";
		private const string CLN_DETTAGLI_DATA_INIZIO = "data_inizio";
		private const string CLN_DETTAGLI_DENOMINAZIONE = "denominazione";
		private const string CLN_DETTAGLI_FISCO = "fisco";
		private const string CLN_DETTAGLI_IDCOMUNE = "idcomune";
		private const string CLN_DETTAGLI_ISTAT = "istat";
		private const string CLN_DETTAGLI_NUOVO_COMUNE = "nuovo_comune";
		private const string CLN_DETTAGLI_PROVINCIA = "provincia";
		private const string CLN_DETTAGLI_STATUS = "status";
		private const string CLN_DETTAGLI_VECCHIO_COMUNE = "vecchio_comune";

		private const string CLN_COMIMPORT_SIGLA_PROVINCIA = "sigla_provincia";
		private const string CLN_COMIMPORT_DATA_INIZIO = "datainizio";
		private const string CLN_COMIMPORT_FISCO = "fisco";
		private const string CLN_COMIMPORT_ISTAT = "istat";
		private const string CLN_COMIMPORT_CAP = "cap";
		private const string CLN_COMIMPORT_CATASTO = "catasto";

		private const string CLN_IMPORT_CORREZIONE_FOFC_PSPU = "correzione_fofc_pspu";
		private const string CLN_IMPORT_CORREZIONE_DATAINIZIO_1960_01_01="correzione_datainizio_1960_01_01";
		private const string CLN_IMPORT_DENOMINAZIONE = "cln_denominazione";
		private const string CLN_IMPORT_ID_CODICE = "idcodice";
		private const string CLN_IMPORT_ID_ENTE = "idente";
		private const string CLN_IMPORT_ID_PROVINCIA = "cln_id_provincia";
		private const string CLN_IMPORT_NOME_IMPORTAZIONE = "nome_importazione";
		private const string CLN_IMPORT_SIGLA_PROVINCIA = "cln_sigla_provincia";
		private const string CLN_IMPORT_TABELLA_SORGENTE = "tabella_sorgente";
		private const string CLN_IMPORT_DATA_INIZIO = "cln_data_inizio";
		private const string CLN_IMPORT_DATA_FINE = "cln_data_fine";
		private const string CLN_IMPORT_ISTAT = "cln_istat";
		private const string CLN_IMPORT_FISCO = "cln_fisco";
		private const string CLN_IMPORT_CATASTO = "cln_catasto";
		private const string CLN_IMPORT_CAP = "cln_cap";
		private const string CLN_IMPORT_VALORE1 = "cln_valore1";
		private const string CLN_IMPORT_VALORE2 = "cln_valore2";

		private const string CLN_SINGLE1_IDPROVINCIA = "idprovincia";
		private const string CLN_SINGLE1_IS_NUOVO = "isnuovo";
		private const string CLN_SINGLE1_NOME = CLN_COMIMPORT_DENOMINAZIONE;
		private const string CLN_SINGLE1_PROVINCIA = "provincia";
		private const string CLN_SINGLE1_IDCOMUNE = "idcomune";

		private const string CLN_SINGLE2_IDCOMUNE = "idcomune";
		private const string CLN_SINGLE2_IDPROVINCIA = "idprovincia";
		private const string CLN_SINGLE2_IS_NUOVO = "isnuovo";
		private const string CLN_SINGLE2_MATCHING = "matching";
		private const string CLN_SINGLE2_NOME = CLN_GEO_DENOMINAZIONE;
		private const string CLN_SINGLE2_PROVINCIA = "provincia";

		


		private MetaData meta;
		private VistaGeo_Comune DS;

		public Tabelle(MetaData _meta, VistaGeo_Comune _DS, DataGrid dataGridDettagli, ComboBox comboBoxProvincia)
		{
			meta = _meta;
			DS = _DS;
		
			PostData.MarkAsTemporaryTable(DS.dettagli, false);
//			PostData.MarkAsTemporaryTable(DS.risultato, false);
			PostData.MarkAsTemporaryTable(DS.geo_comuni_da_importare, false);
			PostData.MarkAsTemporaryTable(DS.tutti_i_single1, false);
			PostData.MarkAsTemporaryTable(DS.tutti_i_single2, false);
			PostData.MarkAsTemporaryTable(DS.tutte_le_coppie, false);
			PostData.MarkAsTemporaryTable(DS.single1_della_provincia_corrente, false);
			PostData.MarkAsTemporaryTable(DS.single2_della_provincia_corrente, false);
			PostData.MarkAsTemporaryTable(DS.coppie_della_provincia_corrente, false);
			PostData.MarkAsTemporaryTable(DS.province_selezionate, false);
			PostData.MarkAsTemporaryTable(DS.geo_provincia, false);

			DS.geo_comuni_da_importare.idcomuneColumn.Caption = "id. comune";
			DS.geo_comuni_da_importare.idprovinciaColumn.Caption = "id. provincia";
			DS.geo_comuni_da_importare.datainizioColumn.Caption = "data inizio";
			DS.geo_comuni_da_importare.datafineColumn.Caption = "data fine";
			DS.geo_comuni_da_importare.sigla_provinciaColumn.Caption = "sigla";

			DS.geo_comune.idcomuneColumn.Caption = "id. comune";
			DS.geo_comune.vecchiocomuneColumn.Caption = "vecchio";
			DS.geo_comune.nuovocomuneColumn.Caption = "nuovo";
			DS.geo_comune.datainizioColumn.Caption = "data inizio";
			DS.geo_comune.datafineColumn.Caption = "data fine";
			DS.geo_comune.idprovinciaColumn.Caption = "id. provincia";

/*			DS.risultato.idcomuneColumn.Caption = "id. comune";
			DS.risultato.idprovinciaColumn.Caption = "id. provincia";
			DS.risultato.primo_comune_trovatoColumn.Caption = "primo comune trovato";
			DS.risultato.secondo_comune_trovatoColumn.Caption = "secondo comune trovato";
*/
			DS.dettagli.idcomuneColumn.Caption = "id. comune";
			DS.dettagli.data_inizioColumn.Caption = "data inizio";
			DS.dettagli.data_fineColumn.Caption = "data fine";

			DS.coppie_della_provincia_corrente.idcomune1Column.Caption = "id. 1";
			DS.coppie_della_provincia_corrente.idcomune2Column.Caption = "id. 2";
			DS.coppie_della_provincia_corrente.nome1Column.Caption = "nome del comune da importare";
			DS.coppie_della_provincia_corrente.nome2Column.Caption = "nome del comune già memorizzato";
			DS.coppie_della_provincia_corrente.isnuovo1Column.Caption = "nuovo1";
			DS.coppie_della_provincia_corrente.isnuovo2Column.Caption = "nuovo2";

			DS.single1_della_provincia_corrente.idcomuneColumn.Caption = "id.";
			DS.single1_della_provincia_corrente.nomeColumn.Caption = "nome del comune da importare";
			DS.single1_della_provincia_corrente.idprovinciaColumn.Caption = "";
			DS.single1_della_provincia_corrente.isnuovoColumn.Caption = "nuovo";

			DS.single2_della_provincia_corrente.idcomuneColumn.Caption = "id.";
			DS.single2_della_provincia_corrente.denominazioneColumn.Caption = "nome del comune già memorizzato";
			DS.single2_della_provincia_corrente.idprovinciaColumn.Caption = "";
			DS.single2_della_provincia_corrente.isnuovoColumn.Caption = "nuovo";

			DS.geo_aggiornamento.id_aggiornamentoColumn.Caption = "id. aggiornamento";
			DS.geo_aggiornamento.tabella_originaleColumn.Caption = "tabella originale";
			DS.geo_aggiornamento.tabella_geoColumn.Caption = "tabella geo";
			DS.geo_aggiornamento.comune_importatoColumn.Caption = "comune importato";
			DS.geo_aggiornamento.vecchio_valoreColumn.Caption = "vecchio valore";
			DS.geo_aggiornamento.nuovo_valoreColumn.Caption = "nuovo valore";


			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn,
				DS.geo_provincia, "sigla", 
				null, null,  true
			);

			DS.geo_provincia.AcceptChanges();

			associaGridConTable(dataGridDettagli, DS.dettagli);
		}

		public DataTable getComuniDaImportare() 
		{
			return DS.geo_comuni_da_importare;
		}

		private void copiaRighe(DataRow[] righeSorg, DataTable table)
		{
			table.Clear();
			foreach (DataRow rigaSorg in righeSorg) 
			{
				DataRow riga = table.NewRow();
				foreach (DataColumn col in table.Columns) 
				{
					riga[col.ColumnName] = rigaSorg[col.ColumnName];
				}
				table.Rows.Add(riga);
			}
		}


		public bool isValidSingle1() 
		{
			return rComuniDaAccoppiare[0]!=null;
		}

		public bool isValidSingle2() 
		{
			return rComuniDaAccoppiare[1]!=null;		
		}


		public DataTable getProvince() 
		{
			return DS.geo_provincia;
		}

/*		public DataTable pulisciTabellaRisultato() 
		{
			DS.risultato.Clear();
			return DS.risultato;
		}

		public void aggiungiNuovaRigaInRisultati(DataTable dtRisultato, DataRow rComuneDaImportare, string primoComuneTrovato, string secondoComuneTrovato, string siglaProvincia) 
		{
			DataRow drNuova = dtRisultato.NewRow();
			drNuova[CLN_RISULTATO_DENOMINAZIONE] = rComuneDaImportare[CLN_COMIMPORT_DENOMINAZIONE];
			drNuova[CLN_RISULTATO_ID_PROVINCIA] = rComuneDaImportare[CLN_COMIMPORT_IDPROVINCIA];
			drNuova[CLN_RISULTATO_PRIMO_COMUNE_TROVATO] = primoComuneTrovato;
			drNuova[CLN_RISULTATO_SECONDO_COMUNE_TROVATO] = secondoComuneTrovato;
			drNuova[CLN_RISULTATO_MATCHED_PROVINCIA] = siglaProvincia;
			dtRisultato.Rows.Add(drNuova);
		}*/


		public void setProvincia(int idProvincia, DataGrid dataGridCoppie, DataGrid dataGridSingle1, DataGrid dataGridSingle2) 
		{
			idProvinciaCorrente = idProvincia;
			rComuniDaAccoppiare[0] = null;
			rComuniDaAccoppiare[1] = null;

			foreach (DataRow r in DS.dettagli.Rows) 
			{
				foreach (DataColumn c in DS.dettagli.Columns) 
				{
					r[c] = DBNull.Value;
				}
			}

			DataRow[] rCoppie = DS.tutte_le_coppie.Select(CLN_COPPIE_IDPROVINCIA1+"="+idProvinciaCorrente);
			copiaRighe(rCoppie, DS.coppie_della_provincia_corrente);

			DataRow[] rSingle1 = DS.tutti_i_single1.Select(CLN_SINGLE1_IDPROVINCIA+"="+idProvinciaCorrente);
			copiaRighe(rSingle1, DS.single1_della_provincia_corrente);
			
			DataRow[] rSingle2 = DS.tutti_i_single2.Select(CLN_SINGLE2_IDPROVINCIA+"="+idProvinciaCorrente);
			copiaRighe(rSingle2, DS.single2_della_provincia_corrente);

			associaGridConTable(dataGridCoppie, DS.coppie_della_provincia_corrente);
			associaGridConTable(dataGridSingle1, DS.single1_della_provincia_corrente);
			associaGridConTable(dataGridSingle2, DS.single2_della_provincia_corrente);

			matchingTraISingle();
		}

		public void associaGridConTable(DataGrid grid, DataTable table) 
		{
			meta.DescribeColumns(table, "default");
			HelpForm.SetDataGrid(grid, table);
			new formatgrids(grid).AutosizeColumnWidth();
		}

		public DataRow[] getGeoComuniDiUnaProvincia(int idProvinciaCorrente) 
		{
			return DS.geo_comune.Select(CLN_GEO_IDPROVINCIA+"="+idProvinciaCorrente);		
		}

		#region 1: INIZIALIZZAZIONE SINGLE1, SINGLE2, COPPIE

		public void inserisciNuovaRigaInTabellaTutteLeCoppie (
			DataRow rComuneDaImportare,
			DataRow rGeoComune,
			string siglaProvincia1,
			string siglaProvincia2,
			bool isComuneDaImportareNuovo,
			bool isGeoComuneNuovo,
			int matchingValue
			) 
		{
			creaNuovaCoppia (
				rComuneDaImportare[CLN_COMIMPORT_IDCOMUNE],
				rGeoComune[CLN_GEO_IDCOMUNE],
				rComuneDaImportare[CLN_COMIMPORT_IDPROVINCIA],
				rGeoComune[CLN_GEO_IDPROVINCIA],
				rComuneDaImportare[CLN_COMIMPORT_DENOMINAZIONE],
				rGeoComune[CLN_GEO_DENOMINAZIONE],
				siglaProvincia1,
				siglaProvincia2,
				isComuneDaImportareNuovo,
				isGeoComuneNuovo,
				matchingValue
			);
		}

		public void inserisciNuovaRigaInTabellaTuttiISingle1 (
			DataRow rComuneDaImportare, string siglaProvincia
			)
		{
			VistaGeo_Comune.geo_comuni_da_importareRow rComDaImp = (VistaGeo_Comune.geo_comuni_da_importareRow) rComuneDaImportare;
			creaNuovoSingle1 (
				rComDaImp.idcomune,
				rComDaImp.idprovincia,
				rComDaImp.nome,
				rComDaImp.sigla_provincia,
				isComuneDaImportareNuovo(rComDaImp)
			);
		}

		public void inserisciNuovaRigaInTabellaTuttiISingle2(DataRow rGeoComune, string siglaProvincia) 
		{
			VistaGeo_Comune.geo_comuneRow rGeo = (VistaGeo_Comune.geo_comuneRow) rGeoComune;
			creaNuovoSingle2 (
				rGeo.idcomune,
				rGeo.idprovincia,
				rGeo.denominazione,
				siglaProvincia,
				isGeoComuneNuovo(rGeo)
			);
		}
		#endregion

		#region 2: COPIA DA (SINGLE1, SINGLE2, COPPIE) IN DETTAGLI

		private void completaDettagliComuneDaImportare(VistaGeo_Comune.geo_comuni_da_importareRow rComuneDaImportare) 
		{
			DS.dettagli.Rows[0][CLN_DETTAGLI_IDCOMUNE] = rComuneDaImportare[CLN_COMIMPORT_IDCOMUNE];
			DS.dettagli.Rows[0][CLN_DETTAGLI_DENOMINAZIONE] = rComuneDaImportare[CLN_COMIMPORT_DENOMINAZIONE];
			DS.dettagli.Rows[0][CLN_DETTAGLI_PROVINCIA] = rComuneDaImportare[CLN_COMIMPORT_SIGLA_PROVINCIA];
			DS.dettagli.Rows[0][CLN_DETTAGLI_DATA_INIZIO] = rComuneDaImportare[CLN_COMIMPORT_DATA_INIZIO];
			DS.dettagli.Rows[0][CLN_DETTAGLI_DATA_FINE] = rComuneDaImportare[CLN_COMIMPORT_DATA_FINE];
			DS.dettagli.Rows[0][CLN_DETTAGLI_FISCO] = rComuneDaImportare[CLN_COMIMPORT_FISCO];
			DS.dettagli.Rows[0][CLN_DETTAGLI_CATASTO] = rComuneDaImportare[CLN_COMIMPORT_CATASTO];
			DS.dettagli.Rows[0][CLN_DETTAGLI_ISTAT] = rComuneDaImportare[CLN_COMIMPORT_ISTAT];
			DS.dettagli.Rows[0][CLN_DETTAGLI_CAP] = rComuneDaImportare[CLN_COMIMPORT_CAP];
		}

		/// <summary>
		/// Copia una riga di tSingle1 nella prima riga di DS.dettagli e conserva tale riga in 
		/// rComuniDaAccoppiare
		/// </summary>
		/// <param name="rSingle1"></param>
		public bool inserisciUnSingle1NeiDettagli(int idSingle1, int indiceRigaSingle1) 
		{
			if (occupato) return false;
			if ((rComuniDaAccoppiare[0]!=null)&&
				Convert.ToInt16(rComuniDaAccoppiare[0][CLN_SINGLE1_IDCOMUNE])==idSingle1) return false;

			DataRow rSingle1 = DS.tutti_i_single1.Select(CLN_SINGLE1_IDCOMUNE+"="+idSingle1)[0];

			rComuniDaAccoppiare[0] = rSingle1;

			DS.dettagli.Rows[0][CLN_DETTAGLI_STATUS]="S";

			VistaGeo_Comune.geo_comuni_da_importareRow rComuneDaImportare = (VistaGeo_Comune.geo_comuni_da_importareRow)
				DS.geo_comuni_da_importare.Select(CLN_COMIMPORT_IDCOMUNE+"="+idSingle1)[0];

			completaDettagliComuneDaImportare(rComuneDaImportare);

			if (rComuniDaAccoppiare[1]==null) 
			{
				foreach (DataColumn col in DS.dettagli.Columns) 
				{
					DS.dettagli.Rows[1][col]=DBNull.Value;
				}
			}

			DataRow[] rSingle2 = DS.single2_della_provincia_corrente.Select();
			for (int j=0; j<rSingle2.Length; j++)
			{
				rSingle2[j][CLN_SINGLE2_MATCHING] = valoriDiMatching[indiceRigaSingle1][j];
			}
			rComuniDaDisaccoppiare = null;
			return true;
		}


		private void completaDettagliGeocomune(VistaGeo_Comune.geo_comuneRow rGeoComune) 
		{
			DataAccess da = meta.Conn;
			DS.dettagli.Rows[1][CLN_DETTAGLI_IDCOMUNE] = rGeoComune.idcomune;
			DS.dettagli.Rows[1][CLN_DETTAGLI_DENOMINAZIONE] = rGeoComune[CLN_GEO_DENOMINAZIONE];
			DS.dettagli.Rows[1][CLN_DETTAGLI_DATA_INIZIO] = rGeoComune[CLN_GEO_DATA_INIZIO];
			DS.dettagli.Rows[1][CLN_DETTAGLI_DATA_FINE] = rGeoComune[CLN_GEO_DATA_FINE];
			DS.dettagli.Rows[1][CLN_DETTAGLI_VECCHIO_COMUNE] = rGeoComune[CLN_GEO_VECCHIO_COMUNE];
			DS.dettagli.Rows[1][CLN_DETTAGLI_NUOVO_COMUNE] = rGeoComune[CLN_GEO_NUOVO_COMUNE];

			DS.dettagli.Rows[1][CLN_DETTAGLI_FISCO] = da.DO_READ_VALUE(
				"geo_comune_ente", 
				  "(idcomune="+QueryCreator.quotedstrvalue(rGeoComune.idcomune, true)
				+ ") and (idente="+QueryCreator.quotedstrvalue(1, true)
				+ ") and (idcodice="+QueryCreator.quotedstrvalue(1, true)
				+ ")", 
				"valore"
				);
			DS.dettagli.Rows[1][CLN_DETTAGLI_CATASTO] = da.DO_READ_VALUE(
				"geo_comune_ente", 
				"(idcomune="+QueryCreator.quotedstrvalue(rGeoComune.idcomune, true)
				+ ") and (idente="+QueryCreator.quotedstrvalue(1, true)
				+ ") and (idcodice="+QueryCreator.quotedstrvalue(2, true)
				+ ")", 
				"valore"
				);
			DS.dettagli.Rows[1][CLN_DETTAGLI_ISTAT] = da.DO_READ_VALUE(
				"geo_comune_ente", 
				"(idcomune="+QueryCreator.quotedstrvalue(rGeoComune.idcomune, true)
				+ ") and (idente="+QueryCreator.quotedstrvalue(2, true)
				+ ") and (idcodice="+QueryCreator.quotedstrvalue(1, true)
				+ ")", 
				"valore"
				);
			DS.dettagli.Rows[1][CLN_DETTAGLI_CAP] = da.DO_READ_VALUE(
				"geo_comune_ente", 
				"(idcomune="+QueryCreator.quotedstrvalue(rGeoComune.idcomune, true)
				+ ") and (idente="+QueryCreator.quotedstrvalue(3, true)
				+ ") and (idcodice="+QueryCreator.quotedstrvalue(1, true)
				+ ")", 
				"valore"
				);
		}

		public bool inserisciUnSingle2NeiDettagli(int idSingle2, int indiceRigaSingle2) 
		{
			if (occupato) return false;
			if ((rComuniDaAccoppiare[1]!=null)&&
				Convert.ToInt16(rComuniDaAccoppiare[1][CLN_SINGLE2_IDCOMUNE])==idSingle2) return false;
			
			DataRow rSingle2 = DS.tutti_i_single2.Select(CLN_SINGLE2_IDCOMUNE+"="+idSingle2)[0];
			rComuniDaAccoppiare[1] = rSingle2;

			DS.dettagli.Rows[1][CLN_DETTAGLI_STATUS] = "S";
			DS.dettagli.Rows[1][CLN_DETTAGLI_PROVINCIA] = rSingle2[CLN_SINGLE2_PROVINCIA];

			VistaGeo_Comune.geo_comuneRow rGeoComune = (VistaGeo_Comune.geo_comuneRow)
				DS.geo_comune.Select(CLN_GEO_IDCOMUNE+"="+idSingle2)[0];

			completaDettagliGeocomune(rGeoComune);

			if (rComuniDaAccoppiare[0]==null) 
			{
				foreach (DataColumn col in DS.dettagli.Columns) 
				{
					DS.dettagli.Rows[0][col]=DBNull.Value;
				}
			}
			DataRow[] rSingle1 = DS.single1_della_provincia_corrente.Select();
			for (int i=0; i<rSingle1.Length; i++)
			{
				rSingle1[i][CLN_SINGLE2_MATCHING] = valoriDiMatching[i][indiceRigaSingle2];
			}
			rComuniDaDisaccoppiare = null;
			return true;
		}

		public bool inserisciUnaCoppiaNeiDettagli(int id1, int id2) 
		{
			if (occupato) return false;
			if ((rComuniDaDisaccoppiare!=null)&&
				(Convert.ToInt16(rComuniDaDisaccoppiare[CLN_COPPIE_IDCOMUNE1])==id1)&&
				(Convert.ToInt16(rComuniDaDisaccoppiare[CLN_COPPIE_IDCOMUNE2])==id2)) return false;
			
			VistaGeo_Comune.geo_comuni_da_importareRow rAccoppiato1 = (VistaGeo_Comune.geo_comuni_da_importareRow)
				DS.geo_comuni_da_importare.Select (
				CLN_COMIMPORT_IDCOMUNE+"="+id1
				)[0];
			VistaGeo_Comune.geo_comuneRow rAccoppiato2 = (VistaGeo_Comune.geo_comuneRow)
				DS.geo_comune.Select (
				CLN_GEO_IDCOMUNE+"="+id2
				)[0];
			rComuniDaDisaccoppiare = (VistaGeo_Comune.tutte_le_coppieRow)
				DS.tutte_le_coppie.Select(
				CLN_COPPIE_IDCOMUNE1+"="+id1+" and "+CLN_COPPIE_IDCOMUNE2+"="+id2
				)[0];

			rComuniDaAccoppiare[0] = null;
			rComuniDaAccoppiare[1] = null;

			DS.dettagli.Rows[0][CLN_DETTAGLI_STATUS] = "C";
			DS.dettagli.Rows[1][CLN_DETTAGLI_STATUS] = "C";

			DS.dettagli.Rows[1][CLN_DETTAGLI_PROVINCIA] = rComuniDaDisaccoppiare[CLN_COPPIE_PROVINCIA2];

			completaDettagliComuneDaImportare(rAccoppiato1);

			completaDettagliGeocomune(rAccoppiato2);
			return true;
		}

		public void matchingTraISingle() 
		{
			VistaGeo_Comune.single1_della_provincia_correnteRow[] rSingle1 = (VistaGeo_Comune.single1_della_provincia_correnteRow[]) DS.single1_della_provincia_corrente.Select();
			VistaGeo_Comune.single2_della_provincia_correnteRow[] rSingle2 = (VistaGeo_Comune.single2_della_provincia_correnteRow[]) DS.single2_della_provincia_corrente.Select();
			valoriDiMatching = new int[rSingle1.Length][];
			for (int i=0; i<rSingle1.Length; i++) 
			{
				Matching.confrontaUnSingle1ConGeoComuni (
					this,
					rSingle1[i], 
					rSingle2,
					out valoriDiMatching[i]
				);

			}
		}

		#endregion



		#region 3: ACCOPPIA E DISACCOPPIA
		/// <summary>
		/// Aggiunge alla tabella delle coppie la nuova coppia formata dai due single che erano
		/// stati copiati nella tabella dei dettagli e rimuove tali due single dalle rispettive tabelle.
		/// </summary>
		/// <param name="tCoppieDiUnaProvincia"></param>
		/// <param name="tSingle1DiUnaProvincia"></param>
		/// <param name="tSingle2DiUnaProvincia"></param>
		public int accoppiaIDueSingleContenutiInDettagli (out int id1, out int id2) 
		{
			occupato = true;
			id1 = (int) rComuniDaAccoppiare[0][CLN_SINGLE1_IDCOMUNE];
			id2 = (int) rComuniDaAccoppiare[1][CLN_SINGLE2_IDCOMUNE];
//			string comuneDaImportare = Matching.eliminaAccenti(rComuniDaAccoppiare[0][CLN_SINGLE1_NOME].ToString());
//			string geoComune = rComuniDaAccoppiare[1][CLN_SINGLE2_NOME].ToString();
			
			rComuniDaDisaccoppiare = creaNuovaCoppia (
				id1,
				id2,
				rComuniDaAccoppiare[0][CLN_SINGLE1_IDPROVINCIA],
				rComuniDaAccoppiare[1][CLN_SINGLE2_IDPROVINCIA],
				rComuniDaAccoppiare[0][CLN_SINGLE1_NOME],
				rComuniDaAccoppiare[1][CLN_SINGLE2_NOME],
				rComuniDaAccoppiare[0][CLN_SINGLE1_PROVINCIA],
				rComuniDaAccoppiare[1][CLN_SINGLE2_PROVINCIA],
				rComuniDaAccoppiare[0][CLN_SINGLE1_IS_NUOVO],
				rComuniDaAccoppiare[1][CLN_SINGLE2_IS_NUOVO],
				Matching.confrontaUnSingle1ConUnSingle2 (
					this,
					(VistaGeo_Comune.tutti_i_single1Row) rComuniDaAccoppiare[0], 
					(VistaGeo_Comune.tutti_i_single2Row) rComuniDaAccoppiare[1]
				)
			);
			DS.dettagli.Rows[0][CLN_DETTAGLI_STATUS] = "C";
			DS.dettagli.Rows[1][CLN_DETTAGLI_STATUS] = "C";

			aggiungiAllaTabellaUnaCopiaDellaRiga(DS.coppie_della_provincia_corrente, rComuniDaDisaccoppiare);

			eliminaSingle1DallaTabellaDeiSingle1DellaProvinciaCorrente(id1);
			eliminaSingle2DallaTabellaDeiSingle2DellaProvinciaCorrente(id2);

			DS.tutti_i_single1.Rows.Remove(rComuniDaAccoppiare[0]);
			DS.tutti_i_single2.Rows.Remove(rComuniDaAccoppiare[1]);

			rComuniDaAccoppiare[0] = null;
			rComuniDaAccoppiare[1] = null;

			matchingTraISingle();
			int errore = controlloAccoppiamento(id1, id2);
			if (errore!=-1) 
			{
				MessageBox.Show("ERRORE "+errore+" NELL'ACCOPPIAMENTO di "+id1+" "+id2);
			}
			occupato = false;
			return DS.coppie_della_provincia_corrente.Rows.Count-1;
		}

		private int controlloAccoppiamento(object id1, object id2) 
		{
			int errore = -1;
			DataRow[] r = DS.tutti_i_single1.Select(CLN_SINGLE1_IDCOMUNE+"="+id1);
			if (r.Length!=0) 
			{
				errore = 0;
			}

			r = DS.tutti_i_single2.Select(CLN_SINGLE2_IDCOMUNE+"="+id2);
			if (r.Length!=0) 
			{
				errore = 1;
			}

			r = DS.single1_della_provincia_corrente.Select(CLN_SINGLE1_IDCOMUNE+"="+id1);
			if (r.Length!=0) 
			{
				errore = 2;
			}

			r = DS.single2_della_provincia_corrente.Select(CLN_SINGLE2_IDCOMUNE+"="+id2);
			if (r.Length!=0) 
			{
				errore = 3;
			}
			r = DS.tutte_le_coppie.Select (
				CLN_COPPIE_IDCOMUNE1+"="+id1+" and "+CLN_COPPIE_IDCOMUNE2+"="+id2
				);
			if (r.Length!=1) 
			{
				errore = 4;
			}

			r = DS.coppie_della_provincia_corrente.Select (
				CLN_COPPIE_IDCOMUNE1+"="+id1+" and "+CLN_COPPIE_IDCOMUNE2+"="+id2
				);
			if (r.Length!=1) {
				errore = 5;
			}
			return errore;
		}

		private int controlloDisaccoppiamento(object id1, object id2) 
		{
			int errore = -1;
			DataRow[] r = DS.tutti_i_single1.Select(CLN_SINGLE1_IDCOMUNE+"="+id1);
			if (r.Length!=1) 
			{
				errore = 0;
			}

			r = DS.tutti_i_single2.Select(CLN_SINGLE2_IDCOMUNE+"="+id2);
			if (r.Length!=1) 
			{
				errore = 1;
			}

			r = DS.single1_della_provincia_corrente.Select(CLN_SINGLE1_IDCOMUNE+"="+id1);
			if (r.Length!=1) 
			{
				errore = 2;
			}

			r = DS.single2_della_provincia_corrente.Select(CLN_SINGLE2_IDCOMUNE+"="+id2);
			if (r.Length!=1) 
			{
				errore = 3;
			}
			r = DS.tutte_le_coppie.Select (
				CLN_COPPIE_IDCOMUNE1+"="+id1+" and "+CLN_COPPIE_IDCOMUNE2+"="+id2
				);
			if (r.Length!=0) 
			{
				errore = 4;
			}

			r = DS.coppie_della_provincia_corrente.Select (
				CLN_COPPIE_IDCOMUNE1+"="+id1+" and "+CLN_COPPIE_IDCOMUNE2+"="+id2
				);
			if (r.Length!=0) 
			{
				errore = 5;
			}
			return errore;
		}

		private void eliminaSingle1DallaTabellaDeiSingle1DellaProvinciaCorrente(object id1) 
		{
			DataRow rigaDaEliminare = DS.single1_della_provincia_corrente.Select (
				CLN_SINGLE1_IDCOMUNE+"="+id1
				)[0];
			DS.single1_della_provincia_corrente.Rows.Remove(rigaDaEliminare);
		}

		private void eliminaSingle2DallaTabellaDeiSingle2DellaProvinciaCorrente(object id2) 
		{
			DataRow rigaDaEliminare = DS.single2_della_provincia_corrente.Select (
				CLN_SINGLE2_IDCOMUNE+"="+id2
				)[0];
			DS.single2_della_provincia_corrente.Rows.Remove(rigaDaEliminare);
		}

		private VistaGeo_Comune.tutte_le_coppieRow creaNuovaCoppia(
			object idComune1,
			object idComune2,
			object idProvincia1,
			object idProvincia2,
			object denominazione1,
			object denominazione2,
			object siglaProvincia1,
			object siglaProvincia2,
			object comuneDaImportareIsNuovo,
			object geoComuneIsNuovo,
			int matchingValue
			) 
		{
			VistaGeo_Comune.tutte_le_coppieRow 
				rCoppia = (VistaGeo_Comune.tutte_le_coppieRow) DS.tutte_le_coppie.NewRow();
			rCoppia[CLN_COPPIE_IDCOMUNE1] = idComune1;
			rCoppia[CLN_COPPIE_IDCOMUNE2] = idComune2;
			rCoppia[CLN_COPPIE_PROVINCIA1] = siglaProvincia1;
			rCoppia[CLN_COPPIE_PROVINCIA2] = siglaProvincia2;
			rCoppia[CLN_COPPIE_NOME1] = denominazione1;
			rCoppia[CLN_COPPIE_NOME2] = denominazione2;
			rCoppia[CLN_COPPIE_IDPROVINCIA1] = idProvincia1;
			rCoppia[CLN_COPPIE_IDPROVINCIA2] = idProvincia2;
			rCoppia[CLN_COPPIE_IS_NUOVO_1] = comuneDaImportareIsNuovo;
			rCoppia[CLN_COPPIE_IS_NUOVO_2] = geoComuneIsNuovo;
			rCoppia[CLN_COPPIE_MATCHING] = matchingValue;
			DS.tutte_le_coppie.Rows.Add(rCoppia);
			return rCoppia;
		}

		private VistaGeo_Comune.tutti_i_single1Row creaNuovoSingle1 (
			object idComune,
			object idProvincia,
			object denominazione,
			object siglaProvincia,
			object isNuovo
		) 
		{
			VistaGeo_Comune.tutti_i_single1Row rSingle1 = (VistaGeo_Comune.tutti_i_single1Row) DS.tutti_i_single1.NewRow();
			rSingle1[CLN_SINGLE1_IDCOMUNE] = idComune;
			rSingle1[CLN_SINGLE1_IDPROVINCIA] = idProvincia;
			rSingle1[CLN_SINGLE1_NOME] = denominazione;
			rSingle1[CLN_SINGLE1_PROVINCIA] = siglaProvincia;
			rSingle1[CLN_SINGLE1_IS_NUOVO] = isNuovo;
			DS.tutti_i_single1.Rows.Add(rSingle1);
			return rSingle1;
		}

		private VistaGeo_Comune.tutti_i_single2Row creaNuovoSingle2 (
			object idComune,
			object idProvincia,
			object denominazione,
			object siglaProvincia,
			object isNuovo
			) 
		{
			VistaGeo_Comune.tutti_i_single2Row rSingle2 = (VistaGeo_Comune.tutti_i_single2Row) 
				DS.tutti_i_single2.NewRow();
			rSingle2[CLN_SINGLE2_IDCOMUNE] = idComune;
			rSingle2[CLN_SINGLE2_IDPROVINCIA] = idProvincia;
			rSingle2[CLN_SINGLE2_NOME] = denominazione;
			rSingle2[CLN_SINGLE2_PROVINCIA] = siglaProvincia;
			rSingle2[CLN_SINGLE2_IS_NUOVO] = isNuovo;
			DS.tutti_i_single2.Rows.Add(rSingle2);
			return rSingle2;
		}
		/// <summary>
		/// Aggiunge rispettivamente alla tabella tSingle1 e tSingle2 i due comuni della coppia
		/// contenuti nella tabella dettagli e li conserva in rComuniDaAccoppiare;
		/// infine rimuove dalla tabella tCoppie la riga rComuniDaDisaccoppiare che conteneva tale coppia
		/// </summary>
		/// <param name="tCoppieDiUnaProvincia"></param>
		/// <param name="tSingle1DiUnaProvincia"></param>
		/// <param name="tSingle2DiUnaProvincia"></param>
		public void disaccoppiaLaCoppiaContenutaInDettagli(out int id1, out int id2) 
		{
			occupato = true;
			id1 = (int) rComuniDaDisaccoppiare[CLN_COPPIE_IDCOMUNE1];
			id2 = (int) rComuniDaDisaccoppiare[CLN_COPPIE_IDCOMUNE2];
			rComuniDaAccoppiare[0] = creaNuovoSingle1 (
				id1,
				rComuniDaDisaccoppiare[CLN_COPPIE_IDPROVINCIA1],
				rComuniDaDisaccoppiare[CLN_COPPIE_NOME1],
				rComuniDaDisaccoppiare[CLN_COPPIE_PROVINCIA1],
				rComuniDaDisaccoppiare[CLN_COPPIE_IS_NUOVO_1]
			);

			rComuniDaAccoppiare[1] = creaNuovoSingle2 (
				id2,
				rComuniDaDisaccoppiare[CLN_COPPIE_IDPROVINCIA2],
				rComuniDaDisaccoppiare[CLN_COPPIE_NOME2],
				rComuniDaDisaccoppiare[CLN_COPPIE_PROVINCIA2],
				rComuniDaDisaccoppiare[CLN_COPPIE_IS_NUOVO_2]
			);

			DS.dettagli.Rows[0][CLN_DETTAGLI_STATUS] = "S";
			DS.dettagli.Rows[1][CLN_DETTAGLI_STATUS] = "S";

			aggiungiAllaTabellaUnaCopiaDellaRiga(DS.single1_della_provincia_corrente, rComuniDaAccoppiare[0]);
			aggiungiAllaTabellaUnaCopiaDellaRiga(DS.single2_della_provincia_corrente, rComuniDaAccoppiare[1]);

			eliminaLaCoppiaDallaTabellaCoppieDellaProvinciaCorrente(id1, id2);

			DS.tutte_le_coppie.Rows.Remove(rComuniDaDisaccoppiare);
			rComuniDaDisaccoppiare = null;

			matchingTraISingle();
			int errore = controlloDisaccoppiamento(id1, id2);
			if (errore!=-1) 
			{
				MessageBox.Show("ERRORE "+errore+" NEL DISACCOPPIAMENTO di "+id1+" "+id2);
			}
			occupato = false;
		}

		private void aggiungiAllaTabellaUnaCopiaDellaRiga(DataTable tabellaDestinazione, DataRow rigaSorgente) 
		{
			DataRow rigaDest = tabellaDestinazione.NewRow();
			foreach (DataColumn c in tabellaDestinazione.Columns) 
			{
				rigaDest[c] = rigaSorgente[c.ColumnName];			
			}
			tabellaDestinazione.Rows.Add(rigaDest);
		}

		private void eliminaLaCoppiaDallaTabellaCoppieDellaProvinciaCorrente(object id1, object id2) 
		{
			DataRow coppiaDaEliminare = DS.coppie_della_provincia_corrente.Select (
				CLN_COPPIE_IDCOMUNE1+"="+id1+" and "+CLN_COPPIE_IDCOMUNE2+"="+id2
				)[0];
			DS.coppie_della_provincia_corrente.Rows.Remove(coppiaDaEliminare);
		}
		#endregion

		public DataRow[] getComuniDaImportareDiUnaProvincia(int idProvincia) 
		{
			return DS.geo_comuni_da_importare.Select(CLN_COMIMPORT_IDPROVINCIA+"="+idProvincia);
		}


		#region lettura di una colonna da una riga
		public int getIdComuneDaSingle1(DataRow rSingle1) 
		{
			return (int) rSingle1[CLN_SINGLE1_IDCOMUNE];
		}

		public int getIdComuneDaSingle2(DataRow rSingle2) 
		{
			return (int) rSingle2[CLN_SINGLE2_IDCOMUNE];
		}

		public int getIdComune1DaCoppia(DataRow rCoppia) 
		{
			return (int) rCoppia[CLN_COPPIE_IDCOMUNE1];
		}

		public int getIdComune2DaCoppia(DataRow rCoppia) 
		{
			return (int) rCoppia[CLN_COPPIE_IDCOMUNE2];
		}

		public string getNomeDaComuneDaImportareOSingle1(DataRow rGeoComune) 
		{
			return rGeoComune[CLN_COMIMPORT_DENOMINAZIONE].ToString();
		}

		public string getNomeDaGeoComuneOSingle2(DataRow rGeoComune) 
		{
			return rGeoComune[CLN_GEO_DENOMINAZIONE].ToString();
		}

		public int getIdDaProvincia(DataRow rProvincia) 
		{
			return Convert.ToInt32(rProvincia[CLN_COMIMPORT_IDPROVINCIA].ToString());
		}

		public string getSiglaDaProvincia(DataRow rProvincia)
		{
			return rProvincia[CLN_PROVINCIA_SIGLA].ToString();
		}

		public static string getNomeImportazione(DataRow rImport) 
		{
			return rImport[CLN_IMPORT_NOME_IMPORTAZIONE].ToString();
		}
		#endregion

		private string nullSeDBNull(string nomeColonna, object s) 
		{
			return (s is DBNull) 
				? ", "+nomeColonna+"=null" 
				: ", "+nomeColonna+"=i."+((string)s).Replace("+","+i.");
		}

		private string clausolaWhereSullaProvincia() 
		{
			if (!(rImportazioneDati[CLN_IMPORT_ID_PROVINCIA] is DBNull))
			{
				string where = "(p.idprovincia=i."+rImportazioneDati[CLN_IMPORT_ID_PROVINCIA]+") where (p."+filtroIdProvincia+")";
				return where;
			} 
			if (!(rImportazioneDati[CLN_IMPORT_SIGLA_PROVINCIA] is DBNull))
			{
				object clnSiglaProv = rImportazioneDati[CLN_IMPORT_SIGLA_PROVINCIA];

				if (rImportazioneDati[CLN_IMPORT_CORREZIONE_FOFC_PSPU].ToString()=="S") 
				{
					return "(p.sigla=case i."+clnSiglaProv+" when 'FO' then 'FC' when 'PS' then 'PU' else i."+clnSiglaProv+" end) where (p."+filtroIdProvincia+")";
				}
				return "(p.sigla=i."+clnSiglaProv+") where (p."+filtroIdProvincia+")";
			}
			return null;
		}


		#region utilities
		
		public void stampaTabella(DataTable table) 
		{
			Console.WriteLine("STAMPA DELLE "+table.Rows.Count+" RIGHE DI "+table.TableName);
			foreach (DataRow r in table.Rows) 
			{
				foreach (DataColumn c in table.Columns) 
				{
					Console.Write(r[c]+" ");
				}
				Console.WriteLine();
			}
		}

		public void stampaRighe(DataRow[] righe) 
		{
			Console.WriteLine("STAMPA DELLE "+righe.Length+" RIGHE");
			foreach (DataRow r in righe) 
			{
				foreach (DataColumn c in r.Table.Columns) 
				{
					Console.Write(r[c]+" ");
				}
				Console.WriteLine();
			}
		}

		public void stampaRiga(DataRow r) 
		{
			foreach (DataColumn c in r.Table.Columns) 
			{
				Console.WriteLine(c.ColumnName+"= '"+r[c]+"'");
			}
		}
		#endregion

		public void letturaTabelle (
			Form form, DataGrid dataGridDatiCorretti, DataGrid dataGridGeoComune) 
		{
			bool leggi = meta.GetFormData(true);
			rImportazioneDati = (VistaGeo_Comune.geo_importazione_datiRow) HelpForm.GetLastSelected(DS.geo_importazione_dati);

			DS.dettagli.Clear();
			DS.dettagli.Rows.Add(DS.dettagli.NewRow());
			DS.dettagli.Rows.Add(DS.dettagli.NewRow());

			MetaData metaTDCDI = MetaData.GetMetaData(form, DS.geo_comuni_da_importare.TableName);

			string query =
				"select "+CLN_COMIMPORT_DENOMINAZIONE + "=i." + rImportazioneDati[CLN_IMPORT_DENOMINAZIONE]
				+ ", "+CLN_COMIMPORT_IDPROVINCIA + "=p.idprovincia"
				+ ", "+CLN_COMIMPORT_SIGLA_PROVINCIA + "=p.sigla";
			if (rImportazioneDati[CLN_IMPORT_CORREZIONE_DATAINIZIO_1960_01_01].ToString()=="S") 
			{
				query += ", datainizio=nullif(i.datainizio,'1960-01-01')";
			} 
			else 
			{
				query += nullSeDBNull(CLN_COMIMPORT_DATA_INIZIO, rImportazioneDati[CLN_IMPORT_DATA_INIZIO]);
			}
			query 
				+=nullSeDBNull(CLN_COMIMPORT_DATA_FINE, rImportazioneDati[CLN_IMPORT_DATA_FINE])
				+ nullSeDBNull(CLN_COMIMPORT_ISTAT, rImportazioneDati[CLN_IMPORT_ISTAT])
				+ nullSeDBNull(CLN_COMIMPORT_FISCO, rImportazioneDati[CLN_IMPORT_FISCO])
				+ nullSeDBNull(CLN_COMIMPORT_CATASTO, rImportazioneDati[CLN_IMPORT_CATASTO])
				+ nullSeDBNull(CLN_COMIMPORT_CAP, rImportazioneDati[CLN_IMPORT_CAP])
				+ nullSeDBNull(CLN_COMIMPORT_VALORE[0], rImportazioneDati[CLN_IMPORT_VALORE1])
				+ nullSeDBNull(CLN_COMIMPORT_VALORE[1], rImportazioneDati[CLN_IMPORT_VALORE2])
				+ " from "
				+ rImportazioneDati[CLN_IMPORT_TABELLA_SORGENTE]
				+ " i join geo_provincia p on ";

			if (!(rImportazioneDati[CLN_IMPORT_ID_PROVINCIA] is DBNull))
			{
				query += "(p.idprovincia=i."+rImportazioneDati[CLN_IMPORT_ID_PROVINCIA]+") where (p."+filtroIdProvincia+")";
			} 
			else 
			{
				if (!(rImportazioneDati[CLN_IMPORT_SIGLA_PROVINCIA] is DBNull))
				{
					object clnSiglaProv = rImportazioneDati[CLN_IMPORT_SIGLA_PROVINCIA];

					if (rImportazioneDati[CLN_IMPORT_CORREZIONE_FOFC_PSPU].ToString()=="S") 
					{
						query += "(p.sigla=case i."+clnSiglaProv+" when 'FO' then 'FC' when 'PS' then 'PU' else i."+clnSiglaProv+" end) where (p."+filtroIdProvincia+")";
					} 
					else 
					{
						query += "(p.sigla=i."+clnSiglaProv+") where (p."+filtroIdProvincia+")";
					}
				}
			}

			DataTable tabellaDaImportare = meta.Conn.SQLRunner(query);

			DS.geo_comuni_da_importare.Clear();
			foreach (DataRow rigaSorg in tabellaDaImportare.Rows) 
			{
				DataRow riga = metaTDCDI.Get_New_Row(null, DS.geo_comuni_da_importare);
				foreach (DataColumn col in tabellaDaImportare.Columns) 
				{
					if (col.ColumnName!=CLN_COMIMPORT_IDCOMUNE) 
					{
						riga[col.ColumnName] = rigaSorg[col.ColumnName];
					}
				}
			}
			Console.WriteLine(query);
			Console.WriteLine("Ho letto "+DS.geo_comuni_da_importare.Rows.Count+" righe da geo_comuni_da_importare");
			associaGridConTable(dataGridDatiCorretti, DS.geo_comuni_da_importare);

			string filtroGeoComune = "("+filtroIdProvincia+") and ((datafine is null) or (datafine!="+QueryCreator.quotedstrvalue(COMUNE_CANCELLATO,true)+"))";

			DS.geo_comune.Clear();
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn,
				DS.geo_comune,
				null, 
				filtroGeoComune, 
				null, true
			);

			Console.WriteLine("select * from geo_comune where "+filtroGeoComune);
			Console.WriteLine("Ho letto "+DS.geo_comune.Rows.Count+" righe da geo_comune");
			associaGridConTable(dataGridGeoComune, DS.geo_comune);

			string filtroGeoComuneEnte = 
				"(idente="+QueryCreator.quotedstrvalue(rImportazioneDati[CLN_IMPORT_ID_ENTE], true)
				+") and (idcomune in (select c.idcomune from geo_comune c join geo_provincia p on c.idprovincia=p.idprovincia where p."+filtroIdProvincia
				+" and ((datafine is null) or (datafine!="+QueryCreator.quotedstrvalue(COMUNE_CANCELLATO,true)+")))";
			
			DS.geo_comune_ente.Clear();
			DataAccess.RUN_SELECT_INTO_TABLE(
				meta.Conn,
				DS.geo_comune_ente, 
				null, 
				filtroGeoComuneEnte,
				null, true
			);

			Console.WriteLine("select * from geo_comune_ente where "+filtroGeoComuneEnte);
			Console.WriteLine("Ho letto "+DS.geo_comune_ente.Rows.Count+" righe da geo_comune_ente");
			associaGridConTable(dataGridGeoComune, DS.geo_comune);
		}

		private DataColumn[] getCampiNonChiave(DataTable tabella) 
		{
			DataColumn[] campiNonChiave = new DataColumn[tabella.Columns.Count - tabella.PrimaryKey.Length];
			int i = 0;
			foreach (DataColumn c in tabella.Columns) 
			{
				if (Array.IndexOf(tabella.PrimaryKey, c) == -1)
					campiNonChiave[i++] = c;
			}
			return campiNonChiave;
		}

		private void aggiornaGeoComuneEnte (
			int idCodice,
			VistaGeo_Comune.geo_comuneRow rGeoComune,
			VistaGeo_Comune.geo_comuni_da_importareRow rComuneDaImportare,
			MetaData metaGCE,
			MetaData metaAgg
		) 
		{
			DataRow[] righeDiGCE = DS.geo_comune_ente.Select("idcomune="+rGeoComune.idcomune+" and idcodice="+idCodice);
			MetaData.SetDefault(DS.geo_comune_ente, "idcodice", idCodice);
			DataRow rGCE = (righeDiGCE.Length!=0) ? righeDiGCE[0] : metaGCE.Get_New_Row(rGeoComune, DS.geo_comune_ente);
			
			DataColumn[] campiNonChiave = getCampiNonChiave(DS.geo_comune_ente);

			rGCE["datainizio"] = rComuneDaImportare[CLN_COMIMPORT_DATA_INIZIO];
			rGCE["datafine"] = rComuneDaImportare[CLN_COMIMPORT_DATA_FINE];
			rGCE["valore"] = rComuneDaImportare[CLN_COMIMPORT_VALORE[idCodice-1]];

			if ((rGCE.RowState==DataRowState.Added) || ! PostData.CheckForFalseUpdate(rGCE))
			{
				char tipoOperazione = (righeDiGCE.Length!=0) ? LOG_MODIFICA : LOG_INSERIMENTO;
				logModificaRigaDiGeoComuneEnte(tipoOperazione, metaAgg, (VistaGeo_Comune.geo_comune_enteRow) rGCE, rComuneDaImportare.nome, rGeoComune.denominazione);
			}
		}

		public void aggiungiLeCoppieEISingle1AlDB(Form form, DataGrid gridAggiornamento) 
		{
			DS.geo_aggiornamento.Clear();
			DS.geo_comune.RejectChanges();
			DS.geo_comune_ente.RejectChanges();

			MetaData metaAgg = MetaData.GetMetaData(form, "geo_aggiornamento");
			MetaData metaGC = MetaData.GetMetaData(form, "geo_comune");
			MetaData metaGCE = MetaData.GetMetaData(form, "geo_comune_ente");

			DataColumn[] campiNonChiaveGeoComune = getCampiNonChiave(DS.geo_comune);

			MetaData.SetDefault(DS.geo_comune_ente, "idente", rImportazioneDati[CLN_IMPORT_ID_ENTE]);

			foreach (VistaGeo_Comune.tutti_i_single1Row rSingle1 in DS.tutti_i_single1.Rows) 
			{
				DataRow[] rComuniDaImportare =
					DS.geo_comuni_da_importare.Select(CLN_COMIMPORT_IDCOMUNE+"="+rSingle1.idcomune);
				VistaGeo_Comune.geo_comuni_da_importareRow rComuneDaImportare = (VistaGeo_Comune.geo_comuni_da_importareRow) rComuniDaImportare[0];
				VistaGeo_Comune.geo_comuneRow rNuovoGeoComune = (VistaGeo_Comune.geo_comuneRow) 
					metaGC.Get_New_Row(null, DS.geo_comune);
				rNuovoGeoComune[CLN_GEO_DENOMINAZIONE] = rSingle1.nome;
				rNuovoGeoComune[CLN_GEO_DATA_INIZIO] = rComuneDaImportare[CLN_COMIMPORT_DATA_INIZIO];
				rNuovoGeoComune[CLN_GEO_DATA_FINE] = rComuneDaImportare[CLN_COMIMPORT_DATA_FINE];
				rNuovoGeoComune[CLN_GEO_IDPROVINCIA] = rSingle1.idprovincia;

				DataRow rNuovoAggiornamento = metaAgg.Get_New_Row(null, DS.geo_aggiornamento);
				rNuovoAggiornamento["data"] = System.DateTime.Now;
				rNuovoAggiornamento["tabella_originale"] = rImportazioneDati[CLN_IMPORT_TABELLA_SORGENTE];
				rNuovoAggiornamento["tabella_geo"] = DS.geo_comune.TableName;
				rNuovoAggiornamento["tipo"] = LOG_INSERIMENTO;
				rNuovoAggiornamento["comune_importato"] = rSingle1.nome;
				rNuovoAggiornamento["chiave"] = QueryCreator.WHERE_REL_CLAUSE(rNuovoGeoComune, DS.geo_comune.PrimaryKey, 
					DS.geo_comune.PrimaryKey, DataRowVersion.Default, false);
				rNuovoAggiornamento["nuovo_valore"] = QueryCreator.WHERE_REL_CLAUSE(rNuovoGeoComune, campiNonChiaveGeoComune, 
					campiNonChiaveGeoComune, DataRowVersion.Default, false);
				aggiornaGeoComuneEnte(1, rNuovoGeoComune, rComuneDaImportare, metaGCE, metaAgg);
				if (!(rComuneDaImportare["valore2"] is DBNull)) 
				{
					aggiornaGeoComuneEnte(2, rNuovoGeoComune, rComuneDaImportare, metaGCE, metaAgg);
				}
            }

			foreach (VistaGeo_Comune.tutte_le_coppieRow rCoppia in DS.tutte_le_coppie.Rows) 
			{
				DataRow[] rComuniDaImportare = 
					DS.geo_comuni_da_importare.Select(CLN_COMIMPORT_IDCOMUNE+"="+rCoppia.idcomune1);
				VistaGeo_Comune.geo_comuni_da_importareRow rComuneDaImportare = (VistaGeo_Comune.geo_comuni_da_importareRow) rComuniDaImportare[0];
				DataRow[] rGeoComuni = DS.geo_comune.Select(CLN_GEO_IDCOMUNE+"="+rCoppia.idcomune2);
				VistaGeo_Comune.geo_comuneRow rGeoComune = (VistaGeo_Comune.geo_comuneRow) rGeoComuni[0];
				aggiornaGeoComuneEnte(1, rGeoComune, rComuneDaImportare, metaGCE, metaAgg);
				if (!(rComuneDaImportare["valore2"] is DBNull)) 
				{
					aggiornaGeoComuneEnte(2, rGeoComune, rComuneDaImportare, metaGCE, metaAgg);
				}
			}

			DataColumn[] campiNonChiaveGeoComuneEnte = getCampiNonChiave(DS.geo_comune_ente);

			foreach (VistaGeo_Comune.geo_comune_enteRow rGCE in DS.geo_comune_ente.Rows) 
			{
				if (rGCE.RowState == DataRowState.Unchanged) 
				{
					VistaGeo_Comune.geo_comuneRow rGeoComune = (VistaGeo_Comune.geo_comuneRow)
						rGCE.GetParentRow("geo_comunegeo_comune_ente");
					rGCE.datafine = COMUNE_CANCELLATO;
					logModificaRigaDiGeoComuneEnte(LOG_CANCELLAZIONE, metaAgg, rGCE, null, rGeoComune.denominazione);
					int count = meta.Conn.RUN_SELECT_COUNT("geo_comune_ente", "idcomune="+rGeoComune.idcomune, true);
					if (count==1) 
					{
						rGeoComune.datafine = COMUNE_CANCELLATO;
						logModificaRigaDiGeoComune(LOG_CANCELLAZIONE, metaAgg, rGeoComune);
					}
				}
			}

			associaGridConTable(gridAggiornamento, DS.geo_aggiornamento);
		}


		private void logModificaRigaDiGeoComune (
			char tipoOperazione,
			MetaData metaAgg,
			VistaGeo_Comune.geo_comuneRow rGeoComune
		) 
		{
			DataColumn[] campiNonChiaveGeoComune = getCampiNonChiave(DS.geo_comune);

			DataRow rNuovoAggiornamento = metaAgg.Get_New_Row(null, DS.geo_aggiornamento);
			rNuovoAggiornamento["data"] = System.DateTime.Now;
			rNuovoAggiornamento["tabella_originale"] = rImportazioneDati[CLN_IMPORT_TABELLA_SORGENTE];
			rNuovoAggiornamento["tabella_geo"] = DS.geo_comune.TableName;
			rNuovoAggiornamento["tipo"] = tipoOperazione;
			rNuovoAggiornamento["geo_comune"] = rGeoComune.denominazione;
			rNuovoAggiornamento["chiave"] = QueryCreator.WHERE_REL_CLAUSE(rGeoComune, DS.geo_comune.PrimaryKey, 
				DS.geo_comune.PrimaryKey, DataRowVersion.Default, false);
			rNuovoAggiornamento["vecchio_valore"] = QueryCreator.WHERE_REL_CLAUSE(rGeoComune, campiNonChiaveGeoComune, 
				campiNonChiaveGeoComune, DataRowVersion.Current, false);
		}

		private void logModificaRigaDiGeoComuneEnte (
			char tipoOperazione,
			MetaData metaAgg,
			VistaGeo_Comune.geo_comune_enteRow rGCE,
			string nomeComuneDaImportare,
			string nomeGeoComune
		) 
		{
			DataColumn[] campiNonChiaveGeoComuneEnte = getCampiNonChiave(DS.geo_comune_ente);
			DataRow rNuovoAggiornamento = metaAgg.Get_New_Row(null, DS.geo_aggiornamento);
			rNuovoAggiornamento["data"] = System.DateTime.Now;
			rNuovoAggiornamento["tabella_originale"] = rImportazioneDati[CLN_IMPORT_TABELLA_SORGENTE];
			rNuovoAggiornamento["tabella_geo"] = DS.geo_comune_ente.TableName;
			rNuovoAggiornamento["tipo"] = tipoOperazione;
			rNuovoAggiornamento["comune_importato"] = nomeComuneDaImportare;
			rNuovoAggiornamento["geo_comune"] = nomeGeoComune;
			rNuovoAggiornamento["chiave"] = QueryCreator.WHERE_REL_CLAUSE(rGCE, DS.geo_comune_ente.PrimaryKey, 
				DS.geo_comune_ente.PrimaryKey, DataRowVersion.Default, false);
			if (rGCE.RowState==DataRowState.Modified) 
			{
				rNuovoAggiornamento["vecchio_valore"] = QueryCreator.WHERE_REL_CLAUSE(rGCE, campiNonChiaveGeoComuneEnte, 
					campiNonChiaveGeoComuneEnte, DataRowVersion.Original, false);
			}
			rNuovoAggiornamento["nuovo_valore"] = QueryCreator.WHERE_REL_CLAUSE(rGCE, campiNonChiaveGeoComuneEnte, 
				campiNonChiaveGeoComuneEnte, DataRowVersion.Current, false);
		}

		public bool isComuneDaImportareNuovo(geo_comuni_da_importareRow rComuneDaCercare) 
		{
			return rComuneDaCercare[CLN_COMIMPORT_DATA_FINE] is DBNull;
		}

		public bool isGeoComuneNuovo(VistaGeo_Comune.geo_comuneRow rGeoComune) 
		{
			if (rGeoComune[CLN_GEO_DATA_FINE]!=DBNull.Value) 
				return false;
			DataRow[] rSuccessori = DS.geo_comune.Select(CLN_GEO_VECCHIO_COMUNE+"="+rGeoComune[CLN_GEO_IDCOMUNE]);
			return (rGeoComune[CLN_GEO_NUOVO_COMUNE] is DBNull) && (rSuccessori.Length==0);
		}

		public void setProvinceSelezionate(string idProvinceSelezionate) 
		{
			filtroIdProvincia = "idProvincia in ("+idProvinceSelezionate+")";
		}

		public void ricavaInfoDalComuneDaImportare (
			int idComune,
			out DateTime dataInizio,
			out DateTime dataFine,
			out string valore1,
			out string valore2
			) 
		{
			VistaGeo_Comune.geo_comuni_da_importareRow rComuneDaImportare = (VistaGeo_Comune.geo_comuni_da_importareRow)
				DS.geo_comuni_da_importare.Select(CLN_COMIMPORT_IDCOMUNE+"="+idComune)[0];
			dataInizio = Tabelle.leggiData(rComuneDaImportare[CLN_COMIMPORT_DATA_INIZIO]);
			dataFine = Tabelle.leggiData(rComuneDaImportare[CLN_COMIMPORT_DATA_FINE]);
			valore1 = rComuneDaImportare[CLN_COMIMPORT_VALORE[0]].ToString();
			object oValore2 = rComuneDaImportare[CLN_COMIMPORT_VALORE[1]];
			valore2 = (oValore2 is DBNull) ? null : (string) oValore2;
		}

		public bool confrontaConValoriGiaSulDB (
			DateTime dataInizioDaImportare,
			DateTime dataFineDaImportare,
			string valore1DaImportare,
			string valore2DaImportare,
			int idComune
			) 
		{
			
			VistaGeo_Comune.geo_comune_enteRow[] rGeoComuneEnte = (VistaGeo_Comune.geo_comune_enteRow[])
				DS.geo_comune_ente.Select (
					"idcomune="+idComune
					+ " and idente="+rImportazioneDati.idente
				);
			if (rGeoComuneEnte.Length==0) return false;
//			if (rGeoComuneEnte[0]["datainizio"]==dataInizio) return 1;

			DateTime dataFine1SulDB = leggiData(rGeoComuneEnte[0]["datafine"]);
			if (dataFineDaImportare != dataFine1SulDB) return false;

			string valore1SulDB = (string) rGeoComuneEnte[0]["valore"];
			if (valore1DaImportare != valore1SulDB) return false;

			if (rGeoComuneEnte.Length>=2) 
			{
				DateTime dataFine2SulDB = leggiData(rGeoComuneEnte[1]["datafine"]);
				if (dataFineDaImportare != dataFine2SulDB) return false;

				string valore2SulDB = (string) rGeoComuneEnte[1]["valore"];
				if (valore2DaImportare != valore2SulDB) return false;
			}



			return true;
		}

		public void setImportazioneDati(geo_importazione_datiRow rImport) 
		{
			rImportazioneDati = rImport;
		}

		public static DateTime leggiData(object dbValue) 
		{
			if (dbValue is DBNull) return Convert.ToDateTime(null);
			return (DateTime) dbValue;
		}

	}
}
