function confirmDeactivate(id) {
    if (confirm("Bạn có muốn thay đổi không ? ")) {
        const form = document.createElement("form");
        form.method = "Post";
        form.action = `/Admin/LoaiXeController/DeactivateAsync?id=${id}`;
        document.body.appendChild(form);
        form.submit();
    }
}

/*
document.addEventListener("DOMContentLoaded", function() {
    const addLoaiXeForm = document.getElementById("addLoaiXeForm");

    addLoaiXeForm.onsubmit = function(e) {
        e.preventDefault();

        const formData = new FormData(addLoaiXeForm);

        fetch("/Admin/LoaiXeAdmin", { // Đảm bảo route chính xác
            method: "POST",
            body: JSON.stringify({
                TenLoai: formData.get("TenLoaiXe"),
                SoGhe: parseInt(formData.get("SoGhe"))
            }),
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                if (!response.ok) throw new Error("Failed to add new LoaiXe");
                return response.json();
            })
            .then(data => {
                // Reload lại trang để hiển thị dữ liệu mới
                location.reload();
            })
            .catch(error => {
                alert(error.message);
            });
    };
});*/
