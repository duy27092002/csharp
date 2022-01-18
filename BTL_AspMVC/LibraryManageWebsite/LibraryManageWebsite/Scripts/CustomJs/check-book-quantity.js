$(document).ready(function () {

    // duyệt từng dòng trong danh sách liệt kê
    let trs = $("#book-list-table tbody").find("tr");

    $.each(trs, function (i, e) {

        let bookName = $($(e).find('td')[0]).text().trim();
        let bookAuthor = $($(e).find('td')[1]).text().trim();
        let getQty = $($(e).find('td')[3]).text().trim();
        let status = $($(e).find('td')[5]).text().trim();

        if (getQty > 0 && getQty <= 10) {
            if (status == "Đã hết") {
                // cập nhật trạng thái của sách
                updateStatus(bookName, bookAuthor);
            }

            $(this).find(".msg").text("Sắp hết sách");
        }
        else if (getQty <= 0 && status == "Còn sách") {
            // cập nhật trạng thái của sách khi sách đã hết bằng ajax
            updateStatus(bookName, bookAuthor);
        }
    });

});

// thay đổi trạng thái của sách
function updateStatus(bookName, bookAuthor) {
    $.ajax({
        url: "/Books/UpdateStatus",
        type: "Get",
        dataType: "json",
        data: {
            bookName: bookName,
            bookAuthor: bookAuthor
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