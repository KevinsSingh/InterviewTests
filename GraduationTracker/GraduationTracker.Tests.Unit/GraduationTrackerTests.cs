using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasCredits()
        {
            var tracker = new GraduationTracker();
            Tuple<bool, STANDING> result;

            //I'm going to assume that we know the students in the Repository and which ones
            //have the criteria to graduate before hand. Otherwise we will have no way of validating
            //the results of the tested function.

            //Student ID 1 - Has an average of 95 - Will Graduate MagnaCumLaude      
            result = tracker.HasGraduated(Repository.GetDiploma(1), Repository.GetStudent(1));
            Assert.IsTrue(result.Item1);
            Assert.AreEqual(result.Item2, STANDING.MagnaCumLaude);

            //Student ID 2 - Has an average of 80 - Will Graduate *
            //According to the code it will be MagnaCumLaude but seems like SumaCumLaude isn't used.
            result = tracker.HasGraduated(Repository.GetDiploma(1), Repository.GetStudent(2));
            Assert.IsTrue(result.Item1);
            Assert.AreEqual(result.Item2, STANDING.MagnaCumLaude);

            //Student ID 3 - Has an average of 50 - Will Not Graduate
            result = tracker.HasGraduated(Repository.GetDiploma(1), Repository.GetStudent(3));
            Assert.IsFalse(result.Item1);
            Assert.AreEqual(result.Item2, STANDING.Average);

            //Student ID 4 - Has an average of 40 - Will Not Graduate
            result = tracker.HasGraduated(Repository.GetDiploma(1), Repository.GetStudent(4));
            Assert.IsFalse(result.Item1);
            Assert.AreEqual(result.Item2, STANDING.Remedial);
        }

    }
}
