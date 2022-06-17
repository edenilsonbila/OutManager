﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutManager.Models
{
    public class Restaurant
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Endereco { get; set; }
    }
}