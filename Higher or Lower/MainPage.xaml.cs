namespace Higher_or_Lower;

public partial class MainPage : ContentPage
{
    readonly Random rnd = new Random();
    int winningNumber;
    int lives = 5;

    public MainPage()
    {
        InitializeComponent();
        winningNumber = rnd.Next(1, 50);
    }
    private void Reset()
    {
        lives = 5;
        winningNumber = rnd.Next(1, 50);
        _guessStepper.Value = 25;
    }

    private async void Message(string higherOrLower, string complete)
    {
        await DisplayAlert("Guess", "Guess " + higherOrLower + " You have " + lives + " lives left", complete);
    }

    private async void CounterBtn_Clicked(object sender, EventArgs e)
    {
        if (lives >= 0)
        {
            if (winningNumber < _guessStepper.Value)
            {
                Message("lower", "Try Again");
                lives--;
            }
            else if (winningNumber > _guessStepper.Value)
            {
                Message("higher", "Try Again");
                lives--;
            }
            else
            {
                if (lives == 1)
                {
                    await DisplayAlert("Guess", "Congratulations! You had " + lives + " life left", "Play Again");
                    Reset();
                }
                else
                {
                    await DisplayAlert("Guess", "Congratulations! You had " + lives + " lives left", "Play Again");
                    Reset();
                }
            }
        }
        else
        {
            await DisplayAlert("Guess", "You are out of lives, the number was " + winningNumber, "Play Again");
            Reset();
        }

    }
}

