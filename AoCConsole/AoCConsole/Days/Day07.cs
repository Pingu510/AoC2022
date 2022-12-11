using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    /// <summary>
    /// --- Day 7: No Space Left On Device ---
    ///        Stepping hell part one?
    /// </summary>
    internal class Day07
    {
        private static int _maxFolderSize = 100000;
        private HashSet<FileModel> _sizedDirs;

        internal Day07()
        {
            Console.WriteLine("Day 7:");

            StarOne(InputHelper.GetInput("day07.txt")); // answer: 1844187
            StarTwo(InputHelper.GetInput("day07.txt")); // answer: 4978279
        }

        private void StarOne(string[] input)
        {
            _maxFolderSize = 100000;
            _sizedDirs = new HashSet<FileModel>();

            ConstructFileTree(input);

            double result = 0;
            foreach (var dir in _sizedDirs)
            {
                result += dir.TotalDirSize;
            }

            Console.WriteLine("Dir count: " + _sizedDirs.Count); // 30
            Console.WriteLine("Dir sum: " + result);
        }

        private FileModel ConstructFileTree(string[] input)
        {
            FileModel _root = new FileModel() { Name = "/", SubFiles = new HashSet<FileModel>(), IsDir = true };
            FileModel _currentPosition = _root;

            // Construct filetree
            foreach (var row in input)
            {
                var line = row.Split();

                // is command
                if (line[0] == "$")
                {
                    if (line[1] == "ls")
                    {
                        continue;
                    }
                    else if (line[2] == "..")
                    {
                        _currentPosition = _currentPosition.Parent ?? _root;
                    }
                    else if (line[2] == "/")
                    {
                        _currentPosition = _root;
                    }
                    else
                    {
                        //find child dir                           
                        _currentPosition = _currentPosition.SubFiles.First(x => x.Name == line[2]);
                    }
                }
                else // is dir or file
                {
                    var file = new FileModel()
                    {
                        Name = line[1],
                        Parent = _currentPosition
                    };

                    // add under currentPosition
                    if (line[0] == "dir")
                    {
                        file.IsDir = true;
                        file.SubFiles = new HashSet<FileModel>();
                        _sizedDirs.Add(file);
                    }
                    else
                    {
                        file.Size = double.Parse(line[0]);
                        AddSizeToParent(_currentPosition, (double)file.Size);
                    }

                    _currentPosition.SubFiles.Add(file);
                }
            }

            return _root;
        }

        private void AddSizeToParent(FileModel parent, double filesize)
        {
            if (parent == null)
            {
                return;
            }

            parent.TotalDirSize += filesize;

            if (parent.TotalDirSize > _maxFolderSize)
            {
                _sizedDirs.Remove(parent);
            }
            AddSizeToParent(parent.Parent, filesize);
        }
        
        private void StarTwo(string[] input)
        {
            string result = "";
            int nessecaryDiskSpace = 30000000;
            int totalDiskSize = 70000000;

            _sizedDirs = new HashSet<FileModel>();
            _maxFolderSize = int.MaxValue;

            var root = ConstructFileTree(input);
            double minFolderSize = nessecaryDiskSpace - (totalDiskSize - root.TotalDirSize);

            var orderdDir = _sizedDirs.Where(x => x.IsDir && x.TotalDirSize > minFolderSize).OrderBy(x => x.TotalDirSize);

            var dirToDel = orderdDir.First(x => x.TotalDirSize >= minFolderSize);

            Console.WriteLine("Result: " + dirToDel.TotalDirSize);
        }
    }

    internal class FileModel
    {
        public string Name { get; set; } = string.Empty;
        public bool IsDir { get; set; } = false;
        public double TotalDirSize { get; set; } = 0;
        public double Size { get; set; } = 0;
        public FileModel? Parent { get; set; } = null;
        public HashSet<FileModel>? SubFiles { get; set; } = new HashSet<FileModel>();
    }
}
