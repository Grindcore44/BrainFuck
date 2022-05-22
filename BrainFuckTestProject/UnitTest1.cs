using System.IO;
using System.Text;
using Xunit;
// AAA RULE

// arrange  ���������� ������ ��� ������-�� ���� 
// act ���������� ����
// assert ��������� ��������� ��������� ����

//[Theory] ��������� ��������� ��� ���������� ����
//[InLineData("��������", "��������")] ��������� �������� ������ ��������� (���������� ����� ���� �������� ���������)
////[InLineData("��������2", "��������2")] � ��� ����������� ������ ���������� �� �������������



namespace BrainFuckTestProject
{
    public class DataOperationTest
    {

        //[Fact] ������� �����������, ��� ������ ���������� ��� ������

        [Theory]
        [InlineData(0)]
        [InlineData(69)]
        [InlineData(121)]
        public void NextCellTest(int newCurrent)
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);

            var expectedCurrent1 = newCurrent + 1;
            repository.Current = newCurrent;

            // act
            dataOperations.NextCell();
            var actual1 = repository.Current;


            // assert

            Assert.Equal(expectedCurrent1, actual1);

        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(13121)]

        public void PreviusCellTest(int newCurrent)
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);

            var expectedCurrent1 = newCurrent - 1;
            repository.Current = newCurrent;

            // act
            dataOperations.PreviusCell();
            var actual1 = repository.Current;
            // assert

            Assert.Equal(expectedCurrent1, actual1);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]

        public void NextCharValueTest(int newCurrent)
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);

            var expectedCurrent1 = (char)newCurrent+1;
            repository.Memory[repository.Current] = (char)newCurrent;

            // act
            dataOperations.NextCharValue();
            var actual1 = repository.Memory[repository.Current];

            // assert
            Assert.Equal(expectedCurrent1, actual1); // 1; 2
         
        }

        [Theory]
        [InlineData(33)]
        [InlineData(23)]
        [InlineData(44)]

        public void PreviousCharValueTest(int newCurrent)
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);

            var expectedCurrent1 = (char)newCurrent - 1;
            repository.Memory[repository.Current] = (char)newCurrent;

            // act

            dataOperations.PreviousCharValue();
            var actual1 = repository.Memory[repository.Current];

            // assert
            Assert.Equal(expectedCurrent1, actual1); 
        }


        [Theory]
        [InlineData("[]", 1)]
        [InlineData("[++++[++++++[][][][][][][][][][][]][+++++++][][][][]][][][][][][][][]++]+++++]", 52)]
        [InlineData("[++++[++++++++]++++++++[++++[[[+++++++++++[+++++++]]]--------------]]++++]", 73)]
        public void IfZeroNextTest(string newCurrentProgram, int expectedCurrent)
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);
            repository.Memory[repository.Current] = (char)0;
            repository.Program = newCurrentProgram;
            var expectedCurrent1 = expectedCurrent;
            var PositionNumber = 0;
            // act
            
            var actual1 = dataOperations.IfZeroNext(PositionNumber, repository.Program);
            // assert
            Assert.Equal(expectedCurrent1, actual1);

        }

        [Fact]
        public void IfNoZeroBackTest()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);
            repository.Memory[repository.Current] = (char)1;
            repository.Program = "[++++[++++++++]+++++++]";
            var expectedCurrent1 = 0;
            var PositionNumber = 22;

            // act
            
            var actual1 = dataOperations.IfNoZeroBack(PositionNumber, repository.Program);

            // assert
            Assert.Equal(expectedCurrent1, actual1);
        }

        [Fact]

        public void DisplayCellValueTest()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository,inputOutput);

            repository.Memory[0] = '{';
            var expectedCurrent = "{";
            // act
            dataOperations.DisplayCellValue();
            var actual = testTextWriter.OutputHeh;

            // assert
            Assert.Equal(expectedCurrent, actual);

        }

        [Fact]

        public void InputValueInCellTest() 
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader("}");
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var dataOperations = new DataOperations(repository, inputOutput);
            var expectedCurrent = '}';

            // act

            dataOperations.InputValueInCell();
            var actual = repository.Memory[0];
            // assert

            Assert.Equal(expectedCurrent, actual);

        }

        [Fact]

        public void enum�odeBrainFuckTest1()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = "+";
            string nameExpected = nameof(testDataOperations.NextCharValue);


            // act
            testDataOperations.Enum�odeBrainFuck(brainFuckCode); 
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }

        [Fact]
        public void enum�odeBrainFuckTest2()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = "-";
            string nameExpected = nameof(testDataOperations.PreviousCharValue);


            // act
            testDataOperations.Enum�odeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }
        [Fact]
        public void enum�odeBrainFuckTest3()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = ".";
            string nameExpected = nameof(testDataOperations.DisplayCellValue);


            // act
            testDataOperations.Enum�odeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }

        [Fact]
        public void enum�odeBrainFuckTest4()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = ">";
            string nameExpected = nameof(testDataOperations.NextCell);


            // act
            testDataOperations.Enum�odeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }

        [Fact]
        public void enum�odeBrainFuckTest5()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = "<";
            string nameExpected = nameof(testDataOperations.PreviusCell);


            // act
            testDataOperations.Enum�odeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }

        [Fact]
        public void enum�odeBrainFuckTest6()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = ",";
            string nameExpected = nameof(testDataOperations.InputValueInCell);


            // act
            testDataOperations.Enum�odeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }

        [Fact]
        public void enum�odeBrainFuckTest7()
         {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = "[";
            string nameExpected = nameof(testDataOperations.IfZeroNext);


            // act
            testDataOperations.Enum�odeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }

        [Fact]
        public void enum�odeBrainFuckTest8()
        {
            // arrange
            var repository = new Repository();
            var testTextWriter = new TestTextWriter();
            var testTextReader = new TestTextReader();
            var inputOutput = new InputOutput(testTextReader, testTextWriter);
            var testDataOperations = new TestDataOperations(repository, inputOutput);
            var brainFuckCode = "]";
            string nameExpected = nameof(testDataOperations.IfNoZeroBack);


            // act
            testDataOperations.Enum�odeBrainFuck(brainFuckCode);
            var actual = testDataOperations.Result;
            var actualName = testDataOperations.Name;


            // assert
            Assert.True(actual);
            Assert.Equal(nameExpected, actualName);
        }
        // string a = nameof(Enum�odeBrainFuck); ���������� ������������ ������� � ����������,
        // ��� ��������� � ����������, ��� ���� ��������� ���������������� � ���, ������ ������ "Enum�odeBrainFuck"
        public class TestDataOperations : DataOperations
        {
            private bool _result;
            private string _name;
            
            public bool Result => _result;
            public string Name => _name;
            public TestDataOperations(Repository dataFromRepository,
        InputOutput inputOutput)
                :base(dataFromRepository, inputOutput)
            {
                _result = false;
            }
            public override void NextCharValue()
            {
                _result = true;
                _name = nameof(NextCharValue);
            }
            public override void PreviousCharValue()
            {
                _result = true;
                _name = nameof(PreviousCharValue);
            }
            public override void DisplayCellValue()
            {
                _result = true;
                _name = nameof(DisplayCellValue);
            }
            public override void NextCell()
            {
                _result = true;
                _name = nameof(NextCell);
            }
            public override void PreviusCell()
            {
                _result = true;
                _name = nameof(PreviusCell);
            }
            public override void InputValueInCell()
            {
                _result = true;
                _name = nameof(InputValueInCell);
            }
            public override int IfZeroNext(int PositionNumber, string BrainFuckCode) 
            {
                _result = true;
                _name = nameof(IfZeroNext);
                return 1;
            }
            public override int IfNoZeroBack(int PositionNumber, string BrainFuckCode)
            {
                _result = true;
                _name = nameof(IfNoZeroBack);
                return 1;
            }


        }

        public class TestTextReader : TextReader
        {
            private string _input;

            public string InputHeh => _input;

            public TestTextReader(string input)
            {
                _input = input;
            }
            public TestTextReader()
            { 
               
            }
            public override string ReadLine()
            {
                return _input;
            }
        }

        public class TestTextWriter : TextWriter
        {
            private string _output;

            public string OutputHeh => _output; 
            
            public TestTextWriter(string output)
            {
                _output = output;

            }
            public TestTextWriter() // �����������, ������� ��������� ������� ��������� ������ ��� ���������
            {

            }
            public override Encoding Encoding => Encoding.UTF8; //��������� �������� ������ ��� ��������

            public override void Write(string output)
            {
                _output = output;
            }
        }

    }
    
}
       // ���� �� ���� � ���� �� ENUM (�� ���� 6 ������)