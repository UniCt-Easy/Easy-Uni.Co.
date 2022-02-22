require('../components/metadata/MetaApp.js');
require('../$template$/metadata/Meta$currentApp$App.js');
require('../components/metadata/Enum.js');
require('../components/i18n/LocalResourceIt.js');
require('../components/i18n/LocalResourceFr.js');
require('../components/i18n/LocalResourceEn.js');
require('../components/metadata/LocalResource.js');
require('../components/metadata/Config.js');
require('../components/metadata/Logger.js');
require('../components/metadata/DbProcedureMessage.js');
require('../components/metadata/Routing.js');
require('../components/metadata/EventManager.js');
require('../components/metadata/Utils.js');
require('../components/metadata/GetDataUtils.js');
require('../components/metadata/GetDataUtilsDotNet.js');
require('../components/metadata/ConnWebService.js');
require('../components/metadata/ConnWebSocket.js');
require('../components/metadata/Connection.js');
require('../components/metadata/MetaModel.js');
require('../components/metadata/GetData.js');
require('../components/metadata/Security.js');
require('../components/metadata/AuthManager.js');
require('../components/metadata/PostData.js');
require('../components/metadata/FormProcedureMessages.js');
require('../components/metadata/BootstrapContainerTab.js');
require('../components/metadata/BootstrapModal.js');
require('../components/metadata/LoaderControl.js');
require('../components/metadata/ModalLoaderControl.js');
require('../components/metadata/ListManager.js');
require('../components/metadata/ListManagerCalendar.js');
require('../components/metadata/CssDefault.js');
require('../components/metadata/TypedObject.js');
require('../components/metadata/MetaPageState.js');
require('../components/metadata/HelpForm.js');
require('../components/metadata/CheckBoxListControl.js');
require('../components/metadata/GridControl.js');
require('../components/metadata/GridControlX.js');
require('../components/metadata/GridControlXChild.js');
require('../components/metadata/GridControlXEdit.js');
require('../components/metadata/CalendarControl.js');
require('../components/metadata/MetaData.js');
require('../components/metadata/MetaPage.js');
require('../components/metadata/ComboManager.js');
require('../components/metadata/GridMultiSelectControl.js');
require('../components/metadata/MultiSelectControl.js');
require('../components/metadata/Attachment.js');
require('../components/metadata/UploadControl.js');
require('../components/metadata/SliderControl.js');
require('../components/metadata/tachimetro/TachimetroControl.js');
require('../components/metadata/graph/GraphControl.js');
require('../components/metadata/MainToolBarManager.js');
require('../components/metadata/DropDownGridControl.js');
require('../components/metadata/GridControlXScrollable.js');
require('../components/metadata/ListManagerScrollable.js');
require('../components/metadata/GridControlXMultiSelect.js');
require('../components/metadata/ListManagerMultiSelect.js');
require('../components/metadata/TreeNode.js');
require('../components/metadata/TreeNode_Dispatcher.js');
require('../components/metadata/TreeViewManager.js');
require('../components/metadata/TreeNodeUnLeveled.js');
require('../components/metadata/TreeNodeLeveled.js');
require('../components/metadata/TreeNodeUnLeveled_Dispatcher.js');
require('../components/metadata/TreeNodeLeveled_Dispatcher.js');

require('../components/metadata/tree/SimpleUnLeveled_TreeNode.js');
require('../components/metadata/tree/SimpleUnLeveled_TreeNode_Dispatcher.js');
require('../components/metadata/tree/SimpleUnLeveled_TreeViewManager.js');
require('../components/metadata/tree/TreeControl.js');

require('../app_segreterie/cambioruolo.js');

require('../$template$/assets/i18n/LocalResourceIt.js');
require('../$template$/assets/i18n/LocalResourceEn.js');
require('../$template$/Localization.js');

require('../componentsEasy/metadata/MetaEasyPage.js');
require('../componentsEasy/metadata/MetaEasyData.js');
require('../$template$/metadata/Meta$currentApp$Page.js');
require('../$template$/metadata/Meta$currentApp$Data.js');

require('../$template/metadata/ImportExcel.js');

require('../$template$/metadata/Toast.js');
require('../$template$/metadata/scheduler/scheduleConfig.js');
require('../$template$/custom.js');
require('../$template$/menubuilder/menuBuilder.js');

function requireAll(r) { r.keys().forEach(r); }
requireAll(require.context('../$template$/metadata', true, /meta_.*\.js$/));


