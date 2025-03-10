using System.Collections.Generic;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Randomizations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Runner.UnityApp.Car;
using System.Linq;



public class ParentSelection : SelectionBase
{
    private readonly int tournamentSize;

    public ParentSelection(int tournamentSize) : base(2)
    {
        this.tournamentSize = tournamentSize;
    }

    protected override IList<IChromosome> PerformSelectChromosomes(int number, Generation generation)
    {
        IList<CarChromosome> population = generation.Chromosomes.Cast<CarChromosome>().ToList();
        IList<IChromosome> parents = new List<IChromosome>();

        while (parents.Count < number)
        {
            // Selecionar aleatoriamente os índices dos indivíduos para competir no torneio
            int[] randomIndexes = RandomizationProvider.Current.GetUniqueInts(tournamentSize, 0, population.Count);

            // Avaliar o desempenho de cada indivíduo e selecionar o melhor
            CarChromosome bestIndividual = null;
            float bestFitness = float.MinValue;

            foreach (int index in randomIndexes)
            {
                CarChromosome individual = population[index];
                float fitness = (float)individual.Fitness;
                // Verificar se o fitness deste indivíduo é o melhor até agora

                if (fitness > bestFitness)
                {
                    bestIndividual = individual;
                    bestFitness = fitness;
                }
            }

            // Adicionar o melhor indivíduo como progenitor
            parents.Add(bestIndividual);
        }

        return parents;
    }
}
