(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfschedastatusschedastatusview() {
        MetaData.apply(this, ["perfschedastatusschedastatusview"]);
        this.name = 'meta_perfschedastatusschedastatusview';
    }

    meta_perfschedastatusschedastatusview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfschedastatusschedastatusview,
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
					case 'schedastatus':
						this.describeAColumn(table, 'title', 'Stato', null, 20, 1024);
						this.describeAColumn(table, 'perfschedastatus_description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'perfschedastatus_active', 'Attivo', null, 40, null);
//$objCalcFieldConfig_schedastatus$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfschedastatus"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "schedastatus": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('perfschedastatusschedastatusview', new meta_perfschedastatusschedastatusview('perfschedastatusschedastatusview'));

	}());
