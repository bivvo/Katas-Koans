using NUnit.Framework;
using Shouldly;

namespace StringCalculator.Test
{
    [TestFixture]
    public class StringCalcTest
    {
        private Calculator _calculator = new Calculator();


        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [TestCase]
        public void Given_an_empty_string_Result_should_be_zero()
        {
            _calculator.Add(string.Empty).ShouldBe(0);
        }

        [TestCase]
        public void Give_a_single_value_Result_to_equal_given_value()
        {
            _calculator.Add("1").ShouldBe(1);
        }

        [TestCase("1,2", 3)]
        [TestCase("2,3", 5)]
        [TestCase("10,10", 20)]
        [TestCase("100,100,100", 300)]
        public void Given_delimited_string_of_two_values_Then_return_value_should_be_the_sum(string input, int expected)
        {         
            _calculator.Add(input).ShouldBe(expected);
        }

        [TestCase("1\n2", 3)]
        [TestCase("1\n2,3", 6)]
        public void Given_string_delimeted_with_newlines_value_should_equal_the_sum_of_all_integers(string input, int expected)
        {
            _calculator.Add(input).ShouldBe(expected);
        }

        [TestCase("1\n,")]
        [TestCase("1,3,4,\n5")]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Given_Double_Delimited_string_Then_calculator_should_return_argumentexception(string input)
        {
            _calculator.Add(input);
        }

        [TestCase("//;1;2;3", 6)]
        [TestCase("//;1;2;3,6", 12)]
        [TestCase("//;1;2;3,6\n6", 18)]
        public void Given_a_change_of_delimiter_calculator_Should_handle_new_delimeter_and_return_sum(string input, int expected)
        {
            _calculator.Add(input).ShouldBe(expected);
        }

        [TestCase]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Given_negative_values_calculator_should_throw_argument_exception()
        {
            _calculator.Add("-1,2,3");
        }

    }
}
