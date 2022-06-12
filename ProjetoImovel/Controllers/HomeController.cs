using Microsoft.AspNetCore.Mvc;
using Microsoft.Xrm.Sdk.Messages;
using Newtonsoft.Json;
using ProjetoImovel.Models;
using System.Diagnostics;

namespace ProjetoImovel.Controllers {
    public class HomeController : Controller {
        HttpClient client = new HttpClient();

        public async Task<ActionResult> Index(int novoRegistro = 0, int novoDelete = 0, int novaAlteracao = 0) {
            return View();
        }

        public async Task<JsonResult> VerifyNewImoveis() {
            string url = "https://62a15133cc8c0118ef493dd7.mockapi.io/api/ProjetoImoveis/Imovel";
            var reg = JsonConvert.DeserializeObject<List<Imovel>>(await client.GetStringAsync(url));

            return Json(reg);
        }

        public async Task<ActionResult> Create(Imovel imovel) {

            if (imovel.ValorVenda != 0) {
                string url = "https://62a15133cc8c0118ef493dd7.mockapi.io/api/ProjetoImoveis/Imovel";
                await client.PostAsJsonAsync(url, imovel);

                return RedirectToAction("Index", "Home", new { novoRegistro = 1 });
            }
            return View();
        }

        public async Task<ActionResult> Delete(int id) {
            string url = "https://62a15133cc8c0118ef493dd7.mockapi.io/api/ProjetoImoveis/Imovel/" + id;
            var reg = await client.DeleteAsync(url);

            return RedirectToAction("Index", "Home", new { novoDelete = 1 });
        }

        public async Task<ActionResult> Edit(int Id) {
            string url = "https://62a15133cc8c0118ef493dd7.mockapi.io/api/ProjetoImoveis/Imovel?id=" + Id;
            var reg = JsonConvert.DeserializeObject<List<Imovel>>(await client.GetStringAsync(url));
            Imovel imovel = new Imovel();

            //Por conta das libs estarem bugadas tive que fazer essa gambiarra :D
            foreach (var item in reg) {
                imovel = item;
            }

            return View(imovel);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Imovel imovel) {
            if (imovel.ValorVenda != 0) {
                string url = "https://62a15133cc8c0118ef493dd7.mockapi.io/api/ProjetoImoveis/Imovel/" + imovel.Id;
                await client.PutAsJsonAsync(url, imovel);

                return RedirectToAction("Index", "Home", new { novaAlteracao = 1 });
            }
            return View();
        }
    }
}