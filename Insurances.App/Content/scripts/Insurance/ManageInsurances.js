//Section ready
$(function ($) {
  Request.Init();
});

var DataReview = 0;

var Request = {
  Init: function () {
    $('#InsurancesTable').hide();
    Request.LoadClients();
    Request.Config();
  },

  Config: function () {

    $('#page-top').attrchange({
      //Listen while a style atribute change.
      trackValues: true,
      /* enables tracking old and new values */
      callback: function (e) { //callback handler on DOM changes  
        //log the events in the panel
        if (parseInt($('#page-top').css('padding-right')) > 0) {
          $('#page-top').css('padding-right', '');
        }
      }
    });

    $('#btnSearch').click(function (e) {
      e.preventDefault();
      Request.LoadRequest();
    });
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

  LoadRequest: function () {
    var sInsurancesUrl = FormatString(UrlsPolicy.GetPolById, $('#selectClients').val());

    if ($.fn.DataTable.isDataTable('#InsurancesTable')) {
      $('#InsurancesTable').DataTable().clear();
      $('#InsurancesTable').DataTable().destroy();
    }

    $('#InsurancesTable').DataTable({
      "bServerSide": false,
      "bProcessing": true,
      "searching": true,
      "bSort": true,
      "ajax": {
        async: true,
        crossDomain: true,
        url: sInsurancesUrl,
        method: "GET",
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        dataSrc: function (data) {
          return data.ModelData;
        },
        error: function (XmlHttpError, error, description) {
          $.notify({
            // options
            icon: 'glyphicon glyphicon-exclamation-sign',
            title: 'Error',
            message: 'Error @ LoadRequest',
            target: '_blank'
          },
            { type: 'danger' });
        }
      },
      "aoColumns": [
        { data: "Name" },
        { data: "Description" },
        { data: "CoveringTypeId" },
        { data: "CoveringPercentage" },
        { data: "PolicyStart" },
        { data: "Period" },
        { data: "Price" },
        { data: "RiskName" },
        {
          "mRender": function (data, type, full, meta) {
            return "<div >" +
              "<button type='button' id='btnCancel' class='btn btn-danger glyphicon glyphicon-remove' onclick='Request.CancelPolicy(" + JSON.stringify(full) + ")'></button>" +
              "</div>";
          }
        }
      ],
      "order": [[0, "desc"]],
      "initComplete": function () {
        $('#InsurancesTable').show();
      }
    });
  },

  CancelPolicy: function (Data) {
    var sCancelPolicy = FormatString(UrlsPolicy.CancelPolicy);

    var CancelPolicyCall = $.ajax({
      async: true,
      crossDomain: true,
      url: sCancelPolicy,
      method: "POST",
      dataType: "JSON",
      data: JSON.stringify(Data),
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

    $.when(CancelPolicyCall).done(function (dataPolicy) {
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
      Request.LoadRequest();
    });
  },
};
