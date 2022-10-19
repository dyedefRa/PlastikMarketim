using System.Threading.Tasks;

namespace PlastikMarketim.Data
{
    public interface IPlastikMarketimDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
