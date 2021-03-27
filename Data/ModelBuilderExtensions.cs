using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Utils;
namespace BookStoreAPI.Data
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account{
                    Id = 1,
                    FullName = "Admin",
                    Email = "admin@admin",
                    Password = Hash.GetHashString("admin"),
                    Phone = "+84xxxxxx",
                    HomeAddress = "HomAddress Admin",
                    Image = "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg",
                    Role = Account.AccountRole.Admin
                },
                new Account{
                    Id = 2,
                    FullName = "Employee 1",
                    Email = "employee1@employee",
                    Password = Hash.GetHashString("employee"),
                    Phone = "+84xxxxxx",
                    HomeAddress = "HomAddress Employee 1",
                    Image = "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg",
                    Role = Account.AccountRole.Employee
                },
                new Account{
                    Id = 3,
                    FullName = "Employee 2",
                    Email = "employee2@employee",
                    Password = Hash.GetHashString("employee"),
                    Phone = "+84xxxxxx",
                    HomeAddress = "HomAddress Employee 2",
                    Image = "https://www.ormondbeachmartialarts.com/wp-content/uploads/2017/04/default-image.jpg",
                    IsBlocked = true,
                    Role = Account.AccountRole.Employee
                }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author{
                    Id = 1000007,
                    FullName = "John Irving",
                    Biography = "John Irving was born in Exeter, New Hampshire, on March 3, 1942, and he once admitted that he was a 'grim' child. Although he excelled in English at school and knew by the time he graduated that he wanted to write novels, it was not until he met a young Southern novelist named John Yount, at the University of New Hampshire, that he received encouragement. In 1963, Irving enrolled at the Institute of European Studies in Vienna, and he later worked as a university lecturer. His first novel, Setting Free the Bears, about a plot to release all the animals from the Vienna Zoo, was followed by The Water-Method Man, a comic tale of a man with a urinary complaint, and The 158-Pound Marriage, which exposes the complications of spouse-swapping. Irving achieved international recognition with The World According to Garp, which he hoped would 'cause a few smiles among the tough-minded and break a few softer hearts'. The Hotel New Hampshire is a startlingly original family saga, and The Cider House Rules is the story of Doctor Wilbur Larch - saint, obstetrician, founder of an orphanage, ether addict and abortionist - and of his favourite orphan, Homer Wells, who is never adopted. A Prayer for Owen Meany features the most unforgettable character Irving has yet created. A Son of the Circus is an extraordinary evocation of modern day India. A collection of John Irving's shorter writing, Trying to Save Piggy Sneed, was published in 1993. Irving has also written the screenplays for The Cider House Rules and A Son of the Circus, and wrote about his experiences in the world of movies in his memoir My Movie Business.",
                    Image = "http://s.s-bol.com/imgbase0//imagebase/regular/FC/8/0/4/0/260408.jpg"
                },
                new Author{
                    Id = 1000008,
                    FullName = "Khaled Hosseini",
                    Biography = "Khaled Hosseini was born in Kabul, Afghanistan, in 1965. His father was a diplomat with the Afghan Foreign Ministry and his mother taught Farsi and History at a large high school in Kabul. In 1970, the Foreign Ministry sent his family to Tehran, where his father worked for the Afghan embassy. They lived in Tehran until 1973, at which point they returned to Kabul. In July of 1973, on the night Hosseini’s youngest brother was born, the Afghan king, Zahir Shah, was overthrown in a bloodless coup by the king’s cousin, Daoud Khan. At the time, Hosseini was in fourth grade and was already drawn to poetry and prose; he read a great deal of Persian poetry as well as Farsi translations of novels ranging from Alice in Wonderland to Mickey Spillane’s Mike Hammer series. In 1976, the Afghan Foreign Ministry once again relocated the Hosseini family, this time to Paris. They were ready to return to Kabul in 1980, but by then Afghanistan had already witnessed a bloody communist coup and the invasion of the Soviet army. The Hosseinis sought and were granted political asylum in the United States. In September of 1980, Hosseini’s family moved to San Jose, California. They lived on welfare and food stamps for a short while, as they had lost all of their property in Afghanistan. His father took multiple jobs and managed to get his family off welfare. Hosseini graduated from high school in 1984 and enrolled at Santa Clara University where he earned a bachelor’s degree in Biology in 1988. The following year, he entered the University of California-San Diego’s School of Medicine, where he earned a Medical Degree in 1993. He completed his residency at Cedars-Sinai Hospital in Los Angeles and began practicing Internal Medicine in 1996. His first love, however, has always been writing. Hosseini has vivid, and fond, memories of peaceful pre-Soviet era Afghanistan, as well as of his personal experiences with Afghan Hazaras. One Hazara in particular was a thirty-year-old man named Hossein Khan, who worked for the Hosseinis when they were living in Iran. When Hosseini was in the third grade, he taught Khan to read and write. Though his relationship with Hossein Khan was brief and rather formal, Hosseini always remembered the fondness that developed between them. In 2006, Hosseini was named a goodwill envoy to the UNHCR, The United Nations Refugee Agency.",
                    Image = "http://s.s-bol.com/imgbase0//imagebase/regular/FC/6/0/0/4/1504006.jpg"
                },
                new Author{
                    Id = 1000009,
                    FullName = "Nicholas Sparks",
                    Biography = "Nicholas Charles Sparks was born in Omaha, Nebraska, on December 31, 1965, the second son of Patrick Michael and Jill Emma Marie Sparks. His siblings are Michael Earl Sparks and Danielle Sparks. As a child, he lived in Minnesota, Los Angeles, and Grand Island, Nebraska, finally settling in Fair Oaks, California, at the age of eight. His father was a professor, his mother a homemaker, then an optometrist's assistant. He lived in Fair Oaks through high school, graduated valedictorian in 1984, and received a full track scholarship to the University of Notre Dame. After breaking the Notre Dame school record as part of a relay team in 1985 as a freshman, he was injured and spent the summer recovering. During that summer, he wrote his first novel, though it was never published. He majored in Business Finance and graduated with high honors in 1988. He and his wife Catherine, who met on spring break in 1988, were married in July 1989. While living in Sacramento, he wrote a second novel that same year, though that novel wasn't published, either. He worked a variety of jobs over the next three years, including real estate appraisal, waiting tables, selling dental products by phone, and starting his own small manufacturing business which struggled from the beginning. In 1990, he collaborated on a book with Billy Mills, the Olympic Gold Medalist. Though it received scant publicity, sales topped 50,000 copies in the first year of release. Nicholas attends church regularly and reads approximately 125 books a year. He contributes to a variety of local and national charities, and is a major contributor to the Creative Writing Program (MFA) at the University of Notre Dame, where he provides scholarships, internships, and a fellowship annually. Along with his wife, he founded The Epiphany School in New Bern, North Carolina, and he spent five years coaching track and field athletes at the local public high school.",
                    Image = "http://s.s-bol.com/imgbase0//imagebase/regular/FC/2/7/6/9/839672.jpg"
                },
                new Author{
                    Id = 1000001,
                    FullName = "Linda van Rijn",
                    Biography = "Linda van Rijn (1974, Harmelen) is na haar studie Literatuurwetenschappen in de reisbranche gaan werken. Eerst in het buitenland als reisleidster op diverse toeristische locaties en tegenwoordig als interimmanager voor een grote toeristische organisatie. Al die jaren bleef ze geïnteresseerd in literatuur en ze schreef verhalen, maar nooit met het doel om echt auteur te worden. Dat veranderde na het lezen van Cruise van Suzanne Vermeer. En nu is daar haar eerste literaire thriller Last Minute, een literaire thriller waarmee ze niet alleen Suzanne Vermeer, maar ook andere grote namen als Saskia Noort en Esther Verhoef naar de kroon steekt. In november 2011 zal haar tweede thriller verschijnen bij Uitgeverij Marmer, getiteld Piste Gespertt.",
                    Image = "http://s.s-bol.com/imgbase0//imagebase/regular/FC/3/9/5/3/4193593.jpg"
                },
                new Author{
                    Id = 1000002,
                    FullName = "Terry Brooks",
                    Biography = "Terry Brooks (8 januari 1944, Sterling (Illinois)) is een Amerikaans schrijver van epische fantasy. Hij is vooral bekend geworden door zijn serie Shannara, waarvan het eerste deel, Het Zwaard van Shannara, in 1977 verscheen. Brooks werd geboren in Sterling, Illinois en studeerde Engelse literatuur aan het Hamilton College in New York. Aan de Washington & Lee University studeerde hij rechten. Aanvankelijk werkte hij als advocaat, maar na de publicatie van zijn eerste boek besloot hij in 1986 om fulltime te gaan schrijven. Brooks schreef ook het boek Star Wars Episode I: A Phantom Menace (1999) van de gelijknamige film.",
                    Image = "http://2.bp.blogspot.com/-Sd0btC31U58/T0uFQR-ajcI/AAAAAAAAACg/YBEFGGQO9uA/s200/TerryBrooks_A_plus.jpg"
                },
                new Author{
                    Id = 1000003,
                    FullName = "David Baldacci",
                    Biography = "David Baldacci (1960) werd geboren in Virginia in de Verenigde Staten. Na zijn studies politieke wetenschappen en rechten werkte hij negen jaar lang als advocaat in Washington D.C. In 1982 studeerde hij cum laude af, en begon hij aan een studie rechten. Tijdens deze studie zette hij zijn eerste schreden op het schrijverspad. Ook toen hij na zijn afstuderen in 1986 aan het werk ging als advocaat en bedrijfsjurist, bleef hij schrijven. In 1996 verscheen zijn sensationele debuut Het recht van de macht (Absolute power) die later verfilmd werd door Clint Eastwood, waarmee hij in een klap doorbrak. Zijn werk is in 35 talen vertaald en wereldwijd zijn er 40 miljoen van zijn boeken verkocht.",
                    Image = "http://s.s-bol.com/imgbase0//imagebase/regular/FC/4/1/8/6/6814.jpg"
                },
                new Author{
                    Id = 1000004,
                    FullName = "Dan Brown",
                    Biography = "Dan Brown is een Amerikaanse schrijver van thrillers. Tot Brown besloot zich volledig op het schrijven te storten, doceerde hij Engels aan de Philips Exeter Academy. Zijn interesse in het breken van geheimzinnige codes en fascinatie voor de werkwijze van inlichtingendiensten leidde tot het schrijven van zijn eerste twee boeken: Het Juvenalis Dilemma en De Delta Deceptie. Samen met zijn vrouw Blythe, die kunsthistorica en schilderes is, gaat hij regelmatig op reis om research voor zijn boeken te doen, zo ook naar Parijs. Daar waren ze veel in het Louvre te vinden. De bestseller De Da Vinci Code was het resultaat. In 2009 publiceerde Dan Brown zijn vijfde boek Het verloren symbool.",
                    Image = "http://s.s-bol.com/imgbase0/PARTYIMAGE/FC/1/5/6/6/0/1566097.gif"
                },
                new Author{
                    Id = 1000005,
                    FullName = "Sophie Kinsella",
                    Biography = "Sophie Kinsella ex-financieel journaliste en schrijfster van de Shopaholic-reeks. Sophie Kinsella woont in Surrey, Engeland samen met haar man en vier zoons. Ze heeft twee zussen en vindt het (meestal) heerlijk om met hen te gaan winkelen. Met haar bestsellers Hou je mond!, Shopaholic!, Shopaholic! in alle staten en Shopaholic! zegt ja, veroverde zij de harten van miljoenen lezers over de hele wereld. Ook de romans onder haar eigen naam Madeleine Wickham, Zoete tranen, Slapeloze nachten, Dubbel feest en De cocktailclub, zijn inmiddels razend beroemd.",
                    Image = "http://s.s-bol.com/imgbase0/PARTYIMAGE/FC/6/6/9/1/1/66911.gif"
                },
                new Author{
                    Id = 1000006,
                    FullName = "Maeve Binchy",
                    Biography = "Maeve Binchy was born on 28 May 1940 in Dublin and raised in Dalkey. The eldest child of a lawyer and a nurse, Maeve received her education at the Holy Child Convent in nearby Killiney. From there she went on to earn herself a BA (Bachelor of Arts Degree) in History from University College Dublin. In the years after she graduated she taught in several schools for girls and wrote stories during her summer holidays. In 1969 one of her stories earned her a job writing a column in The Irish Times and her career as a writer officially began. Maeve Binchy's books have put her name on the top 10 of Britain's most popular writers, not to mention the New York Times' Bestseller List. Considered a true Irish storyteller, Binchy's novels touch on issues such as parent-child relationships and the illusion of love.",
                    Image = "http://s.s-bol.com/imgbase0//imagebase/regular/FC/5/3/4/5/305435.jpg"
                }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book{
                    Id = 1,
                    ISBN = "9789000307975",
                    Title = "Vrienden voor het leven",
                    //AuthorId = 1000006,
                    Summary = "Vrienden voor het leven is het verhaal van drie vriendinnen die op weg naar volwassenheid verwikkeld raken in een zonderlinge driehoeksverhouding. Benny en Eve, boezemvriendinnen uit het Ierse dorpje Knockglen, gaan in Dublin studeren en sluiten daar al snel vriendschap met de aantrekkelijke en ambitieuze Nan. Het opwindende studentenleven brengt hun echter niet alleen geluk maar ook verdriet. Met haar grote vermogen om menselijke gevoelens herkenbaar neer te zetten weet Maeve Binchy geluk en verdriet, warmte en humor samen te brengen in deze meeslepende roman. Vrienden voor het leven verscheen voor het eerst in 1991 en is het favoriete boek van vele Maeve Binchy-fans. Het boek is inmiddels toe aan de zeventiende druk. In 1995 werd het zeer succesvol verfilmd onder de titel Circle of Friends met Minnie Driver en Chris O’Donnell in de hoofdrollen.",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/5/3/6/6/1001004011806635.jpg",
                    Price = 10.00f
                },

                new Book {
                    Id = 2,
                    ISBN = "9780552159722",
                    Title = "Deception point",
                    //AuthorId = 1000004,
                    Summary = "When a new NASA satellite detects evidence of an astonishingly rare object buried deep in the Arctic ice, the floundering space agency proclaims a much-needed victory.. a victory that has profound implications for U.S. space policy and the impending presidential election. With the Oval Office in the balance, the President dispatches White House Intelligence analyst Rachel Sexton to the Arctic to verify the authenticity of the find. Accompanied by a team of experts, including the charismatic academic Michael Tolland, Rachel uncovers the unthinkable - evidence of scientific trickery - a bold deception that threatens to plunge the world into controversy..",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/8/8/9/8/1001004006878988.jpg",
                    Price = 9.99f
                },
                new Book {
                    Id = 3,
                    ISBN = "9789022558027",
                    Title = "Magic staff",
                    //AuthorId = 1000002,
                    Summary = "Vijf eeuwen geleden werd de wereld door een noodlottige demonenoorlog in de as gelegd. De overlevenden hebben een toevluchtsoord gevonden in een door magie beschermde vallei, maar nu staat een genadeloos leger op het punt de vallei binnen te vallen. De enige hoop op redding voor de overlevenden was Sider Ament, maar hij leeft niet meer. Sider was de drager van de enig overgebleven zwarte staf, een machtige talisman die eeuwenlang door de Ridders van het Woord is doorgegeven en die van cruciaal belang is bij het in evenwicht houden van de magie op de wereld. Om de wereld van de ondergang te redden, moet de magie van de staf behouden blijven. Panterra Qu, een jonge Spoorzoeker aan wie de staf na Siders dood wordt doorgegeven, heeft grote moeite om de macht ervan naar zijn hand te zetten. Alles moet op alles worden gezet, want eenieder zal een hoge tol betalen als de oorlog tussen het Woord en de Leegte naar de duisternis dreigt af te glijden. ",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/2/2/5/2/9200000002212522.jpg",
                    Price = 17.50f
                },
                new Book {
                    Id = 4,
                    ISBN = "9781841499789",
                    Title = "Bloodfire Quest",
                    //AuthorId = 1000002,
                    Summary = "The adventure that started in Wards of Faerie takes a thrilling new turn, in the second novel of New York Times bestselling author Terry Brooks’s brand-new trilogy—The Dark Legacy of Shannara! The quest for the long-lost Elfstones has drawn the leader of the Druid order and her followers into the hellish dimension known as the Forbidding, where the most dangerous creatures banished from the Four Lands are imprisoned. Now the hunt for the powerful talismans that can save their world has become a series of great challenges: a desperate search for kidnapped comrades, a relentless battle against unspeakable predators, and a grim race to escape the Forbidding alive. But though freedom is closer than they know, it may come at a terrifying price. Back in the village of Arborlon, the mystical, sentient tree that maintains the barrier between the Four Lands and the Forbidding is dying. And with each passing day, as the breach between the two worlds grows larger, the threat of the evil eager to spill forth and wreak havoc grows more dire. The only hope lies with a young Druid, faced with a staggering choice: cling to the life she cherishes or combat an army of darkness by making the ultimate sacrifice.",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/7/0/0/7/9200000009027007.jpg",
                    Price = 24.50f
                },
                new Book {
                    Id = 5,
                    ISBN = "9781409117933",
                    Title = "A Week in Winter",
                    //AuthorId = 1000006,
                    Summary = "Stoneybridge is full of holiday-makers in summer, its beaches are full of buckets and spades and sandcastles; but in winter it's cold and wild. Few choose to walk along the fine sands, the big round pebbles and the exposed rocky promontories that make up the wind-swept Atlantic coastline. Those who do can't help but see Stone House, the big house on the cliff; once falling into disrepair it is now a beautiful hotel specialising in winter holidays. Its big, warm kitchen, its open log-fires and its elegant bedrooms provide a welcome few can resist, whatever their reasons for coming. Henry and Nicola are burdened with a terrible secret, while cheerful nurse Winnie finds herself on the holiday from hell. John has arrived on an impulse after he missed a flight at Shannon; eccentric Freda claims to be a psychic - and a part-time hairdresser. Then there's Nora, a silent watchful older woman who seems ready to disapprove at any moment.. A Week in Winter is full of Maeve's trademark warmth, humour and characters you want to spend time with.",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/6/2/8/0/9200000008070826.jpg",
                    Price = 11.99f
                },
                new Book {
                    Id = 6,
                    ISBN = "9789460681387",
                    Title = "Blue Curacao",
                    //AuthorId = 1000001,
                    Summary = "Als haar kersverse echtgenoot tijdens de huwelijksreis spoorloos verdwijnt, staat Hannah voor een raadsel. Hoe goed kent ze eigenlijk de mensen die ze altijd... De romantische huwelijksreis van Hannah en Koen naar Curaçao wordt ruw verstoord als Koen tijdens het snorkelen spoorloos verdwijnt. Hannah wordt gek van angst. De plaatselijke politie loopt niet zo hard als Hannah zou willen en ten einde raad gaat ze zelf op onderzoek uit. Die zoektocht brengt onaangename waarheden aan het licht. Als Hannah zelfs voor haar eigen leven moet vrezen, wordt ze geconfronteerd met de vraag of ze Koen wel zo goed kent als ze denkt.",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/0/9/4/2/9200000010732490.jpg",
                    Price = 48.99f
                },
                new Book {
                    Id = 7,
                    ISBN = "9780751548525",
                    Title = "Safe Haven",
                    //AuthorId = 1000009,
                    Summary = "Love hurts. There is nothing as painful as heartbreak. But in order to learn to love again you must learn to trust again. When a mysterious young woman named Katie appears in the small town of Southport, her sudden arrival raises questions about her past. Beautiful yet unassuming, Katie is determined to avoid forming personal ties until a series of events draws her into two reluctant relationships. Despite her reservations, Katie slowly begins to let down her guard, putting down roots in the close-knit community. But even as Katie starts to fall in love, she struggles with the dark secret that still haunts her ...",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/0/5/2/3/9200000010683250.jpg",
                    Price = 33.80f
                },
                new Book {
                    Id = 8,
                    ISBN = "9789023429258",
                    Title = "De wereld volgens Garp",
                    //AuthorId = 1000007,
                    Summary = "De wereld volgens Garp is een zeldzaam komische, originele maar ook schokkende roman die John Irving in één klap beroemd maakte. Sinds de verschijning in 1978 hebben miljoenen lezers genoten van de excentrieke, non-conformistische Jenny, haar zoon T.S. Garp en de fanatici, onschuldige kinderen, transseksuelen, hoeren, worstelaars en de vele andere figuren die de wereld van Garp bevolken. De wereld volgens Garp is een klassieker, een meesterlijke tragikomedie die een diepe indruk op de lezer zal achterlaten.",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/6/3/6/7/1001004005997636.jpg",
                    Price = 19.90f
                },
                new Book {
                    Id = 9,
                    ISBN = "9789460680854",
                    Title = "Winter Chalet",
                    //AuthorId = 1000001,
                    Summary = "Vier vriendinnen genieten van een skivakantie in Kirchberg. De moord op een van hen stelt iedereen voor een raadsel... Tijdens een gezellige skivakantie in het Oostenrijkse Kirchberg kunnen de vriendinnen Isa, Chantal, Karen en Annemieke eindelijk weer eens tijd met z'n vieren doorbrengen. Karen, Chantal en Isa arriveren op de zaterdag, Annemieke sluit later aan, ze moet nog werken. De vakantie van de drie begint heel genoeglijk. De vriendinnen hebben de kans echt bij te praten, wat er in het drukke dagelijks leven vaak bij in schiet, en het is prachtig weer om te skien, wat ze dan ook met veel plezier doen. Maar de gezellige skivakantie krijgt een noodlottige wending op de dag dat Annemieke arriveert. Bij aankomst treft ze een van haar vriendinnen dood aan. Rechercheur GŸnter Wolfsberg van de politie in Kirchberg start een onderzoek. Hij verhoort alle vriendinnen en hun partners en ontdekt dat onder het oppervlak van gelukkige relaties en intense vriendschap de nodige spanningen schuilgaan. Het heeft er alle schijn van dat sommige mensen wel erg graag de schuld willen afschuiven...",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/6/6/6/7/9200000002547666.jpg",
                    Price = 10.00f
                },

                new Book {
                    Id = 10,
                    ISBN = "9789023464044",
                    Title = "De Vliegeraar",
                    //AuthorId = 1000008,
                    Summary = "Amir en Hassan zijn gevoed door dezelfde min en groeien samen op in de hoofdstad van Afghanistan. Als blijk van hun verbondenheid kerft Amir hun namen in een granaatappelboom: 'Amir en Hassan, de sultans van Kabul'. Maar sultans zijn ze alleen in hun fantasie, want Amir hoort tot de bevoorrechte bevolkingsgroep en Hassan en zijn vader zijn arme Hazaren, in dienst van Amirs vader. Bij de jaarlijkse vliegerwedstrijd in Kabul is Amir de vliegeraar, degene die het touw van de vlieger in handen heeft. Hassan is zijn hulpje, de vliegervanger. 'Voor jou doe ik alles!' roept Hassan hem toe voordat hij wegrent om de vallende vlieger uit de lucht op te vangen. Die grenzeloze loyaliteit is niet wederzijds. Wanneer er iets vreselijks gebeurt met Hassan verraadt hij zijn trouwe metgezel. Na de Russische inval vluchten Amir en zijn vader naar de Verenigde Staten. Amir bouwt er een nieuw bestaan op, maar hij slaagt er niet in Hassan te vergeten. De ontdekking van een schokkend familiegeheim voert hem uiteindelijk terug naar Afghanistan, dat inmiddels door de Taliban is bezet. Daar wordt Amir geconfronteerd met spoken uit zijn verleden. Zijn voornemen om zijn oude schuld jegens Hassan in te lossen sleept hem tegen wil en dank mee in een huiveringwekkend avontuur. De vliegeraar is verfilmd door Marc Foster als The Kite Runner.",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/6/3/5/1/1001004010981536.jpg",
                    Price = 6.99f
                },
                new Book {
                    Id = 11,
                    ISBN = "9789024529445",
                    Title = "De delta deceptie",
                    //AuthorId = 1000004,
                    Summary = "Hij is terug... Een wetenschappelijke revolutie, een verbijsterende misleiding, een razendsnelle thriller! Onder het poolijs ligt iets wat de wereld voorgoed kan veranderen... Een NASA-satelliet doet een opzienbarende ontdekking op de Noordpool. Dat is een opsteker voor de ruimtevaartorganisatie, die al tijden onder vuur ligt. Ook voor president Zach Herney betekent de vondst goed nieuws: een tweede termijn in het Witte Huis lijkt in zicht. De president vraagt Rachel Sexton, analiste bij de inlichtingendienst NRO, na te gaan of de vondst authentiek is. In allerijl vertrekt ze naar het noordpoolgebied om het werk van een team wetenschappers, onder wie de charismatische oceanograaf Michael Tolland, te controleren. Maar na Rachels aankomst neemt de zaak een onverwachte wending. Het 'bewijs' lijkt minder rotsvast dan gedacht. Voor de president gewaarschuwd kan worden, begint een nachtmerrie op het poolijs. Een speciale eenheid maakt werk van zijn missie: kost wat kost voorkomen dat de waarheid uitkomt... Na Het Juvenalis dilemma, maar vóór De Da Vinci code, schreef Dan Brown deze 'verfijnde mengeling van actie en intriges' (Publishers Weekly). Opnieuw besteedt hij aandacht aan een schimmige geheime dienst. Deze National Reconnaissance Office is nauw verweven met de beroemde ruimtevaartorganisatie NASA. Dan Brown is dé bestsellerauteur van dit moment. De Da Vinci code stond maandenlang op 1 in de top tienen, en ook Het Bernini mysterie en Het Juvenalis dilemma vonden moeiteloos hun weg naar de consument. Ook dit jaar zal in het teken staan van Dan Brown, omdat in mei The Da Vinci Code, dé grote publieksfilm van 2006, wereldwijd in première gaat.",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/5/0/5/5/1001004006225505.jpg",
                    Price = 14.95f
                },
                new Book {
                    Id = 12,
                    ISBN = "9789044309904",
                    Title = "Hou je mond!",
                    //AuthorId = 1000005,
                    Summary = "Emma heeft, zoals alle jonge vrouwen ter wereld, een paar geheimpjes. Voor haar ouders, haar vriend, haar collega's. Zo werd ze ontmaagd in de logeerkamer terwijl haar ouders een film zaten te kijken en ze vindt haar vriend Connor een beetje op Ken lijken. Die van Barbie en Ken. Ze geeft de plant van haar irritante collega sinaasappelsap - bijna dagelijks - en haar string doet pijn. Emma is altijd nerveus als ze moet vliegen. Daarom vertelt ze al haar geheimen zomaar aan een ardige vreemde man die naast haar in het vliegtuig zit. Tenminste, Emma denkt dat het een vreemde is. Want wanneer ze de volgende dag op haar werk komt... Sophie Kinsella is bestsellerschrijfster en journaliste. Ze woont in Londen. Ze heeft weinig grote geheimen, behalve dat ze niet dol is op vliegen.",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/8/3/1/6/1001004002056138.jpg",
                    Price = 10.00f
                },

                new Book {
                    Id = 13,
                    ISBN = "9789023467786",
                    Title = "In een mens",
                    //AuthorId = 1000007,
                    Summary = "In een mens is een meeslepende roman over verlangen, geheimhouding en seksuele identiteit. Een boek over de liefde in al haar verschijningsvormen en een gepassioneerd betoog voor seksuele verscheidenheid. Billy, de biseksuele hoofdpersoon, vertelt het tragikomische verhaal (dat meer dan vijf decennia beslaat) van zijn leven als ‘seksuele verdachte’, een term die John Irving voor het eerst gebruikte in zijn onsterfelijke roman De wereld volgens Garp. Dit is John Irvings meest politieke roman sinds De regels van het ciderhuis en Bidden wij voor Owen Meany en een treffend eerbetoon aan Billy’s vrienden en minnaars – een bonte verzameling personages die de lezer niet licht zal vergeten. Het is een onvergetelijk portret van de eenzame, biseksuele man die zich voorgenomen heeft om 'echt belangrijk' te zijn.",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/0/7/8/7/9200000000037870.jpg",
                    Price = 19.90f
                },
                new Book {
                    Id = 14,
                    ISBN = "9780751548556",
                    Title = "The lucky one",
                    //AuthorId = 1000009,
                    Summary = "Do you believe in lucky charms? While in Iraq, U.S. Marine Logan Thibault finds a photo, half-buried in the dirt, of a woman. He carries it in his pocket, and from then on his luck begins to change. Back home, Logan is haunted by thoughts of war. Over time, he becomes convinced that the woman in the photo holds the key to his destiny. So he finds the vulnerable and loving Beth and a passionate romance begins. But Logan battles with the one secret he has kept from Beth: how he found her in the first place. And it is a secret that could utterly destroy everything they love ...",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/7/0/3/7/1001004011797307.jpg",
                    Price = 9.80f
                },
                new Book {
                    Id = 15,
                    ISBN = "9780751542974",
                    Title = "Best of me",
                    //AuthorId = 1000009,
                    Summary = "The new epic love story by the bestselling author of The Last Song and The Notebook. They were teenage sweethearts from opposite sides of the tracks - with a passion that would change their lives for ever. But life would force them apart. Years later, the lines they had drawn between past and present are about to slip.. Called back to their hometown for the funeral of the mentor who once gave them shelter when they needed it most, they are faced with each other once again and forced to confront the paths they chose. Can true love ever rewrite the past?",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/4/6/2/8/9200000001208264.jpg",
                    Price = 13.80f
                },
                new Book {
                    Id = 16,
                    ISBN = "9789000316090",
                    Title = "Hotel aan zee",
                    //AuthorId = 1000006,
                    Summary = "In de zomer is het gezellig druk in het badplaatsje Stoneybridge. Overal slenteren vakantiegangers rond en de stranden zijn bezaaid met emmers, schepjes en zandkastelen. Maar in de winter begeeft bijna niemand zich naar de prachtige stranden en de woeste kliffen die samen de ruige westkust van Ierland vormen. De enkeling die toch naar de kust gaat, kan niet om hotel Stone House heen. Daar kan iedere gast rekenen op een warm welkom van eigenaresse Chicky Starr, ongeacht de reden van zijn komst. Zo dragen Henry en Nicola een afschuwelijk geheim met zich mee, ziet de vrolijke verpleegkundige Winnie haar vakantie in het water vallen en komt John op de bonnefooi aanwaaien nadat hij zijn vlucht heeft gemist. De excentrieke Freda is paragnost - en parttime kapper. En dan is er nog Nora, een zwijgzame oudere dame die overal zo het hare van lijkt te denken. Hotel aan zee is een hartverwarmende roman met alle ingrediënten van een echte Maeve Binchy: warmte, humor en heerlijke personages met wie je graag je tijd doorbrengt!",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/7/2/1/0/9200000009850127.jpg",
                    Price = 14.99f
                },
                new Book {
                    Id = 17,
                    ISBN = "9789024561858",
                    Title = "Inferno",
                    //AuthorId = 1000004,
                    Summary = "Inferno, de vierde Robert Langdon-thriller, speelt zich af in Italië. `Hoewel ik al tijdens mijn studie Dantes Inferno heb gelezen, heb ik pas onlangs, toen ik onderzoek deed in Florence, echte waardering gekregen voor de invloed van Dantes werk op de moderne tijd,' verklaart Brown. `Ik verheug me erop in mijn nieuwe boek de lezers mee te nemen op een reis naar deze mysterieuze wereld, een landschap vol codes, symbolen en geheime doorgangen.'",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/8/9/9/9/9200000010839998.jpg",
                    Price = 17.49f
                },
                new Book {
                    Id = 18,
                    ISBN = "9789046113110",
                    Title = "In het hart",
                    //AuthorId = 1000003,
                    Summary = "Dit is het aangrijpende verhaal van de twaalfjarige Louisa Mae Cardinal, die in New York woont met haar verlegen broertje Oz. Het is 1940 en ze hebben het niet gemakkelijk, want het inkomen van hun vader, die schrijver is, is niet hoog. Maar dat kan Lou niet zoveel schelen, want ze aanbidt haar vader en is gek op zijn verhalen. Maar dan, in één verschrikkelijk moment, verandert Lou's leven voorgoed. Een auto-ongeluk maakt een einde aan hun vaders leven, waardoor zij en Oz moeten verhuizen naar het verre Virginia. Daar, in het isolement van de desolate bergen, komen ze te wonen bij hun excentrieke overgrootmoeder Louisa, Lou's naamgenote. Geplaatst tegenover nieuwe verantwoordelijkheden ziet Lou zich gedwongen snel volwassen te worden. Daar, op haar overgrootmoeders eenvoudige boerderij, op het land waarvan haar vader zo hield en waarover hij steeds weer schreef, ontdekt zij wie zij werkelijk is en wat zij kan betekenen voor deze wereld. En wanneer een vernietigend noodlot hun nieuwe huis treft kan zij de strijd die volgt het hoofd bieden; een strijd die gaat om recht en overleving en die gestreden wordt in een overvolle rechtszaal in Virginia...",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/2/6/2/1/1001004005971262.jpg",
                    Price = 5.00f
                },

                new Book {
                    Id = 19,
                    ISBN = "9781447229902",
                    Title = "The Hit",
                    //AuthorId = 1000003,
                    Summary = "The trap is set. Failure is not an option. When government hit man Will Robie is given his next target he knows he’s about to embark on his toughest mission yet. He is tasked with killing one of their own, following evidence to suggest that fellow assassin Jessica Reel has been turned. She’s leaving a trail of death in her wake including her handler. The trap is set. To send a killer to catch a killer. But what happens when you can’t trust those who have access to the nation’s most secret intelligence?",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/6/5/2/3/9200000009123256.jpg",
                    Price = 21.99f
                },
                new Book {
                    Id = 20,
                    ISBN = "9789044339482",
                    Title = "De Tennisparty",
                    //AuthorId = 1000005,
                    Summary = "Het tennisweekend is Patricks idee. Zijn nieuwe landhuis, gekocht met de bonussen van zijn baan als beleggingsadviseur, is de ideale locatie. Patricks vrouw Caroline weet nog niet wat de werkelijke reden voor het feestje is. Zij vindt het leuk om haar oude buren Stephen en Annie weer te zien, maar ze is minder blij met de snoeverige Charles en zijn verwende vrouw Cressida. En het laatste koppel, Don en Valerie, beiden bloedfanatiek, is helemaal onuitstaanbaar. Terwijl de vier stellen zich op het zonnige terras installeren, lijkt al vast te staan wie de winnaars zijn in het leven en wie de verliezers. Maar wanneer de eerste bal over het net wordt geslagen, is dat het begin van twee dagen flirten, driftbuien, knallende ruzies en schokkende onthullingen. Door de komst van een ongenode gast wordt duidelijk dat dit weekend helemaal niets met tennis te maken heeft. Lang voordat ze beroemd werd met haar Shopaholic! serie schreef Sophie Kinsella onder haar eigen naam, Madeleine Wickham, zeven romans. De tennis party, haar allereerste boek, verscheen toen ze pas vierentwintig was en is daarom altijd heel bijzonder voor haar gebleven. Daarna volgden onder andere Het zwemfeestje en De vraagprijs. Haar werk is in meer dan dertig talen verschenen. De auteur woont met haar man en kinderen in Londen. 'Een rake roman met scherpe observaties. Licht maar dodelijk.' Mail on Sunday",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/3/7/6/4/9200000009984673.jpg",
                    Price = 18.50f
                },
                new Book {
                    Id = 21,
                    ISBN = "9780552778459",
                    Title = "In One Person",
                    //AuthorId = 1000007,
                    Summary = "A compelling novel of desire, secrecy, and sexual identity, In One Person is a story of unfulfilled love—tormented, funny, and affecting—and an impassioned embrace of our sexual differences. Billy, the bisexual narrator and main character of In One Person, tells the tragicomic story (lasting more than half a century) of his life as a “sexual suspect,” a phrase first used by John Irving in 1978 in his landmark novel of “terminal cases,” The World According to Garp. His most political novel since The Cider House Rules and A Prayer for Owen Meany, John Irving’s In One Person is a poignant tribute to Billy’s friends and lovers—a theatrical cast of characters who defy category and convention. Not least, In One Person is an intimate and unforgettable portrait of the solitariness of a bisexual man who is dedicated to making himself 'worthwhile.'",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/3/4/5/9/9200000009409543.jpg",
                    Price = 25.00f
                },

                new Book {
                    Id = 22,
                    ISBN = "9789400501157",
                    Title = "De aanslag",
                    //AuthorId = 1000003,
                    Summary = "Will Robie is een van de besten in zijn vak, een huurmoordenaar die nooit twijfelt en altijd zijn doelwit uitschakelt. Hij is de man op wie de Amerikaanse overheid een beroep doet als het gaat om het doden van haar grootste vijanden, van de monsters die talloze onschuldige slachtoffers op hun naam hebben staan. En niemand is zo goed als Robie. Niemand, behalve Jessica Reel... Reel is net als Robie zeer ervaren, uiterst professioneel en dodelijk precies. Maar Reel heeft zich tegen haar werkgever gekeerd en het vizier gericht op haar voormalige collega’s binnen hun agentschap. Nu een van hun eigen mensen moet worden afgestopt, doet men opnieuw een beroep op Robie. Zijn opdracht: zorg dat je Reel te pakken krijgt, levend of dood. Maar wanneer Robie de jacht opent op Reel, ontdekt hij al snel dat zij weleens gegronde redenen kan hebben voor haar verraad. De aanslagen op het agentschap houden verband met een veel groter gevaar. Een gevaar dat Washington D.C., de Verenigde Staten en de rest van de wereld op de grondvesten zal doen schudden...",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/4/8/2/7/9200000010047284.jpg",
                    Price = 19.99f
                },
                new Book {
                    Id = 23,
                    ISBN = "9789044339338",
                    Title = "Mag ik je nummer even?",
                    //AuthorId = 1000005,
                    Summary = "Poppy Wyatt is haar verlovingsring kwijt! Een antiek geval, al drie generaties in het bezit van de familie van Magnus, haar aanstaande. Over tien dagen is de bruiloft! En terwijl ze buiten met haar vriendinnen staat te bellen, wordt haar mobieltje plotseling uit haar handen gegrist. Ook dat nog! Nu is de crisis compleet. Wat moet ze zonder telefoon beginnen? Helemaal hyper denkt Poppy dat ze aan het hallucineren is geslagen wanneer ze in een afvalbak zomaar een smartphone ziet liggen. Hebbes! Maar het duurt niet lang voor de eigenaar, de botte zakenman Sam Roxton, zich meldt. En Sam is 'not amused' als Poppy ijskoud weigert haar schat aan hem af te staan.",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/3/0/9/4/9200000009984903.jpg",
                    Price = 10.00f
                },

                new Book {
                    Id = 24,
                    ISBN = "9789022556627",
                    Title = "Jarka Ruus",
                    //AuthorId = 1000002,
                    Summary = "Twintig jaar zijn voorbij gegaan sinds Grianne Ohmsford afstand deed van haar leven als de gevreesde Ilse Hek, ze bevrijd werd door de magie van het Zwaard van Shannara en de vernietiging van haar mentor, de Morgawr. Als Grianne plotseling verdwijnt, wordt haar jonge dienaar Tagwen gedwongen de handschoen op te nemen en haar uit de handen van haar vijanden te redden, samen met Griannes jonge neef Pen Ohmsford en de machtige elf Ahren Elessedil.",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/7/8/9/9/1001004011269987.jpg",
                    Price = 18.95f
                },
                new Book {
                    Id = 25,
                    ISBN = "9789460680755",
                    Title = "Last Minute",
                    //AuthorId = 1000001,
                    Summary = "Op de lastminute-vakantie in Hurghada loopt Susan haar ex-vriend tegen het lijf. Liever had ze hem nooit meer gezien... Vijf jaar zijn Susan Waterberg en haar man Hugo getrouwd en gelukkig in Almere. Die mijlpaal wil Susan niet onopgemerkt voorbij laten gaan. Ze regelt haar schoonouders als oppas voor hun zoontje Stijn van drie en boekt een lastminutevakantie naar Hurghada. Voor Hugo is de trip een grote verrassing, zeker omdat hij zijn PADI (duikbrevet) pas een jaar heeft. Nu kan hij eindelijk echt gaan duiken. Hoewel het afscheid van Stijntje hun beiden zwaar valt, verheugen ze zich op een onbezorgde zonvakantie. Als ze op de duikschool inchecken krijgt Susan de schrik van haar leven. De duikinstructeur is een oude bekende en confronteert haar met een verleden dat ze altijd voor Hugo heeft verzwegen. De zorgeloze strandvakantie die Susan voor ogen had, verandert in een web van leugens en chantage. Om haar gezin te behouden, zal ze definitief moeten afrekenen met haar verleden.",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/2/5/6/7/1001004011817652.jpg",
                    Price = 4.99f
                },
                new Book {
                    Id = 26,
                    ISBN = "9789023464143",
                    Title = "Duizend schitterende zonnen",
                    //AuthorId = 1000008,
                    Summary = "De ongeschoolde Mariam is vijftien wanneer ze wordt uitgehuwelijkt aan de dertig jaar oudere schoenverkoper Rasheed in Kabul. Jaren later moet zij de beeldschone en slimme Laila naast zich dulden, die door Rasheed na een raketaanval uit het puin is gered. Rasheed neemt Laila in huis in de hoop dat zij hem de zoon zal schenken die Mariam hem niet kan geven. In eerste instantie overheersen tussen de twee vrouwen gevoelens van achterdocht en jaloezie, maar door de tirannieke houding van Rasheed ontstaat er langzamerhand een innige vriendschap. Samen zetten Mariam en Laila alles op alles om te overleven in de eindeloze oorlog van Afghanistan, die voor hen ook binnenshuis woedt. Na het overweldigende succes van De vliegeraar verrast Khaled Hosseini zijn lezers opnieuw met een verpletterend verhaal",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/7/3/5/1/1001004010981537.jpg",
                    Price = 16.99f
                },
                new Book {
                    Id = 27,
                    ISBN = "9781408842423",
                    Title = "And the Mountains Echoed",
                    //AuthorId = 1000008,
                    Summary = "And the Mountains Echoed is a deeply moving story about how we love, how we take care of one another and how the choices we make resonate through generations. With profound wisdom, depth, insight and compassion 'and moving from Kabul, to Paris, to San Francisco, to the Greek island of Tinos' Hosseini writes about the bonds that define us and shape our lives, the ways that we help our loved ones in need and how we are often surprised by the people closest to us. Six years in the writing, Khaled Hosseini says of his new book: 'My earlier novels were, at heart, tales of fatherhood and motherhood. My new novel is a multi-generational family story as well, this time revolving around brothers and sisters, and the ways in which they love, wound, betray, honour and sacrifice for each other.'",
                    Image = "http://s.s-bol.com/imgbase0/imagebase/large/FC/0/6/0/3/9200000010223060.jpg",
                    Price = 8.99f
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category{
                    Id = 1,
                    Name = "SOCIAL BOOK"
                },
                new Category{
                    Id = 2,
                    Name = "PSYCHOLOGICAL BOOK",
                },
                new Category{
                    Id = 3,
                    Name = "ECONOMIC BOOK",
                },
                new Category{
                    Id = 4,
                    Name = "CHILDREN'S BOOKS",
                },
                new Category{
                    Id = 5,
                    Name = "NOVEL BOOK"
                }
            );

            modelBuilder.Entity<AuthorBook>().HasData(
                new AuthorBook{
                    BookId = 1,
                    AuthorId = 1000006,
                },
                new AuthorBook {
                    BookId = 2,
                    AuthorId = 1000004,
                },
                new AuthorBook {
                    BookId = 3,
                    AuthorId = 1000002,
                },
                new AuthorBook {
                    BookId = 4,
                    AuthorId = 1000002,
                },
                new AuthorBook {
                    BookId = 5,
                    AuthorId = 1000006,
                },
                new AuthorBook {
                    BookId = 6,
                    AuthorId = 1000001,
                },
                new AuthorBook {
                    BookId = 7,
                    AuthorId = 1000009,
                },
                new AuthorBook {
                    BookId = 8,
                    AuthorId = 1000007,
                },
                new AuthorBook {
                    BookId = 9,
                    AuthorId = 1000001,
                },
                new AuthorBook {
                    BookId = 10,
                    AuthorId = 1000008,
                },
                new AuthorBook {
                    BookId = 11,
                    AuthorId = 1000004,
                },
                new AuthorBook {
                    BookId = 12,
                    AuthorId = 1000005,
                },
                new AuthorBook {
                    BookId = 13,
                    AuthorId = 1000007,
                },
                new AuthorBook {
                    BookId = 14,
                    AuthorId = 1000009,
                },
                new AuthorBook {
                    BookId = 15,
                    AuthorId = 1000009,
                },
                new AuthorBook {
                    BookId = 16,
                    AuthorId = 1000006,
                },
                new AuthorBook {
                    BookId = 17,
                    AuthorId = 1000004,
                },
                new AuthorBook {
                    BookId = 18,
                    AuthorId = 1000003,
                },

                new AuthorBook {
                    BookId = 19,
                    AuthorId = 1000003,
                },
                new AuthorBook {
                    BookId = 20,
                    AuthorId = 1000005,
                },
                new AuthorBook {
                    BookId = 21,
                    AuthorId = 1000007,
                },

                new AuthorBook {
                    BookId = 22,
                    AuthorId = 1000003,
                },
                new AuthorBook {
                    BookId = 23,
                    AuthorId = 1000005,
                },
                new AuthorBook {
                    BookId = 24,
                    AuthorId = 1000002,
                },
                new AuthorBook {
                    BookId = 25,
                    AuthorId = 1000001,
                },
                new AuthorBook {
                    BookId = 26,
                    AuthorId = 1000008,
                },
                new AuthorBook {
                    BookId = 27,
                    AuthorId = 1000008,
                }
            );
            modelBuilder.Entity<BookCategory>().HasData(
                new BookCategory{
                    BookId = 1,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 2,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 3,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 4,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 5,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 6,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 7,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 8,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 9,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 10,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 11,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 12,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 13,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 14,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 15,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 16,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 17,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 18,
                    CategoryId = 1,
                },

                new BookCategory {
                    BookId = 19,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 20,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 21,
                    CategoryId = 1,
                },

                new BookCategory {
                    BookId = 22,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 23,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 24,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 25,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 26,
                    CategoryId = 1,
                },
                new BookCategory {
                    BookId = 27,
                    CategoryId = 1,
                }
            );
            return modelBuilder;
        }
    }
}