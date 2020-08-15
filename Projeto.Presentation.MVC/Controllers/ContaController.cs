using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using Projeto.Presentation.Mvc.Models;

namespace Projeto.Presentation.Mvc.Controllers
{
    public class ContaController : Controller
    {
        private readonly IContaRepository contaRepository;

        public ContaController(IContaRepository contaRepository)
        {
            this.contaRepository = contaRepository;
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ContaCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var conta = new Conta
                    {
                        Id = Guid.NewGuid(),
                        NomeConta = model.NomeConta,
                        DataConta = DateTime.Parse(model.DataConta),
                        ValorConta = decimal.Parse(model.ValorConta),
                        Observacoes = model.Observacoes,
                        Categoria = model.Categoria,
                        FormaDePagamento = model.FormaDePagamento,
                        Tipo = model.Tipo
                    };

                    contaRepository.Create(conta);

                    TempData["MensagemSucesso"] = $"Conta {conta.NomeConta}, cadastrada com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }

            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }
    }
}