using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BibliotecaASPNET.Repository;
using BibliotecaASPNET.Models;
using BibliotecaASPNET.Controllers;
using System.Web.Mvc;
using System.Linq;

namespace BibliotecaASPNET.Tests
{
    /// <summary>
    /// Descrição resumida para LivroControllerTests
    /// </summary>
    [TestClass]
    public class LivroControllerTests
    {
        public LivroControllerTests()
        {
            //
            // TODO: Adicionar lógica de construtor aqui
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtém ou define o contexto do teste que provê
        ///informação e funcionalidade da execução de teste atual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de teste adicionais
        //
        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:
        //
        // Use ClassInitialize para executar código antes de executar o primeiro teste na classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para executar código após a execução de todos os testes em uma classe
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize para executar código antes de executar cada teste 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para executar código após execução de cada teste
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void IndexTestMethod()
        {
            // Arrange
            var mockRepository = new Mock<LivroRepository>();

            mockRepository.Setup(repository => repository.ListarLivros()).Returns(new List<Livro>()
            {
                new Livro() {LivroId = 1, LivroTitulo = "Livrao", LivroAutor = "Carao", LivroEditora = "Editorao", LivroAno = 2345},
                new Livro() {LivroId = 2, LivroTitulo = "Livrinho", LivroAutor = "Carinha", LivroEditora = "Editorinha", LivroAno = 2006}
            });

            var controller = new LivroController(mockRepository.Object); 

            // Act

            var result = controller.ListarLivros();

            // Assert

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;
            var model = viewResult.ViewData.Model;
            Assert.IsInstanceOfType(model, typeof(IEnumerable<Livro>));

            var livros = model as IEnumerable<Livro>;
            Assert.AreEqual(2, livros.Count());
        }
    }
}
