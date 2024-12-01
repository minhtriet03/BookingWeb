function confirmDeactivate(xeId) {
    if(confirm("Bạn có muốn thay đổi hoạt động của xe này không?")) {
        const form = document.createElement("form");
        form.method = "Post";
        form.action = `/Admin/XeAdmin/DeactivateXeAsync?id=${xeId}`;
        document.body.appendChild(form);
        form.submit();
    }
}

document.addEventListener('DOMContentLoaded', function () {
    // Gọi hàm để lấy danh sách loại xe
    fetchLoaiXe();
});

// Hàm lấy danh sách loại xe
async function fetchLoaiXe() {
    const apiUrl = 'http://localhost:5108/api/loaixe'; // Thay đổi port nếu cần
    try {
        const response = await fetch(apiUrl);
        if (!response.ok) {
            throw new Error('Mạng lỗi hoặc không tìm thấy dữ liệu');
        }
        const loaixes = await response.json();
        renderLoaiXe(loaixes);
    } catch (error) {
        console.error('Có lỗi xảy ra:', error);
    }
}

// Hàm render loại xe vào select
function renderLoaiXe(loaixes) {
    const loaiXeSelect = document.getElementById('loaiXe');
    loaiXeSelect.innerHTML = ''; // Xóa các tùy chọn cũ

    loaixes.forEach(loaixe => {
        const option = document.createElement('option');
        option.value = loaixe.idLoai; // Giả sử idLoai là giá trị của tùy chọn
        option.textContent = loaixe.tenLoai || 'Chưa có tên'; // Hiển thị tên loại xe
        loaiXeSelect.appendChild(option);
    });
}