namespace OnlineStoreProject.DTO
{
    public class ItemDTO
    {
       
        public int ItemId { get; set; }

        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        
        public  int PageSize { get; set; }
        public int PageNumber { get; set; }
       

    }

}
