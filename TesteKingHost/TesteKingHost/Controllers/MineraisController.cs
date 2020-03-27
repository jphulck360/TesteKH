using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TesteKingHost.Models;

namespace TesteKingHost.Controllers
{
    public class MineraisController : Controller
    {
        private readonly string apiUrl = "https://localhost:44368/api/minerais";

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Mineral> listaMinerais = new List<Mineral>();

            using (var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listaMinerais = JsonConvert.DeserializeObject<List<Mineral>>(apiResponse);
                }
            }
            return View(listaMinerais);
        }
        #endregion

        #region Obter Mineral (por id)

        public ViewResult GetMineral() => View();

        [HttpPost]
        public async Task<IActionResult> GetMineral(int id)
        {
            Mineral mineral = new Mineral();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    mineral = JsonConvert.DeserializeObject<Mineral>(apiResponse);
                }
            }
            return View(mineral);
        }

        #endregion

        #region Adicionar Mineral

        public ViewResult AddMineral() => View();

        [HttpPost]
        public async Task<IActionResult> AddMineral(Mineral mineral)
        {
            Mineral mineralRecebido = new Mineral();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(mineral),
                                                  Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(apiUrl, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    mineralRecebido = JsonConvert.DeserializeObject<Mineral>(apiResponse);
                }
            }
            return View(mineralRecebido);
        }

        #endregion

        #region Atualizar Mineral

        [HttpGet]
        public async Task<IActionResult> UpdateMineral(int id)
        {
            Mineral mineral = new Mineral();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    mineral = JsonConvert.DeserializeObject<Mineral>(apiResponse);
                }
            }
            return View(mineral);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMineral(Mineral mineral)
        {
            Mineral mineralRecebido = new Mineral();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(mineral.MineralId.ToString()), "MineralId");
                content.Add(new StringContent(mineral.MineralName), "MineralName");
                content.Add(new StringContent(mineral.Description), "Description");
                content.Add(new StringContent(mineral.Completed.ToString()), "Completed");
                content.Add(new StringContent(mineral.UpdatedAt.ToString()), "UpdatedAt");

                using (var response = await httpClient.PutAsync(apiUrl, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Atualizado com sucesso!";
                    mineralRecebido = JsonConvert.DeserializeObject<Mineral>(apiResponse);
                }
            }
            return View(mineralRecebido);
        }

        #endregion

        #region Deletar Mineral

        [HttpPost]
        public async Task<IActionResult> DeleteMineral(int MineralId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(apiUrl + "/" + MineralId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }

        #endregion
    }
}