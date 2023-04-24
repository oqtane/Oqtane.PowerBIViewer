/* Module Script */
var Oqtane = Oqtane || {};

Oqtane.PowerBIViewer = {

    showReport: function (reportContainer, isEdit, accessToken, embedUrl, embedReportId) {

        // Get models. models contains enums that can be used.
        var models = window['powerbi-client'].models;

        var EditMode = models.ViewMode.View;

        if (isEdit) {
            EditMode = models.ViewMode.Edit;
        } else {
            EditMode = models.ViewMode.View;
        }

        var config = {
            type: 'report',
            tokenType: models.TokenType.Embed,
            accessToken: accessToken,
            embedUrl: embedUrl,
            id: embedReportId,
            permissions: models.Permissions.All,
            viewMode: EditMode,
            settings: {
                filterPaneEnabled: true,
                navContentPaneEnabled: true
            }
        };
        powerbi.reset(reportContainer);

        report = powerbi.embed(reportContainer, config);
    }

};