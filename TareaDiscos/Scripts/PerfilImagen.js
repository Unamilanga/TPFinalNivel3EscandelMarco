<script>
    function activarUrl() {
    const url = prompt("Ingrese la URL de la imagen:");
    if (url) {
        const input = document.getElementById("txtUrl");
    const img = document.getElementById("previewImg");
    input.value = url;
    img.src = url;
    }
}

    window.addEventListener("DOMContentLoaded", function () {
    const input = document.getElementById("txtUrl");
    const img = document.getElementById("previewImg");

    // Mostrar el valor actual al cargar
    if (input && input.value.trim()) {
        img.src = input.value;
    } else {
        img.src = "https://via.placeholder.com/150";
    }

    // Escuchar cambios en tiempo real (si el usuario edita a mano)
    input.addEventListener("input", function () {
        img.src = input.value || "https://via.placeholder.com/150";
    });
});

</script>
