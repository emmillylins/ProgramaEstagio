﻿using System;

public class Episodios
{
	public Episodios() { }

	public int Numero {  get; set; }
	public string Titulo { get; set; }
	public double Duracao { get; set; }
	public string Resumo { get; set; }
	public int TotalConvidados { get; set; }

	public List<Convidado> Convidados { get; set; } = [];
}
