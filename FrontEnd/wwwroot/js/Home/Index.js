var lancamentos;

$(function () {

    $('#upArquivo').on('change', LerArquivo);

    $('#btRun').on('click', function () {

        var Model = {
            key: merchantKey,
            lancamentos: lancamentos
        };

        var url = urlWebApi + '/transaction';

        var method = 'GET';

        $('#tbStats tbody').html('');


        jsApi.postInformation(method, url, Model, function (data) {
            //console.log(data);
          MontaGrid(data);
        });
    });

});

var MontaGrid = function (data) {
    var i = 1;
    data.forEach(function (obj) {
        var credit = obj.CreditCardTransactionResultCollection[0];
        //console.log(obj);
        $('#tbStats tbody').append('<tr> \
                                        <td>' + GetPriority(obj.Priority) + '</td> \
                                        <td>' + obj.FileOrder + '</td> \
                                        <td>' + i + '</td> \
                                        <td>' + obj.InternalTime + 'ms</td> \
                                        <td>' + credit.AcquirerMessage + '</td> \
                                        <td>' + obj.OrderResult.CreateDate + '</td> \
                                    </tr>');
        i++;
    });
}

var GetPriority = function (num) {
    if (num === 0) {
        return 'Normal';
    }
    else if (num === 1) {
        return '<span style="color: #dacb00;"><strong>Urgente</strong></span>';
    }
    else {
        return '<span style="color: Red;"><strong>Urgente</strong></span>';
    }
}

var LerArquivo = function(e) {
    var file = e.target.files[0];
    if (!file) {
        return;
    }
    var reader = new FileReader();
    reader.onload = function (e) {
        lancamentos = e.target.result
        //console.log(arr);
    };
    reader.readAsText(file);
}