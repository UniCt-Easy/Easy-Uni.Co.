(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tesikindsegview() {
        MetaData.apply(this, ["tesikindsegview"]);
        this.name = 'meta_tesikindsegview';
    }

    meta_tesikindsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tesikindsegview,
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
					case 'seg':
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'tesikind_description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'tesikind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'tesikind_sortcode', 'Sortcode', null, 50, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idtesikind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tesikindsegview', new meta_tesikindsegview('tesikindsegview'));

	}());
