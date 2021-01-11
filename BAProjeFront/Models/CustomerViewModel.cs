namespace BAProjeFront.Models{
    public class CustomerViewModel{
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email{get;set;}
        public Cart Cart{get;set;}
    }
}