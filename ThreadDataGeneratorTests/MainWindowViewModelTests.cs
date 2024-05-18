using FluentAssertions;
using System.Threading.Tasks;
using ThreadDataGenerator.ViewModel;
using Xunit;

namespace ThreadDataGeneratorTests;

public class MainWindowViewModelTests
{
    //[Fact]
    //public void StartThreads_WithValidInput_ShouldStartThreads()
    //{
    //    // Arrange
    //    var viewModel = new MainWindowViewModel();
    //    viewModel.ThreadInput = "5"; // Set a valid number of threads

    //    // Act
    //    viewModel.StartThreads();

    //    // Assert
    //    viewModel.Threads.Should().HaveCount(5); // Check if the correct number of threads are started
    //    foreach (var thread in viewModel.Threads)
    //    {
    //        thread.Should().NotBeNull(); // Ensure each thread is not null
    //        thread.IsAlive.Should().BeTrue(); // Ensure each thread is alive
    //    }
    //}

    [Fact]
    public void StartThreads_WithInvalidInput_ShouldNotStartThreads()
    {
        // Arrange
        var viewModel = new MainWindowViewModel();
        viewModel.ThreadInput = "1"; // Set an invalid number of threads

        // Act
        viewModel.StartThreads();

        // Assert
        viewModel.Threads.Should().BeEmpty(); // Ensure no threads are started
    }

    // Add more test cases as needed to cover different scenarios
}
