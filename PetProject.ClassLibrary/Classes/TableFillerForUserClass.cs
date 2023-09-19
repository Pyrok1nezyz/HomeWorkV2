namespace HomeWork.Classes
{
    internal class TableFillerForUserClass
    {
        private User user;
        internal TableFillerForUserClass(User user)
        {
            this.user = user;
        }

        public long Id => user.Id;

        public string Name => user.Name;

        public string Password => user.Password;

        public string Computer
        {
            get
            {
                if(user.Computer != null) return user.Computer.ToString();
                return "NULL";
            }
        }
    }
}
