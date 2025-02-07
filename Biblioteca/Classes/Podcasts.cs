using System;

public class Podcasts(string nomePodcast)
{
    List<Podcasts> NumeroEpisodio { get; set; }
    public string Nome { get; set; }
    public double Duracao { get; set; }
    public string Resumo { get; set; }
}
