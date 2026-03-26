using HDRUK_DevTest.Models;
using System.Text.Json;

namespace HDRUK_DevTest.Services
{
    public class DatasetService
    {
        private readonly string _url = "https://raw.githubusercontent.com/HDRUK/hackathon-entity-linkage/refs/heads/dev/fe-implement/app/data/all_datasets.json";

        public async Task<List<HealthDataModel>> GetDatasets()
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync(_url);
            var document = JsonDocument.Parse(json);
            var datasets = new List<HealthDataModel>();

            foreach (var item in document.RootElement.EnumerateArray())
            {
                var metadata = item.GetProperty("metadata");
                var summary = metadata.GetProperty("summary");

                metadata.TryGetProperty("accessibility", out var accessibility);
                accessibility.TryGetProperty("access", out var access);

                datasets.Add(new HealthDataModel
                {
                    Title = summary.TryGetProperty("title", out var title)
                        ? title.GetString() : null,
                    Description = summary.TryGetProperty("description", out var description)
                        ? description.GetString() : null,
                    AccessServiceCategory = access.TryGetProperty("accessServiceCategory", out var category)
                        ? category.GetString() : null,
                    AccessRights = access.TryGetProperty("accessRights", out var rights)
                        ? rights.GetString() : null
                });
            }

            return datasets;
        }
    }
}