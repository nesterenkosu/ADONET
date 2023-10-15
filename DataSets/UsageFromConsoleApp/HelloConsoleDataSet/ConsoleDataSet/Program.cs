using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//Подключить пространство имён System.Data

namespace ConsoleDataSet
{
    class Program
    {       
        static void Main(string[] args)
        {
            //Объявление переменных, необходимых для доступа к DataSet'у 
            //и TableAdapter'у 
            MyDataSetTableAdapters.UsersTableAdapter usersTableAdapter = new MyDataSetTableAdapters.UsersTableAdapter();
            MyDataSet mydataset = new MyDataSet();

            //Заполнение DataSet'а данными из базы данных
            usersTableAdapter.Fill(mydataset.Users); 

            //Вывод содержимого таблицы Users
            foreach (var user in mydataset.Users)            
                Console.WriteLine(user.Id+" "+user.Username+" "+user.Age);
            
            Console.ReadLine();
        }
    }
}
