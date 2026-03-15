using IWshRuntimeLibrary;
using Microsoft.Win32;

using File = System.IO.File;

namespace InstalledSoftwareRadarApi.Services;

public class SoftwareScannerService
{
    public Dictionary<string, string> ScanAll()
    {
        var apps = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        ScanRegistry(apps);
        ScanStartMenu(apps);

        return apps.OrderBy(a => a.Key)
                   .ToDictionary(a => a.Key, a => a.Value);
    }

    private void ScanRegistry(Dictionary<string, string> apps)
    {
        string[] registryKeys =
        {
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
            @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
        };

        foreach (var keyPath in registryKeys)
        {
            using var key = Registry.LocalMachine.OpenSubKey(keyPath);
            if (key == null) continue;

            foreach (var subkeyName in key.GetSubKeyNames())
            {
                using var subkey = key.OpenSubKey(subkeyName);

                var name = subkey?.GetValue("DisplayName") as string;
                var icon = subkey?.GetValue("DisplayIcon") as string;
                var location = subkey?.GetValue("InstallLocation") as string;

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                string exe = null;

                if (!string.IsNullOrEmpty(icon))
                {
                    icon = icon.Split(',')[0];
                    if (icon.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) && File.Exists(icon))
                        exe = icon;
                }

                if (exe == null && !string.IsNullOrWhiteSpace(location) && Directory.Exists(location))
                    exe = FindBestExecutable(location);

                if (IsValidExecutable(exe))
                    apps.TryAdd(name, exe);
            }
        }
    }

    private void ScanStartMenu(Dictionary<string, string> apps)
    {
        string[] startMenus =
        {
            Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu),
            Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)
        };

        var shell = new WshShell();

        foreach (var startMenu in startMenus)
        {
            if (!Directory.Exists(startMenu)) continue;

            var options = new EnumerationOptions
            {
                RecurseSubdirectories = true,
                IgnoreInaccessible = true
            };

            var shortcuts = Directory.GetFiles(startMenu, "*.lnk", options);

            foreach (var shortcut in shortcuts)
            {
                try
                {
                    var link = (IWshShortcut)shell.CreateShortcut(shortcut);

                    if (IsValidExecutable(link.TargetPath))
                    {
                        var name = Path.GetFileNameWithoutExtension(shortcut);
                        apps.TryAdd(name, link.TargetPath);
                    }
                }
                catch { }
            }
        }
    }

    private string FindBestExecutable(string folder)
    {
        try
        {
            var files = Directory.GetFiles(folder, "*.exe");

            foreach (var exe in files)
            {
                var name = Path.GetFileName(exe).ToLower();

                if (name.Contains("unins") || name.Contains("uninstall")) continue;
                if (name.Contains("setup") || name.Contains("install")) continue;

                return exe;
            }
        }
        catch { }

        return null;
    }

    private bool IsValidExecutable(string exe)
    {
        if (string.IsNullOrWhiteSpace(exe)) return false;
        if (!File.Exists(exe)) return false;

        var lower = exe.ToLower();

        if (lower.Contains("unins") || lower.Contains("uninstall")) return false;
        if (lower.StartsWith(@"c:\windows")) return false;

        return lower.EndsWith(".exe");
    }
}
