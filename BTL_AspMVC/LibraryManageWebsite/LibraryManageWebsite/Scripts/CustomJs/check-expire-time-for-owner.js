$(document).ready(function () {

    let today = new Date();
    let dd = String(today.getDate()).padStart(2, '0');
    let mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    let yyyy = today.getFullYear();

    today = mm + '/' + dd + '/' + yyyy;

    let trs = $("#owner-table tbody").find("tr");

    $.each(trs, function (i, e) {

        let ownerId = $($(e).find('td')[0]).text().trim();
        let expireTime = $($(e).find('td')[3]).text().trim();
        let status = $($(e).find('td')[4]).text().trim();

        let getDays = Math.round((new Date(expireTime)).getTime() - (new Date(today)).getTime()) / (1000 * 3600 * 24);

        // nếu thời hạn còn nhỏ hơn 30 ngày thì sẽ cảnh báo
        if (getDays <= 30 && getDays >= 0) {
            if (status == "Đã hủy kích hoạt") {
                updateStatus(ownerId);
            }

            $(this).find(".msg").text("Sắp hết hạn");

        } else if (getDays < 0 && status == "Đã kích hoạt") {
            // thay đổi trạng thái kích hoạt về ngừng kích hoạt
            updateStatus(ownerId);
        } else if (getDays > 30 && status == "Đã hủy kích hoạt") {
            // chuyển: đã ngừng kích hoạt -> đã kích hoạt
            updateStatus(ownerId);
        }

    });

});

// thay đổi trạng thái kích hoạt
function updateStatus(ownerId) {
    $.ajax({
        url: "/Owners/UpdateStatus",
        type: "Get",
        dataType: "json",
        data: {
            ownerId: ownerId
        },
        success: function (result) {
            // nếu cập nhật thành công thì 10s sau load lại trang
            if (result.success) {
                window.setTimeout(function () {
                    window.location.reload();
                }, 10000);
            }
        },
        error: function (result) { }
    });
}