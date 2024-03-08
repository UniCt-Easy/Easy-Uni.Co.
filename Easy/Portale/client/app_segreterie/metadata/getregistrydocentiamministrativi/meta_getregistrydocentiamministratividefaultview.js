(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_getregistrydocentiamministratividefaultview() {
        MetaData.apply(this, ["getregistrydocentiamministratividefaultview"]);
        this.name = 'meta_getregistrydocentiamministratividefaultview';
    }

    meta_getregistrydocentiamministratividefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getregistrydocentiamministratividefaultview,
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
						this.describeAColumn(table, 'surname', 'Cognome', null, 1000, 50);
						this.describeAColumn(table, 'getregistrydocentiamministrativi_forename', 'Nome', null, 2000, 50);
						this.describeAColumn(table, 'getregistrydocentiamministrativi_extmatricula', 'Matricola', null, 3000, 40);
						this.describeAColumn(table, 'getregistrydocentiamministrativi_cf', 'CF', null, 4000, 16);
						this.describeAColumn(table, 'getregistrydocentiamministrativi_contratto', 'Contratto', null, 5000, 50);
						this.describeAColumn(table, 'getregistrydocentiamministrativi_ssd', 'SSD', null, 6000, 50);
						this.describeAColumn(table, 'getregistrydocentiamministrativi_struttura', 'Struttura', null, 7000, 1024);
						this.describeAColumn(table, 'getregistrydocentiamministrativi_istituto', 'Istituto', null, 8000, 101);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "surname ASC , getregistrydocentiamministrativi_forename ASC ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('getregistrydocentiamministratividefaultview', new meta_getregistrydocentiamministratividefaultview('getregistrydocentiamministratividefaultview'));

	}());
