using Microsoft.VisualStudio.TestTools.UnitTesting;
using NerdStore.Modulo.Catalogo.Domain.Entites;
using NerdStore.Modulo.Catalogo.Domain.ValueObjects;
using NerdStore.Shared.DomainObjects;
using System;

namespace NerdStore.Catalogo.Domain.Tests
{
    [TestClass]
    public class ProdutoTests
    {
        [TestMethod]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {
            var ex = Assert.ThrowsException<DomainException>(() =>
                new Produto(string.Empty, "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", 0, new DimensaoVO(1, 1, 1))
            );

            Assert.AreEqual("O campo Nome do produto não pode estar vazio", ex.Message);

            ex = Assert.ThrowsException<DomainException>(() =>
                new Produto("Nome", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", 0, new DimensaoVO(1, 1, 1))
            );

            Assert.AreEqual("O campo Descricao do produto não pode estar vazio", ex.Message);

            ex = Assert.ThrowsException<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 100, Guid.Empty, DateTime.Now, "Imagem", 0, new DimensaoVO(1, 1, 1))
            );

            Assert.AreEqual("O campo CategoriaId do produto não pode estar vazio", ex.Message);

            ex = Assert.ThrowsException<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 0, Guid.NewGuid(), DateTime.Now, "Imagem", 0, new DimensaoVO(1, 1, 1))
            );

            Assert.AreEqual("O campo Valor do produto não pode ser menor igual a 0", ex.Message);

            ex = Assert.ThrowsException<DomainException>(() =>
               new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, 0, new DimensaoVO(1, 1, 1))
           );

            Assert.AreEqual("O campo Imagem do produto não pode estar vazio", ex.Message);

            ex = Assert.ThrowsException<DomainException>(() =>
               new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, 0, new DimensaoVO(0, 1, 1))
           );

            Assert.AreEqual("O campo Altura não pode ser menor ou igual a 0", ex.Message);

            ex = Assert.ThrowsException<DomainException>(() =>
               new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, 0, new DimensaoVO(1, 0, 1))
           );

            Assert.AreEqual("O campo Largura não pode ser menor ou igual a 0", ex.Message);

            ex = Assert.ThrowsException<DomainException>(() =>
               new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, 0, new DimensaoVO(1, 1, 0))
           );

            Assert.AreEqual("O campo Profundidade não pode ser menor ou igual a 0", ex.Message);


        }
    }
}
