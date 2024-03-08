(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_ccnldefaultview() {
        MetaData.apply(this, ["ccnldefaultview"]);
        this.name = 'meta_ccnldefaultview';
    }

    meta_ccnldefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_ccnldefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'idccnl', 'Codice', null, 10, null);
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 150);
						this.describeAColumn(table, 'ccnl_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'ccnl_area', 'Area', null, 40, 50);
						this.describeAColumn(table, 'ccnl_decorrenza', 'Decorrenza', null, 60, null);
						this.describeAColumn(table, 'ccnl_scadec', 'Scadenza ec.', null, 70, null);
						this.describeAColumn(table, 'ccnl_scadenza', 'Scadenza', null, 80, null);
						this.describeAColumn(table, 'ccnl_sortcode', 'Sortcode', null, 90, null);
						this.describeAColumn(table, 'ccnl_stipula', 'Stipula', null, 100, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idccnl"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('ccnldefaultview', new meta_ccnldefaultview('ccnldefaultview'));

	}());
