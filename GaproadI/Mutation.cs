using System.Diagnostics;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Randomizations;
using System;

public class Mutation : IMutation
{
    public bool IsOrdered { get; private set; } 

    public Mutation()
    {
        IsOrdered = true;
    }

    public void Mutate(IChromosome chromosome, float probability)
    {
        

        for (int i = 0; i < chromosome.Length; i++)
        {
            // Para cada gene do cromossoma, verifica se deve ser mutado com base na probabilidade fornecida
            if (RandomizationProvider.Current.GetDouble() <= probability)
            {
                
                double mean = 0; 
                double std = 1; 
                double geneValue = SampleGaussian(mean, std);
                // O novo valor gerado é usado para substituir o valor original do gene no cromossoma.
                chromosome.ReplaceGene(i, new Gene(geneValue));
            }
        }
    }

    protected double SampleGaussian(double mean, double std)
    {
        
        double x1 = RandomizationProvider.Current.GetDouble(0, 1);
        double x2 = RandomizationProvider.Current.GetDouble(0, 1);
        double y1 = Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Cos(2.0 * Math.PI * x2);
        return y1 * std + mean;
    }
}
