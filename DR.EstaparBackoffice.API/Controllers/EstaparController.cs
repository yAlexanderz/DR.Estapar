using DR.EstaparBackoffice.Domain.DTO;
using DR.EstaparBackoffice.Domain.Models;
using DR.EstaparBackoffice.Domain.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Numerics;

namespace DR.EstaparBackoffice.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EstaparController : ControllerBase
    {

        #region INTERFACES

        private readonly IEstaparRepository _estaparRepository;

        #endregion

        #region CONSTRUTORES

        public EstaparController(IEstaparRepository estaparRepository)
        {
            _estaparRepository = estaparRepository;
        }

        #endregion

        [Authorize]
        [HttpGet("Passagens")]
        public async Task<IActionResult> BuscarPassagens(string? garagem)
        {
            string? codigo = null;
            string? mensagem = "";
            List<Passagem> passagem = new List<Passagem>();
            List<Garagem> garagens = new List<Garagem>();

            try
            {
                var idGaragemClaim = User.Claims.FirstOrDefault(c => c.Type == "IdGaragem")?.Value;
                if (garagem.IsNullOrEmpty())
                {
                    mensagem = "Preencha o código da garagem!";
                    throw new Exception();
                }
                if (idGaragemClaim != garagem)
                {
                    throw new Exception("Usuário autenticado não possui permissões para a garagem selecionada");
                }
                passagem = await _estaparRepository.DadosPassagens(garagem);
                garagens = await _estaparRepository.DadosGaragens(garagem);

                if (passagem == null || passagem.Count < 1)
                {
                    mensagem = "Não há carros nessa garagem";
                    throw new Exception();
                }

                foreach (var item in passagem)
                {
                    var garagemDoCarro = garagens.Find(g => g.Codigo == item.Garagem);
                    TimeSpan duracao = (TimeSpan)(item.DataHoraSaida - item.DataHoraEntrada);
                    int horas = duracao.Hours;
                    int minutos = duracao.Minutes;
                    double horasEstacionado = horas + (minutos / 100.0);
                    double? precoTotal;

                    if (item.FormaPagamento == "MEN")
                    {
                        item.PrecoTotal = 0;
                    }
                    else if (horasEstacionado <= 1)
                    {
                        item.PrecoTotal = garagemDoCarro.Preco_1aHora;
                    }
                    else
                    {

                        if (minutos <= 30 && horas <= 1)
                        {
                            // Se não passou de 30 minutos de carência, cobrar 50% do valor por hora extra.
                            item.PrecoTotal = garagemDoCarro.Preco_1aHora + ((int)garagemDoCarro.Preco_HorasExtra / 2);
                        }
                        else
                        {
                            // Se passou de 30 minutos de carência, cobrar hora cheia por hora extra.
                            item.PrecoTotal = garagemDoCarro.Preco_1aHora + (horas * (int)garagemDoCarro.Preco_HorasExtra);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    data = mensagem,
                    statusCode = HttpStatusCode.BadRequest
                });
            }

            return Ok(new { message = "Ok", data = passagem, statusCode = HttpStatusCode.OK }); ;
        }

        [Authorize]
        [HttpGet("Garagens")]
        public async Task<IActionResult> BuscarGaragens(string? codigo)
        {
            string? mensagem = "";
            List<Garagem> garagens = new List<Garagem>();

            try
            {
                garagens = await _estaparRepository.DadosGaragens(codigo);
                if (garagens == null || garagens.Count < 1)
                {
                    mensagem = "Ocorreu um erro ao consultar os dados, verifique o que fora digitado ou tente novamente mais tarde";
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    data = mensagem,
                    statusCode = HttpStatusCode.BadRequest
                });
            }

            return Ok(new { message = "Ok", data = garagens, statusCode = HttpStatusCode.OK }); ;
        }

        [Authorize]
        [HttpGet("Pagamentos")]
        public async Task<IActionResult> BuscarFormasPagamento(string? sigla)
        {
            string? mensagem = "";
            List<FormaPagamento> fPagamentos = new List<FormaPagamento>();

            try
            {
                fPagamentos = await _estaparRepository.FormasPagamento(sigla);
                if (fPagamentos == null || fPagamentos.Count < 1)
                {
                    mensagem = "Ocorreu um erro ao consultar os dados, verifique o que fora digitado ou tente novamente mais tarde";
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    data = mensagem,
                    statusCode = HttpStatusCode.BadRequest
                });
            }

            return Ok(new { message = "Ok", data = fPagamentos, statusCode = HttpStatusCode.OK }); ;
        }
    }
}

