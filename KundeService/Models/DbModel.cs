using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;
using System.Data.Entity.Core.EntityClient;
using System.Data.Common;

namespace KundeService.Models
{
    public class BrukerSprsml
    {
        [Key]
        public int id { get; set; }
        public string sprsml { get; set; }
        public string email { get; set; }
    }

    public class FAQ
    {
        public int id { get; set; }
        public string kategori { get; set; }
        public string sprsml { get; set; }
        public string svar { get; set; }
    }

    public class DbInit : DropCreateDatabaseIfModelChanges<SprsmlContext>
    {
        protected override void Seed(SprsmlContext context)
        {

            var faq1 = new FAQ()
            {
                kategori = "Selvbetjening",
                sprsml = "Avbestille",
                svar = @"Hvis du bestiller på sas.no eller gjennom sas sales and service, 
                får du en 24-timers pengene tilbake-garanti. 
                Det betyr at du kan kansellere reisen uten kostnader innen 24 timer etter bestillingen 
                og få full refusjon. Hvis du bestiller mindre enn 24 timer før avgang, kan du kansellere 
                reisen din opptil 12 timer før avgang og få full refusjon. Dette gjør du via mine bestillinger på vår hjemmeside. 
                Hvis det er mer enn 24 timer siden du bestilte kan du benytte vårt skjema for avbestille."
            };

            var faq2 = new FAQ()
            {
                kategori = "Selvbetjening",
                sprsml = "Reservere sete",
                svar = @"Her kan du allerede nå kjøpe ditt favorittsete. Hent frem bestillingen ved å legge
                inn referansen og etternavn det er gratis å reservere sete etter at sjekk inn er åpnet (normalt 22 timer før avgang)."
            };
            var faq3 = new FAQ()
            {
                kategori = "Selvbetjening",
                sprsml = "Bestille mat",
                svar = "Du kan forhåndsbestille måltider her. Hent frem bestillingen ved å legge inn referansen og etternavn."
            };
            var faq4 = new FAQ()
            {
                kategori = "Selvbetjening",
                sprsml = "Ekstra bagasje",
                svar = @"Helt frem til sjekk inn åpner kan du kjøpe ekstra bagasje til rabattert pris her. 
                Hent frem bestillingen ved å legge inn referansen og etternavn."
            };
            var faq5 = new FAQ()
            {
                kategori = "Selvbetjening",
                sprsml = "Sjekke inn",
                svar = "Du kan sjekke inn her. Du finner mer informasjon om online sjekk inn her."
            };
            var faq6 = new FAQ()
            {
                kategori = "Selvbetjening",
                sprsml = "Oppgradere",
                svar = "Oppgrader til sas plus eller sas business på din neste flyvning. Du kan by på en oppgradering og finner mer informasjon her."
            };

            var faq7 = new FAQ()
            {
                kategori = "Bagasje",
                sprsml = "Hvor er min bagasje?",
                svar = @"95 % av all forsinket bagasje kommer vanligvis til rette innen 24 timer. 
                Hvis din bagasjen forsvinner eller blir forsinket, gjør vi vårt ytterste for å løse situasjonen så fort som mulig. 
                Du må rapportere forsinket bagasje på flyplassen, ved ankomstserviceskranken. Oppgi telefonnummeret ditt når du 
                rapporterer tapt bagasje, slik at vi kan holde deg oppdatert om søket på sms. Vi vil sende deg en sms når vi finner 
                bagasjen din. Deretter vil vi sende deg en ny sms for å opplyse om når vi har levert bagasjen til adressen du har oppgitt. 
                Du kan holde deg oppdatert om saken i vårt bagasjesporingssystem. Systemet lar deg logge inn ved å bruke et referansenummer 
                (fem bokstaver og fem tall, som arnsk12345) som du finner på mappen du mottok når du rapporterte din forsinkede bagasje. 
                Merk at dette er et annet nummer enn nummeret på bagasjekvitteringen. Når bagasjen har vært borte i 21 dager har du 
                mulighet til å kreve erstatning. Fyll ut blanketten for tapt bagasje og send den sammen med originalkopier av billetten, 
                bagasjekvitteringen og bagasjerapporten til sas sales and support."
            };
            var faq8 = new FAQ()
            {
                kategori = "Bagasje",
                sprsml = "Må jeg gi beskjed til sas på forhånd dersom jeg vil ha med golf bag eller ski?",
                svar = @"Hvis du reiser i en gruppe (fmer enn 9 passasjerer) med flere stk. Spesialbagasje, ber vi om at du alltid 
                registrerer dette før avreise. Hvis du har bestilt gjennom et reisebyrå, må du kontakte dem. 
                Hvis du har bestilt gjennom sas, kan du registrere spesialbagasjen her. Du sjekker inn som vanlig, får bagasjelappene og 
                leverer spesialbagasjen ved skranken markert spesialbagasje. Reiser du med en av våre partnere kan det være andre 
                bagasjeregler som gjelder. Informasjon finnes på det respektive flyselskapets nettsted. Forskjellige 
                flyselskap opererer med forskjellig lastekapasitet. Av den grunn er innsjekking av spesialbagasje en 
                tjeneste med forbehold om tilgjengelighet, og vi kan ikke alltid garantere at din spesialbagasje vil være med på flygningen."
            };
            var faq9 = new FAQ()
            {
                kategori = "Bagasje",
                sprsml = "Er ski og skobag regnet som en eller to kolli bagasje?",
                svar = @"Skiutstyr som pakkes i skipose og en separat skistøvelbag regnes som ett kolli. 
                Dette betyr at hvis du ikke har bagasje utenom skiutstyr og du reiser på en billett som inkluderer innsjekket bagasje, 
                betaler du ikke ekstra. Skiutsyr kan inkludere: ski og staver eller snowboard, hjelm og skisko eller støvler"
            };
            var faq10 = new FAQ()
            {
                kategori = "Bagasje",
                sprsml = "Hvor mye bagasje er tillatt for baby?",
                svar = @"Spedbarnet kan reise med én innsjekket bagasje som veier maks. 23 kg (maks. Størrelse: 115 cm). Ingen håndbagasje er inkludert for spedbarn"
            };
            var faq11 = new FAQ()
            {
                kategori = "Bagasje",
                sprsml = "Hvor mye bagasje kan jeg ta med?",
                svar = @"Les mer om antall kolli du kan ta med. Antall kolli du kan ta med er avhengig av 
                billettypen du reiser på og om du er eurobonus-medlem. Les mer om medlemsnivåer eller reiseklasser"
            };
            var faq12 = new FAQ()
            {
                kategori = "Bagasje",
                sprsml = "Hva er tillatt vekt for innsjekket bagasje?",
                svar = @"Antall kolli du kan ta med er avhengig av billettypen du reiser på og om du er eurobonus-medlem. Les mer om medlemsnivåer eller reiseklasser"
            };
            var faq13 = new FAQ()
            {
                kategori = "Bagasje",
                sprsml = "Hva er håndbabasje reglene?",
                svar = @"Du kan ha med én håndbagasje (maks 8 kg, høyde 55 cm, bredde 40 cm og dybde 23 cm) 
                og én håndveske eller pc-veske (høyde 40 cm, bredde 30 cm og dybde 15 cm) om bord."
            };
            var faq14 = new FAQ()
            {
                kategori = "Bagasje",
                sprsml = "Hvor kan jeg hente gjenstander som ble gjenglemt om bord?",
                svar = @"Det er ikke sas som håndterer eiendeler som glemmes igjen om bord. Hvis du har glemt noe på et fly så er det 
                hittegodskontoret på flyplassen du fløy til du skal kontakte. Spør etter hittegodsavdelingen på flyplassen, eller gå inn på nettsiden til flyplassen. 
                Der pleier det å finnes informasjon"
            };
            var faq15 = new FAQ()
            {
                kategori = "Bagasje",
                sprsml = "Er barnevogn og barnesete for bil regnet som ekstra bagasje?",
                svar = @"Hvis du reiser med et spedbarn (under 2 år), kan du alltid ta med en barnevogn som innsjekket bagasje uten ekstra kostnad. 
                Hvis barnevognen er en todelt modell, bør den pakkes i to deler. Du kan kjøpe spesialposer på flyplassen til å pakke inn barnevognen. 
                Kolliet koster 50 nok, men er gratis hvis du flyr på sas plus og sas business eller hvis du er et eurobonus-medlem på 
                gull- eller diamant-nivå. Husk at ingen andre gjenstander enn barnevognen skal inkluderes i plastikkposen. 
                Hvis du ønsker å ta med en vogn for et barn over 2 år, anses dette som ett stk. Bagasje. Hvis barnet også har sin egen bag, 
                vil en avgift for extra bagasje påløpe."
            };
            var faq16 = new FAQ()
            {
                kategori = "Bagasje",
                sprsml = "Hvor mye koster ekstra bagasje?",
                svar = @"Om du tar med deg mer bagasje enn det som inngår i din billett betaler du en fast kostnad pr ekstra bagasje. 
                Du sparer opp til 40% om du velger å betale for ekstra bagasje innan innsjekk på www.sas.noalle priser gjelder per stk. 
                Innsjekket bagasje og for enveisflygninger (inkludert flyforbindelser). Avgiften for større bagasje 
                (24–32 kg) kan kun betales på flyplassen. Plasskrevende bagasje og bagasje som veier mer enn 32 kg 
                sjekkes inn som spesialbagasje og betales i henhold til prislisten nedenfor."
            };
            var faq17 = new FAQ()
            {
                kategori = "Bestilling",
                sprsml = "Er det mulig å endre en ungdomsbillett?",
                svar = @"Du kan endre dato og tid for reisen din (men ikke destinasjonen), mot et gebyr. Bestillinger gjort på sas.no kan endres online."
            };
            var faq18 = new FAQ()
            {
                kategori = "Bestilling",
                sprsml = "Kan jeg endre min bonusbillett?",
                svar = @"Ja, kan endres frem til 24 timer før avreise. Har du bestilt billetten på sas.no, 
                kan du endre den selv under forutsetning at poengene er fortsatt gyldig."
            };
            var faq19 = new FAQ()
            {
                kategori = "Bestilling",
                sprsml = "Er det mulig å endre min billett?",
                svar = @"Du kan endre tid og dato for reisen (men ikke ruten) på de fleste reiser bestilt på sas.no for omtrent 600 nok 
                per person og rute innen europa. Hvis den nye billettprisen er dyrere enn den opprinnelige, må du også betale mellomlegget"
            };
            var faq20 = new FAQ()
            {
                kategori = "Bestilling",
                sprsml = "Kan jeg endre min billett når jeg har sjekket in?",
                svar = @"Ja, du kan endre billetten etter du har sjekket in, men sjekk inn må kanseleres først. "
            };
            var faq21 = new FAQ()
            {
                kategori = "Bestilling",
                sprsml = "Hvor sent kan jeg endre min billett?",
                svar = @"Reiser du med sas i europa, kan du endre din billett intill 1 time før avreise. Eurobonus billetter kan endres frem til 24 timer før avreise. "
            };
            var faq22 = new FAQ()
            {
                kategori = "Bestilling",
                sprsml = "Får jeg nytt bestillingsreferanse når jeg endrer?",
                svar = @"Nei, du beholder samme bestillingsreferanse."
            };
            var faq23 = new FAQ()
            {
                kategori = "Bestilling",
                sprsml = "Er det gebyr for endring av billett for spedbarn?",
                svar = @"Nei, det er ikke gebyr for endring av billett for spedbarn."
            };
            var faq24 = new FAQ()
            {
                kategori = "Bestilling",
                sprsml = "Kan jeg annullere en avbestilling?",
                svar = @"Nei, da må du gjøre en ny bestilling."
            };
            var faq25 = new FAQ()
            {
                kategori = "Innsjekk",
                sprsml = "Hvordan sjekker jeg inn spesialbagasje?",
                svar = @"Du sjekker inn som vanlig, får bagasjelappene og leverer spesialbagasjen ved skranken merket spesialbagasje."
            };
            var faq26 = new FAQ()
            {
                kategori = "Innsjekk",
                sprsml = "Hvor får jeg bagasjelapper hvis jeg benytter mobil eller internett innsjekk?",
                svar = @"Når du sjekker inn på mobil eller internett, kan du skrive ut bagasjelappene på flyplassen i en sas self service-automat. 
                Fest bagasjelappene på bagasjen og send dem av gårde i en sas self service bag drop (i sverige: arlanda og luleå, 
                i schengen-området og til storbritannia) eller ved sas bag drop-skranken."
            };
            var faq27 = new FAQ()
            {
                kategori = "Innsjekk",
                sprsml = "Kan jeg legge til bagasje etter innsjekk?",
                svar = @"Hvis du må sjekke inn mer bagasje enn det som er tillatt for billetten din, kan du kjøpe overvekt mot et gebyr. 
                Tyngre bagasje kan sendes som flyfrakt."
            };
            var faq28 = new FAQ()
            {
                kategori = "Innsjekk",
                sprsml = "Hvorfor er kun en sjekket inn når det er to i bestillingen?",
                svar = @"For å sjekke inn flere personer med forskjellige etternavn i samme bestilling må du klikke på 'additional passenger(s)' 
                og legge til alle etternavnene.du vil nå ha mulighet til å velge seter og sjekke inn alle personene i bestillingen."
            };
            var faq29 = new FAQ()
            {
                kategori = "Innsjekk",
                sprsml = "Når er fristen for å sjekke inn bagasje?",
                svar = @"Bagasje må være innsjekket i tide til at du kan være ved gaten 20-40 minutter før avgang, avhengig av hvor du reiser fra. "
            };
            var faq30 = new FAQ()
            {
                kategori = "Innsjekk",
                sprsml = "Når må jeg være på flyplassen?",
                svar = @"Når du må være på flyplassen avhenger av hvordan du sjekker inn, din destinasjon og hvor mye bagasje du har. "
            };
            var faq31 = new FAQ()
            {
                kategori = "Innsjekk",
                sprsml = "Hvordan sjekker jeg inn på flyplassen?",
                svar = @"Du benytter benytter sas self-service automat. Legg inn din bookingreferanse eller betalingskortet du opplyste om ved bestilling. 
                Følg de enkle instruksjonene så får du ombordstigningskort og bagasjelapper. Fest bagasjelappene og lever på 'baggage drop'."
            };
            var faq32 = new FAQ()
            {
                kategori = "Innsjekk",
                sprsml = "Trenger jeg ombordstigningskort?",
                svar = @"Ja, du behøver ombordstigningskort for å komme gjennom sikkerhetskontrollen. Du kan få et elektronisk boardingkort om du sjekker inn i vår app. 
                Du kan også hente det fram i vår selvbetjeningsautomat ved å benytte booking referanse eller betalingskort tilknyttet bestillingen. 
                Det er oftest også mulig å printe det ut hjemme eller få det sendt til din mobil."
            };
            var faq33 = new FAQ()
            {
                kategori = "Reiseinformasjon",
                sprsml = "Har dere aviser om bord?",
                svar = @"Du vil finne inflightmagasinet scandinavian traveler om bord hos sas. I tillegg kan du fra 22 timer før avreise laste ned aviser via sas app."
            };
            var faq34 = new FAQ()
            {
                kategori = "Reiseinformasjon",
                sprsml = "Kan vi bestille seter ved siden av hverandre?",
                svar = @"Du kan kjøpe plasser på forhånd. Du kan også velge seter gratis, ved hjelp av vår online innsjekkingstjeneste, som åpnes 22 timer før avreise."
            };
            var faq35 = new FAQ()
            {
                kategori = "Reiseinformasjon",
                sprsml = "Kan jeg ta med egen mat om bord?",
                svar = @"Du kan ta med egen mat ombord hvis du følger sikkerhetsforskriften når det gjelder bagasje. 
                Vær oppmerksom på at det kan være passasjerer med allergi på flyet. Ikke ta med eller spis peanøtter ombord. Vi tilbyr kaffe og te gratis om bord."
            };
            var faq36 = new FAQ()
            {
                kategori = "Reiseinformasjon",
                sprsml = "Hva hvis mitt barn fyller 2 år under reisen?",
                svar = @"Hvis barnet ditt fyller to år under reisen, må du bestille barnebillett begge veier. Andre regler kan gjelde hvis du reiser med andre flyselskaper."
            };
            var faq37 = new FAQ()
            {
                kategori = "Reiseinformasjon",
                sprsml = "Hvor store er setene om bord?",
                svar = @"Størrelsen på setene varierer avhengig av typen av fly. Det kan også variere avhengig av serviceklassen (sas go eller sas plus)."
            };
            var faq38 = new FAQ()
            {
                kategori = "Reiseinformasjon",
                sprsml = "Til hvilke land trenger jeg pass?",
                svar = @"Når du reiser til utlandet, må du ofte ha pass. Passet viser ikke bare hvem du er, 
                men også hvilket land du er bosatt i. Hvis du er en eu-borger som reiser til land i schengen, kan du bruke et nasjonalt identitetskort i stedet for et pass. 
                Ta kontakt med ambassaden til reisemålet ditt angående passets minimumsgyldighet. Reise til andre land vil kreve pass."
            };
            var faq39 = new FAQ()
            {
                kategori = "Reiseinformasjon",
                sprsml = "Jeg har sendt en henvendelse til dere. Når kan jeg forvente å få svar?",
                svar = @"Takk for din henvendelse. Vår målsetning er å svare deg på din henvendelse så raskt som mulig. 
                Du kan følge status på saken din ved å benytte linken i e-postbekreftelsen fra oss."
            };


            context.FAQ.Add(faq1);
            context.FAQ.Add(faq2);
            context.FAQ.Add(faq3);
            context.FAQ.Add(faq4);
            context.FAQ.Add(faq5);
            context.FAQ.Add(faq6);
            context.FAQ.Add(faq7);
            context.FAQ.Add(faq8);
            context.FAQ.Add(faq9);
            context.FAQ.Add(faq10);
            context.FAQ.Add(faq11);
            context.FAQ.Add(faq12);
            context.FAQ.Add(faq13);
            context.FAQ.Add(faq14);
            context.FAQ.Add(faq15);
            context.FAQ.Add(faq16);
            context.FAQ.Add(faq17);
            context.FAQ.Add(faq18);
            context.FAQ.Add(faq19);
            context.FAQ.Add(faq20);
            context.FAQ.Add(faq21);
            context.FAQ.Add(faq22);
            context.FAQ.Add(faq23);
            context.FAQ.Add(faq24);
            context.FAQ.Add(faq25);
            context.FAQ.Add(faq26);
            context.FAQ.Add(faq27);
            context.FAQ.Add(faq28);
            context.FAQ.Add(faq29);
            context.FAQ.Add(faq30);
            context.FAQ.Add(faq31);
            context.FAQ.Add(faq32);
            context.FAQ.Add(faq33);
            context.FAQ.Add(faq34);
            context.FAQ.Add(faq35);
            context.FAQ.Add(faq36);
            context.FAQ.Add(faq37);
            context.FAQ.Add(faq38);
            context.FAQ.Add(faq39);

            base.Seed(context);
        }
    }

    public class SprsmlContext : DbContext
    {
        public SprsmlContext()
          : base("name=Sprsml")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DbInit());
        }

        public DbSet<BrukerSprsml> BrukerSprsml { get; set; }
        public DbSet<FAQ> FAQ { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }


}