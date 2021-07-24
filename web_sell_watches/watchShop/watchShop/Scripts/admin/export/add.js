$(document).ready(function () {

    // ấn nút thêm sản phẩm ở thêm mới hóa đơn xuất
    $("#btn-add-items").click(function () {

        //getGiay(getIds(), getLoaiGiayId());

        $("#modal-data").modal('toggle');
    });

    // nút hủy ở modal để thoát ra
    $("#btn-close").click(function () {
        $("#modal-data").modal('toggle');
    });

    // dropdown thay đổi với giá trị tương ứng theo mã loại giày
    $('#select-category').change(function () {
        //getGiay(getIds(), getLoaiGiayId());
    });
})