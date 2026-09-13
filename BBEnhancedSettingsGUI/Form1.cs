using SoulsFormats;
using System.Diagnostics;
using System.Reflection;
using System.Runtime;
using System.Text.Json;
using System.Text.Json.Serialization;
using static SoulsFormats.EMEVD.Instruction;
using Button = System.Windows.Forms.Button;

namespace BBEnhancedSettingsGUI
{

    public partial class Form1 : Form
    {
        List<Setting> settings = [];
        private readonly System.Windows.Forms.Timer timer = new();
        static string emevdPath = GetRelativeFilePath(@"GAME FILES\dvdroot_ps4\event\common.emevd.dcx");
        private readonly int settingsEventId = 10008400;
        EMEVD? emevd;
        int selectedIndex;
        string settingsPath;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!emevdPathTextBox.Focused && !settingsFilterInput.Focused)
            {
                int limit = settingsListPanel.Controls.Count - 1;
                Panel panel;
                switch (keyData)
                {
                    case Keys.Down:
                        selectedIndex = Math.Min(selectedIndex + 1, limit);
                        panel = (Panel)settingsListPanel.Controls[selectedIndex];
                        UpdateSelection(panel);
                        settingsListPanel.ScrollControlIntoView(panel);
                        return true;
                    case Keys.Up:
                        selectedIndex = Math.Max(selectedIndex - 1, 0);
                        panel = (Panel)settingsListPanel.Controls[selectedIndex];
                        UpdateSelection(panel);
                        settingsListPanel.ScrollControlIntoView(panel);
                        return true;
                    case Keys.Space:
                    case Keys.Enter:
                        HandleSettingsButtonClick(selectedIndex);
                        return true;
                }
            }
            switch (keyData)
            {
                case Keys.Control | Keys.F:
                    settingsFilterInput.Focus();
                    break;
                case Keys.Control | Keys.S:
                    saveButton.PerformClick();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public Form1()
        {
            InitializeComponent();
            UpdateSettingsPath();
            string overridePath = GetRelativeFilePath("path.txt");
            Console.WriteLine(overridePath);
            if (File.Exists(overridePath))
            {
                string contents = File.ReadAllText(overridePath).Trim();
                if (File.Exists(contents))
                {
                    emevdPath = contents;
                }
            }
            emevdPathTextBox.Text = emevdPath;
            try
            {
                Console.WriteLine(emevdPath);
                emevd = EMEVD.Read(emevdPath);
            }
            catch (Exception)
            {
                Console.WriteLine("NON-EXISTENT");
            }
            LoadSettings();
            settingDescriptionLabel.MaximumSize = new Size(settingDescriptionPanel.Width, 0);
            timer.Interval = 3000;
            timer.Tick += TimerTick;
        }

        void UpdateSettingsPath()
        { 
            string overrideName = "path_override.txt";
            string pathOverride = "";
            if (File.Exists(overrideName))
            {
                string path = File.ReadAllText(overrideName).Trim();
                if (Directory.Exists(path)) {
                    pathOverride = path;
                }
                settingsPath = Path.Combine(pathOverride, "_data", "settings.json");
            }
            else
            {
                settingsPath = GetRelativeFilePath(Path.Combine("_data", "settings.json"));
            }
            Console.WriteLine(settingsPath);
        }

        void LoadSettings()
        {
            settingsListPanel.AutoScroll = true;

            // read settings info from json file to Settings objects
            string settingsString = File.ReadAllText(settingsPath);
            settings = [.. JsonSerializer.Deserialize<List<Setting>>(settingsString)!.Where(s => s.Hidden != true)];

            // find current settings values in common.emevd.dcx by finding any of the values of PossibleValues for each entry
            List<List<List<int>>>? currentSettings = ScanEventsFile(emevd);

            if (currentSettings == null)
            {
                emevdPathTextBox.BackColor = Color.IndianRed;
                MessageBox.Show("Could not find required mod events in selected \"common.emevd.dcx\" file. Settings can still be changed, but mod files will be unnaffected until the patcher is ran.");
            }
            else
            {
                string overridePath = GetRelativeFilePath("path.txt");
                File.WriteAllText(overridePath, emevdPath);
                emevdPathTextBox.BackColor = this.BackColor;
                // update Settings objects with current values from emevd
                UpdateSettings(currentSettings, settings);
            }
            settingsListPanel.Controls.Clear();
            for (int settingIndex = 0; settingIndex < settings.Count; settingIndex++)
            {
                Setting setting = settings[settingIndex];
                Panel panel = BuildSettingButtonPanel(settingIndex, setting);

                if (settingIndex == 0)
                {
                    HandleSettingsPanelClick(panel, null);
                }
            }
            saveButton.Enabled = true;
        }

        Panel BuildSettingButtonPanel(int settingIndex, Setting setting)
        {
            Panel panel = new();
            setting.Panel = panel;
            var button = new Button();
            Label label = new();
            settingsListPanel.Controls.Add(panel);
            panel.Controls.Add(button);
            panel.Controls.Add(label);
            panel.Height = 30;
            panel.Width = settingsListPanel.Width - SystemInformation.VerticalScrollBarWidth;
            panel.Padding = new Padding(all: 5);
            panel.Margin = new Padding(all: 0);
            panel.Name = $"SettingPanel_{settingIndex}";

            button.Name = $"SettingButton_{settingIndex}";
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Paint += (s, e) =>
            {
                var b = (Button)s!;
                using var pen = new Pen(Color.Black, 2);
                e.Graphics.DrawRectangle(pen, 1, 1, b.Width - 2, b.Height - 2);
            };
            button.Left = 2;
            button.AutoSize = false;
            button.Size = new Size(130, panel.Height - 6);
            button.Top = 3;
            button.TextAlign = ContentAlignment.MiddleCenter;
            UpdateButton(button, setting.Value);

            label.BackColor = Color.Transparent;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Left = button.Width + 10;
            label.Width = settingsListPanel.Width;
            label.Height = panel.Height;
            label.Text = setting.Name;

            panel.Click += new EventHandler((sender, e) => { HandleSettingsPanelClick(panel, null); });
            label.Click += new EventHandler((sender, e) => { HandleSettingsPanelClick(panel, null); });
            button.Click += new EventHandler((sender, e) =>
            {
                HandleSettingsPanelClick(panel, null);
                HandleSettingsButtonClick(selectedIndex);
            });
            return panel;
        }

        static void UpdateSettings(List<List<List<int>>> currentSettings, List<Setting> settings)
        {
            foreach (List<List<int>> currentSetting in currentSettings)
            {
                int flag = currentSetting[0].First();
                Setting setting = settings.FirstOrDefault(s => s.PossibleValues.ContainsValue(flag))!;
                if (setting == null)
                {
                    continue;
                }
                if (setting.ActivateOnly == true)
                {
                    setting.Value = currentSetting[0][1] == 0 ? "Disabled" : "Enabled";
                }
                else if (setting.PossibleValues.Count > 2 || setting.ForceRotate == true)
                {
                    if (currentSetting[0][1] == 1)
                    {
                        setting.Value = setting.PossibleValues.Keys.FirstOrDefault(k => setting.PossibleValues[k] == currentSetting[0][0])!;
                    }
                }
                else
                {
                    setting.Value = setting.PossibleValues.Keys.FirstOrDefault(k => setting.PossibleValues[k] == flag)!;
                }
            }
        }

        void HandleSettingsPanelClick(object sender, EventArgs? e)
        {
            selectedIndex = settingsListPanel.Controls.IndexOf((Panel)sender);
            string panelName = $"SettingPanel_{selectedIndex}";
            string buttonName = $"SettingButton_{selectedIndex}";
            Panel panel = (Panel)settingsListPanel.Controls[panelName]!;
            Button button = (Button)panel.Controls[buttonName]!;
            button?.Focus();
            Point scrollPosition = settingsListPanel.AutoScrollPosition;
            UpdateSelection((Panel)sender);
            settingsListPanel.AutoScrollPosition = new Point(Math.Abs(scrollPosition.X), Math.Abs(scrollPosition.Y));
        }

        void UpdateSelection(Panel selectedPanel)
        {
            foreach (Panel panel in settingsListPanel.Controls)
            {
                panel.BackColor = Color.Transparent;
            }
            selectedPanel.BackColor = SystemColors.MenuHighlight;
            Setting setting = settings[selectedIndex];
            settingTitleLabel.Text = setting.Name;
            settingDescriptionLabel.Text = setting.Description;
            ResizeLabel();
        }

        void HandleSettingsButtonClick(int index)
        {
            Setting setting = settings[index];
            List<string> keys = [.. setting.PossibleValues.Keys.Order()];
            int settingIndex = keys.IndexOf(setting.Value) + 1;
            if (settingIndex >= keys.Count)
            {
                settingIndex = 0;
            }
            setting.Value = keys[settingIndex];
            Button button = (Button)settingsListPanel.Controls[index].Controls.Find($"SettingButton_{index}", true).First();
            UpdateButton(button, setting.Value);
        }

        static void UpdateButton(Button button, string text)
        {
            button.Text = text;
            switch (text)
            {
                case "Enabled":
                    button.ForeColor = Color.Black;
                    button.BackColor = Color.LimeGreen;
                    break;
                case "Disabled":
                    button.ForeColor = Color.Snow;
                    button.BackColor = Color.Black;
                    break;
                default:
                    button.ForeColor = Color.Black;
                    button.BackColor = Color.White;
                    break;
            }
        }

        void TimerTick(object? sender, EventArgs e)
        {
            savedStatusLabel.Text = "";
            ((System.Windows.Forms.Timer)sender!).Stop();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            UpdateEventFile();
            UpdateSettingsJson();
            savedStatusLabel.Text = "Saved!";
            timer.Start();
        }

        static string GetRelativeFilePath(string pathPart)
        {
            string root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            if (new DirectoryInfo(root).Name == "net8.0-windows")
            {
                pathPart = "..\\..\\..\\" + pathPart; // in project directory
            }
            string path = Path.Combine(root, pathPart);
            return Path.GetFullPath(path);
        }

        List<List<List<int>>>? ScanEventsFile(EMEVD? emevd)
        {
            if (emevd == null)
            {
                Console.WriteLine("Null EMEVD");
                return null;
            }
            List<EMEVD.Event> events = emevd.Events;
            foreach (var @event in events)
            {
                //Console.WriteLine(@event.ID);
            }
            List<EMEVD.Event> settingsEvents = [.. events.Where(e => (int)e.ID == settingsEventId)];
            if (settingsEvents.Count == 0)
            {
                Console.WriteLine("Missing events. Could not process.");
                return null;
            }

            var currentSettings = new List<List<List<int>>>();

            foreach (EMEVD.Event @event in settingsEvents)
            {
                List<EMEVD.Instruction> instructions = @event.Instructions;
                foreach (EMEVD.Instruction instruction in instructions)
                {
                    int length = instruction.ArgData.Length;
                    if (length != 8)
                    {
                        continue;
                    }
                    ArgType[] argTypes = new ArgType[2];
                    Array.Fill(argTypes, ArgType.Int32);
                    List<object> args = instruction.UnpackArgs(argTypes);
                    if (args[0].ToString()!.Length == 8)
                    {
                        currentSettings.Add(new List<List<int>> { { [(int)args[0], (int)args[1]] } });
                    }
                }
            }
            return currentSettings;
        }

        void UpdateEventFile()
        {
            if (emevd == null)
            {
                return;
            }
            string bakFilePath = emevdPath + ".bak";
            if (!File.Exists(bakFilePath))
            {
                File.Copy(emevdPath, bakFilePath);
            }
            List<EMEVD.Event> events = emevd.Events;
            List<EMEVD.Event> settingsEvents = [.. events.Where(e => settingsEventId == (int)e.ID)];
            if (settingsEvents.Count != 1)
            {
                Console.WriteLine("Missing events. Could not process.");
                return;
            }

            List<List<int>> defaults = [];

            foreach (EMEVD.Event @event in settingsEvents)
            {
                //Console.WriteLine(@event.ID);
                List<EMEVD.Instruction> instructions = @event.Instructions;
                foreach (EMEVD.Instruction instruction in instructions)
                {
                    int length = instruction.ArgData.Length;
                    if (length != 8)
                    {
                        continue;
                    }
                    ArgType[] argTypes = new ArgType[2];
                    Array.Fill(argTypes, ArgType.Int32);
                    List<object> args = instruction.UnpackArgs(argTypes);
                    if (args[0].ToString()!.Length != 8)
                    {
                        continue;
                    }
                    //Console.WriteLine(args[0].ToString());
                    int eventFlag = (int)args[0];
                    Setting setting = settings.FirstOrDefault(s => s.PossibleValues.ContainsValue(eventFlag))!;
                    if (setting == null)
                    {
                        savedStatusLabel.Text = args.Count.ToString();
                        continue;
                    }
                    if (setting.ActivateOnly == true)
                    {
                        args[1] = setting.Value == "Enabled" ? 1 : 0;
                    }
                    else if (setting.PossibleValues.Count > 2 || setting.ForceRotate == true)
                    {
                        args[1] = setting.PossibleValues[setting.Value] == eventFlag ? 1 : 0;
                    }
                    else
                    {
                        int newDefault = setting.PossibleValues[setting.Value];
                        args[0] = newDefault;
                    }
                    instruction.PackArgs(args);
                }
            }

            foreach (Setting setting in settings)
            {
                if (setting.ActivateOnly == null)
                {
                    continue;
                }
            }

            emevd.Write(emevdPath);
        }

        void UpdateSettingsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            string settingsString = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(settingsPath, settingsString);
        }

        private void ResizeLabel()
        {
            int scrollbarWidth = settingDescriptionPanel.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0;
            settingDescriptionLabel.MaximumSize = new Size(settingDescriptionPanel.Width - scrollbarWidth, 0);
            settingDescriptionPanel.PerformLayout();
        }

        private void SettingDescriptionPanel_Resize(object sender, EventArgs e)
        {
            ResizeLabel();
        }

        private void BrowseEmevdPathButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "|common.emevd.dcx"
            };
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                emevdPathTextBox.Text = openFileDialog.FileName;
                emevdPath = openFileDialog.FileName;
                try
                {
                    emevd = EMEVD.Read(emevdPath);
                }
                catch (Exception)
                {
                    emevd = null;
                }
                LoadSettings();
            }
        }

        private void settingsFilterInput_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as TextBox)!.Text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                foreach (var setting in settings)
                {
                    setting.Panel.Visible = true;
                }
            }
            else
            {
                foreach (var setting in settings)
                {
                    setting.Panel.Visible = setting.Name.Contains(text, StringComparison.CurrentCultureIgnoreCase);
                }
            }
        }

        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            settingsFilterInput.Clear();
        }
    }

    class Setting
    {
        required public string Name { get; set; }
        required public string Description { get; set; }
        required public string Value { get; set; }
        required public Dictionary<string, int> PossibleValues { get; set; }
        public bool? ActivateOnly { get; set; }
        public bool? Hidden { get; set; }
        public bool? ForceRotate { get; set; } // act like PossibleValues has more than 2 values
        [JsonIgnore] public Panel Panel { get; set; }
    }
}
