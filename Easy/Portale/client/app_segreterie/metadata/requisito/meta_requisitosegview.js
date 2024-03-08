(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_requisitosegview() {
        MetaData.apply(this, ["requisitosegview"]);
        this.name = 'meta_requisitosegview';
    }

    meta_requisitosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_requisitosegview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, -1);
						this.describeAColumn(table, 'requisito_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'requisito_sortcode', 'Codice identificativo', null, 40, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idrequisito"];
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

			//$describeTree$
        });

    window.appMeta.addMeta('requisitosegview', new meta_requisitosegview('requisitosegview'));

	}());
