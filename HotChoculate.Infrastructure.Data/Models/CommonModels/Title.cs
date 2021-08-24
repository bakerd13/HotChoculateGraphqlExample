using System;

namespace HotChoculate.Infrastructure.Data.Models.Common
{
    public class Title
    {
        public int TitleUniqueNumber { get; set; }
        public string TitleDescription { get; set; }
        public bool? TitleEmployee { get; set; }
        public bool? TitleServiceLocation { get; set; }
        public int? TitleSortOrder { get; set; }
        public int? AccessIntegrationDataHubMappingId { get; set; }
        public Guid? MultiEnvironmentManagerGuid { get; set; }
    }
}
