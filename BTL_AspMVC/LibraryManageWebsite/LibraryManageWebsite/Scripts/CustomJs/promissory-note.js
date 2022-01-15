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
                text: "Xin hãy nhập đầy đủ dữ liệu!",
                icon: "error",
                buttons: "Đã hiểu",
            });
        }
        else {

            let getDays = Math.round(((new Date(expiryDate)).getTime() - (new Date(borrowedDate)).getTime()) / (1000 * 3600 * 24));

            if (getDays < 0) {
                swal({
                    title: "Lỗi!",
                    text: "Ngày trả đã ở trong quá khứ. Vui lòng kiểm tra lại!",
                    icon: "error",
                    buttons: "Đã hiểu",
                });
            }
            else {
                if (getDays == 0) {
                    cost = 5,000;
                }
                else {
                    cost = formatNumber(5000 + ((getDays - 1) * 3000));
                }
            }

            let pnData = {
                Id: "",
                ReaderId: "",
                UserId: userId,
                OwnerId: ownerId,
                BookId: "",
                BorrowedDate: borrowedDate,
                ExpiryDate: getExpiryDate,
                Cost: cost,
                Status: status
            }

            $.ajax({
                url: "/PromissoryNotes/CreateConfirmed",
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
                },
                error: function (result) {
                    if (result.error) {
                        swal({
                            title: "Lỗi!",
                            text: "" + result.mess,
                            icon: "error",
                            buttons: "Đã hiểu",
                        });
                    }
                }
            });
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