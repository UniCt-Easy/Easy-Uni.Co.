(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pcspuntiorganicoview() {
        MetaData.apply(this, ["pcspuntiorganicoview"]);
        this.name = 'meta_pcspuntiorganicoview';
    }

    meta_pcspuntiorganicoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pcspuntiorganicoview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'year', 'Anno', null, 10, null);
						this.describeAColumn(table, 'position_title', 'Qualifica/Categoria', null, 20, 50);
						this.describeAColumn(table, 'puntipiu0', 'Punti organico acquisiti ', 'fixed.2', 30, null);
						this.describeAColumn(table, 'puntimeno0', 'Punti organico persi', 'fixed.2', 40, null);
						this.describeAColumn(table, 'importo0', 'Spese di personale', 'fixed.2', 50, null);
						this.describeAColumn(table, 'importoesterno0', 'Finanziamenti esterni', 'fixed.2', 60, null);
						this.describeAColumn(table, 'importoateneo0', 'A carico Ateneo', 'fixed.2', 70, null);
						this.describeAColumn(table, 'puntipiu1', 'Punti organico acquisiti anno +1', 'fixed.2', 100, null);
						this.describeAColumn(table, 'puntimeno1', 'Punti organico acquisiti anno +1', 'fixed.2', 110, null);
						this.describeAColumn(table, 'importo1', 'Spese di personale anno +1', 'fixed.2', 120, null);
						this.describeAColumn(table, 'importoesterno1', 'Finanziamenti esterni anno +1', 'fixed.2', 130, null);
						this.describeAColumn(table, 'importoateneo1', 'A carico Ateneo anno +1', 'fixed.2', 140, null);
						this.describeAColumn(table, 'puntipiu2', 'Punti organico acquisiti anno +2', 'fixed.2', 200, null);
						this.describeAColumn(table, 'puntimeno2', 'Punti organico persi anno +2', 'fixed.2', 210, null);
						this.describeAColumn(table, 'importo2', 'Spese di personale anno +2', 'fixed.2', 220, null);
						this.describeAColumn(table, 'importoesterno2', 'Finanziamenti esterni anno +2', 'fixed.2', 230, null);
						this.describeAColumn(table, 'importoateneo2', 'A carico Ateneo anno +2', 'fixed.2', 240, null);
						this.describeAColumn(table, 'puntipiu3', 'Punti organico persi anno +3', 'fixed.2', 300, null);
						this.describeAColumn(table, 'puntimeno3', 'Punti organico persi anno +3', 'fixed.2', 310, null);
						this.describeAColumn(table, 'importo3', 'Spese di personale anno +3', 'fixed.2', 320, null);
						this.describeAColumn(table, 'importoesterno3', 'Finanziamenti esterni anno +3', 'fixed.2', 330, null);
						this.describeAColumn(table, 'importoateneo3', 'A carico Ateneo anno +3', 'fixed.2', 340, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["importo0"].caption = "Spese di personale";
						table.columns["importo1"].caption = "Spese di personale anno +1";
						table.columns["importo2"].caption = "Spese di personale anno +2";
						table.columns["importo3"].caption = "Spese di personale anno +3";
						table.columns["importoateneo0"].caption = "A carico Ateneo";
						table.columns["importoateneo1"].caption = "A carico Ateneo anno +1";
						table.columns["importoateneo2"].caption = "A carico Ateneo anno +2";
						table.columns["importoateneo3"].caption = "A carico Ateneo anno +3";
						table.columns["importoesterno0"].caption = "Finanziamenti esterni";
						table.columns["importoesterno1"].caption = "Finanziamenti esterni anno +1";
						table.columns["importoesterno2"].caption = "Finanziamenti esterni anno +2";
						table.columns["importoesterno3"].caption = "Finanziamenti esterni anno +3";
						table.columns["isdoc"].caption = "Docente";
						table.columns["position_title"].caption = "Qualifica/Categoria";
						table.columns["puntimeno0"].caption = "Punti organico persi";
						table.columns["puntimeno1"].caption = "Punti organico acquisiti anno +1";
						table.columns["puntimeno2"].caption = "Punti organico persi anno +2";
						table.columns["puntimeno3"].caption = "Punti organico persi anno +3";
						table.columns["puntipiu0"].caption = "Punti organico acquisiti ";
						table.columns["puntipiu1"].caption = "Punti organico acquisiti anno +1";
						table.columns["puntipiu2"].caption = "Punti organico acquisiti anno +2";
						table.columns["puntipiu3"].caption = "Punti organico persi anno +3";
						table.columns["year"].caption = "Anno";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			primaryKey: function () {
				return ["year", "position_title"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('pcspuntiorganicoview', new meta_pcspuntiorganicoview('pcspuntiorganicoview'));

	}());
