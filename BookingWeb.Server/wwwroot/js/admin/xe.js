function confirmDeactivate(xeId) {
    if (confirm("Bạn có muốn thay đổi hoạt động của xe này không?")) {
        const form = document.createElement("form");
        form.method = "Post";
        form.action = `/Admin/XeAdmin/DeactivateXeAsync?id=${xeId}`;
        document.body.appendChild(form);
        form.submit();
    }
}
function validateBienSo() {
    var bienSoInput = document.getElementById("bienSo");
    var bienSoValue = bienSoInput.value;
    var regex = /^\d{2}[A-Z]-\d{5}$/;

    if (!regex.test(bienSoValue)) {
        alert("Biển số xe không hợp lệ. Vui lòng nhập theo định dạng");
        return false;
    }
    // const isExistXe = await checkXeExist();
    // if (!isExistXe) {
    //     alert("Xe đã tồn tại. Vui lòng nhập lại.");
    //     return false; // Ngăn không cho gửi form
    // }

    return true;
}

document.getElementById("addXeForm").onsubmit = function () {
    return validateBienSo(); // Gọi hàm kiểm tra khi gửi form
};



// // Fetch API
// async function checkXeExist() {
//     const bienSo = document.getElementById("bienSo").value;
//     const isExistXe = await checkBienSoExists(bienSo);

//     return !isExistXe; // Trả về true nếu không tồn tại, false nếu đã tồn tại
// }

// async function checkBienSoExists(bienSo) {
//     const response = await fetch(`/api/Xe/BienSo?bienSo=${bienSo}`);
//     const data = await response.json();
//     if (data != null) {
//         return false;
//     }
//     return data.true;
// }