namespace weatherApp.UI;

public sealed class MainForm : Form
{
    private readonly TextBox _cityTextBox;
    private readonly Button _searchButton;
    private readonly Label _statusLabel;
    private readonly Label _tempLabel;
    private readonly Label _conditionLabel;
    private readonly Label _humidityLabel;

    public MainForm()
    {
        Text = "Weather App";
        Width = 540;
        Height = 320;
        StartPosition = FormStartPosition.CenterScreen;

        _cityTextBox = new TextBox
        {
            Left = 20,
            Top = 20,
            Width = 260,
            PlaceholderText = "Enter city name"
        };

        _searchButton = new Button
        {
            Left = 300,
            Top = 18,
            Width = 120,
            Height = 30,
            Text = "Search"
        };
        _searchButton.Click += OnSearchClickAsync;

        _statusLabel = new Label
        {
            Left = 20,
            Top = 65,
            Width = 480,
            Text = "Ready"
        };

        _tempLabel = new Label { Left = 20, Top = 110, Width = 300, Text = "Temperature: -" };
        _conditionLabel = new Label { Left = 20, Top = 140, Width = 300, Text = "Condition: -" };
        _humidityLabel = new Label { Left = 20, Top = 170, Width = 300, Text = "Humidity: -" };

        Controls.AddRange(
            [
                _cityTextBox,
                _searchButton,
                _statusLabel,
                _tempLabel,
                _conditionLabel,
                _humidityLabel
            ]);
    }

    private async void OnSearchClickAsync(object? sender, EventArgs e)
    {
        var city = _cityTextBox.Text.Trim();
        if (string.IsNullOrWhiteSpace(city))
        {
            MessageBox.Show("Please enter a city name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _searchButton.Enabled = false;
        _statusLabel.Text = $"Loading weather for {city}...";

        try
        {
            // Placeholder while backend services are being implemented.
            await Task.Delay(300);
            _tempLabel.Text = "Temperature: -";
            _conditionLabel.Text = "Condition: -";
            _humidityLabel.Text = "Humidity: -";
            _statusLabel.Text = "Starter UI is wired. Next: connect backend service calls.";
        }
        finally
        {
            _searchButton.Enabled = true;
        }
    }
}
