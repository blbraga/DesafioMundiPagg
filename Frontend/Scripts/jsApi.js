function jsApi() {
};

jsApi.postInformation = function (method, url, information, fnCallback) {
    if (!$.isFunction(fnCallback))
        return false;

    //dados = JSON.stringify(information);

    $.ajax({
        type: method,
        url: url,
        data: information,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            fnCallback(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('Ocorreu um erro interno não esperado.');
        }
    });
};