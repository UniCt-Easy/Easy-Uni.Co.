(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_orakindsegview() {
        MetaData.apply(this, ["orakindsegview"]);
        this.name = 'meta_orakindsegview';
    }

    meta_orakindsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_orakindsegview,
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
						this.describeAColumn(table, 'orakind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'orakind_sortcode', 'Ordinamento', null, 50, null);
						this.describeAColumn(table, 'orakind_ripetizioni', 'Consente ripetizioni', null, 60, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idorakind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "orakind_sortcode asc ";
					}
					case "seg": {
						return "orakind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('orakindsegview', new meta_orakindsegview('orakindsegview'));

	}());
