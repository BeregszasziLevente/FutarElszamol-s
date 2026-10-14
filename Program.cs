using FutarElszamolás;
using System.IO;

List<Futar> futarok = new List<Futar>();
string[] sorok = File.ReadAllLines("futarok.txt");

Console.WriteLine("Adatok beolvasása a futarok.txt fájlból...");

foreach (string sor in sorok)
{
    string[] darabolt = sor.Split(";");
    
    Futar peldany = new Futar();

    peldany.Nev = darabolt[0];
    peldany.MegtettKm=int.Parse(darabolt[1]);
    peldany.CsomagSzam=int.Parse(darabolt[2]);
    peldany.KesesPercek=int.Parse(darabolt[3]);
    
    futarok.Add(peldany);
}

Console.WriteLine("\nFutárok napi elszámolása:");

int TeljesNapiMunkaber = 0;
int OsszesCsomag = 0;

int LegnagyobbBer = 0;
string LegnagyobbBerNev = "";

int KesesNelkul = 0;

foreach (Futar futar in futarok)
{
    int MunkaBer = futar.CsomagSzam * 600 + futar.MegtettKm * 100;

    if (futar.CsomagSzam>=20 && futar.KesesPercek<15) { MunkaBer += 8000; }
    if (futar.KesesPercek>=30) { MunkaBer -= 5000; }

    TeljesNapiMunkaber += MunkaBer;
    OsszesCsomag += futar.CsomagSzam;

    if (MunkaBer>LegnagyobbBer)
    {
        LegnagyobbBer = MunkaBer;
        LegnagyobbBerNev = futar.Nev;
    }

    if (futar.KesesPercek==0) { KesesNelkul++; }

    Console.WriteLine($"{futar.Nev}: {futar.CsomagSzam} csomag, {futar.MegtettKm} km (Késés: {futar.KesesPercek} perc) - Munkabér: {MunkaBer} Ft");
}

Console.WriteLine("\nÖsszesített statusztika:");
Console.WriteLine($"Cég által kifizetett teljes munkabér: {TeljesNapiMunkaber} Ft");
Console.WriteLine($"Átlagos csomagszám futáronként: {Math.Round(futarok.Average(a=>a.CsomagSzam),0)} csomag");
Console.WriteLine($"Legmagasabb napi bér: {LegnagyobbBerNev} ({LegnagyobbBer} Ft)");
Console.WriteLine($"Késés nélkül dolgozó futárok száma: {KesesNelkul} fő");