(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfschedastatusdefaultview() {
        MetaData.apply(this, ["perfschedastatusdefaultview"]);
        this.name = 'meta_perfschedastatusdefaultview';
    }

    meta_perfschedastatusdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfschedastatusdefaultview,
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
						this.describeAColumn(table, 'title', 'Stato', null, 2000, 1024);
						this.describeAColumn(table, 'perfschedastatus_description', 'Descrizione', null, 3000, -1);
						this.describeAColumn(table, 'perfschedastatus_active', 'Attivo', null, 4000, null);
//$objCalcFieldConfig_default$
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
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('perfschedastatusdefaultview', new meta_perfschedastatusdefaultview('perfschedastatusdefaultview'));

	}());
