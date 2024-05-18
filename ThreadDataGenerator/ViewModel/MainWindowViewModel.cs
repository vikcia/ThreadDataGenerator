using System.Collections.ObjectModel;
using ThreadDataGenerator.Models;
using ThreadDataGenerator.MVVM;
using ThreadDataGenerator.Services;

namespace ThreadDataGenerator.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
    private ObservableCollection<ListViewModel> listOfThreads = new ();
    public ObservableCollection<ListViewModel> ListOfThreads
    {
        get { return listOfThreads; }
        set
        {
            listOfThreads = value;
            OnPropertyChanged();
        }
    }

    private string threadInput = "";
    public string ThreadInput
    {
        get { return threadInput; }
        set
        {
            threadInput = value;
            OnPropertyChanged();
        }
    }

    private string buttonContent = "Start";
    public string ButtonContent
    {
        get { return buttonContent; }
        set
        {
            buttonContent = value;
            OnPropertyChanged();
        }
    }

    private string buttonVisibility = "Visible";
    public string ButtonVisibility
    {
        get { return buttonVisibility; }
        set
        {
            buttonVisibility = value;
            OnPropertyChanged();
        }
    }

    private bool running = false;
    private bool shouldStop = false;
    public bool ShouldStop { get; set; }

    private readonly DatabaseService databaseService;
    private readonly List<Thread> threads;
    public List<Thread> Threads { get; private set; } = new();

    public MainWindowViewModel()
    {
        threads = new ();
        databaseService = new ();
    }

    public async Task Start()
    {
        if (running)
        {
            await StopThreadsAndSaveToDB();
        }
        else
        {
            StartThreads();
        }
        running = !running;
    }

    public async Task StopThreadsAndSaveToDB()
    {
        shouldStop = true;
        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        foreach (ListViewModel item in ListOfThreads)
        {
            await databaseService.SaveToDatabaseAsync(item.ThreadId, item.RandomGeneratedString);
        }

        ListOfThreads.Clear();
        ButtonContent = "Start";
        ButtonVisibility = "Visible";
    }

    public void StartThreads()
    {
        int numberOfThreads;

        if (int.TryParse(ThreadInput, out numberOfThreads) && numberOfThreads >= 2 && numberOfThreads <= 15)
        {
            shouldStop = false;

            for (int i = 0; i < numberOfThreads; i++)
            {
                int threadId = i + 1;
                Thread thread = new Thread(() => GenerateThreadData(threadId));
                threads.Add(thread);
                thread.Start();
            }

            ButtonContent = "Stop";
            ButtonVisibility = "Collapsed";
        }
    }

    public void GenerateThreadData(int threadId)
    {
        Random random = new ();

        while (!shouldStop)
        {
            string randomString = RandomStringGenerator(random.Next(5, 11));

            App.Current.Dispatcher.Invoke(() =>
            {
                ListOfThreads.Add(new ListViewModel { ThreadId = threadId, RandomGeneratedString = randomString });

                if (ListOfThreads.Count > 20)
                    ListOfThreads.RemoveAt(0);
            });

            Thread.Sleep(random.Next(500, 2001));
        }
    }

    public string RandomStringGenerator(int length)
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        char[] stringChars = new char[length];
        Random random = new ();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }
        return new string(stringChars);
    }
}