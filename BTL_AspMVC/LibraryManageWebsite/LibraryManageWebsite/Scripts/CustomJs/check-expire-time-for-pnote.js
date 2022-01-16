$(document).ready(function () {

    let today = new Date();
    let dd = String(today.getDate()).padStart(2, '0');
    let mm = String(today.getMonth() + 1).padStart(2, '0');
    let yyyy = today.getFullYear();

    today = mm + '/' + dd + '/' + yyyy;

    let trs = $("#pn-table tbody").find("tr");

    $.each(trs, function (i, e) {

        let expireTime = $($(e).find('td')[4]).text().trim();

        let getDays = Math.round((new Date(expireTime)).getTime() - (new Date(today)).getTime()) / (1000 * 3600 * 24);

        // nếu thời hạn còn nhỏ hơn 30 ngày thì sẽ cảnh báo
        if (getDays <= 1 && getDays > 0) {
            $(this).find(".msg").text("Sắp hết hạn");
        }

        // nếu đã trễ hạn thì cảnh báo đỏ
        if (getDays < 0) {
            $(this).find(".msg").removeClass("bg-warning");
            $(this).find(".msg").addClass("bg-danger");
            $(this).find(".msg").text("Đã hết hạn");
        }

    });

});