using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListUp
{
    public class FileWriter : SingletonMonoBehaviour<FileWriter>
    {
        private int bufferSize;
        private string directory;
        private string extension;
        private string prefix;
        private string suffix;
        private string separator;

        protected override void OnUnityAwake()
        {
        }

        public void Init(int bufferSize, string directory, string extension, string prefix, string suffix, string separator)
        {
            this.bufferSize = bufferSize;
            this.directory = directory;
            this.extension = extension;
            this.prefix = prefix;
            this.suffix = suffix;
            this.separator = separator;
        }

        public void Write(string fileName, List<string> header, List<Dictionary<string, string>> values)
        {
            StringBuilder output = new StringBuilder(bufferSize);
            WriteHaeder(output, header);
            WriteValues(output, header, values);
            File.WriteAllText(directory + fileName + extension, output.ToString());
        }

        private void WriteHaeder(StringBuilder output, List<string> header)
        {
            output.Append(prefix);

            bool first = true;
            foreach (var item in header)
            {
                if (first) first = false;
                else output.Append(separator);
                output.Append(item);
            }

            output.Append(suffix);
        }

        private void WriteValues(StringBuilder output, List<string> header, List<Dictionary<string, string>> values)
        {
            foreach (var item in values)
            {
                WriteValue(output, header, item);
            }
        }

        private void WriteValue(StringBuilder output, List<string> header, Dictionary<string, string> value)
        {
            output.Append(prefix);

            bool first = true;
            foreach (var item in header)
            {
                if (first) first = false;
                else output.Append(separator);
                output.Append(value[item]);
            }

            output.Append(suffix);
        }
    }
}
