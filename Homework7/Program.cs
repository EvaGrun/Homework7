using System;
using System.IO;
using System.Collections.Generic;

namespace Homework7

{
    class Program
    {

        /// <summary>
        /// Метод для выяснения, нужно ли выполнить еще какие-либо действия, или можно закрыть программу
        /// </summary>
        /// <param name="userChoice"></param>
        /// <returns></returns>
        static string Repeat()
        {
            Console.WriteLine("Если хотите продолжить - напишите \"да\", если заврешить программу - нажмите любую клавишу");
            string userChoice = Console.ReadLine();
            return userChoice;
        }

        /// <summary>
        /// Метод для создания коллекции работников из файла
        /// </summary>
        /// <param name="path">адрес файла</param>
        /// <param name="tempBD">коллекция , которую надо заполнить</param>
        static void ReadFile(string path, List<Worker> tempBD)
        {
            if (File.Exists(path))
            {
                string[] workers = File.ReadAllLines(path);
                
                foreach (var w in workers)
                {

                    string[] workerTemp = w.Split('#', 7);
                    int ID = Int32.Parse(workerTemp[0]);
                    DateTime createDate = DateTime.Parse(workerTemp[1]);
                    string name = workerTemp[2];
                    int age = Int32.Parse(workerTemp[3]);
                    int height = Int32.Parse(workerTemp[4]);
                    DateTime birthDay = DateTime.Parse(workerTemp[5]);
                    string birthPlace = workerTemp[6];
                    Worker temp = new Worker(ID, createDate, name, age, height, birthDay, birthPlace); 
                    tempBD.Add(temp);
                }
            }
            else Console.WriteLine("Файл отсутствует");
        }


        static void Main(string[] args)
        {
            try
            {
                string[] da = { "lf", "l", "да", "д", "дл", "lk" };
                string userChoice = "да";
                string path = @"\workers.txt";

                List<Worker> tempBD = new List<Worker>();
                ReadFile(path, tempBD);

                Repository db = new Repository(tempBD);
                //Worker first = new Worker();
                //Repository db = new Repository(first);



                while (Array.Exists(da, element => element == userChoice.ToLower()))
                {
                    Console.WriteLine("Что вы хотите сделать?\n" +
                    "Если вывести записи обо всех сотрудниках - нажмите 1. \n" +
                    "Если отсортировать записи в обратном порядке (от старых к новым) - намите 2. \n" +
                    "Если загрузить данные в выбранном диапазоене дат создания - нажмите 3. \n" +
                    "Если создать новую запись - нажмите 4 \n" +                     
                    "Если удалить или изменить запись (для этого вам потребуется ID работника) - нажмите 5.");
                    string userAnswer  = Console.ReadLine();

                    if (userAnswer == "1")
                    {
                        Console.WriteLine("Данные сотрудников");
                        db.Sort();
                        db.Print();
                        userChoice = Repeat();
                    }

                    else if (userAnswer == "2")
                    {
                        Console.WriteLine("Записи о сотрудниках в обратном порядке:");
                        db.Reverse();
                        db.Print();
                        userChoice = Repeat();
                    }

                    else if(userAnswer == "3")
                    {
                        Console.WriteLine("Задайте диапазон дат"); ///надо дописать
                        userChoice = Repeat();
                    }

                    else if(userAnswer == "4")
                    {
                        Console.WriteLine("Введите Ф.И.О. сотрудника");
                        string name = Console.ReadLine();

                        Console.WriteLine("Введите рост сотрудника");
                        int height = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("Введите Дату рождения сотрудника в формате м.дд.гг");
                        string dateStr = Console.ReadLine(); 
                        DateTime birthDay = DateTime.ParseExact(dateStr, "M.dd.yy", null);

                        Console.WriteLine("Введите место рождения сотрудника");
                        string birthPlace = Console.ReadLine();

                        Worker newWorker = new Worker(name, height, birthDay, birthPlace);
                        db.Add(newWorker);

                        userChoice = Repeat();
                    }

                    else if(userAnswer == "5")
                    {
                        Console.WriteLine("Введите айди сотрудника данные которого вы хотите изменить"); 
                        int id = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("Что вы хотите изменить?\n" +
                            "Если ФИО - нажмите 1.\n" +
                            "Если возраст и дату рождения - нажмите 2.\n" +
                            "Если рост нажмите 3.\n" +
                            "Если место рождения нажмите 4.\n" +
                            "Если хотите удалить запись - нажмите 0.");
                        string answer = Console.ReadLine();
                        if (answer == "1")
                        {
                            Console.WriteLine("Введите новое имя: ");
                            string newName = Console.ReadLine();
                            db.changeInfo(id, answer, newName);
                        }
                        else if (answer == "2")
                        {
                            Console.WriteLine("Введите новую дату рождения в формате м.дд.гг");
                            string newAge = Console.ReadLine();
                            db.changeInfo(id, answer, newAge);
                            userChoice = Repeat();
                        }
                        else if (answer == "3")
                        {
                            Console.WriteLine("Введите новый рост");
                            string newHeight = Console.ReadLine();
                            db.changeInfo(id, answer, newHeight);
                            userChoice = Repeat();
                        }

                        else if (answer == "4")
                        {
                            Console.WriteLine("Введите новое  место рождения");
                            string newBirthPlace = Console.ReadLine();
                            db.changeInfo(id, answer, newBirthPlace);
                            userChoice = Repeat();
                        }

                        else if (answer == "0") 
                        {
                            db.DeleteWorker(id);
                            userChoice = Repeat();
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели неверную команду. Попробуйте еще раз");
                            userChoice = Repeat();
                        }
                    }

                    else
                    {
                        Console.WriteLine("Вы ввели некорректную команду. Попробуйте еще раз");
                        userChoice = Repeat();
                    }
                }    
            }



            catch (Exception ex)
            {
                Console.WriteLine($"Fatal error: {ex.Message}");
            }



        }
    }
}
