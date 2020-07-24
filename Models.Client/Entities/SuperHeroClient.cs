using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Client.Entities
{
    public class SuperHeroClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Strenght { get; set; }
        public int Intelligence { get; set; }
        public int Stamina { get; set; }
        public int Charism { get; set; }
    }
}
