using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Chromosomes;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System;

namespace GeneticSharp.Runner.UnityApp.Car
{
    public class CarFitness : IFitness
    {
        public CarFitness()
        {
            ChromosomesToBeginEvaluation = new BlockingCollection<CarChromosome>();
            ChromosomesToEndEvaluation = new BlockingCollection<CarChromosome>();
        }

        public BlockingCollection<CarChromosome> ChromosomesToBeginEvaluation { get; private set; }
        public BlockingCollection<CarChromosome> ChromosomesToEndEvaluation { get; private set; }

        public double Evaluate(IChromosome chromosome)
        {
            var c = chromosome as CarChromosome;
            ChromosomesToBeginEvaluation.Add(c);

            float fitness = 0;

            do
            {
                Thread.Sleep(1000);

                float distance = c.Distance;
                float elapsedTime = c.EllapsedTime;
                float numberOfWheels = c.NumberOfWheels;
                float carMass = c.CarMass;
                bool roadCompleted = c.RoadCompleted;

                List<float> velocities = c.Velocities;
                float sumVelocities = c.SumVelocities;

                List<float> accelerations = c.Accelerations;
                float sumAccelerations = c.SumAccelerations;

                List<float> forces = c.Forces;
                float sumForces = c.SumForces;
                


                
                
                
                //fitness = distance/ (elapsedTime + 1); //2:2 gap 
                


       

                

                //fitness=6×distance+2×sumVelocities+numberOfWheels
                
                  // Calculate medium velocity gap 1:1
                float mediumVelocity = 0;
                if (velocities != null && velocities.Count != 0)
                {
                    mediumVelocity = sumVelocities / velocities.Count;
                }

                // Adjust fitness calculation
                 fitness = mediumVelocity * 7 + distance / 5 + (roadCompleted ? 200 : 0);

                c.Fitness = fitness;

              
              /*float mediumVelocity = 0;
             if (velocities != null && velocities.Count != 0)
             {
              mediumVelocity = sumVelocities / velocities.Count;
             }

             // Adjust fitness calculation
            float fitness = (distance * 100 / (elapsedTime + 1)) + (mediumVelocity * 10) + (roadCompleted ? 500 : 0);

            c.Fitness = fitness;*/





            

             /* if (roadCompleted)
               {
                 fitness = 1000 / elapsedTime + distance * 0.01f;
               }
               else
               {
                 fitness = distance * 0.01f;
               }*/

            } while (!c.Evaluated);

            ChromosomesToEndEvaluation.Add(c);

            do
            {
                Thread.Sleep(1000);
            } while (!c.Evaluated);

            return fitness;
        }
    }
}
