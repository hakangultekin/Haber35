using Haber35.CORE.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.DAL.SeedData
{
    public static class SeedModelBuilderExt
    {
        public static void Seed(this ModelBuilder builder)
        {
            //şifre H1234
            AppUser user = new AppUser { Id = "05fcadae-fa72-4a86-89ee-2a4943ad265d", FirstName = "Hakan", LastName = "Gültekin", UserName = "hgultekin", NormalizedUserName = "HGULTEKIN", Email = "hakan35@hotmail.it", NormalizedEmail = "HAKAN35@HOTMAIL.IT", EmailConfirmed = true, BirthDate = new DateTime(1995, 08, 03), CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, PasswordHash = "AQAAAAEAACcQAAAAEKpyrdvmsPkODSCAljhCSJMJlvzQ/Mrbvkhxm4RP1kbHKFepD7AUAIs96OG40roakw==", SecurityStamp = "YFZSZFREU2D5QIXVH5AISZMENKE76MLB", ConcurrencyStamp = "d3ebae65-8fca-4b48-a673-149ea670d8c8", ImagePath = "/Images/Users/05fcadae-fa72-4a86-89ee-2a4943ad265d.jpg", Adress
            = "Teleferik mahallesi Balçova/İzmir"};
            builder.Entity<AppUser>().HasData(user);

            /// ********* ROLES **********
            IdentityRole adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = "ADMIN";
            builder.Entity<IdentityRole>().HasData(adminRole);


            /// ************ CATEGORIES ************ 
            Category teknoloji = new Category { CategoryName = "Teknoloji", CreatedDate = DateTime.Now, CreatorUserId = user.Id, ModifiedDate = DateTime.Now, ModifierUserId = user.Id, Status = true };
            Category spor = new Category { CategoryName = "Spor", CreatedDate = DateTime.Now, CreatorUserId = user.Id, ModifiedDate = DateTime.Now, ModifierUserId = user.Id, Status = true };
            Category bilim = new Category { CategoryName = "Bilim", CreatedDate = DateTime.Now, CreatorUserId = user.Id, ModifiedDate = DateTime.Now, ModifierUserId = user.Id, Status = true };
            Category tarih = new Category { CategoryName = "Tarih", CreatedDate = DateTime.Now, CreatorUserId = user.Id, ModifiedDate = DateTime.Now, ModifierUserId = user.Id, Status = true };
            Category yazilim = new Category { CategoryName = "Yazılım", CreatedDate = DateTime.Now, CreatorUserId = user.Id, ModifiedDate = DateTime.Now, ModifierUserId = user.Id, Status = true };
            Category saglik = new Category { CategoryName = "Sağlık", CreatedDate = DateTime.Now, CreatorUserId = user.Id, ModifiedDate = DateTime.Now, ModifierUserId = user.Id, Status = true };
            Category beslenme = new Category { CategoryName = "Beslenme", CreatedDate = DateTime.Now, CreatorUserId = user.Id, ModifiedDate = DateTime.Now, ModifierUserId = user.Id, Status = true };
            Category egitim = new Category { CategoryName = "Eğitim", CreatedDate = DateTime.Now, CreatorUserId = user.Id, ModifiedDate = DateTime.Now, ModifierUserId = user.Id, Status = true };
            Category sanat = new Category { CategoryName = "Kültür Sanat", CreatedDate = DateTime.Now, CreatorUserId = user.Id, ModifiedDate = DateTime.Now, ModifierUserId = user.Id, Status = true };
            Category edebiyat = new Category { CategoryName = "Edebiyat", CreatedDate = DateTime.Now, CreatorUserId = user.Id, ModifiedDate = DateTime.Now, ModifierUserId = user.Id, Status = true };

            builder.Entity<Category>().HasData(teknoloji, spor, bilim, tarih, yazilim, saglik, beslenme, egitim, sanat, edebiyat);


            /// ********** ARTICLES **********
            #region Add Articles
            Article art1 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Bilimin şakası olur mu?",
                Content = "Şakayla aldatmayı birbirinden ayıran en önemli kriter, şakacının yaptığı şakadan bir çıkar elde etmemiş olması ve şakanın yapıldığı kimseye bir süre sonra mutlaka ve mutlaka “maruz kaldığı şeyin şaka olduğu” bilgisinin verilmesi ya da anlamasının sağlanmasıdır. Yani yaptığınız şakayı itiraf etmiyor, bundan bir de çıkar elde ediyorsanız, yaptığınız şey şaka değil, bir tür aldatmadır.Kimi şakaların etkisi, şaka yapanla şaka yapılan arasında kalmaz, kişisel olmaktan çıkıp toplumsal hale bürünür ve bir hatayı, bir olumsuzluğu veya bir şeylerin yanlış gittiğini ortaya koymayı sağlar.\n\n Bu haftaki yazımda edebiyattan bilime, bir şeylerin yanlış gittiğini ortaya çıkarmayı amaçlayan kimi kahramanların yaptıkları bazı şakalardan örnek vermek istiyorum: Birinci örneğimiz edebiyat alanından… Chuck Ross adlı bir kablo TV satıcısı yazmaya çok meraklıydı ancak yayın dünyasının yazarlar arasında ayrımcılık yaptığına inanıyordu. Bunu kanıtlamak için Jerzy Kozinsky’nin 1969 yılında Amerikan Ulusal Kitap Ödülü’ne layık görülen “Adımlar” adlı romanını yeniden daktilo edip, başka bir yazar adıyla birlikte kitabın orijinal yayımcısı Random House da dahil ABD’deki 14 büyük yayınevine ve 13 edebiyat ajansına gönderdi. Kitabı bu 27 kurumdan hiçbiri tanımadığı gibi, tümü taslağı reddetti. Şaka, Ross’un da arzu ettiği üzere, yayınevlerinin isimsiz yazarlara nasıl büyük bir önyargıyla baktığını ortaya koymuş oldu.",
                Viewer = 1234,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ImagePath = "/Images/Post/1.png"
            }; // bilim

            Article art2 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Kitapçıdan teknoloji devine: Amazon ne yapıyor da dünyayı değiştiriyor?",
                Content = "Bir süredir 4 büyük firmayı, stratejilerini ve neler yaptıklarını daha yakından izlemeye başladım. Sektörde GAFA adı verilen bu dört firma (Google, Apple, Facebook, Amazon) farklı alanlarda liderlikleri olsa da, bir çok alanda da kesişiyor ve birbirleriyle yarışıyorlar. Hatta daha da sert çekişmelerin olması da kaçınılmaz gibi görünüyor.\n\nAmazon ülkemizde her ne kadar genelde AWS ile bilinse (hatta pek bilinmese) de aslında ABD’de bir çok sektörü derinden etkilemiş, değiştiren ve dönüştüren çok kilit firmalardan birisi. Amazon’un hikayesi, kuruluş süreci gibi konulara girmeden, amacım benim dikkatimi çeken bazı konularda -özellikle de Amazon’un evlere ne kadar sık ve etkili bir şekilde ulaşmasını içeren birkaç konuda Amazon’un ne durumda olduğunu paylaşmak sadece.\n\nABD’de 20 senedir hisseleri borsada işlem gören Amazon, perakende pazarında %5’lik bir paya sahip. Kitap satışı ile işe başlayan Amazon, şu anda neredeyse her şeyi bulabileceğiniz bir açık pazar.",
                Viewer = 1156,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/2.jpeg"
            }; // teknoloji, kültür sanat

            Article art3 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Spor Yapmanın Beynimizi Değiştiren Faydaları",
                Content = "Beynimiz kuşkusuz bizim için en önemli organımızdır. Beynimizi daha verimli kullanmak için birçok zihinsel aktivite yaptığımız gibi, uzmanlar tarafından önerilen fiziksel aktiviteleri de zaman zaman uygulamamız gerekmektedir. İşte bu fiziksel aktivitelerin en önemlisi spordur.\n\nSpor yapmak beynimiz için son derece önemli bir fiziksel aktivitedir. Spor yapan bireylerin, yapmayanlara oranla çok daha rahat odaklandığı, konsantre olduğu, hafızalarının çok daha gelişmiş olduğu ve algılarının da egzersiz yapmayan kimselere oranla çok daha açık olduğu bilimsel araştırmalar ile kanıtlanmıştır.\n\nBu anlamda yapılan araştırmalardan bir tanesi de bir Nörobilimci olan ve aynı zamanda bir TED Talks konuşmacısı olarak bizlere kendisini tanıtan Wendy Suzuki’ye ait. Wendy Suzuki, düzenli yapılan egzersiz sayesinde beynimizdeki dopamin, seratonin, nöradrenalin gibi hormanların salgılanışındaki artışı çalışmalarında gözlemlediğini bunun da beynimizin özellikle hafıza, odaklanma, konsantrasyon gibi işlevlerini yerine getirmede çok daha iyi çalıştığını söylemekte.",
                Viewer = 4897,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/3.jpg"
            }; // spor, sağlık

            Article art4 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Tarih Çağları ve Organizasyon Yapıları",
                Content = "Mağaradan, tarım toplumlarına.. Feodal beyliklerden, sanayi devrimine.. Ve günümüzdeki şirket yapılarına uzanan, insanlığın organizasyon yapısı değişimine baktığımızda tek bir şey görüyoruz: Daha fazla adalet arayışı! Şirketlerden koşarak istifa eden insanlar ne istiyor: Hiç çalışmamak mı? veya zevk aldığı, huzurlu olduğu, kendisinden bir şeyler verebildiği işlerde çalışmak mı? İnsanların büyük şirketlere girmek yerine startuplara yönelmesini, kazanç önemli değil kendim bir Instagram store açarım incik boncuk satarım çabasını, freelance çalışırım mesai saatlerimi kendim belirlerim mantığını incelediğimizde gelecekte şirketlerin istedikleri nitelikte çalışan bulmakta zorlanacağını tahmin etmek zor değil. Burada hemen akla gelen işsizlik ve benzer vasıflarda çok fazla insan varken bunun hiçbir zaman olmayacağı. Kesinlikle evet! Hiçbir zaman şirketler çalışan bulamayıp boş kalmayacak. Ancak istediği adamları bulamayacağı ya da dengeyi kaybedeceği noktaya gelecek.",
                Viewer = 32658,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/4.jpeg"
            }; // tarih - kültür-sanat

            Article art5 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Dependency Injection nedir? ASP.NET Core projelerinde nasıl kullanılır?",
                Content = "Arkadaşlar selamlar bu yazımda, ASP.NET Core projelerinde çok kullandığımız Dependency Injection kavramından ve yaşam döngüsünden bahsedeceğim. Dependency injection SOLID prensiplerini uygularken bağımlılıkların en aza indirmek için kullanılan bir yöntemdir. Dependency injection kullanımı ile beraber loosely coupled yapısına da uygun kod yazmış oluruz. Projeye yeni özellikler eklerken, düzeltme veya ekleme yapılacak bölümler en aza indirilmiş olur. Bağımlılık tanımlarını yaparken 3 adet farklı yaşam döngüsü bulunmaktadır.\n Transient (AddTransient) : Uygulama içerisinde bağımlılık olarak oluşturduğumuz ve kullandığımız nesnenin her kullanım ve çağrıda tekrardan oluşturulmasını sağlar. \n Singleton (AddSingleton) : Uygulama içerisinde bağımlılık oluşturduğumuz ve kullandığımız nesnenin tek bir sefer oluşturulmasını ve aynı nesnenin uygulama içinde kullanılmasını sağlar. \n Scoped (AddScoped) : Uygulama içerisindeki bağımlılık oluşturduğumu nesnenin request sonlanana kadar aynı nesneyi kullanmasını farklı bir çağrı için gelindiğinde yeni bir nesne yaratılmasını sağlar.",
                Viewer = 1907,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/5.png"
            }; // yazılım, teknoloji

            Article art6 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Her Şeyin Başı Sağlık, Sağlığın Başı Uyku",
                Content = "Kimilerinin en büyük korkulu rüyası(!), kimileri için tam bir zaman kaybı. Hayatımızı devam ettirebilmek için en temel şeylerden biri uyku . Gerçekten gerektiği kadar önem veriyor muyuz, kaliteli uyku uyumayı başarabiliyor muyuz? Bunlar hep büyük muammalar. Ancak araştırmaların ortaya çıkardığı gerçek ise, insanların gitgide daha az uyku uyumaya başladığı. Bu vahim durum, uzun vadede erken ölüm riskinde artışa kadar varan kapsamlı sağlık sorunlarının kaynağı olarak görülüyor. \n Ömrümüzün yaklaşık üçte birlik kısmını alan uyku pek çok kişi tarafından zaman kaybı olarak görülür. Hatta daha az uyuyan insanlar, çok uyku uyuyanların hayatı kaçırdıklarını, zamanın bir kısmını boşa harcadığını düşünür. Ancak araştırmalar yeterince uyku uyumayan insanların yaşam sürelerinin daha kısa olduğunu gösteriyor. Bir başka deyişle hayatı kaçırmayayım derken, başka türlü kaçırıyor olabilir.",
                Viewer = 1299,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/6.jpeg"
            }; // sağlık

            Article art7 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Beslenme ile İlgili Büyüyen Yeni Trend: İklim Diyeti",
                Content = "Bireysel olarak çevre üzerindeki etkimizin bir bölümünü neler yediğimiz belirler. Bugüne kadarki en sofistike analizlere göre, sağlıklı yiyecekler yemek her zaman çevre için de en iyi yoldur. Araştırmacılar, sağlıksız diyetlerin insanlara ve gezegene ciddi zarar vererek toplumu tehdit ettiğini gösteriyor. İklim değişikliği göz önünde bulundurularak yemek yemek, 2020'nin en büyük gıda trendi olarak şekilleniyor. Günümüzde beslenme ile ilgili büyüyen bu yeni trend, sağlıklı beslenirken bir yandan da öğünlerin doğaya daha az zarar vermesine dikkat etmeyi içeriyor. İnsanlar, daha az et ve süt tüketen, çevre dostu alternatifler arayan bir ‘iklim diyetine’ yöneliyorlar.\n\n Daha fazla sebze ve daha az (veya hiç) hayvansal ürün yemek, daha sürdürülebilir gıda seçimleri yapmak, sağlığımızı da iyi yönde etkileyen bir unsur. Bununla beraber, vegan olmak ve iklim diyeti uygulamak aynı şey olarak algılanmamalıdır. Hatta badem ve soya gibi popüler vegan gıdalarının yüksek su kullanımı ve ağaçsızlaşma açısından negatif etkileri olabilir. Vejetaryenlerin, veganlardan değişik olarak tükettiği süt ürünlerinin, son dönemlerde yapılan yeni araştırmalar sonucunda, olumlu etkisi de soluklaşmış durumda. Kısaca, pastırma yerine peyniri tercih etmenin gezegen için çok daha yararlı olmadığı ortaya çıktı.\n\nAraştırmalar, genel olarak, iklim, su ve sağlık krizlerini hafifletebilecek diyet değişikliklerini öneriyor. Büyükbaş hayvan, koyun ve keçi etlerinin tüketiminin en yüksek çevresel zarara neden olduğu doğrulanıyor. Ancak, günde bir kez belirli hayvansal ürünler yemenin, etleri hariç tutan ancak süt ürünleri tüketen lakto-ovo vejetaryen diyetlerinden, dünyamız için daha az zararlı olduğunu ortaya çıkarıyor. Tavuk ve balık, özellikle yerel çiftçilerden veya yerel balık pazarlarından satın alındığında, kırmızı etten daha iyi seçenek durumundalar. Yerel et, nakliye emisyonlarını azaltmakta yardımcı konumdadır. Meyve ve sebze satın alırken de “mevsimsel ve bölgesel” durum da değerlendirilmelidir.",
                Viewer = 2489,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/7.png"
            }; // beslenme - sağlık

            Article art8 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Eğitim Evriliyor mu?",
                Content = "Tüm kurumlar hızla evrilirken, en eski kurumlardan biri olan okulların da bu değişimden etkilenmemesi mümkün değil. Önümüzdeki yıllarda eğitim bu güne kadarki en hızlı değişim döneminden geçecek. Tüm sektörlerde gördüğümüz altüst olma, eğitimde de olacak. Eğitimciler için pek heyecanlı bir dönem geliyor: ya altüst edileceğiz ya da altüst edenlerden olacağız.\n\nGünümüzün eğitim sisteminin birçok öğesi (8 yıllık zorunlu okul, okuma/yazma ve aritmetik temelli müfredat, not, sınıf, ders, öğretmen) 18. yüzyıl sonunda Prusya’da kurgulandı ve 19. yüzyılda ABD’de geliştirildi. Öğretmenden öğrenciye içerik nakli üzerine kurulu bu üretim hattı modelinin temel amacı emirlere uyabilen, zamanını yönetebilen, rutin süreçleri uygulayabilen, temel okuryazarlığa sahip endüstriyel ekonomi işçisi yetiştirmek idi. Bu modelin zamanı çoktan geçti. Bilginin meta olduğu çağımızda, bırakın endüstri işçisini, bilgi çalışanı yetiştirmek bile yetersiz, artık doğru cevabı aramak yerine farklı cevaplar oluşturabilecek akıllı yaratıcılar yetiştirmek gerekiyor. Fakat maalesef, elimizdeki eğitim sistemi geleceğin toplumu için gereken insan kaynağını oluşturmaktan aciz. Tüm dünya eğitimde dönüşümün sancılarını yaşıyor. Ülkemizde ise durum daha da vahim: bırakın geleceğe insan yetiştirmeyi, eğitim sistemimiz günümüzün ihtiyaçlarını bile karşılamaktan uzak. OECD 2015 Yetişkin Becerileri Araştırması’nda en üst düzeye erişebilen yetişkin oranında tüm kategorilerde (sözel, sayısal, teknoloji ile problem çözme) ve tüm yaş gruplarında (16–24, 25–34, 35–44) sonuncu olmamız tesadüf değil. 2015’de gelmiş geçmiş en kötü PİSA sonuçlarını almış olmamız da tesadüf değil; bu yılın sonunda açıklanacak olan 2018 sınavı sonuçları daha da kötü çıkabilir. Milli Eğitim Bakanımız iyi şeyler için çabalıyor, fakat sistemi bir kişinin kısa sürede değiştirebilme olasılığını düşük görüyorum.\n\nÇağımızda eğitimde değişimi tetikleyen 6 önemli güç var: hızla artan bilgi, yükselen maliyetler, eşitsizlikler, eğitime hızla giren teknoloji, eski sistemi reddeden Z kuşağı ve eğitimde dönüşümü sağlayacağına inandığım girişimciler. Bu 6 önemli gücün etkileşimi sayesinde önümüzdeki 20 yıl içinde eğitimde ciddi bir dönüşüm yaşanacağını düşünüyorum. 21. yüzyılda eğitimin amacı artık öğretmenden öğrenciye bilgi aktarmak değil, çünkü artık bilgi meta haline geldi ve bilgiye ulaşım çok kolay. Öğrenciler istedikleri yerden istedikleri zaman internetten video izleyerek veya farklı bir kaynaktan istedikleri şeyi öğrenebiliyorlar. Sınıfta oturup öğretmeni dinlemek yerine kendi aralarında kurdukları irili ufaklı fiziksel veya sanal gruplar ile rahatlıkla öğrenebiliyorlar. Eğitim sistemi öğrencilerin değişen öğrenme biçimlerini ve alışkanlıklarını göz önüne alınarak yeniden kurgulanmak zorunda. 21 yüzyılda eğitimin temel amaçları tutku ve hedef keşfi, kritik becerilerin (eleştirel düşünme ve problem çözme; iş birliği, hızlı hareket ve adaptasyon; inisiyatif ve girişimcilik; etkin sözlü, yazılı ve multimedya iletişim; bilgiye ulaşım ve bilgi analizi; merak ve hayal) geliştirilmesi ve belki de en önemlisi öğrenciye ilham vermek!",
                Viewer = 1327,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/8.jpeg"
            }; // eğitim

            Article art9 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Sanat uzun, hayat kısa.",
                Content = "Felsefenin ontoloji, siyaset, mantık gibi şanlı kolları varken neden estetik ve sanatla ilgilendiğimi sormuştu birkaç kişi. Çünkü çoğu insan sanatla ilgilenmenin zengin hobisinden öte bir şey olmadığını düşünüyor. Öyle ya iyi bir resim ya da heykel ancak ev dekore edebilir. Hala görüyorum bazen yorumlarda “hakikatin peşindeysen, hakikati araştırıyorsan…” şeklinde başlayan ve sanatın hakikatini küçümseyen ifadeler. Ben sanırım kendimi anlatamadım. Hakikat denen bir şey olmadığı ve hayatta katlanabilmenin en iyi yolu sanat olduğu için sanatla ilgileniyorum. Tarkovsky’nin sevdiğim bir sözü var, “Dünya mükemmel olmadığı için sanat vardır.” demişti. Bu sanat 15. yüzyılda resim ve heykeldi. Şimdi ise sinema, şiir, müzik, edebiyat… Yol değişebilir ama örtülü amaç hep aynı diye düşünüyorum. Yaşamı anlamak ve katlanmak.\n\nHakikatperest değilim. Sonsuz deneyim ufukları var benim için yalnızca. Ben bir müzik dinlerken veya bir film izlerken o nesne öznede nasıl bu etkiyi yaratıyor; nasıl özneyi ele geçiriyor; nasıl bazı şeyler bizi büyülerken diğerleri sıradan geliyor; nasıl ortaya haz duygusunu ortaya çıkartıyor ve nasıl kendine yeni bir gerçeklik yaratabiliyor bunları merak ediyorum. Sanat yapıtını ve estetik deneyimi anlamaya çalışıyorum. Anlayayım ki tüm dünya deneyimim tıpkı sanat deneyimim gibi estetikleşsin, yürümek dahi dans etmek kadar zevk versin istiyorum.\n\nSonsuzun değil; yaşamın peşindeyim.",
                Viewer = 6659,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/9.jpeg"
            }; // sanat

            Article art10 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Yapay Zeka ve Sanat",
                Content = "Yapay zekâ yolunda atılan adımları ve yaşanan gelişmeleri son derece ilgiyle takip ediyorum. Bu alanda beni çok heyecanlandıran pek çok yenilikle her geçen gün karşılaşsam da özellikle belirtmeliyim ki; bu yenilikler içinde yapay zeka ve sanat ilişkisi hiç ilgimi çekmemişti. Ancak geçen yıl bir konuşma sonrası dinleme fırsatı bulduğum Robot Şair Deniz Yılmaz ‘ın hikayesi beni şaşırtan ve üzerinde düşünmeye iten bir etki yarattı.\n\nBir düşünsenize; “akıllı” bir robot gerçekten okunası şiirler yazıyor, sanatla uğraşıyor; yani “his”lerini ve “düşünce”lerini toplumla buluşturmaya, sesini duyurmaya ihtiyaç duyuyor ve bunda da son derece başarılı. Öyle ki, kendi adını taşıyan şiirlerinin derlendiği kitabı sayesinde okurlarıyla, “hayran kitlesi”yle buluşuyor.\n\nDeniz Yılmaz’ı yaratan düşünceyi, beyni daha önceden de yaptığımız özel sohbetlerle şahsen tanıyorum; ancak onu sizlerle de buluşturmak, yapay zekâ ve sanatı nasıl harmanladığını kendi ağzından sizlere aktarabilmesini sağlamak üzere geçtiğimiz günlerde Dijital CEO ile Teknoloji Sohbetleri’nde kendisini ağırladım ve son derece keyifli bir sohbet gerçekleştirdik. Bager Akbay’dan bahsediyorum. Bana göre çok özel bir beyne sahip ve kendisiyle yaptığım her sohbette yepyeni bir bakış açısı kazanmamı sağlıyor. O nedenle sizlerin de bu sohbetten keyif alacağınızı umuyorum.",
                Viewer = 4897,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/10.jpg"
            }; // sanat - yazılım- teknoloji

            Article art11 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Sağlık İçin Teknoloji",
                Content = "Son günlerde sağlık teknolojilerine dair gelişmelere olan merakımın ve bu alanda yeni bilgiler öğrenme isteğimin artması için bazı nedenler oldu. Öncelikle yeni cerrahi teknolojilerin bugün geldiği noktayı, sonrasında genetik hastalıkların tedavisinde kullanılmak üzere çalışılan yeni teknolojileri öğrenme fırsatı buldum.\n\nBeni en çok şaşırtan, sağlık teknolojilerinin (HealthTech) günlük hayatımızda kullandığımız teknolojilerden çok daha hızlı geliştiğini fark etmek oldu. Artık yeni bilgisayar modellerine şaşırmıyor ya da yeni telefon modellerine hayran kalmıyoruz. Bir bakıma kendi sınırlarına ulaştıklarını (singularity) söyleyebiliriz. Ancak sağlık için teknoloji kullanımı; güncel donanım ve yazılımlar sayesinde şaşırtıcı bir şekilde gelişiyor. Artık vücudumuzun en zor bölgesindeki cerrahi müdahaleler açık yara olmadan robotik kollar yardımıyla yapılıyor. Veya iflas eden bir organın yerine yeni organlar transplantasyon yapılmadan görev alabiliyor.\n\nTüm bunları paylaşırken uzmanı olmadığım bir konuda ahkam kesmek değil, bilmediğim bir alanda gelişen teknolojik gelişmelere karşı şaşkınlığımı ifade etmek istedim. Sadece kendi uzmanlık alanlarımıza bakarak dünyayı değerlendirmek yerine, diğer alanlara da göz atmakta her zaman fayda var. Bu sayede bazen kendi işlerimizde çok büyük sandığımız değişim ve sıçramaların değerlendirmesini daha sağlıklı yapabiliriz. Bu nedenle diğer disiplinlerdeki gelişmeleri öğrenmeye ve merak etmeye zaman ayırmak gerekiyor.",
                Viewer = 489,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/11.png"
            }; // teknoloji - sağlık


            Article art12 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Yazılımcı Konsantrasyonu, Beyin Akış Durumu ve Bölünmeler Üzerine",
                Content = "Bu yazıyı 2013 senesinde akademik kariyerimin bebek adımlarını atarken (sektörden yeni geçmiş olmanın verdiği bir gazla) ilk defa kaleme almış ve farklı bir mecrada yayınlamıştım. O zaman da çok ilginç ve keyifli yorumlar almıştım. Şimdi Aykırı Yazılımcılar için yazıya tekrar el attım ve güncelleyerek sizlerle paylaşıyorum.\n\nÖzellikle yazılım işine hiç girmemiş ya da bu işe bulaşmamış ama programlamadan çok iyi anlayan :) arkadaşlara, bölünmenin mahiyetini ve maliyetini terbiyenizi bozmadan bilimsel bir dille anlatmak için yine bu yazıyı kullanabilirsiniz…\nYazılım geliştirme (programlama, kodlama), yaratıcı bir iş çıkartmayı (değeri olan bir çıktı elde etmeyi) hedefleyen bir süreç olup, azami dikkat ve konsantrasyon gerektirir.\nNot: Tam da bu noktada “yazılım bir sanat mıdır?”, “programlama sanatı”, “yaratıcılık ve yazılım”, “yazılım mühendisi olma yazılım sanatçısı ol”, “yazılım geliştirme sadece yaratıcı insanlar için mi?” gibi ucu bucağı bitmeyen konuları açıyoruz… Şimdilik bunları az öteye park edelim :)\n\nTam konsantre bir programlama sırasında beyin bir “akış” (flow) moduna geçmekte, etrafla ilişkisini kesmekte ve bir probleme günlerce konsantre olabilmektedir. Ciddi bir çevresel izolasyon gerektiren akış moduna girildiğinde, üretkenlik maksimum düzeydedir ve tüm kritik kodlamalar bu seviyede yapılır.",
                Viewer = 6489,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/12.jpg"
            }; // teknoloji - sağlık - bilim

            Article art13 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Sağlık için Blockchain",
                Content = "Hasta hayatını kurtarabilecek bilginin hızlı paylaşımı ya da maliyet yaratan bürokrasinin azaltılması gibi konularda Blockchain bazlı girişimler sağlık sektörünün oyuncuları olan hasta, hastane, sigorta ve ilaç şirketlerine yeni açılımlar getirebilir.\n\nSon iki yazımızda Blockchain’nin sadece finans dünyasında değil başka pek çok alanda da kullanılabileceğini söylemiş ve bunlardan sanat ve insani yardım dünyası yararına yapılabileceklere bakmıştık.\n\nBu yazımızda ise sağlık alanında Blockchain bize ne gibi faydalar sağlayabilir ona göz atacağız.\n\n2015 yılı Haziran ayında “thedarkoverlord” isimli bir hacker yaklaşık 10 milyon Amerikalı’ya ait medikal veriyi 1 milyon ABD Dolarına yakın bir rakamdan satışa çıkardı. Hacker bu gizli medikal bilgileri dört ayrı şirketin ana bilgisayarlarından almıştı. İşte size merkezi sistemlerin en büyük dezavantajlarından biri: Verilerin bir arada tutulduğu merkezi yapılar her zaman güvenlik açığı potansiyeli taşır.\n\nÖte yandan sağlık kurumlarının kendi özel veritabanlarını tutmaları ve hastaya ait bilgilerin kurumlar arasında paylaşımı ciddi bir sıkıntı. Sistemlerin birbiri ile konuşmaması bir yana bir şekilde iletişim sağlansa bile yaşanan gecikmeler dakikaların bile çok önemli olduğu kimi durumlarda daha ciddi sorunlara hatta ölümlere kadar giden kayıplara yol açabiliyor. Bilgi eğer hastanın kontrolünde olsa acil müdahale gerektiren kritik durumlarda hasta (ya da yakınları) o an ulaşabildikleri ilk sağlık kurumunda yetkili kişilere bu bilgilere erişime izin verebilir ve hastaya gerekli müdahaleler zamanında yapılabilir.",
                Viewer = 1548,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/13.jpeg"
            }; // teknoloji - sağlık - yazılım


            Article art14 = new Article
            {
                CreatorUserId = user.Id,
                Title = "En Doğru Beslenmenin Yolu Teknolojiden Geçer",
                Content = "Yediklerimizin vücudumuza dolayısıyla da sağlığımıza etkisi konusunda yapılmış binlerce araştırma bulunuyor. Bu doğrultuda dikkat etmemiz gereken ya da her zaman tüketmeye özen göstermemiz gereken besin grupları var. Ancak bu besin gruplarının etkileri daha genel geçer doğrular şeklinde kabul ediliyor. Farklı bireylerde aynı besinler bambaşka sonuçlara sebep olabiliyor. Örneğin lahana genelde yararlıdır ancak böbrek taşı geliştirmeye yatkın bireylerin dikkat etmesi gereken yiyeceklerin başında geliyor.\n\nDoğru yiyecekleri tüketme ve daha sağlıklı bir bedene sahip olma konusunda farklı alanlarda destek veren teknolojik birçok çözüm var.İlk olarak tüketilen gıdaların içindeki bileşenlerin neler olduğuna odaklanan uygulamalar var. Bu uygulamalar genellikle bir bileşenin belli bir besinde olup olmadığını ölçebiliyor. Nima isimli girişimin evde kullanım için geliştirdiği kit sayesinde bir besinde gluten olup olmadığını ölçebiliyorsunuz. Tellspec ise tahmini olarak bir yiyecekteki kalori ve besin değerlerini ve glisemik yüklemeyi gösteriyor. MyDX ise geliştirilen aparatla yiyeceklerde ağır metaller ya da zehirli ilaçlar var mı onu kontrol etmenizi sağlıyor. İçtiğiniz su için de kullanabiliyorsunuz.\n\nTeknolojinin kişisel sağlık konusunda katkıda bulunduğu alanlardan biri de sanal danışmanlarla doğru beslenme ve egzersiz tavsiyeleri vermek. Ph360 firmasının geliştirdiği Shae isimli danışman önce detaylı bir soru formunun ardından sizi iyice tanıyor ve her gün sağlık durumunuz, hedefiniz ve ortam şartlarına göre en doğru yiyecekleri size öneriyor. Ayrıca ne zaman ve ne şekilde egzersiz yapmanız gerektiğini de iletiyor. Sadece soru formu değil zamanla alışkanlıklarınızı öğrenerek ona göre algoritmalar geliştiriyor ve önerilerini çeşitlendirebiliyor.\n\nDiğer bir alan sizin kişisel sağlık değerlerinizin takibi ile ilgili. Habit, Nutrigenomix, PlainSmart, DNAFit, LifeNome gibi birçok girişimin evde kullanılmak için geliştirdiği kitlerle kan değerleriniz ve DNA’nız takip edilebiliyor ve metabolizmanıza göre uygun beslenme önerileri alabiliyorsunuz. Bu daha da kişisel olarak takibinizi sağlıyor.",
                Viewer = 1658,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/14.png"
            }; // teknoloji - sağlık

            Article art15 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Sanatla iyileşmek",
                Content = "Geçtiğimiz günlerde internet dergilerini karıştırırken karşıma tınısı çok hoş bir kavram çıktı: “Sanat terapisi” bir solukta okuyup bitirdiğim yazının ardından bunu mutlaka kendi okuyucularımla da paylaşmalıyım diye düşündüm.\n\nHemen hepimizin dönem dönem içine girdiğimiz zor günleri atlatmak için sevdiğimiz şeylere yöneldiğimiz bilinen bir gerçek, ancak inanın bana sanat terapisi çoğundan daha etkili ve bilinç dahilinde gerçekleştirile bir yöntem. Öncelikle kavrama bir tanım getirerek başlamak istiyorum anlatmaya. Sanat terapisi, sanatın farklı alanlarını (resim, müzik, edebiyat veya dramayı) kullanarak kişilerin kendilerini daha iyi yorumlayıp iyileşme sürecine girmelerini sağlayan bir terapi biçimi.\n\nSanat terapisinin tarihçesi oldukça eskilere dayansa da toplum içerisinde yaygınlık kazanması yaşadığımız günlere tekabül ediyor. Hastaların ortaya koyduğu sanatsal ürünler üzerinden yapılan değerlendirmeler ilk kez 1870'li yıllarda yapılmış. Özellikle II. Dünya savaşının akabininde yaşanan ağır bireysel travmaların çözümünde de yer yer kullanılan sanat terapileri Sigmund Freud ve Carl Gustav Jung gibi isimlerin de kavrama ilişkin farklı yaklaşımlarıyla bugüne dek ulaşmış. Sanat terapisinin Türkiye ayağında ise ilk çalışmaları Prof. Dr. Kazım Dağyolu’nun yaptığını görüyoruz. Dağyolu’nun izinden giden Prof. Dr. Süleyman Velioğlu ise çalışmalarını 1957'den beri yönetilmeye devam eden Psikopatolojik Sanat Laboratuvarında yürütmüş. Günümüzde daha da açılım kazanan sanat terapileri İstanbul Üniversitesi Tıp Fakültesi Anabilim Dalından Doç. Dr. Nurhan Eren’e emanet edilmiş. Eren 1995 yılından beri bireysel ve grup odaklı sanat terapileri gerçekleştiriyor. Terapilerinde ise kişinin davranışlarını resim çalışmaları üzerinden uzun sürelere yayarak değerlendirdiği bir metot izliyor.",
                Viewer = 3335,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/15.jpg"
            }; // teknoloji - sağlık - sanat


            Article art16 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Yeni Medya Sanat Değil",
                Content = "Bir arkadaşım, kendisi iyi de bir fotoğrafçı, sanat tarihi okumasına rağmen girdiği bu yıl ziyaret ettiği bir sanat sınıfında hiç anlamadığı fizik konuşmaları yapıldığından bahsediyordu. Buna sanat denmesini de anlamıyor, kendisini bu durum karşısında garip hissettiğini de ekliyordu. Hatta “Bu insanlar sanatçı değil ki biliminsanı!?” diyerek noktayı koydu. Konu konuyu açtı kahvaltıda, ben de anlatmaya başladım.\n\nNeden sanat ve bilimin bu yakınlığı kimimizi heyecanlandırıyor?\nBu soruya uzun uzun argümanlar, makaleler, içeriklerle cevap verebilirim ancak biraz ilgilenip bu yazıya kadar geldiyseniz bildiğinizi varsayıp devam ediyorum açıklamalara.\n\nBu yüzyıl daha başından şiddetli bir büyüme eğrisi çiziyor. Sanki milenyumun ilk saatlerinde bilgi perdesine roket fırlattık yırtıp yırtıp geçiyoruz. 2000'den 5 Şubat 2016'ya kadar bir bilginin diğerini mayalaması süreci elbette insanın merakını cezbetti.\n\nTeknoloji — Sanat — Bilim yakınlığı elbette gündelik teknolojik aletlerin hayatımıza girmesiyle, 1960'lardan itibaren dikkat çekmeye başlıyor. Sonrasında yapılan tonla performans, yazılım, robot, sensör temelli, mekanik temelli, görsel temelli işlerle yeni medya diye genellediğimiz bir alan varoluyor.\n\nYeni medya eserlerine bu kadar yükselmemizin sebebi de işte bu merakımızı cezbeden çağımızın çeşitliliği. Girişimcilikten sanata bilgi temelli herşeyin değerini kaynaklarımızı çeşitlendirerek arttırıyoruz. İyisi kötüsüyle gani gani bilgi var ortada. Bu bilgilere ulaşmamızı sağlayan şey kilit kelimemiz burada.",
                Viewer = 2548,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/16.jpeg"
            }; // teknoloji - sanat

            Article art17 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Yeni Nesil Eğitim Sistemi Ve Yazılım Dünyası",
                Content = "Merhaba, bugün son zamanlarda en çok ilgi duyduğum konulardan biri olan online eğitim deneyimlerimi aktaracağım. Gündelik hayatta koşuşturmaktan hobilere zaman ayırmak ya da ilgi duyduğumuz bir konu hakkında kursa gitmek neredeyse imkansız hale geliyor. Bu yüzden işe giderken yolda ya da evde boş zamanlarımda ilgi duyduğum bir konu hakkında eğitim almak bence inanılmaz güzel bir fikir. Zaman olsa bile belirli bir zaman aralığını ayırmak son derece zor bir durum.\n\nÖrneğin java öğrenmek istiyorsunuz ve bir kursa yazıldınız diyelim. Geçmiş olsun, cumartesi ve pazar sabahlarınız yollarda heba oldu. Sabah 9:00'dan öğlen 15:00'e kadar kursta ders dinleyerek geçireceksiniz. Peki ya canınız bu hafta sabah 9:00'da java dinlemek istemiyorsa? Gece 4:00'da bir anda java öğrenme aşkınız gelirse ne olacak? Bilmiyorum sizin için durum nedir ama ben genelde kafama estiği zaman bir şeyler yapmayı seven biriyim. Her istediğim zaman her istediğimi(belli bir çerçevede) öğrenebileceğim bir online servis varken bunu denememek saçma olurdu.\n\nBizlere bu lüksü sağlayan tek bir servis yok aslında, Udemy, CodeSchool, TreeHouse gibi bir sürü birbirine çok yakın konseptlerde hizmet sağlayıcılar bulunuyor. İlk başlarda Udemy’den ilgi duyduğum konularda dersler satın almaya başladım ancak istediğim kalitede içerikler yoktu ne yazık ki. Udemy aslında sadece bir aracı, birisi geliyor ben Java anlatacağım diyor çekiyor videolarını, bizlerde gidip satın alıyoruz. Böyle olunca dersin içeriği ve kalitesi belli bir standartta olmuyor. Çok kaliteli derslerde var, çok kalitesiz derslerde. Bu sebeple başka arayışlara girdim ve bana göre sektördeki en iyisi olan TreeHouse ile devam etme kararı aldım.",
                Viewer = 1368,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/17.png"
            }; // eğitim - yazılım

            Article art18 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Spor endüstrisinde dijitalleşmenin geleceği: Taraftar tokenları",
                Content = "Pandemi koşullarının dünya ekonomisi üzerindeki etkileri hissedilmeden çok daha önce, spor endüstrisi uzun vadeli finansal kazanımlar sağlanması gerekliliğine dair sinyaller veriyordu. Bugün ise sinyaller alarm zillerine dönüşmüş durumda.\n\nAvrupa ülkelerinde bahis reklamları üzerine getirilen regülasyonlar 2019 yılı itibarıyla İtalya Serie A takımlarının yıllık 100 milyon Euro, İspanya La Liga takımlarının ise 90 milyon Euro kayıp vermesine sebep oldu.\n\nTeknoloji bazlı inovasyonların spor endüstrisinin şiddetle ihtiyaç duyduğu gelirleri yaratmakta elzem olduğu apaçık görünüyor. Ayrıca, Sport Tomorrow’un çalışmaları, 2030 yılında Z ve Alfa kuşaklarının dünyanın gelir yaratan çalışan nüfusunun neredeyse yarısını oluşturacağını gösteriyor. Bu nesiller, teknolojiyle hemhal olarak büyüyor ve tüketim alışkanlıkları ayrılmaz bir şekilde teknolojiye bağlı. Bu gelişmeler ışığında spor endüstrisinin de değişen dünyanın kurallarını hızlı bir şekilde benimsemesi gerektiği görünüyor.\n\nPandeminin yarattığı koşullar ile çok sayıda gelir kapısından uzaklaşmak zorunda kalan spor kulüpleri dijitalleşmek ve yeni gelir yöntemleri oluşturabilmek için ihtimaller üzerine çalışıyor. Taraftar tokenları tam da bu noktada devreye giriyor. Peki, nedir bu taraftar token?\n\nTaraftar tokenları, sahiplerine Socios.com’da taraftarı oldukları kulüplerle bağlantı kurma şansı sağlayan dijital varlıklar.",
                Viewer = 2019,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/18.png"
            }; // spor - teknoloji - yazılım

            Article art19 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Anlatılmayan Bilişim Tarihinin Peşinde Bir Serzeniş…",
                Content = "Bazen günlük problemlerle baş edebilmek için okuma yapmak, seçenekleri, alternatifleri öğrenmek, bilgimizi artırmamız gerekir. Çünkü karşılaştığımız problemler bilgi eksikliğimizi yüzümüze çarparlar.\n\nZamanında bizi meşgul eden problemlerden biri Apache Kafka’ya (bir mesajlaşma sistemi) gönderilen JSON formatlı mesajların şema/biçim açısından gelişimini/değişimini yönetebilmekti. Problemin bir boyutu gönderilen mesajlardaki alanların tipini ve uzunluğunu denetlemekti. Yani şemasını kontrol etmek, şema denetimi, şemaya uygunluğun kontrol edilmesi. Diğer bir boyutsa ileride gelecek olan değişikleri geriye/ileriye uyumlu bir biçimde nasıl yönetebileceğimizdi. Yani şema evrimini/değişimini nasıl yönetecektik? Kesin olan şey değişimin kaçınılmaz olduğudur. Yazılım yaşayan bir şeydir. Durmadan değişir. Değişimin bitmesi öldüğü anlamına gelir. Yerine ya yenisi alınır ya da yeniden yazılır. Tablolara yeni kolonlar eklenir, veya var olan kolonlar silinir veya isim değişiklikleri yapılır. Bu değişiklikler en arka taraftan en ön tarafa, kullanıcıya gidinceye kadar olan tüm katmanlarda veri aktarımında değişiklik yapmayı gerektirir. Dolayısıyla Kafka’ya ilettiğimiz mesajların şemasal değişimini nasıl yöneteceğimiz, nasıl ilerleyeceğimiz konusu gündemdeydi.\n\nO sıralar Martin Kleppmann’ın yazdığı “Designing Data Intensive Applications” kitabını okuyordum. Adı gibi yoğun (intensive) bir kitap. Hala okuyorum, muhtemelen önümüzdeki bir kaç yıl daha okuyacağım gibi. :)\n\nGündemde olduğu için kitabın şema evrimi ile ilgili bölümüne öncelik tanıdım. JSON, XML, Protocol Buffers, Avro, Parquet gibi verileri iletirken veya saklarken nasıl ifade edileceğini belirleyen veri kodlama/serileştirme biçimlerini anlatıp, şema evrimi/değişimi açısından bu standartları inceliyordu.\n\nKodlama biçimlerini metin temelli ve binary diye sınıflandırıyordu. Gerçi bu ayrımın daha öncesinde de farkındaydım, ama şimdi özel olarak bu konuya odaklanmıştık. Sonrasında sorular sorular. Metin ne, binary ne, her şey zaten ikili tabanda ifade edilmiyor mu? Her şey sonuçta 1/0 değil mi? Derken url-encoding, base64, utf8, unicode, ascii vb. kodlama biçimlerine dallandım. Kurcaladıkça alttan bir şeyler çıkıyordu. Her yeni öğrendiğim şey yeni şeylere kapı aralıyordu. Kodlama, alfabeler, sayı sistemleri vb. derken olay tarihsel bir yolculuğa dönüştü. Morse alfabesi, telgraf vs. kadar gittik. Bugünü anlamak için geçmişe yapılan bir yolculuk.",
                Viewer = 10256,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/19.png"
            }; // tarih - teknoloji - yazılım

            Article art20 = new Article
            {
                CreatorUserId = user.Id,
                Title = "YouTube kanalları ve Popüler Bilim",
                Content = "YouTube her bir gün için yaklaşık 50 yıllık içeriğin yüklendiği (her dakika başına 300 saat), bir milyarın üzerinde insanın öyle ya da böyle yolunun düştüğü ve ortalamada her gün 5 milyar videonun izlendiği, kendi başına dünya üzerindeki tüm internet trafiğinin %17'sini kontrol eden bir site. Ancak elbette bunları (sayı detaylarına kadar olmasa da) hemen hepimiz biliyoruz. YouTube’un Google tarafından 2006'da satın alındıktan sonraki devasa kapasite genişlemesi ve küresel ölçekli yaptığı açılımlar (dil destekleri, lokasyona özel algoritmalar vbg.) belki de facebook.com ve google.com’la birlikte onu internetin en bilinen ve önemli üç sitesinden biri haline getiriyor. YouTube elbette başlı başına pek çok kitabı dolduracak bir konu, ancak bu yazı kapsamında çok daha özel ve görece küçük bir YouTube kesiti olan popüler bilim kanallarına vurgu yapacağız. Bu kanallar nedir, neden varlardır ve daha önemlisi ülkemizde bu alanın gelişme şansı var mıdır?\n\nYabancı Kanallar\nSayıları pek çok olan bu kanallara dair iki liste vererek başlayalım (liste1 — liste2). Elbette bu listelere dahil edilmemiş pek çok şahane kanal da mevcut (örneğin SpaceTime). Fizikten biyolojiye, kimyadan kozmolojiye, genetikten mühendisliğe fen bilimleriyle alakalı her alanda uzmanlaşmış bir YouTube kanalı bulmak mümkün. Hatta artık bu iş o kadar köklü bir zemine oturmuş durumda ki işin içeriğinin üstüne animasyon, anlatım, hitabet gibi kısımlarının da özenle hazırlandığı kanallar ortaya çıkmış durumda.\n\nElbette tüm bu emek ve çaba yalnızca YouTube’un her izlenme başına verdiği 0.0005 dolar benzeri paralar için yapılmıyor. Burada işin finansmanından bahsetmek önemli çünkü her ne kadar bir YouTube kanalından popüler bilim anlatmak bize hobi olarak görünse dahi aslında oldukça zahmetli bir uğraş. İçeriğin hazırlanması, anlatılabilecek formata sokulmaları, videoların çekimleri ve düzenlenmeleri derken yalnızca basit bir kamera önünde 10–20 dakikalık anlatım dahi insanın bazen günlerine mal olabiliyor. Üstüne üstlük bir de bu videoları daha izlenebilir ve keyifli kılmak adına eklenen animasyonlar, yapılan deneyler gibi ekstraların da zaman ve parasal maliyetleri göz önüne alınması gerekiyor. Yani ilgi çekici ve keyifli bir video çekip YouTube’a koymanın maliyeti oldukça yüksek. Üstüne üstlük işler burada bitmiyor.",
                Viewer = 7895,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/20.png"
            }; // bilim - teknoloji

            Article art21 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Bu Böyledir, Hedefler, Önermeler ve Hafiflemek",
                Content = "Mustafa Kutlu’yu keşfetmemle hemen onun kısa hikayelerini okumak istedim ve ilk seçtiğim kitap bu oldu.\n\nİçindekilere bakınca birbirinden farklı kısa hikayeler içeren bir kitap sanmıştım ama öyle değilmiş. Bunu biraz geç anladım çünkü bazı bölümleri hikayedeki diğer kahramanların gözünden okuyoruz. Bu tarz bana yeni pencereler açtı diyebilirim. Okunması zor, anlaşılması güç ve eminim ki yazması da çilelidir ama kitabı bitirince garip bir tat alıyorsunuz. Kitabı okumayanlar için baştan uyarayım, yazının devamında hikayeden tat kaçırabilecek detaylar veriyorum.\n\nKitaptaki ana kahramanımız Süleyman bir lunaparkta eşi ve çocuğuyla birlikte, şu garip tüfeklerle balonları patlattığın anlamsız oyunlar vardır ya sonunda ödül kazandığın, işte onun gibi bir şeyde ama vurmaya çalıştığı oyuncak tavşanlara takılıp kalıyor bir süre. Tabii bunu biraz geç anlıyoruz. Her bölümde Süleyman’ın farklı bir yönünü öğreniyor, yaşadığı ayrı bir sıkıntıyı sanki biz de yaşıyoruz.\n\nBütün o sıkıntılardan uzaklaşmak için geldiği bu lunapark ona dar geliyor, burada bile bir türlü gün yüzü göremiyor. Hemen yanı başında patronu birer birer vuruyor tavşanları ama kendisi yanında bir umut bekleyen kızı ve artık sıkılmış olan, gitmek için baskı yapan karısı varken içinden şöyle geçiriyor:\n\nBu kitabı bitireli neredeyse üç hafta oldu ama bu yazıyı hazırlayamadım bir türlü. Ama şu an bile bu cümleyi okurken kendimi Süleyman’ın yerine nasıl koyduğumu, o acayip dünyaya nasıl adım attığımı hatırlıyorum. Benim için bu hikaye bu cümleyle başladı diyebilirim. Iskaladığımız hedefler, kaçırdığımız fırsatlar bu cümleyle gözünüzde canlanıyor.",
                Viewer = 648,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/21.jpg"
            }; // edebiyat

            Article art22 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Ya Yeni Bir Dünya Yoksa?",
                Content = "Geçen gün internette dolaşırken önüme bir gönderi çıktı. Kalemine bayıldığım Madeline Miller’ın Ben Kirke kitabındaki bir alıntıyı paylaşmışlardı.\n\nBundan iki sene, bütün dünya kapılarını kapatmaya karar verdiğinde ben de her öğrenci gibi evime döndüm. Üniversitede sadece bir dönem geçirmiştim. Üniversitenin ne olduğuna dair en ufak bir fikrim yoktu. Birileriyle tanışmıştım ama gerçekte kiminle arkadaştım? Bilmiyordum.\n\nÇoğu günler aynı cümleleri tekrarlayarak kendimi tanıtırdım. Herkes gibi kendimi bir sunum yaparmışçasına anlatırdım. En iyi göründüğüm kıyafetleri giyer, en iyi bildiğimiz konuları konuşurdum. Herkes gibi karşımdakini güldürür, ona kendini dünyanın en iyi insanıymış gibi hissettirirdim. Bunlar bir insanla ilk tanıştığımızda çok etkilidir. Onlara böyle hissettirirsek bizi severler, ancak böyle hissetmelerini sağlarsak bizimle kalırlar.\n\nEve döndüğümde bu dünyayı tamamen geride bıraktım ve kendimle baş başa kaldım. Üniversite çok garip bir yerdi. Yepyeni bir dünyada kendine yer bulmak için yer edinmiş insanları takip ediyordunuz. Peki gerçekten istediğiniz bu muydu? Var olmak istediğiniz yer? Ben kendim için bundan emin değildim.\n\nOn dokuz yaşındaydım ve bir ömrü kendimi ait hissetmediğim bir dünyada geçirmiştim. Lisede arkadaşlarımın arasında otururken aniden oradan uzaklaşır ve sessizleşirdim. Yurt koridorlarında yürürken diğer insanlara bakar, kendime onların arasında bir yer bulmaya çalışırdım. Bütün bu sıkıntılarım biriyle denk geldiğimde kalbimin içine kaçardı. Bu düşünceler hiç aklımdan geçmemiş gibi gülümser, sohbet ederdim.",
                Viewer = 849,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/22.jpeg"
            }; // edebiyat

            Article art23 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Bir Pisuvar Sanat Tarihini Nasıl Değiştirdi",
                Content = "Aralarında Fransız ressam Marcel Duchamp’ın da (28 Temmuz 1887–2 Kasım 1968) bulunduğu, dönemin sınırlayıcı kalıplarından bunalan bir grup sanatçı 1917'de “Bağımsız Sanatçılar” adıyla bir dernek kurdu. Dernek, kuruluşunun hemen ardından, “Jüri yok, ödül yok” mottosuyla büyük bir sergi düzenleyeceğinin duyurusunu yaptı.\n\nBildiri afişinde, gönderilen tüm sanat eserlerinin herhangi bir jüri değerlendirmesine tabi tutulmadan alfabetik sırayla asılacağı bildirilmişti. Sergiye 1.235 sanatçı tarafından 2.125 sanat eseri gönderildi ve içlerinden sadece bir tanesi reddedildi; Fountain.\n\nDuchamp sergiye göndereceği sanat eserini hazırlamak için evinden çıkıp, tuvalet malzemeleri satan bir dükkana gitti. Gözüne kestirdiği bir pisuvarı satın aldı, stüdyosuna götürdü, imzaladı ve sergiye gönderdi. Gönderdiği pisuvara, imzasını atmaktan ve Fountain (çeşme) olarak adlandırmaktan başka herhangi bir dokunuş yapmamıştı, üstelik onun üretim aşamasına da hiçbir şekilde dahil olmuş değildi. Onun Fountain’i, herhangi bir fabrikada sıradan bir üretim sürecinden geçmiş, diğer milyonlarca pisuvardan hiçbir farkı olmayan başka bir pisuvardı sadece.\n\nSergi komitesi verdiği sözü tutmadı ve Fountain’in bir sanat eseri olmadığını, dolayısıyla sergilenemeyeceğini belirtti ve eseri geri çevirdi. Bu olay, zamanın Dadaistleri arasında bir curcunaya sebep oldu ve Duschamp, Bağımsız Sanatçılar Derneği'nin yönetim kurulundaki görevinden istifa etti.\n\nAncak bu, Duchamp’ın ortalığı karıştıran ilk eseri değildi; bu olaydan önce de sanat dünyasında doğru olarak kabul edilen her şeyi defalarca sorgulamış ve “Sanat nedir?” sorusunu cevaplamak için sanat dünyasına meydan okumuştu. Bu olaydan on iki sene önce Fransa’da da olduğu gibi.\n\nFransa’da, sanatçı bir ailede dünyaya gelmişti; tüm kardeşleri sanatçıydı ve o da kardeşlerinin ayak izlerini takip etmeye karar verdi. Académie Julian sanat okuluna başladı, ancak burada derslere girmek yerine tüm zamanını bilardo oynayarak geçirmeyi daha çekici bulmuştu.",
                Viewer = 4325,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/23.jpeg"
            }; // edebiyat , sanat , tarih

            Article art24 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Sizi Başarıya Götürecek Alışkanlıklarınız Var Mı?",
                Content = "Ünlü bir Ceo, profesyonel bir sporcu, altın çocuk bir girişimci ya da mesleğinin en üst seviyesinde ilerleyen herkes için geçerli olabilecek şey, bir gün uyandıklarında şimdiki pozisyonlarında bulundukları şansa sahip olmadıklarıdır. Bazılarının gülünç bir şekilde üstün yetenekli olduğu ve bugüne kadar yaptıkları başarılı işlerden dolayı hedef alındığı ama daha da derinlerde kazanmaya devam ettiği zaman, alışkanlıkların nihayetinde ne olduğunun farkına varırsınız. Çünkü onlar, kendilerine başarı getiren alışkanlıklarını sürdürdüler ve başarılarını bu devamlılık getirdi.Geleceğin başarısını sağlamak için birinci sınıf alışkanlıkları benimsemekten ve bunlar hakkında günlük olarak ustalaşmaktan daha önemli bir şey yoktur. Bu yüzden, son derece başarılı kişilerde görülen dört alışkanlığa göz atmakta fayda var; Ne kadar büyük ya da küçük olursa olsun, başarısızlık ve sıkıntının başarıya ya da sıçrama tahtasına büyük bir başarı için bir engel olarak hizmet edip etmeyeceğine karar verirler. Oldukça başarılı bir şekilde onların yaşamları boyunca başarısızlıklarını ve olumsuzluklarını kullanarak büyümeleri ve yeni başarı seviyelerine ulaşmalarını sağlar. Bu zorlu ama çok büyük ödüllendirici alışkanlığı hayatınıza kabul edersiniz, kazanmak ve en iyi halini almak için kendinizi harika bir konuma sokarsınız. Zaman yönetimi ve bunun ne kadar önemli olduğunu her zaman duyuyoruz. Ancak ben, enerji yönetiminin zaman yönetiminden daha önemli olduğuna inanıyorum. Zamanınızı iyi yönetebilirsiniz, ancak tüm enerjinizi düşük ödüllendirici ve sıkıcı görevlere yönlendirirseniz bunun sonucu iyi olmaz. Oldukça başarılı olan zaman yönetimi hakkındaki kişiler, aynı zamanda enerjilerini her gün düzenleme konusunda da saplıntılıdırlar. Her zaman bakılması gereken önemli bir durum da, harcadığımız enerjinin geri dönüşünün bize ne kazandırdığıdır. Zaman yönetimi önemlidir ve bence zamanınızı daha iyi yönetebilmeniz için sürekli yeni yollar aramalısınız. Ancak bu yolları ararken enerji yönetiminin önemini unutmayın. Sizin önemli bir hedefe ulaşmanıza ya da amacınızı yerine getirmenize engel olmaya düşük ödüllendirici görevlerde değerli enerjinizi harcamayı bırakın. Bu nokta altı çizilmesi gereken -net- durumlardan biridir. Son derece başarılı olanların altın sırrı, hayat boyu öğrenmeye açık olmalarıdır. Üzücü bir gerçek olarak, çoğu insan hayatının belli bir noktasında sonra öğrenme alışkanlıklarını terk ediyorlar. Başarıya koşanların farkındalıkları bu nokta da belirgin bir şekilde ortaya çıkıyor. Onlar çoğu insanlar gibi olmuyorlar. Hayat boyu öğrenen bir öğrenci olmayı ve bunu yapmanın muazzam faydalarını toplayan küçük bir kesimin saflarına katılmayı taahhüt et. Büyük bir vizyona sahip olmak ve kendinizi şuandaki durumlarınızın ötesinde görmek bir alışkanlıktır, çünkü bu her gün yapmanız gereken bir şeydir. Yaşlandıkça, yıllar ilerledikçe başarısızlık ve sıkıntı yaşarız. Bir gün son derece mutlu olabilirsiniz ve ertesi gün tamamen kötü bir gün sizi bekleyebilir. Hayatınız için inanılmaz bir vizyona sahip olmak, günlük yaşamınıza dahil olmanın değil, aynı zamanda her günün her dakikasında bu vizyonu gerçekleştirmenin günlük bir alışkanlık haline gelmesi gerektiğini bilmek gerekir. Oldukça başarılı olanlar, en baştaki hedeflerini ve hayallerini görselleştirerek başarıya ulaşırlar. Görselleştirmek arzu edilen her şey için geçerli ve başarısı kanıtlanmış bir yöntemdir. Hayatınız için iyi bir vizyona sahip olmak, savaşın sadece yarısıdır. Bunu tam olarak gerçekleştirdiğinize inanmak ve o vizyonu hayata geçirmek için her gün çalışmak, her şeyi tam bir çember haline getiren ayrıntıdır. Daha önce yapmadıysanız hayatınız için kalıcı bir vizyon yaratmaya başlayın ve o vizyonu gerçeğe dönüştürmek için özenle çalışırken, kendi inancınızı da geliştirin. En iyisi olmak ve tüm potansiyelinize ulaşmak, günlük alışkanlıkları aksatmamak ile ilgilidir. Yukarıda değindiğimiz 4 farklı alışkanlığı hayatınıza kalıcı olarak dahil ederseniz, sizin için başarının altın anahtarı olabilir.",
                Viewer = 5648,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/24.png"
            }; // spor

            Article art25 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Rallici deyip geçmeyin",
                Content = "Bugün size enteresan bir karakterden bahsedeceğim: Ralli pilotu. Bu karakter özelinde, sporculukla ilişkilendirilebilecek ama tüm sporculara genellemenin zor olduğu bazı kişisel boyutlar tarif edeceğim. Bu yazının amacı kendi hikayemi anlatmak değil; belki başka bir zaman. Daha önemli bir mesajım var: Uzun yıllar içinde bulunduğum ortamlardan yola çıkarak adına “sporcu” dediğimiz kompleks karakterin, birçok spor dalıyla bağdaştırabileceğimiz ama özellikle karmaşık yapısıyla (günler süren yarışlar, pilot-kopilot uyumu, takım faktörü, finansal şartlar, doğal ortamın belirsizleri vs gibi) bir çok dinamiği içinde barındıran ralli sporunda yoğunlaşan yetkinliklerini tarif edeceğim. Bahsettiğim sportif yetkinlikler değil; sportif bir boyutu var ama aslında hayatla ilgili temel becerilerden bahsediyorum. Biraz daha açayım: Bir insanın nasıl otomobil kullandığına dikkatle bakarsanız aşağı yukarı nasıl bir insan olduğunu çözersiniz. Sakin bir sürücü çoğunlukla normal hayatında da aceleci olmayan, adımları teker teker atan bir bireydir. Benzer şekilde, bir ralli pilotu yarışta nasıl bir yaklaşım benimsiyorsa gündelik hayatında temel tercihlerini de o yönde yapar. İlk etaplarda atak yapmayan ve yarışın içinde yavaş yavaş hızlanan bir ralli pilotu muhtemelen normal hayatında da sabırlı ve risk iştahı yüksek olmayan bir pilot olarak çıkar karşınıza; yavaş bir pilottur demiyorum, sadece adım adım hızlanıp ölçülü risk alır. Yarışın ilk kilometrelerinden itibaren %100 performans göstermeye gayret eden pilot ise hayatta da benzer bir tavır takınır: Hızlı, sonuca gitmeye çalışan, gözünü budaktan sakınmayan bir kişiyle karşılaşacağınıza emin olabilirsiniz. Böyle bir bağlamda yetişen tipik bir ralli pilotu sporculuk hayatı boyunca bazı temel yetkinlikler geliştirir. Bunlar diğer spor dallarından biraz daha karmaşık bir otamda oluştuğu için çok yönlüdür. Ralli uzun soluklu bir süreçtir; sporcular genellikle 2–3 güne yayılmış zaman diliminde çok sayıda etap geçerler. Yarış tamamen kontrol altına alınmış kısa bir pistte değil, doğal bir ortamda geçer: Geçici olarak trafiğe kapatılmış köy/kasaba yolları, ormanlar, çoğu zaman nadiren kullanılan tali yollar ralli parkuru olur. Yolun yarış anındaki durumunu kimse tam olarak bilemez. Tecrübe seviyenize göre hava koşulları, zemin durumu, yolda karşılaşabileceğiniz doğal sürprizlerle ilgili bir fikriniz olabilir ama emin olamazsınız. Belirli sayıda etap geçildikten sonra sporcular özel bir “servis alanına” gelip araçlarına gerekli ayar, onarım, lastik değişimi gibi işlemler yaptırırlar; yani teknik açıdan birbiri içine geçen süreçler ve seçimler içerir. Rallide pilotun yanında görevi yol notu okumak olan bir de ko-pilot bulunur. Yani aracın içinde etkileşimli bir süreç vardır ve uyum önemlidir. Tipik bir karı-koca uyumuna benzetilebilir ama daha kritiktir, zira ko-pilota hayatınızı teslim edecek kadar güvenirsiniz. Ucuz bir spor değildir, dolayısıyla finansman ihtiyacı vardır. Ralli pilotu bu kaynağa sahip değilse finansman yaratmak için iş planını yatırımcılara anlatan bir girişimci gibi davranır. Aylar, yıllar boyu sponsor olma ihtimali olan kişi ve kurumlara proje sunduğumu, aynı süreci sürekli yaşayan onlarca örnek bilirim. Lafı uzatmadan sadede gelmek istiyorum: Ralli pilotu yapmaya çalıştığı işin doğası gereği zamanla evrilir ve karmaşık, ilk bakışta yorumlaması zor bir karakter haline gelir. Bu yazıda onların içinden gelen biri olarak sizlere bu ilginç karakterin bazı niteliklerini anlatmaya çalışacağım. Ralli pilotu içinde bulunduğu durumu objektif olarak muhakeme etme kabiliyeti geliştirmiş bir bireydir. Bu değerlendirmeyi defalarca yanlış, (fazla iyimser/fazla kötümser) yapmış ve yanılmış, bu nedenlerle gerçekçi bir değerlendirme yapmanın önemini kavramıştır. Sessiz ve çoğunlukla içsel bir süreçle sürekli içinde olduğu durumu değerlendirir ve gerekiyorsa pozizyon değiştirir.",
                Viewer = 2234,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/25.jpg"
            }; // spor, eğitim

            Article art26 = new Article
            {
                CreatorUserId = user.Id,
                Title = "Sporcu Velisi Olmak",
                Content = "Genç sporcuların çoğu antrenmanlarda eğlenememeye başlıyor ve sporu bırakıyor. Keyifsizliğin temelindeki en önemli sebeplerden birisi; sporun aktivite olmaktan çıkıp, rekabet kısmının ağır basmaya başlamasıdır. Bu noktada velilerin de kendilerini, çocuğunun spordan keyif alması için neler yaptığı ve sporu galibiyet/mağlubiyet olarak görmesine sebep olup olmadığı konularında sorgulaması gerekir. Spor rakibi alt etmek olarak değil, rakiple karşılıklı mücadele etmekten duyulan keyif olarak tanımlanmalıdır. Veliler çocuklarına sporun ne olduğunu en doğru şekilde anlatırlarsa, fair-play algısı da kuvvetlenecek ve gelişecektir. Bu nedenle galibiyet değil, iyi ve ahlaklı olmak yüceltilmelidir. Bir veliyi çocuğunun maç kazanması tabii ki mutlu eder ancak sporcunun rakibine, hakemlere, takım arkadaşlarına, antrenörüne ve izleyicilere karşı saygılı olması çok daha değerlidir. Sporcuların ödüllerden değil, rakibiyle karşılıklı spor yapmasından keyif alması sağlanmalıdır. İyi bir birey olmak, her zaman kazanan bir sporcu olmaktan önemlidir. Ayrıca eğitim ve spor, gerekli özen gösterildiği sürece bir arada götürebilir. Sınavların, ödevlerin yoğun olduğu dönemlerde velilerin çocuklarını spordan alıkoymalarına hiç gerek yok. Antrenmanlarda ders ortamının dışına çıkıyor olmanın yanı sıra vücuttaki fazla enerji de atılır. Böylece sporcu-öğrenci derslerine daha kolay odaklanabilir. Kişinin antrenman ve ders çalışma vakitlerini ayarlaması için; kendi isteğiyle düzenleyeceği günlük, haftalık programlar ve dinlenmesine gösterdiği özen yardımcı olacaktır. Aynı zamanda spor, uzun vadede eğitim konusunda avantajlar yaratır. Sporcu-öğrenciler, başarılı performansları sayesinde yurt dışındaki iyi üniversitelerden burslu okuma imkanı kazanabilir. Spor, zaman zaman veliler için çok talepkardır; velilerin hafta sonlarından, dinlenme zamanlarından ödün vermesi gerekebilir. Ancak unutulmamalıdır ki, sporcu-öğrenci ve veli de kendi aralarında bir takımdır. Bu takım arkadaşlığı bağlamında; velilerin kendi zamanlarını sporcu-öğrencinin antrenman saatlerine göre ayarlaması gibi, sporcu-öğrencilerin hem okula hem de antrenmanlara karşı olan motivasyonunu yüksek tutmaya yardımcı olmasına da ihtiyaç duyulabilir. Veliler sporcu-öğrenci yapması gereken görevi yaptığında onu tebrik edip, “aferin” demekten geri kalmamalıdır. Böylece kişi, velisi tarafından onaylanmış olmanın keyfine varacaktır. Bu süreçte sporcu-öğrenci hatalar da yapabilir. Yeri geldiğinde veli çocuğunun hatalar yapmasına izin vermeli ve herkesin hata yapabildiğinin farkına varmasını sağlamalıdır. Aynı zamanda veliler, çocuklarının performansı hakkında olumsuz yorum yapmamalı veya nasıl performans göstermesi hakkında tavsiyelerde bulunmamalıdır. Bu uyarıları ve önerileri gerekli gördüğü taktirde sporcunun antrenörü zaten yapacak ve eksikleri üzerinde sporcuyla beraber çalışacaktır.",
                Viewer = 1125,
                Status = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifierUserId = user.Id,
                ImagePath = "/Images/Post/26.jpeg"
            }; // spor, eğitim

            builder.Entity<Article>().HasData(art1, art2, art3, art4, art5, art6, art7, art8, art9, art10, art11, art12, art13, art14, art15, art16, art17, art18, art19, art20, art21, art22, art23, art24, art25, art26);

            #endregion



            // Article categories
            builder.Entity<Article>().HasMany(a => a.Categories).WithMany(b => b.Articles).UsingEntity(x => x.HasData(
                   new { ArticlesId = art1.Id, CategoriesId = bilim.Id },
                   new { ArticlesId = art2.Id, CategoriesId = teknoloji.Id },
                   new { ArticlesId = art2.Id, CategoriesId = sanat.Id },
                   new { ArticlesId = art3.Id, CategoriesId = spor.Id },
                   new { ArticlesId = art3.Id, CategoriesId = saglik.Id },
                   new { ArticlesId = art4.Id, CategoriesId = tarih.Id },
                   new { ArticlesId = art4.Id, CategoriesId = sanat.Id },
                   new { ArticlesId = art5.Id, CategoriesId = yazilim.Id },
                   new { ArticlesId = art5.Id, CategoriesId = teknoloji.Id },
                   new { ArticlesId = art6.Id, CategoriesId = saglik.Id },
                   new { ArticlesId = art7.Id, CategoriesId = saglik.Id },
                   new { ArticlesId = art7.Id, CategoriesId = beslenme.Id },
                   new { ArticlesId = art8.Id, CategoriesId = egitim.Id },
                   new { ArticlesId = art9.Id, CategoriesId = sanat.Id },
                   new { ArticlesId = art10.Id, CategoriesId = sanat.Id },
                   new { ArticlesId = art10.Id, CategoriesId = yazilim.Id },
                   new { ArticlesId = art10.Id, CategoriesId = teknoloji.Id },
                   new { ArticlesId = art11.Id, CategoriesId = teknoloji.Id },
                   new { ArticlesId = art11.Id, CategoriesId = saglik.Id },
                   new { ArticlesId = art12.Id, CategoriesId = saglik.Id },
                   new { ArticlesId = art12.Id, CategoriesId = teknoloji.Id },
                   new { ArticlesId = art12.Id, CategoriesId = bilim.Id },
                   new { ArticlesId = art13.Id, CategoriesId = teknoloji.Id },
                   new { ArticlesId = art13.Id, CategoriesId = saglik.Id },
                   new { ArticlesId = art13.Id, CategoriesId = yazilim.Id },
                   new { ArticlesId = art14.Id, CategoriesId = teknoloji.Id },
                   new { ArticlesId = art14.Id, CategoriesId = saglik.Id },
                   new { ArticlesId = art15.Id, CategoriesId = teknoloji.Id },
                   new { ArticlesId = art15.Id, CategoriesId = saglik.Id },
                   new { ArticlesId = art15.Id, CategoriesId = sanat.Id },
                   new { ArticlesId = art16.Id, CategoriesId = teknoloji.Id },
                   new { ArticlesId = art16.Id, CategoriesId = sanat.Id },
                   new { ArticlesId = art17.Id, CategoriesId = egitim.Id },
                   new { ArticlesId = art17.Id, CategoriesId = yazilim.Id },
                   new { ArticlesId = art18.Id, CategoriesId = spor.Id },
                   new { ArticlesId = art18.Id, CategoriesId = teknoloji.Id },
                   new { ArticlesId = art18.Id, CategoriesId = yazilim.Id },
                   new { ArticlesId = art19.Id, CategoriesId = tarih.Id },
                   new { ArticlesId = art19.Id, CategoriesId = teknoloji.Id },
                   new { ArticlesId = art19.Id, CategoriesId = yazilim.Id },
                   new { ArticlesId = art20.Id, CategoriesId = bilim.Id },
                   new { ArticlesId = art20.Id, CategoriesId = teknoloji.Id },
                   new { ArticlesId = art21.Id, CategoriesId = edebiyat.Id },
                   new { ArticlesId = art22.Id, CategoriesId = edebiyat.Id },
                   new { ArticlesId = art23.Id, CategoriesId = edebiyat.Id },
                   new { ArticlesId = art23.Id, CategoriesId = sanat.Id },
                   new { ArticlesId = art23.Id, CategoriesId = tarih.Id },
                   new { ArticlesId = art24.Id, CategoriesId = spor.Id },
                   new { ArticlesId = art25.Id, CategoriesId = spor.Id },
                   new { ArticlesId = art25.Id, CategoriesId = egitim.Id },
                   new { ArticlesId = art26.Id, CategoriesId = spor.Id },
                   new { ArticlesId = art26.Id, CategoriesId = egitim.Id }
               ));
        }
    }
}
