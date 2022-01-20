$(document).ready(function () {

    // dữ liệu cần lấy: mã phiếu, thời gian mượn, thời gian trả (hiện tại), chi phí mượn
    let getPNId = $("#Id").val();
    let borrowedDate = $("#BorrowedDate").val();
    let expiryDate = $("#ExpiryDate").val();
    let cost = 0;

    // tính khoảng cách thời gian giữa ngày mượn và trả
    let getDays = Math.round(((new Date(expiryDate)).getTime() - (new Date(borrowedDate)).getTime()) / (1000 * 3600 * 24));

    if (getDays == 0) {
        cost = formatNumber(5000);
        $("#Cost").val(cost);
    }
    else {
        cost = formatNumber(5000 + ((getDays - 1) * 3000));
        $("#Cost").val(cost);
    }

    // sự kiện ấn nút trả sách
    $("body").on("click", "#returning-book-btn", function () {

        $.ajax({
            url: "/PromissoryNotes/ReturningBookConfirmed",
            type: "Post",
            dataType: "json",
            data: {
                id: getPNId,
                expiryDate: expiryDate,
                cost: cost
            },
            success: function (result) {
                if (result.success) {
                    window.location = "/PromissoryNotes/Index";
                }
                else {
                    swal({
                        title: "Lỗi!",
                        text: "" + result.mess,
                        icon: "error",
                        buttons: "Đã hiểu",
                    });
                }
            },
            error: function (result) { }
        });
    });

});

function formatNumber(nStr) {

    let groupSeperate = ',';

    let x = formatString(nStr);

    let rgx = /(\d+)(\d{3})/;

    while (rgx.test(x)) {
        x = x.replace(rgx, '$1' + groupSeperate + '$2');
    }

    return x;
}

function formatString(money) {

    let x = '';

    let arr = money.toString().split(',');

    arr.forEach((str) => {
        x += str;
    });

    return x;
}