var baseUrl = '.';

//angular setup
const ngApp = angular.module('app', []);

//ajax
const fetch = (url, data, callback) => {
    var $loadingContainer = $('#loading');
    if ($loadingContainer) kendo.ui.progress($('#loading'), true);
    $.ajax({
        url: url,
        dataType: 'json',
        data: data,
        async: true,
        cache: false,
        type: data ? 'POST' : 'GET',
        success: response => {
            if (response.Success) {
                if (typeof callback == 'function') callback(response);
            } else showMessageBox(response.Message, response.Status);
            if ($loadingContainer) kendo.ui.progress($('#loading'), false);
        },
        error: response => {
            alert(response.responseText);
            if ($loadingContainer) kendo.ui.progress($('#loading'), false);
        },
        timeout: 6000000,
    });
};

const fetchWithError = (url, data, callback) => {
    var $loadingContainer = $('#loading');
    if ($loadingContainer) kendo.ui.progress($('#loading'), true);
    $.ajax({
        url: url,
        dataType: 'json',
        data: data,
        async: true,
        cache: false,
        type: data ? 'POST' : 'GET',
        success: response => {
            if (typeof callback == 'function') callback(response);
            if ($loadingContainer) kendo.ui.progress($('#loading'), false);
        },
        error: response => {
            alert(response.responseText);
            if ($loadingContainer) kendo.ui.progress($('#loading'), false);
        },
        timeout: 6000000,
    });
};

//message box
const showMessageBox = (message, type) => {
    switch (type) {
        case 'Warning':
            return popupWindow(message, {
                title: 'Warning',
                template: msgBoxTemplateOK,
            });
            break;
        case 'Error':
            return popupWindow(message, {
                title: 'Error',
                template: msgBoxTemplateOK,
            });
            break;
        case 'Confirm':
            return popupWindow(message, {
                title: 'Confirm',
                template: msgBoxTemplateYesNo,
            });
            break;
        case 'Success':
            return popupWindow(message, { title: 'Success' });
            break;
        default:
            return popupWindow(message, { title: 'Info' });
    }
};

const popupWindow = (message, e) => {
    var defer = $.Deferred();
    var defaults = {
        title: 'Information',
        template: msgBoxTemplateOK,
    };
    var e = $.extend(defaults, e);
    var result = false;
    $("<div id='popupWindow'></div>")
        .appendTo('body')
        .css('text-align', 'center')
        .kendoWindow({
            minWidth: 400,
            maxWidth: 500,
            title: e.title,
            modal: true,
            visible: false,
            actions: [],
            close: function (e) {
                this.destroy();
                defer.resolve(result);
            },
        })
        .data('kendoWindow')
        .content(e.template)
        .center()
        .open();
    switch (e.title) {
        case 'Warning':
            $('#popupWindow .popupLogo').html(
                "<img src='" + baseUrl + "/Content/images/error-24px-1.png" +
                    "' style='width:100%' />"
            );
            break;
        case 'Error':
            $('#popupWindow .popupLogo').html(
                "<img src='" + baseUrl + "/Content/images/error-24px-1.png" +
                    "' style='width:100%' />"
            );
            break;
        case 'Confirm':
            $('#popupWindow .popupLogo').html(
                "<img src='" + baseUrl + "/Content/images/help-24px-1.png" +
                    "' style='width:100%' />"
            );
            break;
        case 'Success':
            $('#popupWindow .popupLogo').html(
                "<img src='" + baseUrl + "/Content/images/check_circle-24px-1.png" +
                    "' style='width:100%' />"
            );
            break;
        default:
            $('#popupWindow .popupLogo').html(
                "<img src='" + baseUrl + "/Content/images/help-24px-1.png" +
                    "' style='width:100%' />"
            );
            break;
    }
    $('#popupWindow .popupMessage').html(message).css('text-align', 'left');
    $('#popupWindow .confirm_okyes').click(function () {
        result = true;
        $('#popupWindow').data('kendoWindow').close();
    });
    $('#popupWindow .confirm_cancelno').click(function () {
        result = false;
        $('#popupWindow').data('kendoWindow').close();
        return false;
    });
    return defer.promise();
};

const commonMessageTemplate =
    '<table border=0 style="min-width:50%;max-width:100%"> <tr><td width="50px" style="padding-left:10px"><div class="popupLogo" style="float:left;width:50px"></div></td><td style="padding-left:10px"> <div class="popupMessage"></div></td></tr></table>';

const msgBoxTemplateOK =
    commonMessageTemplate +
    '</br>' +
    '<input type="button" class="confirm_okyes k-button pull-right" value="Ok" style="width: 80px; text-align : center;" />';

const msgBoxTemplateYesNo =
    commonMessageTemplate +
    '</br>' +
    '<input type="button" class="confirm_okyes k-button pull-right" value="Yes" style="width: 80px; text-align : center;" />' +
    '&nbsp' +
    '<input type="button" class="confirm_cancelno k-button pull-right" value="No" style="width: 80px; text-align : center;" />';

const msgBoxTemplateOkCancel =
    commonMessageTemplate +
    '</br>' +
    '<input type="button" class="confirm_okyes k-button pull-right" value="Ok" style="width: 80px; text-align : center;" />' +
    '&nbsp' +
    '<input type="button" class="confirm_cancelno k-button pull-right" value="Cancel" style="width: 80px; text-align : center;" />';

//kendo grid updating cell on the fly
const kendoFastReDrawRow = (grid, row) => {
    var dataItem = grid.dataItem(row);
    var rowChildren = $(row).children('td[role="gridcell"]');
    for (var i = 0; i < grid.columns.length; i++) {
        var column = grid.columns[i];
        var template = column.template;
        var cell = rowChildren.eq(i);
        if (template !== undefined) {
            var kendoTemplate = kendo.template(template);
            cell.html(kendoTemplate(dataItem));
        } else {
            var fieldValue = dataItem[column.field];
            var format = column.format;
            var values = column.values;
            if (values !== undefined && values != null) {
                for (var j = 0; j < values.length; j++) {
                    var value = values[j];
                    if (value.value == fieldValue) {
                        cell.html(value.text);
                        break;
                    }
                }
            } else if (format !== undefined) {
                cell.html(kendo.format(format, fieldValue));
            } else {
                cell.html(fieldValue);
            }
        }
    }
    var expanded = $.map(
        grid.tbody.children(':has(> .k-hierarchy-cell .k-i-collapse)'),
        row => {
            return $(row).data('uid');
        }
    );
    grid.one('dataBound', () => {
        grid.expandRow(
            grid.tbody.children().filter((idx, row) => {
                return $.inArray($(row).data('uid'), expanded) >= 0;
            })
        );
    });
    grid.refresh();
};

//get cookie
const getCo = cname => {
    var name = cname + '=';
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return '';
};

//create GUID
const newGuid = () => {
    const s4 = () => {
        return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
}

//read query string
const getQs = key => {
    const vars = [];
    const hashes = window.location.href
        .slice(window.location.href.indexOf('?') + 1)
        .split('&');
    let hash;
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars[key];
};

//remove query string
function removeQs() {
    const uri = window.location.toString();
    if (uri.indexOf('?') > 0) {
        const clean_uri = uri.substring(0, uri.indexOf('?'));
        window.history.replaceState({}, document.title, clean_uri);
    }
}

//js data store
const loadDetails = function (details, detail) {
    var index = findIndex(details, detail.Id);
    if (index !== -1)
        details[index] = detail;
    else
        details.push(detail);
}

//find index array
const findIndex = function (details, id) {
    for (var i = 0; i < details.length; i++)
        if (details[i].Id == id)
            return i;
    return - 1;
}