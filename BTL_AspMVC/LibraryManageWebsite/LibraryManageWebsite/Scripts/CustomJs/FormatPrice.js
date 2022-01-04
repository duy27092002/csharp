$(document).ready(function () {
    $('body').on('keyup', '.price', function () {
        $(this).val(formatNumber(formatString($(this).val())));
    });
});

function formatNumber(nStr) {
    var groupSeperate = ',';
    var x = formatString(nStr);
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x)) {
        x = x.replace(rgx, '$1' + groupSeperate + '$2');
    }
    return x;
}

function formatString(money) {
    var x = '';
    var arr = money.toString().split(',');
    arr.forEach((str) => {
        x += str;
    });
    return x;
}