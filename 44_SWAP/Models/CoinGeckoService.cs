using System.Net.Http.Json;

namespace _44_SWAP.Models
{
    public class CoinGeckoApiResponse
    {
        public CoinData Tether { get; set; }
        public CoinData Ethereum { get; set; }
        public CoinData Binancecoin { get; set; }
        public CoinData Solana { get; set; }
        public CoinData Cardano { get; set; }
    }

    public class CoinData
    {
        public decimal Usd { get; set; }
    }

    public class CoinGeckoService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "CG-7yoS655kDQREJqZXffsQcvAS"; // Yeni API anahtarı

        public CoinGeckoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CoinGeckoApiResponse> GetAllCoinPricesInUSD()
        {
            string apiUrl = $"https://api.coingecko.com/api/v3/simple/price?ids=tether,ethereum,binancecoin,solana,cardano&vs_currencies=usd&api_key={ApiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CoinGeckoApiResponse>();
            }
            else
            {
                // Handle error
                return null;
            }
        }

        // Example usage for individual coins
        public async Task<decimal> GetUSDTPriceInUSD()
        {
            var prices = await GetAllCoinPricesInUSD();
            return prices?.Tether?.Usd ?? 0;
        }

        public async Task<decimal> GetEthereumPriceInUSD()
        {
            var prices = await GetAllCoinPricesInUSD();
            return prices?.Ethereum?.Usd ?? 0;
        }

        public async Task<decimal> GetBinancePriceInUSD()
        {
            var prices = await GetAllCoinPricesInUSD();
            return prices?.Binancecoin?.Usd ?? 0;
        }

        public async Task<decimal> GetSolanaPriceInUSD()
        {
            var prices = await GetAllCoinPricesInUSD();
            return prices?.Solana?.Usd ?? 0;
        }

        public async Task<decimal> GetCardanoPriceInUSD()
        {
            var prices = await GetAllCoinPricesInUSD();
            return prices?.Cardano?.Usd ?? 0;
        }
    }
}
