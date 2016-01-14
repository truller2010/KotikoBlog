/* global define: false, ko: false */
define([
    "i18next", 'jquery'
], function alertsViewModel(i18n, $) {
    "use strict";

    var viewModel = {}, alerts = ko.observableArray(), alertClass = {
        INFO: "alert alert-info bounce",
        SUCCESS: "alert alert-success bounceIn",
        WARN: "alert shake",
        ERROR: "alert alert-danger tada",
        FATAL: "alert alert-fatal tada"
    }, labelClass = {
        INFO: "label label-info",
        SUCCESS: "label label-success",
        WARN: "label label-warning",
        ERROR: "label label-important",
        FATAL: "label label-inverse"
    };

    function info(detail, summary) {
        alerts.push({
            alertClass: alertClass.INFO,
            labelClass: labelClass.INFO,
            label: i18n.t('INFO'),
            summary: summary,
            detail: detail
        });
    }

    function success(detail, summary) {
        if (!detail) {
            success(i18n.SUCCESS_ALERT_TEXT);
        }

        alerts.push({
            alertClass: alertClass.SUCCESS,
            labelClass: labelClass.SUCCESS,
            label: i18n.t('SUCCESS'),
            summary: summary,
            detail: detail
        });
    }

    function warn(detail, summary) {
        alerts.push({
            alertClass: alertClass.WARN,
            labelClass: labelClass.WARN,
            label: i18n.t('WARN'),
            summary: summary,
            detail: detail
        });
    }

    function error(detail, summary) {
        alerts.push({
            alertClass: alertClass.ERROR,
            labelClass: labelClass.ERROR,
            label: i18n.t('ERROR'),
            summary: summary,
            detail: detail
        });
    }

    function fatal(detail, summary) {
        alerts.push({
            alertClass: alertClass.FATAL,
            labelClass: labelClass.FATAL,
            label: i18n.t('FATAL'),
            summary: summary,
            detail: detail
        });
    }

    function removeAllAlerts() {
        alerts.removeAll();
    }

    function removeAlert(index) {
        alerts.splice(index, 1);
        if ($('#alerts')) {
            $('#alerts').css("height", "auto");
        }
    }

    function hasAlerts() {
        return alerts().length > 0;
    }

    function countAlerts(alertClass) {
        var count = 0, i = 0, imax = alerts().length;

        for (i = 0; i < imax; i = i + 1) {
            if (alerts()[i].alertClass === alertClass) {
                count = count + 1;
            }
        }

        return count;
    }

    function raiseError(data, element) {
        removeAllAlerts();
        error(i18n.format(data));
    }

    function raiseInfo(data, element) {
        removeAllAlerts();
        info(i18n.format(data));
    }

    function raiseSuccess(data, element) {
        removeAllAlerts();
        success(i18n.format(data));
    }

    function raiseWarn(data, element) {
        removeAllAlerts();
        warn(i18n.format(data));
    }

    function raiseFatal(data, element) {
        removeAllAlerts();
        fatal(i18n.format(data));
    }

    viewModel.i18n = i18n;
    viewModel.alerts = alerts;
    viewModel.info = info;
    viewModel.success = success;
    viewModel.warn = warn;
    viewModel.error = error;
    viewModel.fatal = fatal;
    viewModel.removeAllAlerts = removeAllAlerts;
    viewModel.removeAlert = removeAlert;
    viewModel.hasAlerts = ko.computed(hasAlerts);

    viewModel.raiseError = raiseError;
    viewModel.raiseWarn = raiseWarn;
    viewModel.raiseInfo = raiseInfo;
    viewModel.raiseFatal = raiseFatal;
    viewModel.raiseSuccess = raiseSuccess;

    viewModel.countInfos = ko.computed(function countErrors() {
        return countAlerts(alertClass.INFO);
    });
    viewModel.countSuccesses = ko.computed(function countErrors() {
        return countAlerts(alertClass.SUCCESS);
    });
    viewModel.countWarns = ko.computed(function countErrors() {
        return countAlerts(alertClass.WARN);
    });
    viewModel.countErrors = ko.computed(function countErrors() {
        return countAlerts(alertClass.ERROR);
    });
    viewModel.countFatals = ko.computed(function countErrors() {
        return countAlerts(alertClass.FATAL);
    });

    return viewModel;
});