﻿using LES.Models.ViewModel.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.ViewModel.Admin
{
    public class AdminTrocaModel : TrocaModel, IViewModel
    {
        public PaginaDetalhesModel Cliente = new PaginaDetalhesModel();
    }
}
