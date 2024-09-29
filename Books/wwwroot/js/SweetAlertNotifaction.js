function notification(title, text, icon) {
    Swal.fire({
        title: title,
        text: text,
        icon: icon,
        confirmButton: 'OK'
    });
}
