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
        //Объявление переменных, необходимых для доступа к DataSet'у 
        //и TableAdapter'у в глобальной области видимости
        static MyDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        static MyDataSet mydataset;
        static void Main(string[] args)
        {
            
            usersTableAdapter = new MyDataSetTableAdapters.UsersTableAdapter();
            mydataset = new MyDataSet();

            //Заполнение DataSet'а данными из базы данных
            usersTableAdapter.Fill(mydataset.Users);

            //Вызов метода
            int ann_id = GetUserIdByName("Anna");

            //Печать полученного значения
            Console.WriteLine("Ann id is "+ann_id);
            
            Console.ReadLine();
        }

        //Объявление метода, получающего из базы данных 
        //id пользователя по его имени
        static int GetUserIdByName(string username)
        {
            return (from user in mydataset.Users.AsEnumerable()
                    where user.Username == username
                    select user.Id).First();
        }
    }
}
