﻿using System;

namespace WebApiRH.Models.ViewModel
{
    public class HomeCreateModel
    {
        public String Admin { get; set; }
        public String Address { get; set; }
        public int Appartaments { get; set; }
        public int Floors { get; set; }
        public int Porches { get; set; }
        public String Year { get; set; }
        public int Status { get; set; }
        public String Image { get; set; }

        public static explicit operator Home(HomeCreateModel m)
        {
            return new Home()
            {
                Uid = Guid.NewGuid().ToString("D"),
                FK_Admin = m.Admin,
                Fk_ImageUrl = m.Image,
                Location = m.Address,
                Appartaments = m.Appartaments,
                Floors = m.Floors,
                Porches = m.Porches,
                YearCommissioning = m.Year,
                Fk_Status = m.Status,
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Removed = false
            };
        }
    }
}