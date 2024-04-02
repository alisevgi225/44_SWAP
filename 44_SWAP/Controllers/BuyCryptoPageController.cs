using _44_SWAP.Models;
using Business_Layer.Concrete;
using Data_Acces_Layer.Entity_Framework;
using EntityLayer.concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _44_SWAP.Controllers
{
    public class BuyCryptoPageController : Controller
    {
        private readonly CoinGeckoService _coinGeckoService;
        CoinManager coinManager = new CoinManager(new EFCoinDal());
        User_WalletManager walletManager = new User_WalletManager(new EFUser_WalletDal());

        public BuyCryptoPageController(CoinGeckoService coinGeckoService)
        {
            _coinGeckoService = coinGeckoService;
        }

        public IActionResult Index()
        {
            var values = coinManager.TGetList();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> Not(SelectSwap selectSwap)
        {
            //satış için
            var values = walletManager.TGetList();
            var satilaCoinFind = coinManager.TGetList().Where(x => x.CoinBoild == selectSwap.satilan).First();
            int satilaCoinID = satilaCoinFind.CoinID;
            var result = values.Where(x => x.UserID == int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value) && x.CoinID == satilaCoinID).First();
            User_Wallet waletSell = new User_Wallet();
            waletSell.WalletID = result.WalletID;
            waletSell.UserID = result.UserID;
            waletSell.CoinID = result.CoinID;
            waletSell.Value = result.Value - selectSwap.miktar - selectSwap.miktar * 0.003;
            walletManager.TUpdate(waletSell);


            // seçilen birimlere göre sonuç bulma
            Dictionary<string, decimal> prices2 = new Dictionary<string, decimal>
            {
            { "Usdt", await _coinGeckoService.GetUSDTPriceInUSD() },
            { "Ethereum", await _coinGeckoService.GetEthereumPriceInUSD() },
            { "Binancecoin", await _coinGeckoService.GetBinancePriceInUSD() },
            { "Solana", await _coinGeckoService.GetSolanaPriceInUSD() },
            { "Cardano", await _coinGeckoService.GetCardanoPriceInUSD() }
            };
            decimal sonuc = 0;
            if (prices2.ContainsKey(selectSwap.satilan))
            {
                if (prices2.ContainsKey(selectSwap.alinan))
                {
                    sonuc = selectSwap.miktar * (prices2[selectSwap.satilan] / prices2[selectSwap.alinan]);
                }
            }

            //Alış için
            var alinanCoinFind = coinManager.TGetList().Where(x => x.CoinBoild == selectSwap.alinan).First();
            int alinanCoinID = alinanCoinFind.CoinID;
            User_Wallet waletBuy = new User_Wallet();
            waletBuy.UserID = result.UserID;
            waletBuy.CoinID = alinanCoinID;
            waletBuy.Value = double.Parse(sonuc.ToString());
            walletManager.TInsert(waletBuy);
            return RedirectToAction("Summarey");
        }
        [HttpGet]
        public async Task<IActionResult> Summarey()
        {
            return View();
        }
    }
}
