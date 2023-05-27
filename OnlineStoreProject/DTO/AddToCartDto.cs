namespace OnlineStoreProject.DTO
{
    public class AddToCartDto
    {
     
        public int? UserId { get; set; }
    
       
        public int? ItemId { get; set; }
        public int? Qtn { get; set; }
        public string? Note { get; set; }
   
    }
}
