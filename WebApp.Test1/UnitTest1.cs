using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Models;
using WebApp.Models.Entities;



namespace WebApp.Test1
{
    public class UnitTest1
    {
        [Fact]
        public void EditTest()
        {
            Guid V = Guid.Parse("1BC26054-6FDF-404E-43F2-08DC1E71AF72");

            var controlleur = new EtudiantController();

            var result = controlleur.Edit(V);

            result.Should().BeOfType<Task<IActionResult>>();
            Assert.NotNull(result);
        }

        [Fact] 
        public void DeleteTest()
        {
            Guid V = Guid.Parse("1BC26054-6FDF-404E-43F2-08DC1E71AF72");

            var controlleur = new EtudiantController();

            var result = controlleur.Delete(V);

            result.Should().BeOfType<Task<IActionResult>>();
            Assert.NotNull(result);
        }

        [Fact]
        public void ListTest()
        {
            var controlleur = new EtudiantController();

            var result = controlleur.List();

            Assert.NotNull(result);
            result.Should().BeOfType<Task<IActionResult>>();

        }
        //[Fact]
        //public async void ListTest()
        //{
        //    var controlleur = new EtudiantController();

        //    var result = await controlleur.List() as ViewResult;

        //    Assert.NotNull(result);
        //    Assert.Equal(200, result.StatusCode);
        //}

        [Fact]
        public void AddTest()
        {
            var controlleur = new EtudiantController();

            var result = controlleur.Add();

            Assert.NotNull(result);
        }

        [Fact]
        public void Add1Test()
        {
            var etudiant = A.Fake<AddEtudiantViewModel>();

            var controlleur = new EtudiantController();

            var result = controlleur.Add(etudiant);

            Assert.NotNull(result);
        }

        [Fact]
        public void Edit1Test()
        {
            var etudiant = A.Fake<Etudiant>();

            var controlleur = new EtudiantController();

            var result = controlleur.Edit(etudiant);

            Assert.NotNull(result);
        }

        [Fact]
        public void Delete1Test()
        {
            var etudiant = A.Fake<Etudiant>();

            var controlleur = new EtudiantController();

            var result = controlleur.Delete(etudiant);

            Assert.NotNull(result);
        }
    }
}