using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Homework7
{
    struct Repository
    {
        /// <summary>
        /// База данных сотрудников
        /// </summary>
        public List<Worker> db; 

        int index;

        /// <summary>
        /// конуструктор для загрузки сотрудников из массива
        /// </summary>
        /// <param name="Path">путь к файлу</param>
        /// 
        public Repository(List<Worker> db)
        {
            this.db = db;
            int elementCount = db.Count();
            if (elementCount<1)
            {
                this.index = 0;
            }
            else this.index = db[elementCount - 1].ID+1;
        }

        /// <summary>
        /// конуструктор для добавления работников по одному в консоле
        /// </summary>
        /// <param name="ConcretWorker"></param>
        public Repository(Worker ConcretWorker)
        {
            this.index = 1;
            this.db = new List<Worker>();
            db.Add(ConcretWorker);
        }


        /// <summary>
        /// метод для добавления работника в массив с работниками
        /// </summary>
        /// <param name="ConcreteWorker">данные одного сотрудника</param>
        public void Add(Worker ConcreteWorker)
        {
            ConcreteWorker.ID = index;
            this.db.Add(ConcreteWorker);
            index++;
        }

        /// <summary>
        /// метод для вывода базы сотрудников в консоль
        /// </summary>
        public void Print ()
        {
            for (int i = 0; i < db.Count(); i++)
            {
                Console.WriteLine(this.db[i].Print());
            }
        }


        /// <summary>
    /// Метод для осртировки по дате создания в обратном порядке, от первых к последним
    /// </summary>
        public void Sort()
        {
            db.Sort((w1, w2) => DateTime.Compare(w1.CreateDate, w2.CreateDate));
        }

        /// <summary>
        /// Метод для осртировки по дате создания в обратном порядке, от последних к первым
        /// </summary>
        public void Reverse()
        {
            Sort();
            db.Reverse();
        }

        /// <summary>
        /// Метод для удаления записи о работнике
        /// </summary>
        /// <param name="id">id работника, которого надо удалить</param>
        public void DeleteWorker(int id) 
        {
            var workerToDelete = this.db.Where(x => x.ID == id).Select(x => x).First();
            db.Remove(workerToDelete);
            this.index--;
        }

        /// <summary>
        /// Метод для изменения данных сотрудников
        /// </summary>
        /// <param name="selectId">айди выбранного сотрудника</param>
        /// <param name="answer">переменная указывающая, что именно надо сделать с выбранным сотрудником</param>
        /// <param name="newInfo">новые данные, которыми надо заменить старые</param>
        public void changeInfo (int selectId, string answer, string newInfo)
        {
            var workerToChange = this.db.Where(x => x.ID == selectId).Select(x => x).First();
            int i = db.IndexOf(workerToChange);

            if (answer == "1")
            {
                db[i].Name = newInfo;
            }
            else if (answer == "2")
            {
                db[i].BirthDay = DateTime.ParseExact(newInfo, "M.dd.yy", null);
            }
            else if (answer == "3")
            {
                db[i].Height = Int32.Parse(newInfo);
            }

            else if (answer == "4")
            {
                db[i].BirthPlace = newInfo;
            }
        }


        //public void PrintSelect(DateTime start, DateTime end)
        //{
        //    Sort();
        //    int firstI = 0;
        //    int secondI = 0;

        //    for (int i = 0; i < db.Count; i++)
        //    {
        //        if (db[1].CreateDate <= start)
        //        {
        //            firstI = i;
        //        }

        //    }

        //    for (int i = 0; i<db.Count; i++)
        //    {
        //        if (db[1].CreateDate <= end)
        //        {
        //            secondI = i;
        //        }
        //    }


        //    {
        //        for (int i = secondI + 1; i < firstI- 1; i++)
        //        {
        //            Console.WriteLine(this.db[i].Print());
        //        }
        //    }
        //}


    }
}
