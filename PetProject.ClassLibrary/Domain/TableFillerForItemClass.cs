using PetProject.Core.Entities;

namespace PetProject.Core.Domain
{
    public class TableFillerForItemClass : Item
    {
        private Item item;

        public TableFillerForItemClass(Item item)
        {
            this.item = item;
        }

        public int Id => item.Id;
        public string Name => item.Name;
        public string MainCategory => item.MainCategory!.ToString();
        public string? SubCategory
        {
            get
            {
                if (item.SubCategory != null)
                    return item.SubCategory!.ToString();
                else return null;
            }
        }

        public int Price => item.Price;
        public int Count => item.Count;
        public bool IsForceBuy => item.IsForceBuy;

        public List<int>? Ids_CountryOfDeliverys => item.CountryId;
        public bool IsDiscounted => item.IsDiscounted;
        public bool IsDeleted => item.IsDeleted;
        public bool IsHided => item.IsHided;
        public int Id_Byer => item.CustomerId;
    }
}
