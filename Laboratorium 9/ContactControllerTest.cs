using Laboratorium_3___App.Controllers;
using Laboratorium_3___App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_9
{
    public class ContactControllerTest
    {
        private ContactController _controler;
        private IContactService _service;

        public ContactControllerTest()
        {
            IDateTimeProvider dateTimeProvider = new CurrentDateTimeProvider();
            _service = new MemoryContactService(dateTimeProvider);
            _service.Add(new Contact() { Name = "Test1" });
            _service.Add(new Contact() { Name = "Test2" });
            _controler = new ContactController(_service);
        }

        [Fact]
        public void IndexTest()
        {
            var result = _controler.Index();
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            Assert.IsType<List<Contact>>(view.Model);
            var list = view.Model as List<Contact>;
            Assert.Equal(_service.FindAll().Count, list.Count());
        }

        [Fact]
        public void DetailsTestForNonExistingContacts()
        {
            var result = _controler.Details(3);
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void DetailsTestForExistingContacts(int id)
        {
            var result = _controler.Details(id);
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            Assert.IsType<Contact>(view.Model);
            var contact = view.Model as Contact;
            Assert.Equal(id, contact.Id);
        }

        [Fact]
        public void DeleteTest()
        {

            var contact = new Contact() { Id = 1 };
            var prev = _service.FindById(contact.Id);
            Assert.Equal(prev.Id, contact.Id);
            //pobrac obiektow ile jest
            int contactQuantity = _service.FindAll().Count;
            //wywolac metoda na controlerze delete z istniejacym uzytkownikiem
            _controler.Delete(_service.FindById(1));
            //czy licznik wszzystkich obiektow jest o 1 mniejszy
            int contactQuantity2 = _service.FindAll().Count;
            Assert.Equal(contactQuantity - 1 , contactQuantity2);
            Assert.Null(_service.FindById(1));

        }
    }
}