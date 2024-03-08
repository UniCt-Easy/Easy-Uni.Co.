(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pcscessazioniview() {
        MetaData.apply(this, ["pcscessazioniview"]);
        this.name = 'meta_pcscessazioniview';
    }

    meta_pcscessazioniview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pcscessazioniview,
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
						this.describeAColumn(table, 'title', 'Dipendente', null, 10, 101);
						this.describeAColumn(table, 'data', 'Data di fine rapporto', null, 20, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["data"].caption = "Data di fine rapporto";
						table.columns["title"].caption = "Dipendente";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			primaryKey: function () {
				return ["idpcscessazioniview"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('pcscessazioniview', new meta_pcscessazioniview('pcscessazioniview'));

	}());
