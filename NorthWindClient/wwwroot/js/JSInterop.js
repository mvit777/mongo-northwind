
//define namespace for bootstrap components
var MV_Components = {};
//register the helper functions in the namespace for bootstrap components
(function () {
    this.ToggleModal = function (modal, mode) {
        $(modal).modal(mode);
    }
    this.ToggleToast = function (toast, options) {
        $(toast).toast(options);
    }
    this.JSDataTable = function (table, options) {
        //this will take care we not recreate the table
        if (!$.fn.dataTable.isDataTable(table)) {
            $(table).DataTable(options);
        }
    }
    this.RefreshJSDataTable = function (table, options) {
        $(table).dataTable().fnDestroy();
    }
}).apply(MV_Components);