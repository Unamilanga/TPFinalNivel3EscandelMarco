window.addEventListener('DOMContentLoaded', function () {
    var btn = document.getElementById('btnShowPass');
    var pwd = document.getElementById('txtContraseña');
    if (btn && pwd) {
        btn.addEventListener('mousedown', function () {
            pwd.type = 'text';
        });
        btn.addEventListener('mouseup', function () {
            pwd.type = 'password';
        });
        btn.addEventListener('mouseleave', function () {
            pwd.type = 'password';
        });
        btn.addEventListener('touchstart', function () {
            pwd.type = 'text';
        });
        btn.addEventListener('touchend', function () {
            pwd.type = 'password';
        });
    }
});