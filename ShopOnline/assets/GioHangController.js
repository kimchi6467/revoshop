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
            var listProduct = $('.txtSoLuong');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    iSoluong: $(item).val(),
                    
                    iMaSANPHAM: $(item).data('id')
                    
                });
            });

            $.ajax({
                url: '/GioHang/Update',
                data: {GioHang: JSON.stringify(cartList) },
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