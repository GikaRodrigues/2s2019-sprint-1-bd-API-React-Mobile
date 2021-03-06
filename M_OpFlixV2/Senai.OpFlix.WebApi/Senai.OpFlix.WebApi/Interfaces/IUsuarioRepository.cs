﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuarios BuscarPorEmailESenha(LoginViewModel login);

        void CadastrarAdmin(Usuarios usuario);

        void Cadastrar(Usuarios usuario);
    }
}
