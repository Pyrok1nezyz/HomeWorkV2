namespace HomeWork.Classes
{
    internal class TableFillerForItemClass : Item
    {
        private Item item;

        public TableFillerForItemClass(Item item)
        {
            this.item = item;
        }

        public int Id => item.Id;
        public string Name => item.Name;
        public string Category => item.Category!.ToString();
        public int Price => item.Price;
        public int Count => item.Count;
        public bool IsForceBuy => item.IsForceBuy;

        public List<int>? Ids_CountryOfDeliverys => item.Ids_CountryOfDeliverys;
        public bool IsDiscounted => item.IsDiscounted;
        public bool IsDeleted => item.IsDeleted;
        public bool IsHided => item.IsHided;
        public int Id_Byer => item.Id_Byer;
    }
}
