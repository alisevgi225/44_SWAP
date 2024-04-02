using _44_SWAP.Models;
using Business_Layer.Concrete;
using Data_Acces_Layer.Entity_Framework;
using EntityLayer.concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace _44_SWAP.Controllers
{
	public class WalletPage : Controller
	{
		private readonly CoinGeckoService _coinGeckoService;
		User_WalletManager walletManager = new User_WalletManager(new EFUser_WalletDal());
		public WalletPage(CoinGeckoService coinGeckoService)
		{
			_coinGeckoService = coinGeckoService;
		}


		[HttpGet]
		public async Task<IActionResult> Wallet()
		{
			var values = walletManager.TGetWalletUserID(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value));

			Dictionary<string, decimal> prices2 = new Dictionary<string, decimal>
	{
		{ "Usdt", await _coinGeckoService.GetUSDTPriceInUSD() },
		{ "Ethereum", await _coinGeckoService.GetEthereumPriceInUSD() },
		{ "Binancecoin", await _coinGeckoService.GetBinancePriceInUSD() },
		{ "Solana", await _coinGeckoService.GetSolanaPriceInUSD() },
		{ "Cardano", await _coinGeckoService.GetCardanoPriceInUSD() }
	};

			List<CoinAndIcon> coinAndIconList = new List<CoinAndIcon>();
			decimal varlik=0;
			foreach (var item in values)
			{
				if (prices2.ContainsKey(item.Coin.CoinBoild))
				{
					decimal sonuc = prices2[item.Coin.CoinBoild];
					CoinAndIcon coinAndIcon = new CoinAndIcon
					{
						name = item.Coin.CoinBoild,
						icon = item.Coin.CoinIcon,
						fiyat = sonuc.ToString(),
						varlikDeger = (sonuc * Convert.ToDecimal(item.Value)).ToString(),
						miktar = item.Value.ToString()
					};
					varlik = varlik+(sonuc * Convert.ToDecimal(item.Value));
					coinAndIconList.Add(coinAndIcon);
				}
			}
			ViewBag.Varlik = varlik;
			return View(coinAndIconList);
		}

		[HttpGet]
        public IActionResult CoinUpload()
        {
            return View();
        }
		[HttpPost]
        public IActionResult CoinUpload(User_Wallet wallet)
        {
			wallet.UserID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
			wallet.CoinID = 1;
			wallet.Value = 10;
            walletManager.TUpdate(wallet);
			ViewBag.uploadSuccecful = true;
            return View();
        }

    }

}
