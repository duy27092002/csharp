$(document).ready(function () {

    // ấn nút thêm sản phẩm ở thêm mới hóa đơn nhập
    $("#btn-add-items").click(function () {

        getProducts(getIds(), getCategoryId());

        $("#modal-data").modal('toggle');
    });

    // nút hủy ở modal để thoát ra
    $("#btn-close").click(function () {
        $("#modal-data").modal('toggle');
    });

    // dropdown thay đổi với giá trị tương ứng theo mã loại giày
    $('#select-category').change(function () {
        getProducts(getIds(), getCategoryId());
    });

    // nút thêm khi chọn xong sản phẩm
    $('#btn-modal-accept').click(function () {
        // tìm sản phẩm được chọn (được tích trong ô checkbox)
        var cbs = $('#tb-add-items tbody').find('.cb');

        var html = '';

        // hiển thị dữ liệu ra bảng "Danh mục sản phẩm" theo cột
        $.each(cbs, function (i, e) {
            if ($(e).is(':checked')) {
                var tds = $(e).parent().parent().find('td');
                html += '<tr>' +
                    '<td>' + $(tds[0]).text() + '</td>' +
                    '<td>' + $(tds[1]).text() + '</td>' +
                    '<td>' + $('#select-category option:selected').text() + '</td>' +
                    '<td>' + $(tds[2]).text() + '</td>' +
                    '<td> <input class = "form-control num text-center" /></td>' +
                    '<td> <input class = "form-control num text-center" /></td>' +
                    '<td> <input class = "form-control num text-center" readonly /></td>' +
                    '<td style = "width:1px;"><button class = "btn btn-sm btn-danger btn-delete">Xóa</button></td>' +
                    '</tr>'
            }
        });

        console.log(html);
        // in dữ liệu vào bảng "Danh mục sản phẩm"
        $('#tb-items').append(html);

        getProducts(getIds(), getCategoryId());
    });

    // xóa sản phẩm k mong muốn khi đã thêm vào bảng "Danh mục sản phẩm"
    $('body').on('click', '.btn-delete', function () {
        $(this).parent().parent().remove();

        // Tính lại tổng tiền
        getTotal();
    });

    // bắt sự kiện gõ số lượng và số tiền trong bảng "Danh mục sản phẩm"
    $('body').on('keyup', '.num', function () {
        var total = 0;

        $(this).val(formatNumber(formatString($(this).val())));

        var tds = $($(this).parent().parent()).find('td');

        var value = parseInt(formatString($(tds[tds.length - 3]).children(0).val())) *
            parseInt(formatString($(tds[tds.length - 4]).children(0).val()))

        $(tds[tds.length - 2]).children(0).val(formatNumber(value));

        getTotal();
    });

    // nút tạo hóa đơn nhập
    $('#btn-submit').click(function () {
        // tạo ra đối tượng hóa đơn nhập
        var info = {
            time: $('#time').val(),
            supplierID: $('#supplierID').val(),
            staffID: $('#staffID').val()
        };

        var details = [];

        // tìm ra các dữ liệu trong bảng chi tiết
        var trs = $('#tb-items tbody').find('tr');

        // tạo ra danh sách đối tượng chi tiết hóa đơn nhập
        $.each(trs, function (i, e) {
            // tìm tất cả các cột dữ liệu trong bảng
            var tds = $(e).find('td');

            var detail = {
                watchID: $(tds[0]).text(),
                amount: formatString($($(tds[4]).children(0)).val()),
                price: formatString($($(tds[5]).children(0)).val())
            };

            details.push(detail);
        });

        add(info, details);
    });
});

// lấy id của sản phẩm
function getIds() {
    var trs = $('#tb-items tbody').find('tr');
    var arr = [];
    $.each(trs, function (i, e) {
        var val = parseInt($($(e).find('td')[0]).text());
        arr.push(val);
    });
    console.log(arr);
    return arr;
}

// lấy mã loại đồng hồ để truyền vào getProducts() với vai trò là malg
function getCategoryId() {
    return $('#select-category').val();
}

// lấy mã (ids), tên đồng hồ, tên nhà sản xuất theo danh mục đồng hồ (sử dụng ajax)
function getProducts(ids, categoryId) {
    $.ajax({
        contentType: 'application/json; charset = utf-8',
        url: "/Product/GetProByCategoryID",
        type: "Get",
        dataType: "json",
        data: {
            json: JSON.stringify(ids),
            categoryId: categoryId
        },
        success: function (result) {
            var data = result.data;
            var html = '';
            $.each(data, function (i, e) {
                html += '<tr>' +
                    '<td>' + e.id + '</td>' +
                    '<td>' + e.name + '</td>' +
                    '<td>' + e.producer + '</td>' +
                    '<td class = "text-center"> <input type = "checkbox" class = "cb" /></td>'
                '<tr>';
            });
            $('#tb-add-items tbody').empty().append(html);
            console.log(data);
        },
        error: function (data) {
            console.log("error");
        }
    });
}

// định dạng số (ví dụ: 1000 => 1,000)
function formatNumber(nStr) {
    var groupSeperate = ',';
    var x = formatString(nStr);
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x)) {
        x = x.replace(rgx, '$1' + groupSeperate + '$2');
    }
    return x;
}

// biến đỗi chuỗi số thành dạng số (ví dụ: 1,000 => 1000)
function formatString(money) {
    var x = '';
    var arr = money.toString().split(',');
    arr.forEach((str) => {
        x += str;
    });
    return x;
}

// tính tổng tiền = giá tiền (/1sp) * số lượng sp
// nếu có nhiều sp thì cộng dồn tổng tiền của mỗi sp
function getTotal() {
    var trs = $('#tb-items tbody').find('tr');
    var total = 0;
    $.each(trs, function (i, e) {
        var tds = $(e).find('td');
        var val = $(tds[tds.length - 2]).children(0).val();
        total += parseInt(formatString(val));
    });
    $('#total').text("Tổng Tiền: " + formatNumber(total));
}

// hàm thêm hóa đơn nhập khi đã có đủ dữ liệu, chuẩn bị in ra Index
function add(info, details) {
    $.ajax({
        url: "/Inport/CreateConfirmed/",
        type: "POST",
        dataType: "json",
        data: {
            info: info,
            json: JSON.stringify(details)
        },
        success: function (result) {
            console.log(result.msg);
            window.location = "/Inport/Index";
        },
        error: function (data) {
            console.log("error");
        }
    });
}