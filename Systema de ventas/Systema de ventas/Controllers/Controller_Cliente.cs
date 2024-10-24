using Systema_de_ventas.Datos;
using Systema_de_ventas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Systema_de_ventas.Controllers
{
    public class Controller_Cliente : Controller
    {
        CRUD_cliente _CRUD_Cliente = new CRUD_cliente();

        // Método para listar clientes
        public IActionResult Listar()
        {
            var oLista = _CRUD_Cliente.Listar();
            return View(oLista);
        }

        // Método para cargar la vista de guardar
        public IActionResult Guardar()
        {
            return View(new Modelo_cliente());
        }

        [HttpPost]
        public IActionResult Guardar(Modelo_cliente oCliente)
        {
            if (!ModelState.IsValid)
                return View(oCliente);

            var respuesta = _CRUD_Cliente.Registrar(oCliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View(oCliente);
        }

        // Método para cargar la vista de edición
        public IActionResult Editar(int ClienteId)
        {
            var oCliente = _CRUD_Cliente.Detalle(ClienteId);
            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Editar(Modelo_cliente oCliente)
        {
            if (!ModelState.IsValid)
                return View(oCliente);

            var respuesta = _CRUD_Cliente.Editar(oCliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View(oCliente);
        }

        // Método para cargar la vista de confirmación de eliminación
        public IActionResult Eliminar(int ClienteId)
        {
            var oCliente = _CRUD_Cliente.Detalle(ClienteId);
            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Eliminar(Modelo_cliente oCliente)
        {
            var respuesta = _CRUD_Cliente.Borrar(oCliente.ClienteId);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View(oCliente);
        }

        public IActionResult Detalle(int ClienteId)
        {
            var cliente = _CRUD_Cliente.Detalle(ClienteId); // Obtener cliente por su ID
            if (cliente == null)
            {
                return NotFound(); // Retorna 404 si el cliente no existe
            }

            // Si es una solicitud AJAX, devuelve solo el contenido del cliente
            return PartialView(cliente); // Retorna la vista parcial con el modelo cliente
        }



    }
}
