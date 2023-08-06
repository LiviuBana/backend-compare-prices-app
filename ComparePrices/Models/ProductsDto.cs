namespace ComparePrices.Models
{
    public class ProductsDto
    {   
        public int Id { get; set; }
        public string? site {get ; set; }
        public string? producer { get; set; }

        public string? model { get; set; }

        public string? title { get; set; }

        public string? price { get; set; }

        public string? url { get; set; }

        public string? availability { get; set; }


    }
}
