
using ExtractInfoFromCsv.Interface;

namespace ExtractInfoFromCsv.Service
{
    public class MainBackgroundService(IServiceScopeFactory scope) : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var res = scope.CreateScope();
            var provider = res.ServiceProvider;
            var obj = provider.GetService<IWorkingWithInfo>();
            var saveData = provider.GetService<ISaveDataToFile>();
            var en = obj.GetInfoFromFileProcessed();
            foreach (var item in en) {
                saveData.SaveDataToFile(item.nameTypeDataInfo, item.Tags);
            }
            return Task.CompletedTask;
        }
    }
}
