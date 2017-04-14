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

        private LivroRepository _repositorio;

        [HttpGet]
        public ActionResult ListarLivros()
        {
            _repositorio = new LivroRepository();

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
                    _repositorio = new LivroRepository();

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
            _repositorio = new LivroRepository();

            return View(_repositorio.ListarLivros().Find(t => t.LivroId == id));
        }

        [HttpPost]
        public ActionResult EditarLivro(int id, Livro livroObj)
        {
            try
            {
                _repositorio = new LivroRepository();

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
                _repositorio = new LivroRepository();

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