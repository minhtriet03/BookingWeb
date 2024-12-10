function confirmDeactivate(id) {
    if (confirm("Bạn có muốn thay đổi không ? ")) {
        const form = document.createElement("form");
        form.method = "Post";
        form.action = `/Admin/TaiKhoanAdmin/DeactivateAsync?id=${id}`;
        document.body.appendChild(form);
        form.submit();
    }
}