
namespace WebStore
{
    internal class Pages
    {
        internal static bool lang = false; // En - false; Rus - true

        internal static void HomePage()
        {
            Console.Clear();
            int choise;

            if (lang)
            {
                Console.WriteLine("Главная страница\n");
                Console.WriteLine("1 - Войти как администратор\n2 - Войти как пользователь\n3 - Зарегистрироваться\n\n4 - Изменить язык\n0 - Завершить программу\n\n");
            }
            else
            {
                Console.WriteLine("Homepage\n");
                Console.WriteLine("1 - Sign in as admin\n2 - Sign in as a user\n3 - Sign up\n\n4 - Change the language\n0 - End the program\n");
            }

            if (int.TryParse(Console.ReadLine(), out choise))
            {
                switch (choise)
                {
                    case 1:
                        AdminAuthenticationPage();
                        break;
                    case 2:
                        UsersAuthenticationPage();
                        break;
                    case 3:
                        UsersRegistrationPage();
                        break;
                    case 4:
                        LanguageSelectorPage();
                        break;
                    case 0:
                        return;
                    default:
                        Console.Clear();
                        if (lang)
                            Console.WriteLine("Неверный формат ввода");
                        else
                            Console.WriteLine("Incorrect input format");
                        Console.ReadLine();

                        HomePage();

                        break;
                }
            }
            else
            {
                Console.Clear();
                if (lang)
                    Console.WriteLine("Неверный формат ввода");
                else
                    Console.WriteLine("Incorrect input format");
                Console.ReadLine();

                HomePage();
            }
        }

        internal static void LanguageSelectorPage()
        {
            Console.Clear();
            int choise;

            if (lang)
            {
                Console.WriteLine("Выберите язык\n");
                Console.WriteLine("1 - Русский\n2 - Английский\n\n0 - Назад\n");
            }
            else
            {
                Console.WriteLine("Choose a language\n");
                Console.WriteLine("1 - Russian\n2 - English\n\n0 - Back\n");
            }

            if (int.TryParse(Console.ReadLine(), out choise))
            {
                switch (choise)
                {
                    case 1:
                        lang = true;
                        HomePage();
                        break;
                    case 2:
                        lang = false;
                        HomePage();
                        break;
                    case 0:
                        HomePage();
                        return;
                    default:
                        Console.Clear();
                        if (lang)
                            Console.WriteLine("Неверный формат ввода");
                        else
                            Console.WriteLine("Incorrect input format");
                        Console.ReadLine();

                        LanguageSelectorPage();

                        break;
                }
            }
            else
            {
                Console.Clear();
                if (lang)
                    Console.WriteLine("Неверный формат ввода");
                else
                    Console.WriteLine("Incorrect input format");
                Console.ReadLine();

                LanguageSelectorPage();
            }
        }

        internal static void AdminAuthenticationPage()
        {
            Console.Clear();
            string adminLogin;
            string adminPassword;

            if (lang)
            {
                Console.WriteLine("Аутентификация для администратора\n");
                Console.Write("введите логин: ");
            }
            else
            {
                Console.WriteLine("Authentication for administrator\n");
                Console.Write("enter your login: ");
            }

            adminLogin = Console.ReadLine();

            if(lang)
                Console.Write("введите пароль: ");
            else
                Console.Write("enter your password: ");

            adminPassword = Console.ReadLine();

            if (Scripts.AdminAuthentication(adminLogin, adminPassword))
                AdminPage();
            else
                IncorrectDataPage();
        }

        internal static void UsersAuthenticationPage()
        {
            Console.Clear();
            string usersLogin;
            string usersPassword;

            if (lang)
            {
                Console.WriteLine("Аутентификация для пользователя\n");
                Console.Write("введите логин: ");
            }
            else
            {
                Console.WriteLine("Authentication for the user\n");
                Console.Write("enter your login: ");
            }

            usersLogin = Console.ReadLine();

            if (lang)
                Console.Write("введите пароль: ");
            else
                Console.Write("enter your password: ");

            usersPassword = Console.ReadLine();

            if (Scripts.UsersAuthentication(usersLogin, usersPassword))
                UserPage(Scripts.UsersSearcher(usersLogin, usersPassword));
            else
                IncorrectDataPage();
        }

        internal static void UsersRegistrationPage()
        {
            Console.Clear();
            string firstName;
            string lastName;
            string login;
            string password;
            if (lang)
                Console.WriteLine("Регистрация\n");
            else
                Console.WriteLine("Registration\n");

            if (lang)
                Console.Write("введите имя: ");
            else
                Console.Write("enter a name: ");
            firstName = Console.ReadLine();
            if (lang)
                Console.Write("введите фамилию: ");
            else
                Console.Write("enter last name: ");
            lastName = Console.ReadLine();
            if (lang)
                Console.Write("придумайте логин: ");
            else
                Console.Write("make a login: ");
            login = Console.ReadLine();
            if (lang)
                Console.Write("придумайте пароль: ");
            else
                Console.Write("make a password: ");
            password = Console.ReadLine();

            if (firstName != "" && lastName != "" && login != "" && password != "")
            {
                User newUser = Scripts.UsersRegistration(firstName, lastName, login, password);
                Console.Clear();
                if (lang)
                    Console.WriteLine("Вы успешно зарегистрировались");
                else
                    Console.WriteLine("You have successfully registered");
                Console.ReadLine();

                UserPage(newUser);
            }
            else
            {
                Console.Clear();
                if (lang)
                    Console.WriteLine("Пустые поля непредусмотрены");
                else
                    Console.WriteLine("Blank fields are not provided");
                Console.ReadLine();

                UsersRegistrationPage();
            }
        }

        internal static void AdminPage()
        {
            Console.Clear();
            int choise;

            if (lang)
            {
                Console.WriteLine("Вы вошли как администратор\n");
                Console.WriteLine("1 - Получить информацию о пользователях\n2 - Получить информацию о товарах\n3 - Получить информацию о истории покупок\n\n0 - Выйти\n");
            }
            else
            {
                Console.WriteLine("You are logged in as an administrator\n");
                Console.WriteLine("1 - Get information about users\n2 - Get information about products\n3 - Get information about your purchase history\n\n0 - Log out\n");
            }

            if (int.TryParse(Console.ReadLine(), out choise))
            {
                switch (choise)
                {
                    case 1:
                        AdminUsersTablePage();
                        break;
                    case 2:
                        AdminProductsTablePage();
                        break;
                    case 3:
                        AdminPurchaseHistoryTablePage();
                        break;
                    case 19:
                        DonatPage();
                        AdminPage();
                        break;
                    case 0:
                        HomePage();
                        break;
                    default:
                        Console.Clear();
                        if (lang)
                            Console.WriteLine("Неверный формат ввода");
                        else
                            Console.WriteLine("Incorrect input format");
                        Console.ReadLine();

                        AdminPage();

                        break;
                }
            }
            else
            {
                Console.Clear();
                if (lang)
                    Console.WriteLine("Неверный формат ввода");
                else
                    Console.WriteLine("Incorrect input format");
                Console.ReadLine();

                AdminPage();
            }
        }

        internal static void AdminUsersTablePage()
        {
            Console.Clear();
            int choise;

            Scripts.PrintUsersTable();
            if(lang)
                Console.WriteLine("1 - Добавить пользователя\n2 - Удалить пользователя\n\n0 - Назад\n");
            else
                Console.WriteLine("1 - Add user\n2 - Delete a user\n\n0 - Back\n");

            if (int.TryParse(Console.ReadLine(), out choise))
            {
                switch (choise)
                {
                    case 1:
                        UsersInserterPage();
                        break;
                    case 2:
                        UsersDeleterPage();
                        break;
                    case 0:
                        AdminPage();
                        break;
                    default:
                        Console.Clear();
                        if (lang)
                            Console.WriteLine("Неверный формат ввода");
                        else
                            Console.WriteLine("Incorrect input format");
                        Console.ReadLine();

                        AdminUsersTablePage();

                        break;
                }
            }
            else
            {
                Console.Clear();
                if (lang)
                    Console.WriteLine("Неверный формат ввода");
                else
                    Console.WriteLine("Incorrect input format");
                Console.ReadLine();

                AdminUsersTablePage();
            }
        }

        internal static void UsersInserterPage()
        {
            Console.Clear();
            string firstName;
            string lastName;
            string login;
            string password;

            if (lang)
                Console.Write("введите имя: ");
            else
                Console.Write("enter a name: ");
            firstName = Console.ReadLine();
            if (lang)
                Console.Write("введите фамилию: ");
            else
                Console.Write("enter last name: ");
            lastName = Console.ReadLine();
            if (lang)
                Console.Write("придумайте логин: ");
            else
                Console.Write("make a login: ");
            login = Console.ReadLine();
            if (lang)
                Console.Write("придумайте пароль: ");
            else
                Console.Write("make a password: ");
            password = Console.ReadLine();

            if (firstName != "" && lastName != "" && login != "" && password != "")
            {
                Scripts.UsersInserter(firstName, lastName, login, password);
                Console.Clear();
                if(lang)
                    Console.WriteLine("Пользователь добавлен");
                else
                    Console.WriteLine("User added");
                Console.ReadLine();

                AdminPage();
            }
            else
            {
                Console.Clear();
                if (lang)
                    Console.WriteLine("Пустые поля непредусмотрены");
                else
                    Console.WriteLine("Blank fields are not provided");
                Console.ReadLine();

                UsersInserterPage();
            }
        }

        internal static void UsersDeleterPage()
        {
            Console.Clear();
            int idForDelete;

            Scripts.PrintUsersTable();

            if (lang)
            {
                Console.WriteLine("Введите id пользователей через пробел, которых нужно удалить");
                Console.WriteLine("0 - Назад\n");
            }
            else
            {
                Console.WriteLine("Enter the id of the users you want to remove, separated by a space");
                Console.WriteLine("0 - Back\n");
            }

            string strId = Console.ReadLine();
            string[] idArr = strId.Split(new Char[] { ' ' });

            for (int i = 0; i < idArr.Length; i++)
            {
                if (int.Parse(idArr[i]) == 0)
                {
                    AdminPage();
                }
                Scripts.UsersDeleter(int.Parse(idArr[i]));
            }

            Console.Clear();
            if(lang)
                Console.WriteLine("Удаление прошло успешно");
            else
                Console.WriteLine("The deletion was successful");
            Console.ReadLine();

            AdminPage();
        }

        internal static void AdminProductsTablePage()
        {
            Console.Clear();
            int choise;

            Scripts.PrintProductsTable();
            if(lang)
                Console.WriteLine("1 - Добавить товар\n2 - Удалить товар\n\n0 - Назад\n");
            else
                Console.WriteLine("1 - Add product\n2 - Delete product\n\n0 - Back\n");

            if (int.TryParse(Console.ReadLine(), out choise))
            {
                switch (choise)
                {
                    case 1:
                        ProductsInserterPage();
                        break;
                    case 2:
                        ProductsDeleterPage();
                        break;
                    case 0:
                        AdminPage();
                        break;
                    default:
                        Console.Clear();
                        if (lang)
                            Console.WriteLine("Неверный формат ввода");
                        else
                            Console.WriteLine("Incorrect input format");
                        Console.ReadLine();

                        AdminProductsTablePage();

                        break;
                }
            }
            else
            {
                Console.Clear();
                if (lang)
                    Console.WriteLine("Неверный формат ввода");
                else
                    Console.WriteLine("Incorrect input format");
                Console.ReadLine();

                AdminProductsTablePage();
            }
        }

        internal static void ProductsInserterPage()
        {
            Console.Clear();
            string title;
            string info;
            int cost;

            if(lang)
                Console.Write("введите название товара: ");
            else
                Console.Write("enter product name: ");
            title = Console.ReadLine();
            if (lang)
                Console.Write("введите информацию о товаре: ");
            else
                Console.Write("enter product information: ");
            info = Console.ReadLine();
            if (lang)
                Console.Write("введите цену товара: ");
            else
                Console.Write("enter the price of product: ");
            cost = int.Parse(Console.ReadLine());

            if (title != "" && info != "")
            {
                Scripts.ProductsInserter(title, info, cost);
                Console.Clear();
                if(lang)
                    Console.WriteLine("Товар добавлен");
                else
                    Console.WriteLine("Product added");
                Console.ReadLine();

                AdminPage();
            }
            else
            {
                Console.Clear();
                if (lang)
                    Console.WriteLine("Пустые поля непредусмотрены");
                else
                    Console.WriteLine("Blank fields are not provided");
                Console.ReadLine();

                ProductsInserterPage();
            }
        }

        internal static void ProductsDeleterPage()
        {
            Console.Clear();
            int idForDelete;

            Scripts.PrintProductsTable();

            if (lang)
            {
                Console.WriteLine("Введите id товаров через пробел, которые нужно удалить");
                Console.WriteLine("0 - Назад\n");
            }
            else
            {
                Console.WriteLine("Enter the id of the items you want to remove, separated by a space");
                Console.WriteLine("0 - Back\n");
            }

            string strId = Console.ReadLine();
            string[] idArr = strId.Split(new Char[] { ' ' });

            for (int i = 0; i < idArr.Length; i++)
            {
                if (int.Parse(idArr[i]) == 0)
                {
                    AdminPage();
                }
                Scripts.ProductsDeleter(int.Parse(idArr[i]));
            }

            Console.Clear();
            if(lang)
                Console.WriteLine("Удаление прошло успешно");
            else
                Console.WriteLine("The deletion was successful");
            Console.ReadLine();

            AdminPage();
        }

        internal static void AdminPurchaseHistoryTablePage()
        {
            Console.Clear();
            int choise;

            Scripts.PrintPurchaseHistoryTable();

            if(lang)
                Console.WriteLine("0 - Назад\n");
            else
                Console.WriteLine("0 - Back\n");

            if (int.TryParse(Console.ReadLine(), out choise))
            {
                switch (choise)
                {
                    case 0:
                        AdminPage();
                        break;
                    default:
                        Console.Clear();
                        if (lang)
                            Console.WriteLine("Неверный формат ввода");
                        else
                            Console.WriteLine("Incorrect input format");
                        Console.ReadLine();

                        AdminPurchaseHistoryTablePage();

                        break;
                }
            }
            else
            {
                Console.Clear();
                if (lang)
                    Console.WriteLine("Неверный формат ввода");
                else
                    Console.WriteLine("Incorrect input format");
                Console.ReadLine();

                AdminPurchaseHistoryTablePage();
            }
        }

        internal static void UserPage(User user)
        {
            Console.Clear();
            int choise;

            if (lang)
            {
                Console.WriteLine("Вы вошли как пользователь\n");
                Console.WriteLine("1 - Приобрести товар\n2 - Информация о пользователе\n3 - История покупок\n\n0 - Выйти\n");
            }
            else
            {
                Console.WriteLine("You are logged in as a user\n");
                Console.WriteLine("1 - Buy a product\n2 - User information\n3 - Purchase History\n\n0 - Log out\n");
            }
            

            if (int.TryParse(Console.ReadLine(), out choise))
            {
                switch (choise)
                {
                    case 1:
                        UserBuyPage(user);
                        break;
                    case 2:
                        UserInfoPage(user);
                        break;
                    case 3:
                        UserPurchaseHistoryPage(user);
                        break;
                    case 0:
                        HomePage();
                        break;
                    default:
                        Console.Clear();
                        if (lang)
                            Console.WriteLine("Неверный формат ввода");
                        else
                            Console.WriteLine("Incorrect input format");
                        Console.ReadLine();

                        UserPage(user);

                        break;
                }
            }
            else
            {
                Console.Clear();
                if (lang)
                    Console.WriteLine("Неверный формат ввода");
                else
                    Console.WriteLine("Incorrect input format");
                Console.ReadLine();

                UserPage(user);
            }
        }

        internal static void UserBuyPage(User user)
        {
            Console.Clear();
            Scripts.PrintProductsTable();

            if (lang)
            {
                Console.WriteLine("Введите id товаров через пробел, которые бы хотели приобрести");
                Console.WriteLine("0 - Назад\n");
            }
            else
            {
                Console.WriteLine("Enter the id of the items you would like to purchase, separated by a space");
                Console.WriteLine("0 - Back\n");
            }
            
            string strId = Console.ReadLine();
            string[] idArr = strId.Split(new Char[] { ' ' });

            for (int i = 0; i < idArr.Length; i++)
            {
                if (int.Parse(idArr[i]) == 0)
                {
                    UserPage(user);
                }
                Scripts.ProductsBuyer(int.Parse(idArr[i]), user);
            }

            Console.Clear();
            if(lang)
                Console.WriteLine("Товар(ы) успешно приобретены");
            else
                Console.WriteLine("Product(s) successfully purchased");
            Console.ReadLine();
            UserPage(user);
        }

        internal static void UserInfoPage(User user)
        {
            Console.Clear();
            int choise;

            Scripts.PrintPersonalUserTable(user);

            if(lang)
                Console.WriteLine("0 - Назад\n");
            else
                Console.WriteLine("0 - Back\n");
            Console.ReadLine();

            UserPage(user);
        }

        internal static void UserPurchaseHistoryPage(User user)
        {
            Console.Clear();
            int choise;

            Scripts.PrintPersonalPurchaseHistoryTable(user);

            if (lang)
                Console.WriteLine("0 - Назад\n");
            else
                Console.WriteLine("0 - Back\n");
            Console.ReadLine();

            UserPage(user);
        }

        internal static void DonatPage()
        {
            // this donut belongs to smcl/Sean McLemon
            double A = 0, B = 0, i, j;
            var z = new double[7040];
            var b = new char[1760];
            int timer = 190;
            while (timer != 0)
            {
                memset(b, ' ', 1760);
                memset(z, 0.0f, 7040);
                for (j = 0; 6.28 > j; j += 0.07)
                {
                    for (i = 0; 6.28 > i; i += 0.02)
                    {
                        double c = Math.Sin(i);
                        double d = Math.Cos(j);
                        double e = Math.Sin(A);
                        double f = Math.Sin(j);
                        double g = Math.Cos(A);
                        double h = d + 2;
                        double D = 1 / (c * h * e + f * g + 5);
                        double l = Math.Cos(i);
                        double m = Math.Cos(B);
                        double n = Math.Sin(B);
                        double t = c * h * g - f * e;
                        int x = (int)(40 + 30 * D * (l * h * m - t * n));
                        int y = (int)(12 + 15 * D * (l * h * n + t * m));
                        int o = x + 80 * y;
                        int N = (int)(8 * ((f * e - c * d * g) * m - c * d * e - f * g - l * d * n));
                        if (22 > y && y > 0 && x > 0 && 80 > x && D > z[o])
                        {
                            z[o] = D;
                            b[o] = ".,-~:;=!*#$@"[N > 0 ? N : 0];
                        }
                    }
                }
                Thread.Sleep(20);
                Console.Clear();
                nl(b);
                Console.Write(b);
                Console.WriteLine(timer/10);
                A += 0.04;
                B += 0.02;
                timer--;
            }
            static void memset<T>(T[] buf, T val, int bufsz)
            {
                if (buf == null)
                    buf = new T[bufsz];
                for (int i = 0; i < bufsz; i++)
                    buf[i] = val;
            }

            static void nl(char[] b)
            {
                for (int i = 80; 1760 > i; i += 80)
                {
                    b[i] = '\n';
                }
            }
        }

        internal static void IncorrectDataPage()
        {
            Console.Clear();
            if (lang)
                Console.WriteLine("Неверный логин или пароль");
            else
                Console.WriteLine("Incorrect login or password");
            Console.ReadLine();

            HomePage();
        }
    }
}

