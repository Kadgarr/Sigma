using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesShop.Models
{
    public partial class Orders
    {
        [BindNever]
        public int IdOrder { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]//сокрытие поля
        public DateTime? DateOfZakaz { get; set; }
        public int Price { get; set; }
        public string IdUser { get; set; }

        [Display (Name ="Введите имя и фамилию:")]
        public string name { get; set; }
        public string idCard { get; set; }

        [Display(Name = "Введите адресс електронной почты:")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
