using Xunit;
using Laboratorium_3___Homework.Controllers;
using Laboratorium_3___Homework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using ProjectData;
using Microsoft.Extensions.Caching.Memory;

namespace ProjectTests
{
    public class PhotoControllerTest
    {
        private PhotoController _controller;
        private IPhotoService _service;

        public PhotoControllerTest()
        {
            AppDbContext dbcontext = new AppDbContext();
            IMemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());
            _service = new MemoryPhotoService(dbcontext, memoryCache);
            _service.Add(new Photo() { Description="abc", AuthorId=101 });
            _service.Add(new Photo() { Description = "abcd" });
            _controller = new PhotoController(_service);
        }

        [Fact]
        public void IndexTest()
        {
            var result = _controller.PagedIndex(101);
            Assert.IsType<ViewResult>(result);

            var view = result as ViewResult;
            Assert.IsType<List<Photo>>(view.Model);

            var list = view.Model as List<Photo>;
            Assert.Equal(_service.FindAll().Count, list.Count());
        }

        
    }
}
