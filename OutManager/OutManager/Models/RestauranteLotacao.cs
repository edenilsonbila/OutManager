using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutManager.Models
{
    public class RestauranteLotacao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RestaurantId { get; set; }
        public int IndiceLotacao { get; set; }
        public DateTime Horario { get; set; }
    }
}
