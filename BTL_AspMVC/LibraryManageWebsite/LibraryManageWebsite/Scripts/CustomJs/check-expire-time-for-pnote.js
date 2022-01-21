$(document).ready(function () {

    let today = new Date();
    let dd = String(today.getDate()).padStart(2, '0');
    let mm = String(today.getMonth() + 1).padStart(2, '0');
    let yyyy = today.getFullYear();

    today = mm + '/' + dd + '/' + yyyy;

    let trs = $(".pn-table tbody").find("tr");

    $.each(trs, function (i, e) {

        let expireTime = $($(e).find('td')[4]).text().trim();
        let status = $($(e).find('td')[6]).text().trim();
        let pnId = $($(e).find(".pnId")).val();

        let getDays = Math.round((new Date(expireTime)).getTime() - (new Date(today)).getTime()) / (1000 * 3600 * 24);

        // nếu thời hạn còn nhỏ hơn 1 ngày thì sẽ cảnh báo
        if (getDays >= 0) {

            if (getDays <= 1 && status == "Trễ hạn") {
                // cập nhật thành trạng thái đang mượn
                updateStatus(pnId);
            }
            else if (getDays <= 1 && status == "Đang mượn") {
                $(this).find(".msg").text("Sắp hết hạn");
            }
            else if (getDays > 1 && status == "Trễ hạn") {
                // cập nhật thành trạng thái đang mượn
                updateStatus(pnId);
            }

        }

        // nếu đã trễ hạn thì cảnh báo đỏ
        if (getDays < 0 && status == "Đang mượn") {
            // cập nhật thành trạng thái trễ hạn
            updateStatus(pnId);
        }

    });

});

// thay đổi trạng thái mượn sách
function updateStatus(pnId) {
    $.ajax({
        url: "/PromissoryNotes/UpdateStatus",
        type: "Get",
        dataType: "json",
        data: {
            pnId: pnId
        },
        success: function (result) {
            // nếu cập nhật thành công thì 10s sau load lại trang
            if (result.success) {
                window.setTimeout(function () {
                    window.location.reload();
                }, 10000);
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
}