// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyDilemmaTests.cs" company="Det Prikkede Kompagni A/S">
//   
// </copyright>
// <summary>
//   The my dilemma tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DilemmaProgram
{
    using Dilemma;

    using Xunit;

    /// <summary>
    /// The my dilemma tests.
    /// </summary>
    public class MyDilemmaTests
    {
        /// <summary>
        /// The opponent all defect.
        /// </summary>
        [Fact]
        public void OpponentAllDefect()
        {
            var dilemma = new MyDilemma();

            for (int i = 0; i < 50; i++)
            {
                var myChoice = dilemma.Execute(Choice.Defect);
            }
        }

        /// <summary>
        /// The opponent all cooperate.
        /// </summary>
        [Fact]
        public void OpponentAllCooperate()
        {
            var dilemma = new MyDilemma();

            for (int i = 0; i < 50; i++)
            {
                var myChoice = dilemma.Execute(Choice.Cooperate);
            }
        }
    }
}