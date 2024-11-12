using static rbest.dirtree.ops.Config;

namespace rbest
{
    internal class Program
    {
        public static string __name__    = "rbest";
        public static string __version__ = "0.0.1";

        public static string[] ImpFiles = rbest.dirtree.ops.project.ConfigFiles;

        static void Main(string[] args)
        {
            @out.put.cu_print("Welcome", $"{__name__}@{__version__}",ConsoleColor.White);

            if (args.Length <= 0)
            {
                

                foreach (string item in ImpFiles)
                {
                    if (!Directory.GetFiles(Environment.CurrentDirectory).Contains(item))
                    {
                        @out.put.ec_print($"file `{item}` not found!");
                    }
                }

            }

            ///
            ///
            ///
            ///
            ///


            if (args.Length > 0)
            {
                if (args[0].ToLower() == "help")
                {
                    List<string> HelpText = [
                    "help              : For this help message",
                    "new $name $type   : To create a new roobi project.",
                    "                   (req: $project_name , $project_type)",
                    "                   (type: `help new` for more info)",
                    "run               : Runs current project.",
                    "rm                : Removes current project.",
                    "                   (req: ?$project_dir)",
                    "                   (needs to be in the same dir as `rbest.config.json`)",
                    "                   (type: `rm $project_dir` to delete a proejct dir)"
                   ];

                    foreach (string item in HelpText)
                    {
                        @out.put.n_print(item);
                    }
                }
                else if (args[0].ToLower() == "new")
                {
                    string p_name = "";

                    if (args.Length > 1)
                    {
                        p_name = args[1];
                    }
                    else
                    {
                        Console.Write("\nProject Name: ");
                        p_name = Console.ReadLine();
                    }

                    dirtree.ops.project.Create(p_name);
                }
                else if (args[0].ToLower() == "rm")
                {
                    string p_name = "";

                    if (args.Length > 1)
                    {
                        p_name = args[1];
                    }
                    else
                    {
                        p_name = "#read-config";
                    }

                    dirtree.ops.project.Delete(p_name);
                }
                else if (args[0].ToLower() == "run")
                {

                }
                else
                {
                    @out.put.ec_print($"no such command `{args[0]}`, try typing `help`");
                }
            }
        }
    }
}
