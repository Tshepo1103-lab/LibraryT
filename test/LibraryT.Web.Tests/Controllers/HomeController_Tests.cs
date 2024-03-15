using System.Threading.Tasks;
using LibraryT.Models.TokenAuth;
using LibraryT.Web.Controllers;
using Shouldly;
using Xunit;

namespace LibraryT.Web.Tests.Controllers
{
    public class HomeController_Tests: LibraryTWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}