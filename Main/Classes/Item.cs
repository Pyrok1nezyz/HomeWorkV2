namespace HomeWork.Classes
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Category? Category { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public bool IsForceBuy { get; set; }

        public List<int>? Ids_CountryOfDeliverys { get; set; }
        public bool IsDiscounted { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsHided { get; set; }
        public int Id_Byer { get; set; }
    }
}
