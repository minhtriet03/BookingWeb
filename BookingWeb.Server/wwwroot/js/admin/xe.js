function confirmDeactivate(xeId) {
    if(confirm("Bạn có muốn thay đổi hoạt động của xe này không?")) {
        const form = document.createElement("form");
        form.method = "Post";
        form.action = `/Admin/XeAdmin/DeactivateXeAsync?id=${xeId}`;
        document.body.appendChild(form);
        form.submit();
    }
}