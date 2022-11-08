using NUnit.Framework;
using unit_test.Controllers;
using unit_test.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
using unit_test.Models;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;

namespace RookiesTest
{
	public class RookiesTests
	{
		private RookiesController _rookiesController;
		private Mock<IPersonService> _personService;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        [SetUp]
		public void Setup()
		{
			_personService = new Mock<IPersonService>();
			_rookiesController = new RookiesController(_personService.Object);
		}

		[Test]
		public void Create_RedirectToAction_Valid()
		{
			var mockModel = new PersonCreateModel
			{
				FirstName = "Doan",
				LastName = "Mai",
			};
			var result = _rookiesController.Create(mockModel);

			Assert.IsInstanceOf<RedirectToActionResult>(result);

			Assert.AreEqual((result as RedirectToActionResult).ActionName, "Index");
		}

        //[Test]
        //public void Create_RedirectToAction_InValid()
        //{
        //    var mockModel = new PersonCreateModel
        //    {
		//		FirstName = ""
        //    };
        //    var result = _rookiesController.Create(mockModel);
		//
        //    Assert.IsInstanceOf<ViewResult>(result);
        //}

        [Test]
		public void Create_ReturnView()
		{
			var result = _rookiesController.Create();

			Assert.IsInstanceOf<ViewResult>(result);
		}

		[Test]
		public void Detail_ReturnView_Valid()
		{	
			var index = 0;
			var expectPersonModel = new PersonModel
			{
				FirstName = "Truong",
				LastName = "Ngo"
			};

			_personService.Setup(person => person.GetOne(It.IsAny<int>())).Returns(expectPersonModel);

			var expectPersonDetailModel = new PersonDetailModel
			{
				FirstName = "Truong",
				LastName = "Ngo"
			};

			var result = _rookiesController.Detail(index) as ViewResult;

			Assert.IsNotNull(result);

			var resultPersonDetailModel = result.Model as PersonDetailModel;

			Assert.IsNotNull(resultPersonDetailModel);

			Assert.AreEqual(expectPersonDetailModel.FirstName, resultPersonDetailModel.FirstName);

			Assert.AreEqual(expectPersonDetailModel.LastName, resultPersonDetailModel.LastName);

		}

		[Test]
		public void Detail_ReturnActionResult_InValid()
		{
			_personService.Setup(person => person.GetOne(It.IsAny<int>())).Returns(null as PersonModel);

			var index = 0;
			var result = _rookiesController.Detail(index);

			Assert.AreEqual((result as RedirectToActionResult).ActionName, "Index");
		}

		[Test]
		public void Edit_ReturnActionResult_Valid()
		{
			var index = 0;
			var mockModel = new PersonModel
			{
				FirstName = "Doan",
				LastName = "Mai",
			};
			_personService.Setup(person => person.GetOne(It.IsAny<int>())).Returns(mockModel);

			var result = _rookiesController.Edit(index) ;

			Assert.IsInstanceOf<ViewResult>(result);
		}

		[Test]
		public void Edit_ReturnActionResult_InValid()
		{
			_personService.Setup(person => person.GetOne(It.IsAny<int>())).Returns(null as PersonModel);

			var index = 0;
			var result = _rookiesController.Edit(index);

			Assert.AreEqual((result as RedirectToActionResult).ActionName, "Index");
		}

		[Test]
		public void Update_ReturnActionResult_Valid()
		{
			var index = 0;
			var mockModel = new PersonModel
			{
				FirstName = "Doan",
				LastName = "Mai",
			};
			var mockEditModel = new PersonEditModel
			{
				FirstName = "",
				LastName = "",
			};
			var mockPerson = _personService.Setup(person => person.GetOne(It.IsAny<int>())).Returns(mockModel);

			mockEditModel.FirstName = mockModel.FirstName;
			mockEditModel.LastName = mockModel.LastName;

			var result = _rookiesController.Update(index, mockEditModel);

			Assert.AreEqual((result as RedirectToActionResult).ActionName, "Index");
		}

		[Test]
		public void Update_ReturnView_InValid()
		{
			var mockModel = new PersonEditModel();
			var result = _rookiesController.Update(0, mockModel);

			Assert.IsInstanceOf<ViewResult>(result);
		}

		[Test]
		public void Delete_Person_NotFound()
		{
			var index = -1;
            var result = _rookiesController.Delete(index);

			Assert.IsInstanceOf<NotFoundResult>(result);
		}

		[Test]
		public void Delete_Person_Success()
		{
			var mockModel = new PersonModel
			{
				FirstName = "Doan",
				LastName = "Mai",
			};
			var mockPerson = _personService.Setup(person => person.Delete(It.IsAny<int>())).Returns(mockModel);
			var index = 1;
			var result = _rookiesController.Delete(index);

			Assert.IsNotNull(result);
			Assert.AreEqual((result as RedirectToActionResult).ActionName, "Index");
		}

		[Test]
		public void DeleteAndToRedirectToResultView_Person_NotFound()
		{
			var index = -1;
			var result = _rookiesController.DeleteAndToRedirectToResultView(index);

			Assert.IsInstanceOf<NotFoundResult>(result);
		}

		[Test]
		public void DeleteAndToRedirectToResultView_Person_Success()
		{
			var mockModel = new PersonModel{
				FirstName = "Doan",
				LastName = "Mai",
			};
			var index = 1;
			var mockPerson = _personService.Setup(person => person.Delete(It.IsAny<int>())).Returns(mockModel);

			var result = _rookiesController.DeleteAndToRedirectToResultView(index);

			//var deletedPersonFullName = _httpContextAccessor.HttpContext.Session.GetString("DeletePersonName");

			//Assert.AreEqual(deletedPersonFullName, mockModel.FullName);

            Assert.AreEqual((result as RedirectToActionResult).ActionName, "DeleteResult");

		}
	}
}