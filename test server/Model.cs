﻿namespace test_server {
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Linq;

    public class TestContext : DbContext {
        // Контекст настроен для использования строки подключения "Model" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "VzyatkiVRF.Models.Model" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Model" 
        // в файле конфигурации приложения.
        public TestContext ()
            : base("name=Model") {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }

    public class Complaint {
        [Key]
        public int ComplaintID { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public int BrideSize { get; set; }
        [MaxLength(2000)]
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool Checked { get; set; }
        public Category Category { get; set; }
    }

    public class Category {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual List<Complaint> Complaints { get; set; }
    }
}