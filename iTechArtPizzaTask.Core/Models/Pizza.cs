﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class Pizza : BaseEntity
    {
        public string PizzaName { get; set; }
        [Column(TypeName = "money")]
        public double PizzaCost { get; set; }
        public ICollection<PizzasIngridient> PizzasIngridients { get; set; }
    }
}
