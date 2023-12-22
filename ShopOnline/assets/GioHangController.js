var GioHang = {
    init: function () {
        GioHang.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });

        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });

        $('#btnUpdate').off('click').on('click', function () {
            var listSanPham = $('.txtSoLuong');
            var GioHangList = [];
            $.each(listSanPham, function (_i, item) {
                GioHangList.push({
                    SoLuong: $(item).val(),
                    
                    SANPHAM: {
                        MaSANPHAM: $(item).data('maSanPham')
                    }
                    
                });
            });

            $.ajax({
                url: '/GioHang/Update',
                data: { GioHang: JSON.stringify(GioHangList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });


        $('#btnDeleteAll').off('click').on('click', function () {


            $.ajax({
                url: '/GioHang/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });
    }
}
GioHang.init();