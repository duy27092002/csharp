$(document).ready(function () {

    $("body").on("click", "#create-pn-btn", function () {

        // lấy dữ liệu đầu vào
        let userId = $("#UserId").val();
        let ownerId = $("#OwnerId").val();
        let readerPhone = $("#ReaderPhone").val();
        let bookName = $("#BookName").val();
        let bookAuthor = $("#BookAuthor").val();
        let borrowedDate = $("#BorrowedDate").val();
        let expiryDate = $("#ExpiryDate").val();
        let cost = 0;
        let status = 0;

        // custom lại ngày trả sách
        let getExpiryDate = new Date(expiryDate);
        let dd = String(getExpiryDate.getDate()).padStart(2, '0');
        let mm = String(getExpiryDate.getMonth() + 1).padStart(2, '0'); //January is 0!
        let yyyy = getExpiryDate.getFullYear();

        getExpiryDate = mm + '/' + dd + '/' + yyyy;

        // kiểm tra dữ liệu đầu vào
        if (readerPhone.length == 0 || readerPhone.trim == "" || bookName.length == 0 || bookName.trim == ""
            || bookAuthor.length == 0 || bookAuthor.trim == "" || expiryDate.length == 0 || expiryDate == null) {
            swal({
                title: "Lỗi dữ liệu!",
                text: "Xin hãy nhập đầy đủ dữ liệu",
                icon: "warning",
                buttons: "Đã hiểu",
            });
        }
        else {

            let getDays = Math.round(((new Date(expiryDate)).getTime() - (new Date(borrowedDate)).getTime()) / (1000 * 3600 * 24));

            if (getDays < 0) {
                swal({
                    title: "Lỗi!",
                    text: "Ngày trả đã ở trong quá khứ. Vui lòng kiểm tra lại!",
                    icon: "warning",
                    buttons: "Đã hiểu",
                });
            }
            else {
                if (getDays == 0) {
                    cost = 5000;
                }
                else {
                    cost = 5000 + ((getDays - 1) * 3000);
                }
            }

            // sử dụng ajax lấy mã đọc giả theo số điện thoại
            $.ajax({
                url: "/PromissoryNotes/GetReaderId",
                type: "Post",
                dataType: "json",
                data: {
                    readerPhone: readerPhone
                },
                success: function (result) {
                    if (result.success) {
                        // lấy mã đọc giả
                        $("#ReaderId").val(result.readerId);
                    }
                },
                error: function (result) {
                    if (!result.success) {
                        console.log("Không lấy được mã đọc giả!");
                    }
                }
            });

            // sử dụng ajax lấy mã sách theo tên sách và tác giả
            $.ajax({
                url: "/PromissoryNotes/GetBookId",
                type: "Post",
                dataType: "json",
                data: {
                    bookName: bookName,
                    bookAuthor: bookAuthor
                },
                success: function (result) {
                    if (result.success) {
                        // lấy mã sách
                        $("#BookId").val(result.readerId);
                    }
                },
                error: function (result) {
                    if (!result.success) {
                        console.log("Không lấy được mã sách!");
                    }
                }
            });

            let readerId = $("#ReaderId").val();
            let bookId = $("#BookId").val();

            let pnData = {
                Id: "",
                ReaderId: readerId,
                UserId: userId,
                OwnerId: ownerId,
                BookId: bookId,
                BorrowedDate: borrowedDate,
                ExpiryDate: getExpiryDate,
                Cost: cost,
                Status: status
            }

            $.ajax({
                url: "/PromissoryNotes/Create",
                type: "Post",
                dataType: "json",
                data: {
                    promissoryNote: pnData
                },
                success: function (result) {
                    if (result.success) {
                        window.location("/PromissoryNotes");
                    }
                },
                error: function (result) {
                    if (!result.success) {
                        console.log("Tạo phiếu không thành công!");
                    }
                }
            });
        }
    });

});