﻿using Aplicacao.Entidades;
using Aplicacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCategoria
    {
        IEnumerable<CategoriaViewModel> Listar();
        CategoriaViewModel Carregar(int id);
        void Cadastrar(CategoriaViewModel categoria);
        void Excluir(int id);
    }
}
