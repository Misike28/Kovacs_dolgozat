using kovacs_mihaly_dolgozat;
using System.Text;

List<Versenyzok> racers = [];
using StreamReader sr = new(
    path: "..\\..\\..\\src\\forras.txt",
    encoding: Encoding.UTF8);

while (!sr.EndOfStream) racers.Add(new(sr.ReadLine()));
Console.WriteLine($"{racers.Count} versenyző fejezte be a versenyt");

var elit = racers.Count(r => r.Category == "elit");
Console.WriteLine($"{elit} számú versenyző van az elit kategóriában");

var kor = racers
    .Where (r=> r.Sex==false)
    .Average (r=> DateTime.Now.Year - r.Year);

Console.WriteLine($"A női versenyzők átlag életkora: {kor}");
var kereksum = TimeSpan.FromSeconds(racers.Sum(p => p.Kerekpar.TotalSeconds)).TotalHours;
Console.WriteLine($"A versenyzők kerékpározással töltött összideje: {kereksum:0.00} óra");

var uszasavg = TimeSpan.FromSeconds(racers
    .Where(r => r.Category == "elit junior")
    .Average(r => r.Uszas.TotalSeconds));
Console.WriteLine($"Az úszással töltött átlag idő: {uszasavg}");

var ferfiwinner = racers
    .Where(r => r.Sex)
    .MinBy(r => r.Uszas.TotalSeconds + r.Elsodepo.TotalSeconds + r.Uszas.TotalSeconds + r.Masodikdepo.TotalSeconds + r.Futas.TotalSeconds);
Console.WriteLine(ferfiwinner);
var kategoriak = racers
    .OrderBy(r => r.Category)
    .GroupBy(r => r.Category);
foreach (var c in kategoriak)
{
    Console.WriteLine($"{c.Key}: {c.Count()}");
}

