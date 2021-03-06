﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Models
{
    public class GeneralProductModel
    {
        public GeneralProductModel()
        {
            Characteristics = new List<CharacteriscitModel>();
        }
        public int Id { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string TextUrl { get; set; }
        public string PhotoPath { get; set; }
        public string UrlToBuy { get; set; }
        public IList<CharacteriscitModel> Characteristics { get; set; }
    }
}