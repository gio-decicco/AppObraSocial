$(document).ready(function () {
  $("#consultar").click(function () {
    $("#tablaClientes").empty();
    $.ajax({
      type: "GET",
      url: "https://localhost:7024/api/Clientes/getAll",
      dataType: "json",
      success: function (response) {
        for (let index = 0; index < response.length; index++) {
          $("#tablaClientes").append(
            "<tr> <th>" +
              response[index].id +
              "</th>" +
              "<td>" +
              response[index].name +
              "</td>" +
              "<td>" +
              response[index].surname +
              "</td>" +
              "<td>" +
              response[index].email +
              "</td>" +
              "<td>" +
              response[index].idPlanNavigation.descripcion +
              "</td> </tr>"
          );
        }
      },
    });
    mostrarElemento("#listaClientes");
  });

  $("#consultarPlanes").click(function () {
    $("#tablaPlanes").empty();
    $.ajax({
      type: "GET",
      url: "https://localhost:7024/api/Planes/getAll",
      success: function (response) {
        for (let index = 0; index < response.length; index++) {
          $("#tablaPlanes").append(
            "<tr> <th>" +
              response[index].idPlan +
              "</th>" +
              "<td>" +
              response[index].descripcion +
              "</td>" +
              "<td>" +
              response[index].cuota +
              "</td>"
          );
        }
      },
    });
    mostrarElemento("#verPlanes");
  });

  var listaElementos = [
    "#nuevoCliente",
    "#listaClientes",
    "#verPlanes",
    "#seccionNuevoPlan",
  ];

  function mostrarElemento(idElemento) {
    for (var e of listaElementos) {
      $(e).hide();
    }
    if (idElemento != null) {
      $(idElemento).show();
    }
  }

  $("#nuevoPlan").click(function (e) {
    mostrarElemento("#seccionNuevoPlan");
  });

  $("#formularioPlan").validate({
    rules:{
      descripcion: "required",
      cuota: "required"
    },
    messages:{
      descripcion: "Por favor ingrese una descripción",
      cuota: "Por favor ingrese un valor de plan"
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
  })

  $("#formularioPlan").submit(function(event){
    event.preventDefault();
    if ($("#formularioPlan").valid()){
      var descripcionValor = $("#descripcion").val();
    var cuotaValor = $("#cuota").val();

    var plane = {
      descripcion: descripcionValor,
      cuota: cuotaValor,
    };

    $.ajax({
      type: "POST",
      url: "https://localhost:7024/api/Planes/savePlan",
      contentType: "application/json",
        data: JSON.stringify(plane),
      success: function (response) {
        Swal.fire("Se registró el nuevo plan!")
        setTimeout(function(){
          mostrarElemento();
        }, 1500);
      }
    });
    }
    
  })

  $("#nuevo").click(function () {
    $("#plan").empty();
    $.ajax({
      type: "GET",
      url: "https://localhost:7024/api/Planes/getAll",
      dataType: "json",
      success: function (response) {
        for (let index = 0; index < response.length; index++) {
          $("#plan").append(
            "<option value='" +
              response[index].idPlan +
              "'>" +
              response[index].descripcion +
              "</option>"
          );
        }
      },
    });
    mostrarElemento("#nuevoCliente");
  });

  $("#formularioCliente").validate({
    rules: {
      name: "required",
      surname: "required",
      email: "required",
      document: "required",
      plan: "required",
    },
    messages: {
      name: "Ingrese un nombre por favor",
      surname: "Ingrese un apellido por favor",
      email: "Seleccione un email por favor",
      document: "Ingrese un número de documento",
      plan: "Seleccione un plan",
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

  $("#formularioCliente").submit(function (event) {
    event.preventDefault();
    if ($("#formularioCliente").valid()) {
      var name = $("#name").val();
      var surname = $("#surname").val();
      var email = $("#email").val();
      var documento = $("#document").val();
      var idPlan = $("#plan").val();

      var cliente = {
        name: name,
        surname: surname,
        email: email,
        document: documento,
        idPlan: idPlan,
      };

      $.ajax({
        type: "POST",
        url: "https://localhost:7024/api/Clientes/saveCliente",
        contentType: "application/json",
        data: JSON.stringify(cliente),
        success: function () {
          Swal.fire({
            icon: "success",
            title: "Cliente registrado",
            text: "El cliente se ha registrado exitosamente.",
          });

          mostrarElemento();
        },
        error: function () {
          Swal.fire({
            icon: "error",
            title: "Error al crear el socio",
            text: "Ha ocurrido un error al intentar crear el socio.",
          });
        },
      });
    }
  });
});
