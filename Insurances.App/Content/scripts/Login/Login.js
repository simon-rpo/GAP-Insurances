//Section ready
$(function ($) {
  Login.Init();
});

var UserData = [];

var Login = {
  Init: function () {

    Login.Config();
  },
  //Initial configuration
  Config: function () {
    $("#btnLogin").on("click", function () {
      var bValidation = Login.ValidateLogin();
      if (bValidation) {
        var LoginCallBack = Login.LogIn();
        var AuthCallBack = Login.Auth();

        $.when(LoginCallBack, AuthCallBack).done(function (LoginData, authData) {
          if (LoginData.length > 0 && authData.length > 0) {
            if (LoginData[1] === "success" && authData[1] === "success") {
              sessionStorage.setItem("User", authData[0]);
              var UserData = authData[0];
              UserData.Password = $("#passwordInput").val();

              $.ajax({
                async: false,
                crossDomain: true,
                url: FormatString(UrlsAuthenticate.Authenticate, JSON.stringify(UserData), JSON.stringify(LoginData[0])),
                method: "POST",
                dataType: "JSON",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                  window.location = UrlsAuthenticate.ToHome;
                },
                error: function (XmlHttpError, error, description) {
                  $("#LoginMessage").html(dict.AccessDeny[Language.Culture]);
                }
              });
            } else {
              $("#LoginMessage").html(data.Message);
            }
          }
        });
      }
    });

    //Pres enter in password input
    $("#passwordInput").keypress(function (e) {
      if (e.keyCode == 13)
        $("#btnLogin").click();
    });
    $("#userNameInput").keypress(function (e) {
      if (e.keyCode == 13)
        $("#btnLogin").click();
    });
    $('#userNameInput').on('click', function () {
      $(this).scrollTop(200);
    });
    $('#userNameInput').on('focus', function () {
      $('#noLogin').text("");
    });
  },

  ValidateLogin: function () {
    if ($("#userNameInput").val() == '' || $("#userNameInput").val() == null) {
      $("#LoginMessage").html(dict.InsertUser[Language.Culture]);
      return false;
    }
    if ($("#passwordInput").val() == '' || $("#passwordInput").val() == null) {
      $("#LoginMessage").html(dict.InsertPassword[Language.Culture]);
      return false;
    }
    return true;
  },

  LogIn: function () {
    UserData = {
      username: $("#userNameInput").val(),
      password: $("#passwordInput").val(),
    };

    var Url = FormatString(UrlsAuthenticate.LoginUser);

    var LoginCall = $.ajax({
      async: true,
      crossDomain: true,
      url: Url,
      method: "POST",
      dataType: "JSON",
      contentType: "application/x-www-form-urlencoded; charset=UTF-8",
      data: UserData,
      error: function (XmlHttpError, error, description) {
        if (typeof XmlHttpError.responseJSON !== typeof undefined) {
          if (XmlHttpError.responseJSON.error === "invalid_grant") {
            $("#LoginMessage").html(dict.invalid_grant[Language.Culture]);
          }
          if (XmlHttpError.responseJSON.error === "invalid_clientId") {
            $("#LoginMessage").html(dict.AccessDeny[Language.Culture]);
          }
        } else {
          $("#LoginMessage").html(dict.AccessDeny[Language.Culture]);
        }
      }
    });
    return LoginCall;
  },

  Auth: function () {
    var UserData = {
      UserName: $("#userNameInput").val(),
      Password: $("#passwordInput").val(),
    };
    var sAuthUrl = FormatString(UrlsAuthenticate.LoginUser);

    var AuthCall = $.ajax({
      async: true,
      crossDomain: true,
      url: sAuthUrl,
      method: "POST",
      dataType: "JSON",
      contentType: "application/json; charset=utf-8",
      data: JSON.stringify(UserData),
      error: function (XmlHttpError, error, description) {
        //$("#LoginMessage").html(dict.AccessDeny[Language.Culture]);
      }
    });

    return AuthCall;
  },

  Logout: function () {
    $.ajax({
      url: FormatString(UrlsAuthenticate.Logout),
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      cache: false,
      success: function () {
        sessionStorage.clear();
        window.location = '../login/login';
      }
    });
  },
};