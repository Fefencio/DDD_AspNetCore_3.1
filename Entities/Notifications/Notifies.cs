﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Notifications
{
    public class Notifies
    {
        public Notifies()
        {
            Notitycoes = new List<Notifies>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }
        [NotMapped]
        public string mensagem { get; set; }
        [NotMapped]
        public List<Notifies> Notitycoes { get; set; }

        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade)) 
            {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }

            return true;
        }

        public bool ValidarPropriedadeInt(int valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }

        public bool ValidarPropriedadeDecimal(decimal valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }
            if (valor < 0 )
            {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "O Valor não pode ser inferior a 0",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }
    }
}