(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettostatusdefaultview() {
        MetaData.apply(this, ["perfprogettostatusdefaultview"]);
        this.name = 'meta_perfprogettostatusdefaultview';
    }

    meta_perfprogettostatusdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettostatusdefaultview,
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
						this.describeAColumn(table, 'title', 'Stato', null, 20, 1024);
						this.describeAColumn(table, 'perfprogettostatus_description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'perfprogettostatus_active', 'Attivo', null, 40, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfprogettostatus"];
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

    window.appMeta.addMeta('perfprogettostatusdefaultview', new meta_perfprogettostatusdefaultview('perfprogettostatusdefaultview'));

	}());
