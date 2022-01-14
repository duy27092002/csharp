$(document).ready(function () {

    let trs = $("#owner-table tbody").find("tr");

    $.each(trs, function (i, e) {

        let registrationTime = $($(e).find('td')[1]).text().trim();

        let expireTime = $($(e).find('td')[2]).text().trim();

        let getDays = Math.round((new Date(expireTime)).getTime() - (new Date(registrationTime)).getTime()) / (1000 * 3600 * 24);

        // nếu thời hạn còn nhỏ hơn 1 năm thì sẽ cảnh báo
        if (getDays <= 365 && getDays > 0) {
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