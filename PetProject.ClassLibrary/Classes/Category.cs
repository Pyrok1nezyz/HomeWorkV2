namespace HomeWork.Classes
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int id_parentCategory { get; set; }
        public bool IsMain { get; set; }

        public override string ToString()
        {
            if(string.IsNullOrEmpty(Name)) return Id.ToString();
            return Name;
        }
    }
}
