using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApi.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    HomeAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    IsBlocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Biography = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCards_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<float>(type: "REAL", nullable: false),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Receipts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ISBN = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Summary = table.Column<string>(type: "TEXT", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QuantityInStock = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    Discount = table.Column<int>(type: "INTEGER", nullable: false),
                    PublisherId = table.Column<int>(type: "INTEGER", nullable: true),
                    Order_ReceiptId = table.Column<int>(type: "INTEGER", nullable: true),
                    ShoppingCartId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Order_Receipts_Order_ReceiptId",
                        column: x => x.Order_ReceiptId,
                        principalTable: "Order_Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategory_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Liked = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Email", "FullName", "HomeAddress", "Image", "IsBlocked", "Password", "Phone", "Role" },
                values: new object[] { 1, "admin@admin", "Admin", "HomAddress Admin", "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg", false, "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918", "+84xxxxxx", 2 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Email", "FullName", "HomeAddress", "Image", "IsBlocked", "Password", "Phone", "Role" },
                values: new object[] { 2, "employee1@employee", "Employee 1", "HomAddress Employee 1", "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg", false, "2FDC0177057D3A5C6C2C0821E01F4FA8D90F9A3BB7AFD82B0DB526AF98D68DE8", "+84xxxxxx", 1 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Email", "FullName", "HomeAddress", "Image", "IsBlocked", "Password", "Phone", "Role" },
                values: new object[] { 3, "employee2@employee", "Employee 2", "HomAddress Employee 2", "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg", true, "2FDC0177057D3A5C6C2C0821E01F4FA8D90F9A3BB7AFD82B0DB526AF98D68DE8", "+84xxxxxx", 1 });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "FullName", "Image" },
                values: new object[] { 1000006, "Maeve Binchy was born on 28 May 1940 in Dublin and raised in Dalkey. The eldest child of a lawyer and a nurse, Maeve received her education at the Holy Child Convent in nearby Killiney. From there she went on to earn herself a BA (Bachelor of Arts Degree) in History from University College Dublin. In the years after she graduated she taught in several schools for girls and wrote stories during her summer holidays. In 1969 one of her stories earned her a job writing a column in The Irish Times and her career as a writer officially began. Maeve Binchy's books have put her name on the top 10 of Britain's most popular writers, not to mention the New York Times' Bestseller List. Considered a true Irish storyteller, Binchy's novels touch on issues such as parent-child relationships and the illusion of love.", "Maeve Binchy", "http://s.s-bol.com/imgbase0//imagebase/regular/FC/5/3/4/5/305435.jpg" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "FullName", "Image" },
                values: new object[] { 1000005, "Sophie Kinsella ex-financieel journaliste en schrijfster van de Shopaholic-reeks. Sophie Kinsella woont in Surrey, Engeland samen met haar man en vier zoons. Ze heeft twee zussen en vindt het (meestal) heerlijk om met hen te gaan winkelen. Met haar bestsellers Hou je mond!, Shopaholic!, Shopaholic! in alle staten en Shopaholic! zegt ja, veroverde zij de harten van miljoenen lezers over de hele wereld. Ook de romans onder haar eigen naam Madeleine Wickham, Zoete tranen, Slapeloze nachten, Dubbel feest en De cocktailclub, zijn inmiddels razend beroemd.", "Sophie Kinsella", "http://s.s-bol.com/imgbase0/PARTYIMAGE/FC/6/6/9/1/1/66911.gif" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "FullName", "Image" },
                values: new object[] { 1000004, "Dan Brown is een Amerikaanse schrijver van thrillers. Tot Brown besloot zich volledig op het schrijven te storten, doceerde hij Engels aan de Philips Exeter Academy. Zijn interesse in het breken van geheimzinnige codes en fascinatie voor de werkwijze van inlichtingendiensten leidde tot het schrijven van zijn eerste twee boeken: Het Juvenalis Dilemma en De Delta Deceptie. Samen met zijn vrouw Blythe, die kunsthistorica en schilderes is, gaat hij regelmatig op reis om research voor zijn boeken te doen, zo ook naar Parijs. Daar waren ze veel in het Louvre te vinden. De bestseller De Da Vinci Code was het resultaat. In 2009 publiceerde Dan Brown zijn vijfde boek Het verloren symbool.", "Dan Brown", "http://s.s-bol.com/imgbase0/PARTYIMAGE/FC/1/5/6/6/0/1566097.gif" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "FullName", "Image" },
                values: new object[] { 1000002, "Terry Brooks (8 januari 1944, Sterling (Illinois)) is een Amerikaans schrijver van epische fantasy. Hij is vooral bekend geworden door zijn serie Shannara, waarvan het eerste deel, Het Zwaard van Shannara, in 1977 verscheen. Brooks werd geboren in Sterling, Illinois en studeerde Engelse literatuur aan het Hamilton College in New York. Aan de Washington & Lee University studeerde hij rechten. Aanvankelijk werkte hij als advocaat, maar na de publicatie van zijn eerste boek besloot hij in 1986 om fulltime te gaan schrijven. Brooks schreef ook het boek Star Wars Episode I: A Phantom Menace (1999) van de gelijknamige film.", "Terry Brooks", "http://2.bp.blogspot.com/-Sd0btC31U58/T0uFQR-ajcI/AAAAAAAAACg/YBEFGGQO9uA/s200/TerryBrooks_A_plus.jpg" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "FullName", "Image" },
                values: new object[] { 1000003, "David Baldacci (1960) werd geboren in Virginia in de Verenigde Staten. Na zijn studies politieke wetenschappen en rechten werkte hij negen jaar lang als advocaat in Washington D.C. In 1982 studeerde hij cum laude af, en begon hij aan een studie rechten. Tijdens deze studie zette hij zijn eerste schreden op het schrijverspad. Ook toen hij na zijn afstuderen in 1986 aan het werk ging als advocaat en bedrijfsjurist, bleef hij schrijven. In 1996 verscheen zijn sensationele debuut Het recht van de macht (Absolute power) die later verfilmd werd door Clint Eastwood, waarmee hij in een klap doorbrak. Zijn werk is in 35 talen vertaald en wereldwijd zijn er 40 miljoen van zijn boeken verkocht.", "David Baldacci", "http://s.s-bol.com/imgbase0//imagebase/regular/FC/4/1/8/6/6814.jpg" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "FullName", "Image" },
                values: new object[] { 1000009, "Nicholas Charles Sparks was born in Omaha, Nebraska, on December 31, 1965, the second son of Patrick Michael and Jill Emma Marie Sparks. His siblings are Michael Earl Sparks and Danielle Sparks. As a child, he lived in Minnesota, Los Angeles, and Grand Island, Nebraska, finally settling in Fair Oaks, California, at the age of eight. His father was a professor, his mother a homemaker, then an optometrist's assistant. He lived in Fair Oaks through high school, graduated valedictorian in 1984, and received a full track scholarship to the University of Notre Dame. After breaking the Notre Dame school record as part of a relay team in 1985 as a freshman, he was injured and spent the summer recovering. During that summer, he wrote his first novel, though it was never published. He majored in Business Finance and graduated with high honors in 1988. He and his wife Catherine, who met on spring break in 1988, were married in July 1989. While living in Sacramento, he wrote a second novel that same year, though that novel wasn't published, either. He worked a variety of jobs over the next three years, including real estate appraisal, waiting tables, selling dental products by phone, and starting his own small manufacturing business which struggled from the beginning. In 1990, he collaborated on a book with Billy Mills, the Olympic Gold Medalist. Though it received scant publicity, sales topped 50,000 copies in the first year of release. Nicholas attends church regularly and reads approximately 125 books a year. He contributes to a variety of local and national charities, and is a major contributor to the Creative Writing Program (MFA) at the University of Notre Dame, where he provides scholarships, internships, and a fellowship annually. Along with his wife, he founded The Epiphany School in New Bern, North Carolina, and he spent five years coaching track and field athletes at the local public high school.", "Nicholas Sparks", "http://s.s-bol.com/imgbase0//imagebase/regular/FC/2/7/6/9/839672.jpg" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "FullName", "Image" },
                values: new object[] { 1000008, "Khaled Hosseini was born in Kabul, Afghanistan, in 1965. His father was a diplomat with the Afghan Foreign Ministry and his mother taught Farsi and History at a large high school in Kabul. In 1970, the Foreign Ministry sent his family to Tehran, where his father worked for the Afghan embassy. They lived in Tehran until 1973, at which point they returned to Kabul. In July of 1973, on the night Hosseini’s youngest brother was born, the Afghan king, Zahir Shah, was overthrown in a bloodless coup by the king’s cousin, Daoud Khan. At the time, Hosseini was in fourth grade and was already drawn to poetry and prose; he read a great deal of Persian poetry as well as Farsi translations of novels ranging from Alice in Wonderland to Mickey Spillane’s Mike Hammer series. In 1976, the Afghan Foreign Ministry once again relocated the Hosseini family, this time to Paris. They were ready to return to Kabul in 1980, but by then Afghanistan had already witnessed a bloody communist coup and the invasion of the Soviet army. The Hosseinis sought and were granted political asylum in the United States. In September of 1980, Hosseini’s family moved to San Jose, California. They lived on welfare and food stamps for a short while, as they had lost all of their property in Afghanistan. His father took multiple jobs and managed to get his family off welfare. Hosseini graduated from high school in 1984 and enrolled at Santa Clara University where he earned a bachelor’s degree in Biology in 1988. The following year, he entered the University of California-San Diego’s School of Medicine, where he earned a Medical Degree in 1993. He completed his residency at Cedars-Sinai Hospital in Los Angeles and began practicing Internal Medicine in 1996. His first love, however, has always been writing. Hosseini has vivid, and fond, memories of peaceful pre-Soviet era Afghanistan, as well as of his personal experiences with Afghan Hazaras. One Hazara in particular was a thirty-year-old man named Hossein Khan, who worked for the Hosseinis when they were living in Iran. When Hosseini was in the third grade, he taught Khan to read and write. Though his relationship with Hossein Khan was brief and rather formal, Hosseini always remembered the fondness that developed between them. In 2006, Hosseini was named a goodwill envoy to the UNHCR, The United Nations Refugee Agency.", "Khaled Hosseini", "http://s.s-bol.com/imgbase0//imagebase/regular/FC/6/0/0/4/1504006.jpg" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "FullName", "Image" },
                values: new object[] { 1000007, "John Irving was born in Exeter, New Hampshire, on March 3, 1942, and he once admitted that he was a 'grim' child. Although he excelled in English at school and knew by the time he graduated that he wanted to write novels, it was not until he met a young Southern novelist named John Yount, at the University of New Hampshire, that he received encouragement. In 1963, Irving enrolled at the Institute of European Studies in Vienna, and he later worked as a university lecturer. His first novel, Setting Free the Bears, about a plot to release all the animals from the Vienna Zoo, was followed by The Water-Method Man, a comic tale of a man with a urinary complaint, and The 158-Pound Marriage, which exposes the complications of spouse-swapping. Irving achieved international recognition with The World According to Garp, which he hoped would 'cause a few smiles among the tough-minded and break a few softer hearts'. The Hotel New Hampshire is a startlingly original family saga, and The Cider House Rules is the story of Doctor Wilbur Larch - saint, obstetrician, founder of an orphanage, ether addict and abortionist - and of his favourite orphan, Homer Wells, who is never adopted. A Prayer for Owen Meany features the most unforgettable character Irving has yet created. A Son of the Circus is an extraordinary evocation of modern day India. A collection of John Irving's shorter writing, Trying to Save Piggy Sneed, was published in 1993. Irving has also written the screenplays for The Cider House Rules and A Son of the Circus, and wrote about his experiences in the world of movies in his memoir My Movie Business.", "John Irving", "http://s.s-bol.com/imgbase0//imagebase/regular/FC/8/0/4/0/260408.jpg" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "FullName", "Image" },
                values: new object[] { 1000001, "Linda van Rijn (1974, Harmelen) is na haar studie Literatuurwetenschappen in de reisbranche gaan werken. Eerst in het buitenland als reisleidster op diverse toeristische locaties en tegenwoordig als interimmanager voor een grote toeristische organisatie. Al die jaren bleef ze geïnteresseerd in literatuur en ze schreef verhalen, maar nooit met het doel om echt auteur te worden. Dat veranderde na het lezen van Cruise van Suzanne Vermeer. En nu is daar haar eerste literaire thriller Last Minute, een literaire thriller waarmee ze niet alleen Suzanne Vermeer, maar ook andere grote namen als Saskia Noort en Esther Verhoef naar de kroon steekt. In november 2011 zal haar tweede thriller verschijnen bij Uitgeverij Marmer, getiteld Piste Gespertt.", "Linda van Rijn", "http://s.s-bol.com/imgbase0//imagebase/regular/FC/3/9/5/3/4193593.jpg" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 20, 0, "9789044339482", "http://s.s-bol.com/imgbase0/imagebase/large/FC/3/7/6/4/9200000009984673.jpg", null, 18.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Het tennisweekend is Patricks idee. Zijn nieuwe landhuis, gekocht met de bonussen van zijn baan als beleggingsadviseur, is de ideale locatie. Patricks vrouw Caroline weet nog niet wat de werkelijke reden voor het feestje is. Zij vindt het leuk om haar oude buren Stephen en Annie weer te zien, maar ze is minder blij met de snoeverige Charles en zijn verwende vrouw Cressida. En het laatste koppel, Don en Valerie, beiden bloedfanatiek, is helemaal onuitstaanbaar. Terwijl de vier stellen zich op het zonnige terras installeren, lijkt al vast te staan wie de winnaars zijn in het leven en wie de verliezers. Maar wanneer de eerste bal over het net wordt geslagen, is dat het begin van twee dagen flirten, driftbuien, knallende ruzies en schokkende onthullingen. Door de komst van een ongenode gast wordt duidelijk dat dit weekend helemaal niets met tennis te maken heeft. Lang voordat ze beroemd werd met haar Shopaholic! serie schreef Sophie Kinsella onder haar eigen naam, Madeleine Wickham, zeven romans. De tennis party, haar allereerste boek, verscheen toen ze pas vierentwintig was en is daarom altijd heel bijzonder voor haar gebleven. Daarna volgden onder andere Het zwemfeestje en De vraagprijs. Haar werk is in meer dan dertig talen verschenen. De auteur woont met haar man en kinderen in Londen. 'Een rake roman met scherpe observaties. Licht maar dodelijk.' Mail on Sunday", "De Tennisparty" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 17, 0, "9789024561858", "http://s.s-bol.com/imgbase0/imagebase/large/FC/8/9/9/9/9200000010839998.jpg", null, 17.49f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Inferno, de vierde Robert Langdon-thriller, speelt zich af in Italië. `Hoewel ik al tijdens mijn studie Dantes Inferno heb gelezen, heb ik pas onlangs, toen ik onderzoek deed in Florence, echte waardering gekregen voor de invloed van Dantes werk op de moderne tijd,' verklaart Brown. `Ik verheug me erop in mijn nieuwe boek de lezers mee te nemen op een reis naar deze mysterieuze wereld, een landschap vol codes, symbolen en geheime doorgangen.'", "Inferno" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 18, 0, "9789046113110", "http://s.s-bol.com/imgbase0/imagebase/large/FC/2/6/2/1/1001004005971262.jpg", null, 5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Dit is het aangrijpende verhaal van de twaalfjarige Louisa Mae Cardinal, die in New York woont met haar verlegen broertje Oz. Het is 1940 en ze hebben het niet gemakkelijk, want het inkomen van hun vader, die schrijver is, is niet hoog. Maar dat kan Lou niet zoveel schelen, want ze aanbidt haar vader en is gek op zijn verhalen. Maar dan, in één verschrikkelijk moment, verandert Lou's leven voorgoed. Een auto-ongeluk maakt een einde aan hun vaders leven, waardoor zij en Oz moeten verhuizen naar het verre Virginia. Daar, in het isolement van de desolate bergen, komen ze te wonen bij hun excentrieke overgrootmoeder Louisa, Lou's naamgenote. Geplaatst tegenover nieuwe verantwoordelijkheden ziet Lou zich gedwongen snel volwassen te worden. Daar, op haar overgrootmoeders eenvoudige boerderij, op het land waarvan haar vader zo hield en waarover hij steeds weer schreef, ontdekt zij wie zij werkelijk is en wat zij kan betekenen voor deze wereld. En wanneer een vernietigend noodlot hun nieuwe huis treft kan zij de strijd die volgt het hoofd bieden; een strijd die gaat om recht en overleving en die gestreden wordt in een overvolle rechtszaal in Virginia...", "In het hart" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 19, 0, "9781447229902", "http://s.s-bol.com/imgbase0/imagebase/large/FC/6/5/2/3/9200000009123256.jpg", null, 21.99f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "The trap is set. Failure is not an option. When government hit man Will Robie is given his next target he knows he’s about to embark on his toughest mission yet. He is tasked with killing one of their own, following evidence to suggest that fellow assassin Jessica Reel has been turned. She’s leaving a trail of death in her wake including her handler. The trap is set. To send a killer to catch a killer. But what happens when you can’t trust those who have access to the nation’s most secret intelligence?", "The Hit" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 21, 0, "9780552778459", "http://s.s-bol.com/imgbase0/imagebase/large/FC/3/4/5/9/9200000009409543.jpg", null, 25f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "A compelling novel of desire, secrecy, and sexual identity, In One Person is a story of unfulfilled love—tormented, funny, and affecting—and an impassioned embrace of our sexual differences. Billy, the bisexual narrator and main character of In One Person, tells the tragicomic story (lasting more than half a century) of his life as a “sexual suspect,” a phrase first used by John Irving in 1978 in his landmark novel of “terminal cases,” The World According to Garp. His most political novel since The Cider House Rules and A Prayer for Owen Meany, John Irving’s In One Person is a poignant tribute to Billy’s friends and lovers—a theatrical cast of characters who defy category and convention. Not least, In One Person is an intimate and unforgettable portrait of the solitariness of a bisexual man who is dedicated to making himself 'worthwhile.'", "In One Person" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 27, 0, "9781408842423", "http://s.s-bol.com/imgbase0/imagebase/large/FC/0/6/0/3/9200000010223060.jpg", null, 8.99f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "And the Mountains Echoed is a deeply moving story about how we love, how we take care of one another and how the choices we make resonate through generations. With profound wisdom, depth, insight and compassion 'and moving from Kabul, to Paris, to San Francisco, to the Greek island of Tinos' Hosseini writes about the bonds that define us and shape our lives, the ways that we help our loved ones in need and how we are often surprised by the people closest to us. Six years in the writing, Khaled Hosseini says of his new book: 'My earlier novels were, at heart, tales of fatherhood and motherhood. My new novel is a multi-generational family story as well, this time revolving around brothers and sisters, and the ways in which they love, wound, betray, honour and sacrifice for each other.'", "And the Mountains Echoed" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 23, 0, "9789044339338", "http://s.s-bol.com/imgbase0/imagebase/large/FC/3/0/9/4/9200000009984903.jpg", null, 10f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Poppy Wyatt is haar verlovingsring kwijt! Een antiek geval, al drie generaties in het bezit van de familie van Magnus, haar aanstaande. Over tien dagen is de bruiloft! En terwijl ze buiten met haar vriendinnen staat te bellen, wordt haar mobieltje plotseling uit haar handen gegrist. Ook dat nog! Nu is de crisis compleet. Wat moet ze zonder telefoon beginnen? Helemaal hyper denkt Poppy dat ze aan het hallucineren is geslagen wanneer ze in een afvalbak zomaar een smartphone ziet liggen. Hebbes! Maar het duurt niet lang voor de eigenaar, de botte zakenman Sam Roxton, zich meldt. En Sam is 'not amused' als Poppy ijskoud weigert haar schat aan hem af te staan.", "Mag ik je nummer even?" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 24, 0, "9789022556627", "http://s.s-bol.com/imgbase0/imagebase/large/FC/7/8/9/9/1001004011269987.jpg", null, 18.95f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Twintig jaar zijn voorbij gegaan sinds Grianne Ohmsford afstand deed van haar leven als de gevreesde Ilse Hek, ze bevrijd werd door de magie van het Zwaard van Shannara en de vernietiging van haar mentor, de Morgawr. Als Grianne plotseling verdwijnt, wordt haar jonge dienaar Tagwen gedwongen de handschoen op te nemen en haar uit de handen van haar vijanden te redden, samen met Griannes jonge neef Pen Ohmsford en de machtige elf Ahren Elessedil.", "Jarka Ruus" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 25, 0, "9789460680755", "http://s.s-bol.com/imgbase0/imagebase/large/FC/2/5/6/7/1001004011817652.jpg", null, 4.99f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Op de lastminute-vakantie in Hurghada loopt Susan haar ex-vriend tegen het lijf. Liever had ze hem nooit meer gezien... Vijf jaar zijn Susan Waterberg en haar man Hugo getrouwd en gelukkig in Almere. Die mijlpaal wil Susan niet onopgemerkt voorbij laten gaan. Ze regelt haar schoonouders als oppas voor hun zoontje Stijn van drie en boekt een lastminutevakantie naar Hurghada. Voor Hugo is de trip een grote verrassing, zeker omdat hij zijn PADI (duikbrevet) pas een jaar heeft. Nu kan hij eindelijk echt gaan duiken. Hoewel het afscheid van Stijntje hun beiden zwaar valt, verheugen ze zich op een onbezorgde zonvakantie. Als ze op de duikschool inchecken krijgt Susan de schrik van haar leven. De duikinstructeur is een oude bekende en confronteert haar met een verleden dat ze altijd voor Hugo heeft verzwegen. De zorgeloze strandvakantie die Susan voor ogen had, verandert in een web van leugens en chantage. Om haar gezin te behouden, zal ze definitief moeten afrekenen met haar verleden.", "Last Minute" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 26, 0, "9789023464143", "http://s.s-bol.com/imgbase0/imagebase/large/FC/7/3/5/1/1001004010981537.jpg", null, 16.99f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "De ongeschoolde Mariam is vijftien wanneer ze wordt uitgehuwelijkt aan de dertig jaar oudere schoenverkoper Rasheed in Kabul. Jaren later moet zij de beeldschone en slimme Laila naast zich dulden, die door Rasheed na een raketaanval uit het puin is gered. Rasheed neemt Laila in huis in de hoop dat zij hem de zoon zal schenken die Mariam hem niet kan geven. In eerste instantie overheersen tussen de twee vrouwen gevoelens van achterdocht en jaloezie, maar door de tirannieke houding van Rasheed ontstaat er langzamerhand een innige vriendschap. Samen zetten Mariam en Laila alles op alles om te overleven in de eindeloze oorlog van Afghanistan, die voor hen ook binnenshuis woedt. Na het overweldigende succes van De vliegeraar verrast Khaled Hosseini zijn lezers opnieuw met een verpletterend verhaal", "Duizend schitterende zonnen" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 16, 0, "9789000316090", "http://s.s-bol.com/imgbase0/imagebase/large/FC/7/2/1/0/9200000009850127.jpg", null, 14.99f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "In de zomer is het gezellig druk in het badplaatsje Stoneybridge. Overal slenteren vakantiegangers rond en de stranden zijn bezaaid met emmers, schepjes en zandkastelen. Maar in de winter begeeft bijna niemand zich naar de prachtige stranden en de woeste kliffen die samen de ruige westkust van Ierland vormen. De enkeling die toch naar de kust gaat, kan niet om hotel Stone House heen. Daar kan iedere gast rekenen op een warm welkom van eigenaresse Chicky Starr, ongeacht de reden van zijn komst. Zo dragen Henry en Nicola een afschuwelijk geheim met zich mee, ziet de vrolijke verpleegkundige Winnie haar vakantie in het water vallen en komt John op de bonnefooi aanwaaien nadat hij zijn vlucht heeft gemist. De excentrieke Freda is paragnost - en parttime kapper. En dan is er nog Nora, een zwijgzame oudere dame die overal zo het hare van lijkt te denken. Hotel aan zee is een hartverwarmende roman met alle ingrediënten van een echte Maeve Binchy: warmte, humor en heerlijke personages met wie je graag je tijd doorbrengt!", "Hotel aan zee" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 22, 0, "9789400501157", "http://s.s-bol.com/imgbase0/imagebase/large/FC/4/8/2/7/9200000010047284.jpg", null, 19.99f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Will Robie is een van de besten in zijn vak, een huurmoordenaar die nooit twijfelt en altijd zijn doelwit uitschakelt. Hij is de man op wie de Amerikaanse overheid een beroep doet als het gaat om het doden van haar grootste vijanden, van de monsters die talloze onschuldige slachtoffers op hun naam hebben staan. En niemand is zo goed als Robie. Niemand, behalve Jessica Reel... Reel is net als Robie zeer ervaren, uiterst professioneel en dodelijk precies. Maar Reel heeft zich tegen haar werkgever gekeerd en het vizier gericht op haar voormalige collega’s binnen hun agentschap. Nu een van hun eigen mensen moet worden afgestopt, doet men opnieuw een beroep op Robie. Zijn opdracht: zorg dat je Reel te pakken krijgt, levend of dood. Maar wanneer Robie de jacht opent op Reel, ontdekt hij al snel dat zij weleens gegronde redenen kan hebben voor haar verraad. De aanslagen op het agentschap houden verband met een veel groter gevaar. Een gevaar dat Washington D.C., de Verenigde Staten en de rest van de wereld op de grondvesten zal doen schudden...", "De aanslag" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 15, 0, "9780751542974", "http://s.s-bol.com/imgbase0/imagebase/large/FC/4/6/2/8/9200000001208264.jpg", null, 13.8f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "The new epic love story by the bestselling author of The Last Song and The Notebook. They were teenage sweethearts from opposite sides of the tracks - with a passion that would change their lives for ever. But life would force them apart. Years later, the lines they had drawn between past and present are about to slip.. Called back to their hometown for the funeral of the mentor who once gave them shelter when they needed it most, they are faced with each other once again and forced to confront the paths they chose. Can true love ever rewrite the past?", "Best of me" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 10, 0, "9789023464044", "http://s.s-bol.com/imgbase0/imagebase/large/FC/6/3/5/1/1001004010981536.jpg", null, 6.99f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Amir en Hassan zijn gevoed door dezelfde min en groeien samen op in de hoofdstad van Afghanistan. Als blijk van hun verbondenheid kerft Amir hun namen in een granaatappelboom: 'Amir en Hassan, de sultans van Kabul'. Maar sultans zijn ze alleen in hun fantasie, want Amir hoort tot de bevoorrechte bevolkingsgroep en Hassan en zijn vader zijn arme Hazaren, in dienst van Amirs vader. Bij de jaarlijkse vliegerwedstrijd in Kabul is Amir de vliegeraar, degene die het touw van de vlieger in handen heeft. Hassan is zijn hulpje, de vliegervanger. 'Voor jou doe ik alles!' roept Hassan hem toe voordat hij wegrent om de vallende vlieger uit de lucht op te vangen. Die grenzeloze loyaliteit is niet wederzijds. Wanneer er iets vreselijks gebeurt met Hassan verraadt hij zijn trouwe metgezel. Na de Russische inval vluchten Amir en zijn vader naar de Verenigde Staten. Amir bouwt er een nieuw bestaan op, maar hij slaagt er niet in Hassan te vergeten. De ontdekking van een schokkend familiegeheim voert hem uiteindelijk terug naar Afghanistan, dat inmiddels door de Taliban is bezet. Daar wordt Amir geconfronteerd met spoken uit zijn verleden. Zijn voornemen om zijn oude schuld jegens Hassan in te lossen sleept hem tegen wil en dank mee in een huiveringwekkend avontuur. De vliegeraar is verfilmd door Marc Foster als The Kite Runner.", "De Vliegeraar" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 13, 0, "9789023467786", "http://s.s-bol.com/imgbase0/imagebase/large/FC/0/7/8/7/9200000000037870.jpg", null, 19.9f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "In een mens is een meeslepende roman over verlangen, geheimhouding en seksuele identiteit. Een boek over de liefde in al haar verschijningsvormen en een gepassioneerd betoog voor seksuele verscheidenheid. Billy, de biseksuele hoofdpersoon, vertelt het tragikomische verhaal (dat meer dan vijf decennia beslaat) van zijn leven als ‘seksuele verdachte’, een term die John Irving voor het eerst gebruikte in zijn onsterfelijke roman De wereld volgens Garp. Dit is John Irvings meest politieke roman sinds De regels van het ciderhuis en Bidden wij voor Owen Meany en een treffend eerbetoon aan Billy’s vrienden en minnaars – een bonte verzameling personages die de lezer niet licht zal vergeten. Het is een onvergetelijk portret van de eenzame, biseksuele man die zich voorgenomen heeft om 'echt belangrijk' te zijn.", "In een mens" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 1, 0, "9789000307975", "http://s.s-bol.com/imgbase0/imagebase/large/FC/5/3/6/6/1001004011806635.jpg", null, 10f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Vrienden voor het leven is het verhaal van drie vriendinnen die op weg naar volwassenheid verwikkeld raken in een zonderlinge driehoeksverhouding. Benny en Eve, boezemvriendinnen uit het Ierse dorpje Knockglen, gaan in Dublin studeren en sluiten daar al snel vriendschap met de aantrekkelijke en ambitieuze Nan. Het opwindende studentenleven brengt hun echter niet alleen geluk maar ook verdriet. Met haar grote vermogen om menselijke gevoelens herkenbaar neer te zetten weet Maeve Binchy geluk en verdriet, warmte en humor samen te brengen in deze meeslepende roman. Vrienden voor het leven verscheen voor het eerst in 1991 en is het favoriete boek van vele Maeve Binchy-fans. Het boek is inmiddels toe aan de zeventiende druk. In 1995 werd het zeer succesvol verfilmd onder de titel Circle of Friends met Minnie Driver en Chris O’Donnell in de hoofdrollen.", "Vrienden voor het leven" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 2, 0, "9780552159722", "http://s.s-bol.com/imgbase0/imagebase/large/FC/8/8/9/8/1001004006878988.jpg", null, 9.99f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "When a new NASA satellite detects evidence of an astonishingly rare object buried deep in the Arctic ice, the floundering space agency proclaims a much-needed victory.. a victory that has profound implications for U.S. space policy and the impending presidential election. With the Oval Office in the balance, the President dispatches White House Intelligence analyst Rachel Sexton to the Arctic to verify the authenticity of the find. Accompanied by a team of experts, including the charismatic academic Michael Tolland, Rachel uncovers the unthinkable - evidence of scientific trickery - a bold deception that threatens to plunge the world into controversy..", "Deception point" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 3, 0, "9789022558027", "http://s.s-bol.com/imgbase0/imagebase/large/FC/2/2/5/2/9200000002212522.jpg", null, 17.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Vijf eeuwen geleden werd de wereld door een noodlottige demonenoorlog in de as gelegd. De overlevenden hebben een toevluchtsoord gevonden in een door magie beschermde vallei, maar nu staat een genadeloos leger op het punt de vallei binnen te vallen. De enige hoop op redding voor de overlevenden was Sider Ament, maar hij leeft niet meer. Sider was de drager van de enig overgebleven zwarte staf, een machtige talisman die eeuwenlang door de Ridders van het Woord is doorgegeven en die van cruciaal belang is bij het in evenwicht houden van de magie op de wereld. Om de wereld van de ondergang te redden, moet de magie van de staf behouden blijven. Panterra Qu, een jonge Spoorzoeker aan wie de staf na Siders dood wordt doorgegeven, heeft grote moeite om de macht ervan naar zijn hand te zetten. Alles moet op alles worden gezet, want eenieder zal een hoge tol betalen als de oorlog tussen het Woord en de Leegte naar de duisternis dreigt af te glijden. ", "Magic staff" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 4, 0, "9781841499789", "http://s.s-bol.com/imgbase0/imagebase/large/FC/7/0/0/7/9200000009027007.jpg", null, 24.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "The adventure that started in Wards of Faerie takes a thrilling new turn, in the second novel of New York Times bestselling author Terry Brooks’s brand-new trilogy—The Dark Legacy of Shannara! The quest for the long-lost Elfstones has drawn the leader of the Druid order and her followers into the hellish dimension known as the Forbidding, where the most dangerous creatures banished from the Four Lands are imprisoned. Now the hunt for the powerful talismans that can save their world has become a series of great challenges: a desperate search for kidnapped comrades, a relentless battle against unspeakable predators, and a grim race to escape the Forbidding alive. But though freedom is closer than they know, it may come at a terrifying price. Back in the village of Arborlon, the mystical, sentient tree that maintains the barrier between the Four Lands and the Forbidding is dying. And with each passing day, as the breach between the two worlds grows larger, the threat of the evil eager to spill forth and wreak havoc grows more dire. The only hope lies with a young Druid, faced with a staggering choice: cling to the life she cherishes or combat an army of darkness by making the ultimate sacrifice.", "Bloodfire Quest" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 14, 0, "9780751548556", "http://s.s-bol.com/imgbase0/imagebase/large/FC/7/0/3/7/1001004011797307.jpg", null, 9.8f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Do you believe in lucky charms? While in Iraq, U.S. Marine Logan Thibault finds a photo, half-buried in the dirt, of a woman. He carries it in his pocket, and from then on his luck begins to change. Back home, Logan is haunted by thoughts of war. Over time, he becomes convinced that the woman in the photo holds the key to his destiny. So he finds the vulnerable and loving Beth and a passionate romance begins. But Logan battles with the one secret he has kept from Beth: how he found her in the first place. And it is a secret that could utterly destroy everything they love ...", "The lucky one" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 6, 0, "9789460681387", "http://s.s-bol.com/imgbase0/imagebase/large/FC/0/9/4/2/9200000010732490.jpg", null, 48.99f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Als haar kersverse echtgenoot tijdens de huwelijksreis spoorloos verdwijnt, staat Hannah voor een raadsel. Hoe goed kent ze eigenlijk de mensen die ze altijd... De romantische huwelijksreis van Hannah en Koen naar Curaçao wordt ruw verstoord als Koen tijdens het snorkelen spoorloos verdwijnt. Hannah wordt gek van angst. De plaatselijke politie loopt niet zo hard als Hannah zou willen en ten einde raad gaat ze zelf op onderzoek uit. Die zoektocht brengt onaangename waarheden aan het licht. Als Hannah zelfs voor haar eigen leven moet vrezen, wordt ze geconfronteerd met de vraag of ze Koen wel zo goed kent als ze denkt.", "Blue Curacao" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 5, 0, "9781409117933", "http://s.s-bol.com/imgbase0/imagebase/large/FC/6/2/8/0/9200000008070826.jpg", null, 11.99f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Stoneybridge is full of holiday-makers in summer, its beaches are full of buckets and spades and sandcastles; but in winter it's cold and wild. Few choose to walk along the fine sands, the big round pebbles and the exposed rocky promontories that make up the wind-swept Atlantic coastline. Those who do can't help but see Stone House, the big house on the cliff; once falling into disrepair it is now a beautiful hotel specialising in winter holidays. Its big, warm kitchen, its open log-fires and its elegant bedrooms provide a welcome few can resist, whatever their reasons for coming. Henry and Nicola are burdened with a terrible secret, while cheerful nurse Winnie finds herself on the holiday from hell. John has arrived on an impulse after he missed a flight at Shannon; eccentric Freda claims to be a psychic - and a part-time hairdresser. Then there's Nora, a silent watchful older woman who seems ready to disapprove at any moment.. A Week in Winter is full of Maeve's trademark warmth, humour and characters you want to spend time with.", "A Week in Winter" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 8, 0, "9789023429258", "http://s.s-bol.com/imgbase0/imagebase/large/FC/6/3/6/7/1001004005997636.jpg", null, 19.9f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "De wereld volgens Garp is een zeldzaam komische, originele maar ook schokkende roman die John Irving in één klap beroemd maakte. Sinds de verschijning in 1978 hebben miljoenen lezers genoten van de excentrieke, non-conformistische Jenny, haar zoon T.S. Garp en de fanatici, onschuldige kinderen, transseksuelen, hoeren, worstelaars en de vele andere figuren die de wereld van Garp bevolken. De wereld volgens Garp is een klassieker, een meesterlijke tragikomedie die een diepe indruk op de lezer zal achterlaten.", "De wereld volgens Garp" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 9, 0, "9789460680854", "http://s.s-bol.com/imgbase0/imagebase/large/FC/6/6/6/7/9200000002547666.jpg", null, 10f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Vier vriendinnen genieten van een skivakantie in Kirchberg. De moord op een van hen stelt iedereen voor een raadsel... Tijdens een gezellige skivakantie in het Oostenrijkse Kirchberg kunnen de vriendinnen Isa, Chantal, Karen en Annemieke eindelijk weer eens tijd met z'n vieren doorbrengen. Karen, Chantal en Isa arriveren op de zaterdag, Annemieke sluit later aan, ze moet nog werken. De vakantie van de drie begint heel genoeglijk. De vriendinnen hebben de kans echt bij te praten, wat er in het drukke dagelijks leven vaak bij in schiet, en het is prachtig weer om te skien, wat ze dan ook met veel plezier doen. Maar de gezellige skivakantie krijgt een noodlottige wending op de dag dat Annemieke arriveert. Bij aankomst treft ze een van haar vriendinnen dood aan. Rechercheur GŸnter Wolfsberg van de politie in Kirchberg start een onderzoek. Hij verhoort alle vriendinnen en hun partners en ontdekt dat onder het oppervlak van gelukkige relaties en intense vriendschap de nodige spanningen schuilgaan. Het heeft er alle schijn van dat sommige mensen wel erg graag de schuld willen afschuiven...", "Winter Chalet" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 11, 0, "9789024529445", "http://s.s-bol.com/imgbase0/imagebase/large/FC/5/0/5/5/1001004006225505.jpg", null, 14.95f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Hij is terug... Een wetenschappelijke revolutie, een verbijsterende misleiding, een razendsnelle thriller! Onder het poolijs ligt iets wat de wereld voorgoed kan veranderen... Een NASA-satelliet doet een opzienbarende ontdekking op de Noordpool. Dat is een opsteker voor de ruimtevaartorganisatie, die al tijden onder vuur ligt. Ook voor president Zach Herney betekent de vondst goed nieuws: een tweede termijn in het Witte Huis lijkt in zicht. De president vraagt Rachel Sexton, analiste bij de inlichtingendienst NRO, na te gaan of de vondst authentiek is. In allerijl vertrekt ze naar het noordpoolgebied om het werk van een team wetenschappers, onder wie de charismatische oceanograaf Michael Tolland, te controleren. Maar na Rachels aankomst neemt de zaak een onverwachte wending. Het 'bewijs' lijkt minder rotsvast dan gedacht. Voor de president gewaarschuwd kan worden, begint een nachtmerrie op het poolijs. Een speciale eenheid maakt werk van zijn missie: kost wat kost voorkomen dat de waarheid uitkomt... Na Het Juvenalis dilemma, maar vóór De Da Vinci code, schreef Dan Brown deze 'verfijnde mengeling van actie en intriges' (Publishers Weekly). Opnieuw besteedt hij aandacht aan een schimmige geheime dienst. Deze National Reconnaissance Office is nauw verweven met de beroemde ruimtevaartorganisatie NASA. Dan Brown is dé bestsellerauteur van dit moment. De Da Vinci code stond maandenlang op 1 in de top tienen, en ook Het Bernini mysterie en Het Juvenalis dilemma vonden moeiteloos hun weg naar de consument. Ook dit jaar zal in het teken staan van Dan Brown, omdat in mei The Da Vinci Code, dé grote publieksfilm van 2006, wereldwijd in première gaat.", "De delta deceptie" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 12, 0, "9789044309904", "http://s.s-bol.com/imgbase0/imagebase/large/FC/8/3/1/6/1001004002056138.jpg", null, 10f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Emma heeft, zoals alle jonge vrouwen ter wereld, een paar geheimpjes. Voor haar ouders, haar vriend, haar collega's. Zo werd ze ontmaagd in de logeerkamer terwijl haar ouders een film zaten te kijken en ze vindt haar vriend Connor een beetje op Ken lijken. Die van Barbie en Ken. Ze geeft de plant van haar irritante collega sinaasappelsap - bijna dagelijks - en haar string doet pijn. Emma is altijd nerveus als ze moet vliegen. Daarom vertelt ze al haar geheimen zomaar aan een ardige vreemde man die naast haar in het vliegtuig zit. Tenminste, Emma denkt dat het een vreemde is. Want wanneer ze de volgende dag op haar werk komt... Sophie Kinsella is bestsellerschrijfster en journaliste. Ze woont in Londen. Ze heeft weinig grote geheimen, behalve dat ze niet dol is op vliegen.", "Hou je mond!" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Discount", "ISBN", "Image", "Order_ReceiptId", "Price", "PublicationDate", "PublisherId", "QuantityInStock", "ShoppingCartId", "Summary", "Title" },
                values: new object[] { 7, 0, "9780751548525", "http://s.s-bol.com/imgbase0/imagebase/large/FC/0/5/2/3/9200000010683250.jpg", null, 33.8f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, "Love hurts. There is nothing as painful as heartbreak. But in order to learn to love again you must learn to trust again. When a mysterious young woman named Katie appears in the small town of Southport, her sudden arrival raises questions about her past. Beautiful yet unassuming, Katie is determined to avoid forming personal ties until a series of events draws her into two reluctant relationships. Despite her reservations, Katie slowly begins to let down her guard, putting down roots in the close-knit community. But even as Katie starts to fall in love, she struggles with the dark secret that still haunts her ...", "Safe Haven" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "CHILDREN'S BOOKS" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "SOCIAL BOOK" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "PSYCHOLOGICAL BOOK" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "ECONOMIC BOOK" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "NOVEL BOOK" });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000006, 1 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000008, 26 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000001, 25 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000002, 24 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000005, 23 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000003, 22 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000007, 21 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000005, 20 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000003, 19 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000003, 18 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000004, 17 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000006, 16 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000009, 15 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000008, 27 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000007, 13 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000004, 2 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000002, 3 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000002, 4 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000009, 14 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000001, 6 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000006, 5 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000007, 8 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000001, 9 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000008, 10 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000004, 11 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000005, 12 });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1000009, 7 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 16, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 17, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 18, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 19, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 25, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 21, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 22, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 23, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 24, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 15, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 20, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 14, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 12, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 11, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 10, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 9, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 8, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 26, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 13, 1 });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { 27, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BookId",
                table: "AuthorBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Order_ReceiptId",
                table: "Books",
                column: "Order_ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ShoppingCartId",
                table: "Books",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_AccountId",
                table: "CreditCards",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Receipts_AccountId",
                table: "Order_Receipts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AccountId",
                table: "Reviews",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_AccountId",
                table: "ShoppingCarts",
                column: "AccountId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Order_Receipts");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
