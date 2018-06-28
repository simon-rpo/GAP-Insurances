/* API's Url */

// localHost
var UrlApi = "http://localhost:50431/api/";
var PrePath = "/";


var UrlsClients = {
    GetAll: UrlApi + "Client/GetClients",
};

var UrlsCoveringTypes = {
    GetAll: UrlApi + "CoveringType/GetCoveringTypes",
};

var UrlsPolicy = {
    Save: UrlApi + "Policy/SavePolicy",
    GetPolById: UrlApi + "Policy/GetPoliciesByClient?ClientId={0}",
    CancelPolicy: UrlApi + "Policy/CancelPolicy",
};

var UrlsAuthenticate = {
    LoginUser: UrlApi + "Login/GetAuth",
    Authenticate: PrePath + "Home/Authenticate?Data1={0}&Data2={1}",
    ToHome: PrePath + "Home/Home",
    LogOutUser: PrePath + "Login/LogOut",
};