using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static class Brand
        {
            public static readonly string Added = "Marka eklendi";
            public static readonly string Deleted = "Marka silindi";
            public static readonly string GetAll = "Markalar Listelendi";
            public static readonly string GetById = "Marka getirildi";
            public static readonly string Updated = "Marka güncellendi";
        }

        public static class Car
        {
            public static readonly string Added = "Araç eklendi";
            public static readonly string Deleted = "Araç silindi";
            public static readonly string GetAll = "Araçlar Listelendi";
            public static readonly string GetById = "Araç getirildi";
            public static readonly string Updated = "Araç güncellendi";
            public static readonly string Details = "Araç detayları getirildi";
        }

        public static class Color
        {
            public static readonly string Added = "Renk eklendi";
            public static readonly string Deleted = "Renk silindi";
            public static readonly string GetAll = "Renkler Listelendi";
            public static readonly string GetById = "Renk getirildi";
            public static readonly string Updated = "Renk güncellendi";
        }

        public static class Customer
        {
            public static readonly string Added = "Müşteri eklendi";
            public static readonly string Deleted = "Müşteri silindi";
            public static readonly string GetAll = "Müşteriler Listelendi";
            public static readonly string GetById = "Müşteri getirildi";
            public static readonly string Updated = "Müşteri güncellendi";
        }

        public static class Rental
        {
            public static readonly string Added = "Kiralama eklendi";
            public static readonly string Deleted = "Kiralama silindi";
            public static readonly string GetAll = "Kiralamalar Listelendi";
            public static readonly string GetById = "Kiralama getirildi";
            public static readonly string Updated = "Kiralama güncellendi";
            public static readonly string CarUnavailable = "Araç başka bir müşteride, kiralama eklenemedi";
        }

        public static class User
        {
            public static readonly string Added = "Kullanıcı eklendi";
            public static readonly string Deleted = "Kullanıcı silindi";
            public static readonly string GetAll = "Kullanıcı Listelendi";
            public static readonly string GetById = "Kullanıcı getirildi";
            public static readonly string Updated = "Kullanıcı güncellendi";
        }
    }
}
