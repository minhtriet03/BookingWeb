$(document).ready(function () {

    $('#tinhThanhDi, #tinhThanhDen').change(function() {
        var tinhThanhDi = $('#tinhThanhDi').val();
        var tinhThanhDen = $('#tinhThanhDen').val();

        if (tinhThanhDi && tinhThanhDen && tinhThanhDi === tinhThanhDen) {
            Swal.fire({
                icon: 'error',
                title: 'Lỗi',
                text: 'Điểm đi và điểm đến không được trùng nhau!'
            });

            // Reset select điểm đến
            $('#tinhThanhDen').val('');
        }
    });

    $('#benXeDi, #benXeDen ').change(function () {
        var benXeDi = $('#benXeDi').val();
        var benXeDen = $('#benXeDen').val();
        console.log(benXeDi);
        console.log(benXeDen);

        if (benXeDi && benXeDen ) {
            $.ajax({
                url : '/api/TuyenDuong/GetByConditional',
                type : 'GET',
                data : {
                    idDiemDi : benXeDi,
                    idDiemDen : benXeDen
                },
                success: function (response) {
                    // Kiểm tra cấu trúc response
                    if (response.$values) {
                        // Kiểm tra mảng có phần tử không
                        if (response.$values.length > 0) {
                            Swal.fire({
                                icon: 'warning',
                                title: 'Cảnh báo',
                                text: 'Tuyến đường này đã tồn tại!'
                            });

                            // Optional: Reset select
                            $('#benXeDen').val('');
                        }
                    } else if (response.idTuyenDuong) {
                        // Trường hợp trả về object duy nhất
                        Swal.fire({
                            icon: 'warning',
                            title: 'Cảnh báo',
                            text: 'Tuyến đường này đã tồn tại!'
                        });

                        // Optional: Reset select
                        $('#benXeDen').val('');
                    }
                },
                error: function(xhr, status, error) {
                    console.error('Lỗi kiểm tra tuyến đường:', error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Lỗi',
                        text: 'Có lỗi xảy ra khi kiểm tra tuyến đường'
                    });
                }
            })
        }
    })


    $('#tinhThanhDi').change(function() {
        var tinhThanhId = $(this).val();

        if(tinhThanhId) {
            $.ajax({
                url: '/api/Benxe/BenXeByTinhThanh',
                type: 'GET',
                data: { idTinhThanh: tinhThanhId },
                dataType: 'json', // Thêm dòng này
                success: function(data) {
                    $('#benXeDi').empty();
                    $('#benXeDi').append('<option value="">Chọn bến xe</option>');

                    // Kiểm tra cấu trúc dữ liệu
                    if (data.$values) {
                        $.each(data.$values, function(index, item){
                            $('#benXeDi').append(
                                '<option value="' + item.idBenXe + '">' +
                                item.tenBenXe +
                                '</option>'
                            );
                        });
                    } else {
                        console.log('Dữ liệu không đúng định dạng', data);
                    }
                },
                error: function(xhr, status, error) {
                    console.log('Lỗi AJAX:', status, error);
                    console.log('Chi tiết lỗi:', xhr.responseText);
                }
            });
        } else {
            $('#benXeDi').empty();
            $('#benXeDi').append('<option value="">Chọn bến xe</option>');
        }
    });
    $('#tinhThanhDen').change(function() {
        var tinhThanhId = $(this).val();
        if (tinhThanhId) {
            $.ajax({
                url: '/api/Benxe/BenXeByTinhThanh',
                type: 'GET',
                data: { idTinhThanh: tinhThanhId },
                dataType: 'json',
                success: function(data) {
                    $('#benXeDen').empty();
                    $('#benXeDen').append('<option value="">Chọn bến xe</option>');

                    // Kiểm tra cấu trúc dữ liệu
                    if (data.$values) {
                        $.each(data.$values, function(index, item){
                            $('#benXeDen').append(
                                '<option value="' + item.idBenXe + '">' +
                                item.tenBenXe +
                                '</option>'
                            );
                        });
                    } else {
                        console.log('Dữ liệu không đúng định dạng', data);
                    }
                },
                error: function(xhr, status, error) {
                    console.log('Lỗi AJAX:', status, error);
                    console.log('Chi tiết lỗi:', xhr.responseText);
                }
            })
        }
    })
});

function confirmDeactivate(id) {
    if (confirm("Bạn có muốn thay đổi không ? ")) {
        const form = document.createElement("form");
        form.method = "Post";
        form.action = `/Admin/TuyenDuongAdmin/DeactivateAsync?id=${id}`;
        document.body.appendChild(form);
        form.submit();
    }
}