(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tirociniocandidaturakinddefaultview() {
        MetaData.apply(this, ["tirociniocandidaturakinddefaultview"]);
        this.name = 'meta_tirociniocandidaturakinddefaultview';
    }

    meta_tirociniocandidaturakinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tirociniocandidaturakinddefaultview,
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
						this.describeAColumn(table, 'tirociniocandidaturakind_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'tirociniocandidaturakind_sortcode', 'Sortcode', null, 40, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idtirociniocandidaturakind"];
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

    window.appMeta.addMeta('tirociniocandidaturakinddefaultview', new meta_tirociniocandidaturakinddefaultview('tirociniocandidaturakinddefaultview'));

	}());
