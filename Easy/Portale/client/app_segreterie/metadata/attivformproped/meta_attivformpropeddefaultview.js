(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_attivformpropeddefaultview() {
        MetaData.apply(this, ["attivformpropeddefaultview"]);
        this.name = 'meta_attivformpropeddefaultview';
    }

    meta_attivformpropeddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_attivformpropeddefaultview,
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
						this.describeAColumn(table, 'attivformproped_alternativa', 'Alternativa', null, 10, null);
						this.describeAColumn(table, 'attivform_proped_iddidprogcurr', 'Curriculum', null, 10, null);
						this.describeAColumn(table, 'attivform_proped_iddidprogori', 'Orientamento', null, 20, null);
						this.describeAColumn(table, 'attivform_proped_iddidproganno', 'Anno di corso', null, 30, null);
						this.describeAColumn(table, 'attivform_proped_iddidprogporzanno', 'Porzione d\'anno', null, 40, null);
						this.describeAColumn(table, 'attivform_proped_iddidproggrupp', 'Gruppo opzionale', null, 50, null);
						this.describeAColumn(table, 'attivform_proped_idinsegn', 'Insegnamento', null, 60, null);
						this.describeAColumn(table, 'attivform_proped_idinsegninteg', 'Integrando', null, 70, null);
						this.describeAColumn(table, 'attivform_proped_start', 'Dal', null, 80, null);
						this.describeAColumn(table, 'attivform_proped_stop', 'Al', null, 90, null);
						this.describeAColumn(table, 'attivform_proped_tipovalutaz', 'Profitto o Idoneità', null, 100, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "iddidprog", "idattivform", "iddidprogori", "idcorsostudio", "iddidproganno", "iddidprogcurr", "iddidprogporzanno"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('attivformpropeddefaultview', new meta_attivformpropeddefaultview('attivformpropeddefaultview'));

	}());
