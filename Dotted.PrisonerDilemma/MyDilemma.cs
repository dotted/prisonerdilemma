// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyDilemma.cs" company="Det Prikkede Kompagni A/S">
//   
// </copyright>
// <summary>
//   Prisoner's dilemma
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DilemmaProgram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Dilemma;

    /// <summary>
    /// The dilemma program.
    /// </summary>
    public class MyDilemma : IExecutable
    {
        /// <summary>
        /// The random.
        /// </summary>
        // private readonly Random random = new Random();

        /// <summary>
        /// The previous choices made by opponent.
        /// </summary>
        private readonly IList<Choice?> opponentPreviousChoices;

        /// <summary>
        /// The previous choices made by me.
        /// </summary>
        private readonly IList<Choice> myPreviousChoices;

        /// <summary>
        /// The my previous choice.
        /// </summary>
        private Choice myPreviousChoice;

        /// <summary>
        /// The opponent previous choice.
        /// </summary>
        private Choice? opponentPreviousChoice;

        /// <summary>
        /// The randomness counter.
        /// </summary>
        private int randomnessCounter;

        /// <summary>
        /// The anti deadlock.
        /// </summary>
        private int antiDeadlock;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyDilemma"/> class.
        /// </summary>
        public MyDilemma()
        {
            this.opponentPreviousChoices = new List<Choice?>(50);
            this.myPreviousChoices = new List<Choice>(50);
        }

/*
        /// <summary>
        /// Gets the current iteration.
        /// </summary>
        private int Iteration
        {
            get
            {
                return this.opponentPreviousChoices.Count;
            }
        }
*/

/*
        /// <summary>
        /// The score.
        /// </summary>
        /// <param name="me">The me.</param>
        /// <param name="you">The you.</param>
        /// <returns>The <see cref="int"/>.</returns>
        private int Score(Choice me, Choice you)
        {
            if (me == Choice.Defect && you == Choice.Cooperate)
            {
                return 5;
            }

            if (me == Choice.Cooperate && you == Choice.Cooperate)
            {
                return 3;
            }

            if (me == Choice.Defect && you == Choice.Defect)
            {
                return 1;
            }

            return 0;
        }
*/

        /// <summary>
        /// The incoming.
        /// </summary>
        /// <param name="choice">The choice.</param>
        /// <returns>The <see cref="Choice"/>.</returns>
        private void Incoming(Choice? choice)
        {
            this.opponentPreviousChoices.Add(choice);
        }

        /// <summary>
        /// The return.
        /// </summary>
        /// <param name="choice">The choice.</param>
        /// <param name="opponentChoice"></param>
        /// <returns>The <see cref="Choice"/>.</returns>
        private Choice Return(Choice choice, Choice? opponentChoice)
        {
            this.opponentPreviousChoice = opponentChoice;
            this.myPreviousChoices.Add(choice);
            this.myPreviousChoice = choice;
            return choice;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="opponentsLastChoice">The opponents last choice.</param>
        /// <returns>The <see cref="Choice"/>.</returns>
        public Choice Execute(Choice? opponentsLastChoice)
        {
            this.Incoming(opponentsLastChoice);

            /*var bored = this.random.NextDouble();
            if (bored > 0.2)
            {
                return this.Return(Choice.Cooperate);
            }
            return this.Return(Choice.Defect);*/

            /*if (opponentsLastChoice != null)
            {
                if (this.Score(this.myPreviousChoice, (Choice)opponentsLastChoice) >= 3)
                {
                    return this.Return(this.myPreviousChoice);
                }

                if (this.myPreviousChoice == Choice.Cooperate)
                {
                    return this.Return(Choice.Defect);
                }

                return this.Return(Choice.Cooperate);
            }

            return this.Return(Choice.Cooperate);*/

            /*if (this.Iteration % 3 == 0)
            {
                return this.Return(Choice.Defect);
            }
            return this.Return(Choice.Cooperate);*/


            if (opponentsLastChoice != null)
            {
                if (opponentsLastChoice != this.opponentPreviousChoice || opponentsLastChoice != this.myPreviousChoice)
                {
                    this.randomnessCounter++;
                }
                else if (opponentsLastChoice == this.myPreviousChoice)
                {
                    this.randomnessCounter--;
                }

                if (opponentsLastChoice != this.myPreviousChoice)
                {
                    this.antiDeadlock++;
                }

                if (this.randomnessCounter >= 8)
                {
                    // Don't allow decrments to take us out of all out defect
                    this.randomnessCounter = 9;
                    return this.Return(Choice.Defect, opponentsLastChoice);
                }
                
                if (this.antiDeadlock == 3)
                {
                    this.antiDeadlock = 0;
                    return this.Return(Choice.Cooperate, opponentsLastChoice);
                }

                return (Choice)opponentsLastChoice;
            }

            return this.Return(Choice.Cooperate, opponentsLastChoice);

            /*switch (this.Iteration)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:

            }*/



            /*
            const int x = 2;
            const double ProbabilityOfCoorporate = (x - 1.0) / (3.0 * x + 2.0);


            if (opponentsLastChoice.Equals(Choice.Cooperate) && this.myPreviousChoice.Equals(Choice.Cooperate))
            {
                return this.Return(Choice.Cooperate);
            }
            
            if (opponentsLastChoice.Equals(Choice.Defect))
            {
                if (this.myPreviousChoice.Equals(Choice.Defect))
                {
                    if (this.random.NextDouble() > 2 * ProbabilityOfCoorporate)
                    {
                        return this.Return(Choice.Defect);
                    }
                    return this.Return(Choice.Cooperate);
                    
                }
                if (this.random.NextDouble() > ProbabilityOfCoorporate)
                {
                    return this.Return(Choice.Defect);
                }
                return this.Return(Choice.Cooperate);
            }

            if (this.myPreviousChoice.Equals(Choice.Defect))
            {
                return this.Return(Choice.Cooperate);
            }

            // For first run
            return this.Return(Choice.Cooperate);
            */

            /*
            if (this.Iteration == 1 && opponentsLastChoice == null)
            {
                return Choice.Defect;
            }
            
            // There is no risk of revenge from opponent, assume defect on last round and by extention the second last round
            else if (this.Iteration > 47)
            {
                return Choice.Defect;
            }
            else
            {
                return (Choice)opponentsLastChoice;
            }
            */
        }
    }
}