(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_classescuolakinddefaultview() {
        MetaData.apply(this, ["classescuolakinddefaultview"]);
        this.name = 'meta_classescuolakinddefaultview';
    }

    meta_classescuolakinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_classescuolakinddefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 2000, 1024);
						this.describeAColumn(table, 'corsostudiokind_title', 'Tipologia di corso', null, 3200, 50);
						this.describeAColumn(table, 'corsostudiolivello_title', 'Livello del corso', null, 4200, 50);
						this.describeAColumn(table, 'eqf_level', 'Livello EQF (European Qualifications Framework)', null, 5100, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idclassescuolakind"];
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

    window.appMeta.addMeta('classescuolakinddefaultview', new meta_classescuolakinddefaultview('classescuolakinddefaultview'));

	}());
