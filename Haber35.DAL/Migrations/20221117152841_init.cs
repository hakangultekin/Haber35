using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Haber35.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Viewer = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ModifierUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletoryUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ModifierUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletoryUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ModifierUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletoryUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    ArticlesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => new { x.ArticlesId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Articles_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db96d546-0517-43ab-8087-db5bb51915f1", "c92b7842-7f7e-4d6b-86fa-5257bc8db0ce", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[] { "05fcadae-fa72-4a86-89ee-2a4943ad265d", 0, null, new DateTime(1995, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d3ebae65-8fca-4b48-a673-149ea670d8c8", new DateTime(2022, 11, 17, 18, 28, 40, 874, DateTimeKind.Local).AddTicks(6927), "hakan35@hotmail.it", true, "Hakan", "/Images/Profile/05fcadae-fa72-4a86-89ee-2a4943ad265d.jpg", "Gültekin", false, null, "HAKAN35@HOTMAIL.IT", "HGULTEKIN", "AQAAAAEAACcQAAAAEKpyrdvmsPkODSCAljhCSJMJlvzQ/Mrbvkhxm4RP1kbHKFepD7AUAIs96OG40roakw==", null, false, "YFZSZFREU2D5QIXVH5AISZMENKE76MLB", true, false, new DateTime(2022, 11, 17, 18, 28, 40, 875, DateTimeKind.Local).AddTicks(3632), "hgultekin" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedDate", "CreatorUserId", "DeletedDate", "DeletoryUserId", "ImagePath", "ModifiedDate", "ModifierUserId", "Status", "Title", "Viewer" },
                values: new object[,]
                {
                    { new Guid("ebfcee97-a0b1-4976-8df9-247bc76e2ce4"), "Şakayla aldatmayı birbirinden ayıran en önemli kriter, şakacının yaptığı şakadan bir çıkar elde etmemiş olması ve şakanın yapıldığı kimseye bir süre sonra mutlaka ve mutlaka “maruz kaldığı şeyin şaka olduğu” bilgisinin verilmesi ya da anlamasının sağlanmasıdır. Yani yaptığınız şakayı itiraf etmiyor, bundan bir de çıkar elde ediyorsanız, yaptığınız şey şaka değil, bir tür aldatmadır.Kimi şakaların etkisi, şaka yapanla şaka yapılan arasında kalmaz, kişisel olmaktan çıkıp toplumsal hale bürünür ve bir hatayı, bir olumsuzluğu veya bir şeylerin yanlış gittiğini ortaya koymayı sağlar.\n\n Bu haftaki yazımda edebiyattan bilime, bir şeylerin yanlış gittiğini ortaya çıkarmayı amaçlayan kimi kahramanların yaptıkları bazı şakalardan örnek vermek istiyorum: Birinci örneğimiz edebiyat alanından… Chuck Ross adlı bir kablo TV satıcısı yazmaya çok meraklıydı ancak yayın dünyasının yazarlar arasında ayrımcılık yaptığına inanıyordu. Bunu kanıtlamak için Jerzy Kozinsky’nin 1969 yılında Amerikan Ulusal Kitap Ödülü’ne layık görülen “Adımlar” adlı romanını yeniden daktilo edip, başka bir yazar adıyla birlikte kitabın orijinal yayımcısı Random House da dahil ABD’deki 14 büyük yayınevine ve 13 edebiyat ajansına gönderdi. Kitabı bu 27 kurumdan hiçbiri tanımadığı gibi, tümü taslağı reddetti. Şaka, Ross’un da arzu ettiği üzere, yayınevlerinin isimsiz yazarlara nasıl büyük bir önyargıyla baktığını ortaya koymuş oldu.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(724), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/1.png", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(730), null, true, "Bilimin şakası olur mu?", 1234 },
                    { new Guid("f236ec17-be64-4939-8680-f53cedbb0796"), "Aralarında Fransız ressam Marcel Duchamp’ın da (28 Temmuz 1887–2 Kasım 1968) bulunduğu, dönemin sınırlayıcı kalıplarından bunalan bir grup sanatçı 1917'de “Bağımsız Sanatçılar” adıyla bir dernek kurdu. Dernek, kuruluşunun hemen ardından, “Jüri yok, ödül yok” mottosuyla büyük bir sergi düzenleyeceğinin duyurusunu yaptı.\n\nBildiri afişinde, gönderilen tüm sanat eserlerinin herhangi bir jüri değerlendirmesine tabi tutulmadan alfabetik sırayla asılacağı bildirilmişti. Sergiye 1.235 sanatçı tarafından 2.125 sanat eseri gönderildi ve içlerinden sadece bir tanesi reddedildi; Fountain.\n\nDuchamp sergiye göndereceği sanat eserini hazırlamak için evinden çıkıp, tuvalet malzemeleri satan bir dükkana gitti. Gözüne kestirdiği bir pisuvarı satın aldı, stüdyosuna götürdü, imzaladı ve sergiye gönderdi. Gönderdiği pisuvara, imzasını atmaktan ve Fountain (çeşme) olarak adlandırmaktan başka herhangi bir dokunuş yapmamıştı, üstelik onun üretim aşamasına da hiçbir şekilde dahil olmuş değildi. Onun Fountain’i, herhangi bir fabrikada sıradan bir üretim sürecinden geçmiş, diğer milyonlarca pisuvardan hiçbir farkı olmayan başka bir pisuvardı sadece.\n\nSergi komitesi verdiği sözü tutmadı ve Fountain’in bir sanat eseri olmadığını, dolayısıyla sergilenemeyeceğini belirtti ve eseri geri çevirdi. Bu olay, zamanın Dadaistleri arasında bir curcunaya sebep oldu ve Duschamp, Bağımsız Sanatçılar Derneği'nin yönetim kurulundaki görevinden istifa etti.\n\nAncak bu, Duchamp’ın ortalığı karıştıran ilk eseri değildi; bu olaydan önce de sanat dünyasında doğru olarak kabul edilen her şeyi defalarca sorgulamış ve “Sanat nedir?” sorusunu cevaplamak için sanat dünyasına meydan okumuştu. Bu olaydan on iki sene önce Fransa’da da olduğu gibi.\n\nFransa’da, sanatçı bir ailede dünyaya gelmişti; tüm kardeşleri sanatçıydı ve o da kardeşlerinin ayak izlerini takip etmeye karar verdi. Académie Julian sanat okuluna başladı, ancak burada derslere girmek yerine tüm zamanını bilardo oynayarak geçirmeyi daha çekici bulmuştu.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1094), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/23.jpeg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1095), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Bir Pisuvar Sanat Tarihini Nasıl Değiştirdi", 4325 },
                    { new Guid("c364ccb4-ae38-40b3-8a41-6e658a8c9cf1"), "Geçen gün internette dolaşırken önüme bir gönderi çıktı. Kalemine bayıldığım Madeline Miller’ın Ben Kirke kitabındaki bir alıntıyı paylaşmışlardı.\n\nBundan iki sene, bütün dünya kapılarını kapatmaya karar verdiğinde ben de her öğrenci gibi evime döndüm. Üniversitede sadece bir dönem geçirmiştim. Üniversitenin ne olduğuna dair en ufak bir fikrim yoktu. Birileriyle tanışmıştım ama gerçekte kiminle arkadaştım? Bilmiyordum.\n\nÇoğu günler aynı cümleleri tekrarlayarak kendimi tanıtırdım. Herkes gibi kendimi bir sunum yaparmışçasına anlatırdım. En iyi göründüğüm kıyafetleri giyer, en iyi bildiğimiz konuları konuşurdum. Herkes gibi karşımdakini güldürür, ona kendini dünyanın en iyi insanıymış gibi hissettirirdim. Bunlar bir insanla ilk tanıştığımızda çok etkilidir. Onlara böyle hissettirirsek bizi severler, ancak böyle hissetmelerini sağlarsak bizimle kalırlar.\n\nEve döndüğümde bu dünyayı tamamen geride bıraktım ve kendimle baş başa kaldım. Üniversite çok garip bir yerdi. Yepyeni bir dünyada kendine yer bulmak için yer edinmiş insanları takip ediyordunuz. Peki gerçekten istediğiniz bu muydu? Var olmak istediğiniz yer? Ben kendim için bundan emin değildim.\n\nOn dokuz yaşındaydım ve bir ömrü kendimi ait hissetmediğim bir dünyada geçirmiştim. Lisede arkadaşlarımın arasında otururken aniden oradan uzaklaşır ve sessizleşirdim. Yurt koridorlarında yürürken diğer insanlara bakar, kendime onların arasında bir yer bulmaya çalışırdım. Bütün bu sıkıntılarım biriyle denk geldiğimde kalbimin içine kaçardı. Bu düşünceler hiç aklımdan geçmemiş gibi gülümser, sohbet ederdim.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1091), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/22.jpeg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1092), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Ya Yeni Bir Dünya Yoksa?", 849 },
                    { new Guid("8373b590-dd2d-40d3-a6c4-698a2438daae"), "Mustafa Kutlu’yu keşfetmemle hemen onun kısa hikayelerini okumak istedim ve ilk seçtiğim kitap bu oldu.\n\nİçindekilere bakınca birbirinden farklı kısa hikayeler içeren bir kitap sanmıştım ama öyle değilmiş. Bunu biraz geç anladım çünkü bazı bölümleri hikayedeki diğer kahramanların gözünden okuyoruz. Bu tarz bana yeni pencereler açtı diyebilirim. Okunması zor, anlaşılması güç ve eminim ki yazması da çilelidir ama kitabı bitirince garip bir tat alıyorsunuz. Kitabı okumayanlar için baştan uyarayım, yazının devamında hikayeden tat kaçırabilecek detaylar veriyorum.\n\nKitaptaki ana kahramanımız Süleyman bir lunaparkta eşi ve çocuğuyla birlikte, şu garip tüfeklerle balonları patlattığın anlamsız oyunlar vardır ya sonunda ödül kazandığın, işte onun gibi bir şeyde ama vurmaya çalıştığı oyuncak tavşanlara takılıp kalıyor bir süre. Tabii bunu biraz geç anlıyoruz. Her bölümde Süleyman’ın farklı bir yönünü öğreniyor, yaşadığı ayrı bir sıkıntıyı sanki biz de yaşıyoruz.\n\nBütün o sıkıntılardan uzaklaşmak için geldiği bu lunapark ona dar geliyor, burada bile bir türlü gün yüzü göremiyor. Hemen yanı başında patronu birer birer vuruyor tavşanları ama kendisi yanında bir umut bekleyen kızı ve artık sıkılmış olan, gitmek için baskı yapan karısı varken içinden şöyle geçiriyor:\n\nBu kitabı bitireli neredeyse üç hafta oldu ama bu yazıyı hazırlayamadım bir türlü. Ama şu an bile bu cümleyi okurken kendimi Süleyman’ın yerine nasıl koyduğumu, o acayip dünyaya nasıl adım attığımı hatırlıyorum. Benim için bu hikaye bu cümleyle başladı diyebilirim. Iskaladığımız hedefler, kaçırdığımız fırsatlar bu cümleyle gözünüzde canlanıyor.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1087), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/21.jpg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1088), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Bu Böyledir, Hedefler, Önermeler ve Hafiflemek", 648 },
                    { new Guid("bb7591b8-8fe4-46ed-8050-e9f3caf730b1"), "YouTube her bir gün için yaklaşık 50 yıllık içeriğin yüklendiği (her dakika başına 300 saat), bir milyarın üzerinde insanın öyle ya da böyle yolunun düştüğü ve ortalamada her gün 5 milyar videonun izlendiği, kendi başına dünya üzerindeki tüm internet trafiğinin %17'sini kontrol eden bir site. Ancak elbette bunları (sayı detaylarına kadar olmasa da) hemen hepimiz biliyoruz. YouTube’un Google tarafından 2006'da satın alındıktan sonraki devasa kapasite genişlemesi ve küresel ölçekli yaptığı açılımlar (dil destekleri, lokasyona özel algoritmalar vbg.) belki de facebook.com ve google.com’la birlikte onu internetin en bilinen ve önemli üç sitesinden biri haline getiriyor. YouTube elbette başlı başına pek çok kitabı dolduracak bir konu, ancak bu yazı kapsamında çok daha özel ve görece küçük bir YouTube kesiti olan popüler bilim kanallarına vurgu yapacağız. Bu kanallar nedir, neden varlardır ve daha önemlisi ülkemizde bu alanın gelişme şansı var mıdır?\n\nYabancı Kanallar\nSayıları pek çok olan bu kanallara dair iki liste vererek başlayalım (liste1 — liste2). Elbette bu listelere dahil edilmemiş pek çok şahane kanal da mevcut (örneğin SpaceTime). Fizikten biyolojiye, kimyadan kozmolojiye, genetikten mühendisliğe fen bilimleriyle alakalı her alanda uzmanlaşmış bir YouTube kanalı bulmak mümkün. Hatta artık bu iş o kadar köklü bir zemine oturmuş durumda ki işin içeriğinin üstüne animasyon, anlatım, hitabet gibi kısımlarının da özenle hazırlandığı kanallar ortaya çıkmış durumda.\n\nElbette tüm bu emek ve çaba yalnızca YouTube’un her izlenme başına verdiği 0.0005 dolar benzeri paralar için yapılmıyor. Burada işin finansmanından bahsetmek önemli çünkü her ne kadar bir YouTube kanalından popüler bilim anlatmak bize hobi olarak görünse dahi aslında oldukça zahmetli bir uğraş. İçeriğin hazırlanması, anlatılabilecek formata sokulmaları, videoların çekimleri ve düzenlenmeleri derken yalnızca basit bir kamera önünde 10–20 dakikalık anlatım dahi insanın bazen günlerine mal olabiliyor. Üstüne üstlük bir de bu videoları daha izlenebilir ve keyifli kılmak adına eklenen animasyonlar, yapılan deneyler gibi ekstraların da zaman ve parasal maliyetleri göz önüne alınması gerekiyor. Yani ilgi çekici ve keyifli bir video çekip YouTube’a koymanın maliyeti oldukça yüksek. Üstüne üstlük işler burada bitmiyor.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1081), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/20.png", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1082), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "YouTube kanalları ve Popüler Bilim", 7895 },
                    { new Guid("8b3ec632-0507-4ebc-9839-d082e672f64c"), "Bazen günlük problemlerle baş edebilmek için okuma yapmak, seçenekleri, alternatifleri öğrenmek, bilgimizi artırmamız gerekir. Çünkü karşılaştığımız problemler bilgi eksikliğimizi yüzümüze çarparlar.\n\nZamanında bizi meşgul eden problemlerden biri Apache Kafka’ya (bir mesajlaşma sistemi) gönderilen JSON formatlı mesajların şema/biçim açısından gelişimini/değişimini yönetebilmekti. Problemin bir boyutu gönderilen mesajlardaki alanların tipini ve uzunluğunu denetlemekti. Yani şemasını kontrol etmek, şema denetimi, şemaya uygunluğun kontrol edilmesi. Diğer bir boyutsa ileride gelecek olan değişikleri geriye/ileriye uyumlu bir biçimde nasıl yönetebileceğimizdi. Yani şema evrimini/değişimini nasıl yönetecektik? Kesin olan şey değişimin kaçınılmaz olduğudur. Yazılım yaşayan bir şeydir. Durmadan değişir. Değişimin bitmesi öldüğü anlamına gelir. Yerine ya yenisi alınır ya da yeniden yazılır. Tablolara yeni kolonlar eklenir, veya var olan kolonlar silinir veya isim değişiklikleri yapılır. Bu değişiklikler en arka taraftan en ön tarafa, kullanıcıya gidinceye kadar olan tüm katmanlarda veri aktarımında değişiklik yapmayı gerektirir. Dolayısıyla Kafka’ya ilettiğimiz mesajların şemasal değişimini nasıl yöneteceğimiz, nasıl ilerleyeceğimiz konusu gündemdeydi.\n\nO sıralar Martin Kleppmann’ın yazdığı “Designing Data Intensive Applications” kitabını okuyordum. Adı gibi yoğun (intensive) bir kitap. Hala okuyorum, muhtemelen önümüzdeki bir kaç yıl daha okuyacağım gibi. :)\n\nGündemde olduğu için kitabın şema evrimi ile ilgili bölümüne öncelik tanıdım. JSON, XML, Protocol Buffers, Avro, Parquet gibi verileri iletirken veya saklarken nasıl ifade edileceğini belirleyen veri kodlama/serileştirme biçimlerini anlatıp, şema evrimi/değişimi açısından bu standartları inceliyordu.\n\nKodlama biçimlerini metin temelli ve binary diye sınıflandırıyordu. Gerçi bu ayrımın daha öncesinde de farkındaydım, ama şimdi özel olarak bu konuya odaklanmıştık. Sonrasında sorular sorular. Metin ne, binary ne, her şey zaten ikili tabanda ifade edilmiyor mu? Her şey sonuçta 1/0 değil mi? Derken url-encoding, base64, utf8, unicode, ascii vb. kodlama biçimlerine dallandım. Kurcaladıkça alttan bir şeyler çıkıyordu. Her yeni öğrendiğim şey yeni şeylere kapı aralıyordu. Kodlama, alfabeler, sayı sistemleri vb. derken olay tarihsel bir yolculuğa dönüştü. Morse alfabesi, telgraf vs. kadar gittik. Bugünü anlamak için geçmişe yapılan bir yolculuk.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1077), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/19.png", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1078), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Anlatılmayan Bilişim Tarihinin Peşinde Bir Serzeniş…", 10256 },
                    { new Guid("f88c1c0e-f384-4008-aca0-f950a0fb5796"), "Pandemi koşullarının dünya ekonomisi üzerindeki etkileri hissedilmeden çok daha önce, spor endüstrisi uzun vadeli finansal kazanımlar sağlanması gerekliliğine dair sinyaller veriyordu. Bugün ise sinyaller alarm zillerine dönüşmüş durumda.\n\nAvrupa ülkelerinde bahis reklamları üzerine getirilen regülasyonlar 2019 yılı itibarıyla İtalya Serie A takımlarının yıllık 100 milyon Euro, İspanya La Liga takımlarının ise 90 milyon Euro kayıp vermesine sebep oldu.\n\nTeknoloji bazlı inovasyonların spor endüstrisinin şiddetle ihtiyaç duyduğu gelirleri yaratmakta elzem olduğu apaçık görünüyor. Ayrıca, Sport Tomorrow’un çalışmaları, 2030 yılında Z ve Alfa kuşaklarının dünyanın gelir yaratan çalışan nüfusunun neredeyse yarısını oluşturacağını gösteriyor. Bu nesiller, teknolojiyle hemhal olarak büyüyor ve tüketim alışkanlıkları ayrılmaz bir şekilde teknolojiye bağlı. Bu gelişmeler ışığında spor endüstrisinin de değişen dünyanın kurallarını hızlı bir şekilde benimsemesi gerektiği görünüyor.\n\nPandeminin yarattığı koşullar ile çok sayıda gelir kapısından uzaklaşmak zorunda kalan spor kulüpleri dijitalleşmek ve yeni gelir yöntemleri oluşturabilmek için ihtimaller üzerine çalışıyor. Taraftar tokenları tam da bu noktada devreye giriyor. Peki, nedir bu taraftar token?\n\nTaraftar tokenları, sahiplerine Socios.com’da taraftarı oldukları kulüplerle bağlantı kurma şansı sağlayan dijital varlıklar.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1074), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/18.png", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1074), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Spor endüstrisinde dijitalleşmenin geleceği: Taraftar tokenları", 2019 },
                    { new Guid("65aaa38a-7e2b-4575-8e86-3d82f70b4621"), "Bir arkadaşım, kendisi iyi de bir fotoğrafçı, sanat tarihi okumasına rağmen girdiği bu yıl ziyaret ettiği bir sanat sınıfında hiç anlamadığı fizik konuşmaları yapıldığından bahsediyordu. Buna sanat denmesini de anlamıyor, kendisini bu durum karşısında garip hissettiğini de ekliyordu. Hatta “Bu insanlar sanatçı değil ki biliminsanı!?” diyerek noktayı koydu. Konu konuyu açtı kahvaltıda, ben de anlatmaya başladım.\n\nNeden sanat ve bilimin bu yakınlığı kimimizi heyecanlandırıyor?\nBu soruya uzun uzun argümanlar, makaleler, içeriklerle cevap verebilirim ancak biraz ilgilenip bu yazıya kadar geldiyseniz bildiğinizi varsayıp devam ediyorum açıklamalara.\n\nBu yüzyıl daha başından şiddetli bir büyüme eğrisi çiziyor. Sanki milenyumun ilk saatlerinde bilgi perdesine roket fırlattık yırtıp yırtıp geçiyoruz. 2000'den 5 Şubat 2016'ya kadar bir bilginin diğerini mayalaması süreci elbette insanın merakını cezbetti.\n\nTeknoloji — Sanat — Bilim yakınlığı elbette gündelik teknolojik aletlerin hayatımıza girmesiyle, 1960'lardan itibaren dikkat çekmeye başlıyor. Sonrasında yapılan tonla performans, yazılım, robot, sensör temelli, mekanik temelli, görsel temelli işlerle yeni medya diye genellediğimiz bir alan varoluyor.\n\nYeni medya eserlerine bu kadar yükselmemizin sebebi de işte bu merakımızı cezbeden çağımızın çeşitliliği. Girişimcilikten sanata bilgi temelli herşeyin değerini kaynaklarımızı çeşitlendirerek arttırıyoruz. İyisi kötüsüyle gani gani bilgi var ortada. Bu bilgilere ulaşmamızı sağlayan şey kilit kelimemiz burada.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1066), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/16.jpeg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1067), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Yeni Medya Sanat Değil", 2548 },
                    { new Guid("b925b916-a7b8-4e1c-8571-efbeae3d1591"), "Geçtiğimiz günlerde internet dergilerini karıştırırken karşıma tınısı çok hoş bir kavram çıktı: “Sanat terapisi” bir solukta okuyup bitirdiğim yazının ardından bunu mutlaka kendi okuyucularımla da paylaşmalıyım diye düşündüm.\n\nHemen hepimizin dönem dönem içine girdiğimiz zor günleri atlatmak için sevdiğimiz şeylere yöneldiğimiz bilinen bir gerçek, ancak inanın bana sanat terapisi çoğundan daha etkili ve bilinç dahilinde gerçekleştirile bir yöntem. Öncelikle kavrama bir tanım getirerek başlamak istiyorum anlatmaya. Sanat terapisi, sanatın farklı alanlarını (resim, müzik, edebiyat veya dramayı) kullanarak kişilerin kendilerini daha iyi yorumlayıp iyileşme sürecine girmelerini sağlayan bir terapi biçimi.\n\nSanat terapisinin tarihçesi oldukça eskilere dayansa da toplum içerisinde yaygınlık kazanması yaşadığımız günlere tekabül ediyor. Hastaların ortaya koyduğu sanatsal ürünler üzerinden yapılan değerlendirmeler ilk kez 1870'li yıllarda yapılmış. Özellikle II. Dünya savaşının akabininde yaşanan ağır bireysel travmaların çözümünde de yer yer kullanılan sanat terapileri Sigmund Freud ve Carl Gustav Jung gibi isimlerin de kavrama ilişkin farklı yaklaşımlarıyla bugüne dek ulaşmış. Sanat terapisinin Türkiye ayağında ise ilk çalışmaları Prof. Dr. Kazım Dağyolu’nun yaptığını görüyoruz. Dağyolu’nun izinden giden Prof. Dr. Süleyman Velioğlu ise çalışmalarını 1957'den beri yönetilmeye devam eden Psikopatolojik Sanat Laboratuvarında yürütmüş. Günümüzde daha da açılım kazanan sanat terapileri İstanbul Üniversitesi Tıp Fakültesi Anabilim Dalından Doç. Dr. Nurhan Eren’e emanet edilmiş. Eren 1995 yılından beri bireysel ve grup odaklı sanat terapileri gerçekleştiriyor. Terapilerinde ise kişinin davranışlarını resim çalışmaları üzerinden uzun sürelere yayarak değerlendirdiği bir metot izliyor.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1063), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/15.jpeg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1064), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Sanatla iyileşmek", 3335 },
                    { new Guid("c8e74294-180c-4729-b1c6-990d0b5e9cee"), "Yediklerimizin vücudumuza dolayısıyla da sağlığımıza etkisi konusunda yapılmış binlerce araştırma bulunuyor. Bu doğrultuda dikkat etmemiz gereken ya da her zaman tüketmeye özen göstermemiz gereken besin grupları var. Ancak bu besin gruplarının etkileri daha genel geçer doğrular şeklinde kabul ediliyor. Farklı bireylerde aynı besinler bambaşka sonuçlara sebep olabiliyor. Örneğin lahana genelde yararlıdır ancak böbrek taşı geliştirmeye yatkın bireylerin dikkat etmesi gereken yiyeceklerin başında geliyor.\n\nDoğru yiyecekleri tüketme ve daha sağlıklı bir bedene sahip olma konusunda farklı alanlarda destek veren teknolojik birçok çözüm var.İlk olarak tüketilen gıdaların içindeki bileşenlerin neler olduğuna odaklanan uygulamalar var. Bu uygulamalar genellikle bir bileşenin belli bir besinde olup olmadığını ölçebiliyor. Nima isimli girişimin evde kullanım için geliştirdiği kit sayesinde bir besinde gluten olup olmadığını ölçebiliyorsunuz. Tellspec ise tahmini olarak bir yiyecekteki kalori ve besin değerlerini ve glisemik yüklemeyi gösteriyor. MyDX ise geliştirilen aparatla yiyeceklerde ağır metaller ya da zehirli ilaçlar var mı onu kontrol etmenizi sağlıyor. İçtiğiniz su için de kullanabiliyorsunuz.\n\nTeknolojinin kişisel sağlık konusunda katkıda bulunduğu alanlardan biri de sanal danışmanlarla doğru beslenme ve egzersiz tavsiyeleri vermek. Ph360 firmasının geliştirdiği Shae isimli danışman önce detaylı bir soru formunun ardından sizi iyice tanıyor ve her gün sağlık durumunuz, hedefiniz ve ortam şartlarına göre en doğru yiyecekleri size öneriyor. Ayrıca ne zaman ve ne şekilde egzersiz yapmanız gerektiğini de iletiyor. Sadece soru formu değil zamanla alışkanlıklarınızı öğrenerek ona göre algoritmalar geliştiriyor ve önerilerini çeşitlendirebiliyor.\n\nDiğer bir alan sizin kişisel sağlık değerlerinizin takibi ile ilgili. Habit, Nutrigenomix, PlainSmart, DNAFit, LifeNome gibi birçok girişimin evde kullanılmak için geliştirdiği kitlerle kan değerleriniz ve DNA’nız takip edilebiliyor ve metabolizmanıza göre uygun beslenme önerileri alabiliyorsunuz. Bu daha da kişisel olarak takibinizi sağlıyor.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1059), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/14.png", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1060), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "En Doğru Beslenmenin Yolu Teknolojiden Geçer", 1658 },
                    { new Guid("dc37cff7-ecfa-4da0-952a-93a967518000"), "Hasta hayatını kurtarabilecek bilginin hızlı paylaşımı ya da maliyet yaratan bürokrasinin azaltılması gibi konularda Blockchain bazlı girişimler sağlık sektörünün oyuncuları olan hasta, hastane, sigorta ve ilaç şirketlerine yeni açılımlar getirebilir.\n\nSon iki yazımızda Blockchain’nin sadece finans dünyasında değil başka pek çok alanda da kullanılabileceğini söylemiş ve bunlardan sanat ve insani yardım dünyası yararına yapılabileceklere bakmıştık.\n\nBu yazımızda ise sağlık alanında Blockchain bize ne gibi faydalar sağlayabilir ona göz atacağız.\n\n2015 yılı Haziran ayında “thedarkoverlord” isimli bir hacker yaklaşık 10 milyon Amerikalı’ya ait medikal veriyi 1 milyon ABD Dolarına yakın bir rakamdan satışa çıkardı. Hacker bu gizli medikal bilgileri dört ayrı şirketin ana bilgisayarlarından almıştı. İşte size merkezi sistemlerin en büyük dezavantajlarından biri: Verilerin bir arada tutulduğu merkezi yapılar her zaman güvenlik açığı potansiyeli taşır.\n\nÖte yandan sağlık kurumlarının kendi özel veritabanlarını tutmaları ve hastaya ait bilgilerin kurumlar arasında paylaşımı ciddi bir sıkıntı. Sistemlerin birbiri ile konuşmaması bir yana bir şekilde iletişim sağlansa bile yaşanan gecikmeler dakikaların bile çok önemli olduğu kimi durumlarda daha ciddi sorunlara hatta ölümlere kadar giden kayıplara yol açabiliyor. Bilgi eğer hastanın kontrolünde olsa acil müdahale gerektiren kritik durumlarda hasta (ya da yakınları) o an ulaşabildikleri ilk sağlık kurumunda yetkili kişilere bu bilgilere erişime izin verebilir ve hastaya gerekli müdahaleler zamanında yapılabilir.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1014), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/13.jpeg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1015), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Sağlık için Blockchain", 1548 },
                    { new Guid("c7534753-4548-4f65-8d01-4753bbbda8e5"), "Merhaba, bugün son zamanlarda en çok ilgi duyduğum konulardan biri olan online eğitim deneyimlerimi aktaracağım. Gündelik hayatta koşuşturmaktan hobilere zaman ayırmak ya da ilgi duyduğumuz bir konu hakkında kursa gitmek neredeyse imkansız hale geliyor. Bu yüzden işe giderken yolda ya da evde boş zamanlarımda ilgi duyduğum bir konu hakkında eğitim almak bence inanılmaz güzel bir fikir. Zaman olsa bile belirli bir zaman aralığını ayırmak son derece zor bir durum.\n\nÖrneğin java öğrenmek istiyorsunuz ve bir kursa yazıldınız diyelim. Geçmiş olsun, cumartesi ve pazar sabahlarınız yollarda heba oldu. Sabah 9:00'dan öğlen 15:00'e kadar kursta ders dinleyerek geçireceksiniz. Peki ya canınız bu hafta sabah 9:00'da java dinlemek istemiyorsa? Gece 4:00'da bir anda java öğrenme aşkınız gelirse ne olacak? Bilmiyorum sizin için durum nedir ama ben genelde kafama estiği zaman bir şeyler yapmayı seven biriyim. Her istediğim zaman her istediğimi(belli bir çerçevede) öğrenebileceğim bir online servis varken bunu denememek saçma olurdu.\n\nBizlere bu lüksü sağlayan tek bir servis yok aslında, Udemy, CodeSchool, TreeHouse gibi bir sürü birbirine çok yakın konseptlerde hizmet sağlayıcılar bulunuyor. İlk başlarda Udemy’den ilgi duyduğum konularda dersler satın almaya başladım ancak istediğim kalitede içerikler yoktu ne yazık ki. Udemy aslında sadece bir aracı, birisi geliyor ben Java anlatacağım diyor çekiyor videolarını, bizlerde gidip satın alıyoruz. Böyle olunca dersin içeriği ve kalitesi belli bir standartta olmuyor. Çok kaliteli derslerde var, çok kalitesiz derslerde. Bu sebeple başka arayışlara girdim ve bana göre sektördeki en iyisi olan TreeHouse ile devam etme kararı aldım.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1070), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/17.png", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1071), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Yeni Nesil Eğitim Sistemi Ve Yazılım Dünyası", 1368 },
                    { new Guid("f96f9e36-400b-4383-b7c0-9d5669992520"), "Son günlerde sağlık teknolojilerine dair gelişmelere olan merakımın ve bu alanda yeni bilgiler öğrenme isteğimin artması için bazı nedenler oldu. Öncelikle yeni cerrahi teknolojilerin bugün geldiği noktayı, sonrasında genetik hastalıkların tedavisinde kullanılmak üzere çalışılan yeni teknolojileri öğrenme fırsatı buldum.\n\nBeni en çok şaşırtan, sağlık teknolojilerinin (HealthTech) günlük hayatımızda kullandığımız teknolojilerden çok daha hızlı geliştiğini fark etmek oldu. Artık yeni bilgisayar modellerine şaşırmıyor ya da yeni telefon modellerine hayran kalmıyoruz. Bir bakıma kendi sınırlarına ulaştıklarını (singularity) söyleyebiliriz. Ancak sağlık için teknoloji kullanımı; güncel donanım ve yazılımlar sayesinde şaşırtıcı bir şekilde gelişiyor. Artık vücudumuzun en zor bölgesindeki cerrahi müdahaleler açık yara olmadan robotik kollar yardımıyla yapılıyor. Veya iflas eden bir organın yerine yeni organlar transplantasyon yapılmadan görev alabiliyor.\n\nTüm bunları paylaşırken uzmanı olmadığım bir konuda ahkam kesmek değil, bilmediğim bir alanda gelişen teknolojik gelişmelere karşı şaşkınlığımı ifade etmek istedim. Sadece kendi uzmanlık alanlarımıza bakarak dünyayı değerlendirmek yerine, diğer alanlara da göz atmakta her zaman fayda var. Bu sayede bazen kendi işlerimizde çok büyük sandığımız değişim ve sıçramaların değerlendirmesini daha sağlıklı yapabiliriz. Bu nedenle diğer disiplinlerdeki gelişmeleri öğrenmeye ve merak etmeye zaman ayırmak gerekiyor.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1005), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/11.png", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1006), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Sağlık İçin Teknoloji", 489 },
                    { new Guid("c04c1664-220b-4284-a392-470ba69c71ee"), "Bu yazıyı 2013 senesinde akademik kariyerimin bebek adımlarını atarken (sektörden yeni geçmiş olmanın verdiği bir gazla) ilk defa kaleme almış ve farklı bir mecrada yayınlamıştım. O zaman da çok ilginç ve keyifli yorumlar almıştım. Şimdi Aykırı Yazılımcılar için yazıya tekrar el attım ve güncelleyerek sizlerle paylaşıyorum.\n\nÖzellikle yazılım işine hiç girmemiş ya da bu işe bulaşmamış ama programlamadan çok iyi anlayan :) arkadaşlara, bölünmenin mahiyetini ve maliyetini terbiyenizi bozmadan bilimsel bir dille anlatmak için yine bu yazıyı kullanabilirsiniz…\nYazılım geliştirme (programlama, kodlama), yaratıcı bir iş çıkartmayı (değeri olan bir çıktı elde etmeyi) hedefleyen bir süreç olup, azami dikkat ve konsantrasyon gerektirir.\nNot: Tam da bu noktada “yazılım bir sanat mıdır?”, “programlama sanatı”, “yaratıcılık ve yazılım”, “yazılım mühendisi olma yazılım sanatçısı ol”, “yazılım geliştirme sadece yaratıcı insanlar için mi?” gibi ucu bucağı bitmeyen konuları açıyoruz… Şimdilik bunları az öteye park edelim :)\n\nTam konsantre bir programlama sırasında beyin bir “akış” (flow) moduna geçmekte, etrafla ilişkisini kesmekte ve bir probleme günlerce konsantre olabilmektedir. Ciddi bir çevresel izolasyon gerektiren akış moduna girildiğinde, üretkenlik maksimum düzeydedir ve tüm kritik kodlamalar bu seviyede yapılır.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1009), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/12.jpg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1010), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Yazılımcı Konsantrasyonu, Beyin Akış Durumu ve Bölünmeler Üzerine", 6489 },
                    { new Guid("73bbb9aa-4f31-4524-83b6-5338855866e1"), "Beynimiz kuşkusuz bizim için en önemli organımızdır. Beynimizi daha verimli kullanmak için birçok zihinsel aktivite yaptığımız gibi, uzmanlar tarafından önerilen fiziksel aktiviteleri de zaman zaman uygulamamız gerekmektedir. İşte bu fiziksel aktivitelerin en önemlisi spordur.\n\nSpor yapmak beynimiz için son derece önemli bir fiziksel aktivitedir. Spor yapan bireylerin, yapmayanlara oranla çok daha rahat odaklandığı, konsantre olduğu, hafızalarının çok daha gelişmiş olduğu ve algılarının da egzersiz yapmayan kimselere oranla çok daha açık olduğu bilimsel araştırmalar ile kanıtlanmıştır.\n\nBu anlamda yapılan araştırmalardan bir tanesi de bir Nörobilimci olan ve aynı zamanda bir TED Talks konuşmacısı olarak bizlere kendisini tanıtan Wendy Suzuki’ye ait. Wendy Suzuki, düzenli yapılan egzersiz sayesinde beynimizdeki dopamin, seratonin, nöradrenalin gibi hormanların salgılanışındaki artışı çalışmalarında gözlemlediğini bunun da beynimizin özellikle hafıza, odaklanma, konsantrasyon gibi işlevlerini yerine getirmede çok daha iyi çalıştığını söylemekte.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(971), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/3.jpg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(972), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Spor Yapmanın Beynimizi Değiştiren Faydaları", 4897 },
                    { new Guid("d6c23f5e-d2ee-44e9-9797-86f83557c899"), "Mağaradan, tarım toplumlarına.. Feodal beyliklerden, sanayi devrimine.. Ve günümüzdeki şirket yapılarına uzanan, insanlığın organizasyon yapısı değişimine baktığımızda tek bir şey görüyoruz: Daha fazla adalet arayışı! Şirketlerden koşarak istifa eden insanlar ne istiyor: Hiç çalışmamak mı? veya zevk aldığı, huzurlu olduğu, kendisinden bir şeyler verebildiği işlerde çalışmak mı? İnsanların büyük şirketlere girmek yerine startuplara yönelmesini, kazanç önemli değil kendim bir Instagram store açarım incik boncuk satarım çabasını, freelance çalışırım mesai saatlerimi kendim belirlerim mantığını incelediğimizde gelecekte şirketlerin istedikleri nitelikte çalışan bulmakta zorlanacağını tahmin etmek zor değil. Burada hemen akla gelen işsizlik ve benzer vasıflarda çok fazla insan varken bunun hiçbir zaman olmayacağı. Kesinlikle evet! Hiçbir zaman şirketler çalışan bulamayıp boş kalmayacak. Ancak istediği adamları bulamayacağı ya da dengeyi kaybedeceği noktaya gelecek.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(975), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/4.jpeg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(976), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Tarih Çağları ve Organizasyon Yapıları", 32658 },
                    { new Guid("7dd1c0eb-9a11-4616-b34c-488f8190649a"), "Arkadaşlar selamlar bu yazımda, ASP.NET Core projelerinde çok kullandığımız Dependency Injection kavramından ve yaşam döngüsünden bahsedeceğim. Dependency injection SOLID prensiplerini uygularken bağımlılıkların en aza indirmek için kullanılan bir yöntemdir. Dependency injection kullanımı ile beraber loosely coupled yapısına da uygun kod yazmış oluruz. Projeye yeni özellikler eklerken, düzeltme veya ekleme yapılacak bölümler en aza indirilmiş olur. Bağımlılık tanımlarını yaparken 3 adet farklı yaşam döngüsü bulunmaktadır.\n Transient (AddTransient) : Uygulama içerisinde bağımlılık olarak oluşturduğumuz ve kullandığımız nesnenin her kullanım ve çağrıda tekrardan oluşturulmasını sağlar. \n Singleton (AddSingleton) : Uygulama içerisinde bağımlılık oluşturduğumuz ve kullandığımız nesnenin tek bir sefer oluşturulmasını ve aynı nesnenin uygulama içinde kullanılmasını sağlar. \n Scoped (AddScoped) : Uygulama içerisindeki bağımlılık oluşturduğumu nesnenin request sonlanana kadar aynı nesneyi kullanmasını farklı bir çağrı için gelindiğinde yeni bir nesne yaratılmasını sağlar.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(983), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/5.png", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(984), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Dependency Injection nedir? ASP.NET Core projelerinde nasıl kullanılır?", 1907 },
                    { new Guid("9ddc51f4-4a67-4d5e-a51e-4b89d39093fd"), "Kimilerinin en büyük korkulu rüyası(!), kimileri için tam bir zaman kaybı. Hayatımızı devam ettirebilmek için en temel şeylerden biri uyku . Gerçekten gerektiği kadar önem veriyor muyuz, kaliteli uyku uyumayı başarabiliyor muyuz? Bunlar hep büyük muammalar. Ancak araştırmaların ortaya çıkardığı gerçek ise, insanların gitgide daha az uyku uyumaya başladığı. Bu vahim durum, uzun vadede erken ölüm riskinde artışa kadar varan kapsamlı sağlık sorunlarının kaynağı olarak görülüyor. \n Ömrümüzün yaklaşık üçte birlik kısmını alan uyku pek çok kişi tarafından zaman kaybı olarak görülür. Hatta daha az uyuyan insanlar, çok uyku uyuyanların hayatı kaçırdıklarını, zamanın bir kısmını boşa harcadığını düşünür. Ancak araştırmalar yeterince uyku uyumayan insanların yaşam sürelerinin daha kısa olduğunu gösteriyor. Bir başka deyişle hayatı kaçırmayayım derken, başka türlü kaçırıyor olabilir.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(987), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/6.jpeg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(988), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Her Şeyin Başı Sağlık, Sağlığın Başı Uyku", 1299 },
                    { new Guid("f8fe96ac-9815-4bd3-b65b-e249726f7d4e"), "Bir süredir 4 büyük firmayı, stratejilerini ve neler yaptıklarını daha yakından izlemeye başladım. Sektörde GAFA adı verilen bu dört firma (Google, Apple, Facebook, Amazon) farklı alanlarda liderlikleri olsa da, bir çok alanda da kesişiyor ve birbirleriyle yarışıyorlar. Hatta daha da sert çekişmelerin olması da kaçınılmaz gibi görünüyor.\n\nAmazon ülkemizde her ne kadar genelde AWS ile bilinse (hatta pek bilinmese) de aslında ABD’de bir çok sektörü derinden etkilemiş, değiştiren ve dönüştüren çok kilit firmalardan birisi. Amazon’un hikayesi, kuruluş süreci gibi konulara girmeden, amacım benim dikkatimi çeken bazı konularda -özellikle de Amazon’un evlere ne kadar sık ve etkili bir şekilde ulaşmasını içeren birkaç konuda Amazon’un ne durumda olduğunu paylaşmak sadece.\n\nABD’de 20 senedir hisseleri borsada işlem gören Amazon, perakende pazarında %5’lik bir paya sahip. Kitap satışı ile işe başlayan Amazon, şu anda neredeyse her şeyi bulabileceğiniz bir açık pazar.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(963), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/2.jpeg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(967), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Kitapçıdan teknoloji devine: Amazon ne yapıyor da dünyayı değiştiriyor?", 1156 },
                    { new Guid("050ae81d-f5ba-4c07-b8f0-a6c710ae1369"), "Tüm kurumlar hızla evrilirken, en eski kurumlardan biri olan okulların da bu değişimden etkilenmemesi mümkün değil. Önümüzdeki yıllarda eğitim bu güne kadarki en hızlı değişim döneminden geçecek. Tüm sektörlerde gördüğümüz altüst olma, eğitimde de olacak. Eğitimciler için pek heyecanlı bir dönem geliyor: ya altüst edileceğiz ya da altüst edenlerden olacağız.\n\nGünümüzün eğitim sisteminin birçok öğesi (8 yıllık zorunlu okul, okuma/yazma ve aritmetik temelli müfredat, not, sınıf, ders, öğretmen) 18. yüzyıl sonunda Prusya’da kurgulandı ve 19. yüzyılda ABD’de geliştirildi. Öğretmenden öğrenciye içerik nakli üzerine kurulu bu üretim hattı modelinin temel amacı emirlere uyabilen, zamanını yönetebilen, rutin süreçleri uygulayabilen, temel okuryazarlığa sahip endüstriyel ekonomi işçisi yetiştirmek idi. Bu modelin zamanı çoktan geçti. Bilginin meta olduğu çağımızda, bırakın endüstri işçisini, bilgi çalışanı yetiştirmek bile yetersiz, artık doğru cevabı aramak yerine farklı cevaplar oluşturabilecek akıllı yaratıcılar yetiştirmek gerekiyor. Fakat maalesef, elimizdeki eğitim sistemi geleceğin toplumu için gereken insan kaynağını oluşturmaktan aciz. Tüm dünya eğitimde dönüşümün sancılarını yaşıyor. Ülkemizde ise durum daha da vahim: bırakın geleceğe insan yetiştirmeyi, eğitim sistemimiz günümüzün ihtiyaçlarını bile karşılamaktan uzak. OECD 2015 Yetişkin Becerileri Araştırması’nda en üst düzeye erişebilen yetişkin oranında tüm kategorilerde (sözel, sayısal, teknoloji ile problem çözme) ve tüm yaş gruplarında (16–24, 25–34, 35–44) sonuncu olmamız tesadüf değil. 2015’de gelmiş geçmiş en kötü PİSA sonuçlarını almış olmamız da tesadüf değil; bu yılın sonunda açıklanacak olan 2018 sınavı sonuçları daha da kötü çıkabilir. Milli Eğitim Bakanımız iyi şeyler için çabalıyor, fakat sistemi bir kişinin kısa sürede değiştirebilme olasılığını düşük görüyorum.\n\nÇağımızda eğitimde değişimi tetikleyen 6 önemli güç var: hızla artan bilgi, yükselen maliyetler, eşitsizlikler, eğitime hızla giren teknoloji, eski sistemi reddeden Z kuşağı ve eğitimde dönüşümü sağlayacağına inandığım girişimciler. Bu 6 önemli gücün etkileşimi sayesinde önümüzdeki 20 yıl içinde eğitimde ciddi bir dönüşüm yaşanacağını düşünüyorum. 21. yüzyılda eğitimin amacı artık öğretmenden öğrenciye bilgi aktarmak değil, çünkü artık bilgi meta haline geldi ve bilgiye ulaşım çok kolay. Öğrenciler istedikleri yerden istedikleri zaman internetten video izleyerek veya farklı bir kaynaktan istedikleri şeyi öğrenebiliyorlar. Sınıfta oturup öğretmeni dinlemek yerine kendi aralarında kurdukları irili ufaklı fiziksel veya sanal gruplar ile rahatlıkla öğrenebiliyorlar. Eğitim sistemi öğrencilerin değişen öğrenme biçimlerini ve alışkanlıklarını göz önüne alınarak yeniden kurgulanmak zorunda. 21 yüzyılda eğitimin temel amaçları tutku ve hedef keşfi, kritik becerilerin (eleştirel düşünme ve problem çözme; iş birliği, hızlı hareket ve adaptasyon; inisiyatif ve girişimcilik; etkin sözlü, yazılı ve multimedya iletişim; bilgiye ulaşım ve bilgi analizi; merak ve hayal) geliştirilmesi ve belki de en önemlisi öğrenciye ilham vermek!", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(994), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/8.jpeg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(995), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Eğitim Evriliyor mu?", 1327 },
                    { new Guid("e5b2a53c-9ab1-490d-b21f-298cbed5e5e6"), "Felsefenin ontoloji, siyaset, mantık gibi şanlı kolları varken neden estetik ve sanatla ilgilendiğimi sormuştu birkaç kişi. Çünkü çoğu insan sanatla ilgilenmenin zengin hobisinden öte bir şey olmadığını düşünüyor. Öyle ya iyi bir resim ya da heykel ancak ev dekore edebilir. Hala görüyorum bazen yorumlarda “hakikatin peşindeysen, hakikati araştırıyorsan…” şeklinde başlayan ve sanatın hakikatini küçümseyen ifadeler. Ben sanırım kendimi anlatamadım. Hakikat denen bir şey olmadığı ve hayatta katlanabilmenin en iyi yolu sanat olduğu için sanatla ilgileniyorum. Tarkovsky’nin sevdiğim bir sözü var, “Dünya mükemmel olmadığı için sanat vardır.” demişti. Bu sanat 15. yüzyılda resim ve heykeldi. Şimdi ise sinema, şiir, müzik, edebiyat… Yol değişebilir ama örtülü amaç hep aynı diye düşünüyorum. Yaşamı anlamak ve katlanmak.\n\nHakikatperest değilim. Sonsuz deneyim ufukları var benim için yalnızca. Ben bir müzik dinlerken veya bir film izlerken o nesne öznede nasıl bu etkiyi yaratıyor; nasıl özneyi ele geçiriyor; nasıl bazı şeyler bizi büyülerken diğerleri sıradan geliyor; nasıl ortaya haz duygusunu ortaya çıkartıyor ve nasıl kendine yeni bir gerçeklik yaratabiliyor bunları merak ediyorum. Sanat yapıtını ve estetik deneyimi anlamaya çalışıyorum. Anlayayım ki tüm dünya deneyimim tıpkı sanat deneyimim gibi estetikleşsin, yürümek dahi dans etmek kadar zevk versin istiyorum.\n\nSonsuzun değil; yaşamın peşindeyim.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(998), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/9.jpeg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(999), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Sanat uzun, hayat kısa.", 6659 },
                    { new Guid("1399d257-4c9e-485f-a788-24b7f02decf4"), "Yapay zekâ yolunda atılan adımları ve yaşanan gelişmeleri son derece ilgiyle takip ediyorum. Bu alanda beni çok heyecanlandıran pek çok yenilikle her geçen gün karşılaşsam da özellikle belirtmeliyim ki; bu yenilikler içinde yapay zeka ve sanat ilişkisi hiç ilgimi çekmemişti. Ancak geçen yıl bir konuşma sonrası dinleme fırsatı bulduğum Robot Şair Deniz Yılmaz ‘ın hikayesi beni şaşırtan ve üzerinde düşünmeye iten bir etki yarattı.\n\nBir düşünsenize; “akıllı” bir robot gerçekten okunası şiirler yazıyor, sanatla uğraşıyor; yani “his”lerini ve “düşünce”lerini toplumla buluşturmaya, sesini duyurmaya ihtiyaç duyuyor ve bunda da son derece başarılı. Öyle ki, kendi adını taşıyan şiirlerinin derlendiği kitabı sayesinde okurlarıyla, “hayran kitlesi”yle buluşuyor.\n\nDeniz Yılmaz’ı yaratan düşünceyi, beyni daha önceden de yaptığımız özel sohbetlerle şahsen tanıyorum; ancak onu sizlerle de buluşturmak, yapay zekâ ve sanatı nasıl harmanladığını kendi ağzından sizlere aktarabilmesini sağlamak üzere geçtiğimiz günlerde Dijital CEO ile Teknoloji Sohbetleri’nde kendisini ağırladım ve son derece keyifli bir sohbet gerçekleştirdik. Bager Akbay’dan bahsediyorum. Bana göre çok özel bir beyne sahip ve kendisiyle yaptığım her sohbette yepyeni bir bakış açısı kazanmamı sağlıyor. O nedenle sizlerin de bu sohbetten keyif alacağınızı umuyorum.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1001), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/10.jpg", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(1002), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Yapay Zeka ve Sanat", 4897 },
                    { new Guid("0d9a29c3-dad9-4ee1-a324-238d5669c6f0"), "Bireysel olarak çevre üzerindeki etkimizin bir bölümünü neler yediğimiz belirler. Bugüne kadarki en sofistike analizlere göre, sağlıklı yiyecekler yemek her zaman çevre için de en iyi yoldur. Araştırmacılar, sağlıksız diyetlerin insanlara ve gezegene ciddi zarar vererek toplumu tehdit ettiğini gösteriyor. İklim değişikliği göz önünde bulundurularak yemek yemek, 2020'nin en büyük gıda trendi olarak şekilleniyor. Günümüzde beslenme ile ilgili büyüyen bu yeni trend, sağlıklı beslenirken bir yandan da öğünlerin doğaya daha az zarar vermesine dikkat etmeyi içeriyor. İnsanlar, daha az et ve süt tüketen, çevre dostu alternatifler arayan bir ‘iklim diyetine’ yöneliyorlar.\n\n Daha fazla sebze ve daha az (veya hiç) hayvansal ürün yemek, daha sürdürülebilir gıda seçimleri yapmak, sağlığımızı da iyi yönde etkileyen bir unsur. Bununla beraber, vegan olmak ve iklim diyeti uygulamak aynı şey olarak algılanmamalıdır. Hatta badem ve soya gibi popüler vegan gıdalarının yüksek su kullanımı ve ağaçsızlaşma açısından negatif etkileri olabilir. Vejetaryenlerin, veganlardan değişik olarak tükettiği süt ürünlerinin, son dönemlerde yapılan yeni araştırmalar sonucunda, olumlu etkisi de soluklaşmış durumda. Kısaca, pastırma yerine peyniri tercih etmenin gezegen için çok daha yararlı olmadığı ortaya çıktı.\n\nAraştırmalar, genel olarak, iklim, su ve sağlık krizlerini hafifletebilecek diyet değişikliklerini öneriyor. Büyükbaş hayvan, koyun ve keçi etlerinin tüketiminin en yüksek çevresel zarara neden olduğu doğrulanıyor. Ancak, günde bir kez belirli hayvansal ürünler yemenin, etleri hariç tutan ancak süt ürünleri tüketen lakto-ovo vejetaryen diyetlerinden, dünyamız için daha az zararlı olduğunu ortaya çıkarıyor. Tavuk ve balık, özellikle yerel çiftçilerden veya yerel balık pazarlarından satın alındığında, kırmızı etten daha iyi seçenek durumundalar. Yerel et, nakliye emisyonlarını azaltmakta yardımcı konumdadır. Meyve ve sebze satın alırken de “mevsimsel ve bölgesel” durum da değerlendirilmelidir.", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(990), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, "/Images/Post/7.png", new DateTime(2022, 11, 17, 18, 28, 40, 877, DateTimeKind.Local).AddTicks(991), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true, "Beslenme ile İlgili Büyüyen Yeni Trend: İklim Diyeti", 2489 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedDate", "CreatorUserId", "DeletedDate", "DeletoryUserId", "ModifiedDate", "ModifierUserId", "Status" },
                values: new object[,]
                {
                    { new Guid("414f9e1c-676e-40e2-8e5a-bd05797728cf"), "Kültür Sanat", new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8393), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8394), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true },
                    { new Guid("ad535ced-0bfe-44fd-b47f-a10b0a95f7ba"), "Teknoloji", new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(6426), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(7516), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true },
                    { new Guid("906262b0-7ecb-4073-87c6-992cc676bf7e"), "Spor", new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8358), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8363), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true },
                    { new Guid("449c0ab5-f243-4648-ae7b-8314ede30f27"), "Bilim", new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8366), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8368), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true },
                    { new Guid("8e89b79f-cbfd-4996-8c69-a7f4d875a9b1"), "Tarih", new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8370), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8371), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true },
                    { new Guid("6cc1d6de-3547-4543-a0a3-90dfb19ccd42"), "Yazılım", new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8374), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8375), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true },
                    { new Guid("d5152959-1fa7-45e9-a43b-b52f18525e18"), "Sağlık", new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8378), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8379), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true },
                    { new Guid("1f06e44c-ee70-46a3-b127-0aa428440dc0"), "Beslenme", new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8386), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8387), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true },
                    { new Guid("e59b4176-f6d6-48b3-b0af-80aa12adedcd"), "Eğitim", new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8390), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8391), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true },
                    { new Guid("cc44d524-0221-478d-9cf5-bb454b6213dd"), "Edebiyat", new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8396), "05fcadae-fa72-4a86-89ee-2a4943ad265d", null, null, new DateTime(2022, 11, 17, 18, 28, 40, 876, DateTimeKind.Local).AddTicks(8397), "05fcadae-fa72-4a86-89ee-2a4943ad265d", true }
                });

            migrationBuilder.InsertData(
                table: "ArticleCategory",
                columns: new[] { "ArticlesId", "CategoriesId" },
                values: new object[,]
                {
                    { new Guid("f8fe96ac-9815-4bd3-b65b-e249726f7d4e"), new Guid("ad535ced-0bfe-44fd-b47f-a10b0a95f7ba") },
                    { new Guid("8b3ec632-0507-4ebc-9839-d082e672f64c"), new Guid("6cc1d6de-3547-4543-a0a3-90dfb19ccd42") },
                    { new Guid("73bbb9aa-4f31-4524-83b6-5338855866e1"), new Guid("d5152959-1fa7-45e9-a43b-b52f18525e18") },
                    { new Guid("9ddc51f4-4a67-4d5e-a51e-4b89d39093fd"), new Guid("d5152959-1fa7-45e9-a43b-b52f18525e18") },
                    { new Guid("0d9a29c3-dad9-4ee1-a324-238d5669c6f0"), new Guid("d5152959-1fa7-45e9-a43b-b52f18525e18") },
                    { new Guid("f96f9e36-400b-4383-b7c0-9d5669992520"), new Guid("d5152959-1fa7-45e9-a43b-b52f18525e18") },
                    { new Guid("c04c1664-220b-4284-a392-470ba69c71ee"), new Guid("d5152959-1fa7-45e9-a43b-b52f18525e18") },
                    { new Guid("dc37cff7-ecfa-4da0-952a-93a967518000"), new Guid("d5152959-1fa7-45e9-a43b-b52f18525e18") },
                    { new Guid("c8e74294-180c-4729-b1c6-990d0b5e9cee"), new Guid("d5152959-1fa7-45e9-a43b-b52f18525e18") },
                    { new Guid("b925b916-a7b8-4e1c-8571-efbeae3d1591"), new Guid("d5152959-1fa7-45e9-a43b-b52f18525e18") },
                    { new Guid("f88c1c0e-f384-4008-aca0-f950a0fb5796"), new Guid("6cc1d6de-3547-4543-a0a3-90dfb19ccd42") },
                    { new Guid("0d9a29c3-dad9-4ee1-a324-238d5669c6f0"), new Guid("1f06e44c-ee70-46a3-b127-0aa428440dc0") },
                    { new Guid("c7534753-4548-4f65-8d01-4753bbbda8e5"), new Guid("e59b4176-f6d6-48b3-b0af-80aa12adedcd") },
                    { new Guid("f8fe96ac-9815-4bd3-b65b-e249726f7d4e"), new Guid("414f9e1c-676e-40e2-8e5a-bd05797728cf") },
                    { new Guid("d6c23f5e-d2ee-44e9-9797-86f83557c899"), new Guid("414f9e1c-676e-40e2-8e5a-bd05797728cf") },
                    { new Guid("e5b2a53c-9ab1-490d-b21f-298cbed5e5e6"), new Guid("414f9e1c-676e-40e2-8e5a-bd05797728cf") },
                    { new Guid("1399d257-4c9e-485f-a788-24b7f02decf4"), new Guid("414f9e1c-676e-40e2-8e5a-bd05797728cf") },
                    { new Guid("b925b916-a7b8-4e1c-8571-efbeae3d1591"), new Guid("414f9e1c-676e-40e2-8e5a-bd05797728cf") },
                    { new Guid("65aaa38a-7e2b-4575-8e86-3d82f70b4621"), new Guid("414f9e1c-676e-40e2-8e5a-bd05797728cf") },
                    { new Guid("f236ec17-be64-4939-8680-f53cedbb0796"), new Guid("414f9e1c-676e-40e2-8e5a-bd05797728cf") },
                    { new Guid("8373b590-dd2d-40d3-a6c4-698a2438daae"), new Guid("cc44d524-0221-478d-9cf5-bb454b6213dd") },
                    { new Guid("050ae81d-f5ba-4c07-b8f0-a6c710ae1369"), new Guid("e59b4176-f6d6-48b3-b0af-80aa12adedcd") },
                    { new Guid("c364ccb4-ae38-40b3-8a41-6e658a8c9cf1"), new Guid("cc44d524-0221-478d-9cf5-bb454b6213dd") },
                    { new Guid("c7534753-4548-4f65-8d01-4753bbbda8e5"), new Guid("6cc1d6de-3547-4543-a0a3-90dfb19ccd42") },
                    { new Guid("1399d257-4c9e-485f-a788-24b7f02decf4"), new Guid("6cc1d6de-3547-4543-a0a3-90dfb19ccd42") },
                    { new Guid("7dd1c0eb-9a11-4616-b34c-488f8190649a"), new Guid("ad535ced-0bfe-44fd-b47f-a10b0a95f7ba") },
                    { new Guid("1399d257-4c9e-485f-a788-24b7f02decf4"), new Guid("ad535ced-0bfe-44fd-b47f-a10b0a95f7ba") },
                    { new Guid("f96f9e36-400b-4383-b7c0-9d5669992520"), new Guid("ad535ced-0bfe-44fd-b47f-a10b0a95f7ba") },
                    { new Guid("c04c1664-220b-4284-a392-470ba69c71ee"), new Guid("ad535ced-0bfe-44fd-b47f-a10b0a95f7ba") },
                    { new Guid("dc37cff7-ecfa-4da0-952a-93a967518000"), new Guid("ad535ced-0bfe-44fd-b47f-a10b0a95f7ba") },
                    { new Guid("c8e74294-180c-4729-b1c6-990d0b5e9cee"), new Guid("ad535ced-0bfe-44fd-b47f-a10b0a95f7ba") },
                    { new Guid("b925b916-a7b8-4e1c-8571-efbeae3d1591"), new Guid("ad535ced-0bfe-44fd-b47f-a10b0a95f7ba") },
                    { new Guid("65aaa38a-7e2b-4575-8e86-3d82f70b4621"), new Guid("ad535ced-0bfe-44fd-b47f-a10b0a95f7ba") },
                    { new Guid("f88c1c0e-f384-4008-aca0-f950a0fb5796"), new Guid("ad535ced-0bfe-44fd-b47f-a10b0a95f7ba") },
                    { new Guid("dc37cff7-ecfa-4da0-952a-93a967518000"), new Guid("6cc1d6de-3547-4543-a0a3-90dfb19ccd42") },
                    { new Guid("8b3ec632-0507-4ebc-9839-d082e672f64c"), new Guid("ad535ced-0bfe-44fd-b47f-a10b0a95f7ba") },
                    { new Guid("73bbb9aa-4f31-4524-83b6-5338855866e1"), new Guid("906262b0-7ecb-4073-87c6-992cc676bf7e") },
                    { new Guid("f88c1c0e-f384-4008-aca0-f950a0fb5796"), new Guid("906262b0-7ecb-4073-87c6-992cc676bf7e") },
                    { new Guid("ebfcee97-a0b1-4976-8df9-247bc76e2ce4"), new Guid("449c0ab5-f243-4648-ae7b-8314ede30f27") },
                    { new Guid("c04c1664-220b-4284-a392-470ba69c71ee"), new Guid("449c0ab5-f243-4648-ae7b-8314ede30f27") },
                    { new Guid("bb7591b8-8fe4-46ed-8050-e9f3caf730b1"), new Guid("449c0ab5-f243-4648-ae7b-8314ede30f27") },
                    { new Guid("d6c23f5e-d2ee-44e9-9797-86f83557c899"), new Guid("8e89b79f-cbfd-4996-8c69-a7f4d875a9b1") }
                });

            migrationBuilder.InsertData(
                table: "ArticleCategory",
                columns: new[] { "ArticlesId", "CategoriesId" },
                values: new object[,]
                {
                    { new Guid("8b3ec632-0507-4ebc-9839-d082e672f64c"), new Guid("8e89b79f-cbfd-4996-8c69-a7f4d875a9b1") },
                    { new Guid("f236ec17-be64-4939-8680-f53cedbb0796"), new Guid("8e89b79f-cbfd-4996-8c69-a7f4d875a9b1") },
                    { new Guid("7dd1c0eb-9a11-4616-b34c-488f8190649a"), new Guid("6cc1d6de-3547-4543-a0a3-90dfb19ccd42") },
                    { new Guid("bb7591b8-8fe4-46ed-8050-e9f3caf730b1"), new Guid("ad535ced-0bfe-44fd-b47f-a10b0a95f7ba") },
                    { new Guid("f236ec17-be64-4939-8680-f53cedbb0796"), new Guid("cc44d524-0221-478d-9cf5-bb454b6213dd") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategory_CategoriesId",
                table: "ArticleCategory",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreatorUserId",
                table: "Articles",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatorUserId",
                table: "Categories",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatorUserId",
                table: "Comments",
                column: "CreatorUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
