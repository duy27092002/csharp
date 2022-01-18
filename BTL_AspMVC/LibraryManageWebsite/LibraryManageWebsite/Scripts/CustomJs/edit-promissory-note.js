$(document).ready(function () {

    let bookName = $("#BookName").val(); // tên sách khi mới load trang edit
    let bookAuthor = $("#BookAuthor").val(); // tên tác giả khi mới load trang edit
    let formatDate = /^([0]?[0-9]|[1][0-2])\/([0]?[0-9]|[1|2][0-9]|[3][0-1])\/([0-9]{4})$/;
    let borrowedDate = $("#BorrowedDate").val();
    let cost = 0;

    // sự kiện thay đổi ngày trả để tính chi phí mượn
    $("body").on("keyup", "#ExpiryDate", function () {

        let expiryDate = $("#ExpiryDate").val();

        // tính khoảng cách thời gian giữa ngày mượn và trả
        let getDays = Math.round(((new Date(expiryDate)).getTime() - (new Date(borrowedDate)).getTime()) / (1000 * 3600 * 24));

        if (getDays == 0) {
            $("#Cost").val(formatNumber(5000));
        }
        else {
            cost = formatNumber(5000 + ((getDays - 1) * 3000));
            $("#Cost").val(cost);
        }

    });

    // sự kiện ấn nút lưu phiếu sau khi sửa
    $("body").on("click", "#update-pn-btn", function () {

        // lấy dữ liệu đầu vào
        let getPNId = $("#Id").val();
        let userId = $("#UserId").val();
        let ownerId = $("#OwnerId").val();
        let readerPhone = $("#ReaderPhone").val();
        //let bookName = $("#BookName").val();
        //let bookAuthor = $("#BookAuthor").val();
        let expiryDate = $("#ExpiryDate").val();
        let status = $("#Status").val();

        // kiểm tra dữ liệu đầu vào
        if (readerPhone.length == 0 || readerPhone.trim == "" || bookName.length == 0 || bookName.trim == ""
            || bookAuthor.length == 0 || bookAuthor.trim == "" || expiryDate.length == 0 || expiryDate == null) {
            swal({
                title: "Lỗi dữ liệu!",
                text: "Xin hãy nhập đầy đủ dữ liệu!",
                icon: "error",
                buttons: "Đã hiểu",
            });
        }
        else {
            // kiểm tra định dạng ngày trả
            // nếu đúng định dạng
            if (formatDate.test(expiryDate.trim())) {
                // custom lại ngày trả sách
                let getExpiryDate = new Date(expiryDate);
                let dd = String(getExpiryDate.getDate()).padStart(2, '0');
                let mm = String(getExpiryDate.getMonth() + 1).padStart(2, '0');
                let yyyy = getExpiryDate.getFullYear();
                getExpiryDate = mm + '/' + dd + '/' + yyyy;

                // tính khoảng cách thời gian giữa ngày mượn và trả
                let getDays = Math.round(((new Date(expiryDate)).getTime() - (new Date(borrowedDate)).getTime()) / (1000 * 3600 * 24));

                if (getDays < 0) {
                    swal({
                        title: "Lỗi!",
                        text: "Ngày trả đã ở trong quá khứ. Vui lòng kiểm tra lại!",
                        icon: "error",
                        buttons: "Đã hiểu",
                    });
                    return;
                }
                else {
                    if (getDays == 0) {
                        cost = formatNumber(5000);
                    }
                    else {
                        cost = formatNumber(5000 + ((getDays - 1) * 3000));
                    }
                }

                let pnData = {
                    Id: getPNId,
                    ReaderId: "",
                    UserId: userId,
                    OwnerId: ownerId,
                    BookId: "",
                    BorrowedDate: borrowedDate,
                    ExpiryDate: getExpiryDate,
                    Cost: cost,
                    Status: status
                }

                // nếu không thay đổi thông tin sách (tức là: vẫn mượn sách cũ)
                if (bookName == $("#BookName").val() && bookAuthor == $("#BookAuthor").val()) {

                    $.ajax({
                        url: "/PromissoryNotes/EditAndDoNotChangeBookInfo",
                        type: "Post",
                        dataType: "json",
                        data: {
                            promissoryNote: pnData,
                            readerPhone: readerPhone,
                            bookName: bookName,
                            bookAuthor: bookAuthor
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
                }
                else { // nếu thay đổi thông tin sách (tức là: đổi sách mới)

                    // lấy dữ liệu sách mới
                    let newBookName = $("#BookName").val();
                    let newBookAuthor = $("#BookAuthor").val();

                    $.ajax({
                        url: "/PromissoryNotes/EditAndChangeBookInfo",
                        type: "Post",
                        dataType: "json",
                        data: {
                            promissoryNote: pnData,
                            readerPhone: readerPhone,
                            newBookName: newBookName,
                            newBookAuthor: newBookAuthor,
                            oldBookName: bookName,
                            oldBookAuthor: bookAuthor
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
                }
            }
            else // nếu sai định dạng
            {
                swal({
                    title: "Lỗi!",
                    text: "Sai định dạng ngày trả. Vui lòng kiểm tra lại!",
                    icon: "error",
                    buttons: "Đã hiểu",
                });
            }
        }
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