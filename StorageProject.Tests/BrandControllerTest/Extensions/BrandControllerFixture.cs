using Moq;
using StorageProject.Application.Contracts;
using StorageProject.Api.Controllers;
namespace StorageProject.Tests.BrandControllerTest.Extensions
{
    public class BrandControllerFixture
    {
        public Mock<IBrandService> BrandServiceMock { get; } = new();
        public BrandController Controller { get; }


        public BrandControllerFixture()
        {
            Controller = new BrandController(BrandServiceMock.Object);
        }
    }
}
