# ConsoleWebStore

## My first application

The C# program communicates with the MySQL database (using the MAMP package) and the entire interface is in the console.

![](https://github.com/Bodya70rus/ConsoleWebStore/blob/main/ex.gif?raw=true)

For the program to work correctly you need to: 
1. Start MAMP -> Go to phpmyadmin;
2. Initialize the database as DBSP;
3. In that database create three tables:

```sql
CREATE TABLE `DBSP`.`users` ( `id` INT(5) UNSIGNED NOT NULL AUTO_INCREMENT , `firstName` VARCHAR(20) NOT NULL , `lastName` VARCHAR(20) NOT NULL ,     `login` VARCHAR(20) NOT NULL , `password` VARCHAR(20) NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;
CREATE TABLE `DBSP`.`products` ( `id` INT(5) UNSIGNED NOT NULL AUTO_INCREMENT , `title` VARCHAR(20) NOT NULL , `info` VARCHAR(40) NOT NULL , `cost` INT(10) UNSIGNED NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;
CREATE TABLE `DBSP`.`purchaseHistory` ( `id` INT(5) UNSIGNED NOT NULL AUTO_INCREMENT , `productTitle` VARCHAR(20) NOT NULL , `productInfo` VARCHAR(40) NOT NULL , `productId` INT(5) UNSIGNED NOT NULL , `userFirstName` VARCHAR(20) NOT NULL , `userLastName` VARCHAR(20) NOT NULL , `userId` INT(5) UNSIGNED NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;
```
4. Initialize a user with id = 1 in the table 'users', he will be an administrator;
5. It is possible to start the program and log in as administrator using the data of the first user.
