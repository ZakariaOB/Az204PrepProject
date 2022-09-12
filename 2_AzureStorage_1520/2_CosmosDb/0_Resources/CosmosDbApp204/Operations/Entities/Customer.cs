using Newtonsoft.Json;

namespace CosmosDbApp204.Operations.Entities
{
    public class Customer
    {
        public Customer(
            string customerId, 
            string customerName, 
            string customerCity, 
            List<Order> orders)
        {
            this.customerId = customerId;
            this.customerName = customerName;
            this.customerCity = customerCity;
            this.orders = orders;
        }

        [JsonProperty("id")]
        public string customerId { get; set; }

        public string customerName { get; set; }
        public string customerCity { get; set; }
        public List<Order> orders { get; set; }
    }
}
