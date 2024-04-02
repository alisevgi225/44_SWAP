using Business_Layer.Concrete;
using Data_Acces_Layer.Entity_Framework;
using EntityLayer.concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _44_SWAP.Controllers
{
	public class RegisterAndLoginController : Controller
	{
		User_LoginManager loginManager = new User_LoginManager(new EFUser_LoginDal());
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(User_Login kullaniciKelimeler)
		{
			// Veritabanından kelimeleri çek
			List<User_Login> dbKelimeler = loginManager.TGetList();

			foreach (var item in dbKelimeler)
			{
				// Kullanıcının girdiği kelimeleri ayır
				string[] dbKelime = item.Words.Split(' ');

				// Tüm kelimelerin eşleşip eşleşmediğini kontrol et
				bool eslesmeVar = KelimelerEslesiyorMu(kullaniciKelimeler.Words.Split(' '), dbKelime);

				if (eslesmeVar)
				{
					// Giriş başarılı
					int userId = item.User_ID;
					var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, kullaniciKelimeler.User_ID.ToString()),
				new Claim(ClaimTypes.NameIdentifier, userId.ToString())
			};

					var claimsIdentity = new ClaimsIdentity(
						claims,
						CookieAuthenticationDefaults.AuthenticationScheme
					);

					var authProperties = new AuthenticationProperties
					{
						// Oturum süresi, çerez özellikleri vb. ayarlamaları buradan yapabilirsiniz
					};

					// Kullanıcıyı oturum açmış olarak işaretle
					await HttpContext.SignInAsync(
						CookieAuthenticationDefaults.AuthenticationScheme,
						new ClaimsPrincipal(claimsIdentity),
						authProperties
					);

                    // Giriş başarılı, başka bir sayfaya yönlendir
                    return RedirectToAction("Index", "HomePage");
				}
			}

			// Giriş başarısız
			return RedirectToAction("RegisetrConfirm");
		}

		private bool KelimelerEslesiyorMu(string[] kullaniciKelimeler, string[] dbKelime)
		{
			// Her iki listeyi küçük harfe çevirerek karşılaştır
			for (int i = 0; i < kullaniciKelimeler.Length; i++)
			{
				kullaniciKelimeler[i] = kullaniciKelimeler[i].ToLower();
			}

			return kullaniciKelimeler.SequenceEqual(dbKelime);
		}


		public IActionResult RegisetrConfirm()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Register()
		{
			var words = new List<string>()
		{
			"hello", "goodbye", "friend", "family", "home", "school", "work", "play", "eat", "drink",
			"like", "dislike", "happy", "sad", "big", "small", "hot", "cold", "fast", "slow", "beautiful",
			"ugly", "old", "young", "day", "night", "morning", "afternoon", "evening", "night", "week",
			"month", "year", "today", "tomorrow", "yesterday", "time", "money", "job", "travel", "holiday",
			"weather", "food", "drink", "restaurant", "menu", "health", "sick", "medicine", "doctor",
			"hospital", "emergency", "help", "thank", "sorry", "please"
		};

			List<string> randomWords = GetRandomWords(words, 10);
			string word = "";
			foreach (var item in randomWords)
			{
				word = word + item + " ";
			}
			User_Login user = new User_Login();
			user.Words = word.TrimEnd();
			loginManager.TInsert(user);
			return View(new List<User_Login> { user });

		}
		private List<string> GetRandomWords(List<string> words, int count)
		{
			Random random = new Random();
			return words.OrderBy(w => random.Next()).Take(count).ToList();
		}
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(
			CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login");
		}
	}
}
