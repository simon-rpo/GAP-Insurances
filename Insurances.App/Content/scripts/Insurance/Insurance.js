//Section ready
$(function ($) {
  Insurance.Init();
});

var Insurance = {
  Init: function () {

    // #region "Init"

    Insurance.LoadClients();
    Insurance.LoadCoveringType();

    $('#dateCoverageStart').datetimepicker({
      format: "YYYY/MM/DD",
    });
    // #endregion

    Insurance.Config();
  },
  //Initial config
  Config: function () {

    $("#btnSave").click(function (e) {
      e.preventDefault();
      Insurance.SavePolicy();
    });

    return;
  },


  LoadClients: function () {
    var sClients = FormatString(UrlsClients.GetAll);

    var ClientsCall = $.ajax({
      async: true,
      crossDomain: true,
      url: sClients,
      method: "POST",
      dataType: "JSON",
      contentType: "application/json; charset=utf-8",
      error: function (XmlHttpError, error, description) {
        $.notify({
          // options
          icon: 'glyphicon glyphicon-exclamation-sign',
          title: 'Error',
          message: 'Error @ LoadClients',
          target: '_blank'
        },
          { type: 'danger' });
      }
    });

    $.when(ClientsCall).done(function (dataClients) {
      if (dataClients.length < 1) {
        $.notify({
          icon: 'glyphicon glyphicon-exclamation-sign',
          title: '',
          message: 'No data for Clients',
          target: '_blank'
        },
          { type: 'warning' });
        return;
      }
      var ul = "";
      $(dataClients.ModelData).each(function (index, value) {
        ul += '<option value=' + value.Id + '>' + value.Name + '</option>';
      });
      $("#selectClients").find('option').remove();
      $('#selectClients').append(ul);
      $("#selectClients").selectpicker("refresh");
    });
  },


  LoadCoveringType: function () {
    var sCoveringTypes = FormatString(UrlsCoveringTypes.GetAll);

    var CovTypesCall = $.ajax({
      async: true,
      crossDomain: true,
      url: sCoveringTypes,
      method: "POST",
      dataType: "JSON",
      contentType: "application/json; charset=utf-8",
      error: function (XmlHttpError, error, description) {
        $.notify({
          // options
          icon: 'glyphicon glyphicon-exclamation-sign',
          title: 'Error',
          message: 'Error @ LoadClients',
          target: '_blank'
        },
          { type: 'danger' });
      }
    });

    $.when(CovTypesCall).done(function (dataCovTypes) {
      if (dataCovTypes.length < 1) {
        $.notify({
          icon: 'glyphicon glyphicon-exclamation-sign',
          title: '',
          message: 'No data for Covering types',
          target: '_blank'
        },
          { type: 'warning' });
        return;
      }
      var ul = "";
      $(dataCovTypes.ModelData).each(function (index, value) {
        ul += '<option value=' + value.Id + '>' + value.Name + '</option>';
      });
      $("#selectCovTypes").find('option').remove();
      $('#selectCovTypes').append(ul);
      $("#selectCovTypes").selectpicker("refresh");
    });
  },

  SavePolicy: function () {
    var sSavePolicy = FormatString(UrlsPolicy.Save);

    var SaveData = {
      Name: $('#inputName').val(),
      Description: $('#inputDescription').val(),
      CoveringTypeId: $('#selectCovTypes').val(),
      CoveringPercentage: $("#inputCoveringPercentage").val(),
      PolicyStart: $('#dateCoverageStart').find('input').val(),
      Period: $("#inputPeriod").val(),
      Price: $("#inputPrice").val(),
      ClientId: $('#selectClients').val(),
      Risk: $("#seleRiskType").val(),
      Status: 2,
    };

    var SavePolicyCall = $.ajax({
      async: true,
      crossDomain: true,
      url: sSavePolicy,
      method: "POST",
      dataType: "JSON",
      data: JSON.stringify(SaveData),
      contentType: "application/json; charset=utf-8",
      error: function (XmlHttpError, error, description) {
        $.notify({
          // options
          icon: 'glyphicon glyphicon-exclamation-sign',
          title: 'Error',
          message: 'Error @ SavePolicy',
          target: '_blank'
        },
          { type: 'danger' });
      }
    });

    $.when(SavePolicyCall).done(function (dataPolicy) {
      if (dataPolicy.ModelData.Code === 1) {
        $.notify({
          icon: 'glyphicon glyphicon-exclamation-sign',
          title: '',
          message: dataPolicy.ModelData.Message,
          target: '_blank'
        },
          { type: 'Success' });

      } else {
        $.notify({
          icon: 'glyphicon glyphicon-exclamation-sign',
          title: '',
          message: dataPolicy.ModelData.Message,
          target: '_blank'
        },
          { type: 'warning' });
      }
    });
  },

};



