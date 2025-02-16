using System;
using WixSharp;

namespace numfortune_setup
{
    internal class Program
    {
        static void Main()
        {
            var project = new Project("numfortune.Avalonia",
                              new Dir(@"[ProgramFiles64Folder]\\numfortune.Avalonia",
                                  new DirFiles(@"*.*"),
                                  new Dir("runtimes",
                                      new Dir("win-x64",
                                            new Dir("native",
                                                new File("runtimes\\win-x64\\native\\libHarfBuzzSharp.dll"),
                                                new File("runtimes\\win-x64\\native\\libSkiaSharp.dll")
                                            )
                                        )
                                    )
                        ),
                        new Dir(@"%ProgramMenu%",
                         new ExeFileShortcut("numfortune.Avalonia", "[ProgramFiles64Folder]\\numfortune.Avalonia\\numfortune.Desktop.exe", "") { WorkingDirectory = "[INSTALLDIR]" }
                      )//,
                       //new Property("ALLUSERS","0")
            );

            project.GUID = new Guid("90D24925-7418-48AD-9950-676C2F839B20");
            project.Version = new Version("2.0.3");
            project.Platform = Platform.x64;
            project.SourceBaseDir = "E:\\source\\numfortune.avalonia.new\\numfortune.Desktop\\bin\\Release\\net8.0";
            project.LicenceFile = "LICENSE.rtf";
            project.OutDir = "E:\\";
            project.ControlPanelInfo.Manufacturer = "Giulio Sorrentino";
            project.ControlPanelInfo.Name = "numerone's fortune in avalonia";
            project.ControlPanelInfo.HelpLink = "https://github.com/numerunix/numfortune.avalonia.new/issues";
            project.Description = "Una semplice fortune app per windows 10 e 11";
            //            project.Properties.SetValue("ALLUSERS", 0);
            project.BuildMsi();
        }
    }
}
