using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entites;


namespace WebApplication1.Models
{
    public class ZakazModel
    {
        public ZakazModel(Zakaz zakaz)
        {
            Id_zakaz = zakaz.Id_zakaz;
            Users = zakaz.Users;
            Nazvanie = zakaz.Nazvanie;
            Zena = zakaz.Zena;
            Image = zakaz.Image;
        }
        public int Id_zakaz { get; set; }
        public string Users { get; set; }
        public string Nazvanie { get; set; }
        public string Zena { get; set; }
        public string Image { get; set; }

    }
}