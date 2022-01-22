using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7
{
    class Worker
    {
        /// <summary>
        /// ID работника
        /// </summary>
        private int id;

        /// <summary>
        /// Метод для чтения и изменения приватного поля ID
        /// </summary>
        /// <returns>id пользователя</returns>
        public int ID 
        {            
            get { return id; }
            set { id = value; }
        }


        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        private DateTime createDate;

        /// <summary>
        /// Метод для чтения приватного поля Дата создания
        /// </summary>
        /// <returns>Дата создания</returns>
        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        /// <summary>
        /// Ф.И.О.
        /// </summary>
        private string name;

        /// <summary>
        /// Метод для чтения и изменения имени
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        private int age;

        /// <summary>
        /// Метод для чтения и изменения имени
        /// </summary>
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        /// <summary>
        /// Рост
        /// </summary>
        private int height;

        /// <summary>
        /// Метод для чтения и изменения роста
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
        private DateTime birthDay;

        /// <summary>
        /// Метод для чтения и изменения даты рождения
        /// </summary>
        public DateTime BirthDay
        {
            get { return birthDay; }
            set { birthDay = value; }
        }

        /// <summary>
        /// Место рождения
        /// </summary>
        private string birthPlace;

        /// <summary>
        /// Метод для чтения и изменения места рождения
        /// </summary>
        public string BirthPlace
        {
            get { return birthPlace; }
            set { birthPlace = value; }
        }


        /// <summary>
        /// Конструктор для создания работника в консоли
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="height">Рост</param>
        /// <param name="birthDay">День рождения</param>
        /// <param name="birthPlace">Место рождения</param>
        public Worker(string name, int height, DateTime birthDay, string birthPlace)
        {
            this.id = 0;
            DateTime now = DateTime.Today;
            this.createDate = DateTime.Now;
            this.name = name;
            this.age = now.Year - birthDay.Year;
            if (birthDay > now.AddYears(-age)) age--;
            this.height = height;
            this.birthDay = birthDay;
            this.birthPlace = birthPlace;
        }

        /// <summary>
        /// метод для загрухзки работника из файла
        /// </summary>
        /// <param name="id">номер</param>
        /// <param name="createDate">дата создания</param>
        /// <param name="name">ФИО</param>
        /// <param name="age">возраст</param>
        /// <param name="height">рост</param>
        /// <param name="birthDay">день рождения</param>
        /// <param name="birthPlace">место рождения</param>
        public Worker(int id, DateTime createDate, string name, int age, int height, DateTime birthDay, string birthPlace)
        {
            this.id = id;
            this.createDate = createDate;
            this.name = name;
            this.age = age;            
            this.height = height;
            this.birthDay = birthDay;
            this.birthPlace = birthPlace;
        }

        /// <summary>
        /// Конструктор для создания работника без параметров
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="height">Рост</param>
        /// <param name="birthDay">День рождения</param>
        /// <param name="birthPlace">Место рождения</param>
        public Worker()
        {
            this.id = 0;
            this.createDate = DateTime.Now;
            this.name = "Имя";
            this.age = 0;
            this.height = 0;
            this.birthDay = new DateTime(2000, 1, 1, 0, 00, 0);
            this.birthPlace = "Место рождения";
        }

        /// <summary>
        /// Метод для вывода информации о сотруднике
        /// </summary>
        public string Print()
        {
            return $"ID: {id}. Дата создания: {createDate}. \n Имя: {name}. Возраст: {age}. Рост: {height}. \n День рождения: {birthDay.ToString("d")}. \n Место рождения: {birthPlace}\n";
        }

        

    }
}
