namespace OnlineStoreProject.DTO
{
    public class CreateItemDTO
    {
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public int? Qtn { get; set; }
        public int ItemId { get; set; }
        public bool? IsAvailabile { get; set; }
    }
}
