(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiaraltrekinddefaultview() {
        MetaData.apply(this, ["dichiaraltrekinddefaultview"]);
        this.name = 'meta_dichiaraltrekinddefaultview';
    }

    meta_dichiaraltrekinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiaraltrekinddefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 256);
						this.describeAColumn(table, 'dichiaraltrekind_description', 'Descrizione', null, 30, 2048);
						this.describeAColumn(table, 'dichiaraltrekind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'dichiaraltrekind_sortcode', 'Sortcode', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddichiaraltrekind"];
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

    window.appMeta.addMeta('dichiaraltrekinddefaultview', new meta_dichiaraltrekinddefaultview('dichiaraltrekinddefaultview'));

	}());
