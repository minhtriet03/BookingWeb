function confirmDeactivate(userId) {
    if(confirm("Bạn có muốn khóa người dùng này không?")) {
        const form = document.createElement("form");
        form.method = "POST";
        form.action=`/Admin/UserAdmin/DeactivateUserAsync?id=${userId}`;
        document.body.appendChild(form);
        form.submit();
    }
}