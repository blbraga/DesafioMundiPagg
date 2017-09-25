$(function () {

    $('#btRun').on('click', function () {

        var Model = {
            key : merchantKey
        };

        var url = urlWebApi + '/transaction';

        var method = 'GET';

        jsApi.postInformation(method, url, Model, function (data) {
            //console.log(data);
            MontaGrid(data);
        });
    });

});

var MontaGrid = function (data) {
    $('#tbStats tbody').html('');

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
    if (num == 0) {
        return 'Normal';
    }
    else if (num == 1) {
        return '<span style="color: Yellow;"><strong>Urgente</strong></span>';
    }
    else {
        return '<span style="color: Red;"><strong>Urgente</strong></span>';
    }
}