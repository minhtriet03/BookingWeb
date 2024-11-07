function createPagination(data, tableId, paginationId, itemsPerPage, editAction, editController ) {
    // Lấy các phần tử HTML cần thiết
    const table = document.getElementById(tableId);
    const pagination = document.getElementById(paginationId);
    let currentPage = 1;
    // Tính tổng số trang
    let totalPages = Math.ceil(data.length / itemsPerPage);

    function displayPage(page) {
        currentPage = page;
        // Xóa nội dung hiện tại của bảng
        table.innerHTML = '';
        // Tính chỉ số bắt đầu và kết thúc cho trang hiện tại
        const startIndex = (page - 1) * itemsPerPage;
        const endIndex = startIndex + itemsPerPage;

        // Lặp qua dữ liệu và tạo các hàng cho bảng
        for (let i = startIndex; i < endIndex && i < data.length; i++) {
            const row = table.insertRow();
            console.log(data[i].idUser);
            for (let prop in data[i]) {
                if (data[i].hasOwnProperty(prop)) {
                    const cell = row.insertCell();
                    cell.textContent = data[i][prop];
                }
            }
            // Thêm các nút hành động (Edit, Delete)
            const actionsCell = row.insertCell();
            const editButton = document.createElement('a');
            /*editButton.setAttribute('asp-action', editAction);
            editButton.setAttribute('asp-controller', editController);
            editButton.setAttribute('asp-route-id', data[i].idUser);*/
            editButton.href = '/api/QuanLyNguoiDung/Edit?id=' + data[i].idUser;
            editButton.classList.add('btn', 'btn-primary', 'btn-sm');
            editButton.textContent = 'Edit';
            const deleteButton = document.createElement('a');
            deleteButton.href = '#';
            deleteButton.classList.add('btn', 'btn-danger', 'btn-sm');
            deleteButton.textContent = 'Delete';
            actionsCell.appendChild(editButton);
            actionsCell.appendChild(deleteButton);
        }

        // Xóa nội dung hiện tại của phần phân trang
        pagination.innerHTML = '';

        // Tạo nút "Previous"
        const prevButton = document.createElement('a');
        prevButton.href = '#';
        prevButton.classList.add('page-link');
        prevButton.textContent = 'Previous';
        prevButton.addEventListener('click', () => {
            if (currentPage > 1) {
                displayPage(currentPage - 1);
            }
        });
        const prevItem = document.createElement('li');
        prevItem.classList.add('page-item');
        if (currentPage === 1) {
            prevItem.classList.add('disabled');
        }
        prevItem.appendChild(prevButton);
        pagination.appendChild(prevItem);

        // Tạo các nút số trang
        for (let i = 1; i <= totalPages; i++) {
            const pageLink = document.createElement('a');
            pageLink.href = '#';
            pageLink.classList.add('page-link');
            pageLink.textContent = i;
            pageLink.addEventListener('click', () => {
                if (i !== currentPage) {
                    displayPage(i);
                }
            });
            const pageItem = document.createElement('li');
            pageItem.classList.add('page-item');
            if (i === currentPage) {
                pageItem.classList.add('active');
            }
            pageItem.appendChild(pageLink);
            pagination.appendChild(pageItem);
        }

        // Tạo nút "Next"
        const nextButton = document.createElement('a');
        nextButton.href = '#';
        nextButton.classList.add('page-link');
        nextButton.textContent = 'Next';
        nextButton.addEventListener('click', () => {
            if (currentPage < totalPages) {
                displayPage(currentPage + 1);
            }
        });
        const nextItem = document.createElement('li');
        nextItem.classList.add('page-item');
        if (currentPage === totalPages) {
            nextItem.classList.add('disabled');
        }
        nextItem.appendChild(nextButton);
        pagination.appendChild(nextItem);
    }

    // Hiển thị trang đầu tiên khi hàm được gọi
    displayPage(currentPage);
}