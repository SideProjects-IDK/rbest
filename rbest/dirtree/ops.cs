using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using static rbest.dirtree.ops;

namespace rbest.dirtree
{
    public class ops
    {
        public class project
        {
            public static readonly string[] ConfigFiles = {
                "rbest.config.json",
                "rbest.lang.config.json",
                "rbest.lang.require.paths.json",
                "rbest.package.json",
                "rbest.vin.config.json",
                "rbest.system.config.json"
            };

            public static void Create(string projectName)
            {
                string projectDirectory = Path.Combine(Environment.CurrentDirectory, projectName);

                if (Directory.Exists(projectDirectory))
                {
                    @out.put.ec_print($"`{projectName}` already exists in `{projectDirectory}`");
                    return;
                }


                Console.Write("\nAuthor: ");
                string AuthoName = Console.ReadLine();
                Console.Write("Author: Github: Username: ");
                string AuthoGithubLine = Console.ReadLine();
                Console.Write("\n");

                @out.put.cu_print("Directory", $"Creating directory `{projectName}` in `{Environment.CurrentDirectory}`", ConsoleColor.Cyan);
                Directory.CreateDirectory(projectDirectory);

                foreach (var file in ConfigFiles)
                {
                    string filePath = Path.Combine(projectDirectory, file);
                    @out.put.cu_print("File", $"Creating file `{file}` in `{projectDirectory}`", ConsoleColor.Cyan);

                    switch (file)
                    {
                        case "rbest.config.json":
                            var rbestConfigJson = new Config.FileSyntax.RbestConfigJson
                            {
                                VinCompatable = true,
                                NuCompatable = true,
                                VinSettings = new Config.FileSyntax.RbestConfigJson.Vin
                                {
                                    AdminUser = "root"
                                }
                            };
                            File.WriteAllText(filePath, JsonSerializer.Serialize(rbestConfigJson, new JsonSerializerOptions { WriteIndented = true }));
                            break;

                        case "rbest.lang.config.json":
                            var rbestLangConfigJson = new Config.FileSyntax.RbestLangConfigJson
                            {
                                Lang = "roobi",
                                Roobi = new Config.FileSyntax.RbestLangConfigJson.RoobiSettings
                                {
                                    Version = GetRubyVersion(),
                                    Platform = GetPlatform(),
                                },
                                Require = new Config.FileSyntax.RbestLangConfigJson.RequireSettings
                                {
                                    Files = new Config.FileSyntax.RbestLangConfigJson.RequireSettings.RequireFiles
                                    {
                                        Main = ""+projectDirectory+"rbest.lang.require.paths.json"
                                    }
                                }
                            };
                            File.WriteAllText(filePath, JsonSerializer.Serialize(rbestLangConfigJson, new JsonSerializerOptions { WriteIndented = true }));
                            break;

                        case "rbest.lang.require.paths.json":
                            var rbestLangRequirePathsJson = new Config.FileSyntax.RbestLangRequirePathsJson
                            {
                                Paths = 
                                [
                                    new Config.FileSyntax.RbestLangRequirePathsJson.RequirePath { Alias = "@main", Path = ""+projectDirectory+"main" },
                                    new Config.FileSyntax.RbestLangRequirePathsJson.RequirePath { Alias = "@libs", Path = ""+projectDirectory+"libs" }
                                ]
                            };
                            File.WriteAllText(filePath, JsonSerializer.Serialize(rbestLangRequirePathsJson, new JsonSerializerOptions { WriteIndented = true }));
                            break;

                        case "rbest.package.json":
                            var rbestPackageJson = new Config.FileSyntax.RbestPackageJson
                            {
                                ProjectName = projectName,
                                ProjectLocation = ""+projectDirectory+"",
                                ProjectConf = new Config.FileSyntax.RbestPackageJson.ProjectConfig
                                {
                                    Vin = ""+projectDirectory+"rbest.vin.config.json",
                                    Sys = ""+projectDirectory+"rbest.system.config.json"
                                },
                                ProjectMain = new Config.FileSyntax.RbestPackageJson.ProjectMainClass
                                {
                                    Scripts = new Config.FileSyntax.RbestPackageJson.ProjectMainClass.ScriptsClass
                                    {
                                        Main = ""+projectDirectory+"main\\main.rb"
                                    },
                                    Dependencies = new Config.FileSyntax.RbestPackageJson.ProjectMainClass.DependenciesClass
                                    {
                                        Local = new Config.FileSyntax.RbestPackageJson.ProjectMainClass.DependenciesClass.LocalDependencies
                                        {
                                            Helper = ""+projectDirectory+"main\\helper.rb"
                                        },
                                        Jems = new Dictionary<string, string>()
                                    }
                                },
                                ProjectAuthor = new Config.FileSyntax.RbestPackageJson.ProjectAuthorClass
                                {
                                    Name = AuthoName,
                                    GitHub = $"github.com/{AuthoGithubLine}"
                                },
                                ProjectPublish = new Config.FileSyntax.RbestPackageJson.ProjectPublishClass
                                {
                                    License = "MIT",
                                    Copyright = AuthoName
                                }
                            };
                            File.WriteAllText(filePath, JsonSerializer.Serialize(rbestPackageJson, new JsonSerializerOptions { WriteIndented = true }));
                            break;

                        case "rbest.vin.config.json":
                            var rbestVinConfigJson = new Config.FileSyntax.RbestVinConfigJson
                            {
                                ShellCodes =
                                [
                                    "28347f-t8y47-yr8d-t8y5f73",
                                    "94a32c-17y83-4d5t-8y6f83",
                                    "11f45a-98y62-4c5d-7y3f21",
                                    "67d21c-85y39-2d4t-1y9f45",
                                    "43f65c-22y17-8d5t-6y2f19",
                                    "98c21a-75y46-3c5d-4y8f22",
                                    "14f32a-39y83-2d5t-7y1f65",
                                    "73d42c-16y59-1c5d-9y3f18",
                                    "28f65a-82y47-4d5t-6y2f11",
                                    "59c31a-25y39-8d5t-3y9f46",
                                    "92f42c-11y62-2c5d-7y4f23",
                                    "17f53a-48y17-1d5t-8y6f14",
                                    "35c21a-69y83-4c5d-2y3f27",
                                    "46f32c-22y59-3d5t-9y1f38",
                                    "83d19a-95y46-2d5t-6y2f41"
                                ]
                            };
                            File.WriteAllText(filePath, JsonSerializer.Serialize(rbestVinConfigJson, new JsonSerializerOptions { WriteIndented = true }));
                            break;

                        case "rbest.system.config.json":
                            var rbestSystemConfigJson = new Config.FileSyntax.RbestSystemConfigJson
                            {
                                OS = new Config.FileSyntax.RbestSystemConfigJson.OSClass
                                {
                                    Name = Environment.OSVersion.Platform.ToString(),
                                    Version = Environment.OSVersion.Version.ToString()
                                }
                            };
                            File.WriteAllText(filePath, JsonSerializer.Serialize(rbestSystemConfigJson, new JsonSerializerOptions { WriteIndented = true }));
                            break;
                    }
                }
            }

            private static string GetRubyVersion()
            {
                try
                {
                    Process process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "ruby",
                            Arguments = "-v",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        }
                    };

                    process.Start();
                    string output = process.StandardOutput.ReadLine();
                    process.WaitForExit();

                    ///// Example output: "ruby 2.7.2p137 (2020-10-01 revision 5445e04352) [x64-mingw32]"
                    return output.Split(' ')[1]; ///// Extract version number (e.g., "2.7.2")
                }
                catch (Exception)
                {
                    return "Ruby not found";
                }
            }

            private static string GetPlatform()
            {
                return Environment.OSVersion.Platform.ToString(); ///// Returns "Win32NT" for Windows, etc.
            }

            public static void Delete(string projectName)
            {
                if (projectName == "#read-config")
                {
                    ///// READ CONFIG FILE FOR CURRENT PROEJCT NAME AND DELETE IT
                }
                else
                {
                    ///// Delete the project directory
                }
            }

            public static void Run()
            {
                ///// Implement project running logic
            }
        }

        public class Config
        {
            public class FileSyntax
            {
                public class RbestConfigJson
                {
                    public bool VinCompatable { get; set; } = true;
                    public bool NuCompatable { get; set; } = true;
                    public Vin VinSettings { get; set; } = new Vin();

                    public class Vin
                    {
                        public string AdminUser { get; set; } = "root";
                    }
                }

                public class RbestLangConfigJson
                {
                    public string Lang { get; set; } = "roobi";
                    public RoobiSettings Roobi { get; set; } = new RoobiSettings();
                    public RequireSettings Require { get; set; } = new RequireSettings();

                    public class RoobiSettings
                    {
                        public string Version { get; set; } = GetRubyVersion();
                        public string Platform { get; set; } = GetPlatform();

                        private static string GetRubyVersion()
                        {
                            try
                            {
                                Process process = new Process
                                {
                                    StartInfo = new ProcessStartInfo
                                    {
                                        FileName = "ruby",
                                        Arguments = "-v",
                                        RedirectStandardOutput = true,
                                        UseShellExecute = false,
                                        CreateNoWindow = true
                                    }
                                };

                                process.Start();
                                string output = process.StandardOutput.ReadLine();
                                process.WaitForExit();

                                ///// Example output: "ruby 2.7.2p137 (2020-10-01 revision 5445e04352) [x64-mingw32]"
                                return output.Split(' ')[1]; ///// Extract version number (e.g., "2.7.2")
                            }
                            catch (Exception)
                            {
                                return "Ruby not found";
                            }
                        }

                        private static string GetPlatform()
                        {
                            return Environment.OSVersion.Platform.ToString(); ///// Returns "Win32NT" for Windows, etc.
                        }
                    }

                    public class RequireSettings
                    {
                        public RequireFiles Files { get; set; } = new RequireFiles();

                        public class RequireFiles
                        {
                            public string Main { get; set; } = "./rbest.lang.require.paths.json";
                        }
                    }
                }

                public class RbestLangRequirePathsJson
                {
                    public List<RequirePath> Paths { get; set; } = new List<RequirePath>
                    {
                        new RequirePath { Alias = "@main", Path = "./main" },
                        new RequirePath { Alias = "@libs", Path = "./libs" }
                    };

                    public class RequirePath
                    {
                        public string Alias { get; set; }
                        public string Path { get; set; }
                    }
                }

                public class RbestPackageJson
                {
                    public string ProjectName { get; set; } = "$your-project-name";
                    public string ProjectLocation { get; set; } = "./";
                    public ProjectConfig ProjectConf { get; set; } = new ProjectConfig();
                    public ProjectMainClass ProjectMain { get; set; } = new ProjectMainClass();
                    public ProjectAuthorClass ProjectAuthor { get; set; } = new ProjectAuthorClass();
                    public ProjectPublishClass ProjectPublish { get; set; } = new ProjectPublishClass();

                    public class ProjectConfig
                    {
                        public string Vin { get; set; } = "./rbest.vin.config.json";
                        public string Sys { get; set; } = "./rbest.system.config.json";
                    }

                    public class ProjectMainClass
                    {
                        public ScriptsClass Scripts { get; set; } = new ScriptsClass();
                        public DependenciesClass Dependencies { get; set; } = new DependenciesClass();

                        public class ScriptsClass
                        {
                            public string Main { get; set; } = "./main/main.rb";
                        }

                        public class DependenciesClass
                        {
                            public LocalDependencies Local { get; set; } = new LocalDependencies();
                            public Dictionary<string, string> Jems { get; set; } = new Dictionary<string, string>();

                            public class LocalDependencies
                            {
                                public string Helper { get; set; } = "./main/helper.rb";
                            }
                        }
                    }

                    public class ProjectAuthorClass
                    {
                        public string Name { get; set; }
                        public string GitHub { get; set; }
                    }

                    public class ProjectPublishClass
                    {
                        public string License { get; set; } = "MIT";
                        public string Copyright { get; set; }
                    }
                }

                public class RbestVinConfigJson
                {
                    public List<string> ShellCodes { get; set; } = new List<string>
                    {
                        "28347f-t8y47-yr8d-t8y5f73",
                        "94a32c-17y83-4d5t-8y6f83",
                        "11f45a-98y62-4c5d-7y3f21",
                        "67d21c-85y39-2d4t-1y9f45",
                        "43f65c-22y17-8d5t-6y2f19",
                        "98c21a-75y46-3c5d-4y8f22",
                        "14f32a-39y83-2d5t-7y1f65",
                        "73d42c-16y59-1c5d-9y3f18",
                        "28f65a-82y47-4d5t-6y2f11",
                        "59c31a-25y39-8d5t-3y9f46",
                        "92f42c-11y62-2c5d-7y4f23",
                        "17f53a-48y17-1d5t-8y6f14",
                        "35c21a-69y83-4c5d-2y3f27",
                        "46f32c-22y59-3d5t-9y1f38",
                        "83d19a-95y46-2d5t-6y2f41"
                    };
                }

                public class RbestSystemConfigJson
                {
                    public OSClass OS { get; set; } = new OSClass();

                    public class OSClass
                    {
                        public string Name { get; set; } = "$current-os-name";
                        public string Version { get; set; } = "$current-os-version";
                    }
                }
            }
        }
    }
}