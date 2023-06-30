$(document).ready(function () {
  $("#login").validate({
    rules: {
      username: "required",
      password: "required",
    },
    messages: {
      username: "Ingrese un nombre de usuario",
      password: "Ingrese una contraseña",
    },
    errorElement: "span",
    errorPlacement: function (error, element) {
      error.addClass("invalid-feedback");
      error.insertAfter(element);
    },
    highlight: function (element, errorClass, validClass) {
      $(element).addClass("is-invalid").removeClass("is-valid");
    },
    unhighlight: function (element, errorClass, validClass) {
      $(element).removeClass("is-invalid").addClass("is-valid");
    },
  });

  $("#login").on('submit', function(event){
    event.preventDefault();
    if ($("#login").valid()){
      var username = $("#username").val();
      var password = $("#password").val();

      $.ajax({
        type: "GET",
        url: "https://localhost:7024/get/gio_decicco",
        data: username,
        dataType: "json",
        success: function (response) {
          if (response && response.password === password){
            Swal.fire("Inicio de sesion exitoso!");
            setTimeout(function () {
              window.location.replace("menu.html");
            }, 1500);
          }
          else{
            Swal.fire("No se pudo iniciar sesion :(")
          }
        },
        error: function (xhr, status, error){
        }
      });
    }
  })
});
