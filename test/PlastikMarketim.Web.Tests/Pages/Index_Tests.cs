using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace PlastikMarketim.Pages
{
    public class Index_Tests : PlastikMarketimWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
