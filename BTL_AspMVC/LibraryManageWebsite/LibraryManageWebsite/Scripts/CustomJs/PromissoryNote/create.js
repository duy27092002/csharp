$(document).ready(function () {
    // Tóm tắt thao tác:

    // load các cuốn sách theo tên khi datalist thay đổi giá trị
    $("#book-name").change(function () {
        GetBook(GetBookName());
    });

    // chọn cuốn sách mong muốn thông qua sự kiện checkbox
    $("#btn-modal-accept").click(function () {

        let today = new Date();
        let dd = String(today.getDate()).padStart(2, '0');
        let mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
        let yyyy = today.getFullYear();

        today = mm + '/' + dd + '/' + yyyy;

        let cbs = $("#add-book-table tbody").find(".cb");

        let html = '';

        $.each(cbs, function (i, e) {

            if ($(e).is(':checked')) {

                let tds = $(e).parent().parent().find("td");

                html += '<tr class="text-center">';
                html += '<td>' + $(tds[0]).text() + '</td>';
                html += '<td>' + $(tds[1]).text() + '</td>';
                html += '<td><input type="text" class="form-control bg-white text-center" readonly value="' + today + '" /></td>';
                html += '<td><input type="date" class="form-control text-center" /></td>';
                html += '<td><input type="text" class="form-control text-right bg-white cost" readonly value="150,000" /></td>';
                html += '<td class="text-nowrap" style="width:1px"><a class="btn btn-sm btn-success" disabled>Đang mượn</a></td>';
                html += '<td class="text-nowrap" style="width:1px"><button class="btn btn-sm btn-danger btn-delete-book">Xóa</button></td>';
            }

        });

        $("#book-table").append(html);

        GetBook(GetBookName());
    });

    // xóa sách không mong muốn
    $("body").on('click', '.btn-delete-book', function () {
        $(this).parent().parent().remove();
    });

});

// lấy tên sách từ datalist
function GetBookName() {

    let getBookName = $("#book-name").val();

    return getBookName;
}

// lấy danh sách tên các cuốn sách
//function GetBookName() {
//    let trs = $("#book-table tbody").find("tr");

//    let bookNameArr = [];

//    $.each(trs, function (i, e) {

//        let bookName = $($(e).find("td")[0]).text();

//        bookNameArr.push(bookName);

//    });

//    return bookNameArr;
//}

// lấy danh sách tên tác giả
//function GetAuthor() {
//    let trs = $("#book-table tbody").find("tr");

//    let authorArr = [];

//    $.each(trs, function (i, e) {

//        let author = $($(e).find("td")[1]).text();

//        authorArr.push(author);

//    });

//    return authorArr;
//}

// đổ ra thông tin sách theo tên đã chọn
function GetBook(bookName) {
    $.ajax({

        contentType: 'application/json; charset = utf-8',
        url: "/Books/GetBookListForPromissoryNote",
        type: "Get",
        dataType: "json",
        data: {
            bookName: bookName
        },
        success: function (result) {

            let data = result.data;
            let html = '';

            $.each(data, function (i, e) {
                html += '<tr>' +
                    '<td>' + e.Name + '</td>' +
                    '<td>' + e.Author + '</td>' +
                    '<td>' + e.Publisher + '</td>' +
                    '<td class = "text-center"> <input type = "checkbox" class = "cb" /></td>'
                '<tr>';
            });

            $('#add-book-table tbody').empty().append(html);
        },
        error: function (data) {

            console.log("error");
        }
    });
}