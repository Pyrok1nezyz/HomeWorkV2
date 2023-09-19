using System.Text;
using HomeWork.Classes;
using HomeWork.Db;
using HomeWork.Forms;

namespace HomeWork
{
    public partial class MarketForm : Form
    {
        Random rnd = new Random();
        public MarketForm()
        {
            InitializeComponent();
        }
        private void MarketForm_Load(object sender, EventArgs e)
        {
            var list = new MySQLDbContext().GetItems();
            UpdateDataGridView(list);
        }

        private void UpdateDataGridView(List<Item> list)
        {
            var newlist = new List<TableFillerForItemClass>();
            foreach (var item in list)
            {
                var newitem = new TableFillerForItemClass(item);
                newlist.Add(newitem);
            }
            dataGridView1.DataSource = newlist;
        }

        private void hqLabel_Login_Click(object sender, EventArgs e)
        {
            var form = new AutorizationForm();
            form.ShowDialog();
        }

        private async void hqButton_Generator_Click(object sender, EventArgs e)
        {
            var item = new Item();
            item.Ids_CountryOfDeliverys = new List<int>();
            var items = new MySQLDbContext().GetItems();
            var categories = new MySQLDbContext().GetCategories();

            //id
            if (items.Count == 0)
                item.Id = 1;
            else if (items.Count > 0) item.Id = items.LastOrDefault()!.Id + 1;

            //Name
            item.Name = await GetRandomName();

            //SubCategory
            if (Convert.ToBoolean(rnd.Next(0, 2)))
            {
                var list = new MySQLDbContext().GetCategories().Where(e => e.IsMain == false).ToList();
                item.SubCategory = list[rnd.Next(1, list.Count)];
            }

            //Category
            if (item.SubCategory == null)
            {
                item.MainCategory = categories[rnd.Next(categories.FirstOrDefault()!.Id, categories.Count)];
            }
            else
            {
                item.MainCategory = GetMainCategoryBySubCategory(item.SubCategory);
            }

            //Price
            item.Price = rnd.Next(1, 10000);

            //Count
            item.Count = rnd.Next(1, 10);

            //ForceBuy
            var n = rnd.Next(0, 2);
            item.IsForceBuy = Convert.ToBoolean(n);

            //Ids_ContryOfDeliverys
            for (int i = 0; i < rnd.Next(1, 10); i++)
            {
                item.Ids_CountryOfDeliverys.Add(rnd.Next(1, 10));
            }

            //IsDeleted
            n = rnd.Next(0, 2);
            item.IsDeleted = Convert.ToBoolean(n);

            //IsDiscounted
            n = rnd.Next(0, 2);
            item.IsDiscounted = Convert.ToBoolean(n);

            //IsHided
            n = rnd.Next(0, 2);
            item.IsHided = Convert.ToBoolean(n);

            //Id_Byer

            if (Convert.ToBoolean(rnd.Next(0, 2)))
            {
                using (var db = new MySQLDbContext())
                {
                    item.Id_Byer = 0;
                    db.AddItem(item);
                    dataGridView1.DataSource = items;
                }
                MarketForm_Load(sender, e);
                return;
            }
            else
            {
                using (var db = new MySQLDbContext())
                {
                    item.Id_Byer = rnd.Next(1, db.GetUsers().Count);
                    db.AddItem(item);
                    dataGridView1.DataSource = items;
                }
                MarketForm_Load(sender, e);
                return;
            }

        }

        private Category GetMainCategoryBySubCategory(Category category)
        {
            var MainCategory = new MySQLDbContext().GetCategories().Find(e => e.Id == category.id_parentCategory);
            if (MainCategory!.IsMain)
            {
                return MainCategory;
            }
            else
            {
                return GetMainCategoryBySubCategory(MainCategory);
            }
        }

        private async Task<string> GetRandomName()
        {
            const string check3 = "ABCDEFGHIJKLMOPQRSTUYWXYZ";

            StringBuilder password = new StringBuilder();

            for (int i = 0; i < rnd.Next(8, 17); i++)
            {
                var symbol = Convert.ToChar(rnd.Next(65, 91));
                password.Append(symbol);
            }

            var newpass = password.ToString();

            //проверка на наличие литера в верхнем регистре
            var IsHaveBigLetter = false;

            foreach (var letter in newpass)
            {
                foreach (var c3 in check3)
                {
                    if (letter == c3)
                    {
                        IsHaveBigLetter = true;
                        continue;
                    }
                }
            }

            if (IsHaveBigLetter)
            {
                return newpass;

            }
            else
            {
                return await GetRandomName();
            }
        }

        private void hqButton_Buy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var items = new MySQLDbContext().GetItems();
                var item = items.First(e => e.Id.ToString() == dataGridView1.CurrentRow.Cells[0].Value.ToString());

                using (var db = new MySQLDbContext())
                    item.Id_Byer = rnd.Next(1, db.GetUsers().Count);

                UpdateDataGridView(items);
            }
        }

        private void hqButton_PC_Click(object sender, EventArgs e)
        {
            var list = GetSortedListOfItems(1);
            UpdateDataGridView(list);
        }

        private void hqButton_Phones_Click(object sender, EventArgs e)
        {
            var list = GetSortedListOfItems(2);
            UpdateDataGridView(list);
        }

        private void hqButton_TV_Click(object sender, EventArgs e)
        {
            var list = GetSortedListOfItems(3);
            UpdateDataGridView(list);
        }

        private void hqButton_Beatuy_Click(object sender, EventArgs e)
        {
            var list = GetSortedListOfItems(4);
            UpdateDataGridView(list);
        }

        private void hqButton_OfficeFurniture_Click(object sender, EventArgs e)
        {
            var list = GetSortedListOfItems(5);
            UpdateDataGridView(list);
        }

        private void hqButton_Accesories_Click(object sender, EventArgs e)
        {
            var list = GetSortedListOfItems(6);
            UpdateDataGridView(list);
        }

        private void hqButton_NetDevices_Click(object sender, EventArgs e)
        {
            var list = GetSortedListOfItems(7);
            UpdateDataGridView(list);
        }

        private void hqButton_Home_Click(object sender, EventArgs e)
        {
            var list = GetSortedListOfItems(8);
            UpdateDataGridView(list);
        }

        private void hqButton_CarAccesoryes_Click(object sender, EventArgs e)
        {
            var list = GetSortedListOfItems(9);
            UpdateDataGridView(list);
        }

        private void hqButton_GardenTools_Click(object sender, EventArgs e)
        {
            var list = GetSortedListOfItems(10);
            UpdateDataGridView(list);
        }

        private void hqButton_Discount_Click(object sender, EventArgs e)
        {
            var list = new MySQLDbContext().GetItems().Where(e => e.IsDiscounted).ToList();
            UpdateDataGridView(list);
        }

        private void hqButton_AllItems_Click(object sender, EventArgs e)
        {
            MarketForm_Load(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            hqButton_AllItems_Click(sender, e);
        }

        private List<Item> GetSortedListOfItems(int mainCategory)
        {
            var list = new List<Item>();
            using (var db = new MySQLDbContext())
            {
                list = db.GetItems().Where(e => e.MainCategory!.Id == mainCategory).ToList();
            }

            return list;
        }
    }
}
