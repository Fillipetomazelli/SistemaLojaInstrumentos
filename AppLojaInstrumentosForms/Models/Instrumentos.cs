﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLojaInstrumentosForms.Models
{
    public class Instrumentos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string Modelo { get; set; }  
        public string Genero { get; set; }
        public int Loja_Id { get; set; }
    }
}
