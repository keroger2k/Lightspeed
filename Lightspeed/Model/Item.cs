
namespace Lightspeed.Model
{
    public class Item
    {
        public int itemId { get; set; }
        public double systemSku { get; set; }
        public decimal defaultCost { get; set; }
        public decimal avgCost { get; set; }
        public bool tax { get; set; }
        public bool archived { get; set; }
        public string description { get; set; }
        public int modelYear { get; set; }
        public string upc { get; set; }
        public string ean { get; set; }
        public string customSku { get; set; }
        public string manufacturerSku { get; set; }
        public int categoryID { get; set; }
        public int taxClassID { get; set; }
        public int departmentID { get; set; }
        public int itemMatrixID { get; set; }
        public int manufacturerID { get; set; }
        public int sessionID { get; set; }
        public int defaultVendorID { get; set; }
        public int itemECommerceID { get; set; }

        public override string ToString()
        {
             return string.Format("ItemId: {0}, SKU: {1}, Description: {2}", this.itemId, this.customSku, this.description);
        }
    }
}
