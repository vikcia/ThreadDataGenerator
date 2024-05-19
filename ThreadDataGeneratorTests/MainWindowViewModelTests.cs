using FluentAssertions;
using ThreadDataGenerator;
using ThreadDataGenerator.ViewModel;

namespace ThreadDataGeneratorTests;

public class MainWindowViewModelTests
{
    private readonly MainWindowViewModel _viewModel;

    public MainWindowViewModelTests()
    {
        _viewModel = new MainWindowViewModel(new FakeDispatcherWrapper());
    }

    [Fact]
    public void StartThreads_WithValidInput_ShouldStartThreads()
    {
        // Arrange
        Random random = new Random();
        string input = random.Next(2, 16).ToString();
        int inputToInt = int.Parse(input);

        _viewModel.ThreadInput = input;

        // Act
        _viewModel.StartThreads();

        // Assert
        _viewModel.threads.Should().HaveCount(inputToInt);
        foreach (var thread in _viewModel.threads)
        {
            thread.Should().NotBeNull();
            thread.IsAlive.Should().BeTrue();
        }
    }

    [Theory]
    [InlineData("1")]
    [InlineData("16")]
    [InlineData(".")]
    [InlineData("/")]
    [InlineData("z")]
    [InlineData("abc")]
    public void StartThreads_WithInvalidInput_ShouldNotStartThreads(string input)
    {
        // Arrange
        _viewModel.ThreadInput = input;

        // Act
        _viewModel.StartThreads();

        // Assert
        _viewModel.threads.Should().BeEmpty();
    }

    [Fact]
    public void RandomStringGenerator_ShouldGenerateStringWithCorrectLength()
    {
        // Arrange
        const int length = 8;

        // Act
        var randomString = _viewModel.RandomStringGenerator(length);

        // Assert
        randomString.Should().NotBeNull();
        randomString.Length.Should().Be(length);
    }
}