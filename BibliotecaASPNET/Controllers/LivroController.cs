using BibliotecaASPNET.Models;
using BibliotecaASPNET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaASPNET.Controllers
{
    public class LivroController : Controller
    {
        // GET: Livro

        private readonly LivroRepository _repositorio;

        public LivroController(LivroRepository _repositorio)
        {
            this._repositorio = _repositorio;
        }

        [HttpGet]
        public ActionResult ListarLivros()
        {

            ModelState.Clear();

            return View(_repositorio.ListarLivros());
        }

        [HttpGet]
        public ActionResult AdicionarLivro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarLivro(Livro livroObj)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if(_repositorio.AdicionarLivro(livroObj))
                    {
                        ViewBag.Mensagem = "Livro adcionado com sucesso!";

                    }
                }

                return RedirectToAction("ListarLivros");
            }

            catch
            {
                return View("ListarLivros");
            }
        }

        [HttpGet]
        public ActionResult EditarLivro(int id)
        {

            return View(_repositorio.ListarLivros().Find(t => t.LivroId == id));
        }

        [HttpPost]
        public ActionResult EditarLivro(int id, Livro livroObj)
        {
            try
            {

                _repositorio.EditarLivro(livroObj);

                return RedirectToAction("ListarLivros");
            }

            catch
            {
                return View("ListarLivros");
            }
        }

        public ActionResult ExcluirLivroPorId(int id)
        {
            try
            {

                if (_repositorio.ExcluirLivro(id))
                {
                    ViewBag.Mensagem = "Livro excluido com sucesso";
                }

                return RedirectToAction("ListarLivros");
            }

            catch
            {
                return View("Listarlivros");
            }
        }
    }
}