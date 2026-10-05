(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_attivformappelloview() {
        MetaData.apply(this, ["attivformappelloview"]);
        this.name = 'meta_attivformappelloview';
    }

    meta_attivformappelloview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_attivformappelloview,
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
					case 'appello':
						this.describeAColumn(table, 'title', 'Attività formativa', null, 1000, -1);
						this.describeAColumn(table, 'aa', 'AA', null, 2000, 9);
						this.describeAColumn(table, 'didproganno_anno', 'Anno di corso', null, 3100, null);
						this.describeAColumn(table, 'didprog_title', 'Didattica programmata', null, 5100, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 5200, 9);
						this.describeAColumn(table, 'sede_title', 'Sede Didattica programmata', null, 5320, 1024);
						this.describeAColumn(table, 'attivform_tipovalutaz', 'Profitto o Idoneità', null, 18000, null);
//$objCalcFieldConfig_appello$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idsede", "iddidprog", "idattivform", "iddidprogori", "idcorsostudio", "iddidproganno", "iddidprogcurr", "iddidprogporzanno"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "appello": {
						return "";
					}
					case "appello": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('attivformappelloview', new meta_attivformappelloview('attivformappelloview'));

	}());
