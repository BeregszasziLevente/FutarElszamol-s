using FutarElszamolás;
using System.IO;

List<Futar> futarok = new List<Futar>();
string[] sorok = File.ReadAllLines("futarok.txt");

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