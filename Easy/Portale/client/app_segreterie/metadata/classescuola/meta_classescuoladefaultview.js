(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_classescuoladefaultview() {
        MetaData.apply(this, ["classescuoladefaultview"]);
        this.name = 'meta_classescuoladefaultview';
    }

    meta_classescuoladefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_classescuoladefaultview,
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
						this.describeAColumn(table, 'sigla', 'Sigla', null, 10, 50);
						this.describeAColumn(table, 'classescuola_title', 'Denominazione', null, 20, 256);
						this.describeAColumn(table, 'corsostudionorma_title', 'Normativa', null, 30, 50);
						this.describeAColumn(table, 'classescuola_indicecineca', 'Identificativo CINECA', null, 30, null);
						this.describeAColumn(table, 'classescuolakind_title', 'Tipologia', null, 40, 1024);
						this.describeAColumn(table, 'classescuolaarea_title', 'Area', null, 50, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idclassescuola"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "sigla asc , classescuola_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('classescuoladefaultview', new meta_classescuoladefaultview('classescuoladefaultview'));

	}());
