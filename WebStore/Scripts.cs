
namespace WebStore
{
    internal class Scripts
    {
        internal static MySqlDataReader ConnectDB(string query, bool option) // true - open, false - close
        {
            string connectionString =
                "SERVER=localhost;" +
                "PORT=8889;" +
                "USERNAME=root;" +
                "PASSWORD=root;" +
                "DATABASE=DBSP";

            MySqlConnection connection = new MySqlConnection(connectionString);

            if (option)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            else
            {
                connection.Close();
                return null;
            }
        }

        internal static void PrintUsersTable()
        {
            if(Pages.lang)
                Console.WriteLine("Таблица пользователей\n");
            else
                Console.WriteLine("User table\n");

            string queryTableUsers = "SELECT * FROM users";
            ConsoleTable usersTable;
            
            if (Pages.lang)
                usersTable = new ConsoleTable("ID", "имя", "фамилия", "логин", "пароль");
            else
                usersTable = new ConsoleTable("ID", "first name", "last name", "login", "password");

            MySqlDataReader usersReader = ConnectDB(queryTableUsers, true);

            while (usersReader.Read())
            {
                usersTable.AddRow(usersReader["id"], usersReader["firstName"],
                    usersReader["lastName"], usersReader["login"], usersReader["password"]);
            }

            usersTable.Write(Format.Alternative);
            Console.WriteLine();

            ConnectDB(queryTableUsers, false);
        }

        internal static void PrintProductsTable()
        {
            if (Pages.lang)
                Console.WriteLine("Таблица товаров\n");
            else
                Console.WriteLine("Table of products\n");

            string queryTableProducts = "SELECT * FROM products";
            ConsoleTable tableForProducts;
            
            if (Pages.lang)
                tableForProducts = new ConsoleTable("ID", "название", "информация", "цена");
            else
                tableForProducts = new ConsoleTable("ID", "title", "info", "cost");

            MySqlDataReader productsReader = ConnectDB(queryTableProducts, true);

            while (productsReader.Read())
            {
                tableForProducts.AddRow(productsReader["id"], productsReader["title"],
                    productsReader["info"], productsReader["cost"]);
            }

            tableForProducts.Write(Format.Alternative);
            Console.WriteLine();

            ConnectDB(queryTableProducts, false);
        }

        internal static void PrintPurchaseHistoryTable()
        {
            if (Pages.lang)
                Console.WriteLine("Таблица истории покупок\n");
            else
                Console.WriteLine("Purchasing history table\n");

            string queryTablePurchaseHistory = "SELECT * FROM purchaseHistory";
            ConsoleTable tableForPurchaseHistory;
            
            if (Pages.lang)
                tableForPurchaseHistory = new ConsoleTable("ID", "название товара",
                "информация о товаре", "ID товара", "имя покупателя", "фамилия покупателя", "ID покупателя");
            else
                tableForPurchaseHistory = new ConsoleTable("ID", "product title",
                "product info", "product ID", "buyer first name", "buyer last name", "buyer ID");

            MySqlDataReader purchaseHistoryReader = ConnectDB(queryTablePurchaseHistory, true);

            while (purchaseHistoryReader.Read())
            {
                tableForPurchaseHistory.AddRow(purchaseHistoryReader["id"],
                    purchaseHistoryReader["productTitle"], purchaseHistoryReader["productInfo"],
                    purchaseHistoryReader["productId"], purchaseHistoryReader["userFirstName"],
                    purchaseHistoryReader["userLastName"], purchaseHistoryReader["userId"]);
            }

            tableForPurchaseHistory.Write(Format.Alternative);
            Console.WriteLine();

            ConnectDB(queryTablePurchaseHistory, false);
        }

        internal static bool AdminAuthentication(string login, string password)
        {
            bool reply;
            string queryAdminAuthentication = "SELECT * FROM users WHERE id = 1";

            MySqlDataReader adminReader = ConnectDB(queryAdminAuthentication, true);

            adminReader.Read();

            try
            {
                if ((string)(adminReader["login"]) == login && (string)(adminReader["password"]) == password)
                {
                    reply = true;
                    ConnectDB(queryAdminAuthentication, false);
                    return reply;
                }
                else
                {
                    reply = false;
                    ConnectDB(queryAdminAuthentication, false);
                    return reply;
                }
            }
            catch
            {
                reply = false;
                ConnectDB(queryAdminAuthentication, false);
                return reply;
            }
        }

        internal static bool UsersAuthentication(string login, string password)
        {
            bool reply;
            string queryUsersAuthentication = $"SELECT * FROM users WHERE login = '{login}'";

            MySqlDataReader usersReader = ConnectDB(queryUsersAuthentication, true);

            usersReader.Read();

            try
            {
                if ((string)(usersReader["password"]) == password)
                {
                    reply = true;
                    ConnectDB(queryUsersAuthentication, false);
                    return reply;
                }
                else
                {
                    reply = false;
                    ConnectDB(queryUsersAuthentication, false);
                    return reply;
                }
            }
            catch
            {
                reply = false;
                ConnectDB(queryUsersAuthentication, false);
                return reply;
            }
        }

        internal static User UsersRegistration(string firstName, string lastName, string login, string password)
        {
            User newUser = new User(firstName, lastName, login, password);

            string queryUsersRegistration = $"INSERT INTO `users`(`firstName`, `lastName`, `login`, `password`) " +
                $"VALUES ('{firstName}','{lastName}','{login}','{password}')";

            MySqlDataReader usersReader = ConnectDB(queryUsersRegistration, true);
            ConnectDB(queryUsersRegistration, false);

            return newUser;
        }

        internal static User UsersSearcher(string login, string password)
        {
            string queryUsersSearcher = $"SELECT * FROM users WHERE login = '{login}' && password = '{password}'";

            MySqlDataReader usersReader = ConnectDB(queryUsersSearcher, true);

            usersReader.Read();

            User currentUser = new User((string)usersReader["firstName"], (string)usersReader["lastName"], login, password);

            ConnectDB(queryUsersSearcher, false);

            return currentUser;
        }

        internal static void UsersInserter(string firstName, string lastName, string login, string password)
        {
            string queryUsersInserter = $"INSERT INTO `users`(`firstName`, `lastName`, `login`, `password`) " +
                $"VALUES ('{firstName}','{lastName}','{login}','{password}')";

            MySqlDataReader usersReader = ConnectDB(queryUsersInserter, true);
            ConnectDB(queryUsersInserter, false);
        }

        internal static void UsersDeleter(int id)
        {
            string queryUsersDeleter = $"DELETE FROM users WHERE id = {id}";

            MySqlDataReader userReader = ConnectDB(queryUsersDeleter, true);
            ConnectDB(queryUsersDeleter, false);
        }

        internal static void ProductsInserter(string title, string info, int cost)
        {
            string queryProductsInserter = $"INSERT INTO `products`(`title`, `info`, `cost`) " +
                $"VALUES ('{title}','{info}',{cost})";

            MySqlDataReader productReader = ConnectDB(queryProductsInserter, true);
            ConnectDB(queryProductsInserter, false);
        }

        internal static void ProductsDeleter(int id)
        {
            string queryProductsDeleter = $"DELETE FROM products WHERE id = {id}";

            MySqlDataReader productsReader = ConnectDB(queryProductsDeleter, true);
            ConnectDB(queryProductsDeleter, false);
        }

        internal static int GetUserId(User user)
        {
            string strId;
            int id;
            string queryGetUsersId = $"SELECT * FROM users WHERE login = '{user.login}' && password = '{user.password}'";

            MySqlDataReader usersReader = ConnectDB(queryGetUsersId, true);

            usersReader.Read();

            strId = $"{usersReader["id"]}";
            id = int.Parse(strId);

            ConnectDB(queryGetUsersId, false);

            return id;
        }

        internal static Product ProductsSearcher(int id)
        {
            string queryProductsSearcher = $"SELECT * FROM products WHERE id = {id}";

            MySqlDataReader productsReader = ConnectDB(queryProductsSearcher, true);

            productsReader.Read();

            string strCost = $"{productsReader["cost"]}";
            int cost = int.Parse(strCost);

            Product currentProduct = new Product((string)productsReader["title"], (string)productsReader["info"], cost);

            ConnectDB(queryProductsSearcher, false);

            return currentProduct;
        }

        internal static void ProductsBuyer(int id, User user)
        {
            string queryProductsBuyer = $"INSERT INTO `purchaseHistory`" +
                $"(`productTitle`, `productInfo`, `productId`, `userFirstName`, `userLastName`, `userId`)" +
                $"VALUES ('{ProductsSearcher(id).title}','{ProductsSearcher(id).info}',{id},'{user.firstName}','{user.lastName}',{GetUserId(user)})";

            MySqlDataReader productReader = ConnectDB(queryProductsBuyer, true);
            ConnectDB(queryProductsBuyer, false);
        }

        internal static void PrintPersonalUserTable(User user)
        {
            string queryPersonalUserTable = $"SELECT * FROM users WHERE login = '{user.login}' " +
                $"&& password = '{user.password}'";
            var tableForPersonalUser = new ConsoleTable("ID", "first name", "last name", "login", "password");

            MySqlDataReader userReader = ConnectDB(queryPersonalUserTable, true);
            userReader.Read();

            tableForPersonalUser.AddRow(userReader["id"], userReader["firstName"],
                    userReader["lastName"], userReader["login"], userReader["password"]);

            tableForPersonalUser.Write(Format.Alternative);
            Console.WriteLine();

            ConnectDB(queryPersonalUserTable, false);
        }

        internal static void PrintPersonalPurchaseHistoryTable(User user)
        {
            string queryPersonalPurchaseHistoryTable = $"SELECT * FROM purchaseHistory WHERE userId = '{GetUserId(user)}'";
            var PersonaltableForPurchaseHistory = new ConsoleTable("ID", "product title",
                "product info", "product ID", "buyer first name", "buyer last name", "buyer ID");

            MySqlDataReader purchaseHistoryReader = ConnectDB(queryPersonalPurchaseHistoryTable, true);

            while (purchaseHistoryReader.Read())
            {
                PersonaltableForPurchaseHistory.AddRow(purchaseHistoryReader["id"],
                    purchaseHistoryReader["productTitle"], purchaseHistoryReader["productInfo"],
                    purchaseHistoryReader["productId"], purchaseHistoryReader["userFirstName"],
                    purchaseHistoryReader["userLastName"], purchaseHistoryReader["userId"]);
            }

            PersonaltableForPurchaseHistory.Write(Format.Alternative);
            Console.WriteLine();

            ConnectDB(queryPersonalPurchaseHistoryTable, false);
        }
    }
}
