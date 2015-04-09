﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Dominio.Entidades
{


    public class Produto
    {
        [HiddenInput(DisplayValue=false)]
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public decimal Preco { get; set; }


    }
}
