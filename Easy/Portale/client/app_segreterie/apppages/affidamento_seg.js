
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_affidamento() {
		MetaPage.apply(this, ['affidamento', 'seg', true]);
        this.name = 'Affidamento';
		this.defaultListType = 'seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_affidamento.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_affidamento,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				if (!parentRow.gratuito)
					parentRow.gratuito = "N";
				if (!parentRow.iderogazkind)
					parentRow.iderogazkind = 1;
				if (!parentRow.riferimento)
					parentRow.riferimento = "N";
				_.forEach(this.getDataTable("lezione_alias2").rows, function (r) {
					r['!title'] = parentRow.title;
				});
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-affidamento_seg");
				var arraydef = [];
				
				//beforeFillInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return self.superClass.beforeFill.call(self)
							.then(function () {
								return def.resolve();
							});
					});
				return def.promise();
			},

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('affidamento'), this.getDataTable('affidamentocaratteristica'));
				//afterClearin
			},

			
			afterLink: function () {
				var self = this;
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar36').fullCalendar('rerenderEvents');
				});
				$("#OpenScheduleConfig").on("click", _.partial(this.fireOpenScheduleConfig, this));
				$("#OpenScheduleConfig").prop("disabled", true);
				var grid_affidamentocaratteristica_segChildsTables = [
					{ tablename: 'affidamentocaratteristicaora', edittype: 'seg', columnlookup: 'ora', columncalc: '!affidamentocaratteristicaora'},
				];
				$('#grid_affidamentocaratteristica_seg').data('childtables', grid_affidamentocaratteristica_segChildsTables);
				$('#grid_affidamentocaratteristica_seg').data('childtablesadd', false);
				$('#grid_affidamentocaratteristica_seg').data('childtablesdelete', false);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			rowSelected: function (dataRow) {
				$("#OpenScheduleConfig").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#OpenScheduleConfig").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			//insertClick

			//beforePost

			afterFill: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('affidamento'), this.getDataTable('affidamentocaratteristica'));
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
					var filter = self.q.and(
						self.q.eq("idreg", this.state.currentRow.idreg_docenti),
						self.q.ne("idaffidamento", self.state.currentRow.idaffidamento)
					);
					return this.getExternalEventForCalendar(filter, $("[data-tag='lezione_alias2.seg.seg']")).then( function(){
						return MetaPage.prototype.afterFill.call(self);
					});
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			fireOpenScheduleConfig: function (that) {

				if (!that.state.currentRow.title) return that.showMessageOk(that.localResource.loc.getIsValidFieldMandatory('titolo'));
				var maxHoursPerDayTable = null;
				var idreg = that.state.currentRow.idreg_docenti;
				var filter = that.q.eq("idreg", idreg);
				appMeta.getData.runSelect("getoremaxgg" , "*" , filter, null)
					.then(function (dt) {
						maxHoursPerDayTable = dt;
						var scheduler = new appMeta.scheduleConfig(that,
							{
								minDateValue: that.state.currentRow.start,
								maxHours: _.sumBy(that.getDataTable('affidamentocaratteristicaora').rows, function (row) {
									return row.ora;
								}),
								tableNameSchedule: 'lezione_alias2',
								columnDate: 'start',
								columnTitle: '!title',
								columnTitleValue: that.state.currentRow.title,
								columnStop: 'stop',
								chooseAula: true,
								calendarTag : "lezione_alias2.seg.seg",
								maxHoursPerDayTable : maxHoursPerDayTable
							});
						return scheduler.show();
					})
			},

			//buttons
        });

	window.appMeta.addMetaPage('affidamento', 'seg', metaPage_affidamento);

}());
