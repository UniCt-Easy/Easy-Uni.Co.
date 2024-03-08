
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


using System;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using System.IO;
using CrystalDecisions.Windows.Forms;

namespace resultparameter_default//Report//
{
	/// <summary>
	/// Summary description for FrmViewReport.
	/// </summary>
    public class FrmViewReport : MetaDataForm {
        public  CrystalDecisions.Windows.Forms.CrystalReportViewer crViewer;
        private System.ComponentModel.IContainer components;

		private DataRow Params;
        Easy_DataAccess Conn;
        public ToolBar toolBar;
		private System.Windows.Forms.ToolBarButton tbFirstPage;
		private System.Windows.Forms.ToolBarButton tbPrevPage;
		private System.Windows.Forms.ToolBarButton tbNextPage;
		private System.Windows.Forms.ToolBarButton tbLastPage;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton tbPrint;
		private System.Windows.Forms.ToolBarButton tbZoom;
		private System.Windows.Forms.ToolBarButton tbTree;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenu mnuZoom;
		private System.Windows.Forms.MenuItem mnu2;
		private System.Windows.Forms.MenuItem mnu1;
		private System.Windows.Forms.MenuItem mnu400;
		private System.Windows.Forms.MenuItem mnu300;
		private System.Windows.Forms.MenuItem mnu200;
		private System.Windows.Forms.MenuItem mnu100;
		private System.Windows.Forms.MenuItem mnu75;
		private System.Windows.Forms.MenuItem mnu50;
		private System.Windows.Forms.MenuItem mnu25;
		private System.Windows.Forms.ToolBarButton tbExport;
		DataRow ModuleReport;
		int ReportPages;
        public bool oneprint=false;
        public bool printed = false;
        public bool denyprint = false;
	    public bool errore = false;

	    private MetaData meta;

	    private string elencoparametri = "";

        public FrmViewReport(DataRow DRModuleReport, 
			Easy_DataAccess MyDA,
			DataRow Params,
            MetaData meta) {
			InitializeComponent();
            toolBar.Enabled = false;
			this.Params = Params;
			this.ModuleReport = DRModuleReport;
			Conn = MyDA;
            this.meta = meta;

            foreach (DataColumn c in Params.Table.Columns) {
                elencoparametri += c.ColumnName + "=" + Params[c.ColumnName].ToString() + ";";
            }

            Text = ModuleReport["description"].ToString();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewReport));
            this.crViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.tbFirstPage = new System.Windows.Forms.ToolBarButton();
            this.tbPrevPage = new System.Windows.Forms.ToolBarButton();
            this.tbNextPage = new System.Windows.Forms.ToolBarButton();
            this.tbLastPage = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tbPrint = new System.Windows.Forms.ToolBarButton();
            this.tbZoom = new System.Windows.Forms.ToolBarButton();
            this.mnuZoom = new System.Windows.Forms.ContextMenu();
            this.mnu2 = new System.Windows.Forms.MenuItem();
            this.mnu1 = new System.Windows.Forms.MenuItem();
            this.mnu400 = new System.Windows.Forms.MenuItem();
            this.mnu300 = new System.Windows.Forms.MenuItem();
            this.mnu200 = new System.Windows.Forms.MenuItem();
            this.mnu100 = new System.Windows.Forms.MenuItem();
            this.mnu75 = new System.Windows.Forms.MenuItem();
            this.mnu50 = new System.Windows.Forms.MenuItem();
            this.mnu25 = new System.Windows.Forms.MenuItem();
            this.tbTree = new System.Windows.Forms.ToolBarButton();
            this.tbExport = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // crViewer
            // 
            this.crViewer.ActiveViewIndex = -1;
            this.crViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crViewer.DisplayToolbar = false;
            this.crViewer.EnableDrillDown = false;
            this.crViewer.Location = new System.Drawing.Point(0, 30);
            this.crViewer.Name = "crViewer";
            this.crViewer.ShowCloseButton = false;
            this.crViewer.ShowGotoPageButton = false;
            this.crViewer.ShowRefreshButton = false;
            this.crViewer.ShowTextSearchButton = false;
            this.crViewer.Size = new System.Drawing.Size(742, 410);
            this.crViewer.TabIndex = 0;
            this.crViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // toolBar
            // 
            this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbFirstPage,
            this.tbPrevPage,
            this.tbNextPage,
            this.tbLastPage,
            this.toolBarButton1,
            this.tbPrint,
            this.tbZoom,
            this.tbTree,
            this.tbExport});
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.imageList1;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(742, 28);
            this.toolBar.TabIndex = 1;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // tbFirstPage
            // 
            this.tbFirstPage.ImageIndex = 6;
            this.tbFirstPage.Name = "tbFirstPage";
            this.tbFirstPage.Tag = "first";
            this.tbFirstPage.ToolTipText = "Prima pagina";
            // 
            // tbPrevPage
            // 
            this.tbPrevPage.ImageIndex = 0;
            this.tbPrevPage.Name = "tbPrevPage";
            this.tbPrevPage.Tag = "prev";
            this.tbPrevPage.ToolTipText = "Pagina precedente";
            // 
            // tbNextPage
            // 
            this.tbNextPage.ImageIndex = 1;
            this.tbNextPage.Name = "tbNextPage";
            this.tbNextPage.Tag = "next";
            this.tbNextPage.ToolTipText = "Pagina successiva";
            // 
            // tbLastPage
            // 
            this.tbLastPage.ImageIndex = 7;
            this.tbLastPage.Name = "tbLastPage";
            this.tbLastPage.Tag = "last";
            this.tbLastPage.ToolTipText = "Ultima pagina";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbPrint
            // 
            this.tbPrint.ImageIndex = 2;
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.Tag = "print";
            this.tbPrint.ToolTipText = "Stampa";
            // 
            // tbZoom
            // 
            this.tbZoom.DropDownMenu = this.mnuZoom;
            this.tbZoom.ImageIndex = 3;
            this.tbZoom.Name = "tbZoom";
            this.tbZoom.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.tbZoom.Tag = "zoom";
            this.tbZoom.ToolTipText = "Zoom";
            // 
            // mnuZoom
            // 
            this.mnuZoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnu2,
            this.mnu1,
            this.mnu400,
            this.mnu300,
            this.mnu200,
            this.mnu100,
            this.mnu75,
            this.mnu50,
            this.mnu25});
            // 
            // mnu2
            // 
            this.mnu2.Index = 0;
            this.mnu2.Text = "Adatta alla finestra";
            this.mnu2.Click += new System.EventHandler(this.mnu2_Click);
            // 
            // mnu1
            // 
            this.mnu1.Index = 1;
            this.mnu1.Text = "Pagina intera";
            this.mnu1.Click += new System.EventHandler(this.mnu1_Click);
            // 
            // mnu400
            // 
            this.mnu400.Index = 2;
            this.mnu400.Text = "400%";
            this.mnu400.Click += new System.EventHandler(this.mnu400_Click);
            // 
            // mnu300
            // 
            this.mnu300.Index = 3;
            this.mnu300.Text = "300%";
            this.mnu300.Click += new System.EventHandler(this.mnu300_Click);
            // 
            // mnu200
            // 
            this.mnu200.Index = 4;
            this.mnu200.Text = "200%";
            this.mnu200.Click += new System.EventHandler(this.mnu200_Click);
            // 
            // mnu100
            // 
            this.mnu100.Index = 5;
            this.mnu100.Text = "100%";
            this.mnu100.Click += new System.EventHandler(this.mnu100_Click);
            // 
            // mnu75
            // 
            this.mnu75.Index = 6;
            this.mnu75.Text = "75%";
            this.mnu75.Click += new System.EventHandler(this.mnu75_Click);
            // 
            // mnu50
            // 
            this.mnu50.Index = 7;
            this.mnu50.Text = "50%";
            this.mnu50.Click += new System.EventHandler(this.mnu50_Click);
            // 
            // mnu25
            // 
            this.mnu25.Index = 8;
            this.mnu25.Text = "25%";
            this.mnu25.Click += new System.EventHandler(this.mnu25_Click);
            // 
            // tbTree
            // 
            this.tbTree.ImageIndex = 8;
            this.tbTree.Name = "tbTree";
            this.tbTree.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbTree.Tag = "tree";
            this.tbTree.ToolTipText = "Mostra treeview";
            // 
            // tbExport
            // 
            this.tbExport.ImageIndex = 5;
            this.tbExport.Name = "tbExport";
            this.tbExport.Tag = "export";
            this.tbExport.ToolTipText = "Esporta";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            // 
            // FrmViewReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 437);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.crViewer);
            this.Name = "FrmViewReport";
            this.Text = "FrmViewReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmViewReport_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmViewReport_FormClosed);
            this.Load += new System.EventHandler(this.FrmViewReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		public static string GetA3PrinterName(){
			int NSupported=0;				
			string selectedprinter=null;
			PrintDocument pdoc=new PrintDocument();
            try {
                foreach (string printername in PrinterSettings.InstalledPrinters) {
                    //controlla la stampante
                    pdoc.PrinterSettings.PrinterName = printername;
                    if ((pdoc.PrinterSettings != null) && (pdoc.PrinterSettings.PaperSizes != null)) {
                        foreach (System.Drawing.Printing.PaperSize PS in pdoc.PrinterSettings.PaperSizes) {
                            if (PS.PaperName.ToString() == "A3") {
                                NSupported++;
                                if (selectedprinter == null) selectedprinter = pdoc.PrinterSettings.PrinterName;
                                if (pdoc.PrinterSettings.IsDefaultPrinter) selectedprinter = pdoc.PrinterSettings.PrinterName;
                            }
                        }
                    }
                }
            }
            catch {  //System.ComponentModel.Win32Exception (0x80004005): Server RPC non disponibile
                return null;
            }
			return selectedprinter;
		}
                                
		ReportDocument ReportDoc;
        System.Drawing.Printing.PaperSize findSuitablePaperSize(System.Drawing.Printing.PaperSize model,
            PaperKind modelPaper,
            PrinterSettings.PaperSizeCollection paperSizes) {
            if (paperSizes.Count == 1) {
                return paperSizes[0];
            }

            foreach (System.Drawing.Printing.PaperSize papSize in paperSizes) {               
                if (papSize.Kind != modelPaper) continue;
                //if (papSize.Width < model.Width) continue;
                //if (papSize.Height < model.Height) continue;
                return papSize;
            }
            return null;

        }

        void setPrintDocument(PrinterSettings PrnSet,  PageSettings PageSet) {
            bool Landscape = (ModuleReport["orientation"].ToString().ToUpper() == "P");
            PrnSet.DefaultPageSettings.Landscape = Landscape;
            PageSet.Landscape = Landscape;
            string papersize = ModuleReport["papersize"].ToString();
            if (papersize == "") papersize = "A4";            
            if (papersize.ToUpper() == "A3") {
                System.Drawing.Printing.PaperSize A3pSize = findSuitablePaperSize(
                   GetSystemSize(CrystalDecisions.Shared.PaperSize.PaperA3), PaperKind.A3, PrnSet.PaperSizes);
                if (A3pSize != null) {
                    PrnSet.DefaultPageSettings.PaperSize = A3pSize;
                    PageSet.PaperSize = A3pSize;
                }
            }
            if (papersize.ToUpper() == "A4") {
                System.Drawing.Printing.PaperSize A4pSize = findSuitablePaperSize(
                   GetSystemSize(CrystalDecisions.Shared.PaperSize.PaperA4), PaperKind.A4, PrnSet.PaperSizes);
                if (A4pSize != null) {
                    PrnSet.DefaultPageSettings.PaperSize = A4pSize;
                    PageSet.PaperSize = A4pSize;
                }
            }
        }

        string printerName;

        string getPrinterNameFor(string paperSize) {
            string choosen = null;
            try {
                foreach (string prn in PrinterSettings.InstalledPrinters) {
                    PrintDocument pdoc = new PrintDocument();
                    pdoc.PrinterSettings.PrinterName = prn;
                    foreach (System.Drawing.Printing.PaperSize PS in pdoc.PrinterSettings.PaperSizes) {
                        if (PS.PaperName.ToString() == paperSize) {
                            if (choosen == null) choosen = prn;
                            if (pdoc.PrinterSettings.IsDefaultPrinter) return prn;
                        }
                    }
                }
            }
            catch {
                //System.ComponentModel.Win32Exception (0x80004005): Server RPC non disponibile
            }
            return choosen;
        }


		public bool ShowReport() {
			string errmess;

			
            //pdoc.DefaultPageSettings.PaperSize = GetSystemSize(ReportDoc.PrintOptions.PaperSize);
            //pdoc.DefaultPageSettings.Landscape = (ModuleReport["orientation"].ToString().ToUpper() == "P");

            string papersize = ModuleReport["papersize"].ToString();

            if (papersize.ToUpper() == "ASK") {                
                frmSelectPrinter frm = new resultparameter_default.frmSelectPrinter(papersize);
                if (frm.ShowDialog(this) != DialogResult.OK) return false;
                printerName = frm.cmbPrn.Text;
            }         
            else {
                printerName = getPrinterNameFor(papersize);
            }

            
            
		    if (printerName == null) return false;

            ReportDoc = Easy_DataAccess.GetReport(Conn,ModuleReport,Params, out errmess);
			if (ReportDoc==null) {
				show(errmess,"Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errore = true;
				return false;			
			}

            try {
                ReportDoc.PrintOptions.PrinterName = printerName; //PDIAL.PrinterSettings.PrinterName;
            }
            catch {
                errore = true;
                show("La stampante di nome " + printerName + " non appare essere correttamente installata.", "Errore");
                return false;
            }

            
			ReportDispatcherClass.SetDefaultOrientation(ref ReportDoc, ModuleReport);

			//formato dal report al printer dialog 

            //eseguo bind del report
            crViewer.ReportSource = ReportDoc; //ReportDoc;
			
			Cursor.Current = Cursors.Default;

            toolBar.Enabled = true;
            return true;
		}
		
			
		//Size: from Crystal to .Net
		private System.Drawing.Printing.PaperSize GetSystemSize(
			CrystalDecisions.Shared.PaperSize Formato) {
			switch(Formato) {
                case CrystalDecisions.Shared.PaperSize.PaperA3:
                    return new System.Drawing.Printing.PaperSize("Easy A3", 1175, 1650);
                case CrystalDecisions.Shared.PaperSize.PaperA4:
                    return new System.Drawing.Printing.PaperSize("Easy A4", 825, 1175);
                default:
                    return new System.Drawing.Printing.PaperSize("Easy A4", 825, 1175);
            }
        }


        /// <summary>
        /// Manda in stampa il documento
        /// </summary>
        /// <param name="ShowPrintDialog">True vuol dire che sono in anteprima, ricompare
        /// il PrintDialog</param>
        public bool StampaReport() {
            if (errore) return false;
            if (printerName == null) return false;
            if (ReportDoc == null) return false;
            if (oneprint && printed) {
                show("Una sola copia della stampa è ammessa.");
                return false;
            }
            //se in anteprima mostro il printDialog con tutte le proprietà impostate
            //in precedenza

            PrintDialog pd = new PrintDialog();

            pd.PrinterSettings = new PrinterSettings();
            pd.PrinterSettings.PrinterName = printerName;


            string papersize = ModuleReport["papersize"].ToString();

            

                //pd.Document = pdoc;
                //pd.PrinterSettings = pdoc.PrinterSettings;

                ReportPages = 1;
            ReportPageRequestContext oPageContext = new ReportPageRequestContext();
            operating = true;

            try {
                ReportPages = ReportDoc.FormatEngine.GetLastPageNumber(oPageContext);
            }
            catch (Exception E) {
                QueryCreator.ShowException("Errore nel calcolo del numero totale delle pagine", E);
                errore = true;
                operating = false;
                return false;
            }

            if (ReportPages < 1) ReportPages = 1;

            pd.AllowCurrentPage = false;
            pd.AllowSomePages = (ReportPages > 1) && (!oneprint);
            pd.AllowSelection = false;
            if (pd.AllowSomePages) { //pdoc.PrinterSettings != null && 

                pd.PrinterSettings.FromPage = 1;
                pd.PrinterSettings.ToPage = ReportPages;

            }

            pd.AllowPrintToFile = !oneprint;

            if (papersize.ToUpper() != "ASK") {
                setPrintDocument(pd.PrinterSettings, pd.PrinterSettings.DefaultPageSettings);
            }

            if (pd.ShowDialog(this) != DialogResult.OK) {
                operating = false;
                return false;
            }

            //Reimposto il formato carta
            //setPrintDocument(ref pdoc);

            //pdoc.PrinterSettings = pd.PrinterSettings;

            //pdoc.PrinterSettings.Collate = pd.PrinterSettings.Collate;
            //if (pdoc.PrinterSettings != null) {
                pd.PrinterSettings.Collate = (pd.PrinterSettings.Copies > 1) && 
                            (pd.PrinterSettings.ToPage > pd.PrinterSettings.FromPage);
            //}


            //imposto la stampante selezionata
            try {
                //ReportDoc.PrintOptions.PrinterName = pdoc.DefaultPageSettings.PrinterSettings.PrinterName;
                ReportDoc.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName;
            }
            catch (Exception E) {
                operating = false;
                QueryCreator.ShowException("La stampante selezionata (" + printerName + ") non è valida", E);
                errore = true;
                return false;
            }
                        
            //Se non sono in anteprima stampo direttamente
            try {

                
                ReportDoc.PrintToPrinter(pd.PrinterSettings, pd.PrinterSettings.DefaultPageSettings, false);
                //ReportDoc.PrintToPrinter(pdoc.PrinterSettings.Copies,
                //    (pdoc.PrinterSettings.Copies > 1) &&
                //    (pdoc.PrinterSettings.ToPage > pdoc.PrinterSettings.FromPage), //pdoc.PrinterSettings.Collate,
                //    pdoc.PrinterSettings.FromPage,
                //    pdoc.PrinterSettings.ToPage);
                printed = true;
                operating = false;
                return true;
            }
            catch (Exception E) {
                errore = true;
                operating = false;
                if (!E.ToString().Contains("OnStartPrint") && ! E.ToString().Contains("OnEndPage")) {
                    meta.LogError("Errore nella stampa\r\n" + elencoparametri, E);
                }
                QueryCreator.ShowException(
                        QueryCreator.GetPrintable(
                        "Si è verificato un errore in fase di invio dei dati alla stampante.\n" +
                        "Controllare che il server di stampa sia acceso ed accessibile dal proprio computer."), E);
                return false;
            }
        }

        private void FrmViewReport_FormClosed(object sender, FormClosedEventArgs e) {
            
            if (ReportDoc != null) {
                ReportDoc.Dispose();
                ReportDoc = null;
            }
            if (crViewer != null) {
                crViewer.ReportSource = null;
            }
            this.Params = null;
            this.ModuleReport = null;
            this.meta = null;
            this.Conn = null;
        }

        private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e) {
            if (errore) return;
			switch(e.Button.Tag.ToString().ToLower()) {
				case "first":
					crViewer.ShowFirstPage();
					break;
				case "prev":
					crViewer.ShowPreviousPage();
					break;
				case "next":
					crViewer.ShowNextPage();
					break;
				case "last":
					crViewer.ShowLastPage();
					break;
				case "print":
					StampaReport();
					break;
				case "tree":
                    if (tbTree.Pushed) {
                        crViewer.ToolPanelView = ToolPanelViewType.GroupTree;
                    }
                    else {
                        crViewer.ToolPanelView = ToolPanelViewType.None;
                    }
                    break;
				case "export":
                    if (oneprint) {
                        show("L'esportazione è vietata sulle stampe protette");
                        return;
                    }
			        try {
			            crViewer.ExportReport();
			        }
			        catch (Exception E) {
                        errore = true;
                        meta.LogError("Errore esportando una stampa " + elencoparametri, E);
			            QueryCreator.ShowException("Errore esportando la stampa", E);
			        }
			        break;
			}
		}

		//Imposta Zoom
		private void SetZoom(int level) {
		    if (errore) return;
			crViewer.Zoom(level);
		}
		//Adatta alla finestra
		private void mnu2_Click(object sender, System.EventArgs e) {
			SetZoom(1);
		}
		//Pagina intera
		private void mnu1_Click(object sender, System.EventArgs e) {
			SetZoom(2);
		}
		//400%
		private void mnu400_Click(object sender, System.EventArgs e) {
			SetZoom(400);
		}
		//300%
		private void mnu300_Click(object sender, System.EventArgs e) {
			SetZoom(300);
		}
		//200%
		private void mnu200_Click(object sender, System.EventArgs e) {
			SetZoom(200);
		}
		//100%
		private void mnu100_Click(object sender, System.EventArgs e) {
			SetZoom(100);
		}
		//75%
		private void mnu75_Click(object sender, System.EventArgs e) {
			SetZoom(75);
		}
		//50%
		private void mnu50_Click(object sender, System.EventArgs e) {
			SetZoom(50);
		}
		//25%
		private void mnu25_Click(object sender, System.EventArgs e) {
			SetZoom(25);
		}

		private void AbilitaPageNavigator(bool enable) {
			tbFirstPage.Enabled=enable;
			tbPrevPage.Enabled=enable;
			tbNextPage.Enabled=enable;
			tbLastPage.Enabled=enable;
		}

		private void FrmViewReport_Load(object sender, System.EventArgs e) {
		    try {
		        ReportPages = 0;
		        ReportPageRequestContext oPageContext = new ReportPageRequestContext();
		        ReportPages = ReportDoc.FormatEngine.GetLastPageNumber(oPageContext);
		        AbilitaPageNavigator(ReportPages > 1);
		    }
		    catch (Exception E) {
		        meta.LogError("Errore nel calcolo della stampa con i parametri:\r\n" + elencoparametri, E);
		        QueryCreator.ShowException("Errore nel calcolo della stampa", E);
		        AbilitaPageNavigator(false);
                errore = true;
		    }
            isInited = true;
        }
        private bool isInited = false;
        bool operating = false;
        private void FrmViewReport_FormClosing(object sender, FormClosingEventArgs e) {
            if (operating) {
                show("Attendere il completamento dell'operazione in corso", "Errore");
                e.Cancel = true;
                return;
            }
            if (!isInited) {
                show("Attendere il completamento dell'apertura della maschera prima di chiuderla", "Errore");
                e.Cancel = true;
                return;
            }
        }

        
    }
}
