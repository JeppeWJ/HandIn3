using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microwave.Classes;
using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace Microwave.Test.Unit
{
    [TestFixture]
    class BuzzerTest
    {
        private IBuzzer _uut;
        private IOutput _output;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _uut = new Buzzer(_output);

        }


        [TestCase("Bip Bip Bip!")]
        public void WriteToOutputFromBuzzerTest(string text)
        {
            _uut.BuzzerOn(text);
            _output.Received(1).OutputLine(text);
        }
    }
}
