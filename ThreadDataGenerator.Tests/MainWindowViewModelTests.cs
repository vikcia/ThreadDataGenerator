//using System.Globalization;
//using System.Linq;
//using System.Threading;
//using ThreadDataGenerator.ValidationRules;
//using ThreadDataGenerator.ViewModel;
//using FluentAssertions;
//using Xunit;

//namespace ThreadDataGenerator.Tests;

//public class MainWindowViewModelTests
//{
//    [Theory]
//    [InlineData("1")] // Below minimum
//    [InlineData("16")] // Above maximum
//    [InlineData("abc")] // Invalid input
//    public void StartThreads_InvalidInput_ShouldNotStartThreads(string input)
//    {
//        // Arrange
//        var viewModel = new MainWindowViewModel();
//        viewModel.ThreadInput = input;

//        // Act
//        viewModel.StartThreads();

//        // Assert
//        viewModel.Threads.Should().BeEmpty();
//    }

//    [Theory]
//    [InlineData("2")] // Minimum
//    [InlineData("7")] // Middle value
//    [InlineData("15")] // Maximum
//    public void StartThreads_ValidInput_ShouldStartThreads(string input)
//    {
//        // Arrange
//        var viewModel = new MainWindowViewModel();
//        viewModel.ThreadInput = input;

//        // Act
//        viewModel.StartThreads();

//        // Assert
//        viewModel.Threads.Should().HaveCount(int.Parse(input));
//        foreach (var thread in viewModel.Threads)
//        {
//            thread.Should().NotBeNull();
//            thread.IsAlive.Should().BeTrue();
//        }
//    }
//}

//using FluentAssertions;
//using System.Threading.Tasks;
//using ThreadDataGenerator.ViewModel;
//using Xunit;

//namespace ThreadDataGenerator.Tests;

//public class MainWindowViewModelTests
//{
//    [Fact]
//    public void StartThreads_WithValidInput_ShouldStartThreads()
//    {
//        // Arrange
//        var viewModel = new MainWindowViewModel();
//        viewModel.ThreadInput = "5"; // Set a valid number of threads

//        // Act
//        viewModel.StartThreads();

//        // Assert
//        viewModel.Threads.Should().HaveCount(5); // Check if the correct number of threads are started
//        foreach (var thread in viewModel.Threads)
//        {
//            thread.Should().NotBeNull(); // Ensure each thread is not null
//            thread.IsAlive.Should().BeTrue(); // Ensure each thread is alive
//        }
//    }

//    [Fact]
//    public void StartThreads_WithInvalidInput_ShouldNotStartThreads()
//    {
//        // Arrange
//        var viewModel = new MainWindowViewModel();
//        viewModel.ThreadInput = "1"; // Set an invalid number of threads

//        // Act
//        viewModel.StartThreads();

//        // Assert
//        viewModel.Threads.Should().BeEmpty(); // Ensure no threads are started
//    }

//    // Add more test cases as needed to cover different scenarios
//}
