document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.querySelector('.input-group input[placeholder="Search for..."]'); // Tìm ô input
    const tableBody = document.getElementById("idTable"); // Lấy tbody
    const tableRows = tableBody.querySelectorAll("tr"); // Lấy tất cả các hàng trong tbody

    // Kiểm tra nếu tìm thấy các phần tử
    if (!searchInput || !tableBody) {
        console.error("Không tìm thấy ô tìm kiếm hoặc bảng dữ liệu.");
        return;
    }

    // Lắng nghe sự kiện nhập liệu
    searchInput.addEventListener("input", function () {
        const searchValue = searchInput.value.trim().toLowerCase(); // Lấy giá trị nhập (trim và chuyển về chữ thường)

        tableRows.forEach(row => {
            const rowText = row.textContent.toLowerCase(); // Nội dung của hàng (chuyển về chữ thường)
            if (rowText.includes(searchValue)) {
                row.style.display = ""; // Hiển thị hàng nếu tìm thấy
            } else {
                row.style.display = "none"; // Ẩn hàng nếu không tìm thấy
            }
        });
    });
});
