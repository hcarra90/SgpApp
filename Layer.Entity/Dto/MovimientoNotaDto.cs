﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class MovimientoNotaDto
    {
        public int Id { get; set; }
        public string Euid { get; set; }
        public DateTime Fecha { get; set; }
        public string Nota { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
        public string Usuario { get; set; }
        public string Jaula { get; set; }
    }
}
