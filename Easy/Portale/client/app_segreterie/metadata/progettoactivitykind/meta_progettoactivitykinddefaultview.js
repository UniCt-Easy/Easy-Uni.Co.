﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettoactivitykinddefaultview() {
        MetaData.apply(this, ["progettoactivitykinddefaultview"]);
        this.name = 'meta_progettoactivitykinddefaultview';
    }

    meta_progettoactivitykinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettoactivitykinddefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 2048);
						this.describeAColumn(table, 'progettoactivitykind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'progettoactivitykind_sortcode', 'Sortcode', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprogettoactivitykind"];
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

    window.appMeta.addMeta('progettoactivitykinddefaultview', new meta_progettoactivitykinddefaultview('progettoactivitykinddefaultview'));

	}());
