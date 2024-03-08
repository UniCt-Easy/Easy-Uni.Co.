(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_affidamentokinddefaultview() {
        MetaData.apply(this, ["affidamentokinddefaultview"]);
        this.name = 'meta_affidamentokinddefaultview';
    }

    meta_affidamentokinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_affidamentokinddefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'affidamentokind_description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'affidamentokind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'affidamentokind_sortcode', 'Ordinamento', null, 50, null);
						this.describeAColumn(table, 'affidamentokind_costoora', 'Costo orario', 'fixed.2', 100, null);
						this.describeAColumn(table, 'affidamentokind_costoorariodacontratto', 'Costo orario da ruolo', null, 110, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idaffidamentokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					case "default": {
						return "title asc , affidamentokind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('affidamentokinddefaultview', new meta_affidamentokinddefaultview('affidamentokinddefaultview'));

	}());
