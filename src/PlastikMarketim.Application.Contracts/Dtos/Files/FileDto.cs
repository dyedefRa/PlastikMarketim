using PlastikMarketim.Enums;
using Volo.Abp.Application.Dtos;

namespace PlastikMarketim.Dtos.Files
{
    public class FileDto : EntityDto<int>
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public long? FileSize { get; set; }
        public string FilePath { get; set; }
        public string FullPath { get; set; }
        public string Title { get; set; }
        public string ContentType { get; set; }
        public Status Status { get; set; } = Status.Active;
    }
}
