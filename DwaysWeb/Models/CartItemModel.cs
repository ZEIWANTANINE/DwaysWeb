namespace DwaysWeb.Models
{
    public class CartItemModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total {
            get { return Quantity * Price; } }
        public string Image { get; set; }
        public CartItemModel() {

        }
        public CartItemModel(Products product){
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            Price = product.ProductPrice;
            Quantity = 1;
            Image = product.ProductPhoto;
        }
    }
}
