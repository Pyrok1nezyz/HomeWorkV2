using System.Text;
using HomeWork.Classes;
using HomeWork.Db;
using HomeWork.Forms;

namespace HomeWork
{
    public partial class MarketForm : Form
    {
        List<Item> _items;
        List<Category> _categories;
        Random rnd = new Random();
        public MarketForm()
        {
            InitializeComponent();
            _items = new List<Item>();
            _categories = new List<Category>();
        }
        private void MarketForm_Load(object sender, EventArgs e)
        {
            _items = MySQLDbContext._items;
            _categories = MySQLDbContext._categories;

            UpdateDataGridView(_items);
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
            item.Id = 0;
            item.Name = "";
            item.Category = new Category();
            item.Price = 0;
            item.Count = 0;
            item.IsForceBuy = true;
            item.Ids_CountryOfDeliverys = new List<int>();
            item.IsDiscounted = false;
            item.IsHided = false;
            item.Id_Byer = 0;

            //id
            if (_items.Count == 0)
                item.Id = 1;
            else if (_items.Count > 0) item.Id = _items.LastOrDefault()!.Id + 1;

            //Name
            item.Name = await GetRandomName();

            //Category
            item.Category = _categories[rnd.Next(_categories.FirstOrDefault()!.Id, _categories.Count)];

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
                    dataGridView1.DataSource = _items;
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
                    dataGridView1.DataSource = _items;
                }
                MarketForm_Load(sender, e);
                return;
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
                var item = _items.First(e => e.Id.ToString() == dataGridView1.CurrentRow.Cells[0].Value.ToString());

                using (var db = new MySQLDbContext()) item.Id_Byer = rnd.Next(1, db.GetUsers().Count);
                UpdateDataGridView(_items);
            }
        }

        private void hqButton_PC_Click(object sender, EventArgs e)
        {
            var list = new List<Item>(MySQLDbContext._items.Where(e => e.Category!.Id == 1).ToList());
            UpdateDataGridView(list);
        }

        private void hqButton_Phones_Click(object sender, EventArgs e)
        {
            var list = new List<Item>(MySQLDbContext._items.Where(e => e.Category!.Id == 2).ToList());
            UpdateDataGridView(list);
        }

        private void hqButton_TV_Click(object sender, EventArgs e)
        {
            var list = new List<Item>(MySQLDbContext._items.Where(e => e.Category!.Id == 3).ToList());
            UpdateDataGridView(list);
        }

        private void hqButton_Beatuy_Click(object sender, EventArgs e)
        {
            var list = new List<Item>(MySQLDbContext._items.Where(e => e.Category!.Id == 4).ToList());
            UpdateDataGridView(list);
        }

        private void hqButton_OfficeFurniture_Click(object sender, EventArgs e)
        {
            var list = new List<Item>(MySQLDbContext._items.Where(e => e.Category!.Id == 5).ToList());
            UpdateDataGridView(list);
        }

        private void hqButton_Accesories_Click(object sender, EventArgs e)
        {
            var list = new List<Item>(MySQLDbContext._items.Where(e => e.Category!.Id == 6).ToList());
            UpdateDataGridView(list);
        }

        private void hqButton_NetDevices_Click(object sender, EventArgs e)
        {
            var list = new List<Item>(MySQLDbContext._items.Where(e => e.Category!.Id == 7).ToList());
            UpdateDataGridView(list);
        }

        private void hqButton_Home_Click(object sender, EventArgs e)
        {
            var list = new List<Item>(MySQLDbContext._items.Where(e => e.Category!.Id == 8).ToList());
            UpdateDataGridView(list);
        }

        private void hqButton_CarAccesoryes_Click(object sender, EventArgs e)
        {
            var list = new List<Item>(MySQLDbContext._items.Where(e => e.Category!.Id == 9).ToList());
            UpdateDataGridView(list);
        }

        private void hqButton_GardenTools_Click(object sender, EventArgs e)
        {
            var list = new List<Item>(MySQLDbContext._items.Where(e => e.Category!.Id == 10).ToList());
            UpdateDataGridView(list);
        }

        private void hqButton_Discount_Click(object sender, EventArgs e)
        {
            var list = new List<Item>(MySQLDbContext._items.Where(e => e.IsDiscounted).ToList());
            UpdateDataGridView(list);
        }

        private void hqButton_AllItems_Click(object sender, EventArgs e)
        {
            UpdateDataGridView(MySQLDbContext._items);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
