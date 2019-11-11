using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MyShop.Backend.Controllers;
using MyShop.Backend.Data;
using MyShop.Backend.Models;
using MyShop.ViewModels;

namespace MyShop.Backend.Tests
{
    public class CategoriesControllerTests : IDisposable
    {
        private SqliteConnection _connection;
        private ApplicationDbContext _dbContext;
        
        public CategoriesControllerTests()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(_connection)
                .Options;
            _dbContext = new ApplicationDbContext(options);
            _dbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }

        [Fact]
        public async Task PostCategory_Success()
        {
            var category = new CategoryCreateRequest { Name = "Test category" };

            var controller = new CategoriesController(_dbContext);
            var result = await controller.PostCategory(category);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<CategoryVm>(createdAtActionResult.Value);
            Assert.Equal("Test category", returnValue.Name);
        }

        [Fact]
        public async Task GetCategory_Success()
        {
            _dbContext.Categories.Add(new Category { Name = "Test brand" });
            await _dbContext.SaveChangesAsync();

            var controller = new CategoriesController(_dbContext);
            var result = await controller.GetCategories();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<CategoryVm>>>(result);
            Assert.NotEmpty(actionResult.Value);
        }
    }
}
