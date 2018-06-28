var Language = {
    Id: "1",
    Culture: "ES",
    Name: "Spanish",
    Init: function () {
        if (sessionStorage.getItem("Culture") != null && sessionStorage.getItem("Culture") != 'undefined') {
            Language.Culture = sessionStorage.getItem("Culture");
        } else {
            sessionStorage.setItem("Culture", Language.Culture);
        }
    }
};

Language.Init();

var dict = {
    "PAYROLL": {
        EN: "Payroll App"
    },
    "PayrollDirect": {
        EN: "Payroll"
    },
}
