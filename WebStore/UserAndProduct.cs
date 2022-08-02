
namespace WebStore
{
    internal class User
    {
        internal string firstName { get; set; }
        internal string lastName { get; set; }
        internal string login { get; set; }
        internal string password { get; set; }

        internal User(string firstName, string lastName, string login, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.login = login;
            this.password = password;
        }
    }
    
    internal class Product
    {
        internal string title { get; set; }
        internal string info { get; set; }
        internal int cost { get; set; }

        internal Product(string title, string info, int cost)
        {
            this.title = title;
            this.info = info;
            this.cost = cost;
        }
    }
}

