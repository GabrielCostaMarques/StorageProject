using Microsoft.AspNetCore.Mvc;
using Moq;
using StorageProject.Application.DTOs.Brand;
using Ardalis.Result;

namespace StorageProject.Tests.BrandControllerTest
{
    public class GetBrandTests : IClassFixture<BrandControllerFixture>
    {
        private readonly BrandControllerFixture _fixture;

        public GetBrandTests(BrandControllerFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public async Task GetAllBrands_ReturnOK()
        {
            //Arrange
            var fakeList = new List<BrandDTO> { 
                new BrandDTO { Id = Guid.NewGuid(), Name = "Brand1"},
                new BrandDTO { Id = Guid.NewGuid(), Name = "Brand2"},
                new BrandDTO { Id = Guid.NewGuid(), Name = "Brand3"},
            };

            _fixture.BrandServiceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(Result.Success(fakeList));
            //Act
            var result = await _fixture.Controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        //[Fact]
        //public async Task GetAllBrands_ReturnBadRequest()
        //{
        //    //Arrange
        //    _fixture.BrandServiceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(Result<List<BrandDTO>>.Error("Error"));
        //    //Act
        //    var result = await _fixture.Controller.Get();
        //    //Assert
        //    Assert.IsType<NotFoundObjectResult>(result);
        //}
    }
}
